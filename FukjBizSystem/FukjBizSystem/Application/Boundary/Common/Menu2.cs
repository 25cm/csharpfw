using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.Common.SubMenu;
using FukjBizSystem.Application.DataSet;
using Zynas.Control;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common2
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MenuForm
    /// <summary>
    /// メニュー画面
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class MenuForm : Form
    {
        #region （旧）画面遷移関連

        #region ShowForm(Form frm)
        /// <summary>
        /// 画面遷移
        /// </summary>
        /// <param name="frm"></param>
        [Obsolete("MoveNext(FukjBaseForm frm)メソッドを使用してください。")]
        public void ShowForm(Form frm)
        {

            // 表示されていた画面をCloseする（インスタンスが残り続ける暫定対応）
            if (this.formPanel.Controls.Count > 0)
            {
                ((Form)this.formPanel.Controls[0]).Close();
            }
            this.formPanel.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Visible = true;
            //frm.Parent=this;
            formPanel.Controls.Add(frm);
            this.Text = frm.Text;
            frm.Focus();
        }
        #endregion

        #endregion

        #region （新）画面遷移関連

        #region MoveNext(FukjBaseForm frm)
        /// <summary>
        /// 次の画面を起動する（遷移先を指定）
        /// </summary>
        /// <param name="frm"></param>
        public void MoveNext(FukjBaseForm frm)
        {
            MoveNext(frm, null);
        }
        #endregion

        #region MoveNext(FukjBaseForm frm, FukjBaseForm.FormEnded formEnd)
        /// <summary>
        /// 次の画面を起動する（遷移先を指定）
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="formEnd"></param>
        public void MoveNext(FukjBaseForm frm, FukjBaseForm.FormEnded formEnd)
        {
            if (this.formPanel.Controls.Count > 0)
            {
                // 遷移元の画面を保存（Closeしない）
                frm.previousForm = ((FukjBaseForm)this.formPanel.Controls[0]);
            }

            if (formEnd != null)
            {
                frm.FormEndEvent += formEnd;
            }

            this.formPanel.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Visible = true;

            // 初期ロード中にAbortされた場合は前の画面に戻す
            if (frm.DialogResult == System.Windows.Forms.DialogResult.Abort)
            {
                // 遷移元画面を取得
                FukjBaseForm frm2 = (FukjBaseForm)frm.previousForm;

                // 現在の画面をCloseする
                frm.Close();

                frm2.TopLevel = false;
                frm2.FormBorderStyle = FormBorderStyle.None;
                frm2.Dock = DockStyle.Fill;
                frm2.Visible = true;
                formPanel.Controls.Add(frm2);
                this.Text = frm2.Text;
                frm2.Focus();
            }
            else
            {
                frm.Parent = (FukjBaseForm)frm.previousForm;
                formPanel.Controls.Add(frm);
                this.Text = frm.Text;
                frm.Focus();
            }
        }
        #endregion

        #region MovePrev()
        /// <summary>
        /// 前の画面を起動する
        /// </summary>
        public void MovePrev()
        {
            FukjBaseForm frm = null;

            if (this.formPanel.Controls.Count > 0)
            {
                // 前画面のインスタンスを取得
                frm = (FukjBaseForm)((FukjBaseForm)this.formPanel.Controls[0]).previousForm;

                // 現在の画面をCloseする
                ((FukjBaseForm)this.formPanel.Controls[0]).Close();
            }
            else
            {
                // 前画面が無い場合は遷移しない
                return;
            }

            this.formPanel.Controls.Clear();

            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.Visible = true;
            formPanel.Controls.Add(frm);
            this.Text = frm.Text;
            frm.Focus();
        }
        #endregion

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MenuForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MenuForm()
            : base()
        {
            InitializeComponent();
        }
        #endregion

        #region 定数(private)

        /// <summary>
        /// 台帳管理以降の初期メニュー表示位置
        /// </summary>
        private const int INITIAL_TOP_LOCATION = 123;

        /// <summary>
        /// 台帳管理以降の初期タブインデックス
        /// </summary>
        private const int INITIAL_TAB_INDEX = 3;

        /// <summary>
        /// メニュー毎の表示位置オフセット
        /// </summary>
        private const int MENU_OFFSET = 35;

        #endregion

        #region イベントハンドラ

        #region MenuForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： MenuForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MenuForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                //ログイン者名表示
                this.strShokuinNm.Text = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                // Version情報表示
                EnableVersionDisp();

                // ユーザ毎のルートメニューを表示
                SetUserRootMenu();

                // 既定のサブメニュー（作業一覧）を表示
                workListMenuForm frm = new workListMenuForm();
                MoveNext(frm);

                // 作業一覧に初期フォーカスを設定
                ActiveControl = workListButton;
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

        #region closeButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // アプリケーションを終了する
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
        
        #region workListButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： workListButton_Click
        /// <summary>
        /// 作業一覧メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void workListButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                workListMenuForm frm = new workListMenuForm();
                MoveNext(frm);
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

        #region userSettingButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： userSettingButton_Click
        /// <summary>
        /// ユーザー設定メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void userSettingButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                UserSettingMenuForm frm = new UserSettingMenuForm();
                MoveNext(frm);
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
        
        #region daichoButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： daichoButton_Click
        /// <summary>
        /// 台帳管理メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void daichoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                DaichoMenuForm frm = new DaichoMenuForm();
                MoveNext(frm);
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

        #region masterButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： masterButton_Click
        /// <summary>
        /// マスタ管理メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void masterButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                MasterMenuForm frm = new MasterMenuForm();
                MoveNext(frm);
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

        #region kinoHoshoButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kinoHoshoButton_Click
        /// <summary>
        /// 機能保証メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kinoHoshoButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                KinoHoshoMenuForm frm = new KinoHoshoMenuForm();
                MoveNext(frm);
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

        #region yoshiHanbaiButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： yoshiHanbaiButton_Click
        /// <summary>
        /// 用紙販売管理メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void yoshiHanbaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                YoshiHanbaiMenuForm frm = new YoshiHanbaiMenuForm();
                MoveNext(frm);
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

        #region saisuiinButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： saisuiinButton_Click
        /// <summary>
        /// 採水員管理メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void saisuiinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                SaisuiinMenuForm frm = new SaisuiinMenuForm();
                MoveNext(frm);
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

        #region kaiinButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kaiinButton_Click
        /// <summary>
        /// 会員管理メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kaiinButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                KaiinMenuForm frm = new KaiinMenuForm();
                MoveNext(frm);
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

        #region keiriButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： keiriButton_Click
        /// <summary>
        /// 経理管理メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void keiriButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                KeiriMenuForm frm = new KeiriMenuForm();
                MoveNext(frm);
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

        #region hoteiKensaButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoteiKensaButton_Click
        /// <summary>
        /// 法定検査管理メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoteiKensaButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                HoteiKensaMenuForm frm = new HoteiKensaMenuForm();
                MoveNext(frm);
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

        #region suishitsuKensaButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suishitsuKensaButton_Click
        /// <summary>
        /// 水質検査管理メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suishitsuKensaButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                SuishituKensaMenuForm frm = new SuishituKensaMenuForm();
                MoveNext(frm);
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

        #region sonotaButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： sonotaButton_Click
        /// <summary>
        /// その他メニューボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void sonotaButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // サブメニューを表示
                SonotaMenuForm frm = new SonotaMenuForm();
                MoveNext(frm);
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

        #region メソッド(public)

        #region SetMenuEnabled
        /// <summary>
        /// メニューの活性化を制御（他画面に遷移させない等の制御）
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="enabled"></param>
        public void SetMenuEnabled(bool enabled)
        {
            // 閉じるボタン等の制御
            this.ControlBox = enabled;

            // ボタンの活性化制御
            SetButtonEnabled(this, enabled);
        }
        #endregion
        
        #endregion

        #region メソッド(private)

        #region SetButtonEnabled
        /// <summary>
        /// メニューのボタン活性化を制御(フォームパネルは除く)
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="enabled"></param>
        private void SetButtonEnabled(System.Windows.Forms.Control ctrl, bool enabled)
        {
            foreach (System.Windows.Forms.Control c in ctrl == null ? this.Controls : ctrl.Controls)
            {
                if (c.Name == formPanel.Name)
                {
                    continue;
                }

                if (c.Controls.Count > 0)
                {
                    SetButtonEnabled(c, enabled);
                }

                if (c.GetType() == typeof(Button) || c.GetType() == typeof(ZButton))
                {
                    c.Enabled = enabled;
                }
            }
        }
        #endregion

        #region EnableVersionDisp
        /// <summary>
        /// バージョン番号を表示
        /// </summary>
        private void EnableVersionDisp()
        {
            bool showVersion = true;

            if (showVersion)
            {
                // バージョン情報を取得・表示
                string verStr = string.Empty;
                Version ver = Assembly.GetExecutingAssembly().GetName().Version;
                verStr = string.Format("{0}.{1}.{2}.{3}", ver.Major, ver.Minor, ver.Build, ver.Revision);
                lblVersionVal.Text = verStr;

                lblVersion.Visible = true;
                lblVersionVal.Visible = true;
            }
            else
            {
                lblVersion.Visible = false;
                lblVersionVal.Visible = false;
            }

        }
        #endregion

        #region SetUserRootMenu()
        /// <summary>
        /// ルートメニューの表示を制御
        /// </summary>
        private void SetUserRootMenu()
        {
            // ログインユーザの所属部署を条件として機能マスタを取得
            IGetUserFunctionByShokuinCdALInput alInput = new GetUserFunctionByShokuinCdALInput();
            alInput.ShokuinCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;

            IGetUserFunctionByShokuinCdALOutput alOutput = new GetUserFunctionByShokuinCdApplicationLogic().Execute(alInput);

            // 取得したメニューを表示
            int topLocation = INITIAL_TOP_LOCATION;
            int tabIndex = INITIAL_TAB_INDEX;
            foreach (FunctionMstDataSet.UserFunctionRow row in alOutput.UserFunction)
            {
                // 機能ボタンを表示
                ((Button)(Controls["rootMenuPanel"].Controls[row.TaishoFunctionNm])).Visible = true;

                // 表示位置を調整
                ((Button)(Controls["rootMenuPanel"].Controls[row.TaishoFunctionNm])).Top = topLocation;

                // タブインデックス
                ((Button)(Controls["rootMenuPanel"].Controls[row.TaishoFunctionNm])).TabIndex = tabIndex;

                // 次のボタンの表示位置まで進める
                topLocation += MENU_OFFSET;

                // タブインデックスをインクリメント
                tabIndex++;
            }
        }
        #endregion
    
        #endregion
    }
    #endregion
}
