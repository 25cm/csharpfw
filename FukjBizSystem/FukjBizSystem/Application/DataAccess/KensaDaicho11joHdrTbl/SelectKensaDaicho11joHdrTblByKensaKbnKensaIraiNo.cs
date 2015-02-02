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
    //  インターフェイス名 ： ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNo  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        string KensaKbn { get; set; }

        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所CD
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼依頼年度
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNo  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAInput : ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string KensaKbn { get; set; }

        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所CD
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNo  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput
    {
        /// <summary>
        /// 検査台帳（11条）ヘッダ情報
        /// </summary>
        KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable KensaDaicho11joHdrDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNo  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput : ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput
    {
        /// <summary>
        /// 検査台帳（11条）ヘッダ情報
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable KensaDaicho11joHdrDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNo  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDataAccess : BaseDataAccess<ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAInput, ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaDaicho11joHdrTblTableAdapter tableAdapter = new KensaDaicho11joHdrTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNo  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDataAccess()
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
        /// 2014/SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNo  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput Execute(ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput output = new SelectKensaDaicho11joHdrTblByKensaKbnKensaIraiNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 検査依頼台帳（11条）ヘッダ情報取得
                output.KensaDaicho11joHdrDT = tableAdapter.GetDataByKensaKbnKensaIraiNo(input.KensaKbn, input.KensaIraiHoteiKbn, input.KensaIraiHokenjoCd, input.KensaIraiNendo, input.KensaIraiRenban);

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
