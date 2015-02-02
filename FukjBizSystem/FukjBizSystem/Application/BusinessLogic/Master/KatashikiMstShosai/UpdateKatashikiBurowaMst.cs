using System.Reflection;
using FukjBizSystem.Application.DataAccess.KatashikiBurowaMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertKatashikiBurowaMstBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertKatashikiBurowaMstBLInput : IInsertKatashikiBurowaMstDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertKatashikiBurowaMstBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertKatashikiBurowaMstBLInput : IInsertKatashikiBurowaMstBLInput
    {
        /// <summary>
        /// KatashikiBurowaMstDataTable
        /// </summary>
        public KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable KatashikiBurowaMstDT { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertKatashikiBurowaMstBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertKatashikiBurowaMstBLOutput : IInsertKatashikiBurowaMstDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertKatashikiBurowaMstBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertKatashikiBurowaMstBLOutput : IInsertKatashikiBurowaMstBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKatashikiBurowaMstBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKatashikiBurowaMstBusinessLogic : BaseBusinessLogic<IInsertKatashikiBurowaMstBLInput, IInsertKatashikiBurowaMstBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKatashikiBurowaMstBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKatashikiBurowaMstBusinessLogic()
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
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IInsertKatashikiBurowaMstBLOutput Execute(IInsertKatashikiBurowaMstBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertKatashikiBurowaMstBLOutput output = new InsertKatashikiBurowaMstBLOutput();

            try
            {
                new InsertKatashikiBurowaMstDataAccess().Execute(input);
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
