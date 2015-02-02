using System.Reflection;
using FukjBizSystem.Application.DataAccess.ConstMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.BushoMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetConstMstByKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetConstMstByKbnBLInput : ISelectConstMstByKbnDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetConstMstByKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetConstMstByKbnBLInput : IGetConstMstByKbnBLInput
    {
        /// <summary>
        /// 定数区分
        /// </summary>
        public string ConstKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetConstMstByKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetConstMstByKbnBLOutput : ISelectConstMstByKbnDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetConstMstByKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetConstMstByKbnBLOutput : IGetConstMstByKbnBLOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public ConstMstDataSet.ConstMstDataTable DataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetConstMstByKbnBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetConstMstByKbnBusinessLogic : BaseBusinessLogic<IGetConstMstByKbnBLInput, IGetConstMstByKbnBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetConstMstByKbnBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetConstMstByKbnBusinessLogic()
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
        /// 2014/08/07　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetConstMstByKbnBLOutput Execute(IGetConstMstByKbnBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetConstMstByKbnBLOutput output = new GetConstMstByKbnBLOutput();

            try
            {
                ISelectConstMstByKbnDAOutput daOutput = new SelectConstMstByKbnDataAccess().Execute(input);

                output.DataTable = daOutput.DataTable;
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
