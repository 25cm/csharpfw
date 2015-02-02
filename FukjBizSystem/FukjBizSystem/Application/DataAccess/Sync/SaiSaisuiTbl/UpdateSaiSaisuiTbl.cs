using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SaiSaisuiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.Sync.SaiSaisuiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSaiSaisuiTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface IUpdateSaiSaisuiTblDAInput
    {
        /// <summary>
        /// SaiSaisuiTblDataTable
        /// </summary>
        SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiTbl { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSaiSaisuiTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class UpdateSaiSaisuiTblDAInput : IUpdateSaiSaisuiTblDAInput
    {
        /// <summary>
        /// SaiSaisuiTblDataTable
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiTbl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSaiSaisuiTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface IUpdateSaiSaisuiTblDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSaiSaisuiTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class UpdateSaiSaisuiTblDAOutput : IUpdateSaiSaisuiTblDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSaiSaisuiTblDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/13　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class UpdateSaiSaisuiTblDataAccess : BaseDataAccess<IUpdateSaiSaisuiTblDAInput, IUpdateSaiSaisuiTblDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SaiSaisuiTblTableAdapter tableAdapter = new SaiSaisuiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateSaiSaisuiTblDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/13　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateSaiSaisuiTblDataAccess()
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
        /// 2014/11/13　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateSaiSaisuiTblDAOutput Execute(IUpdateSaiSaisuiTblDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateSaiSaisuiTblDAOutput output = new UpdateSaiSaisuiTblDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 同時実行制御違反の対応
                foreach (SaiSaisuiTblDataSet.SaiSaisuiTblRow row in input.SaiSaisuiTbl)
                {
                    if (row.RowState == System.Data.DataRowState.Modified)
                    {
                        SaiSaisuiTblDataSet.SaiSaisuiTblDataTable modify = tableAdapter.GetDataByKey(row.SaiSaisuiIraiHoteiKbn, row.SaiSaisuiIraiHokenjoCd, row.SaiSaisuiIraiNendo, row.SaiSaisuiIraiRrenban);

                        // 値の詰め替え
                        foreach (System.Data.DataColumn col in modify.Columns)
                        {
                            modify[0][col.ColumnName] = row[col.ColumnName];
                        }
                        
                        tableAdapter.Update(modify);
                    }
                    else if (row.RowState == System.Data.DataRowState.Deleted)
                    {
                        SaiSaisuiTblDataSet.SaiSaisuiTblDataTable delete = tableAdapter.GetDataByKey(row["SaiSaisuiIraiHoteiKbn", System.Data.DataRowVersion.Original].ToString(), row["SaiSaisuiIraiHokenjoCd", System.Data.DataRowVersion.Original].ToString(), row["SaiSaisuiIraiNendo", System.Data.DataRowVersion.Original].ToString(), row["SaiSaisuiIraiRenban", System.Data.DataRowVersion.Original].ToString());

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
