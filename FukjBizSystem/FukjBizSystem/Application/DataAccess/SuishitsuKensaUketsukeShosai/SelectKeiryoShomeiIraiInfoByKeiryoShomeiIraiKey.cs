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
    //  インターフェイス名 ： ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAInput
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
    interface ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAInput
    {
        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAInput
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
    class SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAInput : ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAInput
    {
        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput
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
    interface ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput
    {
        /// <summary>
        /// KeiryoShomeiIraiInfo
        /// </summary>
        SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoDataTable KeiryoShomeiIraiInfo { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput
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
    class SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput : ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput
    {
        /// <summary>
        /// KeiryoShomeiIraiInfo
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoDataTable KeiryoShomeiIraiInfo { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDataAccess
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
    class SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDataAccess : BaseDataAccess<ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAInput, ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KeiryoShomeiIraiInfoTableAdapter tableAdapter = new KeiryoShomeiIraiInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDataAccess
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
        public SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDataAccess()
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
        public override ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput Execute(ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput output = new SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KeiryoShomeiIraiInfo = tableAdapter.GetDataByKeiryouShomeiIraiKey(input.KeiryoShomeiIraiNendo, input.KeiryoShomeiIraiSishoCd, input.KeiryoShomeiIraiRenban);
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
