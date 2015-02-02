using System.Reflection;
using FukjBizSystem.Application.DataAccess.SaisuiinMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SaisuiinKanri.SaisuiinShomeishoHakko
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaisuiinShomeishoHakkoKensakuByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaisuiinShomeishoHakkoKensakuByCondBLInput : ISelectSaisuiinShomeishoHakkoKensakuByCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiinShomeishoHakkoKensakuByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiinShomeishoHakkoKensakuByCondBLInput : IGetSaisuiinShomeishoHakkoKensakuByCondBLInput
    {
        /// <summary>
        /// Search condition
        /// </summary>
        public SaisuiinMstSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaisuiinShomeishoHakkoKensakuByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaisuiinShomeishoHakkoKensakuByCondBLOutput : ISelectSaisuiinShomeishoHakkoKensakuByCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiinShomeishoHakkoKensakuByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiinShomeishoHakkoKensakuByCondBLOutput : IGetSaisuiinShomeishoHakkoKensakuByCondBLOutput
    {
        /// <summary>
        /// SaisuiinShomeishoHakkoKensakuDataTable
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinShomeishoHakkoKensakuDataTable SaisuiinShomeishoHakkoKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiinShomeishoHakkoKensakuByCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiinShomeishoHakkoKensakuByCondBusinessLogic : BaseBusinessLogic<IGetSaisuiinShomeishoHakkoKensakuByCondBLInput, IGetSaisuiinShomeishoHakkoKensakuByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSaisuiinShomeishoHakkoKensakuByCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSaisuiinShomeishoHakkoKensakuByCondBusinessLogic()
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
        /// 2014/07/25　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSaisuiinShomeishoHakkoKensakuByCondBLOutput Execute(IGetSaisuiinShomeishoHakkoKensakuByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSaisuiinShomeishoHakkoKensakuByCondBLOutput output = new GetSaisuiinShomeishoHakkoKensakuByCondBLOutput();

            try
            {
                ISelectSaisuiinShomeishoHakkoKensakuByCondDAOutput daOutput = new SelectSaisuiinShomeishoHakkoKensakuByCondDataAccess().Execute(input);
                output.SaisuiinShomeishoHakkoKensakuDataTable = daOutput.SaisuiinShomeishoHakkoKensakuDataTable;
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
