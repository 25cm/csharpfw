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
    public partial class HenkinListForm : FukjBaseForm
    {
        public HenkinListForm()
        {
            InitializeComponent();
            this.MaeukekinListDataGridView.Rows.Add("2014000001", "1", "○○支所", "1234", "株式会社○○環境開発工業", "請求", "20140712", "銀行",  "21,000", "11,000", "10,000", "未");
            this.MaeukekinListDataGridView.Rows.Add("2014000002", "1", "○○支所", "2345", "株式会社△△環境開発工業", "請求", "20140720", "現金",  "34,000",  "34,000", "0", "済");
            this.MaeukekinListDataGridView.Rows.Add("2014000003", "1", "○○支所", "3456", "株式会社財茄子", "前受金", "20140722", "郵便",  "9,000", "0", "0","");

            this.NyukinDtFromTextBox.Value = DateTime.ParseExact("2014/08/01", "yyyy/MM/dd", null);
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
            //MaeukekinListDataGridView.Rows.Clear();
            //if (radioButton1.Checked)
            //{
            //    this.MaeukekinListDataGridView.Rows.Add("2014000001", "1", "○○支所", "1234", "株式会社○○環境開発工業", "請求", "20140705", "21,000", "", "", "0", "", "21,000", "未", "0");
            //    this.MaeukekinListDataGridView.Rows.Add("2014000002", "1", "○○支所", "2345", "株式会社△△環境開発工業", "請求", "20140705", "34,000", "", "", "0", "", "34,000", "未", "0");
            //    this.MaeukekinListDataGridView.Rows.Add("2014000003", "1", "○○支所", "3456", "株式会社□□産業", "請求", "20140705", "26,000", "", "", "0", "", "26,000", "未", "0");
            //}
            //else
            //{
            //    this.MaeukekinListDataGridView.Rows.Add("2014000001", "1", "○○支所", "1234", "株式会社○○環境開発工業", "請求", "20140705", "21,000", "20140712", "銀行", "21,000", "680992", "0", "済", "0");
            //    this.MaeukekinListDataGridView.Rows.Add("2014000002", "1", "○○支所", "2345", "株式会社△△環境開発工業", "請求", "20140705", "34,000", "20140720", "現金", "34,000", "133456", "0", "未", "0");
            //    this.MaeukekinListDataGridView.Rows.Add("2014000003", "1", "○○支所", "3456", "株式会社財茄子", "前受金", "", "9,000", "20140722", "現金", "0", "225678", "0", "", "9,000");
            //    this.MaeukekinListDataGridView.Rows.Add("2014000004", "1", "○○支所", "4567", "□□株式会社", "用紙販売", "", "5,000", "20140723", "現金", "5,000", "33678", "0", "", "0");
            //}
        }

        private void torokuButton_Click(object sender, EventArgs e)
        {
            HenkinShosaiForm frm = new HenkinShosaiForm();
            Program.mForm.ShowForm(frm);
        }

        private void shosaiButton_Click(object sender, EventArgs e)
        {
            HenkinShosaiForm frm = new HenkinShosaiForm();
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

        private void SrhUseNyukinDtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SrhUseNyukinDtCheckBox.Checked)
            {
                NyukinDtFromTextBox.Enabled = true;
                NyukinDtToTextBox.Enabled = true;
            }
            else
            {
                NyukinDtFromTextBox.Enabled = false;
                NyukinDtToTextBox.Enabled = false;
            }

        }

        //private void radioButton1_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (radioButton1.Checked)
        //    {
        //        groupBox1.Enabled = false;
        //    }
        //    else
        //    {
        //        groupBox1.Enabled = true;
        //    }

        //}




    }

}
