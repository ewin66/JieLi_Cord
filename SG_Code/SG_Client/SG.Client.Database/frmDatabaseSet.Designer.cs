namespace SG.Client.Database
{
    partial class frmDatabaseSet
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gcProfileClass = new DevExpress.XtraGrid.GridControl();
            this.gridProfileClass = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.ColFNumber = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSqlTable = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSqlTableClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gcSummary = new DevExpress.XtraGrid.GridControl();
            this.gvSummary = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colItemClass = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDataType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLength = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colsrcName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPageName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.gcDetailEditor = new DevExpress.XtraEditors.GroupControl();
            this.tcEditor = new DevExpress.XtraTab.XtraTabControl();
            this.tcClass = new DevExpress.XtraTab.XtraTabPage();
            this.gcItemClassEditor = new DevExpress.XtraEditors.GroupControl();
            this.ucClassNote = new SG.Client.Library.UserControls.ucLabelMemoEdit();
            this.ucClassTable = new SG.Client.Library.UserControls.ucLabelLookupEdit();
            this.ucClassCTable = new SG.Client.Library.UserControls.ucLabelLookupEdit();
            this.ucClassFName = new SG.Client.Library.UserControls.ucLabelTextEdit();
            this.ucClassFNumber = new SG.Client.Library.UserControls.ucLabelTextEdit();
            this.tcAttribute = new DevExpress.XtraTab.XtraTabPage();
            this.gcAttributeEditor = new DevExpress.XtraEditors.GroupControl();
            this.tpSummary.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).BeginInit();
            this.tcBusiness.SuspendLayout();
            this.tpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).BeginInit();
            this.gcNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcProfileClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfileClass)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetailEditor)).BeginInit();
            this.gcDetailEditor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tcEditor)).BeginInit();
            this.tcEditor.SuspendLayout();
            this.tcClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcItemClassEditor)).BeginInit();
            this.gcItemClassEditor.SuspendLayout();
            this.tcAttribute.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcAttributeEditor)).BeginInit();
            this.SuspendLayout();
            // 
            // tpSummary
            // 
            this.tpSummary.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpSummary.Appearance.PageClient.Options.UseBackColor = true;
            this.tpSummary.Controls.Add(this.tableLayoutPanel1);
            this.tpSummary.Size = new System.Drawing.Size(776, 484);
            // 
            // tpDetail
            // 
            this.tpDetail.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tpDetail.Appearance.PageClient.Options.UseBackColor = true;
            this.tpDetail.Controls.Add(this.gcDetailEditor);
            this.tpDetail.Size = new System.Drawing.Size(776, 484);
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
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.gcProfileClass, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gcSummary, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(776, 484);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // gcProfileClass
            // 
            this.gcProfileClass.Cursor = System.Windows.Forms.Cursors.Default;
            this.gcProfileClass.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcProfileClass.Location = new System.Drawing.Point(3, 3);
            this.gcProfileClass.MainView = this.gridProfileClass;
            this.gcProfileClass.Name = "gcProfileClass";
            this.gcProfileClass.Size = new System.Drawing.Size(194, 560);
            this.gcProfileClass.TabIndex = 11;
            this.gcProfileClass.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridProfileClass});
            // 
            // gridProfileClass
            // 
            this.gridProfileClass.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.ColFNumber,
            this.colName,
            this.colSqlTable,
            this.colSqlTableClass,
            this.colNote});
            this.gridProfileClass.GridControl = this.gcProfileClass;
            this.gridProfileClass.Name = "gridProfileClass";
            this.gridProfileClass.OptionsBehavior.Editable = false;
            this.gridProfileClass.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.Click;
            this.gridProfileClass.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridProfileClass.OptionsView.ColumnAutoWidth = false;
            this.gridProfileClass.OptionsView.ShowAutoFilterRow = true;
            this.gridProfileClass.OptionsView.ShowFooter = true;
            this.gridProfileClass.OptionsView.ShowGroupPanel = false;
            // 
            // ColFNumber
            // 
            this.ColFNumber.AppearanceHeader.Options.UseTextOptions = true;
            this.ColFNumber.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.ColFNumber.Caption = "编号";
            this.ColFNumber.FieldName = "FNUMBER";
            this.ColFNumber.Name = "ColFNumber";
            this.ColFNumber.Visible = true;
            this.ColFNumber.VisibleIndex = 0;
            this.ColFNumber.Width = 50;
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
            this.colName.Width = 100;
            // 
            // colSqlTable
            // 
            this.colSqlTable.AppearanceHeader.Options.UseTextOptions = true;
            this.colSqlTable.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colSqlTable.Caption = "实体数据表";
            this.colSqlTable.FieldName = "FSQLTABLENAME";
            this.colSqlTable.Name = "colSqlTable";
            this.colSqlTable.Visible = true;
            this.colSqlTable.VisibleIndex = 2;
            this.colSqlTable.Width = 200;
            // 
            // colSqlTableClass
            // 
            this.colSqlTableClass.Caption = "分类数据表";
            this.colSqlTableClass.FieldName = "FSQLCLASSTABLENAME";
            this.colSqlTableClass.Name = "colSqlTableClass";
            this.colSqlTableClass.Visible = true;
            this.colSqlTableClass.VisibleIndex = 3;
            this.colSqlTableClass.Width = 200;
            // 
            // colNote
            // 
            this.colNote.AppearanceHeader.Options.UseTextOptions = true;
            this.colNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colNote.Caption = "说明";
            this.colNote.FieldName = "FNOTE";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 4;
            this.colNote.Width = 300;
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
            this.gcSummary.Location = new System.Drawing.Point(203, 3);
            this.gcSummary.MainView = this.gvSummary;
            this.gcSummary.Name = "gcSummary";
            this.gcSummary.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1});
            this.gcSummary.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gcSummary.Size = new System.Drawing.Size(570, 560);
            this.gcSummary.TabIndex = 10;
            this.gcSummary.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvSummary});
            // 
            // gvSummary
            // 
            this.gvSummary.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colItemClass,
            this.colFName,
            this.colDataType,
            this.colLength,
            this.colsrcName,
            this.colPageName,
            this.colOrder});
            this.gvSummary.GridControl = this.gcSummary;
            this.gvSummary.Name = "gvSummary";
            this.gvSummary.OptionsBehavior.Editable = false;
            this.gvSummary.OptionsBehavior.ReadOnly = true;
            this.gvSummary.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gvSummary.OptionsView.ColumnAutoWidth = false;
            this.gvSummary.OptionsView.ShowAutoFilterRow = true;
            this.gvSummary.OptionsView.ShowFooter = true;
            this.gvSummary.OptionsView.ShowGroupPanel = false;
            // 
            // colItemClass
            // 
            this.colItemClass.AppearanceHeader.Options.UseTextOptions = true;
            this.colItemClass.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colItemClass.Caption = "基础资料名称";
            this.colItemClass.FieldName = "CLASSNAME";
            this.colItemClass.Name = "colItemClass";
            this.colItemClass.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "FTYPENAME", "{0}")});
            this.colItemClass.Visible = true;
            this.colItemClass.VisibleIndex = 0;
            this.colItemClass.Width = 92;
            // 
            // colFName
            // 
            this.colFName.AppearanceHeader.Options.UseTextOptions = true;
            this.colFName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colFName.Caption = "属性名称";
            this.colFName.FieldName = "FNAME";
            this.colFName.Name = "colFName";
            this.colFName.Visible = true;
            this.colFName.VisibleIndex = 1;
            this.colFName.Width = 108;
            // 
            // colDataType
            // 
            this.colDataType.AppearanceHeader.Options.UseTextOptions = true;
            this.colDataType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDataType.Caption = "属性类型";
            this.colDataType.FieldName = "FDATETYPEVAL";
            this.colDataType.Name = "colDataType";
            this.colDataType.Visible = true;
            this.colDataType.VisibleIndex = 2;
            this.colDataType.Width = 82;
            // 
            // colLength
            // 
            this.colLength.AppearanceHeader.Options.UseTextOptions = true;
            this.colLength.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colLength.Caption = "长度";
            this.colLength.FieldName = "FLENGTH";
            this.colLength.Name = "colLength";
            this.colLength.Visible = true;
            this.colLength.VisibleIndex = 3;
            // 
            // colsrcName
            // 
            this.colsrcName.AppearanceHeader.Options.UseTextOptions = true;
            this.colsrcName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colsrcName.Caption = "相关属性";
            this.colsrcName.FieldName = "SRCNAME";
            this.colsrcName.Name = "colsrcName";
            this.colsrcName.Visible = true;
            this.colsrcName.VisibleIndex = 4;
            this.colsrcName.Width = 198;
            // 
            // colPageName
            // 
            this.colPageName.AppearanceHeader.Options.UseTextOptions = true;
            this.colPageName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPageName.Caption = "属性页";
            this.colPageName.FieldName = "FPAGENAME";
            this.colPageName.Name = "colPageName";
            this.colPageName.Visible = true;
            this.colPageName.VisibleIndex = 5;
            // 
            // colOrder
            // 
            this.colOrder.Caption = "顺序";
            this.colOrder.FieldName = "FORDER";
            this.colOrder.Name = "colOrder";
            this.colOrder.Visible = true;
            this.colOrder.VisibleIndex = 6;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TypeName", "名称")});
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            // 
            // gcDetailEditor
            // 
            this.gcDetailEditor.Controls.Add(this.tcEditor);
            this.gcDetailEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcDetailEditor.Location = new System.Drawing.Point(0, 0);
            this.gcDetailEditor.Name = "gcDetailEditor";
            this.gcDetailEditor.Size = new System.Drawing.Size(776, 484);
            this.gcDetailEditor.TabIndex = 1;
            // 
            // tcEditor
            // 
            this.tcEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEditor.Location = new System.Drawing.Point(2, 22);
            this.tcEditor.Name = "tcEditor";
            this.tcEditor.SelectedTabPage = this.tcClass;
            this.tcEditor.Size = new System.Drawing.Size(772, 460);
            this.tcEditor.TabIndex = 1;
            this.tcEditor.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tcClass,
            this.tcAttribute});
            // 
            // tcClass
            // 
            this.tcClass.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tcClass.Appearance.PageClient.Options.UseBackColor = true;
            this.tcClass.Controls.Add(this.gcItemClassEditor);
            this.tcClass.Name = "tcClass";
            this.tcClass.Size = new System.Drawing.Size(766, 431);
            this.tcClass.Text = "基础资料名称";
            // 
            // gcItemClassEditor
            // 
            this.gcItemClassEditor.Controls.Add(this.ucClassNote);
            this.gcItemClassEditor.Controls.Add(this.ucClassTable);
            this.gcItemClassEditor.Controls.Add(this.ucClassCTable);
            this.gcItemClassEditor.Controls.Add(this.ucClassFName);
            this.gcItemClassEditor.Controls.Add(this.ucClassFNumber);
            this.gcItemClassEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcItemClassEditor.Location = new System.Drawing.Point(0, 0);
            this.gcItemClassEditor.Name = "gcItemClassEditor";
            this.gcItemClassEditor.Size = new System.Drawing.Size(766, 431);
            this.gcItemClassEditor.TabIndex = 1;
            // 
            // ucClassNote
            // 
            this.ucClassNote.Enabled = true;
            this.ucClassNote.LabelBackColor = System.Drawing.Color.Empty;
            this.ucClassNote.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.ucClassNote.LabelText = "备注";
            this.ucClassNote.LabelWidth = 147F;
            this.ucClassNote.Location = new System.Drawing.Point(46, 238);
            this.ucClassNote.Name = "ucClassNote";
            this.ucClassNote.ReadOnly = false;
            this.ucClassNote.Size = new System.Drawing.Size(371, 108);
            this.ucClassNote.TabIndex = 5;
            // 
            // ucClassTable
            // 
            this.ucClassTable.Enabled = true;
            this.ucClassTable.LabelBackColor = System.Drawing.Color.Empty;
            this.ucClassTable.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.ucClassTable.LabelText = "实体数据表：";
            this.ucClassTable.LabelWidth = 147F;
            this.ucClassTable.Location = new System.Drawing.Point(46, 185);
            this.ucClassTable.Name = "ucClassTable";
            this.ucClassTable.ReadOnly = false;
            this.ucClassTable.Size = new System.Drawing.Size(371, 27);
            this.ucClassTable.TabIndex = 4;
            // 
            // ucClassCTable
            // 
            this.ucClassCTable.Enabled = true;
            this.ucClassCTable.LabelBackColor = System.Drawing.Color.Empty;
            this.ucClassCTable.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.ucClassCTable.LabelText = "分类数据表:";
            this.ucClassCTable.LabelWidth = 147F;
            this.ucClassCTable.Location = new System.Drawing.Point(46, 136);
            this.ucClassCTable.Name = "ucClassCTable";
            this.ucClassCTable.ReadOnly = false;
            this.ucClassCTable.Size = new System.Drawing.Size(371, 27);
            this.ucClassCTable.TabIndex = 3;
            // 
            // ucClassFName
            // 
            this.ucClassFName.Enabled = true;
            this.ucClassFName.LabelBackColor = System.Drawing.Color.Empty;
            this.ucClassFName.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.ucClassFName.LabelText = "名称：";
            this.ucClassFName.LabelWidth = 147F;
            this.ucClassFName.Location = new System.Drawing.Point(46, 88);
            this.ucClassFName.Name = "ucClassFName";
            this.ucClassFName.ReadOnly = false;
            this.ucClassFName.Size = new System.Drawing.Size(371, 26);
            this.ucClassFName.TabIndex = 1;
            // 
            // ucClassFNumber
            // 
            this.ucClassFNumber.Enabled = true;
            this.ucClassFNumber.LabelBackColor = System.Drawing.Color.Empty;
            this.ucClassFNumber.LabelForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            this.ucClassFNumber.LabelText = "编号：";
            this.ucClassFNumber.LabelWidth = 147F;
            this.ucClassFNumber.Location = new System.Drawing.Point(46, 43);
            this.ucClassFNumber.Name = "ucClassFNumber";
            this.ucClassFNumber.ReadOnly = false;
            this.ucClassFNumber.Size = new System.Drawing.Size(371, 26);
            this.ucClassFNumber.TabIndex = 0;
            // 
            // tcAttribute
            // 
            this.tcAttribute.Appearance.PageClient.BackColor = System.Drawing.SystemColors.Control;
            this.tcAttribute.Appearance.PageClient.Options.UseBackColor = true;
            this.tcAttribute.Controls.Add(this.gcAttributeEditor);
            this.tcAttribute.Name = "tcAttribute";
            this.tcAttribute.Size = new System.Drawing.Size(766, 431);
            this.tcAttribute.Text = "基础资料属性";
            // 
            // gcAttributeEditor
            // 
            this.gcAttributeEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcAttributeEditor.Location = new System.Drawing.Point(0, 0);
            this.gcAttributeEditor.Name = "gcAttributeEditor";
            this.gcAttributeEditor.Size = new System.Drawing.Size(766, 431);
            this.gcAttributeEditor.TabIndex = 2;
            // 
            // frmDatabaseSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(782, 539);
            this.Name = "frmDatabaseSet";
            this.Text = "基础数据设置";
            this.tpSummary.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcBusiness)).EndInit();
            this.tcBusiness.ResumeLayout(false);
            this.tpDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcNavigator)).EndInit();
            this.gcNavigator.ResumeLayout(false);
            this.gcNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcProfileClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridProfileClass)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSummary)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gcDetailEditor)).EndInit();
            this.gcDetailEditor.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tcEditor)).EndInit();
            this.tcEditor.ResumeLayout(false);
            this.tcClass.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcItemClassEditor)).EndInit();
            this.gcItemClassEditor.ResumeLayout(false);
            this.tcAttribute.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcAttributeEditor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraGrid.GridControl gcProfileClass;
        private DevExpress.XtraGrid.Views.Grid.GridView gridProfileClass;
        private DevExpress.XtraGrid.Columns.GridColumn ColFNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.GridControl gcSummary;
        private DevExpress.XtraGrid.Views.Grid.GridView gvSummary;
        private DevExpress.XtraGrid.Columns.GridColumn colItemClass;
        private DevExpress.XtraGrid.Columns.GridColumn colFName;
        private DevExpress.XtraGrid.Columns.GridColumn colDataType;
        private DevExpress.XtraGrid.Columns.GridColumn colsrcName;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colSqlTable;
        private DevExpress.XtraGrid.Columns.GridColumn colSqlTableClass;
        private DevExpress.XtraGrid.Columns.GridColumn colLength;
        private DevExpress.XtraGrid.Columns.GridColumn colPageName;
        private DevExpress.XtraGrid.Columns.GridColumn colOrder;
        private DevExpress.XtraEditors.GroupControl gcDetailEditor;
        public DevExpress.XtraTab.XtraTabControl tcEditor;
        public DevExpress.XtraTab.XtraTabPage tcClass;
        public DevExpress.XtraTab.XtraTabPage tcAttribute;
        private DevExpress.XtraEditors.GroupControl gcItemClassEditor;
        private DevExpress.XtraEditors.GroupControl gcAttributeEditor;
        private Library.UserControls.ucLabelMemoEdit ucClassNote;
        private Library.UserControls.ucLabelLookupEdit ucClassTable;
        private Library.UserControls.ucLabelLookupEdit ucClassCTable;
        private Library.UserControls.ucLabelTextEdit ucClassFName;
        private Library.UserControls.ucLabelTextEdit ucClassFNumber;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
    }
}
