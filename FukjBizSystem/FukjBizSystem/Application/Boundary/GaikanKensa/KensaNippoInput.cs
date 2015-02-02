using System;
using System.Data;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaNippoInput;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Control.ZDataGridView;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputShosaiForm
    /// <summary>
    /// 検査結果入力（詳細）
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  AnhNV        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaNippoInputForm : FukjBaseForm
    {
        #region NippoVariable
        /// <summary>
        /// NippoVariable
        /// </summary>
        struct NippoVariable
        {
            /// <summary>
            /// 月走行距離
            /// </summary>
            private double monthSokoKyori;
            public double MonthSokoKyori
            {
                get { return monthSokoKyori; }
                set { monthSokoKyori = (value > 0) ? value : 0; }
            }

            /// <summary>
            /// 総走行距離
            /// </summary>
            private double yearSokoKyori;
            public double YearSokoKyori
            {
                get { return yearSokoKyori; }
                set { yearSokoKyori = (value > 0) ? value : 0; }
            }

            /// <summary>
            /// 総給油量
            /// </summary>
            private double totalKyuyu;
            public double TotalKyuyu
            {
                get { return totalKyuyu; }
                set { totalKyuyu = (value > 0) ? value : 0; }
            }

            /// <summary>
            /// 前回給油総走行距離
            /// </summary>
            private double zenkaiSokoKyori;
            public double ZenkaiSokoKyori
            {
                get { return zenkaiSokoKyori; }
                set { zenkaiSokoKyori = (value > 0) ? value : 0; }
            }

            /// <summary>
            /// 前回給油量
            /// </summary>
            private double zenkaiKyuyu;
            public double ZenkaiKyuyu
            {
                get { return zenkaiKyuyu; }
                set { zenkaiKyuyu = (value > 0) ? value : 0; }
            }

            /// <summary>
            /// 前々回給油総走行距離
            /// </summary>
            private double zenzenkaiSokoKyori;
            public double ZenzenkaiSokoKyori
            {
                get { return zenzenkaiSokoKyori; }
                set { zenzenkaiSokoKyori = (value > 0) ? value : 0; }
            }
        }
        #endregion

        #region SessionStored
        /// <summary>
        /// Values when load form
        /// </summary>
        class SessionStored
        {
            /// <summary>
            /// 検査員(1)
            /// </summary>
            public string KensainCd { get; set; }
            /// <summary>
            /// 検査日(2) - yyyyMMdd
            /// </summary>
            public string KensaDt { get; set; }
            /// <summary>
            /// 当月稼働日数(45)
            /// </summary>
            public string TougetsuNissu { get; set; }
            /// <summary>
            /// 稼働日数合計(46)
            /// </summary>
            public string TotalNissu { get; set; }
            /// <summary>
            /// 月平均稼働日数(47)
            /// </summary>
            public string MonthAveNissu { get; set; }
            /// <summary>
            /// 当月件数(48)
            /// </summary>
            public string TougetsuKensu { get; set; }
            /// <summary>
            /// 件数合計(49)
            /// </summary>
            public string TotalKensu { get; set; }
            /// <summary>
            /// 日平均件数(50)
            /// </summary>
            public string DayAveKensu { get; set; }
            /// <summary>
            /// 実走行距離（日）(51)
            /// </summary>
            public string SokoKyori { get; set; }
            /// <summary>
            /// 実走行距離（月）(52)
            /// </summary>
            public string MonthSokoKyori { get; set; }
            /// <summary>
            /// 総走行距離（年）(53)
            /// </summary>
            public string YearSokoKyori { get; set; }
            /// <summary>
            /// 給油(54)
            /// </summary>
            public string Kyuyu { get; set; }
            /// <summary>
            /// 最近の燃費(55)
            /// </summary>
            public string Nenpi { get; set; }
            /// <summary>
            /// 総給油量(56)
            /// </summary>
            public string TotalKyuyu { get; set; }
            /// <summary>
            /// 検査時間計(57)
            /// </summary>
            public string TotalKensaTime { get; set; }
            /// <summary>
            /// 累計検査時間(58)
            /// </summary>
            public string RuikeiKensaTime { get; set; }
            /// <summary>
            /// クロスチェック現地調査(59)
            /// </summary>
            public string CrossCheck { get; set; }
            /// <summary>
            /// 実地調査件数(60)
            /// </summary>
            public string JittiChosaKensu { get; set; }
            /// <summary>
            /// 超過原因調査件数(61)
            /// </summary>
            public string ChokaGenin { get; set; }
            /// <summary>
            /// 車両点検記録(62)
            /// </summary>
            public string SyaryoTenken { get; set; }
            /// <summary>
            /// 報告事項等(64)
            /// </summary>
            public string HokokuJiko { get; set; }
            /// <summary>
            /// 管理職の指示内容(65)
            /// </summary>
            public string KanrisyaShiji { get; set; }
            /// <summary>
            /// 検査完了(66)
            /// </summary>
            public bool KensaKanryo { get; set; }
            /// <summary>
            /// 副課長確認(67)
            /// </summary>
            public bool FukuKachoKakunin { get; set; }
            /// <summary>
            /// 課長確認(68)
            /// </summary>
            public bool KachoKakunin { get; set; }
            /// <summary>
            /// Source table of 検査実施一覧グリッドビュー(7)
            /// </summary>
            public KensaIraiTblDataSet.KensaNippoInputDataTable JisshiSource { get; set; }
            /// <summary>
            /// Source table of 検査中止一覧グリッドビュー(31)
            /// </summary>
            public KensaIraiTblDataSet.KensaNippoInputDataTable ChushiSource { get; set; }
	
			/// <summary>
            /// コンストラクタ
            /// </summary>
            public SessionStored()
            {
                JisshiSource = new KensaIraiTblDataSet.KensaNippoInputDataTable();
                ChushiSource = new KensaIraiTblDataSet.KensaNippoInputDataTable();
            }
        }
        #endregion

        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            InputKey,       // キー入力待ちモード
            Add,            // 新規登録モード
            Edit,           // 編集モード
            NonEditable     // 編集不可モード
        }

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public DispMode _dispMode;

        #endregion

        #region プロパティ(private)
        
        /// <summary>
        /// 検査員コード
        /// </summary>
        private string _nippoKensainCd;

        /// <summary>
        /// 検査日
        /// </summary>
        private string _nippoKensaDt;

        /// <summary>
        /// 日報ヘッダテーブル
        /// </summary>
        private NippoHdrTblDataSet.NippoHdrTblDataTable _nippoHdrTable;

        /// <summary>
        /// NippoVariable
        /// </summary>
        private NippoVariable _nippoVariable;

        /// <summary>
        /// KensaNippoEditableCheckDataTable
        /// </summary>
        private KensaIraiTblDataSet.KensaNippoEditableCheckDataTable _editableCheckTable;

        /// <summary>
        /// Source for 検査員(1) and 補助員(14)
        /// </summary>
        private ShokuinMstDataSet.ShokuinMstDataTable _cbSource;

        /// <summary>
        /// SessionStored
        /// </summary>
        private SessionStored _session = new SessionStored();

		// 受入20141219 add sta
		/// <summary>
		/// Flag identify a DataGridView has been changed
		/// </summary>
		private bool _gridViewChanged;
		// 受入20141219 add end

		#endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaNippoInputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  AnhNV　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaNippoInputForm()
        {
            InitializeComponent();
            SetStdControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaNippoInputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="nippoKensaDt"></param>
        /// <param name="nippoKensainCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  AnhNV　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaNippoInputForm(string nippoKensaDt, string nippoKensainCd)
        {
            InitializeComponent();

            _nippoKensainCd = nippoKensainCd;
            _nippoKensaDt = nippoKensaDt;
            
            SetStdControlDomain();
        }
        #endregion

        #region イベント

        #region KensaNippoInputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaNippoInputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaNippoInputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Load default value
                DoFormLoad();
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

        #region kensaInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensaInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensaInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No row is selected?
                if (jissiListDataGridView.SelectedRows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "検査実施一覧より対象データを選択して下さい。");
                    return;
                }

                // 検査結果入力遷移チェック
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "更新処理が行われていない場合、入力した内容は全て破棄されます。\r\n検査結果入力画面へ遷移しますか？")
                    != DialogResult.Yes)
                {
                    return;
                }

                // Call to 009-005
                string kensaIraiHoteiKbn = Convert.ToString(jissiListDataGridView.CurrentRow.Cells[kensaSyubetsu1HiddenCol.Name].Value);
                string kensaIraiHokenjoCd = Convert.ToString(jissiListDataGridView.CurrentRow.Cells[hokenjoCd1HiddenCol.Name].Value);
                string kensaIraiNendo = Convert.ToString(jissiListDataGridView.CurrentRow.Cells[torokuNendo1HiddenCol.Name].Value);
                string kensaIraiRenban = Convert.ToString(jissiListDataGridView.CurrentRow.Cells[irairenban1HiddenCol.Name].Value);
                string mochikomiDt = Convert.ToString(jissiListDataGridView.CurrentRow.Cells[KensaKekkaMochikomiDtCol.Name].Value);

                KensaKekkaInputShosaiForm frm = new KensaKekkaInputShosaiForm(kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban, mochikomiDt);
                frm.ShowDialog();
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

        #region koshinButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： koshinButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void koshinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 一覧件数チェック
                if (jissiListDataGridView.Rows.Count == 0 && chushiListDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "更新対象データがありません。");
                    return;
                }
                // 更新内容チェック
                if (!CheckUpdateData()) return;
                // 変更不可チェック
                if (!EditableCheck()) return;
                // 更新チェック
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力された内容で日報を更新します。よろしいですか？")
                    != DialogResult.Yes)
                {
                    return;
                }

                // Execute update
                DoUpdate();
                // 更新完了
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新処理が完了しました。");

                // Refresh the form
                DoKakunin(false);

                // Control the display of all items
                DisplayControl();

				// 検査実施一覧　日報追加 (15) //20141216
				ControlNippoAddCol();

                //if (_dispMode == DispMode.Add)
                //{
                //    // Change display mode to EDIT mode
                //    _dispMode = DispMode.Edit;
                //    // Control the display of all items
                //    DisplayControl();
                //}
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

        #region torikeshiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torikeshiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torikeshiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力された内容がある場合、全て破棄されます。\r\n取消処理を行ってよろしいですか？")
                    == DialogResult.Yes)
                {
                    // Re-initialize the screen
                    InitializeScreen();

                    // No param?
                    //if (string.IsNullOrEmpty(_nippoKensainCd + _nippoKensaDt))
                    //{
                    //    // Current system date
                    //    DateTime systemDt = Common.Common.GetCurrentTimestamp();

                    //    kensainComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;
                    //    // 検査日(2)
                    //    kensaDtTextBox.Value = systemDt;
                    //}
                    //else
                    //{
                    //    // Default value for 検査員(1)
                    //    kensainComboBox.SelectedValue = _nippoKensainCd;
                    //    // 検査日(2)
                    //    kensaDtTextBox.Value = DateTime.ParseExact(_nippoKensaDt, "yyyyMMdd", null);
                    //}

                    // Input key mode
                    _dispMode = DispMode.InputKey;
                    DisplayControl();

					// 検査実施一覧　日報追加 (15) //20141216
					ControlNippoAddCol();
				}
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

        #region nippoPrintButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： nippoPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nippoPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 印刷チェック
                if (!IsFormEdit())
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "表示されているデータが変更されています。\r\n日報出力前に更新を行ってください。");
                    return;
                }

                // Confirmation
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "日報を印刷します。よろしいですか？") == DialogResult.Yes)
                {
                    // Print 039
                    INippoPrintBtnClickALInput alInput = new NippoPrintBtnClickALInput();
                    alInput.NippoKensaDt = kensaDtTextBox.Value.ToString("yyyyMMdd");
                    alInput.NippoKensainCd = kensainComboBox.SelectedValue.ToString();
                    new NippoPrintBtnClickApplicationLogic().Execute(alInput);
                }
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

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Program.mForm.MovePrev();
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

        #region sokoKyoriTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： sokoKyoriTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void sokoKyoriTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 実走行距離（日）(51)
                double sokoKyori;
                double.TryParse(sokoKyoriTextBox.Text, out sokoKyori);
                // 給油(54)
                double kyuyu;
                double.TryParse(kyuyuTextBox.Text, out kyuyu);

                // 実走行距離（月）(52)
                monthSokoKyoriTextBox.Text = (_nippoVariable.MonthSokoKyori + sokoKyori).ToString("N1");
                // 総走行距離（年）(53)
                yearSokoKyoriTextBox.Text = (_nippoVariable.YearSokoKyori + sokoKyori).ToString("N1");

                // 給油(54) is zero or blank
                if (string.IsNullOrEmpty(kyuyuTextBox.Text) || kyuyuTextBox.Text == "0")
                {
                    // (55) = (Variable.ZenkaiSokoKyori - Variable.ZenzenkaiSokoKyori) / Variable.ZenkaiKyuyu
                    nenpiTextBox.Text = _nippoVariable.ZenkaiKyuyu == 0 ? "0" :
                        ((_nippoVariable.ZenkaiSokoKyori - _nippoVariable.ZenzenkaiSokoKyori) / _nippoVariable.ZenkaiKyuyu).ToString("N1");
                }
                else if (kyuyu > 0) // 給油(54) greater than zero
                {
                    // 総走行距離（年）(53)
                    double yearSokyuKori;
                    double.TryParse(yearSokoKyoriTextBox.Text, out yearSokyuKori);
                    // (55) = ((53) - Variable．ZenkaiSokoKyori) / (54)
                    nenpiTextBox.Text = ((yearSokyuKori - _nippoVariable.ZenkaiSokoKyori) / kyuyu).ToString("N1");
                }

                // Formatted value
                if (!string.IsNullOrEmpty(sokoKyoriTextBox.Text))
                {
                    sokoKyoriTextBox.Text = sokoKyori.ToString("N1");
                }
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

        #region kyuyuTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kyuyuTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kyuyuTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 総走行距離（年）(53)
                double yearSokyoKyori;
                double.TryParse(yearSokoKyoriTextBox.Text, out yearSokyoKyori);
                // 給油(54)
                double kyuyu;
                double.TryParse(kyuyuTextBox.Text, out kyuyu);
                
                // 最近の燃費(55)
                nenpiTextBox.Text = kyuyu == 0 ? "0" :
                    nenpiTextBox.Text = ((yearSokyoKyori - _nippoVariable.ZenkaiSokoKyori) / kyuyu).ToString("N1");
                // 総給油量(56)
                totalKyuyuTextBox.Text = (_nippoVariable.TotalKyuyu + kyuyu).ToString("N1");

                // Formatted value
                if (!string.IsNullOrEmpty(kyuyuTextBox.Text))
                {
                    kyuyuTextBox.Text = kyuyu.ToString("N1");
                }
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

        #region KensaNippoInputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaNippoInputForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaNippoInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        koshinButton.Focus();
                        koshinButton.PerformClick();
                        break;
                    case Keys.F3:
                        torikeshiButton.Focus();
                        torikeshiButton.PerformClick();
                        break;
                    case Keys.F6:
                        nippoPrintButton.Focus();
                        nippoPrintButton.PerformClick();
                        break;
                    case Keys.F8:
                        kakuninButton.Focus();
                        kakuninButton.PerformClick();
                        break;
                    case Keys.F9:
                        kensaInputButton.Focus();
                        kensaInputButton.PerformClick();
                        break;
                    case Keys.F12:
                        closeButton.Focus();
                        closeButton.PerformClick();
                        break;
                    default:
                        break;
                }
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

        #region kakuninButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuninButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuninButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Not select Kensain yet?
                if (string.IsNullOrEmpty(Convert.ToString(kensainComboBox.SelectedValue)))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "検査員を選択して下さい。");
                    return;
                }

                DoKakunin(true);
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

        #region chgJisshiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chgJisshiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　AnhNV　　    新規作成
        /// 2014/12/03  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chgJisshiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No selected row in 検査実施一覧(7)
                if (jissiListDataGridView.SelectedRows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "検査実施一覧より対象データを選択して下さい。");
                    return;
                }

                // 中止可能チェック v1.04
                if (!string.IsNullOrEmpty(Convert.ToString(jissiListDataGridView.CurrentRow.Cells[suishitsuNoCol.Name].Value)))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "水質検査受付済のため中止にできません");
                    return;
                }
                if (Convert.ToString(jissiListDataGridView.CurrentRow.Cells[status1HiddenCol.Name].Value) != "40")
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "他画面にて処理が行われているため中止にできません");
                    return;
                }

                // Pass row from jisshiListDgv to chushiListDgv
                PassDgvRow(jissiListDataGridView, chushiListDataGridView, "1", "1");
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

        #region chgChushiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： chgChushiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　AnhNV　　    新規作成
        /// 2014/12/03  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void chgChushiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // No selected row in 検査中止一覧(31)
                if (chushiListDataGridView.SelectedRows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "検査中止一覧より対象データを選択して下さい。");
                    return;
                }

                // 実施移動可能チェック (v1.04)
                if (Convert.ToString(chushiListDataGridView.CurrentRow.Cells[status2HiddenCol.Name].Value) != "40")
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "他画面にて処理が行われているため実施にできません");
                    return;
                }

                // Pass row from chushiListDgv to jisshiListDgv
                PassDgvRow(chushiListDataGridView, jissiListDataGridView, "0");

				// 受入20141219 検査中止一覧から検査実施一覧へ移動させる場合、グリッド内の日報追加Cbの制御も行う。
				ControlNippoAddCol();
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

		#region DGV change detect
		private void jissiListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			_gridViewChanged = true;
		}

		private void chushiListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
		{
			_gridViewChanged = true;
		}
		#endregion

		#endregion

		#region メソッド(private)

		#region DoFormLoad
		////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialScreen"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  AnhNV　　    新規作成
        /// 2014/12/03  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad(bool initialScreen = true)
        {
            if (initialScreen)
            {
                // Initialize the screen
                InitializeScreen();
            }

            #region Get data
            // Current system date
            DateTime systemDt = Common.Common.GetCurrentTimestamp();

            IFormLoadALInput alInput = new FormLoadALInput();
            // Edit/non-edit mode?
            if (!string.IsNullOrEmpty(_nippoKensainCd))
            {
                alInput.NippoKensainCd = _nippoKensainCd;
                alInput.NippoKensaDt = DateTime.ParseExact(_nippoKensaDt, "yyyyMMdd", null);
            }
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);
            _cbSource = alOutput.ShokuinMstDataTable;
            #endregion

            #region Set data
            // 検査員(1)
            Utility.Utility.SetComboBoxList(kensainComboBox, _cbSource, "ShokuinNm", "ShokuinCd", true);

            // No param?
            if (string.IsNullOrEmpty(_nippoKensainCd + _nippoKensaDt))
            {
                kensainComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;
                // 検査日(2)
                kensaDtTextBox.Value = systemDt;
                // Input key mode
                _dispMode = DispMode.InputKey;
            }
            else
            {
                _editableCheckTable = alOutput.KensaNippoEditableCheckDataTable;
                _nippoHdrTable = alOutput.NippoHdrTblDataTable;

                // Separate result table by NippoDtlKensaChushiFlg
                KensaIraiTblDataSet.KensaNippoInputDataTable jisshiSource = new KensaIraiTblDataSet.KensaNippoInputDataTable();
                KensaIraiTblDataSet.KensaNippoInputDataTable chushiSource = new KensaIraiTblDataSet.KensaNippoInputDataTable();
				SeparateDgvSource(alOutput.KensaNippoInputDataTable, jisshiSource, chushiSource, _dispMode);	//受入20141217 表示モードを引数に追加
                _session.JisshiSource = jisshiSource;
                _session.ChushiSource = chushiSource;

                // 補助員(14)
                BindHojoinSource(_cbSource);
                // Bind source to 検査実施一覧グリッドビュー(7)
                BindSourceToDgv(jissiListDataGridView, jisshiSource);
                // Bind source to 検査中止一覧グリッドビュー(31)
                BindSourceToDgv(chushiListDataGridView, chushiSource);

                // Default value for 検査員(1)
                kensainComboBox.SelectedValue = _nippoKensainCd;
                // 検査日(2)
                kensaDtTextBox.Value = DateTime.ParseExact(_nippoKensaDt, "yyyyMMdd", null);

                // Preparing data for Leave events on 実走行距離（月）(52), 総走行距離（年）(53), 最近の燃費(55), 総給油量(56)
                SetNippoVariables(alOutput.NippoVariableDataTable);
                // Source for all remaining items
                SetItemSource(alOutput.KensaNippoInputDataTable, alOutput.NippoVariableDataTable, alOutput.NippoDtlTblDataTable);

                // Result display mode
                _dispMode = alOutput.DispMode;
            }
            #endregion

            // Active/inactive items
            DisplayControl();
            // Enable/Disable 日報追加(74)
            ControlNippoAddCol();

            _session.KensainCd = Convert.ToString(kensainComboBox.SelectedValue);
            _session.KensaDt = kensaDtTextBox.Value.ToString("yyyyMMdd");
        }
        #endregion

        #region SetStdControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetStdControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetStdControlDomain()
        {
            // 検査実施一覧グリッドビュー(7)
            jissiListDataGridView.SetStdControlDomain(kensainCol.Index, ZControlDomain.ZG_STD_NAME, 20);
            jissiListDataGridView.SetStdControlDomain(kensaSyubetsuCol.Index, ZControlDomain.ZG_STD_NAME, 30);
            jissiListDataGridView.SetStdControlDomain(sichosonCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            jissiListDataGridView.SetStdControlDomain(settisyaCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            jissiListDataGridView.SetStdControlDomain(syoriHoshikiCol.Index, ZControlDomain.ZG_STD_NAME, 14);
            jissiListDataGridView.SetStdControlDomain(ninsoCol.Index, ZControlDomain.ZG_STD_NUM, 4);
            jissiListDataGridView.SetStdControlDomain(kensaTimeCol.Index, ZControlDomain.ZG_STD_NUM, 3);
            jissiListDataGridView.SetStdControlDomain(seikyuHohoCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            jissiListDataGridView.SetStdControlDomain(seikyuGyosyaCol.Index, ZControlDomain.ZG_STD_NAME, 40);
            jissiListDataGridView.SetStdControlDomain(zaitakuCol.Index, ZControlDomain.ZG_STD_NAME, 4, DataGridViewContentAlignment.MiddleCenter);
            jissiListDataGridView.SetStdControlDomain(ikenCol.Index, ZControlDomain.ZG_STD_NAME, 40);
            jissiListDataGridView.SetStdControlDomain(renrakuKanrisyaCol.Index, ZControlDomain.ZG_STD_NAME, 4, DataGridViewContentAlignment.MiddleCenter);
            jissiListDataGridView.SetStdControlDomain(renrakuGyosyaCol.Index, ZControlDomain.ZG_STD_NAME, 4, DataGridViewContentAlignment.MiddleCenter);

            // 検査中止一覧グリッドビュー(31)
            chushiListDataGridView.SetStdControlDomain(chusiKensainCol.Index, ZControlDomain.ZG_STD_NAME, 20);
            chushiListDataGridView.SetStdControlDomain(chusiKensaSyubetsuCol.Index, ZControlDomain.ZG_STD_NAME, 30);
            chushiListDataGridView.SetStdControlDomain(chusiSichosonCol.Index, ZControlDomain.ZG_STD_NAME, 10);
            chushiListDataGridView.SetStdControlDomain(chusiSettisyaCol.Index, ZControlDomain.ZG_STD_NAME, 60);
            chushiListDataGridView.SetStdControlDomain(chusiSyoriHoshikiCol.Index, ZControlDomain.ZG_STD_NAME, 14);
            chushiListDataGridView.SetStdControlDomain(chusiNinsoCol.Index, ZControlDomain.ZG_STD_NUM, 4);
            chushiListDataGridView.SetStdControlDomain(riyuCol.Index, ZControlDomain.ZG_STD_NAME, 60);

            // TextBoxes
            tougetsuNissuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            totalNissuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3);
            monthAveNissuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4, 1, InputValidateUtility.SignFlg.Positive);
            tougetsuKensuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3);
            totalKensuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5);
            dayAveKensuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            sokoKyoriTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4, 1, InputValidateUtility.SignFlg.Positive);
            monthSokoKyoriTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 1, InputValidateUtility.SignFlg.Positive);
            yearSokoKyoriTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, 1, InputValidateUtility.SignFlg.Positive);
            kyuyuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4, 1, InputValidateUtility.SignFlg.Positive);
            nenpiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 1, InputValidateUtility.SignFlg.Positive);
            totalKyuyuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, 1, InputValidateUtility.SignFlg.Positive);
            totalKensaTimeTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            ruikeiKensaTimeTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, 1, InputValidateUtility.SignFlg.Positive);
            crossCheckTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            jittiChosaKensuTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            chokaGeninTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            syaryoTenkenTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 40);
            hokokuJikoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);
            kanrisyaShijiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 100);
        }
        #endregion

        #region DisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayControl()
        {
            // 検査員コンボボックス(1)
            kensainComboBox.Enabled =
            // 検査日(2)
            kensaDtTextBox.Enabled =
            // 確認ボタン (3)
            kakuninButton.Enabled = _dispMode == DispMode.InputKey ? true : false;

            // 検査実施/中止一覧パネル（タブ切替）(5), (30)
			jissiListDataGridView.EditMode = _dispMode == DispMode.Add || _dispMode == DispMode.Edit ? DataGridViewEditMode.EditOnKeystrokeOrF2 : DataGridViewEditMode.EditProgrammatically;
			chushiListDataGridView.EditMode = _dispMode == DispMode.Add || _dispMode == DispMode.Edit ? DataGridViewEditMode.EditOnKeystrokeOrF2 : DataGridViewEditMode.EditProgrammatically;
            // 報告/承認パネル(上記以外)（タブ切替）(64)
            hokokuJikoTextBox.ReadOnly =
            // 報告/承認パネル(上記以外)（タブ切替）(65)
            kanrisyaShijiTextBox.ReadOnly = _dispMode == DispMode.Add || _dispMode == DispMode.Edit ? false : true;
            
            // ↑ボタン(28), ↓ボタン(29)
            chgJisshiButton.Enabled =
            chgChushiButton.Enabled =
            // 結果入力ボタン(6)
            kensaInputButton.Enabled =
            // 確認項目パネル（タブ切替）- panel của tab (44)
            kakuninKomokuPanel.Enabled =
            // 報告/承認パネル(上記以外)（タブ切替）(66)
            kensaKanryoCheckBox.Enabled =
            // 更新ボタン (69)
            koshinButton.Enabled = _dispMode == DispMode.Add || _dispMode == DispMode.Edit ? true : false;
            
            // 副課長確認(67)
            // TODO Need access role here!!!
            fukuKachoKakuninCheckBox.Enabled =
            // 課長確認(68)
            kachoKakuninCheckBox.Enabled = _dispMode == DispMode.InputKey || _dispMode == DispMode.NonEditable ? false : true;
            // 取消ボタン (70)
            torikeshiButton.Enabled = _dispMode == DispMode.InputKey ? false : true;
            // 日報印刷ボタン (71)
            nippoPrintButton.Enabled = _dispMode == DispMode.Edit || _dispMode == DispMode.NonEditable ? true : false;
        }
        #endregion

        #region InitializeScreen
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InitializeScreen
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InitializeScreen()
        {
            // Clear 検査実施一覧グリッドビュー(7)
            BindSourceToDgv(jissiListDataGridView, null);

            // Clear 検査中止一覧グリッドビュー(31)
            BindSourceToDgv(chushiListDataGridView, null);

            #region Tab44
            // 当月稼働日数(45)
            tougetsuNissuTextBox.Text = string.Empty;
            // 稼働日数合計(46)
            totalNissuTextBox.Text = string.Empty;
            // 月平均稼働日数(47)
            monthAveNissuTextBox.Text = string.Empty;
            // 当月件数(48)
            tougetsuKensuTextBox.Text = string.Empty;
            // 件数合計(49)
            totalKensuTextBox.Text = string.Empty;
            // 日平均件数(50)
            dayAveKensuTextBox.Text = string.Empty;
            // 実走行距離（日）(51)
            sokoKyoriTextBox.Text = string.Empty;
            // 実走行距離（月）(52)
            monthSokoKyoriTextBox.Text = string.Empty;
            // 総走行距離（年）(53)
            yearSokoKyoriTextBox.Text = string.Empty;
            // 給油(54)
            kyuyuTextBox.Text = string.Empty;
            // 最近の燃費(55)
            nenpiTextBox.Text = string.Empty;
            // 総給油量(56)
            totalKyuyuTextBox.Text = string.Empty;
            // 検査時間計(57)
            totalKensaTimeTextBox.Text = string.Empty;
            // 累計検査時間(58)
            ruikeiKensaTimeTextBox.Text = string.Empty;
            // クロスチェック現地調査(50)
            crossCheckTextBox.Text = string.Empty;
            // 実地調査件数(60)
            jittiChosaKensuTextBox.Text = string.Empty;
            // 超過原因調査件数(61)
            chokaGeninTextBox.Text = string.Empty;
            // 車両点検記録(62)
            syaryoTenkenTextBox.Text = string.Empty;
            #endregion

            #region Tab63
            // 報告事項等(64)
            hokokuJikoTextBox.Text = string.Empty;
            // 管理職の指示内容(65)
            kanrisyaShijiTextBox.Text = string.Empty;
            // 検査完了(66)
            kensaKanryoCheckBox.Checked = false;
            // 副課長確認(67)
            fukuKachoKakuninCheckBox.Checked = false;
            // 課長確認(68)
            kachoKakuninCheckBox.Checked = false;
            #endregion
        }
        #endregion

        #region SeparateDgvSource
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SeparateDgvSource
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rawSource"></param>
        /// <param name="jisshiSource"></param>
        /// <param name="chushiSource"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SeparateDgvSource
        (
            KensaIraiTblDataSet.KensaNippoInputDataTable rawSource,
            KensaIraiTblDataSet.KensaNippoInputDataTable jisshiSource,
            KensaIraiTblDataSet.KensaNippoInputDataTable chushiSource,
			KensaNippoInputForm.DispMode mode
        )
        {
            foreach (KensaIraiTblDataSet.KensaNippoInputRow row in rawSource)
            {
				// Flg column not always filled '0' or '1' value. nullvalue and blank and empty care.  ※DBNullと空白、空文字も考慮。
				string wkNippoDtlKensaChushiFlg = row.IsNippoDtlKensaChushiFlgNull() ? String.Empty : row.NippoDtlKensaChushiFlg.Trim();

				// 受入20141217 mod 編集モードで日報明細を持たない場合、一覧に表示しない。
				if (!mode.Equals("2") || !row.IsNippoDtlKensaDtNull())
				{
					if (String.IsNullOrEmpty(wkNippoDtlKensaChushiFlg) || wkNippoDtlKensaChushiFlg == "0")
					{
						row.KensaChushiFlg = "0";
						// Set to 検査実施一覧グリッドビュー(7)
						jisshiSource.ImportRow(row);
					}
					else if (wkNippoDtlKensaChushiFlg == "1")
					{
						row.KensaChushiFlg = "1";
						// Set to 検査中止一覧グリッドビュー(31)
						chushiSource.ImportRow(row);
					}
				}
            }
        }
        #endregion

        #region DoKakunin
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoKakunin
        /// <summary>
        /// 
        /// </summary>
        /// <param name="showMsg"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18  AnhNV　　    新規作成
        /// 2014/12/03  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoKakunin(bool showMsg)
        {
            #region Get data
            IKakuninBtnClickALInput alInput = new KakuninBtnClickALInput();
            alInput.KensaIraiKensaTantoshaCd = kensainComboBox.SelectedValue.ToString();
            alInput.YoteiDt = kensaDtTextBox.Value;
            IKakuninBtnClickALOutput alOutput = new KakuninBtnClickApplicationLogic().Execute(alInput);
            _dispMode = alOutput.DispMode;
            _editableCheckTable = alOutput.KensaNippoEditableCheckDataTable;
            _nippoHdrTable = alOutput.NippoHdrTblDataTable;
            #endregion

            #region Set data
            // Preparing data for Leave events on 実走行距離（月）(52), 総走行距離（年）(53), 最近の燃費(55), 総給油量(56)
            SetNippoVariables(alOutput.NippoVariableDataTable);

            // No data in NippoDtlTbl and KensaIraiTbl
            if (alOutput.IsError)
            {
                if (showMsg)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "表示データがありません。");
                }

                // Clear the gridviews
                BindSourceToDgv(jissiListDataGridView, null);
                BindSourceToDgv(chushiListDataGridView, null);
                return;
            }

			// Separate result table by NippoDtlKensaChushiFlg
			KensaIraiTblDataSet.KensaNippoInputDataTable jisshiSource = new KensaIraiTblDataSet.KensaNippoInputDataTable();
			KensaIraiTblDataSet.KensaNippoInputDataTable chushiSource = new KensaIraiTblDataSet.KensaNippoInputDataTable();
			SeparateDgvSource(alOutput.KensaNippoInputDataTable, jisshiSource, chushiSource, _dispMode);	//受入20141217 表示モードを引数に追加
			_session.JisshiSource = jisshiSource;
			_session.ChushiSource = chushiSource;

			// Add mode
            if (_dispMode == DispMode.Add)
            {
                SetChushiFlgToDgvSource(alOutput.KensaNippoInputDataTable, "0");
                // 検査実施一覧グリッドビュー(7)
                BindSourceToDgv(jissiListDataGridView, alOutput.KensaNippoInputDataTable);
            }
            else // Edit or Non-edit mode
            {
                // Bind source to 検査実施一覧グリッドビュー(7)
                BindSourceToDgv(jissiListDataGridView, jisshiSource);

                // Bind source to 検査中止一覧グリッドビュー(31)
                BindSourceToDgv(chushiListDataGridView, chushiSource);
            }
            #endregion

            // Source for all remain items
            SetItemSource(alOutput.KensaNippoInputDataTable, alOutput.NippoVariableDataTable, alOutput.NippoDtlTblDataTable);
            // 補助員(14)
            BindHojoinSource(_cbSource);
            // Control the display of all items by screen mode
            DisplayControl();
            // Enable/Disable 日報追加(74)
            ControlNippoAddCol();
        }
        #endregion

        #region SetNippoVariables
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetNippoVariables
        /// <summary>
        /// 
        /// </summary>
        /// <param name="varTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetNippoVariables(NippoHdrTblDataSet.NippoHdrTblDataTable varTable)
        {
            // No handle for empty table
            if (varTable.Rows.Count == 0) return;

            // Previous 検査日(2)
            string preKensaDt = kensaDtTextBox.Value.AddDays(-1).ToString("yyyyMMdd"); // yyyyMMdd
            // 検査日(2)
            string kensaDt = kensaDtTextBox.Value.ToString("yyyyMMdd"); // yyyyMMdd
            // Nendo of 検査日(2)
            int kensaNendo = Utility.DateUtility.GetNendo(kensaDtTextBox.Value);
            // The first day in month of 検査日(2)
            string startKensaNendo = new DateTime(kensaNendo, kensaDtTextBox.Value.Month, 1).ToString("yyyyMMdd"); // yyyyMM01
            // The 1st, April of 検査日(2)
            string defaultNendo = new DateTime(kensaNendo, 4, 1).ToString("yyyyMMdd"); // yyyy0401

            NippoHdrTblDataSet.NippoHdrTblRow[] hdrRow = (NippoHdrTblDataSet.NippoHdrTblRow[])varTable.Select(string.Format("NippoKensaDt < '{0}' and NippoKyuyu > 0", kensaDt), "NippoKensaDt desc");
            // Get the last 1st NippoKensaDt that close up to 検査日(2)
            string last1stDt = hdrRow.Length == 0 ? string.Empty : hdrRow[0].NippoKensaDt;
            // Get the last 2nd NippoKensaDt that close up to 検査日(2)
            string last2ndDt = hdrRow.Length == 0 ? string.Empty : (hdrRow.Length == 1 ? hdrRow[0].NippoKensaDt : hdrRow[1].NippoKensaDt);

            // Variables
            object monthSokoKyori = varTable.Compute("sum(NippoSokoKyori)", string.Format("NippoKensaDt >= '{0}' and NippoKensaDt <= '{1}'", startKensaNendo, preKensaDt));
            object yearSokoKyori = varTable.Compute("sum(NippoSokoKyori)", string.Format("NippoKensaDt >= '{0}' and NippoKensaDt <= '{1}'", defaultNendo, preKensaDt));
            object totalKyuyu = varTable.Compute("sum(NippoKyuyu)", string.Format("NippoKensaDt >= '{0}' and NippoKensaDt <= '{1}'", defaultNendo, preKensaDt));
            object zenkaiSokoKyori = varTable.Compute("sum(NippoSokoKyori)", string.Format("NippoKensaDt >= '{0}' and NippoKensaDt <= '{1}'", defaultNendo, last1stDt));
            double zenkaiKyuyu = hdrRow.Length == 0 ? 0 : hdrRow[0].NippoKyuyu;
            object zenzenkaiSokoKyori = varTable.Compute("sum(NippoSokoKyori)", string.Format("NippoKensaDt >= '{0}' and NippoKensaDt <= '{1}'", defaultNendo, last2ndDt));

            // Calling the Setter
            _nippoVariable = new NippoVariable();
            _nippoVariable.MonthSokoKyori = monthSokoKyori is DBNull ? 0 : Math.Round(Convert.ToDouble(monthSokoKyori), 1);
            _nippoVariable.YearSokoKyori = yearSokoKyori is DBNull ? 0 : Math.Round(Convert.ToDouble(yearSokoKyori), 1);
            _nippoVariable.TotalKyuyu = totalKyuyu is DBNull ? 0 : Math.Round(Convert.ToDouble(totalKyuyu), 1);
            _nippoVariable.ZenkaiSokoKyori = zenkaiSokoKyori is DBNull ? 0 : Math.Round(Convert.ToDouble(zenkaiSokoKyori), 1);
            _nippoVariable.ZenkaiKyuyu = Math.Round(zenkaiKyuyu, 1);
            _nippoVariable.ZenzenkaiSokoKyori = zenzenkaiSokoKyori is DBNull ? 0 : Math.Round(Convert.ToDouble(zenzenkaiSokoKyori), 1);
        }
        #endregion

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            // Current system date
            DateTime systemDt = Common.Common.GetCurrentTimestamp();
            // Login user
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Machine's name
            string host = Dns.GetHostName();
            // Dgv source tables
            KensaIraiTblDataSet.KensaNippoInputDataTable updateTable = new KensaIraiTblDataSet.KensaNippoInputDataTable();
            if (null != jissiListDataGridView.DataSource)
            {
                updateTable.Merge((KensaIraiTblDataSet.KensaNippoInputDataTable)jissiListDataGridView.DataSource);
            }
            if (null != chushiListDataGridView.DataSource)
            {
                updateTable.Merge((KensaIraiTblDataSet.KensaNippoInputDataTable)chushiListDataGridView.DataSource);
            }

            IKoshinBtnClickALInput alInput = new KoshinBtnClickALInput();
            alInput.KensaDt = kensaDtTextBox.Value;
            alInput.KensainCd = Convert.ToString(kensainComboBox.SelectedValue);
            alInput.Mode = _dispMode;
            alInput.SystemDt = systemDt;
            alInput.KensaNippoInputDataTable = updateTable;
			alInput.NippoKbn = GetGaikanNippoKbn();	//20141217 受入テスト

            if (_dispMode == DispMode.Add) // Add mode
            {
                alInput.NippoDtlTblDataTable = CreateNippoDtlTblDataTableInsert(systemDt, user, host);
                alInput.NippoHdrTblDataTable = CreateNippoHdrTblDataTableInsert(systemDt, user, host);
			}
            else // Edit mode
            {
                alInput.NippoHdrTblDataTable = CreateNippoHdrTblDataTableUpdate(_nippoHdrTable, user, host);
            }
            new KoshinBtnClickApplicationLogic().Execute(alInput);
        }
        #endregion

        #region CheckUpdateData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckUpdateData
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// 2014/12/04  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckUpdateData()
        {
            StringBuilder errMsg = new StringBuilder();

            foreach (DataGridViewRow dgvr in chushiListDataGridView.Rows)
            {
                // 検査中止又は延期理由(43) is empty
                if (string.IsNullOrEmpty(Convert.ToString(dgvr.Cells[riyuCol.Name].Value)))
                {
                    errMsg.AppendLine("検査中止・延期理由を入力して下さい。");
                    break;
                }
            }

            // v1.05 ADD Start
            foreach (DataGridViewRow dgvr in jissiListDataGridView.Rows)
            {
                // 検査状況(75)  = 001
                if (Convert.ToString(dgvr.Cells[kensaJokyoCol.Name].Value) == "001")
                {
                    errMsg.AppendLine("未検査の検査は中止一覧へ移動してください。");
					break;	// 受入20141217 同じメッセージは１件出れば良い。
                }
            }
            // v1.05 ADD End

            // 実走行距離(51) is empty
            if (string.IsNullOrEmpty(sokoKyoriTextBox.Text))
            {
                errMsg.AppendLine("実走行距離を入力して下さい。");
            }

            // 給油(54) is empty
            if (string.IsNullOrEmpty(kyuyuTextBox.Text))
            {
                errMsg.AppendLine("給油を入力して下さい。");
            }

            // An error occurred
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region EditableCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditableCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name=""></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditableCheck()
        {
            // 検査員(1)
            string kensainCd = Convert.ToString(kensainComboBox.SelectedValue);
            // 検査日(2)
            string kensaDt = kensaDtTextBox.Value.ToString("yyyyMMdd");

			//結合20141227 mod sta １、変更チェック用データを取り直す。　２．外観日報区分の条件を ='2' 承認 とする。←検索ＳＱＬ
            //DataRow[] rowCheck = _editableCheckTable.Select(string.Format("NippoDtlKensaDt='{0}' and NippoDtlKensainCd='{1}'", kensaDt, kensainCd));

			//更新ボタン押下時も、確認ボタン押下時と同じ変更不可チェックを行う。
			IKakuninBtnClickALInput alInput = new KakuninBtnClickALInput();
			alInput.KensaIraiKensaTantoshaCd = kensainComboBox.SelectedValue.ToString();
			alInput.YoteiDt = kensaDtTextBox.Value;
			IKakuninBtnClickALOutput alOutput = new KakuninBtnClickApplicationLogic().Execute(alInput);
			_editableCheckTable = alOutput.KensaNippoEditableCheckDataTable;

			DataRow[] rowCheck = _editableCheckTable.Select(string.Format("NippoDtlKensaDt='{0}' and NippoDtlKensainCd='{1}'", kensaDt, kensainCd));
			//結合20141227 mod end

            if (rowCheck.Length > 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "検印済、または、承認済、または、請求済のため、更新できません。");
                return false;
            }

            return true;
        }
        #endregion

        #region CreateNippoHdrTblDataTableInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNippoHdrTblDataTableInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NippoHdrTblDataSet.NippoHdrTblDataTable CreateNippoHdrTblDataTableInsert
        (
            DateTime now,
            string user,
            string host
        )
        {
            NippoHdrTblDataSet.NippoHdrTblDataTable table = new NippoHdrTblDataSet.NippoHdrTblDataTable();
            NippoHdrTblDataSet.NippoHdrTblRow newRow = table.NewNippoHdrTblRow();

            // 検査日(2)
            newRow.NippoKensaDt = kensaDtTextBox.Value.ToString("yyyyMMdd");
            // 検査員コード(1)
            newRow.NippoKensainCd = Convert.ToString(kensainComboBox.SelectedValue);
            // 走行距離(51)
            newRow.NippoSokoKyori = Convert.ToDouble(sokoKyoriTextBox.Text);
            // 給油(54)
            newRow.NippoKyuyu = Convert.ToDouble(kyuyuTextBox.Text);
            // 車両点検記録(62)
            newRow.NippoSharyoTenkenKiroku = syaryoTenkenTextBox.Text;
            // 実地調査件数(60)
            newRow.NippoJitchichosaKensu = string.IsNullOrEmpty(jittiChosaKensuTextBox.Text) ? 0 : Convert.ToInt32(jittiChosaKensuTextBox.Text);
            // 超過原因調査件数(61)
            newRow.NippoChokageninchosaKensu = string.IsNullOrEmpty(chokaGeninTextBox.Text) ? 0 : Convert.ToInt32(chokaGeninTextBox.Text);
            // クロスチェック現地調査件数(59)
            newRow.NippoCrosscheckKensu = string.IsNullOrEmpty(crossCheckTextBox.Text) ? 0 : Convert.ToInt32(crossCheckTextBox.Text);
            // 検査員報告事項(64)
            newRow.NippoHokokujiko = hokokuJikoTextBox.Text;
            // 管理職指示内容(65)
            newRow.NippoShijinaiyo = kanrisyaShijiTextBox.Text;
            // 検査完了フラグ(66)
            newRow.NippoKanryoFlg = kensaKanryoCheckBox.Checked ? "1" : "0";
            // 副課長チェックフラグ(67)
            newRow.NippoFukukachoCheckFlg = fukuKachoKakuninCheckBox.Checked ? "1" : "0";
            // 課長チェックフラグ(68)
            newRow.NippoKachoCheckFlg = kachoKakuninCheckBox.Checked ? "1" : "0";
            // 登録日
            newRow.InsertDt = now;
            // 登録者
            newRow.InsertUser = user;
            // 登録端末
            newRow.InsertTarm = host;
            // 更新日
            newRow.UpdateDt = now;
            // 更新者
            newRow.UpdateUser = user;
            // 更新端末
            newRow.UpdateTarm = host;

            // Add and commit
            table.AddNippoHdrTblRow(newRow);
            newRow.AcceptChanges();
            newRow.SetAdded();

            return table;
        }
        #endregion

        #region CreateNippoDtlTblDataTableInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNippoDtlTblDataTableInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// 2014/12/03  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NippoDtlTblDataSet.NippoDtlTblDataTable CreateNippoDtlTblDataTableInsert
        (
            DateTime now,
            string user,
            string host
        )
        {
            // Create a new table
            NippoDtlTblDataSet.NippoDtlTblDataTable table = new NippoDtlTblDataSet.NippoDtlTblDataTable();
            // 連番
            int renban = 1;
            // v1.04
            string nippoAdd = string.Empty;

            #region Records in 検査実施一覧(7)
            foreach (DataGridViewRow dgvr in jissiListDataGridView.Rows)
            {
                // v1.04
                // Skip row with 日報追加(74) is OFF
                if (Convert.ToString(dgvr.Cells[nippoAddCol.Name].Value) == "0") continue;
                // End v1.04

                // Create a new row
                NippoDtlTblDataSet.NippoDtlTblRow newRow = table.NewNippoDtlTblRow();

                // 検査日(2)
                newRow.NippoDtlKensaDt = kensaDtTextBox.Value.ToString("yyyyMMdd");
                // 検査員コード(1)
                newRow.NippoDtlKensainCd = Convert.ToString(kensainComboBox.SelectedValue);
                // 連番
                newRow.NippoDtlRenban = renban.ToString();
                // 検査種別(9)/(33)
                newRow.NippoDtlKensaSyubetsu = Convert.ToString(dgvr.Cells[kensaSyubetsu1HiddenCol.Name].Value);
                // 検査依頼保健所コード(10)/(34)
                newRow.NippoDtlKensaIraiHokenjoCd = Convert.ToString(dgvr.Cells[hokenjoCd1HiddenCol.Name].Value);
                // 検査依頼年度(11)/(35)
                newRow.NippoDtlKensaIraiNendo = Convert.ToString(dgvr.Cells[torokuNendo1HiddenCol.Name].Value);
                // 検査依頼連番(12)/(36)
                newRow.NippoDtlKensaIraiRenban = Convert.ToString(dgvr.Cells[irairenban1HiddenCol.Name].Value);
                // 補助員コード (14)
                newRow.NippoDtlHojoinCd = Convert.ToString(dgvr.Cells[hojoinCol.Name].Value);
                // 検査中止フラグ(43)
                newRow.NippoDtlKensaChushiFlg = "0";
                // 検査中止理由
                newRow.NippoDtlKensaChushiRiyu = string.Empty;
                // 登録日
                newRow.InsertDt = now;
                // 登録者
                newRow.InsertUser = user;
                // 登録端末
                newRow.InsertTarm = host;
                // 更新日
                newRow.UpdateDt = now;
                // 更新者
                newRow.UpdateUser = user;
                // 更新端末
                newRow.UpdateTarm = host;

                // Add and commit
                table.AddNippoDtlTblRow(newRow);
                newRow.AcceptChanges();
                newRow.SetAdded();

                // Next renban number
                renban++;
            }
            #endregion

            #region Records in 検査中止一覧(31)
            foreach (DataGridViewRow dgvr in chushiListDataGridView.Rows)
            {
                // Create a new row
                NippoDtlTblDataSet.NippoDtlTblRow newRow = table.NewNippoDtlTblRow();

                // 検査日(2)
                newRow.NippoDtlKensaDt = kensaDtTextBox.Value.ToString("yyyyMMdd");
                // 検査員コード(1)
                newRow.NippoDtlKensainCd = Convert.ToString(kensainComboBox.SelectedValue);
                // 連番
                newRow.NippoDtlRenban = renban.ToString();
                // 検査種別(9)/(33)
                newRow.NippoDtlKensaSyubetsu = Convert.ToString(dgvr.Cells[kensaSyubetsu2HiddenCol.Name].Value);
                // 検査依頼保健所コード(10)/(34)
                newRow.NippoDtlKensaIraiHokenjoCd = Convert.ToString(dgvr.Cells[hokenjoCd2HiddenCol.Name].Value);
                // 検査依頼年度(11)/(35)
                newRow.NippoDtlKensaIraiNendo = Convert.ToString(dgvr.Cells[torokuNendo2HiddenCol.Name].Value);
                // 検査依頼連番(12)/(36)
                newRow.NippoDtlKensaIraiRenban = Convert.ToString(dgvr.Cells[irairenban2HiddenCol.Name].Value);
                // 補助員コード (14)
                newRow.NippoDtlHojoinCd = string.Empty;
                // 検査中止フラグ(43)
                newRow.NippoDtlKensaChushiFlg = "1";
                // 検査中止理由
                newRow.NippoDtlKensaChushiRiyu = Convert.ToString(dgvr.Cells[riyuCol.Name].Value);
                // 登録日
                newRow.InsertDt = now;
                // 登録者
                newRow.InsertUser = user;
                // 登録端末
                newRow.InsertTarm = host;
                // 更新日
                newRow.UpdateDt = now;
                // 更新者
                newRow.UpdateUser = user;
                // 更新端末
                newRow.UpdateTarm = host;

                // Add and commit
                table.AddNippoDtlTblRow(newRow);
                newRow.AcceptChanges();
                newRow.SetAdded();

                // Next renban number
                renban++;
            }
            #endregion

            return table;
        }
        #endregion

        #region CreateNippoHdrTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNippoHdrTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NippoHdrTblDataSet.NippoHdrTblDataTable CreateNippoHdrTblDataTableUpdate
        (
            NippoHdrTblDataSet.NippoHdrTblDataTable table,
            string user,
            string host
        )
        {
            // 走行距離(51)
            table[0].NippoSokoKyori = Convert.ToDouble(sokoKyoriTextBox.Text);
            // 給油(54)
            table[0].NippoKyuyu = Convert.ToDouble(kyuyuTextBox.Text);
            // 車両点検記録(62)
            table[0].NippoSharyoTenkenKiroku = syaryoTenkenTextBox.Text;
            // 実地調査件数(60)
            table[0].NippoJitchichosaKensu = string.IsNullOrEmpty(jittiChosaKensuTextBox.Text) ? 0 : Convert.ToInt32(jittiChosaKensuTextBox.Text);
            // 超過原因調査件数(61)
            table[0].NippoChokageninchosaKensu = string.IsNullOrEmpty(chokaGeninTextBox.Text) ? 0 : Convert.ToInt32(chokaGeninTextBox.Text);
            // クロスチェック現地調査件数(59)
            table[0].NippoCrosscheckKensu = string.IsNullOrEmpty(crossCheckTextBox.Text) ? 0 : Convert.ToInt32(crossCheckTextBox.Text);
            // 検査員報告事項(64)
            table[0].NippoHokokujiko = hokokuJikoTextBox.Text;
            // 管理職指示内容(65)
            table[0].NippoShijinaiyo = kanrisyaShijiTextBox.Text;
            // 検査完了フラグ(66)
            table[0].NippoKanryoFlg = kensaKanryoCheckBox.Checked ? "1" : "0";
            // 副課長チェックフラグ(67)
            table[0].NippoFukukachoCheckFlg = fukuKachoKakuninCheckBox.Checked ? "1" : "0";
            // 課長チェックフラグ(68)
            table[0].NippoKachoCheckFlg = kachoKakuninCheckBox.Checked ? "1" : "0";
            // 更新日
            //table[0].UpdateDt = // Defines in appLogic after optimistic lock checking
            // 更新者
            table[0].UpdateUser = user;
            // 更新端末
            table[0].UpdateTarm = host;

            return table;
        }
        #endregion

        #region GetGaikanNippoKbn
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetGaikanNippoKbn
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetGaikanNippoKbn()
        {
            // 外観日報区分
            string nippoKbn = string.Empty;

            // 検査完了(66), 副課長確認(67), 課長確認(68) are all ON
            if (kensaKanryoCheckBox.Checked && fukuKachoKakuninCheckBox.Checked && kachoKakuninCheckBox.Checked)
            {
                nippoKbn = "2";
            }
            else if (!kensaKanryoCheckBox.Checked && !fukuKachoKakuninCheckBox.Checked && !kachoKakuninCheckBox.Checked) // 検査完了(66), 副課長確認(67), 課長確認(68) are all OFF
            {
                nippoKbn = "0";
            }
            else if (kensaKanryoCheckBox.Checked && !fukuKachoKakuninCheckBox.Checked && !kachoKakuninCheckBox.Checked) // 検査完了(66) is ON only
            {
                nippoKbn = "1";
            }

            return nippoKbn;
        }
        #endregion

        #region BindHojoinSource
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： BindHojoinSource
        /// <summary>
        /// Binding source for 補助員 combobox (14)
        /// </summary>
        /// <param name="source"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BindHojoinSource(ShokuinMstDataSet.ShokuinMstDataTable source)
        {
            // 補助員(14)
            DataGridViewComboBoxColumn dgvc = (DataGridViewComboBoxColumn)jissiListDataGridView.Columns[hojoinCol.Name];
            dgvc.DataSource = source;
            dgvc.DisplayMember = "ShokuinNm";
            dgvc.ValueMember = "ShokuinCd";
        }
        #endregion

        #region PassDgvRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PassDgvRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDgv"></param>
        /// <param name="toDgv"></param>
        /// <param name="chushiFlg"></param>
        /// <param name="moveFlg">Indicates the row which moves between 2 datagridview</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PassDgvRow(ZDataGridView fromDgv, ZDataGridView toDgv, string chushiFlg, string moveFlg = null)
        {
            // New source for target dgv
            KensaIraiTblDataSet.KensaNippoInputDataTable newSource = new KensaIraiTblDataSet.KensaNippoInputDataTable();

            // Merge to original source
            if (null != toDgv.DataSource)
            {
                newSource.Merge((KensaIraiTblDataSet.KensaNippoInputDataTable)toDgv.DataSource);
            }

            // Selected row for passing
            KensaIraiTblDataSet.KensaNippoInputRow selectedRow = (KensaIraiTblDataSet.KensaNippoInputRow)((DataRowView)fromDgv.CurrentRow.DataBoundItem).Row;
            selectedRow.KensaChushiFlg = chushiFlg;
            // Row move from?
            selectedRow.RowMove = moveFlg;
            newSource.ImportRow(selectedRow);
            // Delete the selected row
            ((KensaIraiTblDataSet.KensaNippoInputDataTable)fromDgv.DataSource).Rows.Remove(selectedRow);

            // Set new source for target dgv (require clear)
            BindSourceToDgv(toDgv, newSource);
        }
        #endregion

        #region SetChushiFlgToDgvSource
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetChushiFlgToDgvSource
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvSource"></param>
        /// <param name="chushiFlg"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetChushiFlgToDgvSource(KensaIraiTblDataSet.KensaNippoInputDataTable dgvSource, string chushiFlg)
        {
            foreach (KensaIraiTblDataSet.KensaNippoInputRow row in dgvSource)
            {
                row.KensaChushiFlg = chushiFlg;
            }
        }
        #endregion

        #region SetItemSource
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetItemSource
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nippoInputTable"></param>
        /// <param name="nippoVariableTable"></param>
        /// <param name="nippoDtlTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetItemSource
        (
            KensaIraiTblDataSet.KensaNippoInputDataTable nippoInputTable,
            NippoHdrTblDataSet.NippoHdrTblDataTable nippoVariableTable,
            NippoDtlTblDataSet.NippoDtlTblDataTable nippoDtlTable
        )
        {
            #region NippoHdr data
            if (_nippoHdrTable.Count > 0)
            {
                // 実走行距離（日）(51)
                sokoKyoriTextBox.Text = _nippoHdrTable[0].IsNippoSokoKyoriNull() ? string.Empty : _nippoHdrTable[0].NippoSokoKyori.ToString("N1");
                // 給油(54)
                kyuyuTextBox.Text = _nippoHdrTable[0].IsNippoKyuyuNull() ? string.Empty : _nippoHdrTable[0].NippoKyuyu.ToString("N1");
                // クロスチェック現地調査(59)
                crossCheckTextBox.Text = Convert.ToString(_nippoHdrTable[0].NippoCrosscheckKensu);
                // 実地調査件数(60)
                jittiChosaKensuTextBox.Text = Convert.ToString(_nippoHdrTable[0].NippoJitchichosaKensu);
                // 超過原因調査件数(61)
                chokaGeninTextBox.Text = Convert.ToString(_nippoHdrTable[0].NippoChokageninchosaKensu);
                // 車両点検記録(62)
                syaryoTenkenTextBox.Text = _nippoHdrTable[0].NippoSharyoTenkenKiroku;
                // 報告事項等(64)
                hokokuJikoTextBox.Text = _nippoHdrTable[0].NippoHokokujiko;
                // 管理職の指示内容(65)
                kanrisyaShijiTextBox.Text = _nippoHdrTable[0].NippoShijinaiyo;
                // 検査完了(66)
                kensaKanryoCheckBox.Checked = _nippoHdrTable[0].NippoKanryoFlg == "1" ? true : false;
                // 副課長確認(67)
                fukuKachoKakuninCheckBox.Checked = _nippoHdrTable[0].NippoFukukachoCheckFlg == "1" ? true : false;
                // 課長確認(68)
                kachoKakuninCheckBox.Checked = _nippoHdrTable[0].NippoKachoCheckFlg == "1" ? true : false;
            }

            // 実走行距離（月）(52)
            monthSokoKyoriTextBox.Text = _nippoVariable.MonthSokoKyori.ToString("N1");
            // 総走行距離（年）(53)
            yearSokoKyoriTextBox.Text = _nippoVariable.YearSokoKyori.ToString("N1");
            // 最近の燃費(55)
            double kyuyu;
            Double.TryParse(kyuyuTextBox.Text, out kyuyu);
            if (kyuyu == 0)
            {
                if (_nippoVariable.ZenkaiKyuyu != 0)
                {
                    nenpiTextBox.Text = ((_nippoVariable.ZenkaiSokoKyori - _nippoVariable.ZenzenkaiSokoKyori) / _nippoVariable.ZenkaiKyuyu).ToString("N1");
                }
                else
                {
                    nenpiTextBox.Text = "0";
                }
            }
            else
            {
                nenpiTextBox.Text = ((_nippoVariable.YearSokoKyori - _nippoVariable.ZenkaiSokoKyori) / kyuyu).ToString("N1");
            }

            // 総給油量(56)
            totalKyuyuTextBox.Text = _nippoVariable.TotalKyuyu.ToString("N1");
            #endregion

            // 検査員(1)
            string kensainCd = Convert.ToString(kensainComboBox.SelectedValue);
            // yyyyMM of 検査日(2)
            string kensaYM = kensaDtTextBox.Value.ToString("yyyyMM"); // yyyyMM
            // Nendo of 検査日(2)
            int kensaNendo = Utility.DateUtility.GetNendo(kensaDtTextBox.Value); // yyyy
            // April, Nendo of 検査日(2)
            string aprNendo = new DateTime(kensaNendo, 4, 1).ToString("yyyyMM"); // nendo04

            #region 検査時間計(57), 累計検査時間(58)
			// 受入20141219 del
			//double totalKensa = 0;
			//double ruikeiKensa = 0;

            if (nippoInputTable.Rows.Count > 0)
            {
				// 受入20141217 mod sta
				//// 検査時間計(57)
				//object totalKensaObj = nippoInputTable.Compute("sum(KensaKekkaKensaTimes)", string.Empty);
				//// 累計検査時間(58)
				//object ruikeiKensaObj = nippoInputTable.Compute("sum(KensaKekkaKensaTimes)", string.Format("NippoDtlKensaDt >= '{0}' and NippoDtlKensaDt <= '{1}'", aprNendo, kensaYM));

				//// Parse to result
				//Double.TryParse(Convert.ToString(totalKensaObj), out totalKensa);
				//Double.TryParse(Convert.ToString(ruikeiKensaObj), out ruikeiKensa);

				//// Convert minutes to hours
				//TimeSpan ts = TimeSpan.FromMinutes(totalKensa);

				//// 検査時間計(57)
				//totalKensaTimeTextBox.Text = ts.TotalHours.ToString("N1");
				//// 累計検査時間(58)
				//ruikeiKensaTimeTextBox.Text = ruikeiKensa.ToString("N1");

				KensaIraiTblDataSet.KensaNippoInputRow ipRow = (KensaIraiTblDataSet.KensaNippoInputRow)nippoInputTable.Rows[0];

				// 検査時間計(57)
				totalKensaTimeTextBox.Text = ipRow.IsKensaKekkaKensaTimesByKensaDtNull() ? String.Empty : ipRow.KensaKekkaKensaTimesByKensaDt.ToString("N1");

				// 累計検査時間(58)
				ruikeiKensaTimeTextBox.Text = ipRow.IsKensaKekkaKensaTimesByKensainCdNull() ? String.Empty : ipRow.KensaKekkaKensaTimesByKensainCd.ToString("N1");

				// 受入20141217 mod end
			}
            #endregion

            #region 当月稼働日数(45) ~ 日平均件数(50)
            int tougetsuNissu = 0;
            int totalNissu = 0;
            int tougetsuKensu = 0;
            int totalKensu = 0;
			string ndtKensaDt = string.Empty;
			//受入20141217 add sta
			int totalTsukisu = 0;
			string lastYm = String.Empty;
			//受入20141217 add sta
			foreach (NippoHdrTblDataSet.NippoHdrTblRow hdrRow in nippoVariableTable)
            {
                // Return yyyyMM
                ndtKensaDt = hdrRow.NippoKensaDt.Length > 2 ? hdrRow.NippoKensaDt.Substring(0, 6) : string.Empty;

				//受入20141217 mod sta
				
				// 指定された検査日以前のデータのみカウントする
				if (hdrRow.NippoKensaDt.CompareTo(kensaDtTextBox.Value.ToString("yyyyMMdd")) <= 0)
				{
					if (ndtKensaDt == kensaYM)
					{
						tougetsuNissu++;
					}

					if (!lastYm.Equals(ndtKensaDt))
					{
						totalTsukisu++;
						lastYm = ndtKensaDt;
					}

					if (Int32.Parse(ndtKensaDt) >= Int32.Parse(aprNendo)
						&& Int32.Parse(ndtKensaDt) <= Int32.Parse(kensaYM))
					{
						totalNissu++;
					}
				}
				//受入20141217 mod end
			}

            // 当月稼働日数(45)
            tougetsuNissuTextBox.Text = tougetsuNissu.ToString();
            // 稼働日数合計(46)
            totalNissuTextBox.Text = totalNissu.ToString();
            // 月平均稼働日数(47)
			// 受入20141217 mod sta
			//if (kensaYM != aprNendo) // Avoid divide by zero exception
			//{
			//    // ｛稼働日数合計｝/検査日年度の4月から検査日までの月数 ※検査日の月を含める
			//	monthAveNissuTextBox.Text = (totalNissu / ((kensaDtTextBox.Value.Year - kensaNendo) * 12 + kensaDtTextBox.Value.Month - 4)).ToString("N1");
			//}
			if (totalTsukisu > 0)
			{
				monthAveNissuTextBox.Text = ((float)totalNissu / (float)totalTsukisu).ToString("N1");
			}
			// 受入20141217 mod end

            foreach (NippoDtlTblDataSet.NippoDtlTblRow dtlRow in nippoDtlTable)
            {
                // Return yyyyMM
                ndtKensaDt = dtlRow.NippoDtlKensaDt.Length > 2 ? dtlRow.NippoDtlKensaDt.Substring(0, 6) : string.Empty;

                if (ndtKensaDt == kensaYM && dtlRow.NippoDtlKensaChushiFlg != "1")
                {
                    tougetsuKensu++;
                }

                if (Int32.Parse(ndtKensaDt) >= Int32.Parse(aprNendo)
                    && Int32.Parse(ndtKensaDt) <= Int32.Parse(kensaYM)
                    && dtlRow.NippoDtlKensaChushiFlg != "1")
                {
                    totalKensu++;
                }
            }
            // 当月件数(48)
            tougetsuKensuTextBox.Text = tougetsuKensu.ToString();
            // 件数合計(49)
            totalKensuTextBox.Text = totalKensu.ToString();
            // 日平均件数(50)
            if (totalKensu > 0) // Avoid divide by zero exception
            {
                dayAveKensuTextBox.Text = (totalNissu / totalKensu).ToString("N1");
                
            }
            #endregion

            #region Stored values
			_session.KensainCd = Convert.ToString(kensainComboBox.SelectedValue);
			_session.KensaDt = kensaDtTextBox.Value.ToString("yyyyMMdd");

            _session.SokoKyori = sokoKyoriTextBox.Text;
            _session.Kyuyu = kyuyuTextBox.Text;
            _session.CrossCheck = crossCheckTextBox.Text;
            _session.JittiChosaKensu = jittiChosaKensuTextBox.Text;
            _session.ChokaGenin = chokaGeninTextBox.Text;
            _session.SyaryoTenken = syaryoTenkenTextBox.Text;
            _session.HokokuJiko = hokokuJikoTextBox.Text;
            _session.KanrisyaShiji = kanrisyaShijiTextBox.Text;
            _session.KensaKanryo = kensaKanryoCheckBox.Checked;
            _session.FukuKachoKakunin = fukuKachoKakuninCheckBox.Checked;
            _session.KachoKakunin = kachoKakuninCheckBox.Checked;
            _session.MonthSokoKyori = monthSokoKyoriTextBox.Text;
            _session.YearSokoKyori = yearSokoKyoriTextBox.Text;
            _session.Nenpi = nenpiTextBox.Text;
            _session.TotalKyuyu = totalKyuyuTextBox.Text;
            _session.TotalKensaTime = totalKensaTimeTextBox.Text;
            _session.RuikeiKensaTime = ruikeiKensaTimeTextBox.Text;
            _session.TougetsuNissu = tougetsuNissuTextBox.Text;
            _session.TotalNissu = totalNissuTextBox.Text;
            _session.MonthAveNissu = monthAveNissuTextBox.Text;
            _session.TougetsuKensu = tougetsuKensuTextBox.Text;
            _session.TotalKensu = totalKensuTextBox.Text;
            _session.DayAveKensu = dayAveKensuTextBox.Text;
            #endregion
        }
        #endregion

        #region BindSourceToDgv
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： BindSourceToDgv
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgv"></param>
        /// <param name="source"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BindSourceToDgv(ZDataGridView dgv, object source)
        {
            // Clear current datasource
            dgv.DataSource = null;
            dgv.Rows.Clear();

			_gridViewChanged = false;	// 受入20141219 add

            // Binding a new source
            if (null != source)
            {
                dgv.DataSource = source;
            }
        }
        #endregion

        #region IsFormEdit
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsFormEdit
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/27  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsFormEdit()
        {
            #region comments
            //if (_nippoHdrTable.Rows.Count > 0)
            //{
            //    // 実走行距離（日）(51)
            //    double sokoKyori, baseSokoKyori;
            //    Double.TryParse(sokoKyoriTextBox.Text, out sokoKyori);
            //    Double.TryParse(Convert.ToString(_nippoHdrTable[0].NippoSokoKyori), out baseSokoKyori);
            //    if (sokoKyori != baseSokoKyori) { return false; }
            //    // 実走行距離（月）(52)
            //    // 総走行距離（年）(53)

            //    // 給油(54)
            //    double kyuyu, baseKyuyu;
            //    Double.TryParse(kyuyuTextBox.Text, out kyuyu);
            //    Double.TryParse(Convert.ToString(_nippoHdrTable[0].NippoKyuyu), out baseKyuyu);
            //    if (kyuyu != baseKyuyu) { return false; }
            //    // 最近の燃費(55)
            //    // 総給油量(56)

            //    // クロスチェック現地調査(59)
            //    if (crossCheckTextBox.Text !=
            //        Convert.ToString(_nippoHdrTable[0].IsNippoCrosscheckKensuNull() ? string.Empty : _nippoHdrTable[0].NippoCrosscheckKensu.ToString())) { return false; }
            //    // 実地調査件数(60)
            //    if (jittiChosaKensuTextBox.Text !=
            //        Convert.ToString(_nippoHdrTable[0].IsNippoJitchichosaKensuNull() ? string.Empty : _nippoHdrTable[0].NippoJitchichosaKensu.ToString())) { return false; }
            //    // 超過原因調査件数(61)
            //    if (chokaGeninTextBox.Text !=
            //        Convert.ToString(_nippoHdrTable[0].IsNippoChokageninchosaKensuNull() ? string.Empty : _nippoHdrTable[0].NippoChokageninchosaKensu.ToString())) { return false; }
            //    // 車両点検記録(62)
            //    if (syaryoTenkenTextBox.Text != _nippoHdrTable[0].NippoSharyoTenkenKiroku) { return false; }
            //    // 報告事項等(64)
            //    if (hokokuJikoTextBox.Text != _nippoHdrTable[0].NippoHokokujiko) { return false; }
            //    // 管理職の指示内容(65)
            //    if (kanrisyaShijiTextBox.Text != _nippoHdrTable[0].NippoShijinaiyo) { return false; }
            //    // 検査完了(66)
            //    if ((kensaKanryoCheckBox.Checked && _nippoHdrTable[0].NippoKanryoFlg != "1")
            //        || (!kensaKanryoCheckBox.Checked && _nippoHdrTable[0].NippoKanryoFlg == "1")) { return false; }
            //    // 副課長確認(67)
            //    if ((fukuKachoKakuninCheckBox.Checked && _nippoHdrTable[0].NippoFukukachoCheckFlg != "1")
            //        || (!fukuKachoKakuninCheckBox.Checked && _nippoHdrTable[0].NippoFukukachoCheckFlg == "1")) { return false; }
            //    // 課長確認(68)
            //    if ((kachoKakuninCheckBox.Checked && _nippoHdrTable[0].NippoKachoCheckFlg != "1")
            //        || (!kachoKakuninCheckBox.Checked && _nippoHdrTable[0].NippoKachoCheckFlg == "1")) { return false; }
            //}
            //else // No record in NippoHdr table
            //{
            //    if (sokoKyoriTextBox.Text != string.Empty
            //        || kyuyuTextBox.Text != string.Empty
            //        || crossCheckTextBox.Text != string.Empty
            //        || jittiChosaKensuTextBox.Text != string.Empty
            //        || chokaGeninTextBox.Text != string.Empty
            //        || syaryoTenkenTextBox.Text != string.Empty
            //        || hokokuJikoTextBox.Text != string.Empty
            //        || kanrisyaShijiTextBox.Text != string.Empty
            //        || kensaKanryoCheckBox.Checked
            //        || fukuKachoKakuninCheckBox.Checked
            //        || kachoKakuninCheckBox.Checked)
            //    {
            //        return false;
            //    }
            //}
            #endregion

            // 検査員(1)
            if (Convert.ToString(kensainComboBox.SelectedValue) != _session.KensainCd) { return false; }
            // 検査日(2)
            if (kensaDtTextBox.Value.ToString("yyyyMMdd") != _session.KensaDt) { return false; }
            // 当月稼働日数(45)
            if (tougetsuNissuTextBox.Text != _session.TougetsuNissu) { return false; }
            // 稼働日数合計(46)
            if (totalNissuTextBox.Text != _session.TotalNissu) { return false; }
            // 月平均稼働日数(47)
            if (monthAveNissuTextBox.Text != _session.MonthAveNissu) { return false; }
            // 当月件数(48)
            if (tougetsuKensuTextBox.Text != _session.TougetsuKensu) { return false; }
            // 件数合計(49)
            if (totalKensuTextBox.Text != _session.TotalKensu) { return false; }
            // 日平均件数(50)
            if (dayAveKensuTextBox.Text != _session.DayAveKensu) { return false; }
            // 実走行距離（日）(51)
            if (sokoKyoriTextBox.Text != _session.SokoKyori) { return false; }
            // 実走行距離（月）(52)
            if (monthSokoKyoriTextBox.Text != _session.MonthSokoKyori) { return false; }
            // 総走行距離（年）(53)
            if (yearSokoKyoriTextBox.Text != _session.YearSokoKyori) { return false; }
            // 給油(54)
            if (kyuyuTextBox.Text != _session.Kyuyu) { return false; }
            // 最近の燃費(55)
            if (nenpiTextBox.Text != _session.Nenpi) { return false; }
            // 総給油量(56)
            if (totalKyuyuTextBox.Text != _session.TotalKyuyu) { return false; }
            // 検査時間計(57)
            if (totalKensaTimeTextBox.Text != _session.TotalKensaTime) { return false; }
            // 累計検査時間(58)
            if (ruikeiKensaTimeTextBox.Text != _session.RuikeiKensaTime) { return false; }
            // クロスチェック現地調査(59)
            if (crossCheckTextBox.Text != _session.CrossCheck) { return false; }
            // 実地調査件数(60)
            if (jittiChosaKensuTextBox.Text != _session.JittiChosaKensu) { return false; }
            // 超過原因調査件数(61)
            if (chokaGeninTextBox.Text != _session.ChokaGenin) { return false; }
            // 車両点検記録(62)
            if (syaryoTenkenTextBox.Text != _session.SyaryoTenken) { return false; }
            // 報告事項等(64)
            if (hokokuJikoTextBox.Text != _session.HokokuJiko) { return false; }
            // 管理職の指示内容(65)
            if (kanrisyaShijiTextBox.Text != _session.KanrisyaShiji) { return false; }
            // 検査完了(66)
            if (kensaKanryoCheckBox.Checked != _session.KensaKanryo) { return false; }
            // 副課長確認(67)
            if (fukuKachoKakuninCheckBox.Checked != _session.FukuKachoKakunin) { return false; }
            // 課長確認(68)
            if (kachoKakuninCheckBox.Checked != _session.KachoKakunin) { return false; }

			//// 検査実施一覧グリッドビュー(7)
			//KensaIraiTblDataSet.KensaNippoInputDataTable jissiSource = (KensaIraiTblDataSet.KensaNippoInputDataTable)jissiListDataGridView.DataSource;
			//DataTable difJissiTable = CompareTables(jissiSource, _session.JisshiSource);
			//if (difJissiTable.Rows.Count > 0) { return false; }

			//// 検査中止一覧グリッドビュー(31)
			//KensaIraiTblDataSet.KensaNippoInputDataTable chushiSource = (KensaIraiTblDataSet.KensaNippoInputDataTable)chushiListDataGridView.DataSource;
			//DataTable difChushiTable = CompareTables(chushiSource, _session.ChushiSource);
			//if (difChushiTable.Rows.Count > 0) { return false; }

			// 受入20141219 add sta グリッドは画面上で編集された状態でも、編集有りとする。
			// 検査実施一覧グリッドビュー(7)、検査中止一覧グリッドビュー(31)
			if (_gridViewChanged)
			{
				return false;
			}
			// 受入20141219 add end

            return true;
        }
        #endregion

        #region ControlNippoAddCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ControlNippoAddCol
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.04
        /// 2014/12/04  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ControlNippoAddCol()
        {
            // 検査状況(75)
            string kensaJokyo = string.Empty;
            // 水質No(17)
            string suishitsuNo = string.Empty;
            DataGridViewCheckBoxCell dgvCk;

            foreach (DataGridViewRow dgvr in jissiListDataGridView.Rows)
            {
                // Cast 日報追加(74) cell as Checkbox cell
                dgvCk = (DataGridViewCheckBoxCell)dgvr.Cells[nippoAddCol.Name];

                if (_dispMode == DispMode.Edit || _dispMode == DispMode.NonEditable)
                {
                    // Disable and check ON 日報追加(74)
                    //dgvCk.ReadOnly = true;
                    dgvCk.ReadOnly = true;
                    dgvCk.Value = "1";
                }
                else if (_dispMode == DispMode.Add)
                {
                    kensaJokyo = Convert.ToString(dgvr.Cells[kensaJokyoCol.Name].Value);
                    suishitsuNo = Convert.ToString(dgvr.Cells[suishitsuNoCol.Name].Value);

                    if (kensaJokyo == "003") // v1.05 change from 1 to 003
                    {
                        // Disable and check ON 日報追加(74)
                        dgvCk.ReadOnly = true;
						dgvCk.Value = "1";
                        //dgvCk.FlatStyle = FlatStyle.Flat;
                        //dgvCk.Style.ForeColor = Color.DarkGray;
                        //dgvCk.Value = "1"; // Implements in SQL
                    }
                    else if (kensaJokyo == "002" || kensaJokyo == "004") //2015.01.08 mod kiyokuni 
                    //else if (kensaJokyo == "002") // v1.05 change from 2 to 002
                    {
                        if (!string.IsNullOrEmpty(suishitsuNo))
                        {
                            // Disable and check ON 日報追加(74)
                            dgvCk.ReadOnly = true;
							dgvCk.Value = "1";
							//dgvCk.FlatStyle = FlatStyle.Flat;
                            //dgvCk.Style.ForeColor = Color.DarkGray;
                            //dgvCk.Value = "1";
                        }
                        else
                        {
                            // Enable and check OFF 日報追加(74)
                            dgvCk.ReadOnly = false;
							dgvCk.Value = "0";
							//dgvCk.Value = "0";
                        }
                    }
                    else if (kensaJokyo == "001") // v1.05 change from 3 to 001
                    {
                        // Enable and check OFF 日報追加(74)
                        dgvCk.ReadOnly = true;
						dgvCk.Value = "0";
						//dgvCk.Value = "0";
                    }
                }
            }
        }
        #endregion

        #region CompareTables
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CompareTables
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private DataTable CompareTables(DataTable first, DataTable second)
        {
            first.TableName = "FirstTable";
            second.TableName = "SecondTable";
 
            //Create Empty Table
            DataTable table = new DataTable("Difference");

            try
            {
                //Must use a Dataset to make use of a DataRelation object
                using (System.Data.DataSet ds = new System.Data.DataSet())
                {
                    //Add first tables
                    ds.Tables.Add(first.Copy());

                    // Second table exist in current DataSet?
                    if (!ds.Tables.Contains(second.TableName))
                    {
                        ds.Tables.Add(second.Copy());
                    }
                    else
                    {
                        // Exist => 2 tables are same
                        return new DataTable();
                    }

                    //Get Columns for DataRelation
                    DataColumn[] firstcolumns = new DataColumn[2];
                    firstcolumns[0] = ds.Tables[0].Columns[1];
                    firstcolumns[1] = ds.Tables[0].Columns[7];

                    DataColumn[] secondcolumns = new DataColumn[2];
                    secondcolumns[0] = ds.Tables[1].Columns[1];
                    secondcolumns[1] = ds.Tables[1].Columns[7];

                    //Create DataRelation
                    DataRelation r = new DataRelation(string.Empty, firstcolumns, secondcolumns, false);

                    ds.Relations.Add(r);

                    //Create columns for return table
                    for (int i = 0; i < first.Columns.Count; i++)
                    {
                        table.Columns.Add(first.Columns[i].ColumnName, first.Columns[i].DataType);
                    }

                    //If First Row not in Second, Add to return table.
                    table.BeginLoadData();

                    foreach (DataRow parentrow in ds.Tables[0].Rows)
                    {
                        DataRow[] childrows = parentrow.GetChildRows(r);
                        if (childrows == null || childrows.Length == 0)
                            table.LoadDataRow(parentrow.ItemArray, true);
                    }

                    table.EndLoadData();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
 
            return table;
        }
        #endregion

        #endregion

    }
    #endregion
}
