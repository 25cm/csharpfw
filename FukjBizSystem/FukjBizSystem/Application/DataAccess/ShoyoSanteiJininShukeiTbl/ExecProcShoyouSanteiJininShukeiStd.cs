using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShoyoSanteiJininShukeiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShoyoSanteiJininShukeiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcShoyouSanteiJininShukeiStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcShoyouSanteiJininShukeiStdDAInput
    {
        /// <summary>
        /// Nendo
        /// </summary>
        int Nendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcShoyouSanteiJininShukeiStdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcShoyouSanteiJininShukeiStdDAInput : IExecProcShoyouSanteiJininShukeiStdDAInput
    {
        /// <summary>
        /// Nendo
        /// </summary>
        public int Nendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcShoyouSanteiJininShukeiStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcShoyouSanteiJininShukeiStdDAOutput
    {
        /// <summary>
        /// ErrorFlg
        /// </summary>
        string ErrorFlg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcShoyouSanteiJininShukeiStdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcShoyouSanteiJininShukeiStdDAOutput : IExecProcShoyouSanteiJininShukeiStdDAOutput
    {
        /// <summary>
        /// ErrorFlg
        /// </summary>
        public string ErrorFlg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcShoyouSanteiJininShukeiStdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcShoyouSanteiJininShukeiStdDataAccess : BaseDataAccess<IExecProcShoyouSanteiJininShukeiStdDAInput, IExecProcShoyouSanteiJininShukeiStdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShoyouSanteiJininShukeiStdTableAdapter tableAdapter = new ShoyouSanteiJininShukeiStdTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcShoyouSanteiJininShukeiStdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcShoyouSanteiJininShukeiStdDataAccess()
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
        /// 2014/12/23  HuyTX　    新規作成
        /// 2014/12/26  habu　    CommandTimeout設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcShoyouSanteiJininShukeiStdDAOutput Execute(IExecProcShoyouSanteiJininShukeiStdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcShoyouSanteiJininShukeiStdDAOutput output = new ExecProcShoyouSanteiJininShukeiStdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);
                string updateTarm = Dns.GetHostName();

                // CommandTimeout設定
                tableAdapter.CommandTimeout = 600;
                //tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                ShoyoSanteiJininShukeiTblDataSet.ShoyouSanteiJininShukeiStdDataTable stdDataTable = tableAdapter.ExecProcShoyouSanteiJininShukeiStd(input.Nendo.ToString(), 
                                                                Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm,
                                                                updateTarm);

                output.ErrorFlg = stdDataTable != null && stdDataTable.Count > 0 ? stdDataTable[0].ErrorFlg : string.Empty;

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
