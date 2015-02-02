using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKensaUketsukeDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsuke
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectZenkaiKensaIraiInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectZenkaiKensaIraiInfoDAInput
    {
        /// <summary>
        /// 浄化槽台帳法定区分
        /// </summary>
        string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度
        /// </summary>
        string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        string JokasoRenban { get; set; }

        /// <summary>
        /// 現在日(yyyyMMdd)
        /// </summary>
        string TodayStr { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZenkaiKensaIraiInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZenkaiKensaIraiInfoDAInput : ISelectZenkaiKensaIraiInfoDAInput
    {
        /// <summary>
        /// 浄化槽台帳法定区分
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string JokasoRenban { get; set; }

        /// <summary>
        /// 現在日(yyyyMMdd)
        /// </summary>
        public string TodayStr { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectZenkaiKensaIraiInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectZenkaiKensaIraiInfoDAOutput
    {
        /// <summary>
        /// 前回検査情報
        /// </summary>
        SuishitsuKensaUketsukeDataSet.ZenkaiKensaIraiInfoDataTable ZenkaiKensaInfoDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZenkaiKensaIraiInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZenkaiKensaIraiInfoDAOutput : ISelectZenkaiKensaIraiInfoDAOutput
    {
        /// <summary>
        /// 前回検査情報
        /// </summary>
        public SuishitsuKensaUketsukeDataSet.ZenkaiKensaIraiInfoDataTable ZenkaiKensaInfoDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZenkaiKensaIraiInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZenkaiKensaIraiInfoDataAccess : BaseDataAccess<ISelectZenkaiKensaIraiInfoDAInput, ISelectZenkaiKensaIraiInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ZenkaiKensaIraiInfoTableAdapter tableAdapter = new ZenkaiKensaIraiInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectZenkaiKensaIraiInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectZenkaiKensaIraiInfoDataAccess()
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
        /// 2014/12/04  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectZenkaiKensaIraiInfoDAOutput Execute(ISelectZenkaiKensaIraiInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectZenkaiKensaIraiInfoDAOutput output = new SelectZenkaiKensaIraiInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // タイムアウトを設定(単位：秒)
                tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                output.ZenkaiKensaInfoDT = tableAdapter.GetData(input.JokasoHokenjoCd, input.JokasoTorokuNendo, input.JokasoRenban, input.TodayStr);

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
