using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.JokasoDaichoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoGaikanInputBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanInputBySearchCondDAInput
    {
        /// <summary>
        /// 一括請求先コード
        /// </summary>
        string SeikyusakiCd { get; set; }

        /// <summary>
        /// 検査年度FROM
        /// </summary>
        string NendoFrom { get; set; }

        /// <summary>
        /// 検査年度TO
        /// </summary>
        string NendoTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanInputBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanInputBySearchCondDAInput : ISelectJinendoGaikanInputBySearchCondDAInput
    {
        /// <summary>
        /// 一括請求先コード
        /// </summary>
        public string SeikyusakiCd { get; set; }

        /// <summary>
        /// 検査年度FROM
        /// </summary>
        public string NendoFrom { get; set; }

        /// <summary>
        /// 検査年度TO
        /// </summary>
        public string NendoTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoGaikanInputBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanInputBySearchCondDAOutput
    {
        /// <summary>
        /// JinendoGaikanInputDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JinendoGaikanInputDataTable JinendoGaikanInputDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanInputBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanInputBySearchCondDAOutput : ISelectJinendoGaikanInputBySearchCondDAOutput
    {
        /// <summary>
        /// JinendoGaikanInputDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JinendoGaikanInputDataTable JinendoGaikanInputDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanInputBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanInputBySearchCondDataAccess : BaseDataAccess<ISelectJinendoGaikanInputBySearchCondDAInput, ISelectJinendoGaikanInputBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JinendoGaikanInputTableAdapter tableAdapter = new JinendoGaikanInputTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJinendoGaikanInputBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJinendoGaikanInputBySearchCondDataAccess()
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
        /// 2014/09/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJinendoGaikanInputBySearchCondDAOutput Execute(ISelectJinendoGaikanInputBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJinendoGaikanInputBySearchCondDAOutput output = new SelectJinendoGaikanInputBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JinendoGaikanInputDataTable = tableAdapter.GetDataBySearchCond(input.SeikyusakiCd, input.NendoFrom, input.NendoTo);
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
