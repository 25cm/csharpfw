using System;
using System.Drawing;
using FukjBizSystem.Application.Boundary.Common;

namespace FukjBizSystem.Application.Boundary.KensaIraiKanri
{
    public partial class KensaIraishoImageList : FukjBaseForm
    {

        KensaIraishoDisplay dispForm;

        public KensaIraishoImageList()
        {
            InitializeComponent();
        }

        public KensaIraishoImageList(KensaIraishoDisplay f)
        {
            dispForm = f; // メイン・フォームへの参照を保存
            InitializeComponent();
        }

        private void KensaIraishoList_Load(object sender, EventArgs e)
        {
            string imageDir = @"C:\PDF"; // 画像ディレクトリ
            string[] jpgFiles =
              System.IO.Directory.GetFiles(imageDir, "*.jpg");

            int width = 100;
            int height = 50;

            imageList1.ImageSize = new Size(width, height);
            listView1.LargeImageList = imageList1;

            for (int i = 0; i < jpgFiles.Length; i++)
            {
                Image original = Bitmap.FromFile(jpgFiles[i]);
                Image thumbnail = createThumbnail(original, width, height);

                imageList1.Images.Add(thumbnail);
                listView1.Items.Add(jpgFiles[i].Replace("jpg","pdf"), i);

                original.Dispose();
                thumbnail.Dispose();
            }
        }

        Image createThumbnail(Image image, int w, int h)
        {
            Bitmap canvas = new Bitmap(w, h);

            Graphics g = Graphics.FromImage(canvas);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, w, h);

            float fw = (float)w / (float)image.Width;
            float fh = (float)h / (float)image.Height;

            float scale = Math.Min(fw, fh);
            fw = image.Width * scale;
            fh = image.Height * scale;

            g.DrawImage(image, (w - fw) / 2, (h - fh) / 2, fw, fh);
            g.Dispose();

            return canvas;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(!string.IsNullOrEmpty(listView1.SelectedItems[0].Text))
            {
                AxAcroPDFLib.AxAcroPDF acPdf = (AxAcroPDFLib.AxAcroPDF)dispForm.Controls["axAcroPDF1"];

                acPdf.LoadFile(listView1.SelectedItems[0].Text);

                acPdf.Refresh();
            }
        }
    }
}
