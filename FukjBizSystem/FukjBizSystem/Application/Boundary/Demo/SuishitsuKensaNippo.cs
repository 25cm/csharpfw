using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FukjBizSystem.Application.Boundary.Demo
{
    public partial class SuishitsuKensaNippoForm : Form
    {
        private string gyoshaNm;
        private string gyoshaCd;

        private int motikomiCnt;
        private int shushuCnt;
        private int kingaku;
        private int nyukingaku;

        private int motikomiCntAll;
        private int shushuCntAll;
        private int kingakuAll;
        private int nyukingakuAll;

        public SuishitsuKensaNippoForm()
        {
            InitializeComponent();
        }

        private void ViewChangeButton_Click(object sender, EventArgs e)
        {
            if (SearchPanel.Height == 30)
            {
                SearchPanel.Height = 74;
                GyoshaListPanel.Top = 75;
                GyoshaListPanel.Height = 471;
                ViewChangeButton.Text = "▲";
            }
            else
            {
                SearchPanel.Height = 30;
                GyoshaListPanel.Top = 30;
                GyoshaListPanel.Height = 520;
                ViewChangeButton.Text = "▼";
            }
        }
        
        // クリアボタン
        private void ClearButton_Click(object sender, EventArgs e)
        {
            UketsukeDtDateTimePicker.Value = DateTime.Now;
        }

        // 検索ボタン
        private void KensakuButton_Click(object sender, EventArgs e)
        {
            DoSearch();
        }

        // 全て確認チェックボックス
        private void AllCheckCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvRow in NippoListDataGridView.Rows)
            {
                if (int.Parse(dgvRow.Cells[RecordTypeCol.Index].Value.ToString()) != 3
                    && int.Parse(dgvRow.Cells[RecordTypeCol.Index].Value.ToString()) != 4)
                {
                    dgvRow.Cells[kakuninCol.Index].Value = AllCheckCheckBox.Checked;
                }
            }
        }

        // 確定ボタン
        private void KakuteiButton_Click(object sender, EventArgs e)
        {
            // TODO
            MessageBox.Show("機能説明:水質検査日報一覧の確認状態を確定します。");
        }

        // 日報出力ボタン
        private void NippoOutputButton_Click(object sender, EventArgs e)
        {
            // TODO
            MessageBox.Show("機能説明:画面表示内容に対応する水質検査日報を出力します\n(内容確認用の帳票として)");
        }

        // 一覧出力ボタン
        private void OutputButton_Click(object sender, EventArgs e)
        {
            // TODO
            MessageBox.Show("機能説明:画面に表示されている一覧をExcelで出力します");
        }

        // 閉じるボタン
        private void TojiruButton_Click(object sender, EventArgs e)
        {
            // TODO 遷移元メニュー画面未定
            KensaKekka.KekkaMenuForm frm = new KensaKekka.KekkaMenuForm();
            Program.mForm.ShowForm(frm);
        }

        private void DoSearch()
        {
            // 既存データクリア
            NippoListDataGridView.Rows.Clear();

            DataTable table = GetData();

            StringBuilder cond = new StringBuilder();
            //if (!string.IsNullOrEmpty(nendoTextBox.Text))
            //{
            //    if (cond.Length > 0) { cond.Append(" AND "); }
            //    cond.AppendFormat("IraiNendo = '{0}'", nendoTextBox.Text);
            //}
            //if (!string.IsNullOrEmpty(noFromTextBox.Text))
            //{
            //    if (cond.Length > 0) { cond.Append(" AND "); }
            //    cond.AppendFormat("IraiRenban >= '{0}'", noFromTextBox.Text);
            //}
            //if (!string.IsNullOrEmpty(noToTextBox.Text))
            //{
            //    if (cond.Length > 0) { cond.Append(" AND "); }
            //    cond.AppendFormat("IraiRenban <= '{0}'", noToTextBox.Text);
            //}

            // TODO 製品版では、クエリ内でフィルタを行う
            SetData(table, cond);
        }

        private DataTable GetData()
        {
            // TODO 製品版ではALを実行・取得する（※検索条件は(1)検査依頼の受付日、(2)ログインユーザーの所属支所、業者コード順）

            DataTable table = new DataTable();

            table.Columns.Add("GyoshaNm", typeof(string));
            table.Columns.Add("GyoshaCd", typeof(string));
            table.Columns.Add("kensaShubetsu", typeof(string));
            table.Columns.Add("KaiingaiKbn", typeof(int));
            table.Columns.Add("GenkinKbn", typeof(int));
            table.Columns.Add("KensaRyokin", typeof(int));
            table.Columns.Add("MotikomiKensu", typeof(int));
            table.Columns.Add("ShushuKensu", typeof(int));
            table.Columns.Add("Kingaku", typeof(int));
            table.Columns.Add("Nyukingaku", typeof(int));
            table.Columns.Add("KakuninKbn", typeof(int));
            table.Columns.Add("RecordType", typeof(int)); // 1=9条、2=水質11条、3=事業所計、4=総合計

            {
                DataRow row = table.NewRow();

                row["GyoshaNm"]      = "(株)○○○○○";
                row["GyoshaCd"]      = "123";
                row["kensaShubetsu"] = "500人槽以下A";
                row["KaiingaiKbn"]   = 0;
                row["GenkinKbn"]     = 0;
                row["KensaRyokin"]   = 8100;
                row["MotikomiKensu"] = 1;
                row["ShushuKensu"]   = 0;
                row["Kingaku"]       = 8100;
                row["Nyukingaku"]    = 0;
                row["KakuninKbn"]    = 0;
                row["RecordType"]    = 1;

                table.Rows.Add(row);
            }
            {
                DataRow row = table.NewRow();

                row["GyoshaNm"]      = "(株)○○○○○";
                row["GyoshaCd"]      = "123";
                row["kensaShubetsu"] = "500人槽以上A";
                row["KaiingaiKbn"]   = 0;
                row["GenkinKbn"]     = 0;
                row["KensaRyokin"]   = 8640;
                row["MotikomiKensu"] = 2;
                row["ShushuKensu"]   = 0;
                row["Kingaku"]       = 17280;
                row["Nyukingaku"]    = 0;
                row["KakuninKbn"]    = 0;
                row["RecordType"]    = 1;

                table.Rows.Add(row);
            }
            {
                DataRow row = table.NewRow();

                row["GyoshaNm"]      = "(株)○○○○○";
                row["GyoshaCd"]      = "123";
                row["kensaShubetsu"] = "流入水A";
                row["KaiingaiKbn"]   = 0;
                row["GenkinKbn"]     = 0;
                row["KensaRyokin"]   = 7560;
                row["MotikomiKensu"] = 0;
                row["ShushuKensu"]   = 4;
                row["Kingaku"]       = 30240;
                row["Nyukingaku"]    = 0;
                row["KakuninKbn"]    = 0;
                row["RecordType"]    = 1;

                table.Rows.Add(row);
            }
            {
                DataRow row = table.NewRow();

                row["GyoshaNm"]      = "(株)○○○○○";
                row["GyoshaCd"]      = "123";
                row["kensaShubetsu"] = "水濁法A";
                row["KaiingaiKbn"]   = 0;
                row["GenkinKbn"]     = 0;
                row["KensaRyokin"]   = 11340;
                row["MotikomiKensu"] = 0;
                row["ShushuKensu"]   = 8;
                row["Kingaku"]       = 90720;
                row["Nyukingaku"]    = 0;
                row["KakuninKbn"]    = 0;
                row["RecordType"]    = 1;

                table.Rows.Add(row);
            }

            {
                DataRow row = table.NewRow();

                row["GyoshaNm"]      = "(有)△△△△△";
                row["GyoshaCd"]      = "124";
                row["kensaShubetsu"] = "11条(～10)";
                row["KaiingaiKbn"]   = 0;
                row["GenkinKbn"]     = 0;
                row["KensaRyokin"]   = 5600;
                row["MotikomiKensu"] = 2;
                row["ShushuKensu"]   = 8;
                row["Kingaku"]       = 56000;
                row["Nyukingaku"]    = 0;
                row["KakuninKbn"]    = 0;
                row["RecordType"]    = 2;

                table.Rows.Add(row);
            }
            {
                DataRow row = table.NewRow();

                row["GyoshaNm"]      = "(有)△△△△△";
                row["GyoshaCd"]      = "124";
                row["kensaShubetsu"] = "11条(21～50)";
                row["KaiingaiKbn"]   = 0;
                row["GenkinKbn"]     = 0;
                row["KensaRyokin"]   = 8000;
                row["MotikomiKensu"] = 1;
                row["ShushuKensu"]   = 16;
                row["Kingaku"]       = 136000;
                row["Nyukingaku"]    = 0;
                row["KakuninKbn"]    = 0;
                row["RecordType"]    = 2;

                table.Rows.Add(row);
            }

            {
                DataRow row = table.NewRow();

                row["GyoshaNm"]      = "□□□□□(株)";
                row["GyoshaCd"]      = "125";
                row["kensaShubetsu"] = "500人槽以下A";
                row["KaiingaiKbn"]   = 1;
                row["GenkinKbn"]     = 1;
                row["KensaRyokin"]   = 8100;
                row["MotikomiKensu"] = 0;
                row["ShushuKensu"]   = 4;
                row["Kingaku"]       = 32400;
                row["Nyukingaku"]    = 32400;
                row["KakuninKbn"]    = 0;
                row["RecordType"]    = 1;

                table.Rows.Add(row);
            }
            {
                DataRow row = table.NewRow();

                row["GyoshaNm"]      = "□□□□□(株)";
                row["GyoshaCd"]      = "125";
                row["kensaShubetsu"] = "500人槽以上A";
                row["KaiingaiKbn"]   = 0;
                row["GenkinKbn"]     = 0;
                row["KensaRyokin"]   = 8640;
                row["MotikomiKensu"] = 2;
                row["ShushuKensu"]   = 0;
                row["Kingaku"]       = 17280;
                row["Nyukingaku"]    = 0;
                row["KakuninKbn"]    = 0;
                row["RecordType"]    = 1;

                table.Rows.Add(row);
            }

            return table;
        }

        private void SetData(DataTable table, StringBuilder cond)
        {
            gyoshaNm = "";
            gyoshaCd = string.Empty;

            motikomiCnt = 0;
            shushuCnt = 0;
            kingaku = 0;
            nyukingaku = 0;

            motikomiCntAll = 0;
            shushuCntAll = 0;
            kingakuAll = 0;
            nyukingakuAll = 0;

            foreach (DataRow row in table.Select(cond.ToString()))
            {
                if(gyoshaCd == string.Empty)
                {
                    // 業者コード退避
                    gyoshaNm = row["GyoshaNm"].ToString();
                    gyoshaCd = row["GyoshaCd"].ToString();
                }
                else if(gyoshaCd != row["GyoshaCd"].ToString())
                {
                    // 業者コード退避
                    gyoshaNm = row["GyoshaNm"].ToString();
                    gyoshaCd = row["GyoshaCd"].ToString();

                    // 事業所計表示
                    DispSubTotal();

                    // 総合計加算
                    SetTotal();
                }

                // 各レコード表示
                DispRecoard(row);

                // 事業所計加算
                SetSubTotal(row);
            }
            if(gyoshaCd != string.Empty)
            {
                // 事業所計表示
                DispSubTotal();

                // 総合計加算
                SetTotal();

                // 総合計表示
                DispTotal();
            }

            // 集計行の背景色変更＆チェックボックス非活性
            foreach(DataGridViewRow row in NippoListDataGridView.Rows)
            {
                if (int.Parse(row.Cells[RecordTypeCol.Index].Value.ToString()) == 3)
                {
                    row.Cells[kakuninCol.Index].ReadOnly = true;  
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                }
                else if (int.Parse(row.Cells[RecordTypeCol.Index].Value.ToString()) == 4)
                {
                    row.Cells[kakuninCol.Index].ReadOnly = true;
                    row.DefaultCellStyle.BackColor = Color.Orange;
                }
            }

            // TODO 受付No表示　9条
            UketsukeNo9joFromTextBox.Text = "1212";
            UketsukeNo9joToTextBox.Text = "1233";
            UketsukeHonsu9joTextBox.Text = "21";
            // TODO 受付No表示　水質11条
            UketsukeNoSuishitsu11joFromTextBox.Text = "4578";
            UketsukeNoSuishitsu11joToTextBox.Text = "4605";
            UketsukeHonsuSuishitsu11joTextBox.Text = "27";
            // TODO 受付No表示　外観11条
            UketsukeNoGaikan11joFromTextBox.Text = "2567";
            UketsukeNoGaikan11joToTextBox.Text = "2607";
            UketsukeHonsuGaikan11joTextBox.Text = "40";

        }

        // 各レコード表示
        private void DispRecoard(DataRow row)
        {
            NippoListDataGridView.Rows.Add(
                row["GyoshaNm"]
                , row["GyoshaCd"]
                , row["kensaShubetsu"]
                , row["KaiingaiKbn"]
                , row["GenkinKbn"]
                , row["KensaRyokin"]
                , row["MotikomiKensu"]
                , row["ShushuKensu"]
                , row["Kingaku"]
                , row["Nyukingaku"]
                , row["KakuninKbn"]
                , row["RecordType"]
                );
        }

        // 事業所計表示
        private void DispSubTotal()
        {
            NippoListDataGridView.Rows.Add(
                gyoshaNm
                , gyoshaCd
                , "■ 事業所計 ■"
                , 0
                , 0
                , 0
                , motikomiCnt
                , shushuCnt
                , kingaku
                , nyukingaku
                , 0
                , 3
                );
        }

        // 総合計表示
        private void DispTotal()
        {
            NippoListDataGridView.Rows.Add(
                ""
                , ""
                , "■■ 総合計 ■■"
                , 0
                , 0
                , 0
                , motikomiCntAll
                , shushuCntAll
                , kingakuAll
                , nyukingakuAll
                , 0
                , 4
                );
        }

        // 事業所計加算
        private void SetSubTotal(DataRow row)
        {
            motikomiCnt = motikomiCnt + int.Parse(row["MotikomiKensu"].ToString());
            shushuCnt   = shushuCnt   + int.Parse(row["ShushuKensu"].ToString());
            kingaku     = kingaku     + int.Parse(row["Kingaku"].ToString());
            nyukingaku  = nyukingaku  + int.Parse(row["Nyukingaku"].ToString());
        }

        // 総合計加算
        private void SetTotal()
        {
            motikomiCntAll = motikomiCntAll + motikomiCnt;
            shushuCntAll   = shushuCntAll   + shushuCnt;
            kingakuAll     = kingakuAll     + kingaku;
            nyukingakuAll  = nyukingakuAll  + nyukingaku;
        }
    }
}
