using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using FukjTabletSystem.Properties;
using Microsoft.VisualBasic.PowerPacks;

namespace FukjTabletSystem.Application.Boundary.Common
{
    /// <summary>
    /// 手書き入力支援ダイアログ
    /// </summary>
    public partial class InkCanvasDialog : Form
    {
        #region フィールド(private)

        private Graphics grfx;  // Graphics オブジェクト

        private int start = 0;  // 1 = 描画中
        private int startX;     // Line X 起点
        private int startY;     // Line Y 起点

        /// <summary>
        /// ペンの設定
        /// </summary>
        private Pen myPen = new Pen(Pens.Black.Color, 0);

        /// <summary>
        /// ペン設定保存用
        /// </summary>
        private Color PreColor = Pens.Black.Color;

        // 保存済みファイルのリスト
        private string SaveFileName;

        public string GetSaveFileName()
        {
            return SaveFileName;
        }

        // 保存パス
        private string SaveDirectry;

        /// <summary>
        /// shapeContainer
        /// </summary>
        private ShapeContainer shapeContainer;

        /// <summary>
        /// lineShape
        /// </summary>
        private LineShape lineShape;
        
        /// <summary>
        /// rectangleShape
        /// </summary>
        private RectangleShape rectangleShape;

        #endregion

        #region コンストラクタ(string directry)
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="directry"></param>
        public InkCanvasDialog(string directry)
        {
            InitializeComponent();

            // 引数の保存
            SaveDirectry = directry;
        }
        #endregion

        #region イベントハンドラ

        #region InkCanvasDialog_Load(object sender, EventArgs e)
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InkCanvasDialog_Load(object sender, EventArgs e)
        {
            try
            {
                this.SuspendLayout();

                this.WindowState = FormWindowState.Maximized;

                // PictureBoxと同サイズのBitmapオブジェクトを作成
                pictureBox.Image = new Bitmap(this.Width, this.Height);

                grfx = Graphics.FromImage(pictureBox.Image);

                //全体を黒で塗りつぶす
                grfx.FillRectangle(Brushes.White, grfx.VisibleClipBounds);

                this.pictureBox.Refresh();
            }
            finally
            {
                this.ResumeLayout();
            }
        }
        #endregion

        #region pictureBox_MouseDown(object sender, MouseEventArgs e)
        /// <summary>
        /// マウスダウン
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            start = 1;
            startX = e.X;
            startY = e.Y;

            if (lineInputCheckBox.Checked)
            {
                shapeContainer = new ShapeContainer();
                lineShape = new LineShape();
                shapeContainer.Parent = pictureBox;
                lineShape.Parent = shapeContainer;
                lineShape.BorderColor = Color.Black;
                lineShape.BorderWidth = 1;
                lineShape.StartPoint = new Point(startX, startY);
                lineShape.EndPoint = new Point(e.X, e.Y);
            }
            else if (textInputCheckBox.Checked)
            {
                shapeContainer = new ShapeContainer();
                rectangleShape = new RectangleShape();
                shapeContainer.Parent = pictureBox;
                rectangleShape.Parent = shapeContainer;
                rectangleShape.BorderColor = Color.Black;
                rectangleShape.BorderStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                rectangleShape.BorderWidth = 1;
                rectangleShape.Left = startX;
                rectangleShape.Top = startY;
                rectangleShape.Width = 0;
                rectangleShape.Height = 0;
            }
        }
        #endregion

