using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.MemoDaibunruiMst;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.MemoTabPage
{

    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMemoDaibunruiMstBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMemoDaibunruiMstBLInput : ISelectAllMemoDaibunruiMstDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoDaibunruiMstBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
	class GetMemoDaibunruiMstBLInput : IGetMemoDaibunruiMstBLInput
    {
	}
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMemoDaibunruiMstBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMemoDaibunruiMstBLOutput : ISelectAllMemoDaibunruiMstDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoDaibunruiMstBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMemoDaibunruiMstBLOutput : IGetMemoDaibunruiMstBLOutput
    {
        /// <summary>
        /// MemoDaibunruiMstDataTable
        /// </summary>
		public MemoDaibunruiMstDataSet.MemoDaibunruiMstDataTable MemoDaibunruiMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoDaibunruiMstBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMemoDaibunruiMstBusinessLogic : BaseBusinessLogic<IGetMemoDaibunruiMstBLInput, IGetMemoDaibunruiMstBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMemoDaibunruiMstBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetMemoDaibunruiMstBusinessLogic()
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
        /// 2014/11/14　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetMemoDaibunruiMstBLOutput Execute(IGetMemoDaibunruiMstBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMemoDaibunruiMstBLOutput output = new GetMemoDaibunruiMstBLOutput();

            try
            {
                ISelectAllMemoDaibunruiMstDAOutput daOutput = new SelectAllMemoDaibunruiMstDataAccess().Execute(input);
                output.MemoDaibunruiMst = daOutput.MemoDaibunruiMst;
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
