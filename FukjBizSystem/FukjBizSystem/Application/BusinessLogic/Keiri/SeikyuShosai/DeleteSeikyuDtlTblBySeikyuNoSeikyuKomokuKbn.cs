using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuDtlTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput : IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput : IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput
    {
        /// <summary>
        /// 請求No 
        /// </summary>
        public string SeikyuNo { get; set; }

        /// <summary>
        /// 請求項目区分
        /// </summary>
        public string SeikyuKomokuKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput : IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput : IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic : BaseBusinessLogic<IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput, IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic()
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
        /// 2014/10/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput Execute(IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput output = new DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput();

            try
            {
                new DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess().Execute(input);
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
