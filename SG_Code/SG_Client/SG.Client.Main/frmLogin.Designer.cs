namespace SG.Client.Main
{
    partial class frmLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.timer1 = new System.Windows.Forms.Timer();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.cmbOrg = new DevExpress.XtraEditors.LookUpEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbDataset = new DevExpress.XtraEditors.LookUpEdit();
            this.label8 = new System.Windows.Forms.Label();
            this.rdCard = new System.Windows.Forms.RadioButton();
            this.rdUser = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pcInputArea = new DevExpress.XtraEditors.PanelControl();
            this.btnModifyPwd = new System.Windows.Forms.LinkLabel();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.chkSaveLoginInfo = new DevExpress.XtraEditors.CheckEdit();
            this.txtCardNo = new DevExpress.XtraEditors.TextEdit();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.lblLoadingInfo = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrg.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataset.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInputArea)).BeginInit();
            this.pcInputArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveLoginInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.cmbOrg);
            this.panelControl1.Controls.Add(this.label3);
            this.panelControl1.Controls.Add(this.cmbDataset);
            this.panelControl1.Controls.Add(this.label8);
            this.panelControl1.Location = new System.Drawing.Point(198, 85);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(268, 60);
            this.panelControl1.TabIndex = 229;
            // 
            // cmbOrg
            // 
            this.cmbOrg.Location = new System.Drawing.Point(71, 5);
            this.cmbOrg.Name = "cmbOrg";
            this.cmbOrg.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOrg.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FNUMBER", 100, "帐套编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FNAME", 200, "帐套名称")});
            this.cmbOrg.Properties.NullText = "";
            this.cmbOrg.Properties.PopupWidth = 300;
            this.cmbOrg.Size = new System.Drawing.Size(191, 20);
            this.cmbOrg.TabIndex = 230;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 14);
            this.label3.TabIndex = 229;
            this.label3.Text = "组织机构：";
            // 
            // cmbDataset
            // 
            this.cmbDataset.Location = new System.Drawing.Point(71, 37);
            this.cmbDataset.Name = "cmbDataset";
            this.cmbDataset.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbDataset.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FNUMBER", 100, "帐套编号"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("FNAME", 200, "帐套名称")});
            this.cmbDataset.Properties.NullText = "";
            this.cmbDataset.Properties.PopupWidth = 300;
            this.cmbDataset.Size = new System.Drawing.Size(191, 20);
            this.cmbDataset.TabIndex = 228;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(25, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 14);
            this.label8.TabIndex = 20;
            this.label8.Text = "帐套：";
            // 
            // rdCard
            // 
            this.rdCard.AutoSize = true;
            this.rdCard.Location = new System.Drawing.Point(333, 60);
            this.rdCard.Name = "rdCard";
            this.rdCard.Size = new System.Drawing.Size(73, 18);
            this.rdCard.TabIndex = 26;
            this.rdCard.TabStop = true;
            this.rdCard.Text = "刷卡登陆";
            this.rdCard.UseVisualStyleBackColor = true;
            // 
            // rdUser
            // 
            this.rdUser.AutoSize = true;
            this.rdUser.Location = new System.Drawing.Point(226, 60);
            this.rdUser.Name = "rdUser";
            this.rdUser.Size = new System.Drawing.Size(85, 18);
            this.rdUser.TabIndex = 25;
            this.rdUser.TabStop = true;
            this.rdUser.Text = "用户名登陆";
            this.rdUser.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::SG.Client.Main.Properties.Resources.login_bk2;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(162, 348);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pcInputArea
            // 
            this.pcInputArea.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcInputArea.Controls.Add(this.btnModifyPwd);
            this.pcInputArea.Controls.Add(this.txtUser);
            this.pcInputArea.Controls.Add(this.label1);
            this.pcInputArea.Controls.Add(this.txtPwd);
            this.pcInputArea.Controls.Add(this.label2);
            this.pcInputArea.Controls.Add(this.chkSaveLoginInfo);
            this.pcInputArea.Controls.Add(this.txtCardNo);
            this.pcInputArea.Controls.Add(this.lblInfo);
            this.pcInputArea.Location = new System.Drawing.Point(198, 145);
            this.pcInputArea.Name = "pcInputArea";
            this.pcInputArea.Size = new System.Drawing.Size(268, 96);
            this.pcInputArea.TabIndex = 24;
            // 
            // btnModifyPwd
            // 
            this.btnModifyPwd.AutoSize = true;
            this.btnModifyPwd.ForeColor = System.Drawing.Color.RoyalBlue;
            this.btnModifyPwd.LinkColor = System.Drawing.Color.RoyalBlue;
            this.btnModifyPwd.Location = new System.Drawing.Point(203, 69);
            this.btnModifyPwd.Name = "btnModifyPwd";
            this.btnModifyPwd.Size = new System.Drawing.Size(43, 14);
            this.btnModifyPwd.TabIndex = 229;
            this.btnModifyPwd.TabStop = true;
            this.btnModifyPwd.Text = "改密码";
            this.btnModifyPwd.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnModifyPwd_LinkClicked);
            // 
            // txtUser
            // 
            this.txtUser.EditValue = "";
            this.txtUser.Location = new System.Drawing.Point(71, 10);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(191, 20);
            this.txtUser.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 1;
            this.label1.Text = "用户名：";
            // 
            // txtPwd
            // 
            this.txtPwd.EditValue = "";
            this.txtPwd.Location = new System.Drawing.Point(71, 40);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(191, 20);
            this.txtPwd.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "密码：";
            // 
            // chkSaveLoginInfo
            // 
            this.chkSaveLoginInfo.Location = new System.Drawing.Point(53, 67);
            this.chkSaveLoginInfo.Name = "chkSaveLoginInfo";
            this.chkSaveLoginInfo.Properties.Caption = "保存登录信息";
            this.chkSaveLoginInfo.Size = new System.Drawing.Size(104, 19);
            this.chkSaveLoginInfo.TabIndex = 17;
            // 
            // txtCardNo
            // 
            this.txtCardNo.Location = new System.Drawing.Point(18, 9);
            this.txtCardNo.Name = "txtCardNo";
            this.txtCardNo.Properties.PasswordChar = '*';
            this.txtCardNo.Size = new System.Drawing.Size(244, 20);
            this.txtCardNo.TabIndex = 230;
            this.txtCardNo.Visible = false;
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblInfo.Location = new System.Drawing.Point(15, 37);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(247, 23);
            this.lblInfo.TabIndex = 231;
            this.lblInfo.Text = "请刷卡。。。";
            this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInfo.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(361, 297);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 27);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消 (&C)";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(262, 297);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(93, 27);
            this.btnLogin.TabIndex = 14;
            this.btnLogin.Text = "登录 (&L)";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblLoadingInfo
            // 
            this.lblLoadingInfo.AutoSize = true;
            this.lblLoadingInfo.ForeColor = System.Drawing.Color.DodgerBlue;
            this.lblLoadingInfo.Location = new System.Drawing.Point(178, 270);
            this.lblLoadingInfo.Name = "lblLoadingInfo";
            this.lblLoadingInfo.Size = new System.Drawing.Size(67, 14);
            this.lblLoadingInfo.TabIndex = 12;
            this.lblLoadingInfo.Text = "准备就绪...";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SG.Client.Main.Properties.Resources._2009011340768021;
            this.pictureBox2.Location = new System.Drawing.Point(208, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(247, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(144, 14);
            this.label6.TabIndex = 10;
            this.label6.Text = "用户登陆(User Login)";
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(178, 289);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(304, 2);
            this.label5.TabIndex = 9;
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 348);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.rdCard);
            this.Controls.Add(this.rdUser);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pcInputArea);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.lblLoadingInfo);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "系统登录";
            this.Load += new System.EventHandler(this.frmLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOrg.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbDataset.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcInputArea)).EndInit();
            this.pcInputArea.ResumeLayout(false);
            this.pcInputArea.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkSaveLoginInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCardNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lblLoadingInfo;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.CheckEdit chkSaveLoginInfo;
        private System.Windows.Forms.Label label8;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.PanelControl pcInputArea;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.LookUpEdit cmbDataset;
        private System.Windows.Forms.LinkLabel btnModifyPwd;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LookUpEdit cmbOrg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton rdCard;
        private System.Windows.Forms.RadioButton rdUser;
        private DevExpress.XtraEditors.TextEdit txtCardNo;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Timer timer1;
    }
}