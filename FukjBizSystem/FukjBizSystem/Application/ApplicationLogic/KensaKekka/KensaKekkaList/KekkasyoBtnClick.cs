using System;
using System.Net;
using System.Reflection;
using System.Text;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.KensaKekka.KensaKekkaList;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KensaKekka.KensaKekkaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKekkasyoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/15  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKekkasyoBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// InsatsuKbn
        /// </summary>
        string InsatsuKbn { get; set; }

        /// <summary>
        /// IsOutputPages 
        /// </summary>
        bool IsOutputPages { get; set; }

        /// <summary>
        /// KensaKekkaListDataTable
        /// </summary>
        KensaKekkaTblDataSet.KensaKekkaListDataTable KensaKekkaListDataTable { get; set; }

        /// <summary>
        /// PrintSuishitsu 
        /// </summary>
        bool PrintSuishitsu { get; set; }

        /// <summary>
        /// IsEdaban 
        /// </summary>
        bool IsEdaban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KekkasyoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/15  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KekkasyoBtnClickALInput : IKekkasyoBtnClickALInput
    {
        /// <summary>
        /// InsatsuKbn
        /// </summary>
        public string InsatsuKbn { get; set; }

        /// <summary>
        /// IsOutputPages 
        /// </summary>
        public bool IsOutputPages { get; set; }

        /// <summary>
        /// KensaKekkaListDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaListDataTable KensaKekkaListDataTable { get; set; }

        /// <summary>
        /// PrintSuishitsu 
        /// </summary>
        public bool PrintSuishitsu { get; set; }

        /// <summary>
        /// IsEdaban 
        /// </summary>
        public bool IsEdaban { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKekkasyoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/15  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKekkasyoBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KekkasyoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/15  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KekkasyoBtnClickALOutput : IKekkasyoBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KekkasyoBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/15  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KekkasyoBtnClickApplicationLogic : BaseApplicationLogic<IKekkasyoBtnClickALInput, IKekkasyoBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKekkaList：KekkasyoBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KekkasyoBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KekkasyoBtnClickApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/15  HuyTX　    新規作成
        /// 2014/11/11  HuyTX　    Ver1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKekkasyoBtnClickALOutput Execute(IKekkasyoBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKekkasyoBtnClickALOutput output = new KekkasyoBtnClickALOutput();

            try
            {
                StartTransaction();

                //MOD_Ver1.07 Start
                //if (input.PrintSuishitsu)
                //{
                //    //print 042
                //    IPrintSuishitsuKensaKekkaShoBLInput printSuishitsuBLInput = new PrintSuishitsuKensaKekkaShoBLInput();
                //    printSuishitsuBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                //    printSuishitsuBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SuishitsuKensaKekkaShoFormatFile;
                //    //printSuishitsuBLInput.AfterDispFlg = true;
                //    printSuishitsuBLInput.AfterPrintFlg = true;

                //    printSuishitsuBLInput.InsatsuKbn = input.InsatsuKbn;
                //    printSuishitsuBLInput.IsOutputPages = input.IsOutputPages;
                //    printSuishitsuBLInput.SuishitsuKensaKekkaInfoDataTable = CreateSuishitsuKensaKekka(input.KensaKekkaListDataTable);

                //    new PrintSuishitsuKensaKekkaShoBusinessLogic().Execute(printSuishitsuBLInput);
                //}
                //else
                //{
                //    //print 003
                //}

                //if (input.InsatsuKbn == "2")
                //{
                IUpdateKensaIraiTblBLInput updateKensaIraiBLInput = new UpdateKensaIraiTblBLInput();
                updateKensaIraiBLInput.KensaIraiTblDataTable = CreateKensaIraiDataTable(input.KensaKekkaListDataTable, input.IsEdaban);
                new UpdateKensaIraiTblBusinessLogic().Execute(updateKensaIraiBLInput);
                //}

                //MOD_Ver1.07 End

                CompleteTransaction();

            }
            catch
            {
                throw;
            }
            finally
            {
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region DEL_20141117_HuyTX (refer to common 000-026)
        //#region CreateSuishitsuKensaKekka
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： CreateSuishitsuKensaKekka
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="kensaKekkaDT"></param>
        ///// <returns></returns>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/10/16  HuyTX　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable CreateSuishitsuKensaKekka(KensaKekkaTblDataSet.KensaKekkaListDataTable kensaKekkaDT)
        //{
        //    KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable suishitsuKensaKekkaDT = new KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoDataTable();
        //    KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoRow[] suishitsuRows;
        //    IGetSuishitsuKensaKekkaInfoBLInput blInput = new GetSuishitsuKensaKekkaInfoBLInput();
        //    IGetSuishitsuKensaKekkaInfoBLOutput blOutput = new GetSuishitsuKensaKekkaInfoBusinessLogic().Execute(blInput);

        //    string kensaIraiHoteiKbn = string.Empty;
        //    string kensaIraiHokenjoCd = string.Empty;
        //    string kensaIraiNendo = string.Empty;
        //    string kensaIraiRenban = string.Empty;

        //    foreach (KensaKekkaTblDataSet.KensaKekkaListRow kensaKekkaRow in kensaKekkaDT)
        //    {
        //        kensaIraiHoteiKbn = kensaKekkaRow.KensaIraiHoteiKbn;
        //        kensaIraiHokenjoCd = kensaKekkaRow.KensaIraiHokenjoCd;
        //        kensaIraiNendo = kensaKekkaRow.KensaIraiNendo;
        //        kensaIraiRenban = kensaKekkaRow.KensaIraiRenban;

        //         suishitsuRows = (KensaKekkaTblDataSet.SuishitsuKensaKekkaInfoRow[])blOutput.SuishitsuKensaKekkaInfoDataTable.Select(string.Format("KensaIraiHoteiKbn = '{0}' AND KensaIraiHokenjoCd = '{1}' AND KensaIraiNendo = '{2}' AND KensaIraiRenban = '{3}'",
        //            new string[] { kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban }));

        //        if (suishitsuRows.Length > 0)
        //        {
        //            suishitsuKensaKekkaDT.ImportRow(suishitsuRows[0]);
        //        }
        //    }

        //    return suishitsuKensaKekkaDT;
        //}

        //#endregion
        #endregion

        #region CreateKensaIraiDataTable
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaKekkaDT"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  HuyTX　    新規作成
        /// 2015/01/22  habu 　    GetAll廃止
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiDataTable(KensaKekkaTblDataSet.KensaKekkaListDataTable kensaKekkaDT, bool isEdaban)
        {
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            #region to be removed
            // 20150122 habu GetAll廃止
            //IGetKensaIraiTblInfoBLInput getKensaIraiBLInput = new GetKensaIraiTblInfoBLInput();
            //IGetKensaIraiTblInfoBLOutput getKensaIraiBLOutput = new GetKensaIraiTblInfoBusinessLogic().Execute(getKensaIraiBLInput);

            //string kensaIraiHoteiKbn = string.Empty;
            //string kensaIraiHokenjoCd = string.Empty;
            //string kensaIraiNendo = string.Empty;
            //string kensaIraiRenban = string.Empty;
            #endregion

            DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

            foreach (KensaKekkaTblDataSet.KensaKekkaListRow kensaKekkaRow in kensaKekkaDT)
            {
                #region to be removed
                //kensaIraiHoteiKbn = kensaKekkaRow.KensaIraiHoteiKbn;
                //kensaIraiHokenjoCd = kensaKekkaRow.KensaIraiHokenjoCd;
                //kensaIraiNendo = kensaKekkaRow.KensaIraiNendo;
                //kensaIraiRenban = kensaKekkaRow.KensaIraiRenban;
                #endregion

                IStdFilteredGetDataBLInput getKensaIraiBLInput = new StdFilteredGetDataBLInput();
                getKensaIraiBLInput.DataTableType = typeof(KensaIraiTblDataSet.KensaIraiTblDataTable);
                getKensaIraiBLInput.TableAdapterType = typeof(KensaIraiTblTableAdapter);

                getKensaIraiBLInput.Query.AddEqualCond(kensaIraiDT.KensaIraiHoteiKbnColumn.ColumnName, kensaKekkaRow.KensaIraiHoteiKbn);
                getKensaIraiBLInput.Query.AddEqualCond(kensaIraiDT.KensaIraiHokenjoCdColumn.ColumnName, kensaKekkaRow.KensaIraiHokenjoCd);
                getKensaIraiBLInput.Query.AddEqualCond(kensaIraiDT.KensaIraiNendoColumn.ColumnName, kensaKekkaRow.KensaIraiNendo);
                getKensaIraiBLInput.Query.AddEqualCond(kensaIraiDT.KensaIraiRenbanColumn.ColumnName, kensaKekkaRow.KensaIraiRenban);

                IStdFilteredGetDataBLOutput getKensaIraiBLOutput = new StdFilteredGetDataBusinessLogic().Execute(getKensaIraiBLInput);

                KensaIraiTblDataSet.KensaIraiTblRow[] kensaIraiRows = (KensaIraiTblDataSet.KensaIraiTblRow[])getKensaIraiBLOutput.GetDataTable.Select(string.Empty);

                #region to be removed
                // 20150122 habu GetAll廃止
                //KensaIraiTblDataSet.KensaIraiTblRow[] kensaIraiRows = (KensaIraiTblDataSet.KensaIraiTblRow[])getKensaIraiBLOutput.KensaIraiTblDataTable.Select(string.Format("KensaIraiHoteiKbn = '{0}' AND KensaIraiHokenjoCd = '{1}' AND KensaIraiNendo = '{2}' AND KensaIraiRenban = '{3}'",
                //   new string[] { kensaIraiHoteiKbn, kensaIraiHokenjoCd, kensaIraiNendo, kensaIraiRenban }));
                #endregion

                if (kensaIraiRows.Length > 0)
                {
                    //Rakkan check
                    if (kensaKekkaRow.UpdateDt != kensaIraiRows[0].UpdateDt)
                    {
                        // 更新されている場合は、他のユーザから更新されていると判断し、楽観ロックエラーで例外を発生
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    //送付日
                    kensaIraiRows[0].KensaIraiSofuDt = currentDateTime.ToString("yyyyMMdd");

                    //結果書発行区分
                    kensaIraiRows[0].KensaIraiKekkashoHakkoKbn = "1";

                    //ステータス区分
                    kensaIraiRows[0].KensaIraiStatusKbn = "80";

                    //ADD_Ver.106 start

                    if (isEdaban)
                    {
                        //結果書印刷回数
                        kensaIraiRows[0].KensaIraiKekkashoInsatsuCnt = kensaIraiRows[0].IsKensaIraiKekkashoInsatsuCntNull() ? 1 : kensaIraiRows[0].KensaIraiKekkashoInsatsuCnt + 1;
                    }

                    //ADD_Ver.106 end

                    //更新日
                    kensaIraiRows[0].UpdateDt = currentDateTime;

                    //更新者
                    kensaIraiRows[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    //更新端末
                    kensaIraiRows[0].UpdateTarm = Dns.GetHostName();

                    kensaIraiDT.ImportRow(kensaIraiRows[0]);
                }
            }

            return kensaIraiDT;
        }
        #endregion

        #endregion

    }
    #endregion
}
