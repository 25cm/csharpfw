using System.Reflection;
using FukjBizSystem.Application.DataAccess.YoshiHanbaiDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput : ISelectYoshiHanbaiDtlTblByYoshiHanbaiChumonNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput : IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput
    {
        /// <summary>
        /// 注文番号
        /// </summary>
        public string YoshiHanbaiChumonNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput : ISelectYoshiHanbaiDtlTblByYoshiHanbaiChumonNoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput : IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput
    {
        /// <summary>
        /// 用紙販売明細テーブル
        /// </summary>
        public YoshiHanbaiDtlTblDataSet.YoshiHanbaiDtlTblDataTable YoshiHanbaiDtlTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic : BaseBusinessLogic<IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput, IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic()
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
        /// 2014/07/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput Execute(IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput output = new GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput();

            try
            {
                ISelectYoshiHanbaiDtlTblByYoshiHanbaiChumonNoDAOutput daOutput = new SelectYoshiHanbaiDtlTblByYoshiHanbaiChumonNoDataAccess().Execute(input);
                output.YoshiHanbaiDtlTblDataTable = daOutput.YoshiHanbaiDtlTblDataTable;
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
