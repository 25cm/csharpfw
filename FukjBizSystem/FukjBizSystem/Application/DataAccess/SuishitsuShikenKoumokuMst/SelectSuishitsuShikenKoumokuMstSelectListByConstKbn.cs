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
    //  インターフェイス名 ： ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/19　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput
    {
        /// <summary>
        /// 定数区分(048:法定検査、049:計量証明)
        /// </summary>
        string ConstKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/19　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput : ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput
    {
        /// <summary>
        /// 定数区分(048:法定検査、049:計量証明)
        /// </summary>
        public string ConstKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/19　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAOutput
    {
        /// <summary>
        /// SuishitsuShikenKoumokuMstSelectListDataTable
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable SuishitsuShikenKoumokuMstSelectListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/19　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAOutput : ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAOutput
    {
        /// <summary>
        /// SuishitsuShikenKoumokuMstDataTable
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstSelectListDataTable SuishitsuShikenKoumokuMstSelectListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/19　宗  　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDataAccess : BaseDataAccess<ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput, ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuShikenKoumokuMstSelectListTableAdapter tableAdapter = new SuishitsuShikenKoumokuMstSelectListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/19　宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDataAccess()
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
        /// 2015/01/19　宗  　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAOutput Execute(ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAOutput output = new SelectSuishitsuShikenKoumokuMstSelectListByConstKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SuishitsuShikenKoumokuMstSelectListDataTable = tableAdapter.GetData(input.ConstKbn);
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
