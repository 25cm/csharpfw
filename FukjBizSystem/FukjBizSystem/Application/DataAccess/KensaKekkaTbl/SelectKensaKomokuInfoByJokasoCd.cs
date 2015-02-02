using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKomokuInfoByJokasoCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKomokuInfoByJokasoCdDAInput
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
    //  クラス名 ： SelectKensaKomokuInfoByJokasoCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKomokuInfoByJokasoCdDAInput : ISelectKensaKomokuInfoByJokasoCdDAInput
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
    //  インターフェイス名 ： ISelectKensaKomokuInfoByJokasoCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKomokuInfoByJokasoCdDAOutput
    {
        /// <summary>
        /// KensaKomokuInfoDataTable
        /// </summary>
        KensaKekkaTblDataSet.KensaKomokuInfoDataTable KensaKomokuInfoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKomokuInfoByJokasoCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKomokuInfoByJokasoCdDAOutput : ISelectKensaKomokuInfoByJokasoCdDAOutput
    {
        /// <summary>
        /// KensaKomokuInfoDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKomokuInfoDataTable KensaKomokuInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKomokuInfoByJokasoCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKomokuInfoByJokasoCdDataAccess : BaseDataAccess<ISelectKensaKomokuInfoByJokasoCdDAInput, ISelectKensaKomokuInfoByJokasoCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKomokuInfoTableAdapter tableAdapter = new KensaKomokuInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaKomokuInfoByJokasoCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaKomokuInfoByJokasoCdDataAccess()
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
        /// 2014/10/16  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaKomokuInfoByJokasoCdDAOutput Execute(ISelectKensaKomokuInfoByJokasoCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaKomokuInfoByJokasoCdDAOutput output = new SelectKensaKomokuInfoByJokasoCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaKomokuInfoDataTable = tableAdapter.GetDataByJokasoCd(input.KensaIraiJokasoHokenjoCd,
                                                                                input.KensaIraiJokasoTorokuNendo,
                                                                                input.KensaIraiJokasoRenban);

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
