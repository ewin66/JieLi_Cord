using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SG.Client.Library.UserControls
{
    public partial class ucLabelTextEdit : UserControl
    {
        public ucLabelTextEdit()
        {
            InitializeComponent();
        }

        [Category("自定义参数设置")]
        [DefaultValue("")]
        [Description("获取/设置标签文本")]
        public string LabelText
        {
            get
            {
                return labelControl.Text;
            }
            set
            {
                this.labelControl.Text = value;
            }
        }

        [Category("自定义参数设置")]
        [DefaultValue("")]
        [Description("获取/设置只读")]
        public bool ReadOnly
        {
            get
            {
                return txtTextEdit.Properties.ReadOnly;
            }
            set
            {
                txtTextEdit.Properties.ReadOnly = value;
            }
        }

        [Category("自定义参数设置")]
        [DefaultValue("")]
        [Description("获取/设置只读")]
        public bool Enabled
        {
            get
            {
                return txtTextEdit.Enabled;
            }
            set
            {
                txtTextEdit.Enabled = value;
            }
        }

        [Category("自定义参数设置")]
        [DefaultValue("")]
        [Description("获取/设置文本宽度")]
        public float LabelWidth
        {
            get
            {
                return tabPanel.ColumnStyles[0].Width;
            }
            set
            {
                tabPanel.ColumnStyles[0].Width = value;
            }
        }

        [Category("自定义参数设置")]
        [DefaultValue("")]
        [Description("获取/设置文本颜色")]
        public Color LabelForeColor
        {
            get
            {
                return labelControl.ForeColor;
            }
            set
            {
                labelControl.ForeColor = value;
            }
        }

        [Category("自定义参数设置")]
        [DefaultValue("")]
        [Description("获取/设置背景颜色")]
        public Color LabelBackColor
        {
            get
            {
                return labelControl.BackColor;
            }
            set
            {
                labelControl.BackColor = value;
            }
        }

        [Category("自定义参数设置")]
        [DefaultValue("")]
        [Description("获取/设置MemoEdit控件")]

        public DevExpress.XtraEditors.TextEdit cTextEdit
        {
            get { return txtTextEdit; }
            set { txtTextEdit = value; }
        }
    }
}
