using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Keiri;
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
    //  インターフェイス名 ： IUpdateBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        NyukinShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// SeikyuNyukinTblListDataTable
        /// </summary>
        SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable SeikyuNyukinTblListDataTable { get; set; }

        /// <summary>
        /// NyukinTblDataTable
        /// </summary>
        NyukinTblDataSet.NyukinTblDataTable NyukinTblDataTable { get; set; }

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// SeikyuDtlTblDataTableLoad 
        ///// </summary>
        //SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDataTableLoad { get; set; }

        ///// <summary>
        ///// KensaIraiTblDataTableLoad
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

        ///// <summary>
        ///// SeikyuHdrTblDataTableLoad
        ///// </summary>
        //SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDataTableLoad { get; set; }
        // 2014.12.27 toyoda Delete End

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

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// KurikoshiKinTblDataTable
        ///// </summary>
        //KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTableLoad { get; set; }

        ///// <summary>
        ///// SeikyuNyukinTblDataTableLoad 
        ///// </summary>
        //SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable SeikyuNyukinTblDataTableLoad { get; set; }
        // 2014.12.27 toyoda Delete End

        /// <summary>
        /// JikaiKurikoshi 
        /// </summary>
        decimal JikaiKurikoshi { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateBtnClickALInput : IUpdateBtnClickALInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        public NyukinShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// SeikyuNyukinTblListDataTable
        /// </summary>
        public SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable SeikyuNyukinTblListDataTable { get; set; }

        /// <summary>
        /// NyukinTblDataTable
        /// </summary>
        public NyukinTblDataSet.NyukinTblDataTable NyukinTblDataTable { get; set; }

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// SeikyuDtlTblDataTableLoad 
        ///// </summary>
        //public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDataTableLoad { get; set; }

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

        ///// <summary>
        ///// SeikyuHdrTblDataTableLoad
        ///// </summary>
        //public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDataTableLoad { get; set; }
        // 2014.12.27 toyoda Delete End

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

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// KurikoshiKinTblDataTable
        ///// </summary>
        //public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTableLoad { get; set; }

        ///// <summary>
        ///// SeikyuNyukinTblDataTableLoad 
        ///// </summary>
        //public SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable SeikyuNyukinTblDataTableLoad { get; set; }
        // 2014.12.27 toyoda Delete End

        /// <summary>
        /// JikaiKurikoshi 
        /// </summary>
        public decimal JikaiKurikoshi { get; set; }
        
        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("入金No[{0}]", NyukinTblDataTable[0].NyukinNo); ;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateBtnClickALOutput : IUpdateBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateBtnClickApplicationLogic : BaseApplicationLogic<IUpdateBtnClickALInput, IUpdateBtnClickALOutput>
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
        private const string FunctionName = "NyukinShosai：UpdateBtnClick";

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
        //  コンストラクタ名 ： UpdateBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateBtnClickApplicationLogic()
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
        /// 2014/12/10  HuyTX　    新規作成
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
        /// 2014/12/10  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateBtnClickALOutput Execute(IUpdateBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateBtnClickALOutput output = new UpdateBtnClickALOutput();

            try
            {
                StartTransaction();

                SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable seikyuNyukinTblDT;
                SeikyuDtlTblDataSet.SeikyuDtlTblDataTable seikyuDtlDT;
                KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTblDT;
                YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable yoshiHanbaiHdrTblDT;
                NenKaihiTblDataSet.NenKaihiTblDataTable nenKaihiTblDT;
                SeikyuHdrTblDataSet.SeikyuHdrTblDataTable seikyuHdrTblDT;

                CreateSeikyuData(input.SeikyuNyukinTblListDataTable,
                                input.NyukinTblDataTable, input,
                                out seikyuNyukinTblDT,
                                out seikyuDtlDT,
                                out kensaIraiTblDT,
                                out yoshiHanbaiHdrTblDT,
                                out nenKaihiTblDT);

                //mode update
                if (input.DispMode == NyukinShosaiForm.DispMode.Edit)
                {
                    IGetNyukinTblByKeyBLInput getNyukinByKeyInput = new GetNyukinTblByKeyBLInput();
                    getNyukinByKeyInput.NyukinNo = input.NyukinTblDataTable[0].NyukinNo;
                    IGetNyukinTblByKeyBLOutput getNyukinByKeyOutput = new GetNyukinTblByKeyBusinessLogic().Execute(getNyukinByKeyInput);

                    //Rakkan check
                    if (input.NyukinTblDataTable[0].UpdateDt != getNyukinByKeyOutput.NyukinTblDataTable[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }
                    //更新日
                    input.NyukinTblDataTable[0].UpdateDt = _currentDateTime;
                }

                //insert/update NyukinTbl
                IUpdateNyukinTblBLInput updateNyukinBLInput = new UpdateNyukinTblBLInput();
                updateNyukinBLInput.NyukinTblDataTable = input.NyukinTblDataTable;
                new UpdateNyukinTblBusinessLogic().Execute(updateNyukinBLInput);

                //insert/update SeikyuNyukinTbl
                IUpdateSeikyuNyukinTblBLInput updateSeikyuNyukinBLInput = new UpdateSeikyuNyukinTblBLInput();
                updateSeikyuNyukinBLInput.SeikyuNyukinTblDataTable = seikyuNyukinTblDT;
                new UpdateSeikyuNyukinTblBusinessLogic().Execute(updateSeikyuNyukinBLInput);

                //insert/update SeikyuDtlTbl
                IUpdateSeikyuDtlTblBLInput updateSeikyuDtl = new UpdateSeikyuDtlTblBLInput();
                updateSeikyuDtl.SeikyuDtlTblDT = seikyuDtlDT;
                new UpdateSeikyuDtlTblBusinessLogic().Execute(updateSeikyuDtl);

                //insert/update KensaIraiTbl
                if (kensaIraiTblDT != null && kensaIraiTblDT.Count > 0)
                {
                    IUpdateKensaIraiTblBLInput updateKensaIraiBLInput = new UpdateKensaIraiTblBLInput();
                    updateKensaIraiBLInput.KensaIraiTblDataTable = kensaIraiTblDT;
                    new UpdateKensaIraiTblBusinessLogic().Execute(updateKensaIraiBLInput);
                }

                //insert/update YoshiHanbaiHdrTbl
                if (yoshiHanbaiHdrTblDT != null && yoshiHanbaiHdrTblDT.Count > 0)
                {
                    IUpdateYoshiHanbaiHdrTblBLInput updateYoshiHanbaiBLInput = new UpdateYoshiHanbaiHdrTblBLInput();
                    updateYoshiHanbaiBLInput.YoshiHanbaiHdrTblDataTable = yoshiHanbaiHdrTblDT;
                    new UpdateYoshiHanbaiHdrTblBusinessLogic().Execute(updateYoshiHanbaiBLInput);
                }

                //insert/update NenKaihiTbl
                if (nenKaihiTblDT != null && nenKaihiTblDT.Count > 0)
                {
                    IUpdateNenKaihiTblBLInput updateNenKaihiBLInput = new UpdateNenKaihiTblBLInput();
                    updateNenKaihiBLInput.NenKaihiTblDataTable = nenKaihiTblDT;
                    new UpdateNenKaihiTblBusinessLogic().Execute(updateNenKaihiBLInput); 
                }

                //insert/update SeikyuHdrTbl
                MakeSeikyuHdrTblUpdate(input, seikyuDtlDT, out seikyuHdrTblDT);
                if (seikyuHdrTblDT != null && seikyuHdrTblDT.Count > 0)
                {
                    IUpdateSeikyuHdrTblBLInput updateSeikyuHdrBLInput = new UpdateSeikyuHdrTblBLInput();
                    updateSeikyuHdrBLInput.SeikyuHdrTblDataTable = seikyuHdrTblDT;
                    new UpdateSeikyuHdrTblBusinessLogic().Execute(updateSeikyuHdrBLInput);
                }

                //insert/update KurikoshiKinTbl
                KurikoshiKinTblDataSet.KurikoshiKinTblDataTable kurikoshiKinTblDT;
                MakeKurikoshiKinTblData(input, out kurikoshiKinTblDT);
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

        #region CreateSeikyuData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSeikyuData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seikyuNyukinTblListDT"></param>
        /// <param name="nyukinDT"></param>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateSeikyuData(SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable seikyuNyukinTblListDT, 
                                        NyukinTblDataSet.NyukinTblDataTable nyukinDT,
                                        IUpdateBtnClickALInput input,
                                        out SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable seikyuNyukinTblDT,
                                        out SeikyuDtlTblDataSet.SeikyuDtlTblDataTable seikyuDtlDT,
                                        out KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTblDT,
                                        out YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable yoshiHanbaiHdrTblDT,
                                        out NenKaihiTblDataSet.NenKaihiTblDataTable nenKaihiTblDT)
        {
            seikyuNyukinTblDT = new SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable();
            seikyuDtlDT = new SeikyuDtlTblDataSet.SeikyuDtlTblDataTable();
            kensaIraiTblDT = new KensaIraiTblDataSet.KensaIraiTblDataTable();
            yoshiHanbaiHdrTblDT = new YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable();
            nenKaihiTblDT = new NenKaihiTblDataSet.NenKaihiTblDataTable();

            // 2014.12.26 toyoda Mod Start
            //SeikyuDtlTblDataSet.SeikyuDtlTblRow[] seikyuDtlLoadRows;
            SeikyuDtlTblDataSet.SeikyuDtlTblDataTable seikyuDtlLoadRows;
            // 2014.12.26 toyoda Mod End

            string kensaHoteiKbn = string.Empty;
            string kensaHokenjoCd = string.Empty;
            string kensaNendo = string.Empty;
            string kensaRenban = string.Empty;

            foreach (SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow seikyuNyukinTblListRow in seikyuNyukinTblListDT.Rows)
            {
                #region SeikyuNyukinTblRow

                if (input.DispMode == NyukinShosaiForm.DispMode.Add)
                {
                    seikyuNyukinTblDT.Merge(MakeSeikyuNyukinTblInsert(seikyuNyukinTblListRow, nyukinDT[0].NyukinNo));
                }
                else 
                {
                    seikyuNyukinTblDT.Merge(MakeSeikyuNyukinTblUpdate(input, seikyuNyukinTblListRow, nyukinDT[0].NyukinNo));
                }

                #endregion

                // 2014.12.26 toyoda Mod Start
                //seikyuDtlLoadRows = null;
                //seikyuDtlLoadRows = (SeikyuDtlTblDataSet.SeikyuDtlTblRow[])input.SeikyuDtlTblDataTableLoad.Select(string.Format("{0} = '{1}' AND {2} = '{3}'",
                //    new object[]{input.SeikyuDtlTblDataTableLoad.SeikyuNoColumn.ColumnName,
                //                seikyuNyukinTblListRow.shishoNoCol,
                //                input.SeikyuDtlTblDataTableLoad.SeikyuRenbanColumn.ColumnName,
                //                seikyuNyukinTblListRow.renbanCol}));
                IGetSeikyuDtlTblByKeyBLInput seikyuDtlInput = new GetSeikyuDtlTblByKeyBLInput();
                seikyuDtlInput.SeikyuNo = seikyuNyukinTblListRow.shishoNoCol;
                seikyuDtlInput.SeikyuRenban = seikyuNyukinTblListRow.renbanCol;
                seikyuDtlLoadRows = new GetSeikyuDtlTblByKeyBusinessLogic().Execute(seikyuDtlInput).SeikyuDtlTblDataTable;
                // 2014.12.26 toyoda Mod End
                
                if (seikyuDtlLoadRows.Count > 0)
                {
                    #region SeikyuDtlTblRow

                    seikyuDtlDT.Merge(MakeSeikyuDtlTblUpdate(seikyuNyukinTblListRow, seikyuDtlLoadRows[0]));

                    #endregion

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
                                yoshiHanbaiHdrTblDT.Merge(MakeYoshiHanbaiHdrUpdate(input, seikyuNyukinTblListRow, seikyuNyukinTblListDT));
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
                }
            }

        }
        #endregion

        #region MakeSeikyuNyukinTblInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSeikyuNyukinTblInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="seikyuNyukinTblListRow"></param>
        /// <param name="nyukinNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable MakeSeikyuNyukinTblInsert(SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow seikyuNyukinTblListRow, string nyukinNo)
        {
            SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable seikyuNyukinInsert = new SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable();
            SeikyuNyukinTblDataSet.SeikyuNyukinTblRow seikyuNyukinRow;

            seikyuNyukinRow = seikyuNyukinInsert.NewSeikyuNyukinTblRow();

            //請求No
            seikyuNyukinRow.SeikyuNo = seikyuNyukinTblListRow.shishoNoCol;

            //請求連番
            seikyuNyukinRow.SeikyuRenban = seikyuNyukinTblListRow.renbanCol;

            //入金No
            seikyuNyukinRow.NyukinNo = nyukinNo;

            //請求項目区分
            seikyuNyukinRow.SeikyuKomokuKbn = seikyuNyukinTblListRow.seikyuKomokuKbnCol;

            //請求項目名
            seikyuNyukinRow.SeikyuKomokuNm = seikyuNyukinTblListRow.seikyuKamokuCol;

            //請求項目コード
            seikyuNyukinRow.SeikyuKomokuCd = seikyuNyukinTblListRow.seikyuKomokuCdCol;

            //商品名
            seikyuNyukinRow.SeikyuSyohinNm = seikyuNyukinTblListRow.syohinCol;

            //会計科目
            seikyuNyukinRow.KaikeiKamoku = string.Empty;

            //請求金額
            seikyuNyukinRow.SeikyuKingaku = seikyuNyukinTblListRow.seikyuKingakuCol;

            //入金割振金額
            seikyuNyukinRow.NyukinWarifuriGaku = seikyuNyukinTblListRow.nyukinWarifuriCol;

            //会計連動フラグ
            seikyuNyukinRow.KaikeiRendoFlg = "0";

            //登録日
            seikyuNyukinRow.InsertDt = _currentDateTime;

            //登録者
            seikyuNyukinRow.InsertUser = _loginUser;

            //登録端末
            seikyuNyukinRow.InsertTarm = _loginTarm;

            //更新日
            seikyuNyukinRow.UpdateDt = _currentDateTime;

            //更新者
            seikyuNyukinRow.UpdateUser = _loginUser;

            //更新端末
            seikyuNyukinRow.UpdateTarm = _loginTarm;

            seikyuNyukinInsert.AddSeikyuNyukinTblRow(seikyuNyukinRow);
            seikyuNyukinRow.AcceptChanges();
            seikyuNyukinRow.SetAdded();

            return seikyuNyukinInsert;
        }
        #endregion

        #region MakeSeikyuNyukinTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSeikyuNyukinTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="seikyuNyukinTblListRow"></param>
        /// <param name="nyukinNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable MakeSeikyuNyukinTblUpdate(IUpdateBtnClickALInput input, 
                                                                                            SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow seikyuNyukinTblListRow, 
                                                                                            string nyukinNo)
        {

            // 2014.12.26 toyoda Delete Start
            //SeikyuNyukinTblDataSet.SeikyuNyukinTblRow[] seikyuNyukinTblRows = 
            //    (SeikyuNyukinTblDataSet.SeikyuNyukinTblRow[])input.SeikyuNyukinTblDataTableLoad.Select(string.Format("{0} = '{1}' AND {2} = '{3}' AND {4} = '{5}'",
            //                                                                                        new object[]{input.SeikyuNyukinTblDataTableLoad.SeikyuNoColumn.ColumnName,
            //                                                                                                    seikyuNyukinTblListRow.shishoNoCol,
            //                                                                                                    input.SeikyuNyukinTblDataTableLoad.SeikyuRenbanColumn.ColumnName,
            //                                                                                                    seikyuNyukinTblListRow.renbanCol,
            //                                                                                                    input.SeikyuNyukinTblDataTableLoad.NyukinNoColumn.ColumnName,
            //                                                                                                    nyukinNo}));
            // 2014.12.26 toyoda Delete End

            IGetSeikyuNyukinTblByKeyBLInput getSeikyuNyukinByKeyInput = new GetSeikyuNyukinTblByKeyBLInput();
            getSeikyuNyukinByKeyInput.SeikyuNo = seikyuNyukinTblListRow.shishoNoCol;
            getSeikyuNyukinByKeyInput.SeikyuRenban = seikyuNyukinTblListRow.renbanCol;
            getSeikyuNyukinByKeyInput.NyukinNo = nyukinNo;
            IGetSeikyuNyukinTblByKeyBLOutput getSeikyuNyukinByKeyOutput = new GetSeikyuNyukinTblByKeyBusinessLogic().Execute(getSeikyuNyukinByKeyInput);

            // 2014.12.26 toyoda Mod Start
            //if (seikyuNyukinTblRows.Length > 0)
            //{
            //    //Rakkan check
            //    if (seikyuNyukinTblRows[0].UpdateDt != getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable[0].UpdateDt)
            //    {
            //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            //    }
            //    //入金割振金額
            //    getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable[0].NyukinWarifuriGaku = seikyuNyukinTblListRow.nyukinWarifuriCol;
            //    //更新日
            //    getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable[0].UpdateDt = _currentDateTime;
            //    //更新者
            //    getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable[0].UpdateUser = _loginUser;
            //    //更新端末
            //    getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable[0].UpdateTarm = _loginTarm;
            //}
            //入金割振金額
            getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable[0].NyukinWarifuriGaku = seikyuNyukinTblListRow.nyukinWarifuriCol;
            //更新日
            getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable[0].UpdateDt = _currentDateTime;
            //更新者
            getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable[0].UpdateUser = _loginUser;
            //更新端末
            getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable[0].UpdateTarm = _loginTarm;
            // 2014.12.26 toyoda Mod End

            return getSeikyuNyukinByKeyOutput.SeikyuNyukinTblDataTable;
        }
        #endregion

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
        /// 2014/12/13　HuyTX    新規作成
        /// 2014/12/22　HuyTX    Ver1.06
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
                //Ver1.06 Start
                //getSeikyuDtlOutput.SeikyuDtlTblDataTable[0].NyukinTotal = seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol;
                getSeikyuDtlOutput.SeikyuDtlTblDataTable[0].NyukinTotal = (seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol) - seikyuNyukinTblListRow.nyukinWarifuriGakuCol;
                //Ver1.06 End
                //完済フラグ
                getSeikyuDtlOutput.SeikyuDtlTblDataTable[0].SeikyuKansaiFlg = seikyuNyukinTblListRow.zangakuCol == 0 ? "1" : "0";
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
        /// 2014/12/13　HuyTX    新規作成
        /// 2014/12/22　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable MakeKensaIraiTblUpdate(IUpdateBtnClickALInput input,
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
            //        //Ver1.06 Start
            //        //getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinzumiAmt = seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol;
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinzumiAmt = (seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol) - seikyuNyukinTblListRow.nyukinWarifuriGakuCol;
            //        //Ver1.06 End
            //        //入金完了区分 
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinKanryoKbn = seikyuNyukinTblListRow.zangakuCol == 0 ? "1" : "0";
            //        //更新日
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateDt = _currentDateTime;
            //        //更新者
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateUser = _loginUser;
            //        //更新端末
            //        getKensaIraiOutput.KensaIraiTblDataTable[0].UpdateTarm = _loginTarm;
            //    }
            //}
            //入金済金額 
            //Ver1.06 Start
            //getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinzumiAmt = seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol;
            getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinzumiAmt = (seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol) - seikyuNyukinTblListRow.nyukinWarifuriGakuCol;
            //Ver1.06 End
            //入金完了区分 
            getKensaIraiOutput.KensaIraiTblDataTable[0].KensaIraiNyukinKanryoKbn = seikyuNyukinTblListRow.zangakuCol == 0 ? "1" : "0";
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
        /// 2014/12/13　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable MakeYoshiHanbaiHdrUpdate(IUpdateBtnClickALInput input,
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
            //    getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku = nyukinWarifuriGakuByYoshiNo != null ? Decimal.Parse(nyukinWarifuriGakuByYoshiNo.ToString()) : 0;
            //    //完済フラグ 
            //    if (getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGokeiKingaku
            //        == (getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGenkinNyukingaku
            //            + getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku))
            //    {
            //        getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiKansaiFlg = "1";
            //    }

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
            getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku = nyukinWarifuriGakuByYoshiNo != null ? Decimal.Parse(nyukinWarifuriGakuByYoshiNo.ToString()) : 0;
            //完済フラグ 
            if (getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGokeiKingaku
                == (getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGenkinNyukingaku
                    + getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiSeikyuKingaku))
            {
                getYoshiHanbaiHdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiKansaiFlg = "1";
            }

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
        /// 2014/12/13　HuyTX    新規作成
        /// 2014/12/22　HuyTX    Ver1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NenKaihiTblDataSet.NenKaihiTblDataTable MakeNenKaihiTblUpdate(IUpdateBtnClickALInput input,
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
            //    //Ver1.06 Start
            //    //getNenKaihiOutput.NenKaihiTblDataTable[0].NyukinGaku = seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol;
            //    getNenKaihiOutput.NenKaihiTblDataTable[0].NyukinGaku = (seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol) - seikyuNyukinTblListRow.nyukinWarifuriGakuCol;
            //    //Ver1.06 End
            //    //更新日
            //    getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateDt = _currentDateTime;
            //    //更新者
            //    getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateUser = _loginUser;
            //    //更新端末
            //    getNenKaihiOutput.NenKaihiTblDataTable[0].UpdateTarm = _loginTarm;
            //}
            //入金金額 
            //Ver1.06 Start
            //getNenKaihiOutput.NenKaihiTblDataTable[0].NyukinGaku = seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol;
            getNenKaihiOutput.NenKaihiTblDataTable[0].NyukinGaku = (seikyuNyukinTblListRow.nyukinTotalCol + seikyuNyukinTblListRow.nyukinWarifuriCol) - seikyuNyukinTblListRow.nyukinWarifuriGakuCol;
            //Ver1.06 End
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

        #region MakeSeikyuHdrTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSeikyuHdrTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="seikyuNyukinTblListRow"></param>
        /// <param name="seikyuNyukinTblListDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuHdrTblDataSet.SeikyuHdrTblDataTable MakeSeikyuHdrTblUpdate(IUpdateBtnClickALInput input,
                                                                                SeikyuNyukinTblDataSet.SeikyuNyukinTblListRow seikyuNyukinTblListRow,
                                                                                SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable seikyuNyukinTblListDT)
        {
            IGetSeikyuHdrTblByKeyBLInput getSeikyuHdrInput;
            IGetSeikyuHdrTblByKeyBLOutput getSeikyuHdrOutput;
            
            // 2014.12.26 toyoda Delete Start
            //SeikyuHdrTblDataSet.SeikyuHdrTblRow[] seikyuHdrTblRows;
            // 2014.12.26 toyoda Delete End

            object nyukinTotal = null;

            // 2014.12.26 toyoda Delete Start
            //seikyuHdrTblRows = (SeikyuHdrTblDataSet.SeikyuHdrTblRow[])input.SeikyuHdrTblDataTableLoad.Select(string.Format("{0} = '{1}'",
            //                                    input.SeikyuHdrTblDataTableLoad.SeikyuNoColumn.ColumnName, seikyuNyukinTblListRow.shishoNoCol));
            // 2014.12.26 toyoda Delete End

            getSeikyuHdrInput = new GetSeikyuHdrTblByKeyBLInput();
            getSeikyuHdrInput.SeikyuNo = seikyuNyukinTblListRow.shishoNoCol;
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
            //    nyukinTotal = seikyuNyukinTblListDT.Compute(string.Format("SUM({0})", seikyuNyukinTblListDT.nyukinTotalColColumn.ColumnName),
            //        string.Format("{0} = '{1}'", seikyuNyukinTblListDT.shishoNoColColumn.ColumnName, seikyuNyukinTblListRow.shishoNoCol));
            //    getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].NyukinTotal = nyukinTotal != null ? Decimal.Parse(nyukinTotal.ToString()) : 0;

            //    //更新日
            //    getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateDt = _currentDateTime;
            //    //更新者
            //    getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateUser = _loginUser;
            //    //更新端末
            //    getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateTarm = _loginTarm;
            //}
            //入金合計金額 
            nyukinTotal = seikyuNyukinTblListDT.Compute(string.Format("SUM({0})", seikyuNyukinTblListDT.nyukinTotalColColumn.ColumnName),
                string.Format("{0} = '{1}'", seikyuNyukinTblListDT.shishoNoColColumn.ColumnName, seikyuNyukinTblListRow.shishoNoCol));
            getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].NyukinTotal = nyukinTotal != null ? Decimal.Parse(nyukinTotal.ToString()) : 0;

            //更新日
            getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateDt = _currentDateTime;
            //更新者
            getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateUser = _loginUser;
            //更新端末
            getSeikyuHdrOutput.SeikyuHdrTblDataTable[0].UpdateTarm = _loginTarm;
            // 2014.12.26 toyoda Mod End

            return getSeikyuHdrOutput.SeikyuHdrTblDataTable;
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
        private void MakeSeikyuHdrTblUpdate(IUpdateBtnClickALInput input, 
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
        /// 2014/12/13　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeKurikoshiKinTblData(IUpdateBtnClickALInput input, out KurikoshiKinTblDataSet.KurikoshiKinTblDataTable kurikoshiKinTblDT)
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
            else if(input.NyukinmotoKbn == "2")
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

            //2015.01.07 mod 判定式変更 繰越し金なしの場合はデータを作らない kiyokuni
            if (kurikoshiKinTblRows.Count == 0 && input.JikaiKurikoshi > 0)
            //if (kurikoshiKinTblRows.Count == 0)
            {
                #region make data insert

                // 2014.12.26 toyoda mod Start
                //IGetKurikoshiKinTblInfoBLInput getInfoInput = new GetKurikoshiKinTblInfoBLInput();
                //IGetKurikoshiKinTblInfoBLOutput getInfoOutput = new GetKurikoshiKinTblInfoBusinessLogic().Execute(getInfoInput);
                //string kurikoshikinNo = string.Empty;
                //kurikoshiKinTblRows = (KurikoshiKinTblDataSet.KurikoshiKinTblRow[])getInfoOutput.KurikoshiKinTblDataTable.Select("", string.Format("{0} DESC", getInfoOutput.KurikoshiKinTblDataTable.KurikoshikinNoColumn.ColumnName));

                //if (kurikoshiKinTblRows.Length > 0)
                //{
                //    kurikoshikinNo = Convert.ToString(Convert.ToInt32(kurikoshiKinTblRows[0].KurikoshikinNo) + 1).PadLeft(5, '0');
                //}
                string kurikoshikinNo = new GetMaxKurikoshiKinNoBusinessLogic().Execute(new GetMaxKurikoshiKinNoBLInput()).MaxKurikoshikinNo;
                if (!string.IsNullOrEmpty(kurikoshikinNo))
                {
                    kurikoshikinNo = Convert.ToString(Convert.ToInt32(kurikoshikinNo) + 1).PadLeft(5, '0');
                }
                // 2014.12.26 toyoda mod End

                KurikoshiKinTblDataSet.KurikoshiKinTblRow kurikoshiKinRow = kurikoshiKinTblDT.NewKurikoshiKinTblRow();

                //繰越金No 
                kurikoshiKinRow.KurikoshikinNo = !string.IsNullOrEmpty(kurikoshikinNo) ? kurikoshikinNo : "00001";

                //業者個人区分 
                kurikoshiKinRow.GyosyaKojinKbn = input.NyukinmotoKbn;

                //業者コード
                kurikoshiKinRow.GyosyaCd = input.NyukinmotoKbn == "1" ? input.GyoshaCd : string.Empty;

                //浄化槽保健所コード 
                kurikoshiKinRow.JokasoHokenjoCd = input.NyukinmotoKbn == "2" ? (input.JokasoRow != null ? input.JokasoRow.JokasoHokenjoCd : string.Empty) : string.Empty;

                //浄化槽台帳登録年度
                kurikoshiKinRow.JokasoTorokuNendo = input.NyukinmotoKbn == "2" ? (input.JokasoRow != null ? input.JokasoRow.JokasoTorokuNendo : string.Empty) : string.Empty;

                //浄化槽台帳連番 
                kurikoshiKinRow.JokasoRenban = input.NyukinmotoKbn == "2" ? (input.JokasoRow != null ? input.JokasoRow.JokasoRenban : string.Empty) : string.Empty;

                //最終更新日 
                kurikoshiKinRow.SaisyuKoshinDt = _currentDateTime.ToString("yyyyMMdd");

                //繰り越し金
                kurikoshiKinRow.KurikoshiKin = input.JikaiKurikoshi;

                //登録日
                kurikoshiKinRow.InsertDt = _currentDateTime;

                //登録者
                kurikoshiKinRow.InsertUser = _loginUser;

                //登録端末
                kurikoshiKinRow.InsertTarm = _loginTarm;

                //更新日
                kurikoshiKinRow.UpdateDt = _currentDateTime;

                //更新者
                kurikoshiKinRow.UpdateUser = _loginUser;

                //更新端末
                kurikoshiKinRow.UpdateTarm = _loginTarm;

                kurikoshiKinTblDT.AddKurikoshiKinTblRow(kurikoshiKinRow);
                kurikoshiKinRow.AcceptChanges();
                kurikoshiKinRow.SetAdded();
                #endregion
            }
            else if (kurikoshiKinTblRows.Count > 0)
            //else
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
                        getByKeyOutput.KurikoshiKinTblDataTable[0].KurikoshiKin = input.JikaiKurikoshi;

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

        #endregion
    }
    #endregion
}
