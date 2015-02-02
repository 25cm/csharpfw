using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaKeihatsuSuishinHiShukeiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAInput
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
    interface ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAInput
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
    class SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAInput : ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAInput
    {
        
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput
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
    interface ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinHiShukeiTblDataTable
        /// </summary>
        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable KensaKeihatsuSuishinHiShukeiTblMaxShukeiDtDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput
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
    class SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput : ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinHiShukeiTblDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable KensaKeihatsuSuishinHiShukeiTblMaxShukeiDtDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDataAccess
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
    class SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDataAccess : BaseDataAccess<ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAInput, ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKeihatsuSuishinHiShukeiTblTableAdapter tableAdapter = new KensaKeihatsuSuishinHiShukeiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDataAccess
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
        public SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDataAccess()
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
        public override ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput Execute(ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput output = new SelectKensaKeihatsuSuishinHiShukeiTblByMaxShukeiDtDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaKeihatsuSuishinHiShukeiTblMaxShukeiDtDT = tableAdapter.GetDataByMaxShukeiDt();

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
