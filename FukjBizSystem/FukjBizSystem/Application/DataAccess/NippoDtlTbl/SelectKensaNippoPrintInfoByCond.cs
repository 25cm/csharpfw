using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.NippoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NippoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaNippoPrintInfoByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaNippoPrintInfoByCondDAInput
    {
        /// <summary>
        /// NippoKensaDt
        /// </summary>
        string NippoKensaDt { get; set; }

        /// <summary>
        /// NippoKensainCd
        /// </summary>
        string NippoKensainCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaNippoPrintInfoByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaNippoPrintInfoByCondDAInput : ISelectKensaNippoPrintInfoByCondDAInput
    {
        /// <summary>
        /// NippoKensaDt
        /// </summary>
        public string NippoKensaDt { get; set; }

        /// <summary>
        /// NippoKensainCd
        /// </summary>
        public string NippoKensainCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaNippoPrintInfoByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaNippoPrintInfoByCondDAOutput
    {
        /// <summary>
        /// KensaNippoPrintInfoDataTable
        /// </summary>
        NippoDtlTblDataSet.KensaNippoPrintInfoDataTable KensaNippoPrintInfoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaNippoPrintInfoByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaNippoPrintInfoByCondDAOutput : ISelectKensaNippoPrintInfoByCondDAOutput
    {
        /// <summary>
        /// KensaNippoPrintInfoDataTable
        /// </summary>
        public NippoDtlTblDataSet.KensaNippoPrintInfoDataTable KensaNippoPrintInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaNippoPrintInfoByCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/22  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaNippoPrintInfoByCondDataAccess : BaseDataAccess<ISelectKensaNippoPrintInfoByCondDAInput, ISelectKensaNippoPrintInfoByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaNippoPrintInfoTableAdapter tableAdapter = new KensaNippoPrintInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaNippoPrintInfoByCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/22  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaNippoPrintInfoByCondDataAccess()
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
        /// 2014/10/22  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaNippoPrintInfoByCondDAOutput Execute(ISelectKensaNippoPrintInfoByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaNippoPrintInfoByCondDAOutput output = new SelectKensaNippoPrintInfoByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaNippoPrintInfoDataTable = tableAdapter.GetDataBySearchCond(input.NippoKensaDt, input.NippoKensainCd);

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
