using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaYoteiWariate;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanri;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成(検査予定平準から派生)
    /// 2015/02/01　habu　　    種類検査担当者は更新しないように修正
    /// </history>
    public partial class KensaYoteiWariateForm : FukjBaseForm
    {
        #region Fields

        private string kensainCdRight = string.Empty;

        private KensaKeikakuDataSet.KensaKeikakuListDataTable table = null;

        /// <summary>
        /// 11条検査について、集計を分ける境界値(51人槽以上と、それ以下)
        /// </summary>
        private const int limit11Jo = 51;

        // 検査員未割当の場合の仮のコード
        private readonly string SHOKUIN_CD_NONE = string.Empty;
        private readonly string SHOKUIN_NM_NONE = "(未割当)";

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensainCdLeft"></param>
        /// <param name="kensainCdRight"></param>
        /// <param name="editDataSource"></param>
        public KensaYoteiWariateForm()
        {
            InitializeComponent();

            // ログイン職員を対象とする
            string targetShokuinCd = FukjBizSystem.Application.Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;

            this.kensainCdRight = targetShokuinCd;

            SetControlDomain();
        }
        #endregion

        #region closeButton_Click
        /// <summary>
        /// 閉じるボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            Program.mForm.MovePrev();
        }
        #endregion

        #region KensaYoteiWariateForm_Load
        /// <summary>
        /// 初期ロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaYoteiWariateForm_Load(object sender, EventArgs e)
        {
            BoundaryUtility.StdLoadEventSequence(
                this, delegate()
                {
                    // 割当対象検査予定取得
                    string shishoCd = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

                    IDataLoadALInput input = new DataLoadALInput();
                    input.SishoCd = shishoCd;
                    input.ShokuinCd = kensainCdRight;
                    IDataLoadALOutput output = new DataLoadApplicationLogic().Execute(input);

                    table = output.EditDataTable;

                    // 検査員表示
                    rightKensainTextBox.Text = GetShokuinNm(kensainCdRight);

                    // 取得データを画面に設定
                    SetData(table);
                });
        }
        #endregion

        #region kakuteiButton_Click
        /// <summary>
        /// 確定ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question
                        , "選択された検査予定の割当を行います。よろしいですか?")
                        != DialogResult.Yes)
                    {
                        return;
                    }

                    DateTime shoriDt = Common.Common.GetCurrentTimestamp();

                    // 更新データ作成
                    KensaIraiTblDataSet.KensaIraiTblDataTable newTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                    new DataBindingHelper().CopyDataTable(newTable, table);

                    // 検査依頼ステータスを割当済みに設定
                    foreach (KensaIraiTblDataSet.KensaIraiTblRow row in newTable)
                    {
                        string newStatus = string.Empty;

                        bool tantoSet = false;
                        bool yoteiBiSet = false;

                        if (!string.IsNullOrEmpty(TypeUtility.GetString(row[newTable.KensaIraiKensaTantoshaCdColumn])))
                        {
                            tantoSet = true;
                        }

                        // 予定の日付まで決定した時点で予定日決定とする
                        if (!string.IsNullOrEmpty(TypeUtility.GetString(row[newTable.KensaIraiKensaYoteiNenColumn]))
                            && !string.IsNullOrEmpty(TypeUtility.GetString(row[newTable.KensaIraiKensaYoteiTsukiColumn]))
                            && !string.IsNullOrEmpty(TypeUtility.GetString(row[newTable.KensaIraiKensaYoteiBiColumn]))
                            && TypeUtility.GetString(row[newTable.KensaIraiKensaYoteiBiColumn]) != "00")
                        {
                            yoteiBiSet = true;
                        }

                        // 要員、予定日が決定した場合計画済み
                        if (tantoSet && yoteiBiSet)
                        {
                            newStatus = Utility.Constants.KensaIraiStatusConstant.STATUS_YOTEI_KEIKAKU_ZUMI;
                        }
                        // 要員のみの場合、要員割当済み
                        else if (tantoSet && !yoteiBiSet)
                        {
                            newStatus = Utility.Constants.KensaIraiStatusConstant.STATUS_TANTOU_WARIATE_ZUMI;
                        }
                        // 予定日のみの場合、依頼登録済み
                        else if (!tantoSet && yoteiBiSet)
                        {
                            newStatus = Utility.Constants.KensaIraiStatusConstant.STATUS_IRAI_TOROKU;
                        }
                        else
                        {
                            newStatus = Utility.Constants.KensaIraiStatusConstant.STATUS_IRAI_TOROKU;
                        }

                        string oldStatus = TypeUtility.GetString(row[newTable.KensaIraiStatusKbnColumn]);

                        // 不要な更新は行わない様にする
                        if (newStatus != oldStatus)
                        {
                            row.KensaIraiStatusKbn = newStatus;
                        }

                        // 担当者またはステータスの変更があった場合は、更新情報を設定する
                        if (row.RowState == DataRowState.Modified)
                        {
                            row.UpdateDt = shoriDt;
                            row.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                            row.UpdateTarm = Dns.GetHostName();
                        }
                    }

                    // データ更新
                    IDecisionBtnClickALInput input = new DecisionBtnClickALInput();
                    input.KensaIraiUpdateData = newTable;
                    IDecisionBtnClickALOutput output = new DecisionBtnClickApplicationLogic().Execute(input);

                    Program.mForm.MovePrev();
                });
        }
        #endregion

        #region rightButton_Click
        /// <summary>
        /// 右移動ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rightButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    DataGridView fromGrid = leftDataGridView;

                    string fromKensainCd = SHOKUIN_CD_NONE;
                    string toKensainCd = kensainCdRight;

                    // 選択行がない場合はキャンセル
                    if (fromGrid.SelectedRows.Count == 0)
                    {
                        return;
                    }

                    // 振替実行
                    MoveKensaYotei(fromKensainCd, toKensainCd, fromGrid);
                });
        }
        #endregion

        #region leftButton_Click
        /// <summary>
        /// 左移動ボタン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void leftButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    DataGridView fromGrid = rightDataGridView;

                    string fromKensainCd = kensainCdRight;
                    string toKensainCd = SHOKUIN_CD_NONE;

                    // 選択行がない場合はキャンセル
                    if (fromGrid.SelectedRows.Count == 0)
                    {
                        return;
                    }

                    // 振替実行
                    MoveKensaYotei(fromKensainCd, toKensainCd, fromGrid);
                });
        }
        #endregion

        #region listDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    //// 左または右の一覧の検査予定日が変更された場合に処理
                    //DataGridView targetDataGrid = (DataGridView)sender;

                    //string key = (string)targetDataGrid[e.RowIndex, colKey.Index].Value;

                    //string hokenjoCd;
                    //string nendo;
                    //string renban;

                    //string[] keyElems = key.Split(new char[] { '-' });

                    //if (keyElems.Length < 3)
                    //{
                    //    return;
                    //}

                    //hokenjoCd = keyElems[0];
                    //nendo = keyElems[1];
                    //renban = keyElems[2];

                    //// メモリ上データを更新
                    //KensaKeikakuDataSet.KensaKeikakuListRow[] kensaRows
                    //    = (KensaKeikakuDataSet.KensaKeikakuListRow[])table.Select(
                    //    string.Format(
                    //    "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'"
                    //      , table.KensaIraiHokenjoCdColumn.ColumnName
                    //      , TypeUtility.GetString(hokenjoCd)
                    //      , table.KensaIraiNendoColumn.ColumnName
                    //      , TypeUtility.GetString(nendo)
                    //      , table.KensaIraiRenbanColumn.ColumnName
                    //      , TypeUtility.GetString(renban)
                    //    ));

                    //if (kensaRows.Length == 0)
                    //{
                    //    return;
                    //}

                    //string newYoteiDate = (string)targetDataGrid[e.RowIndex, ColKensaYoteiDate.Index].Value;

                    //DateTime tempDate;

                    //// 入力形式が不正な場合はエラーとする
                    //if (!DateTime.TryParseExact(newYoteiDate, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out tempDate))
                    //{
                    //    return;
                    //}

                    //// 検査予定日変更を反映
                    //kensaRows[0].KensaIraiKensaYoteiNen = tempDate.Year.ToString("0000");
                    //kensaRows[0].KensaIraiKensaYoteiTsuki = tempDate.Month.ToString("00");
                    //kensaRows[0].KensaIraiKensaYoteiBi = tempDate.Day.ToString("00");
                }, false, false);
        }
        #endregion

        #region listDataGridView_CellValidating
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listDataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    //// 左または右の一覧の検査予定日が変更された場合に処理
                    //DataGridView targetDataGrid = (DataGridView)sender;

                    //if (e.ColumnIndex == ColKensaYoteiDate.Index)
                    //{
                    //    string newYoteiDate = (string)e.FormattedValue;

                    //    DateTime tempDate;

                    //    // 入力形式が不正な場合はエラーとする
                    //    if (!DateTime.TryParseExact(newYoteiDate, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out tempDate))
                    //    {
                    //        e.Cancel = true;
                    //        return;
                    //    }

                    //    // 月をまたいだ予定日の変更は禁止する
                    //    if (targetMonth.Year != tempDate.Year || targetMonth.Month != tempDate.Month)
                    //    {
                    //        e.Cancel = true;
                    //        return;
                    //    }
                    //}
                }, false, false);
        }
        #endregion

        #region filterButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void filterButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 抽出条件を適用し、再検索
                    SetData(table);
                });
        }
        #endregion

        private delegate bool FilterEval(KensaKeikakuDataSet.KensaKeikakuListRow row);

        #region SetData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        private void SetData(KensaKeikakuDataSet.KensaKeikakuListDataTable table)
        {
            int selLeft = -1;
            int selRight = -1;

            // 選択行を退避
            if (leftDataGridView.CurrentRow != null) { selLeft = leftDataGridView.CurrentRow.Index; }
            if (rightDataGridView.CurrentRow != null) { selRight = rightDataGridView.CurrentRow.Index; }

            // 抽出条件を設定
            FilterEval filt = (row) =>
            {
                if (kensaYoteiDateRadioButton.Checked)
                {
                    string date = TypeUtility.GetString(row[table.KensaIraiKensaYoteiNenColumn])
                        + TypeUtility.GetString(row[table.KensaIraiKensaYoteiTsukiColumn])
                        + TypeUtility.GetString(row[table.KensaIraiKensaYoteiBiColumn])
                        ;

                    if (!string.IsNullOrEmpty(kensaYoteiFromDateTextBox.Text))
                    {
                        if (string.Compare(kensaYoteiFromDateTextBox.Text, date) > 0)
                        { return false; }
                    }
                    if (!string.IsNullOrEmpty(kensaYoteiToDateTextBox.Text))
                    {
                        if (string.Compare(kensaYoteiToDateTextBox.Text, date) < 0)
                        { return false; }
                    }
                }
                else
                {
                    string date = TypeUtility.GetString(row[table.KensaIraiKensaYoteiNenColumn])
                        + TypeUtility.GetString(row[table.KensaIraiKensaYoteiTsukiColumn])
                        ;

                    if (!string.IsNullOrEmpty(kensaYoteiFromMonthTextBox.Text))
                    {
                        if (string.Compare(kensaYoteiFromMonthTextBox.Text, date) > 0)
                        { return false; }
                    }
                    if (!string.IsNullOrEmpty(kensaYoteiToMonthTextBox.Text))
                    {
                        if (string.Compare(kensaYoteiToMonthTextBox.Text, date) < 0)
                        { return false; }
                    }
                }

                if (!string.IsNullOrEmpty(setchiBashoTextBox.Text))
                {
                    if(!TypeUtility.GetString(row[table.JokasoSetchiBashoAdrColumn.ColumnName]).Contains(setchiBashoTextBox.Text))
                    {
                        return false;
                    }
                }

                return true;
            };

            var yoteiRows = from yoteiRow in table.AsEnumerable()
                            where filt(yoteiRow)
                            select yoteiRow;

            // 検査員毎に絞り込むこと(左と右、2通り)
            {
                var yoteiRowsLeft = from yoteiRow in yoteiRows
                                    where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == SHOKUIN_CD_NONE
                                    select yoteiRow;

                SetDataLeft(yoteiRowsLeft);
            }
            {
                var yoteiRowsRight = from yoteiRow in yoteiRows
                                     where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == kensainCdRight
                                     select yoteiRow;

                SetDataRight(yoteiRowsRight);
            }

            #region 合計検査件数初期設定

            //// 11条件数(50人槽以下、51人槽以上)をそれぞれ設定する
            //{
            //    var leftMiman = from yoteiRow in yoteiRows
            //                    where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == SHOKUIN_CD_NONE
            //                    && (int)yoteiRow[table.JokasoShoriTaishoJininColumn.ColumnName] <= (limit11Jo - 1)
            //                    select yoteiRow;
            //    leftMimanTextBox.Text = leftMiman.Count().ToString();
            //}
            //{
            //    var leftIzyou = from yoteiRow in yoteiRows
            //                    where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == SHOKUIN_CD_NONE
            //                    && (int)yoteiRow[table.JokasoShoriTaishoJininColumn.ColumnName] >= (limit11Jo)
            //                    select yoteiRow;
            //    leftIzyouTextBox.Text = leftIzyou.Count().ToString();
            //}
            //{

            //    var rightMiman = from yoteiRow in yoteiRows
            //                    where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == kensainCdRight
            //                    && (int)yoteiRow[table.JokasoShoriTaishoJininColumn.ColumnName] <= (limit11Jo - 1)
            //                    select yoteiRow;
            //    rightMimanTextBox.Text = rightMiman.Count().ToString();
            //}
            //{

            //    var rightIzyou = from yoteiRow in yoteiRows
            //                     where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == kensainCdRight
            //                     && (int)yoteiRow[table.JokasoShoriTaishoJininColumn.ColumnName] >= (limit11Jo)
            //                     select yoteiRow;
            //    rightIzyouTextBox.Text = rightIzyou.Count().ToString();
            //}

            #endregion

            // 選択行を復元
            if (selLeft >= 0 && selLeft < leftDataGridView.Rows.Count) { leftDataGridView.Rows[selLeft].Selected = true; }
            if (selRight >= 0 && selRight < rightDataGridView.Rows.Count) { rightDataGridView.Rows[selRight].Selected = true; }
        }
        #endregion

        #region MoveKensaYotei
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromGrid"></param>
        /// <param name="fromMimanTextBox"></param>
        /// <param name="fromIzyouTextBox"></param>
        /// <param name="toGrid"></param>
        /// <param name="toMimanTextBox"></param>
        /// <param name="toIzyouTextBox"></param>
        private void MoveKensaYotei(string fromKensainCd, string toKensainCd, DataGridView fromGrid)
        {
            // 振替対象のキーを抽出(一覧で現在選択されているもの)
            List<string> targetKeyList = new List<string>();
            foreach (DataGridViewRow gridRow in fromGrid.SelectedRows)
            {
                targetKeyList.Add((string)gridRow.Cells[colKey.Index].Value);
            }

            // 振替元データ抽出
            var fromRows = from yoteiRow in table.AsEnumerable()
                           where
                           TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == fromKensainCd
                           select yoteiRow;

            string toNm = GetShokuinNm(toKensainCd);

            foreach (KensaKeikakuDataSet.KensaKeikakuListRow row in fromRows)
            {
                // 対象外の場合はスキップ
                if (!targetKeyList.Contains(GetKensaIraiKey(row)))
                {
                    continue;
                }

                if (toKensainCd != SHOKUIN_CD_NONE)
                {
                    row.KensaIraiKensaTantoshaCd = toKensainCd;
                }
                // 未割当との振替の場合は別に扱う(空を設定する)
                else
                {
                    row.KensaIraiKensaTantoshaCd = string.Empty;
                }
            }

            // 表示更新
            SetData(table);
        }
        #endregion

        #region SetDataLeft
        /// <summary>
        /// 左側ペインにデータを設定
        /// </summary>
        /// <param name="rows"></param>
        private void SetDataLeft(IEnumerable<KensaKeikakuDataSet.KensaKeikakuListRow> rows)
        {
            SetDispData(leftDataGridView, rows);
        }
        #endregion

        #region SetDataRight
        /// <summary>
        /// 右側ペインにデータを設定
        /// </summary>
        /// <param name="rows"></param>
        private void SetDataRight(IEnumerable<KensaKeikakuDataSet.KensaKeikakuListRow> rows)
        {
            SetDispData(rightDataGridView, rows);
        }
        #endregion

        #region SetData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="targetGrid"></param>
        /// <param name="rows"></param>
        private void SetDispData(DataGridView targetGrid, IEnumerable<KensaKeikakuDataSet.KensaKeikakuListRow> rows)
        {
            targetGrid.Rows.Clear();

            int i = 0;
            foreach (KensaKeikakuDataSet.KensaKeikakuListRow row in rows)
            {
                targetGrid.Rows.Add(
                     GetKensaIraiKey(row)
                    , GetKensaYoteiDateStr(row)
                    , TypeUtility.GetString(row[table.KensaIraiHoteiKbnNmColumn.ColumnName])
                    , TypeUtility.GetInt(row[table.JokasoShoriTaishoJininColumn.ColumnName])
                    , TypeUtility.GetString(row[table.JokasoSetchiBashoAdrColumn.ColumnName])
                    );
                i++;
            }
        }
        #endregion

        #region GetKensaIraiKey
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetKensaIraiKey(KensaKeikakuDataSet.KensaKeikakuListRow row)
        {
            KensaKeikakuDataSet.KensaKeikakuListDataTable table = new KensaKeikakuDataSet.KensaKeikakuListDataTable();

            string key =
                string.Join("-"
                , new string[]
                {
                    TypeUtility.GetString(row[table.KensaIraiHoteiKbnColumn.ColumnName])
                    , TypeUtility.GetString(row[table.KensaIraiHokenjoCdColumn.ColumnName])
                    , TypeUtility.GetString(row[table.KensaIraiNendoColumn.ColumnName])
                    , TypeUtility.GetString(row[table.KensaIraiRenbanColumn.ColumnName])
                });

            return key;
        }
        #endregion

        #region GetKensaYoteiDateStr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <returns></returns>
        private string GetKensaYoteiDateStr(KensaKeikakuDataSet.KensaKeikakuListRow row)
        {
            string nen = TypeUtility.GetString(row[table.KensaIraiKensaYoteiNenColumn.ColumnName]);
            string tsuki = TypeUtility.GetString(row[table.KensaIraiKensaYoteiTsukiColumn.ColumnName]);
            string bi = TypeUtility.GetString(row[table.KensaIraiKensaYoteiBiColumn.ColumnName]);

            string yoteiDt = string.Empty;

            if (!string.IsNullOrEmpty(tsuki) && !string.IsNullOrEmpty(bi))
            {
                yoteiDt = string.Join("/"
                    , new string[] {
                    nen
                    , tsuki
                    , bi
                    });
            }

            return yoteiDt;
        }
        #endregion

        #region GetShokuinNm
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokuinCd"></param>
        /// <returns></returns>
        private string GetShokuinNm(string shokuinCd)
        {
            string toNm = string.Empty;

            if (shokuinCd != SHOKUIN_CD_NONE)
            {
                ShokuinMstDataSet.ShokuinMstDataTable tbl = MstUtility.ShokuinMst.GetShokuinMstByShokuinCd(shokuinCd);
                if (tbl.Count > 0)
                {
                    toNm = tbl[0].ShokuinNm;
                }
            }
            else
            {
                toNm = SHOKUIN_NM_NONE;
            }

            return toNm;
        }
        #endregion

        #region SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        private void SetControlDomain()
        {
            kensaYoteiFromDateTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 8);
            kensaYoteiToDateTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 8);
            kensaYoteiFromMonthTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 6);
            kensaYoteiToMonthTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 6);

            setchiBashoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);

            leftDataGridView.SetStdControlDomain(ColNinsou.Index, ZControlDomain.ZG_STD_NUM);
            rightDataGridView.SetStdControlDomain(ColNinsou.Index, ZControlDomain.ZG_STD_NUM);
        }
        #endregion

    }
}
