using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE.ShokenKekkaHosokuTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaHosokuTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShokenKekkaHosokuTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShokenKekkaHosokuTblDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShokenKekkaHosokuTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShokenKekkaHosokuTblDAInput : IDeleteShokenKekkaHosokuTblDAInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShokenKekkaHosokuTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShokenKekkaHosokuTblDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShokenKekkaHosokuTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShokenKekkaHosokuTblDAOutput : IDeleteShokenKekkaHosokuTblDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShokenKekkaHosokuTblDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShokenKekkaHosokuTblDataAccess : BaseDataAccessCe<IDeleteShokenKekkaHosokuTblDAInput, IDeleteShokenKekkaHosokuTblDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokenKekkaHosokuTblTableAdapter tableAdapter = new ShokenKekkaHosokuTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteShokenKekkaHosokuTblDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteShokenKekkaHosokuTblDataAccess()
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
        /// 2014/11/17　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteShokenKekkaHosokuTblDAOutput Execute(IDeleteShokenKekkaHosokuTblDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteShokenKekkaHosokuTblDAOutput output = new DeleteShokenKekkaHosokuTblDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                FukjTabletSystem.Application.DataSet.SQLCE.ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable ShokenKekkaHosokuTbl = tableAdapter.GetData();

                foreach (FukjTabletSystem.Application.DataSet.SQLCE.ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblRow row in ShokenKekkaHosokuTbl)
                {
                    row.AcceptChanges();
                    row.Delete();
                }

                tableAdapter.Update(ShokenKekkaHosokuTbl);

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
