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

namespace HostsModifier
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panelUAC = new System.Windows.Forms.Panel();
            this.lbUAC = new System.Windows.Forms.Label();
            this.btnStartWithAdmin = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panelUAC.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelUAC
            // 
            this.panelUAC.Controls.Add(this.lbUAC);
            this.panelUAC.Controls.Add(this.btnStartWithAdmin);
            this.panelUAC.Location = new System.Drawing.Point(168, 260);
            this.panelUAC.Name = "panelUAC";
            this.panelUAC.Size = new System.Drawing.Size(346, 254);
            this.panelUAC.TabIndex = 6;
            this.panelUAC.Visible = false;
            // 
            // lbUAC
            // 
            this.lbUAC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbUAC.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lbUAC.Location = new System.Drawing.Point(83, 35);
            this.lbUAC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbUAC.Name = "lbUAC";
            this.lbUAC.Size = new System.Drawing.Size(199, 30);
            this.lbUAC.TabIndex = 2;
            this.lbUAC.Text = "需要管理员权限权限";
            this.lbUAC.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStartWithAdmin
            // 
            this.btnStartWithAdmin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartWithAdmin.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartWithAdmin.Location = new System.Drawing.Point(14, 95);
            this.btnStartWithAdmin.Name = "btnStartWithAdmin";
            this.btnStartWithAdmin.Size = new System.Drawing.Size(322, 41);
            this.btnStartWithAdmin.TabIndex = 0;
            this.btnStartWithAdmin.Text = "以管理员方式重新运行";
            this.btnStartWithAdmin.UseVisualStyleBackColor = true;
            this.btnStartWithAdmin.Click += new System.EventHandler(this.btnStartWithAdmin_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUpdate.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnUpdate.Location = new System.Drawing.Point(73, 64);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(207, 68);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "更新为最新";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 212);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.panelUAC);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(370, 250);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hosts文件更新";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelUAC.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelUAC;
        private System.Windows.Forms.Label lbUAC;
        private System.Windows.Forms.Button btnStartWithAdmin;
        private System.Windows.Forms.Button btnUpdate;
    }
}
