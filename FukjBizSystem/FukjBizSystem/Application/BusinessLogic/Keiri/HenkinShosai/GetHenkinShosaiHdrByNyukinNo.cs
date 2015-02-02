using System.Reflection;
using FukjBizSystem.Application.DataAccess.HenkinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.HenkinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHenkinShosaiHdrByNyukinNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHenkinShosaiHdrByNyukinNoBLInput : ISelectHenkinShosaiHdrByNyukinNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHenkinShosaiHdrByNyukinNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHenkinShosaiHdrByNyukinNoBLInput : IGetHenkinShosaiHdrByNyukinNoBLInput
    {
        /// <summary>
        /// 入金No
        /// </summary>
        public string NyukinNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHenkinShosaiHdrByNyukinNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHenkinShosaiHdrByNyukinNoBLOutput : ISelectHenkinShosaiHdrByNyukinNoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHenkinShosaiHdrByNyukinNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHenkinShosaiHdrByNyukinNoBLOutput : IGetHenkinShosaiHdrByNyukinNoBLOutput
    {
        /// <summary>
        /// HekinShosaiHdrDataTable
        /// </summary>
        public HenkinTblDataSet.HekinShosaiHdrDataTable HekinShosaiHdrDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHenkinShosaiHdrByNyukinNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHenkinShosaiHdrByNyukinNoBusinessLogic : BaseBusinessLogic<IGetHenkinShosaiHdrByNyukinNoBLInput, IGetHenkinShosaiHdrByNyukinNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetHenkinShosaiHdrByNyukinNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetHenkinShosaiHdrByNyukinNoBusinessLogic()
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
        /// 2014/11/05　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetHenkinShosaiHdrByNyukinNoBLOutput Execute(IGetHenkinShosaiHdrByNyukinNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetHenkinShosaiHdrByNyukinNoBLOutput output = new GetHenkinShosaiHdrByNyukinNoBLOutput();

            try
            {
                ISelectHenkinShosaiHdrByNyukinNoDAOutput daOutput = new SelectHenkinShosaiHdrByNyukinNoDataAccess().Execute(input);
                output.HekinShosaiHdrDataTable = daOutput.HekinShosaiHdrDataTable;
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
