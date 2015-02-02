using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.Test
{
    public partial class TestForm1 : FukjBaseForm
    {
        public TestForm1()
        {
            InitializeComponent();
        }

        private void TestForm1_Load(object sender, EventArgs e)
        {
            textBox1.SetStdControlDomain(Zynas.Control.Common.ZControlDomain.ZT_STD_NUM, 5, 0 , Zynas.Control.Common.InputValidateUtility.SignFlg.Positive);
            zTextBox1.SetStdControlDomain(Zynas.Control.Common.ZControlDomain.ZT_STD_NUM, 5, 2, Zynas.Control.Common.InputValidateUtility.SignFlg.Positive);
            zTextBox2.SetStdControlDomain(Zynas.Control.Common.ZControlDomain.ZT_STD_NUM, 5, 0, Zynas.Control.Common.InputValidateUtility.SignFlg.Positive);
        }
    }
}
