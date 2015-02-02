using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KeiryoShomeiOutputList;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using Zynas.Control.Common;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.SuishitsuKensaKanri
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KeiryoShomeiOutputListForm
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class KeiryoShomeiOutputListForm : FukjBaseForm
    {
        #region プロパティ(private)

        /// <summary>
        /// 検索条件の表示・非表示フラグ(初期値：表示）
        /// </summary>
        private bool _searchShowFlg = true;
        private int _defaultSearchPanelTop = 0;
        private int _defaultSearchPanelHeight = 0;
        private int _defaultListPanelTop = 0;
        private int _defaultListPanelHeight = 0;
        ///// <summary>
        ///// ShishoMstDataTable
        ///// </summary>
        //private ShishoMstDataSet.ShishoMstDataTable _shishoMst = new ShishoMstDataSet.ShishoMstDataTable();
        /// <summary>
        /// KeiryoShomeiOutputListDataTable
        /// </summary>
        private KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable _keiryoShomeiOutputListDataTable = new KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable();
        /// <summary>
        /// KeiryoShomeiIraiTblDataTable
        /// </summary>
        private KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable _updateTbl = new KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable();

        /// <summary>
        /// DateTime Now
        /// </summary>
        private DateTime today = Common.Common.GetCurrentTimestamp();
        
        /// <summary>
        /// KeiryoShomeiBunsekiKekkashoFlg
        /// </summary>
        private int _keiryoBunsekiFlgCol = 0;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KeiryoShomeiOutputListForm
        /// <summary>
        /// コンストラクタ(終了時イベントなし)
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KeiryoShomeiOutputListForm()
        {
            InitializeComponent();
        }
        #endregion

        #region イベント

        #region KeiryoShomeiOutputListForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KeiryoShomeiOutputListForm_Load
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KeiryoShomeiOutputListForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // Default value for panel
                this._searchShowFlg = true;
                this._defaultSearchPanelTop = this.searchPanel.Top;
                this._defaultSearchPanelHeight = this.searchPanel.Height;
                this._defaultListPanelTop = this.outputPanel.Top;
                this._defaultListPanelHeight = this.outputPanel.Height;

                // Set ControlDomain
                SetControlDomain();
                // Excute load form
                DoLoadForm();
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

        #region ViewChangeButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： ViewChangeButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ViewChangeButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                this._searchShowFlg = !this._searchShowFlg;
                if (this._searchShowFlg) // 検索条件を開く
                {
                    this.viewChangeButton.Text = "▲";
                }
                else // 検索条件を閉じる
                {
                    this.viewChangeButton.Text = "▼";
                }
                Common.Common.SwitchSearchPanel(
                    this._searchShowFlg,
                    this.searchPanel,
                    this._defaultSearchPanelTop,
                    this._defaultSearchPanelHeight,
                    this.outputPanel,
                    this._defaultListPanelTop,
                    this._defaultListPanelHeight);
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
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void clearButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ClearForm();
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
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void kensakuButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                // Validate
                if (!ValidatorData())
                {
                    return;
                }
                // DoSearch
                DoSearch();
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

        #region torokuButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： torokuButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void printButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                string strServerFolder = String.Empty;
                string strLocalFolder = String.Empty;
                string strBackupFolder = String.Empty;

                // 20150131 sou Start 選択値の取得は印刷時ではなく検索時に行う
                //_keiryoBunsekiFlgCol = keiryoShomeiRadioButton.Checked ? 0 : 1;
                // 20150131 sou End

                if (tsujoRadioButton.Checked) // 25 was checked
                {
                    if (keiryoListDataGridView.RowCount <= 0)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "表示データがありません。");
                        return;
                    }
                }
                else // 26 was checked
                {
                    if (keiryoListDataGridView.RowCount <= 0)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "印刷できるデータがありません。");
                        return;
                    }
                    if (keiryoListDataGridView.SelectedRows == null)
                    {
                        MessageForm.Show2(MessageForm.DispModeType.Error, "対象データを選択して下さい。");
                        return;
                    }
                }
                if (String.IsNullOrEmpty(busuTextBox.Text)) // 27 is empty
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "部数を入力してください。");
                    return;
                }
                // 20150131 sou Start
                //if (bunssekiHokokuRadioButton.Checked) // 32 was checked
                if (_keiryoBunsekiFlgCol == 1)
                // 20150131 sou End
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "分析報告書を印刷します。よろしいですか？") == DialogResult.No)
                    {
                        return;
                    }
                }
                else // 31 was checked
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "計量証明書を印刷します。よろしいですか？") == DialogResult.No)
                    {
                        return;
                    }
                }

                if (_keiryoBunsekiFlgCol == 1) // Hidden value
                {
                    // Export 052
                    if (tsujoRadioButton.Checked) // 25 was checked processing 1 row
                    {
                        int index = keiryoListDataGridView.CurrentRow.Index;
                        IPrintBtnClickALInput alInput = new PrintBtnClickALInput();

                        alInput.Nendo = _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo;
                        alInput.Renban = _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban;
                        alInput.SishoCd = _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd;
                        alInput.PrintType = 2;
                        alInput.EdabanChecked = edabanCheckBox.Checked ? true : false;
                        alInput.UpdateDt = _keiryoShomeiOutputListDataTable[index].UpdateDt;
                        alInput.IsPlusCnt = senyoRadioButton.Checked && edabanCheckBox.Checked ? true : false;
                        alInput.PrintCnt = Int32.Parse(busuTextBox.Text);
                        if (senyoRadioButton.Checked) // 35 was checked (Checking server information)
                        {
                            //Excute 000_017 Reset server
                            Utility.SharedFolderUtility.Connect();
                            // Get information of server, backup, local using function 000_028
                            strServerFolder = Utility.SharedFolderUtility.GetKeiryoShomeiIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                       Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001,
                                                                                                       _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo,
                                                                                                       _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd,
                                                                                                       _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban);
                            strBackupFolder = Utility.SharedFolderUtility.GetKeiryoShomeiIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                       Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002,
                                                                                                       _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo,
                                                                                                       _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd,
                                                                                                       _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban);                           
                            strLocalFolder = Utility.SharedFolderUtility.GetConstLocalFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                            if (String.IsNullOrEmpty(strServerFolder) &&
                                String.IsNullOrEmpty(strBackupFolder) &&
                                String.IsNullOrEmpty(strLocalFolder))
                            {
                                MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが設定されていません。システム管理者に連絡してください。");
                                return;
                            }
                            // Create file name with format : KeiryoShomeiIraiNendo + "_" + KeiryoShomeiIraiSishoCd + "_" + KeiryoShomeiIraiRenban + ".pdf" 
                            string fileName = String.Concat(_keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo, "_",
                                                            _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd, "_",
                                                            _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban, ".pdf");
                            if (edabanCheckBox.Checked) // 24 was checked
                            {
                                if (File.Exists(Path.Combine(strServerFolder, fileName))) // file name is exists in server folder
                                {
                                    // Copy file to backup folder
                                    File.Copy(Path.Combine(strServerFolder, fileName), Path.Combine(strBackupFolder, fileName), true);
                                    // Delete file exist in server folder
                                    File.Delete(Path.Combine(strServerFolder, fileName));
                                    // Rename file name with format:  KeiryoShomeiIraiNendo + "_" + KeiryoShomeiIraiSishoCd + "_" + KeiryoShomeiIraiRenban + "_" + KeiryoShomeiShomeishoInsatsuCnt + ".pdf"

                                    fileName = String.Concat(_keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo, "_",
                                                             _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd, "_",
                                                             _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban, "_",
                                                             _keiryoShomeiOutputListDataTable[index].IsKeiryoShomeiShomeishoInsatsuCntNull() ?
                                                             String.Empty : _keiryoShomeiOutputListDataTable[index].KeiryoShomeiShomeishoInsatsuCnt.ToString(), ".pdf");
                                }
                            }
                            alInput.ConvertStatus = true;
                            alInput.FileNamePdf = fileName;
                            alInput.SavePath = strServerFolder;
                        }
                        // Excute                        
                        IPrintBtnClickALOutput alOutput = new PrintBtnClickApplicationLogic().Execute(alInput);
                        // Searh again
                        DoSearch();
                        if (alOutput.PrintErr)
                        {
                            MessageForm.Show2(MessageForm.DispModeType.Error, "証明書作成に失敗しました。システム管理者に連絡してください。");
                            return;
                        }
                        //Excute 000_018 Disconnect server
                        Utility.SharedFolderUtility.Disconnect();
                    }
                    else // processing all rows
                    {
                        // Export
                        //Excute 000_017 Reset server
                        if (senyoRadioButton.Checked)
                            Utility.SharedFolderUtility.Connect();
                        for (int i = 0; i < keiryoListDataGridView.RowCount; i++)
                        {
                            IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                            KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable printTbl = new KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable();
                            alInput.Nendo = _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo;
                            alInput.SishoCd = _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd;
                            alInput.Renban = _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban;
                            alInput.PrintType = 2;
                            alInput.EdabanChecked = edabanCheckBox.Checked ? true : false;
                            alInput.UpdateDt = _keiryoShomeiOutputListDataTable[i].UpdateDt;
                            alInput.IsPlusCnt = senyoRadioButton.Checked && edabanCheckBox.Checked ? true : false;
                            alInput.PrintCnt = Int32.Parse(busuTextBox.Text);
                            if (senyoRadioButton.Checked) // 35 was checked
                            {
                                // Get information of server, backup, local using function 000_028
                                strServerFolder = Utility.SharedFolderUtility.GetKeiryoShomeiIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                       Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001,
                                                                                                       _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo,
                                                                                                       _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd,
                                                                                                       _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban);
                                strBackupFolder = Utility.SharedFolderUtility.GetKeiryoShomeiIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                           Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002,
                                                                                                           _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo,
                                                                                                           _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd,
                                                                                                           _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban);                                
                                strLocalFolder = Utility.SharedFolderUtility.GetConstLocalFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                                if (String.IsNullOrEmpty(strServerFolder) &&
                                    String.IsNullOrEmpty(strBackupFolder) &&
                                    String.IsNullOrEmpty(strLocalFolder))
                                {
                                    MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが設定されていません。システム管理者に連絡してください。");
                                    return;
                                }

                                // Create file name with format : KeiryoShomeiIraiNendo + "_" + KeiryoShomeiIraiSishoCd + "_" + KeiryoShomeiIraiRenban + ".pdf" 
                                string fileName = String.Concat(_keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo, "_",
                                                                _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd, "_",
                                                                _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban, ".pdf");

                                if (edabanCheckBox.Checked) // 24 was checked
                                {
                                    if (File.Exists(Path.Combine(strServerFolder, fileName))) // file name is exists in server folder
                                    {
                                        // Copy file to backup folder
                                        File.Copy(Path.Combine(strServerFolder, fileName), Path.Combine(strBackupFolder, fileName), true);
                                        // Delete file exist in server folder
                                        File.Delete(Path.Combine(strServerFolder, fileName));
                                        // Rename file name with format:  KeiryoShomeiIraiNendo + "_" + KeiryoShomeiIraiSishoCd + "_" + KeiryoShomeiIraiRenban + "_" + KeiryoShomeiShomeishoInsatsuCnt + ".pdf"
                                        fileName = String.Concat(_keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo, "_",
                                                                 _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd, "_",
                                                                 _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban, "_",
                                                                 _keiryoShomeiOutputListDataTable[i].IsKeiryoShomeiShomeishoInsatsuCntNull() ?
                                                             String.Empty : _keiryoShomeiOutputListDataTable[i].KeiryoShomeiShomeishoInsatsuCnt.ToString(), ".pdf");
                                    }
                                }
                                // Set conver file = true
                                alInput.ConvertStatus = true;
                                alInput.FileNamePdf = fileName;
                                alInput.SavePath = strServerFolder;
                            }
                            IPrintBtnClickALOutput alOutput = new PrintBtnClickApplicationLogic().Execute(alInput);
                            // Searh again
                            DoSearch();
                            if (alOutput.PrintErr)
                            {
                                MessageForm.Show2(MessageForm.DispModeType.Error, "証明書作成に失敗しました。システム管理者に連絡してください。");
                                return;
                            }
                        }
                        //Excute 000_018 Disconect server
                        Utility.SharedFolderUtility.Disconnect();
                    }
                }
                else
                {
                    // Export 051
                    if (tsujoRadioButton.Checked) // 25 was checked processing 1 row
                    {
                        int index = keiryoListDataGridView.CurrentRow.Index;
                        IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                        KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable printTbl = new KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable();
                        alInput.Nendo = _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo;
                        alInput.SishoCd = _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd;
                        alInput.Renban = _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban;
                        alInput.PrintType = 1;
                        alInput.EdabanChecked = edabanCheckBox.Checked ? true : false;
                        alInput.UpdateDt = _keiryoShomeiOutputListDataTable[index].UpdateDt;
                        alInput.IsPlusCnt = senyoRadioButton.Checked && edabanCheckBox.Checked ? true : false;
                        alInput.PrintCnt = Int32.Parse(busuTextBox.Text);
                        if (senyoRadioButton.Checked) // 35 was checked
                        {
                            //Excute 000_017 Reset server
                            Utility.SharedFolderUtility.Connect();
                            // Get information of server, backup, local using function 000_028                            
                            strServerFolder = Utility.SharedFolderUtility.GetKeiryoShomeiIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                   Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001,
                                                                                                   _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo,
                                                                                                   _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd,
                                                                                                   _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban);
                            strBackupFolder = Utility.SharedFolderUtility.GetKeiryoShomeiIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                       Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002,
                                                                                                       _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo,
                                                                                                       _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd,
                                                                                                       _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban);                            
                            strLocalFolder = Utility.SharedFolderUtility.GetConstLocalFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                            if (String.IsNullOrEmpty(strServerFolder) &&
                                String.IsNullOrEmpty(strBackupFolder) &&
                                String.IsNullOrEmpty(strLocalFolder))
                            {
                                MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが設定されていません。システム管理者に連絡してください。");
                                return;
                            }


                            // Create file name with format : KeiryoShomeiIraiNendo + "_" + KeiryoShomeiIraiSishoCd + "_" + KeiryoShomeiIraiRenban + ".pdf" 
                            string fileName = String.Concat(_keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo, "_",
                                                                _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd, "_",
                                                                _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban, ".pdf");

                            if (edabanCheckBox.Checked) // 24 was checked
                            {
                                if (File.Exists(Path.Combine(strServerFolder, fileName))) // file name is exists in server folder
                                {
                                    // Copy file to backup folder
                                    File.Copy(Path.Combine(strServerFolder, fileName), Path.Combine(strBackupFolder, fileName), true);
                                    // Delete file exist in server folder
                                    File.Delete(Path.Combine(strServerFolder, fileName));
                                    // Rename file name with format:  KeiryoShomeiIraiNendo + "_" + KeiryoShomeiIraiSishoCd + "_" + KeiryoShomeiIraiRenban + "_" + KeiryoShomeiShomeishoInsatsuCnt + ".pdf"
                                    fileName = String.Concat(_keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiNendo, "_",
                                                             _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiSishoCd, "_",
                                                             _keiryoShomeiOutputListDataTable[index].KeiryoShomeiIraiRenban, "_",
                                                             _keiryoShomeiOutputListDataTable[index].IsKeiryoShomeiShomeishoInsatsuCntNull() ?
                                                             String.Empty : _keiryoShomeiOutputListDataTable[index].KeiryoShomeiShomeishoInsatsuCnt.ToString(), ".pdf");
                                }
                            }
                            // Set conver file = true
                            alInput.ConvertStatus = true;
                            alInput.FileNamePdf = fileName;
                            alInput.SavePath = strServerFolder;
                        }
                        IPrintBtnClickALOutput alOutput = new PrintBtnClickApplicationLogic().Execute(alInput);
                        // Searh again
                        DoSearch();
                        if (alOutput.PrintErr)
                        {
                            MessageForm.Show2(MessageForm.DispModeType.Error, "証明書作成に失敗しました。システム管理者に連絡してください。");
                            return;
                        }
                        //Excute 000_017 Reset server
                        Utility.SharedFolderUtility.Disconnect();
                    }
                    else // Processing all rows
                    {
                        //Excute 000_017 Reset server
                        if (senyoRadioButton.Checked)
                            Utility.SharedFolderUtility.Connect();
                        for (int i = 0; i < keiryoListDataGridView.RowCount; i++)
                        {
                            IPrintBtnClickALInput alInput = new PrintBtnClickALInput();
                            KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable printTbl = new KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable();
                            alInput.Nendo = _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo;
                            alInput.SishoCd = _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd;
                            alInput.Renban = _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban;
                            alInput.PrintType = 1;
                            alInput.EdabanChecked = edabanCheckBox.Checked ? true : false;
                            alInput.UpdateDt = _keiryoShomeiOutputListDataTable[i].UpdateDt;
                            alInput.IsPlusCnt = senyoRadioButton.Checked && edabanCheckBox.Checked ? true : false;
                            alInput.PrintCnt = Int32.Parse(busuTextBox.Text);
                            if (senyoRadioButton.Checked) // 35 was checked
                            {
                                // Get information of server, backup, local using function 000_028
                                strServerFolder = Utility.SharedFolderUtility.GetKeiryoShomeiIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                   Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001,
                                                                                                   _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo,
                                                                                                   _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd,
                                                                                                   _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban);
                                strBackupFolder = Utility.SharedFolderUtility.GetKeiryoShomeiIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                           Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002,
                                                                                                           _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo,
                                                                                                           _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd,
                                                                                                           _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban);                                
                                strLocalFolder = Utility.SharedFolderUtility.GetConstLocalFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_055,
                                                                                                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                                if (String.IsNullOrEmpty(strServerFolder) &&
                                    String.IsNullOrEmpty(strBackupFolder) &&
                                    String.IsNullOrEmpty(strLocalFolder))
                                {
                                    MessageForm.Show2(MessageForm.DispModeType.Error, "保存先フォルダが設定されていません。システム管理者に連絡してください。");
                                    return;
                                }


                                // Create file name with format : KeiryoShomeiIraiNendo + "_" + KeiryoShomeiIraiSishoCd + "_" + KeiryoShomeiIraiRenban + ".pdf" 
                                string fileName = String.Concat(_keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo, "_",
                                                                _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd, "_",
                                                                _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban, ".pdf");
                                if (edabanCheckBox.Checked) // 24 was checked
                                {
                                    if (File.Exists(Path.Combine(strServerFolder, fileName))) // file name is exists in server folder
                                    {
                                        // Copy file to backup folder
                                        File.Copy(Path.Combine(strServerFolder, fileName), Path.Combine(strBackupFolder, fileName), true);
                                        // Delete file exist in server folder
                                        File.Delete(Path.Combine(strServerFolder, fileName));
                                        // Rename file name with format:  KeiryoShomeiIraiNendo + "_" + KeiryoShomeiIraiSishoCd + "_" + KeiryoShomeiIraiRenban + "_" + KeiryoShomeiShomeishoInsatsuCnt + ".pdf"
                                        fileName = String.Concat(_keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiNendo, "_",
                                                                 _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiSishoCd, "_",
                                                                 _keiryoShomeiOutputListDataTable[i].KeiryoShomeiIraiRenban, "_",
                                                                 _keiryoShomeiOutputListDataTable[i].IsKeiryoShomeiShomeishoInsatsuCntNull() ?
                                                             String.Empty : _keiryoShomeiOutputListDataTable[i].KeiryoShomeiShomeishoInsatsuCnt.ToString(), ".pdf");
                                    }
                                }
                                // Set conver file = true
                                alInput.ConvertStatus = true;
                                alInput.FileNamePdf = fileName;
                                alInput.SavePath = strServerFolder;
                            }
                            IPrintBtnClickALOutput alOutput = new PrintBtnClickApplicationLogic().Execute(alInput);
                            // Searh again
                            DoSearch();
                            if (alOutput.PrintErr)
                            {
                                MessageForm.Show2(MessageForm.DispModeType.Error, "証明書作成に失敗しました。システム管理者に連絡してください。");
                                return;
                            }
                        }
                        //Excute 000_018 Disconect server
                        Utility.SharedFolderUtility.Disconnect();
                    }
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

        #region shosaiButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： shosaiButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void shosaiButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

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

        #region outputButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： outputButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void outputButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                String fileName = "計量証明出力";
                if (keiryoListDataGridView.RowCount > 0)
                    Common.Common.FlushGridviewDataToExcel(keiryoListDataGridView, fileName);
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

        #region tojiruButton_Click
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tojiruButton_Click
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tojiruButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
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

        #region suikenNoFromTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suikenNoFromTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suikenNoFromTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (suikenNoFromTextBox.Text.Length > 0 && suikenNoFromTextBox.Text.Length < 7)
                {
                    int lenght = suikenNoFromTextBox.Text.Length;
                    for (int i = 0; i < 6 - lenght; i++)
                    {
                        suikenNoFromTextBox.Text = "0" + suikenNoFromTextBox.Text;
                    }
                    suikenNoToTextBox.Text = suikenNoFromTextBox.Text;
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

        #region suikenNoToTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： suikenNoToTextBox_Leave
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void suikenNoToTextBox_Leave(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (suikenNoToTextBox.Text.Length > 0 && suikenNoToTextBox.Text.Length < 7)
                {
                    int lenght = suikenNoToTextBox.Text.Length;
                    for (int i = 0; i < 6 - lenght; i++)
                    {
                        suikenNoToTextBox.Text = "0" + suikenNoToTextBox.Text;
                    }
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

        #region uketsukeDtUseCheckBox_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uketsukeDtUseCheckBox_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uketsukeDtUseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (uketsukeDtUseCheckBox.Checked)
                {
                    uketsukeDtFromTextBox.Enabled = true;
                    uketsukeDtToTextBox.Enabled = true;
                }
                else
                {
                    uketsukeDtFromTextBox.Enabled = false;
                    uketsukeDtToTextBox.Enabled = false;
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

        #region bunsekiRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： bunsekiRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void bunsekiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                edabanCheckBox.Checked = false;
                edabanCheckBox.Enabled = false;
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

        #region tujoRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： tujoRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void tujoRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                edabanCheckBox.Checked = false;
                edabanCheckBox.Enabled = false;
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

        #region senyoshiRadioButton_CheckedChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： senyoshiRadioButton_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void senyoshiRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                edabanCheckBox.Enabled = true;                
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

        #region KeiryoShomeiOutputListForm_KeyDown
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： KeiryoShomeiOutputListForm_KeyDown
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KeiryoShomeiOutputListForm_KeyDown(object sender, KeyEventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (e.KeyData)
                {
                    case Keys.F1:
                        printButton.Focus();
                        printButton.PerformClick();
                        break;
                    case Keys.F6:
                        outputButton.Focus();
                        outputButton.PerformClick();
                        break;
                    case Keys.F7:
                        clearButton.Focus();
                        clearButton.PerformClick();
                        break;
                    case Keys.F8:
                        kensakuButton.Focus();
                        kensakuButton.PerformClick();
                        break;
                    case Keys.F12:
                        tojiruButton.Focus();
                        tojiruButton.PerformClick();
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

        #region uketsukeDtFromTextBox_ValueChanged
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： uketsukeDtFromTextBox_ValueChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <param name="sender"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　PhuongDT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void uketsukeDtFromTextBox_ValueChanged(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                uketsukeDtToTextBox.Value = uketsukeDtFromTextBox.Value;
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

        #region ClearForm
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： ClearForm
        /// <summary>
        /// Clear data
        /// </summary>        
        /// <history>        
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void ClearForm()
        {
            // 支所 (1)
            shishoComboBox.SelectedValue = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;
            // 年度 (2)
            int nendo = Utility.DateUtility.GetNendo(Boundary.Common.Common.GetCurrentTimestamp());
            nendoTextBox.Text = nendo.ToString();
            // 水検No (開始) (3)
            suikenNoFromTextBox.Clear();
            // 水検No (終了) (4)
            suikenNoToTextBox.Clear();
            // 設置者 (5)
            settishaTextBox.Clear();
            // 受付日検索使用フラグ (6)
            uketsukeDtUseCheckBox.Checked = false;
            // 受付日（開始）(7)
            DateTime startDate = new DateTime(today.Year, today.Month, 1);
            uketsukeDtFromTextBox.Value = startDate;
            // 受付日（終了）(8)
            uketsukeDtToTextBox.Value = startDate.AddMonths(1).AddDays(-1);
            // 帳票区分(11)(12)
            keiryoShomeiRadioButton.Checked = true;
        }
        #endregion

        #region SetControlDomain
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetControlDomain
        /// <summary>
        /// 
        /// </summary>        
        /// <history>        
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetControlDomain()
        {
            // 年度
            //nendoTextBox.SetControlDomain(ZControlDomain.ZT_NENDO);
            nendoTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 4, HorizontalAlignment.Left);    // （受入）暫定対応　ZT_NENDOが有効にならない
            // 水検No (開始)
            suikenNoFromTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 6);
            // 水検No (終了)
            suikenNoToTextBox.SetStdControlDomain(ZControlDomain.ZT_STD_CD, 6);
            // 設置者
            settishaTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NAME, 60);
            // 年度
            keiryoListDataGridView.SetStdControlDomain(0, ZControlDomain.ZT_STD_CD, 4);
            // 支所
            keiryoListDataGridView.SetStdControlDomain(1, ZControlDomain.ZG_STD_NAME, 10);
            // 水検No
            keiryoListDataGridView.SetStdControlDomain(2, ZControlDomain.ZG_STD_CD, 6);
            // 受付日
            keiryoListDataGridView.SetStdControlDomain(3, ZControlDomain.ZG_STD_NAME, 10);
            // 浄化槽番号
            keiryoListDataGridView.SetStdControlDomain(4, ZControlDomain.ZG_STD_NAME, 11);
            // 設置者名
            keiryoListDataGridView.SetStdControlDomain(5, ZControlDomain.ZG_STD_NAME, 60);
            // 部数
            busuTextBox.SetStdControlDomain(ZControlDomain.ZG_STD_NUM, 2);
        }
        #endregion

        #region DoLoadForm
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： DoLoadForm
        /// <summary>
        /// Excute load form
        /// </summary>        
        /// <history>        
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoLoadForm()
        {
            IFormLoadALInput alInput = new FormLoadALInput();
            //20150128 HuyTX Mod 課題対応 No279 支所コンボから事務局除外対応
            //_shishoMst = new FormLoadApplicationLogic().Execute(alInput).ShishoMstDataTable;
            //if (_shishoMst.Count > 0) Utility.Utility.SetComboBoxList(shishoComboBox, _shishoMst, "ShishoNm", "ShishoCd", true);
            Utility.Utility.SetComboBoxList(shishoComboBox, 
                                            new FormLoadApplicationLogic().Execute(alInput).ShishoMstExceptJimukyokuDataTable, 
                                            "ShishoNm", 
                                            "ShishoCd", 
                                            true);
            //End
            // Clear to default value
            ClearForm();
            // 計量証明一覧グリッドビュー
            keiryoListDataGridView.Rows.Clear();
            // 印刷区分/分析結果報告書
            //bunsekiRadioButton.Checked = true;
            // 枝番
            edabanCheckBox.Checked = false;
            edabanCheckBox.Enabled = false;
            // 印刷範囲/選択分
            tsujoRadioButton.Checked = true;
            // 部数
            busuTextBox.Text = "1";
        }
        #endregion

        #region DoSearch
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： DoSearch
        /// <summary>
        /// Excute search
        /// </summary>        
        /// <history>        
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoSearch()
        {
            // Clear data grid view
            keiryoListDataGridView.AutoGenerateColumns = false;
            _keiryoShomeiOutputListDataTable.Clear();
            // Get data
            IKensakuBtnClickALInput blInput = new KensakuBtnClickALInput();
            SetSearchConditions(ref blInput);
            _keiryoShomeiOutputListDataTable = new KensakuBtnClickApplicationLogic().Execute(blInput).KeiryoShomeiOutputListDataTable;
            keiryoListDataGridView.DataSource = _keiryoShomeiOutputListDataTable;
            keiryoShomeiListCountLabel.Text = _keiryoShomeiOutputListDataTable.Count + "件";
            if (_keiryoShomeiOutputListDataTable.Count <= 0)
            {
                MessageForm.Show2(MessageForm.DispModeType.Infomation, "表示データがありません。");
            }
            // 20150131 sou Start 選択値の取得は印刷時ではなく検索時に行う
            _keiryoBunsekiFlgCol = keiryoShomeiRadioButton.Checked ? 0 : 1;
            // 20150131 sou End
        }
        #endregion

        #region SetSearchConditions
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： SetSearchConditions
        /// <summary>
        /// Set search conditions
        /// </summary>        
        /// <history>        
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetSearchConditions(ref IKensakuBtnClickALInput input)
        {
            // 支所
            input.ShishoCd = shishoComboBox.SelectedValue.ToString();
            // 年度
            input.Nendo = nendoTextBox.Text;
            // 水検No(開始)
            if (!String.IsNullOrEmpty(suikenNoFromTextBox.Text))
            {
                input.SuikenNoFrom = suikenNoFromTextBox.Text;
            }
            // 水検No(終了)
            if (!String.IsNullOrEmpty(suikenNoToTextBox.Text))
            {
                input.SuikenNoTo = suikenNoToTextBox.Text;
            }
            // 設置者
            if (!String.IsNullOrEmpty(settishaTextBox.Text))
            {
                input.Settisha = settishaTextBox.Text;
            }
            // 受付日
            if (uketsukeDtUseCheckBox.Checked)
            {
                input.UketsukeDtFrom = uketsukeDtFromTextBox.Value.ToString("yyyyMMdd");
                input.UketsukeDtTo = uketsukeDtToTextBox.Value.ToString("yyyyMMdd");
            }
            // 計量証明分析報告書フラグ (隠し)
            input.ChouhyouKubunFlg = keiryoShomeiRadioButton.Checked ? "0" : "1";
            // 表示順
            input.DispOrder = uketsukeOrderRadioButton.Checked ? "0" : "1";
        }
        #endregion

        #region ValidatorData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド ： ValidatorData
        /// <summary>
        /// Check data is valid or not
        /// </summary>        
        /// <history>
        /// <returns>False is invalid otherwise True</returns>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool ValidatorData()
        {
            StringBuilder errMsg = new StringBuilder();
            // 水検No（開始＆終了）
            if (!String.IsNullOrEmpty(suikenNoFromTextBox.Text) && !String.IsNullOrEmpty(suikenNoToTextBox.Text))
            {
                //「水検No（開始）　>　水検No（終了）」の場合
                if (Int32.Parse(suikenNoFromTextBox.Text) > Int32.Parse(suikenNoToTextBox.Text))
                {
                    errMsg.Append("範囲指定が正しくありません。水検Noの大小関係を確認してください。 \r\n");
                }
            }
            // 受付日（開始＆終了）
            if (uketsukeDtUseCheckBox.Checked)
            {
                if (uketsukeDtFromTextBox.Value > uketsukeDtToTextBox.Value)
                {
                    errMsg.Append("範囲指定が正しくありません。受付日の大小関係を確認してください。\r\n");
                }
            }
            // 支所
            if (String.IsNullOrEmpty(shishoComboBox.Text))
            {
                errMsg.Append("支所を選択してください。\r\n");
            }
            // 年度
            if (String.IsNullOrEmpty(nendoTextBox.Text))
            {
                errMsg.Append("年度を入力してください。\r\n");
            }
            if (!String.IsNullOrEmpty(errMsg.ToString()))
            {
                MessageForm.Show2(MessageForm.DispModeType.Error, errMsg.ToString());
                return false;
            }
            return true;
        }
        #endregion

        #endregion
    }
    #endregion
}