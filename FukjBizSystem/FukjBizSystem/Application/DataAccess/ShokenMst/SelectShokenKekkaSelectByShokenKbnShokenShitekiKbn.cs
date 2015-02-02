using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShokenMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShokenMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAInput
    {
        /// <summary>
        /// 所見区分
        /// </summary>
        string ShokenKbn { get; set; }

        /// <summary>
        /// 対象検査ビットマスク
        /// </summary>
        int ShokenTaishoKensaBitMask { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAInput : ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAInput
    {
        /// <summary>
        /// 所見区分
        /// </summary>
        public string ShokenKbn { get; set; }

        /// <summary>
        /// 対象検査ビットマスク
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput
    {
        /// <summary>
        /// ShokenKekkaSelectDataTable
        /// </summary>
        ShokenMstDataSet.ShokenKekkaSelectDataTable ShokenKekkaSelectDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput : ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput
    {
        /// <summary>
        /// ShokenKekkaSelectDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenKekkaSelectDataTable ShokenKekkaSelectDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDataAccess : BaseDataAccess<ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAInput, ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokenKekkaSelectTableAdapter tableAdapter = new ShokenKekkaSelectTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/31　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDataAccess()
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
        /// 2014/10/31　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput Execute(ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput output = new SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShokenKekkaSelectDataTable = tableAdapter.GetDataByKbn(input.ShokenKbn, input.ShokenTaishoKensaBitMask);
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
