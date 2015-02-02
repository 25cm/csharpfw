using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuIraiUketsukeWrkDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuIraiUketsukeWrk
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaIraiUketsukeListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraiUketsukeListBySearchCondDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        string kensaKbn { get; set; }

        /// <summary>
        /// 支所コード（必須）
        /// </summary>
        string shishoCd { get; set; }

        /// <summary>
        /// 受付番号（from）
        /// </summary>
        string uketsukeNoFrom { get; set; }

        /// <summary>
        /// 受付番号（to）
        /// </summary>
        string uketsukeNoTo { get; set; }

        /// <summary>
        /// 受付日（from）
        /// </summary>
        DateTime? uketsukeDateFrom { get; set; }

        /// <summary>
        /// 受付日（to）
        /// </summary>
        DateTime? uketsukeDateTo { get; set; }

        /// <summary>
        /// 出力済みを含めるか
        /// </summary>
        bool includeOutput { get; set; }

        /// <summary>
        /// 出力日（from）
        /// </summary>
        DateTime? outputDateFrom { get; set; }

        /// <summary>
        /// 出力日（to）
        /// </summary>
        DateTime? outputDateTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiUketsukeListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiUketsukeListBySearchCondDAInput : ISelectKensaIraiUketsukeListBySearchCondDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string kensaKbn { get; set; }

        /// <summary>
        /// 支所コード（必須）
        /// </summary>
        public string shishoCd { get; set; }

        /// <summary>
        /// 受付番号（from）
        /// </summary>
        public string uketsukeNoFrom { get; set; }

        /// <summary>
        /// 受付番号（to）
        /// </summary>
        public string uketsukeNoTo { get; set; }

        /// <summary>
        /// 受付日（from）
        /// </summary>
        public DateTime? uketsukeDateFrom { get; set; }

        /// <summary>
        /// 受付日（to）
        /// </summary>
        public DateTime? uketsukeDateTo { get; set; }

        /// <summary>
        /// 出力済みを含めるか
        /// </summary>
        public bool includeOutput { get; set; }

        /// <summary>
        /// 出力日（from）
        /// </summary>
        public DateTime? outputDateFrom { get; set; }

        /// <summary>
        /// 出力日（to）
        /// </summary>
        public DateTime? outputDateTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaIraiUketsukeListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraiUketsukeListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaIraiUketsukeList
        /// </summary>
        SuishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeListDataTable KensaIraiUketsukeList { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiUketsukeListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiUketsukeListBySearchCondDAOutput : ISelectKensaIraiUketsukeListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaIraiUketsukeList
        /// </summary>
        public SuishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeListDataTable KensaIraiUketsukeList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiUketsukeListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiUketsukeListBySearchCondDataAccess : BaseDataAccess<ISelectKensaIraiUketsukeListBySearchCondDAInput, ISelectKensaIraiUketsukeListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaIraiUketsukeListTableAdapter tableAdapter = new KensaIraiUketsukeListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaIraiUketsukeListBySearchCondDataAccess
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
        public SelectKensaIraiUketsukeListBySearchCondDataAccess()
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
        /// 2014/10/06　豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaIraiUketsukeListBySearchCondDAOutput Execute(ISelectKensaIraiUketsukeListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaIraiUketsukeListBySearchCondDAOutput output = new SelectKensaIraiUketsukeListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaIraiUketsukeList = tableAdapter.GetDataBySearchCond(input.kensaKbn,
                                                                                input.shishoCd,
                                                                                input.uketsukeNoFrom,
                                                                                input.uketsukeNoTo,
                                                                                input.uketsukeDateFrom,
                                                                                input.uketsukeDateTo,
                                                                                input.includeOutput,
                                                                                input.outputDateFrom,
                                                                                input.outputDateTo);
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
