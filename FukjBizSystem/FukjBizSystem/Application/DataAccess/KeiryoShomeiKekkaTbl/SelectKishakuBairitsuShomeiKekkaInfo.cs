using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KeiryoShomeiKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KeiryoShomeiKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKishakuBairitsuShomeiKekkaInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKishakuBairitsuShomeiKekkaInfoDAInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        KensaIraishoOutputSearchCond SearchCond { get; set; }

        /// <summary>
        /// ShikenKomokuCd 
        /// </summary>
        string ShikenKomokuCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKishakuBairitsuShomeiKekkaInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKishakuBairitsuShomeiKekkaInfoDAInput : ISelectKishakuBairitsuShomeiKekkaInfoDAInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public KensaIraishoOutputSearchCond SearchCond { get; set; }

        /// <summary>
        /// ShikenKomokuCd 
        /// </summary>
        public string ShikenKomokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKishakuBairitsuShomeiKekkaInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKishakuBairitsuShomeiKekkaInfoDAOutput
    {
        /// <summary>
        /// KishakuBairitsuShomeiKekkaDataTable
        /// </summary>
        KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaDataTable KishakuBairitsuShomeiKekkaDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKishakuBairitsuShomeiKekkaInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKishakuBairitsuShomeiKekkaInfoDAOutput : ISelectKishakuBairitsuShomeiKekkaInfoDAOutput
    {
        /// <summary>
        /// KishakuBairitsuShomeiKekkaDataTable
        /// </summary>
        public KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaDataTable KishakuBairitsuShomeiKekkaDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKishakuBairitsuShomeiKekkaInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKishakuBairitsuShomeiKekkaInfoDataAccess : BaseDataAccess<ISelectKishakuBairitsuShomeiKekkaInfoDAInput, ISelectKishakuBairitsuShomeiKekkaInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KishakuBairitsuShomeiKekkaTableAdapter tableAdapter = new KishakuBairitsuShomeiKekkaTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKishakuBairitsuShomeiKekkaInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKishakuBairitsuShomeiKekkaInfoDataAccess()
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
        /// 2014/12/02  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKishakuBairitsuShomeiKekkaInfoDAOutput Execute(ISelectKishakuBairitsuShomeiKekkaInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKishakuBairitsuShomeiKekkaInfoDAOutput output = new SelectKishakuBairitsuShomeiKekkaInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KishakuBairitsuShomeiKekkaDataTable = tableAdapter.GetDataBySearchCond(input.SearchCond, input.ShikenKomokuCd);

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
