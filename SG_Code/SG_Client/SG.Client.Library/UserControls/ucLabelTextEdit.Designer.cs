namespace SG.Client.Library.UserControls
{
    partial class ucLabelTextEdit
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
            this.tabPanel = new System.Windows.Forms.TableLayoutPanel();
            this.txtTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.labelControl = new DevExpress.XtraEditors.LabelControl();
            this.tabPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTextEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tabPanel
            // 
            this.tabPanel.ColumnCount = 2;
            this.tabPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tabPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabPanel.Controls.Add(this.txtTextEdit, 0, 0);
            this.tabPanel.Controls.Add(this.labelControl, 0, 0);
            this.tabPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPanel.Location = new System.Drawing.Point(0, 0);
            this.tabPanel.Name = "tabPanel";
            this.tabPanel.RowCount = 1;
            this.tabPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tabPanel.Size = new System.Drawing.Size(252, 26);
            this.tabPanel.TabIndex = 13;
            // 
            // txtTextEdit
            // 
            this.txtTextEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTextEdit.Location = new System.Drawing.Point(70, 3);
            this.txtTextEdit.Name = "txtTextEdit";
            this.txtTextEdit.Size = new System.Drawing.Size(179, 20);
            this.txtTextEdit.TabIndex = 34;
            // 
            // labelControl
            // 
            this.labelControl.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl.Location = new System.Drawing.Point(3, 3);
            this.labelControl.Name = "labelControl";
            this.labelControl.Size = new System.Drawing.Size(61, 20);
            this.labelControl.TabIndex = 30;
            this.labelControl.Text = "Label";
            // 
            // ucLabelTextEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabPanel);
            this.Name = "ucLabelTextEdit";
            this.Size = new System.Drawing.Size(252, 26);
            this.tabPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtTextEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tabPanel;
        private DevExpress.XtraEditors.LabelControl labelControl;
        public DevExpress.XtraEditors.TextEdit txtTextEdit;
    }
}
