using System.Reflection;
using FukjBizSystem.Application.DataAccess.SaisuiinMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SaisuiinKanri.SaisuiinInfoShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaisuiinInfoShosaiBySaisuiinCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaisuiinInfoShosaiBySaisuiinCdBLInput : ISelectSaisuiinInfoShosaiBySaisuiinCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiinInfoShosaiBySaisuiinCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiinInfoShosaiBySaisuiinCdBLInput : IGetSaisuiinInfoShosaiBySaisuiinCdBLInput
    {
        /// <summary>
        /// 採水員コード
        /// </summary>
        public string SaisuiinCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaisuiinInfoShosaiBySaisuiinCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaisuiinInfoShosaiBySaisuiinCdBLOutput : ISelectSaisuiinInfoShosaiBySaisuiinCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiinInfoShosaiBySaisuiinCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiinInfoShosaiBySaisuiinCdBLOutput : IGetSaisuiinInfoShosaiBySaisuiinCdBLOutput
    {
        /// <summary>
        /// SaisuiinInfoShosaiDataTable
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinInfoShosaiDataTable SaisuiinInfoShosaiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiinInfoShosaiBySaisuiinCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiinInfoShosaiBySaisuiinCdBusinessLogic : BaseBusinessLogic<IGetSaisuiinInfoShosaiBySaisuiinCdBLInput, IGetSaisuiinInfoShosaiBySaisuiinCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSaisuiinInfoShosaiBySaisuiinCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSaisuiinInfoShosaiBySaisuiinCdBusinessLogic()
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
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSaisuiinInfoShosaiBySaisuiinCdBLOutput Execute(IGetSaisuiinInfoShosaiBySaisuiinCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSaisuiinInfoShosaiBySaisuiinCdBLOutput output = new GetSaisuiinInfoShosaiBySaisuiinCdBLOutput();

            try
            {
                ISelectSaisuiinInfoShosaiBySaisuiinCdDAOutput daOutput = new SelectSaisuiinInfoShosaiBySaisuiinCdDataAccess().Execute(input);
                output.SaisuiinInfoShosaiDataTable = daOutput.SaisuiinInfoShosaiDataTable;
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
