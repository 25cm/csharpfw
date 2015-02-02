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
    //  インターフェイス名 ： ISelectMaxKensaDtByJokasoDaichoKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMaxKensaDtByJokasoDaichoKeyDAInput
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
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaxKensaDtByJokasoDaichoKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMaxKensaDtByJokasoDaichoKeyDAInput : ISelectMaxKensaDtByJokasoDaichoKeyDAInput
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
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMaxKensaDtByJokasoDaichoKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMaxKensaDtByJokasoDaichoKeyDAOutput
    {
        /// <summary>
        /// MaxKensaDt
        /// </summary>
        SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtDataTable MaxKensaDt { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaxKensaDtByJokasoDaichoKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMaxKensaDtByJokasoDaichoKeyDAOutput : ISelectMaxKensaDtByJokasoDaichoKeyDAOutput
    {
        /// <summary>
        /// MaxKensaDt
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtDataTable MaxKensaDt { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaxKensaDtByJokasoDaichoKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMaxKensaDtByJokasoDaichoKeyDataAccess : BaseDataAccess<ISelectMaxKensaDtByJokasoDaichoKeyDAInput, ISelectMaxKensaDtByJokasoDaichoKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private MaxKensaDtTableAdapter tableAdapter = new MaxKensaDtTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMaxKensaDtByJokasoDaichoKeyDataAccess
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
        public SelectMaxKensaDtByJokasoDaichoKeyDataAccess()
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
        /// 2014/12/09　豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectMaxKensaDtByJokasoDaichoKeyDAOutput Execute(ISelectMaxKensaDtByJokasoDaichoKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMaxKensaDtByJokasoDaichoKeyDAOutput output = new SelectMaxKensaDtByJokasoDaichoKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.MaxKensaDt = tableAdapter.GetDataByJokasoDaichoKey(input.KensaIraiJokasoHokenjoCd, input.KensaIraiJokasoTorokuNendo, input.KensaIraiJokasoRenban);
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
