using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.Sync.KensaKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaKekkaTblDAInput
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
    public interface IUpdateKensaKekkaTblDAInput
    {
        /// <summary>
        /// KensaKekkaTblDataTable
        /// </summary>
        KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaTbl { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaKekkaTblDAInput
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
    public class UpdateKensaKekkaTblDAInput : IUpdateKensaKekkaTblDAInput
    {
        /// <summary>
        /// KensaKekkaTblDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaTbl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaKekkaTblDAOutput
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
    public interface IUpdateKensaKekkaTblDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaKekkaTblDAOutput
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
    public class UpdateKensaKekkaTblDAOutput : IUpdateKensaKekkaTblDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaKekkaTblDataAccess
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
    public class UpdateKensaKekkaTblDataAccess : BaseDataAccess<IUpdateKensaKekkaTblDAInput, IUpdateKensaKekkaTblDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKekkaTblTableAdapter tableAdapter = new KensaKekkaTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKensaKekkaTblDataAccess
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
        public UpdateKensaKekkaTblDataAccess()
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
        public override IUpdateKensaKekkaTblDAOutput Execute(IUpdateKensaKekkaTblDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKensaKekkaTblDAOutput output = new UpdateKensaKekkaTblDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 同時実行制御違反の対応
                foreach (KensaKekkaTblDataSet.KensaKekkaTblRow row in input.KensaKekkaTbl)
                {
                    if (row.RowState == System.Data.DataRowState.Modified)
                    {
                        KensaKekkaTblDataSet.KensaKekkaTblDataTable modify = tableAdapter.GetDataByKey(row.KensaKekkaIraiHoteiKbn, row.KensaKekkaIraiHokenjoCd, row.KensaKekkaIraiNendo, row.KensaKekkaIraiRenban);

                        // 値の詰め替え
                        foreach (System.Data.DataColumn col in modify.Columns)
                        {
                            modify[0][col.ColumnName] = row[col.ColumnName];
                        }
                        
                        tableAdapter.Update(modify);
                    }
                    else if (row.RowState == System.Data.DataRowState.Deleted)
                    {
                        KensaKekkaTblDataSet.KensaKekkaTblDataTable delete = tableAdapter.GetDataByKey(row["KensaKekkaIraiHoteiKbn", System.Data.DataRowVersion.Original].ToString(), row["KensaKekkaIraiHokenjoCd", System.Data.DataRowVersion.Original].ToString(), row["KensaKekkaIraiNendo", System.Data.DataRowVersion.Original].ToString(), row["KensaKekkaIraiRenban", System.Data.DataRowVersion.Original].ToString());

                        // 値の詰め替え
                        foreach (System.Data.DataColumn col in delete.Columns)
                        {
                            delete[0][col.ColumnName] = row[col.ColumnName, System.Data.DataRowVersion.Original];
                        }

                        delete[0].Delete();

                        tableAdapter.Update(delete);
                    }
                    else
                    {
                        tableAdapter.Update(row);
                    }
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
