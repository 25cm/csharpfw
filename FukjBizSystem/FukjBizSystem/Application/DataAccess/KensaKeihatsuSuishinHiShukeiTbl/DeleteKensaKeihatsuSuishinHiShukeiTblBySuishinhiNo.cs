using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.KensaKeihatsuSuishinHiShukeiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAInput
    {
        /// <summary>
        /// 推進費No
        /// </summary>
        string SuishinhiNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAInput : IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAInput
    {
        /// <summary>
        /// 推進費No
        /// </summary>
        public string SuishinhiNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAOutput : IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/16  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDataAccess : BaseDataAccess<IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAInput, IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKeihatsuSuishinHiShukeiTblTableAdapter tableAdapter = new KensaKeihatsuSuishinHiShukeiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDataAccess()
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
        /// 2014/10/16  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAOutput Execute(IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAOutput output = new DeleteKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteBySuishinhiNo(input.SuishinhiNo);

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
