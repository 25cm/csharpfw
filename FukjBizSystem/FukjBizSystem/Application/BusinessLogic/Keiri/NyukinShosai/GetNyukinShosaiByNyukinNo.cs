using System.Reflection;
using FukjBizSystem.Application.DataAccess.NyukinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNyukinShosaiByNyukinNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNyukinShosaiByNyukinNoBLInput : ISelectNyukinShosaiByNyukinNoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinShosaiByNyukinNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNyukinShosaiByNyukinNoBLInput : IGetNyukinShosaiByNyukinNoBLInput
    {
        /// <summary>
        /// NyukinNo 
        /// </summary>
        public string NyukinNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNyukinShosaiByNyukinNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNyukinShosaiByNyukinNoBLOutput : ISelectNyukinShosaiByNyukinNoDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinShosaiByNyukinNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNyukinShosaiByNyukinNoBLOutput : IGetNyukinShosaiByNyukinNoBLOutput
    {
        /// <summary>
        /// NyukinTblShosaiDataTable
        /// </summary>
        public NyukinTblDataSet.NyukinTblShosaiDataTable NyukinTblShosaiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinShosaiByNyukinNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNyukinShosaiByNyukinNoBusinessLogic : BaseBusinessLogic<IGetNyukinShosaiByNyukinNoBLInput, IGetNyukinShosaiByNyukinNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetNyukinShosaiByNyukinNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/07  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetNyukinShosaiByNyukinNoBusinessLogic()
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
        /// 2014/10/07  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetNyukinShosaiByNyukinNoBLOutput Execute(IGetNyukinShosaiByNyukinNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetNyukinShosaiByNyukinNoBLOutput output = new GetNyukinShosaiByNyukinNoBLOutput();

            try
            {
                output.NyukinTblShosaiDataTable = new SelectNyukinShosaiByNyukinNoDataAccess().Execute(input).NyukinTblShosaiDataTable;

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
