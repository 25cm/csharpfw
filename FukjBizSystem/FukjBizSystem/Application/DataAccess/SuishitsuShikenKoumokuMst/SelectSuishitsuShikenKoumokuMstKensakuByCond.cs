using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuShikenKoumokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuShikenKoumokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuShikenKoumokuMstKensakuByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuShikenKoumokuMstKensakuByCondDAInput
    {
        /// <summary>
        /// 水質試験項目コードFROM
        /// </summary>
        string SuishitsuShikenKoumokuCdFrom { get; set; }

        /// <summary>
        /// 水質試験項目コードTO
        /// </summary>
        string SuishitsuShikenKoumokuCdTo { get; set; }

        /// <summary>
        /// 正式名称
        /// </summary>
        string SeishikiNm { get; set; }

        /// <summary>
        /// 略式名称
        /// </summary>
        string RyakushikiNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuShikenKoumokuMstKensakuByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuShikenKoumokuMstKensakuByCondDAInput : ISelectSuishitsuShikenKoumokuMstKensakuByCondDAInput
    {
        /// <summary>
        /// 水質試験項目コードFROM
        /// </summary>
        public string SuishitsuShikenKoumokuCdFrom { get; set; }

        /// <summary>
        /// 水質試験項目コードTO
        /// </summary>
        public string SuishitsuShikenKoumokuCdTo { get; set; }

        /// <summary>
        /// 正式名称
        /// </summary>
        public string SeishikiNm { get; set; }

        /// <summary>
        /// 略式名称
        /// </summary>
        public string RyakushikiNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput
    {
        /// <summary>
        /// SuishitsuShikenKoumokuMstKensakuDataTable
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstKensakuDataTable SuishitsuShikenKoumokuMstKensakuDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput : ISelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput
    {
        /// <summary>
        /// SuishitsuShikenKoumokuMstKensakuDataTable
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstKensakuDataTable SuishitsuShikenKoumokuMstKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuShikenKoumokuMstKensakuByCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuShikenKoumokuMstKensakuByCondDataAccess : BaseDataAccess<ISelectSuishitsuShikenKoumokuMstKensakuByCondDAInput, ISelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuShikenKoumokuMstKensakuTableAdapter tableAdapter = new SuishitsuShikenKoumokuMstKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSuishitsuShikenKoumokuMstKensakuByCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSuishitsuShikenKoumokuMstKensakuByCondDataAccess()
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
        /// 2014/07/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput Execute(ISelectSuishitsuShikenKoumokuMstKensakuByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput output = new SelectSuishitsuShikenKoumokuMstKensakuByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SuishitsuShikenKoumokuMstKensakuDataTable = tableAdapter.GetDataBySearchCond(
                                                                        input.SuishitsuShikenKoumokuCdFrom,
                                                                        input.SuishitsuShikenKoumokuCdTo,
                                                                        DataAccessUtility.EscapeSQLString(input.SeishikiNm),
                                                                        DataAccessUtility.EscapeSQLString(input.RyakushikiNm));
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
