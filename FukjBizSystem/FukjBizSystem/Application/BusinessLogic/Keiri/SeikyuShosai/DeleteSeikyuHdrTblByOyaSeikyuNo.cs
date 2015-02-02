using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuHdrTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSeikyuHdrTblByOyaSeikyuNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSeikyuHdrTblByOyaSeikyuNoBLInput : IDeleteSeikyuHdrTblByOyaSeikyuNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuHdrTblByOyaSeikyuNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuHdrTblByOyaSeikyuNoBLInput : IDeleteSeikyuHdrTblByOyaSeikyuNoBLInput
    {
        /// <summary>
        /// OyaSeikyuNo
        /// </summary>
        public string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSeikyuHdrTblByOyaSeikyuNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSeikyuHdrTblByOyaSeikyuNoBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuHdrTblByOyaSeikyuNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuHdrTblByOyaSeikyuNoBLOutput : IDeleteSeikyuHdrTblByOyaSeikyuNoBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuHdrTblByOyaSeikyuNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuHdrTblByOyaSeikyuNoBusinessLogic : BaseBusinessLogic<IDeleteSeikyuHdrTblByOyaSeikyuNoBLInput, IDeleteSeikyuHdrTblByOyaSeikyuNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteSeikyuHdrTblByOyaSeikyuNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/17　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteSeikyuHdrTblByOyaSeikyuNoBusinessLogic()
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
        /// 2014/12/17　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteSeikyuHdrTblByOyaSeikyuNoBLOutput Execute(IDeleteSeikyuHdrTblByOyaSeikyuNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteSeikyuHdrTblByOyaSeikyuNoBLOutput output = new DeleteSeikyuHdrTblByOyaSeikyuNoBLOutput();

            try
            {
                new DeleteSeikyuHdrTblByOyaSeikyuNoDataAccess().Execute(input);
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
