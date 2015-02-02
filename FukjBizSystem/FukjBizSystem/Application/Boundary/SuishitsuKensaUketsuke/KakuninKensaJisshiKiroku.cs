using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.JokasoDaichoKanri;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuninKensaJisshiKirokuForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01  DatNT　　    新規作成
    /// 2015/01/11  宗           外観＆臭気の選択リスト取得
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KakuninKensaJisshiKirokuForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// 検索条件の表示・非表示フラグ(初期値：表示）
        /// </summary>
        private bool _searchShowFlg = true;
        private int _defaultSearchPanelTop = 0;
        private int _defaultSearchPanelHeight = 0;
        private int _defaultListPanelTop = 0;
        private int _defaultListPanelHeight = 0;

        // 下線付きフォント
        private Font underLineFont;

        /// <summary>
        /// Today
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// LoginUser
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// pcUpdate
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// ログインユーザーの所属支所コード
        /// </summary>
        private string LoginUserShozokuShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

        /// <summary>
        /// 画面モード
        /// </summary>
        enum DispMode
        {
            Shoki,
            Kakunin,
            Hensyu
        };

        // 検索条件
        private KeiryoShomeiDaichoSearchCond searchCond = new KeiryoShomeiDaichoSearchCond();

        #region ConstDT

        /// <summary>
        /// ConstMst Kbn = 052
        /// </summary>
        private DataTable const052DT = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_052);

        //20141217 HuyTX Ver1.03 Start
        /// <summary>
        /// ConstMst Kbn = 027
        /// </summary>
        private DataTable const027DT = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_027);
        //End

        /// <summary>
        /// ConstMst Kbn = 053
        /// </summary>
        private DataTable const053DT = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_053);

        /// <summary>
        /// ConstMst Kbn = 061
        /// </summary>
        private DataTable const061DT = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_061);

        // 20150111 sou Start
        /// <summary>
        /// 外観の選択リスト
        /// </summary>
        private DataTable gaikanList = new SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable();
        /// <summary>
        /// 臭気の選択リスト
        /// </summary>
        private DataTable shukiList = new SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable();
        // 20150111 sou End

        #endregion

        #region 試験項目コード

        /// <summary>
        /// 試験項目コード(亜硝酸性窒素(定性))
        /// </summary>
        private string NO2NTEISEI = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_030);

        /// <summary>
        /// 試験項目コード(硝酸性窒素(定性))
        /// </summary>
        private string NO3NTEISEI = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_031);

        // 20150111 sou Start
        /// <summary>
        /// 試験項目コード(外観)
        /// </summary>
        private string GAIKAN = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_027);

        /// <summary>
        /// 試験項目コード(臭気)
        /// </summary>
        private string SHUKI = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_028);
        // 20150111 sou End

        // 20150121 sou Start
        /// <summary>
        /// 試験項目コード(BODA)
        /// </summary>
        private string BODA = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_003);

        /// <summary>
        /// 試験項目コード(BODB)
        /// </summary>
        private string BODB = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_019);

        /// <summary>
        /// 試験項目コード(透視度)
        /// </summary>
        private string TR = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_029);

        /// <summary>
        /// 試験項目コード(塩化物イオン)
        /// </summary>
        private string CL = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_005);

        /// <summary>
        /// 試験項目コード(SS)
        /// </summary>
        private string SS = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002);

        /// <summary>
        /// 試験項目コード(アンモニア性窒素)
        /// </summary>
        private string NH4N = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_004);

        /// <summary>
        /// 試験項目コード(全窒素A)
        /// </summary>
        private string TNA = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_009);

        /// <summary>
        /// 試験項目コード(全窒素B)
        /// </summary>
        private string TNB = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_016);

        /// <summary>
        /// 試験項目コード(COD)
        /// </summary>
        private string COD = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_049, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_006);
        // 20150121 sou End

        #endregion

        #region 試験項目コードの取得

        /// <summary>
        /// pH（水素イオン濃度）
        /// </summary>
        private string pH = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

        /// <summary>
        /// Tr（透視度）
        /// </summary>
        private string tr = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002);

        /// <summary>
        /// BOD（生物化学的酸素要求量）
        /// </summary>
        private string bod = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_003);

        /// <summary>
        /// 残留塩素濃度
        /// </summary>
        private string zanryu = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_004);

        /// <summary>
        /// Cl（塩化物イオン）
        /// </summary>
        private string cl = Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_048, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_005);

        #endregion

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KakuninKensaJisshiKirokuForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KakuninKensaJisshiKirokuForm()
        {
            InitializeComponent();

            SetControlDomain();

            // フォームのフォントのベースに下線付きフォントを生成
            underLineFont = new Font(this.Font, this.Font.Style | FontStyle.Strikeout);

            //// 並び替え不可
            //foreach(DataGridViewColumn col in listDataGridView.Columns)
            //{
            //    col.SortMode = DataGridViewColumnSortMode.Programmatic;
            //}

            // スクロール固定
            //listDataGridView.Columns[hukukachoKeninCol.Index].Frozen = true;
            
            // ヘッダのVisualスタイルを無効化
            kakuninKensaDataGridView.EnableHeadersVisualStyles = false;

            SetHeaderBackColor();

            //this.Text = "11条検査 検査台帳";

            // 20141220 sou Start
            // テーブルの先頭に空白を追加
            const027DT = AddBlankRow(const027DT);
            const052DT = AddBlankRow(const052DT);
            const053DT = AddBlankRow(const053DT);
            const061DT = AddBlankRow(const061DT);
            // 20141220 sou End

            //20150111 sou Start
            // ※選択リストを絞る場合は引数の開始コードと終了コードを指定してください。指定しない場合(string.Empty)は支所別に全件取得します。
            gaikanList = AddBlankRowSuishitsuKekkaNmMst(GetSuishitsuKekkaNmMst(LoginUserShozokuShishoCd, string.Empty, string.Empty));
            shukiList = AddBlankRowSuishitsuKekkaNmMst(GetSuishitsuKekkaNmMst(LoginUserShozokuShishoCd, string.Empty, string.Empty));
            //20150111 sou End
        }
        #endregion

        #region イベント

        #region KakuninKensaJisshiKirokuForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KakuninKensaJisshiKirokuForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KakuninKensaJisshiKirokuForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValues();

                DoFormLoad();
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

        #region ViewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ViewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = !this._searchShowFlg;
                if (this._searchShowFlg) // 検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else // 検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }
                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.kakuninKensaPanel,
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
        /// 2014/11/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                SetDefaultValues();
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
        /// 2014/11/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!CheckCondition()) { return; }

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

        #region KakuninKensaJisshiKirokuForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KakuninKensaJisshiKirokuForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KakuninKensaJisshiKirokuForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F1:
                        daichoOutputButton.Focus();
                        daichoOutputButton.PerformClick();
                        break;

                    case Keys.F5:
                        kakuteiButton.Focus();
                        kakuteiButton.PerformClick();
                        break;

                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
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
                        tojiruButton.Focus();
                        tojiruButton.PerformClick();
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
        /// 2014/12/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
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

        #region kachoKeninCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kachoKeninCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kachoKeninCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow gridRow in kakuninKensaDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell cbCell = (DataGridViewCheckBoxCell)gridRow.Cells[kachoKeninCol.Name];

                    cbCell.Value = kachoKeninCheckBox.Checked ? "1" : "0";
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

        #region hukukachoKeninCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hukukachoKeninCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hukukachoKeninCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow gridRow in kakuninKensaDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell cbCell = (DataGridViewCheckBoxCell)gridRow.Cells[hukuKachoKeninCol.Name];

                    cbCell.Value = hukukachoKeninCheckBox.Checked ? "1" : "0";
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

        #region keiryoKanriKeninCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keiryoKanriKeninCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void keiryoKanriKeninCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                foreach (DataGridViewRow gridRow in kakuninKensaDataGridView.Rows)
                {
                    DataGridViewCheckBoxCell cbCell = (DataGridViewCheckBoxCell)gridRow.Cells[keiryokanrisyaKeninCol.Name];

                    cbCell.Value = keiryoKanriKeninCheckBox.Checked ? 1 : 0;
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

        #region kakuteiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuteiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// 2015/01/15  宗          画面モード変更を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kakuninKensaDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "対象データがありません。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集された内容を確定します。\r\nよろしいですか？") == DialogResult.No)
                {
                    return;
                }

                DoUpdate();

                // 20150111 sou Start
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "確定処理が完了しました。");
                // 20150111 sou End

                foreach (DataGridViewRow row in kakuninKensaDataGridView.Rows)
                {
                    row.Cells[koshinKbnCol.Name].Value = "0";
                    row.Cells[koshinKeninKbnCol.Name].Value = "0";
                }

                // 20141219 sou Start
                SetOriginalCol();
                // 20141219 sou End

                // 画面モード変更
                ModeChange(DispMode.Kakunin);
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

        #region outputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： outputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (kakuninKensaDataGridView.Rows.Count == 0) { return; }

                string outputFilename = "確認検査実施一覧";
                Common.Common.FlushGridviewDataToExcel(this.kakuninKensaDataGridView, outputFilename);
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
        
        #region kakuninKensaDataGridView_CellContentClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuninKensaDataGridView_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuninKensaDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex < 0) { return; }

                if (kakuninKensaDataGridView.CurrentCell.GetType() == typeof(DataGridViewButtonCell))
                {
                    string hokenjoCd = kakuninKensaDataGridView[jokasoHokenjoCdCol.Name, e.RowIndex].Value.ToString();

                    string nendo = kakuninKensaDataGridView[jokasoTorokuNendoCol.Name, e.RowIndex].Value.ToString();

                    string renban = kakuninKensaDataGridView[jokasoRenbanCol.Name, e.RowIndex].Value.ToString();

                    JokasoDaichoShosai frm = new JokasoDaichoShosai(hokenjoCd, nendo, renban, JokasoDaichoShosai.DispMode.View);
                    Program.mForm.MoveNext(frm);
                }
                // 20150115 sou Start
                // チェックボックスセルの場合は、直ちに編集を終了する(直ちにValueChangedイベントを発生させるため)
                else if (kakuninKensaDataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    this.Validate();
                }
                // 20150115 sou End
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

            //// チェックボックスセルの場合は、直ちに編集を終了する(直ちにValueChangedイベントを発生させるため)
            //if (kakuninKensaDataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
            //{
            //    kakuninKensaDataGridView.EndEdit();
            //}
        }
        #endregion

        #region kakuninKensaDataGridView_CellValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuninKensaDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// 
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuninKensaDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (e.RowIndex < 0) { return; }

                SetCellState();

                // 画面モード変更
                ModeChange(DispMode.Hensyu);
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

        #region kakuninKensaDataGridView_DataError
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuninKensaDataGridView_DataError
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuninKensaDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                e.ThrowException = false;
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

        #region daichoOutputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoOutputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoOutputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 20150112 sou Start 印刷時にダイアログを使用せず、画面の検索条件をそのまま使用する。
                //KeiryoShomeiDaichoSearchCond printCond = new KeiryoShomeiDaichoSearchCond();
                //
                ////年度
                //printCond.Nendo = nendoTextBox.Text.Trim();
                ////依頼受付日（開始）
                //printCond.IraiUketsukeFromDt = iraiUketsukeDtFromTextBox.Text.Trim();
                ////依頼受付日（終了）
                //printCond.IraiUketsukeToDt = iraiUketsukeDtToTextBox.Text.Trim();
                ////依頼No（開始）
                //printCond.IraiNoFrom = iraiNoFromTextBox.Text.Trim();
                ////依頼No（終了）
                //printCond.IraiNoTo = iraiNoToTextBox.Text.Trim();
                //
                //printCond.KensaKbn = suishitsuRadioButton.Checked
                //    ? Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU
                //    : gaikanRadioButton.Checked ? Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN
                //                                : Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN;
                //
                //JisshiKirokuOutputForm frm = new JisshiKirokuOutputForm(printCond);
                //frm.ShowDialog();

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "確認検査実施記録を出力します。\r\nよろしいですか？") == DialogResult.No)
                {
                    return;
                }

                // 20150115 sou Start 検索時の条件を使用する
                //KeiryoShomeiDaichoSearchCond searchCond = new KeiryoShomeiDaichoSearchCond();
                ////支所コード
                //searchCond.ShishoCd = LoginUserShozokuShishoCd;
                ////年度
                //searchCond.Nendo = nendoTextBox.Text.Trim();
                ////依頼受付日（開始）
                //searchCond.IraiUketsukeFromDt = iraiUketsukeDtFromTextBox.Text.Trim();
                ////依頼受付日（終了）
                //searchCond.IraiUketsukeToDt = iraiUketsukeDtToTextBox.Text.Trim();
                ////依頼No（開始）
                //searchCond.IraiNoFrom = string.IsNullOrEmpty(iraiNoFromTextBox.Text.Trim()) ? string.Empty : iraiNoFromTextBox.Text.Trim().PadLeft(6, '0');
                ////依頼No（終了）
                //searchCond.IraiNoTo = string.IsNullOrEmpty(iraiNoToTextBox.Text.Trim()) ? string.Empty : iraiNoToTextBox.Text.Trim().PadLeft(6, '0');
                ////検査区分
                //searchCond.KensaKbn = suishitsuRadioButton.Checked
                //    ? Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_SUISHITSU
                //    : gaikanRadioButton.Checked ? Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN
                //                                : Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN;
                // 20150115 sou End

                IOutputBtnClickALInput alInput = new OutputBtnClickALInput();
                alInput.SearchCond = searchCond;
                new OutputBtnClickApplicationLogic().Execute(alInput);

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "確認検査実施記録の出力が完了しました。");
                // 20150112 sou End
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

        #region kakuninKensaDataGridView_Sorted
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuninKensaDataGridView_Sorted
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuninKensaDataGridView_Sorted(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (suishitsuRadioButton.Checked || gaikanRadioButton.Checked)
                {
                    SetDSForDgvComboBoxCell1();
                }
                else
                {
                    SetDSForDgvComboBoxCell2();
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

        #region 依頼受付日の入力切替
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiUketsukeDtCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2015/01/30　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiUketsukeDtCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 依頼受付日の活性非活性切り替え
                if (iraiUketsukeDtCheckBox.Checked == true)
                {
                    iraiUketsukeDtFromDateTimePicker.Enabled = true;
                    iraiUketsukeDtToDateTimePicker.Enabled = true;
                }
                else
                {
                    iraiUketsukeDtFromDateTimePicker.Enabled = false;
                    iraiUketsukeDtToDateTimePicker.Enabled = false;
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

        #region 入力値の複写(依頼受付日)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiUketsukeDtFromDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2015/01/30　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiUketsukeDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            iraiUketsukeDtToDateTimePicker.Value = iraiUketsukeDtFromDateTimePicker.Value;
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
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　  新規作成
        /// 2015/01/15  宗          画面モード変更を追加
        /// 2015/01/19  宗          支所選択のコンボボックスを追加
        /// 2015/01/27  宗          取得する支所マスタを全件から事務局以外に変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            SetColDisplayIndex();

            InvisibleDgvCol();

            this._searchShowFlg = true;
            this._defaultSearchPanelTop = this.searchPanel.Top;
            this._defaultSearchPanelHeight = this.searchPanel.Height;
            this._defaultListPanelTop = this.kakuninKensaPanel.Top;
            this._defaultListPanelHeight = this.kakuninKensaPanel.Height;

            // 支所
            //IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());
            //Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstDataTable, "ShishoNm", "ShishoCd", true);
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());
            Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);

            // 検索条件初期化
            SetDefaultValues();

            // 画面モード変更
            ModeChange(DispMode.Shoki);
        }
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 年度
            nendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);

            #region to be removed
            //// 依頼受付日（開始）
            //iraiUketsukeDtFromTextBox.SetControlDomain(ZControlDomain.ZT_DT);

            //// 依頼受付日（終了）
            //iraiUketsukeDtToTextBox.SetStdControlDomain(ZControlDomain.ZT_DT);
            #endregion

            // 依頼No（開始）
            iraiNoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            // 依頼No（終了）
            iraiNoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            // 確認検査
            kakuninKensaDataGridView.SetStdControlDomain(pH2Col.Index, ZControlDomain.ZG_STD_NUM, 9, 3, InputValidateUtility.SignFlg.PositiveNegative);

            // 温度（確認検査）
            kakuninKensaDataGridView.SetStdControlDomain(ondo2Col.Index, ZControlDomain.ZG_STD_NUM, 5, 3, InputValidateUtility.SignFlg.PositiveNegative);
        }
        #endregion

        #region SetDefaultValues
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDefaultValues
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者   内容
        /// 2014/11/26  DatNT　  新規作成
        /// 2015/01/19  宗       支所選択のコンボボックスを追加
        /// 2015/01/27  宗       取得する支所マスタを全件から事務局以外に変更
        /// 2015/01/30  宗       依頼受付日をDateTimaePickerに変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDefaultValues()
        {
            DateTime systemDt = Common.Common.GetCurrentTimestamp();

            // 支所
            //shishoComboBox.SelectedValue = LoginUserShozokuShishoCd;
            if (LoginUserShozokuShishoCd == "0")
            {
                shishoComboBox.SelectedIndex = 0;
            }
            else
            {
                shishoComboBox.SelectedValue = LoginUserShozokuShishoCd;
            }

            // 年度
            nendoTextBox.Text = Utility.DateUtility.GetNendo(today).ToString();

            // 11条水質
            suishitsuRadioButton.Checked = true;

            // 依頼受付日（開始）
            //iraiUketsukeDtFromTextBox.Text = string.Empty;
            iraiUketsukeDtFromDateTimePicker.Value = systemDt;

            // 依頼受付日（終了）
            //iraiUketsukeDtToTextBox.Text = string.Empty;
            iraiUketsukeDtToDateTimePicker.Value = systemDt;

            // 依頼No（開始）
            iraiNoFromTextBox.Text = string.Empty;

            // 依頼No（終了）
            iraiNoToTextBox.Text = string.Empty;
        }
        #endregion

        #region CheckCondition
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckCondition
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckCondition()
        {
            StringBuilder errMess = new StringBuilder();

            if (shishoComboBox.SelectedIndex == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "支所が選択されていません。");
                return false;
            }

            // 依頼受付日（開始＆終了）
            //if (!string.IsNullOrEmpty(iraiUketsukeDtFromTextBox.Text) && !string.IsNullOrEmpty(iraiUketsukeDtToTextBox.Text)
            //    && Convert.ToInt32(iraiUketsukeDtFromTextBox.Text) > Convert.ToInt32(iraiUketsukeDtToTextBox.Text))
            if (iraiUketsukeDtCheckBox.Checked
                && Convert.ToInt32(iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd")) 
                > Convert.ToInt32(iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd")))
            {
                errMess.AppendLine("範囲指定が正しくありません。依頼受付日の大小関係を確認してください。");
            }

            // 11条水質依頼書No（開始＆終了）
            if (suishitsuRadioButton.Checked
                && !string.IsNullOrEmpty(iraiNoFromTextBox.Text) && !string.IsNullOrEmpty(iraiNoToTextBox.Text)
                && Convert.ToInt32(iraiNoFromTextBox.Text) > Convert.ToInt32(iraiNoToTextBox.Text))
            {
                errMess.AppendLine("範囲指定が正しくありません。11条水質の依頼書Noの大小関係を確認してください。");
            }

            // 外観検査依頼書No（開始＆終了）
            if(gaikanRadioButton.Checked
                && !string.IsNullOrEmpty(iraiNoFromTextBox.Text) && !string.IsNullOrEmpty(iraiNoToTextBox.Text)
                && Convert.ToInt32(iraiNoFromTextBox.Text) > Convert.ToInt32(iraiNoToTextBox.Text))
            {
                errMess.AppendLine("範囲指定が正しくありません。外観検査の依頼書Noの大小関係を確認してください。");
            }

            // 計量証明依頼書No（開始＆終了）
            if (keiryoShomeiRadioButton.Checked
                && !string.IsNullOrEmpty(iraiNoFromTextBox.Text) && !string.IsNullOrEmpty(iraiNoToTextBox.Text)
                && Convert.ToInt32(iraiNoFromTextBox.Text) > Convert.ToInt32(iraiNoToTextBox.Text))
            {
                errMess.AppendLine("範囲指定が正しくありません。計量証明の依頼書Noの大小関係を確認してください。");
            }

            if (!string.IsNullOrEmpty(errMess.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMess.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region MakeSearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/27  DatNT　  新規作成
        /// 2015/01/19  宗          支所コードの設定元を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 支所コード
            //alInput.ShishoCd = LoginUserShozokuShishoCd;
            alInput.ShishoCd = shishoComboBox.SelectedValue.ToString();


            // 20150116 sou Start
            //if (!string.IsNullOrEmpty(nendoTextBox.Text.Trim()))
            //{
            //    // 年度FROM
            //    alInput.NendoFrom = string.Concat(Convert.ToInt32(nendoTextBox.Text.Trim()), "0401");
            //
            //    // 年度TO
            //    alInput.NendoTo = string.Concat(Convert.ToInt32(nendoTextBox.Text.Trim()) + 1, "0331");
            //}
            // 年度
            alInput.Nendo = nendoTextBox.Text.Trim();
            // 20150116 sou End

            // 20150130 sou Start
            if (iraiUketsukeDtCheckBox.Checked == true)
            {
                // 依頼受付日(開始)
                //alInput.IraiUketsukeDtFrom = iraiUketsukeDtFromTextBox.Text.Trim();
                alInput.IraiUketsukeDtFrom = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                // 依頼受付日(終了)
                //alInput.IraiUketsukeDtTo = iraiUketsukeDtToTextBox.Text.Trim();
                alInput.IraiUketsukeDtTo = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
            }
            else
            {
                // 依頼受付日(開始)
                alInput.IraiUketsukeDtFrom = string.Empty;
                // 依頼受付日(終了)
                alInput.IraiUketsukeDtTo = string.Empty;
            }
            //20150130 sou End

            if (suishitsuRadioButton.Checked)
            {
                alInput.RadioChoosed = "2";
            }
            else if (gaikanRadioButton.Checked)
            {
                alInput.RadioChoosed = "3";
            }
            else
            {
                alInput.RadioChoosed = "1";
            }

            // 依頼No（開始）
            // 20141219 sou Ver1.04 Start
            //alInput.IraiNoFrom = iraiNoFromTextBox.Text.Trim();
            alInput.IraiNoFrom = string.IsNullOrEmpty(iraiNoFromTextBox.Text.Trim()) ? string.Empty : iraiNoFromTextBox.Text.Trim().PadLeft(6, '0');
            // 20141219 sou Ver1.04 End

            // 依頼No（終了）
            // 20141219 sou Ver1.04 Start
            //alInput.IraiNoTo = iraiNoToTextBox.Text.Trim();
            alInput.IraiNoTo = string.IsNullOrEmpty(iraiNoToTextBox.Text.Trim()) ? string.Empty : iraiNoToTextBox.Text.Trim().PadLeft(6, '0');
            // 20141219 sou Ver1.04 End

            // 20150115 sou Start
            // 検索条件退避
            searchCond.ShishoCd = alInput.ShishoCd;
            searchCond.Nendo = nendoTextBox.Text.Trim();
            searchCond.IraiUketsukeFromDt = alInput.IraiUketsukeDtFrom;
            searchCond.IraiUketsukeToDt = alInput.IraiUketsukeDtTo;
            searchCond.IraiNoFrom = alInput.IraiNoFrom;
            searchCond.IraiNoTo = alInput.IraiNoTo;
            searchCond.KensaKbn = alInput.RadioChoosed;
            //// 20150115 sou End

            //20150121 sou Start
            alInput.kmkCdBodA = BODA;
            alInput.kmkCdBodB = BODB;
            alInput.kmkCdTr = TR;
            alInput.kmkCdGaikan = GAIKAN;
            alInput.kmkCdShuki = SHUKI;
            alInput.kmkCdNo2n = NO2NTEISEI;
            alInput.kmkCdNo3n = NO3NTEISEI;
            alInput.kmkCdCl = CL;
            alInput.kmkCdSs = SS;
            alInput.kmkCdNh4n = NH4N;
            alInput.kmkCdTnA = TNA;
            alInput.kmkCdTnB = TNB;
            alInput.kmkCdCod = COD;

            searchCond.KmkCdBodA = alInput.kmkCdBodA;
            searchCond.KmkCdBodB = alInput.kmkCdBodB;
            searchCond.KmkCdTr = alInput.kmkCdTr;
            searchCond.KmkCdGaikan = alInput.kmkCdGaikan;
            searchCond.KmkCdShuki = alInput.kmkCdShuki;
            searchCond.KmkCdNo2nTeisei = alInput.kmkCdNo2n;
            searchCond.KmkCdNo3nTeisei = alInput.kmkCdNo3n;
            searchCond.KmkCdCl = alInput.kmkCdCl;
            searchCond.KmkCdSs = alInput.kmkCdSs;
            searchCond.KmkCdNh4n = alInput.kmkCdNh4n;
            searchCond.KmkCdTnA = alInput.kmkCdTnA;
            searchCond.KmkCdTnB = alInput.kmkCdTnB;
            searchCond.KmkCdCod = alInput.kmkCdCod;
            //20150121 sou End
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
        /// 2014/11/27  DatNT　  新規作成
        /// 2015/01/15  宗          一括検印のクリア、コントロールの状態設定、画面モードの変更を追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            MakeSearchCond(alInput);
            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // 一括検印クリア
            kachoKeninCheckBox.Checked = false;
            hukukachoKeninCheckBox.Checked = false;
            keiryoKanriKeninCheckBox.Checked = false;

            // コントロールの状態設定
            if (keiryoShomeiRadioButton.Checked == true)
            {
                // 計量証明
                keiryokanrisyaKeninCol.Visible = true;
                keiryoKanriKeninCheckBox.Enabled = true;
            }
            else
            {
                // 計量証明以外
                keiryokanrisyaKeninCol.Visible = false;
                keiryoKanriKeninCheckBox.Enabled = false;
            }

            if (alOutput.KakuninKensaJisshiKiroku1DT != null && alOutput.KakuninKensaJisshiKiroku1DT.Count > 0)
            {
                kakuninKensaDataGridView.DataSource = alOutput.KakuninKensaJisshiKiroku1DT;

                SetDSForDgvComboBoxCell1();

                kakuninKensaCountLabel.Text = alOutput.KakuninKensaJisshiKiroku1DT.Count.ToString() + "件";
            }
            else if (alOutput.KakuninKensaJisshiKiroku2DT != null && alOutput.KakuninKensaJisshiKiroku2DT.Count > 0)
            {
                kakuninKensaDataGridView.DataSource = alOutput.KakuninKensaJisshiKiroku2DT;

                kakuninKensaCountLabel.Text = alOutput.KakuninKensaJisshiKiroku2DT.Count.ToString() + "件";

                SetDSForDgvComboBoxCell2();
            }
            else
            {
                if (suishitsuRadioButton.Checked || gaikanRadioButton.Checked)
                {
                    kakuninKensaDataGridView.DataSource = new KensaDaicho11joHdrTblDataSet.KakuninKensaJisshiKiroku1DataTable();
                }
                else
                {
                    kakuninKensaDataGridView.DataSource = new KensaDaicho9joHdrTblDataSet.KakuninKensaJisshiKiroku2DataTable();
                }

                kakuninKensaCountLabel.Text = "0件";

                // 保健所一覧 : リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            
            SetOriginalCol();

            SetCellState();

            // 画面モード変更
            ModeChange(DispMode.Kakunin);
        }
        #endregion

        #region InvisibleDgvCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InvisibleDgvCol
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InvisibleDgvCol()
        {
            foreach (DataGridViewColumn col in kakuninKensaDataGridView.Columns)
            {
                if (col.Name == kensaKbnNmCol.Name
                    || col.Name == iraiNoCol.Name
                    || col.Name == kakoJohoCol.Name
                    || col.Name == komokuNmCol.Name
                    || col.Name == pH1Col.Name
                    || col.Name == ondo1Col.Name
                    || col.Name == ph1KekkaNmCol.Name
                    || col.Name == pH2Col.Name
                    || col.Name == ondo2Col.Name
                    || col.Name == ph2KekkaCdCol.Name
                    || col.Name == saiyotipH2Col.Name
                    || col.Name == kakuninKekkaSotiCol.Name
                    || col.Name == kachoKeninCol.Name
                    || col.Name == hukuKachoKeninCol.Name
                    || col.Name == keiryokanrisyaKeninCol.Name
                    || col.Name == yachoKakuninCol.Name)
                {
                    col.Visible = true;
                }
                else
                {
                    col.Visible = false;
                }
            }
        }
        #endregion

        #region SetDSForDgvComboBoxCell1
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDSForDgvComboBoxCell1
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDSForDgvComboBoxCell1()
        {
            foreach (DataGridViewRow row in kakuninKensaDataGridView.Rows)
            {
                DataGridViewComboBoxCell ph2KekkaCdCbCell = (DataGridViewComboBoxCell)row.Cells[ph2KekkaCdCol.Name];

                DataGridViewComboBoxCell sotiCbCell = (DataGridViewComboBoxCell)row.Cells[kakuninKekkaSotiCol.Name];

                // 結果コード（確認検査）
                //20141217 HuyTX Ver1.03 Start
                //ph2KekkaCdCbCell.DataSource = const052DT;
                ph2KekkaCdCbCell.DataSource = const027DT;
                //End
                ph2KekkaCdCbCell.DisplayMember = "ConstNm";
                ph2KekkaCdCbCell.ValueMember = "ConstValue";

                // 確認結果の措置
                sotiCbCell.DataSource = const061DT;
                sotiCbCell.DisplayMember = "ConstNm";
                sotiCbCell.ValueMember = "ConstValue";
            }
        }
        #endregion

        #region SetDSForDgvComboBoxCell2
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDSForDgvComboBoxCell2
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDSForDgvComboBoxCell2()
        {
            foreach (DataGridViewRow row in kakuninKensaDataGridView.Rows)
            {
                DataGridViewComboBoxCell ph2KekkaCdCbCell = (DataGridViewComboBoxCell)row.Cells[ph2KekkaCdCol.Name];

                DataGridViewComboBoxCell sotiCbCell = (DataGridViewComboBoxCell)row.Cells[kakuninKekkaSotiCol.Name];

                // 結果コード（確認検査）
                if (row.Cells[komokuCdCol.Name].Value.ToString() == NO2NTEISEI || row.Cells[komokuCdCol.Name].Value.ToString() == NO3NTEISEI)
                {
                    ph2KekkaCdCbCell.DataSource = const053DT;
                    ph2KekkaCdCbCell.DisplayMember = "ConstNm";
                    ph2KekkaCdCbCell.ValueMember = "ConstValue";
                }
                // 20150111 sou Start
                else if (row.Cells[komokuCdCol.Name].Value.ToString() == GAIKAN)
                {
                    ph2KekkaCdCbCell.DataSource = gaikanList;
                    ph2KekkaCdCbCell.DisplayMember = "SuishitsuKekkaNm";
                    ph2KekkaCdCbCell.ValueMember = "SuishitsuKekkaNmCd";
                }
                else if (row.Cells[komokuCdCol.Name].Value.ToString() == SHUKI)
                {
                    ph2KekkaCdCbCell.DataSource = shukiList;
                    ph2KekkaCdCbCell.DisplayMember = "SuishitsuKekkaNm";
                    ph2KekkaCdCbCell.ValueMember = "SuishitsuKekkaNmCd";
                }
                // 20150111 sou End
                else
                {
                    ph2KekkaCdCbCell.DataSource = const052DT;
                    ph2KekkaCdCbCell.DisplayMember = "ConstNm";
                    ph2KekkaCdCbCell.ValueMember = "ConstValue";
                }

                // 確認結果の措置
                sotiCbCell.DataSource = const061DT;
                sotiCbCell.DisplayMember = "ConstNm";
                sotiCbCell.ValueMember = "ConstValue";                
            }
        }
        #endregion

        #region SetCellState
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetCellState
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetCellState()
        {
            foreach (DataGridViewRow row in kakuninKensaDataGridView.Rows)
            {
                // 検印状態毎の状態設定
                if (row.Cells[kachoKeninCol.Name].Value.ToString() == "1"
                    || row.Cells[hukuKachoKeninCol.Name].Value.ToString() == "1"
                    || row.Cells[keiryokanrisyaKeninCol.Name].Value.ToString() == "1")
                {
                    // 確認検査
                    row.Cells[pH2Col.Name].ReadOnly = true;

                    // 温度（確認検査）
                    row.Cells[ondo2Col.Name].ReadOnly = true;

                    // 結果コード（確認検査）
                    row.Cells[ph2KekkaCdCol.Name].ReadOnly = true;

                    // 採用値
                    row.Cells[saiyotipH2Col.Name].ReadOnly = true;
                }
                else
                {
                    // 確認検査
                    row.Cells[pH2Col.Name].ReadOnly = false;

                    // 温度（確認検査）
                    row.Cells[ondo2Col.Name].ReadOnly = false;

                    // 結果コード（確認検査）
                    row.Cells[ph2KekkaCdCol.Name].ReadOnly = false;

                    // 採用値
                    row.Cells[saiyotipH2Col.Name].ReadOnly = false;
                }

                // 20150121 sou Start
                if ((row.Cells[komokuCdCol.Name].Value.ToString() == GAIKAN)
                    || (row.Cells[komokuCdCol.Name].Value.ToString() == SHUKI)
                    || (row.Cells[komokuCdCol.Name].Value.ToString() == NO2NTEISEI)
                    || (row.Cells[komokuCdCol.Name].Value.ToString() == NO3NTEISEI))
                {
                    // 確認検査
                    row.Cells[pH2Col.Name].ReadOnly = true;
                    // 温度（確認検査）
                    row.Cells[ondo2Col.Name].ReadOnly = true;

                    // 前回値
                    row.Cells[pH1Col.Name].Value = DBNull.Value;
                    // 温度
                    row.Cells[ondo1Col.Name].Value = DBNull.Value;
                    // 確認検査
                    row.Cells[pH2Col.Name].Value = DBNull.Value;
                    // 温度（確認検査）
                    row.Cells[ondo2Col.Name].Value = DBNull.Value;
                }
                else
                {
                    // 確認検査
                    row.Cells[pH2Col.Name].ReadOnly = false;
                    // 温度（確認検査）
                    row.Cells[ondo2Col.Name].ReadOnly = false;
                }
                // 20150121 sou End
            }
        }
        #endregion

        #region SetColDisplayIndex
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetColDisplayIndex
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetColDisplayIndex()
        {
            // 区分
            kakuninKensaDataGridView.Columns[kensaKbnNmCol.Name].DisplayIndex = 0;

            // 依頼No
            kakuninKensaDataGridView.Columns[iraiNoCol.Name].DisplayIndex = 1;

            // 過去情報ボタン
            kakuninKensaDataGridView.Columns[kakoJohoCol.Name].DisplayIndex = 2;

            // 項目名
            kakuninKensaDataGridView.Columns[komokuNmCol.Name].DisplayIndex = 3;

            // 前回値
            kakuninKensaDataGridView.Columns[pH1Col.Name].DisplayIndex = 4;

            // 温度（前回値）
            kakuninKensaDataGridView.Columns[ondo1Col.Name].DisplayIndex = 5;

            // 結果名称（前回値）
            kakuninKensaDataGridView.Columns[ph1KekkaNmCol.Name].DisplayIndex = 6;

            // 確認検査
            kakuninKensaDataGridView.Columns[pH2Col.Name].DisplayIndex = 7;

            // 温度（確認検査）
            kakuninKensaDataGridView.Columns[ondo2Col.Name].DisplayIndex = 8;

            // 結果コード（確認検査）
            kakuninKensaDataGridView.Columns[ph2KekkaCdCol.Name].DisplayIndex = 9;

            // 採用値
            kakuninKensaDataGridView.Columns[saiyotipH2Col.Name].DisplayIndex = 10;

            // 確認結果の措置
            kakuninKensaDataGridView.Columns[kakuninKekkaSotiCol.Name].DisplayIndex = 11;

            // 課長検印
            kakuninKensaDataGridView.Columns[kachoKeninCol.Name].DisplayIndex = 12;

            // 副課長検印
            kakuninKensaDataGridView.Columns[hukuKachoKeninCol.Name].DisplayIndex = 13;

            // 計量管理者検印
            kakuninKensaDataGridView.Columns[keiryokanrisyaKeninCol.Name].DisplayIndex = 14;

            // 野帳への記入確認
            kakuninKensaDataGridView.Columns[yachoKakuninCol.Name].DisplayIndex = 15;
        }
        #endregion

        #region SetHeaderBackColor
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeaderBackColor
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeaderBackColor()
        {
            kakuninKensaDataGridView.Columns[pH1Col.Name].HeaderCell.Style.BackColor = Color.Gold;
            kakuninKensaDataGridView.Columns[ondo1Col.Name].HeaderCell.Style.BackColor = Color.Gold;
            kakuninKensaDataGridView.Columns[ph1KekkaNmCol.Name].HeaderCell.Style.BackColor = Color.Gold;

            kakuninKensaDataGridView.Columns[pH2Col.Name].HeaderCell.Style.BackColor = Color.LawnGreen;
            kakuninKensaDataGridView.Columns[ondo2Col.Name].HeaderCell.Style.BackColor = Color.LawnGreen;
            kakuninKensaDataGridView.Columns[ph2KekkaCdCol.Name].HeaderCell.Style.BackColor = Color.LawnGreen;
        }
        #endregion

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate()
        {
            DateTime now = Common.Common.GetCurrentTimestamp();

            // KensaDaichoDtlTbl
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable dtlDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();

            // KensaKekkaTbl
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kekkaDT = new KensaKekkaTblDataSet.KensaKekkaTblDataTable();

            // SaiSaisuiTbl
            SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saisuiDT = new SaiSaisuiTblDataSet.SaiSaisuiTblDataTable();

            // KeiryoShomeiKekkaTbl
            KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable keiryoDT = new KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable();

            foreach (DataGridViewRow row in kakuninKensaDataGridView.Rows)
            {
                // Check change
                // ｛確認検査｝又は｛温度（確認検査）｝又は｛結果コード（確認検査）｝又は｛採用値｝が変更された場合
                if (!row.Cells[pH2Col.Name].Value.Equals(row.Cells[pH2OriginalCol.Name].Value)
                    || !row.Cells[ondo2Col.Name].Value.Equals(row.Cells[ondo2OriginalCol.Name].Value)
                    || !row.Cells[ph2KekkaCdCol.Name].Value.Equals(row.Cells[ph2KekkaCdOriginalCol.Name].Value)
                    || !row.Cells[saiyotipH2Col.Name].Value.Equals(row.Cells[saiyotipH2OriginalCol.Name].Value)
                    )
                {
                    row.Cells[koshinKbnCol.Name].Value = "1";
                }

                // ｛課長検印｝又は｛副課長検印｝又は｛計量管理者検印｝が変更された場合
                //20141217 HuyTX Ver1.03 Start
                //if (!row.Cells[kachoKeninCol.Name].Value.Equals(row.Cells[kachoKeninOriginalCol.Name].Value)
                //    || !row.Cells[hukuKachoKeninCol.Name].Value.Equals(row.Cells[hukuKachoKeninOriginalCol.Name].Value)
                //    || !row.Cells[keiryokanrisyaKeninCol.Name].Value.Equals(row.Cells[keiryokanrisyaKeninOriginalCol.Name].Value)
                //    )
                if (!row.Cells[kachoKeninCol.Name].Value.Equals(row.Cells[kachoKeninOriginalCol.Name].Value)
                    || !row.Cells[hukuKachoKeninCol.Name].Value.Equals(row.Cells[hukuKachoKeninOriginalCol.Name].Value)
                    || !row.Cells[keiryokanrisyaKeninCol.Name].Value.Equals(row.Cells[keiryokanrisyaKeninOriginalCol.Name].Value)
                    || !row.Cells[yachoKakuninCol.Name].Value.Equals(row.Cells[yachoKakuninColOriginalCol.Name].Value)
                    )
                //20141217 HuyTX Ver1.03 End
                {
                    row.Cells[koshinKeninKbnCol.Name].Value = "1";
                }

                // 「検査台帳明細テーブル」の更新
                if (row.Cells[koshinKbnCol.Name].Value.ToString() == "1" || row.Cells[koshinKeninKbnCol.Name].Value.ToString() == "1")
                {
                    // Update (1)
                    CreateDtlRow1(dtlDT, row, now);
                }
                else
                {
                    continue;
                }

                if (row.Cells[koshinKbnCol.Name].Value.ToString() == "1")
                {
                    // Update (2)
                    CreateDtlRow2(dtlDT, row, now);
                }

                // 「検査結果テーブル」又は「再採水テーブル」の更新
                if (row.Cells[koshinKbnCol.Name].Value.ToString() == "1")
                {
                    // （｛検査区分｝ = "2" 又は ｛検査区分｝ = "3"） の場合
                    if (row.Cells[kensaKbnCol.Name].Value.ToString() == "2" || row.Cells[kensaKbnCol.Name].Value.ToString() == "3")
                    {
                        // ｛再採水区分｝ = "0" の場合
                        if (row.Cells[saisaisuiKbnCol.Name].Value.ToString() == "0")
                        {
                            // Update (3)
                            CreateKensaKekkaTblRow3(kekkaDT, row, now);
                        }
                        // ｛再採水区分｝ = "1" の場合
                        else if (row.Cells[saisaisuiKbnCol.Name].Value.ToString() == "1")
                        {
                            // Update (4)
                            CreateSaiSaisuiTblRow4(saisuiDT, row, now);
                        }
                    }
                }

                // 「計量証明結果テーブル」の更新
                if (row.Cells[koshinKbnCol.Name].Value.ToString() == "1")
                {
                    if (row.Cells[kensaKbnCol.Name].Value.ToString() == "1")
                    {
                        // Update (5)
                        CreateKeiryoShomeiKekkaTblRow5(keiryoDT, row, now);
                    }
                }
            }

            IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
            alInput.KensaDaichoDtlTblDT = dtlDT;
            alInput.KensaKekkaTblDataTable = kekkaDT;
            alInput.SaiSaisuiTblDataTable = saisuiDT;
            alInput.KeiryoShomeiKekkaTblDT = keiryoDT;
            IKakuteiBtnClickALOutput alOutput = new KakuteiBtnClickApplicationLogic().Execute(alInput);
        }
        #endregion

        #region CreateDtlRow1
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDtlRow1
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtlDT"></param>
        /// <param name="dgvRow"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateDtlRow1(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable dtlDT,
            DataGridViewRow dgvRow,
            DateTime now)
        {
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = dtlDT.NewKensaDaichoDtlTblRow();

            // 検査区分
            dtlRow.KensaKbn = dgvRow.Cells[kensaKbnCol.Name].Value.ToString();

            // 依頼年度
            dtlRow.IraiNendo = dgvRow.Cells[iraiNendoCol.Name].Value.ToString();

            // 支所コード
            dtlRow.ShishoCd = dgvRow.Cells[shishoCdCol.Name].Value.ToString();

            // 水質検査依頼番号
            dtlRow.SuishitsuKensaIraiNo = dgvRow.Cells[iraiNoCol.Name].Value.ToString();

            // 試験項目コード
            dtlRow.ShikenkoumokuCd = dgvRow.Cells[komokuCdCol.Name].Value.ToString();

            // 再検査回数
            dtlRow.SaikensaKbn = "0";

            DataGridViewComboBoxCell sotiCb = (DataGridViewComboBoxCell)dgvRow.Cells[kakuninKekkaSotiCol.Name];

            // 確認検査の措置
            dtlRow.KakuninKensaSoti = sotiCb.Value.ToString();

            // 課長検印区分
            dtlRow.KachoKeninKbn = dgvRow.Cells[kachoKeninCol.Name].Value.ToString();

            // 副課長検印区分
            dtlRow.HukuKachoKeninKbn = dgvRow.Cells[hukuKachoKeninCol.Name].Value.ToString();

            // 計量管理者検印区分
            dtlRow.KeiryoKanrishaKeninKbn = dgvRow.Cells[keiryokanrisyaKeninCol.Name].Value.ToString();

            // 野帳記入確認区分
            dtlRow.YachoKinyuKakuninKbn = dgvRow.Cells[yachoKakuninCol.Name].Value.ToString();

            // 採用区分
            dtlRow.KeiryoShomeiSaiyoKbn = dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1" ? "0" : "1";

            dtlRow.UpdateDt = now;
            dtlRow.UpdateTarm = pcUpdate;
            dtlRow.UpdateUser = loginUser;
            dtlRow.InsertDt = now;
            dtlRow.InsertTarm = pcUpdate;
            dtlRow.InsertUser = loginUser;

            dtlDT.AddKensaDaichoDtlTblRow(dtlRow);
            dtlRow.AcceptChanges();
            dtlRow.SetAdded();
        }
        #endregion

        #region CreateDtlRow2
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDtlRow2
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtlDT"></param>
        /// <param name="dgvRow"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateDtlRow2(
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable dtlDT,
            DataGridViewRow dgvRow,
            DateTime now)
        {
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow = dtlDT.NewKensaDaichoDtlTblRow();

            // 検査区分
            dtlRow.KensaKbn = dgvRow.Cells[kensaKbnCol.Name].Value.ToString();

            // 依頼年度
            dtlRow.IraiNendo = dgvRow.Cells[iraiNendoCol.Name].Value.ToString();

            // 支所コード
            dtlRow.ShishoCd = dgvRow.Cells[shishoCdCol.Name].Value.ToString();

            // 水質検査依頼番号
            dtlRow.SuishitsuKensaIraiNo = dgvRow.Cells[iraiNoCol.Name].Value.ToString();

            // 試験項目コード
            dtlRow.ShikenkoumokuCd = dgvRow.Cells[komokuCdCol.Name].Value.ToString();

            // 再検査回数
            dtlRow.SaikensaKbn = "1";

            DataGridViewComboBoxCell sotiCb = (DataGridViewComboBoxCell)dgvRow.Cells[kakuninKekkaSotiCol.Name];

            // 確認検査の措置
            dtlRow.KakuninKensaSoti = sotiCb.Value.ToString();

            // 課長検印区分
            dtlRow.KachoKeninKbn = dgvRow.Cells[kachoKeninCol.Name].Value.ToString();

            // 副課長検印区分
            dtlRow.HukuKachoKeninKbn = dgvRow.Cells[hukuKachoKeninCol.Name].Value.ToString();

            // 計量管理者検印区分
            dtlRow.KeiryoKanrishaKeninKbn = dgvRow.Cells[keiryokanrisyaKeninCol.Name].Value.ToString();

            // 野帳記入確認区分
            dtlRow.YachoKinyuKakuninKbn = dgvRow.Cells[yachoKakuninCol.Name].Value.ToString();

            // 採用区分
            dtlRow.KeiryoShomeiSaiyoKbn = dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1" ? "1" : "0";

            //結果値
            dtlRow.KeiryoShomeiKekkaValue = dgvRow.Cells[pH2Col.Name].Value != null && !string.IsNullOrEmpty(Convert.ToString(dgvRow.Cells[pH2Col.Name].Value))
                                                                                ? Decimal.Parse(Convert.ToString(dgvRow.Cells[pH2Col.Name].Value)) : 0;

            // 20141219 sou Start
            ////結果値２
            //dtlRow.KeiryoShomeiKekkaValue2 = Convert.ToString(dgvRow.Cells[ph2KekkaCdCol.Name].Value);
            if (dtlRow.KensaKbn == "1")
            {
                //結果値２
                dtlRow.KeiryoShomeiKekkaValue2 = string.Empty;
                //結果コード
                dtlRow.KeiryoShomeiKekkaCd = Convert.ToString(dgvRow.Cells[ph2KekkaCdCol.Name].Value);
            }
            else
            {
                //結果値２
                dtlRow.KeiryoShomeiKekkaValue2 = Convert.ToString(dgvRow.Cells[ph2KekkaCdCol.Name].Value);
                //結果コード
                dtlRow.KeiryoShomeiKekkaCd = string.Empty;
            }
            // 20141219 sou End

            //温度数
            dtlRow.KeiryoShomeiKekkaOndo = dgvRow.Cells[ondo2Col.Name].Value != null && !string.IsNullOrEmpty(Convert.ToString(dgvRow.Cells[ondo2Col.Name].Value)) 
                                                                                ? Decimal.Parse(Convert.ToString(dgvRow.Cells[ondo2Col.Name].Value)) : 0;

            // 採用区分
            dtlRow.KeiryoShomeiSaiyoKbn = dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1" ? "1" : "0";

            dtlRow.UpdateDt = now;
            dtlRow.UpdateTarm = pcUpdate;
            dtlRow.UpdateUser = loginUser;
            dtlRow.InsertDt = now;
            dtlRow.InsertTarm = pcUpdate;
            dtlRow.InsertUser = loginUser;


            dtlDT.AddKensaDaichoDtlTblRow(dtlRow);
            dtlRow.AcceptChanges();
            dtlRow.SetAdded();
        }
        #endregion

        #region CreateKensaKekkaTblRow3
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaKekkaTblRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kekkaDT"></param>
        /// <param name="dgvRow"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateKensaKekkaTblRow3(
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kekkaDT,
            DataGridViewRow dgvRow,
            DateTime now)
        {
            KensaKekkaTblDataSet.KensaKekkaTblRow kekkaRow = kekkaDT.NewKensaKekkaTblRow();

            // 20141220 sou Start
            // 重複確認
            bool overlap = false;
            foreach (KensaKekkaTblDataSet.KensaKekkaTblRow row in kekkaDT.Rows)
            {
                if ((row.KensaKekkaIraiHoteiKbn == dgvRow.Cells[kensaIraiHoteiKbnCol.Name].Value.ToString())
                    && (row.KensaKekkaIraiHokenjoCd == dgvRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString())
                    && (row.KensaKekkaIraiNendo == dgvRow.Cells[kensaIraiNendoCol.Name].Value.ToString())
                    && (row.KensaKekkaIraiRenban == dgvRow.Cells[kensaIraiRenbanCol.Name].Value.ToString()))
                {
                    kekkaRow = row;
                    overlap = true;
                    break;
                }
            }
            // 20141220 sou End

            // 検査依頼法定区分
            kekkaRow.KensaKekkaIraiHoteiKbn = dgvRow.Cells[kensaIraiHoteiKbnCol.Name].Value.ToString();

            // 検査依頼保健所コード
            kekkaRow.KensaKekkaIraiHokenjoCd = dgvRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString();

            // 検査依頼年度
            kekkaRow.KensaKekkaIraiNendo = dgvRow.Cells[kensaIraiNendoCol.Name].Value.ToString();

            // 検査依頼連番
            kekkaRow.KensaKekkaIraiRenban = dgvRow.Cells[kensaIraiRenbanCol.Name].Value.ToString();

            // PH
            if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == pH)
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // pH
                    kekkaRow.KensaKekkaSuisoIonNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH2Col.Name].Value) : 0;

                    // 温度
                    // 20141220 sou Start
                    //kekkaRow.KensaKekkaOndo = !string.IsNullOrEmpty(dgvRow.Cells[ondo1Col.Name].Value.ToString()) ? Convert.ToDecimal(dgvRow.Cells[ondo1Col.Name].Value) : 0;
                    kekkaRow.KensaKekkaOndo = !string.IsNullOrEmpty(dgvRow.Cells[ondo2Col.Name].Value.ToString()) ? Convert.ToDecimal(dgvRow.Cells[ondo2Col.Name].Value) : 0;
                    // 20141220 sou End
                }
                else
                {
                    // pH
                    kekkaRow.KensaKekkaSuisoIonNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH1Col.Name].Value) : 0;

                    // 温度
                    // 20141220 sou Start
                    //kekkaRow.KensaKekkaOndo = !string.IsNullOrEmpty(dgvRow.Cells[ondo2Col.Name].Value.ToString()) ? Convert.ToDecimal(dgvRow.Cells[ondo2Col.Name].Value) : 0;
                    kekkaRow.KensaKekkaOndo = !string.IsNullOrEmpty(dgvRow.Cells[ondo1Col.Name].Value.ToString()) ? Convert.ToDecimal(dgvRow.Cells[ondo1Col.Name].Value) : 0;
                    // 20141220 sou End
                }
            }
            else if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == tr) // TR
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // 透視度
                    kekkaRow.KensaKekkaToshido = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH2Col.Name].Value) : 0;

                    // 透視度２
                    // 20141220 sou Start
                    //kekkaRow.KensaKekkaToshido2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    kekkaRow.KensaKekkaToshido2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
                else
                {
                    // 透視度
                    kekkaRow.KensaKekkaToshido = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH1Col.Name].Value) : 0;

                    // 透視度２
                    // 20141220 sou Start
                    //kekkaRow.KensaKekkaToshido2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    kekkaRow.KensaKekkaToshido2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
            }
            else if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == bod) // BOD
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // 生物化学酸素要求量
                    kekkaRow.KensaKekkaBOD = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH2Col.Name].Value) : 0;

                    // 生物化学酸素要求量２
                    // 20141220 sou Start
                    //kekkaRow.KensaIraiBOD2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    kekkaRow.KensaIraiBOD2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
                else
                {
                    // 生物化学酸素要求量
                    kekkaRow.KensaKekkaBOD = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH1Col.Name].Value) : 0;

                    // 生物化学酸素要求量２
                    // 20141220 sou Start
                    //kekkaRow.KensaIraiBOD2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    kekkaRow.KensaIraiBOD2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
            }
            else if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == zanryu) // 残留塩素濃度
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // 残留塩素濃度
                    kekkaRow.KensaKekkaZanryuEnsoNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH2Col.Name].Value) : 0;
                }
                else
                {
                    // 残留塩素濃度
                    kekkaRow.KensaKekkaZanryuEnsoNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH1Col.Name].Value) : 0;
                }
            }
            else if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == cl) // 塩化物イオン
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // 塩素イオン濃度
                    kekkaRow.KensaKekkaEnsoIonNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToInt32(dgvRow.Cells[pH2Col.Name].Value) : 0;

                    // 塩素イオン濃度２
                    // 20141220 sou Start
                    //kekkaRow.KensaIraiEnsoIonNodo2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    kekkaRow.KensaIraiEnsoIonNodo2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
                else
                {
                    // 塩素イオン濃度
                    kekkaRow.KensaKekkaEnsoIonNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToInt32(dgvRow.Cells[pH1Col.Name].Value) : 0;

                    // 塩素イオン濃度２
                    // 20141220 sou Start
                    //kekkaRow.KensaIraiEnsoIonNodo2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    kekkaRow.KensaIraiEnsoIonNodo2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
            }

            kekkaRow.UpdateDt = now;
            kekkaRow.UpdateTarm = pcUpdate;
            kekkaRow.UpdateUser = loginUser;
            kekkaRow.InsertDt = now;
            kekkaRow.InsertTarm = pcUpdate;
            kekkaRow.InsertUser = loginUser;

            // 20141220 sou Start
            if (!overlap)
            {
            // 20141220 sou End
                kekkaDT.AddKensaKekkaTblRow(kekkaRow);
                kekkaRow.AcceptChanges();
                kekkaRow.SetAdded();
            // 20141220 sou Start
            }
            // 20141220 sou End
        }
        #endregion

        #region CreateSaiSaisuiTblRow4
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSaiSaisuiTblRow4
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kekkaDT"></param>
        /// <param name="dgvRow"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateSaiSaisuiTblRow4(
            SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saisuiDT,
            DataGridViewRow dgvRow,
            DateTime now)
        {
            SaiSaisuiTblDataSet.SaiSaisuiTblRow saisuiRow = saisuiDT.NewSaiSaisuiTblRow();

            // 20141220 sou Start
            // 重複確認
            bool overlap = false;
            foreach (SaiSaisuiTblDataSet.SaiSaisuiTblRow row in saisuiDT.Rows)
            {
                if ((row.SaiSaisuiIraiHoteiKbn == dgvRow.Cells[kensaIraiHoteiKbnCol.Name].Value.ToString())
                    && (row.SaiSaisuiIraiHokenjoCd == dgvRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString())
                    && (row.SaiSaisuiIraiNendo == dgvRow.Cells[kensaIraiNendoCol.Name].Value.ToString())
                    && (row.SaiSaisuiIraiRrenban == dgvRow.Cells[kensaIraiRenbanCol.Name].Value.ToString()))
                {
                    saisuiRow = row;
                    overlap = true;
                    break;
                }
            }
            // 20141220 sou End

            // 検査依頼法定区分
            saisuiRow.SaiSaisuiIraiHoteiKbn = dgvRow.Cells[kensaIraiHoteiKbnCol.Name].Value.ToString();

            // 検査依頼保健所コード
            saisuiRow.SaiSaisuiIraiHokenjoCd = dgvRow.Cells[kensaIraiHokenjoCdCol.Name].Value.ToString();

            // 検査依頼年度
            saisuiRow.SaiSaisuiIraiNendo = dgvRow.Cells[kensaIraiNendoCol.Name].Value.ToString();

            // 検査依頼連番
            saisuiRow.SaiSaisuiIraiRrenban = dgvRow.Cells[kensaIraiRenbanCol.Name].Value.ToString();

            // PH
            if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == pH)
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // 水素イオン濃度
                    saisuiRow.SaiSaisuiSuisoIonNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH2Col.Name].Value) : 0;

                    // 温度
                    // 20141220 sou Start
                    //saisuiRow.SaiSaisuiOndo = !string.IsNullOrEmpty(dgvRow.Cells[ondo1Col.Name].Value.ToString()) ? Convert.ToDecimal(dgvRow.Cells[ondo1Col.Name].Value) : 0;
                    saisuiRow.SaiSaisuiOndo = !string.IsNullOrEmpty(dgvRow.Cells[ondo2Col.Name].Value.ToString()) ? Convert.ToDecimal(dgvRow.Cells[ondo2Col.Name].Value) : 0;
                    // 20141220 sou End
                }
                else
                {
                    // 水素イオン濃度
                    saisuiRow.SaiSaisuiSuisoIonNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH1Col.Name].Value) : 0;

                    // 温度
                    // 20141220 sou Start
                    //saisuiRow.SaiSaisuiOndo = !string.IsNullOrEmpty(dgvRow.Cells[ondo2Col.Name].Value.ToString()) ? Convert.ToDecimal(dgvRow.Cells[ondo2Col.Name].Value) : 0;
                    saisuiRow.SaiSaisuiOndo = !string.IsNullOrEmpty(dgvRow.Cells[ondo1Col.Name].Value.ToString()) ? Convert.ToDecimal(dgvRow.Cells[ondo1Col.Name].Value) : 0;
                    // 20141220 sou End
                }
            }
            else if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == tr) // TR
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // 透視度（度）
                    saisuiRow.SaiSaisuiToshido = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH2Col.Name].Value) : 0;

                    // 透視度２
                    // 20141220 sou Start
                    //saisuiRow.SaiSaisuiToshido2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    saisuiRow.SaiSaisuiToshido2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
                else
                {
                    // 試験項目コード
                    saisuiRow.SaiSaisuiToshido = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH1Col.Name].Value) : 0;

                    // 透視度２
                    // 20141220 sou Start
                    //saisuiRow.SaiSaisuiToshido2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    saisuiRow.SaiSaisuiToshido2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
            }
            else if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == bod) // BOD
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // 生物化学酸素要求量
                    saisuiRow.SaiSaisuiBOD = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH2Col.Name].Value) : 0;

                    // 生物化学酸素要求量２
                    // 20141220 sou Start
                    //saisuiRow.SaiSaisuiBOD2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    saisuiRow.SaiSaisuiBOD2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
                else
                {
                    // 生物化学酸素要求量
                    saisuiRow.SaiSaisuiBOD = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH1Col.Name].Value) : 0;

                    // 生物化学酸素要求量２
                    // 20141220 sou Start
                    //saisuiRow.SaiSaisuiBOD2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    saisuiRow.SaiSaisuiBOD2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
            }
            else if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == zanryu) // 残留塩素濃度
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // 残留塩素濃度
                    saisuiRow.SaiSaisuiZanryuEnsoNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH2Col.Name].Value) : 0;
                }
                else
                {
                    // 残留塩素濃度
                    saisuiRow.SaiSaisuiZanryuEnsoNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToDouble(dgvRow.Cells[pH1Col.Name].Value) : 0;
                }
            }
            else if (dgvRow.Cells[komokuCdCol.Name].Value.ToString() == cl) // 塩化物イオン
            {
                if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
                {
                    // 塩化イオン濃度
                    saisuiRow.SaiSaisuiEnkaIonNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString()) ? Convert.ToDecimal(dgvRow.Cells[pH2Col.Name].Value) : 0;

                    // 塩化イオン濃度２
                    // 20141220 sou Start
                    //saisuiRow.SaiSaisuiEnkaIonNodo2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    saisuiRow.SaiSaisuiEnkaIonNodo2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
                else
                {
                    // 塩化イオン濃度
                    saisuiRow.SaiSaisuiEnkaIonNodo = !string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) ? Convert.ToInt32(dgvRow.Cells[pH1Col.Name].Value) : 0;

                    // 塩化イオン濃度２
                    // 20141220 sou Start
                    //saisuiRow.SaiSaisuiEnkaIonNodo2 = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                    saisuiRow.SaiSaisuiEnkaIonNodo2 = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                    // 20141220 sou End
                }
            }

            saisuiRow.UpdateDt = now;
            saisuiRow.UpdateTarm = pcUpdate;
            saisuiRow.UpdateUser = loginUser;
            saisuiRow.InsertDt = now;
            saisuiRow.InsertTarm = pcUpdate;
            saisuiRow.InsertUser = loginUser;

            // 20141220 sou Start
            if (!overlap)
            {
            // 20141220 sou End
                saisuiDT.AddSaiSaisuiTblRow(saisuiRow);
                saisuiRow.AcceptChanges();
                saisuiRow.SetAdded();
            // 20141220 sou Start
            }
            // 20141220 sou End
        }
        #endregion

        #region CreateKeiryoShomeiKekkaTblRow5
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKeiryoShomeiKekkaTblRow5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kekkaDT"></param>
        /// <param name="dgvRow"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateKeiryoShomeiKekkaTblRow5(
            KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable keiryoDT,
            DataGridViewRow dgvRow,
            DateTime now)
        {
            KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblRow keiryoRow = keiryoDT.NewKeiryoShomeiKekkaTblRow();

            // 計量証明結果依頼年度
            keiryoRow.KeiryoShomeiKekkaIraiNendo = dgvRow.Cells[keiryoShomeiIraiNendoCol.Name].Value.ToString();

            // 計量証明結果依頼支所コード
            keiryoRow.KeiryoShomeiKekkaIraiShishoCd = dgvRow.Cells[keiryoShomeiIraiSishoCdCol   .Name].Value.ToString();

            // 計量証明結果依頼番号
            keiryoRow.KeiryoShomeiKekkaIraiNo = dgvRow.Cells[keiryoShomeiIraiRenbanCol.Name].Value.ToString();

            // 計量証明試験項目コード
            keiryoRow.KeiryoShomeiShikenkoumokuCd = dgvRow.Cells[komokuCdCol.Name].Value.ToString();

            if (dgvRow.Cells[saiyotipH2Col.Name].Value.ToString() == "1")
            {
                // 結果値  
                // 20150122 sou Start
                //keiryoRow.KeiryoShomeiKekkaValue = Convert.ToDecimal(dgvRow.Cells[pH2Col.Name].Value);
                keiryoRow.KeiryoShomeiKekkaValue = dgvRow.Cells[pH2Col.Name].Value == null
                                                   ? 0 : string.IsNullOrEmpty(dgvRow.Cells[pH2Col.Name].Value.ToString())
                                                   ? 0 : Convert.ToDecimal(dgvRow.Cells[pH2Col.Name].Value);
                // 20150122 sou Start

                // 結果コード
                //20141220 sou Start
                //keiryoRow.KeiryoShomeiKekkaCd = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                keiryoRow.KeiryoShomeiKekkaCd = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                //20141220 sou End

                // 結果値表示用
                //20141220 sou Start
                //keiryoRow.KeiryoShomeiKekkaValueHyojiyo = Utility.KensaHanteiUtility.HyojiKetasuHosei(dgvRow.Cells[komokuCdCol.Name].Value.ToString(),
                //                                                                                        dgvRow.Cells[pH1Col.Name].Value.ToString());
                keiryoRow.KeiryoShomeiKekkaValueHyojiyo = Utility.KensaHanteiUtility.HyojiKetasuHosei(dgvRow.Cells[komokuCdCol.Name].Value.ToString(),
                                                                                                        dgvRow.Cells[pH2Col.Name].Value.ToString());
                //20141220 sou End

                //20141220 sou Start
                // 温度数
                keiryoRow.KeiryoShomeiKekkaOndo = IsNumeric(dgvRow.Cells[ondo2Col.Name].Value.ToString()) 
                                                    ? double.Parse(dgvRow.Cells[ondo2Col.Name].Value.ToString()) : 0;
                //20141220 sou End
            }
            else
            {
                // 結果値
                // 20150122 sou Start
                //keiryoRow.KeiryoShomeiKekkaValue = Convert.ToDecimal(dgvRow.Cells[pH1Col.Name].Value);
                keiryoRow.KeiryoShomeiKekkaValue = dgvRow.Cells[pH1Col.Name].Value == null
                                                   ? 0 : string.IsNullOrEmpty(dgvRow.Cells[pH1Col.Name].Value.ToString()) 
                                                   ? 0 : Convert.ToDecimal(dgvRow.Cells[pH1Col.Name].Value);
                // 20150122 sou End

                // 結果コード
                //20141220 sou Start
                //keiryoRow.KeiryoShomeiKekkaCd = dgvRow.Cells[ph2KekkaCdCol.Name].Value.ToString();
                keiryoRow.KeiryoShomeiKekkaCd = dgvRow.Cells[ph1KekkaCdCol.Name].Value.ToString();
                //20141220 sou End

                // 結果値表示用
                //20141220 sou Start
                //keiryoRow.KeiryoShomeiKekkaValueHyojiyo = Utility.KensaHanteiUtility.HyojiKetasuHosei(dgvRow.Cells[komokuCdCol.Name].Value.ToString(),
                //                                                                                        dgvRow.Cells[pH2Col.Name].Value.ToString());
                keiryoRow.KeiryoShomeiKekkaValueHyojiyo = Utility.KensaHanteiUtility.HyojiKetasuHosei(dgvRow.Cells[komokuCdCol.Name].Value.ToString(),
                                                                                                        dgvRow.Cells[pH1Col.Name].Value.ToString());
                //20141220 sou End

                //20141220 sou Start
                // 温度数
                keiryoRow.KeiryoShomeiKekkaOndo = IsNumeric(dgvRow.Cells[ondo1Col.Name].Value.ToString())
                                                    ? double.Parse(dgvRow.Cells[ondo1Col.Name].Value.ToString()) : 0;
                //20141220 sou End
            }

            keiryoRow.UpdateDt = now;
            keiryoRow.UpdateTarm = pcUpdate;
            keiryoRow.UpdateUser = loginUser;
            keiryoRow.InsertDt = now;
            keiryoRow.InsertTarm = pcUpdate;
            keiryoRow.InsertUser = loginUser;

            keiryoDT.AddKeiryoShomeiKekkaTblRow(keiryoRow);
            keiryoRow.AcceptChanges();
            keiryoRow.SetAdded();
        }
        #endregion

        #region SetOriginalCol
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetOriginalCol
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetOriginalCol()
        {
            foreach (DataGridViewRow row in kakuninKensaDataGridView.Rows)
            {
                row.Cells[pH2OriginalCol.Name].Value = row.Cells[pH2Col.Name].Value;

                row.Cells[ondo2OriginalCol.Name].Value = row.Cells[ondo2Col.Name].Value;

                row.Cells[ph2KekkaCdOriginalCol.Name].Value = row.Cells[ph2KekkaCdCol.Name].Value;

                row.Cells[saiyotipH2OriginalCol.Name].Value = row.Cells[saiyotipH2Col.Name].Value;

                row.Cells[kachoKeninOriginalCol.Name].Value = row.Cells[kachoKeninCol.Name].Value;

                row.Cells[hukuKachoKeninOriginalCol.Name].Value = row.Cells[hukuKachoKeninCol.Name].Value;

                row.Cells[keiryokanrisyaKeninOriginalCol.Name].Value = row.Cells[keiryokanrisyaKeninCol.Name].Value;

                //20141217 HuyTX Ver1.03 Start
                row.Cells[yachoKakuninColOriginalCol.Name].Value = row.Cells[yachoKakuninCol.Name].Value;
                //20141217 HuyTX Ver1.03 End
            }
        }
        #endregion

        #region IsNumeric
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsNumeric
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/20  宗     　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsNumeric(string str)
        {
            double d;
            return (double.TryParse(str, out d) ? true : false);
        }
        #endregion

        #region AddBlankRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： AddBlankRow
        /// <summary>
        /// DataTableの先頭に空白行を追加して返す ※定数マスタの形式にのみ対応
        /// </summary>
        /// <param name="dt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/20  宗     　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private DataTable AddBlankRow(DataTable dt)
        {
            ConstMstDataSet.ConstMstDataTable cmdt = new ConstMstDataSet.ConstMstDataTable();

            ConstMstDataSet.ConstMstRow newRow = cmdt.NewConstMstRow();

            newRow.ConstKbn = string.Empty;
            newRow.ConstRenban = string.Empty;

            newRow.ConstNm = " ";
            newRow.ConstValue = "0";

            newRow.InsertDt = today;
            newRow.InsertUser = pcUpdate;
            newRow.InsertTarm = loginUser;
            newRow.UpdateDt = today;
            newRow.UpdateUser = pcUpdate;
            newRow.UpdateTarm = loginUser;

            cmdt.Rows.Add(newRow);

            foreach (ConstMstDataSet.ConstMstRow row in dt.Rows)
            {
                // コピー
                newRow = cmdt.NewConstMstRow();
                newRow.ItemArray = row.ItemArray;
                // 追加
                cmdt.Rows.Add(newRow);
            }

            return cmdt;
        }
        #endregion

        #region AddBlankRowSuishitsuKekkaNmMst
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： AddBlankRowSuishitsuKekkaNmMst
        /// <summary>
        /// DataTableの先頭に空白行を追加して返す ※水質結果名称マスタの形式にのみ対応
        /// </summary>
        /// <param name="dt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/11  宗     　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private DataTable AddBlankRowSuishitsuKekkaNmMst(SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable dt)
        {
            SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable sknmdt = new SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable();

            SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstRow newRow = sknmdt.NewSuishitsuKekkaNmMstRow();

            newRow.SuishitsuKekkaShishoCd = string.Empty;

            newRow.SuishitsuKekkaNm = " ";
            newRow.SuishitsuKekkaNmCd = "0";

            newRow.InsertDt = today;
            newRow.InsertUser = pcUpdate;
            newRow.InsertTarm = loginUser;
            newRow.UpdateDt = today;
            newRow.UpdateUser = pcUpdate;
            newRow.UpdateTarm = loginUser;

            sknmdt.Rows.Add(newRow);

            foreach (SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstRow row in dt.Rows)
            {
                // コピー
                newRow = sknmdt.NewSuishitsuKekkaNmMstRow();
                newRow.ItemArray = row.ItemArray;
                // 追加
                sknmdt.Rows.Add(newRow);
            }

            return sknmdt;
        }
        #endregion

        #region GetSuishitsuKekkaNmMst
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetSuishitsuKekkaNmMst
        /// <summary>
        /// 水質結果名称マスタを取得する
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="suishitsuKekkaNmCdFrom"></param>
        /// <param name="suishitsuKekkaNmCdTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/11  宗     　   新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable GetSuishitsuKekkaNmMst(string shishoCd, string suishitsuKekkaNmCdFrom, string suishitsuKekkaNmCdTo)
        {
            // コンボボックスの選択リスト取得
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.ShishoCd = shishoCd;
            alInput.SuishitsuKekkaNmCdFrom = suishitsuKekkaNmCdFrom;
            alInput.SuishitsuKekkaNmCdTo = suishitsuKekkaNmCdTo;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            return alOutput.SuishitsuKekkaNmMstDt;
        }
        #endregion

        #region 画面モード変更
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ModeChange
        /// <summary>
        /// 
        /// </summary>
        /// <input>
        /// DispMode mode 画面モード
        /// </input>
        /// <history>
        /// 日付        担当者    内容
        /// 2015/01/15　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ModeChange(DispMode mode)
        {
            // 画面モード別のコントロール制御
            switch (mode)
            {
                case DispMode.Shoki:
                    // 実施記録出力ボタン
                    daichoOutputButton.Enabled = false;
                    // 確定ボタン
                    kakuteiButton.Enabled = false;

                    break;
                case DispMode.Kakunin:
                    // 実施記録出力ボタン
                    daichoOutputButton.Enabled = true;
                    // 確定ボタン
                    kakuteiButton.Enabled = false;

                    break;
                case DispMode.Hensyu:
                    // 実施記録出力ボタン
                    daichoOutputButton.Enabled = false;
                    // 確定ボタン
                    kakuteiButton.Enabled = true;

                    break;
            }

            return;
        }
        #endregion

        #endregion
    }
    #endregion
}
