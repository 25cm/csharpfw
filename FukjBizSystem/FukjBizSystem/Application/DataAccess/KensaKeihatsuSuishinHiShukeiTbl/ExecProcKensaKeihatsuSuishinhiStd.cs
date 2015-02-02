using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.KensaKeihatsuSuishinHiShukeiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcKensaKeihatsuSuishinhiStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcKensaKeihatsuSuishinhiStdDAInput
    {
        /// <summary>
        /// StepNo 更新仕様の処理番号
        /// </summary>
        int StepNo { get; set; }

        /// <summary>
        /// 開始日
        /// </summary>
        string SyukeiFrom { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        string SyukeiTo { get; set; }

        /// <summary>
        /// 支払日
        /// </summary>
        string ShiharaiDt { get; set; }

        /// <summary>
        /// 推進費採番No 年度 + 採番No (10桁)
        /// </summary>
        string SaibanNo { get; set; }

        /// <summary>
        /// 業者コード(開始)
        /// </summary>
        string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード(終了)
        /// </summary>
        string GyoshaCdTo { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        string LoginUser { get; set; }

        /// <summary>
        /// 更新端末
        /// </summary>
        string PcUpdate { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcKensaKeihatsuSuishinhiStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcKensaKeihatsuSuishinhiStdDAInput : IExecProcKensaKeihatsuSuishinhiStdDAInput
    {
        /// <summary>
        /// StepNo 更新仕様の処理番号
        /// </summary>
        public int StepNo { get; set; }

        /// <summary>
        /// 開始日
        /// </summary>
        public string SyukeiFrom { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        public string SyukeiTo { get; set; }

        /// <summary>
        /// 支払日
        /// </summary>
        public string ShiharaiDt { get; set; }

        /// <summary>
        /// 推進費採番No 年度 + 採番No (10桁)
        /// </summary>
        public string SaibanNo { get; set; }

        /// <summary>
        /// 業者コード(開始)
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード(終了)
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// 更新端末
        /// </summary>
        public string PcUpdate { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcKensaKeihatsuSuishinhiStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcKensaKeihatsuSuishinhiStdDAOutput
    {
        /// <summary>
        /// Error Flag
        /// </summary>
        string ErrorFlg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcKensaKeihatsuSuishinhiStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcKensaKeihatsuSuishinhiStdDAOutput : IExecProcKensaKeihatsuSuishinhiStdDAOutput
    {
        /// <summary>
        /// Error Flag
        /// </summary>
        public string ErrorFlg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcKensaKeihatsuSuishinhiStdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcKensaKeihatsuSuishinhiStdDataAccess : BaseDataAccess<IExecProcKensaKeihatsuSuishinhiStdDAInput, IExecProcKensaKeihatsuSuishinhiStdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKeihatsuSuishinhiStdTableAdapter tableAdapter = new KensaKeihatsuSuishinhiStdTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcKensaKeihatsuSuishinhiStdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcKensaKeihatsuSuishinhiStdDataAccess()
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
        /// 2014/12/13　DatNT    新規作成
        /// 2014/12/26　habu    CommandTimeout設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcKensaKeihatsuSuishinhiStdDAOutput Execute(IExecProcKensaKeihatsuSuishinhiStdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcKensaKeihatsuSuishinhiStdDAOutput output = new ExecProcKensaKeihatsuSuishinhiStdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // CommandTimeout設定
                tableAdapter.CommandTimeout = 600;
                //tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                output.ErrorFlg = (String)tableAdapter.ExecProcKensaKeihatsuSuishinhiStd(   input.StepNo,
                                                                                            input.SyukeiFrom,
                                                                                            input.SyukeiTo,
                                                                                            input.ShiharaiDt,
                                                                                            input.SaibanNo,
                                                                                            input.GyoshaCdFrom,
                                                                                            input.GyoshaCdTo,
                                                                                            input.LoginUser,
                                                                                            input.PcUpdate);

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
