using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common.PrinterSetting;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrinterSettingForm
    /// <summary>
    /// プリンター設定ダイアログ
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16  豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class PrinterSettingForm : FukjBaseForm
    {
        #region フィールド（private)

        #region パラメータ

        /// <summary>
        /// クライアントIPアドレス
        /// </summary>
        private string _ipAddress;

        /// <summary>
        /// プリンタ設定
        /// </summary>
        private PrintSettingMstDataSet.PrintSettingMstDataTable _printSettingMst = new PrintSettingMstDataSet.PrintSettingMstDataTable();
                
        #endregion

        #endregion
        
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrinterSettingForm
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="ipAddress"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrinterSettingForm(string ipAddress)
        {
            InitializeComponent();

            _ipAddress = ipAddress;
        }
        #endregion

        #region イベント

        #region PrinterSettingForm_Load
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： PrinterSettingForm_Load
        /// <summary>
        /// フォームロード
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void PrinterSettingForm_Load(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // ＰＣにインストールされたプリンタ名をコンボボックスに設定
                foreach (string s in System.Drawing.Printing.PrinterSettings.InstalledPrinters)
                {
                    // 請求書専用紙
                    seikyushoComboBox.Items.Add(s);
                    // はがき／ＤＭ用
                    hagakiComboBox.Items.Add(s);
                    // 送付状専用
                    sofujoComboBox.Items.Add(s);
                    // 機能保証
                    kinoHoshoComboBox.Items.Add(s);
                }

                _printSettingMst.Clear();
                
                // データ取得
                IGetPrintSettingMstByIpAddressALInput alInput = new GetPrintSettingMstByIpAddressALInput();
                alInput.IpAddress = _ipAddress;

                IGetPrintSettingMstByIpAddressALOutput alOutput = new GetPrintSettingMstByIpAddressApplicationLogic().Execute(alInput);

                _printSettingMst.Merge(alOutput.PrintSettingMstDt);
                
                using (System.Drawing.Printing.PrintDocument pd = new System.Drawing.Printing.PrintDocument())
                {
                    //既定のプリンタ名の取得
                    string defaultPrinterName = pd.PrinterSettings.PrinterName;

                    // 請求書専用紙
                    PrintSettingMstDataSet.PrintSettingMstRow rowSeikyu = alOutput.PrintSettingMstDt.FindByIpAddressPrintKbn(_ipAddress, Constants.PrintKbn.PRINT_KBN_SEIKYUSHO);
                    seikyushoComboBox.SelectedItem = rowSeikyu != null ? rowSeikyu.PrinterName : defaultPrinterName;

                    // はがき／ＤＭ用
                    PrintSettingMstDataSet.PrintSettingMstRow rowHagaki = alOutput.PrintSettingMstDt.FindByIpAddressPrintKbn(_ipAddress, Constants.PrintKbn.PRINT_KBN_HAGAKI);
                    hagakiComboBox.SelectedItem = rowHagaki != null ? rowHagaki.PrinterName : defaultPrinterName;

                    // 送付状専用
                    PrintSettingMstDataSet.PrintSettingMstRow rowSofujo = alOutput.PrintSettingMstDt.FindByIpAddressPrintKbn(_ipAddress, Constants.PrintKbn.PRINT_KBN_SOFUJO);
                    sofujoComboBox.SelectedItem = rowSofujo != null ? rowSofujo.PrinterName : defaultPrinterName;

                    // 機能保証
                    PrintSettingMstDataSet.PrintSettingMstRow rowFutsu = alOutput.PrintSettingMstDt.FindByIpAddressPrintKbn(_ipAddress, Constants.PrintKbn.PRINT_KBN_KINOHOSHO);
                    kinoHoshoComboBox.SelectedItem = rowFutsu != null ? rowFutsu.PrinterName : defaultPrinterName;
                }
            }
            catch (Exception ex)
            {
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), ex.ToString());
                MessageForm.Show(MessageForm.DispModeType.Error, MessageResouce.MSGID_E00001, ex.Message);

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

        #region entryButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： entryButton_Click
        /// <summary>
        /// 追加ボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void entryButton_Click(object sender, EventArgs e)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());
            Cursor preCursor = Cursor.Current;

            try
            {
                Cursor.Current = Cursors.WaitCursor;

                // 請求書専用紙
                PrintSettingMstDataSet.PrintSettingMstRow rowSeikyu = _printSettingMst.FindByIpAddressPrintKbn(_ipAddress, Constants.PrintKbn.PRINT_KBN_SEIKYUSHO);
                if (rowSeikyu == null)
                {
                    PrintSettingMstDataSet.PrintSettingMstRow newRow = _printSettingMst.NewPrintSettingMstRow();

                    newRow.IpAddress = _ipAddress;
                    newRow.PrintKbn = Constants.PrintKbn.PRINT_KBN_SEIKYUSHO;
                    newRow.PrinterName = seikyushoComboBox.SelectedItem.ToString();
                    newRow.InsertDt = DateTime.Now;
                    newRow.InsertTarm = Dns.GetHostName();
                    newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newRow.UpdateDt = DateTime.Now;
                    newRow.UpdateTarm = Dns.GetHostName();
                    newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    _printSettingMst.AddPrintSettingMstRow(newRow);
                    newRow.AcceptChanges();
                    newRow.SetAdded();
                }
                else
                {
                    rowSeikyu.PrinterName = seikyushoComboBox.SelectedItem.ToString();
                    rowSeikyu.UpdateDt = DateTime.Now;
                    rowSeikyu.UpdateTarm = Dns.GetHostName();
                    rowSeikyu.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    rowSeikyu.AcceptChanges();
                    rowSeikyu.SetModified();
                }

                // はがき／ＤＭ用
                PrintSettingMstDataSet.PrintSettingMstRow rowHagaki = _printSettingMst.FindByIpAddressPrintKbn(_ipAddress, Constants.PrintKbn.PRINT_KBN_HAGAKI);
                if (rowHagaki == null)
                {
                    PrintSettingMstDataSet.PrintSettingMstRow newRow = _printSettingMst.NewPrintSettingMstRow();

                    newRow.IpAddress = _ipAddress;
                    newRow.PrintKbn = Constants.PrintKbn.PRINT_KBN_HAGAKI;
                    newRow.PrinterName = hagakiComboBox.SelectedItem.ToString();
                    newRow.InsertDt = DateTime.Now;
                    newRow.InsertTarm = Dns.GetHostName();
                    newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newRow.UpdateDt = DateTime.Now;
                    newRow.UpdateTarm = Dns.GetHostName();
                    newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    _printSettingMst.AddPrintSettingMstRow(newRow);
                    newRow.AcceptChanges();
                    newRow.SetAdded();
                }
                else
                {
                    rowHagaki.PrinterName = hagakiComboBox.SelectedItem.ToString();
                    rowHagaki.UpdateDt = DateTime.Now;
                    rowHagaki.UpdateTarm = Dns.GetHostName();
                    rowHagaki.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    rowHagaki.AcceptChanges();
                    rowHagaki.SetModified();
                }

                // 送付状専用
                PrintSettingMstDataSet.PrintSettingMstRow rowSofujo = _printSettingMst.FindByIpAddressPrintKbn(_ipAddress, Constants.PrintKbn.PRINT_KBN_SOFUJO);
                if (rowHagaki == null)
                {
                    PrintSettingMstDataSet.PrintSettingMstRow newRow = _printSettingMst.NewPrintSettingMstRow();

                    newRow.IpAddress = _ipAddress;
                    newRow.PrintKbn = Constants.PrintKbn.PRINT_KBN_SOFUJO;
                    newRow.PrinterName = sofujoComboBox.SelectedItem.ToString();
                    newRow.InsertDt = DateTime.Now;
                    newRow.InsertTarm = Dns.GetHostName();
                    newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newRow.UpdateDt = DateTime.Now;
                    newRow.UpdateTarm = Dns.GetHostName();
                    newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    _printSettingMst.AddPrintSettingMstRow(newRow);
                    newRow.AcceptChanges();
                    newRow.SetAdded();
                }
                else
                {
                    rowSofujo.PrinterName = sofujoComboBox.SelectedItem.ToString();
                    rowSofujo.UpdateDt = DateTime.Now;
                    rowSofujo.UpdateTarm = Dns.GetHostName();
                    rowSofujo.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    rowSofujo.AcceptChanges();
                    rowSofujo.SetModified();
                }

                // 機能保証
                PrintSettingMstDataSet.PrintSettingMstRow rowFutsu = _printSettingMst.FindByIpAddressPrintKbn(_ipAddress, Constants.PrintKbn.PRINT_KBN_KINOHOSHO);
                if (rowHagaki == null)
                {
                    PrintSettingMstDataSet.PrintSettingMstRow newRow = _printSettingMst.NewPrintSettingMstRow();

                    newRow.IpAddress = _ipAddress;
                    newRow.PrintKbn = Constants.PrintKbn.PRINT_KBN_KINOHOSHO;
                    newRow.PrinterName = kinoHoshoComboBox.SelectedItem.ToString();
                    newRow.InsertDt = DateTime.Now;
                    newRow.InsertTarm = Dns.GetHostName();
                    newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newRow.UpdateDt = DateTime.Now;
                    newRow.UpdateTarm = Dns.GetHostName();
                    newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    _printSettingMst.AddPrintSettingMstRow(newRow);
                    newRow.AcceptChanges();
                    newRow.SetAdded();
                }
                else
                {
                    rowFutsu.PrinterName = kinoHoshoComboBox.SelectedItem.ToString();
                    rowFutsu.UpdateDt = DateTime.Now;
                    rowFutsu.UpdateTarm = Dns.GetHostName();
                    rowFutsu.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    rowFutsu.AcceptChanges();
                    rowFutsu.SetModified();
                }

                IEntryBtnClickALInput alInput = new EntryBtnClickALInput();
                alInput.PrintSettingMstDT = _printSettingMst;

                // 更新実行
                new EntryBtnClickApplicationLogic().Execute(alInput);

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "プリンタ設定を保存しました。");

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

        #region closeButton_Click(object sender, EventArgs e)
        ////////////////////////////////////////////////////////////////////////////
        //  イベント名 ： closeButton_Click
        /// <summary>
        /// 閉じるボタン押下
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
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
        
    }
    #endregion
}
