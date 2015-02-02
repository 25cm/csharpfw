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
using Zynas.Framework.Core.Common.Boundary;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri.KensaKeikaku
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/26　habu　　    新規作成
    /// 2014/12/19　habu　　    過去日への振替はできないように修正
    /// 2014/12/19　habu　　    子画面との連携を追加
    /// </history>
    public partial class KensaYoteiCalender : FukjBaseForm
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
        
        #region Fields

        private KensaYoteiCalenderDate[] calenderBoxList;

        private DateTime currentMonth;

        private DateTime shoriDate;

        #endregion

        /// <summary>
        /// 11条検査について、集計を分ける境界値(51人槽以上と、それ以下)
        /// </summary>
        private const int limit11Jo = 51;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public KensaYoteiCalender(KensaYoteiMap frm, KensaKeikakuDataSource ds)
        {
            mapForm = frm;
            editDataSource = ds;

            InitializeComponent();

            #region コントロール配列初期化
            calenderBoxList = new KensaYoteiCalenderDate[]
            {
                kensaYoteiCalenderDate1,
                kensaYoteiCalenderDate2,
                kensaYoteiCalenderDate3,
                kensaYoteiCalenderDate4,
                kensaYoteiCalenderDate5,
                kensaYoteiCalenderDate6,
                kensaYoteiCalenderDate7,
                kensaYoteiCalenderDate8,
                kensaYoteiCalenderDate9,
                kensaYoteiCalenderDate10,
                kensaYoteiCalenderDate11,
                kensaYoteiCalenderDate12,
                kensaYoteiCalenderDate13,
                kensaYoteiCalenderDate14,
                kensaYoteiCalenderDate15,
                kensaYoteiCalenderDate16,
                kensaYoteiCalenderDate17,
                kensaYoteiCalenderDate18,
                kensaYoteiCalenderDate19,
                kensaYoteiCalenderDate20,
                kensaYoteiCalenderDate21,
                kensaYoteiCalenderDate22,
                kensaYoteiCalenderDate23,
                kensaYoteiCalenderDate24,
                kensaYoteiCalenderDate25,
                kensaYoteiCalenderDate26,
                kensaYoteiCalenderDate27,
                kensaYoteiCalenderDate28,
                kensaYoteiCalenderDate29,
                kensaYoteiCalenderDate30,
                kensaYoteiCalenderDate31,
                kensaYoteiCalenderDate32,
                kensaYoteiCalenderDate33,
                kensaYoteiCalenderDate34,
                kensaYoteiCalenderDate35,
                kensaYoteiCalenderDate36,
                kensaYoteiCalenderDate37,
                kensaYoteiCalenderDate38,
                kensaYoteiCalenderDate39,
                kensaYoteiCalenderDate40,
                kensaYoteiCalenderDate41,
                kensaYoteiCalenderDate42,
            };
            #endregion

            // 現在月初期設定
            DateTime temp = Common.Common.GetCurrentTimestamp().Date;
            currentMonth = new DateTime(temp.Year, temp.Month, 1);
            currentMonthTextBox.Text = Utility.DateUtility.ConvertToWareki(currentMonth.ToString("yyyyMMdd"), "gyy年MM月", Utility.DateUtility.GengoKbn.Wareki);

            shoriDate = temp;
        }
        #endregion

        #region KensaYoteiCalender_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaYoteiCalender_Load(object sender, EventArgs e)
        {
            BoundaryUtility.StdLoadEventSequence(
                this, delegate()
                {
                    // 日付ボックスのイベント初期化
                    for (int i = 0; i < calenderBoxList.Length; i++)
                    {
                        SetDragEvents(calenderBoxList[i]);
                    }

                    // カレンダ内容表示
                    UpdateCalenderDisp();
                });
        }
        #endregion

        #region UpdateCalenderDisp
        /// <summary>
        /// 
        /// </summary>
        private void UpdateCalenderDisp()
        {
            // 画面上の現在年月を取得
            DateTime targetMonth = currentMonth;

            // 指定年月の検査依頼データ取得
            KensaKeikakuDataSet.KensaKeikakuListDataTable kensaIraiTable =
                editDataSource.GetNewKensaYoteiData(targetMonth.Year.ToString("0000"), targetMonth.Month.ToString("00"));

            // 既存表示クリア
            for (int i = 0; i < calenderBoxList.Length; i++)
            {
                calenderBoxList[i].ClearDate();
            }

            int initDow = (int)DayOfWeek.Sunday;
            int dowOffset = (int)targetMonth.DayOfWeek - initDow;
            for (int i = 0; i < DateTime.DaysInMonth(targetMonth.Year, targetMonth.Month); i++)
            {
                DateTime currentDate = targetMonth.AddDays(i);
                calenderBoxList[i + dowOffset].SetDate(currentDate);
            }

            // 検査依頼件数データ作成
            for (int i = 0; i < DateTime.DaysInMonth(targetMonth.Year, targetMonth.Month); i++)
            {
                DateTime currentDate = targetMonth.AddDays(i);

                KensaKeikakuDataSet.KensaKeikakuListRow[] kensaIrai7JoRows =
                    (KensaKeikakuDataSet.KensaKeikakuListRow[])kensaIraiTable.Select(
                    string.Format(
                    "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}'"
                    , kensaIraiTable.KensaIraiHoteiKbnColumn.ColumnName
                    , Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN
                    , kensaIraiTable.KensaIraiKensaYoteiNenColumn.ColumnName
                    , currentDate.Year.ToString("0000")
                    , kensaIraiTable.KensaIraiKensaYoteiTsukiColumn.ColumnName
                    , currentDate.Month.ToString("00")
                    , kensaIraiTable.KensaIraiKensaYoteiBiColumn.ColumnName
                    , currentDate.Day.ToString("00")
                    ));

                KensaKeikakuDataSet.KensaKeikakuListRow[] kensaIrai11JoIkaRows =
                    (KensaKeikakuDataSet.KensaKeikakuListRow[])kensaIraiTable.Select(
                    string.Format(
                    "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}' AND {8} <= {9}"
                    , kensaIraiTable.KensaIraiHoteiKbnColumn.ColumnName
                    , Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN
                    , kensaIraiTable.KensaIraiKensaYoteiNenColumn.ColumnName
                    , currentDate.Year.ToString("0000")
                    , kensaIraiTable.KensaIraiKensaYoteiTsukiColumn.ColumnName
                    , currentDate.Month.ToString("00")
                    , kensaIraiTable.KensaIraiKensaYoteiBiColumn.ColumnName
                    , currentDate.Day.ToString("00")
                    , kensaIraiTable.JokasoShoriTaishoJininColumn.ColumnName
                    , (limit11Jo - 1)
                    ));

                KensaKeikakuDataSet.KensaKeikakuListRow[] kensaIrai11JoIzyouRows =
                    (KensaKeikakuDataSet.KensaKeikakuListRow[])kensaIraiTable.Select(
                    string.Format(
                    "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}' AND {8} >= {9}"
                    , kensaIraiTable.KensaIraiHoteiKbnColumn.ColumnName
                    , Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN
                    , kensaIraiTable.KensaIraiKensaYoteiNenColumn.ColumnName
                    , currentDate.Year.ToString("0000")
                    , kensaIraiTable.KensaIraiKensaYoteiTsukiColumn.ColumnName
                    , currentDate.Month.ToString("00")
                    , kensaIraiTable.KensaIraiKensaYoteiBiColumn.ColumnName
                    , currentDate.Day.ToString("00")
                    , kensaIraiTable.JokasoShoriTaishoJininColumn.ColumnName
                    , (limit11Jo)
                    ));

                // 検査件数を算出、設定する
                calenderBoxList[i + dowOffset].SetYoteiCount(
                    kensaIrai7JoRows.Length
                    , kensaIrai11JoIkaRows.Length
                    , kensaIrai11JoIzyouRows.Length);
            }
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
            Close();
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

                    UpdateCalenderDisp();
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

                    UpdateCalenderDisp();
                });
        }
        #endregion

        #region kakuteiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    editDataSource.WriteBackToDB();
                });
        }
        #endregion

        #region Drag関連イベント

        #region SetDragEvents
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        private void SetDragEvents(KensaYoteiCalenderDate text)
        {
            text.MouseDown += delegate(object sender, MouseEventArgs e)
            {
                BoundaryUtility.StdEventSequence(
                    delegate()
                    {
                        // コピー元予定日を転送データとして設定
                        text.DoDragDrop(text.KensaYoteiDay, DragDropEffects.Copy);
                    }, false, false);
            };

            text.DragDrop += delegate(object sender, DragEventArgs e)
            {
                BoundaryUtility.StdEventSequence(
                    delegate()
                    {
                        // 内部保持データ更新(検査予定日を振替)

                        // 移動元検査予定日
                        DateTime fromDate = (DateTime)e.Data.GetData(typeof(DateTime));

                        // 移動先検査予定日
                        DateTime toDate = text.KensaYoteiDay;

                        // 過去日への振替はできない
                        if(shoriDate > toDate)
                        {
                            return;
                        }

                        // 同じ日付での移動は無効
                        if (fromDate == toDate)
                        {
                            return;
                        }

                        // 振替対象データ取得
                        KensaKeikakuDataSet.KensaKeikakuListDataTable kensaIraiTable =
                            editDataSource.GetNewKensaYoteiData(
                            fromDate.Year.ToString("0000")
                            , fromDate.Month.ToString("00"));

                        KensaKeikakuDataSet.KensaKeikakuListRow[] kensaIraiRows =
                            (KensaKeikakuDataSet.KensaKeikakuListRow[])kensaIraiTable.Select(
                            string.Format(
                            "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'"
                            , kensaIraiTable.KensaIraiKensaYoteiNenColumn.ColumnName
                            , fromDate.Year.ToString("0000")
                            , kensaIraiTable.KensaIraiKensaYoteiTsukiColumn.ColumnName
                            , fromDate.Month.ToString("00")
                            , kensaIraiTable.KensaIraiKensaYoteiBiColumn.ColumnName
                            , fromDate.Day.ToString("00")
                            ));

                        // 振替元が0件の場合は処理しない
                        if (kensaIraiRows.Length == 0)
                        {
                            return;
                        }

                        // 確認メッセージを表示する
                        if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査予定日の振替を行いますか?")
                            != DialogResult.Yes)
                        {
                            return;
                        }

                        //// 内部保持データ更新(検査予定日を振替)
                        //// 移動元検査予定日
                        //DateTime fromDate = (DateTime)e.Data.GetData(typeof(DateTime));

                        //// 移動先検査予定日
                        //DateTime toDate = text.KensaYoteiDay;

                        //// 振替対象データ取得
                        //KensaKeikakuDataSet.KensaKeikakuListDataTable kensaIraiTable =
                        //    editSource.GetNewKensaYoteiData(
                        //    fromDate.Year.ToString("0000")
                        //    , fromDate.Month.ToString("00"));

                        //KensaKeikakuDataSet.KensaKeikakuListRow[] kensaIraiRows =
                        //    (KensaKeikakuDataSet.KensaKeikakuListRow[])kensaIraiTable.Select(
                        //    string.Format(
                        //    "{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'"
                        //    , kensaIraiTable.KensaIraiKensaYoteiNenColumn.ColumnName
                        //    , fromDate.Year.ToString("0000")
                        //    , kensaIraiTable.KensaIraiKensaYoteiTsukiColumn.ColumnName
                        //    , fromDate.Month.ToString("00")
                        //    , kensaIraiTable.KensaIraiKensaYoteiBiColumn.ColumnName
                        //    , fromDate.Day.ToString("00")
                        //    ));

                        // 連携更新用データ
                        Dictionary<string, string> updateData = new Dictionary<string, string>();

                        // 振替先の予定日を設定(更新)
                        foreach (KensaKeikakuDataSet.KensaKeikakuListRow row in kensaIraiRows)
                        {
                            row.KensaIraiKensaYoteiNen = toDate.Year.ToString("0000");
                            row.KensaIraiKensaYoteiTsuki = toDate.Month.ToString("00");
                            row.KensaIraiKensaYoteiBi = toDate.Day.ToString("00");

                            string yoteiDt = string.Join("/"
                                , new string[] {
                                     row.KensaIraiKensaYoteiNen
                                    , row.KensaIraiKensaYoteiTsuki
                                    , row.KensaIraiKensaYoteiBi
                                    });

                            updateData.Add(
                                editDataSource.GetKensaIraiKey(row)
                                , yoteiDt);
                        }

                        // 表示連携
                        foreach (string key in updateData.Keys)
                        {
                            string newDate = updateData[key];

                            // 子画面の表示を更新
                            if (mapForm != null)
                            {
                                mapForm.SetKensaYoteiDate(key, newDate);
                            }

                            if (mapForm != null && mapForm.memoForm != null)
                            {
                                mapForm.memoForm.SetKensaYoteiDate(key, newDate);
                            }

                            if (mapForm != null && mapForm.yoteiForm != null)
                            {
                                mapForm.yoteiForm.SetKensaYoteiDate(key, newDate);
                            }
                        }

                        // 表示更新
                        UpdateCalenderDisp();

                    }, false, false);
            };

            text.DragEnter += delegate(object sender, DragEventArgs e)
            {
                {
                    e.Effect = DragDropEffects.Copy;
                }
            };

            text.DragOver += delegate(object sender, DragEventArgs e)
            {
                {
                    e.Effect = DragDropEffects.Copy;
                }
            };
        }
        #endregion

        #endregion

        #region 表示連携用インターフェース

        #region UpdateAll
        /// <summary>
        /// 
        /// </summary>
        public void UpdateAll()
        {
            UpdateCalenderDisp();
        }
        #endregion

        #endregion

    }

    #region KensaYoteiCalenderDate
    /// <summary>
    /// カレンダー日付部分用コントロール
    /// </summary>
    class KensaYoteiCalenderDate : TextBox
    {
        /// <summary>
        /// 日付部分表示ラベル
        /// </summary>
        TextBox DayLabel;

        /// <summary>
        /// 現在表示中の日付
        /// </summary>
        public DateTime KensaYoteiDay;

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public KensaYoteiCalenderDate()
        {
            AllowDrop = true;
            Multiline = true;
            TextAlign = HorizontalAlignment.Right;
            Width = 85;
            Height = 56;
            ReadOnly = true;

            DayLabel = new TextBox();
            Controls.Add(DayLabel);
            DayLabel.Width = 25;
            DayLabel.Height = 22;
            DayLabel.BackColor = SystemColors.ButtonFace;
            DayLabel.TextAlign = HorizontalAlignment.Center;
            DayLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            DayLabel.Location = new Point(0, 0);
            DayLabel.ReadOnly = true;
        }
        #endregion

        #region SetDate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yoteiDay"></param>
        public void SetDate(DateTime yoteiDay)
        {
            KensaYoteiDay = yoteiDay.Date;
            DayLabel.Text = yoteiDay.Day.ToString("00");
        }
        #endregion

        #region ClearDate
        /// <summary>
        /// 
        /// </summary>
        public void ClearDate()
        {
            KensaYoteiDay = DateTime.MinValue.Date;
            Clear();
            DayLabel.Clear();
        }
        #endregion

        #region SetYoteiCount
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yotei7joCnt"></param>
        /// <param name="yotei11JoIkaCnt"></param>
        /// <param name="yotei11JoIzyouCnt"></param>
        public void SetYoteiCount(int yotei7joCnt, int yotei11JoIkaCnt, int yotei11JoIzyouCnt)
        {
            StringBuilder buf = new StringBuilder();
            buf.AppendLine();
            if (yotei7joCnt > 0) { buf.AppendFormat("7条{0}件", yotei7joCnt.ToString("00")); }
            buf.AppendLine();
            if (yotei11JoIkaCnt > 0) { buf.AppendFormat("11条{0}件", yotei11JoIkaCnt.ToString("00")); }
            buf.AppendLine();
            if (yotei11JoIzyouCnt > 0) { buf.AppendFormat("11条{0}件", yotei11JoIzyouCnt.ToString("00")); }

            string yoteiStr = buf.ToString();

            Text = yoteiStr;
        }
        #endregion

    }
    #endregion

}
