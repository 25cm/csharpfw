using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SeikyuDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyuDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSeikyuDtlTblByKeiryoShomeiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSeikyuDtlTblByKeiryoShomeiNoDAInput
    {
        /// <summary>
        /// 計量証明検査依頼年度
        /// </summary>
        string KeiryoShomeiIraiNendo { get; set; }
        /// <summary>
        /// 計量証明支所コード
        /// </summary>
        string KeiryoShomeiIraiSishoCd { get; set; }
        /// <summary>
        /// 計量証明依頼連番
        /// </summary>
        string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuDtlTblByKeiryoShomeiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSeikyuDtlTblByKeiryoShomeiNoDAInput : ISelectSeikyuDtlTblByKeiryoShomeiNoDAInput
    {
        /// <summary>
        /// 計量証明検査依頼年度
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }
        /// <summary>
        /// 計量証明支所コード
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }
        /// <summary>
        /// 計量証明依頼連番
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSeikyuDtlTblByKeiryoShomeiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSeikyuDtlTblByKeiryoShomeiNoDAOutput
    {
        /// <summary>
        /// 請求明細データ
        /// </summary>
        SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuDtlTblByKeiryoShomeiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSeikyuDtlTblByKeiryoShomeiNoDAOutput : ISelectSeikyuDtlTblByKeiryoShomeiNoDAOutput
    {
        /// <summary>
        /// 請求明細データ
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuDtlTblByKeiryoShomeiNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSeikyuDtlTblByKeiryoShomeiNoDataAccess : BaseDataAccess<ISelectSeikyuDtlTblByKeiryoShomeiNoDAInput, ISelectSeikyuDtlTblByKeiryoShomeiNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyuDtlTblTableAdapter tableAdapter = new SeikyuDtlTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSeikyuDtlTblByKeiryoShomeiNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSeikyuDtlTblByKeiryoShomeiNoDataAccess()
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
        /// 2014/10/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSeikyuDtlTblByKeiryoShomeiNoDAOutput Execute(ISelectSeikyuDtlTblByKeiryoShomeiNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSeikyuDtlTblByKeiryoShomeiNoDAOutput output = new SelectSeikyuDtlTblByKeiryoShomeiNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 計量証明番号から請求明細データを取得
                output.SeikyuDtlTblDT = tableAdapter.GetDataByKeiryoShomeiNo(input.KeiryoShomeiIraiNendo, input.KeiryoShomeiIraiSishoCd, input.KeiryoShomeiIraiRenban);
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
