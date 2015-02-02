using System.Reflection;
using FukjBizSystem.Application.DataAccess.HoshoTorokuTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput : ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput : IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput
    {
        /// <summary>
        /// 支所区分
        /// </summary>
        public string HoshoTorokuShishoKbn { get; set; }

        /// <summary>
        /// 売上日付
        /// </summary>
        public string HoshoTorokuUriageDt { get; set; }

        /// <summary>
        /// 販売先コード
        /// </summary>
        public string HoshoTorokuHanbaisakiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput : ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput : IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput
    {
        /// <summary>
        /// 保証登録テーブル
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBusinessLogic : BaseBusinessLogic<IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput, IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBusinessLogic()
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
        /// 2014/10/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput Execute(IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput output = new GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput();

            try
            {
                ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput daOutput = new SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDataAccess().Execute(input);
                output.HoshoTorokuTblDataTable = daOutput.HoshoTorokuTblDataTable;
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
