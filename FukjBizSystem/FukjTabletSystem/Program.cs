using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using FukjTabletSystem.Application.Boundary.Common;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjTabletSystem
{
    static class Program
    {
        #region 静的プロパティ(private)

        /// <summary>
        /// アプリ名
        /// </summary>
        private const string AppName = "FukjTabletSystem";

        /// <summary>
        /// Mutex
        /// </summary>
        private static Mutex MyMutex = null;

        #endregion

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            
            // 15日より古いログファイルを削除う
            TraceLog.DeleteLog(15);

            if (MessageResouce.LoadMessageFile(Properties.Settings.Default.ErrMsgFile))
            {
                try
                {
                    // 二重起動チェック
                    if (!IsDuplicate())
                    {
                        try
                        {
                            // アプリケーションの初期化
                            if (InitialApplication())
                            {
                                // 起動していないのでログイン画面を表示
                                Login.Result mode = Login.Show();

                                // オンライン
                                if (mode == Login.Result.Online)
                                {
                                    // 初期画面表示
                                    Form frm = new FukjTabletSystem.Application.Boundary.Common.TopMenuForm(true);
                                    System.Windows.Forms.Application.Run(frm);
                                }
                                // オフライン
                                else if (mode == Login.Result.Offline)
                                {
                                    // 初期画面表示
                                    Form frm = new FukjTabletSystem.Application.Boundary.Common.TopMenuForm(false);
                                    System.Windows.Forms.Application.Run(frm);
                                }
                            }
                        }
                        finally
                        {
                            // アプリケーションの後処理
                            FinallyApplication();
                        }
                    }
                }
                catch (Exception e)
                {
                    // ログ出力
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), e.ToString());
                    // メッセージ表示
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, e.Message);
                }
                finally
                {
                    if (MyMutex != null) MyMutex.Close();
                }
            }
        }

        #region 静的メソッド(private)

        #region IsDuplicate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsDuplicate
        /// <summary>
        /// 二重起動のチェックを行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>チェック結果</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2011/05/06　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static bool IsDuplicate()
        {
            // ミューテックスの作成
            MyMutex = new System.Threading.Mutex(false, AppName);
            // ミューテックスの所有権を要求する
            if (MyMutex.WaitOne(0, false) == false)
            {
                // すでに起動していると判断して終了
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00006);

                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region InitialApplication
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InitialApplication
        /// <summary>
        /// アプリケーションの初期化を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>成否</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/11/30　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static bool InitialApplication()
        {
            try
            {
                // 帳票ディレクトリの作成
                DirectoryInfo print = new DirectoryInfo(Properties.Settings.Default.PrintDirectory);
                print.Create();

                // 帳票テンプレートディレクトリの作成
                DirectoryInfo printFormat = new DirectoryInfo(Properties.Settings.Default.PrintFormatFolder);
                printFormat.Create();

                // 写真保存ディレクトリの作成
                DirectoryInfo picDirectory = new DirectoryInfo(Properties.Settings.Default.FileDirectory);
                picDirectory.Create();
                
                // データベースファイル作成
                if (!File.Exists(Path.Combine(Properties.Settings.Default.DataPathSQLCE, Properties.Settings.Default.DataNameSQLCE)))
                {
                    DirectoryInfo dbDirectory = new DirectoryInfo(Properties.Settings.Default.DataPathSQLCE);
                    dbDirectory.Create();

                    File.Copy(".\\Database\\fukjTablet.sdf", Path.Combine(Properties.Settings.Default.DataPathSQLCE, Properties.Settings.Default.DataNameSQLCE));
                }
                
                return true;

            }
            catch (Exception e)
            {
                // ログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), e.ToString());
                // メッセージ表示
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, e.Message);

                return false;
            }
        }
        #endregion

        #region FinallyApplication
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： FinallyApplication
        /// <summary>
        /// アプリケーションの後処理を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>成否</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/11/30　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static bool FinallyApplication()
        {
            try
            {
                //// アプリケーションロジックの実体作成
                //FinallyApplicationApplicationLogic application = new FinallyApplicationApplicationLogic();
                //// アプリケーションロジックの実行
                //IFinallyApplicationALOutput output = application.Execute(new FinallyApplicationALInput());

                // 2015.02.01 toyoda Add Start
                // 数値キーボードが起動していれば閉じる
                NumberInput.Close();
                // 2015.02.01 toyoda Add End

                return true;
            }
            catch (Exception e)
            {
                // ログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), e.ToString());
                // メッセージ表示
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, e.Message);

                return false;
            }
            finally
            {
                // ミューテックスの解放
                if (MyMutex != null) MyMutex.ReleaseMutex();
            }
        }
        #endregion

        #endregion
    }
}
