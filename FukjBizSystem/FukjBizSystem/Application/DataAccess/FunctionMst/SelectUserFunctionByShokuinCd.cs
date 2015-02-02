using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.FunctionMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.FunctionMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectUserFunctionByShokuinCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectUserFunctionByShokuinCdDAInput
    {
        /// <summary>
        /// 職員コード 
        /// </summary>
        string ShokuinCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectUserFunctionByShokuinCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectUserFunctionByShokuinCdDAInput : ISelectUserFunctionByShokuinCdDAInput
    {
        /// <summary>
        /// 職員コード 
        /// </summary>
        public string ShokuinCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectUserFunctionByShokuinCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectUserFunctionByShokuinCdDAOutput
    {
        /// <summary>
        /// UserFunctionDataTable
        /// </summary>
        FunctionMstDataSet.UserFunctionDataTable UserFunction { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectUserFunctionByShokuinCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectUserFunctionByShokuinCdDAOutput : ISelectUserFunctionByShokuinCdDAOutput
    {
        /// <summary>
        /// UserFunctionDataTable
        /// </summary>
        public FunctionMstDataSet.UserFunctionDataTable UserFunction { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectUserFunctionByShokuinCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/18  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectUserFunctionByShokuinCdDataAccess : BaseDataAccess<ISelectUserFunctionByShokuinCdDAInput, ISelectUserFunctionByShokuinCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private UserFunctionTableAdapter tableAdapter = new UserFunctionTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectUserFunctionByShokuinCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/18  豊田　      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectUserFunctionByShokuinCdDataAccess()
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
        /// 2014/12/18  豊田　      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectUserFunctionByShokuinCdDAOutput Execute(ISelectUserFunctionByShokuinCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectUserFunctionByShokuinCdDAOutput output = new SelectUserFunctionByShokuinCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.UserFunction = tableAdapter.GetDataByShokuinCd(input.ShokuinCd);

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
