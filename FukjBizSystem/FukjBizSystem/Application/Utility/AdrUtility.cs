using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ChikuMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.YubinNoAdrMstDataSetTableAdapters;
using Zynas.Framework.Core.Common.Boundary;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Utility
{
    /// <summary>
    /// 住所、郵便番号関連
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　habu　　    新規作成
    /// </history>
    public class AdrUtility
    {
        #region ZipCd
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class ZipCd
        {
            public static void SetStdZipCdSearchButton(Button zipButton, TextBox targetZipControl, TextBox targetAdrControl, bool overwriteExists)
            {
                zipButton.Click += delegate(object sender, EventArgs e)
                {
                    YubinNoKensaku yubin = new YubinNoKensaku();
                    yubin.Adr = targetAdrControl.Text;
                    yubin.ShowDialog();

                    if (!string.IsNullOrEmpty(yubin.ZipCd))
                    {
                        targetZipControl.Text = yubin.ZipCd;

                        if (string.IsNullOrEmpty(targetAdrControl.Text) || overwriteExists)
                        {
                            targetAdrControl.Text = yubin.Adr;
                        }
                    }
                };
            }

            public static void SetStdZipCdSearchButton(Button zipButton, TextBox targetZipControl, TextBox targetAdrControl)
            {
                SetStdZipCdSearchButton(zipButton, targetZipControl, targetAdrControl, true);
            }

            public static void SetStdZipCdChanged(TextBox targetZipCdControl, TextBox targetAddressControl, bool overwriteExists)
            {
                targetZipCdControl.Leave += delegate(object sender, EventArgs e)
                {
                    Cursor preCursor = Cursor.Current;

                    try
                    {
                        Cursor.Current = Cursors.WaitCursor;

                        if (string.IsNullOrEmpty(targetAddressControl.Text) || overwriteExists)
                        {
                            targetAddressControl.Text = GetYubinNoAdr(targetZipCdControl.Text);
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
                    }
                };
            }

            public static void SetStdZipCdChanged(TextBox targetZipCdControl, TextBox targetAddressControl)
            {
                SetStdZipCdChanged(targetZipCdControl, targetAddressControl, false);
            }

            #region GetYubinNoAdr
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ZipCd"></param>
            /// <param name="firstIsValid">(if true)if multiple records got, applies first</param>
            /// <returns></returns>
            public static string GetYubinNoAdr(string ZipCd, bool firstIsValid)
            {
                // 郵便番号情報取得
                YubinNoAdrMstDataSet.YubinNoAdrMstDataTable template = new YubinNoAdrMstDataSet.YubinNoAdrMstDataTable();
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(YubinNoAdrMstDataSet.YubinNoAdrMstDataTable);
                input.TableAdapterType = typeof(YubinNoAdrMstTableAdapter);
                input.Query.AddEqualCond(template.ZipCdColumn.ColumnName, ZipCd);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);
                YubinNoAdrMstDataSet.YubinNoAdrMstDataTable yubinTable = (YubinNoAdrMstDataSet.YubinNoAdrMstDataTable)output.GetDataTable;

                string adr = string.Empty;

                if (yubinTable.Rows.Count > 0)
                {
                    if (firstIsValid)
                    {
                        YubinNoAdrMstDataSet.YubinNoAdrMstRow rows = yubinTable[0];
                        adr = rows.ShikuchosonNm + rows.ChoikiNm;
                    }
                    else
                    {
                        YubinNoAdrMstDataSet.YubinNoAdrMstRow rows = yubinTable[yubinTable.Rows.Count - 1];
                        adr = rows.ShikuchosonNm + rows.ChoikiNm;
                    }
                }

                return adr;
            }
            /// <summary>
            /// 
            /// </summary>
            /// <param name="ZipCd"></param>
            /// <returns></returns>
            public static string GetYubinNoAdr(string ZipCd)
            {
                return GetYubinNoAdr(ZipCd, false);
            }
            #endregion
        }
        #endregion

        #region KyuChikuCd
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class KyuChikuCd
        {
            #region GetKyuChikuCdByAddress
            /// <summary>
            /// 
            /// </summary>
            /// <param name="addr"></param>
            /// <returns></returns>
            public static string GetKyuChikuCdByAddress(string addr)
            {
                string genChikuCd = string.Empty;
                string kyuChikuCd = string.Empty;

                // 住所から現地区コードを取得する
                {
                    genChikuCd = GenChikuCd.GetGenChikuCdByAddress(addr);
                }

                // 現地区コードから旧地区コードを取得する
                {
                    kyuChikuCd = GetKyuChikuCdByGenChikuCd(genChikuCd);
                }

                return kyuChikuCd;
            }
            #endregion

            #region GetKyuChikuCdListByAddress
            /// <summary>
            /// 
            /// </summary>
            /// <param name="addr"></param>
            /// <returns></returns>
            public static IEnumerable<KeyValuePair<string, string>> GetKyuChikuCdListByAddress(string addr)
            {
                string genChikuCd = string.Empty;
                IEnumerable<KeyValuePair<string, string>> kyuChikuCdList = new List<KeyValuePair<string, string>>();

                // 住所から現地区コードを取得する
                {
                    genChikuCd = GenChikuCd.GetGenChikuCdByAddress(addr);
                }

                // 現地区コードから旧地区コードリストを取得する
                {
                    kyuChikuCdList = GetKyuChikuCdListByGenChikuCd(genChikuCd);
                }

                return kyuChikuCdList;
            }
            #endregion

            #region GetKyuChikuCdByZipCd
            /// <summary>
            /// 
            /// </summary>
            /// <param name="addr"></param>
            /// <returns></returns>
            public static string GetKyuChikuCdByZipCd(string zipCd)
            {
                string genChikuCd = string.Empty;
                string kyuChikuCd = string.Empty;

                // 郵便番号から現地区コードを取得する
                {
                    genChikuCd = GenChikuCd.GetGenChikuCdByZipCd(zipCd);
                }

                // 現地区コードから旧地区コードを取得する
                {
                    kyuChikuCd = GetKyuChikuCdByGenChikuCd(genChikuCd);
                }

                return kyuChikuCd;
            }
            #endregion

            #region GetKyuChikuCdListByZipCd
            /// <summary>
            /// 
            /// </summary>
            /// <param name="addr"></param>
            /// <returns></returns>
            public static IEnumerable<KeyValuePair<string, string>> GetKyuChikuCdListByZipCd(string zipCd)
            {
                string genChikuCd = string.Empty;
                IEnumerable<KeyValuePair<string, string>> kyuChikuCdList = new List<KeyValuePair<string, string>>();

                // 住所から現地区コードを取得する
                {
                    genChikuCd = GenChikuCd.GetGenChikuCdByZipCd(zipCd);
                }

                // 現地区コードから旧地区コードリストを取得する
                {
                    kyuChikuCdList = GetKyuChikuCdListByGenChikuCd(genChikuCd);
                }

                return kyuChikuCdList;
            }
            #endregion

            #region GetKyuChikuCdByGenChikuCd
            /// <summary>
            /// 
            /// </summary>
            /// <param name="genChikuCd"></param>
            /// <returns></returns>
            public static string GetKyuChikuCdByGenChikuCd(string genChikuCd)
            {
                string kyuChikuCd = string.Empty;

                // 現地区コードから旧地区コードを取得する
                {
                    ChikuMstDataSet.ChikuMstDataTable templateTable = new ChikuMstDataSet.ChikuMstDataTable();

                    IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                    input.DataTableType = typeof(ChikuMstDataSet.ChikuMstDataTable);
                    input.TableAdapterType = typeof(ChikuMstTableAdapter);
                    input.Query.AddEqualCond(templateTable.GappeigoChikuCdColumn.ColumnName, genChikuCd);

                    IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);
                    if (output.GetDataTable.Rows.Count > 0)
                    {
                        // 旧地区コードが取得される
                        kyuChikuCd = (string)output.GetDataTable.Rows[0][templateTable.ChikuCdColumn.ColumnName];
                    }
                }

                return kyuChikuCd;
            }
            #endregion

            #region GetKyuChikuCdListByGenChikuCd
            /// <summary>
            /// 
            /// </summary>
            /// <param name="genChikuCd"></param>
            /// <returns></returns>
            public static IEnumerable<KeyValuePair<string, string>> GetKyuChikuCdListByGenChikuCd(string genChikuCd)
            {
                List<KeyValuePair<string, string>> kyuChikuCdList = new List<KeyValuePair<string, string>>();

                string kyuChikuCd = string.Empty;
                string kyuChikuNm = string.Empty;

                // 現地区コードから旧地区コードを取得する
                {
                    ChikuMstDataSet.ChikuMstDataTable templateTable = new ChikuMstDataSet.ChikuMstDataTable();

                    IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                    input.DataTableType = typeof(ChikuMstDataSet.ChikuMstDataTable);
                    input.TableAdapterType = typeof(ChikuMstTableAdapter);
                    input.Query.AddEqualCond(templateTable.GappeigoChikuCdColumn.ColumnName, genChikuCd);

                    IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);
                    // 旧地区コードが取得される
                    if (output.GetDataTable.Rows.Count > 0)
                    {
                        foreach (DataRow row in output.GetDataTable.Rows)
                        {
                            kyuChikuCd = (string)row[templateTable.ChikuCdColumn.ColumnName];
                            kyuChikuNm = (string)row[templateTable.ChikuNmColumn.ColumnName];

                            KeyValuePair<string, string> val = new KeyValuePair<string, string>(kyuChikuCd, kyuChikuNm);
                            kyuChikuCdList.Add(val);
                        }
                    }
                }

                return kyuChikuCdList;
            }
            #endregion

            #region SetStdKyuChikuCdAdrChanged
            /// <summary>
            /// 
            /// </summary>
            /// <param name="targetAdrControl"></param>
            /// <param name="targetChikuCdControl"></param>
            /// <param name="overwriteExists"></param>
            public static void SetStdKyuChikuCdAdrChanged(TextBox targetAdrControl, TextBox targetChikuCdControl, bool overwriteExists)
            {
                targetAdrControl.Leave += delegate(object sender, EventArgs e)
                {
                    string nm = string.Empty;

                    if (!string.IsNullOrEmpty(targetAdrControl.Text.Trim()))
                    {
                        nm = GetKyuChikuCdByAddress(targetAdrControl.Text.Trim());
                    }

                    if (string.IsNullOrEmpty(targetChikuCdControl.Text) || overwriteExists)
                    {
                        targetChikuCdControl.Text = nm;
                    }
                };
            }
            #endregion

            #region SetStdKyuChikuCdAdrChanged
            /// <summary>
            /// 
            /// </summary>
            /// <param name="targetAdrControl"></param>
            /// <param name="targetChikuCdControl"></param>
            /// <param name="overwriteExists"></param>
            public static void SetStdKyuChikuCdAdrChanged(TextBox targetAdrControl, ComboBox targetChikuCdControl)
            {

                targetAdrControl.Leave += delegate(object sender, EventArgs e)
                {
                    IEnumerable<KeyValuePair<string, string>> nm = new List<KeyValuePair<string, string>>();

                    if (!string.IsNullOrEmpty(targetAdrControl.Text.Trim()))
                    {
                        nm = GetKyuChikuCdListByAddress(targetAdrControl.Text.Trim());
                    }

                    string beforeVal = string.Empty;
                    if (targetChikuCdControl.SelectedValue != null)
                    {
                        beforeVal = (string)targetChikuCdControl.SelectedValue;
                    }

                    const string colCd = "Cd";
                    const string colNm = "Nm";

                    // コンボボックスに取得リストを設定
                    DataTable itemTable = new DataTable();
                    itemTable.Columns.Add(colCd, typeof(string));
                    itemTable.Columns.Add(colNm, typeof(string));

                    foreach (KeyValuePair<string, string> pair in nm)
                    {
                        DataRow itemRow = itemTable.NewRow();
                        itemRow[colCd] = pair.Key;
                        itemRow[colNm] = string.Format("{0}|{1}", pair.Key, pair.Value);

                        itemTable.Rows.Add(itemRow);
                    }

                    targetChikuCdControl.DataSource = itemTable;
                    targetChikuCdControl.ValueMember = colCd;
                    targetChikuCdControl.DisplayMember = colNm;

                    // 以前の選択値が含まれる場合は、復元する
                    targetChikuCdControl.SelectedValue = beforeVal;
                };
            }
            #endregion

            #region SetStdKyuChikuCdZipCdChanged
            /// <summary>
            /// 
            /// </summary>
            /// <param name="targetZipCdControl"></param>
            /// <param name="targetChikuCdControl"></param>
            /// <param name="overwriteExists"></param>
            public static void SetStdKyuChikuCdZipCdChanged(TextBox targetZipCdControl, TextBox targetChikuCdControl, bool overwriteExists)
            {
                targetZipCdControl.Leave += delegate(object sender, EventArgs e)
                {
                    string nm = string.Empty;

                    if (!string.IsNullOrEmpty(targetZipCdControl.Text.Trim()))
                    {
                        nm = GetKyuChikuCdByZipCd(targetZipCdControl.Text.Trim());
                    }

                    if (string.IsNullOrEmpty(targetChikuCdControl.Text) || overwriteExists)
                    {
                        targetChikuCdControl.Text = nm;
                    }
                };
            }
            #endregion
        }
        #endregion

        #region GenChikuCd
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class GenChikuCd
        {
            #region GetGenChikuCdByAddress
            /// <summary>
            /// 
            /// </summary>
            /// <param name="addr"></param>
            /// <returns></returns>
            public static string GetGenChikuCdByAddress(string addr)
            {
                string kyuChikuCd = string.Empty;

                string chikuCd = string.Empty;

                // 住所から郵便番号情報を取得する
                {
                    YubinNoAdrMstDataSet.YubinNoAdrMstDataTable templateTable = new YubinNoAdrMstDataSet.YubinNoAdrMstDataTable();

                    IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                    input.DataTableType = typeof(YubinNoAdrMstDataSet.YubinNoAdrMstDataTable);
                    input.TableAdapterType = typeof(YubinNoAdrMstTableAdapter);
                    // 「住所に対して地区名称を」部分一致する
                    input.Query.AddReverseLikeCond(templateTable.ShikuchosonNmColumn.ColumnName, addr);
                    input.Query.AddReverseLikeCond(templateTable.ChoikiNmColumn.ColumnName, addr);

                    IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);
                    if (output.GetDataTable.Rows.Count > 0)
                    {
                        // 郵便番号マスタの地方公共団体コード(合併後現地区コード)が取得される
                        chikuCd = (string)output.GetDataTable.Rows[0][templateTable.ChihoKokyoDantaiCdColumn.ColumnName];
                    }
                }

                return chikuCd;
            }
            #endregion

            #region GetGenChikuCdByZipCd
            /// <summary>
            /// 
            /// </summary>
            /// <param name="addr"></param>
            /// <returns></returns>
            public static string GetGenChikuCdByZipCd(string zipCd)
            {
                string chikuCd = string.Empty;

                // 郵便番号から郵便番号情報を取得する
                {
                    YubinNoAdrMstDataSet.YubinNoAdrMstDataTable templateTable = new YubinNoAdrMstDataSet.YubinNoAdrMstDataTable();

                    IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                    input.DataTableType = typeof(YubinNoAdrMstDataSet.YubinNoAdrMstDataTable);
                    input.TableAdapterType = typeof(YubinNoAdrMstTableAdapter);
                    input.Query.AddLikeCond(templateTable.ZipCdColumn.ColumnName, zipCd);

                    IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);
                    if (output.GetDataTable.Rows.Count > 0)
                    {
                        // 郵便番号マスタの地方公共団体コード(合併後現地区コード)が取得される
                        chikuCd = (string)output.GetDataTable.Rows[0][templateTable.ChihoKokyoDantaiCdColumn.ColumnName];
                    }
                }

                return chikuCd;
            }
            #endregion

            public static void SetStdGenChikuCdAdrChanged(TextBox targetAdrControl, TextBox targetChikuCdControl, bool overwriteExists)
            {
                targetAdrControl.Leave += delegate(object sender, EventArgs e)
                {
                    string nm = string.Empty;

                    if (!string.IsNullOrEmpty(targetAdrControl.Text.Trim()))
                    {
                        nm = GetGenChikuCdByAddress(targetAdrControl.Text.Trim());
                    }

                    if (string.IsNullOrEmpty(targetChikuCdControl.Text) || overwriteExists)
                    {
                        targetChikuCdControl.Text = nm;
                    }
                };
            }

            public static void SetStdGenChikuCdZipCdChanged(TextBox targetZipCdControl, TextBox targetChikuCdControl, bool overwriteExists)
            {
                targetZipCdControl.Leave += delegate(object sender, EventArgs e)
                {
                    string nm = string.Empty;

                    if (!string.IsNullOrEmpty(targetZipCdControl.Text.Trim()))
                    {
                        nm = GetGenChikuCdByZipCd(targetZipCdControl.Text.Trim());
                    }

                    if (string.IsNullOrEmpty(targetChikuCdControl.Text) || overwriteExists)
                    {
                        targetChikuCdControl.Text = nm;
                    }
                };
            }
        }
        #endregion

        #region Chikuwari
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class Chikuwari
        {
            #region GetChikuwariList
            /// <summary>
            /// 地区マスタから、登録済みの地区割コードのリストを取得する
            /// </summary>
            /// <returns></returns>
            public static IEnumerable<string> GetChikuwariList(bool addEmpty = true)
            {
                List<string> chikuwariList = new List<string>();

                ChikuMstDataSet.ChikuwariCdListDataTable templateTable = new ChikuMstDataSet.ChikuwariCdListDataTable();

                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(ChikuMstDataSet.ChikuwariCdListDataTable);
                input.TableAdapterType = typeof(ChikuwariCdListTableAdapter);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (addEmpty)
                {
                    chikuwariList.Add(string.Empty);
                }

                foreach (ChikuMstDataSet.ChikuwariCdListRow row in output.GetDataTable.Rows)
                {
                    chikuwariList.Add(row.GaikanChikuwariCd);
                }

                return chikuwariList;
            }
            #endregion
        }
        #endregion

        #region HokenjoCd
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class HokenjoCd
        {
            #region GetHokenjoCdByAddress
            /// <summary>
            /// 
            /// </summary>
            /// <param name="addr"></param>
            /// <returns></returns>
            public static string GetHokenjoCdByAddress(string addr)
            {
                string genChikuCd = string.Empty;
                string hokenjoCd = string.Empty;

                // 住所から現地区コードを取得する
                {
                    genChikuCd = GenChikuCd.GetGenChikuCdByAddress(addr);
                }

                // 現地区コードから管轄保健所コードを取得する
                {
                    hokenjoCd = GetHokenjoCdByGenChikuCd(genChikuCd);
                }

                return hokenjoCd;
            }
            #endregion

            #region GetHokenjoCdByZipCd
            /// <summary>
            /// 
            /// </summary>
            /// <param name="addr"></param>
            /// <returns></returns>
            public static string GetHokenjoCdByZipCd(string zipCd)
            {
                string genChikuCd = string.Empty;
                string hokenjoCd = string.Empty;

                // 郵便番号から現地区コードを取得する
                {
                    genChikuCd = GenChikuCd.GetGenChikuCdByZipCd(zipCd);
                }

                // 現地区コードから管轄保健所コードを取得する
                {
                    hokenjoCd = GetHokenjoCdByGenChikuCd(genChikuCd);
                }

                return hokenjoCd;
            }
            #endregion

            #region GetHokenjoCdByGenChikuCd
            /// <summary>
            /// 
            /// </summary>
            /// <param name="genChikuCd"></param>
            /// <returns></returns>
            public static string GetHokenjoCdByGenChikuCd(string genChikuCd)
            {
                string hokenjoCd = string.Empty;

                // 現地区コードから管轄保健所コードを取得する
                {
                    ChikuMstDataSet.ChikuMstDataTable templateTable = new ChikuMstDataSet.ChikuMstDataTable();

                    IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                    input.DataTableType = typeof(ChikuMstDataSet.ChikuMstDataTable);
                    input.TableAdapterType = typeof(ChikuMstTableAdapter);
                    input.Query.AddLikeCond(templateTable.GappeigoChikuCdColumn.ColumnName, genChikuCd);

                    IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);
                    if (output.GetDataTable.Rows.Count > 0)
                    {
                        hokenjoCd = (string)output.GetDataTable.Rows[0][templateTable.KankatsuHokenjoCdColumn.ColumnName];
                    }
                }

                return hokenjoCd;
            }
            #endregion

            #region SetStdHokenjoCdChanged
            /// <summary>
            /// 
            /// </summary>
            /// <param name="targetAdrControl"></param>
            /// <param name="targetHokenjoCdControl"></param>
            /// <param name="overwriteExists"></param>
            public static void SetStdHokenjoCdAdrChanged(TextBox targetAdrControl, TextBox targetHokenjoCdControl, bool overwriteExists)
            {
                targetAdrControl.Leave += delegate(object sender, EventArgs e)
                {
                    string nm = string.Empty;

                    if (!string.IsNullOrEmpty(targetAdrControl.Text.Trim()))
                    {
                        nm = GetHokenjoCdByAddress(targetAdrControl.Text.Trim());
                    }

                    if (string.IsNullOrEmpty(targetHokenjoCdControl.Text) || overwriteExists)
                    {
                        targetHokenjoCdControl.Text = nm;
                    }
                };
            }
            #endregion

            #region SetStdHokenjoCdZipCdChanged
            /// <summary>
            /// 
            /// </summary>
            /// <param name="targetZipCdControl"></param>
            /// <param name="targetHokenjoCdControl"></param>
            /// <param name="overwriteExists"></param>
            public static void SetStdHokenjoCdZipCdChanged(TextBox targetZipCdControl, TextBox targetHokenjoCdControl, bool overwriteExists)
            {
                targetZipCdControl.Leave += delegate(object sender, EventArgs e)
                {
                    string nm = string.Empty;

                    if (!string.IsNullOrEmpty(targetZipCdControl.Text.Trim()))
                    {
                        nm = GetHokenjoCdByZipCd(targetZipCdControl.Text.Trim());
                    }

                    if (string.IsNullOrEmpty(targetHokenjoCdControl.Text) || overwriteExists)
                    {
                        targetHokenjoCdControl.Text = nm;
                    }
                };
            }
            #endregion
        }
        #endregion

    }
}
