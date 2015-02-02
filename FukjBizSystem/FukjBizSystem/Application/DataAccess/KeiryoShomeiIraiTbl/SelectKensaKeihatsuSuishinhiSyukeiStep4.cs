using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KeiryoShomeiIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinhiSyukeiStep4DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKeihatsuSuishinhiSyukeiStep4DAInput
    {
        /// <summary>
        /// 開始日
        /// </summary>
        string KaishiDt { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        string ShuryoDt { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        decimal Amount { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        string GyoshaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinhiSyukeiStep4DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKeihatsuSuishinhiSyukeiStep4DAInput : ISelectKensaKeihatsuSuishinhiSyukeiStep4DAInput
    {
        /// <summary>
        /// 開始日
        /// </summary>
        public string KaishiDt { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        public string ShuryoDt { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinhiSyukeiStep4DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKeihatsuSuishinhiSyukeiStep4DAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinhiSyukeiStep4DataTable
        /// </summary>
        KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep4DataTable KensaKeihatsuSuishinhiSyukeiStep4DT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinhiSyukeiStep4DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKeihatsuSuishinhiSyukeiStep4DAOutput : ISelectKensaKeihatsuSuishinhiSyukeiStep4DAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinhiSyukeiStep4DataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep4DataTable KensaKeihatsuSuishinhiSyukeiStep4DT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinhiSyukeiStep4DataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKeihatsuSuishinhiSyukeiStep4DataAccess : BaseDataAccess<ISelectKensaKeihatsuSuishinhiSyukeiStep4DAInput, ISelectKensaKeihatsuSuishinhiSyukeiStep4DAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKeihatsuSuishinhiSyukeiStep4TableAdapter tableAdapter = new KensaKeihatsuSuishinhiSyukeiStep4TableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaKeihatsuSuishinhiSyukeiStep4DataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaKeihatsuSuishinhiSyukeiStep4DataAccess()
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
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaKeihatsuSuishinhiSyukeiStep4DAOutput Execute(ISelectKensaKeihatsuSuishinhiSyukeiStep4DAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaKeihatsuSuishinhiSyukeiStep4DAOutput output = new SelectKensaKeihatsuSuishinhiSyukeiStep4DAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaKeihatsuSuishinhiSyukeiStep4DT = tableAdapter.GetDataStep4(input.KaishiDt, 
                                                                                        input.ShuryoDt, 
                                                                                        input.Amount, 
                                                                                        input.GyoshaCd);

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
