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
    public interface IBaseStdUpdateDataBLInput : IBaseStdUpdateDataDAInput
    {

    }
    #endregion

    #region BaseStdUpdateDataBLInput
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
    public class BaseStdUpdateDataBLInput : BaseStdUpdateDataDAInput, IBaseStdUpdateDataBLInput
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
    public interface IBaseStdUpdateDataBLOutput
    {

    }
    #endregion

    #region BaseStdUpdateDataBLOutput
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
    public class BaseStdUpdateDataBLOutput : IBaseStdUpdateDataBLOutput
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
    /// 2014/08/27　土生　　    新規作成
    /// </history>
    public class BaseStdUpdateDataBusinessLogic : BaseBusinessLogic<IBaseStdUpdateDataBLInput, IBaseStdUpdateDataBLOutput>
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
        public BaseStdUpdateDataBusinessLogic(string connectionString)
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
        public override IBaseStdUpdateDataBLOutput Execute(IBaseStdUpdateDataBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IBaseStdUpdateDataBLOutput output = new BaseStdUpdateDataBLOutput();

            try
            {
                IBaseStdUpdateDataDAOutput daOutput = new BaseStdUpdateDataDataAccess(connectionString).Execute(input);

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
