using System;
using System.Reflection;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.Common
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
    interface IStdDeleteDataDAInput : IBaseStdDeleteDataDAInput
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
    class StdDeleteDataDAInput : BaseStdDeleteDataDAInput, IStdDeleteDataDAInput
    {
        public StdDeleteDataDAInput()
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
    interface IStdDeleteDataDAOutput : IBaseStdDeleteDataDAOutput
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
    class StdDeleteDataDAOutput : BaseStdDeleteDataDAOutput , IStdDeleteDataDAOutput
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
    class StdDeleteDataDataAccess : BaseStdDeleteDataDataAccess
    {
        #region プロパティ(private)

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
        /// 2014/08/29　habu　　    新規作成
        /// </history>
        public StdDeleteDataDataAccess()
            : base(Properties.Settings.Default.FukjBizSystemConnectionString)
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
        public IStdDeleteDataDAOutput Execute(IStdDeleteDataDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IStdDeleteDataDAOutput output = new StdDeleteDataDAOutput();

            try
            {
                IBaseStdDeleteDataDAOutput toutput = base.Execute(input);

                output.RowCount = toutput.RowCount;
            }
            catch (Exception e)
            {
                // トレースログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("エラー内容:{0}", e.Message));

                // ＤＢエラー
                throw new CustomException(ResultCode.DBError, string.Format("エラー内容:{0}", e.Message));
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
