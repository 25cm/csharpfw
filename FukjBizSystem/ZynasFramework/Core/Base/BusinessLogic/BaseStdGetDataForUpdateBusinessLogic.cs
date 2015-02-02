using System.Data;
using System.Reflection;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace Zynas.Framework.Core.Base.BusinessLogic
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
    public interface IBaseStdGetDataForUpdateBLInput : IBaseStdSelectDataForUpdateDAInput
    {

    }
    #endregion

    #region BaseStdGetDataForUpdateBLInput
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
    public class BaseStdGetDataForUpdateBLInput : BaseStdSelectDataForUpdateDAInput, IBaseStdGetDataForUpdateBLInput
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
    public interface IBaseStdGetDataForUpdateBLOutput
    {
        /// <summary>
        /// 
        /// </summary>
        DataTable GetDataTable { set; get; }
    }
    #endregion

    #region BaseStdGetDataForUpdateBLOutput
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
    public class BaseStdGetDataForUpdateBLOutput : IBaseStdGetDataForUpdateBLOutput
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
    public class BaseStdGetDataForUpdateBusinessLogic : BaseBusinessLogic<IBaseStdGetDataForUpdateBLInput, IBaseStdGetDataForUpdateBLOutput>
    {
        #region プロパティ(private)

        private string connectionString = string.Empty;

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="connectionString">ConnectionString.Typycally get from app.config</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/27　habu　　    新規作成
        /// </history>
        public BaseStdGetDataForUpdateBusinessLogic(string connectionString)
        {
            this.connectionString = connectionString;
        }
        #endregion

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
        public override IBaseStdGetDataForUpdateBLOutput Execute(IBaseStdGetDataForUpdateBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IBaseStdGetDataForUpdateBLOutput output = new BaseStdGetDataForUpdateBLOutput();

            try
            {
                IBaseStdSelectDataForUpdateDAOutput daOutput = new BaseStdSelectDataForUpdateDataAccess(connectionString).Execute(input);

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
