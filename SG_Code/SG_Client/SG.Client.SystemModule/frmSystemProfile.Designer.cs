namespace SG.Client.SystemModule
{
    partial class frmSystemProfile
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
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcProfileClass = new DevExpress.XtraGrid.GridControl();
            this.gridProfileClass = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ClassName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splitContainerControl2 = new DevExpress.XtraEditors.SplitContainerControl();
            this.gcprofile = new DevExpress.XtraGrid.GridControl();
            this.gvprofile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gExplanation = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pcActions = new DevExpress.XtraEditors.PanelControl();
            this.pnlDetail = new DevExpress.XtraEditors.PanelControl();
            this.tpSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProfileClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfileClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).BeginInit();
            this.splitContainerControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcprofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvprofile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcActions)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).BeginInit();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Controls.Add(this.splitContainerControl1);
            this.tpSummary.Size = new System.Drawing.Size(773, 517);
            // 
            // pnlSummary
            // 
            this.pnlSummary.Size = new System.Drawing.Size(779, 546);
            // 
            // tcBusiness
            // 
            this.tcBusiness.Size = new System.Drawing.Size(779, 546);
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Controls.Add(this.pnlDetail);
            this.tpDetail.Size = new System.Drawing.Size(776, 484);
            this.tpDetail.Text = "此页隐藏";
            // 
            // gcNavigator
            // 
            this.gcNavigator.Size = new System.Drawing.Size(779, 26);
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
            this.controlNavigatorSummary.Location = new System.Drawing.Point(601, 2);
            // 
            // lblAboutInfo
            // 
            this.lblAboutInfo.Location = new System.Drawing.Point(404, 2);
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.gcProfileClass);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.splitContainerControl2);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(773, 517);
            this.splitContainerControl1.SplitterPosition = 146;
            this.splitContainerControl1.TabIndex = 0;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // gcProfileClass
            // 
            this.gcProfileClass.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcProfileClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProfileClass.Location = new System.Drawing.Point(0, 0);
            this.gcProfileClass.MainView = this.gridProfileClass;
            this.gcProfileClass.Name = "gcProfileClass";
            this.gcProfileClass.Size = new System.Drawing.Size(146, 517);
            this.gcProfileClass.TabIndex = 0;
            this.gcProfileClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProfileClass});
            // 
            // gridProfileClass
            // 
            this.gridProfileClass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ClassName});
            this.gridProfileClass.GridControl = this.gcProfileClass;
            this.gridProfileClass.Name = "gridProfileClass";
            this.gridProfileClass.OptionsBehavior.Editable = false;
            this.gridProfileClass.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridProfileClass.OptionsView.ShowAutoFilterRow = true;
            this.gridProfileClass.OptionsView.ShowFooter = true;
            this.gridProfileClass.OptionsView.ShowGroupPanel = false;
            // 
            // ClassName
            // 
            this.ClassName.AppearanceHeader.Options.UseTextOptions = true;
            this.ClassName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ClassName.Caption = "参数分类";
            this.ClassName.FieldName = "FCATEGORY";
            this.ClassName.Name = "ClassName";
            this.ClassName.Visible = true;
            this.ClassName.VisibleIndex = 0;
            // 
            // splitContainerControl2
            // 
            this.splitContainerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerControl2.FixedPanel = DevExpress.XtraEditors.SplitFixedPanel.Panel2;
            this.splitContainerControl2.Location = new System.Drawing.Point(0, 0);
            this.splitContainerControl2.Name = "splitContainerControl2";
            this.splitContainerControl2.Panel1.Controls.Add(this.gcprofile);
            this.splitContainerControl2.Panel1.Text = "Panel1";
            this.splitContainerControl2.Panel2.Controls.Add(this.pcActions);
            this.splitContainerControl2.Panel2.Text = "Panel2";
            this.splitContainerControl2.Size = new System.Drawing.Size(622, 517);
            this.splitContainerControl2.SplitterPosition = 0;
            this.splitContainerControl2.TabIndex = 0;
            this.splitContainerControl2.Text = "splitContainerControl2";
            // 
            // gcprofile
            // 
            this.gcprofile.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcprofile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcprofile.Location = new System.Drawing.Point(0, 0);
            this.gcprofile.MainView = this.gvprofile;
            this.gcprofile.Name = "gcprofile";
            this.gcprofile.Size = new System.Drawing.Size(617, 517);
            this.gcprofile.TabIndex = 0;
            this.gcprofile.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvprofile});
            // 
            // gvprofile
            // 
            this.gvprofile.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gCategory,
            this.gDescription,
            this.gValue,
            this.gExplanation});
            this.gvprofile.GridControl = this.gcprofile;
            this.gvprofile.Name = "gvprofile";
            this.gvprofile.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gvprofile.OptionsView.ShowAutoFilterRow = true;
            this.gvprofile.OptionsView.ShowFooter = true;
            this.gvprofile.OptionsView.ShowGroupPanel = false;
            // 
            // gCategory
            // 
            this.gCategory.AppearanceHeader.Options.UseTextOptions = true;
            this.gCategory.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gCategory.Caption = "参数类型";
            this.gCategory.FieldName = "FCATEGORY";
            this.gCategory.Name = "gCategory";
            this.gCategory.OptionsColumn.AllowEdit = false;
            this.gCategory.OptionsColumn.ReadOnly = true;
            this.gCategory.Visible = true;
            this.gCategory.VisibleIndex = 0;
            this.gCategory.Width = 80;
            // 
            // gDescription
            // 
            this.gDescription.AppearanceHeader.Options.UseTextOptions = true;
            this.gDescription.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gDescription.Caption = "参数描述";
            this.gDescription.FieldName = "FDESCRIPTION";
            this.gDescription.Name = "gDescription";
            this.gDescription.OptionsColumn.AllowEdit = false;
            this.gDescription.OptionsColumn.ReadOnly = true;
            this.gDescription.Visible = true;
            this.gDescription.VisibleIndex = 1;
            this.gDescription.Width = 76;
            // 
            // gValue
            // 
            this.gValue.AppearanceCell.Options.UseTextOptions = true;
            this.gValue.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gValue.AppearanceHeader.Options.UseTextOptions = true;
            this.gValue.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gValue.Caption = "值";
            this.gValue.FieldName = "FSVALUE";
            this.gValue.Name = "gValue";
            this.gValue.Visible = true;
            this.gValue.VisibleIndex = 2;
            this.gValue.Width = 76;
            // 
            // gExplanation
            // 
            this.gExplanation.AppearanceHeader.Options.UseTextOptions = true;
            this.gExplanation.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gExplanation.Caption = "备注";
            this.gExplanation.FieldName = "FEXPLANATION";
            this.gExplanation.Name = "gExplanation";
            this.gExplanation.OptionsColumn.AllowEdit = false;
            this.gExplanation.Visible = true;
            this.gExplanation.VisibleIndex = 3;
            this.gExplanation.Width = 169;
            // 
            // pcActions
            // 
            this.pcActions.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pcActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pcActions.Location = new System.Drawing.Point(0, 0);
            this.pcActions.Name = "pcActions";
            this.pcActions.Size = new System.Drawing.Size(0, 0);
            this.pcActions.TabIndex = 1;
            // 
            // pnlDetail
            // 
            this.pnlDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetail.Location = new System.Drawing.Point(0, 0);
            this.pnlDetail.Name = "pnlDetail";
            this.pnlDetail.Size = new System.Drawing.Size(776, 484);
            this.pnlDetail.TabIndex = 1;
            // 
            // frmSystemProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(779, 572);
            this.Name = "frmSystemProfile";
            this.Text = "系统参数设置";
            this.tpSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProfileClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfileClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl2)).EndInit();
            this.splitContainerControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcprofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvprofile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcActions)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlDetail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl2;
        private DevExpress.XtraGrid.GridControl gcprofile;
        private DevExpress.XtraGrid.Views.Grid.GridView gvprofile;
        private DevExpress.XtraGrid.GridControl gcProfileClass;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProfileClass;
        private DevExpress.XtraGrid.Columns.GridColumn ClassName;
        private DevExpress.XtraEditors.PanelControl pcActions;
        private DevExpress.XtraEditors.PanelControl pnlDetail;
        private DevExpress.XtraGrid.Columns.GridColumn gCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gValue;
        private DevExpress.XtraGrid.Columns.GridColumn gExplanation;
    }
}