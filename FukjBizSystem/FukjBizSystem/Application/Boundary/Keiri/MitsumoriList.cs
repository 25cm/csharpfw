using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
//using FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuMstList;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    public partial class MitsumoriListForm : FukjBaseForm
    {
        public MitsumoriListForm()
        {
            InitializeComponent();
            this.MaeukekinListDataGridView.Rows.Add("2014000001", "1", "○○支所", "1234", "株式会社○○環境開発工業", "2014/07/12", "7月度お見積り", "21,000", "2015/03/31");
            this.MaeukekinListDataGridView.Rows.Add("2014000002", "1", "○○支所", "2345", "株式会社△△環境開発工業", "2014/07/20", "7月度お見積り", "25,000", "2015/03/31");

            this.MitsumoriDtFromTextBox.Value = DateTime.ParseExact("2014/07/01", "yyyy/MM/dd", null);
        }

        private void ViewChangeButton_Click(object sender, EventArgs e)
        {
            if (searchPanel.Height == 30)
            {
                searchPanel.Height = 184;
                MaeukekinListPanel.Top = 187;
                MaeukekinListPanel.Height = 339;
                viewChangeButton.Text = "▲";
            }
            else
            {
                searchPanel.Height = 30;
                MaeukekinListPanel.Top = 30;
                MaeukekinListPanel.Height = 475;
                viewChangeButton.Text = "▼";
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
        }

        private void kensakuButton_Click(object sender, EventArgs e)
        {
        }

        private void torokuButton_Click(object sender, EventArgs e)
        {
            MitsumoriShosaiForm frm = new MitsumoriShosaiForm();
            Program.mForm.ShowForm(frm);
        }

        private void shosaiButton_Click(object sender, EventArgs e)
        {
            MitsumoriShosaiForm frm = new MitsumoriShosaiForm();
            Program.mForm.ShowForm(frm);
        }

        private void outputButton_Click(object sender, EventArgs e)
        {
        }

        private void tojiruButton_Click(object sender, EventArgs e)
        {
            KeiriMenuForm frm = new KeiriMenuForm();
            Program.mForm.ShowForm(frm);
        }

        private void MitsumoriDtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (MitsumoriDtCheckBox.Checked)
            {
                MitsumoriDtFromTextBox.Enabled = true;
                MitsumoriDtToTextBox.Enabled = true;
            }
            else
            {
                MitsumoriDtFromTextBox.Enabled = false;
                MitsumoriDtToTextBox.Enabled = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MitsumoriShosaiForm frm = new MitsumoriShosaiForm();
            Program.mForm.ShowForm(frm);
        }



    }

}
