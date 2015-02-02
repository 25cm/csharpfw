using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.KaiinKanri.KaiinNyukin;
using FukjBizSystem.Application.BusinessLogic.Keiri.HenkinShosai;
using FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuList;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.NyukinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// NyukinNo 
        /// </summary>
        string NyukinNo { get; set; }

        /// <summary>
        /// SeikyuNyukinTblListDataTable
        /// </summary>
        SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable SeikyuNyukinTblListDataTable { get; set; }

        /// <summary>
        /// NyukinmotoKbn
        /// </summary>
        string NyukinmotoKbn { get; set; }

        /// <summary>
        /// JokasoRow 
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstSearchRow JokasoRow { get; set; }

        /// <summary>
        /// GyoshaCd 
        /// </summary>
        string GyoshaCd { get; set; }

        /// <summary>
        /// ZeikaiKurikoshi
        /// </summary>
        decimal ZeikaiKurikoshi { get; set; }

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// SeikyuDtlTblDataTableLoad 
        ///// </summary>
        //SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDataTableLoad { get; set; }

        ///// <summary>
        ///// SeikyuHdrTblDataTableLoad
        ///// </summary>
        //SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDataTableLoad { get; set; }

        ///// <summary>
        ///// KurikoshiKinTblDataTable
        ///// </summary>
        //KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTableLoad { get; set; }

        ///// <summary>
        ///// KensaIraiTblDataTable
        ///// </summary>
        //KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTableLoad { get; set; }

        ///// <summary>
        ///// YoshiHanbaiHdrTblDataTableLoad
        ///// </summary>
        //YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable YoshiHanbaiHdrTblDataTableLoad { get; set; }

        ///// <summary>
        ///// NenKaihiTblDataTableLoad 
        ///// </summary>
        //NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblDataTableLoad { get; set; }
        // 2014.12.27 toyoda Delete End
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALInput : IDeleteBtnClickALInput
    {
        /// <summary>
        /// NyukinNo 
        /// </summary>
        public string NyukinNo { get; set; }

        /// <summary>
        /// SeikyuNyukinTblListDataTable
        /// </summary>
        public SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable SeikyuNyukinTblListDataTable { get; set; }

        /// <summary>
        /// NyukinmotoKbn
        /// </summary>
        public string NyukinmotoKbn { get; set; }

        /// <summary>
        /// JokasoRow 
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstSearchRow JokasoRow { get; set; }

        /// <summary>
        /// GyoshaCd 
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// ZeikaiKurikoshi
        /// </summary>
        public decimal ZeikaiKurikoshi { get; set; }

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// SeikyuDtlTblDataTableLoad 
        ///// </summary>
        //public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDataTableLoad { get; set; }

        ///// <summary>
        ///// SeikyuHdrTblDataTableLoad
        ///// </summary>
        //public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDataTableLoad { get; set; }

        ///// <summary>
        ///// KurikoshiKinTblDataTable
        ///// </summary>
        //public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTableLoad { get; set; }

        ///// <summary>
        ///// KensaIraiTblDataTable
        ///// </summary>
        //public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTableLoad { get; set; }

        ///// <summary>
        ///// YoshiHanbaiHdrTblDataTableLoad
        ///// </summary>
        //public YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable YoshiHanbaiHdrTblDataTableLoad { get; set; }

        ///// <summary>
        ///// NenKaihiTblDataTableLoad 
        ///// </summary>
        //public NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblDataTableLoad { get; set; }
        // 2014.12.27 toyoda Delete End

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("入金No[{0}]", NyukinNo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
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
        private const string FunctionName = "NyukinShosai：DeleteBtnClick";

        /// <summary>
        /// loginUser 
        /// </summary>
        private string _loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// loginTarm 
        /// </summary>
        private string _loginTarm = Dns.GetHostName();

        /// <summary>
        /// currentDateTime 
        /// </summary>
        private DateTime _currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/14  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteBtnClickApplicationLogic()
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
        /// 2014/12/14  HuyTX　    新規作成
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
        /// 2014/12/14  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteBtnClickALOutput Execute(IDeleteBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnClickALOutput output = new DeleteBtnClickALOutput();

            try
            {
                StartTransaction();

                string kensaHoteiKbn = string.Empty;
                string kensaHokenjoCd = string.Empty;
                string kensaNendo = string.Empty;
                string kensaRenban = string.Empty;
                KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTblDT = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable yoshiHanbaiHdrTblDT = new YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable();
                NenKaihiTblDataSet.NenKaihiTblDataTable nenKaihiTblDT = new NenKaihiTblDataSet.NenKaihiTblDataTable();

                //delete NyukinTbl
                IDeleteNyukinTblByKeyBLInput delNyukinTblInput = new DeleteNyukinTblByKeyBLInput();
                delNyukinTblInput.NyukinNo = input.NyukinNo;
                new DeleteNyukinTblByKeyBusinessLogic().Execute(delNyukinTblInput);

                IDeleteSeikyuNyukinTblByKeyBLInput delSeikyuNyukinTblInput;

                // 2014.12.26 toyoda Mod Start
                //SeikyuDtlTblDataSet.SeikyuDtlTblRow[] seikyuDtlLoadRows;
                SeikyuDtlTblDataSet.SeikyuDtlTblDataTable seikyuDtlLoadRows;
                // 2014.12.26 toyoda Mod End

                SeikyuDtlTblDataSet.SeikyuDtlTblDataTable seikyuDtlDT = new SeikyuDtlTblDataSet.SeikyuDtlTblDataTable();

                foreach (SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow seikyuNyukinTblListRow in input.SeikyuNyukinTblListDataTable.Rows)
                {
                    //delete SeikyuNyukinTbl
                    delSeikyuNyukinTblInput = new DeleteSeikyuNyukinTblByKeyBLInput();
                    delSeikyuNyukinTblInput.SeikyuNo = seikyuNyukinTblListRow.shishoNoCol;
                    delSeikyuNyukinTblInput.SeikyuRenban = seikyuNyukinTblListRow.renbanCol;
                    delSeikyuNyukinTblInput.NyukinNo = input.NyukinNo;
                    new DeleteSeikyuNyukinTblByKeyBusinessLogic().Execute(delSeikyuNyukinTblInput);

                    // 2014.12.26 toyoda Mod Start
                    //seikyuDtlLoadRows = null;
                    //seikyuDtlLoadRows = (SeikyuDtlTblDataSet.SeikyuDtlTblRow[])input.SeikyuDtlTblDataTableLoad.Select(string.Format("{0} = '{1}' AND {2} = '{3}'",
                    //    new object[]{input.SeikyuDtlTblDataTableLoad.SeikyuNoColumn.ColumnName,
                    //            seikyuNyukinTblListRow.shishoNoCol,
                    //            input.SeikyuDtlTblDataTableLoad.SeikyuRenbanColumn.ColumnName,
                    //            seikyuNyukinTblListRow.renbanCol}));
                    IGetSeikyuDtlTblByKeyBLInput seikyuDtlInput = new GetSeikyuDtlTblByKeyBLInput();
                    seikyuDtlInput.SeikyuNo = seikyuNyukinTblListRow.shishoNoCol;
                    seikyuDtlInput.SeikyuRenban = seikyuNyukinTblListRow.renbanCol;
                    seikyuDtlLoadRows = new GetSeikyuDtlTblByKeyBusinessLogic().Execute(seikyuDtlInput).SeikyuDtlTblDataTable;
                    // 2014.12.26 toyoda Mod End

                    if (seikyuDtlLoadRows.Count > 0)
                    {
                        #region switch 請求項目区分[SeikyuKomokuKbn]

                        switch (seikyuNyukinTblListRow.seikyuKomokuKbnCol)
                        {
                            case "1":
                                #region 請求項目区分[SeikyuKomokuKbn]=1:検査手数料
                                kensaHoteiKbn = !seikyuDtlLoadRows[0].IsKensaIraiHoteiKbnNull() ? seikyuDtlLoadRows[0].KensaIraiHoteiKbn : string.Empty;
                                kensaHokenjoCd = !seikyuDtlLoadRows[0].IsKensaIraiHokenjoCdNull() ? seikyuDtlLoadRows[0].KensaIraiHokenjoCd : string.Empty;
                                kensaNendo = !seikyuDtlLoadRows[0].IsKensaIraiNendoNull() ? seikyuDtlLoadRows[0].KensaIraiNendo : string.Empty;
                                kensaRenban = !seikyuDtlLoadRows[0].IsKensaIraiRenbanNull() ? seikyuDtlLoadRows[0].KensaIraiRenban : string.Empty;

                                if (!kensaIraiTblDT.Rows.Contains(new string[] { kensaHoteiKbn, kensaHokenjoCd, kensaNendo, kensaRenban }))
                                {
                                    kensaIraiTblDT.Merge(MakeKensaIraiTblUpdate(input, seikyuNyukinTblListRow,
                                                                                    kensaHoteiKbn,
                                                                                    kensaHokenjoCd,
                                                                                    kensaNendo,
                                                                                    kensaRenban));

                                }
                                #endregion
                                break;
                            case "3":
                            case "4":
                            case "7":
                                #region 請求項目区分[SeikyuKomokuKbn]=3:保証登録、4:用紙販売、7:送料
                                if (!yoshiHanbaiHdrTblDT.Rows.Contains(seikyuNyukinTblListRow.YoshiHanbaiNo))
                                {
                                    yoshiHanbaiHdrTblDT.Merge(MakeYoshiHanbaiHdrUpdate(input, seikyuNyukinTblListRow, input.SeikyuNyukinTblListDataTable));
                                }

                                #endregion
                                break;
                            case "5":
                                #region 請求項目区分[SeikyuKomokuKbn]=5:年会費
                                if (!seikyuDtlLoadRows[0].IsNenKaihiNoNull() && !nenKaihiTblDT.Rows.Contains(seikyuDtlLoadRows[0].NenKaihiNo))
                                {
                                    nenKaihiTblDT.Merge(MakeNenKaihiTblUpdate(input, seikyuNyukinTblListRow, seikyuDtlLoadRows[0].NenKaihiNo));
                                }
                                #endregion
                                break;
                            default:
                                break;
                        }

                        #endregion

                        #region SeikyuDtlTblRow

                        seikyuDtlDT.Merge(MakeSeikyuDtlTblUpdate(seikyuNyukinTblListRow, seikyuDtlLoadRows[0]));

                        #endregion
                    }
                }

                //update KensaIraiTbl
                if (kensaIraiTblDT != null && kensaIraiTblDT.Count > 0)
                {
                    IUpdateKensaIraiTblBLInput updateKensaIraiBLInput = new UpdateKensaIraiTblBLInput();
                    updateKensaIraiBLInput.KensaIraiTblDataTable = kensaIraiTblDT;
                    new UpdateKensaIraiTblBusinessLogic().Execute(updateKensaIraiBLInput);
                }

                //update YoshiHanbaiHdrTbl
                if (yoshiHanbaiHdrTblDT != null && yoshiHanbaiHdrTblDT.Count > 0)
                {
                    IUpdateYoshiHanbaiHdrTblBLInput updateYoshiHanbaiBLInput = new UpdateYoshiHanbaiHdrTblBLInput();
                    updateYoshiHanbaiBLInput.YoshiHanbaiHdrTblDataTable = yoshiHanbaiHdrTblDT;
                    new UpdateYoshiHanbaiHdrTblBusinessLogic().Execute(updateYoshiHanbaiBLInput);
                }

                //update NenKaihiTbl
                if (nenKaihiTblDT != null && nenKaihiTblDT.Count > 0)
                {
                    IUpdateNenKaihiTblBLInput updateNenKaihiBLInput = new UpdateNenKaihiTblBLInput();
                    updateNenKaihiBLInput.NenKaihiTblDataTable = nenKaihiTblDT;
                    new UpdateNenKaihiTblBusinessLogic().Execute(updateNenKaihiBLInput);
                }

                //update SeikyuDtlTbl
                IUpdateSeikyuDtlTblBLInput updateSeikyuDtl = new UpdateSeikyuDtlTblBLInput();
                updateSeikyuDtl.SeikyuDtlTblDT = seikyuDtlDT;
                new UpdateSeikyuDtlTblBusinessLogic().Execute(updateSeikyuDtl);

                //update SeikyuHdrTbl
                SeikyuHdrTblDataSet.SeikyuHdrTblDataTable seikyuHdrTblDT = new SeikyuHdrTblDataSet.SeikyuHdrTblDataTable();
                MakeSeikyuHdrTblUpdate(input, seikyuDtlDT, out seikyuHdrTblDT);
                if (seikyuHdrTblDT != null && seikyuHdrTblDT.Count > 0)
                {
                    IUpdateSeikyuHdrTblBLInput updateSeikyuHdrBLInput = new UpdateSeikyuHdrTblBLInput();
                    updateSeikyuHdrBLInput.SeikyuHdrTblDataTable = seikyuHdrTblDT;
                    new UpdateSeikyuHdrTblBusinessLogic().Execute(updateSeikyuHdrBLInput);
                }

                //update KurikoshiKinTbl
                KurikoshiKinTblDataSet.KurikoshiKinTblDataTable kurikoshiKinTblDT;
                MakeKurikoshiKinTblUpdate(input, out kurikoshiKinTblDT);
                if (kurikoshiKinTblDT != null && kurikoshiKinTblDT.Count > 0)
                {
                    IUpdateKurikoshiKinTblBLInput updateKurikoshikinBLInput = new UpdateKurikoshiKinTblBLInput();
                    updateKurikoshikinBLInput.KurikoshiKinTblDataTable = kurikoshiKinTblDT;
                    new UpdateKurikoshiKinTblBusinessLogic().Execute(updateKurikoshikinBLInput);
                }


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

        #region MakeSeikyuDtlTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSeikyuDtlTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seikyuNyukinTblListRow"></param>
        /// <param name="seikyuDtlRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/14　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuDtlTblDataSet.SeikyuDtlTblDataTable MakeSeikyuDtlTblUpdate(SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow seikyuNyukinTblListRow,
                                                                                            SeikyuDtlTblDataSet.SeikyuDtlTblRow seikyuDtlRow)
        {
            IGetSeikyuDtlTblByKeyBLInput getSeikyuDtlInput = new GetSeikyuDtlTblByKeyBLInput();
            getSeikyuDtlInput.SeikyuNo = seikyuNyukinTblListRow.shishoNoCol;
            getSeikyuDtlInput.SeikyuRenban = seikyuNyukinTblListRow.renbanCol;
            IGetSeikyuDtlTblByKeyBLOutput getSeikyuDtlOutput = new GetSeikyuDtlTblByKeyBusinessLogic().Execute(getSeikyuDtlInput);

            if (getSeikyuDtlOutput.SeikyuDtlTblDataTable != null && getSeikyuDtlOutput.SeikyuDtlTblDataTable.Count > 0)
            {
                //Rakkan check
                if (seikyuDtlRow.UpdateDt != getSeikyuDtlOutput.SeikyuDtlTblDataTable[0].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                //入金額合計
                getSeikyuDtlOutput.SeikyuDtlTblDataTable[0].NyukinTotal = seikyuNyukinTblListRow.nyukinTotalCol - seikyuNyukinTblListRow.nyukinWarifuriGakuCol;
                //完済フラグ
                getSeikyuDtlOutput.SeikyuDtlTblDataTable[0].SeikyuKansaiFlg = "0";
                //更新日
                getSeikyuDtlOutput.SeikyuDtlTblDataTable[0].UpdateDt = _currentDateTime;
                //更新者
                getSeikyuDtlOutput.SeikyuDtlTblDataTable[0].UpdateUser = _loginUser;
                //更新端末
                getSeikyuDtlOutput.SeikyuDtlTblDataTable[0].UpdateTarm = _loginTarm;
            }

            return getSeikyuDtlOutput.SeikyuDtlTblDataTable;
        }
        #endregion

        #region MakeSeikyuHdrTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSeikyuHdrTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="seikyuDtlTblDT"></param>
        /// <param name="seikyuHdrTblDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/14　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeSeikyuHdrTblUpdate(IDeleteBtnClickALInput input,
                                            SeikyuDtlTblDataSet.SeikyuDtlTblDataTable seikyuDtlTblDT,
                                            out SeikyuHdrTblDataSet.SeikyuHdrTblDataTable seikyuHdrTblDT)
        {
            IGetSeikyuHdrTblByKeyBLInput getSeikyuHdrInput;
            IGetSeikyuHdrTblByKeyBLOutput getSeikyuHdrOutput;
            
            // 2014.12.26 toyoda Delete Start
            //SeikyuHdrTblDataSet.SeikyuHdrTblRow[] seikyuHdrTblRows;
            // 2014.12.26 toyoda Delete End

            object nyukinTotal = null;
            seikyuHdrTblDT = new SeikyuHdrTblDataSet.SeikyuHdrTblDataTable();
            foreach (SeikyuDtlTblDataSet.SeikyuDtlTblRow seikyuDtlRow in seikyuDtlTblDT)
            {
                if (seikyuHdrTblDT.Rows.Contains(seikyuDtlRow.SeikyuNo)) continue;

                // 2014.12.26 toyoda Delete Start
                //seikyuHdrTblRows = (SeikyuHdrTblDataSet.SeikyuHdrTblRow[])input.SeikyuHdrTblDataTableLoad.Select(string.Format("{0} = '{1}'",
                //                                    input.SeikyuHdrTblDataTableLoad.SeikyuNoColumn.ColumnName, seikyuDtlRow.SeikyuNo));
                // 2014.12.26 toyoda Delete End

                getSeikyuHdrInput = new GetSeikyuHdrTblByKeyBLInput();
                getSeikyuHdrInput.SeikyuNo = seikyuDtlRow.SeikyuNo;
                getSeikyuHdrOutput = new GetSeikyuHdrTblByKeyBusinessLogic().Execute(getSeikyuHdrInput);

                // 2014.12.26 toyoda Mod Start
                //if (seikyuHdrTblRows.Length > 0)
                //{
                //    //Rakkan check
                //    if (seikyuHdrTblRows[0].UpdateDt != getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateDt)
                //    {
                //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                //    }
                //    //入金合計金額 
                //    nyukinTotal = seikyuDtlTblDT.Compute(string.Format("SUM({0})", seikyuDtlTblDT.NyukinTotalColumn.ColumnName),
                //        string.Format("{0} = '{1}'", seikyuDtlTblDT.SeikyuNoColumn.ColumnName, seikyuDtlRow.SeikyuNo));
                //    getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].NyukinTotal = nyukinTotal != null ? Decimal.Parse(nyukinTotal.ToString()) : 0;

                //    //更新日
                //    getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateDt = _currentDateTime;
                //    //更新者
                //    getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateUser = _loginUser;
                //    //更新端末
                //    getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateTarm = _loginTarm;

                //    seikyuHdrTblDT.Merge(getSeikyuHdrOutput.SeikyuHdrTblDataTable);
                //}
                //入金合計金額 
                nyukinTotal = seikyuDtlTblDT.Compute(string.Format("SUM({0})", seikyuDtlTblDT.NyukinTotalColumn.ColumnName),
                    string.Format("{0} = '{1}'", seikyuDtlTblDT.SeikyuNoColumn.ColumnName, seikyuDtlRow.SeikyuNo));
                getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].NyukinTotal = nyukinTotal != null ? Decimal.Parse(nyukinTotal.ToString()) : 0;

                //更新日
                getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateDt = _currentDateTime;
                //更新者
                getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateUser = _loginUser;
                //更新端末
                getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateTarm = _loginTarm;

                seikyuHdrTblDT.Merge(getSeikyuHdrOutput.SeikyuHdrTblDataTable);
                // 2014.12.26 toyoda Mod End
            }
        }
        #endregion

        #region MakeKurikoshiKinTblData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKurikoshiKinTblInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="kurikoshiKinTblDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/14　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeKurikoshiKinTblUpdate(IDeleteBtnClickALInput input, out KurikoshiKinTblDataSet.KurikoshiKinTblDataTable kurikoshiKinTblDT)
        {
            IGetKurikoshiKinTblByKeyBLInput getByKeyInput;
            IGetKurikoshiKinTblByKeyBLOutput getByKeyOutput;
            kurikoshiKinTblDT = new KurikoshiKinTblDataSet.KurikoshiKinTblDataTable();

            // 2014.12.26 toyoda mod Start
            //KurikoshiKinTblDataSet.KurikoshiKinTblRow[] kurikoshiKinTblRows = new KurikoshiKinTblDataSet.KurikoshiKinTblRow[] { };
            KurikoshiKinTblDataSet.KurikoshiKinTblDataTable kurikoshiKinTblRows = new KurikoshiKinTblDataSet.KurikoshiKinTblDataTable();
            // 2014.12.26 toyoda mod End

            if (input.NyukinmotoKbn == "1")
            {
                // 2014.12.26 toyoda mod Start
                //kurikoshiKinTblRows = (KurikoshiKinTblDataSet.KurikoshiKinTblRow[])input.KurikoshiKinTblDataTableLoad.Select(string.Format("{0} = '1' AND {1} = '{2}'",
                //    input.KurikoshiKinTblDataTableLoad.GyosyaKojinKbnColumn.ColumnName,
                //    input.KurikoshiKinTblDataTableLoad.GyosyaCdColumn.ColumnName,
                //    input.GyoshaCd));
                IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput kurikoshiInput = new GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput();
                kurikoshiInput.GyosyaKojinKbn = "1";
                kurikoshiInput.GyoshaCd = input.GyoshaCd;
                kurikoshiKinTblRows = new GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBusinessLogic().Execute(kurikoshiInput).KurikoshiKinTblDataTable;
                // 2014.12.26 toyoda mod End

            }
            else if (input.NyukinmotoKbn == "2")
            {
                // 2014.12.26 toyoda mod Start
                //kurikoshiKinTblRows = (KurikoshiKinTblDataSet.KurikoshiKinTblRow[])input.KurikoshiKinTblDataTableLoad.Select(string.Format("{0} = '2' AND {1} = '{2}' AND {3} = '{4}' AND {5} = '{6}'",
                //    input.KurikoshiKinTblDataTableLoad.GyosyaKojinKbnColumn.ColumnName,
                //    input.KurikoshiKinTblDataTableLoad.JokasoHokenjoCdColumn.ColumnName,
                //    input.JokasoRow.JokasoHokenjoCd,
                //    input.KurikoshiKinTblDataTableLoad.JokasoTorokuNendoColumn.ColumnName,
                //    input.JokasoRow.JokasoTorokuNendo,
                //    input.KurikoshiKinTblDataTableLoad.JokasoRenbanColumn.ColumnName,
                //    input.JokasoRow.JokasoRenban));
                IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput kurikoshiInput = new GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput();
                kurikoshiInput.GyosyaKojinKbn = "2";
                kurikoshiInput.JokasoHokenjoCd = input.JokasoRow.JokasoHokenjoCd;
                kurikoshiInput.JokasoTorokuNendo = input.JokasoRow.JokasoTorokuNendo;
                kurikoshiInput.JokasoRenban = input.JokasoRow.JokasoRenban;
                kurikoshiKinTblRows = new GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBusinessLogic().Execute(kurikoshiInput).KurikoshiKinTblDataTable;
                // 2014.12.26 toyoda mod End
            }

            if (kurikoshiKinTblRows.Count > 0)
            {
                #region make data update
                foreach (KurikoshiKinTblDataSet.KurikoshiKinTblRow kurikoshiKinRow in kurikoshiKinTblRows)
                {
                    if (!kurikoshiKinTblDT.Rows.Contains(kurikoshiKinRow.KurikoshikinNo))
                    {
                        getByKeyInput = new GetKurikoshiKinTblByKeyBLInput();
                        getByKeyInput.KurikoshikinNo = kurikoshiKinRow.KurikoshikinNo;
                        getByKeyOutput = new GetKurikoshiKinTblByKeyBusinessLogic().Execute(getByKeyInput);

                        //Rakkan check
                        if (kurikoshiKinRow.KurikoshikinNo == getByKeyOutput.KurikoshiKinTblDataTable[0].KurikoshikinNo
                            && kurikoshiKinRow.UpdateDt != getByKeyOutput.KurikoshiKinTblDataTable[0].UpdateDt)
                        {
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }

                        //最終更新日
                        getByKeyOutput.KurikoshiKinTblDataTable[0].SaisyuKoshinDt = _currentDateTime.ToString("yyyyMMdd");

                        //繰り越し金
                        getByKeyOutput.KurikoshiKinTblDataTable[0].KurikoshiKin = input.ZeikaiKurikoshi;

                        //更新日
                        getByKeyOutput.KurikoshiKinTblDataTable[0].UpdateDt = _currentDateTime;

                        //更新者
                        getByKeyOutput.KurikoshiKinTblDataTable[0].UpdateUser = _loginUser;

                        //更新端末
                        getByKeyOutput.KurikoshiKinTblDataTable[0].UpdateTarm = _loginTarm;

                        kurikoshiKinTblDT.Merge(getByKeyOutput.KurikoshiKinTblDataTable);
                    }
                }
                #endregion
            }
        }
        #endregion

        #region MakeKensaIraiTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeKensaIraiTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="seikyuNyukinTblListRow"></param>
        /// <param name="kensaHoteiKbn"></param>
        /// <param name="kensaHokenjoCd"></param>
        /// <param name="kensaNendo"></param>
        /// <param name="kensaRenban"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/20　HuyTX    Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable MakeKensaIraiTblUpdate(IDeleteBtnClickALInput input,
                                                                                SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow seikyuNyukinTblListRow,
                                                                                string kensaHoteiKbn,
                                                                                string kensaHokenjoCd,
                                                                                string kensaNendo,
                                                                                string kensaRenban)
        {
            IGetKensaIraiTblByKeyBLInput getKensaIraiInput;
            IGetKensaIraiTblByKeyBLOutput getKensaIraiOutput;

            // 2014.12.26 toyoda Delete Start
            //KensaIraiTblDataSet.KensaIraiTblRow[] kensaIraiTblRows;

            //kensaIraiTblRows = (KensaIraiTblDataSet.KensaIraiTblRow[])input.KensaIraiTblDataTableLoad.Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}' AND {6} = '{7}'",
            //    new string[]{input.KensaIraiTblDataTableLoad.KensaIraiHoteiKbnColumn.ColumnName,
            //                        kensaHoteiKbn,
            //                        input.KensaIraiTblDataTableLoad.KensaIraiHokenjoCdColumn.ColumnName,
            //                        kensaHokenjoCd,
            //                        input.KensaIraiTblDataTableLoad.KensaIraiNendoColumn.ColumnName,
            //                        kensaNendo,
            //                        input.KensaIraiTblDataTableLoad.KensaIraiRenbanColumn.ColumnName,
            //                        kensaRenban}));
            // 2014.12.26 toyoda Delete End

            getKensaIraiInput = new GetKensaIraiTblByKeyBLInput();
            getKensaIraiInput.KensaIraiHoteiKbn = kensaHoteiKbn;
            getKensaIraiInput.KensaIraiHokenjoCd = kensaHokenjoCd;
            getKensaIraiInput.KensaIraiNendo = kensaNendo;
            getKensaIraiInput.KensaIraiRenban = kensaRenban;
            getKensaIraiOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(getKensaIraiInput);

            // 2014.12.26 toyoda Mod Start
            //if (kensaIraiTblRows.Length > 0)
            //{
            //    if (getKensaIraiOutput.KensaIraiTblDataTable != null && getKensaIraiOutput.KensaIraiTblDataTable.Count > 0)
            //    {
            //        //Rakkan check
            //        if (kensaIraiTblRows[0].UpdateDt != getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateDt)
            //        {
            //            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            //        }

            //        //入金済金額 
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinzumiAmt = seikyuNyukinTblListRow.nyukinTotalCol - seikyuNyukinTblListRow.nyukinWarifuriCol;
            //        //入金完了区分 
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinKanryoKbn = "0";
            //        //更新日
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateDt = _currentDateTime;
            //        //更新者
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateUser = _loginUser;
            //        //更新端末
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateTarm = _loginTarm;
            //    }
            //}
            //入金済金額 
            getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinzumiAmt = seikyuNyukinTblListRow.nyukinTotalCol - seikyuNyukinTblListRow.nyukinWarifuriCol;
            //入金完了区分 
            getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinKanryoKbn = "0";
            //更新日
            getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateDt = _currentDateTime;
            //更新者
            getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateUser = _loginUser;
            //更新端末
            getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateTarm = _loginTarm;
            // 2014.12.26 toyoda Mod End

            return getKensaIraiOutput.KensaIraiTblDataTable;
        }
        #endregion

        #region MakeYoshiHanbaiHdrUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeYoshiHanbaiHdrUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="seikyuNyukinTblListRow"></param>
        /// <param name="seikyuNyukinTblListDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/20　HuyTX    Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable MakeYoshiHanbaiHdrUpdate(IDeleteBtnClickALInput input,
                                                                                SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow seikyuNyukinTblListRow,
                                                                                SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable seikyuNyukinTblListDT)
        {
            // 2014.12.26 toyoda Delete Start
            //YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblRow[] yoshiHanbaiHdrRows;
            // 2014.12.26 toyoda Delete End

            IGetYoshiHanbaiHdrTblByKeyBLInput getYoshiHanbaiHdrInput;
            IGetYoshiHanbaiHdrTblByKeyBLOutput getYoshiHanbaiHdrOutput;
            object nyukinWarifuriGakuByYoshiNo = null;

            getYoshiHanbaiHdrInput = new GetYoshiHanbaiHdrTblByKeyBLInput();
            getYoshiHanbaiHdrInput.YoshiHanbaiChumonNo = seikyuNyukinTblListRow.YoshiHanbaiNo;
            getYoshiHanbaiHdrOutput = new GetYoshiHanbaiHdrTblByKeyBusinessLogic().Execute(getYoshiHanbaiHdrInput);

            // 2014.12.26 toyoda Delete Start
            //yoshiHanbaiHdrRows = (YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblRow[])input.YoshiHanbaiHdrTblDataTableLoad.Select(string.Format("{0} = '{1}'",
            //    input.YoshiHanbaiHdrTblDataTableLoad.YoshiHanbaiChumonNoColumn.ColumnName, seikyuNyukinTblListRow.YoshiHanbaiNo));
            // 2014.12.26 toyoda Delete End

            // 2014.12.26 toyoda Mod Start
            //if (yoshiHanbaiHdrRows.Length > 0)
            //{
            //    //Rakkan check
            //    if (yoshiHanbaiHdrRows[0].UpdateDt != getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].UpdateDt)
            //    {
            //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            //    }

            //    nyukinWarifuriGakuByYoshiNo = seikyuNyukinTblListDT.Compute(string.Format("SUM({0})", seikyuNyukinTblListDT.nyukinWarifuriColColumn.ColumnName),
            //        string.Format("{0} = '{1}'", seikyuNyukinTblListDT.YoshiHanbaiNoColumn.ColumnName, seikyuNyukinTblListRow.YoshiHanbaiNo));

            //    //請求金額 
            //    getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku = nyukinWarifuriGakuByYoshiNo != null ? 
            //        getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku - Decimal.Parse(nyukinWarifuriGakuByYoshiNo.ToString())
            //        : getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku;
            //    //完済フラグ 
            //    getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiKansaiFlg = "0";

            //    //更新日
            //    getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].UpdateDt = _currentDateTime;
            //    //更新者
            //    getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].UpdateUser = _loginUser;
            //    //更新端末
            //    getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].UpdateTarm = _loginTarm;
            //}
            nyukinWarifuriGakuByYoshiNo = seikyuNyukinTblListDT.Compute(string.Format("SUM({0})", seikyuNyukinTblListDT.nyukinWarifuriColColumn.ColumnName),
                string.Format("{0} = '{1}'", seikyuNyukinTblListDT.YoshiHanbaiNoColumn.ColumnName, seikyuNyukinTblListRow.YoshiHanbaiNo));

            //請求金額 
            getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku = nyukinWarifuriGakuByYoshiNo != null ?
                getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku - Decimal.Parse(nyukinWarifuriGakuByYoshiNo.ToString())
                : getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku;
            //完済フラグ 
            getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiKansaiFlg = "0";

            //更新日
            getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].UpdateDt = _currentDateTime;
            //更新者
            getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].UpdateUser = _loginUser;
            //更新端末
            getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].UpdateTarm = _loginTarm;
            // 2014.12.26 toyoda Mod End

            return getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable;
        }
        #endregion

        #region MakeNenKaihiTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeNenKaihiTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="seikyuNyukinTblListRow"></param>
        /// <param name="nenKaihiNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/20　HuyTX    Ver1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NenKaihiTblDataSet.NenKaihiTblDataTable MakeNenKaihiTblUpdate(IDeleteBtnClickALInput input,
                                                                                SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow seikyuNyukinTblListRow,
                                                                                string nenKaihiNo)
        {
            IGetNenKaihiTblByKeyBLInput getNenKaihiInput;
            IGetNenKaihiTblByKeyBLOutput getNenKaihiOutput;

            // 2014.12.26 toyoda Delete Start
            //NenKaihiTblDataSet.NenKaihiTblRow[] nenKaihiTblRows;
            // 2014.12.26 toyoda Delete End

            getNenKaihiInput = new GetNenKaihiTblByKeyBLInput();
            getNenKaihiInput.KaihiNo = nenKaihiNo;
            getNenKaihiOutput = new GetNenKaihiTblByKeyBusinessLogic().Execute(getNenKaihiInput);

            // 2014.12.26 toyoda Delete Start
            //nenKaihiTblRows = (NenKaihiTblDataSet.NenKaihiTblRow[])input.NenKaihiTblDataTableLoad.Select(string.Format("{0} = '{1}'",
            //                            input.NenKaihiTblDataTableLoad.KaihiNoColumn.ColumnName, nenKaihiNo));
            // 2014.12.26 toyoda Delete End

            // 2014.12.26 toyoda Mod Start
            //if (nenKaihiTblRows.Length > 0)
            //{
            //    //Rakkan check
            //    if (nenKaihiTblRows[0].UpdateDt != getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateDt)
            //    {
            //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            //    }

            //    //入金金額 
            //    getNenKaihiOutput.NenKaihiTblDataTable[0].NyukinGaku = seikyuNyukinTblListRow.nyukinTotalCol - seikyuNyukinTblListRow.nyukinWarifuriCol;
            //    //更新日
            //    getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateDt = _currentDateTime;
            //    //更新者
            //    getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateUser = _loginUser;
            //    //更新端末
            //    getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateTarm = _loginTarm;
            //}
            //入金金額 
            getNenKaihiOutput.NenKaihiTblDataTable[0].NyukinGaku = seikyuNyukinTblListRow.nyukinTotalCol - seikyuNyukinTblListRow.nyukinWarifuriCol;
            //更新日
            getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateDt = _currentDateTime;
            //更新者
            getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateUser = _loginUser;
            //更新端末
            getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateTarm = _loginTarm;
            // 2014.12.26 toyoda Mod End

            return getNenKaihiOutput.NenKaihiTblDataTable;
        }
        #endregion

        #endregion
    }
    #endregion
}
