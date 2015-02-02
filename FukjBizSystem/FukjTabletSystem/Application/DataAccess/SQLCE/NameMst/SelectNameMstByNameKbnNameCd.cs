using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.NameMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.NameMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectNameMstByNameKbnNameCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectNameMstByNameKbnNameCdDAInput
    {
        /// <summary>
        /// 名称区分
        /// </summary>
        string NameKbn { get; set; }

        /// <summary>
        /// 名称コード
        /// </summary>
        string NameCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNameMstByNameKbnNameCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNameMstByNameKbnNameCdDAInput : ISelectNameMstByNameKbnNameCdDAInput
    {
        /// <summary>
        /// 名称区分
        /// </summary>
        public string NameKbn { get; set; }

        /// <summary>
        /// 名称コード
        /// </summary>
        public string NameCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectNameMstByNameKbnNameCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectNameMstByNameKbnNameCdDAOutput
    {
        /// <summary>
        /// 
        /// </summary>
        NameMstDataSet.NameMstDataTable NameMst { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNameMstByNameKbnNameCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNameMstByNameKbnNameCdDAOutput : ISelectNameMstByNameKbnNameCdDAOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public NameMstDataSet.NameMstDataTable NameMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNameMstByNameKbnNameCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNameMstByNameKbnNameCdDataAccess : BaseDataAccessCe<ISelectNameMstByNameKbnNameCdDAInput, ISelectNameMstByNameKbnNameCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NameMstTableAdapter tableAdapter = new NameMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectNameMstByNameKbnNameCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/23　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectNameMstByNameKbnNameCdDataAccess()
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
        /// 2014/11/23　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectNameMstByNameKbnNameCdDAOutput Execute(ISelectNameMstByNameKbnNameCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectNameMstByNameKbnNameCdDAOutput output = new SelectNameMstByNameKbnNameCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.NameMst = tableAdapter.GetDataByNameKbnNameCd(input.NameKbn, input.NameCd);

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
