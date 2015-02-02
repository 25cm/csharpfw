using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    ///  クラス名 ： Login
    /// <summary>
    /// ログイン画面
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/05/02　和田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class Login : FukjBaseForm
    {
        #region 定義

        /// <summary>
        /// 結果コードの定義
        /// </summary>
        public enum Result
        {
            // ログイン
            Login = 1,
            // ログインキャンセル
            Cancel
        }

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 結果コード
        /// </summary>
        private Result _FormResult = Result.Cancel;

        #endregion

        #region プロパティ(public)

        public Result FormResult
        {
            get
            {
                return _FormResult;
            }
        }

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        ///  コンストラクタ名 ： Login
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/05/02　和田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Login()
        {
            InitializeComponent();
        }
        #endregion

        #region Login_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： Login_Load
        /// <summary>
        /// 画面初期表示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/05/02　和田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Login_Load(object sender, EventArgs e)
        {
            // ログインIDにフォーカス
            this.ActiveControl = UserIdTextBox;

            // バージョン情報表示
            EnableVersionDisp();
        }
        #endregion

        #region CloseButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CloseButton_Click
        /// <summary>
        /// loginButton押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/05/02　和田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region LoginButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： LoginButton_Click
        /// <summary>
        /// loginButton押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/05/02　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void LoginButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                Utility.ShokuinInfo.GetShokuinInfo().Shokuin = null;

                ShokuinMstDataSet.ShokuinMstDataTable shokuinMstDT
                    = Common.GetShokuinMstByShokuinCdShokuinPassword(UserIdTextBox.Text, PasswordTextBox.Text);

                if (shokuinMstDT == null || shokuinMstDT.Count == 0)
                {
                    // エラーメッセージ表示
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_W00005);
                    // 入力エリア初期化,フォーカス
                    UserIdTextBox.Text = string.Empty;
                    PasswordTextBox.Text = string.Empty;
                    this.ActiveControl = UserIdTextBox;
                    return;
                }

                // ログイン情報1レコード分保持
                ShokuinMstDataSet.ShokuinMstRow shokuinMstRow = (ShokuinMstDataSet.ShokuinMstRow)shokuinMstDT[0];
                Utility.ShokuinInfo.GetShokuinInfo().Shokuin = shokuinMstRow;

                _FormResult = Result.Login;

                Close();

                //MenuForm frm = new MenuForm();

                //// 複数起動チェック
                //if (!Utility.Utility.OpenFormCheck(frm.Name, false))
                //{
                //    frm.Show();
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

        #region メソッド(public)

        public static new Result Show()
        {
            // ログイン画面の表示
            Login form = new Login();
            form.ShowDialog();

            // 戻り値の返却
            return form.FormResult;
        }

        #endregion  

        #region Login_KeyDown
        ///////////////////////////////////////////////////////////////
        /// イベント名：Login_KeyDown
        /// <summary>
        /// キーイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>Fn
        /// 日付　　　　担当者　　　内容
        /// 2014/05/02　和田　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    // Fn5:ログインボタン押下
                    case Keys.F5:
                        LoginButton.PerformClick();
                        break;
                    // その他
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

    }
    #endregion
}
