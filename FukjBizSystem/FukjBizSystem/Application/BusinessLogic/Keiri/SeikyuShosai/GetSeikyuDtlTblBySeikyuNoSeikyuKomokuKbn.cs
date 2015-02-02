using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput : ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput : IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput
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
    //  インターフェイス名 ： IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput : ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput : IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput
    {
        /// <summary>
        /// SeikyuDtlTblDataTable
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic : BaseBusinessLogic<IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput, IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic()
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
        /// 2014/10/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput Execute(IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput output = new GetSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLOutput();

            try
            {
                output.SeikyuDtlTblDT = new SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess().Execute(input).SeikyuDtlTblDT;
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
