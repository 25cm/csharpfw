using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShoriHoshikiSuishitsuKensaJisshiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput : ISelectShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput : IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput
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
    //  インターフェイス名 ： IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput : ISelectShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput : IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiMstDataTable
        /// </summary>
        public ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable ShoriHoshikiSuishitsuKensaJisshiMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBusinessLogic : BaseBusinessLogic<IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput, IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBusinessLogic()
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
        /// 2015/01/27  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput Execute(IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput output = new GetShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLOutput();

            try
            {
                output.ShoriHoshikiSuishitsuKensaJisshiMstDataTable = new SelectShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiDataAccess().Execute(input).ShoriHoshikiSuishitsuKensaJisshiMstDataTable;

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
