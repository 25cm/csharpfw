using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaDaicho11joHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaDaicho11joHdrTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaicho11joHdrTblByKeyDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        string SuishitsuKensaIraiNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaicho11joHdrTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaicho11joHdrTblByKeyDAInput : ISelectKensaDaicho11joHdrTblByKeyDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        public string SuishitsuKensaIraiNo { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaDaicho11joHdrTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaicho11joHdrTblByKeyDAOutput
    {
        /// <summary>
        /// 検査台帳（11条）ヘッダ情報
        /// </summary>
        KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable KensaDaicho11joHdrDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaicho11joHdrTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaicho11joHdrTblByKeyDAOutput : ISelectKensaDaicho11joHdrTblByKeyDAOutput
    {
        /// <summary>
        /// 検査台帳（11条）ヘッダ情報
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable KensaDaicho11joHdrDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaicho11joHdrTblByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaicho11joHdrTblByKeyDataAccess : BaseDataAccess<ISelectKensaDaicho11joHdrTblByKeyDAInput, ISelectKensaDaicho11joHdrTblByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaDaicho11joHdrTblTableAdapter tableAdapter = new KensaDaicho11joHdrTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaDaicho11joHdrTblByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaDaicho11joHdrTblByKeyDataAccess()
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
        /// 2014/12/02  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaDaicho11joHdrTblByKeyDAOutput Execute(ISelectKensaDaicho11joHdrTblByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaDaicho11joHdrTblByKeyDAOutput output = new SelectKensaDaicho11joHdrTblByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 検査依頼台帳（11条）ヘッダ情報取得
                output.KensaDaicho11joHdrDT = tableAdapter.GetDataByKey(input.KensaKbn, input.IraiNendo, input.ShishoCd, input.SuishitsuKensaIraiNo);

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
