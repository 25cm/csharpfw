using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKekkaNmMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuKekkaNmMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuKekkaNmMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuKekkaNmMstBySearchCondDAInput
    {
        /// <summary>
        /// ShishoCd
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// SuishitsuKekkaNmCdFrom
        /// </summary>
        string SuishitsuKekkaNmCdFrom { get; set; }

        /// <summary>
        /// SuishitsuKekkaNmCdTo
        /// </summary>
        string SuishitsuKekkaNmCdTo { get; set; }

        /// <summary>
        /// SuishitsuKekkaNm
        /// </summary>
        string SuishitsuKekkaNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuKekkaNmMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuKekkaNmMstBySearchCondDAInput : ISelectSuishitsuKekkaNmMstBySearchCondDAInput
    {
        /// <summary>
        /// ShishoCd
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// SuishitsuKekkaNmCdFrom
        /// </summary>
        public string SuishitsuKekkaNmCdFrom { get; set; }

        /// <summary>
        /// SuishitsuKekkaNmCdTo
        /// </summary>
        public string SuishitsuKekkaNmCdTo { get; set; }

        /// <summary>
        /// SuishitsuKekkaNm
        /// </summary>
        public string SuishitsuKekkaNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuKekkaNmMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuKekkaNmMstBySearchCondDAOutput
    {
        /// <summary>
        /// SuishitsuKekkaNmMstDT
        /// </summary>
        SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstKensakuDataTable SuishitsuKekkaNmMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuKekkaNmMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuKekkaNmMstBySearchCondDAOutput : ISelectSuishitsuKekkaNmMstBySearchCondDAOutput
    {
        /// <summary>
        /// SuishitsuKekkaNmMstDT
        /// </summary>
        public SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstKensakuDataTable SuishitsuKekkaNmMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuKekkaNmMstBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuKekkaNmMstBySearchCondDataAccess : BaseDataAccess<ISelectSuishitsuKekkaNmMstBySearchCondDAInput, ISelectSuishitsuKekkaNmMstBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuKekkaNmMstKensakuTableAdapter tableAdapter = new SuishitsuKekkaNmMstKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSuishitsuKekkaNmMstBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSuishitsuKekkaNmMstBySearchCondDataAccess()
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
        /// 2014/07/01　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSuishitsuKekkaNmMstBySearchCondDAOutput Execute(ISelectSuishitsuKekkaNmMstBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSuishitsuKekkaNmMstBySearchCondDAOutput output = new SelectSuishitsuKekkaNmMstBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SuishitsuKekkaNmMstDT = tableAdapter.GetDataBySearchCond(input.ShishoCd, 
                                                                                input.SuishitsuKekkaNmCdFrom, input.SuishitsuKekkaNmCdTo, 
                                                                                DataAccessUtility.EscapeSQLString(input.SuishitsuKekkaNm));

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