        #region pictureBox_MouseUp(object sender, MouseEventArgs e)
        /// <summary>
        /// マウスアップ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (lineInputCheckBox.Checked && lineShape != null)
            {
                grfx.DrawLine(myPen, startX, startY, e.X, e.Y);

                ((PictureBox)sender).Refresh();

                lineShape.Dispose();
                lineShape = null;

                shapeContainer.Dispose();
                shapeContainer = null;
            }
            else if (textInputCheckBox.Checked)
            {
                using (TextInputDialog dlg2 = new TextInputDialog())
                {
                    dlg2.ShowDialog(this);

                    if (dlg2.DialogResult == System.Windows.Forms.DialogResult.OK)
                    {
                        //Fontを作成
                        Font fnt = new Font("メイリオ", rectangleShape.Height / 2 / dlg2.InputLineCount());

                        //文字列を表示する範囲を指定する
                        RectangleF rect = new RectangleF(rectangleShape.Left, rectangleShape.Top, rectangleShape.Width, rectangleShape.Height);

                        //文字を書く
                        grfx.DrawString(dlg2.InputText(), fnt, Brushes.Black, rect);

                        this.pictureBox.Refresh();
                    }
                }

                rectangleShape.Visible = false;

                rectangleShape = null;

                shapeContainer = null;

                textInputCheckBox.Checked = false;
            }
            else if (ovalLargeCheckBox.Checked)
            {
                grfx.DrawImage(Resources.canvas_oval_l, new Point(e.X - (Resources.canvas_oval_l.Width / 2), e.Y - (Resources.canvas_oval_l.Height / 2)));

                ((PictureBox)sender).Refresh();
            }
            else if (ovalSmallCheckBox.Checked)
            {
                grfx.DrawImage(Resources.canvas_oval_s, new Point(e.X - (Resources.canvas_oval_s.Width / 2), e.Y - (Resources.canvas_oval_s.Height / 2)));

                ((PictureBox)sender).Refresh();
            }

