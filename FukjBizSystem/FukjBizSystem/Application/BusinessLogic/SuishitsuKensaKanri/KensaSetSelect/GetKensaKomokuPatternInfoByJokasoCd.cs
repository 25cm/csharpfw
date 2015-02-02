using System.Reflection;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaKomokuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaSetSelect
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKomokuPatternInfoByJokasoCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaKomokuPatternInfoByJokasoCdBLInput : ISelectKensaKomokuPatternInfoByJokasoCdDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKomokuPatternInfoByJokasoCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKomokuPatternInfoByJokasoCdBLInput : IGetKensaKomokuPatternInfoByJokasoCdBLInput
    {
        /// <summary>
        /// JokasoHokenjoCd 
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoTorokuNendo 
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// JokasoRenban 
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKomokuPatternInfoByJokasoCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaKomokuPatternInfoByJokasoCdBLOutput : ISelectKensaKomokuPatternInfoByJokasoCdDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKomokuPatternInfoByJokasoCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKomokuPatternInfoByJokasoCdBLOutput : IGetKensaKomokuPatternInfoByJokasoCdBLOutput
    {
        /// <summary>
        /// KensaKomokuPatternInfoDataTable 
        /// </summary>
        public DaichoSuishitsuKensaKomokuMstDataSet.KensaKomokuPatternInfoDataTable KensaKomokuPatternInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKomokuPatternInfoByJokasoCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKomokuPatternInfoByJokasoCdBusinessLogic : BaseBusinessLogic<IGetKensaKomokuPatternInfoByJokasoCdBLInput, IGetKensaKomokuPatternInfoByJokasoCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaKomokuPatternInfoByJokasoCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaKomokuPatternInfoByJokasoCdBusinessLogic()
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
        /// 2014/12/03  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaKomokuPatternInfoByJokasoCdBLOutput Execute(IGetKensaKomokuPatternInfoByJokasoCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaKomokuPatternInfoByJokasoCdBLOutput output = new GetKensaKomokuPatternInfoByJokasoCdBLOutput();

            try
            {
                output.KensaKomokuPatternInfoDataTable = new SelectKensaKomokuPatternInfoByJokasoCdDataAccess().Execute(input).KensaKomokuPatternInfoDataTable;

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
