using System.Reflection;
using FukjBizSystem.Application.DataAccess.YoshiHanbaiKanri.TyumonShosai;
using FukjBizSystem.Application.DataSet.YoshiHanbaiKanri;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetZaikosuiByYoshiZaikoShishoCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetZaikosuiByYoshiZaikoShishoCdBLInput : ISelectZaikosuiByYoshiZaikoShishoCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetZaikosuiByYoshiZaikoShishoCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetZaikosuiByYoshiZaikoShishoCdBLInput : IGetZaikosuiByYoshiZaikoShishoCdBLInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string YoshiZaikoShishoCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetZaikosuiByYoshiZaikoShishoCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetZaikosuiByYoshiZaikoShishoCdBLOutput : ISelectZaikosuiByYoshiZaikoShishoCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetZaikosuiByYoshiZaikoShishoCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetZaikosuiByYoshiZaikoShishoCdBLOutput : IGetZaikosuiByYoshiZaikoShishoCdBLOutput
    {
        /// <summary>
        /// ZaikoSuiDataTable
        /// </summary>
        public TyumonShosaiDataSet.ZaikosuiDataTable ZaikoSuiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetZaikosuiByYoshiZaikoShishoCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetZaikosuiByYoshiZaikoShishoCdBusinessLogic : BaseBusinessLogic<IGetZaikosuiByYoshiZaikoShishoCdBLInput, IGetZaikosuiByYoshiZaikoShishoCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetZaikosuiByYoshiZaikoShishoCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetZaikosuiByYoshiZaikoShishoCdBusinessLogic()
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
        /// 2015/01/28　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetZaikosuiByYoshiZaikoShishoCdBLOutput Execute(IGetZaikosuiByYoshiZaikoShishoCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetZaikosuiByYoshiZaikoShishoCdBLOutput output = new GetZaikosuiByYoshiZaikoShishoCdBLOutput();

            try
            {
                ISelectZaikosuiByYoshiZaikoShishoCdDAOutput daOutput = new SelectZaikosuiByYoshiZaikoShishoCdDataAccess().Execute(input);
                output.ZaikoSuiDataTable = daOutput.ZaikoSuiDataTable;
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
