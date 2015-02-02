using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common;
using FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaIraiToroku7jo;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KatashikiMstDataSetTableAdapters;
using FukjBizSystem.Application.Utility;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri
{
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaIraiToroku7jo
    /// <summary>
    /// ７条依頼入力
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/xx  habu        新規作成
    /// 2015/01/29  小松　　    要望対応:#8545((要望)【7条検査依頼入力】各項目対応)
    /// 2015/01/30  小松　　    要望対応:#8546((要望)【7条検査依頼入力】編集対応)
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KensaIraiToroku7jo : FukjBaseForm
    {
        #region 定義(public)

        #region 表示モード
        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Add,        // 登録モード
            Edit,       // 編集モード
            Detail,     // 詳細
            Confirm,    // 入力確認
            AddExistsJokaso, // 詳細モード(既存浄化槽台帳紐付け)
        }
        #endregion

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// displayMode
        /// </summary>
        private DispMode _displayMode = DispMode.Add;
        /// <summary>
        /// 
        /// </summary>
        private DispMode _initDisplayMode = DispMode.Add;

        private KensaIraishoDisplay frmdisp;

        // 画面位置管理クラス
        private FormLocation formLocation = new FormLocation();

        #region 画面起動引数
        /// <summary>
        /// _iraiHokenjoCd
        /// </summary>
        private string _iraiHokenjoCd = string.Empty;

        /// <summary>
        /// _iraiNendo
        /// </summary>
        private string _iraiNendo = string.Empty;

        /// <summary>
        /// _iraiRenban
        /// </summary>
        private string _iraiRenban = string.Empty;

        /// <summary>
        /// _jokasoHokenjoCd
        /// </summary>
        private string _jokasoHokenjoCd = string.Empty;

        /// <summary>
        /// _jokasoNendo
        /// </summary>
        private string _jokasoNendo = string.Empty;

        /// <summary>
        /// _jokasoRenban
        /// </summary>
        private string _jokasoRenban = string.Empty;
        #endregion

        #region 処理状態保持データ

        /// <summary>
        /// 検査依頼情報
        /// </summary>
        private KensaIraiTblDataSet.KensaIraiTblDataTable _editDataTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

        /// <summary>
        /// 浄化槽台帳情報
        /// </summary>
        private JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable _editDataTableDaicho = new JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable();

        /// <summary>
        /// 前受金
        /// </summary>
        private MaeukekinTblDataSet.MaeukekinTblDataTable _maeukekinDT = new MaeukekinTblDataSet.MaeukekinTblDataTable();

        private DataTable _lockDataTable = new DataTable();

        private DataTable _lockDataTableDaicho = new DataTable();

        /// <summary>
        /// コントロールデータマッピング
        /// </summary>
        private DataBindingHelper _inDataBind;
        /// <summary>
        /// コントロールデータマッピング
        /// </summary>
        private DataBindingHelper _outDataBind;

        /// <summary>
        /// コントロールデータマッピング
        /// </summary>
        private DataBindingHelper _outDataBindKanrenFile;
        /// <summary>
        /// コントロールデータマッピング
        /// </summary>
        private DataBindingHelper _inDataBindDaicho;
        /// <summary>
        /// コントロールデータマッピング
        /// </summary>
        private DataBindingHelper _outDataBindDaicho;

        FukjBizSystem.Control.ZTextBox _shoriHoshikiKbn = new Control.ZTextBox();
        FukjBizSystem.Control.ZTextBox _shoriHoshikiCd = new Control.ZTextBox();
        FukjBizSystem.Control.ZTextBox _shoriHoshikiShubetsu = new Control.ZTextBox();

        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        public KensaIraiToroku7jo()
        {
            this._initDisplayMode = DispMode.Add;

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hokenjoCd"></param>
        /// <param name="torokuNendo"></param>
        /// <param name="renban"></param>
        public KensaIraiToroku7jo(string hokenjoCd, string nendo, string renban)
        {
            this._iraiHokenjoCd = hokenjoCd;
            this._iraiNendo = nendo;
            this._iraiRenban = renban;

            this._initDisplayMode = DispMode.Detail;

            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hokenjoCd"></param>
        /// <param name="torokuNendo"></param>
        /// <param name="renban"></param>
        public KensaIraiToroku7jo(string hokenjoCd, string nendo, string renban, DispMode initDisplayMode)
        {
            if (initDisplayMode == DispMode.AddExistsJokaso)
            {
                this._jokasoHokenjoCd = hokenjoCd;
                this._jokasoNendo = nendo;
                this._jokasoRenban = renban;

                this._initDisplayMode = initDisplayMode;
            }
            else
            {
                this._iraiHokenjoCd = hokenjoCd;
                this._iraiNendo = nendo;
                this._iraiRenban = renban;

                this._initDisplayMode = initDisplayMode;
            }

            InitializeComponent();
        }
        #endregion

        #region Events

        #region KensaIraiToroku7jo_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaIraiToroku7jo_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // メニュー無効化
                Program.mForm.SetMenuEnabled(false);

                // Set control domain
                SetControlDomain();

                // Set data mapping
                // DB -> Form
                _inDataBind = InitInDataMapping();
                // Form -> DB
                _outDataBind = InitOutDataMapping();

                // 関連ファイルテーブル向け
                _outDataBindKanrenFile = InitOutDataMappingKanrenFile();

                // 浄化槽台帳マスタ向け
                _inDataBindDaicho = InitInDataMappingDaicho();

                _outDataBindDaicho = InitOutDataMappingDaicho();

                // Set Std Control Event
                SetStdHandler();

                if (_initDisplayMode != DispMode.Detail)
                {
                    // 詳細モード時は、PDFは関係しない

                    // 受付ファイルが無い場合は、画面を終了する
                    if (!CheckFileExists())
                    {
                        string path = Properties.Settings.Default.PdfRootDir;

                        MessageForm.Show2(MessageForm.DispModeType.Warning, "未処理の検査依頼書ファイルがありません。\n画面を終了します。");
                        // TODO 仮メッセージ。いずれ削除する
                        MessageForm.Show2(MessageForm.DispModeType.Warning, string.Format("機能説明:\n{0}に存在するPDFファイルが処理対象になります。", path));

                        // エラー終了扱いとし、画面を閉じる
                        this.DialogResult = DialogResult.Abort;

                        CloseForm();

                        // メニュー有効化
                        Program.mForm.SetMenuEnabled(true);

                        return;
                    }
                }

                // 初期登録時は、システム日時を年度として初期設定する
                DateTime sysDt = Common.Common.GetCurrentTimestamp();

                // 画面起動引数チェック
                if (_initDisplayMode == DispMode.Add)
                {
                    this._displayMode = this._initDisplayMode;

                    // 20150119 habu 年度は西暦で扱う
                    string nendo = Utility.DateUtility.GetNendo(sysDt).ToString();
                    //nendo = Common.Common.ConvertToHoshouNendoWareki(nendo);

                    iraiNendoTextBox.Text = nendo;
                    hokenjoJyuriNendoTextBox.Text = nendo;

                    // デフォルト値設定
                    bodJyokyoTextBox.Text = "20";
                    shoriMokuhyoBodComboBox.SelectedValue = 90;
                    // 受付日
                    uketsukeNenTextBox.Text = sysDt.Year.ToString();
                    uketsukeTsukiTextBox.Text = sysDt.Month.ToString().PadLeft(2, '0');
                    uketsukeBiTextBox.Text = sysDt.Day.ToString().PadLeft(2, '0');
                }
                else if (_initDisplayMode == DispMode.AddExistsJokaso)
                {
                    this._displayMode = this._initDisplayMode;

                    // 20150119 habu 年度は西暦で扱う
                    string nendo = Utility.DateUtility.GetNendo(sysDt).ToString();
                    //nendo = Common.Common.ConvertToHoshouNendoWareki(nendo);

                    iraiNendoTextBox.Text = nendo;

                    // 表示データ取得(浄化槽情報)
                    GetControlDataDaicho();

                    // 表示データ設定(浄化槽情報)
                    SetControlDataDaicho();

                    // 受付日
                    string uketsukeDt = this._editDataTableDaicho[0].JokasoUketsukeBi;
                    DateTime tempDT;
                    if (!string.IsNullOrEmpty(uketsukeDt) &&
                        DateTime.TryParseExact(uketsukeDt, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out tempDT))
                    {
                        uketsukeNenTextBox.Text = tempDT.Year.ToString();
                        uketsukeTsukiTextBox.Text = tempDT.Month.ToString().PadLeft(2, '0');
                        uketsukeBiTextBox.Text = tempDT.Day.ToString().PadLeft(2, '0');
                    }
                }
                else if (_initDisplayMode == DispMode.Detail)
                {
                    this._displayMode = this._initDisplayMode;

                    // 表示データ取得
                    GetControlData();

                    // 表示データ設定
                    SetControlData();

                    // 受付日
                    string uketsukeDt = this._editDataTableDaicho[0].JokasoUketsukeBi;
                    DateTime tempDT;
                    if (!string.IsNullOrEmpty(uketsukeDt) &&
                        DateTime.TryParseExact(uketsukeDt, "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out tempDT))
                    {
                        uketsukeNenTextBox.Text = tempDT.Year.ToString();
                        uketsukeTsukiTextBox.Text = tempDT.Month.ToString().PadLeft(2, '0');
                        uketsukeBiTextBox.Text = tempDT.Day.ToString().PadLeft(2, '0');
                    }
                }

                // 受付日、設置日、使用開始日の和暦表示
                convertDispDateToWareki();

                // 検査手数料をセット
                setKensaRyokin();

                SetDisplayControl();

                if (_initDisplayMode != DispMode.Detail)
                {
                    // 詳細モード時は、PDFは関係しない

                    // open sub form
                    frmdisp = new KensaIraishoDisplay(this);
                    frmdisp.Show();

                    // 保存画面位置取得(親フォーム(枠部分)に対して行う)
                    Program.mForm.Location = formLocation.GetPoint(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this);
                    Program.mForm.Size = formLocation.GetSize(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, this.Size);
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                // エラー終了扱いとし、画面を閉じる
                this.DialogResult = DialogResult.Abort;

                CloseForm();

                // Load中にエラーになった場合、FormClosingが実行されない場合があるため、ここで子画面を閉じる
                if (this.frmdisp != null)
                {
                    // 子画面を閉じる
                    this.frmdisp.Close();
                }

                // メニュー有効化
                Program.mForm.SetMenuEnabled(true);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
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
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    CloseForm();
                });
        }
        #endregion

        #region entryButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void entryButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 入力チェック
                    if (!DoValidate())
                    {
                        return;
                    }

                    this._displayMode = DispMode.Confirm;

                    SetDisplayControl();
                });
        }
        #endregion

        #region changeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (this._displayMode == DispMode.Edit)
                    {
                        // 入力チェック
                        if (!DoValidate())
                        {
                            return;
                        }

                        this._displayMode = DispMode.Confirm;
                    }
                    else if (this._displayMode == DispMode.Detail)
                    {
                        this._displayMode = DispMode.Edit;
                    }

                    SetDisplayControl();
                });
        }
        #endregion

        #region deleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {

                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？") == DialogResult.Yes)
                    {
                        IDeleteBtnCllickALInput input = new DeleteBtnCllickALInput();
                        input.HokenjoCd = _iraiHokenjoCd;
                        input.IraiNendo = _iraiNendo;
                        input.Renban = _iraiRenban;

                        IDeleteBtnCllickALOutput output = new DeleteBtnCllickApplicationLogic().Execute(input);

                        // Target data not exists(JokasoDaichoMst)
                        if (!string.IsNullOrEmpty(output.ErrMessage))
                        {
                            MessageForm.Show2(MessageForm.DispModeType.Error, output.ErrMessage);
                            return;
                        }

                        CloseForm();
                    }
                });
        }
        #endregion

        #region reInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void reInputButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    this._displayMode = this._initDisplayMode;

                    SetDisplayControl();
                });
        }
        #endregion

        #region decisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void decisionButton_Click(object sender, EventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    IDecisionBtnClickALInput alInput = new DecisionBtnClickALInput();

                    //insert data
                    if (_initDisplayMode == DispMode.Add)
                    {
                        #region 更新データ作成(検査依頼)

                        KensaIraiTblDataSet.KensaIraiTblDataTable table = CreateEditInsertData();

                        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable tableFile = CreateEditInsertDataKanrenFile();

                        #endregion

                        // 前受金照合番号1を設定
                        if (kisaiAriRadioButton.Checked)
                        {
                            alInput.MaeukekinSyogoNo1 = Constants.MaeukekinSyogoNo1Constant.MANUAL;
                        }
                        else
                        {
                            alInput.MaeukekinSyogoNo1 = Constants.MaeukekinSyogoNo1Constant.AUTO;
                        }

                        // 前受金照合番号2(1項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo21TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo21 = maeukekinShogoNo21TextBox.Text;
                        }
                        // 前受金照合番号2(2項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo22TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo22 = maeukekinShogoNo22TextBox.Text;
                        }
                        // 前受金照合番号2(3項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo23TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo23 = maeukekinShogoNo23TextBox.Text;
                        }
                        // 前受金照合番号2(4項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo24TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo24 = maeukekinShogoNo24TextBox.Text;
                        }
                        // 前受金照合番号2(5項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo25TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo25 = maeukekinShogoNo25TextBox.Text;
                        }

                        // 処理方式を設定
                        alInput.ShoriHoshikiKbn = _shoriHoshikiKbn.Text;
                        // 人槽を設定
                        alInput.Ninsou = int.Parse(shoriTaishoJininTextBox.Text);

                        #region キー採番(検査依頼)

                        DateTime sysDt = Common.Common.GetCurrentTimestamp();

                        //// 支所ごとの採番区分を使用する(法定支所を使用)
                        //// 法定支所は必須入力されるものとする
                        //string saibanShisho = (string)houteiShishoComboBox.SelectedValue;

                        //string iraiSaibanKbn = Utility.Saiban.GetShishoSaibanKbn(Constants.SaibanKbnConstant.SAIBAN_KBN_GAIKAN_KENSA_PREFIX, saibanShisho);

                        // 保健所コードは必須入力されるものとする
                        string iraihokenjoCd = hokenjoCdTextBox.Text;
                        // 20150119 habu 年度は西暦とする
                        // 年度は必須入力されるものとする
                        string iraiNendo = iraiNendoTextBox.Text;
                        //string iraiNendo = Common.Common.ConvertToHoshouNendoSeireki(iraiNendoTextBox.Text);

                        string iraiRenban = Application.Utility.Saiban.GetSaibanRenban(iraiNendo, Constants.SaibanKbnConstant.SAIBAN_KBN_GAIKAN_KENSA);
                        //string iraiRenban = Application.Utility.Saiban.GetSaibanRenban(iraiNendo, iraiSaibanKbn);

                        // 受理年度、受理連番は手入力されるものとする(デフォルトは現在の年度とする)
                        // 20150119 habu 年度は西暦とする
                        // 受理年度を西暦に変換して設定
                        string jyuriNendo = hokenjoJyuriNendoTextBox.Text;
                        //string jyuriNendo = Common.Common.ConvertToHoshouNendoSeireki(hokenjoJyuriNendoTextBox.Text);

                        // 年度、連番設定
                        foreach (KensaIraiTblDataSet.KensaIraiTblRow row in table)
                        {
                            row.KensaIraiHokenjoCd = iraihokenjoCd;
                            row.KensaIraiNendo = iraiNendo;
                            row.KensaIraiRenban = iraiRenban;

                            row.KensaIraiHokenjoJyuriNendo = jyuriNendo;
                        }

                        foreach (KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow row in tableFile)
                        {
                            row.KensaIraiHokenjoCd = iraihokenjoCd;
                            row.KensaIraiNendo = iraiNendo;
                            row.KensaIraiRenban = iraiRenban;
                        }

                        #endregion

                        #region 更新データ作成(浄化槽台帳)

                        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable tableMst = CreateEditInsertDataDaicho();

                        #endregion

                        #region キー採番(浄化槽台帳)

                        string jokasouHokenjoCd = iraihokenjoCd;
                        string jokasouNendo = iraiNendo;

                        string jokasouRenban = Application.Utility.Saiban.GetSaibanRenban(iraiNendo, Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_JOKASO_DAICHO);

                        foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in tableMst)
                        {
                            row.JokasoHokenjoCd = jokasouHokenjoCd;
                            row.JokasoTorokuNendo = jokasouNendo;
                            row.JokasoRenban = jokasouRenban;

                            // 浄化槽台帳の新規登録時は、設置場所保健所コードを設定する
                            row.JokasoSetchiBashoHokenjoCd = jokasouHokenjoCd;

                            row.JokasoHokenjoJuriNoNendo = jyuriNendo;
                        }

                        #endregion

                        #region 検査依頼に浄化槽を紐付け

                        // 年度、連番設定
                        foreach (KensaIraiTblDataSet.KensaIraiTblRow row in table)
                        {
                            row.KensaIraiJokasoHokenjoCd = jokasouHokenjoCd;
                            row.KensaIraiJokasoTorokuNendo = jokasouNendo;
                            row.KensaIraiJokasoRenban = jokasouRenban;
                        }

                        #endregion

                        alInput.UpdateDataTable = table;
                        alInput.KanrenFileUpdateDataTable = tableFile;
                        alInput.JokasoDaichoMstUpdateDataTable = tableMst;
                    }
                    else if (_initDisplayMode == DispMode.AddExistsJokaso)
                    {
                        #region 更新データ作成(検査依頼)

                        KensaIraiTblDataSet.KensaIraiTblDataTable table = CreateEditInsertData();

                        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable tableFile = CreateEditInsertDataKanrenFile();

                        #endregion

                        // 前受金照合番号1を設定
                        if (kisaiAriRadioButton.Checked)
                        {
                            alInput.MaeukekinSyogoNo1 = Constants.MaeukekinSyogoNo1Constant.MANUAL;
                        }
                        else
                        {
                            alInput.MaeukekinSyogoNo1 = Constants.MaeukekinSyogoNo1Constant.AUTO;
                        }

                        // 前受金照合番号2(1項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo21TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo21 = maeukekinShogoNo21TextBox.Text;
                        }
                        // 前受金照合番号2(2項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo22TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo22 = maeukekinShogoNo22TextBox.Text;
                        }
                        // 前受金照合番号2(3項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo23TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo23 = maeukekinShogoNo23TextBox.Text;
                        }
                        // 前受金照合番号2(4項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo24TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo24 = maeukekinShogoNo24TextBox.Text;
                        }
                        // 前受金照合番号2(5項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo25TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo25 = maeukekinShogoNo25TextBox.Text;
                        }

                        // 処理方式を設定
                        alInput.ShoriHoshikiKbn = _shoriHoshikiKbn.Text;
                        // 人槽を設定
                        alInput.Ninsou = int.Parse(shoriTaishoJininTextBox.Text);

                        #region キー採番(検査依頼)

                        DateTime sysDt = Common.Common.GetCurrentTimestamp();

                        //// 支所ごとの採番区分を使用する(法定支所を使用)
                        //// 法定支所は必須入力されるものとする
                        //string saibanShisho = (string)houteiShishoComboBox.SelectedValue;

                        //string iraiSaibanKbn = Utility.Saiban.GetShishoSaibanKbn(Constants.SaibanKbnConstant.SAIBAN_KBN_GAIKAN_KENSA_PREFIX, saibanShisho);

                        // 保健所コードは必須入力されるものとする
                        string iraihokenjoCd = hokenjoCdTextBox.Text;
                        // 20150119 habu 年度は西暦とする
                        // 年度は必須入力されるものとする
                        string iraiNendo = iraiNendoTextBox.Text;
                        //string iraiNendo = Common.Common.ConvertToHoshouNendoSeireki(iraiNendoTextBox.Text);

                        string iraiRenban = Application.Utility.Saiban.GetSaibanRenban(iraiNendo, Constants.SaibanKbnConstant.SAIBAN_KBN_GAIKAN_KENSA);
                        //string iraiRenban = Application.Utility.Saiban.GetSaibanRenban(iraiNendo, iraiSaibanKbn);

                        // 受理年度、受理連番は手入力されるものとする(デフォルトは現在の年度とする)
                        // 20150119 habu 年度は西暦とする
                        // 受理年度を西暦に変換して設定
                        string jyuriNendo = hokenjoJyuriNendoTextBox.Text;
                        //string jyuriNendo = Common.Common.ConvertToHoshouNendoSeireki(hokenjoJyuriNendoTextBox.Text);

                        // 年度、連番設定
                        foreach (KensaIraiTblDataSet.KensaIraiTblRow row in table)
                        {
                            row.KensaIraiHokenjoCd = iraihokenjoCd;
                            row.KensaIraiNendo = iraiNendo;
                            row.KensaIraiRenban = iraiRenban;

                            row.KensaIraiHokenjoJyuriNendo = jyuriNendo;
                        }

                        foreach (KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow row in tableFile)
                        {
                            row.KensaIraiHokenjoCd = iraihokenjoCd;
                            row.KensaIraiNendo = iraiNendo;
                            row.KensaIraiRenban = iraiRenban;
                        }

                        #endregion

                        #region 更新データ作成(浄化槽台帳)

                        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable tableMst = CreateEditUpdateDataDaicho();

                        #endregion

                        #region キー採番(浄化槽台帳)

                        string jokasouHokenjoCd = _jokasoHokenjoCd;
                        string jokasouNendo = _jokasoNendo;
                        string jokasouRenban = _jokasoRenban;

                        foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in tableMst)
                        {
                            row.JokasoHokenjoCd = jokasouHokenjoCd;
                            row.JokasoTorokuNendo = jokasouNendo;
                            row.JokasoRenban = jokasouRenban;
                        }

                        #endregion

                        #region 検査依頼に浄化槽を紐付け

                        // 年度、連番設定
                        foreach (KensaIraiTblDataSet.KensaIraiTblRow row in table)
                        {
                            row.KensaIraiJokasoHokenjoCd = jokasouHokenjoCd;
                            row.KensaIraiJokasoTorokuNendo = jokasouNendo;
                            row.KensaIraiJokasoRenban = jokasouRenban;
                        }

                        #endregion

                        alInput.UpdateDataTable = table;
                        alInput.KanrenFileUpdateDataTable = tableFile;
                        alInput.JokasoDaichoMstUpdateDataTable = tableMst;
                    }
                    else
                    {
                        #region 更新データ作成

                        KensaIraiTblDataSet.KensaIraiTblDataTable table = CreateEditUpdateData();

                        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable tableMst = CreateEditUpdateDataDaicho();

                        #endregion

                        // 前受金照合番号1を設定
                        if (kisaiAriRadioButton.Checked)
                        {
                            alInput.MaeukekinSyogoNo1 = Constants.MaeukekinSyogoNo1Constant.MANUAL;
                        }
                        else
                        {
                            alInput.MaeukekinSyogoNo1 = Constants.MaeukekinSyogoNo1Constant.AUTO;
                        }

                        // 前受金照合番号2(1項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo21TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo21 = maeukekinShogoNo21TextBox.Text;
                        }
                        // 前受金照合番号2(2項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo22TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo22 = maeukekinShogoNo22TextBox.Text;
                        }
                        // 前受金照合番号2(3項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo23TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo23 = maeukekinShogoNo23TextBox.Text;
                        }
                        // 前受金照合番号2(4項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo24TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo24 = maeukekinShogoNo24TextBox.Text;
                        }
                        // 前受金照合番号2(5項目目)を設定
                        if (!string.IsNullOrEmpty(maeukekinShogoNo25TextBox.Text))
                        {
                            alInput.MaeukekinSyogoNo25 = maeukekinShogoNo25TextBox.Text;
                        }

                        // 処理方式を設定
                        alInput.ShoriHoshikiKbn = _shoriHoshikiKbn.Text;
                        // 人槽を設定
                        alInput.Ninsou = int.Parse(shoriTaishoJininTextBox.Text);

                        #region キー採番(浄化槽台帳)

                        string jokasouHokenjoCd = _editDataTable[0].KensaIraiJokasoHokenjoCd;
                        string jokasouNendo = _editDataTable[0].KensaIraiJokasoTorokuNendo;
                        string jokasouRenban = _editDataTable[0].KensaIraiJokasoRenban;

                        foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in tableMst)
                        {
                            row.JokasoHokenjoCd = jokasouHokenjoCd;
                            row.JokasoTorokuNendo = jokasouNendo;
                            row.JokasoRenban = jokasouRenban;
                        }

                        #endregion

                        #region 検査依頼に浄化槽を紐付け

                        // 年度、連番設定
                        foreach (KensaIraiTblDataSet.KensaIraiTblRow row in table)
                        {
                            row.KensaIraiJokasoHokenjoCd = jokasouHokenjoCd;
                            row.KensaIraiJokasoTorokuNendo = jokasouNendo;
                            row.KensaIraiJokasoRenban = jokasouRenban;
                        }

                        #endregion

                        alInput.UpdateDataTable = table;
                        alInput.LockDataTable = this._lockDataTable;
                        alInput.JokasoDaichoMstUpdateDataTable = tableMst;
                    }

                    IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

                    if (!string.IsNullOrEmpty(alOutput.ErrMessage))
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMessage);
                        return;
                    }

                    // 既存浄化槽紐付けの場合は、そのまま画面を閉じる
                    if (_initDisplayMode == DispMode.AddExistsJokaso)
                    {
                        // 画面を閉じる
                        CloseForm();
                    }
                    // 詳細モードの場合は、そのまま画面を閉じる
                    else if (_initDisplayMode == DispMode.Detail)
                    {
                        // 画面を閉じる
                        CloseForm();
                    }
                    // 新規登録モードの場合は画面は保持
                    else
                    {
                        // 但し、依頼書を全て処理した場合は画面を閉じる
                        if (!CheckFileExists())
                        {
                            // 画面を閉じる
                            CloseForm();
                        }
                        else
                        {
                            // 次の入力の準備
                            nextInputPreparation();
                        }
                    }
                });
        }
        #endregion

        #region KensaIraiToroku7jo_FormClosing
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaIraiToroku7jo_FormClosing(object sender, FormClosingEventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    // 画面位置保存(親フォーム(枠部分)に対して行う)
                    formLocation.SetPoint(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, Program.mForm.Location);
                    formLocation.SetSize(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, Program.mForm.Size);

                    // メニュー有効化
                    Program.mForm.SetMenuEnabled(true);
                });
        }
        #endregion

        #region KensaIraiToroku7jo_FormClosed
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KensaIraiToroku7jo_FormClosed(object sender, FormClosedEventArgs e)
        {
            BoundaryUtility.StdEventSequence(
                delegate()
                {
                    if (this.frmdisp != null)
                    {
                        // 子画面を閉じる
                        this.frmdisp.Close();
                    }
                });
        }
        #endregion

        #region oldChikuCdTextBox_TextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： oldChikuCdTextBox_TextChanged
        /// <summary>
        /// 旧地区コードテキスト変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/29　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void oldChikuCdTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (oldChikuCdTextBox.Text.Trim().Length == 5)
                {
                    // 旧地区コードから地区マスタを引いて支所をセット
                    ChikuMstDataSet.ChikuMstDataTable chikuMstDT = Common.Common.GetChikuMstByKey(oldChikuCdTextBox.Text.Trim());
                    if (chikuMstDT != null && chikuMstDT.Rows.Count > 0)
                    {
                        // 法定支所
                        houteiShishoComboBox.SelectedValue = chikuMstDT[0].HoteiTantoShishoCd;
                        // 水質支所
                        suishitsuShishoComboBox.SelectedValue = chikuMstDT[0].SuishitsuTantoShishoCd;
                    }
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
            }
        }
        #endregion

        #region shoriTaishoJininTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shoriTaishoJininTextBox_Leave
        /// <summary>
        /// 処理対象人員ロストフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shoriTaishoJininTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 検査料金表示
                setKensaRyokin();
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

        #region maeukekinShogoNoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： maeukekinShogoNoTextBox_Leave
        /// <summary>
        /// 前受金照合番号ロストフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void maeukekinShogoNoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!(sender is FukjBizSystem.Control.ZTextBox))
                {
                    return;
                }
                FukjBizSystem.Control.ZTextBox taragetTextBox = (FukjBizSystem.Control.ZTextBox)sender;

                if (string.IsNullOrEmpty(taragetTextBox.Text.Trim()))
                {
                    return;
                }
                string maeukekinSyogoNo2 = taragetTextBox.Text.Trim().PadLeft(6, '0');

                // 前受金情報取得
                MaeukekinTblDataSet.MaeukekinTblDataTable maeukeDT;
                IGetMaukekinTblByKeyALInput alInput = new GetMaukekinTblByKeyALInput();
                if (kisaiAriRadioButton.Checked)
                {
                    alInput.MaeukekinSyogoNo1 = Constants.MaeukekinSyogoNo1Constant.MANUAL;
                }
                else
                {
                    alInput.MaeukekinSyogoNo1 = Constants.MaeukekinSyogoNo1Constant.AUTO;
                }
                alInput.MaeukekinSyogoNo2 = maeukekinSyogoNo2;
                IGetMaukekinTblByKeyALOutput alOutput = new GetMaukekinTblByKeyApplicationLogic().Execute(alInput);
                maeukeDT = alOutput.MaeukekinTblDT;

                // 存在チェック
                if (maeukeDT.Rows.Count <= 0)
                {
                    taragetTextBox.Focus();
                    MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("指定された前受金情報が存在しません。[{0}]", maeukekinSyogoNo2));
                    return;
                }
                // 重複チェック
                {
                    int count = 0;
                    if (maeukekinShogoNo21TextBox.Text == maeukekinSyogoNo2)
                    {
                        count++;
                    }
                    if (maeukekinShogoNo22TextBox.Text == maeukekinSyogoNo2)
                    {
                        count++;
                    }
                    if (maeukekinShogoNo23TextBox.Text == maeukekinSyogoNo2)
                    {
                        count++;
                    }
                    if (maeukekinShogoNo24TextBox.Text == maeukekinSyogoNo2)
                    {
                        count++;
                    }
                    if (maeukekinShogoNo25TextBox.Text == maeukekinSyogoNo2)
                    {
                        count++;
                    }
                    if (count >= 2)
                    {
                        taragetTextBox.Focus();
                        MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("同一の番号の前受金情報が指定されています。[{0}]", maeukekinSyogoNo2));
                        return;
                    }
                }
                // 割当済みチェック（自分以外）
                {
                    MaeukekinTblDataSet.MaeukekinTblRow maeukeRow = (MaeukekinTblDataSet.MaeukekinTblRow)maeukeDT[0];
                    if ((string.IsNullOrEmpty(maeukeRow.MaeukekinKensaIraiHoteiKbn) || maeukeRow.MaeukekinKensaIraiHoteiKbn == "0") &&
                        string.IsNullOrEmpty(maeukeRow.MaeukekinKensaIraiHokenjoCd) &&
                        string.IsNullOrEmpty(maeukeRow.MaeukekinKensaIraiNendo) &&
                        string.IsNullOrEmpty(maeukeRow.MaeukekinKensaIraiRenban))
                    {
                        // 未設定はOK
                    }
                    else if (maeukeRow.MaeukekinKensaIraiHoteiKbn != Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN ||
                        maeukeRow.MaeukekinKensaIraiHokenjoCd != _iraiHokenjoCd ||
                        maeukeRow.MaeukekinKensaIraiNendo != _iraiNendo ||
                        maeukeRow.MaeukekinKensaIraiRenban != _iraiRenban)
                    {
                        // 設定済で自分以外は、エラー
                        taragetTextBox.Focus();
                        MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("既に割り当て済みの前受金情報が指定されています。[{0}]", maeukekinSyogoNo2));
                        return;
                    }
                }
                // 合計＞検査料金チェック
                {
                    decimal maeukekinNyukinAmtSum = 0;
                    if (!string.IsNullOrEmpty(maeukekinShogoNo21TextBox.Text.Trim()))
                    {
                        alInput.MaeukekinSyogoNo2 = maeukekinShogoNo21TextBox.Text.Trim();
                        alOutput = new GetMaukekinTblByKeyApplicationLogic().Execute(alInput);
                        if (alOutput.MaeukekinTblDT.Rows.Count > 0)
                        {
                            maeukekinNyukinAmtSum += alOutput.MaeukekinTblDT[0].MaeukekinNyukinAmt;
                        }
                    }
                    if (!string.IsNullOrEmpty(maeukekinShogoNo22TextBox.Text.Trim()))
                    {
                        alInput.MaeukekinSyogoNo2 = maeukekinShogoNo22TextBox.Text.Trim();
                        alOutput = new GetMaukekinTblByKeyApplicationLogic().Execute(alInput);
                        if (alOutput.MaeukekinTblDT.Rows.Count > 0)
                        {
                            maeukekinNyukinAmtSum += alOutput.MaeukekinTblDT[0].MaeukekinNyukinAmt;
                        }
                    }
                    if (!string.IsNullOrEmpty(maeukekinShogoNo23TextBox.Text.Trim()))
                    {
                        alInput.MaeukekinSyogoNo2 = maeukekinShogoNo23TextBox.Text.Trim();
                        alOutput = new GetMaukekinTblByKeyApplicationLogic().Execute(alInput);
                        if (alOutput.MaeukekinTblDT.Rows.Count > 0)
                        {
                            maeukekinNyukinAmtSum += alOutput.MaeukekinTblDT[0].MaeukekinNyukinAmt;
                        }
                    }
                    if (!string.IsNullOrEmpty(maeukekinShogoNo24TextBox.Text.Trim()))
                    {
                        alInput.MaeukekinSyogoNo2 = maeukekinShogoNo24TextBox.Text.Trim();
                        alOutput = new GetMaukekinTblByKeyApplicationLogic().Execute(alInput);
                        if (alOutput.MaeukekinTblDT.Rows.Count > 0)
                        {
                            maeukekinNyukinAmtSum += alOutput.MaeukekinTblDT[0].MaeukekinNyukinAmt;
                        }
                    }
                    if (!string.IsNullOrEmpty(maeukekinShogoNo25TextBox.Text.Trim()))
                    {
                        alInput.MaeukekinSyogoNo2 = maeukekinShogoNo25TextBox.Text.Trim();
                        alOutput = new GetMaukekinTblByKeyApplicationLogic().Execute(alInput);
                        if (alOutput.MaeukekinTblDT.Rows.Count > 0)
                        {
                            maeukekinNyukinAmtSum += alOutput.MaeukekinTblDT[0].MaeukekinNyukinAmt;
                        }
                    }

                    decimal kensaRyokin = 0;
                    int ninsou = 0;
                    if (int.TryParse(shoriTaishoJininTextBox.Text, out ninsou))
                    {
                        // 法定検査料金マスタ取得(人槽から)
                        HoteiKensaRyokinMstDataSet.HoteiKensaRyokinMstRow ryokinRow = Boundary.Common.Common.GetHoteiKensaRyokinMstByNinsou(ninsou);
                        if (ryokinRow != null)
                        {
                            if (_shoriHoshikiKbn.Text == Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU)
                            {
                                kensaRyokin = ryokinRow.TandokuKingaku7Jo;
                            }
                            else
                            {
                                kensaRyokin = ryokinRow.GappeiKingaku7Jo;
                            }
                        }
                    }

                    if (kensaRyokin < maeukekinNyukinAmtSum)
                    {
                        // 前受金合計超
                        taragetTextBox.Focus();
                        MessageForm.Show2(MessageForm.DispModeType.Error, string.Format("前受金合計値が検査手数料を超えた金額になります。\n検査手数料：[{0}] 前受金合計[{1}]", kensaRyokin.ToString("#,##0"), maeukekinNyukinAmtSum.ToString("#,##0")));
                        return;
                    }
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

        #region dateTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： dateTextBox_Leave
        /// <summary>
        /// 日付(受付日、設置日、使用開始日)入力域ロストフォーカスイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void dateTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            try
            {
                // 受付日、設置日、使用開始日の和暦表示
                convertDispDateToWareki();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region copyButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： copyButton_Click
        /// <summary>
        /// 設置者情報コピーボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void copyButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            try
            {
                // 設置者情報コピー
                shiyoshaNmTextBox.Text = setchishaNmTextBox.Text;
                shiyoshaZipCdTextBox.Text = setchishaZipCdTextBox.Text;
                shiyoshaAdrTextBox.Text = setchishaAdrTextBox.Text;
                shiyoshaTelNoTextBox.Text = setchishaTelNoTextBox.Text;
                shisetsuNmTextBox.Text = setchishaNmTextBox.Text;
                setchibashoZipCdTextBox.Text = setchishaZipCdTextBox.Text;
                setchibashoAdrTextBox.Text = setchishaAdrTextBox.Text;
                setchibashoTelNoTextBox.Text = setchishaTelNoTextBox.Text;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region setchiKbnComboBox_SelectedValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setchiKbnComboBox_SelectedValueChanged
        /// <summary>
        /// 市町村設置区分値変更イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setchiKbnComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            try
            {
                if (string.IsNullOrEmpty(setchiKbnComboBox.Text))
                {
                    // 市町村設置区分値が空白ならコピー可
                    copyButton.Enabled = true;
                }
                else
                {
                    copyButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region Methods

        #region GetControlData
        /// <summary>
        /// 表示データ取得(詳細モード：Detail)
        /// </summary>
        private void GetControlData()
        {
            IFormLoadALInput alInput = new FormLoadALInput();

            alInput.IraiHokenjoCd = this._iraiHokenjoCd;
            alInput.IraiNendo = this._iraiNendo;
            alInput.IraiRenban = this._iraiRenban;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            this._editDataTable = alOutput.EditDataTable;
            this._editDataTableDaicho = alOutput.EditDataTableDaicho;
            this._maeukekinDT = alOutput.MaeukekinDT;

            this._lockDataTable = alOutput.LockTable;
            this._lockDataTableDaicho = alOutput.DaichoLockTable;
        }
        #endregion

        #region GetControlDataDaicho
        /// <summary>
        /// 表示データ取得(詳細モード(既存浄化槽台帳紐付け)：AddExistsJokaso)
        /// </summary>
        private void GetControlDataDaicho()
        {
            IFormLoadALInput alInput = new FormLoadALInput();

            alInput.JokasoHokenjoCd = this._jokasoHokenjoCd;
            alInput.JokasoNendo = this._jokasoNendo;
            alInput.JokasoRenban = this._jokasoRenban;

            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            this._editDataTable = alOutput.EditDataTable;
            this._editDataTableDaicho = alOutput.EditDataTableDaicho;
            this._maeukekinDT = alOutput.MaeukekinDT;

            this._lockDataTable = alOutput.LockTable;
            this._lockDataTableDaicho = alOutput.DaichoLockTable;
        }
        #endregion

        #region SetControlData
        /// <summary>
        /// 表示データ設定(詳細モード：Detail)
        /// </summary>
        private void SetControlData()
        {
            // 浄化槽台帳側の情報をマッピングする
            _inDataBindDaicho.FillToControl(_editDataTableDaicho);

            // 検査依頼側の情報をマッピングする
            _inDataBind.FillToControl(_editDataTable);

            // 前受金情報表示
            int maeukekinMax = _maeukekinDT.Rows.Count;
            if (maeukekinMax > 5)
            {
                maeukekinMax = 5;
            }
            DataRow[] rows = _maeukekinDT.Select(string.Empty, "MaeukekinSyogoNo2");
            for (int i = 0; i < maeukekinMax; i++)
            {
                MaeukekinTblDataSet.MaeukekinTblRow row = (MaeukekinTblDataSet.MaeukekinTblRow)rows[i];
                switch (i)
                {
                    case 0:
                        maeukekinShogoNo21TextBox.Text = row.MaeukekinSyogoNo2;
                        break;
                    case 1:
                        maeukekinShogoNo22TextBox.Text = row.MaeukekinSyogoNo2;
                        break;
                    case 2:
                        maeukekinShogoNo23TextBox.Text = row.MaeukekinSyogoNo2;
                        break;
                    case 3:
                        maeukekinShogoNo24TextBox.Text = row.MaeukekinSyogoNo2;
                        break;
                    case 4:
                        maeukekinShogoNo25TextBox.Text = row.MaeukekinSyogoNo2;
                        break;
                }
            }
        }
        #endregion

        #region SetControlDataDaicho
        /// <summary>
        /// 表示データ設定(詳細モード(既存浄化槽台帳紐付け)：AddExistsJokaso)
        /// </summary>
        private void SetControlDataDaicho()
        {
            // 浄化槽台帳側の情報をマッピングする
            _inDataBindDaicho.FillToControl(_editDataTableDaicho);

            // 20150119 habu 年度は西暦で扱う
            //// 登録年度を和暦に変換
            //hokenjoJyuriNendoTextBox.Text = Common.Common.ConvertToHoshouNendoWareki(hokenjoJyuriNendoTextBox.Text);
        }
        #endregion

        #region SetDisplayControl
        /// <summary>
        /// 
        /// </summary>
        private void SetDisplayControl()
        {
            #region db value controls

            bool disabled = true;
            bool keyContDisabled = true;

            // 編集不可モードの場合は、各コントロールを無効にする
            if (_displayMode == DispMode.Confirm || _displayMode == DispMode.Detail || _displayMode == DispMode.Edit)
            {
                keyContDisabled = true;
            }
            else if (_displayMode == DispMode.Add || _displayMode == DispMode.AddExistsJokaso)
            {
                keyContDisabled = false;
            }
            if (_displayMode == DispMode.Confirm || _displayMode == DispMode.Detail)
            {
                disabled = true;
            }
            else if (_displayMode == DispMode.Add || _displayMode == DispMode.AddExistsJokaso || _displayMode == DispMode.Edit)
            {
                disabled = false;
            }

            {
                hokenjoCdTextBox.ReadOnly = keyContDisabled;
                iraiNendoTextBox.ReadOnly = keyContDisabled;

                hokenjoJyuriNendoTextBox.ReadOnly = disabled;
                hokenjoJyuriRenbanTextBox.ReadOnly = disabled;

                houteiShishoComboBox.Enabled = !disabled;
                suishitsuShishoComboBox.Enabled = !disabled;

                #region 受付日
                if (_displayMode == DispMode.Add)
                {
                    uketsukeNenTextBox.ReadOnly = false;
                    uketsukeTsukiTextBox.ReadOnly = false;
                    uketsukeBiTextBox.ReadOnly = false;
                }
                else
                {
                    uketsukeNenTextBox.ReadOnly = true;
                    uketsukeTsukiTextBox.ReadOnly = true;
                    uketsukeBiTextBox.ReadOnly = true;
                }
                #endregion

                #region Tab1

                #region 設置者

                setchishaNmTextBox.ReadOnly = disabled;
                setchishaKanaTextBox.ReadOnly = disabled;
                setchishaZipCdTextBox.ReadOnly = disabled;
                setchishaAdrTextBox.ReadOnly = disabled;
                setchishaTelNoTextBox.ReadOnly = disabled;

                setchiKbnComboBox.Enabled = !disabled;

                #endregion

                #region 使用者

                shiyoshaNmTextBox.ReadOnly = disabled;
                shiyoshaZipCdTextBox.ReadOnly = disabled;
                shiyoshaAdrTextBox.ReadOnly = disabled;
                shiyoshaTelNoTextBox.ReadOnly = disabled;

                #endregion

                #region 設置場所

                konkyoHoreiComboBox.Enabled = !disabled;

                shisetsuNmTextBox.ReadOnly = disabled;
                setchibashoZipCdTextBox.ReadOnly = disabled;
                setchibashoAdrTextBox.ReadOnly = disabled;
                setchibashoTelNoTextBox.ReadOnly = disabled;

                oldChikuCdTextBox.ReadOnly = disabled;
                nowChikuCdTextBox.ReadOnly = disabled;

                chikuwariComboBox.Enabled = !disabled;

                #endregion

                #endregion

                #region Tab2

                #region 型式等

                makerCdTextBox.ReadOnly = disabled;
                katashikiTextBox.ReadOnly = disabled;

                koujiKbnComboBox.Enabled = !disabled;
                //koujiKbnTextBox.ReadOnly = disabled;
                koujiNenTextBox.ReadOnly = disabled;
                koujiNoTextBox.ReadOnly = disabled;
                ninteiNoTextBox.ReadOnly = disabled;

                tatemonoYoto1ComboBox.Enabled = !disabled;
                tatemonoYoto2ComboBox.Enabled = !disabled;
                tatemonoYoto3ComboBox.Enabled = !disabled;
                tatemonoYoto4ComboBox.Enabled = !disabled;
                tatemonoYoto5ComboBox.Enabled = !disabled;

                // 旧建築用途コード
                oldTatemonoYotoComboBox.Enabled = !disabled;

                nobeMensekiTextBox.ReadOnly = disabled;

                #endregion

                #endregion

                #region Tab3

                shoriMokuhyoBodComboBox.Enabled = !disabled;

                hiHeikinOsuiRyoTextBox.ReadOnly = disabled;
                bodJyokyoTextBox.ReadOnly = disabled;

                horyusakiComboBox.Enabled = !disabled;

                DisupozaCheckBox.Enabled = !disabled;

                #region 設置日、使用開始日

                chakkoNenTextBox.ReadOnly = disabled;
                chakkoTsukiTextBox.ReadOnly = disabled;
                chakkoBiTextBox.ReadOnly = disabled;

                shiyokaishiNenTextBox.ReadOnly = disabled;
                shiyokaishiTsukiTextBox.ReadOnly = disabled;
                shiyokaishiBiTextBox.ReadOnly = disabled;

                #endregion

                #region 工事業者,保守点検業者

                koujiGyoshaCdTextBox.ReadOnly = disabled;
                hoshuYoteiGyoshaCdTextBox.ReadOnly = disabled;

                #endregion

                #region 人槽・処理方式

                shoriTaishoJininTextBox.ReadOnly = disabled;

                #endregion

                #region 前受金

                kisaiAriRadioButton.Enabled = !disabled;
                kisaiNashiRadioButton.Enabled = !disabled;
                maeukekinShogoNo21TextBox.ReadOnly = disabled;
                maeukekinShogoNo22TextBox.ReadOnly = disabled;
                maeukekinShogoNo23TextBox.ReadOnly = disabled;
                maeukekinShogoNo24TextBox.ReadOnly = disabled;
                maeukekinShogoNo25TextBox.ReadOnly = disabled;

                #endregion

                #region 業者情報

                saisuiGyoshaCdTextBox.ReadOnly = disabled;
                mochikomiGyoshaCdTextBox.ReadOnly = disabled;
                seikyuGyoshaCdTextBox.ReadOnly = disabled;
                itkatsuSeikyuGyoshaCdTextBox.ReadOnly = disabled;

                #endregion

                #endregion

                #region 検索ボタン類

                setchishaZipKensakuButton.Enabled = !disabled;
                shiyoshaZipKensakuButton.Enabled = !disabled;
                setchibashoZipKensakuButton.Enabled = !disabled;

                makerKensakuButton.Enabled = !disabled;
                katashikiKensakuButton.Enabled = !disabled;

                koujiGyoshaKensakuButton.Enabled = !disabled;
                hoshuYoteiGyoshaKensakuButton.Enabled = !disabled;
                shoriHoshikiKensakuButton.Enabled = !disabled;

                saisuiGyoshaKensakuButton.Enabled = !disabled;
                motikomiGyoshaKensakuButton.Enabled = !disabled;
                seikyuGyoshaKensakuButton.Enabled = !disabled;
                itkatsuSeikyuGyoshaKensakuButton.Enabled = !disabled;

                #endregion
            }

            // 常に無効の項目(マスタ名称など)
            disabled = true;
            {
                iraiRenbanTextBox.ReadOnly = disabled;

                makerNmTextBox.ReadOnly = disabled;
                shohinNmTextBox.ReadOnly = disabled;
                shoriHoshikiShubetsuNmTextBox.ReadOnly = disabled;
                shoriHoshikiNmTextBox.ReadOnly = disabled;
                koujiGyoshaNmTextBox.ReadOnly = disabled;
                hoshuYoteiGyoshaNmTextBox.ReadOnly = disabled;

                kensaRyokinTextBox.ReadOnly = disabled;
            }

            #endregion

            #region command buttons

            entryButton.Visible = (this._displayMode == DispMode.Add || this._displayMode == DispMode.AddExistsJokaso) ? true : false;

            changeButton.Visible = (this._displayMode == DispMode.Detail || this._displayMode == DispMode.Edit) ? true : false;

            deleteButton.Visible = (this._displayMode == DispMode.Detail) ? true : false;

            reInputButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            decisionButton.Visible = (this._displayMode == DispMode.Confirm) ? true : false;

            #endregion
        }
        #endregion

        #region CreateEditInsertData
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateEditInsertData()
        {
            KensaIraiTblDataSet.KensaIraiTblDataTable table = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            _outDataBind.FillToDataRow(table, now, username, host, true);

            // 検査依頼ステータスを設定
            foreach (KensaIraiTblDataSet.KensaIraiTblRow row in table)
            {
                row.KensaIraiStatusKbn = Utility.Constants.KensaIraiStatusConstant.STATUS_IRAI_TOROKU;
            }

            foreach (DataRow row in table.Rows)
            {
                row.AcceptChanges();
                row.SetAdded();
            }

            return table;
        }
        #endregion

        #region CreateEditUpdateData
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateEditUpdateData()
        {
            KensaIraiTblDataSet.KensaIraiTblDataTable table = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            _outDataBind.FillToDataRow(table, now, username, host, false);

            // 検査依頼ステータスを設定
            foreach (KensaIraiTblDataSet.KensaIraiTblRow row in table)
            {
                row.KensaIraiStatusKbn = Utility.Constants.KensaIraiStatusConstant.STATUS_IRAI_TOROKU;
            }

            foreach (DataRow row in table.Rows)
            {
                row.AcceptChanges();
                row.SetModified();
            }

            return table;
        }
        #endregion

        #region CreateEditInsertDataDaicho
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private JokasoDaichoMstDataSet.JokasoDaichoMstDataTable CreateEditInsertDataDaicho()
        {
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable table = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            _outDataBindDaicho.FillToDataRow(table, now, username, host, true);

            foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in table.Rows)
            {
                const int destLen = 10;
                // 設置者カナを浄化槽台帳の検索カナに設定する
                if (!string.IsNullOrEmpty(setchishaKanaTextBox.Text))
                {
                    string kensakuKana = string.Empty;
                    if (setchishaKanaTextBox.Text.Length > destLen)
                    {
                        kensakuKana = setchishaKanaTextBox.Text.Substring(0, destLen).Trim();
                    }
                    else
                    {
                        kensakuKana = setchishaKanaTextBox.Text.Trim();
                    }

                    row.JokasoKensakuKana = kensakuKana;
                }

                // 20150119 habu 年度は西暦とする
                //row.JokasoTorokuNendo = Common.Common.ConvertToHoshouNendoSeireki(row.JokasoTorokuNendo);
                //row.JokasoHokenjoJuriNoNendo = Common.Common.ConvertToHoshouNendoSeireki(row.JokasoHokenjoJuriNoNendo);

                // 浄化槽状態は、新規登録時は1:現行
                row.JokasoJotaiKbn = Utility.Constants.JokasoJotaiKbnConstant.GENZAI;

                // 受付日 = 登録日とする
                //row.JokasoUketsukeBi = now.ToString("yyyyMMdd");
                row.JokasoUketsukeBi = string.Empty;
                if (!string.IsNullOrEmpty(uketsukeNenTextBox.Text) && !string.IsNullOrEmpty(uketsukeTsukiTextBox.Text) && !string.IsNullOrEmpty(uketsukeBiTextBox.Text))
                {
                    DateTime tempDT;
                    if (DateTime.TryParseExact(uketsukeNenTextBox.Text + uketsukeTsukiTextBox.Text.PadLeft(2, '0') + uketsukeBiTextBox.Text.PadLeft(2, '0'),
                        "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out tempDT))
                    {
                        row.JokasoUketsukeBi = tempDT.ToString("yyyyMMdd");
                    }
                }
            }

            foreach (DataRow row in table.Rows)
            {
                row.AcceptChanges();
                row.SetAdded();
            }

            return table;
        }
        #endregion

        #region CreateEditUpdateDataDaicho
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private JokasoDaichoMstDataSet.JokasoDaichoMstDataTable CreateEditUpdateDataDaicho()
        {
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable table = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            // ロード時のデータをコピーする
            _outDataBindDaicho.CopyDataTable(table, _editDataTableDaicho);

            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            _outDataBindDaicho.FillToDataRow(table, now, username, host, true);

            foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in table.Rows)
            {
                const int destLen = 10;
                // 設置者カナを浄化槽台帳の検索カナに設定する
                if (!string.IsNullOrEmpty(setchishaKanaTextBox.Text))
                {
                    string kensakuKana = string.Empty;
                    if (setchishaKanaTextBox.Text.Length > destLen)
                    {
                        kensakuKana = setchishaKanaTextBox.Text.Substring(0, destLen).Trim();
                    }
                    else
                    {
                        kensakuKana = setchishaKanaTextBox.Text.Trim();
                    }

                    row.JokasoKensakuKana = kensakuKana;
                }
            }

            foreach (DataRow row in table.Rows)
            {
                row.AcceptChanges();
                row.SetModified();
            }

            return table;
        }
        #endregion

        #region CreateEditInsertDataKanrenFile
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable CreateEditInsertDataKanrenFile()
        {
            KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable table = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();

            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            _outDataBindKanrenFile.FillToDataRow(table, now, username, host, true);

            foreach (KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow row in table.Rows)
            {
                // 関連ファイルパスを設定する
                row.KensaIraiKanrenFilePath = frmdisp.SelectedFilePath;

                // ALでファイルの移動を行う(その際、ファイルパスを付け替える)
            }

            foreach (DataRow row in table.Rows)
            {
                row.AcceptChanges();
                row.SetAdded();
            }

            return table;
        }
        #endregion

        #region CreateEditUpdateDataKanrenFile
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable CreateEditUpdateDataKanrenFile()
        {
            KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable table = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();

            // Current date time in DB
            DateTime now = Common.Common.GetCurrentTimestamp();
            // Get user name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Get host name
            string host = Dns.GetHostName();

            _outDataBindKanrenFile.FillToDataRow(table, now, username, host, true);

            foreach (KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow row in table.Rows)
            {
                // 関連ファイルパスを設定する
                row.KensaIraiKanrenFilePath = frmdisp.SelectedFilePath;

                // ALでファイルの移動を行う(その際、ファイルパスを付け替える)
            }

            foreach (DataRow row in table.Rows)
            {
                row.AcceptChanges();
                row.SetModified();
            }

            return table;
        }
        #endregion

        #region CloseForm
        /// <summary>
        /// 
        /// </summary>
        protected void CloseForm()
        {
            // メニュー有効化
            Program.mForm.SetMenuEnabled(true);

            Program.mForm.MovePrev();

            //KensaIraiKanriMenu frm = new KensaIraiKanriMenu();
            //Program.mForm.ShowForm(frm);
        }
        #endregion

        #region DoValidate
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool DoValidate()
        {
            StringBuilder errMsgBuf = new StringBuilder();

            string errMsg = string.Empty;

            // 標準バリデーション実行
            if (!hokenjoCdTextBox.DoValidate(true, "保健所コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!iraiNendoTextBox.DoValidate(true, "年度", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            // 受理年度、受理連番は相関必須とする
            {
                bool jyuriInput = !string.IsNullOrEmpty(hokenjoJyuriNendoTextBox.Text) || !string.IsNullOrEmpty(hokenjoJyuriRenbanTextBox.Text);

                if (!hokenjoJyuriNendoTextBox.DoValidate(jyuriInput, "保健所受理年度", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
                if (!hokenjoJyuriRenbanTextBox.DoValidate(jyuriInput, "保健所受理連番", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            }

            if (houteiShishoComboBox.SelectedIndex <= 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "法定支所"));
            }
            if (suishitsuShishoComboBox.SelectedIndex <= 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "水質支所"));
            }

            #region Tab1(設置者・設置場所)

            if (!setchishaNmTextBox.DoValidate(true, "設置者名称", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchishaKanaTextBox.DoValidate(true, "設置者名称カナ", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchishaZipCdTextBox.DoValidate(false, "設置者郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchishaAdrTextBox.DoValidate(true, "設置者住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchishaTelNoTextBox.DoValidate(false, "設置者電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!shiyoshaNmTextBox.DoValidate(false, "使用者名称", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shiyoshaZipCdTextBox.DoValidate(false, "使用者郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shiyoshaAdrTextBox.DoValidate(false, "使用者住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shiyoshaTelNoTextBox.DoValidate(false, "使用者電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (konkyoHoreiComboBox.SelectedIndex < 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "根拠法令"));
            }

            if (!shisetsuNmTextBox.DoValidate(false, "施設名", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchibashoZipCdTextBox.DoValidate(false, "設置場所郵便番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchibashoAdrTextBox.DoValidate(true, "設置場所住所", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!setchibashoTelNoTextBox.DoValidate(false, "設置場所電話番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!oldChikuCdTextBox.DoValidate(false, "設置場所旧地区コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!nowChikuCdTextBox.DoValidate(true, "設置場所現地区コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (chikuwariComboBox.SelectedIndex < 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "地区割コード"));
            }

            #endregion

            #region Tab2(型式等)

            if (!nobeMensekiTextBox.DoValidate(false, "延べ面積", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            #endregion

            #region Tab3(浄化槽情報)

            if (!shohinNmTextBox.DoValidate(false, "商品名", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!ninteiNoTextBox.DoValidate(false, "認定番号", out errMsg)) { errMsgBuf.AppendLine(errMsg); }


            if (!shoriHoshikiShubetsuNmTextBox.DoValidate(false, "処理方式種別", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!shoriHoshikiNmTextBox.DoValidate(true, "処理方式", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (shoriMokuhyoBodComboBox.SelectedIndex < 0)
            {
                errMsgBuf.AppendLine(string.Format("必須項目：{0}が入力されていません。", "処理目標水質"));
            }

            if (!shoriTaishoJininTextBox.DoValidate(true, "処理対象人員", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!hiHeikinOsuiRyoTextBox.DoValidate(false, "日平均汚水量", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            if (!bodJyokyoTextBox.DoValidate(false, "BOD除去率", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            #endregion

            #region Tab5(業者情報)

            if (!saisuiGyoshaCdTextBox.DoValidate(false, "採水業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!mochikomiGyoshaCdTextBox.DoValidate(false, "持込業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!seikyuGyoshaCdTextBox.DoValidate(false, "請求業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }
            if (!itkatsuSeikyuGyoshaCdTextBox.DoValidate(false, "一括請求業者コード", out errMsg)) { errMsgBuf.AppendLine(errMsg); }

            #endregion

            if (errMsgBuf.Length > 0)
            {
                // メッセージ表示
                MessageForm.Show2(MessageForm.DispModeType.Warning, errMsgBuf.ToString());

                return false;
            }

            return true;
        }
        #endregion

        #region Form Difinition Methods

        #region SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        private void SetControlDomain()
        {
            hokenjoCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);
            // 20150119 habu 年度は西暦とする
            iraiNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            //iraiNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);
            iraiRenbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 6);

            // 20150119 habu 年度は西暦とする
            hokenjoJyuriNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            //hokenjoJyuriNendoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 2);
            hokenjoJyuriRenbanTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            #region 受付日
            uketsukeNenTextBox.SetControlDomain(ZControlDomain.ZT_NEN);
            uketsukeTsukiTextBox.SetControlDomain(ZControlDomain.ZT_TSUKI);
            uketsukeBiTextBox.SetControlDomain(ZControlDomain.ZT_BI);
            #endregion

            #region Tab1(7条検査依頼登録1)

            #region 設置者

            setchishaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            setchishaKanaTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME_KANA_HALF, 30);
            setchishaZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            setchishaAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            setchishaTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);

            oldChikuCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);
            nowChikuCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 5);

            #endregion

            #region 使用者

            shiyoshaNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            shiyoshaZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            shiyoshaAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            shiyoshaTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);

            #endregion

            #region 設置場所

            shisetsuNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 60);
            setchibashoZipCdTextBox.SetControlDomain(ZControlDomain.ZT_ZIP_CD);
            setchibashoAdrTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);
            setchibashoTelNoTextBox.SetControlDomain(ZControlDomain.ZT_TEL_NO);

            #endregion

            #endregion

            #region Tab2(7条検査依頼登録2)

            #region 型式等

            makerCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            katashikiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            //koujiKbnTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 1);
            koujiNenTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 2);
            koujiNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5);
            ninteiNoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_ALPHA_NUM, 15);

            nobeMensekiTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 2, InputValidateUtility.SignFlg.Positive);

            #endregion

            #endregion

            #region Tab3(7条検査依頼登録3)

            #region 処理能力

            shoriTaishoJininTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 0, InputValidateUtility.SignFlg.Positive);
            hiHeikinOsuiRyoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 5, 1, InputValidateUtility.SignFlg.Positive);
            bodJyokyoTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 3, 1, InputValidateUtility.SignFlg.Positive);

            #endregion

            #region 設置日、使用開始日

            chakkoNenTextBox.SetControlDomain(ZControlDomain.ZT_NEN);
            chakkoTsukiTextBox.SetControlDomain(ZControlDomain.ZT_TSUKI);
            chakkoBiTextBox.SetControlDomain(ZControlDomain.ZT_BI);

            shiyokaishiNenTextBox.SetControlDomain(ZControlDomain.ZT_NEN);
            shiyokaishiTsukiTextBox.SetControlDomain(ZControlDomain.ZT_TSUKI);
            shiyokaishiBiTextBox.SetControlDomain(ZControlDomain.ZT_BI);

            #endregion

            #region 工事業者,保守点検業者

            // TODO 検索子画面で、届出番号(知事登録番号)、名称から検索できること
            // TODO 検索子画面で、住所、名称から検索できること

            koujiGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            hoshuYoteiGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            #endregion

            #region 人槽・処理方式

            shoriHoshikiShubetsuNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 14);
            shoriHoshikiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 80);

            #endregion

            #endregion

            // 前受金
            maeukekinShogoNo21TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            maeukekinShogoNo22TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            maeukekinShogoNo23TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            maeukekinShogoNo24TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);
            maeukekinShogoNo25TextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            kensaRyokinTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NUM, 6);

            #region 業者情報

            saisuiGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            mochikomiGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            seikyuGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
            itkatsuSeikyuGyoshaCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);

            #endregion

            // set comboBox
            // 根拠法令
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_029);
                Utility.Utility.SetComboBoxList(konkyoHoreiComboBox, table, "ConstNm", "ConstValue", true);
            }
            // 処理目標水質
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_070);
                Utility.Utility.SetComboBoxList(shoriMokuhyoBodComboBox, table, "ConstNm", "ConstValue", false);
            }
            // 市町村設置区分
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_030);
                Utility.Utility.SetComboBoxList(setchiKbnComboBox, table, "ConstNm", "ConstValue", true);
            }

            // 放流先
            {
                DataTable table = MstUtility.NameMst.GetNameTable(Utility.Constants.NameKbnConstant.NAME_KBN_001, true);
                Utility.Utility.SetComboBoxList(horyusakiComboBox, table, "Name", "NameCd", true);
            }

            // 告示区分
            {
                DataTable table = Common.Common.GetConstTable(Utility.Constants.ConstKbnConstanst.CONST_KBN_KOKUJIKBN);
                Utility.Utility.SetComboBoxList(koujiKbnComboBox, table, "ConstNm", "ConstValue", true);
            }

            // 地区割
            {
                IEnumerable<string> chikuwariList = AdrUtility.Chikuwari.GetChikuwariList(false);

                chikuwariComboBox.DataSource = chikuwariList;
            }

            // 支所
            {
                // 20150127 sou Start 取得する支所マスタを全件から事務局以外に変更
                //ShishoMstDataSet.ShishoMstDataTable table = MstUtility.ShishoMst.GetShishoMst();
                ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable table = MstUtility.ShishoMst.GetShishoMstExceptJimukyoku();
                // 20150127 sou End

                Utility.Utility.SetComboBoxList(houteiShishoComboBox, table, table.ShishoNmColumn.ColumnName, table.ShishoCdColumn.ColumnName, true);
                Utility.Utility.SetComboBoxList(suishitsuShishoComboBox, table, table.ShishoNmColumn.ColumnName, table.ShishoCdColumn.ColumnName, true);
            }

            // 建築用途1～5
            {
                KenchikuyotoMstDataSet.KenchikuyotoMstKensakuDataTable tempTable = MstUtility.KenchikuyotoMst.GetKenchikuyotoMstKensaku();

                const string colCd = "Cd";
                const string colNm = "Nm";

                const string valDelim = ":";

                DataTable table = new DataTable();
                table.Columns.Add(colCd, typeof(string));
                table.Columns.Add(colNm, typeof(string));

                // Valueはデリミタで連結した値を設定する(大分類(2),小分類(2),連番からなる)
                // 名称も連結して表示する
                foreach (KenchikuyotoMstDataSet.KenchikuyotoMstKensakuRow tempRow in tempTable)
                {
                    DataRow row = table.NewRow();
                    row[colCd] = string.Join(valDelim, new string[] { tempRow.KenchikuyotoDaibunrui, tempRow.KenchikuyotoShobunrui, tempRow.KenchikuyotoRenban.ToString() });
                    string dispNm = string.Format("{0}({1}){2}", tempRow.KenchikuyotoDaibunruiNm, tempRow.KenchikuyotoShobunruiNm, tempRow.KenchikuyotoNm);
                    row[colNm] = dispNm;

                    table.Rows.Add(row);
                }

                Utility.Utility.SetComboBoxList(tatemonoYoto1ComboBox, table, colNm, colCd, true);
                Utility.Utility.SetComboBoxList(tatemonoYoto2ComboBox, table, colNm, colCd, true);
                Utility.Utility.SetComboBoxList(tatemonoYoto3ComboBox, table, colNm, colCd, true);
                Utility.Utility.SetComboBoxList(tatemonoYoto4ComboBox, table, colNm, colCd, true);
                Utility.Utility.SetComboBoxList(tatemonoYoto5ComboBox, table, colNm, colCd, true);
            }

            // 旧建築用途コード
            {
                DataTable nameMst = Common.Common.GetNameMstTable("002");
                Utility.Utility.SetComboBoxList(oldTatemonoYotoComboBox, nameMst, "NAME", "NAMECD", true);
            }
        }
        #endregion

        #region InitInDataMapping
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataBindingHelper InitInDataMapping()
        {
            // In/OutでDataMappingが異なる場合は、別途定義する

            return InitOutDataMapping();
        }
        #endregion

        #region InitOutDataMapping
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataBindingHelper InitOutDataMapping()
        {
            DataBindingHelper bind = new DataBindingHelper();

            // template table(カラム情報は必要なので)
            KensaIraiTblDataSet.KensaIraiTblDataTable templateTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            bind.AddControlBind(hokenjoCdTextBox, templateTable.KensaIraiHokenjoCdColumn);
            bind.AddControlBind(iraiNendoTextBox, templateTable.KensaIraiNendoColumn);
            bind.AddControlBind(iraiRenbanTextBox, templateTable.KensaIraiRenbanColumn);

            bind.AddControlBind(hokenjoCdTextBox, templateTable.KensaIraiHokenjoJyuriHokenjoCdColumn);
            bind.AddControlBind(hokenjoJyuriNendoTextBox, templateTable.KensaIraiHokenjoJyuriNendoColumn);
            bind.AddControlBind(hokenjoJyuriRenbanTextBox, templateTable.KensaIraiHokenjoJyuriRenbanColumn);

            // TODO この画面で更新を行う場合は、Mappingを見直す -> 7条を後で登録するのであれば、必要

            #region Tab1(7条検査依頼登録1)

            #region 設置者

            bind.AddControlBind(setchishaNmTextBox, templateTable.KensaIraiSetchishaNmColumn);
            bind.AddControlBind(setchishaKanaTextBox, templateTable.KensaIraiSetchishaKanaColumn);
            bind.AddControlBind(setchishaZipCdTextBox, templateTable.KensaIraiSetchishaZipCdColumn);
            bind.AddControlBind(setchishaAdrTextBox, templateTable.KensaIraiSetchishaAdrColumn);
            bind.AddControlBind(setchishaTelNoTextBox, templateTable.KensaIraiSetchishaTelNoColumn);

            bind.AddControlBind(setchiKbnComboBox, templateTable.KensaIraiShichosonSetchigataColumn);
            // 検索カナは別途設定する

            #endregion

            #region 使用者

            #endregion

            #region 設置場所

            bind.AddControlBind(konkyoHoreiComboBox, templateTable.KensaIraiHokonkyoKbnColumn);

            bind.AddControlBind(shisetsuNmTextBox, templateTable.KensaIraiShisetsuNmColumn);
            bind.AddControlBind(setchibashoZipCdTextBox, templateTable.KensaIraiSetchibashoZipCdColumn);
            bind.AddControlBind(setchibashoAdrTextBox, templateTable.KensaIraiSetchibashoAdrColumn);
            bind.AddControlBind(setchibashoTelNoTextBox, templateTable.KensaIraiSetchibashoTelNoColumn);

            bind.AddControlBind(nowChikuCdTextBox, templateTable.KensaIraiGenChikuCdColumn);

            #endregion

            #endregion

            #region Tab2(7条検査依頼登録2)

            #region 型式等

            bind.AddControlBind(makerCdTextBox, templateTable.KensaIraiMakerCdColumn);
            bind.AddControlBind(katashikiTextBox, templateTable.KensaIraiKatashikiCdColumn);

            bind.AddControlBind(koujiKbnComboBox, templateTable.KensaIraiKokujiKbnColumn);
            //bind.AddControlBind(koujiKbnTextBox, templateTable.KensaIraiKokujiKbnColumn);
            bind.AddControlBind(koujiNenTextBox, templateTable.KensaIraiKokujiNendoColumn);
            bind.AddControlBind(koujiNoTextBox, templateTable.KensaIraiKokujiNoColumn);
            bind.AddControlBind(ninteiNoTextBox, templateTable.KensaIraiNinteiNoColumn);

            bind.AddControlBind(tatemonoYoto1ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui1Column, templateTable.KenchikuyotoShobunrui1Column, templateTable.KenchikuyotoRenban1Column });
            bind.AddControlBind(tatemonoYoto2ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui2Column, templateTable.KenchikuyotoShobunrui2Column, templateTable.KenchikuyotoRenban2Column });
            bind.AddControlBind(tatemonoYoto3ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui3Column, templateTable.KenchikuyotoShobunrui3Column, templateTable.KenchikuyotoRenban3Column });
            bind.AddControlBind(tatemonoYoto4ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui4Column, templateTable.KenchikuyotoShobunrui4Column, templateTable.KenchikuyotoRenban4Column });
            bind.AddControlBind(tatemonoYoto5ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui5Column, templateTable.KenchikuyotoShobunrui5Column, templateTable.KenchikuyotoRenban5Column });

            // 旧建築用途コード
            bind.AddControlBind(oldTatemonoYotoComboBox, templateTable.KensaIraiTatemonoYotoColumn);

            bind.AddControlBind(nobeMensekiTextBox, templateTable.KensaIraiNobeMensaekiColumn);

            #endregion

            #endregion

            #region Tab3(7条検査依頼登録3)

            #region 処理能力

            bind.AddControlBind(shoriMokuhyoBodComboBox, templateTable.KensaIraiShorimokuhyoSuishitsuColumn);

            bind.AddControlBind(horyusakiComboBox, templateTable.KensaIraiHoryusakiCdColumn);

            #endregion

            #region 設置日、使用開始日

            bind.AddControlBind(chakkoNenTextBox, templateTable.KensaIraiSetchiNenColumn);
            bind.AddControlBind(chakkoTsukiTextBox, templateTable.KensaIraiSetchiTsukiColumn);
            bind.AddControlBind(chakkoBiTextBox, templateTable.KensaIraiSetchiBiColumn);

            bind.AddControlBind(shiyokaishiNenTextBox, templateTable.KensaIraiShiyoKaishiNenColumn);
            bind.AddControlBind(shiyokaishiTsukiTextBox, templateTable.KensaIraiShiyoKaishiTsukiColumn);
            bind.AddControlBind(shiyokaishiBiTextBox, templateTable.KensaIraiShiyoKaishiBiColumn);

            #endregion

            #region 工事業者,保守点検業者

            bind.AddControlBind(koujiGyoshaCdTextBox, templateTable.KensaIraiKojiGyoshaCdColumn);

            #endregion

            #region 人槽・処理方式

            bind.AddControlBind(shoriTaishoJininTextBox, templateTable.KensaIraiShoritaishoJininColumn);

            bind.AddControlBind(_shoriHoshikiKbn, templateTable.KensaIraiShorihoshikiKbnColumn);
            bind.AddControlBind(_shoriHoshikiCd, templateTable.KensaIraiShorihoshikiCdColumn);

            #endregion

            #region 業者情報

            bind.AddControlBind(saisuiGyoshaCdTextBox, templateTable.KensaIraiSaisuiGyoshaCdColumn);
            bind.AddControlBind(mochikomiGyoshaCdTextBox, templateTable.KensaIraiMochikomiGyoshaCdColumn);
            bind.AddControlBind(seikyuGyoshaCdTextBox, templateTable.KensaIraiSeikyuGyoshaCdColumn);

            #endregion

            #endregion

            // 前受金照合番号
            // 別途設定し、ALで前受金更新(紐付け)処理を実行する

            #region その他固有項目

            // 表示用として、別途登録する
            bind.AddControlBind(shoriMokuhyoBodComboBox, templateTable.KensaIraiBODShoriSeinoColumn);

            #endregion

            // 固定値設定
            // 検査依頼法定区分
            bind.AddControlBind(Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN, templateTable.KensaIraiHoteiKbnColumn);

            //// 受付支所コードは、ログインユーザの所属支所コードとする
            //bind.AddControlBind(
            //    ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd
            //    , templateTable.KensaIraiUketsukeShishoKbnColumn);
            // 受付支所コードは、法定検査担当支所で登録
            bind.AddControlBind(
                houteiShishoComboBox
                , templateTable.KensaIraiUketsukeShishoKbnColumn);

            // 依頼年月日は、登録日を設定
            DateTime sysDt = Common.Common.GetCurrentTimestamp();

            bind.AddControlBind(sysDt.Year.ToString("0000"), templateTable.KensaIraiNenColumn);
            bind.AddControlBind(sysDt.Month.ToString("00"), templateTable.KensaIraiTsukiColumn);
            bind.AddControlBind(sysDt.Day.ToString("00"), templateTable.KensaIraiBiColumn);

            // その他固定値
            bind.AddControlBind("0", templateTable.KensaIraiScreeningKbnColumn);

            bind.AddControlBind("0", templateTable.KensaIraiKensaKanryoKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIraiKeninKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIraiBODNyuryokuzumiKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIraiEnsoIonNyuryokuzumiKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIraiMLSSNyuryokuzumiKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIraiKensahyoInsatsuzumiKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIraiHagakiInsatsuzumiKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIrai7joHoryuKbnColumn);

            bind.AddControlBind("0", templateTable.KensaIraiGaikanNippoKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIraiSuishitsuNippoKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIraiSeikyuKbnColumn);
            bind.AddControlBind("0", templateTable.KensaIraiKekkashoInsatsuCntColumn);

            // ダミー値設定
            bind.AddControlBind(string.Empty, templateTable.KensaIraiJokasoHokenjoCdColumn);
            bind.AddControlBind(string.Empty, templateTable.KensaIraiJokasoTorokuNendoColumn);
            bind.AddControlBind(string.Empty, templateTable.KensaIraiJokasoRenbanColumn);

            return bind;
        }
        #endregion

        #region InitOutDataMappingKanrenFile
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataBindingHelper InitOutDataMappingKanrenFile()
        {
            DataBindingHelper bind = new DataBindingHelper();

            // template table(カラム情報は必要なので)
            KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable templateTable = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();

            bind.AddControlBind(hokenjoCdTextBox, templateTable.KensaIraiHokenjoCdColumn);
            bind.AddControlBind(iraiNendoTextBox, templateTable.KensaIraiNendoColumn);
            bind.AddControlBind(iraiRenbanTextBox, templateTable.KensaIraiRenbanColumn);

            // 固定値設定
            // 検査依頼法定区分
            bind.AddControlBind(Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN, templateTable.KensaIraiHoteiKbnColumn);

            // TODO 定数を使用する
            // TODO 関連ファイル種別を整理する
            // 関連ファイル種別
            bind.AddControlBind("1", templateTable.KensaIraiFileShubetsuCdColumn);

            // TODO 見出しはこれで良いか?
            bind.AddControlBind("7条検査", templateTable.KensaIraiKanrenFileMidashiColumn);

            // ダミー値設定
            bind.AddControlBind(string.Empty, templateTable.KensaIraiKanrenFilePathColumn);

            return bind;
        }
        #endregion

        #region InitInDataMappingDaicho
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataBindingHelper InitInDataMappingDaicho()
        {
            DataBindingHelper bind = new DataBindingHelper();

            // template table(カラム情報は必要なので)
            JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable templateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable();

            bind.AddControlBind(hokenjoCdTextBox, templateTable.JokasoHokenjoCdColumn);

            bind.AddControlBind(hokenjoJyuriNendoTextBox, templateTable.JokasoHokenjoJuriNoNendoColumn);
            bind.AddControlBind(hokenjoJyuriRenbanTextBox, templateTable.JokasoHokenjoJuriNoRenbanColumn);

            bind.AddControlBind(houteiShishoComboBox, templateTable.JokasoHoteiSishoCdColumn);
            bind.AddControlBind(suishitsuShishoComboBox, templateTable.JokasoSuisitsuSishoCdColumn);

            #region Tab1(7条検査依頼登録1)

            #region 設置者

            bind.AddControlBind(setchishaNmTextBox, templateTable.JokasoSetchishaNmColumn);
            bind.AddControlBind(setchishaKanaTextBox, templateTable.JokasoSetchishaKanaColumn);
            bind.AddControlBind(setchishaZipCdTextBox, templateTable.JokasoSetchishaZipCdColumn);
            bind.AddControlBind(setchishaAdrTextBox, templateTable.JokasoSetchishaAdrColumn);
            bind.AddControlBind(setchishaTelNoTextBox, templateTable.JokasoSetchishaTelNoColumn);

            bind.AddControlBind(setchiKbnComboBox, templateTable.JokasoSichosonSetchiKbnColumn);

            #endregion

            #region 使用者

            bind.AddControlBind(shiyoshaNmTextBox, templateTable.JokasoShiyoshaNmColumn);
            bind.AddControlBind(shiyoshaZipCdTextBox, templateTable.JokasoShiyoshaZipCdColumn);
            bind.AddControlBind(shiyoshaAdrTextBox, templateTable.JokasoShiyoshaAdrColumn);
            bind.AddControlBind(shiyoshaTelNoTextBox, templateTable.JokasoShiyoshaTelNoColumn);

            #endregion

            #region 設置場所

            bind.AddControlBind(konkyoHoreiComboBox, templateTable.JokasoHouKonkyoKbnColumn);

            bind.AddControlBind(shisetsuNmTextBox, templateTable.JokasoShisetsuNmColumn);
            bind.AddControlBind(setchibashoZipCdTextBox, templateTable.JokasoSetchiBashoZipCdColumn);
            bind.AddControlBind(setchibashoAdrTextBox, templateTable.JokasoSetchiBashoAdrColumn);
            bind.AddControlBind(setchibashoTelNoTextBox, templateTable.JokasoSetchiBashoTelNoColumn);

            bind.AddControlBind(oldChikuCdTextBox, templateTable.JokasoKyuChikuCdColumn);
            bind.AddControlBind(nowChikuCdTextBox, templateTable.JokasoGenChikuCdColumn);
            bind.AddControlBind(chikuwariComboBox, templateTable.JokasoGaikanTikuwariKbnColumn);

            #endregion

            #endregion

            #region Tab2(7条検査依頼登録2)

            #region 型式等

            bind.AddControlBind(makerCdTextBox, templateTable.JokasoMekaGyoshaCdColumn);
            bind.AddControlBind(katashikiTextBox, templateTable.JokasoKatashikiCdColumn);

            bind.AddControlBind(koujiKbnComboBox, templateTable.JokasoKoujiKbnColumn);
            //bind.AddControlBind(koujiKbnTextBox, templateTable.JokasoKoujiKbnColumn);
            bind.AddControlBind(koujiNenTextBox, templateTable.JokasoKoujiNenColumn);
            bind.AddControlBind(koujiNoTextBox, templateTable.JokasoKoujiNoColumn);
            bind.AddControlBind(ninteiNoTextBox, templateTable.JokasoNinteiNoColumn);

            bind.AddControlBind(tatemonoYoto1ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui1Column, templateTable.KenchikuyotoShobunrui1Column, templateTable.KenchikuyotoRenban1Column });
            bind.AddControlBind(tatemonoYoto2ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui2Column, templateTable.KenchikuyotoShobunrui2Column, templateTable.KenchikuyotoRenban2Column });
            bind.AddControlBind(tatemonoYoto3ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui3Column, templateTable.KenchikuyotoShobunrui3Column, templateTable.KenchikuyotoRenban3Column });
            bind.AddControlBind(tatemonoYoto4ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui4Column, templateTable.KenchikuyotoShobunrui4Column, templateTable.KenchikuyotoRenban4Column });
            bind.AddControlBind(tatemonoYoto5ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui5Column, templateTable.KenchikuyotoShobunrui5Column, templateTable.KenchikuyotoRenban5Column });

            // 旧建築用途コード
            bind.AddControlBind(oldTatemonoYotoComboBox, templateTable.JokasoOldKentikuYoutoCdColumn);

            bind.AddControlBind(nobeMensekiTextBox, templateTable.JokasoTatemonoNobeMensekiColumn);

            #endregion

            #endregion

            #region Tab3(7条検査依頼登録3)

            #region 処理能力

            bind.AddControlBind(shoriMokuhyoBodComboBox, templateTable.JokasoSyoriMokuhyoBODColumn);

            bind.AddControlBind(hiHeikinOsuiRyoTextBox, templateTable.JokasoHiHeikinOsuiRyoColumn);
            bind.AddControlBind(bodJyokyoTextBox, templateTable.JokasoBODJyokyoRitsuColumn);

            bind.AddControlBind(horyusakiComboBox, templateTable.JokasoHoryusakiCdColumn);

            bind.AddControlBind(DisupozaCheckBox, templateTable.JokasoDisupozaFlgColumn);

            #endregion

            #region 設置日、使用開始日

            bind.AddControlBind(chakkoNenTextBox, templateTable.JokasoSetchiNenColumn);
            bind.AddControlBind(chakkoTsukiTextBox, templateTable.JokasoSetchiTsukiColumn);
            bind.AddControlBind(chakkoBiTextBox, templateTable.JokasoSetchiBiColumn);

            bind.AddControlBind(shiyokaishiNenTextBox, templateTable.JokasoSiyokaisiNenColumn);
            bind.AddControlBind(shiyokaishiTsukiTextBox, templateTable.JokasoSiyokaisiTsukiColumn);
            bind.AddControlBind(shiyokaishiBiTextBox, templateTable.JokasoSiyokaisiBiColumn);

            #endregion

            #region 工事業者,保守予定業者

            bind.AddControlBind(koujiGyoshaCdTextBox, templateTable.JokasoKojiGyoshaKbnColumn);
            bind.AddControlBind(hoshuYoteiGyoshaCdTextBox, templateTable.JokasoHoshuyoteiGyoshaCdColumn);

            #endregion

            #region 人槽・処理方式

            bind.AddControlBind(shoriTaishoJininTextBox, templateTable.JokasoShoriTaishoJininColumn);

            bind.AddControlBind(_shoriHoshikiKbn, templateTable.JokasoShoriHosikiKbnColumn);
            bind.AddControlBind(_shoriHoshikiCd, templateTable.JokasoShoriHosikiCdColumn);
            bind.AddControlBind(_shoriHoshikiShubetsu, templateTable.JokasoShoriHosikiShubetuColumn);

            #endregion

            #endregion

            #region 業者情報

            bind.AddControlBind(saisuiGyoshaCdTextBox, templateTable.JokasoSaisuiGyoshaCdColumn);
            bind.AddControlBind(mochikomiGyoshaCdTextBox, templateTable.JokasoMochikomiGyoshaCdColumn);
            bind.AddControlBind(seikyuGyoshaCdTextBox, templateTable.JokasoSeikyuGyoshaCdColumn);
            bind.AddControlBind(itkatsuSeikyuGyoshaCdTextBox, templateTable.JokasoItkatsuSeikyuGyoshaCdColumn);

            #endregion

            #region disp only

            bind.AddControlBind(shoriHoshikiShubetsuNmTextBox, templateTable.ShoriHoshikiShubetsuNmColumn);
            bind.AddControlBind(shoriHoshikiNmTextBox, templateTable.ShoriHoshikiNmColumn);

            bind.AddControlBind(makerNmTextBox, templateTable.MekaGyoshaNmColumn);
            bind.AddControlBind(koujiGyoshaNmTextBox, templateTable.KojiGyoshaNmColumn);

            bind.AddControlBind(hoshuYoteiGyoshaNmTextBox, templateTable.HoshuyoteiGyoshaNmColumn);
            bind.AddControlBind(saisuiGyoshaNmTextBox, templateTable.SaisuiGyoshaNmColumn);
            bind.AddControlBind(mochikomiGyoshaNmTextBox, templateTable.MochikomiGyoshaNmColumn);
            bind.AddControlBind(seikyuGyoshaNmTextBox, templateTable.SeikyuGyoshaNmColumn);
            bind.AddControlBind(itkatsuSeikyuGyoshaNmTextBox, templateTable.ItkatsuSeikyuGyoshaNmColumn);

            #endregion

            return bind;
        }
        #endregion

        #region InitOutDataMappingDaicho
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DataBindingHelper InitOutDataMappingDaicho()
        {
            DataBindingHelper bind = new DataBindingHelper();

            // template table(カラム情報は必要なので)
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable templateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

            bind.AddControlBind(hokenjoCdTextBox, templateTable.JokasoHokenjoCdColumn);

            // ダミー値設定(登録時に採番する)
            bind.AddControlBind(string.Empty, templateTable.JokasoTorokuNendoColumn);
            bind.AddControlBind(string.Empty, templateTable.JokasoRenbanColumn);

            bind.AddControlBind(hokenjoCdTextBox, templateTable.JokasoHokenjoJuriNoHokenCdColumn);
            bind.AddControlBind(hokenjoJyuriNendoTextBox, templateTable.JokasoHokenjoJuriNoNendoColumn);
            bind.AddControlBind(hokenjoJyuriRenbanTextBox, templateTable.JokasoHokenjoJuriNoRenbanColumn);

            bind.AddControlBind(houteiShishoComboBox, templateTable.JokasoHoteiSishoCdColumn);
            bind.AddControlBind(suishitsuShishoComboBox, templateTable.JokasoSuisitsuSishoCdColumn);

            #region Tab1(7条検査依頼登録1)

            #region 設置者

            bind.AddControlBind(setchishaNmTextBox, templateTable.JokasoSetchishaNmColumn);
            bind.AddControlBind(setchishaKanaTextBox, templateTable.JokasoSetchishaKanaColumn);
            bind.AddControlBind(setchishaZipCdTextBox, templateTable.JokasoSetchishaZipCdColumn);
            bind.AddControlBind(setchishaAdrTextBox, templateTable.JokasoSetchishaAdrColumn);
            bind.AddControlBind(setchishaTelNoTextBox, templateTable.JokasoSetchishaTelNoColumn);

            bind.AddControlBind(setchiKbnComboBox, templateTable.JokasoSichosonSetchiKbnColumn);
            // 検索カナは別途設定する

            #endregion

            #region 使用者

            bind.AddControlBind(shiyoshaNmTextBox, templateTable.JokasoShiyoshaNmColumn);
            bind.AddControlBind(shiyoshaZipCdTextBox, templateTable.JokasoShiyoshaZipCdColumn);
            bind.AddControlBind(shiyoshaAdrTextBox, templateTable.JokasoShiyoshaAdrColumn);
            bind.AddControlBind(shiyoshaTelNoTextBox, templateTable.JokasoShiyoshaTelNoColumn);

            #endregion

            #region 設置場所

            bind.AddControlBind(konkyoHoreiComboBox, templateTable.JokasoHouKonkyoKbnColumn);

            bind.AddControlBind(shisetsuNmTextBox, templateTable.JokasoShisetsuNmColumn);
            bind.AddControlBind(setchibashoZipCdTextBox, templateTable.JokasoSetchiBashoZipCdColumn);
            bind.AddControlBind(setchibashoAdrTextBox, templateTable.JokasoSetchiBashoAdrColumn);
            bind.AddControlBind(setchibashoTelNoTextBox, templateTable.JokasoSetchiBashoTelNoColumn);

            bind.AddControlBind(oldChikuCdTextBox, templateTable.JokasoKyuChikuCdColumn);
            bind.AddControlBind(nowChikuCdTextBox, templateTable.JokasoGenChikuCdColumn);
            bind.AddControlBind(chikuwariComboBox, templateTable.JokasoGaikanTikuwariKbnColumn);

            #endregion

            #endregion

            #region Tab2(7条検査依頼登録2)

            #region 型式等

            bind.AddControlBind(makerCdTextBox, templateTable.JokasoMekaGyoshaCdColumn);
            bind.AddControlBind(katashikiTextBox, templateTable.JokasoKatashikiCdColumn);

            bind.AddControlBind(koujiKbnComboBox, templateTable.JokasoKoujiKbnColumn);
            //bind.AddControlBind(koujiKbnTextBox, templateTable.JokasoKoujiKbnColumn);
            bind.AddControlBind(koujiNenTextBox, templateTable.JokasoKoujiNenColumn);
            bind.AddControlBind(koujiNoTextBox, templateTable.JokasoKoujiNoColumn);
            bind.AddControlBind(ninteiNoTextBox, templateTable.JokasoNinteiNoColumn);

            bind.AddControlBind(tatemonoYoto1ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui1Column, templateTable.KenchikuyotoShobunrui1Column, templateTable.KenchikuyotoRenban1Column });
            bind.AddControlBind(tatemonoYoto2ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui2Column, templateTable.KenchikuyotoShobunrui2Column, templateTable.KenchikuyotoRenban2Column });
            bind.AddControlBind(tatemonoYoto3ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui3Column, templateTable.KenchikuyotoShobunrui3Column, templateTable.KenchikuyotoRenban3Column });
            bind.AddControlBind(tatemonoYoto4ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui4Column, templateTable.KenchikuyotoShobunrui4Column, templateTable.KenchikuyotoRenban4Column });
            bind.AddControlBind(tatemonoYoto5ComboBox, new DataColumn[] { templateTable.KenchikuyotoDaibunrui5Column, templateTable.KenchikuyotoShobunrui5Column, templateTable.KenchikuyotoRenban5Column });

            // 旧建築用途コード
            bind.AddControlBind(oldTatemonoYotoComboBox, templateTable.JokasoOldKentikuYoutoCdColumn);

            bind.AddControlBind(nobeMensekiTextBox, templateTable.JokasoTatemonoNobeMensekiColumn);

            #endregion

            #endregion

            #region Tab3(7条検査依頼登録3)

            #region 処理能力

            bind.AddControlBind(shoriMokuhyoBodComboBox, templateTable.JokasoSyoriMokuhyoBODColumn);

            bind.AddControlBind(hiHeikinOsuiRyoTextBox, templateTable.JokasoHiHeikinOsuiRyoColumn);
            bind.AddControlBind(bodJyokyoTextBox, templateTable.JokasoBODJyokyoRitsuColumn);

            bind.AddControlBind(horyusakiComboBox, templateTable.JokasoHoryusakiCdColumn);

            bind.AddControlBind(DisupozaCheckBox, templateTable.JokasoDisupozaFlgColumn);

            #endregion

            #region 設置日、使用開始日

            bind.AddControlBind(chakkoNenTextBox, templateTable.JokasoSetchiNenColumn);
            bind.AddControlBind(chakkoTsukiTextBox, templateTable.JokasoSetchiTsukiColumn);
            bind.AddControlBind(chakkoBiTextBox, templateTable.JokasoSetchiBiColumn);

            bind.AddControlBind(shiyokaishiNenTextBox, templateTable.JokasoSiyokaisiNenColumn);
            bind.AddControlBind(shiyokaishiTsukiTextBox, templateTable.JokasoSiyokaisiTsukiColumn);
            bind.AddControlBind(shiyokaishiBiTextBox, templateTable.JokasoSiyokaisiBiColumn);

            #endregion

            #region 工事業者,保守予定業者

            bind.AddControlBind(koujiGyoshaCdTextBox, templateTable.JokasoKojiGyoshaKbnColumn);
            bind.AddControlBind(hoshuYoteiGyoshaCdTextBox, templateTable.JokasoHoshuyoteiGyoshaCdColumn);

            #endregion

            #region 人槽・処理方式

            bind.AddControlBind(shoriTaishoJininTextBox, templateTable.JokasoShoriTaishoJininColumn);

            bind.AddControlBind(_shoriHoshikiKbn, templateTable.JokasoShoriHosikiKbnColumn);
            bind.AddControlBind(_shoriHoshikiCd, templateTable.JokasoShoriHosikiCdColumn);
            bind.AddControlBind(_shoriHoshikiShubetsu, templateTable.JokasoShoriHosikiShubetuColumn);

            #endregion

            #endregion

            #region 業者情報

            bind.AddControlBind(saisuiGyoshaCdTextBox, templateTable.JokasoSaisuiGyoshaCdColumn);
            bind.AddControlBind(mochikomiGyoshaCdTextBox, templateTable.JokasoMochikomiGyoshaCdColumn);
            bind.AddControlBind(seikyuGyoshaCdTextBox, templateTable.JokasoSeikyuGyoshaCdColumn);
            bind.AddControlBind(itkatsuSeikyuGyoshaCdTextBox, templateTable.JokasoItkatsuSeikyuGyoshaCdColumn);

            #endregion

            #region 浄化槽台帳マスタ固有

            // NOTICE 技術管理者情報はシステムへの入力不要
            // NOTICE 検索カナは別途設定する

            // 検査依頼の設置者情報 -> 浄化槽台帳の届出設置者情報として登録する
            bind.AddControlBind(setchishaNmTextBox, templateTable.JokasoTodokedeSetchishaNmColumn);
            bind.AddControlBind(setchishaZipCdTextBox, templateTable.JokasoTodokedeSetchishaZipCdColumn);
            bind.AddControlBind(setchishaAdrTextBox, templateTable.JokasoTodokedeSetchishaAdrColumn);
            bind.AddControlBind(setchishaTelNoTextBox, templateTable.JokasoTodokedeSetchishaTelNoColumn);

            #endregion

            return bind;
        }
        #endregion

        #region SetStdHandler
        /// <summary>
        /// 
        /// </summary>
        private void SetStdHandler()
        {
            Common.Common.SetStdEnterTabEvent(this);

            Common.Common.SetStdButtonKey(this, Keys.F1, entryButton);
            Common.Common.SetStdButtonKey(this, Keys.F2, changeButton);
            Common.Common.SetStdButtonKey(this, Keys.F3, deleteButton);
            Common.Common.SetStdButtonKey(this, Keys.F4, reInputButton);
            Common.Common.SetStdButtonKey(this, Keys.F5, decisionButton);
            Common.Common.SetStdButtonKey(this, Keys.F6, copyButton);
            Common.Common.SetStdButtonKey(this, Keys.F12, closeButton);

            Common.Common.SetCdAutoPad(hokenjoCdTextBox);
            Common.Common.SetCdAutoPad(iraiNendoTextBox);

            Common.Common.SetCdAutoPad(hokenjoJyuriNendoTextBox);
            Common.Common.SetCdAutoPad(hokenjoJyuriRenbanTextBox);

            Common.Common.SetCdAutoPad(uketsukeNenTextBox);
            Common.Common.SetCdAutoPad(uketsukeTsukiTextBox);
            Common.Common.SetCdAutoPad(uketsukeBiTextBox);

            Common.Common.SetCdAutoPad(oldChikuCdTextBox);
            Common.Common.SetCdAutoPad(nowChikuCdTextBox);

            Common.Common.SetCdAutoPad(chakkoNenTextBox);
            Common.Common.SetCdAutoPad(chakkoTsukiTextBox);
            Common.Common.SetCdAutoPad(chakkoBiTextBox);

            Common.Common.SetCdAutoPad(shiyokaishiNenTextBox);
            Common.Common.SetCdAutoPad(shiyokaishiTsukiTextBox);
            Common.Common.SetCdAutoPad(shiyokaishiBiTextBox);

            Common.Common.SetCdAutoPad(makerCdTextBox);
            Common.Common.SetCdAutoPad(katashikiTextBox);

            Common.Common.SetCdAutoPad(koujiGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(hoshuYoteiGyoshaCdTextBox);

            Common.Common.SetCdAutoPad(maeukekinShogoNo21TextBox);
            Common.Common.SetCdAutoPad(maeukekinShogoNo22TextBox);
            Common.Common.SetCdAutoPad(maeukekinShogoNo23TextBox);
            Common.Common.SetCdAutoPad(maeukekinShogoNo24TextBox);
            Common.Common.SetCdAutoPad(maeukekinShogoNo25TextBox);

            Common.Common.SetCdAutoPad(saisuiGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(mochikomiGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(seikyuGyoshaCdTextBox);
            Common.Common.SetCdAutoPad(itkatsuSeikyuGyoshaCdTextBox);

            #region ZipCd

            AdrUtility.ZipCd.SetStdZipCdSearchButton(setchishaZipKensakuButton, setchishaZipCdTextBox, setchishaAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdSearchButton(shiyoshaZipKensakuButton, shiyoshaZipCdTextBox, shiyoshaAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdSearchButton(setchibashoZipKensakuButton, setchibashoZipCdTextBox, setchibashoAdrTextBox);

            AdrUtility.ZipCd.SetStdZipCdChanged(setchishaZipCdTextBox, setchishaAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdChanged(shiyoshaZipCdTextBox, shiyoshaAdrTextBox);
            AdrUtility.ZipCd.SetStdZipCdChanged(setchibashoZipCdTextBox, setchibashoAdrTextBox);

            #endregion

            #region GyoshaCd

            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(makerKensakuButton, makerCdTextBox, makerNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(koujiGyoshaKensakuButton, koujiGyoshaCdTextBox, koujiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(hoshuYoteiGyoshaKensakuButton, hoshuYoteiGyoshaCdTextBox, hoshuYoteiGyoshaNmTextBox);

            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(saisuiGyoshaKensakuButton, saisuiGyoshaCdTextBox, saisuiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(motikomiGyoshaKensakuButton, mochikomiGyoshaCdTextBox, mochikomiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(seikyuGyoshaKensakuButton, seikyuGyoshaCdTextBox, seikyuGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaSearchButton(itkatsuSeikyuGyoshaKensakuButton, itkatsuSeikyuGyoshaCdTextBox, itkatsuSeikyuGyoshaNmTextBox);

            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(makerCdTextBox, makerNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(koujiGyoshaCdTextBox, koujiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(hoshuYoteiGyoshaCdTextBox, hoshuYoteiGyoshaNmTextBox);

            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(saisuiGyoshaCdTextBox, saisuiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(mochikomiGyoshaCdTextBox, mochikomiGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(seikyuGyoshaCdTextBox, seikyuGyoshaNmTextBox);
            MstUtility.GyoshaMst.SetStdGyoshaCdChanged(itkatsuSeikyuGyoshaCdTextBox, itkatsuSeikyuGyoshaNmTextBox);
            #endregion

            #region HokenjoCd

            AdrUtility.HokenjoCd.SetStdHokenjoCdAdrChanged(setchibashoAdrTextBox, hokenjoCdTextBox, false);
            AdrUtility.HokenjoCd.SetStdHokenjoCdZipCdChanged(setchibashoZipCdTextBox, hokenjoCdTextBox, false);

            #endregion

            #region ChikuCd

            // TODO 旧地区コードはコンボボックスとし、選んでもらうようにする
            // 旧地区コード
            AdrUtility.KyuChikuCd.SetStdKyuChikuCdAdrChanged(setchibashoAdrTextBox, oldChikuCdTextBox, false);
            AdrUtility.KyuChikuCd.SetStdKyuChikuCdZipCdChanged(setchibashoZipCdTextBox, oldChikuCdTextBox, false);

            // 現地区コード
            AdrUtility.GenChikuCd.SetStdGenChikuCdAdrChanged(setchibashoAdrTextBox, nowChikuCdTextBox, false);
            AdrUtility.GenChikuCd.SetStdGenChikuCdZipCdChanged(setchibashoZipCdTextBox, nowChikuCdTextBox, false);

            #endregion

            #region other

            // 型式マスタ検索ボタン
            MstUtility.KatashikiMst.SetStdKatashikiSearchButton(katashikiKensakuButton
                , makerCdTextBox, makerNmTextBox
                , katashikiTextBox, shohinNmTextBox
                , _shoriHoshikiKbn, _shoriHoshikiCd, _shoriHoshikiShubetsu
                , shoriHoshikiShubetsuNmTextBox, shoriHoshikiNmTextBox
                , true);
            //MstUtility.KatashikiMst.SetStdKatashikiSearchButton(katashikiKensakuButton, makerCdTextBox, makerNmTextBox, katashikiTextBox, shohinNmTextBox, true);

            // 処理方式マスタ検索ボタン
            //MstUtility.ShoriHoshikiMst.SetStdShoriHoshikiSearchButton(shoriHoshikiKensakuButton, _shoriHoshikiKbn, _shoriHoshikiCd, _shoriHoshikiShubetsu, shoriHoshikiShubetsuNmTextBox, shoriHoshikiNmTextBox, true);
            setStdShoriHoshikiSearchButton(shoriHoshikiKensakuButton, _shoriHoshikiKbn, _shoriHoshikiCd, _shoriHoshikiShubetsu, shoriHoshikiShubetsuNmTextBox, shoriHoshikiNmTextBox, true);

            // 型式選択ボタン
            KatashikiMstDataSet.KatashikiMstSearchDataTable katashikiTalble = new KatashikiMstDataSet.KatashikiMstSearchDataTable();

            MstUtility.Generic.SetStdMstCdChanged(
                new TextBox[] { makerCdTextBox, katashikiTextBox }
                , new TextBox[] { shohinNmTextBox
                    , _shoriHoshikiKbn, _shoriHoshikiCd, _shoriHoshikiShubetsu
                    , shoriHoshikiShubetsuNmTextBox,shoriHoshikiNmTextBox }
                , new string[] { katashikiTalble.KatashikiMakerCdColumn.ColumnName, katashikiTalble.KatashikiCdColumn.ColumnName }
                , new string[] { katashikiTalble.KatashikiNmColumn.ColumnName
                    , katashikiTalble.KatashikiShorihoushikiKbnColumn.ColumnName, katashikiTalble.KatashikiShorihoushikiCdColumn.ColumnName, katashikiTalble.ShoriHoshikiShubetsuKbnColumn.ColumnName 
                    , katashikiTalble.ShoriHoshikiShubetsuNmColumn.ColumnName , katashikiTalble.ShoriHoshikiNmColumn.ColumnName }
                , typeof(KatashikiMstDataSet.KatashikiMstSearchDataTable)
                , typeof(KatashikiMstSearchTableAdapter), true);

            ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable shoriTable = new ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable();

            #endregion
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool CheckFileExists()
        {
            // 画像ディレクトリ
            string pdfDir = Properties.Settings.Default.PdfRootDir;
            //string pdfDir = @"C:\PDF";

            // ルートからの相対パスを表示、取得する
            string[] pdfPathes = Directory.GetFiles(pdfDir, "*.pdf", SearchOption.TopDirectoryOnly);

            if (pdfPathes.Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region nextInputPreparation
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： nextInputPreparation
        /// <summary>
        /// 次の入力の準備
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/29　小松　　    連続入力対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void nextInputPreparation()
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 子画面を閉じる
                this.frmdisp.Close();

                // 入力・表示域を初期化（初期表示状態に）
                InitDisplayControl();

                // 初期登録時は、システム日時を年度として初期設定する
                DateTime sysDt = Common.Common.GetCurrentTimestamp();

                // 画面起動引数チェック
                if (_initDisplayMode == DispMode.Add)
                {
                    this._displayMode = this._initDisplayMode;

                    string nendo = Utility.DateUtility.GetNendo(sysDt).ToString();
                    // 20150119 habu 年度は西暦で扱う
                    //nendo = Common.Common.ConvertToHoshouNendoWareki(nendo);

                    iraiNendoTextBox.Text = nendo;
                    hokenjoJyuriNendoTextBox.Text = nendo;

                    // デフォルト値設定
                    bodJyokyoTextBox.Text = "20";
                    shoriMokuhyoBodComboBox.SelectedValue = 90;
                    uketsukeNenTextBox.Text = sysDt.Year.ToString();
                    uketsukeTsukiTextBox.Text = sysDt.Month.ToString().PadLeft(2, '0');
                    uketsukeBiTextBox.Text = sysDt.Day.ToString().PadLeft(2, '0');
                }
                else if (_initDisplayMode == DispMode.Detail)
                {
                    this._displayMode = this._initDisplayMode;

                    // 表示データ取得
                    GetControlData();

                    // 表示データ設定
                    SetControlData();
                }

                // 受付日、設置日、使用開始日の和暦表示
                convertDispDateToWareki();

                // 検査手数料をセット
                setKensaRyokin();

                SetDisplayControl();

                // open sub form
                frmdisp = new KensaIraishoDisplay(this);
                frmdisp.Show();

                // 保存画面位置取得(親フォーム(枠部分)に対して行う)
                Program.mForm.Location = formLocation.GetPoint(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this);
                Program.mForm.Size = formLocation.GetSize(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, this.Size);

                // 初期位置へ
                this.Activate();
                this.ActiveControl = hokenjoCdTextBox;
                hokenjoCdTextBox.Focus();
                tabControl1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                // エラー終了扱いとし、画面を閉じる
                this.DialogResult = DialogResult.Abort;

                CloseForm();

                // Load中にエラーになった場合、FormClosingが実行されない場合があるため、ここで子画面を閉じる
                if (this.frmdisp != null)
                {
                    // 子画面を閉じる
                    this.frmdisp.Close();
                }

                // メニュー有効化
                Program.mForm.SetMenuEnabled(true);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region InitDisplayControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InitDisplayControl
        /// <summary>
        /// 入力・表示域を初期化（初期表示状態に）
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/29　小松　　    連続入力対応
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InitDisplayControl()
        {
            {
                hokenjoCdTextBox.Text = string.Empty;
                iraiNendoTextBox.Text = string.Empty;

                hokenjoJyuriNendoTextBox.Text = string.Empty;
                hokenjoJyuriRenbanTextBox.Text = string.Empty;

                houteiShishoComboBox.SelectedIndex = 0;
                suishitsuShishoComboBox.SelectedIndex = 0;

                #region 受付日
                uketsukeNenTextBox.Text = string.Empty;
                uketsukeTsukiTextBox.Text = string.Empty;
                uketsukeBiTextBox.Text = string.Empty;
                #endregion

                #region Tab1

                #region 設置者

                setchishaNmTextBox.Text = string.Empty;
                setchishaKanaTextBox.Text = string.Empty;
                setchishaZipCdTextBox.Text = string.Empty;
                setchishaAdrTextBox.Text = string.Empty;
                setchishaTelNoTextBox.Text = string.Empty;

                setchiKbnComboBox.SelectedIndex = 0;

                #endregion

                #region 使用者

                shiyoshaNmTextBox.Text = string.Empty;
                shiyoshaZipCdTextBox.Text = string.Empty;
                shiyoshaAdrTextBox.Text = string.Empty;
                shiyoshaTelNoTextBox.Text = string.Empty;

                #endregion

                #region 設置場所

                konkyoHoreiComboBox.SelectedIndex = 0;

                shisetsuNmTextBox.Text = string.Empty;
                setchibashoZipCdTextBox.Text = string.Empty;
                setchibashoAdrTextBox.Text = string.Empty;
                setchibashoTelNoTextBox.Text = string.Empty;

                oldChikuCdTextBox.Text = string.Empty;
                nowChikuCdTextBox.Text = string.Empty;

                chikuwariComboBox.SelectedIndex = 0;

                #endregion

                #endregion

                #region Tab2

                #region 型式等

                makerCdTextBox.Text = string.Empty;
                katashikiTextBox.Text = string.Empty;

                koujiKbnComboBox.SelectedIndex = 0;
                koujiNenTextBox.Text = string.Empty;
                koujiNoTextBox.Text = string.Empty;
                ninteiNoTextBox.Text = string.Empty;

                tatemonoYoto1ComboBox.SelectedIndex = 0;
                tatemonoYoto2ComboBox.SelectedIndex = 0;
                tatemonoYoto3ComboBox.SelectedIndex = 0;
                tatemonoYoto4ComboBox.SelectedIndex = 0;
                tatemonoYoto5ComboBox.SelectedIndex = 0;

                nobeMensekiTextBox.Text = string.Empty;

                #endregion

                #endregion

                #region Tab3

                shoriMokuhyoBodComboBox.SelectedIndex = 0;

                hiHeikinOsuiRyoTextBox.Text = string.Empty;
                bodJyokyoTextBox.Text = string.Empty;

                horyusakiComboBox.SelectedIndex = 0;

                DisupozaCheckBox.Text = string.Empty;

                #region 設置日、使用開始日

                chakkoNenTextBox.Text = string.Empty;
                chakkoTsukiTextBox.Text = string.Empty;
                chakkoBiTextBox.Text = string.Empty;

                shiyokaishiNenTextBox.Text = string.Empty;
                shiyokaishiTsukiTextBox.Text = string.Empty;
                shiyokaishiBiTextBox.Text = string.Empty;

                #endregion

                #region 工事業者,保守点検業者

                koujiGyoshaCdTextBox.Text = string.Empty;
                hoshuYoteiGyoshaCdTextBox.Text = string.Empty;

                #endregion

                #region 人槽・処理方式

                shoriTaishoJininTextBox.Text = string.Empty;

                #endregion

                #region 前受金

                kisaiAriRadioButton.Checked = true;
                maeukekinShogoNo21TextBox.Text = string.Empty;
                maeukekinShogoNo22TextBox.Text = string.Empty;
                maeukekinShogoNo23TextBox.Text = string.Empty;
                maeukekinShogoNo24TextBox.Text = string.Empty;
                maeukekinShogoNo25TextBox.Text = string.Empty;

                #endregion

                #region 業者情報

                saisuiGyoshaCdTextBox.Text = string.Empty;
                mochikomiGyoshaCdTextBox.Text = string.Empty;
                seikyuGyoshaCdTextBox.Text = string.Empty;
                itkatsuSeikyuGyoshaCdTextBox.Text = string.Empty;

                saisuiGyoshaNmTextBox.Text = string.Empty;
                mochikomiGyoshaNmTextBox.Text = string.Empty;
                seikyuGyoshaNmTextBox.Text = string.Empty;
                itkatsuSeikyuGyoshaNmTextBox.Text = string.Empty;

                #endregion

                #endregion

                #region 検索ボタン類

                #endregion
            }

            {
                iraiRenbanTextBox.Text = string.Empty;

                makerNmTextBox.Text = string.Empty;
                shohinNmTextBox.Text = string.Empty;
                shoriHoshikiShubetsuNmTextBox.Text = string.Empty;
                shoriHoshikiNmTextBox.Text = string.Empty;
                koujiGyoshaNmTextBox.Text = string.Empty;
                hoshuYoteiGyoshaNmTextBox.Text = string.Empty;

                kensaRyokinTextBox.Text = string.Empty;
            }
        }
        #endregion

        #region setKensaRyokin
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： setKensaRyokin
        /// <summary>
        /// 検査料金表示
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setKensaRyokin()
        {
            kensaRyokinTextBox.Text = string.Empty;
            decimal kensaRyokin = 0;
            int ninsou = 0;
            if (int.TryParse(shoriTaishoJininTextBox.Text, out ninsou))
            {
                // 法定検査料金マスタ取得(人槽から)
                HoteiKensaRyokinMstDataSet.HoteiKensaRyokinMstRow ryokinRow = Boundary.Common.Common.GetHoteiKensaRyokinMstByNinsou(ninsou);
                if (ryokinRow != null)
                {
                    if (_shoriHoshikiKbn.Text == Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU)
                    {
                        kensaRyokin = ryokinRow.TandokuKingaku7Jo;
                    }
                    else
                    {
                        kensaRyokin = ryokinRow.GappeiKingaku7Jo;
                    }
                    if (kensaRyokin >= 0)
                    {
                        kensaRyokinTextBox.Text = kensaRyokin.ToString("#,##0");
                    }
                }
            }
        }
        #endregion

        #region convertDispDateToWareki
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： convertDispDateToWareki
        /// <summary>
        /// 受付日、設置日、使用開始日の和暦表示
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void convertDispDateToWareki()
        {
            // 受付日
            uketsukeDtWarekiTextBox.Text = string.Empty;
            if (!string.IsNullOrEmpty(uketsukeNenTextBox.Text) && !string.IsNullOrEmpty(uketsukeTsukiTextBox.Text) && !string.IsNullOrEmpty(uketsukeBiTextBox.Text))
            {
                DateTime tempDT;
                if (DateTime.TryParseExact(uketsukeNenTextBox.Text + uketsukeTsukiTextBox.Text.PadLeft(2, '0') + uketsukeBiTextBox.Text.PadLeft(2, '0'),
                    "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out tempDT))
                {
                    uketsukeDtWarekiTextBox.Text =
                        Utility.DateUtility.ConvertToWareki(tempDT.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
                }
            }

            // 設置日
            setchiDtWarekiTextBox.Text = string.Empty;
            if (!string.IsNullOrEmpty(chakkoNenTextBox.Text) && !string.IsNullOrEmpty(chakkoTsukiTextBox.Text) && !string.IsNullOrEmpty(chakkoBiTextBox.Text))
            {
                DateTime tempDT;
                if (DateTime.TryParseExact(chakkoNenTextBox.Text + chakkoTsukiTextBox.Text.PadLeft(2, '0') + chakkoBiTextBox.Text.PadLeft(2, '0'),
                    "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out tempDT))
                {
                    setchiDtWarekiTextBox.Text =
                        Utility.DateUtility.ConvertToWareki(tempDT.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);
                }
            }

            // 使用開始日
            shiyokaishiDtWarekiTextBox.Text = string.Empty;
            if (!string.IsNullOrEmpty(shiyokaishiNenTextBox.Text) && !string.IsNullOrEmpty(shiyokaishiTsukiTextBox.Text) && !string.IsNullOrEmpty(shiyokaishiBiTextBox.Text))
            {
                DateTime tempDT;
                if (DateTime.TryParseExact(shiyokaishiNenTextBox.Text + shiyokaishiTsukiTextBox.Text.PadLeft(2, '0') + shiyokaishiBiTextBox.Text.PadLeft(2, '0'),
                    "yyyyMMdd", null, System.Globalization.DateTimeStyles.None, out tempDT))
                {
                    shiyokaishiDtWarekiTextBox.Text =
                        Utility.DateUtility.ConvertToWareki(tempDT.ToString("yyyyMMdd"), "gyy年MM月dd日", Utility.DateUtility.GengoKbn.Wareki);

                }
            }
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="searchButton"></param>
        /// <param name="targetCdControl">処理方式区分</param>
        /// <param name="targetCdControl2">処理方式コード</param>
        /// <param name="targetCdControl3">処理方式種別区分</param>
        /// <param name="targetNmControl">処理方式種別名</param>
        /// <param name="targetNmControl2">処理方式名</param>
        /// <param name="overwriteExists"></param>
        private void setStdShoriHoshikiSearchButton(Button searchButton, System.Windows.Forms.Control targetCdControl, System.Windows.Forms.Control targetCdControl2, System.Windows.Forms.Control targetCdControl3, TextBox targetNmControl, TextBox targetNmControl2, bool overwriteExists)
        {
            searchButton.Click += delegate(object sender, EventArgs e)
            {
                ShoriHoshikiMstSearchForm frm = new ShoriHoshikiMstSearchForm();

                frm.ShowDialog();

                if (frm.DialogResult == DialogResult.OK)
                {
                    if (targetCdControl != null)
                    {
                        Common.Common.SetCdControlValue(targetCdControl, frm.ShoriHoshikiKbn);
                    }
                    if (targetCdControl2 != null)
                    {
                        Common.Common.SetCdControlValue(targetCdControl2, frm.ShoriHoshikiCd);
                    }
                    if (targetCdControl3 != null)
                    {
                        Common.Common.SetCdControlValue(targetCdControl3, frm.ShoriHoshikiShubetsu);
                    }
                    if (targetNmControl != null)
                    {
                        targetNmControl.Text = frm.ShoriHoshikiShubetsuNm;
                    }
                    if (targetNmControl2 != null)
                    {
                        targetNmControl2.Text = frm.ShoriHoshikiNm;
                    }

                    // 検査料金表示
                    setKensaRyokin();
                }
            };
        }

        #endregion

        #endregion
    }
}
