using System.Reflection;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaIraishoOutputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKishakuBairitsuShomeiKekkaInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKishakuBairitsuShomeiKekkaInfoBLInput : ISelectKishakuBairitsuShomeiKekkaInfoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKishakuBairitsuShomeiKekkaInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKishakuBairitsuShomeiKekkaInfoBLInput : IGetKishakuBairitsuShomeiKekkaInfoBLInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public KensaIraishoOutputSearchCond SearchCond { get; set; }

        /// <summary>
        /// ShikenKomokuCd 
        /// </summary>
        public string ShikenKomokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKishakuBairitsuShomeiKekkaInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKishakuBairitsuShomeiKekkaInfoBLOutput : ISelectKishakuBairitsuShomeiKekkaInfoDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKishakuBairitsuShomeiKekkaInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKishakuBairitsuShomeiKekkaInfoBLOutput : IGetKishakuBairitsuShomeiKekkaInfoBLOutput
    {
        /// <summary>
        /// KishakuBairitsuShomeiKekkaDataTable
        /// </summary>
        public KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaDataTable KishakuBairitsuShomeiKekkaDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKishakuBairitsuShomeiKekkaInfoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKishakuBairitsuShomeiKekkaInfoBusinessLogic : BaseBusinessLogic<IGetKishakuBairitsuShomeiKekkaInfoBLInput, IGetKishakuBairitsuShomeiKekkaInfoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKishakuBairitsuShomeiKekkaInfoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKishakuBairitsuShomeiKekkaInfoBusinessLogic()
        {
        }
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
        /// 2014/12/02  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKishakuBairitsuShomeiKekkaInfoBLOutput Execute(IGetKishakuBairitsuShomeiKekkaInfoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKishakuBairitsuShomeiKekkaInfoBLOutput output = new GetKishakuBairitsuShomeiKekkaInfoBLOutput();

            try
            {
                output.KishakuBairitsuShomeiKekkaDataTable = new SelectKishakuBairitsuShomeiKekkaInfoDataAccess().Execute(input).KishakuBairitsuShomeiKekkaDataTable;

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

    }
    #endregion
}
