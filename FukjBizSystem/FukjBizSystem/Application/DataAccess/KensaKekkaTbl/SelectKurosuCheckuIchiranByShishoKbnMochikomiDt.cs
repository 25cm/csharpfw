using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAInput
    {
        /// <summary>
        /// 検査依頼受付支所
        /// </summary>
        string KensaIraiUketsukeShishoKbn { get; set; }

        /// <summary>
        /// 水質検査持込日付
        /// </summary>
        string KensaKekkaMochikomiDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAInput : ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAInput
    {
        /// <summary>
        /// 検査依頼受付支所
        /// </summary>
        public string KensaIraiUketsukeShishoKbn { get; set; }

        /// <summary>
        /// 水質検査持込日付
        /// </summary>
        public string KensaKekkaMochikomiDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput
    {
        /// <summary>
        /// KurosuCheckuIchiranDataTable
        /// </summary>
        KensaKekkaTblDataSet.KurosuCheckuIchiranDataTable KurosuCheckuIchiranDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput : ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput
    {
        /// <summary>
        /// KurosuCheckuIchiranDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KurosuCheckuIchiranDataTable KurosuCheckuIchiranDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDataAccess : BaseDataAccess<ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAInput, ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KurosuCheckuIchiranTableAdapter tableAdapter = new KurosuCheckuIchiranTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDataAccess()
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
        /// 2014/12/26　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput Execute(ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput output = new SelectKurosuCheckuIchiranByShishoKbnMochikomiDtDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KurosuCheckuIchiranDataTable = tableAdapter.GetDataByShishoKbnMochikomiDt(input.KensaIraiUketsukeShishoKbn, input.KensaKekkaMochikomiDt);
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
