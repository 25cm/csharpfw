using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanri;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaKeikaku;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/26　habu　　    新規作成
    /// 2014/12/19　habu　　    カレンダー側への同期を追加
    /// 2015/01/30　habu　　    メモ一覧印刷ボタンを追加
    /// </history>
    public partial class KensaMemoList : FukjBaseForm
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

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="ds"></param>
        public KensaMemoList(KensaYoteiMap frm, KensaKeikakuDataSource ds)
        {
            mapForm = frm;
            editDataSource = ds;

            InitializeComponent();
        }
        #endregion

        #region KensaMemoList_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaMemoList_Load(object sender, EventArgs e)
        {
            BoundaryUtility.StdLoadEventSequence(
                this, delegate()
                {
                    DoSearch();
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

        #region memoPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memoPrintButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 印刷実行
                    IMemoPrintBtnClickALInput input = new MemoPrintBtnClickALInput();

                    KensaKeikakuDataSet.KensaKeikakuListDataTable table = editDataSource.GetKensaYoteiData();

                    // 抽出条件を取得
                    string filterCond = editDataSource.GetFilterCond();

                    // 抽出条件を適用
                    input.PrintData = (KensaKeikakuDataSet.KensaKeikakuListRow[])table.Select(filterCond, editDataSource.GetOrderStr());

                    input.PrintMemoData = (KensaKeikakuDataSet.KensaKeikakuMemoTblRow[])editDataSource.GetKensaYoteiMemoData().Select(string.Empty);

                    IMemoPrintBtnClickALOutput output = new MemoPrintBtnClickApplicationLogic().Execute(input);
                });
        }
        #endregion

        #region memoListDataGridView_SelectionChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memoListDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (memoListDataGridView.CurrentRow == null)
                    {
                        return;
                    }

                    DataGridViewRow gridRow = memoListDataGridView.CurrentRow;

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

                    if (mapForm != null && mapForm.yoteiForm != null)
                    {
                        mapForm.yoteiForm.SelectKensaYotei((string)gridRow.Cells[colKey.Index].Value);
                    }
                }, false, false);
        }
        #endregion

        #region memoListDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void memoListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 検査予定日が更新された場合は、他の画面に更新を反映する
                    if (e.ColumnIndex == date.Index)
                    {
                        string newDate = (string)memoListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        string key = (string)memoListDataGridView.Rows[e.RowIndex].Cells[colKey.Index].Value;

                        // メモリ上共有データの検査予定日を更新
                        editDataSource.SetKensaYoteiDate(key, newDate);

                        // 子画面の表示を更新
                        if (mapForm != null)
                        {
                            mapForm.SetKensaYoteiDate(key, newDate);
                        }

                        if (mapForm != null && mapForm.yoteiForm != null)
                        {
                            mapForm.yoteiForm.SetKensaYoteiDate(key, newDate);
                        }

                        if (mapForm != null && mapForm.calenderForm != null)
                        {
                            mapForm.calenderForm.UpdateAll();
                        }
                    }
                }, false, false);
        }
        #endregion

        #region DoSearch
        /// <summary>
        /// 
        /// </summary>
        private void DoSearch()
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = editDataSource.GetKensaYoteiData();

            KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable memoTable = editDataSource.GetKensaYoteiMemoData();

            // 抽出条件を取得
            string filterCond = editDataSource.GetFilterCond();

            // 抽出条件を適用
            SetData((KensaKeikakuDataSet.KensaKeikakuListRow[])table.Select(filterCond, editDataSource.GetOrderStr()), memoTable);
        }
        #endregion

        #region SetData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="memoTable"></param>
        private void SetData(IEnumerable<KensaKeikakuDataSet.KensaKeikakuListRow> table, KensaKeikakuDataSet.KensaKeikakuMemoTblDataTable memoTable)
        {
            memoListDataGridView.Rows.Clear();

            KensaKeikakuDataSet.KensaKeikakuListDataTable template = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            for (int i = 0; i < table.Count(); i++)
            {
                KensaKeikakuDataSet.KensaKeikakuListRow row = table.ElementAt(i);

                List<string> memoStrList = new List<string>();

                string key = editDataSource.GetKensaIraiKey(row);

                string dispKey = editDataSource.GetKensaIraiDispKey(row);

                string yoteiDt = editDataSource.GetKensaYoteiDateStr(row);

                // メモ情報取得
                KensaKeikakuDataSet.KensaKeikakuMemoTblRow[] memoRows = (KensaKeikakuDataSet.KensaKeikakuMemoTblRow[])memoTable
                    .Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'"
                        , memoTable.JokasoMemoJokasoHokenjoCdColumn.ColumnName
                        , TypeUtility.GetString(row[template.JokasoHokenjoCdColumn.ColumnName])
                        , memoTable.JokasoMemoJokasoTorokuNendoColumn.ColumnName
                        , TypeUtility.GetString(row[template.JokasoTorokuNendoColumn.ColumnName])
                        , memoTable.JokasoMemoJokasoRenbanColumn.ColumnName
                        , TypeUtility.GetString(row[template.JokasoRenbanColumn.ColumnName])
                    ));

                foreach (KensaKeikakuDataSet.KensaKeikakuMemoTblRow memoRow in memoRows)
                {
                    memoStrList.Add(TypeUtility.GetString(memoRow[memoTable.MemoColumn.ColumnName]));
                }

                #region メモ(3行分)表示

                // 3つ未満の場合でも、3行まで表示する
                memoListDataGridView.Rows.Add(
                    key
                    , yoteiDt
                    , dispKey
                    , TypeUtility.GetString(row[template.JokasoSetchishaNmColumn.ColumnName])
                    , TypeUtility.GetString(row[template.JokasoSetchiBashoAdrColumn.ColumnName])
                    , memoStrList.Count > 0 ? memoStrList[0] : string.Empty
                    );
                memoListDataGridView.Rows.Add(
                     string.Empty
                    , string.Empty
                    , string.Empty
                    , string.Empty
                    , string.Empty
                    , memoStrList.Count > 1 ? memoStrList[1] : string.Empty
                    );
                memoListDataGridView.Rows.Add(
                     string.Empty
                    , string.Empty
                    , string.Empty
                    , string.Empty
                    , string.Empty
                    , memoStrList.Count > 2 ? memoStrList[2] : string.Empty
                    );

                // 当初仕様では、4つ以上は表示しない

                #endregion

            }
        }
        #endregion

        #region 表示連携用インターフェース

        #region SelectKensaYotei
        /// <summary>
        /// 検査予定の選択状態を同期
        /// </summary>
        /// <param name="key"></param>
        public void SelectKensaYotei(string key)
        {
            // 選択部分の行表示を変更する
            foreach (DataGridViewRow gridRow in memoListDataGridView.Rows)
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
        /// 検査予定日更新を同期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="yoteiDate"></param>
        public void SetKensaYoteiDate(string key, string yoteiDate)
        {
            // 選択部分の検査予定日を更新する
            foreach (DataGridViewRow gridRow in memoListDataGridView.Rows)
            {
                if (((string)gridRow.Cells[colKey.Index].Value) == key)
                {
                    // 日付を更新
                    gridRow.Cells[date.Index].Value = yoteiDate;
                    break;
                }
            }
        }
        #endregion

        #region SetJokasoSetchiAddress
        /// <summary>
        /// 浄化槽設置場所の更新を同期
        /// </summary>
        /// <param name="key"></param>
        /// <param name="address"></param>
        public void SetJokasoSetchiAddress(string key, string address)
        {
            // 選択部分の設置場所を更新する
            foreach (DataGridViewRow gridRow in memoListDataGridView.Rows)
            {
                if (((string)gridRow.Cells[colKey.Index].Value) == key)
                {
                    // 設置場所を更新
                    gridRow.Cells[setibasyo.Index].Value = address;
                    break;
                }
            }
        }
        #endregion

        #region 
        /// <summary>
        /// 
        /// </summary>
        public void UpdateFilter()
        {
            DoSearch();
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
