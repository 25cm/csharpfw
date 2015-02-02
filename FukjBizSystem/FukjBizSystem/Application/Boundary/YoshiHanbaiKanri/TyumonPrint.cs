using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
//using FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.TyumonList;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using System.Drawing;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    public partial class TyumonPrintForm : FukjBaseForm
    {

        public TyumonPrintForm()
        {
            InitializeComponent();
            //ラベル透過処理
            this.label1.BackColor = Color.Transparent;
            this.label1.Parent = this.panel1;
            this.label1.Location -= (Size)this.panel1.Location;

            YoshiListDataGridView.DefaultCellStyle.Font = new Font(YoshiListDataGridView.Font.Name, 16);
            YoshiListDataGridView.ColumnHeadersDefaultCellStyle.Font = new Font(YoshiListDataGridView.Font.Name, 16);
            YoshiListDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;


            this.YoshiListDataGridView.Rows.Add("01", "浄化槽設置届出・計画書", "false");

            
        }




        private void tojiruButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
