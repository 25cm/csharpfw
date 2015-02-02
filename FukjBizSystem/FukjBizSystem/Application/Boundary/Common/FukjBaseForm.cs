using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Control;
using Zynas.Control;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FukjBaseForm
    /// <summary>
    /// FukjBaseForm
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class FukjBaseForm : Form
    {
        #region ProcessDialogKey
        /// <summary>
        /// Enterキー押下をTab押下に置き換える
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        [System.Security.Permissions.UIPermission(
            System.Security.Permissions.SecurityAction.Demand, Window = System.Security.Permissions.UIPermissionWindow.AllWindows)]    
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //Returnキーが押されているか調べる
            //AltかCtrlキーが押されている時は、本来の動作をさせる
            if (((keyData & Keys.KeyCode) == Keys.Return) &&
                ((keyData & (Keys.Alt | Keys.Control)) == Keys.None))
            {
                // TODO: toyoda EnterキーTab移動がうまく動かない場合は、ここで制御せず、KeyDownイベントを使用する

                if (this.ActiveControl is DataGridView)
                {
                    // ここでは拾えない為、KeyDownイベントで別途制御する
                    // DataGridViewが内部でPreviewKeyDownをハンドルしている？
                }
                else if (this.ActiveControl is TextBox && ((TextBox)this.ActiveControl).Multiline)
                {
                    // 本来の処理をさせる
                }
                else if (this.ActiveControl is ZTextBox && ((ZTextBox)this.ActiveControl).Multiline)
                {
                    // 本来の処理をさせる
                }
                else
                {
                    //Tabキーを押した時と同じ動作をさせる
                    //Shiftキーが押されている時は、逆順にする
                    this.ProcessTabKey((keyData & Keys.Shift) != Keys.Shift);
                    //本来の処理はさせない
                    return true;
                }
            }

            return base.ProcessDialogKey(keyData);
        }
        #endregion

        /// <summary>
        /// フォーム終了時のデリゲート
        /// </summary>
        /// <param name="form"></param>
        public delegate void FormEnded(Form form);

        /// <summary>
        /// フォーム終了時のデリゲート
        /// </summary>
        public event FormEnded FormEndEvent = null;

        /// <summary>
        /// InvokeDelegete
        /// </summary>
        /// <param name="form"></param>
        private delegate void InvokeDelegete(Form form);

        /// <summary>
        /// フォームをクローズする際に戻る画面
        /// </summary>
        public object previousForm = null;

        /// <summary>
        /// 初期化完了フラグ
        /// </summary>
        private bool isLoaded = false;

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FukjBaseForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FukjBaseForm()
        {
            InitializeComponent();

            // 初期化開始
            isLoaded = false;
        }
        #endregion

        #region FukjBaseForm_FormClosed
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： FukjBaseForm_FormClosed
        /// <summary>
        /// フォーム終了時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FukjBaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // フォーム終了時イベントを呼び出す
            if (FormEndEvent != null)
            {
                if (previousForm != null)
                {
                    ((FukjBaseForm)previousForm).BeginInvoke(new InvokeDelegete(FormEndEvent), this);
                }
                else
                {
                    FormEndEvent(this);
                }
            }
        }
        #endregion

        #region FukjBaseForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： FukjBaseForm_KeyDown
        /// <summary>
        /// キー押下時にタブ遷移を行う(ProcessDialogKeyの取りこぼし対応)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void FukjBaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // TODO: toyoda EnterキーTab移動がうまく動かない場合は、ここで制御する

                if (this.ActiveControl is DataGridView)
                {
                    // Shiftキー同時押しはTabバック
                    bool forward = e.Modifiers != Keys.Shift;
                    // 次のコントロールへ遷移
                    this.SelectNextControl(this.ActiveControl, forward, true, true, true);
                    //本来の処理はさせない
                    e.Handled = true;
                }
            }
        }
        #endregion

        #region FukjBaseForm_Shown(object sender, EventArgs e)
        /// <summary>
        /// 画面表示完了時
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FukjBaseForm_Shown(object sender, EventArgs e)
        {
            // 初期化完了
            isLoaded = true;
        }
        #endregion
        
        #region Close()
        /// <summary>
        /// 画面表示が完了していればフォームを閉じます
        /// </summary>
        new public void Close()
        {
            if (isLoaded)
            {
                base.Close();
            }
        }
        #endregion
    }
    #endregion
}
