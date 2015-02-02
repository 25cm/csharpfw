using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.JokasoDaichoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.JokasoDaichoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateJokasoDaichoMstWithoutLocationDAInput
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
    interface IUpdateJokasoDaichoMstWithoutLocationDAInput
    {
        /// <summary>
        /// JokasoDaichoMst
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstWithoutLocationDataTable JokasoDaichoMstWithoutLocation { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateJokasoDaichoMstWithoutLocationDAInput
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
    class UpdateJokasoDaichoMstWithoutLocationDAInput : IUpdateJokasoDaichoMstWithoutLocationDAInput
    {
        /// <summary>
        /// JokasoDaichoMst
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstWithoutLocationDataTable JokasoDaichoMstWithoutLocation { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateJokasoDaichoMstWithoutLocationDAOutput
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
    interface IUpdateJokasoDaichoMstWithoutLocationDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateJokasoDaichoMstWithoutLocationDAOutput
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
    class UpdateJokasoDaichoMstWithoutLocationDAOutput : IUpdateJokasoDaichoMstWithoutLocationDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateJokasoDaichoMstWithoutLocationDataAccess
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
    class UpdateJokasoDaichoMstWithoutLocationDataAccess : BaseDataAccessCe<IUpdateJokasoDaichoMstWithoutLocationDAInput, IUpdateJokasoDaichoMstWithoutLocationDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JokasoDaichoMstWithoutLocationTableAdapter tableAdapter = new JokasoDaichoMstWithoutLocationTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateJokasoDaichoMstWithoutLocationDataAccess
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
        public UpdateJokasoDaichoMstWithoutLocationDataAccess()
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
        public override IUpdateJokasoDaichoMstWithoutLocationDAOutput Execute(IUpdateJokasoDaichoMstWithoutLocationDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateJokasoDaichoMstWithoutLocationDAOutput output = new UpdateJokasoDaichoMstWithoutLocationDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);
                
                //tableAdapter.Update(input.JokasoDaichoMst);
                // ↑
                // System.InvalidOperationException が発生しました。
                // HResult=-2146233079
                // Message=@p5 : 文字列の切り詰め: max=0、len=1、value='1'。
                // Source=System.Data
                // StackTrace:
                //      場所 System.Data.Common.DbDataAdapter.UpdatedRowStatusErrors(RowUpdatedEventArgs rowUpdatedEvent, BatchCommandInfo[] batchCommands, Int32 commandCount)
                //      場所 System.Data.Common.DbDataAdapter.UpdatedRowStatus(RowUpdatedEventArgs rowUpdatedEvent, BatchCommandInfo[] batchCommands, Int32 commandCount)
                //      場所 System.Data.Common.DbDataAdapter.Update(DataRow[] dataRows, DataTableMapping tableMapping)
                //      場所 System.Data.Common.DbDataAdapter.UpdateFromDataTable(DataTable dataTable, DataTableMapping tableMapping)
                //      場所 System.Data.Common.DbDataAdapter.Update(DataTable dataTable)
                //      場所 FukjTabletSystem.Application.DataSet.SQLCE.JokasoDaichoMstDataSetTableAdapters.JokasoDaichoMstTableAdapter.Update(JokasoDaichoMstWithoutLocationDataTable dataTable) 場所 C:\git\fj_biz-system\FukjBizSystem\FukjTabletSystem\Application\DataSet\SQLCE\JokasoDaichoMstDataSet.Designer.cs:行 8106
                //      場所 FukjTabletSystem.Application.DataAccess.SQLCE.JokasoDaichoMst.UpdateJokasoDaichoMstWithoutLocationDataAccess.Execute(IUpdateJokasoDaichoMstWithoutLocationDAInput input) 場所 C:\git\fj_biz-system\FukjBizSystem\FukjTabletSystem\Application\DataAccess\SQLCE\JokasoDaichoMst\UpdateJokasoDaichoMstWithoutLocation.cs:行 165
                // InnerException: 
                // 
                //【現象】
                //  データテーブルに複数件のレコードを設定、かつ、データ型がncharでnull許容のフィールドに
                //  null、null以外の値が混在した場合に、例外が発生する。なお、1件目のレコードがnullでない場合は発生しない。
                //  1件目のレコードでパラメータサイズが定義されている？
                //  row毎のUpdateは成功するので暫定的に・・・

                foreach (JokasoDaichoMstDataSet.JokasoDaichoMstWithoutLocationRow row in input.JokasoDaichoMstWithoutLocation)
                {
                    tableAdapter.Update(row);
                }

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
