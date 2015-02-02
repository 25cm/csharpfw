using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ChikuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ChikuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectChikuMstCommonBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/08  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectChikuMstCommonBySearchCondDAInput
    {
        /// <summary>
        /// 地区コード（開始）
        /// </summary>
        string ChikuCdFrom { get; set; }

        /// <summary>
        /// 地区コード（終了）
        /// </summary>
        string ChikuCdTo { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        string ChikuNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectChikuMstCommonBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/08  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectChikuMstCommonBySearchCondDAInput : ISelectChikuMstCommonBySearchCondDAInput
    {
        /// <summary>
        /// 地区コード（開始）
        /// </summary>
        public string ChikuCdFrom { get; set; }

        /// <summary>
        /// 地区コード（終了）
        /// </summary>
        public string ChikuCdTo { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public string ChikuNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectChikuMstCommonBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/08  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectChikuMstCommonBySearchCondDAOutput
    {
        /// <summary>
        /// ChikuMstSearchCommonDataTable
        /// </summary>
        ChikuMstDataSet.ChikuMstSearchCommonDataTable ChikuMstSearchCommonDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectChikuMstCommonBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/08  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectChikuMstCommonBySearchCondDAOutput : ISelectChikuMstCommonBySearchCondDAOutput
    {
        /// <summary>
        /// ChikuMstSearchCommonDataTable
        /// </summary>
        public ChikuMstDataSet.ChikuMstSearchCommonDataTable ChikuMstSearchCommonDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectChikuMstCommonBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/08  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectChikuMstCommonBySearchCondDataAccess : BaseDataAccess<ISelectChikuMstCommonBySearchCondDAInput, ISelectChikuMstCommonBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ChikuMstSearchCommonTableAdapter tableAdapter = new ChikuMstSearchCommonTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectChikuMstCommonBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/08  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectChikuMstCommonBySearchCondDataAccess()
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
        /// 2014/10/08  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectChikuMstCommonBySearchCondDAOutput Execute(ISelectChikuMstCommonBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectChikuMstCommonBySearchCondDAOutput output = new SelectChikuMstCommonBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ChikuMstSearchCommonDataTable = tableAdapter.GetDataBySearchCond(input.ChikuCdFrom, input.ChikuCdTo, input.ChikuNm);

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
