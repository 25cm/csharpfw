using FukjBizSystem.Properties;

namespace FukjBizSystem
{
    /// <summary>
    /// 設定ファイル読み込みクラス（Tabletアプリと共有する設定を記述）
    /// </summary>
    public class SettingReader
    {
        /// <summary>
        /// 印刷フォーマットフォルダ（共有）
        /// </summary>
        public static string PrintFormatFolder
        {
            get { return Settings.Default.PrintFormatFolder; }
        }

        /// <summary>
        /// 検査結果書テンプレートファイル名
        /// </summary>
        public static string KensaKekkashoFormatFile
        {
            get { return Settings.Default.KensaKekkashoFormatFile; }
        }
        
        /// <summary>
        /// サーバファイル保存パス
        /// </summary>
        public static string SharedFolderDirectory
        {
            get { return Settings.Default.SharedFolderDirectory; }
        }
        
        /// <summary>
        /// 関連ファイルフォルダ
        /// </summary>
        public static string KensaFukaJohoFileFolder
        {
            get { return Settings.Default.KensaFukaJohoFileFolder; }
        }

        /// <summary>
        /// 現場写真ファイルフォルダ
        /// </summary>
        public static string GenbaShashinFileFolder
        {
            get { return Settings.Default.GenbaShashinFileFolder; }
        }
    }
}
