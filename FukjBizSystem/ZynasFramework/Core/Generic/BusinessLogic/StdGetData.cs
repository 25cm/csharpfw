using System.Data;
using System.Reflection;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Core.Generic.DataAccess;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Generic.BusinessLogic
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
    /// 2014/08/27　土生　　    新規作成
    /// </history>
    public interface IStdGetDataBLInput : IStdSelectDataDAInput
    {

    }
    #endregion

    #region StdGetDataBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　土生　　    新規作成
    /// </history>
    public class StdGetDataBLInput : StdSelectDataDAInput, IStdGetDataBLInput
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
    /// 2014/08/27　土生　　    新規作成
    /// </history>
    public interface IStdGetDataBLOutput
    {
        /// <summary>
        /// 
        /// </summary>
        DataTable GetDataTable { set; get; }
    }
    #endregion

    #region StdGetDataBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/27　土生　　    新規作成
    /// </history>
    public class StdGetDataBLOutput : IStdGetDataBLOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public DataTable GetDataTable { set; get; }
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
    /// 2014/08/27　土生　　    新規作成
    /// </history>
    public class StdGetDataBusinessLogic : BaseBusinessLogic<IStdGetDataBLInput, IStdGetDataBLOutput>
    {
        #region メソッド(public)

        #region Execute
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　土生　　    新規作成
        /// </history>
        public override IStdGetDataBLOutput Execute(IStdGetDataBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IStdGetDataBLOutput output = new StdGetDataBLOutput();

            try
            {
                IStdSelectDataDAOutput daOutput = new StdSelectDataDataAccess().Execute(input);

                output.GetDataTable = daOutput.SelectDataTable;
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
