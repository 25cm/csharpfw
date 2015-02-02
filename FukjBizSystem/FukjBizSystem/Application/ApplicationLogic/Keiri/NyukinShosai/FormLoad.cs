using System.Reflection;
using FukjBizSystem.Application.Boundary.Keiri;
using FukjBizSystem.Application.BusinessLogic.Keiri.HenkinShosai;
using FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai;
using FukjBizSystem.Application.BusinessLogic.Master.ShishoMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.NyukinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// NyukinNo 
        /// </summary>
        string NyukinNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// NyukinNo 
        /// </summary>
        public string NyukinNo { get; set; }

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
    //  インターフェイス名 ： IFormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// ShishoMstDataTable
        /// </summary>
        ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// NyukinTblShosaiDataTable
        /// </summary>
        NyukinTblDataSet.NyukinTblShosaiDataTable NyukinTblShosaiDataTable { get; set; }

        /// <summary>
        /// SeikyuNyukinTblListDataTable
        /// </summary>
        SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable SeikyuNyukinTblListDataTable { get; set; }

        /// <summary>
        /// NyukinTblDataTable
        /// </summary>
        NyukinTblDataSet.NyukinTblDataTable NyukinTblDataTable { get; set; }

        /// <summary>
        /// DisplayMode
        /// </summary>
        NyukinShosaiForm.DispMode DisplayMode { get; set; }

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// SeikyuDtlTblDataTable
        ///// </summary>
        //SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDataTable { get; set; }

        ///// <summary>
        ///// KensaIraiTblDataTable
        ///// </summary>
        //KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        ///// <summary>
        ///// YoshiHanbaiHdrTblDataTable
        ///// </summary>
        //YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable YoshiHanbaiHdrTblDataTable { get; set; }

        ///// <summary>
        ///// NenKaihiTblDataTable
        ///// </summary>
        //NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblDataTable { get; set; }

        ///// <summary>
        ///// SeikyuHdrTblDataTable
        ///// </summary>
        //SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDataTable { get; set; }
        
        ///// <summary>
        ///// KurikoshiKinTblDataTable
        ///// </summary>
        //KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }

        ///// <summary>
        ///// SeikyuNyukinTblDataTable
        ///// </summary>
        //SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable SeikyuNyukinTblDataTable { get; set; }
        // 2014.12.27 toyoda Delete End

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// ShishoMstDataTable
        /// </summary>
        public ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// NyukinTblShosaiDataTable
        /// </summary>
        public NyukinTblDataSet.NyukinTblShosaiDataTable NyukinTblShosaiDataTable { get; set; }

        /// <summary>
        /// SeikyuNyukinTblListDataTable
        /// </summary>
        public SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable SeikyuNyukinTblListDataTable { get; set; }

        /// <summary>
        /// NyukinTblDataTable
        /// </summary>
        public NyukinTblDataSet.NyukinTblDataTable NyukinTblDataTable { get; set; }

        /// <summary>
        /// DisplayMode
        /// </summary>
        public NyukinShosaiForm.DispMode DisplayMode { get; set; }

        // 2014.12.27 toyoda Delete Start
        ///// <summary>
        ///// SeikyuDtlTblDataTable
        ///// </summary>
        //public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDataTable { get; set; }

        ///// <summary>
        ///// KensaIraiTblDataTable
        ///// </summary>
        //public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        ///// <summary>
        ///// YoshiHanbaiHdrTblDataTable
        ///// </summary>
        //public YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable YoshiHanbaiHdrTblDataTable { get; set; }

        ///// <summary>
        ///// NenKaihiTblDataTable
        ///// </summary>
        //public NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblDataTable { get; set; }

        ///// <summary>
        ///// SeikyuHdrTblDataTable
        ///// </summary>
        //public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDataTable { get; set; }
        
        ///// <summary>
        ///// KurikoshiKinTblDataTable
        ///// </summary>
        //public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }

        ///// <summary>
        ///// SeikyuNyukinTblDataTable
        ///// </summary>
        //public SeikyuNyukinTblDataSet.SeikyuNyukinTblDataTable SeikyuNyukinTblDataTable { get; set; }
        // 2014.12.27 toyoda Delete End

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "NyukinShosai：FormLoad";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FormLoadApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FormLoadApplicationLogic()
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
        /// 2014/10/03  HuyTX　　    新規作成
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
        /// 2014/10/03  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                //get shisho
                IGetShishoMstInfoBLInput getShishoBLInput = new GetShishoMstInfoBLInput();
                IGetShishoMstInfoBLOutput getShishoBLOutput = new GetShishoMstInfoBusinessLogic().Execute(getShishoBLInput);
                output.ShishoMstDataTable = getShishoBLOutput.ShishoMstDT;

                // 2014.12.27 toyoda Delete Start
                ////get SeikyuDtl
                //IGetSeikyuDtlTblInfoBLInput getSeikyuDtlInput = new GetSeikyuDtlTblInfoBLInput();
                //output.SeikyuDtlTblDataTable = new GetSeikyuDtlTblInfoBusinessLogic().Execute(getSeikyuDtlInput).SeikyuDtlTblDataTable;

                ////get KensaIraiTbl
                //IGetKensaIraiTblInfoBLInput getKensaIraiInput = new GetKensaIraiTblInfoBLInput();
                //output.KensaIraiTblDataTable = new GetKensaIraiTblInfoBusinessLogic().Execute(getKensaIraiInput).KensaIraiTblDataTable;

                ////get YoshiHanbaiHdrTbl
                //IGetYoshiHanbaiHdrTblInfoBLInput getYoshiHanbaiHdr = new GetYoshiHanbaiHdrTblInfoBLInput();
                //output.YoshiHanbaiHdrTblDataTable = new GetYoshiHanbaiHdrTblInfoBusinessLogic().Execute(getYoshiHanbaiHdr).YoshiHanbaiHdrTblDataTable;

                ////get NenKaihiTbl
                //IGetNenKaihiTblInfoBLInput getNenKaihiInput = new GetNenKaihiTblInfoBLInput();
                //output.NenKaihiTblDataTable = new GetNenKaihiTblInfoBusinessLogic().Execute(getNenKaihiInput).NenKaihiTblDataTable;

                ////get SeikyuHdrTbl
                //IGetSeikyuHdrTblInfoBLInput getSeikyuHdrInput = new GetSeikyuHdrTblInfoBLInput();
                //output.SeikyuHdrTblDataTable = new GetSeikyuHdrTblInfoBusinessLogic().Execute(getSeikyuHdrInput).SeikyuHdrTblDataTable;

                ////get KurikoshiKinTbl
                //IGetKurikoshiKinTblInfoBLInput getKurikoshiKinInput = new GetKurikoshiKinTblInfoBLInput();
                //output.KurikoshiKinTblDataTable = new GetKurikoshiKinTblInfoBusinessLogic().Execute(getKurikoshiKinInput).KurikoshiKinTblDataTable;

                ////get SeikyuNyukinTbl
                //IGetSeikyuNyukinTblInfoBLInput getSeikyuNyukinInput = new GetSeikyuNyukinTblInfoBLInput();
                //output.SeikyuNyukinTblDataTable = new GetSeikyuNyukinTblInfoBusinessLogic().Execute(getSeikyuNyukinInput).SeikyuNyukinTblDataTable;
                // 2014.12.27 toyoda Delete End
                
                if (!string.IsNullOrEmpty(input.NyukinNo))
                {
                    //get NyukinTbl
                    IGetNyukinShosaiByNyukinNoBLInput getNyukinBLInput = new GetNyukinShosaiByNyukinNoBLInput();
                    getNyukinBLInput.NyukinNo = input.NyukinNo;
                    IGetNyukinShosaiByNyukinNoBLOutput getNyukinBLOutput = new GetNyukinShosaiByNyukinNoBusinessLogic().Execute(getNyukinBLInput);
                    output.NyukinTblShosaiDataTable = getNyukinBLOutput.NyukinTblShosaiDataTable;

                    //get SeikyuNyukinTblList
                    IGetSeikyuNyukinListBySearchCondBLInput getSeikyuNyukinListBLInput = new GetSeikyuNyukinListBySearchCondBLInput();
                    SeikyushoKagamiHdrSearchCond searchCond = new SeikyushoKagamiHdrSearchCond();
                    searchCond.NyukinNo = input.NyukinNo;
                    getSeikyuNyukinListBLInput.SearchCond = searchCond;
                    output.SeikyuNyukinTblListDataTable = new GetSeikyuNyukinListBySearchCondBusinessLogic().Execute(getSeikyuNyukinListBLInput).SeikyuNyukinTblListDataTable;

                    //get NyukinTbl by key
                    IGetNyukinTblByKeyBLInput getNyukinByKeyInput = new GetNyukinTblByKeyBLInput();
                    getNyukinByKeyInput.NyukinNo = input.NyukinNo;
                    output.NyukinTblDataTable = new GetNyukinTblByKeyBusinessLogic().Execute(getNyukinByKeyInput).NyukinTblDataTable;

                    //check display mode edit/reference
                    if (getNyukinBLOutput.NyukinTblShosaiDataTable != null
                        && getNyukinBLOutput.NyukinTblShosaiDataTable.Count > 0
                        && getNyukinBLOutput.NyukinTblShosaiDataTable[0].NyukinSyubetsu == "1")
                    {
                        output.DisplayMode = !IsExistSeikyuNyukin(input.NyukinNo) ? NyukinShosaiForm.DispMode.Edit : NyukinShosaiForm.DispMode.Reference;
                    }
                    else
                    {
                        output.DisplayMode = NyukinShosaiForm.DispMode.Reference;
                    }
                }

            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region IsExistSeikyuNyukin
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsExistSeikyuNyukin
        /// <summary>
        /// 
        /// </summary>
        /// <param name="nyukinNo"></param>
        /// <returns>true/false</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/12　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsExistSeikyuNyukin(string nyukinNo)
        {
            // 2014.12.28 toyoda Mod Start
            //SeikyuNyukinTblDataSet.SeikyuNyukinTblRow[] seikyuByNyukinNoRows;
            //SeikyuNyukinTblDataSet.SeikyuNyukinTblRow[] seikyuBySeikyuNoRows;
            //IGetSeikyuNyukinTblInfoBLInput getSeikyuInfoBLInput = new GetSeikyuNyukinTblInfoBLInput();
            //IGetSeikyuNyukinTblInfoBLOutput getSeikyuInfoBLOutput = new GetSeikyuNyukinTblInfoBusinessLogic().Execute(getSeikyuInfoBLInput);

            //seikyuByNyukinNoRows = (SeikyuNyukinTblDataSet.SeikyuNyukinTblRow[])getSeikyuInfoBLOutput.SeikyuNyukinTblDataTable.Select(string.Format("NyukinNo = '{0}'", nyukinNo));

            //foreach (SeikyuNyukinTblDataSet.SeikyuNyukinTblRow seikyuByNyukinNo in seikyuByNyukinNoRows)
            //{
            //    seikyuBySeikyuNoRows = (SeikyuNyukinTblDataSet.SeikyuNyukinTblRow[])getSeikyuInfoBLOutput.SeikyuNyukinTblDataTable.Select(string.Format("SeikyuNo = '{0}'", seikyuByNyukinNo.SeikyuNo));
            //    foreach (SeikyuNyukinTblDataSet.SeikyuNyukinTblRow seikyuRow in seikyuBySeikyuNoRows)
            //    {
            //        if (nyukinNo != seikyuRow.NyukinNo)
            //        {
            //            return true;
            //        }
            //    }
            //}
            // 同じ請求に対して別の入金が存在するか確認
            IGetIsExistNyukinByNyukinNoBLInput checkInput = new GetIsExistNyukinByNyukinNoBLInput();
            checkInput.NyukinNo = nyukinNo;
            IGetIsExistNyukinByNyukinNoBLOutput chechOutput = new GetIsExistNyukinByNyukinNoBusinessLogic().Execute(checkInput);
            if (chechOutput.IsExistNyukin.HasValue && chechOutput.IsExistNyukin.Value > 0)
            {
                return true;
            }
            // 2014.12.28 toyoda Mod End

            return false;
        }
        #endregion

        #endregion
    }
    #endregion
}
