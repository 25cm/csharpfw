using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace Zynas.Framework.Core.Common.Boundary.Tablet
{
    /// <summary>
    /// 
    /// </summary>
    public class InputUtility
    {
        /// <summary>
        /// ソフトウェアキーボードプロセス名
        /// </summary>
        private static readonly string OSK_PROCESS_NAME = "TabTip";
        /// <summary>
        /// ソフトウェアキーボード実行ファイルパス(Program Filesからの相対)
        /// </summary>
        private static readonly string OSK_EXE_PATH = @"Common Files\microsoft shared\ink\TabTip.exe";

        #region DispOnScreenKeyBoard
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool DispOnScreenKeyBoard()
        {
            bool ret = false;

            try
            {
                #region OSバージョンチェック
                
                //OSの情報を取得する
                System.OperatingSystem os = System.Environment.OSVersion;

                // windows 8以前の場合
                if (os.Version.Major < 6 || os.Version.Minor < 2)
                {
                    // TODO: とりあえず
                    return false;
                }

                #endregion

                // TODO 毎回終了するべきかは、(レスポンスなどを)実機にて動作検証して判断
                // 起動済みの場合終了
                ret = CloseOnScreenKeyBoard();

                // ソフトウェアキーボードプロセス起動
                ret = CreateOnScreenKeyBoard();

            }
            // エラーの場合は失敗扱いとする
            catch
            {
                return false;
            }

            return ret;
        }
        #endregion

        #region CreateOnScreenKeyBoard
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CreateOnScreenKeyBoard()
        {
            bool ret = false;

            try
            {
                // ソフトウェアキーボードプロセス起動
                Process keybordPs = new Process();

                keybordPs.StartInfo.FileName =
                    System.IO.Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)
                    , OSK_EXE_PATH);

                ret = keybordPs.Start();

                return ret;
            }
            // エラーの場合は失敗扱いとする
            catch
            {
                return false;
            }
        }
        #endregion

        #region CloseOnScreenKeyBoard
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool CloseOnScreenKeyBoard()
        {
            bool ret = false;

            try
            {
                System.Diagnostics.Process[] ps =
                    //System.Diagnostics.Process.GetProcesses();
                    System.Diagnostics.Process.GetProcessesByName(OSK_PROCESS_NAME);

                // 既に起動している場合は一度終了させる（非表示の場合が有る為）
                foreach (System.Diagnostics.Process p in ps)
                {
                    if (p.ProcessName == OSK_PROCESS_NAME)
                    {
                        // 終了メッセージ送信
                        if (!p.CloseMainWindow())
                        {
                            // 終了しなかった場合はプロセスを強制終了
                            p.Kill();
                        }

                        p.Close();

                        ret = true;

                        break;
                    }
                }
            }
            catch
            {
                return false;
            }

            return ret;
        }
        #endregion

    }
}
