using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE.TaniSochiKensaJokyoTeidoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiKensaJokyoTeidoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteAllTaniSochiKensaJokyoTeidoMstDAInput
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
    interface IDeleteAllTaniSochiKensaJokyoTeidoMstDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllTaniSochiKensaJokyoTeidoMstDAInput
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
    class DeleteAllTaniSochiKensaJokyoTeidoMstDAInput : IDeleteAllTaniSochiKensaJokyoTeidoMstDAInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteAllTaniSochiKensaJokyoTeidoMstDAOutput
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
    interface IDeleteAllTaniSochiKensaJokyoTeidoMstDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllTaniSochiKensaJokyoTeidoMstDAOutput
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
    class DeleteAllTaniSochiKensaJokyoTeidoMstDAOutput : IDeleteAllTaniSochiKensaJokyoTeidoMstDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteAllTaniSochiKensaJokyoTeidoMstDataAccess
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
    class DeleteAllTaniSochiKensaJokyoTeidoMstDataAccess : BaseDataAccessCe<IDeleteAllTaniSochiKensaJokyoTeidoMstDAInput, IDeleteAllTaniSochiKensaJokyoTeidoMstDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private TaniSochiKensaJokyoTeidoMstTableAdapter tableAdapter = new TaniSochiKensaJokyoTeidoMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteAllTaniSochiKensaJokyoTeidoMstDataAccess
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
        public DeleteAllTaniSochiKensaJokyoTeidoMstDataAccess()
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
        public override IDeleteAllTaniSochiKensaJokyoTeidoMstDAOutput Execute(IDeleteAllTaniSochiKensaJokyoTeidoMstDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteAllTaniSochiKensaJokyoTeidoMstDAOutput output = new DeleteAllTaniSochiKensaJokyoTeidoMstDAOutput();

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
