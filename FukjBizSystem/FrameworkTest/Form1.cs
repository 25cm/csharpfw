using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Zynas.Control.Common;

namespace FrameworkTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 
            // データ取得(生成)
            DataTable table = new DataTable();

            table.Columns.Add("name", typeof(string));
            table.Columns.Add("address", typeof(string));
            table.Columns.Add("age", typeof(int));
            table.Columns.Add("sex", typeof(string));
            table.Columns.Add("alcholic", typeof(string));
            table.Columns.Add("tobacco", typeof(string));

            {
                DataRow row = table.NewRow();
                row["name"] = "taro";
                row["address"] = "oita kotobuki machi";
                row["age"] = 28;
                row["sex"] = "0";
                row["alcholic"] = "1";
                row["tobacco"] = "1";

                table.Rows.Add(row);
            }
            {
                DataRow row = table.NewRow();
                row["name"] = "hanako";
                row["address"] = "oita kotobuki machi";
                row["age"] = 28;
                row["sex"] = "1";
                row["alcholic"] = "0";
                row["tobacco"] = "2";

                table.Rows.Add(row);
            }

            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "cd";
            comboBox1.DataSource = new object[] { new { cd = "1", name = "5本" }, new { cd = "2", name = "10本" } };

            DataBindingHelper inBind = new DataBindingHelper();

            inBind.AddControlBind(textBox1, table.Columns["name"]);
            inBind.AddControlBind(textBox2, table.Columns["address"]);
            inBind.AddControlBind(textBox3, table.Columns["age"]);

            inBind.AddControlBind(dataGridView1, colName.Index, table.Columns["name"]);
            inBind.AddControlBind(dataGridView1, colAddress.Index, table.Columns["address"]);

            inBind.AddControlBind(new RadioButton[] { radioButton1, radioButton2 }, new object[] { "0", "1" }, table.Columns["sex"]);

            inBind.AddControlBind(checkBox1, "1", "0", table.Columns["alcholic"]);

            inBind.AddControlBind(comboBox1, table.Columns["tobacco"]);

            inBind.FillToControl(table);

            #endregion

            dataGridView1.SetStdControlDomain(0, ZControlDomain.ZG_STD_CD, 4, DataGridViewContentAlignment.TopRight);
            dataGridView1.SetStdControlDomain(1, ZControlDomain.ZG_STD_CD, 4, DataGridViewContentAlignment.MiddleLeft);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // データ定義
            DataTable table = new DataTable();

            table.Columns.Add("name", typeof(string));
            table.Columns.Add("address", typeof(string));
            table.Columns.Add("age", typeof(int));
            table.Columns.Add("sex", typeof(string));
            table.Columns.Add("alcholic", typeof(string));
            table.Columns.Add("tobacco", typeof(string));

            DataBindingHelper outBind = new DataBindingHelper();

            outBind.AddControlBind(textBox1, table.Columns["name"]);
            outBind.AddControlBind(textBox2, table.Columns["address"]);
            outBind.AddControlBind(textBox3, table.Columns["age"]);

            outBind.AddControlBind(dataGridView1, colName.Index, table.Columns["name"]);
            outBind.AddControlBind(dataGridView1, colAddress.Index, table.Columns["address"]);

            outBind.AddControlBind(new RadioButton[] { radioButton1, radioButton2 }, new object[] { "0", "1" }, table.Columns["sex"]);

            outBind.AddControlBind(checkBox1, "1", "0", table.Columns["alcholic"]);

            outBind.AddControlBind(comboBox1, table.Columns["tobacco"]);

            //outBind.FillToDataRow(table);

        }

        private void printButton_Click(object sender, EventArgs e)
        {
            // テスト印刷(Excel出力)実行
            IPrintTestBLInput input = new PrintTestBLInput();

            input.AfterDispFlg = true;
            input.FormatPath = @"C:\Test\PrintFormat\検査員別検査予定一覧.xlsx";
            input.PrintDirectory = @"C:\Test\Print";

            IPrintTestBLOutput output = new PrintTestBusinessLogic().Execute(input);

        }
    }
}
