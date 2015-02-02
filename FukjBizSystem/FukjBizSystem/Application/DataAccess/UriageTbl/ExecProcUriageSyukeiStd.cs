using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.UriageTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.UriageTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcUriageSyukeiStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcUriageSyukeiStdDAInput
    {
        /// <summary>
        /// 売上日FROM
        /// </summary>
        DateTime UriageDtFrom { get; set; }

        /// <summary>
        /// 売上日TO
        /// </summary>
        DateTime UriageDtTo { get; set; }

        /// <summary>
        /// ログイン者
        /// </summary>
        string LoginUser { get; set; }

        /// <summary>
        /// 端末
        /// </summary>
        string Machine { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcUriageSyukeiStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcUriageSyukeiStdDAInput : IExecProcUriageSyukeiStdDAInput
    {
        /// <summary>
        /// 売上日FROM
        /// </summary>
        public DateTime UriageDtFrom { get; set; }

        /// <summary>
        /// 売上日TO
        /// </summary>
        public DateTime UriageDtTo { get; set; }

        /// <summary>
        /// ログイン者
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// 端末
        /// </summary>
        public string Machine { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcUriageSyukeiStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcUriageSyukeiStdDAOutput
    {
        /// <summary>
        /// Error Flag
        /// </summary>
        string ErrorFlg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcUriageSyukeiStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcUriageSyukeiStdDAOutput : IExecProcUriageSyukeiStdDAOutput
    {
        /// <summary>
        /// Error Flag
        /// </summary>
        public string ErrorFlg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcUriageSyukeiStdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcUriageSyukeiStdDataAccess : BaseDataAccess<IExecProcUriageSyukeiStdDAInput, IExecProcUriageSyukeiStdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private UriageSyukeiStdTableAdapter tableAdapter = new UriageSyukeiStdTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcUriageSyukeiStdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcUriageSyukeiStdDataAccess()
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
        /// 2014/11/12  DatNT　  新規作成
        /// 2014/12/26  habu　  CommandTimeOutを設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcUriageSyukeiStdDAOutput Execute(IExecProcUriageSyukeiStdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcUriageSyukeiStdDAOutput output = new ExecProcUriageSyukeiStdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // CommandTimeOutを設定
                tableAdapter.CommandTimeout = 600;
                //tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                output.ErrorFlg = (string)tableAdapter.ExecProcUriageSyukeiStd(input.UriageDtFrom, input.UriageDtTo, input.LoginUser, input.Machine);

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
