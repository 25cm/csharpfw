using System.Collections.Generic;
using System.Data;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Common.DataAccess;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoShosai
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    interface IDeleteBtnCllickALInput : IBseALInput
    {
        /// <summary>
        /// 
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string TorokuNendo { get; set; }

        /// <summary>
        /// 
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    class DeleteBtnCllickALInput : IBseALInputImpl, IDeleteBtnCllickALInput
    {
        /// <summary>
        /// 
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TorokuNendo { get; set; }

        /// <summary>
        /// 
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    interface IDeleteBtnCllickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        string ErrMessage { get; set; }
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    class DeleteBtnCllickALOutput : IDeleteBtnCllickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        public string ErrMessage { get; set; }
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
    /// 2014/08/29　habu　　    新規作成
    /// </history>
    class DeleteBtnCllickApplicationLogic : BaseApplicationLogic<IDeleteBtnCllickALInput, IDeleteBtnCllickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JokasoDaichoShosai：DeleteBtnCllick";

        #endregion

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　habu　　    新規作成
        /// </history>
        public DeleteBtnCllickApplicationLogic()
        {

        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　habu　　    新規作成
        /// </history>
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/08/29　habu　　    新規作成
        /// </history>
        public override IDeleteBtnCllickALOutput Execute(IDeleteBtnCllickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnCllickALOutput output = new DeleteBtnCllickALOutput();

            try
            {
                StartTransaction();

                #region define key colmn and value

                List<string> keyColList = new List<string>();
                List<object> keyValueList = new List<object>();

                JokasoDaichoMstDataSet.JokasoDaichoMstDataTable templateTableDaicho = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

                keyColList.Add(templateTableDaicho.JokasoHokenjoCdColumn.ColumnName);
                keyColList.Add(templateTableDaicho.JokasoTorokuNendoColumn.ColumnName);
                keyColList.Add(templateTableDaicho.JokasoRenbanColumn.ColumnName);

                keyValueList.Add(input.HokenjoCd);
                keyValueList.Add(input.TorokuNendo);
                keyValueList.Add(input.Renban);

                #endregion

                #region check refered tables exists

                // KensaIraiTbl
                {
                    KensaIraiTblDataSet.KensaIraiTblDataTable iraiTemplate = new KensaIraiTblDataSet.KensaIraiTblDataTable();

                    IStdFilteredGetDataBLInput iraiBlInput = new StdFilteredGetDataBLInput();
                    iraiBlInput.DataTableType = typeof(KensaIraiTblDataSet.KensaIraiTblDataTable);
                    iraiBlInput.TableAdapterType = typeof(KensaIraiTblTableAdapter);

                    iraiBlInput.Query.AddEqualCond(iraiTemplate.KensaIraiJokasoHokenjoCdColumn.ColumnName, input.HokenjoCd);
                    iraiBlInput.Query.AddEqualCond(iraiTemplate.KensaIraiJokasoTorokuNendoColumn.ColumnName, input.TorokuNendo);
                    iraiBlInput.Query.AddEqualCond(iraiTemplate.KensaIraiJokasoRenbanColumn.ColumnName, input.Renban);

                    IStdFilteredGetDataBLOutput iraiBlOutput = new StdFilteredGetDataBusinessLogic().Execute(iraiBlInput);

                    if (iraiBlOutput.GetDataTable.Rows.Count > 0)
                    {
                        output.ErrMessage = "検査依頼が登録済のため、削除できません。";

                        return output;
                    }
                }

                #endregion

                #region delete from db

                IStdDeleteDataBLInput blInput = new StdDeleteDataBLInput();
                blInput.TableName = templateTableDaicho.TableName;
                blInput.KeyColNameList = keyColList;
                blInput.ValueList = keyValueList;

                IStdDeleteDataBLOutput blOutput = new StdDeleteDataBusinessLogic().Execute(blInput);

                // 削除された行が0行なら、存在しなかったといえる
                if (blOutput.RowCount == 0)
                {
                    output.ErrMessage = "該当するデータは登録されていません。"
                        + MessageUtility.FormatParamList(
                        new string[] { "保健所コード", "登録年度", "連番" }
                        , new object[] { input.HokenjoCd, input.TorokuNendo, input.Renban });

                    return output;
                }

                #endregion

                #region delete rireki tbl
                {
                    JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable templateTable = new JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable();

                    IStdDeleteDataBLInput deleteBlInput = new StdDeleteDataBLInput();
                    deleteBlInput.TableName = templateTable.TableName;
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoHokenjoCdColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoTorokuNendoColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoRenbanColumn.ColumnName);
                    deleteBlInput.ValueList = keyValueList;

                    IStdDeleteDataBLOutput deleteBlOutput = new StdDeleteDataBusinessLogic().Execute(deleteBlInput);

                    // don't care exists rireki count(may have no rireki(history))
                }
                #endregion

                #region delete jokaso hoyu tani sochi group tbl
                {
                    JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable templateTable = new JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable();

                    IStdDeleteDataBLInput deleteBlInput = new StdDeleteDataBLInput();
                    deleteBlInput.TableName = templateTable.TableName;
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoHokenjoCdColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoTorokuNendoColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoRenbanColumn.ColumnName);
                    deleteBlInput.ValueList = keyValueList;

                    IStdDeleteDataBLOutput deleteBlOutput = new StdDeleteDataBusinessLogic().Execute(deleteBlInput);
                }
                #endregion

                #region delete jokaso memo tbl
                {
                    JokasoMemoTblDataSet.JokasoMemoTblDataTable templateTable = new JokasoMemoTblDataSet.JokasoMemoTblDataTable();

                    IStdDeleteDataBLInput deleteBlInput = new StdDeleteDataBLInput();
                    deleteBlInput.TableName = templateTable.TableName;
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoMemoJokasoHokenjoCdColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoMemoJokasoTorokuNendoColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoMemoJokasoRenbanColumn.ColumnName);
                    deleteBlInput.ValueList = keyValueList;

                    IStdDeleteDataBLOutput deleteBlOutput = new StdDeleteDataBusinessLogic().Execute(deleteBlInput);
                }
                #endregion

                #region delete jokaso daicho kanren file tbl
                {
                    JokasoDiachoKanrenFileTblDataSet.JokasoDiachoKanrenFileTblDataTable templateTable = new JokasoDiachoKanrenFileTblDataSet.JokasoDiachoKanrenFileTblDataTable();

                    IStdDeleteDataBLInput deleteBlInput = new StdDeleteDataBLInput();
                    deleteBlInput.TableName = templateTable.TableName;
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoHokenjoCdColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoTorokuNendoColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoRenbanColumn.ColumnName);
                    deleteBlInput.ValueList = keyValueList;

                    IStdDeleteDataBLOutput deleteBlOutput = new StdDeleteDataBusinessLogic().Execute(deleteBlInput);
                }
                #endregion

                #region delete daicho suistsu kensa komoku tbl
                {
                    DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable templateTable = new DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable();

                    IStdDeleteDataBLInput deleteBlInput = new StdDeleteDataBLInput();
                    deleteBlInput.TableName = templateTable.TableName;
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoHokenjoCdColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoTorokuNendoColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoRenbanColumn.ColumnName);
                    deleteBlInput.ValueList = keyValueList;

                    IStdDeleteDataBLOutput deleteBlOutput = new StdDeleteDataBusinessLogic().Execute(deleteBlInput);
                }
                #endregion

                #region delete daicho suistsu kensa tankomoku tbl
                {
                    DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable templateTable = new DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable();

                    IStdDeleteDataBLInput deleteBlInput = new StdDeleteDataBLInput();
                    deleteBlInput.TableName = templateTable.TableName;
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoHokenjoCdColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoTorokuNendoColumn.ColumnName);
                    deleteBlInput.KeyColNameList.Add(templateTable.JokasoRenbanColumn.ColumnName);
                    deleteBlInput.ValueList = keyValueList;

                    IStdDeleteDataBLOutput deleteBlOutput = new StdDeleteDataBusinessLogic().Execute(deleteBlInput);
                }
                #endregion

                // TODO その他、関連するテーブルがあれば削除する

                CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
