using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuShikenKoumokuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.SuishitsuShikenKoumokuMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuShikenKoumokuMstKensakuByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuShikenKoumokuMstKensakuByCondBLInput : ISelectSuishitsuShikenKoumokuMstKensakuByCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuShikenKoumokuMstKensakuByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuShikenKoumokuMstKensakuByCondBLInput : IGetSuishitsuShikenKoumokuMstKensakuByCondBLInput
    {
        /// <summary>
        /// 水質試験項目コードFROM
        /// </summary>
        public string SuishitsuShikenKoumokuCdFrom { get; set; }

        /// <summary>
        /// 水質試験項目コードTO
        /// </summary>
        public string SuishitsuShikenKoumokuCdTo { get; set; }

        /// <summary>
        /// 正式名称
        /// </summary>
        public string SeishikiNm { get; set; }

        /// <summary>
        /// 略式名称
        /// </summary>
        public string RyakushikiNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuShikenKoumokuMstKensakuByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuShikenKoumokuMstKensakuByCondBLOutput : ISelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuShikenKoumokuMstKensakuByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuShikenKoumokuMstKensakuByCondBLOutput : IGetSuishitsuShikenKoumokuMstKensakuByCondBLOutput
    {
        /// <summary>
        /// SuishitsuShikenKoumokuMstKensakuDataTable
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstKensakuDataTable SuishitsuShikenKoumokuMstKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuShikenKoumokuMstKensakuByCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuShikenKoumokuMstKensakuByCondBusinessLogic : BaseBusinessLogic<IGetSuishitsuShikenKoumokuMstKensakuByCondBLInput, IGetSuishitsuShikenKoumokuMstKensakuByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuShikenKoumokuMstKensakuByCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuShikenKoumokuMstKensakuByCondBusinessLogic()
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
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuShikenKoumokuMstKensakuByCondBLOutput Execute(IGetSuishitsuShikenKoumokuMstKensakuByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuShikenKoumokuMstKensakuByCondBLOutput output = new GetSuishitsuShikenKoumokuMstKensakuByCondBLOutput();

            try
            {
                ISelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput daOutput = new SelectSuishitsuShikenKoumokuMstKensakuByCondDataAccess().Execute(input);
                output.SuishitsuShikenKoumokuMstKensakuDataTable = daOutput.SuishitsuShikenKoumokuMstKensakuDataTable;
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
