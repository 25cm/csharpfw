using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaDaicho9joHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaDaicho9joHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        KeiryoShomeiDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput : ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public KeiryoShomeiDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput
    {
        /// <summary>
        /// Jo9KakuninKensaJisshiKirokuDataTable
        /// </summary>
        KensaDaicho9joHdrTblDataSet.Jo9KakuninKensaJisshiKirokuDataTable Jo9KakuninKensaJisshiKirokuDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput : ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput
    {
        /// <summary>
        /// Jo9KakuninKensaJisshiKirokuDataTable
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.Jo9KakuninKensaJisshiKirokuDataTable Jo9KakuninKensaJisshiKirokuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJo9KakuninKensaJisshiKirokuBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJo9KakuninKensaJisshiKirokuBySearchCondDataAccess : BaseDataAccess<ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput, ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private Jo9KakuninKensaJisshiKirokuTableAdapter tableAdapter = new Jo9KakuninKensaJisshiKirokuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJo9KakuninKensaJisshiKirokuBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJo9KakuninKensaJisshiKirokuBySearchCondDataAccess()
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
        /// 2014/12/05  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput Execute(ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput output = new SelectJo9KakuninKensaJisshiKirokuBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.Jo9KakuninKensaJisshiKirokuDataTable = tableAdapter.GetDataBySearchCond(input.SearchCond);

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
