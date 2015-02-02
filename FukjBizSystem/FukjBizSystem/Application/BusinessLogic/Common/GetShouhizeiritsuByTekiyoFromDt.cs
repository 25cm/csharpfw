using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShohizeiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShouhizeiritsuByTekiyoFromDtBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShouhizeiritsuByTekiyoFromDtBLInput : ISelectShouhizeiritsuByTekiyoFromDtDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShouhizeiritsuByTekiyoFromDtBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShouhizeiritsuByTekiyoFromDtBLInput : IGetShouhizeiritsuByTekiyoFromDtBLInput
    {
        /// <summary>
        /// 適用開始日
        /// </summary>
        public string TekiyoFromDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShouhizeiritsuByTekiyoFromDtBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShouhizeiritsuByTekiyoFromDtBLOutput : ISelectShouhizeiritsuByTekiyoFromDtDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShouhizeiritsuByTekiyoFromDtBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShouhizeiritsuByTekiyoFromDtBLOutput : IGetShouhizeiritsuByTekiyoFromDtBLOutput
    {
        /// <summary>
        /// ShouhizeiritsuDataTable
        /// </summary>
        public ShohizeiMstDataSet.ShouhizeiritsuDataTable ShouhizeiritsuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShouhizeiritsuByTekiyoFromDtBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShouhizeiritsuByTekiyoFromDtBusinessLogic : BaseBusinessLogic<IGetShouhizeiritsuByTekiyoFromDtBLInput, IGetShouhizeiritsuByTekiyoFromDtBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShouhizeiritsuByTekiyoFromDtBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShouhizeiritsuByTekiyoFromDtBusinessLogic()
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
        /// 2014/09/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShouhizeiritsuByTekiyoFromDtBLOutput Execute(IGetShouhizeiritsuByTekiyoFromDtBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShouhizeiritsuByTekiyoFromDtBLOutput output = new GetShouhizeiritsuByTekiyoFromDtBLOutput();

            try
            {
                ISelectShouhizeiritsuByTekiyoFromDtDAOutput daOutput = new SelectShouhizeiritsuByTekiyoFromDtDataAccess().Execute(input);
                output.ShouhizeiritsuDataTable = daOutput.ShouhizeiritsuDataTable;
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
