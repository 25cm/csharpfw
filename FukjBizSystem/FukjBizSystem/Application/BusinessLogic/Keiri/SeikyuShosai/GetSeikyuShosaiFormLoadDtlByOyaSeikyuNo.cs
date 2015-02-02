using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput : ISelectSeikyuShosaiFormLoadDtlByOyaSeikyuNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput : IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput
    {
        /// <summary>
        /// 親請求No
        /// </summary>
        public string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput : ISelectSeikyuShosaiFormLoadDtlByOyaSeikyuNoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput : IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput
    {
        /// <summary>
        /// SeikyuShosaiFormLoadDtlDataTable
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlDataTable SeikyuShosaiFormLoadDtlDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBusinessLogic : BaseBusinessLogic<IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput, IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBusinessLogic()
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
        /// 2014/11/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput Execute(IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput output = new GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput();

            try
            {
                output.SeikyuShosaiFormLoadDtlDT = new SelectSeikyuShosaiFormLoadDtlByOyaSeikyuNoDataAccess().Execute(input).SeikyuShosaiFormLoadDtlDT;
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
