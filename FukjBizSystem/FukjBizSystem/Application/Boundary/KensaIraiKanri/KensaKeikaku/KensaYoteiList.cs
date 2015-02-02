using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanri;
using FukjBizSystem.Application.Utility;
using MapWorksViewer.MapWorks;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/26　habu　　    新規作成
    /// 2014/12/19　habu　　    カレンダー側への同期を追加
    /// </history>
    public partial class KensaYoteiList : FukjBaseForm
    {
        #region 連携対象画面保持

        /// <summary>
        /// 
        /// </summary>
        private KensaYoteiMap mapForm;

        /// <summary>
        /// 
        /// </summary>
        private KensaKeikakuDataSource editDataSource;

        #endregion

        /// <summary>
        /// 
        /// </summary>
        private KensaKeikakuDataSet.KensaKeikakuListDataTable _kensaYoteiTable = null;

        /// <summary>
        /// 
        /// </summary>
        private KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable _memoTable = null;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="ds"></param>
        public KensaYoteiList(KensaYoteiMap frm, KensaKeikakuDataSource ds)
        {
            mapForm = frm;
            editDataSource = ds;

            InitializeComponent();
        }
        #endregion

        #region KensaYoteiList_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaYoteiList_Load(object sender, EventArgs e)
        {
            BoundaryUtility.StdLoadEventSequence(this,
                delegate()
                {
                    // 検査員一覧取得
                    {
                        DataTable table = MstUtility.ShokuinMst.GetShokuinMstKensainByShishoCd(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd);
                        Utility.Utility.SetComboBoxList(kensainComboBox, table, "ShokuinNm", "ShokuinCd", true);
                    }

                    kensainComboBox.SelectedValue = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;

                    {
                        DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_006);
                        Utility.Utility.SetComboBoxList(kensaKbnComboBox, table, "ConstNm", "ConstValue", true);
                    }

                    {
                        _kensaYoteiTable = editDataSource.GetKensaYoteiData();
                        _memoTable = editDataSource.GetKensaYoteiMemoData();

                        // 検索条件を作成し、初期検索を行う
                        DoSearch();
                   }
                });
        }
        #endregion

        #region closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region kensaYoteiListDataGridView_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensaYoteiListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    DataGridView dgv = (DataGridView)sender;

                    //"Link"列ならば、ボタンがクリックされた
                    if (e.ColumnIndex == ColMemo.Index)
                    {
                        if (mapForm.memoForm == null || mapForm.memoForm.IsDisposed)
                        {
                            mapForm.memoForm = new KensaMemoList(mapForm, editDataSource);
                        }

                        mapForm.memoForm.Show();
                    }
                }, false, false);
        }
        #endregion

        #region to be removed
        //#region kensaYoteiListDataGridView_CellFormatting
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="e"></param>
        //private void kensaYoteiListDataGridView_CellFormatting(object sender,
        //    DataGridViewCellFormattingEventArgs e)
        //{
        //    BoundaryUtility.StdEventSequence(
        //        delegate()
        //        {

        //            if ((e.ColumnIndex == this.kensaYoteiListDataGridView.Columns["Rating"].Index)
        //                && e.Value != null)
        //            {
        //                DataGridViewCell cell =
        //                    this.kensaYoteiListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex];
        //            }
        //        }, false, false);
        //}
        //#endregion
        #endregion

        #region kensaYoteiListDataGridView_SelectionChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensaYoteiListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (kensaYoteiListDataGridView.CurrentRow == null)
                    {
                        return;
                    }

                    DataGridViewRow gridRow = kensaYoteiListDataGridView.CurrentRow;

                    if (string.IsNullOrEmpty((string)gridRow.Cells[colKey.Index].Value))
                    {
                        return;
                    }

                    SelectKensaYotei((string)gridRow.Cells[colKey.Index].Value);

                    if (mapForm != null)
                    {
                        // 地図側の検査予定アイコンを選択
                        mapForm.SelectKensaYotei((string)gridRow.Cells[colKey.Index].Value);
                    }

                    if (mapForm != null && mapForm.memoForm != null)
                    {
                        mapForm.memoForm.SelectKensaYotei((string)gridRow.Cells[colKey.Index].Value);
                    }
                }, false, false);
        }
        #endregion

        #region kensaYoteiListDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensaYoteiListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (e.ColumnIndex == ColKensaYoteiDate.Index)
                    {
                        string newDate = (string)kensaYoteiListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        string key = (string)kensaYoteiListDataGridView.Rows[e.RowIndex].Cells[colKey.Index].Value;

                        // メモリ上共有データの検査予定日を更新
                        editDataSource.SetKensaYoteiDate(key, newDate);

                        // 子画面の表示を更新
                        if (mapForm != null)
                        {
                            mapForm.SetKensaYoteiDate(key, newDate);
                        }

                        if (mapForm != null && mapForm.memoForm != null)
                        {
                            mapForm.memoForm.SetKensaYoteiDate(key, newDate);
                        }

                        if (mapForm != null && mapForm.calenderForm != null)
                        {
                            mapForm.calenderForm.UpdateAll();
                        }
                    }
                }, false, false);
        }
        #endregion

        #region kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    DoSearch();

                    #region to be removed
                    //StringBuilder buf = new StringBuilder();

                    //KensaKeikakuDataSet.KensaKeikakuListDataTable templateTable = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

                    //if (!string.IsNullOrEmpty(ninsouTextBox.Text))
                    //{
                    //    if (buf.Length > 0) { buf.Append(" AND "); }
                    //    buf.AppendFormat("{0} = '{1}'", templateTable.JokasoShoriTaishoJininColumn.ColumnName, ninsouTextBox.Text);
                    //}
                    //if (!string.IsNullOrEmpty(kensainTextBox.Text))
                    //{
                    //    if (buf.Length > 0) { buf.Append(" AND "); }
                    //    buf.AppendFormat("{0} LIKE '%{1}%'", templateTable.JokasoKensaTantoshaNmColumn.ColumnName, kensainTextBox.Text);
                    //}
                    //if (kensaKbnComboBox.SelectedIndex > 0)
                    //{
                    //    if (buf.Length > 0) { buf.Append(" AND "); }
                    //    buf.AppendFormat("{0} = '{1}'", templateTable.KensaIraiHoteiKbnColumn.ColumnName, kensaKbnComboBox.SelectedValue);
                    //}
                    //if (kensaYoteiDateRadioButton.Checked)
                    //{
                    //    if (!string.IsNullOrEmpty(kensaYoteiFromDateTextBox.Text))
                    //    {
                    //        if (buf.Length > 0) { buf.Append(" AND "); }
                    //        buf.AppendFormat("{0} + {1} + {2} >= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiFromDateTextBox.Text);
                    //    }
                    //    if (!string.IsNullOrEmpty(kensaYoteiToDateTextBox.Text))
                    //    {
                    //        if (buf.Length > 0) { buf.Append(" AND "); }
                    //        buf.AppendFormat("{0} + {1} + {2} <= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiToDateTextBox.Text);
                    //    }
                    //}
                    //if (kensaYoteiMonthRadioButton.Checked)
                    //{
                    //    if (!string.IsNullOrEmpty(kensaYoteiFromMonthTextBox.Text))
                    //    {
                    //        if (buf.Length > 0) { buf.Append(" AND "); }
                    //        buf.AppendFormat("{0} + {1} + {2} >= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiFromMonthTextBox.Text + "01");
                    //    }
                    //    if (!string.IsNullOrEmpty(kensaYoteiToMonthTextBox.Text))
                    //    {
                    //        if (buf.Length > 0) { buf.Append(" AND "); }
                    //        buf.AppendFormat("{0} + {1} + {2} <= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiToMonthTextBox.Text + "31");
                    //    }
                    //}

                    //SetData((KensaKeikakuDataSet.KensaKeikakuListRow[])_kensaYoteiTable.Select(buf.ToString()), _memoTable);
                    #endregion

                });
        }
        #endregion

        #region kensaYoteiDateRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensaYoteiDateRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    kensaYoteiFromDateTextBox.Enabled = kensaYoteiDateRadioButton.Checked;
                    kensaYoteiToDateTextBox.Enabled = kensaYoteiDateRadioButton.Checked;

                    kensaYoteiFromMonthTextBox.Enabled = kensaYoteiMonthRadioButton.Checked;
                    kensaYoteiToMonthTextBox.Enabled = kensaYoteiMonthRadioButton.Checked;
                }, false, false);
        }
        #endregion

        #region DoSearch
        /// <summary>
        /// 
        /// </summary>
        private void DoSearch()
        {
            string filterCond = CreateFilterCondStr();

            SetData((KensaKeikakuDataSet.KensaKeikakuListRow[])_kensaYoteiTable.Select(filterCond, editDataSource.GetOrderStr()), _memoTable);

            // 共有データに絞込条件を保存
            editDataSource.SetFilterCond(filterCond);

            // 子画面側の表示を更新
            if (mapForm != null && mapForm.memoForm != null)
            {
                mapForm.memoForm.UpdateFilter();
            }

            #region to be removed
            //StringBuilder buf = new StringBuilder();

            //KensaKeikakuDataSet.KensaKeikakuListDataTable templateTable = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            //if (!string.IsNullOrEmpty(ninsouTextBox.Text))
            //{
            //    if (buf.Length > 0) { buf.Append(" AND "); }
            //    buf.AppendFormat("{0} = '{1}'", templateTable.JokasoShoriTaishoJininColumn.ColumnName, ninsouTextBox.Text);
            //}
            //if (!string.IsNullOrEmpty(kensainTextBox.Text))
            //{
            //    if (buf.Length > 0) { buf.Append(" AND "); }
            //    buf.AppendFormat("{0} LIKE '%{1}%'", templateTable.JokasoKensaTantoshaNmColumn.ColumnName, kensainTextBox.Text);
            //}
            //if (kensaKbnComboBox.SelectedIndex > 0)
            //{
            //    if (buf.Length > 0) { buf.Append(" AND "); }
            //    buf.AppendFormat("{0} = '{1}'", templateTable.KensaIraiHoteiKbnColumn.ColumnName, kensaKbnComboBox.SelectedValue);
            //}
            //if (kensaYoteiDateRadioButton.Checked)
            //{
            //    if (!string.IsNullOrEmpty(kensaYoteiFromDateTextBox.Text))
            //    {
            //        if (buf.Length > 0) { buf.Append(" AND "); }
            //        buf.AppendFormat("{0} + {1} + {2} >= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiFromDateTextBox.Text);
            //    }
            //    if (!string.IsNullOrEmpty(kensaYoteiToDateTextBox.Text))
            //    {
            //        if (buf.Length > 0) { buf.Append(" AND "); }
            //        buf.AppendFormat("{0} + {1} + {2} <= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiToDateTextBox.Text);
            //    }
            //}
            //if (kensaYoteiMonthRadioButton.Checked)
            //{
            //    if (!string.IsNullOrEmpty(kensaYoteiFromMonthTextBox.Text))
            //    {
            //        if (buf.Length > 0) { buf.Append(" AND "); }
            //        buf.AppendFormat("{0} + {1} + {2} >= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiFromMonthTextBox.Text + "01");
            //    }
            //    if (!string.IsNullOrEmpty(kensaYoteiToMonthTextBox.Text))
            //    {
            //        if (buf.Length > 0) { buf.Append(" AND "); }
            //        buf.AppendFormat("{0} + {1} + {2} <= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiToMonthTextBox.Text + "31");
            //    }
            //}

            //SetData((KensaKeikakuDataSet.KensaKeikakuListRow[])_kensaYoteiTable.Select(buf.ToString()), _memoTable);
            #endregion
        }
        #endregion

        #region CreateFilterCondStr
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string CreateFilterCondStr()
        {
            StringBuilder buf = new StringBuilder();

            KensaKeikakuDataSet.KensaKeikakuListDataTable templateTable = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            if (!string.IsNullOrEmpty(ninsouTextBox.Text))
            {
                if (buf.Length > 0) { buf.Append(" AND "); }
                buf.AppendFormat("{0} = '{1}'", templateTable.JokasoShoriTaishoJininColumn.ColumnName, ninsouTextBox.Text);
            }
            if (kensainComboBox.SelectedIndex > 0)
            {
                if (buf.Length > 0) { buf.Append(" AND "); }
                buf.AppendFormat("{0} = '{1}'", templateTable.KensaIraiKensaTantoshaCdColumn.ColumnName, kensainComboBox.SelectedValue.ToString());
            }
            if (kensaKbnComboBox.SelectedIndex > 0)
            {
                if (buf.Length > 0) { buf.Append(" AND "); }
                buf.AppendFormat("{0} = '{1}'", templateTable.KensaIraiHoteiKbnColumn.ColumnName, kensaKbnComboBox.SelectedValue);
            }
            if (kensaYoteiDateRadioButton.Checked)
            {
                if (!string.IsNullOrEmpty(kensaYoteiFromDateTextBox.Text))
                {
                    if (buf.Length > 0) { buf.Append(" AND "); }
                    buf.AppendFormat("{0} + {1} + {2} >= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiFromDateTextBox.Text);
                }
                if (!string.IsNullOrEmpty(kensaYoteiToDateTextBox.Text))
                {
                    if (buf.Length > 0) { buf.Append(" AND "); }
                    buf.AppendFormat("{0} + {1} + {2} <= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiToDateTextBox.Text);
                }
            }
            if (kensaYoteiMonthRadioButton.Checked)
            {
                if (!string.IsNullOrEmpty(kensaYoteiFromMonthTextBox.Text))
                {
                    if (buf.Length > 0) { buf.Append(" AND "); }
                    buf.AppendFormat("{0} + {1} + {2} >= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiFromMonthTextBox.Text + "01");
                }
                if (!string.IsNullOrEmpty(kensaYoteiToMonthTextBox.Text))
                {
                    if (buf.Length > 0) { buf.Append(" AND "); }
                    buf.AppendFormat("{0} + {1} + {2} <= '{3}'", templateTable.KensaIraiKensaYoteiNenColumn.ColumnName, templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName, templateTable.KensaIraiKensaYoteiBiColumn.ColumnName, kensaYoteiToMonthTextBox.Text + "31");
                }
            }

            return buf.ToString();
        }
        #endregion

        #region SetData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="memoTable"></param>
        private void SetData(KensaKeikakuDataSet.KensaKeikakuListRow[] rows, KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable memoTable)
        {
            kensaYoteiListDataGridView.Rows.Clear();

            KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            for (int i = 0; i < rows.Length; i++)
            {
                KensaKeikakuDataSet.KensaKeikakuListRow row = rows[i];

                string yoteiDt = editDataSource.GetKensaYoteiDateStr(row);

                string key = editDataSource.GetKensaIraiKey(row);

                string dispKey = editDataSource.GetKensaIraiDispKey(row);

                string hoteiKbn = TypeUtility.GetString(row[table.KensaIraiHoteiKbnColumn.ColumnName]);
                string kanriGyosha = string.Empty;

                if (hoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN)
                {
                    kanriGyosha = TypeUtility.GetString(row[table.JokasoKojiGyoshaNmColumn.ColumnName]);
                }
                else if (hoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN)
                {
                    kanriGyosha = TypeUtility.GetString(row[table.JokasoHoshutenkenGyoshaNmColumn.ColumnName]);
                }
                else if (hoteiKbn == Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU)
                {
                    // 11条水質検査の場合は、(11条外観と同じく)保守点検業者とする
                    kanriGyosha = TypeUtility.GetString(row[table.JokasoHoshutenkenGyoshaNmColumn.ColumnName]);
                }

                string hagakiSumiFlg = TypeUtility.GetString(row[table.KensaIraiHagakiInsatsuzumiKbnColumn.ColumnName]);
                string hagakiSumi = string.Empty;

                if (hagakiSumiFlg == "1")
                {
                    hagakiSumi = "済";
                }

                kensaYoteiListDataGridView.Rows.Add(
                    (i + 1).ToString()
                    , key
                    , yoteiDt
                    , TypeUtility.GetString(row[table.KensaIraiHoteiKbnNmColumn.ColumnName])
                    , dispKey
                    , TypeUtility.GetString(row[table.JokasoSetchishaNmColumn.ColumnName])
                    , TypeUtility.GetString(row[table.JokasoSetchiBashoAdrColumn.ColumnName])
                    , TypeUtility.GetString(row[table.JokasoChizuNoColumn.ColumnName])
                    , TypeUtility.GetString(row[table.JokasoShoriHosikiKbnNmColumn.ColumnName])
                    , (int)row[table.JokasoShoriTaishoJininColumn.ColumnName]
                    , TypeUtility.GetString(row[table.KensaIraiKensaTantoshaNmColumn.ColumnName])
                    , kanriGyosha
                    , "メモ"
                    , TypeUtility.GetString(row[table.JokasoHagakiKbnNmColumn.ColumnName])
                    , hagakiSumi
                    );

                // メモ情報取得
                string memoStr = string.Empty;

                KensaKeikakuDataSet.KensaKeikakuMemoTblRow[] memoRows = (KensaKeikakuDataSet.KensaKeikakuMemoTblRow[])memoTable
                    .Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'"
                        , memoTable.JokasoMemoJokasoHokenjoCdColumn.ColumnName
                        , TypeUtility.GetString(row[table.JokasoHokenjoCdColumn.ColumnName])
                        , memoTable.JokasoMemoJokasoTorokuNendoColumn.ColumnName
                        , TypeUtility.GetString(row[table.JokasoTorokuNendoColumn.ColumnName])
                        , memoTable.JokasoMemoJokasoRenbanColumn.ColumnName
                        , TypeUtility.GetString(row[table.JokasoRenbanColumn.ColumnName])
                    ));

                foreach (KensaKeikakuDataSet.KensaKeikakuMemoTblRow memoRow in memoRows)
                {
                    memoStr += TypeUtility.GetString(memoRow[memoTable.MemoColumn.ColumnName]) + "\r\n";
                }

                // メモ欄のツールチップ表示を設定
                kensaYoteiListDataGridView[ColMemo.Index, i].ToolTipText = memoStr;
            }
        }
        #endregion

        #region 表示連携用インターフェース

        #region SelectKensaYotei
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public void SelectKensaYotei(string key)
        {
            // 選択部分の行表示を変更する
            foreach (DataGridViewRow gridRow in kensaYoteiListDataGridView.Rows)
            {
                if (((string)gridRow.Cells[colKey.Index].Value) == key)
                {
                    // スタイルを選択用に変更
                    gridRow.DefaultCellStyle.BackColor = Color.AliceBlue;
                }
                else
                {
                    // スタイルを通常に戻す
                    gridRow.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        #endregion

        #region SetKensaYoteiDate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="yoteiDate"></param>
        public void SetKensaYoteiDate(string key, string yoteiDate)
        {
            // 選択部分の検査予定日を更新する
            foreach (DataGridViewRow gridRow in kensaYoteiListDataGridView.Rows)
            {
                if (((string)gridRow.Cells[colKey.Index].Value) == key)
                {
                    // 日付を更新
                    gridRow.Cells[ColKensaYoteiDate.Index].Value = yoteiDate;
                    break;
                }
            }
        }
        #endregion

        #region SetJokasoSetchiAddress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="address"></param>
        public void SetJokasoSetchiAddress(string key, string address)
        {
            // 選択部分の設置場所を更新する
            foreach (DataGridViewRow gridRow in kensaYoteiListDataGridView.Rows)
            {
                if (((string)gridRow.Cells[colKey.Index].Value) == key)
                {
                    // 設置場所を更新
                    gridRow.Cells[ColSettiBasho.Index].Value = address;
                    break;
                }
            }
        }
        #endregion

        #region UpdateAll
        /// <summary>
        /// 
        /// </summary>
        public void UpdateAll()
        {
            DoSearch();
        }
        #endregion

        #endregion
    }
}
