using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanri;
using FukjBizSystem.Application.Utility;
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
    /// 2015/02/01　habu　　    種類検査担当者を変更しないように修正
    /// </history>
    public partial class KensaYoteiHeijyunDetailForm : FukjBaseForm
    {
        #region Fields

        private string kensainCdLeft = string.Empty;
        private string kensainCdRight = string.Empty;
        private KensaKeikakuDataSource editDataSource = null;
        private DateTime targetMonth = DateTime.MinValue;

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
        public KensaYoteiHeijyunDetailForm(
            string kensainCdLeft, string kensainCdRight
            , DateTime targetMonth
            , KensaKeikakuDataSource editDataSource)
        {
            InitializeComponent();

            this.kensainCdLeft = kensainCdLeft;
            this.kensainCdRight = kensainCdRight;
            this.targetMonth = targetMonth;
            this.editDataSource = editDataSource;
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
            // 20141219 habu 画面遷移変更
            Program.mForm.MovePrev();
            //Close();
        }
        #endregion

        #region KensaYoteiHeijyunDetailForm_Load
        /// <summary>
        /// 初期ロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaYoteiHeijyunDetailForm_Load(object sender, EventArgs e)
        {
            BoundaryUtility.StdLoadEventSequence(
                this, delegate()
                {
                    table = editDataSource.GetKensaYoteiData();

                    // 検査員表示
                    leftKensainTextBox.Text = GetShokuinNm(kensainCdLeft);
                    rightKensainTextBox.Text = GetShokuinNm(kensainCdRight);

                    SetData(table);
                }
                , closeBody: delegate()
                {
                    DialogResult = DialogResult.Abort;
                    Program.mForm.MovePrev();
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
                    // データ更新
                    editDataSource.WriteBackToDB();
                });

            // 20141219 habu 画面遷移変更
            Program.mForm.MovePrev();
            //Close();
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

                    string fromKensainCd = kensainCdLeft;
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
                    string toKensainCd = kensainCdLeft;

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
                    // 左または右の一覧の検査予定日が変更された場合に処理
                    DataGridView targetDataGrid = (DataGridView)sender;

                    string key = (string)targetDataGrid[e.RowIndex, colKey.Index].Value;

                    string hokenjoCd;
                    string nendo;
                    string renban;

                    string[] keyElems = key.Split(new char[] { '-' });

                    if (keyElems.Length < 3)
                    {
                        return;
                    }

                    hokenjoCd = keyElems[0];
                    nendo = keyElems[1];
                    renban = keyElems[2];

                    // メモリ上データを更新
                    KensaKeikakuDataSet.KensaKeikakuListRow[] kensaRows
                        = (KensaKeikakuDataSet.KensaKeikakuListRow[])table.Select(
                        string.Format(
                        "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'"
                          , table.KensaIraiHokenjoCdColumn.ColumnName
                          , TypeUtility.GetString(hokenjoCd)
                          , table.KensaIraiNendoColumn.ColumnName
                          , TypeUtility.GetString(nendo)
                          , table.KensaIraiRenbanColumn.ColumnName
                          , TypeUtility.GetString(renban)
                        ));

                    if (kensaRows.Length == 0)
                    {
                        return;
                    }

                    string newYoteiDate = (string)targetDataGrid[e.RowIndex, ColKensaYoteiDate.Index].Value;

                    // 入力形式が不正な場合はエラーとする
                    // 日部分に00が入る場合があるがこれは正常のため、エラーとはしない
                    if (!IsValidKensaYoteiDate(newYoteiDate))
                    {
                        return;
                    }

                    // 検査予定日変更を反映
                    kensaRows[0].KensaIraiKensaYoteiNen = newYoteiDate.Substring(0, 4);
                    kensaRows[0].KensaIraiKensaYoteiTsuki = newYoteiDate.Substring(5, 2);
                    kensaRows[0].KensaIraiKensaYoteiBi = newYoteiDate.Substring(8, 2);

                    #region to be removed
                    //DateTime tempDate;

                    //if (!DateTime.TryParseExact(newYoteiDate, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out tempDate))
                    //{
                    //    return;
                    //}

                    //// 検査予定日変更を反映
                    //kensaRows[0].KensaIraiKensaYoteiNen = tempDate.Year.ToString("0000");
                    //kensaRows[0].KensaIraiKensaYoteiTsuki = tempDate.Month.ToString("00");
                    //kensaRows[0].KensaIraiKensaYoteiBi = tempDate.Day.ToString("00");
                    #endregion

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
                    // 左または右の一覧の検査予定日が変更された場合に処理
                    DataGridView targetDataGrid = (DataGridView)sender;

                    if (e.ColumnIndex == ColKensaYoteiDate.Index)
                    {
                        string newYoteiDate = (string)e.FormattedValue;

                        // 入力形式が不正な場合はエラーとする
                        // 日部分に00が入る場合があるがこれは正常のため、エラーとはしない
                        if (!IsValidKensaYoteiDate(newYoteiDate))
                        {
                            e.Cancel = true;
                            return;
                        }

                        string nen = newYoteiDate.Substring(0, 4);
                        string tsuki = newYoteiDate.Substring(5, 2);

                        // 月をまたいだ予定日の変更は禁止する
                        if (targetMonth.Year.ToString("0000") != nen || targetMonth.Month.ToString("00") != tsuki)
                        {
                            e.Cancel = true;
                            return;
                        }

                        #region to be removed
                        //DateTime tempDate;

                        //// 入力形式が不正な場合はエラーとする
                        //if (!DateTime.TryParseExact(newYoteiDate, "yyyy/MM/dd", null, System.Globalization.DateTimeStyles.None, out tempDate))
                        //{
                        //    e.Cancel = true;
                        //    return;
                        //}

                        //// 月をまたいだ予定日の変更は禁止する
                        //if (targetMonth.Year != tempDate.Year || targetMonth.Month != tempDate.Month)
                        //{
                        //    e.Cancel = true;
                        //    return;
                        //}
                        #endregion

                    }
                }, false, false);
        }
        #endregion

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

            var yoteiRows = from yoteiRow in table.AsEnumerable()
                            where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaYoteiNenColumn.ColumnName]) == targetMonth.Year.ToString("0000")
                            && TypeUtility.GetString(yoteiRow[table.KensaIraiKensaYoteiTsukiColumn.ColumnName]) == targetMonth.Month.ToString("00")
                            && TypeUtility.GetString(yoteiRow[table.KensaIraiHoteiKbnColumn.ColumnName]) != Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN
                            select yoteiRow;

            // 検査員毎に絞り込むこと(左と右、2通り)
            // 7条は対象外とする
            {
                var yoteiRowsLeft = from yoteiRow in yoteiRows
                                    where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == kensainCdLeft
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

            // 11条件数(50人槽以下、51人槽以上)をそれぞれ設定する
            {
                var leftMiman = from yoteiRow in yoteiRows
                                where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == kensainCdLeft
                                && (int)yoteiRow[table.JokasoShoriTaishoJininColumn.ColumnName] <= (limit11Jo - 1)
                                select yoteiRow;
                leftMimanTextBox.Text = leftMiman.Count().ToString();
            }
            {
                var leftIzyou = from yoteiRow in yoteiRows
                                where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == kensainCdLeft
                                && (int)yoteiRow[table.JokasoShoriTaishoJininColumn.ColumnName] >= (limit11Jo)
                                select yoteiRow;
                leftIzyouTextBox.Text = leftIzyou.Count().ToString();
            }
            {

                var rightMiman = from yoteiRow in yoteiRows
                                where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == kensainCdRight
                                && (int)yoteiRow[table.JokasoShoriTaishoJininColumn.ColumnName] <= (limit11Jo - 1)
                                select yoteiRow;
                rightMimanTextBox.Text = rightMiman.Count().ToString();
            }
            {

                var rightIzyou = from yoteiRow in yoteiRows
                                 where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == kensainCdRight
                                 && (int)yoteiRow[table.JokasoShoriTaishoJininColumn.ColumnName] >= (limit11Jo)
                                 select yoteiRow;
                rightIzyouTextBox.Text = rightIzyou.Count().ToString();
            }

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
                           where TypeUtility.GetString(yoteiRow[table.KensaIraiKensaYoteiNenColumn.ColumnName]) == targetMonth.Year.ToString("0000")
                           && TypeUtility.GetString(yoteiRow[table.KensaIraiKensaYoteiTsukiColumn.ColumnName]) == targetMonth.Month.ToString("00")
                           && TypeUtility.GetString(yoteiRow[table.KensaIraiHoteiKbnColumn.ColumnName]) != Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN
                           && TypeUtility.GetString(yoteiRow[table.KensaIraiKensaTantoshaCdColumn.ColumnName]) == fromKensainCd
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
                    , (int)row[table.JokasoShoriTaishoJininColumn.ColumnName]
                    , (string)row[table.JokasoSetchiBashoAdrColumn.ColumnName]
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

        #region IsValidKensaYoteiDate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yoteiDt"></param>
        /// <returns></returns>
        private bool IsValidKensaYoteiDate(string yoteiDt)
        {
            if (string.IsNullOrEmpty(yoteiDt))
            {
                return false;
            }

            if (yoteiDt.Length != 10)
            {
                return false;
            }

            int temp = 0;

            string nen = yoteiDt.Substring(0, 4);
            string tsuki = yoteiDt.Substring(5, 2);
            string bi = yoteiDt.Substring(8, 2);

            if (!int.TryParse(nen, out temp))
            {
                return false;
            }
            if (!int.TryParse(tsuki, out temp))
            {
                return false;
            }
            if (!int.TryParse(bi, out temp))
            {
                return false;
            }

            return true;
        }
        #endregion

    }
}
