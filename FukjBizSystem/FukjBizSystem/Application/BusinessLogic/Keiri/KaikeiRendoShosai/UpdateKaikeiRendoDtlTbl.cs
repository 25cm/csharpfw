using System.Reflection;
using FukjBizSystem.Application.DataAccess.KaikeiRendoDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiRendoShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKaikeiRendoDtlTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKaikeiRendoDtlTblBLInput : IUpdateKaikeiRendoDtlTblDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKaikeiRendoDtlTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKaikeiRendoDtlTblBLInput : IUpdateKaikeiRendoDtlTblBLInput
    {
        /// <summary>
        /// KaikeiRendoDtlTblDataTable
        /// </summary>
        public KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblDataTable KaikeiRendoDtlTblDT { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKaikeiRendoDtlTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKaikeiRendoDtlTblBLOutput : IUpdateKaikeiRendoDtlTblDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKaikeiRendoDtlTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKaikeiRendoDtlTblBLOutput : IUpdateKaikeiRendoDtlTblBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKaikeiRendoDtlTblBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKaikeiRendoDtlTblBusinessLogic : BaseBusinessLogic<IUpdateKaikeiRendoDtlTblBLInput, IUpdateKaikeiRendoDtlTblBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKaikeiRendoDtlTblBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKaikeiRendoDtlTblBusinessLogic()
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
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKaikeiRendoDtlTblBLOutput Execute(IUpdateKaikeiRendoDtlTblBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKaikeiRendoDtlTblBLOutput output = new UpdateKaikeiRendoDtlTblBLOutput();

            try
            {
                new UpdateKaikeiRendoDtlTblDataAccess().Execute(input);
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
