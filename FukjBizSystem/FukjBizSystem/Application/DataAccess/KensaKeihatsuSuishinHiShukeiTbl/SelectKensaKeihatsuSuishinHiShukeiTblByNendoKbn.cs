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
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAInput
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
    interface ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAInput
    {
        /// <summary>
        /// 年度 
        /// </summary>
        string SuishinhiNendo { get; set; }

        /// <summary>
        /// 上下期区分
        /// </summary>
        string KamiShimoKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAInput
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
    class SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAInput : ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAInput
    {
        /// <summary>
        /// 年度 
        /// </summary>
        public string SuishinhiNendo { get; set; }

        /// <summary>
        /// 上下期区分
        /// </summary>
        public string KamiShimoKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput
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
    interface ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinHiShukeiTblDataTable
        /// </summary>
        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable KensaKeihatsuSuishinHiShukeiTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput
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
    class SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput : ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinHiShukeiTblDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable KensaKeihatsuSuishinHiShukeiTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDataAccess
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
    class SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDataAccess : BaseDataAccess<ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAInput, ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKeihatsuSuishinHiShukeiTblTableAdapter tableAdapter = new KensaKeihatsuSuishinHiShukeiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDataAccess
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
        public SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDataAccess()
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
        public override ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput Execute(ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput output = new SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaKeihatsuSuishinHiShukeiTblDT = tableAdapter.GetDataBySuishinhiNendoKamiShimoKbn(input.SuishinhiNendo, 
                                                                                                            input.KamiShimoKbn);

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
