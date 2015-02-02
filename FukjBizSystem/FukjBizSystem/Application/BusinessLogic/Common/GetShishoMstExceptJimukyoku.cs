using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShishoMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShishoMstExceptJimukyokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShishoMstExceptJimukyokuBLInput : ISelectShishoMstExceptJimukyokuDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShishoMstExceptJimukyokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShishoMstExceptJimukyokuBLInput : IGetShishoMstExceptJimukyokuBLInput
    {

    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShishoMstExceptJimukyokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShishoMstExceptJimukyokuBLOutput : ISelectShishoMstExceptJimukyokuDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShishoMstExceptJimukyokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShishoMstExceptJimukyokuBLOutput : IGetShishoMstExceptJimukyokuBLOutput
    {
        /// <summary>
        /// ShishoMstExceptJimukyokuDataTable
        /// </summary>
        public ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable ShishoMstExceptJimukyokuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShishoMstExceptJimukyokuBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShishoMstExceptJimukyokuBusinessLogic : BaseBusinessLogic<IGetShishoMstExceptJimukyokuBLInput, IGetShishoMstExceptJimukyokuBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShishoMstExceptJimukyokuBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShishoMstExceptJimukyokuBusinessLogic()
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
        /// 2015/01/27　宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShishoMstExceptJimukyokuBLOutput Execute(IGetShishoMstExceptJimukyokuBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShishoMstExceptJimukyokuBLOutput output = new GetShishoMstExceptJimukyokuBLOutput();

            try
            {
                ISelectShishoMstExceptJimukyokuDAOutput daOutput = new SelectShishoMstExceptJimukyokuDataAccess().Execute(input);
                output.ShishoMstExceptJimukyokuDT = daOutput.ShishoMstExceptJimukyokuDT;
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
