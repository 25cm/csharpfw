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
    //  インターフェイス名 ： ISelectJinendoInputPrintBySeikyusakiCdNendoDAInput
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
    interface ISelectJinendoInputPrintBySeikyusakiCdNendoDAInput
    {
        /// <summary>
        /// 一括請求先コード
        /// </summary>
        string SeikyusakiCd { get; set; }

        /// <summary>
        /// 検査予定年FROM
        /// </summary>
        string NendoFrom { get; set; }

        /// <summary>
        /// 検査予定年TO
        /// </summary>
        string NendoTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoInputPrintBySeikyusakiCdNendoDAInput
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
    class SelectJinendoInputPrintBySeikyusakiCdNendoDAInput : ISelectJinendoInputPrintBySeikyusakiCdNendoDAInput
    {
        /// <summary>
        /// 一括請求先コード
        /// </summary>
        public string SeikyusakiCd { get; set; }

        /// <summary>
        /// 検査予定年FROM
        /// </summary>
        public string NendoFrom { get; set; }

        /// <summary>
        /// 検査予定年TO
        /// </summary>
        public string NendoTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoInputPrintBySeikyusakiCdNendoDAOutput
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
    interface ISelectJinendoInputPrintBySeikyusakiCdNendoDAOutput
    {
        /// <summary>
        /// JinendoInputPrintDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JinendoInputPrintDataTable JinendoInputPrintDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoInputPrintBySeikyusakiCdNendoDAOutput
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
    class SelectJinendoInputPrintBySeikyusakiCdNendoDAOutput : ISelectJinendoInputPrintBySeikyusakiCdNendoDAOutput
    {
        /// <summary>
        /// JinendoInputPrintDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JinendoInputPrintDataTable JinendoInputPrintDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoInputPrintBySeikyusakiCdNendoDataAccess
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
    class SelectJinendoInputPrintBySeikyusakiCdNendoDataAccess : BaseDataAccess<ISelectJinendoInputPrintBySeikyusakiCdNendoDAInput, ISelectJinendoInputPrintBySeikyusakiCdNendoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JinendoInputPrintTableAdapter tableAdapter = new JinendoInputPrintTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJinendoInputPrintBySeikyusakiCdNendoDataAccess
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
        public SelectJinendoInputPrintBySeikyusakiCdNendoDataAccess()
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
        public override ISelectJinendoInputPrintBySeikyusakiCdNendoDAOutput Execute(ISelectJinendoInputPrintBySeikyusakiCdNendoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJinendoInputPrintBySeikyusakiCdNendoDAOutput output = new SelectJinendoInputPrintBySeikyusakiCdNendoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JinendoInputPrintDataTable = tableAdapter.GetDataBySeikyusakiCdNendo(input.SeikyusakiCd, input.NendoFrom, input.NendoTo);
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
