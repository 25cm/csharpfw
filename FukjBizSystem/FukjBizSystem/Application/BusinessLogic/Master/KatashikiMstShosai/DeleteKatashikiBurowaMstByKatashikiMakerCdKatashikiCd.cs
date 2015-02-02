using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KatashikiBurowaMst;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput : IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput : IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput
    {
        /// <summary>
        /// BurowaKatashikiMakerCd
        /// </summary>
        public String BurowaKatashikiMakerCd { get; set; }

        /// <summary>
        /// BurowaKatashikiCd
        /// </summary>
        public String BurowaKatashikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput : IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput : IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic : BaseBusinessLogic<IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput, IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBusinessLogic()
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
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput Execute(IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput output = new DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdBLOutput();

            try
            {
                new DeleteKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDataAccess().Execute(input);
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
