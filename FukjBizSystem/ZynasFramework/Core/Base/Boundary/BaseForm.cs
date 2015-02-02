using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Base.Boundary
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： BaseForm
    /// <summary>
    /// フォームの基本クラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/08　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class BaseForm : Form
    {
        #region WIN32API

        /// <summary>
        /// EnableMenuItem
        /// </summary>
        [DllImport("user32.dll")]
        static extern bool EnableMenuItem(IntPtr hMenu, uint uIDEnableItem, uint uEnable);

        /// <summary>
        /// GetSystemMenu
        /// </summary>
        [DllImport("user32.dll")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        /// <summary>
        /// GetMenuItemCount
        /// </summary>
        [DllImport("user32.dll")]
        static extern int GetMenuItemCount(IntPtr hMenu);

        /// <summary>
        /// RemoveMenu
        /// </summary>
        [DllImport("user32.dll")]
        static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        /// <summary>
        /// MF_REMOVE
        /// </summary>
        internal const UInt32 MF_REMOVE = 0x00001000;

        /// <summary>
        /// MF_BYPOSITION
        /// </summary>
        internal const UInt32 MF_BYPOSITION = 0x00000400;

        /// <summary>
        /// MF_GRAYED
        /// </summary>
        internal const UInt32 MF_GRAYED = 0x00000001;

        /// <summary>
        /// SC_CLOSE
        /// </summary>
        internal const UInt32 SC_CLOSE = 0x0000F060;

        #endregion

        #region 定義

        /// <summary>
        /// フォーム終了時のデリゲート
        /// </summary>
        /// <param name="form"></param>
        public delegate void FormEnd(Form form);

        /// <summary>
        /// キーが離された際のデリゲート
        /// </summary>
        public delegate void KeyPressDelegete();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="form"></param>
        private delegate void InvokeDelegete(Form form);

        #endregion

        #region 静的プロパティ(private)

        /// <summary>
        /// 重複チェック用リスト
        /// </summary>
        private static Dictionary<Form, string> FormList = new Dictionary<Form, string>();

        #endregion

        #region 静的プロパティ(public)

        /// <summary>
        /// キー入力実行リスト
        /// </summary>
        public static Dictionary<Keys, KeyPressDelegete> KeyPressFunction = new Dictionary<Keys, KeyPressDelegete>();

        #endregion

        #region プロパティ(protected)

        /// <summary>
        /// 利用者ID
        /// </summary>
        protected string UserId;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// モーダル制御フラグ
        /// </summary>
        private bool ModalFlg = false;

        /// <summary>
        /// フォーム終了時のデリゲート
        /// </summary>
        private event FormEnd FormEndEvent = null;

        /// <summary>
        /// 画面表示位置クラス
        /// </summary>
        private FormLocation FormLocation = new FormLocation();

        #endregion

        #region コンストラクタ

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： BaseForm
        /// <summary>
        /// クラスの構築を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public BaseForm()
        {
            InitializeComponent();
            //キーイベントをフォームで受け取る

            // TODO DELETE
            //timer1.Interval = 1000;  // タイマの間隔を 1000[ms] に設定
            //timer1.Start();          // タイマを起動
            //TimeLabel.Anchor = AnchorStyles.None;
            //MachineIdLabel.Anchor = AnchorStyles.None;
            //MachineIdLabel.Text = Dns.GetHostName();
            //TimeLabel.Top = 0;
            //MachineIdLabel.Top = 0;
            //TimeLabel.Left = MachineIdLabel.Left + MachineIdLabel.Width + 10;
            //MachineIdLabel.Left = this.Width - MachineIdLabel.Width - TimeLabel.Width - 120;

        }

        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： BaseForm
        /// <summary>
        /// クラスの構築を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="formEnd">画面終了イベント</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected BaseForm(FormEnd formEnd)
        {
            // フォーム終了時イベントを設定
            FormEndEvent = formEnd;

            InitializeComponent();

            // TODO DELETE
            //timer1.Interval = 1000;  // タイマの間隔を 1000[ms] に設定
            //timer1.Start();          // タイマを起動
            //TimeLabel.Anchor = AnchorStyles.None;
            //MachineIdLabel.Anchor = AnchorStyles.None;
            //MachineIdLabel.Text = Dns.GetHostName();
            //TimeLabel.Top = 0;
            //MachineIdLabel.Top = 0;
            //TimeLabel.Left = MachineIdLabel.Left + MachineIdLabel.Width + 10;
            //MachineIdLabel.Left = this.Width - MachineIdLabel.Width - TimeLabel.Width - 120;

        }

        #endregion

        #region メソッド(public)

        #region IsDuplicate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsDuplicate
        /// <summary>
        /// 二重起動のチェックを行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="strList">引数</param>
        /// <returns>チェック結果</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public bool IsDuplicate(params string[] strList)
        {
            // キーを作成
            string key = string.Empty;

            foreach (string str in strList)
            {
                key += str + ",";
            }

            // 同じキーをもつ画面が作成されている
            if (FormList.ContainsValue(key))
            {
                return true;
            }
            // 同じキーをもつ画面が作成されていない
            else
            {
                // キーを追加
                FormList.Add(this, key);

                return false;
            }
        }
        #endregion

        #region ShowDialog
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ShowDialog
        /// <summary>
        /// フォームをモーダルダイアログボックスとして表示します
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/03/18　和田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        new public void ShowDialog()
        {
            // モーダル制御フラグＯＮ
            ModalFlg = true;
            // フォームをモードレスで表示
            Show(ActiveForm);
        }
        #endregion

        #region ShowDialog
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ShowDialog
        /// <summary>
        /// フォームをモーダルダイアログボックスとして表示します
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="owner">親フォーム</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/03/18　和田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        new public void ShowDialog(IWin32Window owner)
        {
            // モーダル制御フラグＯＮ
            ModalFlg = true;
            // フォームをモードレスで表示
            Show(owner);
        }
        #endregion


        /// <summary>
        /// フォームを表示する
        /// </summary>
        delegate void ShowFormDelegate();
        public void ShowForm()
        {
            if (InvokeRequired)
            {
                // 別スレッドから呼び出された場合
                this.BeginInvoke(new ShowFormDelegate(ShowForm));
                return;
            }
            this.ShowDialog();
        }

        /// <summary>
        /// フォームをクローズする
        /// </summary>
        delegate void CloseFormDelegate();
        public void CloseForm()
        {
            if (InvokeRequired)
            {
                // 別スレッドから呼び出された場合
                this.BeginInvoke(new CloseFormDelegate(CloseForm));
                return;
            }
            this.Close();
        }

        #endregion

        #region メソッド(protected)

        #endregion

        #region メソッド(private)

        #region CloseChildForm
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CloseChildForm
        /// <summary>
        /// 子画面(イメージ画面以外)を閉じる
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/08/17　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CloseChildForm()
        {
            try
            {
                // 所有する子画面を全て確認
                foreach (Form form in OwnedForms)
                {
                    try
                    {
                        // 子画面を終了
                        form.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(string.Format("CloseChildForm1 {0}{1}", ex.Message, form.Name));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("CloseChildForm {0}", ex.Message));
            }
        }
        #endregion

        #endregion

        #region イベント

        #region BaseForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BaseForm_Load
        /// <summary>
        /// 初期ロードの処理を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BaseForm_Load(object sender, EventArgs e)
        {
            //「X」閉じるメニュー無効化   
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            if (hMenu != IntPtr.Zero)
            {
                EnableMenuItem(hMenu, SC_CLOSE, MF_GRAYED);
                int menuItemCount = GetMenuItemCount(hMenu);
                RemoveMenu(hMenu, (uint)menuItemCount - 1, MF_REMOVE | MF_BYPOSITION);
            }

            // 表示位置の設定
            if (this.StartPosition == FormStartPosition.WindowsDefaultLocation)
            {
                // デフォルトの場合のみ前回の位置を保持
                Location = FormLocation.GetPoint(UserId, this, new Point(0, 0));
            }

            //キーイベントをフォームで受け取る
            this.KeyPreview = true;
            //KeyDownイベントハンドラを追加
            this.KeyDown += new KeyEventHandler(BaseForm_KeyDown);
        }
        #endregion

        #region BaseForm_Shown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BaseForm_Shown
        /// <summary>
        /// フォームが最初に表示された際の処理を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/13　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BaseForm_Shown(object sender, EventArgs e)
        {
            // モーダル制御フラグがＯＮの場合
            if (ModalFlg)
            {
                // 親フォームを無効にする
                Owner.Enabled = false;
            }
        }
        #endregion

        #region BaseForm_FormClosing
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BaseForm_FormClosing
        /// <summary>
        /// フォームが閉じられる際の処理を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/08　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine(string.Format("BaseForm_FormClosing {0}", this.Text));

            try
            {
                // 子画面が存在する場合
                CloseChildForm();

                // 画面位置
                Point setPoint = this.DesktopLocation;

                #region 画面の位置調整
                if (setPoint.Y <= 0)
                {
                    setPoint.Y = 0;
                }

                if (setPoint.Y >= Screen.GetWorkingArea(this).Height - this.Size.Height / 2)
                {
                    setPoint.Y = Screen.GetWorkingArea(this).Height - this.Size.Height;
                }

                if (setPoint.X < this.Size.Width / 2)
                {
                    setPoint.X = 0;
                }

                if (setPoint.X >= Screen.GetBounds(this).Right - this.Size.Width / 2)
                {
                    setPoint.X = Screen.GetBounds(this).Right - this.Size.Width;
                }
                #endregion

                // 表示位置の保存
                FormLocation.SetPoint(UserId, this, setPoint);
            }
            catch (Exception ex)
            {
                Console.WriteLine(string.Format("BaseForm_FormClosing {0}", ex.Message));
            }

        }
        #endregion

        #region BaseForm_FormClosed
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BaseForm_FormClosed
        /// <summary>
        /// フォームが閉じられた際の処理を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/13　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Console.WriteLine(string.Format("BaseForm_FormClosed {0}", this.Text));

            // モーダル制御フラグがＯＮの場合
            if (ModalFlg)
            {
                // 親フォームを有効にする
                Owner.Enabled = true;
            }

            // フォーム終了時イベントを呼び出す
            if (FormEndEvent != null)
            {
                if (Owner != null)
                {
                    Owner.BeginInvoke(new InvokeDelegete(FormEndEvent), this);
                }
                else
                {
                    FormEndEvent(this);
                }
            }

            // 重複チェック用リストから削除
            FormList.Remove(this);
        }
        #endregion

        #region BaseForm_KeyUp
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： BaseForm_KeyUp
        /// <summary>
        /// キーが離された際の処理を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/11/17　稗田　　    新規作成(ファンクションキー押下で特定の画面を起動対応)
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void BaseForm_KeyUp(object sender, KeyEventArgs e)
        {
            // キー入力実行リスト分繰返し
            foreach (KeyValuePair<Keys, KeyPressDelegete> pair in KeyPressFunction)
            {
                // 入力されたキーが一致する場合
                if (e.Control && e.KeyValue == (char)pair.Key)
                {
                    // 設定された関数を実行
                    if (pair.Value != null)
                    {
                        pair.Value();
                    }
                }
            }
        }
        #endregion

        #region BaseForm_KeyDown
        /////////////////////////////////////////////////////////////////////////////
        ///  イベント名 ： BaseForm_KeyDown
        /// <summary>
        /// キーが押された際の処理を行います
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2012/07/31　吉浦　　    新規作成(攻玉寮のZynasFramework流用)
        /// </history>
        /////////////////////////////////////////////////////////////////////////////
        private void BaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool bThrough = false;

                if (this.ActiveControl.GetType().Name == "TextBox")
                {
                    if (((TextBox)this.ActiveControl).Multiline == true)
                    {
                        bThrough = true;
                    }
                }

                //if (this.ActiveControl.GetType().Name == "ZTextBox")
                //{
                //    if (((GrapeCity.Win.Editors.GcTextBox)this.ActiveControl).Multiline == true)
                //    {
                //        bThrough = true;
                //    }
                //}

                if (this.ActiveControl.GetType().Name == "ZFlexGrid")
                {
                    bThrough = true;
                }

                if (bThrough == false)
                {
                    bool forward = e.Modifiers != Keys.Shift;
                    this.SelectNextControl(this.ActiveControl, forward, true, true, true);
                }
            }
        }
        #endregion

        #region timer1_Tick
        private void timer1_Tick(object sender, EventArgs e)
        {
            //TimeLabel.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");  // 現在の時刻を表示
            //TimeLabel.Text = DateTime.Now.ToString("yyyy/MM/dd HH:mm");  // 現在の時刻を表示

        }
        #endregion

        protected virtual string GetFormTitle(string procname, string projectname, string version)
        {
            return string.Format("{0} - [{1} Ver.{2}]", procname, projectname, version);
        }
        
        #endregion

    }
    #endregion
}
