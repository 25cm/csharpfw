using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using FukjTabletSystem.Application.Utility;

namespace FukjTabletSystem.Application.Boundary.Common
{
    /// <summary>
    /// カメラロール写真取込用支援ダイアログ
    /// </summary>
    public partial class GetPhotoDialog : Form
    {
        #region フィールド(private)

        // 撮影済みファイルのリスト
        private List<string> ImageFileList = new List<string>();
        public List<string> GetImageFileList()
        {
            return ImageFileList;
        }

        // 保存パス
        private string SaveDirectry;

        // 抽出期間開始日時
        private DateTime? StartTime = null;

        #endregion

        #region コンストラクタ(string directry)
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="directry"></param>
        public GetPhotoDialog(string directry)
        {
            InitializeComponent();

            // 引数の保存
            SaveDirectry = directry;
        }
        #endregion

        #region イベントハンドラ

        #region GetPhotoDialog_Load(object sender, EventArgs e)
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetPhotoDialog_Load(object sender, EventArgs e)
        {
            //OSの情報を取得する
            System.OperatingSystem os = System.Environment.OSVersion;

            // windows 8以前の場合
            if (os.Version.Major < 6 || os.Version.Minor < 2)
            {
                TabMessageBox.Show2("カメラ機能はWindows8以降で利用可能です");
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // 抽出期間開始日時を保持
            StartTime = DateTime.Now;
            
            // カメラアプリを起動
            Process.Start("RunCamera.vbs");
        }
        #endregion

        #region stopButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 撮影終了ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void stopButton_Click(object sender, EventArgs e)
        {
            try
            {
                // 開始から終了までの間にカメラロールに保存された撮影データを
                // 保存ディレクトリにコピーし、保存したファイルリストを返す

                DateTime StopTime = DateTime.Now;

                string targetDir = Path.Combine(System.Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Camera Roll");

                if (!Directory.Exists(targetDir))
                {
                    this.DialogResult = DialogResult.Abort;
                    this.Close();
                }

                DirectoryInfo targetDirectoryInfo = new DirectoryInfo(targetDir);

                // ディレクトリ作成
                if (!Directory.Exists(SaveDirectry))
                {
                    Directory.CreateDirectory(SaveDirectry);
                }

                foreach (FileInfo file in targetDirectoryInfo.GetFiles())
                {
                    // 抽出期間中に作成されたイメージファイルのみを対象とする
                    if (file.CreationTime >= StartTime && file.CreationTime <= StopTime && file.Extension == ".JPG")
                    {
                        string fileName = string.Format("{0}{1}{2}", "PICT_", file.CreationTime.ToString("yyyyMMddHHmmss"), ".JPG");

                        // ファイルを移動
                        file.MoveTo(Path.Combine(SaveDirectry, fileName));
                        // リストに追加
                        ImageFileList.Add(fileName);
                    }
                }
            }
            catch
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        #endregion

        #endregion
    }
}
