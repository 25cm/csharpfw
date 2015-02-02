using System.Reflection;
using FukjBizSystem.Application.DataAccess.ConstMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.BushoMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetConstMstByKeyBLInput
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
    interface IGetConstMstByKeyBLInput : ISelectConstMstByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetConstMstByKeyBLInput
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
    class GetConstMstByKeyBLInput : IGetConstMstByKeyBLInput
    {
        /// <summary>
        /// 定数区分
        /// </summary>
        public string ConstKbn { get; set; }
        /// <summary>
        /// 連番
        /// </summary>
        public string ConstRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetConstMstByKeyBLOutput
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
    interface IGetConstMstByKeyBLOutput : ISelectConstMstByKeyDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetConstMstByKeyBLOutput
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
    class GetConstMstByKeyBLOutput : IGetConstMstByKeyBLOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public ConstMstDataSet.ConstMstDataTable DataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetConstMstByKeyBusinessLogic
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
    class GetConstMstByKeyBusinessLogic : BaseBusinessLogic<IGetConstMstByKeyBLInput, IGetConstMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetConstMstByKeyBusinessLogic
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
        public GetConstMstByKeyBusinessLogic()
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
        public override IGetConstMstByKeyBLOutput Execute(IGetConstMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetConstMstByKeyBLOutput output = new GetConstMstByKeyBLOutput();

            try
            {
                ISelectConstMstByKeyDAOutput daOutput = new SelectConstMstByKeyDataAccess().Execute(input);

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
