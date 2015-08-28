namespace SG.Client.Library.UserControls
{
    partial class ucLabelMemoEdit
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
            this.memoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.tabPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl
            // 
            this.labelControl.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.labelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl.Location = new System.Drawing.Point(3, 3);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(61, 102);
            this.labelControl.TabIndex = 30;
            this.labelControl.Text = "Label";
            // 
            // tabPanel
            // 
            this.tabPanel.ColumnCount = 2;
            this.tabPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tabPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabPanel.Controls.Add(this.labelControl, 0, 0);
            this.tabPanel.Controls.Add(this.memoEdit, 1, 0);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanel.Location = new System.Drawing.Point(0, 0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.RowCount = 1;
            this.tabPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tabPanel.Size = new System.Drawing.Size(259, 108);
            this.tabPanel.TabIndex = 15;
            // 
            // memoEdit
            // 
            this.memoEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoEdit.Location = new System.Drawing.Point(70, 3);
            this.memoEdit.Name = "memoEdit";
            this.memoEdit.Size = new System.Drawing.Size(186, 102);
            this.memoEdit.TabIndex = 31;
            this.memoEdit.UseOptimizedRendering = true;
            // 
            // ucLabelMemoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPanel);
            this.Name = "ucLabelMemoEdit";
            this.Size = new System.Drawing.Size(259, 108);
            this.tabPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl;
        private System.Windows.Forms.TableLayoutPanel tabPanel;
        public DevExpress.XtraEditors.MemoEdit memoEdit;
    }
}
