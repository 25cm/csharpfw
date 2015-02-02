using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShoriHoshikiSuishitsuKensaJisshiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLInput
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
    interface IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLInput : ISelectShoriHoshikiSuishitsuKensaJisshiMstByKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLInput
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
    class GetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLInput : IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLInput
    {
        /// <summary>
        /// ShoriHoshikiKbn
        /// </summary>
        public string ShoriHoshikiKbn { get; set; }

        /// <summary>
        /// ShoriHoshikiCd
        /// </summary>
        public string ShoriHoshikiCd { get; set; }

        /// <summary>
        /// KensaKbn
        /// </summary>
        public string KensaKbn { get; set; }

        /// <summary>
        /// KensaKomokuCd
        /// </summary>
        public string KensaKomokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLOutput
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
    interface IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLOutput : ISelectShoriHoshikiSuishitsuKensaJisshiMstByKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLOutput
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
    class GetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLOutput : IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLOutput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiMstDataTable
        /// </summary>
        public ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable ShoriHoshikiSuishitsuKensaJisshiMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByKeyBusinessLogic
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
    class GetShoriHoshikiSuishitsuKensaJisshiMstByKeyBusinessLogic : BaseBusinessLogic<IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLInput, IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByKeyBusinessLogic
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
        public GetShoriHoshikiSuishitsuKensaJisshiMstByKeyBusinessLogic()
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
        public override IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLOutput Execute(IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLOutput output = new GetShoriHoshikiSuishitsuKensaJisshiMstByKeyBLOutput();

            try
            {
                output.ShoriHoshikiSuishitsuKensaJisshiMstDataTable = new SelectShoriHoshikiSuishitsuKensaJisshiMstByKeyDataAccess().Execute(input).ShoriHoshikiSuishitsuKensaJisshiMstDataTable;

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
