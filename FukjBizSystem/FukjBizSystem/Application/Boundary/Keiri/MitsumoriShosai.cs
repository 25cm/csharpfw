using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
//using FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.Keiri
{
    public partial class MitsumoriShosaiForm : FukjBaseForm
    {
        public MitsumoriShosaiForm()
        {
            InitializeComponent();
            this.MitsumoriListDataGridView.Rows.Add("01", "浄化槽太郎 ○○浄化槽", "法定検査", "11条単独 ○～○人槽", "12,000");
            this.MitsumoriListDataGridView.Rows.Add("02", "浄化槽太郎 ○○浄化槽", "水質セット", "放流水検査セット ○人槽", "10,260");
        }
        private void EntryButton_Click(object sender, EventArgs e)
        {
        }
        private void ChangeButton_Click(object sender, EventArgs e)
        {
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
        }

        private void ReInputButton_Click(object sender, EventArgs e)
        {
        }

        private void DecisionButton_Click(object sender, EventArgs e)
        {
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            MitsumoriListForm frm = new MitsumoriListForm();
            Program.mForm.ShowForm(frm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GyoshaMstSearchForm frm = new GyoshaMstSearchForm();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            JokasoDaichoSearchForm frm = new JokasoDaichoSearchForm();
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            KensaMstSearchForm frm = new KensaMstSearchForm();
            frm.ShowDialog();
        }

    }

}
