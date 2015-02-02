using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.KensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaKekkaForTimesUpdateDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKensaKekkaForTimesUpdateDAInput
    {
        /// <summary>
        /// JokasoDaichoMst
        /// </summary>
        KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable KensaKekkaForTimesUpdate { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaKekkaForTimesUpdateDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaKekkaForTimesUpdateDAInput : IUpdateKensaKekkaForTimesUpdateDAInput
    {
        /// <summary>
        /// JokasoDaichoMst
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaForTimesUpdateDataTable KensaKekkaForTimesUpdate { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaKekkaForTimesUpdateDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKensaKekkaForTimesUpdateDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaKekkaForTimesUpdateDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaKekkaForTimesUpdateDAOutput : IUpdateKensaKekkaForTimesUpdateDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaKekkaForTimesUpdateDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaKekkaForTimesUpdateDataAccess : BaseDataAccessCe<IUpdateKensaKekkaForTimesUpdateDAInput, IUpdateKensaKekkaForTimesUpdateDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKekkaForTimesUpdateTableAdapter tableAdapter = new KensaKekkaForTimesUpdateTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKensaKekkaForTimesUpdateDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKensaKekkaForTimesUpdateDataAccess()
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
        /// 2014/11/26　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKensaKekkaForTimesUpdateDAOutput Execute(IUpdateKensaKekkaForTimesUpdateDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKensaKekkaForTimesUpdateDAOutput output = new UpdateKensaKekkaForTimesUpdateDAOutput();

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
                //      場所 FukjTabletSystem.Application.DataSet.SQLCE.KensaKekkaTblDataSetTableAdapters.JokasoDaichoMstTableAdapter.Update(KensaKekkaForTimesUpdateDataTable dataTable) 場所 C:\git\fj_biz-system\FukjBizSystem\FukjTabletSystem\Application\DataSet\SQLCE\KensaKekkaTblDataSet.Designer.cs:行 8106
                //      場所 FukjTabletSystem.Application.DataAccess.SQLCE.JokasoDaichoMst.UpdateKensaKekkaForTimesUpdateDataAccess.Execute(IUpdateKensaKekkaForTimesUpdateDAInput input) 場所 C:\git\fj_biz-system\FukjBizSystem\FukjTabletSystem\Application\DataAccess\SQLCE\JokasoDaichoMst\UpdateKensaKekkaForTimesUpdate.cs:行 165
                // InnerException: 
                // 
                //【現象】
                //  データテーブルに複数件のレコードを設定、かつ、データ型がncharでnull許容のフィールドに
                //  null、null以外の値が混在した場合に、例外が発生する。なお、1件目のレコードがnullでない場合は発生しない。
                //  1件目のレコードでパラメータサイズが定義されている？
                //  row毎のUpdateは成功するので暫定的に・・・

                foreach (KensaKekkaTblDataSet.KensaKekkaForTimesUpdateRow row in input.KensaKekkaForTimesUpdate)
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
