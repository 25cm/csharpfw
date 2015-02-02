using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ZenkaiKensaDataWrkDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ZenkaiKensaDataWrk
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectZenkaiKensaDataWrkByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectZenkaiKensaDataWrkByKeyDAInput
    {
        /// <summary>
        /// JokasoHokenjoCd 
        /// </summary>
        string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoTorokuNendo 
        /// </summary>
        string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// JokasoRenban 
        /// </summary>
        string JokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZenkaiKensaDataWrkByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZenkaiKensaDataWrkByKeyDAInput : ISelectZenkaiKensaDataWrkByKeyDAInput
    {
        /// <summary>
        /// JokasoHokenjoCd 
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoTorokuNendo 
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// JokasoRenban 
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectZenkaiKensaDataWrkByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectZenkaiKensaDataWrkByKeyDAOutput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkDataTable
        /// </summary>
        ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkDataTable ZenkaiKensaDataWrkDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZenkaiKensaDataWrkByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZenkaiKensaDataWrkByKeyDAOutput : ISelectZenkaiKensaDataWrkByKeyDAOutput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkDataTable
        /// </summary>
        public ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkDataTable ZenkaiKensaDataWrkDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZenkaiKensaDataWrkByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZenkaiKensaDataWrkByKeyDataAccess : BaseDataAccess<ISelectZenkaiKensaDataWrkByKeyDAInput, ISelectZenkaiKensaDataWrkByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ZenkaiKensaDataWrkTableAdapter tableAdapter = new ZenkaiKensaDataWrkTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectZenkaiKensaDataWrkByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectZenkaiKensaDataWrkByKeyDataAccess()
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
        /// 2014/09/24  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectZenkaiKensaDataWrkByKeyDAOutput Execute(ISelectZenkaiKensaDataWrkByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectZenkaiKensaDataWrkByKeyDAOutput output = new SelectZenkaiKensaDataWrkByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ZenkaiKensaDataWrkDataTable = tableAdapter.GetDataByKey(input.JokasoHokenjoCd, input.JokasoTorokuNendo, input.JokasoRenban);

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
