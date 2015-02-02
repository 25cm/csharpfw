using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KenchikuyotoDaibunruiMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KenchikuyotoMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KenchikuyotoShobunruiMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.NameMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.ShishoMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.ShokuinMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.ShoriHoshikiMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.TuckSealListDataSetTableAdapters;
using FukjBizSystem.Control;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Utility
{
    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　habu　　    新規作成
    /// </history>
    public class MstUtility
    {
        // NOTICE Master系のCommonは、こちらに順次移設する => 現段階で一旦完了とする

        /// <summary>
        /// 
        /// </summary>
        public enum MstError
        {

        }

        #region Generic

        public class Generic
        {
            #region GetStdMstNm
            /// <summary>
            /// 任意のマスタから、コードを条件に名称を取得する
            /// </summary>
            /// <param name="cdValList"></param>
            /// <param name="cdColNmList"></param>
            /// <param name="nameColNm"></param>
            /// <param name="dataTableType"></param>
            /// <param name="tableAdapterType"></param>
            /// <returns></returns>
            public static string GetStdMstNm(IEnumerable<string> cdValList, IEnumerable<string> cdColNmList, string nameColNm, Type dataTableType, Type tableAdapterType)
            {
                string nm = string.Empty;

                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = dataTableType;
                input.TableAdapterType = tableAdapterType;

                int i = 0;
                int condCnt = 0;
                foreach (string cd in cdValList)
                {
                    if (!string.IsNullOrEmpty(cd))
                    {
                        // add mst get cond(cd)
                        input.Query.AddEqualCond(cdColNmList.ElementAt(i), cd);
                        // add cond count
                        condCnt++;
                    }

                    i++;
                }

                // if all of cd text set, execute select mst query
                if (condCnt == cdColNmList.Count())
                {
                    IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                    if (output.GetDataTable.Rows.Count > 0)
                    {
                        nm = (string)output.GetDataTable.Rows[0][nameColNm];
                    }
                }

                return nm;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="cdValList"></param>
            /// <param name="cdColNmList"></param>
            /// <param name="nameColNm"></param>
            /// <param name="dataTableType"></param>
            /// <param name="tableAdapterType"></param>
            /// <returns></returns>
            public static string GetStdMstNm(string cdVal, string cdColNm, string nameColNm, Type dataTableType, Type tableAdapterType)
            {
                return GetStdMstNm(
                    new string[] { cdVal }
                    , new string[] { cdColNm }
                    , nameColNm
                    , dataTableType
                    , tableAdapterType);
            }
            #endregion

            #region SetStdMstCdChanged
            #region SetStdMstCdChanged
            /// <summary>
            /// コード変更時の名称取得メソッドをコントロールに設定する
            /// </summary>
            /// <param name="targetCdControl">(list or array of )mst cd control</param>
            /// <param name="targetNmControl">mst name control</param>
            /// <param name="overwriteExists">if true, overwrite existing mst name value</param>
            /// <history>
            /// 日付　　　　担当者　　　内容
            /// 2014/10/17  habu　　    新規作成
            /// 2014/12/20  habu　　    複数名称に対応
            /// </history>
            public static void SetStdMstCdChanged(IEnumerable<TextBox> targetCdControlList, IEnumerable<TextBox> targetNmControlList, IEnumerable<string> cdColNmList, IEnumerable<string> nameColNmList, Type dataTableType, Type tableAdapterType, bool overwriteExists)
            {
                EventHandler changeEvent = delegate(object sender, EventArgs e)
                {
                    string nm = string.Empty;

                    IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                    input.DataTableType = dataTableType;
                    input.TableAdapterType = tableAdapterType;

                    int i = 0;
                    int condCnt = 0;
                    foreach (TextBox targetCdControl in targetCdControlList)
                    {
                        if (!string.IsNullOrEmpty(targetCdControl.Text))
                        {
                            // add mst get cond(cd)
                            input.Query.AddEqualCond(cdColNmList.ElementAt(i), targetCdControl.Text);
                            // add cond count
                            condCnt++;
                        }

                        i++;
                    }

                    // if all of cd text set, execute select mst query
                    if (condCnt == cdColNmList.Count())
                    {
                        IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                        if (output.GetDataTable.Rows.Count > 0)
                        {
                            nm = string.Empty;
                            string nameColNm = string.Empty;
                            int j = 0;
                            foreach (TextBox targetNmControl in targetNmControlList)
                            {
                                nameColNm = nameColNmList.ElementAt(j);
                                nm = (string)output.GetDataTable.Rows[0][nameColNm];

                                if (string.IsNullOrEmpty(targetNmControl.Text) || overwriteExists)
                                {
                                    targetNmControl.Text = nm;
                                }
                                j++;
                            }
                        }
                    }
                };

                foreach (TextBox targetCdControl in targetCdControlList)
                {
                    targetCdControl.Leave += changeEvent;
                }

                foreach (TextBox targetNmControl in targetNmControlList)
                {
                    // 自動的に名称コントロールをReadOnlyにする 
                    if (targetNmControl is ZTextBox)
                    {
                        (targetNmControl as ZTextBox).CustomReadOnly = true;
                    }
                    else
                    {
                        targetNmControl.ReadOnly = true;
                    }
                }
            }
            #endregion

            #region SetStdMstCdChanged
            /// <summary>
            /// 
            /// </summary>
            /// <param name="targetCdControl"></param>
            /// <param name="targetNmControl"></param>
            /// <param name="overwriteExists"></param>
            /// <history>
            /// 日付　　　　担当者　　　内容
            /// 2014/10/17  habu　　    新規作成
            /// </history>
            public static void SetStdMstCdChanged(TextBox targetCdControl, TextBox targetNmControl, string cdColNm, string nameColNm, Type dataTableType, Type tableAdapterType, bool overwriteExists)
            {
                SetStdMstCdChanged(
                    new TextBox[] { targetCdControl }
                    , new TextBox[] { targetNmControl }
                    , new string[] { cdColNm }
                    , new string[] { nameColNm }
                    , dataTableType
                    , tableAdapterType
                    , overwriteExists);
            }
            #endregion
            #endregion
        }

        #endregion

        #region NameMst
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class NameMst
        {
            #region GetNameTable
            /// <summary>
            /// 
            /// </summary>
            /// <param name="nameKbn"></param>
            /// <returns></returns>
            /// <history>
            /// 日付　　　　担当者　　　内容
            /// 2014/10/17  habu　　    新規作成
            /// 2014/12/03  habu　　    Utilityに移設
            /// 2014/12/03  habu　　    DeleteFlg追加
            /// </history>
            public static NameMstDataSet.NameMstDataTable GetNameTable(string nameKbn, bool includeDeleted)
            {
                NameMstDataSet.NameMstDataTable template = new NameMstDataSet.NameMstDataTable();

                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(NameMstDataSet.NameMstDataTable);
                input.TableAdapterType = typeof(NameMstTableAdapter);

                if (!string.IsNullOrEmpty(nameKbn)) { input.Query.AddEqualCond(template.NameKbnColumn.ColumnName, nameKbn); }
                if (!includeDeleted)
                {
                    input.Query.AddEqualCond(template.DeleteFlgColumn.ColumnName, Constants.FLG_OFF);
                }

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                return (NameMstDataSet.NameMstDataTable)output.GetDataTable;
            }
            #endregion
        }
        #endregion

        #region ConstMst

        /// <summary>
        /// 
        /// </summary>
        public class ConstMst
        {
            // NOTICE 時期を見て、ConstMstを移設 => 現段階で一旦保留とする
        }

        #endregion

        #region ShishoMst
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class ShishoMst
        {
            #region GetShishoMst
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            /// <history>
            /// 日付　　　　担当者　　　内容
            /// 2014/12/02　habu　　    新規作成
            /// </history>
            public static ShishoMstDataSet.ShishoMstDataTable GetShishoMst()
            {
                ShishoMstDataSet.ShishoMstDataTable template = new ShishoMstDataSet.ShishoMstDataTable();

                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(ShishoMstDataSet.ShishoMstDataTable);
                input.TableAdapterType = typeof(ShishoMstTableAdapter);

                input.Query.AddOrderCol(template.ShishoCdColumn.ColumnName);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                return (ShishoMstDataSet.ShishoMstDataTable)output.GetDataTable;
            }
            #endregion

            #region GetShishoMstExceptJimukyoku
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            /// <history>
            /// 日付　　　　担当者　　　内容
            /// 2015/01/27　宗  　　    新規作成
            /// </history>
            public static ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable GetShishoMstExceptJimukyoku()
            {
                ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable template = new ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable();

                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable);
                input.TableAdapterType = typeof(ShishoMstExceptJimukyokuTableAdapter);

                input.Query.AddOrderCol(template.ShishoCdColumn.ColumnName);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                return (ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable)output.GetDataTable;
            }
            #endregion
        }
        #endregion

        #region ShokuinMst
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class ShokuinMst
        {
            #region GetShokuinMstByShokuinCd
            /// <summary>
            /// 
            /// </summary>
            /// <param name="shokuinCd"></param>
            /// <returns></returns>
            /// <history>
            /// 日付　　　　担当者　　　内容
            /// 2014/10/24　habu　　    新規作成
            /// 2014/12/03  habu　　    Utilityに移設
            /// </history>
            public static ShokuinMstDataSet.ShokuinMstDataTable GetShokuinMstByShokuinCd(string shokuinCd)
            {
                ShokuinMstDataSet.ShokuinMstDataTable template = new ShokuinMstDataSet.ShokuinMstDataTable();

                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(ShokuinMstDataSet.ShokuinMstDataTable);
                input.TableAdapterType = typeof(ShokuinMstTableAdapter);

                if (!string.IsNullOrEmpty(shokuinCd)) { input.Query.AddEqualCond(template.ShokuinCdColumn.ColumnName, shokuinCd); }

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                return (ShokuinMstDataSet.ShokuinMstDataTable)output.GetDataTable;
            }
            #endregion

            #region GetShokuinMstByShishoCd
            /// <summary>
            /// 対象支所の職員を印字順で取得する
            /// (Get By ShishiCd , Order by InjiJun)
            /// </summary>
            /// <param name="shishoCd"></param>
            /// <returns></returns>
            /// <history>
            /// 日付　　　　担当者　　　内容
            /// 2014/10/26　habu　　    新規作成
            /// 2014/12/03  habu　　    Utilityに移設
            /// </history>
            public static ShokuinMstDataSet.ShokuinMstDataTable GetShokuinMstByShishoCd(string shishoCd)
            {
                ShokuinMstDataSet.ShokuinMstDataTable template = new ShokuinMstDataSet.ShokuinMstDataTable();

                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(ShokuinMstDataSet.ShokuinMstDataTable);
                input.TableAdapterType = typeof(ShokuinMstTableAdapter);

                if (!string.IsNullOrEmpty(shishoCd)) { input.Query.AddEqualCond(template.ShokuinShozokuShishoCdColumn.ColumnName, shishoCd); }

                // 20141214 Mod habu 印字順がcharのため、ソート時はintのキャストを行った後にソートする
                input.Query.AddOrderColAsInt(template.ShokuinInjiJunColumn.ColumnName);
                //input.Query.AddOrderCol(template.ShokuinInjiJunColumn.ColumnName);
                input.Query.AddOrderCol(template.ShokuinCdColumn.ColumnName);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                return (ShokuinMstDataSet.ShokuinMstDataTable)output.GetDataTable;
            }
            #endregion

            #region GetShokuinMstKensainByShishoCd
            /// <summary>
            /// 対象支所の職員(検査員)を印字順で取得する
            /// (Get By ShishiCd , Order by InjiJun)
            /// </summary>
            /// <param name="shishoCd"></param>
            /// <returns></returns>
            /// <history>
            /// 日付　　　　担当者　　　内容
            /// 2014/12/26　habu　　    新規作成
            /// </history>
            public static ShokuinMstDataSet.ShokuinMstDataTable GetShokuinMstKensainByShishoCd(string shishoCd)
            {
                ShokuinMstDataSet.ShokuinMstDataTable template = new ShokuinMstDataSet.ShokuinMstDataTable();

                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(ShokuinMstDataSet.ShokuinMstDataTable);
                input.TableAdapterType = typeof(ShokuinMstTableAdapter);

                if (!string.IsNullOrEmpty(shishoCd)) { input.Query.AddEqualCond(template.ShokuinShozokuShishoCdColumn.ColumnName, shishoCd); }

                // 検査員のみを取得対象とする
                input.Query.AddEqualCond(template.ShokuinKensainFlgColumn.ColumnName, Constants.FLG_ON);

                input.Query.AddOrderColAsInt(template.ShokuinInjiJunColumn.ColumnName);
                input.Query.AddOrderCol(template.ShokuinCdColumn.ColumnName);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                return (ShokuinMstDataSet.ShokuinMstDataTable)output.GetDataTable;
            }
            #endregion

            #region GetShokuinMstKensainByShishoCd
            /// <summary>
            /// 対象支所の職員を印字順で取得する(検査員優先)
            /// (Get By ShishiCd , Order by InjiJun)
            /// </summary>
            /// <param name="shishoCd"></param>
            /// <returns></returns>
            /// <history>
            /// 日付　　　　担当者　　　内容
            /// 2014/12/26　habu　　    新規作成
            /// </history>
            public static ShokuinMstDataSet.ShokuinMstDataTable GetShokuinMstByShishoCdOrderKensain(string shishoCd)
            {
                ShokuinMstDataSet.ShokuinMstDataTable template = new ShokuinMstDataSet.ShokuinMstDataTable();

                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(ShokuinMstDataSet.ShokuinMstDataTable);
                input.TableAdapterType = typeof(ShokuinMstTableAdapter);

                if (!string.IsNullOrEmpty(shishoCd)) { input.Query.AddEqualCond(template.ShokuinShozokuShishoCdColumn.ColumnName, shishoCd); }

                // 検査員を優先的に表示対象とする
                input.Query.AddOrderCol(template.ShokuinKensainFlgColumn.ColumnName, false);

                input.Query.AddOrderColAsInt(template.ShokuinInjiJunColumn.ColumnName);
                input.Query.AddOrderCol(template.ShokuinCdColumn.ColumnName);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                return (ShokuinMstDataSet.ShokuinMstDataTable)output.GetDataTable;
            }
            #endregion
        }
        #endregion

        #region GyoshaMst
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class GyoshaMst
        {
            #region SetStdGyoshaSearchButton
            /// <summary>
            /// 
            /// </summary>
            /// <param name="searchButton"></param>
            /// <param name="targetCdControl"></param>
            /// <param name="targetNmControl"></param>
            /// <param name="overwriteExists"></param>
            public static void SetStdGyoshaSearchButton(Button searchButton, TextBox targetCdControl, TextBox targetNmControl, bool overwriteExists)
            {
                searchButton.Click += delegate(object sender, EventArgs e)
                {
                    GyoshaMstSearchForm frm = new GyoshaMstSearchForm();

                    // NOTICE 初期条件を指定できるようにするべきか？(検索項目の調整) => 一旦保留とする
                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        targetCdControl.Text = (string)frm._selectedRow.GyoshaCd;
                        if (targetNmControl != null)
                        {
                            targetNmControl.Text = (string)frm._selectedRow.GyoshaNm;
                        }
                    }
                };
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="searchButton"></param>
            /// <param name="targetCdControl"></param>
            /// <param name="targetNmControl"></param>
            public static void SetStdGyoshaSearchButton(Button searchButton, TextBox targetCdControl, TextBox targetNmControl)
            {
                SetStdGyoshaSearchButton(searchButton, targetCdControl, targetNmControl, true);
            }
            #endregion

            #region SetStdGyoshaCdChanged
            /// <summary>
            /// 
            /// </summary>
            /// <param name="targetCdControl"></param>
            /// <param name="targetNmControl"></param>
            /// <param name="overwriteExists"></param>
            public static void SetStdGyoshaCdChanged(TextBox targetCdControl, TextBox targetNmControl, bool overwriteExists)
            {
                targetCdControl.Leave += delegate(object sender, EventArgs e)
                {
                    string nm = string.Empty;

                    if (!string.IsNullOrEmpty(targetCdControl.Text))
                    {
                        GyoshaMstDataSet.GyoshaMstDataTable template = new GyoshaMstDataSet.GyoshaMstDataTable();

                        IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                        input.DataTableType = typeof(GyoshaMstDataSet.GyoshaMstDataTable);
                        input.TableAdapterType = typeof(DataSet.GyoshaMstDataSetTableAdapters.GyoshaMstTableAdapter);
                        input.Query.AddEqualCond(template.GyoshaCdColumn.ColumnName, targetCdControl.Text);

                        IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                        #region to be removed
                        //ApplicationLogic.Common.GyoshaMstSearch.IKensakuBtnClickALInput input = new ApplicationLogic.Common.GyoshaMstSearch.KensakuBtnClickALInput();
                        //input.GyoshaMstSearchCond = new GyoshaMstSearchCond();
                        //input.GyoshaMstSearchCond.GyoshaCdFrom = targetCdControl.Text;
                        //input.GyoshaMstSearchCond.GyoshaCdTo = targetCdControl.Text;
                        //ApplicationLogic.Common.GyoshaMstSearch.IKensakuBtnClickALOutput output = new ApplicationLogic.Common.GyoshaMstSearch.KensakuBtnClickApplicationLogic().Execute(input);

                        //if (output.GyoshaMstKensakuDT.Count > 0)
                        //{
                        //    nm = output.GyoshaMstKensakuDT[0].GyoshaNm;
                        //}
                        #endregion

                        if (output.GetDataTable.Rows.Count > 0)
                        {
                            nm = ((GyoshaMstDataSet.GyoshaMstDataTable)output.GetDataTable)[0].GyoshaNm;
                        }
                    }

                    if (string.IsNullOrEmpty(targetNmControl.Text) || overwriteExists)
                    {
                        targetNmControl.Text = nm;
                    }
                };

                // 自動的に名称コントロールをReadOnlyにする 
                // NOTICE -> 最終的にこれでいくかは検討 => 使用箇所側での動作確認が取れたので、これで
                if (targetNmControl is ZTextBox)
                {
                    (targetNmControl as ZTextBox).CustomReadOnly = true;
                }
                else
                {
                    targetNmControl.ReadOnly = true;
                }
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="targetCdControl"></param>
            /// <param name="targetNmControl"></param>
            public static void SetStdGyoshaCdChanged(TextBox targetCdControl, TextBox targetNmControl)
            {
                SetStdGyoshaCdChanged(targetCdControl, targetNmControl, true);
            }
            #endregion

        }
        #endregion

        #region KatashikiMst
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// 2014/12/20　habu　　    処理方式を追加
        /// </history>
        public class KatashikiMst
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="searchButton"></param>
            /// <param name="targetCdControl">メーカー業者コード</param>
            /// <param name="targetNmControl">メーカー業者名</param>
            /// <param name="targetCdControl">型式コード</param>
            /// <param name="targetNmControl">型式名</param>
            /// <param name="overwriteExists"></param>
            public static void SetStdKatashikiSearchButton(Button searchButton
                , System.Windows.Forms.Control targetCdControl, TextBox targetNmControl
                , System.Windows.Forms.Control targetCdControl2, TextBox targetNmControl2
                , System.Windows.Forms.Control shoriHoshikiKbnControl, System.Windows.Forms.Control shoriHoshikiCdControl, System.Windows.Forms.Control shoriHoshikiShubetsuControl
                , TextBox shoriHoshikiShubetsuNmControl, TextBox shoriHoshikiNmControl
                , bool overwriteExists)
            {
                searchButton.Click += delegate(object sender, EventArgs e)
                {
                    KatashikiMstSearchForm frm = new KatashikiMstSearchForm();

                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        if (targetCdControl != null)
                        {
                            Common.SetCdControlValue(targetCdControl, frm.MakerGyoshaCd);
                        }
                        if (targetNmControl != null)
                        {
                            targetNmControl.Text = frm.MakerGyoshaNm;
                        }
                        if (targetCdControl2 != null)
                        {
                            Common.SetCdControlValue(targetCdControl2, frm.KatashikiCd);
                        }
                        if (targetNmControl2 != null)
                        {
                            targetNmControl2.Text = frm.KatashikiNm;
                        }
                        if (shoriHoshikiKbnControl != null)
                        {
                            Common.SetCdControlValue(shoriHoshikiKbnControl, frm.ShoriHoshikiKbn);
                        }
                        if (shoriHoshikiCdControl != null)
                        {
                            Common.SetCdControlValue(shoriHoshikiCdControl, frm.ShoriHoshikiCd);
                        }
                        if (shoriHoshikiShubetsuControl!= null)
                        {
                            Common.SetCdControlValue(shoriHoshikiShubetsuControl, frm._ShoriHoshikiShubetsuKbn);
                        }
                        if (shoriHoshikiShubetsuNmControl!= null)
                        {
                            shoriHoshikiShubetsuNmControl.Text = frm._ShoriHoshikiShubetsuNm;
                        }
                        if (shoriHoshikiNmControl != null)
                        {
                            shoriHoshikiNmControl.Text = frm._ShoriHoshikiNm;
                        }
                    }
                };
            }
        }
        #endregion

        #region ShoriHoshikiMst
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　habu　　    新規作成
        /// </history>
        public class ShoriHoshikiMst
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="kbn"></param>
            /// <param name="cd"></param>
            /// <param name="shubetsuKbn"></param>
            /// <returns></returns>
            public static ShoriHoshikiMstDataSet.ShoriHoshikiMstRow GetShoriHoshikiMst(string kbn, string cd, string shubetsuKbn)
            {
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable);
                input.TableAdapterType = typeof(ShoriHoshikiMstTableAdapter);
                if (!string.IsNullOrEmpty(kbn)) { input.Query.AddEqualCond("ShoriHoshikiKbn", kbn); }
                if (!string.IsNullOrEmpty(cd)) { input.Query.AddEqualCond("ShoriHoshikiCd", cd); }
                if (!string.IsNullOrEmpty(shubetsuKbn)) { input.Query.AddEqualCond("ShoriHoshikiShubetsuKbn", shubetsuKbn); }

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count == 0)
                {
                    return null;
                }

                return (ShoriHoshikiMstDataSet.ShoriHoshikiMstRow)output.GetDataTable.Rows[0];
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="searchButton"></param>
            /// <param name="targetCdControl">処理方式区分</param>
            /// <param name="targetCdControl2">処理方式コード</param>
            /// <param name="targetCdControl3">処理方式種別区分</param>
            /// <param name="targetNmControl">処理方式種別名</param>
            /// <param name="targetNmControl2">処理方式名</param>
            /// <param name="overwriteExists"></param>
            public static void SetStdShoriHoshikiSearchButton(Button searchButton, System.Windows.Forms.Control targetCdControl, System.Windows.Forms.Control targetCdControl2, System.Windows.Forms.Control targetCdControl3, TextBox targetNmControl, TextBox targetNmControl2, bool overwriteExists)
            {
                searchButton.Click += delegate(object sender, EventArgs e)
                {
                    ShoriHoshikiMstSearchForm frm = new ShoriHoshikiMstSearchForm();

                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        if (targetCdControl != null)
                        {
                            Common.SetCdControlValue(targetCdControl, frm.ShoriHoshikiKbn);
                        }
                        if (targetCdControl2 != null)
                        {
                            Common.SetCdControlValue(targetCdControl2, frm.ShoriHoshikiCd);
                        }
                        if (targetCdControl3 != null)
                        {
                            Common.SetCdControlValue(targetCdControl3, frm.ShoriHoshikiShubetsu);
                        }
                        if (targetNmControl != null)
                        {
                            targetNmControl.Text = frm.ShoriHoshikiShubetsuNm;
                        }
                        if (targetNmControl2 != null)
                        {
                            targetNmControl2.Text = frm.ShoriHoshikiNm;
                        }
                    }
                };
            }
        }
        #endregion

        #region ChikuMst

        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　habu　　    新規作成
        /// </history>
        public class ChikuMst
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="searchButton"></param>
            /// <param name="oldChikuCdControl"></param>
            /// <param name="genChikuCdControl"></param>
            /// <param name="chikuNmControl"></param>
            /// <param name="overwriteExists"></param>
            public static void SetStdChikuSearchButton(Button searchButton, System.Windows.Forms.Control oldChikuCdControl, System.Windows.Forms.Control genChikuCdControl, TextBox chikuNmControl, bool overwriteExists)
            {
                searchButton.Click += delegate(object sender, EventArgs e)
                {
                    ChikuMstSearchForm frm = new ChikuMstSearchForm();

                    frm.ShowDialog();

                    if (frm.DialogResult == DialogResult.OK)
                    {
                        ChikuMstDataSet.ChikuMstSearchCommonDataTable template = new ChikuMstDataSet.ChikuMstSearchCommonDataTable();

                        if (oldChikuCdControl != null)
                        {
                            Common.SetCdControlValue(oldChikuCdControl, TypeUtility.GetString(frm._selectedRow[template.ChikuCdColumn.ColumnName]));
                        }
                        if (genChikuCdControl != null)
                        {
                            Common.SetCdControlValue(genChikuCdControl, TypeUtility.GetString(frm._selectedRow[template.GappeigoChikuCdColumn.ColumnName]));
                        }
                        if (chikuNmControl != null)
                        {
                            chikuNmControl.Text = TypeUtility.GetString(frm._selectedRow[template.ChikuNmColumn.ColumnName]);
                        }
                    }
                };
            }
        }

        #endregion

        #region KenchikuyotoMst
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　habu　　    新規作成
        /// </history>
        public class KenchikuyotoMst
        {
            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static KenchikuyotoMstDataSet.KenchikuyotoMstKensakuRow GetKenchikuyotoMst(string cd, string cd2, string renban)
            {
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(KenchikuyotoMstDataSet.KenchikuyotoMstDataTable);
                input.TableAdapterType = typeof(KenchikuyotoMstTableAdapter);
                if (!string.IsNullOrEmpty(cd)) { input.Query.AddEqualCond("KenchikuyotoDaibunruiCd", cd); }
                if (!string.IsNullOrEmpty(cd2)) { input.Query.AddEqualCond("KenchikuyotoShobunruiCd", cd2); }
                if (!string.IsNullOrEmpty(renban)) { input.Query.AddEqualCond("KenchikuyotoRenban", renban); }

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count == 0)
                {
                    return null;
                }

                return (KenchikuyotoMstDataSet.KenchikuyotoMstKensakuRow)output.GetDataTable.Rows[0];
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static KenchikuyotoMstDataSet.KenchikuyotoMstDataTable GetKenchikuyotoMst()
            {
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(KenchikuyotoMstDataSet.KenchikuyotoMstDataTable);
                input.TableAdapterType = typeof(KenchikuyotoMstTableAdapter);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count == 0)
                {
                    return new KenchikuyotoMstDataSet.KenchikuyotoMstDataTable();
                }

                return (KenchikuyotoMstDataSet.KenchikuyotoMstDataTable)output.GetDataTable;
            }

            /// <summary>
            /// 
            /// </summary>
            /// <returns></returns>
            public static KenchikuyotoMstDataSet.KenchikuyotoMstKensakuDataTable GetKenchikuyotoMstKensaku()
            {
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(KenchikuyotoMstDataSet.KenchikuyotoMstKensakuDataTable);
                input.TableAdapterType = typeof(KenchikuyotoMstKensakuTableAdapter);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count == 0)
                {
                    return new KenchikuyotoMstDataSet.KenchikuyotoMstKensakuDataTable();
                }

                return (KenchikuyotoMstDataSet.KenchikuyotoMstKensakuDataTable)output.GetDataTable;
            }
        }
        #endregion

        #region KenchikuyotoDaibunruiMst
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　habu　　    新規作成
        /// </history>
        public class KenchikuyotoDaibunruiMst
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="kbn"></param>
            /// <param name="cd"></param>
            /// <param name="shubetsuKbn"></param>
            /// <returns></returns>
            public static KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstRow GetKenchikuyotoDaibunruiMst(string cd)
            {
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstDataTable);
                input.TableAdapterType = typeof(KenchikuyotoDaibunruiMstTableAdapter);
                if (!string.IsNullOrEmpty(cd)) { input.Query.AddEqualCond("KenchikuyotoDaibunruiCd", cd); }

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count == 0)
                {
                    return null;
                }

                return (KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstRow)output.GetDataTable.Rows[0];
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="kbn"></param>
            /// <param name="cd"></param>
            /// <param name="shubetsuKbn"></param>
            /// <returns></returns>
            public static KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstDataTable GetKenchikuyotoDaibunruiMst()
            {
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstDataTable);
                input.TableAdapterType = typeof(KenchikuyotoDaibunruiMstTableAdapter);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count == 0)
                {
                    return new KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstDataTable();
                }

                return (KenchikuyotoDaibunruiMstDataSet.KenchikuyotoDaibunruiMstDataTable)output.GetDataTable;
            }
        }
        #endregion

        #region KenchikuyotoShobunruiMst
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　habu　　    新規作成
        /// </history>
        public class KenchikuyotoShobunruiMst
        {
            /// <summary>
            /// 
            /// </summary>
            /// <param name="kbn"></param>
            /// <param name="cd"></param>
            /// <param name="shubetsuKbn"></param>
            /// <returns></returns>
            public static KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstRow GetKenchikuyotoShobunruiMst(string cd)
            {
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstDataTable);
                input.TableAdapterType = typeof(KenchikuyotoShobunruiMstTableAdapter);
                if (!string.IsNullOrEmpty(cd)) { input.Query.AddEqualCond("KenchikuyotoShobunruiCd", cd); }

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count == 0)
                {
                    return null;
                }

                return (KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstRow)output.GetDataTable.Rows[0];
            }

            /// <summary>
            /// 
            /// </summary>
            /// <param name="kbn"></param>
            /// <param name="cd"></param>
            /// <param name="shubetsuKbn"></param>
            /// <returns></returns>
            public static KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstDataTable GetKenchikuyotoShobunruiMst()
            {
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstDataTable);
                input.TableAdapterType = typeof(KenchikuyotoShobunruiMstTableAdapter);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count == 0)
                {
                    return new KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstDataTable();
                }

                return (KenchikuyotoShobunruiMstDataSet.KenchikuyotoShobunruiMstDataTable)output.GetDataTable;
            }
        }
        #endregion
    }
}
