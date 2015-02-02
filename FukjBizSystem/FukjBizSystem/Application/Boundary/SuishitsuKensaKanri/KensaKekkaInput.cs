using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KensaKekkaInput;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaKekkaInputForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01　HieuNH　　　新規作成
    /// 2014/12/25　小松  　　　計量証明時も温度を表示・登録（pH時）
    /// 2014/12/29  小松        法定検査と計量証明で検査項目コンボの内容を切替
    /// 2015/01/22  小松　　　　クリアボタン押下時は初期値を設定
    ///                         検査区分を切り替えた時の処理を正しく修正
    ///                         範囲選択で未選択(空白)が選べないのを対処
    ///                         範囲選択直後に更新チェックが ONになるように修正
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaKekkaInputForm : FukjBaseForm
    {
        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Update,
            Init,
        }

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 検索条件の表示・非表示フラグ(初期値：表示）
        /// </summary>
        private bool _searchShowFlg = true;
        private int _defaultSearchPanelTop = 0;
        private int _defaultSearchPanelHeight = 0;
        private int _defaultListPanelTop = 0;
        private int _defaultListPanelHeight = 0;

        /// <summary>
        /// 表示モード
        /// </summary>
        public DispMode _dispMode = DispMode.Init;

        /// <summary>
        /// currentDateTime
        /// </summary>
        private DateTime _currentDateTime;

        /// <summary>
        /// Data source for hoteiKensaListDataGridView
        /// </summary>
        private KensaDaicho11joHdrTblDataSet.KensaKekkaInputSearch1DataTable _hoteiKensaListDataTable = new KensaDaicho11joHdrTblDataSet.KensaKekkaInputSearch1DataTable();

        /// <summary>
        /// Data source for keiryoKensaListDataGridView
        /// </summary>
        private KensaDaicho9joHdrTblDataSet.KensaKekkaInputSearch2DataTable _keiryoKensaListDataTable = new KensaDaicho9joHdrTblDataSet.KensaKekkaInputSearch2DataTable();

        /// <summary>
        /// Previous KensaRadioButton checked
        /// </summary>
        private RadioButton _previousKensaRadioButtonChecked;

        /// <summary>
        /// Flag identify radio buttons are change manually
        /// </summary>
        private bool _changeRadioBtnManually;

        /// <summary>
        /// Flag identify a gridview has been changed
        /// </summary>
        private bool _gridViewChanged;

        /// <summary>
        /// 法定検査用水質試験項目マスタ
        /// </summary>
        //private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable HoteiSuishitsuShikenKoumokuMstDataTable;
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable HoteiSuishitsuShikenKoumokuMstSelectListDataTable;
        /// <summary>
        /// 計量証明用水質試験項目マスタ
        /// </summary>
        //private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable KeiryoSuishitsuShikenKoumokuMstDataTable;
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable KeiryoSuishitsuShikenKoumokuMstSelectListDataTable;
        /// <summary>
        /// 法定検査用外観試験項目マスタ
        /// </summary>
        private SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable HoteiGaikanShikenKoumokuMstSelectListDataTable;

        //20150122 sou Start
        /// <summary>
        /// 試験項目コード
        /// </summary>
        private string kmkCdPh = Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, Constants.ConstKbnConstanst.CONST_KBN_001);
        private string kmkCdGaikan = Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, Constants.ConstKbnConstanst.CONST_KBN_027);
        private string kmkCdShuki = Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, Constants.ConstKbnConstanst.CONST_KBN_028);
        private string kmkCdNo2n = Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, Constants.ConstKbnConstanst.CONST_KBN_030);
        private string kmkCdNo3n = Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_049, Constants.ConstKbnConstanst.CONST_KBN_031);
        //20150122 sou End

        #endregion


        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaKekkaInputForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaKekkaInputForm()
            : base()
        {
            InitializeComponent();
            SetControlDomain();
            keiryoKensaListDataGridView.Location = hoteiKensaListDataGridView.Location;
            keiryoKensaListDataGridView.Height = hoteiKensaListDataGridView.Height;
        }
        #endregion

        #region イベント

        #region viewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： viewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void viewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = !this._searchShowFlg;
                if (this._searchShowFlg)//検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else////検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }

                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.listPanel,
                    this._defaultListPanelTop,
                    this._defaultListPanelHeight);
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

        #region gaikanKensaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： gaikanKensaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gaikanKensaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDisplayGridview(sender as RadioButton);

                //// 検査項目 (法定検査)
                //// 20150119 sou Start
                ////Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstDataTable, "SeishikiNm", "SuishitsuShikenKoumokuCd", true);
                //Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                //// 20150119 sou End
                //kensaKomokuComboBox.SelectedIndex = 0;
                // 20150131 sou Start
                // 温度列の表示設定
                hoteiKensaListDataGridView.Columns[hoteiOndoCol.Index].Visible = false;
                // 20150131 sou End
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

		//#region kensaShubetsuRadioButton_Click
		//////////////////////////////////////////////////////////////////////////////
		////  イベント名 ： kensaShubetsuRadioButton_Click
		///// <summary>
		///// 
		///// </summary>
		///// <param name="e"></param>
		///// <param name="sender"></param>
		///// <history>
		///// 日付　　　　担当者　　　内容
		///// 2014/12/18　Toguchi 　　新規作成
		///// </history>
		//////////////////////////////////////////////////////////////////////////////
		//private void kensaShubetsuRadioButton_Click(object sender, EventArgs e)
		//{
		//    // 事前にラジオボタンのAutoCheck = false にしておくこと。

		//    if (hoteiKensaListDataGridView.Rows.Count > 0 ||
		//        keiryoKensaListDataGridView.Rows.Count > 0)
		//    {
		//        if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力中のデータが存在します。入力が破棄されますがよろしいですか？") == DialogResult.No)
		//        {
		//            return;
		//        }
		//    }
			
		//    RadioButton clickedRadio = (RadioButton)sender;
			
		//    // CheckedChangedイベントの内部で前回のラジオボタンを参照しているため、初回なら外観検査を前回とする。
		//    if (_previousKensaRadioButtonChecked == null)
		//    {
		//        _previousKensaRadioButtonChecked = this.gaikanKensaRadioButton;
		//    }

		//    clickedRadio.Checked = true;

		//    if (clickedRadio.Name.Equals(this.gaikanKensaRadioButton.Name))
		//    {
		//        this.suishitsuKensaRadioButton.Checked = false;
		//        this.keiryoShomeiKensaRadioButton.Checked = false;
		//    }
		//    else if (clickedRadio.Name.Equals(this.suishitsuKensaRadioButton.Name))
		//    {
		//        this.gaikanKensaRadioButton.Checked = false;
		//        this.keiryoShomeiKensaRadioButton.Checked = false;
		//    }
		//    else if (clickedRadio.Name.Equals(this.keiryoShomeiKensaRadioButton.Name))
		//    {
		//        this.gaikanKensaRadioButton.Checked = false;
		//        this.suishitsuKensaRadioButton.Checked = false;
		//    }

		//}
		//#endregion

		#region keiryoShomeiKensaRadioButton_CheckedChanged
		////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keiryoShomeiKensaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void keiryoShomeiKensaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDisplayGridview(sender as RadioButton);

                //// 検査項目 (計量証明)
                //// 20150119 sou Start
                ////Utility.Utility.SetComboBoxList(kensaKomokuComboBox, KeiryoSuishitsuShikenKoumokuMstDataTable, "SeishikiNm", "SuishitsuShikenKoumokuCd", true);
                //Utility.Utility.SetComboBoxList(kensaKomokuComboBox, KeiryoSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                //// 20150119 sou Start
                //kensaKomokuComboBox.SelectedIndex = 0;
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

        #region suishitsuKensaRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDisplayGridview(sender as RadioButton);

                //// 検査項目 (法定検査)
                //// 20150119 sou Start
                ////Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstDataTable, "SeishikiNm", "SuishitsuShikenKoumokuCd", true);
                //Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                //// 20150119 sou End
                //kensaKomokuComboBox.SelectedIndex = 0;
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

        #region suishitsuKensaIraiNoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaIraiNoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaIraiNoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

				//受入20141218 Fromで入力された値をLeave時にTo側へコピーする。
				Common.Common.PaddingZeroForTextBoxLeave(
					(Control.ZTextBox)sender,
					suishitsuKensaIraiNoFromTextBox,
					suishitsuKensaIraiNoToTextBox
				);
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

        #region suishitsuKensaIraiNoToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaIraiNoToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaIraiNoToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                PaddingZeroForTextBoxLeave((Control.ZTextBox)sender);
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

        #region KensaKekkaInputForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKekkaInputForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// 2014/12/10　HieuNH　　　Add event for DataError of Combobox
        /// 2015/01/29  宗          外観検査用の選択リストを追加で取得
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKekkaInputForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = true;
                this._defaultSearchPanelTop = this.searchPanel.Top;
                this._defaultSearchPanelHeight = this.searchPanel.Height;
                this._defaultListPanelTop = this.listPanel.Top;
                this._defaultListPanelHeight = this.listPanel.Height;

                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());

                // 支所 (6)
                //Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
                Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);

                // 検査項目用コンボボックス値取得
                // 20150119 sou Start
                //HoteiSuishitsuShikenKoumokuMstDataTable = alOutput.HoteiSuishitsuShikenKoumokuMstDataTable;
                HoteiSuishitsuShikenKoumokuMstSelectListDataTable = alOutput.HoteiSuishitsuShikenKoumokuMstSelectListDataTable;
                //KeiryoSuishitsuShikenKoumokuMstDataTable = alOutput.KeiryoSuishitsuShikenKoumokuMstDataTable;
                KeiryoSuishitsuShikenKoumokuMstSelectListDataTable = alOutput.KeiryoSuishitsuShikenKoumokuMstSelectListDataTable;
                // 20150119 sou End
                // 20150129 sou Start
                HoteiGaikanShikenKoumokuMstSelectListDataTable = alOutput.HoteiGaikanShikenKoumokuMstSelectListDataTable;
                // 20150129 sou End

                // 検査項目 (7)
                // 20150119 sou Start
                //Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstDataTable, "SeishikiNm", "SuishitsuShikenKoumokuCd", true);
                Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                // 20150119 sou End

                // 範囲 (22)
                //hoteiSokuteiHaniComboBoxCol.DataSource = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_027);
                //hoteiSokuteiHaniComboBoxCol.ValueMember = "ConstValue";
                //hoteiSokuteiHaniComboBoxCol.DisplayMember = "ConstNm";
                Utility.Utility.SetComboBoxColumnList(hoteiSokuteiHaniComboBoxCol, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_027), "ConstNm", "ConstValue", true);

                // 範囲 (35)
                //keiryoSokuteiHaniComboBoxCol.DataSource = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_027);
                //keiryoSokuteiHaniComboBoxCol.ValueMember = "ConstValue";
                //keiryoSokuteiHaniComboBoxCol.DisplayMember = "ConstNm";
                Utility.Utility.SetComboBoxColumnList(keiryoSokuteiHaniComboBoxCol, Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_027), "ConstNm", "ConstValue", true);

                // 結果 (36)
                keiryoKekkaComboBoxCol.DataSource = alOutput.SuishitsuKekkaNmMstDataTable;
                keiryoKekkaComboBoxCol.ValueMember = "SuishitsuKekkaNmCd";
                keiryoKekkaComboBoxCol.DisplayMember = "SuishitsuKekkaNm";

                hoteiKensaListDataGridView.AutoGenerateColumns = false;
                hoteiKensaListDataGridView.DataSource = _hoteiKensaListDataTable;

                keiryoKensaListDataGridView.AutoGenerateColumns = false;
                keiryoKensaListDataGridView.DataSource = _keiryoKensaListDataTable;

                _currentDateTime = Common.Common.GetCurrentTimestamp();
                iraiNendoTextBox.Text = (Utility.DateUtility.GetNendo(_currentDateTime)).ToString();

                _changeRadioBtnManually = true;

                //// ADD HieuNH 2014/12/10 BEGIN
                hoteiKensaListDataGridView.DataError += new DataGridViewDataErrorEventHandler(hoteiKensaListDataGridView_DataError);
                //// ADD HieuNH 2014/12/10 END
                keiryoKensaListDataGridView.DataError += new DataGridViewDataErrorEventHandler(keiryoKensaListDataGridView_DataError);

                shishoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

                hoteiKensaListDataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(hoteiKensaListDataGridView_EditingControlShowing);
                keiryoKensaListDataGridView.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(keiryoKensaListDataGridView_EditingControlShowing);

                // 温度列を非表示
                keiryoKensaListDataGridView.Columns[keiryoOndoCol.Index].Visible = false;
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

        void keiryoKensaListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            _gridViewChanged = true;
        }

        void hoteiKensaListDataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            _gridViewChanged = true;
        }

        #region keiryoKensaListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keiryoKensaListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        void keiryoKensaListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if(keiryoKensaListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
                {
                    DataGridViewComboBoxCell cell = keiryoKensaListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    cell.Value = null;
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

        #region hoteiKensaListDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ：hoteiKensaListDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        void hoteiKensaListDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (hoteiKensaListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewComboBoxCell)
                {
                    DataGridViewComboBoxCell cell = hoteiKensaListDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex] as DataGridViewComboBoxCell;
                    cell.Value = null;
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
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ClearSearchPanel();
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

        #region kensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                DoSearch();
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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// 2015/01/15　小松　　　　完了メッセージ後に画面クリア
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void torokuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!RelationCheck())
                    return;

                if (!GridviewCheck())
                    return;

                if (!InputCheck())
                    return;

				//受入20141218 add sta
				if (!ValidateCheck())
				{
					return;
				}
				//受入20141218 add end

				ITorokuBtnClickALInput alInput = new TorokuBtnClickALInput();
                alInput.IraiNendo = iraiNendoTextBox.Text;
                alInput.ShishoCd = shishoComboBox.SelectedValue.ToString();

                if (gaikanKensaRadioButton.Checked)
                    alInput.KensaKbn = "3";
                else if (suishitsuKensaRadioButton.Checked)
                    alInput.KensaKbn = "2";
                else if (keiryoShomeiKensaRadioButton.Checked)
                    alInput.KensaKbn = "1";
                alInput.KensaKekkaInputSearch1DataTable = _hoteiKensaListDataTable;
                alInput.KensaKekkaInputSearch2DataTable = _keiryoKensaListDataTable;

                new TorokuBtnClickApplicationLogic().Execute(alInput);

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "登録処理が完了しました。");

                _hoteiKensaListDataTable.Clear();
                _keiryoKensaListDataTable.Clear();
				_gridViewChanged = false;	// 受入20141218 一覧をクリアするので、一覧編集済みフラグもクリア。
                // 検索結果件数
                listCountLabel.Text = "0件";
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

        #region KensaKekkaInputForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKekkaInputForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKekkaInputForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F5:
                        entryButton.Focus();
                        entryButton.PerformClick();
                        break;
                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
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

        #region KensaKekkaInputForm_Shown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KensaKekkaInputForm_Shown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KensaKekkaInputForm_Shown(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                _gridViewChanged = false;
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
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

				// 受入20141218 mod sta
				if (hoteiKensaListDataGridView.Rows.Count > 0 ||
					keiryoKensaListDataGridView.Rows.Count > 0)
				{
					if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力中のデータが存在します。入力が破棄されますがよろしいですか？") == DialogResult.No)
					{
						return;
					}
				}

				Program.mForm.MovePrev();
				// 受入20141218 mod end
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

        #region hoteiKensaListDataGridView_CurrentCellDirtyStateChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoteiKensaListDataGridView_CurrentCellDirtyStateChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoteiKensaListDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (hoteiKensaListDataGridView.CurrentCell is DataGridViewCheckBoxCell)
                {
                    hoteiKensaListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    hoteiKensaListDataGridView.EndEdit();
                }
                else if (hoteiKensaListDataGridView.CurrentCell is DataGridViewComboBoxCell)
                {
                    hoteiKensaListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    hoteiKensaListDataGridView.EndEdit();
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

        #region hoteiKensaListDataGridView_CellEndEdit
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoteiKensaListDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoteiKensaListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

				// 受入20141218 足りない列定義を追加
                if (e.ColumnIndex == hoteiSaikensaCheckBoxCol.Index ||
 					e.ColumnIndex == hoteiSokuteiValueCol.Index ||
					e.ColumnIndex == hoteiSokuteiHaniComboBoxCol.Index ||
					e.ColumnIndex == hoteiOndoCol.Index || 
					e.ColumnIndex == hoteiGaibuItakuCheckBoxCol.Index)
                {
                    DataGridViewCheckBoxCell cell = hoteiKensaListDataGridView.Rows[e.RowIndex].Cells[hoteiUpdateCheckBoxCol.Index] as DataGridViewCheckBoxCell;
                    cell.Value = cell.TrueValue;
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

        #region keiryoKensaListDataGridView_CellEndEdit
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keiryoKensaListDataGridView_CellEndEdit
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void keiryoKensaListDataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

				// 受入20141218 足りない列定義を追加
				if (e.ColumnIndex == keiryoSaikensaCheckBoxCol.Index ||
					e.ColumnIndex == keiryoSokuteiValueCol.Index ||
					e.ColumnIndex == keiryoSokuteiHaniComboBoxCol.Index ||
					e.ColumnIndex == keiryoKekkaComboBoxCol.Index ||
                    e.ColumnIndex == keiryoOndoCol.Index ||
                    e.ColumnIndex == keiryoGaibuItakuCheckBoxCol.Index)
                {
                    DataGridViewCheckBoxCell cell = keiryoKensaListDataGridView.Rows[e.RowIndex].Cells[keiryoUpdateCheckBoxCol.Index] as DataGridViewCheckBoxCell;
                    cell.Value = cell.TrueValue;
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

        #region keiryoKensaListDataGridView_CurrentCellDirtyStateChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keiryoKensaListDataGridView_CurrentCellDirtyStateChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void keiryoKensaListDataGridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (keiryoKensaListDataGridView.CurrentCell is DataGridViewCheckBoxCell)
                {
                    keiryoKensaListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    keiryoKensaListDataGridView.EndEdit();
                }
                else if (keiryoKensaListDataGridView.CurrentCell is DataGridViewComboBoxCell)
                {
                    keiryoKensaListDataGridView.CommitEdit(DataGridViewDataErrorContexts.Commit);
                    keiryoKensaListDataGridView.EndEdit();
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

        #endregion

        #region メソッド(private)

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// 2015/01/11  小松　　　　結果値、温度の型をDBにあわせる
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            iraiNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4, HorizontalAlignment.Left);
            suishitsuKensaIraiNoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);
            suishitsuKensaIraiNoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6, HorizontalAlignment.Left);

            hoteiKensaListDataGridView.SetStdControlDomain(hoteiRowNoCol.Index, ZControlDomain.ZG_STD_NUM, -1, DataGridViewContentAlignment.MiddleRight);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiSuishitsuKensaIraiNoCol.Index, ZControlDomain.ZG_STD_CD, 6, DataGridViewContentAlignment.MiddleLeft);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiShikenKomokuCdCol.Index, ZControlDomain.ZG_STD_CD, 3, DataGridViewContentAlignment.MiddleLeft);
            //hoteiKensaListDataGridView.SetStdControlDomain(hoteiSokuteiValueCol.Index, ZControlDomain.ZG_STD_NUM, 9, DataGridViewContentAlignment.MiddleRight);
            //hoteiKensaListDataGridView.SetStdControlDomain(hoteiOndoCol.Index, ZControlDomain.ZG_STD_NUM, 5, DataGridViewContentAlignment.MiddleRight);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiHoteiKbnCol.Index, ZControlDomain.ZG_STD_NAME, -1, DataGridViewContentAlignment.MiddleLeft);
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiKensaNoCol.Index, ZControlDomain.ZG_STD_CD, -1, DataGridViewContentAlignment.MiddleLeft);
            hoteiKensaNoCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			hoteiSuishitsuKensaIraiNoCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            keiryoKensaListDataGridView.SetStdControlDomain(keiryoRowNoCol.Index, ZControlDomain.ZG_STD_NUM, -1, DataGridViewContentAlignment.MiddleRight);
            keiryoKensaListDataGridView.SetStdControlDomain(keiryoSuishitsuKensaIraiNoCol.Index, ZControlDomain.ZG_STD_CD, 6, DataGridViewContentAlignment.MiddleLeft);
            keiryoKensaListDataGridView.SetStdControlDomain(keiryoShikenKomokuCdCol.Index, ZControlDomain.ZG_STD_CD, 3, DataGridViewContentAlignment.MiddleLeft);
            //keiryoKensaListDataGridView.SetStdControlDomain(keiryoSokuteiValueCol.Index, ZControlDomain.ZG_STD_NUM, 9, DataGridViewContentAlignment.MiddleRight);
            keiryoKensaListDataGridView.SetStdControlDomain(keiryoKensaNoCol.Index, ZControlDomain.ZG_STD_CD, -1, DataGridViewContentAlignment.MiddleLeft);
            //keiryoKensaListDataGridView.SetStdControlDomain(keiryoOndoCol.Index, ZControlDomain.ZG_STD_NUM, 5, DataGridViewContentAlignment.MiddleRight);
            keiryoKensaListDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
			keiryoSuishitsuKensaIraiNoCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            // 結果値：decimal(9,3)＝整数部6桁、小数部3桁
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiSokuteiValueCol.Index, ZControlDomain.ZG_STD_NUM, 9, 3, InputValidateUtility.SignFlg.Positive);
            keiryoKensaListDataGridView.SetStdControlDomain(keiryoSokuteiValueCol.Index, ZControlDomain.ZG_STD_NUM, 9, 3, InputValidateUtility.SignFlg.Positive);
            // 温度：decimal(5,3)＝整数部2桁、小数部3桁
            hoteiKensaListDataGridView.SetStdControlDomain(hoteiOndoCol.Index, ZControlDomain.ZG_STD_NUM, 5, 3, InputValidateUtility.SignFlg.Positive);
            keiryoKensaListDataGridView.SetStdControlDomain(keiryoOndoCol.Index, ZControlDomain.ZG_STD_NUM, 5, 3, InputValidateUtility.SignFlg.Positive);
        }
        #endregion

        // (2015/01/22) komatsu　未使用の為削除
        //#region SetControlData
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： SetControlData
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/12/01　HieuNH　　　新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void SetControlData()
        //{
        //    _currentDateTime = Common.Common.GetCurrentTimestamp();
        //    iraiNendoTextBox.Text = (Utility.DateUtility.GetNendo(_currentDateTime)).ToString();

        //    //gaikanKensaRadioButton.Checked = true;
        //    suishitsuKensaRadioButton.Checked = true;
        //    listCountLabel.Text = "0件";

        //    SetDisplayGridview(gaikanKensaRadioButton);

        //}
        //#endregion

        #region SetDisplayGridview
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayGridview
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// 2015/01/22  小松　　　　検査項目コンボボックスの入れ替えはここで行う。（「いいえ」の時クリアされてしまうため）
        /// 2015/01/29  宗          水質検査と外観検査で検索項目の選択リストを分ける
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayGridview(RadioButton rb)
        {
            if (rb != null)
            {
                if (rb.Checked && _changeRadioBtnManually)
                {
                    if (_changeRadioBtnManually)
                    {
                        // 検査種別：外観、水質
                        //if ((rb.Name.Equals(gaikanKensaRadioButton.Name) || rb.Name.Equals(suishitsuKensaRadioButton.Name)) && (_previousKensaRadioButtonChecked.Name.Equals(keiryoShomeiKensaRadioButton.Name)))
                        if (rb.Name.Equals(gaikanKensaRadioButton.Name) || rb.Name.Equals(suishitsuKensaRadioButton.Name))
                        {
                            if (CheckForChangeRadioBtn())
                            {
                                hoteiKensaListDataGridView.Visible = true;
                                _hoteiKensaListDataTable.Clear();
                                keiryoKensaListDataGridView.Visible = false;
                                _keiryoKensaListDataTable.Clear();
                                _gridViewChanged = false;
                                // 検索結果件数
                                listCountLabel.Text = "0件";

                                if (rb.Name.Equals(suishitsuKensaRadioButton.Name))
                                {
                                    // 検査項目 (水質検査)
                                    Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                                    kensaKomokuComboBox.SelectedIndex = 0;
                                }
                                else
                                {
                                    // 検査項目 (外観検査)
                                    Utility.Utility.SetComboBoxList(kensaKomokuComboBox, HoteiGaikanShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                                    kensaKomokuComboBox.SelectedIndex = 0;
                                }
                            }
                            else
                            {
                                _changeRadioBtnManually = false;
                                _previousKensaRadioButtonChecked.Checked = true;
                            }
                        }
						else if (rb.Name.Equals(keiryoShomeiKensaRadioButton.Name))
						{
							if (CheckForChangeRadioBtn())
							{
								hoteiKensaListDataGridView.Visible = false;
								_hoteiKensaListDataTable.Clear();
								keiryoKensaListDataGridView.Visible = true;
								_keiryoKensaListDataTable.Clear();
								_gridViewChanged = false;
                                // 検索結果件数
                                listCountLabel.Text = "0件";

                                // 検査項目 (計量証明)
                                Utility.Utility.SetComboBoxList(kensaKomokuComboBox, KeiryoSuishitsuShikenKoumokuMstSelectListDataTable, "CdRyakushikNm", "SuishitsuShikenKoumokuCd", true);
                                kensaKomokuComboBox.SelectedIndex = 0;
                            }
							else
							{
								_changeRadioBtnManually = false;
								_previousKensaRadioButtonChecked.Checked = true;
							}
						}
						// 受入20141218 add sta 計量証明への行き帰りだけでなく、外観と水質の行き帰りでも一覧をクリアする。
						else
						{
							if (CheckForChangeRadioBtn())
							{
								_hoteiKensaListDataTable.Clear();
								_keiryoKensaListDataTable.Clear();
								_gridViewChanged = false;
                                // 検索結果件数
                                listCountLabel.Text = "0件";

                                kensaKomokuComboBox.SelectedIndex = 0;
                            }
							else
							{
								_changeRadioBtnManually = false;
								_previousKensaRadioButtonChecked.Checked = true;
							}
								
						}
						// 受入20141218 add end
					}
                    _changeRadioBtnManually = true;
                }
                else
                {
                    _previousKensaRadioButtonChecked = rb;
                }
            }
        }
        #endregion

        #region PaddingZeroForTextBoxLeave
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PaddingZeroForTextBoxLeave
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PaddingZeroForTextBoxLeave(Control.ZTextBox targetTextBox)
        {
            // Stop handle for empty target textbox
            if (string.IsNullOrEmpty(targetTextBox.Text)) return;

            // 水質検査依頼番号（開始）
            if (targetTextBox.Name == suishitsuKensaIraiNoFromTextBox.Name)
            {
                suishitsuKensaIraiNoFromTextBox.Text = suishitsuKensaIraiNoFromTextBox.Text.PadLeft(suishitsuKensaIraiNoFromTextBox.MaxLength, '0');
                return;
            }

            // 水質検査依頼番号（終了）
            if (targetTextBox.Name == suishitsuKensaIraiNoToTextBox.Name)
            {
                suishitsuKensaIraiNoToTextBox.Text = suishitsuKensaIraiNoToTextBox.Text.PadLeft(suishitsuKensaIraiNoToTextBox.MaxLength, '0');
                return;
            }
        }
        #endregion

        #region ClearSearchPanel
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ClearSearchPanel
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// 2015/01/22  小松　　　　クリアボタン押下時は初期値を設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearSearchPanel()
        {
            // 水質検査デフォルト
            suishitsuKensaRadioButton.Checked = true;

            if (suishitsuKensaRadioButton.Checked)
            {
                //iraiNendoTextBox.Text = string.Empty;
                _currentDateTime = Common.Common.GetCurrentTimestamp();
                iraiNendoTextBox.Text = (Utility.DateUtility.GetNendo(_currentDateTime)).ToString();
                //shishoComboBox.SelectedIndex = 0;
                shishoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
                kensaKomokuComboBox.SelectedIndex = 0;
                suishitsuKensaIraiNoFromTextBox.Text = string.Empty;
                suishitsuKensaIraiNoToTextBox.Text = string.Empty;

                hoteiKensaListDataGridView.Visible = true;
                _hoteiKensaListDataTable.Clear();
                keiryoKensaListDataGridView.Visible = false;
                _keiryoKensaListDataTable.Clear();
                // 検索結果件数
                listCountLabel.Text = "0件";
            }
        }
        #endregion

        #region CheckForChangeRadioBtn
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckForChangeRadioBtn
        /// <summary>
        /// 
        /// </summary>
        /// <returns>true:はい(入力破棄)/false:いいえ(取消)</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckForChangeRadioBtn()
        {
            bool retVal = true;

            if (hoteiKensaListDataGridView.Visible)
            {
                if (hoteiKensaListDataGridView.Rows.Count > 0)
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力中のデータが存在します。入力が破棄されますがよろしいですか？") == System.Windows.Forms.DialogResult.No)
                    {
                        retVal = false;
                    }
                }
            }
            else if (keiryoKensaListDataGridView.Visible)
            {
                if (keiryoKensaListDataGridView.Rows.Count > 0)
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力中のデータが存在します。入力が破棄されますがよろしいですか？") == System.Windows.Forms.DialogResult.No)
                    {
                        retVal = false;
                    }
                }
            }

            return retVal;
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　HieuNH　　　新規作成
        /// 2014/12/10　HieuNH　　　Replace merge datatable
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            if (_gridViewChanged)
            {
                if (MessageForm.Show2(MessageForm.DispModeType.Question, "入力中のデータが存在します。入力が破棄されますがよろしいですか？") == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }

            _hoteiKensaListDataTable.Clear();
            _keiryoKensaListDataTable.Clear();

            if (RelationCheck())
            {
                IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
                if (gaikanKensaRadioButton.Checked)
                    alInput.KensaKbn = "3";
                else if (suishitsuKensaRadioButton.Checked)
                    alInput.KensaKbn = "2";
                else if (keiryoShomeiKensaRadioButton.Checked)
                    alInput.KensaKbn = "1";
                alInput.IraiNendo = iraiNendoTextBox.Text;
                alInput.ShishoCd = shishoComboBox.SelectedValue.ToString();
                alInput.ShikenkoumokuCd = kensaKomokuComboBox.SelectedValue.ToString();
                alInput.SuishitsuKensaIraiNoFrom = suishitsuKensaIraiNoFromTextBox.Text;
                alInput.SuishitsuKensaIraiNoTo = suishitsuKensaIraiNoToTextBox.Text;
                IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

                if (gaikanKensaRadioButton.Checked || suishitsuKensaRadioButton.Checked)
                {
                    // 20150131 sou Start
                    // 温度列の表示設定
                    hoteiKensaListDataGridView.Columns[hoteiOndoCol.Index].Visible = (alInput.ShikenkoumokuCd == kmkCdPh ? true : false);
                    // 検査番号の表示設定
                    hoteiKensaListDataGridView.Columns[hoteiKensaNoCol.Index].Visible = gaikanKensaRadioButton.Checked;
                    // 20150131 sou End

                    //// MODIFY HieuNH 2014/12/10 BEGIN
                    //_hoteiKensaListDataTable.Merge(alOutput.KensaKekkaInputSearch1DataTable);
                    _hoteiKensaListDataTable = alOutput.KensaKekkaInputSearch1DataTable;
                    //// MODIFY HieuNH 2014/12/10 END
                    listCountLabel.Text = string.Concat(_hoteiKensaListDataTable.Count.ToString(), "件");
                    hoteiKensaListDataGridView.AutoGenerateColumns = false;
                    hoteiKensaListDataGridView.DataSource = _hoteiKensaListDataTable;
                    if (_hoteiKensaListDataTable.Count == 0)
                    {
                        //MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新データがありません。");
                        MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                    }
                }
                else
                {
                    // 水質検査項目コードを取得
                    // pH
                    // 20150122 sou Start
                    //string kensaKomokuCd001 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                    //if (alInput.ShikenkoumokuCd == kensaKomokuCd001)
                    if (alInput.ShikenkoumokuCd == kmkCdPh)
                    // 20150122 sou End
                    {
                        // 温度列を表示
                        keiryoKensaListDataGridView.Columns[keiryoOndoCol.Index].Visible = true;
                    }
                    else
                    {
                        // 温度列を非表示
                        keiryoKensaListDataGridView.Columns[keiryoOndoCol.Index].Visible = false;
                    }

                    // 20150122 sou Start
                    if ((alInput.ShikenkoumokuCd == kmkCdGaikan) || (alInput.ShikenkoumokuCd == kmkCdShuki)
                        || (alInput.ShikenkoumokuCd == kmkCdNo2n) || (alInput.ShikenkoumokuCd == kmkCdNo3n))
                    {
                        // 測定値列を非表示
                        keiryoKensaListDataGridView.Columns[keiryoSokuteiValueCol.Index].Visible = false;
                    }
                    else
                    {
                        // 測定値列を表示
                        keiryoKensaListDataGridView.Columns[keiryoSokuteiValueCol.Index].Visible = true;
                    }
                    // 20150122 sou End

                    //// MODIFY HieuNH 2014/12/10 BEGIN
                    //_keiryoKensaListDataTable.Merge(alOutput.KensaKekkaInputSearch2DataTable);
                    _keiryoKensaListDataTable = alOutput.KensaKekkaInputSearch2DataTable;
                    //// MODIFY HieuNH 2014/12/10 END
                    listCountLabel.Text = string.Concat(_keiryoKensaListDataTable.Count.ToString(), "件");
                    keiryoKensaListDataGridView.AutoGenerateColumns = false;
                    keiryoKensaListDataGridView.DataSource = _keiryoKensaListDataTable;
                    if (_keiryoKensaListDataTable.Count == 0)
                    {
                        //MessageForm.Show2(MessageForm.DispModeType.Infomation, "更新データがありません。");
                        MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
                    }
                }
                _gridViewChanged = false;
            }

        }
        #endregion

        #region RelationCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RelationCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HieuNH　　　新規作成
        /// 2015/01/29  宗          支所の入力確認を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool RelationCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            if (string.IsNullOrEmpty(shishoComboBox.Text))
                errMsg.AppendLine("支所が入力されていません。");
            if (string.IsNullOrEmpty(iraiNendoTextBox.Text))
                errMsg.AppendLine("年度が入力されていません。");
            if (shishoComboBox.SelectedIndex == 0)
                errMsg.AppendLine("支所が選択されていません。");
            if (kensaKomokuComboBox.SelectedIndex == 0)
                errMsg.AppendLine("検査項目が選択されていません。");
            if (!string.IsNullOrEmpty(suishitsuKensaIraiNoFromTextBox.Text) && !string.IsNullOrEmpty(suishitsuKensaIraiNoToTextBox.Text) && suishitsuKensaIraiNoFromTextBox.Text.CompareTo(suishitsuKensaIraiNoToTextBox.Text) > 0 )
            {
                errMsg.AppendLine("範囲指定が正しくありません。水質検査依頼番号の大小関係を確認してください。");
            } 

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region GridviewCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GridviewCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool GridviewCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            bool isValid = false;

            if (hoteiKensaListDataGridView.Visible)
            {
                foreach (DataGridViewRow row in hoteiKensaListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value != null && chk.TrueValue.ToString().Equals(chk.Value.ToString()))
                    {
                        isValid = true;
                        break;
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in keiryoKensaListDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chk.Value != null && chk.TrueValue.ToString().Equals(chk.Value.ToString()))
                    {
                        isValid = true;
                        break;
                    }
                }
            }

            if (!isValid)
                errMsg.AppendLine("対象データを選択して下さい。");

            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region InputCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InputCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool InputCheck()
        {
            StringBuilder errMsg = new StringBuilder();

			//受入20141218 mod sta　法定検査のグリッドも、未入力チェックが必要。
			//if (keiryoKensaListDataGridView.Visible)
			if( hoteiKensaListDataGridView.Visible )
			{
				foreach (DataGridViewRow row in hoteiKensaListDataGridView.Rows)
				{
					// 法定検査
					if ((row.Cells[hoteiSokuteiValueCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[hoteiSokuteiValueCol.Index].Value.ToString())) &&
						(row.Cells[hoteiOndoCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[hoteiOndoCol.Index].Value.ToString())))
					{
						errMsg.AppendLine("検査結果が入力されていません。");
					}
				}
			}
			else
			//受入20141218 mod end
			{
				foreach (DataGridViewRow row in keiryoKensaListDataGridView.Rows)
				{
					// 計量検査
					if ((row.Cells[keiryoSokuteiValueCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[keiryoSokuteiValueCol.Index].Value.ToString())) && 
						(row.Cells[keiryoKekkaComboBoxCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[keiryoKekkaComboBoxCol.Index].Value.ToString())))
					{
						errMsg.AppendLine("検査結果が入力されていません。");
					}
				}
			}

			if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

		//受入20141218 add sta
		#region ValidateCheck
		////////////////////////////////////////////////////////////////////////////
		//  メソッド名 ： ValidateCheck
		/// <summary>
		/// 
		/// </summary>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/12/18　Toguchi　　 新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		private bool ValidateCheck()
		{
			StringBuilder errMsg = new StringBuilder();

			bool isValid = true;
			double wkNum = 0.0;

			if (hoteiKensaListDataGridView.Visible)
			{
				foreach (DataGridViewRow row in hoteiKensaListDataGridView.Rows)
				{
					// 更新チェックボックスがＯＮの行の場合
					DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
					if (chk.Value != null && chk.TrueValue.ToString().Equals(chk.Value.ToString()))
					{
						// 測定値
						if (row.Cells[hoteiSokuteiValueCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[hoteiSokuteiValueCol.Index].Value.ToString()))
						{
							if (double.TryParse(row.Cells[hoteiSokuteiValueCol.Index].Value.ToString(), out wkNum))
							{
								// 測定値は検査項目によって上限と下限が異なるため、ここではＤＢ定義に則したチェックのみ行う。
								if (wkNum < -999999.99 || 999999.99 < wkNum)
								{
									errMsg.AppendLine("範囲外の数値が入力されています。");
									isValid = false;
									break;
								}
							}
							else
							{
								// 数値に変換できない場合
								errMsg.AppendLine("数値を入力してください。");
								isValid = false;
								break;
							}
						}

						// 温度
						if (row.Cells[hoteiOndoCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[hoteiOndoCol.Index].Value.ToString()))
						{
							if (double.TryParse(row.Cells[hoteiOndoCol.Index].Value.ToString(), out wkNum))
							{
								// 水温は０℃から１００℃未満までが対象となる。（固体や気体は対象外のはず）
								if (wkNum < 0 || 100 <= wkNum)
								{
									errMsg.AppendLine("範囲外の数値が入力されています。");
									isValid = false;
									break;
								}
							}
							else
							{
								// 数値に変換できない場合
								errMsg.AppendLine("数値を入力してください。");
								isValid = false;
								break;
							}
						}
					}
				}
			}
			else
			{
				foreach (DataGridViewRow row in keiryoKensaListDataGridView.Rows)
				{
					// 測定値
					if(row.Cells[keiryoSokuteiValueCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[keiryoSokuteiValueCol.Index].Value.ToString()))
					{
						if(double.TryParse(row.Cells[keiryoSokuteiValueCol.Index].Value.ToString(), out wkNum))
						{
							// 測定値は検査項目によって上限と下限が異なるため、ここではＤＢ定義に則したチェックのみ行う。
							if( wkNum < -999999.99 || 999999.99 < wkNum )
							{
								errMsg.AppendLine("範囲外の数値が入力されています。");
								isValid = false;
								break;
							}
						}
						else
						{
							// 数値に変換できない場合
							errMsg.AppendLine("数値を入力してください。");
							isValid = false;
							break;
						}
					}

                    // 温度
                    if (row.Cells[keiryoOndoCol.Index].Value == null || string.IsNullOrEmpty(row.Cells[keiryoOndoCol.Index].Value.ToString()))
                    {
                        if (double.TryParse(row.Cells[keiryoOndoCol.Index].Value.ToString(), out wkNum))
                        {
                            // 水温は０℃から１００℃未満までが対象となる。（固体や気体は対象外のはず）
                            if (wkNum < 0 || 100 <= wkNum)
                            {
                                errMsg.AppendLine("範囲外の数値が入力されています。");
                                isValid = false;
                                break;
                            }
                        }
                        else
                        {
                            // 数値に変換できない場合
                            errMsg.AppendLine("数値を入力してください。");
                            isValid = false;
                            break;
                        }
                    }
                }
			}

			if (!string.IsNullOrEmpty(errMsg.ToString()))
			{
				MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
			}

			return isValid;
		}
		#endregion
		//受入20141218 add end


        #endregion
    }
    #endregion
}
