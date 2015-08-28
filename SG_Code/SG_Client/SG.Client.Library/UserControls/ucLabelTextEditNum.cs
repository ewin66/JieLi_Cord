using DevExpress.XtraEditors.Mask;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SG.Client.Library.UserControls
{
    public partial class ucLabelTextEditNum : SG.Client.Library.UserControls.ucLabelTextEdit
    {
        public ucLabelTextEditNum()
        {
            InitializeComponent();
            txtTextEdit.Properties.Mask.EditMask = "#0.00#####%";
            txtTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
        }


    }
}
