using System;
using System.IO;

namespace FukjBizSystem.Application.Utility
{
    public class FileUtility
    {
        #region Copy(string fromPath, string toPath, bool overWrite)
        /// <summary>
        /// フォルダを作成してファイルを保存する（エラーは呼び出しもとでキャッチする）
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static void Copy(string from, string to, bool overwrite)
        {
            string toDirectory = to.Substring(0, to.LastIndexOf('\\'));

            // フォルダの作成
            System.IO.Directory.CreateDirectory(toDirectory);

            File.Copy(from, to, overwrite);
        }
        #endregion

        #region CopyToLocal(string from, string to, bool overwrite)
        /// <summary>
        /// フォルダを作成してファイルを保存する（エラーは呼び出しもとでキャッチする）
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static void CopyToLocal(string from, string to, bool overwrite)
        {
            string toDirectory = to.Substring(0, to.LastIndexOf('\\'));

            // フォルダの作成
            System.IO.Directory.CreateDirectory(toDirectory);
            
            try
            {
                SharedFolderUtility.Connect();

                File.Copy(from, to, overwrite);
            }
            finally
            {
                SharedFolderUtility.Disconnect();
            }
        }
        #endregion

        #region CopyToServer(string from, string to, bool overwrite)
        /// <summary>
        /// フォルダを作成してファイルを保存する（エラーは呼び出しもとでキャッチする）
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static void CopyToServer(string from, string to, bool overwrite)
        {
            string toDirectory = to.Substring(0, to.LastIndexOf('\\'));
            
            try
            {
                SharedFolderUtility.Connect();

                // フォルダの作成
                System.IO.Directory.CreateDirectory(toDirectory);

                File.Copy(from, to, overwrite);
            }
            finally
            {
                SharedFolderUtility.Disconnect();
            }
        }
        #endregion
        
        #region CopyToTempFromServer(string servetRoot, string localRoot, string filePath, bool overwrite)
        /// <summary>
        /// フォルダを作成してファイルを保存する（エラーは呼び出しもとでキャッチする）
        /// </summary>
        /// <param name="servetRoot"></param>
        /// <param name="localRoot"></param>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static string CopyToTempFromServer(string servetRoot, string localRoot, string filePath, bool overwrite)
        {
            string fromPath = Path.Combine(servetRoot, filePath);

            string toPath = Path.Combine(localRoot, DateTime.Today.ToString("yyyyMMdd"));

            toPath = Path.Combine(toPath, filePath);

            string toDirectory = toPath.Substring(0, toPath.LastIndexOf('\\'));

            // フォルダの作成
            System.IO.Directory.CreateDirectory(toDirectory);

            try
            {
                SharedFolderUtility.Connect();
                
                // 共有フォルダのファイルをローカルにコピー
                File.Copy(fromPath, toPath, overwrite);
            }
            finally
            {
                SharedFolderUtility.Disconnect();
            }

            return toPath;
        }
        #endregion

        #region CopyToServerFromLocalFile(string servetPath, string filePath, bool overwrite)
        /// <summary>
        /// フォルダを作成してファイルを保存する（エラーは呼び出しもとでキャッチする）
        /// </summary>
        /// <param name="serverPath"></param>
        /// <param name="filePath"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static void CopyToServerFromLocalFile(string serverPath, string filePath, bool overwrite)
        {
            string fromPath = filePath;

            string toPath = Path.Combine(serverPath, filePath.Substring(filePath.LastIndexOf('\\') + 1));

            string toDirectory = serverPath;

            try
            {
                SharedFolderUtility.Connect();

                // フォルダの作成
                System.IO.Directory.CreateDirectory(toDirectory);

                // 共有フォルダのファイルをローカルにコピー
                File.Copy(fromPath, toPath, overwrite);
            }
            finally
            {
                SharedFolderUtility.Disconnect();
            }

            return;
        }
        #endregion

        #region DeleteServerFile(string servetRoot, string filePath)
        /// <summary>
        /// 共有フォルダ上のファイルを削除する
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="overwrite"></param>
        /// <returns></returns>
        public static void DeleteServerFile(string servetRoot, string filePath)
        {
            try
            {
                SharedFolderUtility.Connect();

                // サバ上のファイルを削除
                FileInfo fi = new FileInfo(Path.Combine(servetRoot, filePath));
                fi.Delete();
            }
            finally
            {
                SharedFolderUtility.Disconnect();
            }
        }
        #endregion
    }
}
