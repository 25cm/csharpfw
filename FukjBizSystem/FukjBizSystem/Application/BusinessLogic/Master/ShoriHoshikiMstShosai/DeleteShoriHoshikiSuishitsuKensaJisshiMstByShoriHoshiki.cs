using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShoriHoshikiSuishitsuKensaJisshiMst;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput : IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput : IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput
    {
        /// <summary>
        /// ShoriHoshikiKbn
        /// </summary>
        public string ShoriHoshikiKbn { get; set; }

        /// <summary>
        /// ShoriHoshikiCd
        /// </summary>
        public string ShoriHoshikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput : IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBusinessLogic : BaseBusinessLogic<IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput, IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBusinessLogic()
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
        /// 2015/01/28  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput Execute(IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput output = new DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput();

            try
            {
                new DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDataAccess().Execute(input);

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
