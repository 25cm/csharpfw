using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyushoKagamiHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput
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
    interface IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput : ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput
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
    class GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput : IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput
    {
        /// <summary>
        /// 親請求No
        /// </summary>
        public string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput
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
    interface IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput : ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput
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
    class GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput : IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput
    {
        /// <summary>
        /// SeikyuShosaiFormLoadHdrDataTable
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrDataTable SeikyuShosaiFormLoadHdrDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBusinessLogic
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
    class GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBusinessLogic : BaseBusinessLogic<IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput, IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBusinessLogic
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
        public GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBusinessLogic()
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
        public override IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput Execute(IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput output = new GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput();

            try
            {
                output.SeikyuShosaiFormLoadHdrDT = new SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDataAccess().Execute(input).SeikyuShosaiFormLoadHdrDT;
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
