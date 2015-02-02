using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKensaUketsukeShosaiDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaSetPatternByKyokaiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　小松        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaSetPatternByKyokaiNoDAInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        string JokasoHokenjoCd { get; set; }
        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        string JokasoTorokuNendo { get; set; }
        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        string JokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaSetPatternByKyokaiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　小松        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaSetPatternByKyokaiNoDAInput : ISelectKensaSetPatternByKyokaiNoDAInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        public string JokasoHokenjoCd { get; set; }
        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        public string JokasoTorokuNendo { get; set; }
        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaSetPatternByKyokaiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　小松        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaSetPatternByKyokaiNoDAOutput
    {
        /// <summary>
        /// KensaSetPattern
        /// </summary>
        SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternDataTable KensaSetPattern { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaSetPatternByKyokaiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　小松        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaSetPatternByKyokaiNoDAOutput : ISelectKensaSetPatternByKyokaiNoDAOutput
    {
        /// <summary>
        /// KensaSetPattern
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternDataTable KensaSetPattern { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaSetPatternByKyokaiNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　小松        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaSetPatternByKyokaiNoDataAccess : BaseDataAccess<ISelectKensaSetPatternByKyokaiNoDAInput, ISelectKensaSetPatternByKyokaiNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaSetPatternTableAdapter tableAdapter = new KensaSetPatternTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaSetPatternByKyokaiNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/02　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaSetPatternByKyokaiNoDataAccess()
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
        /// 2014/12/10　小松        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaSetPatternByKyokaiNoDAOutput Execute(ISelectKensaSetPatternByKyokaiNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaSetPatternByKyokaiNoDAOutput output = new SelectKensaSetPatternByKyokaiNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaSetPattern = tableAdapter.GetDataByKyokaiNo(input.JokasoHokenjoCd, input.JokasoTorokuNendo, input.JokasoRenban);
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
