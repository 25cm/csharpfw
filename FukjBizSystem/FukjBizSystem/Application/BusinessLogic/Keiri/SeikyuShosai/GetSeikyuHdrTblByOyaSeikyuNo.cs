using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuHdrTblByOyaSeikyuNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuHdrTblByOyaSeikyuNoBLInput : ISelectSeikyuHdrTblByOyaSeikyuNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuHdrTblByOyaSeikyuNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuHdrTblByOyaSeikyuNoBLInput : IGetSeikyuHdrTblByOyaSeikyuNoBLInput
    {
        /// <summary>
        /// 親請求No
        /// </summary>
        public string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuHdrTblByOyaSeikyuNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuHdrTblByOyaSeikyuNoBLOutput : ISelectSeikyuHdrTblByOyaSeikyuNoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuHdrTblByOyaSeikyuNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuHdrTblByOyaSeikyuNoBLOutput : IGetSeikyuHdrTblByOyaSeikyuNoBLOutput
    {
        /// <summary>
        /// SeikyuHdrTblDataTable
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuHdrTblByOyaSeikyuNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuHdrTblByOyaSeikyuNoBusinessLogic : BaseBusinessLogic<IGetSeikyuHdrTblByOyaSeikyuNoBLInput, IGetSeikyuHdrTblByOyaSeikyuNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuHdrTblByOyaSeikyuNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSeikyuHdrTblByOyaSeikyuNoBusinessLogic()
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
        /// 2014/12/16　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSeikyuHdrTblByOyaSeikyuNoBLOutput Execute(IGetSeikyuHdrTblByOyaSeikyuNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuHdrTblByOyaSeikyuNoBLOutput output = new GetSeikyuHdrTblByOyaSeikyuNoBLOutput();

            try
            {
                output.SeikyuHdrTblDT = new SelectSeikyuHdrTblByOyaSeikyuNoDataAccess().Execute(input).SeikyuHdrTblDT;
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
