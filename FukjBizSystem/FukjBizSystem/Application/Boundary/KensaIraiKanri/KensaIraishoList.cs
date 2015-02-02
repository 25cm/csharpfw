using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri
{
    public partial class KensaIraishoList : FukjBaseForm
    {
        #region Fields

        private KensaIraishoDisplay parentDispForm;

        #endregion

        // 画面位置管理クラス
        FormLocation formLocation = new FormLocation();

        public KensaIraishoList()
        {
            InitializeComponent();
        }

        public KensaIraishoList(KensaIraishoDisplay f)
        {
            parentDispForm = f; // メイン・フォームへの参照を保存

            InitializeComponent();
        }

        #region Events

        private void KensaIraishoList_Load(object sender, EventArgs e)
        {
            // PDFリスト取得・表示
            SetPdfInfo();

            fileListDataGridView.Rows[0].Selected = true;

            // 最初のPDFファイルを表示
            OnSelectPdf();

            // 保存画面位置取得
            Location = formLocation.GetPoint(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this);
            Size = formLocation.GetSize(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, this.Size);
        }

        private void fileListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex <= -1)
            {
                return;
            }

            OnSelectPdf();
        }

        private void KensaIraishoList_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 画面位置保存
            formLocation.SetPoint(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, Location);
            formLocation.SetSize(ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd, this, Size);
        }

        #endregion

        #region Methods

        private void SetPdfInfo()
        {
            // TODO 親画面に、選択ファイルパスを返す事

            // 画像ディレクトリ
            string pdfDir = Properties.Settings.Default.PdfRootDir;
            //string pdfDir = @"C:\PDF";

            // ルートからの相対パスを表示、取得する
            string[] pdfPathes = Directory.GetFiles(pdfDir, "*.pdf", SearchOption.TopDirectoryOnly);

            for (int i = 0; i < pdfPathes.Length; i++)
            {
                // 受付ファイル作成日時を取得
                DateTime dtCreate = File.GetCreationTime(pdfPathes[i]);

                string pdfFileName = Path.GetFileName(pdfPathes[i]);

                // 作成日時表示
                fileListDataGridView.Rows.Add(pdfFileName, dtCreate);
            }
        }

        private void OnSelectPdf()
        {
            if (fileListDataGridView.CurrentRow == null)
            {
                return;
            }

            string pdfDir = Properties.Settings.Default.PdfRootDir;
            string pdfFile = fileListDataGridView.CurrentRow.Cells[0].Value.ToString();
            string pdfPath = Path.Combine(pdfDir , pdfFile);

            // 選択されたPDFファイルを表示
            parentDispForm.SelectPdfFile(pdfPath);
        }

        #endregion

        #region 連携インターフェース

        public string GetSelectedFilePath()
        {
            if (fileListDataGridView.CurrentRow == null)
            {
                return null;
            }

            string pdfDir = Properties.Settings.Default.PdfRootDir;
            string pdfFile = fileListDataGridView.CurrentRow.Cells[0].Value.ToString();
            string pdfPath = Path.Combine(pdfDir, pdfFile);

            return pdfPath;
        }

        public string GetSelectedFileName()
        {
            if (fileListDataGridView.CurrentRow == null)
            {
                return null;
            }

            string pdfFile = fileListDataGridView.CurrentRow.Cells[0].Value.ToString();

            return pdfFile;
        }

        #endregion

    }
}

