using System;
using System.Collections.Generic;
using System.Reflection;
using FukjBizSystem.Application.DataSet.KaikeiRendoHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KaikeiRendoHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcSuitoSyukeiStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcSuitoSyukeiStdDAInput
    {
        /// <summary>
        /// 対象区分
        /// </summary>
        string TaishoKbn { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// 対象日（開始）
        /// </summary>
        string TaisyoFrom { get; set; }

        /// <summary>
        /// 対象日（終了）
        /// </summary>
        string TaisyoTo { get; set; }

        /// <summary>
        /// 作成対象
        /// </summary>
        string SakuseiTaisho { get; set; }

        /// <summary>
        /// 作成範囲
        /// </summary>
        string SakuseiHani { get; set; }

        /// <summary>
        /// 和暦
        /// </summary>
        string Wareki { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        string LoginUser { get; set; }

        /// <summary>
        /// 更新端末
        /// </summary>
        string PcUpdate { get; set; }

        /// <summary>
        /// 会計採番No
        /// </summary>
        string KaikeiSaibanNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSuitoSyukeiStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSuitoSyukeiStdDAInput : IExecProcSuitoSyukeiStdDAInput
    {
        /// <summary>
        /// 対象区分
        /// </summary>
        public string TaishoKbn { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 対象日（開始）
        /// </summary>
        public string TaisyoFrom { get; set; }

        /// <summary>
        /// 対象日（終了）
        /// </summary>
        public string TaisyoTo { get; set; }

        /// <summary>
        /// 作成対象
        /// </summary>
        public string SakuseiTaisho { get; set; }

        /// <summary>
        /// 作成範囲
        /// </summary>
        public string SakuseiHani { get; set; }

        /// <summary>
        /// 和暦
        /// </summary>
        public string Wareki { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// 更新端末
        /// </summary>
        public string PcUpdate { get; set; }

        /// <summary>
        /// 会計採番No
        /// </summary>
        public string KaikeiSaibanNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcSuitoSyukeiStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcSuitoSyukeiStdDAOutput
    {
        /// <summary>
        /// ListResult (ErrorFlg & KaikeiSaibanNo)
        /// </summary>
        List<string> ListResult { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSuitoSyukeiStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSuitoSyukeiStdDAOutput : IExecProcSuitoSyukeiStdDAOutput
    {
        /// <summary>
        /// ListResult (ErrorFlg & KaikeiSaibanNo)
        /// </summary>
        public List<string> ListResult { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSuitoSyukeiStdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSuitoSyukeiStdDataAccess : BaseDataAccess<IExecProcSuitoSyukeiStdDAInput, IExecProcSuitoSyukeiStdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuitoSyukeiStdTableAdapter tableAdapter = new SuitoSyukeiStdTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcSuitoSyukeiStdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcSuitoSyukeiStdDataAccess()
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
        /// 2014/11/11  DatNT　  新規作成
        /// 2014/12/26  habu　  CommandTimeout設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcSuitoSyukeiStdDAOutput Execute(IExecProcSuitoSyukeiStdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcSuitoSyukeiStdDAOutput output = new ExecProcSuitoSyukeiStdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);
                
                // CommandTimeout設定
                tableAdapter.CommandTimeout = 600;
                //tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                output.ListResult = tableAdapter.ExecProcSuitoSyukeiStd(    input.TaishoKbn,
                                                                            input.ShishoCd,
                                                                            input.TaisyoFrom,
                                                                            input.TaisyoTo,
                                                                            input.SakuseiTaisho,
                                                                            input.SakuseiHani,
                                                                            input.Wareki,
                                                                            input.LoginUser,
                                                                            input.PcUpdate,
                                                                            input.KaikeiSaibanNo);

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
