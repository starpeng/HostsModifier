#region CopyRight
/**************************************************************
   Copyright (c) 2015 StarPeng. All rights reserved.
   CLR版本        :    4.0.30319.34209
   命名空间名称   :    $rootnamespace$
   文件名         :    Form1
   创建时间       :    2015-04-16 10:02:39
   用户所在的域   :    SWKJT410
   登录用户名     :    Star
   文件描述       :    
   版本           :    1.0.0
   历史           :    
   最后更新人     :   
   最后更新时间   :   
 **************************************************************/
#endregion CopyRight

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace HostsModifier
{
    public partial class MainForm : Form
    {
        private static String _url = "https://hosts-smounives.rhcloud.com/hosts";
        private static String _path = "C:\\Windows\\System32\\drivers\\etc\\hosts";
        private Thread _thread = null;
        private System.Timers.Timer _timer = new System.Timers.Timer(40 * 1000);

        public MainForm()
        {
            InitializeComponent();
            _timer.AutoReset = false;
            _timer.Enabled = false;
            _timer.Elapsed += TimeOut;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (_thread != null)
            {
                return;
            }

            _thread = new Thread(new ThreadStart(DoUpdate));
            _thread.Start();
            _timer.Enabled = true;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (!IsAdministrator())
            {
                panelUAC.Dock = DockStyle.Fill;
                panelUAC.BringToFront();
                panelUAC.Visible = true;
            }
            else
            {
                if (Environment.OSVersion.Version.Major >= 6)
                {
                    this.Text += "(管理员)";
                }
            }

            MakeWriteable(_path);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (_thread != null && _thread.IsAlive)
            {
                try
                {
                    _thread.Abort();
                }
                catch { }
            }
        }

        private void btnStartWithAdmin_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo();
            processStartInfo.WorkingDirectory = Application.StartupPath;
            processStartInfo.FileName = Path.GetFileName(Application.ExecutablePath);
            processStartInfo.Verb = "runas";
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
            {
                String text = "";
                for (Int32 i = 1; i < commandLineArgs.Length; i++)
                {
                    text += commandLineArgs[i];
                }
                processStartInfo.Arguments = text;
            }
            try
            {
                Process.Start(processStartInfo);
                this.Close();
            }
            catch
            {
                this.Close();
            }
        }

        private void DoUpdate()
        {
            try
            {
                this.SafeInvoke(() => { this.btnUpdate.Text = "正在更新..."; });
                var req = (HttpWebRequest)WebRequest.Create(_url);
                req.ServicePoint.Expect100Continue = false;
                req.Method = "GET";
                req.KeepAlive = true;
                req.UserAgent = "HostsModifier V1.0 by StarPeng";
                req.Timeout = 30 * 1000;

                // 以字符流的方式读取HTTP响应
                using (var rsp = (HttpWebResponse)req.GetResponse())
                {
                    var encoding = Encoding.GetEncoding(rsp.CharacterSet);
                    using (var stream = rsp.GetResponseStream())
                    using (var reader = new StreamReader(stream, encoding))
                    {
                        var content = reader.ReadToEnd();
                        File.WriteAllText(_path, content, Encoding.UTF8);
                        MessageBox.Show("更新成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (ThreadAbortException) { }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _thread = null;
                _timer.Enabled = false;
                this.SafeInvoke(() => { this.btnUpdate.Text = "更新到最新"; });
            }
        }

        void TimeOut(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (_thread != null && _thread.IsAlive)
            {
                if (MessageBox.Show("Oops！看起来超时了！是否停止！", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    try
                    {
                        _thread.Abort();
                    }
                    catch { }
                }
                else
                {
                    _timer.Start();
                }
            }
        }

        public static Boolean IsAdministrator()
        {
            Boolean result;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                WindowsIdentity current = WindowsIdentity.GetCurrent();
                WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
                result = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            else
            {
                result = true;
            }

            return result;
        }

        private static void MakeWriteable(String fileName)
        {
            if (File.Exists(fileName))
            {
                FileSystemInfo info = new FileInfo(fileName);
                if (info != null)
                    info.Attributes &= ~FileAttributes.ReadOnly;
            }
        }
    }

    public static class ControlExtention
    {
        public delegate void InvokeHandler();

        public static void SafeInvoke(this Control control, InvokeHandler handler)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(handler);
            }
            else
            {
                handler();
            }
        }
    }
}
