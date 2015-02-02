using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShoriHoshikiSuishitsuKensaJisshiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLInput
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
    interface IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLInput : IUpdateShoriHoshikiSuishitsuKensaJisshiMstDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateShoriHoshikiSuishitsuKensaJisshiMstBLInput
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
    class UpdateShoriHoshikiSuishitsuKensaJisshiMstBLInput : IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLInput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiMstDataTable
        /// </summary>
        public ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable ShoriHoshikiSuishitsuKensaJisshiMstDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLOutput
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
    interface IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateShoriHoshikiSuishitsuKensaJisshiMstBLOutput
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
    class UpdateShoriHoshikiSuishitsuKensaJisshiMstBLOutput : IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateShoriHoshikiSuishitsuKensaJisshiMstBusinessLogic
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
    class UpdateShoriHoshikiSuishitsuKensaJisshiMstBusinessLogic : BaseBusinessLogic<IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLInput, IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateShoriHoshikiSuishitsuKensaJisshiMstBusinessLogic
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
        public UpdateShoriHoshikiSuishitsuKensaJisshiMstBusinessLogic()
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
        public override IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLOutput Execute(IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateShoriHoshikiSuishitsuKensaJisshiMstBLOutput output = new UpdateShoriHoshikiSuishitsuKensaJisshiMstBLOutput();

            try
            {
                new UpdateShoriHoshikiSuishitsuKensaJisshiMstDataAccess().Execute(input);

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
