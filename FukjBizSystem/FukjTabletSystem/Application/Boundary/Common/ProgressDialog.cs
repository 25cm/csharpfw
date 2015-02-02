using System;
using System.ComponentModel;
using System.Windows.Forms;
using FukjTabletSystem.Application.Utility;

namespace FukjTabletSystem.Application.Boundary.Common
{
    /// <summary>
    /// 状況表示ダイアログ
    /// </summary>
    public partial class ProgressDialog : Form
    {
        #region フィールド(private)

        /// <summary>
        /// ワーカ処理に渡す引数
        /// </summary>
        private object workerArgument = null;

        /// <summary>
        /// ワーカ処理で設定された結果
        /// </summary>
        private object _result = null;

        public object Result
        {
            get
            {
                return this._result;
            }
        }

        /// <summary>
        /// ワーカ処理で発生したエラー
        /// </summary>
        private Exception _error = null;

        public Exception Error
        {
            get
            {
                return this._error;
            }
        }

        /// <summary>
        /// BackgroundWorkerクラス
        /// </summary>
        public BackgroundWorker BackgroundWorker
        {
            get
            {
                return this.backgroundWorker;
            }
        }

        #endregion

        #region コンストラクタ

        #region ProgressBarDialog(DoWorkEventHandler doWork, object argument)
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="doWork"></param>
        /// <param name="argument"></param>
        public ProgressDialog(DoWorkEventHandler doWork, object argument)
        {
            InitializeComponent();

            //初期設定
            this.workerArgument = argument;
            this.progressBar.Value = 0;
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            //this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            //this.Top = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - this.Height;
            
            //イベント
            this.Shown += new EventHandler(ProgressBar_Shown);
            this.backgroundWorker.DoWork += doWork;
            this.backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
        }
        #endregion

        #region ProgressBarDialog(DoWorkEventHandler doWorkHandler)
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="doWorkHandler"></param>
        public ProgressDialog(DoWorkEventHandler doWorkHandler)
            : this(doWorkHandler, null)
        {
        }
        #endregion

        #endregion

        #region イベントハンドラ

        #region ProgressBar_Shown(object sender, EventArgs e)
        /// <summary>
        /// ダイアログ表示時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProgressBar_Shown(object sender, EventArgs e)
        {
            this.backgroundWorker.RunWorkerAsync(this.workerArgument);
        }
        #endregion

        #region backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        /// <summary>
        /// ReportProgressメソッドが呼び出されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //プログレスバーの値を変更する
            if (e.ProgressPercentage < this.progressBar.Minimum)
            {
                this.progressBar.Value = this.progressBar.Minimum;
            }
            else if (this.progressBar.Maximum < e.ProgressPercentage)
            {
                this.progressBar.Value = this.progressBar.Maximum;
            }
            else
            {
                this.progressBar.Value = e.ProgressPercentage;
            }
        }
        #endregion

        #region backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        /// <summary>
        /// バックグラウンド処理が終了したとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                TabMessageBox.Show2(TabMessageBox.Type.Error,
                    "エラー",
                    "エラーが発生しました。\n\n" + e.Error.Message);
                this._error = e.Error;
                this.DialogResult = DialogResult.Abort;
            }
            else if (e.Cancelled)
            {
                this.DialogResult = DialogResult.Cancel;
            }
            else
            {
                this._result = e.Result;
                this.DialogResult = DialogResult.OK;
            }

            this.Close();
        }
        #endregion

        private void ProgressDialog_Shown(object sender, EventArgs e)
        {
            this.Left = Owner.Left + 3;
            this.Top = Owner.Height - this.Height + Owner.Top + 1;
            this.Width = Owner.Width - 6;
        }

        #endregion
    }
}
