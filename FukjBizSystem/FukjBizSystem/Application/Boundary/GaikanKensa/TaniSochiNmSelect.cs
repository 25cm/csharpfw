using System;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.GaikanKensa.TaniSochiNmSelect;
using FukjBizSystem.Application.Boundary.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.GaikanKensa
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TaniSochiNmSelectForm
    /// <summary>
    /// 単位装置名選択
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/26　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class TaniSochiNmSelectForm : FukjBaseForm
    {
        #region プロパティ(public)

        /// <summary>
        /// 選択した単位装置名
        /// </summary>
        public string ResultTaniSochiNm;

        #endregion

        #region プロパティ(private)

        // 型式区分
        private string _katashikiMakerCd;
        // 型式コード
        private string _katashikiCd;
        // 所見区分
        private string _shokenKbn;
        // 所見コード
        private string _shokenCd;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TaniSochiNmSelectForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="katashikiMakerCd">浄化槽台帳．型式区分</param>
        /// <param name="katashikiCd">浄化槽台帳．型式コード</param>
        /// <param name="shokenKbn">所見区分</param>
        /// <param name="shokenCd">所見コード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TaniSochiNmSelectForm(string katashikiMakerCd, string katashikiCd, string shokenKbn, string shokenCd)
            : base()
        {
            _katashikiMakerCd = katashikiMakerCd;
            _katashikiCd = katashikiCd;
            _shokenKbn = shokenKbn;
            _shokenCd = shokenCd;

            InitializeComponent();
        }
        #endregion

        #region イベント(private)

        #region TaniSochiNmSelectForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： SyokenKekkaSelectForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TaniSochiNmSelectForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 単位装置名一覧表示
                DoFormLoad();

                if (taniSochiNmDataGridView.Rows.Count == 0)
                {
                    // 使用不可
                    selectButton.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

                this.DialogResult = DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region selectButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： selectButton_Click
        /// <summary>
        /// 選択戻りボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void selectButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (taniSochiNmDataGridView.Rows.Count == 0)
                {
                    return;
                }

                // 選択行数取得
                if (taniSochiNmDataGridView.CurrentRow.Index < 0)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "データを選択して下さい。");
                    return;
                }

                // 単位装置名
                ResultTaniSochiNm = taniSochiNmDataGridView.CurrentRow.Cells[taniSochiNmDataGridViewTextBoxColumn.Index].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 閉じるボタン押下イベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ダイアログを閉じる
                this.Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region taniSochiNmDataGridView_CellDoubleClick
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： taniSochiNmDataGridView_CellDoubleClick
        /// <summary>
        /// 一覧セルダブルクリックイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void taniSochiNmDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (taniSochiNmDataGridView.Rows.Count == 0)
                {
                    return;
                }

                if (e.RowIndex == -1)
                {
                    return;
                }

                selectButton.PerformClick();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region TaniSochiNmSelectForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： TaniSochiNmSelectForm_KeyDown
        /// <summary>
        /// キーダウンイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TaniSochiNmSelectForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyData)
                {
                    case Keys.F1:
                        selectButton.Focus();
                        selectButton.PerformClick();
                        break;
                    case Keys.F12:
                        closeButton.Focus();
                        closeButton.PerformClick();
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region DoFormLoad
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoFormLoad
        /// <summary>
        /// 単位装置名一覧表示
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            // 補足情報取得
            IFormLoadALInput alInput = new FormLoadALInput();
            // 型式区分
            alInput.KatashikiMakerCd = _katashikiMakerCd;
            // 型式コード
            alInput.KatashikiCd = _katashikiCd;
            // 所見区分
            alInput.ShokenKbn = _shokenKbn;
            // 所見コード
            alInput.ShokenCd = _shokenCd;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // 所見一覧データグリッドビュー
            taniSochiNmDataGridView.DataSource = alOutput.TaniSochiNmDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
