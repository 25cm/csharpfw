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
    //  インターフェイス名 ： ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAInput
    {
        /// <summary>
        /// KensaIraiJokasoHokenjoCd
        /// </summary>
        string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiJokasoTorokuNendo
        /// </summary>
        string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// KensaIraiJokasoRenban
        /// </summary>
        string KensaIraiJokasoRenban { get; set; }

        /// <summary>
        /// DaichoKensaKomokuEdaban
        /// </summary>
        string DaichoKensaKomokuEdaban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAInput : ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAInput
    {
        /// <summary>
        /// KensaIraiJokasoHokenjoCd
        /// </summary>
        public string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiJokasoTorokuNendo
        /// </summary>
        public string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// KensaIraiJokasoRenban
        /// </summary>
        public string KensaIraiJokasoRenban { get; set; }

        /// <summary>
        /// DaichoKensaKomokuEdaban
        /// </summary>
        public string DaichoKensaKomokuEdaban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput
    {
        /// <summary>
        /// SuishitsuShikenKoumokuList
        /// </summary>
        SuishitsuKensaUketsukeShosaiDataSet.SuishitsuShikenKoumokuListDataTable SuishitsuShikenKoumokuList { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput : ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput
    {
        /// <summary>
        /// SuishitsuShikenKoumokuList
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.SuishitsuShikenKoumokuListDataTable SuishitsuShikenKoumokuList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDataAccess : BaseDataAccess<ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAInput, ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuShikenKoumokuListTableAdapter tableAdapter = new SuishitsuShikenKoumokuListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDataAccess
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
        public SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDataAccess()
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
        /// 2014/12/10　豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput Execute(ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput output = new SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SuishitsuShikenKoumokuList = tableAdapter.GetDataByDaichoKensaKomokuKey(input.KensaIraiJokasoHokenjoCd, input.KensaIraiJokasoTorokuNendo, input.KensaIraiJokasoRenban, input.DaichoKensaKomokuEdaban);
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
