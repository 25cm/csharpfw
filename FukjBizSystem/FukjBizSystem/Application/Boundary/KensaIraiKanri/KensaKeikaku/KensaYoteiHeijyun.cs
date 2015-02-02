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
    /// </history>
    public partial class KensaYoteiHeijyunForm : FukjBaseForm
    {
        #region Definition

        private const string COL_YOTEI_KADOU_RITSU = "KADOU_YOTEI";
        private const string COL_KENSAIN = "KENSAIN";
        private const string COL_KENSAIN_CD = "KENSAIN_CD";
        private const string COL_7JouCount = "7JouCount";
        private const string COL_11Jou50IkaCount = "COL_11Jou50IkaCount";
        private const string COL_11JouIkaDiff = "11JouIkaDiff";
        private const string COL_11Jou51IzyouCount = "COL_11Jou51IzyouCount";
        private const string COL_11JouIzyouDiff = "11JouIzyouDiff";

        // 検査員未割当の場合の仮のコード
        private readonly string SHOKUIN_CD_NONE = string.Empty;
        private readonly string SHOKUIN_NM_NONE = "(未割当)";

        /// <summary>
        /// 11条検査について、集計を分ける境界値(51人槽以上と、それ以下)
        /// </summary>
        private const int limit11Jo = 51;

        #endregion

        #region Fields

        private KensaKeikakuDataSet.KensaKeikakuListDataTable table = null;

        private KensaKeikakuDataSource editDataSource;

        private DateTime currentMonth;

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public KensaYoteiHeijyunForm()
        {
            InitializeComponent();
        }
        #endregion

        #region KensaYoteiHeijyunForm_Load
        /// <summary>
        /// 初期ロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaYoteiHeijyunForm_Load(object sender, EventArgs e)
        {
            BoundaryUtility.StdLoadEventSequence(
                this, delegate()
                {
                    // 現在月初期設定
                    // 2015.01.05 toyoda Modify Start
                    //DateTime temp = DateTime.Today;
                    DateTime temp = Common.Common.GetCurrentTimestamp().Date;
                    // 2015.01.05 toyoda Modify End

                    currentMonth = new DateTime(temp.Year, temp.Month, 1);
                    currentMonthTextBox.Text = Utility.DateUtility.ConvertToWareki(currentMonth.ToString("yyyyMMdd"), "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki);

                    editDataSource = new KensaKeikakuDataSource();

                    // 編集可能な非結合列はデータ型を指定する
                    kensaTantouListDataGridView.Columns[ColKadouRitsu.Index].ValueType = typeof(decimal);

                    // 年月を変更して再取得・表示
                    UpdateYoteiDisp();

                    ActiveControl = kensaTantouListDataGridView;
                });
        }
        #endregion

        #region closeButton_Click
        /// <summary>
        /// 閉じる
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 20141219 habu 画面遷移変更
                    Program.mForm.MovePrev();
                    //Close();
                });
        }
        #endregion

        #region prevMonthButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prevMonthButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    currentMonth = currentMonth.AddMonths(-1);
                    currentMonthTextBox.Text = Utility.DateUtility.ConvertToWareki(currentMonth.ToString("yyyyMMdd"), "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki);

                    // 年月を変更して再取得・表示
                    UpdateYoteiDisp();
                });
        }
        #endregion

        #region nextMonthButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nextMonthButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    currentMonth = currentMonth.AddMonths(1);
                    currentMonthTextBox.Text = Utility.DateUtility.ConvertToWareki(currentMonth.ToString("yyyyMMdd"), "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki);

                    // 年月を変更して再取得・表示
                    UpdateYoteiDisp();
                });
        }
        #endregion

        #region furikaeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void furikaeButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 2行選択されていない場合は、処理できない
                    if (kensaTantouListDataGridView.SelectedRows.Count < 2)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Warning, "振替を行う検査員を2名選択して下さい");
                        return;
                    }

                    // 選択中の検査員2名を取得
                    string kensainLeft = (string)kensaTantouListDataGridView.SelectedRows[0].Cells[colKensaInCd.Index].Value;
                    string kensainRight = (string)kensaTantouListDataGridView.SelectedRows[1].Cells[colKensaInCd.Index].Value;

                    // 明細画面に遷移し、2検査員間の予定を振替える
                    KensaYoteiHeijyunDetailForm form = new KensaYoteiHeijyunDetailForm(kensainLeft, kensainRight, currentMonth, editDataSource);

                    // 20141219 habu 画面遷移変更
                    Program.mForm.MoveNext(form, DetailEnd);
                    //form.ShowDialog(this);
                    // 振替後、ここに制御が戻る
                    // 初期データ表示
                    // UpdateYoteiDisp();

                });
        }
        #endregion

        #region DetailEnd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        private void DetailEnd(Form form)
        {
            // 初期データ表示
            UpdateYoteiDisp();
        }
        #endregion

        #region kensaTantouListDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kensaTantouListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (e.ColumnIndex == ColKadouRitsu.Index)
                    {
                        // 平均値を再計算する
                        SetAvg();
                    }
                }, false, false);
        }
        #endregion

        #region SetData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        private void SetData(IEnumerable<KensaKeikakuDataSet.KensaKeikakuListRow> rows)
        {
            DataTable aggrTable = new DataTable();
            aggrTable.Columns.Add(COL_KENSAIN, typeof(string));
            aggrTable.Columns.Add(COL_KENSAIN_CD, typeof(string));
            aggrTable.Columns.Add(COL_YOTEI_KADOU_RITSU, typeof(decimal));
            aggrTable.Columns.Add(COL_7JouCount, typeof(int));
            aggrTable.Columns.Add(COL_11Jou50IkaCount, typeof(int));
            aggrTable.Columns.Add(COL_11JouIkaDiff, typeof(int));
            aggrTable.Columns.Add(COL_11Jou51IzyouCount, typeof(int));
            aggrTable.Columns.Add(COL_11JouIzyouDiff, typeof(int));

            // 予定件数合計値
            int ikaSum = 0;
            int izyouSum = 0;
            decimal kensainCnt = 0;

            // 20141226 habu 検査員のみ取得に修正
            // 該当支所の検査員リストを取得
            ShokuinMstDataSet.ShokuinMstDataTable shokuinList = MstUtility.ShokuinMst.GetShokuinMstKensainByShishoCd(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd);
            //ShokuinMstDataSet.ShokuinMstDataTable shokuinList = MstUtility.ShokuinMst.GetShokuinMstByShishoCd(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd);

            // 検査員ごとに予定件数を集計
            var yoteiRowsGroup7 = from yoteiRows in rows.AsEnumerable()
                                  group yoteiRows by TypeUtility.GetString(yoteiRows[table.KensaIraiKensaTantoshaCdColumn.ColumnName])
                                  ;

            // 未割当分の表示内容を生成
            var yetYoteiRowsGroup = from temp in yoteiRowsGroup7
                                    where temp.Key == string.Empty
                                    select temp;

            foreach (var yoteiGroup in yetYoteiRowsGroup)
            {
                {
                    DataRow newRow = aggrTable.NewRow();

                    // 稼働率初期値は1.0
                    newRow[COL_YOTEI_KADOU_RITSU] = 1.0m;

                    newRow[COL_11JouIkaDiff] = 0;
                    newRow[COL_11JouIzyouDiff] = 0;

                    newRow[COL_KENSAIN_CD] = SHOKUIN_CD_NONE;
                    newRow[COL_KENSAIN] = SHOKUIN_NM_NONE;

                    if (yoteiGroup.Count() > 0)
                    {
                        // 検査種別ごとの集計数を設定する
                        newRow[COL_7JouCount] = yoteiGroup.Count((x) => { return (string)x[table.KensaIraiHoteiKbnColumn.ColumnName] == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN; });
                        newRow[COL_11Jou50IkaCount] = yoteiGroup.Count((x) => { return (string)x[table.KensaIraiHoteiKbnColumn.ColumnName] == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN && (int)x[table.JokasoShoriTaishoJininColumn.ColumnName] <= (limit11Jo - 1); });
                        newRow[COL_11Jou51IzyouCount] = yoteiGroup.Count((x) => { return (string)x[table.KensaIraiHoteiKbnColumn.ColumnName] == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN && (int)x[table.JokasoShoriTaishoJininColumn.ColumnName] >= limit11Jo; });
                    }
                    else
                    {
                        // 割当無の場合は0件
                        newRow[COL_7JouCount] = 0;
                        newRow[COL_11Jou50IkaCount] = 0;
                        newRow[COL_11Jou51IzyouCount] = 0;
                    }

                    // 未割当に関しては、平均算出対象にならない

                    aggrTable.Rows.Add(newRow);
                }
            }
            
            // 検査員毎に、表示内容を生成
            foreach (var shokuin in shokuinList)
            {
                {
                    DataRow newRow = aggrTable.NewRow();

                    // 稼働率初期値は1.0
                    newRow[COL_YOTEI_KADOU_RITSU] = 1.0m;

                    newRow[COL_11JouIkaDiff] = 0;
                    newRow[COL_11JouIzyouDiff] = 0;

                    newRow[COL_KENSAIN_CD] = shokuin.ShokuinCd;
                    newRow[COL_KENSAIN] = shokuin.ShokuinNm;

                    var yoteiGroup = from temp in yoteiRowsGroup7
                             where temp.Key == shokuin.ShokuinCd
                             select temp;

                    if (yoteiGroup.Count() > 0 && yoteiGroup.ElementAt(0).Count() > 0)
                    {
                        // 検査種別ごとの集計数を設定する
                        newRow[COL_7JouCount] = yoteiGroup.ElementAt(0).Count((x) => { return (string)x[table.KensaIraiHoteiKbnColumn.ColumnName] == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN; });
                        newRow[COL_11Jou50IkaCount] = yoteiGroup.ElementAt(0).Count((x) => { return (string)x[table.KensaIraiHoteiKbnColumn.ColumnName] == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN && (int)x[table.JokasoShoriTaishoJininColumn.ColumnName] <= (limit11Jo - 1); });
                        newRow[COL_11Jou51IzyouCount] = yoteiGroup.ElementAt(0).Count((x) => { return (string)x[table.KensaIraiHoteiKbnColumn.ColumnName] == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN && (int)x[table.JokasoShoriTaishoJininColumn.ColumnName] >= limit11Jo; });
                    }
                    else
                    {
                        // 割当無の場合は0件
                        newRow[COL_7JouCount] = 0;
                        newRow[COL_11Jou50IkaCount] = 0;
                        newRow[COL_11Jou51IzyouCount] = 0;
                    }

                    // 合計値に加算
                    ikaSum += (int)newRow[COL_11Jou50IkaCount];
                    izyouSum += (int)newRow[COL_11Jou51IzyouCount];

                    kensainCnt += (decimal)newRow[COL_YOTEI_KADOU_RITSU];

                    aggrTable.Rows.Add(newRow);
                }
            }

            // 職員の所属支所が異動になった場合 => 平準化画面では対処しない(個人毎の割当画面を使用する)

            // 集計結果をGridに表示
            SetDispData(aggrTable.Select(string.Empty));

            // 平均値を算出・表示
            SetAvg();
        }
        #endregion

        #region SetDispData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rows"></param>
        private void SetDispData(IEnumerable<DataRow> rows)
        {
            // 集計結果を設定する
            kensaTantouListDataGridView.Rows.Clear();

            int i = 0;
            foreach (DataRow row in rows)
            {
                kensaTantouListDataGridView.Rows.Add(
                    row[COL_KENSAIN_CD]
                    , row[COL_KENSAIN]
                    , row[COL_YOTEI_KADOU_RITSU]
                    , row[COL_11Jou50IkaCount]
                    , row[COL_11JouIkaDiff]
                    , row[COL_11Jou51IzyouCount]
                    , row[COL_11JouIzyouDiff]
                    , row[COL_7JouCount]
                    );
                i++;
            }
        }
        #endregion

        #region SetAvg
        /// <summary>
        /// 
        /// </summary>
        private void SetAvg()
        {
            // 予定件数合計値
            int ikaSum = 0;
            int izyouSum = 0;
            decimal kensainCnt = 0;

            foreach (DataGridViewRow gridRow in kensaTantouListDataGridView.Rows)
            {
                // 未割当の場合はスキップ
                if ((string)(gridRow.Cells[colKensaInCd.Index].Value) == SHOKUIN_CD_NONE)
                {
                    continue;
                }

                // 合計値に加算
                ikaSum += (int)gridRow.Cells[Col11JouIka.Index].Value;
                izyouSum += (int)gridRow.Cells[Col11JouIzyou.Index].Value;

                kensainCnt += (decimal)gridRow.Cells[ColKadouRitsu.Index].Value;
            }

            // 平均値算出(50人以下、51人以上)(予定0件の場合は、0扱いとする)
            int ikaAvg = kensainCnt > 0 ? (int)(ikaSum / kensainCnt) : 0;
            int izyouAvg = kensainCnt > 0 ? (int)(izyouSum / kensainCnt) : 0;

            avg11JouIkaTextBox.Text = ikaAvg.ToString();
            avg11JouIzyouTextBox.Text = izyouAvg.ToString();

            // 各検査員ごとの平均値との差の算出
            foreach (DataGridViewRow gridRow in kensaTantouListDataGridView.Rows)
            {
                gridRow.Cells[Col11JouIkaDiff.Index].Value = (int)gridRow.Cells[Col11JouIka.Index].Value - ikaAvg;
                gridRow.Cells[Col11JouIzyouDiff.Index].Value = (int)gridRow.Cells[Col11JouIzyou.Index].Value - izyouAvg;
            }
        }
        #endregion

        #region UpdateCalenderDisp
        /// <summary>
        /// 
        /// </summary>
        private void UpdateYoteiDisp()
        {
            // 画面上の現在年月を取得
            DateTime targetMonth = currentMonth;

            // 指定年月の検査依頼データ取得
            table = editDataSource.GetNewKensaYoteiData(targetMonth.Year.ToString("0000"), targetMonth.Month.ToString("00"));

            // 既存表示クリア
            kensaTantouListDataGridView.Rows.Clear();

            var kensaIraiRows = from kensaIraiRow in table
                                where TypeUtility.GetString(kensaIraiRow[table.KensaIraiKensaYoteiNenColumn.ColumnName]) == targetMonth.Year.ToString("0000")
                                && TypeUtility.GetString(kensaIraiRow[table.KensaIraiKensaYoteiTsukiColumn.ColumnName]) == targetMonth.Month.ToString("00")
                                select kensaIraiRow;

            SetData(kensaIraiRows);
        }
        #endregion

    }
}
