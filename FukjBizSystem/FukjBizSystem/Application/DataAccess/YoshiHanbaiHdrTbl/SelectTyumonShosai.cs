using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.YoshiHanbaiHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.YoshiHanbaiHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectTyumonShosaiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectTyumonShosaiDAInput
    {
        /// <summary>
        /// 注文番号
        /// </summary>
        string YoshiHanbaiChumonNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectTyumonShosaiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectTyumonShosaiDAInput : ISelectTyumonShosaiDAInput
    {
        /// <summary>
        /// 注文番号
        /// </summary>
        public string YoshiHanbaiChumonNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectTyumonShosaiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectTyumonShosaiDAOutput
    {
        /// <summary>
        /// TyumonShosaiDataTable
        /// </summary>
        YoshiHanbaiHdrTblDataSet.TyumonShosaiDataTable TyumonShosaiDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectTyumonShosaiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectTyumonShosaiDAOutput : ISelectTyumonShosaiDAOutput
    {
        /// <summary>
        /// TyumonShosaiDataTable
        /// </summary>
        public YoshiHanbaiHdrTblDataSet.TyumonShosaiDataTable TyumonShosaiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectTyumonShosaiDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectTyumonShosaiDataAccess : BaseDataAccess<ISelectTyumonShosaiDAInput, ISelectTyumonShosaiDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private TyumonShosaiTableAdapter tableAdapter = new TyumonShosaiTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectTyumonShosaiDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectTyumonShosaiDataAccess()
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
        /// 2014/07/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectTyumonShosaiDAOutput Execute(ISelectTyumonShosaiDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectTyumonShosaiDAOutput output = new SelectTyumonShosaiDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.TyumonShosaiDataTable = tableAdapter.GetDataByYoshiHanbaiChumonNo(input.YoshiHanbaiChumonNo);
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
