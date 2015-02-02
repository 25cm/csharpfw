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
    //  インターフェイス名 ： ISelectYoshiDetailByShishoCdChumonNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYoshiDetailByShishoCdChumonNoDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string YoshiHanbaiShishoCd { get; set; }

        /// <summary>
        /// 注文番号
        /// </summary>
        string YoshiHanbaiChumonNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYoshiDetailByShishoCdChumonNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYoshiDetailByShishoCdChumonNoDAInput : ISelectYoshiDetailByShishoCdChumonNoDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string YoshiHanbaiShishoCd { get; set; }

        /// <summary>
        /// 注文番号
        /// </summary>
        public string YoshiHanbaiChumonNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYoshiDetailByShishoCdChumonNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYoshiDetailByShishoCdChumonNoDAOutput
    {
        /// <summary>
        /// YoshiDetailDataTable
        /// </summary>
        TyumonShosaiDataSet.YoshiDetailDataTable YoshiDetailDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYoshiDetailByShishoCdChumonNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYoshiDetailByShishoCdChumonNoDAOutput : ISelectYoshiDetailByShishoCdChumonNoDAOutput
    {
        /// <summary>
        /// YoshiDetailDataTable
        /// </summary>
        public TyumonShosaiDataSet.YoshiDetailDataTable YoshiDetailDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYoshiDetailByShishoCdChumonNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYoshiDetailByShishoCdChumonNoDataAccess : BaseDataAccess<ISelectYoshiDetailByShishoCdChumonNoDAInput, ISelectYoshiDetailByShishoCdChumonNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private YoshiDetailTableAdapter tableAdapter = new YoshiDetailTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectYoshiDetailByShishoCdChumonNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectYoshiDetailByShishoCdChumonNoDataAccess()
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
        /// 2015/01/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectYoshiDetailByShishoCdChumonNoDAOutput Execute(ISelectYoshiDetailByShishoCdChumonNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectYoshiDetailByShishoCdChumonNoDAOutput output = new SelectYoshiDetailByShishoCdChumonNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.YoshiDetailDataTable = tableAdapter.GetDataByYoshiCdChumonNo(input.YoshiHanbaiShishoCd, input.YoshiHanbaiChumonNo);
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
