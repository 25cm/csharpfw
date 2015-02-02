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
    //  インターフェイス名 ： ISelectKensaDaicho9joHdrTblByKeyDAInput
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
    interface ISelectKensaDaicho9joHdrTblByKeyDAInput
    {
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
    //  クラス名 ： SelectKensaDaicho9joHdrTblByKeyDAInput
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
    class SelectKensaDaicho9joHdrTblByKeyDAInput : ISelectKensaDaicho9joHdrTblByKeyDAInput
    {
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
    //  インターフェイス名 ： ISelectKensaDaicho9joHdrTblByKeyDAOutput
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
    interface ISelectKensaDaicho9joHdrTblByKeyDAOutput
    {
        /// <summary>
        /// 検査台帳（9条）ヘッダ情報
        /// </summary>
        KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable KensaDaicho9joHdrDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaicho9joHdrTblByKeyDAOutput
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
    class SelectKensaDaicho9joHdrTblByKeyDAOutput : ISelectKensaDaicho9joHdrTblByKeyDAOutput
    {
        /// <summary>
        /// 検査台帳（9条）ヘッダ情報
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable KensaDaicho9joHdrDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaicho9joHdrTblByKeyDataAccess
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
    class SelectKensaDaicho9joHdrTblByKeyDataAccess : BaseDataAccess<ISelectKensaDaicho9joHdrTblByKeyDAInput, ISelectKensaDaicho9joHdrTblByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaDaicho9joHdrTblTableAdapter tableAdapter = new KensaDaicho9joHdrTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaDaicho9joHdrTblByKeyDataAccess
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
        public SelectKensaDaicho9joHdrTblByKeyDataAccess()
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
        public override ISelectKensaDaicho9joHdrTblByKeyDAOutput Execute(ISelectKensaDaicho9joHdrTblByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaDaicho9joHdrTblByKeyDAOutput output = new SelectKensaDaicho9joHdrTblByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 検査依頼台帳（9条）ヘッダ情報取得
                output.KensaDaicho9joHdrDT = tableAdapter.GetDataByKey(input.IraiNendo, input.ShishoCd, input.SuishitsuKensaIraiNo);

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
