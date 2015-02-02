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
    public interface IStdFilteredGetDataBLInput : IStdFilteredSelectDataDAInput
    {

    }
    #endregion

    #region StdFilteredGetDataBLInput
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
    public class StdFilteredGetDataBLInput : StdFilteredSelectDataDAInput, IStdFilteredGetDataBLInput
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
    public interface IStdFilteredGetDataBLOutput
    {
        /// <summary>
        /// 
        /// </summary>
        DataTable GetDataTable { set; get; }
    }
    #endregion

    #region StdFilteredGetDataBLOutput
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
    public class StdFilteredGetDataBLOutput : IStdFilteredGetDataBLOutput
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
    public class StdFilteredGetDataBusinessLogic : BaseBusinessLogic<IStdFilteredGetDataBLInput, IStdFilteredGetDataBLOutput>
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
        public override IStdFilteredGetDataBLOutput Execute(IStdFilteredGetDataBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBLOutput();

            try
            {
                IStdFilteredSelectDataDAOutput daOutput = new StdFilteredSelectDataDataAccess().Execute(input);

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
