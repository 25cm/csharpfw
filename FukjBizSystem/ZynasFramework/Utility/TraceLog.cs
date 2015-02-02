using System;
using System.IO;
using System.Reflection;

namespace Zynas.Framework.Utility
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TraceLog
    /// <summary>
    /// ログの出力を行います
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/08　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public static class TraceLog
    {
        #region 静的プロパティ(private)

        /// <summary>
        /// ロガー名
        /// </summary>
        private static string _LoggerName = "TraceLogger";

        #endregion

        public static string LoggerName
        {
            get { return _LoggerName; }
            set { _LoggerName = value; }
        }


        #region 静的メソッド(public)

        #region Write
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： Write
        /// <summary>
        /// ログの出力を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="msg">ログに出力する文字列</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void Write(string msg)
        {
            log4net.LogManager.GetLogger(_LoggerName).Info(msg);
        }
        #endregion

        #region InfoWrite
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： InfoWrite
        /// <summary>
        /// ログの出力を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="msg">ログに出力する文字列</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/07/30　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void InfoWrite(MethodBase method, string msg)
        {
            log4net.LogManager.GetLogger(_LoggerName).Info(method.DeclaringType.FullName + "." + method.Name + "[" + msg + "]");
        }
        #endregion

        #region DebugWrite
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： DebugWrite
        /// <summary>
        /// ログの出力を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="msg">ログに出力する文字列</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/07/30　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void DebugWrite(MethodBase method, string msg)
        {
            log4net.LogManager.GetLogger(_LoggerName).Debug(method.DeclaringType.FullName + "." + method.Name + "[" + msg + "]");
        }
        #endregion

        #region ErrorWrite
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ErrorWrite
        /// <summary>
        /// ログの出力を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="msg">ログに出力する文字列</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/07/30　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void ErrorWrite(MethodBase method, string msg)
        {
            log4net.LogManager.GetLogger(_LoggerName).Error(method.DeclaringType.FullName + "." + method.Name + "[" + msg + "]");
        }
        #endregion

        #region WarnWrite
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： WarnWrite
        /// <summary>
        /// ログの出力を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="msg">ログに出力する文字列</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/07/30　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void WarnWrite(MethodBase method, string msg)
        {
            log4net.LogManager.GetLogger(_LoggerName).Warn(method.DeclaringType.FullName + "." + method.Name + "[" + msg + "]");
        }
        #endregion

        #region FatalWrite
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： FatalWrite
        /// <summary>
        /// ログの出力を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="msg">ログに出力する文字列</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/07/30　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void FatalWrite(MethodBase method, string msg)
        {
            log4net.LogManager.GetLogger(_LoggerName).Fatal(method.DeclaringType.FullName + "." + method.Name + "[" + msg + "]");
        }
        #endregion

        #region StartWrite
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： StartWrite
        /// <summary>
        /// メソッド開始ログの出力を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="msg">ログに出力する文字列</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void StartWrite(MethodBase method)
        {
            log4net.LogManager.GetLogger(_LoggerName).Debug(method.DeclaringType.FullName + "." + method.Name + " In");
        }
        #endregion

        #region EndWrite
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： EndWrite
        /// <summary>
        /// メソッド開始ログの出力を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="msg">ログに出力する文字列</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void EndWrite(MethodBase method)
        {
            log4net.LogManager.GetLogger(_LoggerName).Debug(method.DeclaringType.FullName + "." + method.Name + " Out");
        }
        #endregion


        #region EndWrite
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： EndWrite
        /// <summary>
        /// メソッド開始ログの出力を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="msg">ログに出力する文字列</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/10/29　稗田　　    新規作成(ログ削除対応)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void DeleteLog(int days)
        {
            foreach (log4net.Appender.IAppender appender
                in log4net.LogManager.GetRepository().GetLogger(_LoggerName).Repository.GetAppenders())
            {

                log4net.Appender.FileAppender fileAppender = appender as log4net.Appender.FileAppender;
                // ファイルアペンダの場合
                if (fileAppender != null)
                {
                    // 拡張子を取得
                    string ext = Path.GetExtension(fileAppender.File);
                    // ディレクトリ情報を取得
                    DirectoryInfo dirInfo = new DirectoryInfo(Path.GetDirectoryName(fileAppender.File));
                    // ディレクトリ配下のファイル分繰返し
                    foreach (FileInfo fileInfo in dirInfo.GetFiles("*" + ext))
                    {
                        // 指定期間より古いファイルか判定
                        if (fileInfo.LastWriteTime < (DateTime.Now - new TimeSpan(days, 0, 0, 0)))
                        {
                            // ファイル削除
                            fileInfo.Delete();
                        }
                    }
                }
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
