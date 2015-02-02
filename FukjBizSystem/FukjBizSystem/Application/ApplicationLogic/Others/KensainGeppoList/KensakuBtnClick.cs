using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.ShokuinMstShosai;
using FukjBizSystem.Application.BusinessLogic.Others.KensainGeppoList;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShokuinMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.KensainGeppoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput, IGetKensainGeppoListBySearchCondBLInput
    {
        /// <summary>
        /// 集計処理区分
        /// </summary>
        string ShoriKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// 対象範囲（開始）
        /// </summary>
        public string TaisyoYMFrom { get; set; }

        /// <summary>
        /// 対象範囲（終了）
        /// </summary>
        public string TaisyoYMTo { get; set; }

        /// <summary>
        /// 支所CD
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 集計処理区分
        /// </summary>
        public string ShoriKbn { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("対象範囲（開始）[{0}], 対象範囲（終了）[{1}], 支所CD[{2}], 集計処理区分[{3}]",
                    new string[] { 
                        TaisyoYMFrom,
                        TaisyoYMTo,
                        ShishoCd,
                        ShoriKbn,
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput : IGetKensainGeppoListBySearchCondBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KensainGeppoListDataTable
        /// </summary>
        public KensainGeppoTblDataSet.KensainGeppoListDataTable KensainGeppoListDT { get; set; }

        /// <summary>
        /// KensainGeppoTblDataTable
        /// </summary>
        public KensainGeppoTblDataSet.KensainGeppoTblDataTable KensainGeppoTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensainGeppoList：KensakuBtnClickApplicationLogic";

        /// <summary>
        /// LoginUser
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// pcUpdate
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensakuBtnClickApplicationLogic()
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
        /// 2014/08/18  DatNT　  新規作成
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
        /// 2014/08/18  DatNT　  新規作成
        /// 2014/12/22  habu　  Fixed sum process
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                StartTransaction();

                // List ShukeiNengetsu
                //List<string> listNengetsu = GetListShukeiNengetsu(input);

                // List ShukeiNengetsu & KensainCd for insert
                List<string> listNengetsuKensainCdInsert = new List<string>();

                List<string> targetYMList = new List<string>();
                DateTime dtTargetYMFrom = DateTime.ParseExact(input.TaisyoYMFrom, "yyyyMM", null);
                DateTime dtTargetYMTo = DateTime.ParseExact(input.TaisyoYMTo, "yyyyMM", null);

                // 月報作成対象年月(未作成のみ指定の場合は、後処理で作成対象から除外する)
                for (int i = 0; dtTargetYMFrom.AddMonths(i) <= dtTargetYMTo; i++)
                {
                    targetYMList.Add(dtTargetYMFrom.AddMonths(i).ToString("yyyyMM"));
                }

                // 月報作成対象職員を取得
                // 職員マスタの内、検査員フラグが1の職員分のレコードを作成対象とする
                ShokuinMstDataSet.ShokuinMstDataTable targetShokuinTbl = new ShokuinMstDataSet.ShokuinMstDataTable();
                {
                    IStdFilteredGetDataBLInput shokuinInput = new StdFilteredGetDataBLInput();
                    shokuinInput.DataTableType = typeof(ShokuinMstDataSet.ShokuinMstDataTable);
                    shokuinInput.TableAdapterType = typeof(ShokuinMstTableAdapter);
                    shokuinInput.Query.AddEqualCond(targetShokuinTbl.ShokuinKensainFlgColumn.ColumnName, Utility.Constants.FLG_ON);

                    IStdFilteredGetDataBLOutput shokuinOutput = new StdFilteredGetDataBusinessLogic().Execute(shokuinInput);

                    targetShokuinTbl = (ShokuinMstDataSet.ShokuinMstDataTable)shokuinOutput.GetDataTable;
                }

                //string kensainCd = string.Empty;

                IGetKensainGeppoListBySearchCondBLInput blInput = new GetKensainGeppoListBySearchCondBLInput();
                blInput.TaisyoYMFrom = input.TaisyoYMFrom;
                blInput.TaisyoYMTo = input.TaisyoYMTo;
                blInput.ShishoCd = input.ShishoCd;
                IGetKensainGeppoListBySearchCondBLOutput blOutput = new GetKensainGeppoListBySearchCondBusinessLogic().Execute(blInput);

                switch (input.ShoriKbn)
                {

                    case "1":

                        #region 未作成月のみ集計

                        //List<string> listNengetsuKensainCd = new List<string>();

                        //List<string> listNengetsuKensainCdFull = new List<string>();

                        // 未作成のみ指定の場合は、作成済みの年月は、処理対象から除外する
                        foreach (KensainGeppoTblDataSet.KensainGeppoListRow row in blOutput.KensainGeppoListDT)
                        {
                            // 作成済みの年月は処理対象から除外する
                            if (targetYMList.Contains(row.ShukeiNengetsu))
                            {
                                targetYMList.Remove(row.ShukeiNengetsu);
                            }
                        }

                        #region to be removed
                        //foreach (KensainGeppoTblDataSet.KensainGeppoListRow row in blOutput.KensainGeppoListDT)
                        //{
                        //    listNengetsuKensainCd.Add(row.KensainCd + "-" + row.ShukeiNengetsu);

                        //    if (kensainCd != row.KensainCd)
                        //    {
                        //        foreach (string nengetsu in listNengetsu)
                        //        {
                        //            listNengetsuKensainCdFull.Add(row.KensainCd + "-" + nengetsu);
                        //        }
                        //    }
                        //    kensainCd = row.KensainCd;
                        //}

                        //foreach (string str in listNengetsuKensainCdFull)
                        //{
                        //    if (!listNengetsuKensainCd.Contains(str))
                        //    {
                        //        listNengetsuKensainCdInsert.Add(str);
                        //    }
                        //}

                        //foreach (string shukeiNengetsu in listNengetsu)
                        //{
                        //    IGetKensainGeppoTblByShukeiNengetsuBLInput blInput = new GetKensainGeppoTblByShukeiNengetsuBLInput();
                        //    blInput.ShukeiNengetsu = shukeiNengetsu;
                        //    IGetKensainGeppoTblByShukeiNengetsuBLOutput blOutput = new GetKensainGeppoTblByShukeiNengetsuBusinessLogic().Execute(blInput);

                        //    if (blOutput.KensainGeppoTblDT == null || blOutput.KensainGeppoTblDT.Count == 0)
                        //    {
                        //        listNengetsuInsert.Add(shukeiNengetsu);
                        //    }
                        //}

                        // KensainCd
                        //IGetKensainCdByKensaDtBLInput getKensainCdInput = new GetKensainCdByKensaDtBLInput();
                        //getKensainCdInput.NippoDtlKensaDtFrom = input.TaisyoYMFrom;
                        //getKensainCdInput.NippoDtlKensaDtTo = input.TaisyoYMTo;
                        //IGetKensainCdByKensaDtBLOutput getKensainCdOutput = new GetKensainCdByKensaDtBusinessLogic().Execute(getKensainCdInput);

                        //if (getKensainCdOutput.NippoDtlKensainCdByKensainDtDT != null && getKensainCdOutput.NippoDtlKensainCdByKensainDtDT.Count > 0)
                        //{
                        //    foreach (NippoDtlTblDataSet.NippoDtlKensainCdByKensainDtRow row in getKensainCdOutput.NippoDtlKensainCdByKensainDtDT)
                        //    {
                        //        listKensainCd.Add(row.NippoDtlKensainCd);
                        //    }
                        //}
                        #endregion

                        // Insert
                        UpdateData(CreateDataUpdate(targetYMList, targetShokuinTbl));
                        //UpdateData(CreateDataUpdate(listNengetsuKensainCdInsert));

                        break;

                        #endregion

                    case "2":

                        #region 対象範囲を再集計

                        // Delete KensainGeppoTbl By ShukeiNengetsu
                        IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLInput deleteInput = new DeleteKensainGeppoTblByShukeiNengetsuBetweenBLInput();
                        deleteInput.ShukeiNengetsuFrom = input.TaisyoYMFrom;
                        deleteInput.ShukeiNengetsuTo = input.TaisyoYMTo;
                        new DeleteKensainGeppoTblByShukeiNengetsuBetweenBusinessLogic().Execute(deleteInput);

                        #region to be removed
                        //// KensainCd
                        //IGetKensainCdByKensaDtBLInput getKensainInput = new GetKensainCdByKensaDtBLInput();
                        //getKensainInput.NippoDtlKensaDtFrom = input.TaisyoYMFrom;
                        //getKensainInput.NippoDtlKensaDtTo = input.TaisyoYMTo;
                        //IGetKensainCdByKensaDtBLOutput getKensainOutput = new GetKensainCdByKensaDtBusinessLogic().Execute(getKensainInput);

                        //foreach (KensainGeppoTblDataSet.KensainGeppoListRow row in blOutput.KensainGeppoListDT)
                        //{
                        //    if (kensainCd != row.KensainCd)
                        //    {
                        //        foreach (string nengetsu in listNengetsu)
                        //        {
                        //            listNengetsuKensainCdInsert.Add(row.KensainCd + "-" + nengetsu);
                        //        }
                        //    }
                        //    kensainCd = row.KensainCd;
                        //}
                        #endregion

                        // Insert
                        UpdateData(CreateDataUpdate(targetYMList, targetShokuinTbl));
                        //UpdateData(CreateDataUpdate(listNengetsuKensainCdInsert));

                        break;

                        #endregion

                    case "3":

                        #region 対象範囲の既作成分を出力

                        break;

                        #endregion

                    default:
                        break;
                }

                // DataTable for display
                IGetKensainGeppoListBySearchCondBLInput displayInput = new GetKensainGeppoListBySearchCondBLInput();
                displayInput.TaisyoYMFrom = input.TaisyoYMFrom;
                displayInput.TaisyoYMTo = input.TaisyoYMTo;
                displayInput.ShishoCd = input.ShishoCd;
                IGetKensainGeppoListBySearchCondBLOutput displayOutput = new GetKensainGeppoListBySearchCondBusinessLogic().Execute(displayInput);

                output.KensainGeppoListDT = displayOutput.KensainGeppoListDT;

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

        #region CreateDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listNengetsuKensainCdInsert"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12  DatNT　  新規作成
        /// 2014/11/05  DatNT   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensainGeppoTblDataSet.KensainGeppoTblDataTable CreateDataUpdate(List<string> targetYMList, ShokuinMstDataSet.ShokuinMstDataTable targetShokuinMst)
        //private KensainGeppoTblDataSet.KensainGeppoTblDataTable CreateDataUpdate(List<string> listNengetsuKensainCdInsert)
        {
            // DateTime now
            DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

            KensainGeppoTblDataSet.KensainGeppoTblDataTable insertDT = new KensainGeppoTblDataSet.KensainGeppoTblDataTable();

            if (targetYMList.Count == 0 || targetShokuinMst.Count == 0)
            {
                return insertDT;
            }
            //if (listNengetsuKensainCdInsert.Count == 0)
            //{
            //    return insertDT;
            //}

            // Create DataTable insert
            foreach (string targetYM in targetYMList)
            {
                // 日報集計結果取得
                IGetGeppoShukeiByNengetsuBLInput shukeiInput = new GetGeppoShukeiByNengetsuBLInput();
                shukeiInput.ShukeiNengetsu = targetYM;
                IGetGeppoShukeiByNengetsuBLOutput shukeiOutput = new GetGeppoShukeiByNengetsuBusinessLogic().Execute(shukeiInput);

                foreach (ShokuinMstDataSet.ShokuinMstRow shokuinRow in targetShokuinMst)
                {
                    string kensainCd = shokuinRow.ShokuinCd;
                    string shukeiNengetsu = targetYM;
                    //string kensainCd = nengetsuCd.Split('-')[0];
                    //string shukeiNengetsu = nengetsuCd.Split('-')[1];

                    KensainGeppoTblDataSet.KensainGeppoTblRow insertRow = insertDT.NewKensainGeppoTblRow();

                    // 集計年月
                    insertRow.ShukeiNengetsu = shukeiNengetsu;

                    // 検査員コード
                    insertRow.KensainCd = kensainCd;

                    // 7条件数 
                    int jo7Cnt = 0;
                    // 7条金額 
                    decimal jo7Amt = 0m;
                    {
                        var sum = from shukeiRow in shukeiOutput.GeoppoShukeiDataTable.AsEnumerable()
                                  where
                                  shukeiRow.KensaNengetsu == targetYM
                                  && shukeiRow.NippoDtlKensainCd == kensainCd
                                  && shukeiRow.NippoDtlKensaSyubetsu == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN
                                  select shukeiRow;

                        if (sum.Count() > 0)
                        {
                            jo7Cnt = TypeUtility.GetInt(sum.ElementAt(0)[shukeiOutput.GeoppoShukeiDataTable.KensaCntColumn]);
                            jo7Amt = TypeUtility.GetDecimal(sum.ElementAt(0)[shukeiOutput.GeoppoShukeiDataTable.KensaAmtColumn]);
                        }
                    }

                    insertRow.Kensa7JoCnt = jo7Cnt;
                    insertRow.Kensa7JoAmt = jo7Amt;

                    // 11条件数
                    int jo11Cnt = 0;
                    // 11条金額
                    decimal jo11Amt = 0m;
                    {
                        var sum = from shukeiRow in shukeiOutput.GeoppoShukeiDataTable.AsEnumerable()
                                  where
                                  shukeiRow.KensaNengetsu == targetYM
                                  && shukeiRow.NippoDtlKensainCd == kensainCd
                                  && shukeiRow.NippoDtlKensaSyubetsu == Utility.Constants.HoteiKbnConstant.HOTEI_KBN_11JO_GAIKAN
                                  select shukeiRow;

                        if (sum.Count() > 0)
                        {
                            jo11Cnt = TypeUtility.GetInt(sum.ElementAt(0)[shukeiOutput.GeoppoShukeiDataTable.KensaCntColumn]);
                            jo11Amt = TypeUtility.GetDecimal(sum.ElementAt(0)[shukeiOutput.GeoppoShukeiDataTable.KensaAmtColumn]);
                        }
                    }

                    insertRow.Kensa11JoCnt = jo11Cnt;
                    insertRow.Kensa11JoAmt = jo11Amt;

                    // 稼働日数
                    int kadouDateCnt = 0;
                    {
                        var sum = from shukeiRow in shukeiOutput.GeoppoShukeiKadouDataTable.AsEnumerable()
                                  where
                                  shukeiRow.KensaNengetsu == targetYM
                                  && shukeiRow.NippoKensainCd == kensainCd
                                  select shukeiRow;

                        if (sum.Count() > 0)
                        {
                            kadouDateCnt = TypeUtility.GetInt(sum.ElementAt(0)[shukeiOutput.GeoppoShukeiKadouDataTable.KadouDateCntColumn]);
                        }
                    }

                    insertRow.KadoNissu = kadouDateCnt;

                    #region to be removed
                    //// 7条件数 
                    //IGetCountByKensaSyubetsuKensaDtBLInput kensa7joCntInput = new GetCountByKensaSyubetsuKensaDtBLInput();
                    //kensa7joCntInput.NippoDtlKensaSyubetsu = "1";
                    //kensa7joCntInput.NippoDtlKensaDt = shukeiNengetsu;
                    //insertRow.Kensa7JoCnt = new GetCountByKensaSyubetsuKensaDtBusinessLogic().Execute(kensa7joCntInput).KensaCnt;

                    //// 7条金額 
                    //IGetSumBySyubetsuKensainCdKensaDtBLInput kensa7joAmtInput = new GetSumBySyubetsuKensainCdKensaDtBLInput();
                    //kensa7joAmtInput.NippoDtlKensaSyubetsu = "1";
                    //kensa7joAmtInput.NippoDtlKensainCd = kensainCd;
                    //kensa7joAmtInput.NippoDtlKensaDt = shukeiNengetsu;
                    //insertRow.Kensa7JoAmt = new GetSumBySyubetsuKensainCdKensaDtBusinessLogic().Execute(kensa7joAmtInput).KensaAmt;

                    //// 11条件数 
                    //IGetCountByKensaSyubetsuKensaDtBLInput kensa11joCntInput = new GetCountByKensaSyubetsuKensaDtBLInput();
                    //kensa11joCntInput.NippoDtlKensaSyubetsu = "2";
                    //kensa11joCntInput.NippoDtlKensaDt = shukeiNengetsu;
                    //insertRow.Kensa11JoCnt = new GetCountByKensaSyubetsuKensaDtBusinessLogic().Execute(kensa11joCntInput).KensaCnt;

                    //// 11条金額
                    //IGetSumBySyubetsuKensainCdKensaDtBLInput kensa11joAmtInput = new GetSumBySyubetsuKensainCdKensaDtBLInput();
                    //kensa11joAmtInput.NippoDtlKensaSyubetsu = "2";
                    //kensa11joAmtInput.NippoDtlKensainCd = kensainCd;
                    //kensa11joAmtInput.NippoDtlKensaDt = shukeiNengetsu;
                    //insertRow.Kensa11JoAmt = new GetSumBySyubetsuKensainCdKensaDtBusinessLogic().Execute(kensa11joAmtInput).KensaAmt;

                    //// 稼働日数
                    //IGetKensainDtByShukeiNengetsuBLInput kadoNissuInput = new GetKensainDtByShukeiNengetsuBLInput();
                    //kadoNissuInput.ShukeiNengetsu = shukeiNengetsu;
                    //IGetKensainDtByShukeiNengetsuBLOutput kadoNissuOutput = new GetKensainDtByShukeiNengetsuBusinessLogic().Execute(kadoNissuInput);
                    //if (kadoNissuOutput.NippoDtlKensaDtByShukeiNengetsuDT != null && kadoNissuOutput.NippoDtlKensaDtByShukeiNengetsuDT.Count > 0)
                    //{
                    //    insertRow.KadoNissu = kadoNissuOutput.NippoDtlKensaDtByShukeiNengetsuDT.Count;
                    //}
                    //else
                    //{
                    //    insertRow.KadoNissu = 0;
                    //}
                    #endregion

                    // 20141221 habu avoid query in each loop
                    insertRow.YakushokuFlg = shokuinRow.ShokuinShukeiJogaiFlg;

                    #region to be removed
                    //// 2014/11/05 DatNT v1.02 ADD Start
                    //// 役職フラグ
                    //IGetShokuinMstByKeyBLInput shokuinInput = new GetShokuinMstByKeyBLInput();
                    //shokuinInput.ShokuinCd = kensainCd;
                    //insertRow.YakushokuFlg = new GetShokuinMstByKeyBusinessLogic().Execute(shokuinInput).ShokuinMstDT[0].ShokuinShukeiJogaiFlg;
                    //// 2014/11/05 DatNT v1.02 ADD End
                    #endregion
                    // 20141221 End

                    // 退職済み、かつ当月の稼働日数が0日の場合は、除外する
                    if (shokuinRow.ShokuinTaishokuFlg == Utility.Constants.FLG_ON
                        && insertRow.KadoNissu == 0)
                    {
                        continue;
                    }

                    // 登録日
                    insertRow.InsertDt = now;

                    // 登録者
                    insertRow.InsertUser = loginUser;

                    // 登録端末
                    insertRow.InsertTarm = pcUpdate;

                    // 更新日
                    insertRow.UpdateDt = now;

                    // 更新者
                    insertRow.UpdateUser = loginUser;

                    // 更新端末
                    insertRow.UpdateTarm = pcUpdate;

                    insertDT.AddKensainGeppoTblRow(insertRow);
                    insertRow.AcceptChanges();
                    insertRow.SetAdded();
                }
            }

            return insertDT;
        }
        #endregion

        //#region GetListShukeiNengetsu
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： GetListShukeiNengetsu
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="listKensainCd"></param>
        ///// <param name="listNengetsu"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/09/12  DatNT　  新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private List<string> GetListShukeiNengetsu(IKensakuBtnClickALInput input)
        //{
        //    List<string> listNengetsu = new List<string>();

        //    int yearFrom = Convert.ToInt32(input.TaisyoYMFrom.Substring(0, 4));
        //    int monthFrom = Convert.ToInt32(input.TaisyoYMFrom.Substring(4, 2));
        //    int yearTo = Convert.ToInt32(input.TaisyoYMTo.Substring(0, 4));
        //    int monthTo = Convert.ToInt32(input.TaisyoYMTo.Substring(4, 2));

        //    if (yearFrom == yearTo)
        //    {
        //        for (int i = monthFrom; i <= monthTo; i++)
        //        {
        //            listNengetsu.Add(yearFrom + string.Empty + ((i < 10) ? ("0" + i) : i.ToString()));
        //        }
        //    }

        //    if (yearFrom < yearTo)
        //    {
        //        for (int i = monthFrom; i <= 12; i++)
        //        {
        //            listNengetsu.Add(yearFrom + string.Empty + ((i < 10) ? ("0" + i) : i.ToString()));
        //        }

        //        for (int j = 1; j <= monthTo; j++)
        //        {
        //            listNengetsu.Add(yearTo + string.Empty + ((j < 10) ? ("0" + j) : j.ToString()));
        //        }
        //    }

        //    return listNengetsu;
        //}
        //#endregion

        #region UpdateData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="insertDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateData(KensainGeppoTblDataSet.KensainGeppoTblDataTable insertDT)
        {
            IUpdateKensainGeppoTblBLInput updateInput = new UpdateKensainGeppoTblBLInput();
            updateInput.KensainGeppoTblDT = insertDT;
            IUpdateKensainGeppoTblBLOutput updateOuput = new UpdateKensainGeppoTblBusinessLogic().Execute(updateInput);
        }
        #endregion

        #endregion

    }
    #endregion
}
