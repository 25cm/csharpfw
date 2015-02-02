using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Text;
using FukjBizSystem.Application.DataAccess.Common;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.JokasoDaichiRirekiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Core.Base.Common;
using Zynas.Framework.Core.Generic.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri
{
    #region 入力インターフェイス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/02　habu　　    新規作成
    /// </history>
    interface IUpdateJokasoDaichoRirekiBLInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// TorokuNengetsu
        /// </summary>
        string TorokuNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        string Renban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/02　habu　　    新規作成
    /// </history>
    class UpdateJokasoDaichoRirekiBLInput : IUpdateJokasoDaichoRirekiBLInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// TorokuNengetsu
        /// </summary>
        public string TorokuNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        public string Renban { get; set; }        
    }
    #endregion

    #region 出力インターフェイス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/02　habu　　    新規作成
    /// </history>
    interface IUpdateJokasoDaichoRirekiBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/02　habu　　    新規作成
    /// </history>
    class UpdateJokasoDaichoRirekiBLOutput : IUpdateJokasoDaichoRirekiBLOutput
    {

    }
    #endregion

    #region クラス定義
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/02　habu　　    新規作成
    /// </history>
    class UpdateJokasoDaichoRirekiBusinessLogic : BaseBusinessLogic<IUpdateJokasoDaichoRirekiBLInput, IUpdateJokasoDaichoRirekiBLOutput>
    {
        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/02　habu　　    新規作成
        /// </history>
        public UpdateJokasoDaichoRirekiBusinessLogic()
        {

        }
        #endregion

        #region メソッド(public)

        #region Execute
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/02　habu　　    新規作成
        /// </history>
        public override IUpdateJokasoDaichoRirekiBLOutput Execute(IUpdateJokasoDaichoRirekiBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateJokasoDaichoRirekiBLOutput output = new UpdateJokasoDaichoRirekiBLOutput();

            try
            {
                // 浄化槽台帳データ取得
                JokasoDaichoMstDataSet.JokasoDaichoMstDataTable jokaMstTemplate = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

                IStdFilteredSelectDataDAInput jokaMstInput = new StdFilteredSelectDataDAInput();
                jokaMstInput.DataTableType = typeof(JokasoDaichoMstDataSet.JokasoDaichoMstDataTable);
                jokaMstInput.TableAdapterType = typeof(JokasoDaichoMstTableAdapter);
                jokaMstInput.Query.AddEqualCond(jokaMstTemplate.JokasoHokenjoCdColumn.ColumnName, input.HokenjoCd);
                jokaMstInput.Query.AddEqualCond(jokaMstTemplate.JokasoTorokuNendoColumn.ColumnName, input.TorokuNendo);
                jokaMstInput.Query.AddEqualCond(jokaMstTemplate.JokasoRenbanColumn.ColumnName, input.Renban);

                IStdFilteredSelectDataDAOutput jokaMstOutput = new StdFilteredSelectDataDataAccess().Execute(jokaMstInput);

                // 浄化槽台帳が未登録の場合は中断
                if (jokaMstOutput.SelectDataTable.Rows.Count == 0)
                {
                    return output;
                }

                int rirekiRenban = 1;

                // 浄化槽台帳履歴データ取得
                {
                    JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable jokaRirekiTemplate = new JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable();

                    IStdFilteredSelectDataDAInput jokaRirekiInput = new StdFilteredSelectDataDAInput();
                    jokaRirekiInput.DataTableType = typeof(JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable);
                    jokaRirekiInput.TableAdapterType = typeof(JokasoDaichiRirekiTblTableAdapter);
                    jokaRirekiInput.Query.AddEqualCond(jokaMstTemplate.JokasoHokenjoCdColumn.ColumnName, input.HokenjoCd);
                    jokaRirekiInput.Query.AddEqualCond(jokaMstTemplate.JokasoTorokuNendoColumn.ColumnName, input.TorokuNendo);
                    jokaRirekiInput.Query.AddEqualCond(jokaMstTemplate.JokasoRenbanColumn.ColumnName, input.Renban);
                    // 連番の降順でソート
                    jokaRirekiInput.Query.AddOrderCol(jokaRirekiTemplate.JokasoRirekiRenbanColumn.ColumnName, false);
                    
                    IStdFilteredSelectDataDAOutput jokaRirekiOutput = new StdFilteredSelectDataDataAccess().Execute(jokaRirekiInput);

                    // 履歴連番算出
                    if (jokaRirekiOutput.SelectDataTable.Rows.Count > 0)
                    {
                        string currentRenbanStr = (string)jokaRirekiOutput.SelectDataTable.Rows[0][jokaRirekiTemplate.JokasoRirekiRenbanColumn.ColumnName];
                        int currentRenban = 1;

                        if (int.TryParse(currentRenbanStr, out currentRenban))
                        {
                            rirekiRenban = currentRenban + 1;
                        }
                    }
                }

                // 浄化槽台帳履歴更新
                {
                    // 浄化槽台帳コピー
                    JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable newTable = new JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable();
                    JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblRow newRow = newTable.NewJokasoDaichiRirekiTblRow();
                    foreach (DataColumn col in jokaMstTemplate.Columns)
                    {
                        newRow[col.ColumnName] = jokaMstOutput.SelectDataTable.Rows[0][col.ColumnName];
                    }

                    // 新履歴連番を設定
                    newRow[newTable.JokasoRirekiRenbanColumn] = rirekiRenban.ToString("0000");

                    newTable.AddJokasoDaichiRirekiTblRow(newRow);
                    newTable.AcceptChanges();
                    newRow.SetAdded();

                    IStdUpdateDataDAInput updateInput = new StdUpdateDataDAInput();
                    updateInput.TableName = newTable.TableName;
                    updateInput.TargetDataTable = newTable;
                    updateInput.KeyColNameList.Add(newTable.JokasoHokenjoCdColumn.ColumnName);
                    updateInput.KeyColNameList.Add(newTable.JokasoTorokuNendoColumn.ColumnName);
                    updateInput.KeyColNameList.Add(newTable.JokasoRenbanColumn.ColumnName);
                    updateInput.KeyColNameList.Add(newTable.JokasoRirekiRenbanColumn.ColumnName);

                    IStdUpdateDataDAOutput updateOutput = new StdUpdateDataDataAccess().Execute(updateInput);
                }
            }
            catch
            {
                throw;
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