            start = 0;
            startX = e.X;
            startY = e.Y;
        }
        #endregion

        #region pictureBox_MouseMove(object sender, MouseEventArgs e)
        /// <summary>
        /// マウス移動
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (start == 0) return;
            
            if (lineInputCheckBox.Checked)
            {
                lineShape.EndPoint = new Point(e.X, e.Y);
            }
            else if (textInputCheckBox.Checked)
            {
                rectangleShape.Width = e.X - startX;
                rectangleShape.Height = e.Y - startY;
            }
            else if (ovalLargeCheckBox.Checked || ovalSmallCheckBox.Checked)
            {
                // 線を引かない
            }
            else
            {
                grfx.DrawLine(myPen, startX, startY, e.X, e.Y);
                startX = e.X;
                startY = e.Y;
                pictureBox.Refresh();
            }
        }
        #endregion

        #region saveButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 保存ボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(SaveDirectry))
            {
                Directory.CreateDirectory(SaveDirectry);
            }

            try
            {
                lock (this)
                {
                    Bitmap image = (Bitmap)pictureBox.Image;

                    SaveFileName = string.Format("{0}{1}{2}", "MEMO_", DateTime.Now.ToString("yyyyMMddHHmmss"), ".PNG");
                    
                    image.Save(Path.Combine(SaveDirectry, SaveFileName), ImageFormat.Png);
                }
            }
            catch
            {
                DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }
        #endregion

        #region cancelButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
        #endregion

        #region widthButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 太さボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void widthButton_Click(object sender, EventArgs e)
        {
            if (myPen.Width >= 4)
            {
                myPen = new Pen(Color.Black, 0);
                widthButton.Text = string.Format("太さ：{0}", myPen.Width / 2 + 1);
            }
            else
            {
                myPen = new Pen(Color.Black, myPen.Width + 2);
                widthButton.Text = string.Format("太さ：{0}", myPen.Width / 2 + 1);
            }
        }
        #endregion

        #region eraseButton_Click(object sender, EventArgs e)
        /// <summary>
        /// 消しゴムボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eraseButton_Click(object sender, EventArgs e)
        {
            if (myPen.Color == Pens.White.Color)
            {
                myPen = new Pen(PreColor, 0);

                widthButton.Text = string.Format("太さ：{0}", myPen.Width / 2 + 1);
            }
            else
            {
                PreColor = myPen.Color;

                myPen = new Pen(Pens.White.Color, 50);
            }
        }
        #endregion

        #region clerButton_Click(object sender, EventArgs e)
        /// <summary>
        /// クリアボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clerButton_Click(object sender, EventArgs e)
        {
            pictureBox.Image = new Bitmap(this.Width, this.Height);

            grfx = Graphics.FromImage(pictureBox.Image);

            grfx.FillRectangle(Brushes.White, grfx.VisibleClipBounds);

            this.pictureBox.Refresh();

            myPen = new Pen(Pens.Black.Color, 0);
            widthButton.Text = string.Format("太さ：{0}", myPen.Width / 2 + 1);

            PreColor = Pens.Black.Color;
        }
        #endregion

        #region textInputCheckBox_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 文字入力
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textInputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            myPen = new Pen(myPen.Color, 0);
            widthButton.Text = string.Format("太さ：{0}", myPen.Width / 2 + 1);

            if (textInputCheckBox.Checked)
            {
                ovalSmallCheckBox.Enabled = false;
                ovalLargeCheckBox.Enabled = false;
                lineInputCheckBox.Enabled = false;
                saveButton.Enabled = false;
                widthButton.Enabled = false;
                eraceButton.Enabled = false;
                clearButton.Enabled = false;
            }
            else
            {
                ovalSmallCheckBox.Enabled = true;
                ovalLargeCheckBox.Enabled = true;
                lineInputCheckBox.Enabled = true;
                saveButton.Enabled = true;
                widthButton.Enabled = true;
                eraceButton.Enabled = true;
                clearButton.Enabled = true;
            }
        }
        #endregion

        #region lineInputCheckBox_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 直線描画チェックボックス変更
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lineInputCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            myPen = new Pen(myPen.Color, 0);
            widthButton.Text = string.Format("太さ：{0}", myPen.Width / 2 + 1);

            if (lineInputCheckBox.Checked)
            {
                ovalSmallCheckBox.Enabled = false;
                ovalLargeCheckBox.Enabled = false;
                textInputCheckBox.Enabled = false;
                saveButton.Enabled = false;
                widthButton.Enabled = false;
                eraceButton.Enabled = false;
                clearButton.Enabled = false;
            }
            else
            {
                ovalSmallCheckBox.Enabled = true;
                ovalLargeCheckBox.Enabled = true;
                textInputCheckBox.Enabled = true;
                saveButton.Enabled = true;
                widthButton.Enabled = true;
                eraceButton.Enabled = true;
                clearButton.Enabled = true;
            }
        }
        #endregion

        #region ovalLargeCheckBox_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 正円スタンプ（大）チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ovalLargeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ovalLargeCheckBox.Checked)
            {
                ovalSmallCheckBox.Enabled = false;
                lineInputCheckBox.Enabled = false;
                textInputCheckBox.Enabled = false;
                saveButton.Enabled = false;
                widthButton.Enabled = false;
                eraceButton.Enabled = false;
                clearButton.Enabled = false;
            }
            else
            {
                ovalSmallCheckBox.Enabled = true;
                lineInputCheckBox.Enabled = true;
                textInputCheckBox.Enabled = true;
                saveButton.Enabled = true;
                widthButton.Enabled = true;
                eraceButton.Enabled = true;
                clearButton.Enabled = true;
            }
        }
        #endregion

        #region ovalSmallCheckBox_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 正円スタンプ（小）チェック
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ovalSmallCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ovalSmallCheckBox.Checked)
            {
                ovalLargeCheckBox.Enabled = false;
                lineInputCheckBox.Enabled = false;
                textInputCheckBox.Enabled = false;
                saveButton.Enabled = false;
                widthButton.Enabled = false;
                eraceButton.Enabled = false;
                clearButton.Enabled = false;
            }
            else
            {
                ovalLargeCheckBox.Enabled = true;
                lineInputCheckBox.Enabled = true;
                textInputCheckBox.Enabled = true;
                saveButton.Enabled = true;
                widthButton.Enabled = true;
                eraceButton.Enabled = true;
                clearButton.Enabled = true;
            }
        }
        #endregion

        #endregion
    }
}
