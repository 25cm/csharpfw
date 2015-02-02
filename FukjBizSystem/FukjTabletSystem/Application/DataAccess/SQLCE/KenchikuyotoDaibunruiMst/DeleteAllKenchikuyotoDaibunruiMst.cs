using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE.KenchikuyotoDaibunruiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.KenchikuyotoDaibunruiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteAllKenchikuyotoDaibunruiMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteAllKenchikuyotoDaibunruiMstDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllKenchikuyotoDaibunruiMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteAllKenchikuyotoDaibunruiMstDAInput : IDeleteAllKenchikuyotoDaibunruiMstDAInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteAllKenchikuyotoDaibunruiMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteAllKenchikuyotoDaibunruiMstDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllKenchikuyotoDaibunruiMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteAllKenchikuyotoDaibunruiMstDAOutput : IDeleteAllKenchikuyotoDaibunruiMstDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllKenchikuyotoDaibunruiMstDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteAllKenchikuyotoDaibunruiMstDataAccess : BaseDataAccessCe<IDeleteAllKenchikuyotoDaibunruiMstDAInput, IDeleteAllKenchikuyotoDaibunruiMstDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KenchikuyotoDaibunruiMstTableAdapter tableAdapter = new KenchikuyotoDaibunruiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteAllKenchikuyotoDaibunruiMstDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteAllKenchikuyotoDaibunruiMstDataAccess()
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
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteAllKenchikuyotoDaibunruiMstDAOutput Execute(IDeleteAllKenchikuyotoDaibunruiMstDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteAllKenchikuyotoDaibunruiMstDAOutput output = new DeleteAllKenchikuyotoDaibunruiMstDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteAll();

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
