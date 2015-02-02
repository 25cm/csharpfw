using System;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoShinseiShosai;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.KinoHoshoKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShishoMstShosaiForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class HoshoShinseiShosaiForm : FukjBaseForm
    {
        #region 定義(public)

        /// <summary>
        /// 表示モード
        /// </summary>
        public enum DispMode
        {
            Edit,       // 編集モード
            Delete,
            Detail,     // 詳細
            Confirm,    // 入力確認
        }

        #endregion

        #region プロパティ(public)

        /// <summary>
        /// Display mode
        /// </summary>
        public DispMode _dispMode;

        #endregion

        #region プロパティ(private)

        /// <summary>
        /// 保証登録検査機関
        /// </summary>
        private string _hoshoTorokuKensakikan;

        /// <summary>
        /// 保証登録年度
        /// </summary>
        private string _hoshoTorokuNendo;

        /// <summary>
        /// 保証登録連番
        /// </summary>
        private string _hoshoTorokuRenban;

        /// <summary>
        /// 保証登録テーブル
        /// </summary>
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable _hoshoTorokuTbl { get; set; }

        /// <summary>
        /// 浄化槽マスタ
        /// </summary>
        private JokasoMstDataSet.JokasoMstDataTable _jokasoMst { get; set; }

        /// <summary>
        /// 法定管理マスタ
        /// </summary>
        private HoteiKanriMstDataSet.HoteiKanriMstDataTable _hoteiKanriMst { get; set; }

        /// <summary>
        /// 郵便番号住所マスタ
        /// </summary>
        private YubinNoAdrMstDataSet.YubinNoAdrMstDataTable _yubinNoAdrMst { get; set; }

        /// <summary>
        /// HoshoShinseiShosaiDataTable
        /// </summary>
        private HoshoTorokuTblDataSet.HoshoShinseiShosaiDataTable _dispTable { get; set; }

        // 2015.01.20 AnhNV ADD v1.03 Start
        ///// <summary>
        ///// 業者マスタ
        ///// </summary>
        //private GyoshaMstDataSet.GyoshaMstDataTable _gyoshaMstTable { get; set; }
        /// <summary>
        /// 型式マスタ
        /// </summary>
        private KatashikiMstDataSet.KatashikiMstDataTable _katashikiTable { get; set; }
        /// <summary>
        /// GyoshaMstKensakuDataTable
        /// </summary>
        private GyoshaMstDataSet.GyoshaMstKensakuDataTable _gyoshaMstKensakuTable { get; set; }
        // 2015.01.20 AnhNV ADD v1.03 End

        /// <summary>
        /// Form load completed?
        /// </summary>
        //private bool _isLoad;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HoshoShinseiShosai
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HoshoShinseiShosaiForm()
        {
            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HoshoShinseiShosai
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="hoshoTorokuKensakikan">保証登録検査機関</param>
        /// <param name="hoshoTorokuNendo">保証登録年度</param>
        /// <param name="hoshoTorokuRenban">保証登録連番</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HoshoShinseiShosaiForm(string hoshoTorokuKensakikan, string hoshoTorokuNendo, string hoshoTorokuRenban)
        {
            this._hoshoTorokuKensakikan = hoshoTorokuKensakikan;
            this._hoshoTorokuNendo = hoshoTorokuNendo;
            this._hoshoTorokuRenban = hoshoTorokuRenban;

            InitializeComponent();
            SetControlDomain();
        }
        #endregion

        #region イベント

        #region HoshoShinseiShosaiForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HoshoShinseiShosaiForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HoshoShinseiShosaiForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._dispMode = DispMode.Detail;
                this.Text = "保証登録テーブル詳細";

                // Load and display default value
                DoFormLoad();

                // Title of screen
                SetScreenTitle();

                // Display/Input control
                ItemControl();

                // Form load completed
                //_isLoad = true;
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

        #region kojiGyoshaSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： kojiGyoshaSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kojiGyoshaSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open gyoshaMst search form
                GyoshaMstSearchForm form = new GyoshaMstSearchForm(/*kojiGyosha = */"1", string.Empty);
                form.ShowDialog();

                // User close the form
                if (form.DialogResult != DialogResult.OK) return;

                // No row is selected
                if (form._selectedRow == null) return;

                // 工事業者名称(6)
                kojiGyoshaNmTextBox.Text = form._selectedRow.GyoshaNm;

                // 工事業者コード(hidden)
                hoshoTorokuKojiGyoshaTextBox.Text = form._selectedRow.GyoshaCd;
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

        #region hoshoTorokuSetchishaZipCdTextBox_TextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuSetchishaZipCdTextBox_TextChanged
        /// <summary>
        /// 設置者 郵便番号(10) text changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private void hoshoTorokuSetchishaZipCdTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        // Form load incompleted?
        //        if (!_isLoad) return;

        //        // Select address from YubinNoAdrMstDataSet
        //        YubinNoAdrMstDataSet.YubinNoAdrMstRow[] row = (YubinNoAdrMstDataSet.YubinNoAdrMstRow[])_yubinNoAdrMst.Select(
        //            string.Format("ZipCd = '{0}'", hoshoTorokuSetchishaZipCdTextBox.Text));

        //        // Set result for target textbox
        //        hoshoTorokuSetchishaAdrTextBox.Text =
        //            row.Length > 0 ? string.Concat(row[0].TodofukenNm, row[0].ShikuchosonNm, row[0].ChoikiNm) : string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
        //        MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = preCursor;
        //        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
        //    }
        //}
        #endregion

        #region hoshoTorokuSetchibashoZipCdTextBox_TextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuSetchibashoZipCdTextBox_TextChanged
        /// <summary>
        /// 建物 郵便番号(14) text changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private void hoshoTorokuSetchibashoZipCdTextBox_TextChanged(object sender, EventArgs e)
        //{
        //    TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
        //    Cursor preCursor = Cursor.Current;

        //    try
        //    {
        //        Cursor.Current = Cursors.WaitCursor;

        //        // Form load incompleted
        //        if (!_isLoad) return;

        //        // Select address from YubinNoAdrMstDataSet
        //        YubinNoAdrMstDataSet.YubinNoAdrMstRow[] row = (YubinNoAdrMstDataSet.YubinNoAdrMstRow[])_yubinNoAdrMst.Select(
        //            string.Format("ZipCd = '{0}'", hoshoTorokuSetchibashoZipCdTextBox.Text));

        //        // 建物 住所(37)
        //        hoshoTorokuSetchibashoAdrTextBox.Text =
        //            row.Length > 0 ? string.Concat(row[0].TodofukenNm, row[0].ShikuchosonNm, row[0].ChoikiNm) : string.Empty;
        //    }
        //    catch (Exception ex)
        //    {
        //        TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
        //        MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);
        //    }
        //    finally
        //    {
        //        Cursor.Current = preCursor;
        //        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
        //    }
        //}
        #endregion

        #region zipCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： zipCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void zipCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Current textbox
                TextBox zipCdTextBox = sender as TextBox;

                if (null == _yubinNoAdrMst)
                {
                    IZipCdTextBoxLeaveALOutput alOutput = new ZipCdTextBoxLeaveApplicationLogic().Execute(new ZipCdTextBoxLeaveALInput());
                    _yubinNoAdrMst = alOutput.YubinNoAdrMstDataTable;
                }

                // Select address from YubinNoAdrMstDataSet
                YubinNoAdrMstDataSet.YubinNoAdrMstRow[] row = (YubinNoAdrMstDataSet.YubinNoAdrMstRow[])_yubinNoAdrMst.Select(
                    string.Format("ZipCd = '{0}'", zipCdTextBox.Text));
                
                if (zipCdTextBox.Name == hoshoTorokuSetchishaZipCdTextBox.Name)
                {
                    hoshoTorokuSetchishaAdrTextBox.Text =
                        row.Length > 0 ? string.Concat(row[0].TodofukenNm, row[0].ShikuchosonNm, row[0].ChoikiNm) : string.Empty;
                }

                if (zipCdTextBox.Name == hoshoTorokuSetchibashoZipCdTextBox.Name)
                {
                    // 建物 住所(37)
                    hoshoTorokuSetchibashoAdrTextBox.Text =
                        row.Length > 0 ? string.Concat(row[0].TodofukenNm, row[0].ShikuchosonNm, row[0].ChoikiNm) : string.Empty;
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

        #region setchiKojiGyoshaSearchButton1_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setchiKojiGyoshaSearchButton1_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setchiKojiGyoshaSearchButton1_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                YubinJusyoMstSearchForm form = new YubinJusyoMstSearchForm();
                form.ShowDialog();

                // User close the form
                if (form.DialogResult != DialogResult.OK) return;

                // No row is selected
                if (form._selectedRow == null) return;

                // 設置者 郵便番号(10)
                hoshoTorokuSetchishaZipCdTextBox.Text = form._selectedRow.ZipCd;

                // 設置者 住所(12)
                hoshoTorokuSetchishaAdrTextBox.Text = string.Concat(
                    form._selectedRow.TodofukenNm,
                    form._selectedRow.ShikuchosonNm,
                    form._selectedRow.ChoikiNm);
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

        #region tatemonoSetchKojiGyoshaSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tatemonoSetchKojiGyoshaSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tatemonoSetchKojiGyoshaSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                YubinJusyoMstSearchForm form = new YubinJusyoMstSearchForm();
                form.ShowDialog();

                // User close the form
                if (form.DialogResult != DialogResult.OK) return;

                // No row is selected
                if (form._selectedRow == null) return;

                // 建物 郵便番号(14)
                hoshoTorokuSetchibashoZipCdTextBox.Text = form._selectedRow.ZipCd;

                // 建物 住所(12)
                hoshoTorokuSetchibashoAdrTextBox.Text = string.Concat(
                    form._selectedRow.TodofukenNm,
                    form._selectedRow.ShikuchosonNm,
                    form._selectedRow.ChoikiNm);
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

        #region setchiKojiGyoshaSearchButton2_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： setchiKojiGyoshaSearchButton2_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void setchiKojiGyoshaSearchButton2_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open chikuMst search form
                ChikuMstSearchForm form = new ChikuMstSearchForm();
                form.ShowDialog();

                // User close the form
                if (form.DialogResult != DialogResult.OK) return;

                // No row is selected
                if (form._selectedRow == null) return;

                // 市町村 名称名(16)
                hoshoTorokuHojoShichosonNmTextBox.Text = form._selectedRow.ChikuNm;

                // 市町村 名称コード(hidden)
                hoshoTorokuHojoShichosonCdTextBox.Text = form._selectedRow.ChikuCd;
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

        #region hoshoTorokuSetchishaZipCdTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuSetchishaZipCdTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuSetchishaZipCdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '-')
                {
                    e.Handled = true;
                }

                // only allow one negative sign
                if (e.KeyChar == '-'
                    && (sender as TextBox).Text.IndexOf('-') > -1)
                {
                    e.Handled = true;
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

        #region hoshoTorokuSetchibashoZipCdTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuSetchibashoZipCdTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuSetchibashoZipCdTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!char.IsControl(e.KeyChar)
                && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '-')
                {
                    e.Handled = true;
                }

                // only allow one negative sign
                if (e.KeyChar == '-'
                    && (sender as TextBox).Text.IndexOf('-') > -1)
                {
                    e.Handled = true;
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

        #region hoshoTorokuJokasoTorokuNoTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuJokasoTorokuNoTextBox_Leave
        /// <summary>
        /// 浄化槽登録番号(18) text changed)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuJokasoTorokuNoTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Form load incompleted
                //if (!_isLoad) return;

                // Select address from JokasoMstDataSet
                JokasoMstDataSet.JokasoMstRow[] row = (JokasoMstDataSet.JokasoMstRow[])_jokasoMst.Select(
                    string.Format("JokasoTorokuNo = '{0}'", hoshoTorokuJokasoTorokuNoTextBox.Text));

                // 浄化槽 名称(19)
                jokasoKatashikiNmTextBox.Text = row.Length > 0 ? row[0].JokasoKatashikiNm : string.Empty;
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

        #region seizoGyoshaSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： seizoGyoshaSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void seizoGyoshaSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Open gyoshaMst search form
                GyoshaMstSearchForm form = new GyoshaMstSearchForm(string.Empty, /*seizoGyosha = */"1");
                form.ShowDialog();

                // User close the form
                if (form.DialogResult != DialogResult.OK) return;

                // No row is selected
                if (form._selectedRow == null) return;

                // 製造業者 名称(21)
                seizoGyoshaNmTextBox.Text = form._selectedRow.GyoshaNm;

                // 製造業者 コード(hidden)
                hoshoTorokuMakerCdTextBox.Text = form._selectedRow.GyoshaCd;
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

        #region changeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： changeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void changeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._dispMode == DispMode.Detail)
                {
                    // Switches to Edit mode
                    this._dispMode = DispMode.Edit;
                }
                else if (this._dispMode == DispMode.Edit)
                {
                    // 単項目チェック + 入力内容チェック
                    if (!DataCheck()) return;

                    // Switches to confirm mode
                    this._dispMode = DispMode.Confirm;
                }

                // Set screen title
                SetScreenTitle();

                // Set input/read only property
                ItemControl();

                this._dispMode = DispMode.Edit;
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

        #region deleteButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： deleteButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void deleteButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (this._dispMode == DispMode.Detail)
                {
                    // Switches to delete mode
                    this._dispMode = DispMode.Delete;
                }
                else if (this._dispMode == DispMode.Delete)
                {
                    // Switches to confirm mode
                    this._dispMode = DispMode.Confirm;
                }

                // Set screen title
                SetScreenTitle();

                // Set input/read only property
                ItemControl();

                this._dispMode = DispMode.Delete;
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

        #region reInputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： reInputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void reInputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                
                // Screen title
                SetScreenTitle();

                // Item control display
                ItemControl();
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

        #region decisionButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： decisionButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void decisionButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Update successfully!
                if (DoUpdate())
                {
                    //HoshoShinseiListForm frm = new HoshoShinseiListForm();
                    //Program.mForm.ShowForm(frm);
                    this.DialogResult = DialogResult.OK;
                    Program.mForm.MovePrev();
                }
            }
            catch (CustomException cex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), cex.ToString());

                if (cex.ResultCode == ResultCode.LockError)
                {
                    // 楽観ロックエラー
                    // 「対象の情報が更新されています。
                    //   再度検索後、操作をやり直してください。」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00009);
                }
                else
                {
                    // 何らかのカスタム例外
                    // 「想定外のシステムエラーが発生しました。
                    //   システム管理者へ連絡してください。
                    //   {0}」
                    MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, cex.Message);
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

        #region HoshoShinseiShosaiForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： HoshoShinseiShosaiForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void HoshoShinseiShosaiForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                switch (e.KeyCode)
                {
                    case Keys.F2:
                        changeButton.Focus();
                        changeButton.PerformClick();
                        break;
                    case Keys.F3:
                        deleteButton.Focus();
                        deleteButton.PerformClick();
                        break;
                    case Keys.F4:
                        reInputButton.Focus();
                        reInputButton.PerformClick();
                        break;
                    case Keys.F5:
                        decisionButton.Focus();
                        decisionButton.PerformClick();
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

        #region numberTextBox_KeyPress
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： numberTextBox_KeyPress
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void numberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
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

        #region closeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void closeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Detail mode
                if (this._dispMode == DispMode.Detail)
                {
                    goto SHOWFORM;
                }

                // Other modes
                if (!EditCheck())
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "編集内容が破棄されます。よろしいですか？") == DialogResult.Yes)
                    {
                        goto SHOWFORM;
                    }

                    return;
                }

                SHOWFORM:
                //HoshoShinseiListForm frm = new HoshoShinseiListForm();
                //Program.mForm.ShowForm(frm);
                Program.mForm.SetMenuEnabled(true);
                Program.mForm.MovePrev();
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

        #region katashikiSearchButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiSearchButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　AnhNV　　    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void katashikiSearchButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                KatashikiMstSearchForm frm = new KatashikiMstSearchForm();

                if (frm.ShowDialog() == DialogResult.OK)
                {
                    // 製造業者 コード(27)
                    hoshoTorokuMakerCdTextBox.Text = frm.MakerGyoshaCd;
                    // 製造業者 名称(28)
                    seizoGyoshaNmTextBox.Text = frm.MakerGyoshaNm;
                    // 浄化槽 型式コード(30)
                    katashikiCdTextBox.Text = frm.KatashikiCd;
                    // 浄化槽 型式名称(31)
                    katashikiNmTextBox.Text = frm.KatashikiNm;
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

        #region hoshoTorokuMakerCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： hoshoTorokuMakerCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　AnhNV　　    v1.03
        /// 2015/01/29　AnhNV　　    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void hoshoTorokuMakerCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (null == _gyoshaMstKensakuTable)
                {
                    HoshoTorokuMakerCdTextBoxLeaveALInput alInput = new HoshoTorokuMakerCdTextBoxLeaveALInput();
                    alInput.GyoshaMstSearchCond = new GyoshaMstSearchCond();
                    alInput.GyoshaMstSearchCond.SeizoGyoShaKbn = "1";
                    IHoshoTorokuMakerCdTextBoxLeaveALOutput alOutput = new HoshoTorokuMakerCdTextBoxLeaveApplicationLogic().Execute(alInput);
                    _gyoshaMstKensakuTable = alOutput.GyoshaMstKensakuDT;
                }

                GyoshaMstDataSet.GyoshaMstKensakuRow[] dr = (GyoshaMstDataSet.GyoshaMstKensakuRow[])_gyoshaMstKensakuTable.Select(
                    string.Format("GyoshaCd = '{0}'", hoshoTorokuMakerCdTextBox.Text));

                if (dr.Length > 0)
                {
                    // 製造業者 名称
                    seizoGyoshaNmTextBox.Text = dr[0].GyoshaNm;
                }
                else
                {
                    hoshoTorokuMakerCdTextBox.Text = string.Empty;
                    seizoGyoshaNmTextBox.Text = string.Empty;
                }

                // v1.04 ADD
                KatashikiLeave(hoshoTorokuMakerCdTextBox.Text, katashikiCdTextBox.Text);
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

        #region katashikiCdTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： katashikiCdTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20　AnhNV　　    v1.03
        /// 2015/01/29　AnhNV　　    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void katashikiCdTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                KatashikiLeave(hoshoTorokuMakerCdTextBox.Text, katashikiCdTextBox.Text);
                // v1.04 DEL
                //if (null == _katashikiTable)
                //{
                //    IKatashikiCdTextBoxLeaveALOutput alOutput = new KatashikiCdTextBoxLeaveApplicationLogic().Execute(new KatashikiCdTextBoxLeaveALInput());
                //    _katashikiTable = alOutput.KatashikiMstDataTable;
                //}

                //KatashikiMstDataSet.KatashikiMstRow[] dr = (KatashikiMstDataSet.KatashikiMstRow[])_katashikiTable.Select(
                //    string.Format("KatashikiMakerCd = '{0}' and KatashikiCd = '{1}'", hoshoTorokuMakerCdTextBox.Text, katashikiCdTextBox.Text));

                //// 浄化槽 型式名称
                //katashikiNmTextBox.Text = dr.Length > 0 ? dr[0].KatashikiNm : string.Empty;
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
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoFormLoad()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            alInput.HoshoTorokuKensakikan = _hoshoTorokuKensakikan;
            // 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
            //alInput.HoshoTorokuNendo = Common.Common.ConvertToHoshouNendoSeireki(_hoshoTorokuNendo);
            //alInput.HoshoTorokuNendo = Utility.Utility.ConvertToSeireki(Convert.ToInt32(_hoshoTorokuNendo));
            // 20140811 habu End

            // 2014/11/04 AnhNV Add start
            alInput.HoshoTorokuNendo = Utility.DateUtility.ConvertFromWareki(_hoshoTorokuNendo, "yyyy");
            // 2014/11/04 AnhNV Add end
            alInput.HoshoTorokuRenban = _hoshoTorokuRenban;
            IFormLoadALOutput alOutput = new FormLoadApplicationLogic().Execute(alInput);

            // Output table
            _dispTable = alOutput.HoshoShinseiShosaiDataTable;
            _jokasoMst = alOutput.JokasoMstDataTable;
            _hoteiKanriMst = alOutput.HoteiKanriMstDataTable;
            //_yubinNoAdrMst = alOutput.YubinNoAdrMstDataTable;
            _hoshoTorokuTbl = alOutput.HoshoTorokuTblDataTable;

            // Default value
            DisplayDefault();
        }
        #endregion

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  AnhNV　　    新規作成
        /// 2015/01/20  AnhNV　　    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DoUpdate()
        {
            // Warning message for delete
            if (_dispMode == DispMode.Delete &&
                MessageForm.Show2(MessageForm.DispModeType.Question, "表示されているデータが削除されます。よろしいですか？") != DialogResult.Yes)
            {
                return false;
            }

            //if (_dispMode == DispMode.Edit)
            //{
            //    HoshoExistCheck();
            //}

            // Current system date
            DateTime systemDt = Common.Common.GetCurrentTimestamp();

            IDecisionBtnClickALInput alInput = new DecisionBtnClickALInput();
            alInput.HoshoTorokuTblDT = _dispMode == DispMode.Edit ? CreateHoshoTorokuTblUpdate(_hoshoTorokuTbl) :
                CreateHoshoTorokuTblDelete(_hoshoTorokuTbl);
            alInput.SystemDt = systemDt;
            alInput.DispMode = _dispMode;

            // v1.03
            if (_dispMode == DispMode.Edit)
            {
                JokasoMstDataSet.JokasoMstRow updateRow;
                if (JokasoExistCheck(out updateRow))
                {
                    JokasoMstDataSet.JokasoMstDataTable table = new JokasoMstDataSet.JokasoMstDataTable();
                    table.ImportRow(updateRow);
                    alInput.JokasoMstDataTable = CreateJokasoMstUpdate(table, systemDt);
                }
                else
                {
                    alInput.JokasoMstDataTable = CreateJokasoMstInsert(systemDt);
                }
            }
            // End v1.03

            IDecisionBtnClickALOutput alOutput = new DecisionBtnClickApplicationLogic().Execute(alInput);

            // Update failed
            if (!string.IsNullOrEmpty(alOutput.ErrMsg))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, alOutput.ErrMsg);
                return false;
            }

            return true;
        }
        #endregion

        #region DisplayDefault
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DisplayDefault
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  AnhNV　　    新規作成
        /// 2015/01/20  AnhNV　　    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DisplayDefault()
        {
            // System date
            DateTime now = Common.Common.GetCurrentTimestamp();

            // 保証登録検査機関(3)
            hoshoTorokuKensakikanTextBox.Text = _hoshoTorokuKensakikan;
            // 保証登録年度(4)
            hoshoTorokuNendoTextBox.Text = _hoshoTorokuNendo;
            // 保証登録連番(5)
            hoshoTorokuRenbanTextBox.Text = _hoshoTorokuRenban;
            // 工事業者名称(6)
            kojiGyoshaNmTextBox.Text = _dispTable[0].KojiGyoshaNm;
            // 工事業者コード(hidden)
            hoshoTorokuKojiGyoshaTextBox.Text = _dispTable[0].HoshoTorokuKojiGyosha;
            // 設置者 フリガナ(8)
            hoshoTorokuSetchishaKanaTextBox.Text = _dispTable[0].HoshoTorokuSetchishaKana;
            // 設置者 氏名(9)
            hoshoTorokuSetchishaNmTextBox.Text = _dispTable[0].HoshoTorokuSetchishaNm;
            // 設置者 郵便番号(10)
            hoshoTorokuSetchishaZipCdTextBox.Text = _dispTable[0].HoshoTorokuSetchishaZipCd;
            // 設置者 住所(12)
            hoshoTorokuSetchishaAdrTextBox.Text = _dispTable[0].HoshoTorokuSetchishaAdr;
            // 建物 郵便番号(14)
            hoshoTorokuSetchibashoZipCdTextBox.Text = _dispTable[0].HoshoTorokuSetchibashoZipCd;
            // 建物 住所(37)
            hoshoTorokuSetchibashoAdrTextBox.Text = _dispTable[0].HoshoTorokuSetchibashoAdr;
            // 建物 建築用途(15)
            hoshoTorokuTatemonoyotoTextBox.Text = _dispTable[0].HoshoTorokuTatemonoyoto;
            // 市町村 名称名(16)
            hoshoTorokuHojoShichosonNmTextBox.Text = _dispTable[0].ChikuNm;
            // 市町村 名称コード(hidden)
            hoshoTorokuHojoShichosonCdTextBox.Text = _dispTable[0].HoshoTorokuHojoShichosonCd;
            // 浄化槽 登録番号(18)
            hoshoTorokuJokasoTorokuNoTextBox.Text = _dispTable[0].HoshoTorokuJokasoTorokuNo;
            // 浄化槽 名称(19)
            jokasoKatashikiNmTextBox.Text = _dispTable[0].JokasoKatashikiNm;
            // 浄化槽 人槽(20)
            hoshoTorokuNinsoTextBox.Text = _dispTable[0].HoshoTorokuNinso;
            // 製造業者 名称(21)
            seizoGyoshaNmTextBox.Text = _dispTable[0].MakerGyoshaNm;
            // 製造業者 コード(hidden)
            hoshoTorokuMakerCdTextBox.Text = _dispTable[0].HoshoTorokuMakerCd;
            // 検査機関 名称(23)
            Utility.Utility.SetComboBoxList(jimukyokuNmComboBox, _hoteiKanriMst, "JimukyokuNm", "JimukyokuKbn", true);
            jimukyokuNmComboBox.SelectedValue = _dispTable[0].HoshoTorokuJokasoKensakikan;
            // 使用開始日(24)
            hoshoTorokuShiyokaishiDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].HoshoTorokuShiyokaishiDt.Trim())
                ? now : Convert.ToDateTime(_dispTable[0].HoshoTorokuShiyokaishiDt);
            // 保健所受理番号２（保健所）(25)
            hoshoTorokuHokenjoCdTextBox.Text = _dispTable[0].HoshoTorokuHokenjoCd;
            // 保健所受理番号１（年度）(26)
            //hoshoTorokuHokenjoNendoTextBox.Text = string.IsNullOrEmpty(_dispTable[0].HoshoTorokuHokenjoNendo)
            //    // 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
            //    ? string.Empty : Common.Common.ConvertToHoshouNendoWareki(_dispTable[0].HoshoTorokuHokenjoNendo);
            //    //? string.Empty : Utility.Utility.ConvertToHeisei(Convert.ToInt32(_dispTable[0].HoshoTorokuHokenjoNendo));
            //    // 20140811 habu End
            hoshoTorokuHokenjoNendoTextBox.Text = Utility.DateUtility.ConvertToWareki(_dispTable[0].HoshoTorokuHokenjoNendo, "yy");
            // 保健所受理番号３（市町村）(27)
            hoshoTorokuHokenjoShichosonCdTextBox.Text = _dispTable[0].HoshoTorokuHokenjoShichosonCd;
            // 保健所受理番号４（連番）(28)
            hoshoTorokuHokenjoRenbanTextBox.Text = _dispTable[0].HoshoTorokuHokenjoRenban;
            // 保健所受付日(29)
            hoshoTorokuJyuriDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].HoshoTorokuJyuriDt.Trim())
                ? now : Convert.ToDateTime(_dispTable[0].HoshoTorokuJyuriDt);
            // 登録確認年月日(30)
            hoshoTorokuTorokuKakuninDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].HoshoTorokuTorokuKakuninDt.Trim())
                ? now : Convert.ToDateTime(_dispTable[0].HoshoTorokuTorokuKakuninDt);
            // 取下日付(31)
            hoshoTorokuTorisageDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].HoshoTorokuTorisageDt.Trim())
                ? now : Convert.ToDateTime(_dispTable[0].HoshoTorokuTorisageDt);

            // 2015.01.20 AnhNV ADD v1.03 Start
            // 浄化槽 登録日
            jokasoTorokuDtDateTimePicker.Value = string.IsNullOrEmpty(_dispTable[0].JokasoTorokuDt) ? now : Convert.ToDateTime(_dispTable[0].JokasoTorokuDt);
            // 浄化槽 型式コード
            katashikiCdTextBox.Text = _dispTable[0].KatashikiCd;
            // 浄化槽 型式名称
            katashikiNmTextBox.Text = _dispTable[0].KatashikiNm;
            // 2015.01.20 AnhNV ADD v1.03 End
        }
        #endregion

        #region SetScreenTitle
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetScreenTitle
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetScreenTitle()
        {
            switch (_dispMode)
            {
                case DispMode.Delete:
                    Program.mForm.Text = "保証登録テーブル廃止";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Detail:
                    Program.mForm.Text = "保証登録テーブル詳細";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Confirm:
                    Program.mForm.Text = "保証登録テーブル入力確認";
                    Program.mForm.SetMenuEnabled(true);
                    break;
                case DispMode.Edit:
                    Program.mForm.Text = "保証登録テーブル変更";
                    Program.mForm.SetMenuEnabled(false);
                    break;
                default:
                    Program.mForm.SetMenuEnabled(true);
                    break;
            }
        }
        #endregion

        #region ItemControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ItemControl
        /// <summary>
        /// Control the input/display property of all items
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  AnhNV　　    新規作成
        /// 2015/01/19  AnhNV　　    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ItemControl()
        {
            // 工事業者名称(6)
            // kojiGyoshaNmTextBox.ReadOnly =
            // 設置者 フリガナ(8)
            hoshoTorokuSetchishaKanaTextBox.ReadOnly =
            // 設置者 氏名(9)
            hoshoTorokuSetchishaNmTextBox.ReadOnly =
            // 設置者 郵便番号(10)
            hoshoTorokuSetchishaZipCdTextBox.ReadOnly =
            // 設置者 住所(12)
            hoshoTorokuSetchishaAdrTextBox.ReadOnly =
            // 建物 郵便番号(14)
            hoshoTorokuSetchibashoZipCdTextBox.ReadOnly =
            // 建物 住所(37)
            hoshoTorokuSetchibashoAdrTextBox.ReadOnly =
            // 建物 建築用途(15)
            hoshoTorokuTatemonoyotoTextBox.ReadOnly =
            // 市町村 名称名(16)
            //hoshoTorokuHojoShichosonNmTextBox.ReadOnly =
            // 浄化槽 登録番号(18)
            hoshoTorokuJokasoTorokuNoTextBox.ReadOnly =
            // 浄化槽 人槽(20)
            hoshoTorokuNinsoTextBox.ReadOnly =
            // 製造業者 名称(21)
            //seizoGyoshaNmTextBox.ReadOnly =
            // 保健所受理番号２（保健所）(25)
            hoshoTorokuHokenjoCdTextBox.ReadOnly =
            // 保健所受理番号１（年度）(26)
            hoshoTorokuHokenjoNendoTextBox.ReadOnly =
            // 保健所受理番号３（市町村）(27)
            hoshoTorokuHokenjoShichosonCdTextBox.ReadOnly =
            // 保健所受理番号４（連番）(28)
            hoshoTorokuHokenjoRenbanTextBox.ReadOnly = this._dispMode != DispMode.Edit;
            // 工事業者検索ボタン(7)
            kojiGyoshaSearchButton.Enabled =
            // 設置者 郵便番号住所検索ボタン(11)
            setchiKojiGyoshaSearchButton1.Enabled =
            // 建物 郵便番号住所検索ボタン(13)
            tatemonoSetchKojiGyoshaSearchButton.Enabled =
            // 地区マスタ検索ボタン(17)
            setchiKojiGyoshaSearchButton2.Enabled =
            // 製造業者検索ボタン(22)
            seizoGyoshaSearchButton.Enabled =
            // 検査機関 名称(23)
            jimukyokuNmComboBox.Enabled =
            // 使用開始日(24)
            hoshoTorokuShiyokaishiDtDateTimePicker.Enabled =
            // 保健所受付日(29)
            hoshoTorokuJyuriDtDateTimePicker.Enabled =
            // 登録確認年月日(30)
            hoshoTorokuTorokuKakuninDtDateTimePicker.Enabled = this._dispMode == DispMode.Edit;
            // 廃止年月日(31)
            hoshoTorokuTorisageDtDateTimePicker.Enabled = this._dispMode == DispMode.Delete;
            // 変更ボタン(32)
            changeButton.Visible = (this._dispMode == DispMode.Detail || this._dispMode == DispMode.Edit) ? true : false;
            // 削除ボタン(33)
            deleteButton.Visible = (this._dispMode == DispMode.Detail || this._dispMode == DispMode.Delete) ? true : false;
            // 再入力ボタン(34)
            reInputButton.Visible =
            // 確定ボタン(35)
            decisionButton.Visible = this._dispMode == DispMode.Confirm;

            // 2015/01/19 AnhNV ADD v1.03 Start
            // 名称
            jokasoKatashikiNmTextBox.ReadOnly = _dispMode != DispMode.Edit;
            // 製造業者 コード
            hoshoTorokuMakerCdTextBox.ReadOnly = _dispMode != DispMode.Edit;
            // 浄化槽 登録日
            jokasoTorokuDtDateTimePicker.Enabled = _dispMode == DispMode.Edit;
            // 浄化槽 型式コード
            katashikiCdTextBox.ReadOnly = _dispMode != DispMode.Edit;
            // 型式検索ボタン
            katashikiSearchButton.Enabled = _dispMode == DispMode.Edit;
            // Control the tabstop
            TabStopControl();
            // 2015/01/19 AnhNV ADD v1.03 End
        }
        #endregion

        #region EditCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： EditCheck
        /// <summary>
        /// Trigger when any item is modified
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  AnhNV　　    新規作成
        /// 2015/01/29  AnhNV　　    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool EditCheck()
        {
            // System date
            string now = Common.Common.GetCurrentTimestamp().ToString("yyyy/MM/dd");

            // 工事業者名称(6)
            if (kojiGyoshaNmTextBox.Text != _dispTable[0].KojiGyoshaNm) return false;

            // 設置者 フリガナ(8)
            if (hoshoTorokuSetchishaKanaTextBox.Text != _dispTable[0].HoshoTorokuSetchishaKana) return false;

            // 設置者 氏名(9)
            if (hoshoTorokuSetchishaNmTextBox.Text != _dispTable[0].HoshoTorokuSetchishaNm) return false;

            // 設置者 郵便番号(10)
            if (hoshoTorokuSetchishaZipCdTextBox.Text != _dispTable[0].HoshoTorokuSetchishaZipCd) return false;

            // 設置者 住所(12)
            if (hoshoTorokuSetchishaAdrTextBox.Text != _dispTable[0].HoshoTorokuSetchishaAdr) return false;

            // 建物 郵便番号(14)
            if (hoshoTorokuSetchibashoZipCdTextBox.Text != _dispTable[0].HoshoTorokuSetchibashoZipCd) return false;

            // 建物 住所(37)
            if (hoshoTorokuSetchibashoAdrTextBox.Text != _dispTable[0].HoshoTorokuSetchibashoAdr) return false;

            // 建物 建築用途(15)
            if (hoshoTorokuTatemonoyotoTextBox.Text != _dispTable[0].HoshoTorokuTatemonoyoto) return false;

            // 市町村 名称名(16)
            if (hoshoTorokuHojoShichosonNmTextBox.Text != _dispTable[0].ChikuNm) return false;

            // 浄化槽 登録番号(18)
            if (hoshoTorokuJokasoTorokuNoTextBox.Text != _dispTable[0].HoshoTorokuJokasoTorokuNo) return false;

            // 浄化槽 人槽(20)
            if (hoshoTorokuNinsoTextBox.Text != _dispTable[0].HoshoTorokuNinso) return false;

            // 製造業者 名称(21)
            if (seizoGyoshaNmTextBox.Text != _dispTable[0].MakerGyoshaNm) return false;

            // 検査機関 名称(23)
            if ((jimukyokuNmComboBox.SelectedValue == null && _dispTable[0].HoshoTorokuJokasoKensakikan.Trim() != string.Empty)
                || (jimukyokuNmComboBox.SelectedValue != null && jimukyokuNmComboBox.SelectedValue.ToString() != _dispTable[0].HoshoTorokuJokasoKensakikan)) return false;

            // 使用開始日(24)
            if (hoshoTorokuShiyokaishiDtDateTimePicker.Value.Date
                != Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].HoshoTorokuShiyokaishiDt) ? now : _dispTable[0].HoshoTorokuShiyokaishiDt).Date) return false;

            // 保健所受理番号２（保健所）(25)
            if (hoshoTorokuHokenjoCdTextBox.Text != _dispTable[0].HoshoTorokuHokenjoCd) return false;

            // 保健所受理番号１（年度）(26)
            // 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
            //string hokenjoDB = string.IsNullOrEmpty(_dispTable[0].HoshoTorokuHokenjoNendo) ? string.Empty : Common.Common.ConvertToHoshouNendoWareki(_dispTable[0].HoshoTorokuHokenjoNendo);
            //string hokenjoDB = string.IsNullOrEmpty(_dispTable[0].HoshoTorokuHokenjoNendo) ? string.Empty : Utility.Utility.ConvertToHeisei(Convert.ToInt32(_dispTable[0].HoshoTorokuHokenjoNendo));
            // 20140811 habu End
            string hokenjoDB = Utility.DateUtility.ConvertToWareki(_dispTable[0].HoshoTorokuHokenjoNendo, "yy");
            if (hoshoTorokuHokenjoNendoTextBox.Text != hokenjoDB) return false;

            // 保健所受理番号３（市町村）(27)
            if (hoshoTorokuHokenjoShichosonCdTextBox.Text != _dispTable[0].HoshoTorokuHokenjoShichosonCd) return false;

            // 保健所受理番号４（連番）(28)
            if (hoshoTorokuHokenjoRenbanTextBox.Text != _dispTable[0].HoshoTorokuHokenjoRenban) return false;

            // 保健所受付日(29)
            if (hoshoTorokuJyuriDtDateTimePicker.Value.Date
                != Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].HoshoTorokuJyuriDt) ? now : _dispTable[0].HoshoTorokuJyuriDt).Date) return false;

            // 登録確認年月日(30)
            if (hoshoTorokuTorokuKakuninDtDateTimePicker.Value.Date
                != Convert.ToDateTime(string.IsNullOrEmpty(_dispTable[0].HoshoTorokuTorokuKakuninDt) ? now : _dispTable[0].HoshoTorokuTorokuKakuninDt).Date) return false;

            // v1.04 ADD
            // 浄化槽 名称(24)
            if (jokasoKatashikiNmTextBox.Text != _dispTable[0].JokasoKatashikiNm) return false;
            // 浄化槽 登録日(25)
            DateTime jokasoTorokuDt;
            DateTime.TryParse(_dispTable[0].JokasoTorokuDt, out jokasoTorokuDt);
            if (jokasoTorokuDtDateTimePicker.Value.Date != jokasoTorokuDt.Date) return false;
            // 浄化槽 型式コード(30)
            if (katashikiCdTextBox.Text != _dispTable[0].KatashikiCd) return false;

            return true;
        }
        #endregion

        #region DataCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DataCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  AnhNV　　    新規作成
        /// 2015/01/29  AnhNV　　    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DataCheck()
        {
            // Error messages
            StringBuilder errMsg = new StringBuilder();
            
            // 工事業者名称(6)
            if (string.IsNullOrEmpty(kojiGyoshaNmTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：工事業者名称が選択されていません。\r\n");
            }

            // 設置者 フリガナ(8)
            if (string.IsNullOrEmpty(hoshoTorokuSetchishaKanaTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：設置者 フリガナが入力されていません。\r\n");
            }
            else if (hoshoTorokuSetchishaKanaTextBox.Text.Length > 60)
            {
                errMsg.Append("設置者 フリガナは60文字以下で入力して下さい。\r\n");
            }

            // 設置者 氏名(9)
            if (string.IsNullOrEmpty(hoshoTorokuSetchishaNmTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：設置者 氏名が入力されていません。\r\n");
            }
            else if (hoshoTorokuSetchishaNmTextBox.Text.Length > 30)
            {
                errMsg.Append("設置者 氏名は30文字以下で入力して下さい。\r\n");
            }

            // 設置者 郵便番号(10)
            if (string.IsNullOrEmpty(hoshoTorokuSetchishaZipCdTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：設置者 郵便番号が入力されていません。\r\n");
            }
            else if (hoshoTorokuSetchishaZipCdTextBox.Text.Length != 8)
            {
                errMsg.Append("設置者 郵便番号は8桁で入力して下さい。\r\n");
            }
            else if (!Utility.Utility.IsNumAndNegative(hoshoTorokuSetchishaZipCdTextBox.Text))
            {
                errMsg.Append("設置者 郵便番号は半角数字と-(半角ハイフン)で入力して下さい。\r\n");
            }
            else if (!Utility.Utility.IsZipCode(hoshoTorokuSetchishaZipCdTextBox.Text))
            {
                errMsg.Append("設置者 郵便番号の形式が不正です。\r\n");
            }

            // 設置者 住所(12)
            if (string.IsNullOrEmpty(hoshoTorokuSetchishaAdrTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：設置者 住所が入力されていません。\r\n");
            }
            else if (hoshoTorokuSetchishaAdrTextBox.Text.Length > 80)
            {
                errMsg.Append("設置者 住所は80文字以下で入力して下さい。\r\n");
            }

            // 建物 郵便番号(14)
            if (string.IsNullOrEmpty(hoshoTorokuSetchibashoZipCdTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：建物 郵便番号が入力されていません。\r\n");
            }
            else if (hoshoTorokuSetchibashoZipCdTextBox.Text.Length != 8)
            {
                errMsg.Append("建物 郵便番号は8桁で入力して下さい。\r\n");
            }
            else if (!Utility.Utility.IsNumAndNegative(hoshoTorokuSetchibashoZipCdTextBox.Text))
            {
                errMsg.Append("建物 郵便番号は半角数字と-(半角ハイフン)で入力して下さい。\r\n");
            }
            else if (!Utility.Utility.IsZipCode(hoshoTorokuSetchibashoZipCdTextBox.Text))
            {
                errMsg.Append("建物 郵便番号の形式が不正です。\r\n");
            }

            // 建物 住所(37)
            if (string.IsNullOrEmpty(hoshoTorokuSetchibashoAdrTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：建物 住所が入力されていません。\r\n");
            }
            else if (hoshoTorokuSetchibashoAdrTextBox.Text.Length > 80)
            {
                errMsg.Append("建物 住所は80文字以下で入力して下さい。\r\n");
            }

            // 建物 建築用途(15)
            if (string.IsNullOrEmpty(hoshoTorokuTatemonoyotoTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：建物 建築用途が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDecimal(hoshoTorokuTatemonoyotoTextBox.Text))
            {
                errMsg.Append("建物 建築用途は半角数字で入力して下さい。\r\n");
            }
            else if (hoshoTorokuTatemonoyotoTextBox.Text.Length != 3)
            {
                errMsg.Append("建物 建築用途は3桁で入力して下さい。\r\n");
            }

            // 市町村 名称(16)
            if (string.IsNullOrEmpty(hoshoTorokuHojoShichosonNmTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：市町村 名称が入力されていません。\r\n");
            }
            
            // 浄化槽 登録番号(18)
            if (string.IsNullOrEmpty(hoshoTorokuJokasoTorokuNoTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：浄化槽 登録番号が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDecimal(hoshoTorokuJokasoTorokuNoTextBox.Text))
            {
                errMsg.Append("浄化槽 登録番号は半角数字で入力して下さい。\r\n");
            }
            else if (hoshoTorokuJokasoTorokuNoTextBox.Text.Length != 7)
            {
                errMsg.Append("浄化槽 登録番号は7桁で入力して下さい。\r\n");
            }
            
            // 浄化槽 人槽(20)
            if (string.IsNullOrEmpty(hoshoTorokuNinsoTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：浄化槽 人槽が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDecimal(hoshoTorokuNinsoTextBox.Text))
            {
                errMsg.Append("浄化槽 人槽は半角数字で入力して下さい。\r\n");
            }
            else if (hoshoTorokuNinsoTextBox.Text.Length != 3)
            {
                errMsg.Append("浄化槽 人槽は3桁で入力して下さい。\r\n");
            }

            // 製造業者 名称(21)
            if (string.IsNullOrEmpty(seizoGyoshaNmTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：製造業者 名称が選択されていません。\r\n");
            }

            // 検査機関 名称(23)
            if (jimukyokuNmComboBox.SelectedIndex <= 0)
            {
                errMsg.Append("必須項目：検査機関 名称が選択されていません。\r\n");
            }

            // 保健所受理番号２（保健所）(25)
            if (string.IsNullOrEmpty(hoshoTorokuHokenjoCdTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：保健所受理番号２（保健所）が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDecimal(hoshoTorokuHokenjoCdTextBox.Text))
            {
                errMsg.Append("保健所受理番号２（保健所）は半角数字で入力して下さい。\r\n");
            }
            else if (hoshoTorokuHokenjoCdTextBox.Text.Length != 2)
            {
                errMsg.Append("保健所受理番号２（保健所）は2桁で入力して下さい。\r\n");
            }

            // 保健所受理番号１（年度）(26)
            if (string.IsNullOrEmpty(hoshoTorokuHokenjoNendoTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：保健所受理番号１（年度）が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDecimal(hoshoTorokuHokenjoNendoTextBox.Text))
            {
                errMsg.Append("保健所受理番号１（年度）は半角数字で入力して下さい。\r\n");
            }
            else if (hoshoTorokuHokenjoNendoTextBox.Text.Length != 2)
            {
                errMsg.Append("保健所受理番号１（年度）は2桁で入力して下さい。\r\n");
            }

            // 保健所受理番号３（市町村）(27)
            if (string.IsNullOrEmpty(hoshoTorokuHokenjoShichosonCdTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：保健所受理番号３（市町村）が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDecimal(hoshoTorokuHokenjoShichosonCdTextBox.Text))
            {
                errMsg.Append("保健所受理番号３（市町村）は半角数字で入力して下さい。\r\n");
            }
            else if (hoshoTorokuHokenjoShichosonCdTextBox.Text.Length != 3)
            {
                errMsg.Append("保健所受理番号３（市町村）は3桁で入力して下さい。\r\n");
            }

            // 保健所受理番号４（連番）(28)
            if (string.IsNullOrEmpty(hoshoTorokuHokenjoRenbanTextBox.Text.Trim()))
            {
                errMsg.Append("必須項目：保健所受理番号４（連番）が入力されていません。\r\n");
            }
            else if (!Utility.Utility.IsDecimal(hoshoTorokuHokenjoRenbanTextBox.Text))
            {
                errMsg.Append("保健所受理番号４（連番）は半角数字で入力して下さい。\r\n");
            }
            else if (hoshoTorokuHokenjoRenbanTextBox.Text.Length != 4)
            {
                errMsg.Append("保健所受理番号４（連番）は4桁で入力して下さい。\r\n");
            }

            // v1.04 ADD
            // 浄化槽 型式名称(31)
            if (string.IsNullOrEmpty(katashikiNmTextBox.Text))
            {
                errMsg.AppendLine("必須項目：型式名称が選択されていません。");
            }
            // End v1.04

            // Throw error messages
            if (!string.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }

            return true;
        }
        #endregion

        #region TextBoxTextChanged
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： TextBoxTextChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sourceTextBox"></param>
        /// <param name="targetTextBox"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private void TextBoxTextChanged(TextBox sourceTextBox, TextBox targetTextBox)
        //{
        //    string todofukenNm = string.Empty;
        //    string shichosonNm = string.Empty;
        //    string choikiNm = string.Empty;

        //    // Select address from YubinNoAdrMstDataSet
        //    foreach (YubinNoAdrMstDataSet.YubinNoAdrMstRow row in _yubinNoAdrMst.Select(
        //        string.Format("ZipCd = '{0}'", sourceTextBox.Text)))
        //    {
        //        todofukenNm = row.TodofukenNm;
        //        shichosonNm = row.ShikuchosonNm;
        //        choikiNm = row.ChoikiNm;
        //    }

        //    // Set result for target textbox
        //    targetTextBox.Text = string.Concat(todofukenNm, shichosonNm, choikiNm);
        //}
        #endregion

        #region CreateHoshoTorokuTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHoshoTorokuTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable CreateHoshoTorokuTblUpdate(HoshoTorokuTblDataSet.HoshoTorokuTblDataTable table)
        {
            // 工事業者(hidden)
            table[0].HoshoTorokuKojiGyosha = hoshoTorokuKojiGyoshaTextBox.Text;

            // 設置者名カナ(8)
            table[0].HoshoTorokuSetchishaKana = hoshoTorokuSetchishaKanaTextBox.Text;

            // 設置者名漢字(9)
            table[0].HoshoTorokuSetchishaNm = hoshoTorokuSetchishaNmTextBox.Text;

            // 設置者郵便番号(10)
            table[0].HoshoTorokuSetchishaZipCd = hoshoTorokuSetchishaZipCdTextBox.Text;

            // 保証登録住所(12)
            table[0].HoshoTorokuSetchishaAdr = hoshoTorokuSetchishaAdrTextBox.Text;

            // 設置場所(37)
            table[0].HoshoTorokuSetchibashoAdr = hoshoTorokuSetchibashoAdrTextBox.Text;

            // 郵便番号(14)
            table[0].HoshoTorokuSetchibashoZipCd = hoshoTorokuSetchibashoZipCdTextBox.Text;

            // 建物の用途(15)
            table[0].HoshoTorokuTatemonoyoto = hoshoTorokuTatemonoyotoTextBox.Text;

            // 補助市町村(16)
            table[0].HoshoTorokuHojoShichosonCd = hoshoTorokuHojoShichosonCdTextBox.Text;

            // 浄化槽登録番号(18)
            table[0].HoshoTorokuJokasoTorokuNo = hoshoTorokuJokasoTorokuNoTextBox.Text;

            // 人槽(20)
            table[0].HoshoTorokuNinso = hoshoTorokuNinsoTextBox.Text;

            // メーカー(hidden)
            table[0].HoshoTorokuMakerCd = hoshoTorokuMakerCdTextBox.Text;

            // 浄化槽検査機関(23)
            table[0].HoshoTorokuJokasoKensakikan = jimukyokuNmComboBox.SelectedValue == null ? string.Empty : jimukyokuNmComboBox.SelectedValue.ToString();

            // 使用開始日付(24)
            table[0].HoshoTorokuShiyokaishiDt = hoshoTorokuShiyokaishiDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 保健所受理番号２（保健所）(25)
            table[0].HoshoTorokuHokenjoCd = hoshoTorokuHokenjoCdTextBox.Text;

            // 保健所受理番号１（年度）(26)
            // 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
            //table[0].HoshoTorokuHokenjoNendo = Common.Common.ConvertToHoshouNendoSeireki(hoshoTorokuHokenjoNendoTextBox.Text);
            //table[0].HoshoTorokuHokenjoNendo = Utility.Utility.ConvertToSeireki(Convert.ToInt32(hoshoTorokuHokenjoNendoTextBox.Text));
            // 20140811 habu End
            table[0].HoshoTorokuHokenjoNendo = Utility.DateUtility.ConvertFromWareki(hoshoTorokuHokenjoNendoTextBox.Text, "yyyy");

            // 保健所受理番号３（市町村）(27)
            table[0].HoshoTorokuHokenjoShichosonCd = hoshoTorokuHokenjoShichosonCdTextBox.Text;

            // 保健所受理番号４（連番）(28)
            table[0].HoshoTorokuHokenjoRenban = hoshoTorokuHokenjoRenbanTextBox.Text;

            // 受理日付(29)
            table[0].HoshoTorokuJyuriDt = hoshoTorokuJyuriDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 登録確認日付(30)
            table[0].HoshoTorokuTorokuKakuninDt = hoshoTorokuTorokuKakuninDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 更新者
            table[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 更新端末
            table[0].UpdateTarm = Dns.GetHostName();

            return table;
        }
        #endregion

        #region CreateHoshoTorokuTblDelete
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHoshoTorokuTblDelete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable CreateHoshoTorokuTblDelete(HoshoTorokuTblDataSet.HoshoTorokuTblDataTable table)
        {
            // 取下日付(31)
            table[0].HoshoTorokuTorisageDt = hoshoTorokuTorisageDtDateTimePicker.Value.ToString("yyyyMMdd");

            // 削除フラグ
            table[0].HoshoTorokuDeleteFlg = "1";

            // 更新者
            table[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 更新端末
            table[0].UpdateTarm = Dns.GetHostName();

            return table;
        }
        #endregion

        #region TabStopControl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： TabStopControl
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void TabStopControl()
        {
            // 設置者 フリガナ(10)
            hoshoTorokuSetchishaKanaTextBox.TabStop = _dispMode == DispMode.Edit;
            // 設置者 氏名(11)
            hoshoTorokuSetchishaNmTextBox.TabStop = _dispMode == DispMode.Edit;
            // 設置者 郵便番号(12)
            hoshoTorokuSetchishaZipCdTextBox.TabStop = _dispMode == DispMode.Edit;
            // 設置者 住所(14)
            hoshoTorokuSetchishaAdrTextBox.TabStop = _dispMode == DispMode.Edit;
            // 建物 郵便番号(16)
            hoshoTorokuSetchibashoZipCdTextBox.TabStop = _dispMode == DispMode.Edit;
            // 建物 住所(17)
            hoshoTorokuSetchibashoAdrTextBox.TabStop = _dispMode == DispMode.Edit;
            // 建物 建築用途(18)
            hoshoTorokuTatemonoyotoTextBox.TabStop = _dispMode == DispMode.Edit;
            // 市町村 名称(19)
            //hoshoTorokuHojoShichosonNmTextBox.TabStop = _dispMode == DispMode.Edit;
            // 浄化槽 全浄協登録番号(23)
            hoshoTorokuJokasoTorokuNoTextBox.TabStop = _dispMode == DispMode.Edit;
            // 浄化槽 名称(24)
            jokasoKatashikiNmTextBox.TabStop = _dispMode == DispMode.Edit;
            // 浄化槽 人槽(26)
            hoshoTorokuNinsoTextBox.TabStop = _dispMode == DispMode.Edit;
            // 浄化槽 登録日(25)
            //jokasoTorokuDtDateTimePicker.TabStop = _dispMode == DispMode.Edit;
            // 製造業者 コード(27)
            hoshoTorokuMakerCdTextBox.TabStop = _dispMode == DispMode.Edit;
            // 浄化槽 型式コード(30)
            katashikiCdTextBox.TabStop = _dispMode == DispMode.Edit;
            // 使用開始日(34)
            hoshoTorokuShiyokaishiDtDateTimePicker.TabStop = _dispMode == DispMode.Edit;
            // 保健所受理番号２（保健所）(35)
            hoshoTorokuHokenjoCdTextBox.TabStop = _dispMode == DispMode.Edit;
            // 保健所受理番号１（年度）(36)
            hoshoTorokuHokenjoNendoTextBox.TabStop = _dispMode == DispMode.Edit;
            // 保健所受理番号３（市町村）(37)
            hoshoTorokuHokenjoShichosonCdTextBox.TabStop = _dispMode == DispMode.Edit;
            // 保健所受理番号４（連番）(38)
            hoshoTorokuHokenjoRenbanTextBox.TabStop = _dispMode == DispMode.Edit;
            // 保健所受付日(39)
            hoshoTorokuJyuriDtDateTimePicker.TabStop = _dispMode == DispMode.Edit;
            // 登録確認年月日(40)
            hoshoTorokuTorokuKakuninDtDateTimePicker.TabStop = _dispMode == DispMode.Edit;
            // 廃止年月日(41)
            hoshoTorokuTorisageDtDateTimePicker.TabStop = _dispMode == DispMode.Delete;
        }
        #endregion

        #region HoshoExistCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： HoshoExistCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20  AnhNV　　    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private bool HoshoExistCheck()
        //{
        //    string filter = string.Format("HoshoTorokuKensakikan <> '{0}' and HoshoTorokuNendo <> '{1}' and HoshoTorokuRenban <> '{2}' and HoshoTorokuJokasoTorokuNo = '{3}' and HoshoTorokuDeleteFlg = 0",
        //        _hoshoTorokuKensakikan, _hoshoTorokuNendo, _hoshoTorokuRenban, hoshoTorokuJokasoTorokuNoTextBox.Text);

        //    HoshoTorokuTblDataSet.HoshoTorokuTblRow[] hoshoRow = (HoshoTorokuTblDataSet.HoshoTorokuTblRow[])_hoshoTorokuTbl.Select(filter);

        //    // Exist?
        //    if (hoshoRow.Length > 0)
        //    {
        //        string msg = string.Format("入力された浄化槽登録番号は既に以下の保証登録番号で登録されています。\r\n浄化槽 登録番号:[{0}]",
        //            string.Concat(_hoshoTorokuKensakikan, "-", _hoshoTorokuNendo, "-", _hoshoTorokuRenban));

        //        MessageForm.Show2(MessageForm.DispModeType.Error, msg);
        //    }

        //    return true;
        //}
        #endregion

        #region JokasoExistCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： JokasoExistCheck
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20  AnhNV　　    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool JokasoExistCheck(out JokasoMstDataSet.JokasoMstRow jokasoRow)
        {
            bool result = false;

            JokasoMstDataSet.JokasoMstRow[] row = (JokasoMstDataSet.JokasoMstRow[])_jokasoMst.Select(
                string.Format("JokasoTorokuNo = '{0}'", hoshoTorokuJokasoTorokuNoTextBox.Text));

            if (row.Length > 0)
            {
                jokasoRow = row[0];
                result = true;
            }
            else
            {
                jokasoRow = null;
            }

            return result;
        }
        #endregion

        #region CreateJokasoMstInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateJokasoMstInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="systemDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20  AnhNV　　    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoMstDataSet.JokasoMstDataTable CreateJokasoMstInsert(DateTime systemDt)
        {
            JokasoMstDataSet.JokasoMstDataTable table = new JokasoMstDataSet.JokasoMstDataTable();
            JokasoMstDataSet.JokasoMstRow newRow = table.NewJokasoMstRow();

            // 浄化槽登録番号
            newRow.JokasoTorokuNo = hoshoTorokuJokasoTorokuNoTextBox.Text;
            // 浄化槽型式名称
            newRow.JokasoKatashikiNm = jokasoKatashikiNmTextBox.Text;
            // 浄化槽登録日
            newRow.JokasoTorokuDt = jokasoTorokuDtDateTimePicker.Value.ToString("yyyyMMdd");
            // 浄化槽メーカー業者コード
            newRow.JokasoMakerGyoshaCd = hoshoTorokuMakerCdTextBox.Text;
            // 浄化槽型式コード
            newRow.JokasoKatasikiCd = katashikiCdTextBox.Text;
            // 登録日時
            newRow.InsertDt = systemDt;
            // 登録者
            newRow.InsertUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 登録端末
            newRow.InsertTarm = Dns.GetHostName();
            // 更新日時
            newRow.UpdateDt = systemDt;
            // 更新者
            newRow.UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 更新端末
            newRow.UpdateTarm = Dns.GetHostName();

            table.AddJokasoMstRow(newRow);
            newRow.AcceptChanges();
            newRow.SetAdded();

            return table;
        }
        #endregion

        #region CreateJokasoMstUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateJokasoMstUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="systemDt"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/20  AnhNV　　    v1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoMstDataSet.JokasoMstDataTable CreateJokasoMstUpdate(JokasoMstDataSet.JokasoMstDataTable table, DateTime systemDt)
        {
            // 浄化槽型式名称
            table[0].JokasoKatashikiNm = jokasoKatashikiNmTextBox.Text;
            // 浄化槽登録日
            table[0].JokasoTorokuDt = jokasoTorokuDtDateTimePicker.Value.ToString("yyyyMMdd");
            // 浄化槽メーカー業者コード
            table[0].JokasoMakerGyoshaCd = hoshoTorokuMakerCdTextBox.Text;
            // 浄化槽型式コード
            table[0].JokasoKatasikiCd = katashikiCdTextBox.Text;
            // 更新日時
            table[0].UpdateDt = systemDt;
            // 更新者
            table[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 更新端末
            table[0].UpdateTarm = Dns.GetHostName();

            return table;
        }
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29  AnhNV　　    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            jokasoKatashikiNmTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_NAME, 20);
            hoshoTorokuMakerCdTextBox.SetControlDomain(ZControlDomain.ZT_GYOSHA_CD);
            katashikiCdTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 4);
        }
        #endregion

        #region KatashikiLeave
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KatashikiLeave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hoshoTorokuMakerCd"></param>
        /// <param name="katashikiCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29  AnhNV　　    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KatashikiLeave(string hoshoTorokuMakerCd, string katashikiCd)
        {
            if (null == _katashikiTable)
            {
                IKatashikiCdTextBoxLeaveALOutput alOutput = new KatashikiCdTextBoxLeaveApplicationLogic().Execute(new KatashikiCdTextBoxLeaveALInput());
                _katashikiTable = alOutput.KatashikiMstDataTable;
            }

            KatashikiMstDataSet.KatashikiMstRow[] dr = (KatashikiMstDataSet.KatashikiMstRow[])_katashikiTable.Select(
                string.Format("KatashikiMakerCd = '{0}' and KatashikiCd = '{1}'", hoshoTorokuMakerCd, katashikiCd));

            if (dr.Length > 0)
            {
                // 浄化槽 型式名称
                katashikiNmTextBox.Text = dr[0].KatashikiNm;
            }
            else
            {
                katashikiCdTextBox.Text = string.Empty;
                katashikiNmTextBox.Text = string.Empty;
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
