using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.ApplicationLogic.Common;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Common
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
    /// 2014/10/10　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class Login : FukjTabBaseDialog
    {
        #region 定義

        /// <summary>
        /// 結果コードの定義
        /// </summary>
        public enum Result
        {
            // ログイン（オンライン）
            Online = 1,

            // ログイン（オフライン）
            Offline,

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
        /// 2014/10/10　豊田　　    新規作成
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
        /// 2014/10/10　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void Login_Load(object sender, EventArgs e)
        {
            // ログインIDにフォーカス
            this.ActiveControl = UserIdTextBox;

            // バージョン表示
            versionLabel.Text = string.Format("Ver.{0}", FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion);
        }
        #endregion

        #region CloseButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： CloseButton_Click
        /// <summary>
        /// CloseButton押下時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/10　豊田　　    新規作成
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
        /// 2014/10/10　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void LoginButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                ShokuinInfo.GetShokuinInfo().Shokuin = null;

                if (Utility.IsOnline())
                {
                    // オンライン時はサーバ認証
                    ShokuinMstDataSet.ShokuinMstDataTable shokuinMstDT
                        = FukjBizSystem.Application.Boundary.Common.Common.GetShokuinMstByShokuinCdShokuinPassword(UserIdTextBox.Text, PasswordTextBox.Text);

                    if (shokuinMstDT == null || shokuinMstDT.Count == 0)
                    {
                        // エラーメッセージ表示
                        TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_W00005);

                        // 入力エリア初期化,フォーカス
                        UserIdTextBox.Text = string.Empty;
                        PasswordTextBox.Text = string.Empty;
                        this.ActiveControl = UserIdTextBox;
                        return;
                    }

                    // ログイン情報1レコード分保持
                    ShokuinMstDataSet.ShokuinMstRow shokuinMstRow = (ShokuinMstDataSet.ShokuinMstRow)shokuinMstDT[0];
                    ShokuinInfo.GetShokuinInfo().Shokuin = shokuinMstRow;

                    _FormResult = Result.Online;
                }
                else
                {
                    // オフライン時はローカル認証
                    IGetShokuinMstByShokuinCdShokuinPasswordALInput alInput = new GetShokuinMstByShokuinCdShokuinPasswordALInput();
                    alInput.ShokuinCd = UserIdTextBox.Text;
                    alInput.ShokuinPassword = PasswordTextBox.Text;
                    IGetShokuinMstByShokuinCdShokuinPasswordALOutput output = new GetShokuinMstByShokuinCdShokuinPasswordApplicationLogic().Execute(alInput);

                    if (output.ShokuinMstDT == null || output.ShokuinMstDT.Count == 0)
                    {
                        // エラーメッセージ表示
                        MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_W00005);
                        // 入力エリア初期化,フォーカス
                        UserIdTextBox.Text = string.Empty;
                        PasswordTextBox.Text = string.Empty;
                        this.ActiveControl = UserIdTextBox;
                        return;
                    }

                    // 値の詰め替え
                    ShokuinMstDataSet.ShokuinMstDataTable shokuinMst = new ShokuinMstDataSet.ShokuinMstDataTable();
                    ShokuinMstDataSet.ShokuinMstRow shokuinMstRow = shokuinMst.NewShokuinMstRow();
                    foreach (DataColumn col in output.ShokuinMstDT.Columns)
                    {
                        // ログイン情報1レコード分保持
                        shokuinMstRow[col.ColumnName] = output.ShokuinMstDT[0][col.ColumnName];
                    }
                    ShokuinInfo.GetShokuinInfo().Shokuin = shokuinMstRow;

                    _FormResult = Result.Offline;
                }

                Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001);
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
    }
    #endregion
}
