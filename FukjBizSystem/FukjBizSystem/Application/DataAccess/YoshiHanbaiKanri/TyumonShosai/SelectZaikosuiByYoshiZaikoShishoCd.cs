using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.YoshiHanbaiKanri;
using FukjBizSystem.Application.DataSet.YoshiHanbaiKanri.TyumonShosaiDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectZaikosuiByYoshiZaikoShishoCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectZaikosuiByYoshiZaikoShishoCdDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string YoshiZaikoShishoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZaikosuiByYoshiZaikoShishoCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZaikosuiByYoshiZaikoShishoCdDAInput : ISelectZaikosuiByYoshiZaikoShishoCdDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string YoshiZaikoShishoCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectZaikosuiByYoshiZaikoShishoCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectZaikosuiByYoshiZaikoShishoCdDAOutput
    {
        /// <summary>
        /// ZaikoSuiDataTable
        /// </summary>
        TyumonShosaiDataSet.ZaikosuiDataTable ZaikoSuiDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZaikosuiByYoshiZaikoShishoCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZaikosuiByYoshiZaikoShishoCdDAOutput : ISelectZaikosuiByYoshiZaikoShishoCdDAOutput
    {
        /// <summary>
        /// ZaikoSuiDataTable
        /// </summary>
        public TyumonShosaiDataSet.ZaikosuiDataTable ZaikoSuiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZaikosuiByYoshiZaikoShishoCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZaikosuiByYoshiZaikoShishoCdDataAccess : BaseDataAccess<ISelectZaikosuiByYoshiZaikoShishoCdDAInput, ISelectZaikosuiByYoshiZaikoShishoCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ZaikosuiTableAdapter tableAdapter = new ZaikosuiTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectZaikosuiByYoshiZaikoShishoCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectZaikosuiByYoshiZaikoShishoCdDataAccess()
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
        /// 2015/01/28　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectZaikosuiByYoshiZaikoShishoCdDAOutput Execute(ISelectZaikosuiByYoshiZaikoShishoCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectZaikosuiByYoshiZaikoShishoCdDAOutput output = new SelectZaikosuiByYoshiZaikoShishoCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ZaikoSuiDataTable = tableAdapter.GetDataByYoshiZaikoShishoCd(input.YoshiZaikoShishoCd);
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
