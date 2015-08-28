namespace SG.Server.Host
{
    partial class frmHost
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHost));
            this.btStop = new System.Windows.Forms.Button();
            this.lbSt = new System.Windows.Forms.Label();
            this.btStart = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItem_Show = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Hide = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItem_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(161, 68);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 5;
            this.btStop.Text = "停止";
            this.btStop.UseVisualStyleBackColor = true;
            // 
            // lbSt
            // 
            this.lbSt.AutoSize = true;
            this.lbSt.Location = new System.Drawing.Point(97, 141);
            this.lbSt.Name = "lbSt";
            this.lbSt.Size = new System.Drawing.Size(41, 12);
            this.lbSt.TabIndex = 4;
            this.lbSt.Text = "label1";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(50, 68);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 3;
            this.btStart.Text = "启动";
            this.btStart.UseVisualStyleBackColor = true;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItem_Show,
            this.menuItem_Hide,
            this.menuItem_Exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 70);
            // 
            // menuItem_Show
            // 
            this.menuItem_Show.Name = "menuItem_Show";
            this.menuItem_Show.Size = new System.Drawing.Size(100, 22);
            this.menuItem_Show.Text = "显示";
            // 
            // menuItem_Hide
            // 
            this.menuItem_Hide.Name = "menuItem_Hide";
            this.menuItem_Hide.Size = new System.Drawing.Size(100, 22);
            this.menuItem_Hide.Text = "隐藏";
            // 
            // menuItem_Exit
            // 
            this.menuItem_Exit.Name = "menuItem_Exit";
            this.menuItem_Exit.Size = new System.Drawing.Size(100, 22);
            this.menuItem_Exit.Text = "退出";
            // 
            // frmHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.lbSt);
            this.Controls.Add(this.btStart);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmHost";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "WCF服务";
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.Label lbSt;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Show;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Hide;
        private System.Windows.Forms.ToolStripMenuItem menuItem_Exit;
    }
}

