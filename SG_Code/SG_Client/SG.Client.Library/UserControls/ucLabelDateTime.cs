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
    public partial class ucLabelDateTime : UserControl
    {
        public ucLabelDateTime()
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
                return dateEdit.Properties.ReadOnly;
            }
            set
            {
                dateEdit.Properties.ReadOnly = value;
            }
        }

        [Category("自定义参数设置")]
        [DefaultValue("")]
        [Description("获取/设置只读")]
        public bool Enabled
        {
            get
            {
                return dateEdit.Enabled;
            }
            set
            {
                dateEdit.Enabled = value;
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
        [Description("获取/设置DateEdit控件")]

        public DevExpress.XtraEditors.DateEdit cDateEdit
        {
            get { return dateEdit; }
            set { dateEdit = value; }
        }
    }
}
