using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using FukjBizSystem.Application.DataSet.SuishitsuNippoHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuNippoHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcSuishitsuNippoStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcSuishitsuNippoStdDAInput
    {
        /// <summary>
        /// 水質検査受付日
        /// </summary>
        string UketsukeDt { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// 実行ユーザID
        /// </summary>
        string UserId { get; set; }

        /// <summary>
        /// 実行ユーザ端末
        /// </summary>
        string UserTarm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSuishitsuNippoStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSuishitsuNippoStdDAInput : IExecProcSuishitsuNippoStdDAInput
    {
        /// <summary>
        /// 水質検査受付日
        /// </summary>
        public string UketsukeDt { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 実行ユーザID
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// 実行ユーザ端末
        /// </summary>
        public string UserTarm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcSuishitsuNippoStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcSuishitsuNippoStdDAOutput
    {
        /// <summary>
        /// Result
        /// </summary>
        int Result { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSuishitsuNippoStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSuishitsuNippoStdDAOutput : IExecProcSuishitsuNippoStdDAOutput
    {
        /// <summary>
        /// Result
        /// </summary>
        public int Result { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSuishitsuNippoStdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSuishitsuNippoStdDataAccess : BaseDataAccess<IExecProcSuishitsuNippoStdDAInput, IExecProcSuishitsuNippoStdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuNippoStdTableAdapter tableAdapter = new SuishitsuNippoStdTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcSuishitsuNippoStdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcSuishitsuNippoStdDataAccess()
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
        /// 2014/12/05  DatNT　  新規作成
        /// 2014/12/26  habu　  CommandTimeout設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcSuishitsuNippoStdDAOutput Execute(IExecProcSuishitsuNippoStdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcSuishitsuNippoStdDAOutput output = new ExecProcSuishitsuNippoStdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // CommandTimeout設定
                tableAdapter.CommandTimeout = 600;
                //tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

				tableAdapter.ExecProcSuishitsuNippoStd(input.UketsukeDt, input.ShishoCd, input.UserId, input.UserTarm);

				output.Result = (int)tableAdapter.GetReturnValue("dbo.SuishitsuNippoStd");
	
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
