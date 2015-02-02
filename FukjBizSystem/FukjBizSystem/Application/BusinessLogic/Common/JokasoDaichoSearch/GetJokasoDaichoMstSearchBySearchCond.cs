using System.Reflection;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common.JokasoDaichoSearch
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJokasoDaichoMstSearchBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJokasoDaichoMstSearchBySearchCondBLInput : ISelectJokasoDaichoMstSearchBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoMstSearchBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoMstSearchBySearchCondBLInput : IGetJokasoDaichoMstSearchBySearchCondBLInput
    {
        /// <summary>
        /// JokasoDaichoMstSearchCond
        /// </summary>
        public JokasoDaichoMstSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJokasoDaichoMstSearchBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJokasoDaichoMstSearchBySearchCondBLOutput : ISelectJokasoDaichoMstSearchBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoMstSearchBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoMstSearchBySearchCondBLOutput : IGetJokasoDaichoMstSearchBySearchCondBLOutput
    {
        /// <summary>
        /// JokasoDaichoMstSearchDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstSearchDataTable JokasoDaichoMstSearchDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoMstSearchBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoMstSearchBySearchCondBusinessLogic : BaseBusinessLogic<IGetJokasoDaichoMstSearchBySearchCondBLInput, IGetJokasoDaichoMstSearchBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetJokasoDaichoMstSearchBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetJokasoDaichoMstSearchBySearchCondBusinessLogic()
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
        /// 2014/08/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetJokasoDaichoMstSearchBySearchCondBLOutput Execute(IGetJokasoDaichoMstSearchBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetJokasoDaichoMstSearchBySearchCondBLOutput output = new GetJokasoDaichoMstSearchBySearchCondBLOutput();

            try
            {
                ISelectJokasoDaichoMstSearchBySearchCondDAOutput daOutput = new SelectJokasoDaichoMstSearchBySearchCondDataAccess().Execute(input);
                output.JokasoDaichoMstSearchDataTable = daOutput.JokasoDaichoMstSearchDataTable;
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
