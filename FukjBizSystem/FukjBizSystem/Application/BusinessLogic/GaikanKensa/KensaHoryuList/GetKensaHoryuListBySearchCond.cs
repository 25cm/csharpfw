using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaHoryuList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaHoryuListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaHoryuListBySearchCondBLInput : ISelectKensaHoryuListBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaHoryuListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaHoryuListBySearchCondBLInput : IGetKensaHoryuListBySearchCondBLInput
    {
        /// <summary>
        /// Search condition
        /// </summary>
        public KensaIraiTblSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaHoryuListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaHoryuListBySearchCondBLOutput : ISelectKensaHoryuListBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaHoryuListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaHoryuListBySearchCondBLOutput : IGetKensaHoryuListBySearchCondBLOutput
    {
        /// <summary>
        /// KensaHoryuListDataTable
        /// </summary>
        public KensaHoryuDataSet.KensaHoryuListDataTable KensaHoryuListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaHoryuListBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaHoryuListBySearchCondBusinessLogic : BaseBusinessLogic<IGetKensaHoryuListBySearchCondBLInput, IGetKensaHoryuListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaHoryuListBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaHoryuListBySearchCondBusinessLogic()
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
        /// 2014/08/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaHoryuListBySearchCondBLOutput Execute(IGetKensaHoryuListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaHoryuListBySearchCondBLOutput output = new GetKensaHoryuListBySearchCondBLOutput();

            try
            {
                ISelectKensaHoryuListBySearchCondDAOutput daOutput = new SelectKensaHoryuListBySearchCondDataAccess().Execute(input);
                output.KensaHoryuListDataTable = daOutput.KensaHoryuListDataTable;
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
