using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.NameMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NameMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectNameMstShokenByNameKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectNameMstShokenByNameKbnDAInput
    {
        /// <summary>
        /// NameKbn
        /// </summary>
        string NameKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNameMstShokenByNameKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNameMstShokenByNameKbnDAInput : ISelectNameMstShokenByNameKbnDAInput
    {
        /// <summary>
        /// NameKbn
        /// </summary>
        public string NameKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectNameMstShokenByNameKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectNameMstShokenByNameKbnDAOutput
    {
        /// <summary>
        /// NameMstShokenDataTable
        /// </summary>
        NameMstDataSet.NameMstShokenDataTable NameMstShokenDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNameMstShokenByNameKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNameMstShokenByNameKbnDAOutput : ISelectNameMstShokenByNameKbnDAOutput
    {
        /// <summary>
        /// NameMstShokenDataTable
        /// </summary>
        public NameMstDataSet.NameMstShokenDataTable NameMstShokenDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNameMstShokenByNameKbnDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNameMstShokenByNameKbnDataAccess : BaseDataAccess<ISelectNameMstShokenByNameKbnDAInput, ISelectNameMstShokenByNameKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NameMstShokenTableAdapter tableAdapter = new NameMstShokenTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectNameMstShokenByNameKbnDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectNameMstShokenByNameKbnDataAccess()
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
        /// 2014/08/22　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectNameMstShokenByNameKbnDAOutput Execute(ISelectNameMstShokenByNameKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectNameMstShokenByNameKbnDAOutput output = new SelectNameMstShokenByNameKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.NameMstShokenDataTable = tableAdapter.GetDataByNameKbn(input.NameKbn);

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
