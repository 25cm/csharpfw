using System;
using System.Reflection;
using System.Threading;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.Boundary.YoshiHanbaiKanri;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;
using System.IO;

namespace FukjBizSystem
{
    static class Program
    {
        #region 静的プロパティ(private)
        /// <summary>
        /// アプリ名
        /// </summary>
        private const string AppName = "FukjBizSystem";
        private static Mutex MyMutex = null;
        public static FukjBizSystem.Application.Boundary.Common2.MenuForm mForm = null;
        public static TyumonMenu tyumonMenuFrm = null;

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
                                if (Login.Show() == Login.Result.Login)
                                {
                                    // ログインが行われた場合

                                    // 初期画面表示
                                    mForm = new FukjBizSystem.Application.Boundary.Common2.MenuForm();
                                    //mForm = new MenuForm();
                                    System.Windows.Forms.Application.Run(mForm);
                                }
                            }
                        }
                        finally
                        {
                            // アプリケーションの後処理
                            FinallyApplication();
                        }

                        // ディレクトリの作成
                        //MakeDirectory();

                        //// ログイン画面
                        //Login form = new Login();
                        //form.ShowDialog();

                        //// ログイン成功
                        //if (form.DialogResult == DialogResult.OK)
                        //{
                        //    System.Windows.Forms.Application.Run(new MenuForm());
                        //}
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

                // スキャンPDFディレクトリの作成
                DirectoryInfo scanPdfFormat = new DirectoryInfo(Properties.Settings.Default.PdfRootDir);
                scanPdfFormat.Create();

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
