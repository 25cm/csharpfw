using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.ApplicationLogic.Common;
using FukjBizSystem.Application.ApplicationLogic.Common.PrinterSetting;
using FukjBizSystem.Application.ApplicationLogic.Keiri.KaikeiRendoList;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.Master.BushoMstList;
using FukjBizSystem.Application.BusinessLogic.Master.ConstMst;
using FukjBizSystem.Application.BusinessLogic.Master.GyoshaMstShosai;
using FukjBizSystem.Application.BusinessLogic.Master.SaisuiinMstShosai;
using FukjBizSystem.Application.BusinessLogic.Master.ShishoMstShosai;
using FukjBizSystem.Application.DataAccess.ChikuMst;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl;
using FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl;
using FukjBizSystem.Application.DataAccess.NameMst;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.HoteiKensaRyokinMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.MaeukekinTblDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.ShokenKekkaTblDataSetTableAdapters;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Control;
using Zynas.Control;
using Zynas.Control.ZDataGridView;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.Boundary.Common
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Common
    /// <summary>
    /// 共通機能のユーティリティです
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2013/12/27　吉浦　　    新規作成
    /// 2014/11/29  小松        GetJokasoDaichoMstByJokasoSetchisha追加
    /// 2014/12/01  小松        CreateKensaIraiNoString追加
    /// 　　　　　　　　　　　　CreateKyokaiNoString追加
    /// 2014/12/02  小松        GetKensaDaicho11joHdrTblByKey追加
    /// 　　　　　　　　　　　　GetKensaDaicho9joHdrTblByKey追加
    /// 2014/12/03  小松        GetKensaIraiTblByKey追加
    /// 2014/12/08  小松        GetSaisuiinMstByKey追加
    ///                         GetJokasoDaichoMstByKey追加
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class Common
    {
        #region 定義(private)



        #endregion

        #region 静的メソッド(public)

        #region データグリッド初期化
        public static void initDgv(DataGridView dgv)
        {
            try
            {
                dgv.Rows.Clear();
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region allSelectDgv
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： allSelectDgv
        /// <summary>
        /// Check ON for checkbox column in gridview
        /// </summary>
        /// <param name="dgv">Specify datagridview</param>
        /// <param name="colName">Name of checkbox column</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/03/27　AnhNV　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static void allSelectDgv(DataGridView dgv, string colName)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[colName];
                    chk.Value = true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region allSelectClearDgv
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： allSelectClearDgv
        /// <summary>
        /// Check OFF for checkbox column in gridview
        /// </summary>
        /// <param name="dgv">Specify datagridview</param>
        /// <param name="colName">Name of checkbox column</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/03/27　AnhNV　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static void allSelectClearDgv(DataGridView dgv, string colName)
        {
            try
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[colName];
                    chk.Value = false;
                }
            }
            catch
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region DataGridExcelOutput
        public static bool DataGridViewExcelOutput(string title, DataGridView dg)
        {
            bool excelOutput = false;

            try
            {
                // 保存確認ダイアログの表示
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.FileName = title;
                dlg.Filter = "excel files (*.xls)|*.xls";
                dlg.FilterIndex = 1;

                // ＯＫボタンで終了した場合
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    #region Execl出力

                    // EXCEL起動
                    Excel.Application objExcel = null;
                    Excel.Workbook objWorkBook = null;
                    Excel.Worksheet objWorkSheet = null;
                    objExcel = new Excel.Application();
                    objWorkBook = objExcel.Workbooks.Add(
                        Excel.XlWBATemplate.xlWBATWorksheet);

                    // DataGridViewのセルのデータ取得
                    String[,] v = new String[
                        dg.Rows.Count, dg.Columns.Count];
                    for (int r = 0; r <= dg.Rows.Count - 1; r++)
                    {
                        for (int c = 0; c <= dg.Columns.Count - 1; c++)
                        {
                            String dt = "";
                            if (dg.Rows[r].Cells[c].Value != null)
                            {
                                dt = dg.Rows[r].Cells[c].Value.
                                    ToString();
                            }
                            v[r, c] = dt;
                        }
                    }

                    // EXCELにデータ転送
                    objWorkSheet = (Excel.Worksheet)objWorkBook.Sheets[1];
                    objWorkSheet.get_Range(
                        objWorkSheet.Cells[1, 1], objWorkSheet.Cells[
                        dg.Rows.Count, dg.Columns.Count]).Value2 = v;

                    // エクセル表示
                    objExcel.Visible = true;

                    // EXCEL解放
                    Marshal.ReleaseComObject(objWorkBook);
                    Marshal.ReleaseComObject(objExcel);
                    Marshal.ReleaseComObject(objWorkSheet);
                    objWorkSheet = null;
                    objWorkBook = null;
                    objExcel = null;

                    #endregion

                    excelOutput = true;
                }

            }
            catch
            {
                throw;
            }
            finally
            {
            }
            return excelOutput;
        }
        #endregion

        #region SendHanyoMail
        ///////////////////////////////////////////////////////////////
        /// メソッド：SendHanyoMail
        /// <summary>
        /// 汎用メール機能
        /// </summary>
        /// <param name="smtpServer">SMTPサーバ名</param>
        /// <param name="smtpPort">SMTPサーバポート</param>
        /// <param name="user">送信元アカウント</param>
        /// <param name="pass">送信元アカウントパス</param>
        /// <param name="fromMailAddress">送信元アドレス</param>
        /// <param name="toMailAddress">送信先アドレス</param>
        /// <param name="subject">メールタイトル</param>
        /// <param name="body">メール本文</param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2013/12/20　吉浦  　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static bool SendHanyoMail(string smtpServer,
                                            int smtpPort,
                                            string user,
                                            string pass,
                                            string fromMailAddress,
                                            string toMailAddress,
                                            string subject,
                                            string body)
        {
            bool sendMail = false;

            try
            {
                // 送信サーバーの設定
                System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient();
                smtp.Host = smtpServer;
                smtp.Port = smtpPort;

                // TODO: toyoda 認証が必要であれば・・・
                smtp.Credentials = new NetworkCredential(user, pass);

                MailMessage mail = new MailMessage(fromMailAddress,
                                                   toMailAddress,
                                                   subject,
                                                   body);

                // BCC
                mail.Bcc.Add(fromMailAddress);

                // 送信実行
                smtp.Send(mail);
                mail.Dispose();

                sendMail = true;
            }
            catch (Exception e)
            {
                // ログ出力
                TraceLog.FatalWrite(MethodInfo.GetCurrentMethod(), e.ToString());

                // 例外をスロー
                throw new CustomException(ResultCode.OtherError, 0, "メールの送信に失敗しました。");
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return sendMail;
        }
        #endregion

        #region ExportCSVFromDataGridView
        ///////////////////////////////////////////////////////////////
        /// メソッド：ExportCSVFromDataGridView
        /// <summary>
        /// ExportCSVFromDataTable
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="gridViewInput"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/02/27　CuongNT  　   新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string ExportCSVFromDataGridView(string fileName, DataGridView gridViewInput)
        {
            string messageError = "";

            StringBuilder dataTable = new StringBuilder();

            var headerCol = from DataGridViewColumn col in gridViewInput.Columns
                            where col.Visible == true
                            select col.HeaderText;

            dataTable.AppendLine(string.Join(",", headerCol.ToArray()));

            foreach (DataGridViewRow row in gridViewInput.Rows)
            {
                var data = from DataGridViewCell cell in row.Cells
                           where cell.Visible == true
                           select cell.Value;
                var arrayData = data.ToArray();

                var arrayDataString = from object item in arrayData
                                      select (item == null ? "" : item.ToString());

                dataTable.AppendLine(string.Join(",", arrayDataString.ToArray()));
            }

            // export file 
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.FileName = fileName;
            ofd.Filter = "CSV (*.csv)|*.csv";
            DialogResult dr = ofd.ShowDialog();
            string filename = "";
            if (dr == DialogResult.OK)
            {
                filename = ofd.FileName;
                try
                {
                    using (var sw = new StreamWriter(filename, false, Encoding.UTF8))
                    {
                        sw.Write(dataTable.ToString());
                    }
                }
                catch (Exception e)
                {
                    messageError = e.Message.ToString();
                }
            }

            return messageError;
        }
        #endregion

        #region ExportCSVFromSelectedRowsDataGridView
        ///////////////////////////////////////////////////////////////
        /// メソッド：ExportCSVFromSelectedRowsDataGridView
        /// <summary>
        /// ExportCSVFromSelectedRowsDataGridView
        /// </summary>
        /// <param name="fileName">file name</param>
        /// <param name="checkBoxColNm">Name of checkbox column</param>
        /// <param name="gridViewInput"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/03/26　AnhNV  　   新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string ExportCSVFromSelectedRowsDataGridView(string fileName, string checkBoxColNm, DataGridView gridViewInput)
        {
            string messageError = "";

            StringBuilder dataTable = new StringBuilder();

            // Remove invisible columns
            var headerCol = from DataGridViewColumn col in gridViewInput.Columns
                            where col.Visible == true
                            select col.HeaderText;

            dataTable.AppendLine(string.Join(",", headerCol.ToArray()));

            foreach (DataGridViewRow row in gridViewInput.Rows)
            {
                // Skip rows without checked
                if ((bool)row.Cells[checkBoxColNm].FormattedValue == false) continue;
                // Get row datas
                var data = from DataGridViewCell cell in row.Cells
                           where cell.Visible == true
                           select cell.Value;

                var arrayData = data.ToArray();

                var arrayDataString = from object item in arrayData
                                      select (item == null ? "" : item.ToString());

                dataTable.AppendLine(string.Join(",", arrayDataString.ToArray()));
            }

            // export file 
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.FileName = fileName;
            ofd.Filter = "CSV (*.csv)|*.csv";
            DialogResult dr = ofd.ShowDialog();
            string filename = "";
            if (dr == DialogResult.OK)
            {
                filename = ofd.FileName;
                try
                {
                    using (var sw = new StreamWriter(filename, false, Encoding.UTF8))
                    {
                        sw.Write(dataTable.ToString());
                    }
                }
                catch (Exception e)
                {
                    messageError = e.Message.ToString();
                }
            }

            return messageError;
        }
        #endregion

        #region ChildControlEnableChange
        ///////////////////////////////////////////////////////////////
        /// メソッド：ChildControlEnableChange
        /// <summary>
        /// 子コントロールの一括活性制御
        /// </summary>
        /// <param name="ctl">親コントロール</param>
        /// <param name="enable">活性状態</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/06　和田  　 新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static void ChildControlEnableChange(System.Windows.Forms.Control ctl, bool enable)
        {
            foreach (System.Windows.Forms.Control childCtl in ctl.Controls)
            {
                // Zテキスト
                if (childCtl is ZTextBox)
                {
                    ((ZTextBox)childCtl).CustomReadOnly = !enable;
                }
                // NumberTextBox
                else if (childCtl is NumberTextBox)
                {
                    ((NumberTextBox)childCtl).ReadOnly = !enable;
                }
                // ZDate
                else if (childCtl is ZDate)
                {
                    ((ZDate)childCtl).Enabled = enable;
                }
                // ZDataGridView
                else if (childCtl is ZDataGridView)
                {
                    ((ZDataGridView)childCtl).Enabled = enable;
                }
                // ZButton
                else if (childCtl is ZButton)
                {
                    ((ZButton)childCtl).Enabled = enable;
                }
                // ラジオボタン
                else if (childCtl is RadioButton)
                {
                    ((RadioButton)childCtl).Enabled = enable;
                }
                // コンボボックス
                else if (childCtl is ComboBox)
                {
                    ((ComboBox)childCtl).Enabled = enable;
                }

                // 自コントロールの子コントロールの活性制御
                ChildControlEnableChange(childCtl, enable);
            }
        }
        #endregion

        #region ShokuinMst

        //#region GetShokuinMstByShokuinCd
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="shokuinCd"></param>
        ///// <returns></returns>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/10/24　habu　　    新規作成
        ///// </history>
        //public static ShokuinMstDataSet.ShokuinMstDataTable GetShokuinMstByShokuinCd(string shokuinCd)
        //{
        //    ShokuinMstDataSet.ShokuinMstDataTable template = new ShokuinMstDataSet.ShokuinMstDataTable();

        //    IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
        //    input.DataTableType = typeof(ShokuinMstDataSet.ShokuinMstDataTable);
        //    input.TableAdapterType = typeof(ShokuinMstTableAdapter);

        //    if (!string.IsNullOrEmpty(shokuinCd)) { input.Query.AddEqualCond(template.ShokuinCdColumn.ColumnName, shokuinCd); }

        //    IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

        //    return (ShokuinMstDataSet.ShokuinMstDataTable)output.GetDataTable;
        //}
        //#endregion

        //#region GetShokuinMstByShishoCd
        ///// <summary>
        ///// 対象支所の職員を印字順で取得する
        ///// (Get By ShishiCd , Order by InjiJun)
        ///// </summary>
        ///// <param name="shishoCd"></param>
        ///// <returns></returns>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/10/26　habu　　    新規作成
        ///// </history>
        //public static ShokuinMstDataSet.ShokuinMstDataTable GetShokuinMstByShishoCd(string shishoCd)
        //{
        //    ShokuinMstDataSet.ShokuinMstDataTable template = new ShokuinMstDataSet.ShokuinMstDataTable();

        //    IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
        //    input.DataTableType = typeof(ShokuinMstDataSet.ShokuinMstDataTable);
        //    input.TableAdapterType = typeof(ShokuinMstTableAdapter);

        //    if (!string.IsNullOrEmpty(shishoCd)) { input.Query.AddEqualCond(template.ShokuinShozokuShishoCdColumn.ColumnName, shishoCd); }

        //    input.Query.AddOrderCol(template.ShokuinInjiJunColumn.ColumnName);
        //    input.Query.AddOrderCol(template.ShokuinCdColumn.ColumnName);

        //    IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

        //    return (ShokuinMstDataSet.ShokuinMstDataTable)output.GetDataTable;
        //}
        //#endregion

        #region GetShokuinMstByShokuinCdShokuinPassword
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetShokuinMstByShokuinCdShokuinPassword
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shokuinCd">ログインID</param>
        /// <param name="shokuinPassword">ログインパスワード</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/19　DatNT　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static ShokuinMstDataSet.ShokuinMstDataTable GetShokuinMstByShokuinCdShokuinPassword(
            string shokuinCd,
            string shokuinPassword)
        {
            ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDT = null;

            try
            {
                IGetShokuinMstByShokuinCdShokuinPasswordALInput alInput = new GetShokuinMstByShokuinCdShokuinPasswordALInput();
                alInput.ShokuinCd = shokuinCd;
                alInput.ShokuinPassword = shokuinPassword;
                IGetShokuinMstByShokuinCdShokuinPasswordALOutput output = new GetShokuinMstByShokuinCdShokuinPasswordApplicationLogic().Execute(alInput);

                ShokuinMstDT = output.ShokuinMstDT;

            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return ShokuinMstDT;
        }
        #endregion

        #endregion

        #region GetCurrentTimestamp
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetCurrentTimestamp
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Server date time</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20　DatNT　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static DateTime GetCurrentTimestamp()
        {
            DateTime currentTime = DateTime.Now;

            try
            {
                IGetCurrentTimestampALInput alInput = new GetCurrentTimestampALInput();
                IGetCurrentTimestampALOutput alOutput = new GetCurrentTimestampApplicationLogic().Execute(alInput);

                currentTime = alOutput.CurrentTimestamp;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return currentTime;
        }
        #endregion

        #region SwitchSearchPanel
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： SwitchSearchPanel
        /// <summary>
        ///  検索条件パネルの表示・非表示の切り替え
        /// </summary>
        /// <param name="switchFlg">TRUE：表示　FALSE:非表示</param>
        /// <param name="searchPanel">検索条件パネル</param>
        /// <param name="defSearchPanelTop">検索条件パネルTOP（初期値）</param>
        /// <param name="defSearchPanelHeight">検索条件パネルHEIGHT（初期値）</param>
        /// <param name="listPanel">検索結果リストパネル</param>
        /// <param name="defSearchPanelTop">検索結果リストパネルTOP（初期値）</param>
        /// <param name="defSearchPanelHeight">検索結果リストパネルHEIGHT（初期値）</param>
        /// <param name="colNo">Index of checkbox column</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　YS.CHEW　　 新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static void SwitchSearchPanel(
            bool switchFlg,
            Panel searchPanel,
            int defSearchPanelTop,
            int defSearchPanelHeight,
            Panel listPanel,
            int defListPanelTop,
            int defListPanelHeight
            )
        {
            try
            {
                if (switchFlg)//検索条件を開く
                {
                    searchPanel.Top = defSearchPanelTop;
                    searchPanel.Height = defSearchPanelHeight;
                    listPanel.Top = defListPanelTop;
                    listPanel.Height = defListPanelHeight;
                }
                else////検索条件を閉じる
                {
                    searchPanel.Height = 30;
                    listPanel.Top = searchPanel.Top + searchPanel.Height;
                    listPanel.Height += (defSearchPanelHeight - searchPanel.Height);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region FlushGridviewDataToExcel
        #region releaseObject
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： releaseObject
        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void releaseObject(object obj)
        {
            try
            {
                if (null == obj) return;

                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        ///////////////////////////////////////////////////////////////
        //メソッド名 ： FlushGridviewDataToExcel
        /// <summary>
        ///  指定GridviewのデータをExcelに出力する
        /// </summary>
        /// <param name="targetDataGridView">対象DataGridView</param>
        /// <returns>true:OK/false:cancel</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　YS.CHEW　　 新規作成
        /// 2014/12/04　HuyTX　　 Add case for DataGridViewComboBoxCell
        /// 2014/12/09　小松        OK/CANCELを返すように修正（完了時は完了メッセージを出したいので）
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static bool FlushGridviewDataToExcel(
            DataGridView targetDataGridView,
            string outputFilename

            )
        {
            bool result = false;

            Microsoft.Office.Interop.Excel.Application xlApp = null;
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = null;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = null;

            try
            {
                // 保存確認ダイアログの表示
                SaveFileDialog dlg = new SaveFileDialog();

                dlg.FileName = outputFilename + "_" + Common.GetCurrentTimestamp().ToString("yyyyMMddHHmmss");
                dlg.Filter = "Excel files (*.xls)|*.xls";
                dlg.FilterIndex = 1;

                // ＯＫボタンで終了した場合
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    object misValue = System.Reflection.Missing.Value;

                    xlApp = new Microsoft.Office.Interop.Excel.ApplicationClass();
                    xlWorkBook = xlApp.Workbooks.Add(misValue);
                    xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                    int i = 0;
                    int j = 0;

                    int rowIdx = 0;
                    int colIdx = 0;

                    for (i = 0; i <= targetDataGridView.RowCount - 1; i++)
                    {
                        rowIdx = i;
                        colIdx = 0;
                        for (j = 0; j <= targetDataGridView.ColumnCount - 1; j++)
                        {
                            // Skip hidden columns
                            if (!targetDataGridView.Columns[j].Visible) continue;

                            DataGridViewCell cell = targetDataGridView[j, i];

                            if (i == 0)
                            {
                                DataGridViewHeaderCell h = targetDataGridView.Columns[j].HeaderCell;
                                //                                xlWorkSheet.Cells[i + 1, j + 1] = h.Value;
                                xlWorkSheet.Cells[rowIdx + 1, colIdx + 1] = h.Value;
                            }

                            //ADD_20141204_HuyTX 
                            if (cell.GetType() == typeof(DataGridViewComboBoxCell))
                            {
                                xlWorkSheet.Cells[rowIdx + 2, colIdx + 1] = Convert.ToString(cell.FormattedValue.ToString());
                                Excel.Range rng = (Excel.Range)xlWorkSheet.Cells[rowIdx + 2, colIdx + 1];
                                colIdx++; continue;
                            }
                            //End

                            // Code & No columns format
                            if (targetDataGridView.Columns[j].Name.Length > 5
                                && (targetDataGridView.Columns[j].Name.Substring(targetDataGridView.Columns[j].Name.Length - 5) == "CdCol"
                                || targetDataGridView.Columns[j].Name.Substring(targetDataGridView.Columns[j].Name.Length - 5) == "NoCol"))
                            {
                                //                                xlWorkSheet.Cells[i + 2, j + 1] = "'" + cell.Value;
                                xlWorkSheet.Cells[rowIdx + 2, colIdx + 1] = "'" + cell.Value;
                                //                                Excel.Range rng = (Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                                Excel.Range rng = (Excel.Range)xlWorkSheet.Cells[rowIdx + 2, colIdx + 1];
                                //rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;

                                //continue;
                            }
                            else if (targetDataGridView.Columns[j].Name.Length > 5
                               && targetDataGridView.Columns[j].Name.Substring(targetDataGridView.Columns[j].Name.Length - 5) == "DtCol")
                            {
                                // Date columns format
                                //                                xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                                Excel.Range rng = (Excel.Range)xlWorkSheet.Cells[rowIdx + 2, colIdx + 1];
                                rng.EntireColumn.NumberFormat = "yyyy/MM/dd";
                                rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignRight;
                                xlWorkSheet.Cells[rowIdx + 2, colIdx + 1] = "'" + cell.Value;
                                //continue;
                            }
                            else
                            {
                                //                                xlWorkSheet.Cells[i + 2, j + 1] = cell.Value;
                                xlWorkSheet.Cells[rowIdx + 2, colIdx + 1] = cell.Value;
                            }

                            if (targetDataGridView.Columns[j].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleCenter)
                            {
                                //                                Excel.Range rng = (Excel.Range)xlWorkSheet.Cells[i + 2, j + 1];
                                Excel.Range rng = (Excel.Range)xlWorkSheet.Cells[rowIdx + 2, colIdx + 1];
                                rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                            }
                            else if (targetDataGridView.Columns[j].DefaultCellStyle.Alignment == DataGridViewContentAlignment.MiddleLeft
                                || targetDataGridView.Columns[j].DefaultCellStyle.Alignment == DataGridViewContentAlignment.NotSet)
                            {
                                //                                xlWorkSheet.Cells[i + 2, j + 1] = "'" + cell.Value;
                                xlWorkSheet.Cells[rowIdx + 2, colIdx + 1] = "'" + cell.Value;
                            }

                            colIdx++;
                        }
                    }

                    xlWorkBook.SaveAs(dlg.FileName,
                                        Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                                        misValue,
                                        misValue,
                                        misValue,
                                        misValue,
                                        Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
                                        misValue,
                                        misValue,
                                        misValue,
                                        misValue,
                                        misValue);
                    xlWorkBook.Close(true, misValue, misValue);
                    xlApp.Quit();

                    result = true;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            return result;
        }
        #endregion

        #region SetGyoshaNmByCd
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetGyoshaNmByCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd">業者コード</param>
        /// <param name="gyoshaCdTextBox">業者コードコントロール</param>
        /// <param name="gyoshaNmTextBox">業者名称コントロール</param>
        /// <param name="resetGyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  HuyTX　　　新規作成
        /// 2014/11/27  HuyTX　　　add param resetGyoshaCd(true/false)
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static void SetGyoshaNmByCd(string gyoshaCd, TextBox gyoshaCdTextBox, TextBox gyoshaNmTextBox, bool resetGyoshaCd = true)
        {
            try
            {
                if (string.IsNullOrEmpty(gyoshaCd)) return;

                IGetGyoshaMstByKeyBLInput blInput = new GetGyoshaMstByKeyBLInput();
                blInput.GyoshaCd = gyoshaCd;

                IGetGyoshaMstByKeyBLOutput blOutput = new GetGyoshaMstByKeyBusinessLogic().Execute(blInput);

                if (blOutput.GyoshaMstDataTable.Count == 0)
                {
                    if (resetGyoshaCd)
                    {
                        gyoshaCdTextBox.Text = string.Empty;
                    }
                    gyoshaNmTextBox.Text = string.Empty;
                }
                else
                {
                    gyoshaCdTextBox.Text = blOutput.GyoshaMstDataTable[0].GyoshaCd;
                    gyoshaNmTextBox.Text = blOutput.GyoshaMstDataTable[0].GyoshaNm;
                }
            }
            catch
            {
                throw;
            }

        }
        #endregion

        #region ConstMst

        #region GetConstValue
        /// <summary>
        /// get const value by kbn , renban
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07  habu　　    新規作成
        /// </history>
        public static string GetConstValue(string constKbn, string constRenban)
        {
            string value = string.Empty;

            IGetConstMstByKeyBLInput input = new GetConstMstByKeyBLInput();
            input.ConstKbn = constKbn;
            input.ConstRenban = constRenban;

            IGetConstMstByKeyBLOutput output = new GetConstMstByKeyBusinessLogic().Execute(input);

            if (output.DataTable.Count > 0)
            {
                value = output.DataTable[0].ConstValue;
            }

            return value;
        }
        #endregion

        #region GetConstNm
        /// <summary>
        /// get const nm by kbn , renban
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06  DatNT　　    新規作成
        /// </history>
        public static string GetConstNm(string constKbn, string constRenban)
        {
            string nm = string.Empty;

            IGetConstMstByKeyBLInput input = new GetConstMstByKeyBLInput();
            input.ConstKbn = constKbn;
            input.ConstRenban = constRenban;

            IGetConstMstByKeyBLOutput output = new GetConstMstByKeyBusinessLogic().Execute(input);

            if (output.DataTable.Count > 0)
            {
                nm = output.DataTable[0].ConstNm;
            }

            return nm;
        }
        #endregion

        #region GetConstTable
        /// <summary>
        /// get const value by kbn , renban
        /// </summary>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07  habu　　    新規作成
        /// </history>
        public static DataTable GetConstTable(string constKbn)
        {
            ConstMstDataSet.ConstMstDataTable table;

            IGetConstMstByKbnBLInput input = new GetConstMstByKbnBLInput();
            input.ConstKbn = constKbn;
            IGetConstMstByKbnBLOutput output = new GetConstMstByKbnBusinessLogic().Execute(input);

            table = output.DataTable;

            return table;
        }
        #endregion

        #region GetConstNmByKbnValue
        /// <summary>
        /// get const value by kbn , value
        /// </summary>
        /// <param name="constKbn"></param>
        /// <param name="constValue"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/02  DatNT    新規作成
        /// </history>
        public static string GetConstNmByKbnValue(string constKbn, string constValue)
        {
            string constNm = string.Empty;

            IGetConstMstByKbnValueBLInput input = new GetConstMstByKbnValueBLInput();
            input.ConstKbn = constKbn;
            input.ConstValue = constValue;
            IGetConstMstByKbnValueBLOutput output = new GetConstMstByKbnValueBusinessLogic().Execute(input);

            if (output.ConstMstDT.Count > 0)
            {
                constNm = output.ConstMstDT[0].ConstNm;
            }

            return constNm;
        }
        #endregion

        #endregion

        #region 保証番号年度変換処理(HoshouTorokuNendo Conversion)

        /// <summary>
        /// 西暦年度を和暦年度(平成)に変換
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 元号は常に平成とする
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07  habu　　    新規作成
        /// 2014/12/18  habu　　    年度のパディングを追加(平成1桁の場合に必要)
        /// </history>
        public static string ConvertToHoshouNendoWareki(string seirekiYear)
        {
            string retYear = string.Empty;

            int numYear = 0;
            if (!int.TryParse(seirekiYear, out numYear))
            {
                // エラーログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", seirekiYear));

                return retYear;
            }

            numYear = numYear - Constants.HOSHOU_NENDO_OFFSET;

            if (numYear < 0)
            {
                // エラーログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", seirekiYear));

                return retYear;
            }

            retYear = numYear.ToString("00");
            //retYear = numYear.ToString();

            return retYear;
        }

        /// <summary>
        /// 和暦年度(平成)を西暦年度に変換
        /// </summary>
        /// <returns></returns>
        /// <remarks>
        /// 元号は常に平成とする
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07  habu　　    新規作成
        /// </history>
        public static string ConvertToHoshouNendoSeireki(string warekiYear)
        {
            string retYear = string.Empty;

            int numYear = 0;
            if (!int.TryParse(warekiYear, out numYear))
            {
                // エラーログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", warekiYear));

                return retYear;
            }

            numYear = numYear + Constants.HOSHOU_NENDO_OFFSET;

            if (numYear < 0)
            {
                // エラーログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}", warekiYear));

                return retYear;
            }

            retYear = numYear.ToString();

            return retYear;
        }

        #endregion

        #region SwitchSearchPanelTouch
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： SwitchSearchPanelTouch
        /// <summary>
        ///  検索条件パネルの表示・非表示の切り替え
        /// </summary>
        /// <param name="switchFlg">TRUE：表示　FALSE:非表示</param>
        /// <param name="searchPanel">検索条件パネル</param>
        /// <param name="defSearchPanelTop">検索条件パネルTOP（初期値）</param>
        /// <param name="defSearchPanelHeight">検索条件パネルHEIGHT（初期値）</param>
        /// <param name="listPanel">検索結果リストパネル</param>
        /// <param name="defSearchPanelTop">検索結果リストパネルTOP（初期値）</param>
        /// <param name="defSearchPanelHeight">検索結果リストパネルHEIGHT（初期値）</param>
        /// <param name="colNo">Index of checkbox column</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/28　HuyTX　　 新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static void SwitchSearchPanelTouch(
            bool switchFlg,
            Panel searchPanel,
            int defSearchPanelTop,
            int defSearchPanelHeight,
            Panel listPanel,
            int defListPanelTop,
            int defListPanelHeight
            )
        {
            try
            {
                if (switchFlg)//検索条件を開く
                {
                    searchPanel.Top = defSearchPanelTop;
                    searchPanel.Height = defSearchPanelHeight;
                    listPanel.Top = defListPanelTop;
                    listPanel.Height = defListPanelHeight;
                }
                else////検索条件を閉じる
                {
                    searchPanel.Height = 40;
                    listPanel.Top = searchPanel.Top + searchPanel.Height;
                    listPanel.Height += (defSearchPanelHeight - searchPanel.Height);
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region MakeSetchishaAdr
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSetchishaAdr
        /// <summary>
        /// Concat todofuken, shikuChoson and choikiNm as address
        /// </summary>
        /// <param name="choikiNm"></param>
        /// <param name="shikuChoson"></param>
        /// <param name="todofuken"></param>
        /// <returns>todofuken, shikuChoson, choikiNm</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string MakeSetchishaAdr(string todofuken, string shikuChoson, string choikiNm)
        {
            string result = string.Empty;
            string[] setchishaAdr = new string[3] { todofuken, shikuChoson, choikiNm };

            for (int i = 0; i < 3; i++)
            {
                if (string.IsNullOrEmpty(setchishaAdr[i])) continue;
                result += setchishaAdr[i] + ", ";
            }

            return (result.Length > 2) ? result.Remove(result.Length - 2, 2) : result;
        }
        #endregion

        #region CopyDataGridView
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CopyDataGridView
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvSource"></param>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/20　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static DataGridView CopyDataGridView(DataGridView dgvSource)
        {
            DataGridView dgvCopy = new DataGridView();

            try
            {
                if (dgvCopy.Columns.Count == 0)
                {
                    foreach (DataGridViewColumn dgvc in dgvSource.Columns)
                    {
                        dgvCopy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                    }
                }

                DataGridViewRow row = new DataGridViewRow();

                for (int i = 0; i < dgvSource.Rows.Count; i++)
                {
                    row = (DataGridViewRow)dgvSource.Rows[i].Clone();
                    int intColIndex = 0;
                    foreach (DataGridViewCell cell in dgvSource.Rows[i].Cells)
                    {
                        row.Cells[intColIndex].Value = cell.Value;
                        intColIndex++;
                    }

                    dgvCopy.Rows.Add(row);
                }

                dgvCopy.AllowUserToAddRows = false;
                dgvCopy.Refresh();
            }
            catch
            {
                throw;
            }

            return dgvCopy;
        }
        #endregion

        #region Printer working check

        #region GetDefaultPrinter
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDefaultPrinter
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static string GetDefaultPrinter()
        {
            PrinterSettings settings = new PrinterSettings();
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                settings.PrinterName = printer;

                // Default printer?
                if (settings.IsDefaultPrinter)
                {
                    return printer;
                }
            }

            return string.Empty;
        }
        #endregion

        #region PrinterExist
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： PrinterExist
        /// <summary>
        /// 
        /// </summary>
        /// <param name="printerToCheck"></param>
        /// <returns>
        /// true if printer is already installed, otherwise false
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool PrinterExist(string printerToCheck)
        {
            foreach (string printer in PrinterSettings.InstalledPrinters)
            {
                // Get printer need to check
                if (printer != printerToCheck) continue;

                PrinterSettings ps = new PrinterSettings();
                ps.PrinterName = printer;

                // Printer is working properly?
                if (ps.IsValid)
                {
                    return true;
                }
                else
                {
                    // Printer is not installed, no more loops that needed
                    break;
                }
            }

            // Printer not found or not installed
            return false;
        }
        #endregion

        #endregion

        #region ShokenKekkaTbl

        #region GetShokenKekkaTblByIraiKeyCheckHantei
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraiHoteiKbn"></param>
        /// <param name="iraiHokenjoCd"></param>
        /// <param name="iraiNendo"></param>
        /// <param name="iraiRenban"></param>
        /// <param name="checkHantei"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  habu　    新規作成
        /// </history>
        public static ShokenKekkaTblDataSet.ShokenKekkaTblDataTable GetShokenKekkaTblByIraiKeyCheckHantei(
            string iraiHoteiKbn
            , string iraiHokenjoCd
            , string iraiNendo
            , string iraiRenban
            , string checkHantei
            )
        {
            IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
            input.DataTableType = typeof(ShokenKekkaTblDataSet.ShokenKekkaTblDataTable);
            input.TableAdapterType = typeof(ShokenKekkaTblTableAdapter);

            ShokenKekkaTblDataSet.ShokenKekkaTblDataTable template = new ShokenKekkaTblDataSet.ShokenKekkaTblDataTable();

            input.Query.AddEqualCond(template.KensaIraiShokanIraiHoteiKbnColumn.ColumnName, iraiHoteiKbn);
            input.Query.AddEqualCond(template.KensaIraiShokenIraiHokenjoCdColumn.ColumnName, iraiHokenjoCd);
            input.Query.AddEqualCond(template.KensaIraiShokenIraiNendoColumn.ColumnName, iraiNendo);
            input.Query.AddEqualCond(template.KensaIraiShokenIraiRenbanColumn.ColumnName, iraiRenban);
            input.Query.AddEqualCond(template.ShokenCheckHanteiColumn.ColumnName, checkHantei);

            IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

            if (output.GetDataTable.Rows.Count == 0)
            {
                return null;
            }

            return (ShokenKekkaTblDataSet.ShokenKekkaTblDataTable)output.GetDataTable;
        }
        #endregion

        #endregion

        #region HoteiKensaRyokinMst

        #region GetHoteiKensaRyokinMstByNinsou
        /// <summary>
        /// 法定検査料金マスタ取得
        /// </summary>
        /// <param name="ninsou"></param>
        /// <param name="ninsouTo"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  habu　    新規作成
        /// 2014/12/09  habu　    NinsouEndが空の場合に対応
        /// 2015/01/05  habu　    人槽が文字列だったのに対応
        /// </history>
        public static HoteiKensaRyokinMstDataSet.HoteiKensaRyokinMstRow GetHoteiKensaRyokinMstByNinsou(int ninsou)
        {
            IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
            input.DataTableType = typeof(HoteiKensaRyokinMstDataSet.HoteiKensaRyokinMstDataTable);
            input.TableAdapterType = typeof(HoteiKensaRyokinMstTableAdapter);

            HoteiKensaRyokinMstDataSet.HoteiKensaRyokinMstDataTable template = new HoteiKensaRyokinMstDataSet.HoteiKensaRyokinMstDataTable();

            input.Query.AddCondUnit(string.Format("(CONVERT(int, {0}) <= {1})", template.HoteiKensaRyokinNinsoStartColumn.ColumnName, ninsou));
            // 最終レコードは、NinsouEndが空で設定されるため考慮
            input.Query.AddCondUnit(string.Format("(CONVERT(int, {0}) >= {1} OR {0} = '')", template.HoteiKensaRyokinNinsoEndColumn.ColumnName, ninsou));
            
            //input.Query.AddGreaterEqualCond(template.HoteiKensaRyokinNinsoStartColumn.ColumnName, ninsou);
            //// 最終レコードは、NinsouEndが空で設定されるため考慮
            //input.Query.AddCondUnit(string.Format("{0} <= '{1}' OR {0} = ''", template.HoteiKensaRyokinNinsoEndColumn.ColumnName, ninsou));

            IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

            if (output.GetDataTable.Rows.Count == 0)
            {
                return null;
            }

            return (HoteiKensaRyokinMstDataSet.HoteiKensaRyokinMstRow)output.GetDataTable.Rows[0];
        }
        #endregion

        #endregion

        #region Set up common control

        #region SetCdControlValue
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="cd"></param>
        public static void SetCdControlValue(System.Windows.Forms.Control control, string cd)
        {
            if (control is ComboBox)
            {
                // TODO check, debug
                (control as ComboBox).SelectedValue = cd;
            }
            else
            {
                control.Text = cd;
            }
        }
        #endregion

        #region nendoText

        #region to be removed
        //#region SetStdWarekiNendoEvent
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="targetControl"></param>
        //public static void SetStdWarekiNendoEvent(TextBox targetControl)
        //{
        //    targetControl.Leave += delegate(object sender, EventArgs e)
        //    {
        //        int i;

        //        if (int.TryParse(targetControl.Text, out i))
        //        {
        //            if (int.Parse(targetControl.Text) > 1868)
        //            {
        //                JapaneseCalendar jpCalender = new JapaneseCalendar();
        //                //jpCalender.GetEra(DateTime.Parse(chakkoNenTextBox.Text + "-01-01"));

        //                string[] Gengo = { "M", "T", "S", "H" };

        //                targetControl.Text = Gengo[jpCalender.GetEra(DateTime.Parse(targetControl.Text + "-12-31")) - 1] + jpCalender.GetYear(DateTime.Parse(targetControl.Text + "-12-31")).ToString();
        //            }
        //            else
        //            {
        //                targetControl.Text = "H" + targetControl.Text;
        //            }
        //        }
        //    };
        //}
        //#endregion
        #endregion

        #region to be removed
        //#region SetStdSeirekiConvertEvent
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="seirekiControl"></param>
        ///// <param name="dispControl"></param>
        //public static void SetStdSeirekiConvertEvent(TextBox seirekiControl, System.Windows.Forms.Control dispControl)
        //{
        //    const string DISP_FORMAT = "({0})";

        //    seirekiControl.Leave += delegate(object sender, EventArgs e)
        //    {
        //        // 和暦表示をオプションで表示
        //        string warekiDisp = string.Empty;

        //        string seirekiStr = string.Empty;

        //        if (!string.IsNullOrEmpty(seirekiControl.Text))
        //        {
        //            warekiDisp = string.Format(DISP_FORMAT, Utility.DateUtility.ConvertToWareki(seirekiStr));
        //        }

        //        dispControl.Text = warekiDisp;
        //    };
        //}
        //#endregion
        #endregion

        #endregion

        #region SetRangeCdAutoFill
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromText"></param>
        /// <param name="toText"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/30  habu　　    新規作成
        /// </history>
        public static void SetRangeCdAutoFill(TextBox fromText, TextBox toText, int cdLength, char padChar)
        {
            fromText.Leave += delegate(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(fromText.Text.Trim())) { return; }

                // 指定桁数までパディング
                fromText.Text = fromText.Text.Trim().PadLeft(cdLength, padChar);

                // 空の場合は、開始と同じ値を設定
                if (string.IsNullOrEmpty(toText.Text.Trim()))
                {
                    toText.Text = fromText.Text.Trim();
                }
            };

            toText.Leave += delegate(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(toText.Text.Trim())) { return; }

                // 指定桁数までパディング
                toText.Text = toText.Text.Trim().PadLeft(cdLength, padChar);
            };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromText"></param>
        /// <param name="toText"></param>
        /// <param name="cdLength"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/30  habu　　    新規作成
        /// </history>
        public static void SetRangeCdAutoFill(TextBox fromText, TextBox toText, int cdLength)
        {
            // 既定では0パディングとする
            SetRangeCdAutoFill(fromText, toText, cdLength, '0');
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromText"></param>
        /// <param name="toText"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/30  habu　　    新規作成
        /// </history>
        public static void SetRangeCdAutoFill(TextBox fromText, TextBox toText)
        {
            // MaxLengthを既定のコード長とする
            SetRangeCdAutoFill(fromText, toText, fromText.MaxLength);
        }
        #endregion

        #region SetRangeNoAutoFill
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromText"></param>
        /// <param name="toText"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/30  habu　　    新規作成
        /// </history>
        public static void SetRangeNoAutoFill(TextBox fromText, TextBox toText, int cdLength)
        {
            fromText.Leave += delegate(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(fromText.Text.Trim())) { return; }

                // 空の場合は、開始と同じ値を設定
                if (string.IsNullOrEmpty(toText.Text.Trim()))
                {
                    toText.Text = fromText.Text.Trim();
                }
            };

            toText.Leave += delegate(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(toText.Text.Trim())) { return; }
            };
        }

        public static void SetRangeNoAutoFill(TextBox fromText, TextBox toText)
        {
            // MaxLengthを既定のコード長とする
            SetRangeNoAutoFill(fromText, toText, fromText.MaxLength);
        }
        #endregion

        #region SetCdAutoPad
        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <param name="cdLength"></param>
        /// <param name="padChar"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/30  habu　　    新規作成
        /// </history>
        public static void SetCdAutoPad(TextBox text, int cdLength, char padChar)
        {
            text.Leave += delegate(object sender, EventArgs e)
            {
                if (string.IsNullOrEmpty(text.Text.Trim())) { return; }

                // 指定桁数までパディング
                text.Text = text.Text.Trim().PadLeft(cdLength, padChar);
            };
        }

        public static void SetCdAutoPad(TextBox text)
        {
            SetCdAutoPad(text, text.MaxLength, '0');
        }
        #endregion

        #region Std KeyEvents

        #region SetStdEnterTabEvent
        /// <summary>
        /// if set, Enter key press work as Tab key press
        /// </summary>
        /// <param name="targetControl"></param>
        public static void SetStdEnterTabEvent(Form targetControl)
        {
            targetControl.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    bool forward = e.Modifiers != Keys.Shift;
                    targetControl.SelectNextControl(targetControl.ActiveControl, forward, true, true, true);
                    e.Handled = true;
                }
            };
        }
        #endregion

        #region SetStdButtonKey
        /// <summary>
        /// Set button shortcut key to form
        /// </summary>
        /// <param name="targetControl"></param>
        /// <param name="key"></param>
        /// <param name="targetButton"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/01  habu　　    新規作成
        /// 2014/12/09  habu　　    実行前にボタンのフォーカスを設定する様に変更
        ///                         (DataGridViewのCellEndEventを発生させるため)
        /// </history>
        public static void SetStdButtonKey(Form targetControl, Keys key, Button targetButton)
        {
            targetControl.KeyDown += delegate(object sender, KeyEventArgs e)
            {
                if (e.KeyCode == key)
                {
                    targetButton.Focus();
                    targetButton.PerformClick();
                }
            };
        }
        #endregion

        #endregion

        #region to be removed
        #region GetYubinNoAdr
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ZipCd"></param>
        ///// <param name="firstIsValid">(if true)if multiple records got, applies first</param>
        ///// <returns></returns>
        //public static string GetYubinNoAdr(string ZipCd, bool firstIsValid)
        //{
        //    IZipCdTextBoxLeaveALInput alInput = new ZipCdTextBoxLeaveALInput();
        //    alInput.ZipCd = ZipCd;
        //    IZipCdTextBoxLeaveALOutput alOutput = new ZipCdTextBoxLeaveApplicationLogic().Execute(alInput);

        //    string adr = string.Empty;

        //    if (alOutput.YubinNoAdrMstDT.Rows.Count > 0)
        //    {
        //        if (firstIsValid)
        //        {
        //            YubinNoAdrMstKensakuDataSet.YubinNoAdrMstRow rows = alOutput.YubinNoAdrMstDT[0];
        //            adr = rows.ShikuchosonNm + rows.ChoikiNm;
        //        }
        //        else
        //        {
        //            YubinNoAdrMstKensakuDataSet.YubinNoAdrMstRow rows = alOutput.YubinNoAdrMstDT[alOutput.YubinNoAdrMstDT.Rows.Count - 1];
        //            adr = rows.ShikuchosonNm + rows.ChoikiNm;
        //        }
        //    }

        //    return adr;
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="ZipCd"></param>
        ///// <returns></returns>
        //public static string GetYubinNoAdr(string ZipCd)
        //{
        //    return GetYubinNoAdr(ZipCd, false);
        //}
        #endregion
        #endregion

        #endregion

        #region GetEndOfDay
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetEndOfDay
        /// <summary>
        /// returns end day of target month
        /// </summary>
        /// <input>日付(YYYYMMDD)</input>
        /// <returns>月末日(YYYYMMDD)</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  宗　　　    新規作成
        /// 2014/09/17  habu　　　  Implement
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string GetEndOfDay(string nowDate)
        {
            string endDate = string.Empty;

            try
            {
                DateTime workDate = DateTime.ParseExact(nowDate, "yyyyMMdd", null);

                // target month 1st day
                workDate = new DateTime(workDate.Year, workDate.Month, 1);

                // next month 1st day
                workDate = workDate.AddMonths(1);

                // yesterday of next month 1st day is last day of target month
                workDate = workDate.AddDays(-1);

                endDate = workDate.ToString("yyyyMMdd");
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return endDate;
        }
        #endregion

        #region GaikanKensaChikuHantei
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GaikanKensaChikuHantei
        /// <summary>
        /// 
        /// </summary>
        /// <input>対象年度(YYYY)</input>
        /// <returns>外観検査地区</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  宗　　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string GaikanKensaChikuHantei(string targetYear)
        {
            int nendo = 0;
            string chiku = "";

            try
            {
                nendo = int.Parse(targetYear);
                switch (nendo % 5)
                {
                    case 3:
                        chiku = "A";
                        break;
                    case 4:
                        chiku = "B";
                        break;
                    case 0:
                        chiku = "C";
                        break;
                    case 1:
                        chiku = "D";
                        break;
                    case 2:
                        chiku = "E";
                        break;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return chiku;
        }
        #endregion

        #region GetPrinterName
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetPrinterName
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kbn">印刷用紙区分</param>
        /// <returns>PrinterName</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  豊田  　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string GetPrinterName(string kbn)
        {
            // プリンタ設定を取得
            IGetPrintSettingMstByKeyALInput alInput = new GetPrintSettingMstByKeyALInput();
            alInput.IpAddress = Dns.GetHostName();
            alInput.PrintKbn = kbn.ToString();
            IGetPrintSettingMstByKeyALOutput alOutput = new GetPrintSettingMstByKeyApplicationLogic().Execute(alInput);

            if (alOutput.PrintSettingMstDt.Count > 0)
            {
                return alOutput.PrintSettingMstDt[0].PrinterName;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region Export KaikeiRendo to CSV file

        #region ExportKaikeiRendoToCSVFile
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ExportKaikeiRendoToCSVFile
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_kaikeiNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12　HuyTX    新規作成
        /// 2014/11/03　HuyTX    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void ExportKaikeiRendoToCSVFile(string _kaikeiNo)
        {
            try
            {
                //Ver1.02 Start
                string filePath = Utility.SharedFolderUtility.GetConstLocalFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_023, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                //Ver1.02 End

                string kaikeiNo = _kaikeiNo;
                string fileName = "PkJidou" + kaikeiNo + ".txt";

                if (string.IsNullOrEmpty(filePath))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "会計連動ファイルの作成先フォルダが設定されていません。");
                    return;
                }

                if (!Directory.Exists(filePath))
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "会計連動ファイルの作成先フォルダが存在しません。");
                    return;
                }

                filePath = ((filePath.Substring(filePath.Length - 1, 1) == "\\") ? filePath : filePath + "\\") + fileName;

                if (File.Exists(filePath))
                {
                    if (MessageForm.Show2(MessageForm.DispModeType.Question, "選択された会計連動ファイルを作成します。\n同名ファイルがあった場合は上書きします。\nよろしいですか？") != DialogResult.Yes) return;
                }

                IKaikeiBtnClickALInput alInput = new KaikeiBtnClickALInput();
                alInput.KaikeiNo = _kaikeiNo;
                IKaikeiBtnClickALOutput alOutput = new KaikeiBtnClickApplicationLogic().Execute(alInput);

                //export data to csv file
                bool isSuccess = ExportToCSV(filePath, alOutput.KaikeiRendoTblExportCSVDataTable);

                if (!isSuccess)
                {
                    MessageForm.Show2(MessageForm.DispModeType.Error, "会計連動ファイルの作成に失敗しました。\nシステム管理者へ連絡してください。");
                    return;
                }

                MessageForm.Show2(MessageForm.DispModeType.Infomation, "会計連動ファイルを作成しました。\n" + filePath);
            }
            catch
            {
                throw;
            }
            finally
            {
            }
        }
        #endregion

        #region ExportToCSV
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ExportToCSV
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="exportDataTalbe"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12　HuyTX    新規作成
        /// 2014/11/03　HuyTX    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private static bool ExportToCSV(string filePath, KaikeiRendoDtlTblDataSet.KaikeiRendoTblExportCSVDataTable exportDataTalbe)
        {
            //bool isOutputKaikeiHdr = true;
            bool isSuccess = true;
            string messageError = string.Empty;
            StringBuilder dataOutput = new StringBuilder();

            try
            {
                StreamWriter sw = new StreamWriter(filePath);

                foreach (KaikeiRendoDtlTblDataSet.KaikeiRendoTblExportCSVRow exportRow in exportDataTalbe)
                {
                    if (exportRow.OutputKbn != "1") continue;

                    sw.Write(string.Format("\"{0}\",", exportRow.RendoKaikeiCD));
                    sw.Write(exportRow.DenpyoDt + ",");
                    sw.Write((!exportRow.IsKeikeiRenbanNull() ? exportRow.KeikeiRenban.ToString() : string.Empty) + ",");
                    sw.Write(exportRow.SyohizeiJidoKeisan + ",");
                    sw.Write(string.Format("\"{0}\",", exportRow.KarikataJigyoCd));
                    sw.Write(string.Format("\"{0}\",", exportRow.KarikataKamokuCd));
                    sw.Write(exportRow.KarikataKamokuNm + ",");
                    sw.Write(string.Format("\"{0}\",", exportRow.KarikataHojoKamokuCd));
                    sw.Write(exportRow.KarikataHojoKamokuNm + ",");
                    sw.Write(string.Format("\"{0}\",", exportRow.KarikataSyoKamokuCd));
                    sw.Write(exportRow.KarikataSyoKamokuNm + ",");
                    sw.Write(exportRow.KarikataZeiKbn + ",");
                    sw.Write(Math.Truncate(exportRow.KarikataKingaku) + ",");
                    sw.Write(Math.Truncate(exportRow.KarikataSyohizei) + ",");
                    sw.Write(string.Format("\"{0}\",", exportRow.KashikataJigyoCd));
                    sw.Write(string.Format("\"{0}\",", exportRow.KashikataKamokuCd));
                    sw.Write(exportRow.KashikataKamokuNm + ",");
                    sw.Write(string.Format("\"{0}\",", exportRow.KashikataHojoKamokuCd));
                    sw.Write(exportRow.KashikataHojoKamokuNm + ",");
                    sw.Write(string.Format("\"{0}\",", exportRow.KashikataSyoKamokuCd));
                    sw.Write(exportRow.KashikataSyoKamokuNm + ",");
                    sw.Write(exportRow.KashikataZeiKbn + ",");
                    sw.Write(Math.Truncate(exportRow.KashikataKingaku) + ",");
                    sw.Write(Math.Truncate(exportRow.SyohizeiGaku) + ",");
                    sw.Write(string.Format("\"{0}\",", exportRow.RendoSuji1));
                    sw.Write(string.Format("\"{0}\",", exportRow.RendoSuji2));
                    sw.Write(exportRow.Tekiyo + ",");
                    sw.Write(exportRow.NaibuTorihikiKbn);

                    sw.WriteLine();
                }

                sw.Close();
            }
            catch
            {
                isSuccess = false;
            }

            return isSuccess;
        }
        #endregion

        #endregion

        #region GetSyohizei
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetSyohizei
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chkDt">yyyyMMdd</param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29  AnhNV　　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static decimal GetSyohizei(string chkDt)
        {
            decimal zeiritsu = 0;

            try
            {
                IGetShouhizeiritsuByTekiyoFromDtALInput alInput = new GetShouhizeiritsuByTekiyoFromDtALInput();
                alInput.TekiyoFromDt = chkDt;
                IGetShouhizeiritsuByTekiyoFromDtALOutput alOutput = new GetShouhizeiritsuByTekiyoFromDtApplicationLogic().Execute(alInput);

                if (alOutput.ShouhizeiritsuDataTable.Rows.Count > 0)
                {
                    zeiritsu = alOutput.ShouhizeiritsuDataTable[0].Zeiritsu;
                }
            }
            catch
            {
                throw;
            }
            finally
            {

            }

            return zeiritsu;
        }
        #endregion

        #region GetShishoNmByShishoCd
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： GetShishoNmByShishoCd
        /// <summary>
        /// 
        /// </summary>
        /// <returns>ShiShoNm</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03  DatNT　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string GetShishoNmByShishoCd(string shishoCd)
        {
            string shishoNm = string.Empty;

            try
            {
                IGetShishoMstByKeyBLInput input = new GetShishoMstByKeyBLInput();
                input.ShishoCd = shishoCd;
                IGetShishoMstByKeyBLOutput output = new GetShishoMstByKeyBusinessLogic().Execute(input);

                if (output.ShishoMstDataTable != null && output.ShishoMstDataTable.Count > 0)
                {
                    shishoNm = output.ShishoMstDataTable[0].ShishoNm;
                }
            }
            catch
            {
                throw;
            }

            return shishoNm;
        }
        #endregion

        #region PaddingZeroForTextBoxLeave
        ///////////////////////////////////////////////////////////////
        //メソッド名 ： PaddingZeroForTextBoxLeave
        /// <summary>
        /// Padding zero for textboxes Leave event
        /// </summary>
        /// <param name="targetTextBox">Current textbox that raises the "Leave" event. It's required</param>
        /// <param name="from1TextBox">Required</param>
        /// <param name="to1TextBox">Required</param>
        /// <param name="from2TextBox">Optional. For KyokaiNo only.</param>
        /// <param name="to2TextBox">Optional. For KyokaiNo only.</param>
        /// <param name="from3TextBox">Optional. For KyokaiNo only.</param>
        /// <param name="to3TextBox">Optional. For KyokaiNo only.</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27  AnhNV　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static void PaddingZeroForTextBoxLeave
        (
            TextBox targetTextBox,
            TextBox from1TextBox,
            TextBox to1TextBox,
            TextBox from2TextBox = null,
            TextBox to2TextBox = null,
            TextBox from3TextBox = null,
            TextBox to3TextBox = null
        )
        {
            // Stop handle for empty target textbox
            if (string.IsNullOrEmpty(targetTextBox.Text)) return;

            // From1
            if (targetTextBox.Name == from1TextBox.Name)
            {
                from1TextBox.Text = from1TextBox.Text.PadLeft(from1TextBox.MaxLength, '0');
                to1TextBox.Text = from1TextBox.Text;
                return;
            }
            // To1
            if (targetTextBox.Name == to1TextBox.Name)
            {
                to1TextBox.Text = to1TextBox.Text.PadLeft(to1TextBox.MaxLength, '0');
                return;
            }
            // From2
            if (null != from2TextBox && targetTextBox.Name == from2TextBox.Name)
            {
                from2TextBox.Text = from2TextBox.Text.PadLeft(from2TextBox.MaxLength, '0');
                to2TextBox.Text = from2TextBox.Text;
                return;
            }
            // To2
            if (null != to2TextBox && targetTextBox.Name == to2TextBox.Name)
            {
                to2TextBox.Text = to2TextBox.Text.PadLeft(to2TextBox.MaxLength, '0');
                return;
            }
            // From3
            if (null != from3TextBox && targetTextBox.Name == from3TextBox.Name)
            {
                from3TextBox.Text = from3TextBox.Text.PadLeft(from3TextBox.MaxLength, '0');
                to3TextBox.Text = from3TextBox.Text;
                return;
            }
            // To3
            if (null != to3TextBox && targetTextBox.Name == to3TextBox.Name)
            {
                to3TextBox.Text = to3TextBox.Text.PadLeft(to3TextBox.MaxLength, '0');
                return;
            }
        }
        #endregion

        #region ConvertExcelToPdf
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ConvertExcelToPdf
        /// <summary>
        /// convert excel file to pdf format file
        /// </summary>
        /// <param name="sourcePath">source path Excel file(.xls|.xlsx)</param>
        /// <param name="desPath">destination path Pdf file(.pdf)</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void ConvertExcelToPdf(string sourcePath, string desPath)
        {
            Microsoft.Office.Interop.Excel.ApplicationClass excelApplication = new Microsoft.Office.Interop.Excel.ApplicationClass();
            Microsoft.Office.Interop.Excel.Workbook excelWorkBook = null;
            object paramMissing = Type.Missing;
            Microsoft.Office.Interop.Excel.XlFixedFormatType paramExportFormat = Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF;
            Microsoft.Office.Interop.Excel.XlFixedFormatQuality paramExportQuality = Microsoft.Office.Interop.Excel.XlFixedFormatQuality.xlQualityStandard;

            try
            {
                // Open the source workbook.
                excelWorkBook = excelApplication.Workbooks.Open(sourcePath,
                    paramMissing, paramMissing, paramMissing, paramMissing,
                    paramMissing, paramMissing, paramMissing, paramMissing,
                    paramMissing, paramMissing, paramMissing, paramMissing,
                    paramMissing, paramMissing);

                // Save it in the target format.
                if (excelWorkBook != null)
                    excelWorkBook.ExportAsFixedFormat(paramExportFormat,
                        desPath, paramExportQuality,
                        true, true, paramMissing,
                        paramMissing, false,
                        paramMissing);
            }
            catch (Exception ex)
            {
                // throw ex
                throw ex;
            }
            finally
            {
                // Close the workbook object.
                if (excelWorkBook != null)
                {
                    excelWorkBook.Close(false, paramMissing, paramMissing);
                    excelWorkBook = null;
                }

                // Quit Excel and release the ApplicationClass object.
                if (excelApplication != null)
                {
                    excelApplication.Quit();
                    excelApplication = null;
                }

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }
        #endregion

        #region NumberTextBox_Leave
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： NumberTextBox_Leave
        /// <summary>
        /// format value of Textbox to #,###
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static void NumberTextBox_Leave(object sender, EventArgs e)
        {
            TextBox nbTextBox = sender as TextBox;

            if (string.IsNullOrEmpty(nbTextBox.Text.Trim())) return;

            nbTextBox.Text = string.Format("{0:N0}", Decimal.Parse(nbTextBox.Text.Trim()));
        }
        #endregion

        #region GetJokasoDaichoMstByJokasoSetchisha
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetJokasoDaichoMstByJokasoSetchisha
        /// <summary>
        /// 浄化槽台帳マスタ情報取得（設置者区分、設置者コード指定）
        /// </summary>
        /// <param name="jokasoSetchishaKbn">設置者区分</param>
        /// <param name="jokasoSetchishaCd">設置者コード</param>
        /// <returns>浄化槽台帳マスタ情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/29　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static JokasoDaichoMstDataSet.JokasoDaichoMstDataTable GetJokasoDaichoMstByJokasoSetchisha(string jokasoSetchishaKbn, string jokasoSetchishaCd)
        {
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable jokasoDaichoMstDT = null;

            try
            {
                IGetJokasoDaichoMstByJokasoSetchishaBLInput alInput = new GetJokasoDaichoMstByJokasoSetchishaBLInput();
                // 設置者区分
                alInput.JokasoSetchishaKbn = jokasoSetchishaKbn;
                // 設置者コード
                alInput.JokasoSetchishaCd = jokasoSetchishaCd;
                // 浄化槽台帳マスタ情報取得（設置者区分、設置者コード指定）
                IGetJokasoDaichoMstByJokasoSetchishaBLOutput output = new GetJokasoDaichoMstByJokasoSetchishaBusinessLogic().Execute(alInput);
                jokasoDaichoMstDT = output.JokasoDaichoMstDT;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return jokasoDaichoMstDT;
        }
        #endregion

        #region CreateKensaIraiNoString
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiNoString
        /// <summary>
        /// 検査依頼番号文字列作成
        /// </summary>
        /// <param name="hokenjoCd">検査依頼保健所CD</param>
        /// <param name="nendo">検査依頼年度</param>
        /// <param name="renban">検査依頼連番</param>
        /// <returns>検査依頼番号文字列</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string CreateKensaIraiNoString(string hokenjoCd, string nendo, string renban)
        {
            if (string.IsNullOrEmpty(hokenjoCd) || string.IsNullOrEmpty(nendo) || string.IsNullOrEmpty(renban))
            {
                return string.Empty;
            }
            return string.Concat(hokenjoCd.Trim().PadLeft(2, '0'), "-", Boundary.Common.Common.ConvertToHoshouNendoWareki(nendo.Trim()).PadLeft(2, '0'), "-", renban.Trim().PadLeft(6, '0'));
        }
        #endregion

        #region CreateKeiryoShomeiNoString
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="nendo"></param>
        /// <param name="renban"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　habu　　    新規作成
        /// </history>
        public static string CreateKeiryoShomeiNoString(string shishoCd, string nendo, string renban)
        {
            if (string.IsNullOrEmpty(shishoCd) || string.IsNullOrEmpty(nendo) || string.IsNullOrEmpty(renban))
            {
                return string.Empty;
            }
            return string.Concat(Boundary.Common.Common.ConvertToHoshouNendoWareki(nendo.Trim()).PadLeft(2, '0'), "-", shishoCd.Trim(), "-", renban.Trim().PadLeft(6, '0'));
        }
        #endregion

        #region CreateKyokaiNoString
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKyokaiNoString
        /// <summary>
        /// 協会番号(浄化槽台帳番号)文字列作成
        /// </summary>
        /// <param name="hokenjoCd">浄化槽台帳保健所CD</param>
        /// <param name="nendo">浄化槽台帳登録年度</param>
        /// <param name="renban">浄化槽台帳連番</param>
        /// <returns>浄化槽台帳番号文字列</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static string CreateKyokaiNoString(string hokenjoCd, string nendo, string renban)
        {
            if (string.IsNullOrEmpty(hokenjoCd) || string.IsNullOrEmpty(nendo) || string.IsNullOrEmpty(renban))
            {
                return string.Empty;
            }
            return string.Concat(hokenjoCd.Trim().PadLeft(2, '0'), "-", Boundary.Common.Common.ConvertToHoshouNendoWareki(nendo.Trim()).PadLeft(2, '0'), "-", renban.Trim().PadLeft(5, '0'));
        }
        #endregion

        #region GetKensaDaicho11joHdrTblByKey
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKensaDaicho11joHdrTblByKey
        /// <summary>
        /// 検査台帳（11条）ヘッダ情報取得（主キー指定）
        /// </summary>
        /// <param name="kensaKbn">検査区分</param>
        /// <param name="iraiNendo">依頼年度</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="suishitsuKensaIraiNo">水質検査依頼番号</param>
        /// <returns>検査台帳（11条）ヘッダ情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable GetKensaDaicho11joHdrTblByKey(string kensaKbn, string iraiNendo, string shishoCd, string suishitsuKensaIraiNo)
        {
            KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable kensaDaicho11joHdrDT = null;

            try
            {
                IGetKensaDaicho11joHdrTblByKeyBLInput input = new GetKensaDaicho11joHdrTblByKeyBLInput();
                // 検査区分
                input.KensaKbn = kensaKbn;
                // 依頼年度
                input.IraiNendo = iraiNendo;
                // 支所コード
                input.ShishoCd = shishoCd;
                // 水質検査依頼番号
                input.SuishitsuKensaIraiNo = suishitsuKensaIraiNo;

                // 検査台帳（11条）ヘッダ情報取得
                IGetKensaDaicho11joHdrTblByKeyBLOutput output = new GetKensaDaicho11joHdrTblByKeyBusinessLogic().Execute(input);
                kensaDaicho11joHdrDT = output.KensaDaicho11joHdrDT;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return kensaDaicho11joHdrDT;
        }
        #endregion

        #region GetKensaDaicho9joHdrTblByKey
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKensaDaicho9joHdrTblByKey
        /// <summary>
        /// 検査台帳（9条）ヘッダ情報取得（主キー指定）
        /// </summary>
        /// <param name="iraiNendo">依頼年度</param>
        /// <param name="shishoCd">支所コード</param>
        /// <param name="suishitsuKensaIraiNo">水質検査依頼番号</param>
        /// <returns>検査台帳（9条）ヘッダ情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable GetKensaDaicho9joHdrTblByKey(string iraiNendo, string shishoCd, string suishitsuKensaIraiNo)
        {
            KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable kensaDaicho9joHdrDT = null;

            try
            {
                IGetKensaDaicho9joHdrTblByKeyBLInput input = new GetKensaDaicho9joHdrTblByKeyBLInput();
                // 依頼年度
                input.IraiNendo = iraiNendo;
                // 支所コード
                input.ShishoCd = shishoCd;
                // 水質検査依頼番号
                input.SuishitsuKensaIraiNo = suishitsuKensaIraiNo;

                // 検査台帳（9条）ヘッダ情報取得
                IGetKensaDaicho9joHdrTblByKeyBLOutput output = new GetKensaDaicho9joHdrTblByKeyBusinessLogic().Execute(input);
                kensaDaicho9joHdrDT = output.KensaDaicho9joHdrDT;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return kensaDaicho9joHdrDT;
        }
        #endregion

        #region GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPK
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPK
        /// <summary>
        /// 浄化槽台帳水質検査単項目マスタ情報取得
        /// 指定された協会番号＋枝番の水質検査項目を取得（複数件）
        /// </summary>
        /// <param name="iraiNendo">浄化槽台帳保健所コード</param>
        /// <param name="jokasoTorokuNendo">浄化槽台帳登録年度</param>
        /// <param name="jokasoRenban">浄化槽台帳連番</param>
        /// <param name="komokuEdaban">台帳検査項目枝番</param>
        /// <returns>浄化槽台帳水質検査単項目マスタ情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable
            GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPK(string jokasoHokenjoCd, string jokasoTorokuNendo, string jokasoRenban, string komokuEdaban)
        {
            DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable KensaTanKomokuMstDT = null;

            try
            {
                IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLInput input = new GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLInput();
                // 浄化槽台帳保健所コード
                input.JokasoHokenjoCd = jokasoHokenjoCd;
                // 浄化槽台帳登録年度
                input.JokasoTorokuNendo = jokasoTorokuNendo;
                // 浄化槽台帳連番
                input.JokasoRenban = jokasoRenban;
                // 台帳検査項目枝番
                input.DaichoKensaKomokuEdaban = komokuEdaban;

                // 浄化槽台帳水質検査単項目マスタ情報取得
                IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput output = new GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBusinessLogic().Execute(input);
                KensaTanKomokuMstDT = output.KensaTanKomokuMstDT;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return KensaTanKomokuMstDT;
        }
        #endregion

        #region GetKensaIraiTblByKey
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKensaIraiTblByKey
        /// <summary>
        /// 検査依頼テーブル情報取得（主キー指定）
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="kensaIraiHokenjoCd"></param>
        /// <param name="kensaIraiNendo"></param>
        /// <param name="kensaIraiRenban"></param>
        /// <returns>検査依頼テーブル情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static KensaIraiTblDataSet.KensaIraiTblDataTable GetKensaIraiTblByKey(string kensaIraiHoteiKbn, string kensaIraiHokenjoCd, string kensaIraiNendo, string kensaIraiRenban)
        {
            KensaIraiTblDataSet.KensaIraiTblDataTable outputDT = null;
            try
            {
                // 検索
                IGetKensaIraiTblByKeyBLInput input = new GetKensaIraiTblByKeyBLInput();
                input.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
                input.KensaIraiHokenjoCd = kensaIraiHokenjoCd;
                input.KensaIraiNendo = kensaIraiNendo;
                input.KensaIraiRenban = kensaIraiRenban;
                IGetKensaIraiTblByKeyBLOutput output = new GetKensaIraiTblByKeyBusinessLogic().Execute(input);

                outputDT = output.KensaIraiTblDataTable;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return outputDT;
        }
        #endregion

        #region GetKensaKekkaTblByKey
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKensaKekkaTblByKey
        /// <summary>
        /// 検査結果テーブル情報取得（主キー指定）
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="kensaIraiHokenjoCd"></param>
        /// <param name="kensaIraiNendo"></param>
        /// <param name="kensaIraiRenban"></param>
        /// <returns>検査結果テーブル情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/09　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static KensaKekkaTblDataSet.KensaKekkaTblDataTable GetKensaKekkaTblByKey(string kensaIraiHoteiKbn, string kensaIraiHokenjoCd, string kensaIraiNendo, string kensaIraiRenban)
        {
            KensaKekkaTblDataSet.KensaKekkaTblDataTable outputDT = null;
            try
            {
                // 検索
                IGetKensaKekkaTblByKeyBLInput input = new GetKensaKekkaTblByKeyBLInput();
                input.KensaKekkaIraiHoteiKbn = kensaIraiHoteiKbn;
                input.KensaKekkaIraiHokenjoCd = kensaIraiHokenjoCd;
                input.KensaKekkaIraiNendo = kensaIraiNendo;
                input.KensaKekkaIraiRenban = kensaIraiRenban;
                IGetKensaKekkaTblByKeyBLOutput output = new GetKensaKekkaTblByKeyBusinessLogic().Execute(input);

                outputDT = output.KensaKekkaTblDataTable;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return outputDT;
        }
        #endregion

        #region GetKensaDaicho11joHdrTblByKensaKbnKensaIraiNo
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKensaDaicho11joHdrTblByKey
        /// <summary>
        /// 検査台帳（11条）ヘッダ情報取得（検査依頼番号指定）
        /// </summary>
        /// <param name="kensaKbn">検査区分</param>
        /// <param name="kensaIraiHoteiKbn">検査依頼法定区分</param>
        /// <param name="kensaIraiNendo">検査依頼保健所CD</param>
        /// <param name="kensaIraiNendo">検査依頼依頼年度</param>
        /// <param name="kensaIraiRenban">検査依頼連番</param>
        /// <returns>検査台帳（11条）ヘッダ情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable
            GetKensaDaicho11joHdrTblByKensaKbnKensaIraiNo(string kensaKbn, string kensaIraiHoteiKbn, string kensaIraiHokenjoCd, string kensaIraiNendo, string kensaIraiRenban)
        {
            KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable kensaDaicho11joHdrDT = null;

            try
            {
                ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAInput input = new SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAInput();
                // 検査区分
                input.KensaKbn = kensaKbn;
                // 検査依頼法定区分
                input.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
                // 検査依頼保健所CD
                input.KensaIraiHokenjoCd = kensaIraiHokenjoCd;
                // 検査依頼依頼年度
                input.KensaIraiNendo = kensaIraiNendo;
                // 検査依頼連番
                input.KensaIraiRenban = kensaIraiRenban;

                // 検査台帳（11条）ヘッダ情報取得
                ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput output = new SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDataAccess().Execute(input);
                kensaDaicho11joHdrDT = output.KensaDaicho11joHdrDT;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return kensaDaicho11joHdrDT;
        }
        #endregion

        #region GetKeiryoShomeiIraiTblByKey
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetKeiryoShomeiIraiTblByKey
        /// <summary>
        /// 計量証明依頼テーブル情報取得（主キー指定）
        /// </summary>
        /// <param name="keiryoShomeiIraiNendo"></param>
        /// <param name="keiryoShomeiIraiSishoCd"></param>
        /// <param name="keiryoShomeiIraiRenban"></param>
        /// <returns>計量証明依頼テーブル情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/13　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable GetKeiryoShomeiIraiTblByKey(string keiryoShomeiIraiNendo, string keiryoShomeiIraiSishoCd, string keiryoShomeiIraiRenban)
        {
            KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable outputDT = null;
            try
            {
                // 検索
                ISelectKeiryoShomeiIraiTblByKeyDAInput input = new SelectKeiryoShomeiIraiTblByKeyDAInput();
                input.KeiryoShomeiIraiNendo = keiryoShomeiIraiNendo;
                input.KeiryoShomeiIraiSishoCd = keiryoShomeiIraiSishoCd;
                input.KeiryoShomeiIraiRenban = keiryoShomeiIraiRenban;
                ISelectKeiryoShomeiIraiTblByKeyDAOutput output = new SelectKeiryoShomeiIraiTblByKeyDataAccess().Execute(input);

                outputDT = output.KeiryoShomeiIraiTblDT;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return outputDT;
        }
        #endregion

        #region GetNameMstTable
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetNameMstTable
        /// <summary>
        /// 名称マスタ情報取得（名称区分指定）
        /// </summary>
        /// <param name="nameKbn">名称区分</param>
        /// <returns>名称マスタ情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static DataTable GetNameMstTable(string nameKbn)
        {
            ISelectNameMstByNameKbnDAInput input = new SelectNameMstByNameKbnDAInput();
            input.NameKbn = nameKbn;
            ISelectNameMstByNameKbnDAOutput output = new SelectNameMstByNameKbnDataAccess().Execute(input);
            return output.NameMstDT;
        }
        #endregion

        #endregion

        #region Stubs to Utility

        #region HyojiKetasuHosei
        /// <summary>
        /// 020 水質検査結果値の表示桁数補正
        /// </summary>
        /// <param name="komokuCd"></param>
        /// <param name="kekkaValue"></param>
        /// <returns></returns>
        [Obsolete("use KensaHanteiUtility.*")]
        public static string HyojiKetasuHosei(string komokuCd, string kekkaValue)
        {
            return KensaHanteiUtility.HyojiKetasuHosei(komokuCd, kekkaValue);
        }
        #endregion

        #region GetSaisuiinMstByKey
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetSaisuiinMstByKey
        /// <summary>
        /// 採水員マスタ情報取得
        /// 主キー検索（１件）
        /// </summary>
        /// <param name="saisuiinCd">採水員コード</param>
        /// <returns>採水員マスタ情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static SaisuiinMstDataSet.SaisuiinMstDataTable GetSaisuiinMstByKey(string saisuiinCd)
        {
            SaisuiinMstDataSet.SaisuiinMstDataTable saisuiinMstDT = null;

            try
            {
                IGetSaisuiinMstByKeyBLInput input = new GetSaisuiinMstByKeyBLInput();
                // 採水員コード
                input.SaisuiinCd = saisuiinCd;
                IGetSaisuiinMstByKeyBLOutput output = new GetSaisuiinMstByKeyBusinessLogic().Execute(input);
                saisuiinMstDT = output.SaisuiinMstDataTable;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return saisuiinMstDT;
        }
        #endregion

        #region GetJokasoDaichoMstByKey
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetSaisuiinMstByKey
        /// <summary>
        /// 浄化槽台帳マスタ情報取得
        /// 主キー検索（１件）
        /// </summary>
        /// <param name="jokasoHokenjoCd">浄化槽台帳保健所コード</param>
        /// <param name="jokasoTorokuNendo">浄化槽台帳年度</param>
        /// <param name="jokasoRenban">浄化槽台帳連番</param>
        /// <returns>浄化槽台帳マスタ情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static JokasoDaichoMstDataSet.JokasoDaichoMstDataTable GetJokasoDaichoMstByKey(string jokasoHokenjoCd, string jokasoTorokuNendo, string jokasoRenban)
        {
            JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDT = null;

            try
            {
                IGetJokasoDaichoMstByJokasoDaichoNoBLInput input = new GetJokasoDaichoMstByJokasoDaichoNoBLInput();
                // 浄化槽台帳保健所コード
                input.HokenjoCd = jokasoHokenjoCd;
                // 浄化槽台帳年度
                input.TorokuNendo = jokasoTorokuNendo;
                // 浄化槽台帳連番
                input.Renban = jokasoRenban;
                // 指定された浄化槽台帳番号と一致する浄化槽台帳マスタデータ取得を取得
                IGetJokasoDaichoMstByJokasoDaichoNoBLOutput output = new GetJokasoDaichoMstByJokasoDaichoNoBusinessLogic().Execute(input);
                JokasoDaichoMstDT = output.JokasoDaichoMstDT;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return JokasoDaichoMstDT;
        }
        #endregion

        #region GetChikuMstByKey
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： GetChikuMstByKey
        /// <summary>
        /// 地区マスタ情報取得
        /// 主キー検索（１件）
        /// </summary>
        /// <param name="chikuCd">地区コード</param>
        /// <returns>地区マスタ情報</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/29　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        public static ChikuMstDataSet.ChikuMstDataTable GetChikuMstByKey(string chikuCd)
        {
            ChikuMstDataSet.ChikuMstDataTable chikuMstDT = null;

            try
            {
                ISelectChikuMstByKeyDAInput input = new SelectChikuMstByKeyDAInput();
                // 地区コード
                input.ChikuMstCd = chikuCd;
                // 指定された地区コードと一致する地区マスタデータ取得を取得
                ISelectChikuMstByKeyDAOutput output = new SelectChikuMstByKeyDataAccess().Execute(input);
                chikuMstDT = output.ChikuMstDT;
            }
            catch
            {
                throw;
            }
            finally
            {
            }

            return chikuMstDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
