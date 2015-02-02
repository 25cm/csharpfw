using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Utility
{
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SharedFolderUtility
    /// <summary>
    /// 水質検査関連のユーティリティクラス
    /// 　水質判定などの処理を行うメソッドを提供
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SharedFolderUtility
    {
        #region WIN32API参照用の宣言
        // 接続切断するWin32 API を宣言
        [DllImport("mpr.dll", EntryPoint = "WNetCancelConnection2", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int WNetCancelConnection2(string lpName, Int32 dwFlags, bool fForce);
        // 認証情報を使って接続するWin32 API宣言
        [DllImport("mpr.dll", EntryPoint = "WNetAddConnection2", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
        private static extern int WNetAddConnection2(ref NETRESOURCE lpNetResource, string lpPassword, string lpUsername, Int32 dwFlags);
        // WNetAddConnection2に渡す接続の詳細情報の構造体
        [StructLayout(LayoutKind.Sequential)]
        internal struct NETRESOURCE
        {
            // 列挙の範囲
            public int dwScope;
            // リソースタイプ
            public int dwType;
            // 表示オブジェクト
            public int dwDisplayType;
            // リソースの使用方法
            public int dwUsage;
            [MarshalAs(UnmanagedType.LPWStr)]
            // ローカルデバイス名。使わないならNULL。
            public string lpLocalName;
            [MarshalAs(UnmanagedType.LPWStr)]
            // リモートネットワーク名。使わないならNULL
            public string lpRemoteName;
            [MarshalAs(UnmanagedType.LPWStr)]
            // ネットワーク内の提供者に提供された文字列
            public string lpComment;
            [MarshalAs(UnmanagedType.LPWStr)]
            // リソースを所有しているプロバイダ名
            public string lpProvider;
        }
        #endregion

        #region public メソッド

        #region Connect
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Connect
        /// <summary>
        /// 共有フォルダに接続
        /// サーバの共有フォルダに接続
        /// </summary>
        /// <returns>処理結果（true:正常/false:異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/09  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool Connect()
        {
            // 接続情報を設定  
            NETRESOURCE netResource = new NETRESOURCE();
            netResource.dwScope = 0;
            netResource.dwType = 1;
            netResource.dwDisplayType = 0;
            netResource.dwUsage = 0;
            // ネットワークドライブにする場合は z:などドライブレター設定  
            netResource.lpLocalName = string.Empty;
            // 接続先の共有フォルダ
            netResource.lpRemoteName = Properties.Settings.Default.SharedFolderDirectory;
            netResource.lpProvider = string.Empty;

            // 接続ユーザのID
            string userId = Properties.Settings.Default.SharedFolderUserId;
            // 接続ユーザのPW
            string password = Properties.Settings.Default.SharedFolderUserPw;

            int result = 0;
            try
            {
                // TODO 同一サーバーの他の共有を開いている場合(エクスプローラなどで)、それらが切断されず、後続のConnectに失敗する
                // 既に接続してる場合があるので一旦、切断する
                result = WNetCancelConnection2(Properties.Settings.Default.SharedFolderDirectory, 0, true);
                // 共有フォルダに認証情報を使って接続
                result = WNetAddConnection2(ref netResource, password, userId, 0);
            }
            catch (Exception ex)
            {
                // エラー処理
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("共有フォルダ接続エラー　共有フォルダ:{0} ex:{1}", Properties.Settings.Default.SharedFolderDirectory, ex.Message));
                return false;
            }
            return (result == 0 ? true : false);
        }
        #endregion

        #region Disconnect
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Disconnect
        /// <summary>
        /// 共有フォルダから切断
        /// サーバの共有フォルダから切断
        /// </summary>
        /// <returns>処理結果（true:正常/false:異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/09  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool Disconnect()
        {
            int result = 0;
            try
            {
                // 切断する
                result = WNetCancelConnection2(Properties.Settings.Default.SharedFolderDirectory, 0, true);
            }
            catch (Exception ex)
            {
                // エラー処理
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("共有フォルダ切断エラー　共有フォルダ:{0} ex:{1}", Properties.Settings.Default.SharedFolderDirectory, ex.Message));
                return false;
            }
            return (result == 0 ? true : false);
        }
        #endregion

        #region DownloadFile
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DownloadFile
        /// <summary>
        /// 共有フォルダからローカルにファイルをダウンロード
        /// </summary>
        /// <param name="localFilePath">ローカルファイルパス名</param>
        /// <param name="shareFilePath">共有フォルダファイルパス名</param>
        /// <returns>処理結果（true:正常/false:異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/09  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool DownloadFile(string localFilePath, string shareFilePath)
        {
            // ローカルにダウンロード
            try
            {
                // 一旦、ローカルファイルを削除
                File.Delete(localFilePath);
                // コピー
                File.Copy(shareFilePath, localFilePath);
            }
            catch (UnauthorizedAccessException uae)
            {
                // 認証に失敗
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("ダウンロード認証エラー　ローカルファイル名:{0} 共有フォルダファイル名:{1} ex:{2}", localFilePath, shareFilePath, uae.Message));
                return false;
            }
            catch (Exception ex)
            {
                // 何らかのエラー
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("ダウンロードエラー　ローカルファイル名:{0} 共有フォルダファイル名:{1} ex:{2}", localFilePath, shareFilePath, ex.Message));
                return false;
            }

            return true;
        }
        #endregion

        #region UploadFile
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UploadFile
        /// <summary>
        /// 共有フォルダにローカルのファイルをアップロード
        /// </summary>
        /// <param name="localFilePath">ローカルファイルパス名</param>
        /// <param name="shareFilePath">共有フォルダファイルパス名</param>
        /// <returns>処理結果（true:正常/false:異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/09  小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool UploadFile(string localFilePath, string shareFilePath, bool overwrite = true)
        {
            // 共有フォルダにアップロード
            try
            {
                // コピー（上書き）
                File.Copy(localFilePath, shareFilePath, overwrite);
                // アップロード後はローカルファイル削除
                File.Delete(localFilePath);
            }
            catch (UnauthorizedAccessException uae)
            {
                // 認証に失敗
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("アップロード認証エラー　ローカルファイル名:{0} 共有フォルダファイル名:{1} ex:{2}", localFilePath, shareFilePath, uae.Message));
                return false;
            }
            catch (Exception ex)
            {
                // 何らかのエラー
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("アップロードエラー　ローカルファイル名:{0} 共有フォルダファイル名:{1} ex:{2}", localFilePath, shareFilePath, ex.Message));
                return false;
            }

            return true;
        }
        #endregion

        #region GetConstFolder
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetConstFolder
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constKbn"></param>
        /// <param name="constRenban"></param>
        /// <param name="svLcKbn">0:Server,1:Local</param>
        /// <param name="fdMkekbn"></param>
        /// <param name="addPath"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string GetConstFolder(string constKbn, string constRenban, int svLcKbn, int fdMkekbn, string addPath)
        {
            bool IsConnect = false;

            try
            {
                string retPath = string.Empty;
                string tempPath = string.Empty;

                if (string.IsNullOrEmpty(constKbn) || string.IsNullOrEmpty(constRenban))
                {
                    return retPath;
                }

                // 定数マスタよりパス取得
                string constPath = Common.GetConstValue(constKbn, constRenban);

                if (svLcKbn == 0)
                {
                    tempPath = Path.Combine(Properties.Settings.Default.SharedFolderDirectory, constPath);
                    if (!string.IsNullOrEmpty(addPath))
                    {
                        tempPath = Path.Combine(tempPath, addPath);
                    }
                }
                else if (svLcKbn == 1)
                {
                    tempPath = Path.Combine(Properties.Settings.Default.LocalDirectory, constPath);
                    if (!string.IsNullOrEmpty(addPath))
                    {
                        tempPath = Path.Combine(tempPath, addPath);
                    }
                }
                else
                {
                    return retPath;
                }

                // パス文字列として有効かチェック
                if (tempPath.IndexOfAny(Path.GetInvalidPathChars()) >= 0)
                {
                    return retPath;
                }

                // Connect to server before checking file exists
                if (svLcKbn == 0)
                {
                    // 接続
                    IsConnect = Connect();
                    if (!IsConnect) { return retPath; }
                }

                if (!Directory.Exists(tempPath))
                {
                    if (fdMkekbn == 1)
                    {
                        if (svLcKbn == 0)
                        {
                            try
                            {
                                Directory.CreateDirectory(tempPath);
                            }
                            catch
                            {
                                return retPath;
                            }

                            // 切断
                            IsConnect = Disconnect() ? false : true;
                        }
                        else if (svLcKbn == 1)
                        {
                            try
                            {
                                Directory.CreateDirectory(tempPath);
                            }
                            catch
                            {
                                return retPath;
                            }
                        }
                    }
                    else if (fdMkekbn == 0) { return tempPath; }
                    else { return retPath; }
                }

                retPath = tempPath;

                return retPath;
            }
            finally
            {
                if (IsConnect)
                {
                    Disconnect();
                }
            }
        }
        #endregion

        #region GetKensaIraiKeyFolder
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKensaIraiKeyFolder
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constKbn"></param>
        /// <param name="constRenban"></param>
        /// <param name="kensaKbnStr">KensaIraiHoteiKbn</param>
        /// <param name="hokenjoCdStr">KensaIraiHokenjoCd</param>
        /// <param name="nendoStr">KensaIraiNendo</param>
        /// <param name="renbanStr">KensaIraiRenban</param>
        /// <param name="svLcKbn">0:Server,1:Local</param>
        /// <param name="fdMkekbn">0:don't create,1:create if not exists</param>
        /// <returns>KensaIraiFile Save path.Returns Empty if error</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string GetKensaIraiKeyFolder(string constKbn, string constRenban, string kensaKbnStr, string hokenjoCdStr, string nendoStr, string renbanStr, int svLcKbn, int fdMkekbn)
        {
            string retPath = string.Empty;

            if (string.IsNullOrEmpty(kensaKbnStr) || string.IsNullOrEmpty(hokenjoCdStr)
                || string.IsNullOrEmpty(nendoStr) || string.IsNullOrEmpty(renbanStr))
            {
                return retPath;
            }

            string addPath = string.Empty;
            addPath = Path.Combine(nendoStr, kensaKbnStr);
            addPath = Path.Combine(addPath, hokenjoCdStr);

            retPath = GetConstFolder(constKbn, constRenban, svLcKbn, fdMkekbn, addPath);

            return retPath;
        }
        #endregion

        #region GetKensaIraiKeyFolder
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKensaIraiKeyFolder
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constKbn"></param>
        /// <param name="constRenban"></param>
        /// <param name="kensaKbnStr">KensaIraiHoteiKbn</param>
        /// <param name="hokenjoCdStr">KensaIraiHokenjoCd</param>
        /// <param name="nendoStr">KensaIraiNendo</param>
        /// <param name="renbanStr">KensaIraiRenban</param>
        /// <returns>KensaIraiFile Save path.Returns Empty if error</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string GetKensaIraiKeyFolder(string constKbn, string constRenban, string kensaKbnStr, string hokenjoCdStr, string nendoStr, string renbanStr)
        {
            string retPath = string.Empty;

            retPath = GetKensaIraiKeyFolder(constKbn, constRenban, kensaKbnStr, hokenjoCdStr, nendoStr, renbanStr, 0, 1);

            return retPath;
        }
        #endregion

        #region GetKensaIraiKeyFolder
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constKbn"></param>
        /// <param name="constRenban"></param>
        /// <param name="kensaKbnStr"></param>
        /// <param name="hokenjoCdStr"></param>
        /// <param name="nendoStr"></param>
        /// <param name="renbanStr"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  habu        新規作成
        /// </history>
        public static string GetKeiryoShomeiIraiKeyFolder(string constKbn, string constRenban, string nendoStr, string shishoStr, string renbanStr)
        {
            string retPath = string.Empty;

            string addPath = string.Empty;

            if (string.IsNullOrEmpty(nendoStr)
                || string.IsNullOrEmpty(shishoStr)
                || string.IsNullOrEmpty(renbanStr))
            {
                return retPath;
            }

            addPath = Path.Combine(nendoStr, shishoStr);

            retPath = GetConstFolder(constKbn, constRenban, 0, 1, addPath);

            return retPath;
        }
        #endregion

        #region GetConstServerFolder
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetConstServerFolder
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constKbn"></param>
        /// <param name="constRenban"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string GetConstServerFolder(string constKbn, string constRenban)
        {
            return GetConstFolder(constKbn, constRenban, 0, 1, string.Empty);
        }
        #endregion

        #region GetConstLocalFolder
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetConstLocalFolder
        /// <summary>
        /// 
        /// </summary>
        /// <param name="constKbn"></param>
        /// <param name="constRenban"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  habu        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string GetConstLocalFolder(string constKbn, string constRenban)
        {
            return GetConstFolder(constKbn, constRenban, 1, 1, string.Empty);
        }
        #endregion

        #endregion
    }
}
