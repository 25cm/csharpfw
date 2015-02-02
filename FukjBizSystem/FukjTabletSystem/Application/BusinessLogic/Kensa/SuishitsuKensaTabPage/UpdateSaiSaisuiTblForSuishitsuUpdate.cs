using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.SaiSaisuiTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.SuishitsuKensaTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSaiSaisuiTblForSuishitsuUpdateBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateSaiSaisuiTblForSuishitsuUpdateBLInput : IUpdateSaiSaisuiTblForSuishitsuUpdateDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSaiSaisuiTblForSuishitsuUpdateBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSaiSaisuiTblForSuishitsuUpdateBLInput : IUpdateSaiSaisuiTblForSuishitsuUpdateBLInput
    {
        /// <summary>
        /// SaiSaisuiTblForSuishitsuUpdate
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblForSuishitsuUpdateDataTable SaiSaisuiTblForSuishitsuUpdate { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSaiSaisuiTblForSuishitsuUpdateBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateSaiSaisuiTblForSuishitsuUpdateBLOutput : IUpdateSaiSaisuiTblForSuishitsuUpdateDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSaiSaisuiTblForSuishitsuUpdateBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSaiSaisuiTblForSuishitsuUpdateBLOutput : IUpdateSaiSaisuiTblForSuishitsuUpdateBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSaiSaisuiTblForSuishitsuUpdateBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSaiSaisuiTblForSuishitsuUpdateBusinessLogic : BaseBusinessLogic<IUpdateSaiSaisuiTblForSuishitsuUpdateBLInput, IUpdateSaiSaisuiTblForSuishitsuUpdateBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateSaiSaisuiTblForSuishitsuUpdateBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/21　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateSaiSaisuiTblForSuishitsuUpdateBusinessLogic()
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
        /// 2014/11/21　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateSaiSaisuiTblForSuishitsuUpdateBLOutput Execute(IUpdateSaiSaisuiTblForSuishitsuUpdateBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateSaiSaisuiTblForSuishitsuUpdateBLOutput output = new UpdateSaiSaisuiTblForSuishitsuUpdateBLOutput();

            try
            {
                new UpdateSaiSaisuiTblForSuishitsuUpdateDataAccess().Execute(input);
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
