using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjTabletSystem.Application.ApplicationLogic.Common;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.Utility;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GyoshaSelectListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class GyoshaSelectListForm : FukjTabBaseForm
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GyoshaSelectListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GyoshaSelectListForm()
            : base()
        {
            InitializeComponent();

            // 一覧表示を太字にする
            gyoshaListDataGridView.Font = new System.Drawing.Font(gyoshaListDataGridView.Font.FontFamily, gyoshaListDataGridView.Font.Size, System.Drawing.FontStyle.Bold);
        }
        #endregion

        #region プロパティ

        /// <summary>
        /// 選択された業者情報
        /// </summary>
        private GyoshaMstDataSet.GyoshaMstKensakuRow selectedGyoshaInfo = null;
        public GyoshaMstDataSet.GyoshaMstKensakuRow SelectedGyoshaInfo
        {
            get { return selectedGyoshaInfo; }
        }

        #endregion

        #region イベントハンドラ

        #region GyoshaSelectListForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GyoshaSelectListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                DoSearch();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);

                this.DialogResult = System.Windows.Forms.DialogResult.Abort;
                this.Close();
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region clearButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： clearButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            //業者コード（開始）
            gyoshaCdFromTextBox.Text = string.Empty;

            //業者コード（終了）
            gyoshaCdToTextBox.Text = string.Empty;

            //業者名称
            gyoshaNmTextBox.Text = string.Empty;

            //業者カナ名
            gyoshaKanaTextBox.Text = string.Empty;
        }
        #endregion

        #region kensakuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kensakuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                string ret = DataCheck();

                if (!string.IsNullOrEmpty(ret))
                {
                    TabMessageBox.Show2(TabMessageBox.Type.Error, ret);
                    return;
                }

                DoSearch();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion

        #region gyoshaListDataGridView_CellFormatting
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： 業者マスタ一覧のチェックボックス表示変換
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaListDataGridView_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            // 対象項目判定
            if (dgv.Columns[e.ColumnIndex].Name == "Selected")
            {
                e.Value = "選択";
            }
        }
        #endregion

        #region gyoshaListDataGridView_CellClick
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： 業者マスタ一覧のセルクリック
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void gyoshaListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // ヘッダーのクリックは処理しない
            if (e.RowIndex < 0)
            {
                return;
            }

            DataGridView dgv = (DataGridView)sender;

            // 対象項目判定
            if (dgv.Columns[e.ColumnIndex].Name == "Selected")
            {
                TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
                Cursor preCursor = Cursor.Current;

                try
                {
                    Cursor.Current = Cursors.WaitCursor;

                    selectedGyoshaInfo = gyoshaMstDataSet.GyoshaMstKensaku[e.RowIndex];

                    this.DialogResult = DialogResult.OK;

                    this.Close();

                }
                catch (Exception ex)
                {
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                    TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
                }
                finally
                {
                    Cursor.Current = preCursor;
                    TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
                }

            }
        }
        #endregion
        
        #region 機能ボタン
        
        #region closeButton_Click
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;

                this.Close();
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                TabMessageBox.Show(TabMessageBox.Type.Error, MessageResouce.MSGID_E00001, ex.Message);
            }
            finally
            {
                Cursor.Current = preCursor;
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }
        }
        #endregion
        
        #endregion
                               
        #endregion

        #region メソッド(private)

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoSearch
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            gyoshaMstDataSet.GyoshaMstKensaku.Clear();

            IGetGyoshaMstByConditionALInput alInput = new GetGyoshaMstByConditionALInput();

            GyoshaMstDataSet.GyoshaMstSearchCond gyoshaMst = new GyoshaMstDataSet.GyoshaMstSearchCond();
            gyoshaMst.GyoshaCdFrom = gyoshaCdFromTextBox.Text.Trim();
            gyoshaMst.GyoshaCdTo = gyoshaCdToTextBox.Text.Trim();
            gyoshaMst.GyoshaNm = gyoshaNmTextBox.Text.Trim();
            gyoshaMst.GyoshaKana = gyoshaKanaTextBox.Text.Trim();

            alInput.GyoshaMstSearchCond = gyoshaMst;

            IGetGyoshaMstByConditionALOutput alOutput = new GetGyoshaMstByConditionApplicationLogic().Execute(alInput);

            if (alOutput.GyoshaMstKensakuDT == null || alOutput.GyoshaMstKensakuDT.Count == 0)
            {
                TabMessageBox.Show2(TabMessageBox.Type.Info, "表示データがありません。");
            }
            else
            {
                gyoshaMstDataSet.GyoshaMstKensaku.Merge(alOutput.GyoshaMstKensakuDT);
            }

        }
        #endregion
        
        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <returns>True/False</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string DataCheck()
        {
            StringBuilder errMsg = new StringBuilder();

            //業者コード（開始）(1)
            if (!string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && gyoshaCdFromTextBox.Text.Length != 4)
            {
                errMsg.AppendLine("業者コード（開始）は4桁で入力して下さい。");
            }

            //業者コード（終了）(2)
            if (!string.IsNullOrEmpty(gyoshaCdToTextBox.Text) && gyoshaCdToTextBox.Text.Length != 4)
            {
                errMsg.AppendLine("業者コード（終了）は4桁で入力して下さい。");
            }

            if (string.IsNullOrEmpty(errMsg.ToString()) && !string.IsNullOrEmpty(gyoshaCdFromTextBox.Text) && !string.IsNullOrEmpty(gyoshaCdToTextBox.Text))
            {
                if (Convert.ToInt32(gyoshaCdFromTextBox.Text) > Convert.ToInt32(gyoshaCdToTextBox.Text))
                {
                    errMsg.AppendLine("範囲指定が正しくありません。業者コードの大小関係を確認してください。");
                }
            }

            //業者名称(3)
            if (gyoshaNmTextBox.Text.Trim().Length > 40)
            {
                errMsg.AppendLine("業者名称は40文字以下で入力して下さい。");
            }

            //業者カナ名(4)
            if (gyoshaKanaTextBox.Text.Trim().Length > 40)
            {
                errMsg.AppendLine("業者カナ名は40文字以下で入力して下さい。");
            }

            return errMsg.ToString();
        }
        #endregion
                
        #endregion
    }
    #endregion
}
