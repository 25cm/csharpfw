using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShoriHoshikiMst;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShoriHoshikiMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShoriHoshikiMstByKeyBLInput : IDeleteShoriHoshikiMstByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShoriHoshikiMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShoriHoshikiMstByKeyBLInput : IDeleteShoriHoshikiMstByKeyBLInput
    {
        /// <summary>
        /// 処理方式区分
        /// </summary>
        public String ShoriHoshikiKbn { get; set; }

        /// <summary>
        /// 処理方式コード
        /// </summary>
        public String ShoriHoshikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShoriHoshikiMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShoriHoshikiMstByKeyBLOutput : IDeleteShoriHoshikiMstByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShoriHoshikiMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShoriHoshikiMstByKeyBLOutput : IDeleteShoriHoshikiMstByKeyBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShoriHoshikiMstByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShoriHoshikiMstByKeyBusinessLogic : BaseBusinessLogic<IDeleteShoriHoshikiMstByKeyBLInput, IDeleteShoriHoshikiMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteShoriHoshikiMstByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteShoriHoshikiMstByKeyBusinessLogic()
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
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteShoriHoshikiMstByKeyBLOutput Execute(IDeleteShoriHoshikiMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteShoriHoshikiMstByKeyBLOutput output = new DeleteShoriHoshikiMstByKeyBLOutput();

            try
            {
                new DeleteShoriHoshikiMstByKeyDataAccess().Execute(input);
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
