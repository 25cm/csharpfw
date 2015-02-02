using System;
using System.Data;
using System.Drawing;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.HoteiKensaDaicho;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.JokasoDaichoKanri;
using FukjBizSystem.Application.Boundary.SaisuiinKanri;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoteiKensaDaicho
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付        担当者    内容
    /// 2014/11/28　宗        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HoteiKensaDaicho : FukjBaseForm
    {
        #region プロパティ

        // 下線付きフォント
        private Font underLineFont;

        /// <summary>
        /// ログインユーザーの所属支所コード
        /// </summary>
        private string LoginUserShozokuShishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

        /// <summary>
        /// ログインユーザー名
        /// </summary>
        private string LoginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// クライアント端末名
        /// </summary>
        private string HostName = Dns.GetHostName();

        // 水質検査の試験項目コード
        private DataTable kmkCdDt = Common.Common.GetConstTable("048");

        // 外観検査の試験項目コード
        private DataTable kmkCdGaikanDt = Common.Common.GetConstTable("078");

        /// <summary>
        /// 定数連番(水質検査の試験項目)
        /// </summary>
        private const string ConstRenbanPh = "001";
        private const string ConstRenbanTr = "002";
        private const string ConstRenbanBod = "003";
        private const string ConstRenbanZanen = "004";
        private const string ConstRenbanCl = "005";

        /// <summary>
        /// 定数連番(外観検査の試験項目)
        /// </summary>
        private const string ConstGaikanRenbanBod = "001";
        private const string ConstGaikanRenbanCl = "002";
        private const string ConstGaikanRenbanAtubod = "003";

        private const string ConstRenbanOndo = "000";

        // 処理方式の名称
        private DataTable shoriHoshikiNmDt = Common.Common.GetConstTable("016");

        /// <summary>
        /// 法定区分名称
        /// </summary>
        private const string HouteiKbnNm1 = "7条検査";
        private const string HouteiKbnNm2 = "11条外観";
        private const string HouteiKbnNm3 = "11条水質";
        private const string HouteiKbnNm4 = "11条ス";
        private const string HouteiKbnNm5 = "11条フ";
        private const string HouteiKbnNm6 = "11条ス＋フ";

        /// <summary>
        /// チェック状態確認用
        /// </summary>
        private const string CheckOn = "True";
        private const string CheckOff = "False";

        /// <summary>
        /// 画面モード
        /// </summary>
        enum DispMode
        {
            Load,
            Kakunin,
            Hensyu
        };

        /// <summary>
        /// 内部変更フラグ
        /// </summary>
        private bool insideFlg = true;

        /// <summary>
        /// 前回検索条件保持
        /// </summary>
        private IKensakuBtnClickALInput _searchAlInput;

        #region to be removed
        //ApplicationLigicに移動
        ///// <summary>
        ///// 別検体情報
        ///// </summary>
        //struct BetsuKentai
        //{
        //    public int rowIndex;
        //    public string kachoKenin;
        //    public string hukukachoKenin;
        //}
        #endregion

        #endregion

        #region コンストラクタ

        public HoteiKensaDaicho()
        {
            insideFlg = true;

            InitializeComponent();

            // ドメイン設定
            nendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 4);
            iraiNoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            iraiNoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            // ドメイン設定(DataGridView)
            // 20140108 sou Start 桁指定を整数桁→全桁に修正
            #region to be removed
            //listDataGridView.SetStdControlDomain(ph1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(ondo1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(ph2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //listDataGridView.SetStdControlDomain(ondo2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.PositiveNegative);
            //
            //listDataGridView.SetStdControlDomain(tr1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //listDataGridView.SetStdControlDomain(tr2Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //
            //listDataGridView.SetStdControlDomain(bod1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.Positive);
            //listDataGridView.SetStdControlDomain(bod2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 1, InputValidateUtility.SignFlg.Positive);
            //
            //listDataGridView.SetStdControlDomain(zanen1Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.Positive);
            //listDataGridView.SetStdControlDomain(zanen2Col.Index, ZControlDomain.ZG_STD_NUM, 2, 2, InputValidateUtility.SignFlg.Positive);
            //
            //listDataGridView.SetStdControlDomain(cl1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            //listDataGridView.SetStdControlDomain(cl2Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            #endregion

            listDataGridView.SetStdControlDomain(ph1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(ondo1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(ph2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 1, InputValidateUtility.SignFlg.PositiveNegative);
            listDataGridView.SetStdControlDomain(ondo2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 1, InputValidateUtility.SignFlg.PositiveNegative);

            listDataGridView.SetStdControlDomain(tr1Col.Index, ZControlDomain.ZG_STD_NUM, 2);
            listDataGridView.SetStdControlDomain(tr2Col.Index, ZControlDomain.ZG_STD_NUM, 2);

            listDataGridView.SetStdControlDomain(bod1Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);
            listDataGridView.SetStdControlDomain(bod2Col.Index, ZControlDomain.ZG_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);

            listDataGridView.SetStdControlDomain(zanen1Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.Positive);
            listDataGridView.SetStdControlDomain(zanen2Col.Index, ZControlDomain.ZG_STD_NUM, 4, 2, InputValidateUtility.SignFlg.Positive);

            listDataGridView.SetStdControlDomain(cl1Col.Index, ZControlDomain.ZG_STD_NUM, 4);
            listDataGridView.SetStdControlDomain(cl2Col.Index, ZControlDomain.ZG_STD_NUM, 4);
            // 20140108 sou End

            insideFlg = false;
        }

        #endregion

        #region イベント

        #region FormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SuishitsuKensaDaichoForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuKensaDaichoForm_Load(object sender, EventArgs e)
        {
            this.constMstConstKbn027TableAdapter.Fill(this.kekkaCdDataSet.ConstMstConstKbn027);

            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 内部変更On
                insideFlg = true;

                // 検索条件の初期化
                SearchConditionClear();
                // フォームのフォントのベースに下線付きフォントを生成
                underLineFont = new Font(this.Font, this.Font.Style | FontStyle.Strikeout);

//#if DEBUG
//                // 全項目表示
//                for (int idx = 0; idx < listDataGridView.ColumnCount; idx++)
//                {
//                    listDataGridView.Columns[idx].Visible = true;
//                }
//#else
                // スクロール固定
                listDataGridView.Columns[hukukachoKeninCol.Index].Frozen = true;
//#endif
                // ヘッダのVisualスタイルを無効化
                listDataGridView.EnableHeadersVisualStyles = false;
                // ヘッダの背景色を設定
                SetHeaderBackColor(ph1Col.Index, Color.Gold);
                SetHeaderBackColor(tr1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(bod1Col.Index, Color.Gold);
                SetHeaderBackColor(zanen1Col.Index, Color.LawnGreen);
                SetHeaderBackColor(cl1Col.Index, Color.Gold);
                SetHeaderBackColor(atubod1Col.Index, Color.LawnGreen);

                // 20150115 habu 初期ロード時に、出力ボタン無効
                // 画面モード変更
                ModeChange(DispMode.Load);
                //ModeChange(DispMode.Kakunin);

                // 20150120 sou Start
                // 支所
                IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(new FormLoadALInput());
                Utility.Utility.SetComboBoxList(shishoComboBox, alOutput.ShishoMstExceptJimukyokuDataTable, "ShishoNm", "ShishoCd", true);
                // 20150120 sou End

                // 検索条件初期化を行う
                SearchConditionClear();

                // 20150114 habu ラジオボタン処理修正
                // チェックボックス列のラジオボタン化
                listDataGridView.SetRadioGroup(new int[] { saiyotiPh1Col.Index, saiyotiPh2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiTr1Col.Index, saiyotiTr2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiBod1Col.Index, saiyotiBod2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiZanen1Col.Index, saiyotiZanen2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiCl1Col.Index, saiyotiCl2Col.Index });
                listDataGridView.SetRadioGroup(new int[] { saiyotiAtubod1Col.Index, saiyotiAtubod2Col.Index });

                // 20150127 sou Start DataGridViewの全列の並び替え不可
                foreach (DataGridViewColumn col in listDataGridView.Columns)
                {
                    col.SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                // 20150127 sou End
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                // 画面を終了（前画面に戻る）
                this.DialogResult = DialogResult.Abort;
                // 20150114 habu 画面遷移修正
                // 前画面に戻る
                Program.mForm.MovePrev();
                //this.Close();
            }
            finally
            {
                // 内部変更Off
                insideFlg = false;

                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 検索条件の表示切替
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ViewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // TODO 下記共通関数を使用する
                //Common.SwitchSearchPanel(

                if (viewChangeButton.Text == "▼")
                {
                    searchPanel.Height = 96;
                    //listPanel.Top = 187;
                    //listPanel.Height = 339;
                    viewChangeButton.Text = "▲";
                    clearButton.Visible = true;
                    kensakuButton.Visible = true;
                }
                else
                {
                    clearButton.Visible = false;
                    kensakuButton.Visible = false;
                    searchPanel.Height = 30;
                    //listPanel.Top = 30;
                    //listPanel.Height = 475;
                    viewChangeButton.Text = "▼";
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
        /// 2014/11/28　宗        新規作成
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

        #region クリアボタン
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 検索条件の初期化
                SearchConditionClear();
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

        #region 検索ボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 内部変更On
                insideFlg = true;

                // 関連チェック
                if (!RelationCheck())
                {
                    return;
                }

                // 編集内容破棄チェック
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.No)
                    {
                        return;
                    }
                }

                // 検索条件生成
                IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
                MakeSearchCond(alInput);

                // 検索条件保持
                _searchAlInput = alInput;

                // 検索
                DoSearch(alInput);

                // 画面モード変更、初回判定がある場合は編集モード
                ModeChange((!EditCheck()) ? DispMode.Hensyu : DispMode.Kakunin);
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                // 内部変更Off
                insideFlg = false;

                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 検査台帳一覧のボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_CellContentClick
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 20150127 sou Start ヘッダ選択時は処理を抜ける
                if (e.RowIndex < 0) { return; }
                // 20150127 sou End

                // 過去情報ボタン
                if (e.ColumnIndex == kakoJohoCol.Index)
                {
                    // 浄化槽台帳画面に遷移
                    JokasoDaichoShosai frm = new JokasoDaichoShosai(
                        listDataGridView[jokasoHokenjoCdCol.Index, e.RowIndex].Value.ToString(),
                        listDataGridView[jokasoTorokuNendoCol.Index, e.RowIndex].Value.ToString(),
                        listDataGridView[jokasoRenbanCol.Index, e.RowIndex].Value.ToString(),
                        JokasoDaichoShosai.DispMode.View
                        );
                    Program.mForm.MoveNext(frm);
                }
                // 採水員ボタン
                else if (e.ColumnIndex == saisuiinCol.Index)
                {
                    // 採水員情報詳細画面に遷移
                    SaisuiinInfoShosaiForm frm = new SaisuiinInfoShosaiForm(
                        listDataGridView[saisuiinCdCol.Index, e.RowIndex].Value.ToString()
                        );
                    Program.mForm.MoveNext(frm);
                }

                // チェックボックスセルの場合は、直ちに編集を終了する(直ちにValueChangedイベントを発生させるため)
                if (listDataGridView.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn)
                {
                    // 20150114 habu チェックボックスのラジオボタン化に伴い、編集完了の方式を見直し
                    this.Validate();
                    //listDataGridView.EndEdit();
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

        #region 検査台帳一覧の値変更
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： listDataGridView_CellValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/21　宗        結果コード変更時の判定を追加
        /// 2015/01/29  宗        ATUBODを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void listDataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // 内部変更の場合は処理を抜ける
            if (insideFlg) return;

            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 内部変更On
                insideFlg = true;

                // 対象行を取得
                DataGridViewRow dgvr = listDataGridView.Rows[e.RowIndex];

                // 20150114 habu 共通での処理に変更
                #region to be removed
                // 採用値の反転
                //{
                //    // pH
                //    if (e.ColumnIndex == saiyotiPh1Col.Index
                //        && dgvr.Cells[e.ColumnIndex].Value.ToString() == CheckOn)
                //    {
                //        dgvr.Cells[e.ColumnIndex + 7].Value = false;
                //    }
                //    else if (e.ColumnIndex == saiyotiPh2Col.Index
                //        && dgvr.Cells[e.ColumnIndex].Value.ToString() == CheckOn)
                //    {
                //        dgvr.Cells[e.ColumnIndex - 7].Value = false;
                //    }
                //    // その他
                //    if ((e.ColumnIndex == saiyotiTr1Col.Index
                //        || e.ColumnIndex == saiyotiBod1Col.Index
                //        || e.ColumnIndex == saiyotiZanen1Col.Index
                //        || e.ColumnIndex == saiyotiCl1Col.Index)
                //        && dgvr.Cells[e.ColumnIndex].Value.ToString() == CheckOn)
                //    {
                //        dgvr.Cells[e.ColumnIndex + 6].Value = false;
                //    }
                //    else if ((e.ColumnIndex == saiyotiTr2Col.Index
                //        || e.ColumnIndex == saiyotiBod2Col.Index
                //        || e.ColumnIndex == saiyotiZanen2Col.Index
                //        || e.ColumnIndex == saiyotiCl2Col.Index)
                //        && dgvr.Cells[e.ColumnIndex].Value.ToString() == CheckOn)
                //    {
                //        dgvr.Cells[e.ColumnIndex - 6].Value = false;
                //    }
                //}
                #endregion

                // 変更した結果値を赤文字表示
                if (e.ColumnIndex == ph1Col.Index || e.ColumnIndex == ph2Col.Index
                    || e.ColumnIndex == ondo1Col.Index || e.ColumnIndex == ondo2Col.Index
                    || e.ColumnIndex == tr1Col.Index || e.ColumnIndex == tr2Col.Index
                    || e.ColumnIndex == bod1Col.Index || e.ColumnIndex == bod2Col.Index
                    || e.ColumnIndex == zanen1Col.Index || e.ColumnIndex == zanen2Col.Index
                    || e.ColumnIndex == cl1Col.Index || e.ColumnIndex == cl2Col.Index)
                {
                    dgvr.Cells[e.ColumnIndex].Style.ForeColor = Color.Red;
                }

                // pH(温度)
                if (e.ColumnIndex == ph1Col.Index
                    || e.ColumnIndex == ph2Col.Index
                    || e.ColumnIndex == ondo1Col.Index
                    || e.ColumnIndex == ondo2Col.Index
                    || e.ColumnIndex == ph1KekkaCdCol.Index
                    || e.ColumnIndex == ph2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiPh1Col.Index
                    || e.ColumnIndex == saiyotiPh2Col.Index)
                {
                    //確認検査種別の判定(過去との比較)]
                    CheckKakuninKensaShubetsuKako(dgvr, ph1Col.Index);
                    //確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    //異常種別の判定
                    CheckIjyoShubetsu(dgvr);
                    //適正の判定
                    CheckTekisei(dgvr);
                    //状態設定(pH)
                    SetKmkPropatyPh(dgvr, ph1Col.Index);
                    //｛更新区分（pH）｝ = "1"
                    dgvr.Cells[koshinKbnPh.Index].Value = "1";
                }

                // 透視度
                if (e.ColumnIndex == tr1Col.Index
                    || e.ColumnIndex == tr2Col.Index
                    || e.ColumnIndex == tr1KekkaCdCol.Index
                    || e.ColumnIndex == tr2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiTr1Col.Index
                    || e.ColumnIndex == saiyotiTr2Col.Index)
                {
                    //確認検査種別の判定(BOD/透視度)
                    CheckKakuninKensaShubetsuBodTr(dgvr);
                    //確認検査種別の判定(過去との比較)
                    CheckKakuninKensaShubetsuKako(dgvr, tr1Col.Index);
                    //確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    //異常種別の判定
                    CheckIjyoShubetsu(dgvr);
                    //適正の判定
                    CheckTekisei(dgvr);
                    //状態設定(透視度)
                    SetKmkPropatyAll(dgvr, tr1Col.Index);
                    //｛更新区分（透視度）｝ = "1"
                    dgvr.Cells[koshinKbnTr.Index].Value = "1";
                }

                // BOD
                if (e.ColumnIndex == bod1Col.Index
                    || e.ColumnIndex == bod2Col.Index
                    || e.ColumnIndex == bod1KekkaCdCol.Index
                    || e.ColumnIndex == bod2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiBod1Col.Index
                    || e.ColumnIndex == saiyotiBod2Col.Index)
                {
                    //スクリーニング判定
                    CheckScreening(dgvr);
                    //確認検査種別の判定(BOD/透視度)
                    CheckKakuninKensaShubetsuBodTr(dgvr);
                    //確認検査種別の判定(過去との比較)
                    CheckKakuninKensaShubetsuKako(dgvr, bod1Col.Index);
                    //確認検査種別の判定(BOD基準値オーバー)
                    CheckKakuninKensaShubetsuBodOver(dgvr);
                    //確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    //異常種別の判定
                    CheckIjyoShubetsu(dgvr);
                    //適正の判定
                    CheckTekisei(dgvr);
                    //状態設定(BOD)
                    SetKmkPropatyAll(dgvr, bod1Col.Index);
                    //｛更新区分（BOD）｝ = "1"
                    dgvr.Cells[koshinKbnBod.Index].Value = "1";
                }

                // 残塩
                if (e.ColumnIndex == zanen1Col.Index
                    || e.ColumnIndex == zanen2Col.Index
                    || e.ColumnIndex == zanen1KekkaCdCol.Index
                    || e.ColumnIndex == zanen2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiZanen1Col.Index
                    || e.ColumnIndex == saiyotiZanen2Col.Index)
                {
                    //スクリーニング判定
                    CheckScreening(dgvr);
                    //確認検査種別の判定(過去との比較)
                    CheckKakuninKensaShubetsuKako(dgvr, zanen1Col.Index);
                    //確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    //異常種別の判定
                    CheckIjyoShubetsu(dgvr);
                    //適正の判定
                    CheckTekisei(dgvr);
                    //状態設定(残塩)
                    SetKmkPropatyAll(dgvr, zanen1Col.Index);
                    //｛更新区分（残塩）｝ = "1"
                    dgvr.Cells[koshinKbnZanen.Index].Value = "1";
                }

                // 塩化物イオン
                if (e.ColumnIndex == cl1Col.Index
                    || e.ColumnIndex == cl2Col.Index
                    || e.ColumnIndex == cl1KekkaCdCol.Index
                    || e.ColumnIndex == cl2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiCl1Col.Index
                    || e.ColumnIndex == saiyotiCl2Col.Index)
                {
                    //確認検査種別の判定(過去との比較)
                    CheckKakuninKensaShubetsuKako(dgvr, cl1Col.Index);
                    //確認検査種別の判定(塩化物イオン確認検査)
                    CheckKakuninKensaShubetsuEnkaIon(dgvr);
                    //確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    //異常種別の判定
                    CheckIjyoShubetsu(dgvr);
                    //適正の判定
                    CheckTekisei(dgvr);
                    //状態設定(塩化物イオン)
                    SetKmkPropatyAll(dgvr, cl1Col.Index);
                    //｛更新区分（塩化物イオン）｝ = "1"
                    dgvr.Cells[koshinKbnCl.Index].Value = "1";
                }

                // ATUBOD
                if (e.ColumnIndex == atubod1Col.Index
                    || e.ColumnIndex == atubod2Col.Index
                    || e.ColumnIndex == atubod1KekkaCdCol.Index
                    || e.ColumnIndex == atubod2KekkaCdCol.Index
                    || e.ColumnIndex == saiyotiAtubod1Col.Index
                    || e.ColumnIndex == saiyotiAtubod2Col.Index)
                {
                    //スクリーニング判定
                    CheckScreening(dgvr);
                    //確認検査種別の判定(BOD/透視度)
                    CheckKakuninKensaShubetsuBodTr(dgvr);
                    //確認検査種別の判定(過去との比較)
                    CheckKakuninKensaShubetsuKako(dgvr, atubod1Col.Index);
                    //確認検査種別の判定(BOD基準値オーバー)
                    CheckKakuninKensaShubetsuBodOver(dgvr);
                    //確認検査種別の判定結果を表示
                    DispKakuninKensaShubetsu(dgvr);
                    //異常種別の判定
                    CheckIjyoShubetsu(dgvr);
                    //適正の判定
                    CheckTekisei(dgvr);
                    //状態設定(ATUBOD)
                    SetKmkPropatyAll(dgvr, atubod1Col.Index);
                    //｛更新区分（ATUBOD）｝ = "1"
                    dgvr.Cells[koshinKbnAtubod.Index].Value = "1";
                }

                // 課長検印、副課長検印
                if (e.ColumnIndex == kachoKeninCol.Index
                    || e.ColumnIndex == hukukachoKeninCol.Index)
                {
                    // 状態設定(検印)
                    SetKmkPropaty(dgvr);
                    //更新区分（検印）
                    dgvr.Cells[koshinKbnKenin.Index].Value = "1";
                }

                // スクリーニング指示
                if (e.ColumnIndex == screeningCol.Index)
                {
                    if (dgvr.Cells[screeningCol.Index].Value.ToString() == CheckOn)
                    {
                        // 課長検印
                        dgvr.Cells[kachoKeninCol.Index].ReadOnly = true;
                        // 副課長検印
                        dgvr.Cells[hukukachoKeninCol.Index].ReadOnly = true;
                    }
                    else
                    {
                        // 課長検印
                        dgvr.Cells[kachoKeninCol.Index].ReadOnly = false;
                        // 副課長検印
                        dgvr.Cells[hukukachoKeninCol.Index].ReadOnly = false;
                    }
                }

                // 内部変更Off
                insideFlg = false;

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
                // 20150114 habu finally側に移動
                // 内部変更Off
                insideFlg = false;

                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region 一括検印(課長)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kachoKeninCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kachoKeninCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // レコード0件の場合は処理を抜ける
                if (listDataGridView.RowCount == 0) return;

                if (kachoKeninCheckBox.Checked == true)
                {
                    // チェックを付けた場合
                    foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                    {
                        // 検印可否判定
                        dgvr.Cells[kachoKeninCol.Index].Value = keninKahiHantei(dgvr);
                    }
                }
                else
                {
                    // チェックを外した場合
                    foreach (DataGridViewRow gridRow in listDataGridView.Rows)
                    {
                        gridRow.Cells[kachoKeninCol.Index].Value = false;
                    }
                }
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

        #region 一括検印(副課長)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hukukachoKeninCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hukukachoKeninCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // レコード0件の場合は処理を抜ける
                if (listDataGridView.RowCount == 0) return;

                if (hukukachoKeninCheckBox.Checked == true)
                {
                    // チェックを付けた場合
                    foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                    {
                        // 検印可否判定
                        dgvr.Cells[hukukachoKeninCol.Index].Value = keninKahiHantei(dgvr);
                    }
                }
                else
                {
                    // チェックを外した場合
                    foreach (DataGridViewRow gridRow in listDataGridView.Rows)
                    {
                        gridRow.Cells[hukukachoKeninCol.Index].Value = false;
                    }
                }
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

        #region 台帳出力ボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "検査台帳を出力します。よろしいですか？") == DialogResult.No)
                {
                    return;
                }

                // 20150116 habu 編集済みの場合、破棄確認メッセージを表示する様に変更
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "未確定分の編集内容は出力に反映されません。\r\n出力を行いますか？") == DialogResult.No)
                    {
                        return;
                    }
                }

                // 20150115 habu Add 出力条件を、画面検索処理同等にする
                // 11条検査台帳出力
                IDaichoPrintBtnClickALInput alInput = new DaichoPrintBtnClickALInput();
                alInput.SearchCond = _searchAlInput.SearchCond;

                #region to be removed
                //alInput.Nendo = nendoTextBox.Text;
                //alInput.IraiDateKbn = iraiUketsukeDtCheckBox.Checked == true ? "1" : "0";
                //alInput.IraiDateFrom = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                //alInput.IraiDateTo = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
                //alInput.KensaKbn = suishitsuKensaRadioButton.Checked ? "2" : "3";
                //alInput.IraiNoFrom = string.IsNullOrEmpty(iraiNoFromTextBox.Text) == true ? string.Empty : iraiNoFromTextBox.Text.PadLeft(6, '0');
                //alInput.IraiNoTo = string.IsNullOrEmpty(iraiNoToTextBox.Text) == true ? string.Empty : iraiNoToTextBox.Text.PadLeft(6, '0');
                #endregion

                // 11条検査台帳出力
                new DaichoPrintBtnClickApplicationLogic().Execute(alInput);

                //20150122 sou Start
                //MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力が完了しました。");
                //20150122 sou End
            }
            catch (CustomException ce)
            {
                if ((ce.ResultCode == ResultCode.OperationError) && (ce.ExtensionCode == (int)PrintHotei11joIjoListBusinessLogic.OperationErr.NoDataFound))
                {
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), "出力データがありません。");
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力データがありません。");
                }
                else
                {
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ce.ToString());
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ce.Message);
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

        #region 水質異常一覧出力ボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuninPrintButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/07　宗        スクリーニングフォローの帳票出力を一括出力から個別出力に変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuIjoPrintButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 20150111 sou Start
                #region to be removed
                //// 法定11条水質異常一覧表出力
                //ISuishitsuIjoPrintBtnClickScreeningALInput scAlInput = new SuishitsuIjoPrintBtnClickScreeningALInput();
                //scAlInput.Nendo = nendoTextBox.Text;
                //scAlInput.IraiDateKbn = iraiUketsukeDtCheckBox.Checked == true ? "1" : "0";
                //scAlInput.IraiDateFrom = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                //scAlInput.IraiDateTo = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
                //scAlInput.IraiNoFrom = iraiNoFromTextBox.Text;
                //scAlInput.IraiNoTo = iraiNoToTextBox.Text;
                //scAlInput.MassageFlg = true;
                //new SuishitsuIjoPrintBtnClickScreeningApplicationLogic().Execute(scAlInput);
                //
                //// フォロー検査対象一覧表出力
                //ISuishitsuIjoPrintBtnClickFollowALInput foAlInput = new SuishitsuIjoPrintBtnClickFollowALInput();
                //foAlInput.Nendo = nendoTextBox.Text;
                //foAlInput.IraiDateKbn = iraiUketsukeDtCheckBox.Checked == true ? "1" : "0";
                //foAlInput.IraiDateFrom = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                //foAlInput.IraiDateTo = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
                //foAlInput.IraiNoFrom = iraiNoFromTextBox.Text;
                //foAlInput.IraiNoTo = iraiNoToTextBox.Text;
                //foAlInput.MassageFlg = true;
                //new SuishitsuIjoPrintBtnClickFollowApplicationLogic().Execute(foAlInput);
                #endregion

                // 水質異常一覧出力
                SuishitsuIjoListPrint();
                // 20150111 sou End
            }
            catch (CustomException ce)
            {
                //if ((ce.ResultCode == ResultCode.OperationError) && (ce.ExtensionCode == (int)PrintHotei11joIjoListBusinessLogic.OperationErr.NoDataFound))
                //{
                //    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), "出力データがありません。");
                //    MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力データがありません。");
                //}
                //else
                //{
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ce.ToString());
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ce.Message);
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

        #region 確定ボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kakuteiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/07　宗        スクリーニングフォローの帳票出力を一括出力から個別出力に変更
        /// 2015/01/11  宗        更新後のメッセージを追加＆帳票出力前に出力確認のメッセージを追加
        /// 2015/01/29  宗        ATUBODを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kakuteiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (listDataGridView.Rows.Count == 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, "対象データがありません。");
                    return;
                }

                if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集された内容を確定します。\r\nよろしいですか？") == DialogResult.No)
                {
                    return;
                }

                // 更新
                IKakuteiBtnClickALInput alInput = new KakuteiBtnClickALInput();
                alInput.UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
                alInput.UpdateUser = LoginUser;
                alInput.UpdateTarm = HostName;
                alInput.listDataGridView = listDataGridView;
                new KakuteiBtnClickApplicationLogic().Execute(alInput);

                // 20150111 sou Start
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "確定処理が完了しました。");
                // 20150111 sou End

                #region スクリーニング指示の追加確認
                bool screeningAdd = false;
                foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                {
                    if ((dgvr.Cells[screeningFlgCol.Index].Value.ToString() == "0")
                        && (dgvr.Cells[screeningCol.Index].Value.ToString() == CheckOn))
                    {
                        screeningAdd = true;
                        dgvr.Cells[screeningFlgCol.Index].Value = "1";
                        dgvr.Cells[screeningCol.Index].ReadOnly = true;
                    }
                }
                #endregion

                #region スクリーニングとフォローの対象一覧出力
                if (screeningAdd)
                {
                    #region to be removed
                    // 20150111 sou Start
                    //// 法定11条水質異常一覧表出力
                    //ISuishitsuIjoPrintBtnClickScreeningALInput scAlInput = new SuishitsuIjoPrintBtnClickScreeningALInput();
                    //scAlInput.Nendo = nendoTextBox.Text;
                    //scAlInput.IraiDateKbn = iraiUketsukeDtCheckBox.Checked == true ? "1" : "0";
                    //scAlInput.IraiDateFrom = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                    //scAlInput.IraiDateTo = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
                    //scAlInput.IraiNoFrom = iraiNoFromTextBox.Text;
                    //scAlInput.IraiNoTo = iraiNoToTextBox.Text;
                    //scAlInput.MassageFlg = false;
                    //new SuishitsuIjoPrintBtnClickScreeningApplicationLogic().Execute(scAlInput);
                    //
                    //// フォロー検査対象一覧表出力
                    //ISuishitsuIjoPrintBtnClickFollowALInput foAlInput = new SuishitsuIjoPrintBtnClickFollowALInput();
                    //foAlInput.Nendo = nendoTextBox.Text;
                    //foAlInput.IraiDateKbn = iraiUketsukeDtCheckBox.Checked == true ? "1" : "0";
                    //foAlInput.IraiDateFrom = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                    //foAlInput.IraiDateTo = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
                    //foAlInput.IraiNoFrom = iraiNoFromTextBox.Text;
                    //foAlInput.IraiNoTo = iraiNoToTextBox.Text;
                    //foAlInput.MassageFlg = false;
                    //new SuishitsuIjoPrintBtnClickFollowApplicationLogic().Execute(foAlInput);
                    #endregion

                    // 水質異常一覧出力
                    SuishitsuIjoListPrint();
                    // 20150111 sou End
                }
                #endregion

                #region 更新日の更新
                foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                {
                    // 更新区分(検印)
                    dgvr.Cells[koshinKbnKenin.Index].Value = "0";
                    // 更新区分(スクリーニング候補)
                    dgvr.Cells[koshinKbnScreeningKoho.Index].Value = "0";
                    // 更新区分(クロスチェック異常(水質判定表))
                    dgvr.Cells[koshinKbnCrossSuishitsu.Index].Value = "0";
                    // 更新区分(クロスチェック異常(過去履歴))
                    dgvr.Cells[koshinKbnCrossKako.Index].Value = "0";
                    // 更新区分(pH)
                    dgvr.Cells[koshinKbnPh.Index].Value = "0";
                    // 更新区分(透視度)
                    dgvr.Cells[koshinKbnTr.Index].Value = "0";
                    // 更新区分(BOD)
                    dgvr.Cells[koshinKbnBod.Index].Value = "0";
                    // 更新区分(残塩)
                    dgvr.Cells[koshinKbnZanen.Index].Value = "0";
                    // 更新区分(塩化物イオン)
                    dgvr.Cells[koshinKbnCl.Index].Value = "0";
                    // 更新区分(ATUBOD)
                    dgvr.Cells[koshinKbnAtubod.Index].Value = "0";
                    // 更新区分（過去との比較）pH
                    dgvr.Cells[koshinKbnKakoPh.Index].Value = "0";
                    // 更新区分（過去との比較）透視度
                    dgvr.Cells[koshinKbnKakoTr.Index].Value = "0";
                    // 更新区分（過去との比較）BOD
                    dgvr.Cells[koshinKbnKakoBod.Index].Value = "0";
                    // 更新区分（過去との比較）残塩
                    dgvr.Cells[koshinKbnKakoZanen.Index].Value = "0";
                    // 更新区分（過去との比較）塩化物イオン
                    dgvr.Cells[koshinKbnKakoCl.Index].Value = "0";
                    // 更新区分（過去との比較）ATUBOD
                    dgvr.Cells[koshinKbnKakoAtubod.Index].Value = "0";
                    // 更新区分（BOD/透視度）
                    dgvr.Cells[koshinKbnBodTr.Index].Value = "0";
                    // 更新区分（BOD基準値オーバー）
                    dgvr.Cells[koshinKbnBodOver.Index].Value = "0";
                    // 更新区分（塩化物イオン確認検査）
                    dgvr.Cells[koshinKbnClKakunin.Index].Value = "0";
                }
                #endregion

                #region 更新区分の初期化
                foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                {
                    // 更新区分(検印)
                    dgvr.Cells[koshinKbnKenin.Index].Value = "0";
                    // 更新区分(スクリーニング候補)
                    dgvr.Cells[koshinKbnScreeningKoho.Index].Value = "0";
                    // 更新区分(クロスチェック異常(水質判定表))
                    dgvr.Cells[koshinKbnCrossSuishitsu.Index].Value = "0";
                    // 更新区分(クロスチェック異常(過去履歴))
                    dgvr.Cells[koshinKbnCrossKako.Index].Value = "0";
                    // 更新区分(pH)
                    dgvr.Cells[koshinKbnPh.Index].Value = "0";
                    // 更新区分(透視度)
                    dgvr.Cells[koshinKbnTr.Index].Value = "0";
                    // 更新区分(BOD)
                    dgvr.Cells[koshinKbnBod.Index].Value = "0";
                    // 更新区分(残塩)
                    dgvr.Cells[koshinKbnZanen.Index].Value = "0";
                    // 更新区分(塩化物イオン)
                    dgvr.Cells[koshinKbnCl.Index].Value = "0";
                    // 更新区分(ATUBOD)
                    dgvr.Cells[koshinKbnAtubod.Index].Value = "0";
                    // 更新区分（過去との比較）pH
                    dgvr.Cells[koshinKbnKakoPh.Index].Value = "0";
                    // 更新区分（過去との比較）透視度
                    dgvr.Cells[koshinKbnKakoTr.Index].Value = "0";
                    // 更新区分（過去との比較）BOD
                    dgvr.Cells[koshinKbnKakoBod.Index].Value = "0";
                    // 更新区分（過去との比較）残塩
                    dgvr.Cells[koshinKbnKakoZanen.Index].Value = "0";
                    // 更新区分（過去との比較）塩化物イオン
                    dgvr.Cells[koshinKbnKakoCl.Index].Value = "0";
                    // 更新区分（過去との比較）ATUBOD
                    dgvr.Cells[koshinKbnKakoAtubod.Index].Value = "0";
                    // 更新区分（BOD/透視度）
                    dgvr.Cells[koshinKbnBodTr.Index].Value = "0";
                    // 更新区分（BOD基準値オーバー）
                    dgvr.Cells[koshinKbnBodOver.Index].Value = "0";
                    // 更新区分（塩化物イオン確認検査）
                    dgvr.Cells[koshinKbnClKakunin.Index].Value = "0";
                }
                #endregion

                #region 文字色を初期化
                foreach (DataGridViewRow dgvr in listDataGridView.Rows)
                {
                    dgvr.Cells[ph1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[ph2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[ondo1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[ondo2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tr1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[tr2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[bod1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[bod2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[cl1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[cl2Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[zanen1Col.Index].Style.ForeColor = Color.Black;
                    dgvr.Cells[zanen2Col.Index].Style.ForeColor = Color.Black;
                }
                #endregion

                // 20150116 habu 検索処理を再実行する
                // 検索
                DoSearch(_searchAlInput);

                // 画面モード変更
                ModeChange(DispMode.Kakunin);
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());
                if (cex.ResultCode == ResultCode.LockError)
                {
                    // 楽観ロックエラー
                    // 「対象の情報が更新されています。
                    //   再度検索後、操作をやり直してください。」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00009);
                }
                else
                {
                    // 何らかのカスタム例外
                    // 「想定外のシステムエラーが発生しました。
                    //   システム管理者へ連絡してください。
                    //   {0}」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, cex.Message);
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

        #region 閉じるボタン押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 編集内容破棄チェック
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.No)
                    {
                        return;
                    }
                }
                // 前画面に戻る
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

        #region 入力値の複写(依頼受付日)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiUketsukeDtFromDateTimePicker_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiUketsukeDtFromDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            iraiUketsukeDtToDateTimePicker.Value = iraiUketsukeDtFromDateTimePicker.Value;
        }
        #endregion

        #region 入力値の複写(検体番号)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： iraiNoFromTextBox_TextChanged
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void iraiNoFromTextBox_TextChanged(object sender, EventArgs e)
        {
            iraiNoToTextBox.Text = iraiNoFromTextBox.Text;
        }
        #endregion

        #region ファンクションキー押下
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HoteiKensaDaicho_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HoteiKensaDaicho_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        daichoPrintButton.PerformClick();
                        break;

                    case Keys.F2:
                        suishitsuIjoOutputButton.PerformClick();
                        break;

                    case Keys.F5:
                        kakuteiButton.PerformClick();
                        break;

                    case Keys.F7:
                    case Keys.Alt | Keys.C:
                        clearButton.PerformClick();
                        break;

                    case Keys.F8:
                    case Keys.Alt | Keys.F:
                        kensakuButton.PerformClick();
                        break;

                    case Keys.F12:
                    case Keys.Alt | Keys.X:
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

        #endregion

        #region メソッド(private)

        #region 結果コードのカラムを編集したカラムに置換
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeColumn
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeColumn(DataGridView dgv, DataTable dt, string colNm)
        {
            // 結果コードのカラム作成
            DataGridViewComboBoxColumn dgvCmbCol = new DataGridViewComboBoxColumn();
            dgvCmbCol.DataSource = dt;
            dgvCmbCol.ValueMember = "ConstValue";
            dgvCmbCol.DisplayMember = "ConstNm";
            dgvCmbCol.HeaderText = "";
            dgvCmbCol.Width = 60;

            // カラムの置換
            dgv.Columns.Insert(dgv.Columns[colNm].Index, dgvCmbCol);
            dgv.Columns.Remove(colNm);
            dgvCmbCol.Name = colNm;
        }
        #endregion

        #region 列ヘッダの背景色変更
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetHeaderBackColor
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetHeaderBackColor(int col, Color colorType)
        {
            listDataGridView.Columns[col].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 1].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 2].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 3].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 4].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 5].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 6].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 7].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 8].HeaderCell.Style.BackColor = colorType;
            listDataGridView.Columns[col + 9].HeaderCell.Style.BackColor = colorType;
            if (col == ph1Col.Index)
            {
                listDataGridView.Columns[col + 10].HeaderCell.Style.BackColor = colorType;
                listDataGridView.Columns[col + 11].HeaderCell.Style.BackColor = colorType;
            }
        }
        #endregion

        #region 検索条件の初期化
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SearchConditionClear
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/27  宗        取得する支所マスタを全件から事務局以外に変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SearchConditionClear()
        {
            DateTime systemDt = Common.Common.GetCurrentTimestamp();

            //// 20150120 sou Start
            //shishoComboBox.SelectedValue = LoginUserShozokuShishoCd;
            //// 20150120 sou End
            if (LoginUserShozokuShishoCd == "0")
            {
                shishoComboBox.SelectedIndex = 0;
            }
            else
            {
                shishoComboBox.SelectedValue = LoginUserShozokuShishoCd;
            }

            // 20150115 habu 年度を初期設定するように変更
            nendoTextBox.Text = Utility.DateUtility.GetNendo(Common.Common.GetCurrentTimestamp()).ToString();
            //nendoTextBox.Text = string.Empty;

            iraiUketsukeDtCheckBox.Checked = false;
            iraiUketsukeDtFromDateTimePicker.Value = systemDt;
            iraiUketsukeDtToDateTimePicker.Value = systemDt;

            suishitsuKensaRadioButton.Checked = true;
            gaikanKensaRadioButton.Checked = false;

            iraiNoFromTextBox.Text = string.Empty;
            iraiNoToTextBox.Text = string.Empty;
        }
        #endregion

        #region 検索
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2014/12/29  小松　　　外観検査で検査状況が完了(003)以外は、編集不可
        /// 2014/12/29  小松　　　複数の検査項目が絡む確認検査の場合の実施有無を判定する条件を、1つでも該当すれば実施するように修正
        /// 2015/01/07　宗        一括検印のクリア処理を追加
        /// 2015/01/16　habu      検索条件の再利用をできるように変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch(IKensakuBtnClickALInput alInput)
        {
            // 検査台帳一覧のクリア
            listDataGridView.Rows.Clear();
            // 一括検印のクリア
            kachoKeninCheckBox.Checked = false;
            hukukachoKeninCheckBox.Checked = false;

            // 採水員ボタン列の表示切替
            if (suishitsuKensaRadioButton.Checked == true)
            {
                // 11条水質の場合は表示
                listDataGridView.Columns[saisuiinCol.Index].Visible = true;
            }
            else
            {
                // 外観検査の場合は非表示
                listDataGridView.Columns[saisuiinCol.Index].Visible = false;
            }

            // データ取得
            KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchDataTable table = GetData(alInput);

            // 一覧設定
            foreach (KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchRow row in table.Rows)
            {
                SetData(row);
            }

            // 各種判定
            foreach (DataGridViewRow dgvr in listDataGridView.Rows)
            {
                #region スクリーニング判定
                //スクリーニング判定
                CheckScreening(dgvr);
                #endregion

                #region 確認検査種別の判定(BOD/透視度)
                // どちらかに該当すれば実施
                if ((((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[bod1KensaShubetsuBodTr.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[bod2KensaShubetsuBodTr.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1")))

                    || 
                    (((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))))
                {
                    CheckKakuninKensaShubetsuBodTr(dgvr);
                }
                #endregion

                #region 確認検査種別の判定(過去との比較)
                {
                    // pH
                    if ((dgvr.Cells[saiyotiPh1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[ph1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, ph1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiPh2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[ph2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, ph2Col.Index);
                    }
                    // 透視度
                    if ((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tr1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tr1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[tr2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, tr2Col.Index);
                    }
                    // BOD
                    if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[bod1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, bod1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[bod2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, bod2Col.Index);
                    }
                    // 残留塩素濃度
                    if ((dgvr.Cells[saiyotiZanen1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[zanen1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, zanen1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiZanen2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[zanen2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, zanen2Col.Index);
                    }
                    // 塩化物イオン
                    if ((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[cl1KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, cl1Col.Index);
                    }
                    else if ((dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
                        && (dgvr.Cells[cl2KensaShubetsuKako.Index].Value.ToString() == "0")
                        && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))
                    {
                        CheckKakuninKensaShubetsuKako(dgvr, cl2Col.Index);
                    }
                }
                #endregion

                #region 確認検査種別の判定(BOD基準値オーバー)
                if (((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[bod1KensaShubetsuBodOver.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[bod2KensaShubetsuBodOver.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1")))
                {
                    CheckKakuninKensaShubetsuBodOver(dgvr);
                }
                #endregion

                #region 確認検査種別の判定(塩化物イオン確認検査)
                if (((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[cl1KensaShubetsuEnkaIon.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))

                    || ((dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[cl2KensaShubetsuEnkaIon.Index].Value.ToString() == "0")
                    && (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1")))
                {
                    CheckKakuninKensaShubetsuEnkaIon(dgvr);
                }
                #endregion

                // 確認検査種別の判定結果を表示
                DispKakuninKensaShubetsu(dgvr);

                // 異常種別の判定
                CheckIjyoShubetsu(dgvr);

                // 適正の判定
                CheckTekisei(dgvr);

                // 背景色の判定
                CheckBackColor(dgvr);

                // 各検査項目の状態設定
                SetKmkPropaty(dgvr);

                // 外観検査
                if (gaikanKensaRadioButton.Checked == true)
                {
                    if (dgvr.Cells[kensaJyokyoCol.Index].Value.ToString() != "003")
                    {
                        // 表示のみ
                        dgvr.ReadOnly = true;
                        // 背景：黄色
                        dgvr.DefaultCellStyle.BackColor = Color.LightGray;
                    }

                    // 2015.01.06 toyoda Delete Start 各項目の編集制御が上書きされている為削除
                    //else
                    //{
                    //    // 正常；通常
                    //    dgvr.ReadOnly = false;
                    //    dgvr.DefaultCellStyle.BackColor = Color.White;
                    //}
                    // 2015.01.06 toyoda Delete End
                }
            }

            // 20150129 sou Start
            // 検査種別毎の表示項目切り替え
            ChangeDisplayColumn();
            // 20150129 sou End
        }
        #endregion

        #region 該当データ取得
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchDataTable GetData(IKensakuBtnClickALInput alInput)
        {
            // 依頼情報を検索
            //IKensakuBtnClickALInput alInput = new KensakuBtnClickALInput();
            //MakeSearchCond(alInput);
            IKensakuBtnClickALOutput alOutput = new KensakuBtnClickApplicationLogic().Execute(alInput);

            // 件数判定
            if (alOutput.HoteiKensaDaichoDT == null || alOutput.HoteiKensaDaichoDT.Count == 0)
            {
                hoteiKensaDaichoCountLabel.Text = "0件";

                // リスト数 = 0
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            else
            {
                hoteiKensaDaichoCountLabel.Text = alOutput.HoteiKensaDaichoDT.Count.ToString() + "件";
            }

            return alOutput.HoteiKensaDaichoDT;
        }
        #endregion

        #region 検索条件設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/29  宗        検査種別で試験項目コードの取得元を切り替える
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSearchCond(IKensakuBtnClickALInput alInput)
        {
            // 各項目の値設定
            HoteiKensaDaichoSearchCond searchCond = new HoteiKensaDaichoSearchCond();

            // 支所コード
            // 20150120 sou Start
            //searchCond.ShishoCd = LoginUserShozokuShishoCd;
            searchCond.ShishoCd = shishoComboBox.SelectedValue.ToString();
            // 20150120 sou End

            // 試験項目コードを設定
            // 20150129 sou Start
            //searchCond.KmkCdPh = GetKmkCd(ConstRenbanPh);
            //searchCond.KmkCdTr = GetKmkCd(ConstRenbanTr);
            //searchCond.KmkCdBod = GetKmkCd(ConstRenbanBod);
            //searchCond.KmkCdZanen = GetKmkCd(ConstRenbanZanen);
            //searchCond.KmkCdCl = GetKmkCd(ConstRenbanCl);
            if (suishitsuKensaRadioButton.Checked == true)
            {
                searchCond.KmkCdPh = GetKmkCd(ConstRenbanPh);
                searchCond.KmkCdTr = GetKmkCd(ConstRenbanTr);
                searchCond.KmkCdBod = GetKmkCd(ConstRenbanBod);
                searchCond.KmkCdZanen = GetKmkCd(ConstRenbanZanen);
                searchCond.KmkCdCl = GetKmkCd(ConstRenbanCl);
                searchCond.KmkCdAtubod = string.Empty;
            }
            else
            {
                searchCond.KmkCdPh = string.Empty;
                searchCond.KmkCdTr = string.Empty;
                searchCond.KmkCdBod = GetKmkGaikanCd(ConstGaikanRenbanBod);
                searchCond.KmkCdZanen = string.Empty;
                searchCond.KmkCdCl = GetKmkGaikanCd(ConstGaikanRenbanCl);
                searchCond.KmkCdAtubod = GetKmkGaikanCd(ConstGaikanRenbanAtubod);
            }
            // 20150129 sou End

            // 年度
            searchCond.Nendo = nendoTextBox.Text;

            // 依頼受付日入力区分
            if (iraiUketsukeDtCheckBox.Checked == true)
            {
                searchCond.IraiUketsukeDtInputKbn = "1";
            }
            else
            {
                searchCond.IraiUketsukeDtInputKbn = "0";
            }
            // 依頼受付日(開始)
            searchCond.IraiUketsukeFromDt = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
            // 依頼受付日(開始)
            searchCond.IraiUketsukeToDt = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");

            // 11条水質
            if (suishitsuKensaRadioButton.Checked == true)
            {
                searchCond.KensaKbnSuisitsu = "1";
            }
            else
            {
                searchCond.KensaKbnSuisitsu = "0";
            }
            // 外観検査
            if (gaikanKensaRadioButton.Checked == true)
            {
                searchCond.KensaKbnGaikan = "1";
            }
            else
            {
                searchCond.KensaKbnGaikan = "0";
            }

            // 依頼No(開始)
            searchCond.IraiNoFrom = string.IsNullOrEmpty(iraiNoFromTextBox.Text) == true ? string.Empty : iraiNoFromTextBox.Text.PadLeft(6, '0');
            // 依頼No(終了)
            searchCond.IraiNoTo = string.IsNullOrEmpty(iraiNoToTextBox.Text) == true ? string.Empty : iraiNoToTextBox.Text.PadLeft(6, '0');

            alInput.SearchCond = searchCond;
        }
        #endregion

        #region 取得データを設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetData
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/08  宗        塩化物イオン過去を関数で取得するように変更
        /// 2015/01/22  宗        試験項目毎の桁数制限を追加
        /// 2015/01/29  宗        外観検査時に表示する試験項目を追加
        ///                       検査種別毎に表示項目を切り替える(水質検査=5件、外観検査=3件)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetData(KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchRow row)
        {
            // 未入力項目は、該当項目を、黄色で表示する
            // 確定検査対象の場合は、該当項目を、青色で表示する

            // 初回検査結果＆確定検査結果設定
            var newRow = new DataGridViewRow();
            newRow.CreateCells(this.listDataGridView);

            // 検査依頼法定区分
            newRow.Cells[kensaIraiHoteiKbnCol.Index].Value = row.KensaKekkaIraiHoteiKbn;
            // 検査依頼保健所コード
            newRow.Cells[kensaIraiHokenjoCdCol.Index].Value = row.KensaKekkaIraiHokenjoCd;
            // 検査依頼年度
            newRow.Cells[kensaIraiNendoCol.Index].Value = row.KensaKekkaIraiNendo;
            // 検査依頼連番
            newRow.Cells[kensaIraiRenbanCol.Index].Value = row.KensaKekkaIraiRenban;
            // 浄化槽保健所コード
            newRow.Cells[jokasoHokenjoCdCol.Index].Value = row.KensaIraiJokasoHokenjoCd;
            // 浄化槽台帳登録年度
            newRow.Cells[jokasoTorokuNendoCol.Index].Value = row.KensaIraiJokasoTorokuNendo;
            // 浄化槽台帳連番
            newRow.Cells[jokasoRenbanCol.Index].Value = row.KensaIraiJokasoRenban;
            // 採水員コード
            newRow.Cells[saisuiinCdCol.Index].Value = row.IsKensaIraiSaisuiinCdNull() == true ? string.Empty : row.KensaIraiSaisuiinCd;
            // 放流先コード
            newRow.Cells[horyusakiCdCol.Index].Value = row.IsKensaIraiHoryusakiCdNull() == true ? string.Empty : row.KensaIraiHoryusakiCd;
            // 再採水区分
            newRow.Cells[saisaisuiKbnCol.Index].Value = row.SaisaisuiKbn;
            // 再採水
            newRow.Cells[saisaisuiDispCol.Index].Value = row.SaisaisuiKbn == "1" ? "●" : string.Empty;
            // 検査区分
            newRow.Cells[kensaKbnCol.Index].Value = row.KensaKbn;
            // 区分
            newRow.Cells[kensaKbnNmCol.Index].Value = hoteiKbnHantei(row.KensaKekkaIraiHoteiKbn,
                row.IsKensaIraiScreeningKbnNull() == true ? string.Empty : row.KensaIraiScreeningKbn);
            // 依頼年度
            newRow.Cells[iraiNendoCol.Index].Value = row.IraiNendo;
            // 支所コード
            newRow.Cells[shishoCdCol.Index].Value = row.ShishoCd;
            // 依頼No
            newRow.Cells[iraiNoCol.Index].Value = row.SuishitsuKensaIraiNo;
            // スクリーニング候補
            newRow.Cells[screeningKohoCol.Index].Value = row.IsScreeningKohoNull() == true ? string.Empty : row.ScreeningKoho;
            // フォロー候補
            newRow.Cells[followKohoCol.Index].Value = row.IsFollowKohoNull() == true ? string.Empty : row.FollowKoho;
            // クロスチェック異常（水質判定表）
            newRow.Cells[crossCheckSuishitsuCol.Index].Value = row.IsCrossCheckSuishitsuNull() == true ? string.Empty : row.CrossCheckSuishitsu;
            // クロスチェック異常（過去履歴）
            newRow.Cells[crossCheckKakoCol.Index].Value = row.IsCrossCheckKakoNull() == true ? string.Empty : row.CrossCheckKako;
            // 異常種別
            newRow.Cells[ijyoShubetsuCol.Index].Value = string.Empty;
            // 適正判定コード
            newRow.Cells[tekiseiHanteiCdCol.Index].Value = row.IsHanteiCdNull() == true ? string.Empty : row.HanteiCd;
            // 適正判定
            newRow.Cells[tekiseiHanteiCol.Index].Value = row.IsConstNmNull() == true ? string.Empty : row.ConstNm;
            // 処理方式区分
            newRow.Cells[shoriHoshikiCdCol.Index].Value =
                row.IsKensaIraiShorihoshikiKbnNull() == true ? string.Empty : row.KensaIraiShorihoshikiKbn;
            // 処理方式名
            newRow.Cells[syoriHoshikiNmCol.Index].Value =
                row.IsShoriHoshikiShubetsuNmNull() == true ? string.Empty : row.ShoriHoshikiShubetsuNm;
            // 処理目標水質
            newRow.Cells[shorimokuhyoSuishitsuCol.Index].Value =
                row.IsKensaIraiShorimokuhyoSuishitsuNull() == true ? string.Empty : row.KensaIraiShorimokuhyoSuishitsu;
            // スクリーニング指示済フラグ
            newRow.Cells[screeningFlgCol.Index].Value = ScreeningShijiHantei(
                row.IsKensaIraiScreeningKbnNull() == true ? string.Empty : row.KensaIraiScreeningKbn,
                row.SaisaisuiKbn);
            // スクリーニング指示
            newRow.Cells[screeningCol.Index].Value = (newRow.Cells[screeningFlgCol.Index].Value.ToString() == "1" ? true : false);
            // 課長検印（その他）
            newRow.Cells[kachoKeninEtcCol.Index].Value = (row.SaisaisuiKbn == "0" ? row.KachoKeninKbnScreening : row.KachoKeninKbn);
            // 副課長検印（その他）
            newRow.Cells[hukukachoKeninEtcCol.Index].Value = (row.SaisaisuiKbn == "0" ? row.HukuKachoKeninKbnScreening : row.HukuKachoKeninKbn);
            // 課長検印
            newRow.Cells[kachoKeninCol.Index].Value = (row.SaisaisuiKbn == "0" ?
                (row.KachoKeninKbn == "1" ? true : false) : (row.KachoKeninKbnScreening == "1" ? true : false));
            // 副課長検印
            newRow.Cells[hukukachoKeninCol.Index].Value = (row.SaisaisuiKbn == "0" ?
                (row.HukuKachoKeninKbn == "1" ? true : false) : (row.HukuKachoKeninKbnScreening == "1" ? true : false));
            #region ph
            // 結果入力区分（pH1）
            newRow.Cells[kekkaNyuryokuPh1Col.Index].Value = row.IsPH1KekkaNyuryokuNull() == true ? string.Empty : row.PH1KekkaNyuryoku;
            //if (newRow.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "1")
            if ((newRow.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "1") && (suishitsuKensaRadioButton.Checked))
            {
                // pH1
                newRow.Cells[ph1Col.Index].Value = row.IsPH1KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanPh), row.PH1KekkaValue.ToString());
                // 温度1
                //newRow.Cells[ondo1Col.Index].Value = row.IsPH1KekkaOndoNull() == true ? string.Empty : row.PH1KekkaOndo.ToString();
                newRow.Cells[ondo1Col.Index].Value = row.IsPH1KekkaOndoNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(ConstRenbanOndo, row.PH1KekkaOndo.ToString());
                // 結果コード（pH1）
                newRow.Cells[ph1KekkaCdCol.Index].Value = row.IsPH1KekkaCdNull() == true ? string.Empty : row.PH1KekkaCd;
                // 確認検査種別（pH1）
                newRow.Cells[kakuninKensaPh1Col.Index].Value = row.IsPH1KensaShubetsuNull() == true ? string.Empty : row.PH1KensaShubetsu;
            }
            // 採用値（pH1）
            newRow.Cells[saiyotiPh1Col.Index].Value = row.IsPH1SaiyoKbnNull() == true ? false : (row.PH1SaiyoKbn == "1" ? true : false);
            // pH1確認検査種別（過去との比較）
            newRow.Cells[ph1KensaShubetsuKako.Index].Value = row.IsPH1KensaShubetsuKakoNull() == true ? string.Empty : row.PH1KensaShubetsuKako;
            // 結果入力区分（pH2）
            newRow.Cells[kekkaNyuryokuPh2Col.Index].Value = row.IsPH2KekkaNyuryokuNull() == true ? string.Empty : row.PH2KekkaNyuryoku;
            //if (newRow.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "1")
            if ((newRow.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "1") && (suishitsuKensaRadioButton.Checked))
            {
                // pH2
                newRow.Cells[ph2Col.Index].Value = row.IsPH2KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanPh), row.PH2KekkaValue.ToString());
                // 温度2
                //newRow.Cells[ondo2Col.Index].Value = row.IsPH2KekkaOndoNull() == true ? string.Empty : row.PH2KekkaOndo.ToString();
                newRow.Cells[ondo2Col.Index].Value = row.IsPH2KekkaOndoNull() == true ? string.Empty 
                    : KensaHanteiUtility.HyojiKetasuHosei(ConstRenbanOndo, row.PH2KekkaOndo.ToString());
                // 結果コード（pH2）
                newRow.Cells[ph2KekkaCdCol.Index].Value = row.IsPH2KekkaCdNull() == true ? string.Empty : row.PH2KekkaCd;
                // 確認検査種別（pH2）
                newRow.Cells[kakuninKensaPh2Col.Index].Value = row.IsPH2KensaShubetsuNull() == true ? string.Empty : row.PH2KensaShubetsu;
            }
            // 採用値（pH2）
            newRow.Cells[saiyotiPh2Col.Index].Value = row.IsPH2SaiyoKbnNull() == true ? false : (row.PH2SaiyoKbn == "1" ? true : false);
            // pH2確認検査種別（過去との比較）
            newRow.Cells[ph2KensaShubetsuKako.Index].Value = row.IsPH2KensaShubetsuKakoNull() == true ? string.Empty : row.PH2KensaShubetsuKako;
            // 更新区分（過去との比較）pH
            newRow.Cells[koshinKbnKakoPh.Index].Value = "0";
            #endregion

            #region 透視度
            // 結果入力区分（透視度1）
            newRow.Cells[kekkaNyuryokuTr1Col.Index].Value = row.IsTR1KekkaNyuryokuNull() == true ? string.Empty : row.TR1KekkaNyuryoku;
            //if (newRow.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1")
            if ((newRow.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1") && (suishitsuKensaRadioButton.Checked))
            {
                // 透視度1
                newRow.Cells[tr1Col.Index].Value = row.IsTR1KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTr), row.TR1KekkaValue.ToString());
                // 結果コード（透視度1）
                newRow.Cells[tr1KekkaCdCol.Index].Value = row.IsTR1KekkaCdNull() == true ? string.Empty : row.TR1KekkaCd;
                // 確認検査種別（透視度1）
                newRow.Cells[kakuninKensaTr1Col.Index].Value = row.IsTR1KensaShubetsuNull() == true ? string.Empty : row.TR1KensaShubetsu;
            }
            // 採用値（透視度1）
            newRow.Cells[saiyotiTr1Col.Index].Value = row.IsTR1SaiyoKbnNull() == true ? false : (row.TR1SaiyoKbn == "1" ? true : false);
            // 透視度1確認検査種別（過去との比較）
            newRow.Cells[tr1KensaShubetsuKako.Index].Value = row.IsTR1KensaShubetsuKakoNull() == true ? string.Empty : row.TR1KensaShubetsuKako;
            // 結果入力区分（透視度2）
            newRow.Cells[kekkaNyuryokuTr2Col.Index].Value = row.IsTR2KekkaNyuryokuNull() == true ? string.Empty : row.TR2KekkaNyuryoku;
            //if (newRow.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1")
            if ((newRow.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1") && (suishitsuKensaRadioButton.Checked))
            {
                // 透視度2
                newRow.Cells[tr2Col.Index].Value = row.IsTR2KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanTr), row.TR2KekkaValue.ToString());
                // 結果コード（透視度2）
                newRow.Cells[tr2KekkaCdCol.Index].Value = row.IsTR2KekkaCdNull() == true ? string.Empty : row.TR2KekkaCd;
                // 確認検査種別（透視度2）
                newRow.Cells[kakuninKensaTr2Col.Index].Value = row.IsTR2KensaShubetsuNull() == true ? string.Empty : row.TR2KensaShubetsu;
            }
            // 採用値（透視度2）
            newRow.Cells[saiyotiTr2Col.Index].Value = row.IsTR2SaiyoKbnNull() == true ? false : (row.TR2SaiyoKbn == "1" ? true : false);
            // 透視度2確認検査種別（過去との比較）
            newRow.Cells[tr2KensaShubetsuKako.Index].Value = row.IsTR2KensaShubetsuKakoNull() == true ? string.Empty : row.TR2KensaShubetsuKako;
            // 更新区分（過去との比較）透視度
            newRow.Cells[koshinKbnKakoTr.Index].Value = "0";
            #endregion

            #region BOD
            // 結果入力区分（BOD1）
            newRow.Cells[kekkaNyuryokuBod1Col.Index].Value = row.IsBOD1KekkaNyuryokuNull() == true ? string.Empty : row.BOD1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1")
            {
                if (suishitsuKensaRadioButton.Checked)
                {
                    // BOD1
                    newRow.Cells[bod1Col.Index].Value = row.IsBOD1KekkaValueNull() == true ? string.Empty
                        : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanBod), row.BOD1KekkaValue.ToString());
                }
                else
                {
                    // BOD1
                    newRow.Cells[bod1Col.Index].Value = row.IsBOD1KekkaValueNull() == true ? string.Empty
                        : KensaHanteiUtility.HyojiKetasuHosei(GetKmkGaikanCd(ConstGaikanRenbanBod), row.BOD1KekkaValue.ToString());
                }
                // 結果コード（BOD1）
                newRow.Cells[bod1KekkaCdCol.Index].Value = row.IsBOD1KekkaCdNull() == true ? string.Empty : row.BOD1KekkaCd;
                // 確認検査種別（BOD1）
                newRow.Cells[kakuninKensaBod1Col.Index].Value = row.IsBOD1KensaShubetsuNull() == true ? string.Empty : row.BOD1KensaShubetsu;
            }
            // 採用値（BOD1）
            newRow.Cells[saiyotiBod1Col.Index].Value = row.IsBOD1SaiyoKbnNull() == true ? false : (row.BOD1SaiyoKbn == "1" ? true : false);
            // BOD1確認検査種別（過去との比較）
            newRow.Cells[bod1KensaShubetsuKako.Index].Value = row.IsBOD1KensaShubetsuKakoNull() == true ? string.Empty : row.BOD1KensaShubetsuKako;
            // 結果入力区分（BOD2）
            newRow.Cells[kekkaNyuryokuBod2Col.Index].Value = row.IsBOD2KekkaNyuryokuNull() == true ? string.Empty : row.BOD2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1")
            {
                if (suishitsuKensaRadioButton.Checked)
                {
                    // BOD2
                    newRow.Cells[bod2Col.Index].Value = row.IsBOD2KekkaValueNull() == true ? string.Empty
                        : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanBod), row.BOD2KekkaValue.ToString());
                }
                else
                {
                    // BOD2
                    newRow.Cells[bod2Col.Index].Value = row.IsBOD2KekkaValueNull() == true ? string.Empty
                        : KensaHanteiUtility.HyojiKetasuHosei(GetKmkGaikanCd(ConstGaikanRenbanBod), row.BOD2KekkaValue.ToString());
                }
                // 結果コード（BOD2）
                newRow.Cells[bod2KekkaCdCol.Index].Value = row.IsBOD2KekkaCdNull() == true ? string.Empty : row.BOD2KekkaCd;
                // 確認検査種別（BOD2）
                newRow.Cells[kakuninKensaBod2Col.Index].Value = row.IsBOD2KensaShubetsuNull() == true ? string.Empty : row.BOD2KensaShubetsu;
            }
            // 採用値（BOD2）
            newRow.Cells[saiyotiBod2Col.Index].Value = row.IsBOD2SaiyoKbnNull() == true ? false : (row.BOD2SaiyoKbn == "1" ? true : false);
            // BOD2確認検査種別（過去との比較）
            newRow.Cells[bod2KensaShubetsuKako.Index].Value = row.IsBOD2KensaShubetsuKakoNull() == true ? string.Empty : row.BOD2KensaShubetsuKako;
            // 更新区分（過去との比較）BOD
            newRow.Cells[koshinKbnKakoBod.Index].Value = "0";
            #endregion

            #region 残塩
            // 結果入力区分（残塩1）
            newRow.Cells[kekkaNyuryokuZanen1Col.Index].Value = row.IsZANEN1KekkaNyuryokuNull() == true ? string.Empty : row.ZANEN1KekkaNyuryoku;
            //if (newRow.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "1")
            if ((newRow.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "1") && (suishitsuKensaRadioButton.Checked))
            {
                // 残塩1
                newRow.Cells[zanen1Col.Index].Value = row.IsZANEN1KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanZanen), row.ZANEN1KekkaValue.ToString());
                // 結果コード（残塩1）
                newRow.Cells[zanen1KekkaCdCol.Index].Value = row.IsZANEN1KekkaCdNull() == true ? string.Empty : row.ZANEN1KekkaCd;
                // 確認検査種別（残塩1）
                newRow.Cells[kakuninKensaZanen1Col.Index].Value = row.IsZANEN1KensaShubetsuNull() == true ? string.Empty : row.ZANEN1KensaShubetsu;
            }
            // 採用値（残塩1）
            newRow.Cells[saiyotiZanen1Col.Index].Value = row.IsZANEN1SaiyoKbnNull() == true ? false : (row.ZANEN1SaiyoKbn == "1" ? true : false);
            // 残塩1確認検査種別（過去との比較）
            newRow.Cells[zanen1KensaShubetsuKako.Index].Value = row.IsZANEN1KensaShubetsuKakoNull() == true ? string.Empty : row.ZANEN1KensaShubetsuKako;
            // 結果入力区分（残塩2）
            newRow.Cells[kekkaNyuryokuZanen2Col.Index].Value = row.IsZANEN2KekkaNyuryokuNull() == true ? string.Empty : row.ZANEN2KekkaNyuryoku;
            //if (newRow.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "1")
            if ((newRow.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "1") && (suishitsuKensaRadioButton.Checked))
            {
                // 残塩2
                newRow.Cells[zanen2Col.Index].Value = row.IsZANEN2KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanZanen), row.ZANEN2KekkaValue.ToString());
                // 結果コード（残塩2）
                newRow.Cells[zanen2KekkaCdCol.Index].Value = row.IsZANEN2KekkaCdNull() == true ? string.Empty : row.ZANEN2KekkaCd;
                // 確認検査種別（残塩2）
                newRow.Cells[kakuninKensaZanen2Col.Index].Value = row.IsZANEN2KensaShubetsuNull() == true ? string.Empty : row.ZANEN2KensaShubetsu;
            }
            // 採用値（残塩2）
            newRow.Cells[saiyotiZanen2Col.Index].Value = row.IsZANEN2SaiyoKbnNull() == true ? false : (row.ZANEN2SaiyoKbn == "1" ? true : false);
            // 残塩2確認検査種別（過去との比較）
            newRow.Cells[zanen2KensaShubetsuKako.Index].Value = row.IsZANEN2KensaShubetsuKakoNull() == true ? string.Empty : row.ZANEN2KensaShubetsuKako;
            // 更新区分（過去との比較）残塩
            newRow.Cells[koshinKbnKakoZanen.Index].Value = "0";
            #endregion

            #region 塩化物イオン
            // 結果入力区分（塩化物イオン1）
            newRow.Cells[kekkaNyuryokuCl1Col.Index].Value = row.IsCL1KekkaNyuryokuNull() == true ? string.Empty : row.CL1KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1")
            {
                if (suishitsuKensaRadioButton.Checked)
                {
                    // 塩化物イオン1
                    newRow.Cells[cl1Col.Index].Value = row.IsCL1KekkaValueNull() == true ? string.Empty
                        : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCl), row.CL1KekkaValue.ToString());
                }
                else
                {
                    // 塩化物イオン1
                    newRow.Cells[cl1Col.Index].Value = row.IsCL1KekkaValueNull() == true ? string.Empty
                        : KensaHanteiUtility.HyojiKetasuHosei(GetKmkGaikanCd(ConstGaikanRenbanCl), row.CL1KekkaValue.ToString());
                }
                // 結果コード（塩化物イオン1）
                newRow.Cells[cl1KekkaCdCol.Index].Value = row.IsCL1KekkaCdNull() == true ? string.Empty : row.CL1KekkaCd;
                // 確認検査種別（塩化物イオン1）
                newRow.Cells[kakuninKensaCl1Col.Index].Value = row.IsCL1KensaShubetsuNull() == true ? string.Empty : row.CL1KensaShubetsu;
            }
            // 採用値（塩化物イオン1）
            newRow.Cells[saiyotiCl1Col.Index].Value = row.IsCL1SaiyoKbnNull() == true ? false : (row.CL1SaiyoKbn == "1" ? true : false);
            // 塩化物イオン1確認検査種別（過去との比較）
            newRow.Cells[cl1KensaShubetsuKako.Index].Value = row.IsCL1KensaShubetsuKakoNull() == true ? string.Empty : row.CL1KensaShubetsuKako;
            // 結果入力区分（塩化物イオン2）
            newRow.Cells[kekkaNyuryokuCl2Col.Index].Value = row.IsCL2KekkaNyuryokuNull() == true ? string.Empty : row.CL2KekkaNyuryoku;
            if (newRow.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1")
            {
                if (suishitsuKensaRadioButton.Checked)
                {
                    // 塩化物イオン2
                    newRow.Cells[cl2Col.Index].Value = row.IsCL2KekkaValueNull() == true ? string.Empty
                        : KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCl), row.CL2KekkaValue.ToString());
                }
                else
                {
                    // 塩化物イオン2
                    newRow.Cells[cl2Col.Index].Value = row.IsCL2KekkaValueNull() == true ? string.Empty
                        : KensaHanteiUtility.HyojiKetasuHosei(GetKmkGaikanCd(ConstGaikanRenbanCl), row.CL2KekkaValue.ToString());
                }
                // 結果コード（塩化物イオン2）
                newRow.Cells[cl2KekkaCdCol.Index].Value = row.IsCL2KekkaCdNull() == true ? string.Empty : row.CL2KekkaCd;
                // 確認検査種別（塩化物イオン2）
                newRow.Cells[kakuninKensaCl2Col.Index].Value = row.IsCL2KensaShubetsuNull() == true ? string.Empty : row.CL2KensaShubetsu;
            }
            // 採用値（塩化物イオン2）
            newRow.Cells[saiyotiCl2Col.Index].Value = row.IsCL2SaiyoKbnNull() == true ? false : (row.CL2SaiyoKbn == "1" ? true : false);
            // 塩化物イオン2確認検査種別（過去との比較）
            newRow.Cells[cl2KensaShubetsuKako.Index].Value = row.IsCL2KensaShubetsuKakoNull() == true ? string.Empty : row.CL2KensaShubetsuKako;
            // 更新区分（過去との比較）塩化物イオン
            newRow.Cells[koshinKbnKakoCl.Index].Value = "0";
            #endregion

            // 20150129 sou Start 外観検査時の検査項目追加
            #region ATUBOD
            // 結果入力区分（ATUBOD1）
            newRow.Cells[kekkaNyuryokuAtubod1Col.Index].Value = row.IsATUBOD1KekkaNyuryokuNull() == true ? string.Empty : row.ATUBOD1KekkaNyuryoku;
            if ((newRow.Cells[kekkaNyuryokuAtubod1Col.Index].Value.ToString() == "1") && (gaikanKensaRadioButton.Checked))
            {
                // ATUBOD1
                newRow.Cells[atubod1Col.Index].Value = row.IsATUBOD1KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkGaikanCd(ConstGaikanRenbanAtubod), row.ATUBOD1KekkaValue.ToString());
                // 結果コード（ATUBOD1）
                newRow.Cells[atubod1KekkaCdCol.Index].Value = row.IsATUBOD1KekkaCdNull() == true ? string.Empty : row.ATUBOD1KekkaCd;
                // 確認検査種別（ATUBOD1）
                newRow.Cells[kakuninKensaAtubod1Col.Index].Value = row.IsATUBOD1KensaShubetsuNull() == true ? string.Empty : row.ATUBOD1KensaShubetsu;
            }
            // 採用値（ATUBOD1）
            newRow.Cells[saiyotiAtubod1Col.Index].Value = row.IsATUBOD1SaiyoKbnNull() == true ? false : (row.ATUBOD1SaiyoKbn == "1" ? true : false);
            // ATUBOD1確認検査種別（過去との比較）
            newRow.Cells[atubod1KensaShubetsuKako.Index].Value = row.IsATUBOD1KensaShubetsuKakoNull() == true ? string.Empty : row.ATUBOD1KensaShubetsuKako;
            // 結果入力区分（ATUBOD2）
            newRow.Cells[kekkaNyuryokuAtubod2Col.Index].Value = row.IsATUBOD2KekkaNyuryokuNull() == true ? string.Empty : row.ATUBOD2KekkaNyuryoku;
            if ((newRow.Cells[kekkaNyuryokuAtubod2Col.Index].Value.ToString() == "1") && (gaikanKensaRadioButton.Checked))
            {
                // ATUBOD2
                newRow.Cells[atubod2Col.Index].Value = row.IsATUBOD2KekkaValueNull() == true ? string.Empty
                    : KensaHanteiUtility.HyojiKetasuHosei(GetKmkGaikanCd(ConstGaikanRenbanAtubod), row.ATUBOD2KekkaValue.ToString());
                // 結果コード（ATUBOD2）
                newRow.Cells[atubod2KekkaCdCol.Index].Value = row.IsATUBOD2KekkaCdNull() == true ? string.Empty : row.ATUBOD2KekkaCd;
                // 確認検査種別（ATUBOD2）
                newRow.Cells[kakuninKensaAtubod2Col.Index].Value = row.IsATUBOD2KensaShubetsuNull() == true ? string.Empty : row.ATUBOD2KensaShubetsu;
            }
            // 採用値（ATUBOD2）
            newRow.Cells[saiyotiAtubod2Col.Index].Value = row.IsATUBOD2SaiyoKbnNull() == true ? false : (row.ATUBOD2SaiyoKbn == "1" ? true : false);
            // ATUBOD2確認検査種別（過去との比較）
            newRow.Cells[atubod2KensaShubetsuKako.Index].Value = row.IsATUBOD2KensaShubetsuKakoNull() == true ? string.Empty : row.ATUBOD2KensaShubetsuKako;
            // 更新区分（過去との比較）ATUBOD
            newRow.Cells[koshinKbnKakoAtubod.Index].Value = "0";
            #endregion
            // 20150129 sou End

            // 20150108 sou Start
            // 塩化物イオン過去
            #region to be removed
            //newRow.Cells[clKakoCol.Index].Value =
            //    (row.IsEnkaIonKako1Null() == true ? string.Empty : (KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCl), row.EnkaIonKako1.ToString()) + " ")) +
            //    (row.IsEnkaIonKako2Null() == true ? string.Empty : (KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCl), row.EnkaIonKako2.ToString()) + " ")) +
            //    (row.IsEnkaIonKako3Null() == true ? string.Empty : (KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCl), row.EnkaIonKako3.ToString()) + " ")) +
            //    (row.IsEnkaIonKako4Null() == true ? string.Empty : (KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCl), row.EnkaIonKako4.ToString()) + " ")) +
            //    (row.IsEnkaIonKako5Null() == true ? string.Empty : (KensaHanteiUtility.HyojiKetasuHosei(GetKmkCd(ConstRenbanCl), row.EnkaIonKako5.ToString())));
            #endregion
            newRow.Cells[clKakoCol.Index].Value = 
                HoteiKensaUtility.GetEnkaIonKako(row.KensaIraiJokasoHokenjoCd, row.KensaIraiJokasoTorokuNendo, row.KensaIraiJokasoRenban, row.UketsukeDt, 5);
            //20150108 sou End
            // 結果確定日
            newRow.Cells[kekkaKakuteiDtCol.Index].Value = row.IsKensaKekkaKakuteiDtNull() == true ? string.Empty : row.KensaKekkaKakuteiDt;
            // 更新区分(検印)
            newRow.Cells[koshinKbnKenin.Index].Value = "0";
            // 更新区分(スクリーニング候補)
            newRow.Cells[koshinKbnScreeningKoho.Index].Value = "0";
            // 更新区分(クロスチェック異常(水質判定表))
            newRow.Cells[koshinKbnCrossSuishitsu.Index].Value = "0";
            // 更新区分(クロスチェック異常(過去履歴))
            newRow.Cells[koshinKbnCrossKako.Index].Value = "0";
            // 更新区分(pH)
            newRow.Cells[koshinKbnPh.Index].Value = "0";
            // 更新区分(透視度)
            newRow.Cells[koshinKbnTr.Index].Value = "0";
            // 更新区分(BOD)
            newRow.Cells[koshinKbnBod.Index].Value = "0";
            // 更新区分(残塩)
            newRow.Cells[koshinKbnZanen.Index].Value = "0";
            // 更新区分(塩化物イオン)
            newRow.Cells[koshinKbnCl.Index].Value = "0";
            // 20150129 sou Start
            // 更新区分(ATUBOD)
            newRow.Cells[koshinKbnAtubod.Index].Value = "0";
            // 20150129 sou End
            // 更新区分（BOD/透視度）
            newRow.Cells[koshinKbnBodTr.Index].Value = "0";
            // 更新区分（BOD基準値オーバー）
            newRow.Cells[koshinKbnBodOver.Index].Value = "0";
            // 更新区分（塩化物イオン確認検査）
            newRow.Cells[koshinKbnClKakunin.Index].Value = "0";
            // BOD1確認検査種別（BOD/透視度）
            newRow.Cells[bod1KensaShubetsuBodTr.Index].Value = row.IsBOD1KensaShubetsuBodTrNull() == true ? string.Empty : row.BOD1KensaShubetsuBodTr;
            // BOD2確認検査種別（BOD/透視度）
            newRow.Cells[bod2KensaShubetsuBodTr.Index].Value = row.IsBOD2KensaShubetsuBodTrNull() == true ? string.Empty : row.BOD2KensaShubetsuBodTr;
            // 透視度1確認検査種別（BOD/透視度）
            newRow.Cells[tr1KensaShubetsuBodTr.Index].Value = row.IsTR1KensaShubetsuBodTrNull() == true ? string.Empty : row.TR1KensaShubetsuBodTr;
            // 透視度2確認検査種別（BOD/透視度）
            newRow.Cells[tr2KensaShubetsuBodTr.Index].Value = row.IsTR2KensaShubetsuBodTrNull() == true ? string.Empty : row.TR2KensaShubetsuBodTr;
            // 20150129 sou Start
            // ATUBOD1確認検査種別（BOD/透視度）
            newRow.Cells[atubod1KensaShubetsuBodTr.Index].Value = row.IsATUBOD1KensaShubetsuBodTrNull() == true ? string.Empty : row.ATUBOD1KensaShubetsuBodTr;
            // ATUBOD2確認検査種別（BOD/透視度）
            newRow.Cells[atubod2KensaShubetsuBodTr.Index].Value = row.IsATUBOD2KensaShubetsuBodTrNull() == true ? string.Empty : row.ATUBOD2KensaShubetsuBodTr;
            // 20150129 sou End
            // BOD1確認検査種別（BOD基準値オーバー）
            newRow.Cells[bod1KensaShubetsuBodOver.Index].Value = row.IsBOD1KensaShubetsuBodOverNull() == true ? string.Empty : row.BOD1KensaShubetsuBodOver;
            // BOD2確認検査種別（BOD基準値オーバー）
            newRow.Cells[bod2KensaShubetsuBodOver.Index].Value = row.IsBOD2KensaShubetsuBodOverNull() == true ? string.Empty : row.BOD2KensaShubetsuBodOver;
            // 20150129 sou Start
            // ATUBOD1確認検査種別（BOD基準値オーバー）
            newRow.Cells[atubod1KensaShubetsuBodOver.Index].Value = row.IsATUBOD1KensaShubetsuBodOverNull() == true ? string.Empty : row.ATUBOD1KensaShubetsuBodOver;
            // ATUBOD2確認検査種別（BOD基準値オーバー）
            newRow.Cells[atubod2KensaShubetsuBodOver.Index].Value = row.IsATUBOD2KensaShubetsuBodOverNull() == true ? string.Empty : row.ATUBOD2KensaShubetsuBodOver;
            // 20150129 sou End
            // 塩化物イオン1確認検査種別（塩化物イオン確認検査）
            newRow.Cells[cl1KensaShubetsuEnkaIon.Index].Value = row.IsCL1KensaShubetsuEnkaIonNull() == true ? string.Empty : row.CL1KensaShubetsuEnkaIon;
            // 塩化物イオン2確認検査種別（塩化物イオン確認検査）
            newRow.Cells[cl2KensaShubetsuEnkaIon.Index].Value = row.IsCL2KensaShubetsuEnkaIonNull() == true ? string.Empty : row.CL2KensaShubetsuEnkaIon;
            // 検査状況
            newRow.Cells[kensaJyokyoCol.Index].Value = row.IsKensaKekkaKensaJoukyouKbnNull() == true ? string.Empty : row.KensaKekkaKensaJoukyouKbn;
            // 更新日(検査依頼テーブル)
            newRow.Cells[iraiUpdateDtCol.Index].Value = row.IraiUpdateDt.ToString();
            // 更新日(検査結果テーブル)
            newRow.Cells[kekkaUpdateDtCol.Index].Value = row.IsKekkaUpdateDtNull() == true ? string.Empty : row.KekkaUpdateDt.ToString();
            // 更新日(再採水テーブル)
            newRow.Cells[saisaisuiUpdateDtCol.Index].Value = row.IsSaisaisuiUpdateDtNull() == true ? string.Empty : row.SaisaisuiUpdateDt.ToString();
            // 更新日(検査台帳ヘッダ)
            newRow.Cells[headerUpdateDtCol.Index].Value = row.HeaderUpdateDt.ToString();
            // 更新日(検査台帳明細(PH1))
            newRow.Cells[ph1UpdateDtCol.Index].Value = row.IsPH1UpdateDtNull() == true ? string.Empty : row.PH1UpdateDt.ToString();
            // 更新日(検査台帳明細(PH2))
            newRow.Cells[ph2UpdateDtCol.Index].Value = row.IsPH2UpdateDtNull() == true ? string.Empty : row.PH2UpdateDt.ToString();
            // 更新日(検査台帳明細(透視度1))
            newRow.Cells[tr1UpdateDtCol.Index].Value = row.IsTR1UpdateDtNull() == true ? string.Empty : row.TR1UpdateDt.ToString();
            // 更新日(検査台帳明細(透視度2))
            newRow.Cells[tr2UpdateDtCol.Index].Value = row.IsTR2UpdateDtNull() == true ? string.Empty : row.TR2UpdateDt.ToString();
            // 更新日(検査台帳明細(BOD1))
            newRow.Cells[bod1UpdateDtCol.Index].Value = row.IsBOD1UpdateDtNull() == true ? string.Empty : row.BOD1UpdateDt.ToString();
            // 更新日(検査台帳明細(BOD2))
            newRow.Cells[bod2UpdateDtCol.Index].Value = row.IsBOD2UpdateDtNull() == true ? string.Empty : row.BOD2UpdateDt.ToString();
            // 更新日(検査台帳明細(残塩1))
            newRow.Cells[zanen1UpdateDtCol.Index].Value = row.IsZANEN1UpdateDtNull() == true ? string.Empty : row.ZANEN1UpdateDt.ToString();
            // 更新日(検査台帳明細(残塩2))
            newRow.Cells[zanen2UpdateDtCol.Index].Value = row.IsZANEN2UpdateDtNull() == true ? string.Empty : row.ZANEN2UpdateDt.ToString();
            // 更新日(検査台帳明細(塩化物イオン1))
            newRow.Cells[cl1UpdateDtCol.Index].Value = row.IsCL1UpdateDtNull() == true ? string.Empty : row.CL1UpdateDt.ToString();
            // 更新日(検査台帳明細(塩化物イオン2))
            newRow.Cells[cl2UpdateDtCol.Index].Value = row.IsCL2UpdateDtNull() == true ? string.Empty : row.CL2UpdateDt.ToString();
            // 20150129 sou Start
            // 更新日(検査台帳明細(ATUBOD1))
            newRow.Cells[atubod1UpdateDtCol.Index].Value = row.IsATUBOD1UpdateDtNull() == true ? string.Empty : row.ATUBOD1UpdateDt.ToString();
            // 更新日(検査台帳明細(ATUBOD2))
            newRow.Cells[atubod2UpdateDtCol.Index].Value = row.IsATUBOD2UpdateDtNull() == true ? string.Empty : row.ATUBOD2UpdateDt.ToString();
            // 20150129 sou End
            //20150111 sou Start
            // 検査依頼受付日
            newRow.Cells[uketsukeDtCol.Index].Value = row.IsUketsukeDtNull() == true ? string.Empty : row.UketsukeDt;
            //20150111 sou End

            // 一覧に追加
            listDataGridView.Rows.Add(newRow);
        }
        #endregion

        #region 確認検査種別(BOD/透視度)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuBodTr
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/29  宗        ATUBODを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuBodTr(DataGridViewRow dgvr)
        {
            string paramBod = string.Empty;
            string paramTr = string.Empty;
            string paramAtubod = string.Empty;

            // BOD
            if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
            {
                paramBod = dgvr.Cells[bod1Col.Index].Value.ToString();
            }
            else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
            {
                paramBod = dgvr.Cells[bod2Col.Index].Value.ToString();
            }
            // 透視度
            if ((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))
            {
                paramTr = dgvr.Cells[tr1Col.Index].Value.ToString();
            }
            else if ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))
            {
                paramTr = dgvr.Cells[tr2Col.Index].Value.ToString();
            }
            // ATUBOD
            if ((dgvr.Cells[saiyotiAtubod1Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuAtubod1Col.Index].Value.ToString() == "1"))
            {
                paramAtubod = dgvr.Cells[atubod1Col.Index].Value.ToString();
            }
            else if ((dgvr.Cells[saiyotiAtubod2Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuAtubod2Col.Index].Value.ToString() == "1"))
            {
                paramAtubod = dgvr.Cells[atubod2Col.Index].Value.ToString();
            }

            // 判定
            string resA = KensaHanteiUtility.KakuninKensaShubetsuBODToshido(
                dgvr.Cells[horyusakiCdCol.Index].Value.ToString(),
                paramBod,
                paramTr,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );
            string resB = KensaHanteiUtility.KakuninKensaShubetsuBODToshido(
                dgvr.Cells[horyusakiCdCol.Index].Value.ToString(),
                paramAtubod,
                paramTr,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnBodTr.Index].Value = "1";

            // 判定結果設定
            if ((resA == "1") || (resB == "1"))
            {
                // BOD
                if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bod1KensaShubetsuBodTr.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bod2KensaShubetsuBodTr.Index].Value = "2";
                }
                // 透視度
                if ((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value = "2";
                }
                // ATUBOD
                if ((dgvr.Cells[saiyotiAtubod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuAtubod1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[atubod1KensaShubetsuBodTr.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiAtubod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuAtubod2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[atubod2KensaShubetsuBodTr.Index].Value = "2";
                }
            }
            else
            {
                // BOD
                if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bod1KensaShubetsuBodTr.Index].Value = "1";
                }
                else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bod2KensaShubetsuBodTr.Index].Value = "1";
                }
                // 透視度
                if ((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value = "1";
                }
                else if ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value = "1";
                }
                // ATUBOD
                if ((dgvr.Cells[saiyotiAtubod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuAtubod1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[atubod1KensaShubetsuBodTr.Index].Value = "1";
                }
                else if ((dgvr.Cells[saiyotiAtubod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuAtubod2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[atubod2KensaShubetsuBodTr.Index].Value = "1";
                }
            }
        }
        #endregion

        #region 確認検査種別(過去との比較)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuKako
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/08  宗        クロスチェックのフラグ設定条件を変更(項目毎に判定するのではなく全項目を判定した上で設定する)
        /// 2015/01/29  宗        ATUBODを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuKako(DataGridViewRow dgvr, int index)
        {
            // 試験項目コード
            string kmkCd = string.Empty;
            if (_searchAlInput.SearchCond.KensaKbnSuisitsu == "1")
            {
                if ((index == ph1Col.Index) || (index == ph2Col.Index))
                {
                    kmkCd = GetKmkCd(ConstRenbanPh);
                }
                else if ((index == tr1Col.Index) || (index == tr2Col.Index))
                {
                    kmkCd = GetKmkCd(ConstRenbanTr);
                }
                else if ((index == bod1Col.Index) || (index == bod2Col.Index))
                {
                    kmkCd = GetKmkCd(ConstRenbanBod);
                }
                else if ((index == zanen1Col.Index) || (index == zanen2Col.Index))
                {
                    kmkCd = GetKmkCd(ConstRenbanZanen);
                }
                else if ((index == cl1Col.Index) || (index == cl2Col.Index))
                {
                    kmkCd = GetKmkCd(ConstRenbanCl);
                }
            }
            else
            {
                if ((index == bod1Col.Index) || (index == bod2Col.Index))
                {
                    kmkCd = GetKmkGaikanCd(ConstGaikanRenbanBod);
                }
                else if ((index == cl1Col.Index) || (index == cl2Col.Index))
                {
                    kmkCd = GetKmkGaikanCd(ConstGaikanRenbanCl);
                }
                else if ((index == atubod1Col.Index) || (index == atubod2Col.Index))
                {
                    kmkCd = GetKmkGaikanCd(ConstGaikanRenbanAtubod);
                }
            }

            // 判定
            string hantei = string.Empty;
            hantei = KensaHanteiUtility.KakuninKensaShubetsuKakoHikaku(
                "1",
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString(),
                dgvr.Cells[uketsukeDtCol.Index].Value.ToString(),
                kmkCd,
                // 2015.01.06 toyoda Modify Start
                //decimal.Parse(dgvr.Cells[index].Value.ToString())
                decimal.Parse(dgvr.Cells[index].Value == null ? "0" : dgvr.Cells[index].Value.ToString())
                // 2015.01.06 toyoda Modify End
                );

            string res = string.Empty;
            if (hantei == "1")
            {
                //dgvr.Cells[crossCheckKakoCol.Index].Value = "1";
                res = "2";
            }
            else
            {
                //dgvr.Cells[crossCheckKakoCol.Index].Value = "0";
                res = "1";
            }

            // 更新状態設定
            dgvr.Cells[koshinKbnCrossKako.Index].Value = "1";
            if ((index == ph1Col.Index) || (index == ph2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoPh.Index].Value = "1";
            }
            else if ((index == tr1Col.Index) || (index == tr2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoTr.Index].Value = "1";
            }
            else if ((index == bod1Col.Index) || (index == bod2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoBod.Index].Value = "1";
            }
            else if ((index == zanen1Col.Index) || (index == zanen2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoZanen.Index].Value = "1";
            }
            else if ((index == cl1Col.Index) || (index == cl2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoCl.Index].Value = "1";
            }
            else if ((index == atubod1Col.Index) || (index == atubod2Col.Index))
            {
                dgvr.Cells[koshinKbnKakoAtubod.Index].Value = "1";
            }

            // 判定結果設定
            if ((index == ph1Col.Index) || (index == ph2Col.Index))
            {
                dgvr.Cells[index + 5].Value = res;
            }
            else
            {
                dgvr.Cells[index + 4].Value = res;
            }

            // 判定結果設定(クロスチェック(異常過去履歴))
            if (
                ((dgvr.Cells[saiyotiPh1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[ph1KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiPh2Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[ph2KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[tr1KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[tr2KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[bod1KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[bod2KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiZanen1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[zanen1KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiZanen2Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[zanen2KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[cl1KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[cl2KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiAtubod1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[atubod1KensaShubetsuKako.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[saiyotiAtubod2Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[atubod2KensaShubetsuKako.Index].Value.ToString() == "2"))
                )
            {
                dgvr.Cells[crossCheckKakoCol.Index].Value = "1";
            }
            else
            {
                dgvr.Cells[crossCheckKakoCol.Index].Value = "0";
            }
        }
        #endregion

        #region 確認検査種別(BOD基準値オーバー)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuBodOver
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuBodOver(DataGridViewRow dgvr)
        {
            string paramBod = string.Empty;
            string paramAtubod = string.Empty;

            // BOD
            if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
            {
                paramBod = dgvr.Cells[bod1Col.Index].Value.ToString();
            }
            else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
            {
                paramBod = dgvr.Cells[bod2Col.Index].Value.ToString();
            }
            // ATUBOD
            if ((dgvr.Cells[saiyotiAtubod1Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuAtubod1Col.Index].Value.ToString() == "1"))
            {
                paramAtubod = dgvr.Cells[atubod1Col.Index].Value.ToString();
            }
            else if ((dgvr.Cells[saiyotiAtubod2Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuAtubod2Col.Index].Value.ToString() == "1"))
            {
                paramAtubod = dgvr.Cells[atubod2Col.Index].Value.ToString();
            }

            // 判定
            string resA = KensaHanteiUtility.KakuninKensaShubetsuBODKijyunOver(
                dgvr.Cells[horyusakiCdCol.Index].Value.ToString(),
                paramBod,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );
            string resB = KensaHanteiUtility.KakuninKensaShubetsuBODKijyunOver(
                dgvr.Cells[horyusakiCdCol.Index].Value.ToString(),
                paramAtubod,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnBodOver.Index].Value = "1";

            // 判定結果設定
            if ((resA == "1") || (resB == "1"))
            {
                if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bod1KensaShubetsuBodOver.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bod2KensaShubetsuBodOver.Index].Value = "2";
                }
                if ((dgvr.Cells[saiyotiAtubod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuAtubod1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[atubod1KensaShubetsuBodOver.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiAtubod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuAtubod2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[atubod2KensaShubetsuBodOver.Index].Value = "2";
                }
            }
            else
            {
                if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bod1KensaShubetsuBodOver.Index].Value = "1";
                }
                else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[bod2KensaShubetsuBodOver.Index].Value = "1";
                }
                if ((dgvr.Cells[saiyotiAtubod1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuAtubod1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[atubod1KensaShubetsuBodOver.Index].Value = "1";
                }
                else if ((dgvr.Cells[saiyotiAtubod2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuAtubod2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[atubod2KensaShubetsuBodOver.Index].Value = "1";
                }
            }

        }
        #endregion

        #region 確認検査種別(塩化物イオン確認検査)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKakuninKensaShubetsuEnkaIon
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckKakuninKensaShubetsuEnkaIon(DataGridViewRow dgvr)
        {
            string paramCl = string.Empty;

            // 塩化物イオン
            if ((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))
            {
                paramCl = dgvr.Cells[cl1Col.Index].Value.ToString();
            }
            else if ((dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1"))
            {
                paramCl = dgvr.Cells[cl2Col.Index].Value.ToString();
            }

            // 判定
            string res = KensaHanteiUtility.KakuninKensaShubetsuEnkabutsuIonKensa(
                paramCl,
                dgvr.Cells[jokasoHokenjoCdCol.Index].Value.ToString(),
                dgvr.Cells[jokasoTorokuNendoCol.Index].Value.ToString(),
                dgvr.Cells[jokasoRenbanCol.Index].Value.ToString()
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnCrossSuishitsu.Index].Value = "1";
            dgvr.Cells[koshinKbnClKakunin.Index].Value = "1";

            // 判定結果設定
            if (res == "1")
            {
                dgvr.Cells[crossCheckSuishitsuCol.Index].Value = "1";
                if ((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[cl1KensaShubetsuEnkaIon.Index].Value = "2";
                }
                else if ((dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[cl2KensaShubetsuEnkaIon.Index].Value = "2";
                }
            }
            else
            {
                dgvr.Cells[crossCheckSuishitsuCol.Index].Value = "0";
                if ((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[cl1KensaShubetsuEnkaIon.Index].Value = "1";
                }
                else if ((dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
                    && (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1"))
                {
                    dgvr.Cells[cl2KensaShubetsuEnkaIon.Index].Value = "1";
                }
            }
        }
        #endregion

        #region 確認検査種別の判定結果を表示
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DispKakuninKensaShubetsu
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/29  宗        ATUBODの追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DispKakuninKensaShubetsu(DataGridViewRow dgvr)
        {
            // 初期化
            string ph1 = string.Empty;
            string ph2 = string.Empty;
            string tr1 = string.Empty;
            string tr2 = string.Empty;
            string bod1 = string.Empty;
            string bod2 = string.Empty;
            string zanen1 = string.Empty;
            string zanen2 = string.Empty;
            string cl1 = string.Empty;
            string cl2 = string.Empty;
            string atubod1 = string.Empty;
            string atubod2 = string.Empty;

            #region 表示文字列編集
            // BOD/透視度
            if (dgvr.Cells[bod1KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                bod1 += "A";
            }
            if (dgvr.Cells[bod2KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                bod2 += "A";
            }
            if (dgvr.Cells[tr1KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                tr1 += "A";
            }
            if (dgvr.Cells[tr2KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                tr2 += "A";
            }
            if (dgvr.Cells[atubod1KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                atubod1 += "A";
            }
            if (dgvr.Cells[atubod2KensaShubetsuBodTr.Index].Value.ToString() == "2")
            {
                atubod2 += "A";
            }

            // 過去との比較
            if (dgvr.Cells[ph1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                ph1 += "B";
            }
            if (dgvr.Cells[ph2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                ph2 += "B";
            }
            if (dgvr.Cells[tr1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tr1 += "B";
            }
            if (dgvr.Cells[tr2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                tr2 += "B";
            }
            if (dgvr.Cells[bod1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                bod1 += "B";
            }
            if (dgvr.Cells[bod2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                bod2 += "B";
            }
            if (dgvr.Cells[zanen1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                zanen1 += "B";
            }
            if (dgvr.Cells[zanen2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                zanen2 += "B";
            }
            if (dgvr.Cells[cl1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                cl1 += "B";
            }
            if (dgvr.Cells[cl2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                cl2 += "B";
            }
            if (dgvr.Cells[atubod1KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                atubod1 += "B";
            }
            if (dgvr.Cells[atubod2KensaShubetsuKako.Index].Value.ToString() == "2")
            {
                atubod2 += "B";
            }

            // BOD基準値オーバー
            if (dgvr.Cells[bod1KensaShubetsuBodOver.Index].Value.ToString() == "2")
            {
                bod1 += "C";
            }
            if (dgvr.Cells[bod2KensaShubetsuBodOver.Index].Value.ToString() == "2")
            {
                bod2 += "C";
            }
            if (dgvr.Cells[atubod1KensaShubetsuBodOver.Index].Value.ToString() == "2")
            {
                atubod1 += "C";
            }
            if (dgvr.Cells[atubod2KensaShubetsuBodOver.Index].Value.ToString() == "2")
            {
                atubod2 += "C";
            }

            // 塩化物イオン確認検査
            if (dgvr.Cells[cl1KensaShubetsuEnkaIon.Index].Value.ToString() == "2")
            {
                cl1 += "C";
            }
            if (dgvr.Cells[cl2KensaShubetsuEnkaIon.Index].Value.ToString() == "2")
            {
                cl2 += "C";
            }

            #endregion

            // 結果表示
            dgvr.Cells[kakuninKensaPh1Col.Index].Value = ph1;
            dgvr.Cells[kakuninKensaPh2Col.Index].Value = ph2;
            dgvr.Cells[kakuninKensaTr1Col.Index].Value = tr1;
            dgvr.Cells[kakuninKensaTr2Col.Index].Value = tr2;
            dgvr.Cells[kakuninKensaBod1Col.Index].Value = bod1;
            dgvr.Cells[kakuninKensaBod2Col.Index].Value = bod2;
            dgvr.Cells[kakuninKensaZanen1Col.Index].Value = zanen1;
            dgvr.Cells[kakuninKensaZanen2Col.Index].Value = zanen2;
            dgvr.Cells[kakuninKensaCl1Col.Index].Value = cl1;
            dgvr.Cells[kakuninKensaCl2Col.Index].Value = cl2;
            dgvr.Cells[kakuninKensaAtubod1Col.Index].Value = atubod1;
            dgvr.Cells[kakuninKensaAtubod2Col.Index].Value = atubod2;
        }
        #endregion

        #region スクリーニング判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckScreening
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckScreening(DataGridViewRow dgvr)
        {
            string paramBod = string.Empty;
            string paramZanen = string.Empty;

            // BOD
            //if (dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
            if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
            {
                paramBod = dgvr.Cells[bod1Col.Index].Value.ToString();
            }
            else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
            {
                paramBod = dgvr.Cells[bod2Col.Index].Value.ToString();
            }
            // 残留塩素濃度
            if ((dgvr.Cells[saiyotiZanen1Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "1"))
            {
                paramZanen = dgvr.Cells[zanen1Col.Index].Value.ToString();
            }
            else if ((dgvr.Cells[saiyotiZanen2Col.Index].Value.ToString() == CheckOn)
                && (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "1"))
            {
                paramZanen = dgvr.Cells[zanen2Col.Index].Value.ToString();
            }

            // 判定
            string res = KensaHanteiUtility.ScreeningHantei(
                dgvr.Cells[shoriHoshikiCdCol.Index].Value.ToString(),
                dgvr.Cells[shorimokuhyoSuishitsuCol.Index].Value.ToString(),
                paramBod,
                paramZanen
                );

            // 更新状態設定
            dgvr.Cells[koshinKbnScreeningKoho.Index].Value = "1";

            // 判定結果設定
            dgvr.Cells[screeningKohoCol.Index].Value = res;
        }
        #endregion

        #region 異常種別の判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckIjyoShubetsu
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckIjyoShubetsu(DataGridViewRow dgvr)
        {
            string res = string.Empty;

            // スクリーニング、フォロー
            if (dgvr.Cells[followKohoCol.Index].Value.ToString() == "0")
            {
                if ((dgvr.Cells[screeningKohoCol.Index].Value.ToString() == "1")
                    || (dgvr.Cells[screeningKohoCol.Index].Value.ToString() == "2"))
                {
                    res += "●";
                }
            }
            else if (dgvr.Cells[followKohoCol.Index].Value.ToString() == "1")
            {
                if (dgvr.Cells[screeningKohoCol.Index].Value.ToString() == "0")
                {
                    res += "○";
                }
                else if ((dgvr.Cells[screeningKohoCol.Index].Value.ToString() == "1")
                    || (dgvr.Cells[screeningKohoCol.Index].Value.ToString() == "2"))
                {
                    res += "◎";
                }
            }

            // クロスチェック異常(水質判定表)
            if (dgvr.Cells[crossCheckSuishitsuCol.Index].Value.ToString() == "1")
            {
                res += "★";
            }

            // クロスチェック異常(過去履歴)
            if (dgvr.Cells[crossCheckKakoCol.Index].Value.ToString() == "1")
            {
                res += "☆";
            }

            dgvr.Cells[ijyoShubetsuCol.Index].Value = res;
        }
        #endregion

        #region 適正の判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckTekisei
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/24  宗        適正判定で使用するの共通関数を変更
        ///                       KensaHanteiUtility.TekiyoHantei → KensaHanteiUtility.KensaTekiseiHantei
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckTekisei(DataGridViewRow dgvr)
        {
            // 20150124 sou Start
            #region to be removed
            //// 結果値が揃っている事を確認する
            //if ((dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "0")
            //    )
            //{
            //    dgvr.Cells[tekiseiHanteiCdCol.Index].Value = "0";
            //    dgvr.Cells[tekiseiHanteiCol.Index].Value = string.Empty;
            //    return;
            //}

            //// パラメータ設定
            //string paramPh = string.Empty;
            //string paramTr = string.Empty;
            //string paramBod = string.Empty;
            //string paramZanen = string.Empty;
            //string paramCl = string.Empty;

            //// pH
            //if ((dgvr.Cells[saiyotiPh1Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "1"))
            //{
            //    paramPh = dgvr.Cells[ph1Col.Index].Value.ToString();
            //}
            //else if ((dgvr.Cells[saiyotiPh2Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "1"))
            //{
            //    paramPh = dgvr.Cells[ph2Col.Index].Value.ToString();
            //}
            //// 透視度
            //if ((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))
            //{
            //    paramTr = dgvr.Cells[tr1Col.Index].Value.ToString();
            //}
            //else if ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))
            //{
            //    paramTr = dgvr.Cells[tr2Col.Index].Value.ToString();
            //}
            //// BOD
            //if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
            //{
            //    paramBod = dgvr.Cells[bod1Col.Index].Value.ToString();
            //}
            //else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
            //{
            //    paramBod = dgvr.Cells[bod2Col.Index].Value.ToString();
            //}
            //// 残留塩素濃度
            //if ((dgvr.Cells[saiyotiZanen1Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "1"))
            //{
            //    paramZanen = dgvr.Cells[zanen1Col.Index].Value.ToString();
            //}
            //else if ((dgvr.Cells[saiyotiZanen2Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "1"))
            //{
            //    paramZanen = dgvr.Cells[zanen2Col.Index].Value.ToString();
            //}
            //// 塩化物イオン
            //if ((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))
            //{
            //    paramCl = dgvr.Cells[cl1Col.Index].Value.ToString();
            //}
            //else if ((dgvr.Cells[saiyotiCl2Col.Index].Value.ToString() == CheckOn)
            //    && (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1"))
            //{
            //    paramCl = dgvr.Cells[cl2Col.Index].Value.ToString();
            //}

            //// 判定
            //string res = KensaHanteiUtility.TekiyoHantei(
            //    dgvr.Cells[shoriHoshikiCdCol.Index].Value.ToString(),
            //    dgvr.Cells[shorimokuhyoSuishitsuCol.Index].Value.ToString(),
            //    paramPh,
            //    paramTr,
            //    paramBod,
            //    paramZanen,
            //    paramCl,
            //    dgvr.Cells[kensaIraiHoteiKbnCol.Index].Value.ToString(),
            //    dgvr.Cells[kensaIraiHokenjoCdCol.Index].Value.ToString(),
            //    dgvr.Cells[kensaIraiNendoCol.Index].Value.ToString(),
            //    dgvr.Cells[kensaIraiRenbanCol.Index].Value.ToString()
            //    );
            #endregion
            // 検査依頼
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIrai =
                Utility.KensaHanteiUtility.GetKensaIrai(
                    dgvr.Cells[kensaIraiHoteiKbnCol.Index].Value.ToString(),
                    dgvr.Cells[kensaIraiHokenjoCdCol.Index].Value.ToString(),
                    dgvr.Cells[kensaIraiNendoCol.Index].Value.ToString(),
                    dgvr.Cells[kensaIraiRenbanCol.Index].Value.ToString()
                    );
            // 検査結果
            KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekka =
                Utility.KensaHanteiUtility.GetKensaKekka(
                    dgvr.Cells[kensaIraiHoteiKbnCol.Index].Value.ToString(),
                    dgvr.Cells[kensaIraiHokenjoCdCol.Index].Value.ToString(),
                    dgvr.Cells[kensaIraiNendoCol.Index].Value.ToString(),
                    dgvr.Cells[kensaIraiRenbanCol.Index].Value.ToString()
                    );

            #region 編集内容の反映
            if ((kensaIrai != null) && (kensaKekka != null))
            {
                #region ph
                if ((dgvr.Cells[saiyotiPh1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaSuisoIonNodo = double.Parse(dgvr.Cells[ph1Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaSuisoIonNodoHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.PH,
                                dgvr.Cells[ph1Col.Index].Value.ToString()).ToString();

                    kensaKekka[0].KensaKekkaOndo = decimal.Parse(dgvr.Cells[ondo1Col.Index].Value.ToString());
                }
                else if ((dgvr.Cells[saiyotiPh2Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaSuisoIonNodo = double.Parse(dgvr.Cells[ph2Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaSuisoIonNodoHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.PH,
                                dgvr.Cells[ph2Col.Index].Value.ToString()).ToString();

                    kensaKekka[0].KensaKekkaOndo = decimal.Parse(dgvr.Cells[ondo2Col.Index].Value.ToString());
                }
                #endregion

                #region 透視度
                if ((dgvr.Cells[saiyotiTr1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaToshido = double.Parse(dgvr.Cells[tr1Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaToshidoHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.Toshido,
                                dgvr.Cells[tr1Col.Index].Value.ToString()).ToString();

                    kensaKekka[0].KensaKekkaToshido2 = dgvr.Cells[tr1KekkaCdCol.Index].Value.ToString();
                }
                else if ((dgvr.Cells[saiyotiTr2Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaToshido = double.Parse(dgvr.Cells[tr2Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaToshidoHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.Toshido,
                                dgvr.Cells[tr2Col.Index].Value.ToString()).ToString();

                    kensaKekka[0].KensaKekkaToshido2 = dgvr.Cells[tr2KekkaCdCol.Index].Value.ToString();
                }
                #endregion

                #region BOD
                if ((dgvr.Cells[saiyotiBod1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaBOD = double.Parse(dgvr.Cells[bod1Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaBODHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.BOD,
                                dgvr.Cells[bod1Col.Index].Value.ToString()).ToString();

                    kensaKekka[0].KensaIraiBOD2 = dgvr.Cells[bod1KekkaCdCol.Index].Value.ToString();
                }
                else if ((dgvr.Cells[saiyotiBod2Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaBOD = double.Parse(dgvr.Cells[bod2Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaBODHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.BOD,
                                dgvr.Cells[bod2Col.Index].Value.ToString()).ToString();

                    kensaKekka[0].KensaIraiBOD2 = dgvr.Cells[bod2KekkaCdCol.Index].Value.ToString();
                }
                #endregion

                #region 残塩
                if ((dgvr.Cells[saiyotiZanen1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaZanryuEnsoNodo = double.Parse(dgvr.Cells[zanen1Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaZanryuEnsoNodoHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso,
                                dgvr.Cells[zanen1Col.Index].Value.ToString()).ToString();
                }
                else if ((dgvr.Cells[saiyotiZanen1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaZanryuEnsoNodo = double.Parse(dgvr.Cells[zanen2Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaZanryuEnsoNodoHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso,
                                dgvr.Cells[zanen2Col.Index].Value.ToString()).ToString();
                }
                #endregion

                #region 塩化物イオン
                if ((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaEnsoIonNodo = decimal.Parse(dgvr.Cells[cl1Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaEnsoIonNodoHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon,
                                dgvr.Cells[cl1Col.Index].Value.ToString()).ToString();

                    kensaKekka[0].KensaIraiEnsoIonNodo2 = dgvr.Cells[cl1KekkaCdCol.Index].Value.ToString();
                }
                else if ((dgvr.Cells[saiyotiCl1Col.Index].Value.ToString() == CheckOn) && (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "1"))
                {
                    kensaKekka[0].KensaKekkaEnsoIonNodo = decimal.Parse(dgvr.Cells[cl2Col.Index].Value.ToString());

                    kensaKekka[0].KensaKekkaEnsoIonNodoHantei
                        = SuishitsuUtility.SuishitsuHyokaHantei(
                                kensaIrai[0].KensaIraiShorihoshikiKbn,
                                kensaIrai[0].KensaIraiBODShoriSeino,
                                SuishitsuUtility.SuishitsuKensaKbn.EnkabutsuIon,
                                dgvr.Cells[cl2Col.Index].Value.ToString()).ToString();

                    kensaKekka[0].KensaIraiEnsoIonNodo2 = dgvr.Cells[cl2KekkaCdCol.Index].Value.ToString();
                }
                #endregion
            }
            #endregion

            // 所見結果
            ShokenKekkaTblDataSet.ShokenKekkaListWithBitmaskDataTable shokenKekkaBitMsk =
                Utility.KensaHanteiUtility.GetShokenKekka(
                    dgvr.Cells[kensaIraiHoteiKbnCol.Index].Value.ToString(),
                    dgvr.Cells[kensaIraiHokenjoCdCol.Index].Value.ToString(),
                    dgvr.Cells[kensaIraiNendoCol.Index].Value.ToString(),
                    dgvr.Cells[kensaIraiRenbanCol.Index].Value.ToString()
                    );

            // 判定
            string res = KensaHanteiUtility.KensaTekiseiHantei(kensaIrai, kensaKekka, shokenKekkaBitMsk);

            // 20150124 sou End

            // 判定結果設定
            dgvr.Cells[tekiseiHanteiCdCol.Index].Value = res;
            dgvr.Cells[tekiseiHanteiCol.Index].Value = GetShoriHoshikiNm(res);

        }
        #endregion

        #region 背景色の判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckBackColor
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/29  宗        ATUBODを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CheckBackColor(DataGridViewRow dgvr)
        {
            // 未入力
            if (dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, ph1Col.Index, ph2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, tr1Col.Index, tr2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, bod1Col.Index, bod2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, zanen1Col.Index, zanen2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, cl1Col.Index, cl2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAtubod1Col.Index].Value.ToString() == "0")
            {
                SetBackColor(dgvr, Color.Yellow, atubod1Col.Index, atubod2Col.Index);
            }

            // 確認検査対象
            if (dgvr.Cells[kakuninKensaPh1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, ph1Col.Index, ph2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaTr1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, tr1Col.Index, tr2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaBod1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, bod1Col.Index, bod2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaZanen1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, zanen1Col.Index, zanen2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaCl1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, cl1Col.Index, cl2Col.Index);
            }
            if (dgvr.Cells[kakuninKensaAtubod1Col.Index].Value.ToString() != string.Empty)
            {
                SetBackColor(dgvr, Color.LightBlue, atubod1Col.Index, atubod2Col.Index);
            }

            // 対象外
            if (dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, ph1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, ph2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tr1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, tr2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, bod1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, bod2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, zanen1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, zanen2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, cl1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, cl2Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAtubod1Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, atubod1Col.Index);
            }
            if (dgvr.Cells[kekkaNyuryokuAtubod2Col.Index].Value.ToString() == string.Empty)
            {
                SetBackColor(dgvr, Color.LightGray, atubod2Col.Index);
            }
        }
        #endregion

        #region 背景色の設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetBackColor
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetBackColor(DataGridViewRow dgvr, Color color, int col1Idx, int col2Idx = -1)
        {
            dgvr.Cells[col1Idx].Style.BackColor = color;
            dgvr.Cells[col1Idx + 1].Style.BackColor = color;
            dgvr.Cells[col1Idx + 2].Style.BackColor = color;
            dgvr.Cells[col1Idx + 3].Style.BackColor = color;
            if ((col1Idx == ph1Col.Index) || (col1Idx == ph2Col.Index))
            {
                dgvr.Cells[col1Idx + 4].Style.BackColor = color;
            }

            if (col2Idx >= 0)
            {
                dgvr.Cells[col2Idx].Style.BackColor = color;
                dgvr.Cells[col2Idx + 1].Style.BackColor = color;
                dgvr.Cells[col2Idx + 2].Style.BackColor = color;
                dgvr.Cells[col2Idx + 3].Style.BackColor = color;
                if ((col2Idx == ph1Col.Index) || (col2Idx == ph2Col.Index))
                {
                    dgvr.Cells[col2Idx + 4].Style.BackColor = color;
                }
            }
        }
        #endregion

        #region 各検査項目の状態設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKmkPropaty
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/29  宗        ATUBODを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKmkPropaty(DataGridViewRow dgvr)
        {
            // スクリーニング指示の状態設定
            if ((((dgvr.Cells[screeningKohoCol.Index].Value.ToString() == "1")
                || (dgvr.Cells[screeningKohoCol.Index].Value.ToString() == "2"))
                || ((dgvr.Cells[screeningKohoCol.Index].Value.ToString() != "3")
                && (dgvr.Cells[followKohoCol.Index].Value.ToString() == "1")))
                && dgvr.Cells[screeningCol.Index].Value.ToString() == CheckOff)
            {
                dgvr.Cells[screeningCol.Index].ReadOnly = false;
            }
            else
            {
                dgvr.Cells[screeningCol.Index].ReadOnly = true;
            }

            // 状態設定
            if ((dgvr.Cells[kachoKeninCol.Index].Value.ToString() == CheckOn)
                || (dgvr.Cells[hukukachoKeninCol.Index].Value.ToString() == CheckOn))
            {
                // 状態設定(検印)
                SetKmkPropatyKenin(dgvr);
            }
            else
            {
                // 状態設定(ph)
                SetKmkPropatyPh(dgvr, ph1Col.Index);
                // 状態設定(透視度)
                SetKmkPropatyAll(dgvr, tr1Col.Index);
                // 状態設定(BOD)
                SetKmkPropatyAll(dgvr, bod1Col.Index);
                // 状態設定(残塩)
                SetKmkPropatyAll(dgvr, zanen1Col.Index);
                // 状態設定(塩化物イオン)
                SetKmkPropatyAll(dgvr, cl1Col.Index);
                // 状態設定(ATUBOD)
                SetKmkPropatyAll(dgvr, atubod1Col.Index);

                // 検印可否判定
                if (keninKahiHantei(dgvr))
                {
                    dgvr.Cells[kachoKeninCol.Index].ReadOnly = false;
                    dgvr.Cells[hukukachoKeninCol.Index].ReadOnly = false;
                }
                else
                {
                    dgvr.Cells[kachoKeninCol.Index].ReadOnly = true;
                    dgvr.Cells[hukukachoKeninCol.Index].ReadOnly = true;
                }
            }
        }
        #endregion

        #region 各検査項目の状態設定(検印)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKmkPropatyKentai
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/29  宗        ATUBODを追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKmkPropatyKenin(DataGridViewRow dgvr)
        {
            // スクリーニング指示
            dgvr.Cells[screeningCol.Index].ReadOnly = true;
            // pH1
            dgvr.Cells[ph1Col.Index].ReadOnly = true;
            dgvr.Cells[ondo1Col.Index].ReadOnly = true;
            dgvr.Cells[ph1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiPh1Col.Index].ReadOnly = true;
            // pH2
            dgvr.Cells[ph2Col.Index].ReadOnly = true;
            dgvr.Cells[ondo2Col.Index].ReadOnly = true;
            dgvr.Cells[ph2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiPh2Col.Index].ReadOnly = true;
            // 透視度1
            dgvr.Cells[tr1Col.Index].ReadOnly = true;
            dgvr.Cells[tr1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTr1Col.Index].ReadOnly = true;
            // 透視度2
            dgvr.Cells[tr2Col.Index].ReadOnly = true;
            dgvr.Cells[tr2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiTr2Col.Index].ReadOnly = true;
            // BOD1
            dgvr.Cells[bod1Col.Index].ReadOnly = true;
            dgvr.Cells[bod1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiBod1Col.Index].ReadOnly = true;
            // BOD2
            dgvr.Cells[bod2Col.Index].ReadOnly = true;
            dgvr.Cells[bod2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiBod2Col.Index].ReadOnly = true;
            // 残塩1
            dgvr.Cells[zanen1Col.Index].ReadOnly = true;
            dgvr.Cells[zanen1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiZanen1Col.Index].ReadOnly = true;
            // 残塩2
            dgvr.Cells[zanen2Col.Index].ReadOnly = true;
            dgvr.Cells[zanen2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiZanen2Col.Index].ReadOnly = true;
            // 塩化物イオン1
            dgvr.Cells[cl1Col.Index].ReadOnly = true;
            dgvr.Cells[cl1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiCl1Col.Index].ReadOnly = true;
            // 塩化物イオン2
            dgvr.Cells[cl2Col.Index].ReadOnly = true;
            dgvr.Cells[cl2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiCl2Col.Index].ReadOnly = true;
            // ATUBOD1
            dgvr.Cells[atubod1Col.Index].ReadOnly = true;
            dgvr.Cells[atubod1KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiAtubod1Col.Index].ReadOnly = true;
            // ATUBOD2
            dgvr.Cells[atubod2Col.Index].ReadOnly = true;
            dgvr.Cells[atubod2KekkaCdCol.Index].ReadOnly = true;
            dgvr.Cells[saiyotiAtubod2Col.Index].ReadOnly = true;
        }
        #endregion

        #region 各検査項目の状態設定(pH)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKmkPropatyPh
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKmkPropatyPh(DataGridViewRow dgvr, int index)
        {
            // 採用値(初回)
            dgvr.Cells[index + 4].ReadOnly = (dgvr.Cells[index + 6].Value.ToString() == "1" ? false : true);
            // 採用値(再検査)
            dgvr.Cells[index + 11].ReadOnly = (dgvr.Cells[index + 13].Value.ToString() == "1" ? false : true);

            // 状態設定(初回)
            if ((dgvr.Cells[index + 4].Value.ToString() == CheckOn)
                && (dgvr.Cells[index + 6].Value.ToString() == "1"))
            {
                //pH1
                dgvr.Cells[index].ReadOnly = false;
                dgvr.Cells[index].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //温度1
                dgvr.Cells[index + 1].ReadOnly = false;
                dgvr.Cells[index + 1].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //結果コード（pH1）
                dgvr.Cells[index + 2].ReadOnly = false;
                //pH2
                dgvr.Cells[index + 7].ReadOnly = true;
                dgvr.Cells[index + 7].Style.Font = underLineFont;
                //温度2
                dgvr.Cells[index + 8].ReadOnly = true;
                dgvr.Cells[index + 8].Style.Font = underLineFont;
                //結果コード（pH2）
                dgvr.Cells[index + 9].ReadOnly = true;
            }
            // 状態設定(再検査)
            else if ((dgvr.Cells[index + 11].Value.ToString() == CheckOn)
                && (dgvr.Cells[index + 13].Value.ToString() == "1"))
            {
                //pH1
                dgvr.Cells[index].ReadOnly = true;
                dgvr.Cells[index].Style.Font = underLineFont;
                //温度1
                dgvr.Cells[index + 1].ReadOnly = true;
                dgvr.Cells[index + 1].Style.Font = underLineFont;
                //結果コード（pH1）
                dgvr.Cells[index + 2].ReadOnly = true;
                //pH2
                dgvr.Cells[index + 7].ReadOnly = false;
                dgvr.Cells[index + 7].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //温度2
                dgvr.Cells[index + 8].ReadOnly = false;
                dgvr.Cells[index + 8].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //結果コード（pH2）
                dgvr.Cells[index + 9].ReadOnly = false;
            }
            // 対象外 or 未入力
            else
            {
                dgvr.Cells[index].ReadOnly = true;
                dgvr.Cells[index].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 1].ReadOnly = true;
                dgvr.Cells[index + 1].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 2].ReadOnly = true;
                dgvr.Cells[index + 2].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 7].ReadOnly = true;
                dgvr.Cells[index + 7].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 8].ReadOnly = true;
                dgvr.Cells[index + 8].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 9].ReadOnly = true;
                dgvr.Cells[index + 9].Style.Font = listDataGridView.DefaultCellStyle.Font;
            }
        }
        #endregion

        #region 各検査項目の状態設定(共通)
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetKmkPropatyAll
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetKmkPropatyAll(DataGridViewRow dgvr, int index)
        {
            // 採用値(初回)
            dgvr.Cells[index + 3].ReadOnly = (dgvr.Cells[index + 5].Value.ToString() == "1" ? false : true);
            // 採用値(再検査)
            dgvr.Cells[index + 9].ReadOnly = (dgvr.Cells[index + 11].Value.ToString() == "1" ? false : true);

            // 状態設定(初回)
            if ((dgvr.Cells[index + 3].Value.ToString() == CheckOn)
                && (dgvr.Cells[index + 5].Value.ToString() == "1"))
            {
                //透視度1
                dgvr.Cells[index].ReadOnly = false;
                dgvr.Cells[index].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //結果コード（透視度1）
                dgvr.Cells[index + 1].ReadOnly = false;
                //透視度2
                dgvr.Cells[index + 6].ReadOnly = true;
                dgvr.Cells[index + 6].Style.Font = underLineFont;
                //結果コード（透視度2）
                dgvr.Cells[index + 7].ReadOnly = true;
            }
            // 状態設定(再検査)
            else if ((dgvr.Cells[index + 9].Value.ToString() == CheckOn)
                && (dgvr.Cells[index + 11].Value.ToString() == "1"))
            {
                //透視度1
                dgvr.Cells[index].ReadOnly = true;
                dgvr.Cells[index].Style.Font = underLineFont;
                //結果コード（透視度1）
                dgvr.Cells[index + 1].ReadOnly = true;
                //透視度2
                dgvr.Cells[index + 6].ReadOnly = false;
                dgvr.Cells[index + 6].Style.Font = listDataGridView.DefaultCellStyle.Font;
                //結果コード（透視度2）
                dgvr.Cells[index + 7].ReadOnly = false;
            }
            // 対象外 or 未入力
            else
            {
                dgvr.Cells[index].ReadOnly = true;
                dgvr.Cells[index].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 1].ReadOnly = true;
                dgvr.Cells[index + 1].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 6].ReadOnly = true;
                dgvr.Cells[index + 6].Style.Font = listDataGridView.DefaultCellStyle.Font;
                dgvr.Cells[index + 7].ReadOnly = true;
                dgvr.Cells[index + 7].Style.Font = listDataGridView.DefaultCellStyle.Font;
            }
        }
        #endregion

        #region 検印可否判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： keninKahiHantei
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// 2015/01/29  宗        検査種別毎に判定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool keninKahiHantei(DataGridViewRow dgvr)
        {
            bool res = true;

            // 20150129 sou Start
            //// 検印不可判定(検査結果未入力)
            //if ((dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "0")
            //    || (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "0")
            //{
            //    res = false;
            //}
            if (suishitsuKensaRadioButton.Checked)
            {
                // 検印不可判定(検査結果未入力)
                if ((dgvr.Cells[kekkaNyuryokuPh1Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuPh2Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuTr1Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuTr2Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuZanen1Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuZanen2Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "0"))
                {
                    res = false;
                }
            }
            else
            {
                // 検印不可判定(検査結果未入力)
                if ((dgvr.Cells[kekkaNyuryokuBod1Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuBod2Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuCl1Col.Index].Value.ToString() == "0")
                    || (dgvr.Cells[kekkaNyuryokuCl2Col.Index].Value.ToString() == "0"))
                {
                    res = false;
                }
            }
            // 20150129 sou End

            // 検印不可判定(外観検査中断)
            if (dgvr.Cells[kensaJyokyoCol.Index].Value.ToString() == "1")
            {
                res = false;
            }

            return res;
        }
        #endregion

        #region 関連チェック
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RelationCheck
        /// <summary>
        /// 
        /// </summary>
        /// <output>戻り値：true = 正常、false  = エラー</output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool RelationCheck()
        {
            if (shishoComboBox.SelectedIndex == 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, "支所が選択されていません。");
                return false;
            }

            // 依頼受付日の関連チェック
            if (iraiUketsukeDtCheckBox.Checked)
            {
                if (iraiUketsukeDtFromDateTimePicker.Value > iraiUketsukeDtToDateTimePicker.Value)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "範囲指定が正しくありません。依頼受付日の大小関係を確認してください。");
                    return false;
                }
            }

            // 依頼Noの関連チェック
            if (!string.IsNullOrEmpty(iraiNoFromTextBox.Text) && (!string.IsNullOrEmpty(iraiNoToTextBox.Text)))
            {
                if (int.Parse(iraiNoFromTextBox.Text) > int.Parse(iraiNoToTextBox.Text))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "範囲指定が正しくありません。依頼Noの大小関係を確認してください。");
                    return false;
                }
            }

            // 正常
            return true;
        }
        #endregion

        #region 編集内容破棄チェック
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RelationCheck
        /// <summary>
        /// 
        /// </summary>
        /// <output>戻り値：正常 = true、エラー = false</output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditCheck()
        {
            bool res = true;

            // 検査台帳一覧の件数分繰り返す
            foreach (DataGridViewRow dgvr in listDataGridView.Rows)
            {
                // 更新区分(pH)
                if (dgvr.Cells[koshinKbnPh.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(透視度)
                if (dgvr.Cells[koshinKbnTr.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(BOD)
                if (dgvr.Cells[koshinKbnBod.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(残塩)
                if (dgvr.Cells[koshinKbnZanen.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(塩化物イオン)
                if (dgvr.Cells[koshinKbnCl.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(BOD/透視度)
                if (dgvr.Cells[koshinKbnBodTr.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(過去との比較)(pH)
                if (dgvr.Cells[koshinKbnKakoPh.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(過去との比較)(透視度)
                if (dgvr.Cells[koshinKbnKakoTr.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(過去との比較)(BOD)
                if (dgvr.Cells[koshinKbnKakoBod.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(過去との比較)(残塩)
                if (dgvr.Cells[koshinKbnKakoZanen.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(過去との比較)(塩化物イオン)
                if (dgvr.Cells[koshinKbnKakoCl.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(BOD基準値オーバー)
                if (dgvr.Cells[koshinKbnBodOver.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
                // 更新区分(塩化物イオン確認検査)
                if (dgvr.Cells[koshinKbnClKakunin.Index].Value.ToString() == "1")
                {
                    res = false;
                    break;
                }
            }

            // 正常
            return res;
        }
        #endregion

        #region 法定区分判定＆表示
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： hoteiKbnHantei
        /// <summary>
        /// 
        /// </summary>
        /// <input>
        /// string hoteiKbn 法定区分
        /// string ScrKbn   スクリーニング区分
        /// </input>
        /// <output>
        /// string 法定区分名称
        /// </output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string hoteiKbnHantei(string hoteiKbn, string ScrKbn)
        {
            string res = string.Empty;

            if (ScrKbn == "1")
            {
                res = HouteiKbnNm4;
            }
            else if (ScrKbn == "2")
            {
                res = HouteiKbnNm5;
            }
            else if (ScrKbn == "3")
            {
                res = HouteiKbnNm6;
            }
            else
            {
                if (hoteiKbn == "1")
                {
                    res = HouteiKbnNm1;
                }
                else if (hoteiKbn == "2")
                {
                    res = HouteiKbnNm2;
                }
                else if (hoteiKbn == "3")
                {
                    res = HouteiKbnNm3;
                }
            }

            return res;
        }
        #endregion

        #region スクリーニング指示済判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： hoteiKbnHantei
        /// <summary>
        /// 
        /// </summary>
        /// <input>
        /// string ScrKbn       スクリーニング区分
        /// string SaisaisuiKbn 再採水区分
        /// </input>
        /// <output>
        /// string スクリーニング指示区分 0=未実施, 1=指示済み
        /// </output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string ScreeningShijiHantei(string ScrKbn, string SaisaisuiKbn)
        {
            string res = string.Empty;

            if (ScrKbn == "1")
            {
                if (SaisaisuiKbn == "1")
                {
                    res = "0";
                }
                else
                {
                    res = "1";
                }
            }
            else
            {
                res = "0";
            }

            return res;
        }
        #endregion

        #region 試験項目コード取得
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKmkCd
        /// <summary>
        /// 
        /// </summary>
        /// <input>
        /// string renban 定数マスタに設定している項目毎の連番
        /// </input>
        /// <output>
        /// string 試験項目コード
        /// </output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetKmkCd(string renban)
        {
            string res = string.Empty;

            // 試験項目コードを設定
            foreach (DataRow dr in kmkCdDt.Rows)
            {
                if (dr[1].ToString() == renban)
                {
                    res = dr[3].ToString();
                    break;
                }
            }

            return res;
        }
        #endregion

        #region 試験項目コード取得
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKmkGaikanCd
        /// <summary>
        /// 
        /// </summary>
        /// <input>
        /// string renban 定数マスタに設定している外観の項目毎の連番
        /// </input>
        /// <output>
        /// string 試験項目コード
        /// </output>
        /// <history>
        /// 日付        担当者    内容
        /// 2015/01/29　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetKmkGaikanCd(string renban)
        {
            string res = string.Empty;

            // 試験項目コードを設定
            foreach (DataRow dr in kmkCdGaikanDt.Rows)
            {
                if (dr[1].ToString() == renban)
                {
                    res = dr[3].ToString();
                    break;
                }
            }

            return res;
        }
        #endregion

        #region 処理方式名称取得
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetShoriHoshikiNm
        /// <summary>
        /// 
        /// </summary>
        /// <input>
        /// string val 定数マスタに設定している値
        /// </input>
        /// <output>
        /// string 処理方式名称
        /// </output>
        /// <history>
        /// 日付        担当者    内容
        /// 2014/11/28　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetShoriHoshikiNm(string val)
        {
            string res = string.Empty;

            // 処理方式名称を設定
            foreach (DataRow dr in shoriHoshikiNmDt.Rows)
            {
                if (dr[3].ToString() == val)
                {
                    res = dr[2].ToString();
                    break;
                }
            }

            return res;
        }
        #endregion

        #region to be removed
        #region 同一依頼の別検体データ確認
        //ApplicationLigicに移動
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： CheckBetsuKentai
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <input>
        ///// string baseRowCnt 元となる行位置
        ///// </input>
        ///// <output>
        ///// BetsuKentai 別検体情報
        ///// </output>
        ///// <history>
        ///// 日付        担当者    内容
        ///// 2014/12/01　宗        新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private BetsuKentai CheckBetsuKentai(int baseRowCnt)
        //{
        //    string where1 = listDataGridView[kensaIraiHoteiKbnCol.Index, baseRowCnt].Value.ToString();
        //    string where2 = listDataGridView[kensaIraiHokenjoCdCol.Index, baseRowCnt].Value.ToString();
        //    string where3 = listDataGridView[kensaIraiNendoCol.Index, baseRowCnt].Value.ToString();
        //    string where4 = listDataGridView[kensaIraiRenbanCol.Index, baseRowCnt].Value.ToString();
        //    string where5 = listDataGridView[saisaisuiKbnCol.Index, baseRowCnt].Value.ToString();

        //    BetsuKentai bk = new BetsuKentai();
        //    bk.rowIndex = -1;
        //    bk.kachoKenin = "0";
        //    bk.hukukachoKenin = "0";

        //    int rowCnt = -1;
        //    foreach (DataGridViewRow dgvr in listDataGridView.Rows)
        //    {
        //        rowCnt++;

        //        if (rowCnt == baseRowCnt)
        //        {
        //            continue;
        //        }

        //        if((listDataGridView[kensaIraiHoteiKbnCol.Index, rowCnt].Value.ToString() == where1)
        //            && (listDataGridView[kensaIraiHokenjoCdCol.Index, rowCnt].Value.ToString() == where2)
        //            && (listDataGridView[kensaIraiNendoCol.Index, rowCnt].Value.ToString() == where3)
        //            && (listDataGridView[kensaIraiRenbanCol.Index, rowCnt].Value.ToString() == where4)
        //            && (listDataGridView[saisaisuiKbnCol.Index, rowCnt].Value.ToString() == (where5 == "1" ? "0" : "1")))
        //        {
        //            bk.rowIndex = rowCnt;
        //            bk.kachoKenin = listDataGridView[kachoKeninCol.Index, rowCnt].Value.ToString();
        //            bk.hukukachoKenin = listDataGridView[hukukachoKeninCol.Index, rowCnt].Value.ToString();
        //            break;
        //        }
        //    }

        //    return bk;
        //}
        #endregion
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
        /// 2014/12/03　宗        新規作成
        /// 2015/01/15　habu      初期表示モード追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ModeChange(DispMode mode)
        {
            // 画面モード別のコントロール制御
            switch (mode)
            {
                case DispMode.Load:
                    // 台帳出力ボタン
                    daichoPrintButton.Enabled = false;
                    // 水質異常一覧出力ボタン
                    suishitsuIjoOutputButton.Enabled = false;
                    // 確定ボタン
                    kakuteiButton.Enabled = false;

                    break;
                case DispMode.Kakunin:
                    // 台帳出力ボタン
                    daichoPrintButton.Enabled = true;
                    // 水質異常一覧出力ボタン
                    suishitsuIjoOutputButton.Enabled = true;
                    // 確定ボタン
                    kakuteiButton.Enabled = false;

                    break;
                case DispMode.Hensyu:
                    // 台帳出力ボタン
                    daichoPrintButton.Enabled = true;
                    // 水質異常一覧出力ボタン
                    suishitsuIjoOutputButton.Enabled = true;
                    // 確定ボタン
                    kakuteiButton.Enabled = true;

                    break;
            }

            return;
        }
        #endregion

        #region スクリーニングとフォローの対象一覧出力
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SuishitsuIjoListPrint
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2015/01/11　宗        新規作成
        /// 2015/01/22  宗        出力後の確認メッセージを削除
        ///                       0件時のメッセージの出力形式を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SuishitsuIjoListPrint()
        {
            // 出力確認
            if (MessageForm.Show2(MessageForm.DispModeType.Question, "法定11条水質異常一覧表\r\nフォロー検査対象一覧表\r\nを出力します。よろしいですか？") == DialogResult.Yes)
            {
                // 20150116 habu 編集済みの場合、破棄確認メッセージを表示する様に変更
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "未確定分の編集内容は出力に反映されません。\r\n出力を行いますか？") == DialogResult.No)
                    {
                        return;
                    }
                }

                // 20150122 sou Start
                string kekkaMsg = string.Empty;
                // 20150122 sou End

                // 法定11条水質異常一覧表の出力件数確認
                //20150120 sou Start
                //if (!HoteiKensaUtility.Hotei11joIjoListCountCheck(nendoTextBox.Text
                //    , iraiUketsukeDtCheckBox.Checked == true ? "1" : "0"
                //    , iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd")
                //    , iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd")
                //    , iraiNoFromTextBox.Text
                //    //  20150115 habu 支所を条件に追加
                //    , LoginUserShozokuShishoCd
                //    , iraiNoToTextBox.Text
                //    , GetKmkCd(ConstRenbanPh)
                //    , GetKmkCd(ConstRenbanTr)
                //    , GetKmkCd(ConstRenbanBod)
                //    , GetKmkCd(ConstRenbanZanen)
                //    ))
                if (!HoteiKensaUtility.Hotei11joIjoListCountCheck(_searchAlInput.SearchCond.Nendo
                    , _searchAlInput.SearchCond.IraiUketsukeDtInputKbn
                    , _searchAlInput.SearchCond.IraiUketsukeFromDt
                    , _searchAlInput.SearchCond.IraiUketsukeToDt
                    , _searchAlInput.SearchCond.IraiNoFrom
                    , _searchAlInput.SearchCond.IraiNoTo
                    , _searchAlInput.SearchCond.ShishoCd
                    , _searchAlInput.SearchCond.KmkCdPh
                    , _searchAlInput.SearchCond.KmkCdTr
                    , _searchAlInput.SearchCond.KmkCdBod
                    , _searchAlInput.SearchCond.KmkCdZanen
                    ))
                //20150120 sou End
                {
                    // 出力データなし
                    //MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力データがありません。[法定11条水質異常一覧表]");
                    kekkaMsg += "法定11条水質異常一覧表\r\n";
                }
                else
                {
                    // 法定11条水質異常一覧表出力
                    ISuishitsuIjoPrintBtnClickScreeningALInput scAlInput = new SuishitsuIjoPrintBtnClickScreeningALInput();
                    // 20150120 sou Start
                    //scAlInput.Nendo = nendoTextBox.Text;
                    //scAlInput.IraiDateKbn = iraiUketsukeDtCheckBox.Checked == true ? "1" : "0";
                    //scAlInput.IraiDateFrom = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                    //scAlInput.IraiDateTo = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
                    //scAlInput.IraiNoFrom = iraiNoFromTextBox.Text;
                    //scAlInput.IraiNoTo = iraiNoToTextBox.Text;
                    ////  20150115 habu 支所を条件に追加
                    //scAlInput.ShishoCd = LoginUserShozokuShishoCd;
                    //scAlInput.MassageFlg = true;
                    scAlInput.Nendo = _searchAlInput.SearchCond.Nendo;
                    scAlInput.IraiDateKbn = _searchAlInput.SearchCond.IraiUketsukeDtInputKbn;
                    scAlInput.IraiDateFrom = _searchAlInput.SearchCond.IraiUketsukeFromDt;
                    scAlInput.IraiDateTo = _searchAlInput.SearchCond.IraiUketsukeToDt;
                    scAlInput.IraiNoFrom = _searchAlInput.SearchCond.IraiNoFrom;
                    scAlInput.IraiNoTo = _searchAlInput.SearchCond.IraiNoTo;
                    scAlInput.ShishoCd = _searchAlInput.SearchCond.ShishoCd;
                    scAlInput.MassageFlg = true;
                    // 20150120 sou End
                    new SuishitsuIjoPrintBtnClickScreeningApplicationLogic().Execute(scAlInput);
                }

                // フォロー検査対象一覧表の出力件数確認
                // 20150120 sou Start
                //if (!HoteiKensaUtility.FollowListCountCheck(nendoTextBox.Text
                //    , iraiUketsukeDtCheckBox.Checked == true ? "1" : "0"
                //    , iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd")
                //    , iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd")
                //    , iraiNoFromTextBox.Text
                //    //  20150115 habu 支所を条件に追加
                //    //, LoginUserShozokuShishoCd
                //    , shishoComboBox.SelectedValue.ToString()
                //    , iraiNoToTextBox.Text
                //    , GetKmkCd(ConstRenbanPh)
                //    , GetKmkCd(ConstRenbanTr)
                //    , GetKmkCd(ConstRenbanBod)
                //    , GetKmkCd(ConstRenbanZanen)
                //    ))
                if (!HoteiKensaUtility.FollowListCountCheck(_searchAlInput.SearchCond.Nendo
                    , _searchAlInput.SearchCond.IraiUketsukeDtInputKbn
                    , _searchAlInput.SearchCond.IraiUketsukeFromDt
                    , _searchAlInput.SearchCond.IraiUketsukeToDt
                    , _searchAlInput.SearchCond.IraiNoFrom
                    , _searchAlInput.SearchCond.IraiNoTo
                    , _searchAlInput.SearchCond.ShishoCd
                    , _searchAlInput.SearchCond.KmkCdPh
                    , _searchAlInput.SearchCond.KmkCdTr
                    , _searchAlInput.SearchCond.KmkCdBod
                    , _searchAlInput.SearchCond.KmkCdZanen
                    ))
                // 20150120 sou End
                {
                    // 出力データなし
                    //MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力データがありません。[フォロー検査対象一覧表]");
                    kekkaMsg += "フォロー検査対象一覧表\r\n";
                }
                else
                {
                    // フォロー検査対象一覧表出力
                    ISuishitsuIjoPrintBtnClickFollowALInput foAlInput = new SuishitsuIjoPrintBtnClickFollowALInput();
                    // 20150120 sou Start
                    //foAlInput.Nendo = nendoTextBox.Text;
                    //foAlInput.IraiDateKbn = iraiUketsukeDtCheckBox.Checked == true ? "1" : "0";
                    //foAlInput.IraiDateFrom = iraiUketsukeDtFromDateTimePicker.Value.ToString("yyyyMMdd");
                    //foAlInput.IraiDateTo = iraiUketsukeDtToDateTimePicker.Value.ToString("yyyyMMdd");
                    //foAlInput.IraiNoFrom = iraiNoFromTextBox.Text;
                    //foAlInput.IraiNoTo = iraiNoToTextBox.Text;
                    ////  20150115 habu 支所を条件に追加
                    ////foAlInput.ShishoCd = LoginUserShozokuShishoCd;
                    //foAlInput.ShishoCd = shishoComboBox.SelectedValue.ToString();
                    //foAlInput.MassageFlg = true;
                    foAlInput.Nendo = _searchAlInput.SearchCond.Nendo;
                    foAlInput.IraiDateKbn = _searchAlInput.SearchCond.IraiUketsukeDtInputKbn;
                    foAlInput.IraiDateFrom = _searchAlInput.SearchCond.IraiUketsukeFromDt;
                    foAlInput.IraiDateTo = _searchAlInput.SearchCond.IraiUketsukeToDt;
                    foAlInput.IraiNoFrom = _searchAlInput.SearchCond.IraiNoFrom;
                    foAlInput.IraiNoTo = _searchAlInput.SearchCond.IraiNoTo;
                    foAlInput.ShishoCd = _searchAlInput.SearchCond.ShishoCd;
                    foAlInput.MassageFlg = true;
                    // 20150120 sou End
                    new SuishitsuIjoPrintBtnClickFollowApplicationLogic().Execute(foAlInput);
                }

                //MessageForm.Show2(MessageForm.DispModeType.Infomation, "出力が完了しました。");
                if(kekkaMsg != string.Empty)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Infomation, kekkaMsg + "は出力データがありません。");
                }

            }

            return;
        }
        #endregion

        #region 検査項目の表示＆非表示を判定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ChangeDisplayColumn
        /// <summary>
        /// 一覧全体で全く結果値が入力されていない列は非表示にする。初回と再検査はセットとして考える。
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2015/01/29　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ChangeDisplayColumn()
        {
            #region 初期化
            bool ph = false;
            bool tr = false;
            bool bod = false;
            bool zanen = false;
            bool cl = false;
            bool atubod = false;

            int colCount = 0;
            #endregion

            #region 判定
            if (suishitsuKensaRadioButton.Checked)
            {
                // 水質検査
                ph = true;
                tr = true;
                bod = true;
                zanen = true;
                cl = true;
                atubod = false;
            }
            else
            {
                // 外観検査
                ph = false;
                tr = false;
                bod = true;
                zanen = false;
                cl = true;
                atubod = true;
            }
            #endregion

            #region 項目毎の表示切替
            SetDisplayColumn(ph1Col.Index, ph);
            SetDisplayColumn(bod1Col.Index, bod);
            SetDisplayColumn(tr1Col.Index, tr);
            SetDisplayColumn(zanen1Col.Index, zanen);
            SetDisplayColumn(cl1Col.Index, cl);
            SetDisplayColumn(atubod1Col.Index, atubod);
            #endregion

            #region 表示項目のヘッダの背景色を設定
            if (ph) SetHeaderBackColor(ph1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (tr) SetHeaderBackColor(tr1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (bod) SetHeaderBackColor(bod1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (zanen) SetHeaderBackColor(zanen1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (cl) SetHeaderBackColor(cl1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            if (atubod) SetHeaderBackColor(atubod1Col.Index, colCount++ % 2 == 1 ? Color.LawnGreen : Color.Gold);
            #endregion
        }
        #endregion

        #region 検査項目の表示＆非表示設定
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetDisplayColumn
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付        担当者    内容
        /// 2015/01/29　宗        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetDisplayColumn(int index, bool disp)
        {
            if (index == ph1Col.Index)
            {
                listDataGridView.Columns[index].Visible = disp;
                listDataGridView.Columns[index + 1].Visible = disp;
                listDataGridView.Columns[index + 2].Visible = disp;
                listDataGridView.Columns[index + 3].Visible = disp;
                listDataGridView.Columns[index + 4].Visible = disp;

                listDataGridView.Columns[index + 7].Visible = disp;
                listDataGridView.Columns[index + 8].Visible = disp;
                listDataGridView.Columns[index + 9].Visible = disp;
                listDataGridView.Columns[index + 10].Visible = disp;
                listDataGridView.Columns[index + 11].Visible = disp;
            }
            else
            {
                listDataGridView.Columns[index].Visible = disp;
                listDataGridView.Columns[index + 1].Visible = disp;
                listDataGridView.Columns[index + 2].Visible = disp;
                listDataGridView.Columns[index + 3].Visible = disp;

                listDataGridView.Columns[index + 6].Visible = disp;
                listDataGridView.Columns[index + 7].Visible = disp;
                listDataGridView.Columns[index + 8].Visible = disp;
                listDataGridView.Columns[index + 9].Visible = disp;
            }
        }
        #endregion

        #endregion

    }
    #endregion
}
