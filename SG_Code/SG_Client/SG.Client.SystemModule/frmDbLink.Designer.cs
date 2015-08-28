namespace SG.Client.SystemModule
{
    partial class frmDbLink
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
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colServerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataBase = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUsername = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreateDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcDetailEditor = new DevExpress.XtraEditors.GroupControl();
            this.txtPwd = new DevExpress.XtraEditors.TextEdit();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.txtServer = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.txtNum = new DevExpress.XtraEditors.TextEdit();
            this.lookUpDataBase = new DevExpress.XtraEditors.LookUpEdit();
            this.txtDbType = new DevExpress.XtraEditors.LookUpEdit();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labAccount = new System.Windows.Forms.Label();
            this.tpSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetailEditor)).BeginInit();
            this.gcDetailEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDataBase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDbType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Controls.Add(this.gcSummary);
            this.tpSummary.Size = new System.Drawing.Size(840, 484);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Size = new System.Drawing.Size(846, 513);
            // 
            // tcBusiness
            // 
            this.tcBusiness.Size = new System.Drawing.Size(846, 513);
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Controls.Add(this.gcDetailEditor);
            // 
            // gcNavigator
            // 
            this.gcNavigator.Size = new System.Drawing.Size(846, 26);
            // 
            // controlNavigatorSummary
            // 
            this.controlNavigatorSummary.Buttons.Append.Visible = false;
            this.controlNavigatorSummary.Buttons.CancelEdit.Visible = false;
            this.controlNavigatorSummary.Buttons.Edit.Visible = false;
            this.controlNavigatorSummary.Buttons.EndEdit.Visible = false;
            this.controlNavigatorSummary.Buttons.NextPage.Visible = false;
            this.controlNavigatorSummary.Buttons.PrevPage.Visible = false;
            this.controlNavigatorSummary.Buttons.Remove.Visible = false;
            this.controlNavigatorSummary.Location = new System.Drawing.Point(668, 2);
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Location = new System.Drawing.Point(471, 2);
            // 
            // gcSummary
            // 
            this.gcSummary.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcSummary.EmbeddedNavigator.Buttons.Append.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.Edit.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.NextPage.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.PrevPage.Visible = false;
            this.gcSummary.EmbeddedNavigator.Buttons.Remove.Visible = false;
            this.gcSummary.Location = new System.Drawing.Point(0, 0);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcSummary.Size = new System.Drawing.Size(840, 484);
            this.gcSummary.TabIndex = 8;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNumber,
            this.colName,
            this.colServerName,
            this.colDataBase,
            this.colDataType,
            this.colUsername,
            this.colCreateDate});
            this.gvSummary.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowAutoFilterRow = true;
            this.gvSummary.OptionsView.ShowFooter = true;
            // 
            // colNumber
            // 
            this.colNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.colNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNumber.Caption = "编号";
            this.colNumber.FieldName = "FNUMBER";
            this.colNumber.MinWidth = 40;
            this.colNumber.Name = "colNumber";
            this.colNumber.Visible = true;
            this.colNumber.VisibleIndex = 0;
            this.colNumber.Width = 150;
            // 
            // colName
            // 
            this.colName.AppearanceHeader.Options.UseTextOptions = true;
            this.colName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colName.Caption = "名称";
            this.colName.FieldName = "FNAME";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            this.colName.Width = 200;
            // 
            // colServerName
            // 
            this.colServerName.AppearanceHeader.Options.UseTextOptions = true;
            this.colServerName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colServerName.Caption = "服务器";
            this.colServerName.FieldName = "FSERVERNAME";
            this.colServerName.Name = "colServerName";
            this.colServerName.Visible = true;
            this.colServerName.VisibleIndex = 2;
            this.colServerName.Width = 110;
            // 
            // colDataBase
            // 
            this.colDataBase.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataBase.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataBase.Caption = "数据库";
            this.colDataBase.FieldName = "FDATABASE";
            this.colDataBase.Name = "colDataBase";
            this.colDataBase.Visible = true;
            this.colDataBase.VisibleIndex = 3;
            this.colDataBase.Width = 200;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "类型";
            this.colDataType.FieldName = "DBTYPE";
            this.colDataType.Name = "colDataType";
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 4;
            this.colDataType.Width = 200;
            // 
            // colUsername
            // 
            this.colUsername.AppearanceHeader.Options.UseTextOptions = true;
            this.colUsername.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colUsername.Caption = "配置用户";
            this.colUsername.FieldName = "FUSERNAME";
            this.colUsername.Name = "colUsername";
            this.colUsername.Visible = true;
            this.colUsername.VisibleIndex = 5;
            this.colUsername.Width = 91;
            // 
            // colCreateDate
            // 
            this.colCreateDate.AppearanceHeader.Options.UseTextOptions = true;
            this.colCreateDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colCreateDate.Caption = "配置时间";
            this.colCreateDate.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.colCreateDate.FieldName = "FCREATEDATE";
            this.colCreateDate.Name = "colCreateDate";
            this.colCreateDate.Visible = true;
            this.colCreateDate.VisibleIndex = 6;
            this.colCreateDate.Width = 151;
            // 
            // gcDetailEditor
            // 
            this.gcDetailEditor.Controls.Add(this.txtPwd);
            this.gcDetailEditor.Controls.Add(this.txtUserName);
            this.gcDetailEditor.Controls.Add(this.txtServer);
            this.gcDetailEditor.Controls.Add(this.txtName);
            this.gcDetailEditor.Controls.Add(this.txtNum);
            this.gcDetailEditor.Controls.Add(this.lookUpDataBase);
            this.gcDetailEditor.Controls.Add(this.txtDbType);
            this.gcDetailEditor.Controls.Add(this.label10);
            this.gcDetailEditor.Controls.Add(this.label6);
            this.gcDetailEditor.Controls.Add(this.label9);
            this.gcDetailEditor.Controls.Add(this.label5);
            this.gcDetailEditor.Controls.Add(this.label4);
            this.gcDetailEditor.Controls.Add(this.label8);
            this.gcDetailEditor.Controls.Add(this.label3);
            this.gcDetailEditor.Controls.Add(this.label7);
            this.gcDetailEditor.Controls.Add(this.label2);
            this.gcDetailEditor.Controls.Add(this.label1);
            this.gcDetailEditor.Controls.Add(this.labAccount);
            this.gcDetailEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetailEditor.Location = new System.Drawing.Point(0, 0);
            this.gcDetailEditor.Name = "gcDetailEditor";
            this.gcDetailEditor.Size = new System.Drawing.Size(776, 484);
            this.gcDetailEditor.TabIndex = 120;
            // 
            // txtPwd
            // 
            this.txtPwd.Location = new System.Drawing.Point(134, 252);
            this.txtPwd.Name = "txtPwd";
            this.txtPwd.Properties.PasswordChar = '*';
            this.txtPwd.Size = new System.Drawing.Size(208, 20);
            this.txtPwd.TabIndex = 112;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(134, 210);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(208, 20);
            this.txtUserName.TabIndex = 112;
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(134, 168);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(208, 20);
            this.txtServer.TabIndex = 112;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(134, 126);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(208, 20);
            this.txtName.TabIndex = 112;
            // 
            // txtNum
            // 
            this.txtNum.Location = new System.Drawing.Point(134, 84);
            this.txtNum.Name = "txtNum";
            this.txtNum.Size = new System.Drawing.Size(208, 20);
            this.txtNum.TabIndex = 112;
            // 
            // lookUpDataBase
            // 
            this.lookUpDataBase.Location = new System.Drawing.Point(134, 294);
            this.lookUpDataBase.Name = "lookUpDataBase";
            this.lookUpDataBase.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpDataBase.Properties.NullText = "";
            this.lookUpDataBase.Properties.PopupWidth = 180;
            this.lookUpDataBase.Size = new System.Drawing.Size(208, 20);
            this.lookUpDataBase.TabIndex = 111;
            // 
            // txtDbType
            // 
            this.txtDbType.Location = new System.Drawing.Point(134, 42);
            this.txtDbType.Name = "txtDbType";
            this.txtDbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDbType.Properties.NullText = "";
            this.txtDbType.Properties.PopupWidth = 180;
            this.txtDbType.Size = new System.Drawing.Size(208, 20);
            this.txtDbType.TabIndex = 105;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(348, 129);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 14);
            this.label10.TabIndex = 106;
            this.label10.Text = "*";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(348, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 14);
            this.label6.TabIndex = 106;
            this.label6.Text = "*";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(348, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 14);
            this.label9.TabIndex = 106;
            this.label9.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(348, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(14, 14);
            this.label5.TabIndex = 106;
            this.label5.Text = "*";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 297);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 14);
            this.label4.TabIndex = 104;
            this.label4.Text = "数据库:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(27, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 14);
            this.label8.TabIndex = 104;
            this.label8.Text = "名称:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 255);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 14);
            this.label3.TabIndex = 104;
            this.label3.Text = "口令:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(27, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 104;
            this.label7.Text = "编号:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 104;
            this.label2.Text = "用户名:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 14);
            this.label1.TabIndex = 104;
            this.label1.Text = "服务器:";
            // 
            // labAccount
            // 
            this.labAccount.AutoSize = true;
            this.labAccount.Location = new System.Drawing.Point(27, 45);
            this.labAccount.Name = "labAccount";
            this.labAccount.Size = new System.Drawing.Size(71, 14);
            this.labAccount.TabIndex = 104;
            this.labAccount.Text = "数据库类型:";
            // 
            // frmDbLink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 539);
            this.Name = "frmDbLink";
            this.Text = "数据库连接配置";
            this.tpSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetailEditor)).EndInit();
            this.gcDetailEditor.ResumeLayout(false);
            this.gcDetailEditor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPwd.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtServer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpDataBase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDbType.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colServerName;
        private DevExpress.XtraGrid.Columns.GridColumn colDataBase;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colUsername;
        private DevExpress.XtraGrid.Columns.GridColumn colCreateDate;
        private DevExpress.XtraEditors.GroupControl gcDetailEditor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labAccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private DevExpress.XtraEditors.LookUpEdit lookUpDataBase;
        private DevExpress.XtraEditors.LookUpEdit txtDbType;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraEditors.TextEdit txtNum;
        private DevExpress.XtraEditors.TextEdit txtServer;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtPwd;
        private DevExpress.XtraEditors.TextEdit txtUserName;
    }
}