using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.RyosyuPrint;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.YoshiHanbaiKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： RyosyuPrintForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24　HuyTX  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class RyosyuPrintForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// yoshiHanbaiChumonNo
        /// </summary>
        private string _yoshiHanbaiChumonNo = string.Empty;

        /// <summary>
        /// yoshiHanbaiDt
        /// </summary>
        private string _yoshiHanbaiDt = string.Empty;

        /// <summary>
        /// gyoshaNm
        /// </summary>
        private string _gyoshaNm = string.Empty;

        /// <summary>
        /// yoshiHanbaiGokeiKingaku
        /// </summary>
        private string _yoshiHanbaiGokeiKingaku = string.Empty;

        /// <summary>
        /// hoteiKanriMstDT
        /// </summary>
        private YoshiHanbaiHdrTblDataSet.RyosyuPrintInfoDataTable _ryosyuPrintInfoDataTable = new YoshiHanbaiHdrTblDataSet.RyosyuPrintInfoDataTable();

        /// <summary>
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime = Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： RyosyuPrintForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public RyosyuPrintForm()
        {
            InitializeComponent();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： RyosyuPrintForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <param name="yoshiHanbaiChumonNo"></param>
        /// <param name="gyoshaNm"></param>
        /// <param name="yoshiHanbaiDt"></param>
        /// <param name="yoshiHanbaiGokeiKingaku"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public RyosyuPrintForm(string yoshiHanbaiChumonNo, string yoshiHanbaiDt, string gyoshaNm, string yoshiHanbaiGokeiKingaku)
        {
            InitializeComponent();

            this._yoshiHanbaiChumonNo = yoshiHanbaiChumonNo;
            this._yoshiHanbaiDt = yoshiHanbaiDt;
            this._gyoshaNm = gyoshaNm;
            this._yoshiHanbaiGokeiKingaku = yoshiHanbaiGokeiKingaku;
        }
        #endregion

        #region イベント

        #region RyosyuPrintForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： RyosyuPrintForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RyosyuPrintForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                atenaTextBox.Text = _gyoshaNm;
                outputDtDateTimePicker.Value = _currentDateTime;

                IFormLoadALInput alInput = new FormLoadALInput();
                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

                _ryosyuPrintInfoDataTable = alOutput.RyosyuPrintInfoDataTable;

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region clearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                atenaTextBox.Text = string.Empty;
                outputDtDateTimePicker.Value = _currentDateTime;

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region printButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： printButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "領収書を印刷します。よろしいですか？") != DialogResult.Yes) return;

                _ryosyuPrintInfoDataTable[0].GyoshaNm = atenaTextBox.Text.Trim();
                _ryosyuPrintInfoDataTable[0].YoshiHanbaiDt = outputDtDateTimePicker.Value.ToString("yyyyMMdd");
                _ryosyuPrintInfoDataTable[0].YoshiHanbaiChumonNo = _yoshiHanbaiChumonNo;
                _ryosyuPrintInfoDataTable[0].YoshiHanbaiGokeiKingaku = Decimal.Parse(_yoshiHanbaiGokeiKingaku);

                PrintBtnClickALInput alInput = new PrintBtnClickALInput();
                alInput.RyosyuPrintInfoDataTable = _ryosyuPrintInfoDataTable;
                new PrintBtnClickApplicationLogic().Execute(alInput);

            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region tojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

    }
    #endregion
}
