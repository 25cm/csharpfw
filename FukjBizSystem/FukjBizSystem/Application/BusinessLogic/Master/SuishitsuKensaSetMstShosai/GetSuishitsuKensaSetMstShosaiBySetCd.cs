using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaSetMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.SuishitsuKensaSetMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKensaSetMstShosaiBySetCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKensaSetMstShosaiBySetCdBLInput : ISelectSuishitsuKensaSetMstShosaiBySetCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKensaSetMstShosaiBySetCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKensaSetMstShosaiBySetCdBLInput : IGetSuishitsuKensaSetMstShosaiBySetCdBLInput
    {
        /// <summary>
        /// セットコード
        /// </summary>
        public string SetCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKensaSetMstShosaiBySetCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKensaSetMstShosaiBySetCdBLOutput : ISelectSuishitsuKensaSetMstShosaiBySetCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKensaSetMstShosaiBySetCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKensaSetMstShosaiBySetCdBLOutput : IGetSuishitsuKensaSetMstShosaiBySetCdBLOutput
    {
        /// <summary>
        /// SuishitsuKensaSetMstShosaiDataTable
        /// </summary>
        public SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstShosaiDataTable SuishitsuKensaSetMstShosaiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKensaSetMstShosaiBySetCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKensaSetMstShosaiBySetCdBusinessLogic : BaseBusinessLogic<IGetSuishitsuKensaSetMstShosaiBySetCdBLInput, IGetSuishitsuKensaSetMstShosaiBySetCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuKensaSetMstShosaiBySetCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuKensaSetMstShosaiBySetCdBusinessLogic()
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
        /// 2014/07/09　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuKensaSetMstShosaiBySetCdBLOutput Execute(IGetSuishitsuKensaSetMstShosaiBySetCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuKensaSetMstShosaiBySetCdBLOutput output = new GetSuishitsuKensaSetMstShosaiBySetCdBLOutput();

            try
            {
                ISelectSuishitsuKensaSetMstShosaiBySetCdDAOutput daOutput = new SelectSuishitsuKensaSetMstShosaiBySetCdDataAccess().Execute(input);
                output.SuishitsuKensaSetMstShosaiDataTable = daOutput.SuishitsuKensaSetMstShosaiDataTable;
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
