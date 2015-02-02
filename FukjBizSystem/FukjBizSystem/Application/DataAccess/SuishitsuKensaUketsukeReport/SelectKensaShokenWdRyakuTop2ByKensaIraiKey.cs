using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKensaUketsukeReportDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeReport
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban
        /// </summary>
        string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAInput : ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban
        /// </summary>
        public string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// KensaShokenWdRyakuTop2
        /// </summary>
        SuishitsuKensaUketsukeReportDataSet.KensaShokenWdRyakuTop2DataTable KensaShokenWdRyakuTop2 { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAOutput : ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// KensaShokenWdRyakuTop2
        /// </summary>
        public SuishitsuKensaUketsukeReportDataSet.KensaShokenWdRyakuTop2DataTable KensaShokenWdRyakuTop2 { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaShokenWdRyakuTop2ByKensaIraiKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaShokenWdRyakuTop2ByKensaIraiKeyDataAccess : BaseDataAccess<ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAInput, ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaShokenWdRyakuTop2TableAdapter tableAdapter = new KensaShokenWdRyakuTop2TableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaShokenWdRyakuTop2ByKensaIraiKeyDataAccess
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
        public SelectKensaShokenWdRyakuTop2ByKensaIraiKeyDataAccess()
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
        /// 2014/12/12　豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAOutput Execute(ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAOutput output = new SelectKensaShokenWdRyakuTop2ByKensaIraiKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaShokenWdRyakuTop2 = tableAdapter.GetDataByKensaIraiKey(input.KensaIraiHoteiKbn, input.KensaIraiHokenjoCd, input.KensaIraiNendo, input.KensaIraiRenban);
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
