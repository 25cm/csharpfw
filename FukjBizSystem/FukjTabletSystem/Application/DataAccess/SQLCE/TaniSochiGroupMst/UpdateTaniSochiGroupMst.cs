using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.TaniSochiGroupMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiGroupMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateTaniSochiGroupMstDAInput
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
    interface IUpdateTaniSochiGroupMstDAInput
    {
        /// <summary>
        /// TaniSochiGroupMst
        /// </summary>
        TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable TaniSochiGroupMst { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateTaniSochiGroupMstDAInput
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
    class UpdateTaniSochiGroupMstDAInput : IUpdateTaniSochiGroupMstDAInput
    {
        /// <summary>
        /// TaniSochiGroupMst
        /// </summary>
        public TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable TaniSochiGroupMst { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateTaniSochiGroupMstDAOutput
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
    interface IUpdateTaniSochiGroupMstDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateTaniSochiGroupMstDAOutput
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
    class UpdateTaniSochiGroupMstDAOutput : IUpdateTaniSochiGroupMstDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateTaniSochiGroupMstDataAccess
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
    class UpdateTaniSochiGroupMstDataAccess : BaseDataAccessCe<IUpdateTaniSochiGroupMstDAInput, IUpdateTaniSochiGroupMstDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private TaniSochiGroupMstTableAdapter tableAdapter = new TaniSochiGroupMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateTaniSochiGroupMstDataAccess
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
        public UpdateTaniSochiGroupMstDataAccess()
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
        public override IUpdateTaniSochiGroupMstDAOutput Execute(IUpdateTaniSochiGroupMstDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateTaniSochiGroupMstDAOutput output = new UpdateTaniSochiGroupMstDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.Update(input.TaniSochiGroupMst);

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
