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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    interface IStdDeleteDataBLInput : IStdDeleteDataDAInput
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    class StdDeleteDataBLInput : StdDeleteDataDAInput, IStdDeleteDataBLInput
    {
        public StdDeleteDataBLInput()
            : base()
        {
            KeyColNameList = new System.Collections.Generic.List<string>();
            ValueList = new System.Collections.Generic.List<object>();
        }
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    interface IStdDeleteDataBLOutput : IStdDeleteDataDAOutput
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    class StdDeleteDataBLOutput : StdDeleteDataDAOutput, IStdDeleteDataBLOutput
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    class StdDeleteDataBusinessLogic : BaseBusinessLogic<IStdDeleteDataBLInput, IStdDeleteDataBLOutput>
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
        /// 2014/08/29　habu　　    新規作成
        /// </history>
        public StdDeleteDataBusinessLogic()
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
        /// 2014/08/29　habu　　    新規作成
        /// </history>
        public override IStdDeleteDataBLOutput Execute(IStdDeleteDataBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IStdDeleteDataBLOutput output = new StdDeleteDataBLOutput();

            try
            {
                IStdDeleteDataDAOutput daOutput = new StdDeleteDataDataAccess().Execute(input);

                output.RowCount = daOutput.RowCount;
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
