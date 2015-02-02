using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.HoshoTorokuTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.HoshoTorokuTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAInput
    {
        /// <summary>
        /// 支所区分
        /// </summary>
        string HoshoTorokuShishoKbn { get; set; }

        /// <summary>
        /// 売上日付
        /// </summary>
        string HoshoTorokuUriageDt { get; set; }

        /// <summary>
        /// 販売先コード
        /// </summary>
        string HoshoTorokuHanbaisakiCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAInput : ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAInput
    {
        /// <summary>
        /// 支所区分
        /// </summary>
        public string HoshoTorokuShishoKbn { get; set; }

        /// <summary>
        /// 売上日付
        /// </summary>
        public string HoshoTorokuUriageDt { get; set; }

        /// <summary>
        /// 販売先コード
        /// </summary>
        public string HoshoTorokuHanbaisakiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput
    {
        /// <summary>
        /// 保証登録テーブル
        /// </summary>
        HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput : ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput
    {
        /// <summary>
        /// 保証登録テーブル
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDataAccess : BaseDataAccess<ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAInput, ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private HoshoTorokuTblTableAdapter tableAdapter = new HoshoTorokuTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDataAccess()
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
        /// 2014/10/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput Execute(ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput output = new SelectHoshoTorokuTblByShishoUriageDtHanbaisakiCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.HoshoTorokuTblDataTable = tableAdapter.GetDataByShishoUriageDtHanbaisakiCd(input.HoshoTorokuShishoKbn,
                                                                                                    input.HoshoTorokuUriageDt,
                                                                                                    input.HoshoTorokuHanbaisakiCd);
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
