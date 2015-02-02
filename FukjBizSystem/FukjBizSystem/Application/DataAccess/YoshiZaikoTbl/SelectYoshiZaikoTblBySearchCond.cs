using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.YoshiZaikoTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.YoshiZaikoTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYoshiZaikoTblBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYoshiZaikoTblBySearchCondDAInput
    {
        /// <summary>
        /// ShishoCd
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// YoshiCdFrom
        /// </summary>
        string YoshiCdFrom { get; set; }

        /// <summary>
        /// YoshiCdTo
        /// </summary>
        string YoshiCdTo {get;set;}

        /// <summary>
        /// YoshiNm
        /// </summary>
        string YoshiNm { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYoshiZaikoTblBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYoshiZaikoTblBySearchCondDAInput : ISelectYoshiZaikoTblBySearchCondDAInput
    {
        /// <summary>
        /// ShishoCd
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// YoshiCdFrom
        /// </summary>
        public string YoshiCdFrom { get; set; }

        /// <summary>
        /// YoshiCdTo
        /// </summary>
        public string YoshiCdTo {get;set;}

        /// <summary>
        /// YoshiNm
        /// </summary>
        public string YoshiNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYoshiZaikoTblBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYoshiZaikoTblBySearchCondDAOutput
    {
        /// <summary>
        /// YoshiZaikoTblDT
        /// </summary>
        YoshiZaikoTblDataSet.YoshiZaikoTblKensakuDataTable YoshiZaikoTblDT { get; set; } 
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYoshiZaikoTblBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYoshiZaikoTblBySearchCondDAOutput : ISelectYoshiZaikoTblBySearchCondDAOutput
    {
        /// <summary>
        /// YoshiZaikoTblDT
        /// </summary>
        public YoshiZaikoTblDataSet.YoshiZaikoTblKensakuDataTable YoshiZaikoTblDT { get; set; } 
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYoshiZaikoTblBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYoshiZaikoTblBySearchCondDataAccess : BaseDataAccess<ISelectYoshiZaikoTblBySearchCondDAInput, ISelectYoshiZaikoTblBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private YoshiZaikoTblKensakuTableAdapter tableAdapter = new YoshiZaikoTblKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectYoshiZaikoTblBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectYoshiZaikoTblBySearchCondDataAccess()
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
        /// 2014/07/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectYoshiZaikoTblBySearchCondDAOutput Execute(ISelectYoshiZaikoTblBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectYoshiZaikoTblBySearchCondDAOutput output = new SelectYoshiZaikoTblBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.YoshiZaikoTblDT = tableAdapter.GetDataBySearchCond(input.ShishoCd, input.YoshiCdFrom, input.YoshiCdTo, DataAccessUtility.EscapeSQLString(input.YoshiNm));

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
