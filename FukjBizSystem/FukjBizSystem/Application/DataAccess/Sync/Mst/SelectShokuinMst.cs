using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShokuinMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.Sync.Mst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokuinMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface ISelectShokuinMstDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokuinMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SelectShokuinMstDAInput : ISelectShokuinMstDAInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokuinMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface ISelectShokuinMstDAOutput
    {
        /// <summary>
        /// ShokuinMst
        /// </summary>
        ShokuinMstDataSet.ShokuinMstDataTable ShokuinMst { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokuinMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SelectShokuinMstDAOutput : ISelectShokuinMstDAOutput
    {
        /// <summary>
        /// ShokuinMst
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokuinMstDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SelectShokuinMstDataAccess : BaseDataAccess<ISelectShokuinMstDAInput, ISelectShokuinMstDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokuinMstTableAdapter tableAdapter = new ShokuinMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShokuinMstDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShokuinMstDataAccess()
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
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShokuinMstDAOutput Execute(ISelectShokuinMstDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShokuinMstDAOutput output = new SelectShokuinMstDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShokuinMst = tableAdapter.GetData();

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
