using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KatashikiBetsuTaniSochiMst;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.KatashikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput
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
    interface IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput : IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput
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
    class DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput : IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput
    {
        /// <summary>
        /// メーカー業者コード
        /// </summary>
        public String KatashikiMakerCd { get; set; }

        /// <summary>
        /// 型式コード
        /// </summary>
        public String KatashikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput
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
    interface IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput : IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput
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
    class DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput : IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBusinessLogic
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
    class DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBusinessLogic : BaseBusinessLogic<IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput, IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBusinessLogic
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
        public DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBusinessLogic()
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
        public override IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput Execute(IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput output = new DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdBLOutput();

            try
            {
                new DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDataAccess().Execute(input);
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
