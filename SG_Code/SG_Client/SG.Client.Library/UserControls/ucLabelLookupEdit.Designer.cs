namespace SG.Client.Library.UserControls
{
    partial class ucLabelLookupEdit
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.tabPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lookUpEdit = new DevExpress.XtraEditors.LookUpEdit();
            this.tabPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl
            // 
            this.labelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl.Location = new System.Drawing.Point(3, 3);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(61, 21);
            this.labelControl.TabIndex = 30;
            this.labelControl.Text = "Label";
            // 
            // tabPanel
            // 
            this.tabPanel.ColumnCount = 2;
            this.tabPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tabPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabPanel.Controls.Add(this.labelControl, 0, 0);
            this.tabPanel.Controls.Add(this.lookUpEdit, 1, 0);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanel.Location = new System.Drawing.Point(0, 0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.RowCount = 1;
            this.tabPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tabPanel.Size = new System.Drawing.Size(274, 27);
            this.tabPanel.TabIndex = 14;
            // 
            // lookUpEdit
            // 
            this.lookUpEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lookUpEdit.Location = new System.Drawing.Point(70, 3);
            this.lookUpEdit.Name = "lookUpEdit";
            this.lookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpEdit.Properties.NullText = "[请选择。。。。。。]";
            this.lookUpEdit.Size = new System.Drawing.Size(201, 20);
            this.lookUpEdit.TabIndex = 31;
            // 
            // ucLabelLookupEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPanel);
            this.Name = "ucLabelLookupEdit";
            this.Size = new System.Drawing.Size(274, 27);
            this.tabPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookUpEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl;
        private System.Windows.Forms.TableLayoutPanel tabPanel;
        public DevExpress.XtraEditors.LookUpEdit lookUpEdit;
    }
}
