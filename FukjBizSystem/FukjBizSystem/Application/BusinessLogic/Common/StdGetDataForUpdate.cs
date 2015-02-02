using System.Reflection;
using FukjBizSystem.Application.DataAccess.Common;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    interface IStdGetDataForUpdateBLInput : IStdSelectDataForUpdateDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    class StdGetDataForUpdateBLInput : StdSelectDataForUpdateDAInput, IStdGetDataForUpdateBLInput
    {

    }
    #endregion

    #region 出力インターフェイス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    interface IStdGetDataForUpdateBLOutput : IStdSelectDataForUpdateDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    class StdGetDataForUpdateBLOutput : StdSelectDataForUpdateDAOutput, IStdGetDataForUpdateBLOutput
    {

    }
    #endregion

    #region クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　habu　　    新規作成
    /// </history>
    class StdGetDataForUpdateBusinessLogic : BaseBusinessLogic<IStdGetDataForUpdateBLInput, IStdGetDataForUpdateBLOutput>
    {
        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　habu　　    新規作成
        /// </history>
        public StdGetDataForUpdateBusinessLogic()
        {

        }
        #endregion

        #region メソッド(public)

        #region Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　habu　　    新規作成
        /// </history>
        public override IStdGetDataForUpdateBLOutput Execute(IStdGetDataForUpdateBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IStdGetDataForUpdateBLOutput output = new StdGetDataForUpdateBLOutput();

            try
            {
                IStdSelectDataForUpdateDAOutput daOutput = new StdSelectDataForUpdateDataAccess().Execute(input);

                output.SelectDataTable = daOutput.SelectDataTable;
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
