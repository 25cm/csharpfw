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
    //  インターフェイス名 ： ISelectZenkaiKensaDataWrkBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectZenkaiKensaDataWrkBySearchCondDAInput
    {
        ///// <summary>
        ///// ChikuCdFrom
        ///// </summary>
        //string ChikuCdFrom { get; set; }

        ///// <summary>
        ///// ChikuCdTo
        ///// </summary>
        //string ChikuCdTo { get; set; }

        /// <summary>
        /// GyohsaCdFrom
        /// </summary>
        string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        string GyoshaCdTo { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        string Nendo { get; set; }

        ///// <summary>
        ///// ExistFlg
        ///// </summary>
        //bool ExistFlg { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZenkaiKensaDataWrkBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZenkaiKensaDataWrkBySearchCondDAInput : ISelectZenkaiKensaDataWrkBySearchCondDAInput
    {
        /// <summary>
        ///// ChikuCdFrom
        ///// </summary>
        //public string ChikuCdFrom { get; set; }

        ///// <summary>
        ///// ChikuCdTo
        ///// </summary>
        //public string ChikuCdTo { get; set; }

        /// <summary>
        /// GyohsaCdFrom
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        public string Nendo { get; set; }

        ///// <summary>
        ///// ExistFlg
        ///// </summary>
        //public bool ExistFlg { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectZenkaiKensaDataWrkBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectZenkaiKensaDataWrkBySearchCondDAOutput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable ZenkaiKensaDataWrkKensakuDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZenkaiKensaDataWrkBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZenkaiKensaDataWrkBySearchCondDAOutput : ISelectZenkaiKensaDataWrkBySearchCondDAOutput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        public ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable ZenkaiKensaDataWrkKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectZenkaiKensaDataWrkBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectZenkaiKensaDataWrkBySearchCondDataAccess : BaseDataAccess<ISelectZenkaiKensaDataWrkBySearchCondDAInput, ISelectZenkaiKensaDataWrkBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ZenkaiKensaDataWrkKensakuTableAdapter tableAdapter = new ZenkaiKensaDataWrkKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectZenkaiKensaDataWrkBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/25  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectZenkaiKensaDataWrkBySearchCondDataAccess()
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
        /// 2014/09/25  HuyTX　　    新規作成
        /// 2015/01/22　小松　　　　コマンドタイムアウト設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectZenkaiKensaDataWrkBySearchCondDAOutput Execute(ISelectZenkaiKensaDataWrkBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectZenkaiKensaDataWrkBySearchCondDAOutput output = new SelectZenkaiKensaDataWrkBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // タイムアウトを設定(単位：秒)
                tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                output.ZenkaiKensaDataWrkKensakuDataTable = tableAdapter.GetDataBySearchCond(//input.ChikuCdFrom, 
                                                                                            //input.ChikuCdTo, 
                                                                                            input.GyoshaCdFrom, 
                                                                                            input.GyoshaCdTo,
                                                                                            input.Nendo);
                                                                                            //input.ExistFlg);

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
