using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShoriHoshikiSuishitsuKensaJisshiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiSuishitsuKensaJisshiListBLInput
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
    interface IGetShoriHoshikiSuishitsuKensaJisshiListBLInput : ISelectShoriHoshikiSuishitsuKensaJisshiListDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiListBLInput
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
    class GetShoriHoshikiSuishitsuKensaJisshiListBLInput : IGetShoriHoshikiSuishitsuKensaJisshiListBLInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiSuishitsuKensaJisshiListBLOutput
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
    interface IGetShoriHoshikiSuishitsuKensaJisshiListBLOutput : ISelectShoriHoshikiSuishitsuKensaJisshiListDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiListBLOutput
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
    class GetShoriHoshikiSuishitsuKensaJisshiListBLOutput : IGetShoriHoshikiSuishitsuKensaJisshiListBLOutput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiListDataTable
        /// </summary>
        public ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiListDataTable ShoriHoshikiSuishitsuKensaJisshiListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiListBusinessLogic
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
    class GetShoriHoshikiSuishitsuKensaJisshiListBusinessLogic : BaseBusinessLogic<IGetShoriHoshikiSuishitsuKensaJisshiListBLInput, IGetShoriHoshikiSuishitsuKensaJisshiListBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShoriHoshikiSuishitsuKensaJisshiListBusinessLogic
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
        public GetShoriHoshikiSuishitsuKensaJisshiListBusinessLogic()
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
        public override IGetShoriHoshikiSuishitsuKensaJisshiListBLOutput Execute(IGetShoriHoshikiSuishitsuKensaJisshiListBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShoriHoshikiSuishitsuKensaJisshiListBLOutput output = new GetShoriHoshikiSuishitsuKensaJisshiListBLOutput();

            try
            {
                output.ShoriHoshikiSuishitsuKensaJisshiListDataTable = new SelectShoriHoshikiSuishitsuKensaJisshiListDataAccess().Execute(input).ShoriHoshikiSuishitsuKensaJisshiListDataTable;

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
