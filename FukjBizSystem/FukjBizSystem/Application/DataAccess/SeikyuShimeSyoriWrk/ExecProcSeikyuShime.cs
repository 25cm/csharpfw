using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.SeikyuShimeSyoriWrkDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyuShimeSyoriWrk
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcSeikyuShimeDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcSeikyuShimeDAInput
    {
        /// <summary>
        /// 締め区分
        /// </summary>
        string ShimeKbn { get; set; }

        /// <summary>
        /// 締め年月
        /// </summary>
        string ShimeDt { get; set; }

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        string GyoshaCdTo { get; set; }

        /// <summary>
        /// 請求日
        /// </summary>
        string SeikyuDt { get; set; }

        /// <summary>
        /// 締め済業者/削除・再作成
        /// </summary>
        string ShimeSumi { get; set; }

        ///// <summary>
        ///// Server DateTime
        ///// </summary>
        //DateTime Now { get; set; }

        /// <summary>
        /// LoginUser
        /// </summary>
        string LoginUser { get; set; }

        /// <summary>
        /// PcUpdate
        /// </summary>
        string PcUpdate { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSeikyuShimeDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSeikyuShimeDAInput : IExecProcSeikyuShimeDAInput
    {
        /// <summary>
        /// 締め区分
        /// </summary>
        public string ShimeKbn { get; set; }

        /// <summary>
        /// 締め年月
        /// </summary>
        public string ShimeDt { get; set; }

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 請求日
        /// </summary>
        public string SeikyuDt { get; set; }

        /// <summary>
        /// 締め済業者/削除・再作成
        /// </summary>
        public string ShimeSumi { get; set; }

        /// <summary>
        /// Server DateTime
        /// </summary>
        public DateTime Now { get; set; }

        /// <summary>
        /// LoginUser
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// PcUpdate
        /// </summary>
        public string PcUpdate { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcSeikyuShimeDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcSeikyuShimeDAOutput
    {
        /// <summary>
        /// Error Flag
        /// </summary>
        string ErrorFlg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSeikyuShimeDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSeikyuShimeDAOutput : IExecProcSeikyuShimeDAOutput
    {
        /// <summary>
        /// Error Flag
        /// </summary>
        public string ErrorFlg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSeikyuShimeDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSeikyuShimeDataAccess : BaseDataAccess<IExecProcSeikyuShimeDAInput, IExecProcSeikyuShimeDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyuShimeTableAdapter tableAdapter = new SeikyuShimeTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcSeikyuShimeDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcSeikyuShimeDataAccess()
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
        /// 2014/09/24  DatNT　  新規作成
        /// 2014/12/26  habu　  CommandTimeout設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcSeikyuShimeDAOutput Execute(IExecProcSeikyuShimeDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcSeikyuShimeDAOutput output = new ExecProcSeikyuShimeDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // CommandTimeout設定
                tableAdapter.CommandTimeout = 600;
                //tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                output.ErrorFlg = (string) tableAdapter.ExecProcSeikyuShime(input.ShimeKbn,
                                                                            input.ShimeDt,
                                                                            input.GyoshaCdFrom,
                                                                            input.GyoshaCdTo,
                                                                            input.SeikyuDt,
                                                                            input.ShimeSumi,
                                                                            input.LoginUser,
                                                                            input.PcUpdate,
                                                                            input.Nendo);

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
