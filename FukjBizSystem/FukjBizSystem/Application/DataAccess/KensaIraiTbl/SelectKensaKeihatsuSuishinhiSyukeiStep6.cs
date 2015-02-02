using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinhiSyukeiStep6DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKeihatsuSuishinhiSyukeiStep6DAInput
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
        /// 業者コード
        /// </summary>
        string GyoshaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinhiSyukeiStep6DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKeihatsuSuishinhiSyukeiStep6DAInput : ISelectKensaKeihatsuSuishinhiSyukeiStep6DAInput
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
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinhiSyukeiStep6DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKeihatsuSuishinhiSyukeiStep6DAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinhiSyukeiStep6DataTable
        /// </summary>
        KensaIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep6DataTable KensaKeihatsuSuishinhiSyukeiStep6DT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinhiSyukeiStep6DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKeihatsuSuishinhiSyukeiStep6DAOutput : ISelectKensaKeihatsuSuishinhiSyukeiStep6DAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinhiSyukeiStep6DataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep6DataTable KensaKeihatsuSuishinhiSyukeiStep6DT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinhiSyukeiStep6DataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKeihatsuSuishinhiSyukeiStep6DataAccess : BaseDataAccess<ISelectKensaKeihatsuSuishinhiSyukeiStep6DAInput, ISelectKensaKeihatsuSuishinhiSyukeiStep6DAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKeihatsuSuishinhiSyukeiStep6TableAdapter tableAdapter = new KensaKeihatsuSuishinhiSyukeiStep6TableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaKeihatsuSuishinhiSyukeiStep6DataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaKeihatsuSuishinhiSyukeiStep6DataAccess()
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
        /// 2014/08/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaKeihatsuSuishinhiSyukeiStep6DAOutput Execute(ISelectKensaKeihatsuSuishinhiSyukeiStep6DAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaKeihatsuSuishinhiSyukeiStep6DAOutput output = new SelectKensaKeihatsuSuishinhiSyukeiStep6DAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaKeihatsuSuishinhiSyukeiStep6DT = tableAdapter.GetDataStep6(input.KaishiDt, input.ShuryoDt, input.GyoshaCd);

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
