using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoHoyuTaniSochiGroupTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.Sync.JokasoHoyuTaniSochiGroupTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateJokasoHoyuTaniSochiGroupTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface IUpdateJokasoHoyuTaniSochiGroupTblDAInput
    {
        /// <summary>
        /// JokasoHoyuTaniSochiGroupTblDataTable
        /// </summary>
        JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable JokasoHoyuTaniSochiGroupTbl { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateJokasoHoyuTaniSochiGroupTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class UpdateJokasoHoyuTaniSochiGroupTblDAInput : IUpdateJokasoHoyuTaniSochiGroupTblDAInput
    {
        /// <summary>
        /// JokasoHoyuTaniSochiGroupTblDataTable
        /// </summary>
        public JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable JokasoHoyuTaniSochiGroupTbl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateJokasoHoyuTaniSochiGroupTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface IUpdateJokasoHoyuTaniSochiGroupTblDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateJokasoHoyuTaniSochiGroupTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class UpdateJokasoHoyuTaniSochiGroupTblDAOutput : IUpdateJokasoHoyuTaniSochiGroupTblDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateJokasoHoyuTaniSochiGroupTblDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class UpdateJokasoHoyuTaniSochiGroupTblDataAccess : BaseDataAccess<IUpdateJokasoHoyuTaniSochiGroupTblDAInput, IUpdateJokasoHoyuTaniSochiGroupTblDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JokasoHoyuTaniSochiGroupTblTableAdapter tableAdapter = new JokasoHoyuTaniSochiGroupTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateJokasoHoyuTaniSochiGroupTblDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateJokasoHoyuTaniSochiGroupTblDataAccess()
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
        /// 2014/08/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateJokasoHoyuTaniSochiGroupTblDAOutput Execute(IUpdateJokasoHoyuTaniSochiGroupTblDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateJokasoHoyuTaniSochiGroupTblDAOutput output = new UpdateJokasoHoyuTaniSochiGroupTblDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.Update(input.JokasoHoyuTaniSochiGroupTbl);
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
