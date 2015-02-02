using System.Data;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataAccess.MaeukekinTbl;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KensaIraiKanrenFileTblDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaIraiToroku7jo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/02　habu　　    新規作成
    /// 2015/01/30　小松　　    ７条依頼入力の編集可能対応
    /// 2015/01/31　小松　　    前受金５項目対応
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        string IraiRenban { get; set; }

        /// <summary>
        /// JokasoHokenjoCd
        /// </summary>
        string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoNendo
        /// </summary>
        string JokasoNendo { get; set; }

        /// <summary>
        /// JokasoRenban
        /// </summary>
        string JokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALInput
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
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IBseALInputImpl, IFormLoadALInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        public string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        public string IraiRenban { get; set; }

        /// <summary>
        /// JokasoHokenjoCd
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoNendo
        /// </summary>
        public string JokasoNendo { get; set; }

        /// <summary>
        /// JokasoRenban
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALOutput
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
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// EditDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable EditDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable FileDataTable { get; set; }

        /// <summary>
        /// EditDataTableDaicho
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable EditDataTableDaicho { get; set; }

        /// <summary>
        /// 前受金情報
        /// </summary>
        MaeukekinTblDataSet.MaeukekinTblDataTable MaeukekinDT { get; set; }
        
        /// <summary>
        /// 
        /// </summary>
        DataTable LockTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        DataTable DaichoLockTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALOutput
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
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// EditDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable EditDataTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable FileDataTable { get; set; }

        /// <summary>
        /// EditDataTableDaicho
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable EditDataTableDaicho { get; set; }

        /// <summary>
        /// 前受金情報
        /// </summary>
        public MaeukekinTblDataSet.MaeukekinTblDataTable MaeukekinDT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataTable LockTable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DataTable DaichoLockTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadApplicationLogic
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
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaIraiTorku7jo：FormLoad";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FormLoadApplicationLogic
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
        ////////////////////////////////////////////////////////////////////////////
        public FormLoadApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/02　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/09/02　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                string KENSA_IRAI_7JO = Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN;

                #region get edit data

                {
                    if (!string.IsNullOrEmpty(input.IraiHokenjoCd)
                        && !string.IsNullOrEmpty(input.IraiNendo)
                        && !string.IsNullOrEmpty(input.IraiRenban))
                    {
                        KensaIraiTblDataSet.KensaIraiTblDataTable templateTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

                        IStdFilteredGetDataBLInput blInput = new StdFilteredGetDataBLInput();
                        blInput.DataTableType = typeof(KensaIraiTblDataSet.KensaIraiTblDataTable);
                        blInput.TableAdapterType = typeof(KensaIraiTblTableAdapter);
                        // 法定区分は固定値を指定
                        blInput.Query.AddEqualCond(templateTable.KensaIraiHoteiKbnColumn.ColumnName, KENSA_IRAI_7JO);
                        blInput.Query.AddEqualCond(templateTable.KensaIraiHokenjoCdColumn.ColumnName, input.IraiHokenjoCd);
                        blInput.Query.AddEqualCond(templateTable.KensaIraiNendoColumn.ColumnName, input.IraiNendo);
                        blInput.Query.AddEqualCond(templateTable.KensaIraiRenbanColumn.ColumnName, input.IraiRenban);

                        IStdFilteredGetDataBLOutput blOutput = new StdFilteredGetDataBusinessLogic().Execute(blInput);

                        output.EditDataTable = (KensaIraiTblDataSet.KensaIraiTblDataTable)blOutput.GetDataTable;
                    }
                    else
                    {
                        output.EditDataTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                    }
                }

                {
                    if (!string.IsNullOrEmpty(input.IraiHokenjoCd)
                        && !string.IsNullOrEmpty(input.IraiNendo)
                        && !string.IsNullOrEmpty(input.IraiRenban))
                    {
                        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable fileTemplateTable = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();
                        IStdFilteredGetDataBLInput fileBlInput = new StdFilteredGetDataBLInput();
                        fileBlInput.DataTableType = typeof(KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable);
                        fileBlInput.TableAdapterType = typeof(KensaIraiKanrenFileTblTableAdapter);
                        // 法定区分は固定値を指定
                        fileBlInput.Query.AddEqualCond(fileTemplateTable.KensaIraiHoteiKbnColumn.ColumnName, KENSA_IRAI_7JO);
                        fileBlInput.Query.AddEqualCond(fileTemplateTable.KensaIraiHokenjoCdColumn.ColumnName, input.IraiHokenjoCd);
                        fileBlInput.Query.AddEqualCond(fileTemplateTable.KensaIraiNendoColumn.ColumnName, input.IraiNendo);
                        fileBlInput.Query.AddEqualCond(fileTemplateTable.KensaIraiRenbanColumn.ColumnName, input.IraiRenban);

                        IStdFilteredGetDataBLOutput fileBlOutput = new StdFilteredGetDataBusinessLogic().Execute(fileBlInput);

                        output.FileDataTable = (KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable)fileBlOutput.GetDataTable;
                    }
                    else
                    {
                        output.FileDataTable = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();
                    }
                }

                {
                    if (string.IsNullOrEmpty(input.IraiHokenjoCd)
                        || string.IsNullOrEmpty(input.IraiNendo)
                        || string.IsNullOrEmpty(input.IraiRenban))
                    {

                        JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable jokasoTemplateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable();
                        IStdFilteredGetDataBLInput blInput = new StdFilteredGetDataBLInput();
                        blInput.DataTableType = typeof(JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable);
                        blInput.TableAdapterType = typeof(JokasoDaichoMstListTableAdapter);
                        blInput.Query.AddEqualCond(jokasoTemplateTable.JokasoHokenjoCdColumn.ColumnName, input.JokasoHokenjoCd);
                        blInput.Query.AddEqualCond(jokasoTemplateTable.JokasoTorokuNendoColumn.ColumnName, input.JokasoNendo);
                        blInput.Query.AddEqualCond(jokasoTemplateTable.JokasoRenbanColumn.ColumnName, input.JokasoRenban);

                        IStdFilteredGetDataBLOutput blOutput = new StdFilteredGetDataBusinessLogic().Execute(blInput);

                        output.EditDataTableDaicho = (JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable)blOutput.GetDataTable;
                    }
                    else
                    {
                        // 検査依頼編集を行う場合は、検査依頼に設定済みの浄化槽台帳のキーから取得
                        //output.EditDataTableDaicho = new JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable();

                        JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable jokasoTemplateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable();
                        IStdFilteredGetDataBLInput blInput = new StdFilteredGetDataBLInput();
                        blInput.DataTableType = typeof(JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable);
                        blInput.TableAdapterType = typeof(JokasoDaichoMstListTableAdapter);
                        KensaIraiTblDataSet.KensaIraiTblRow iraiRow = (KensaIraiTblDataSet.KensaIraiTblRow)output.EditDataTable[0];
                        blInput.Query.AddEqualCond(jokasoTemplateTable.JokasoHokenjoCdColumn.ColumnName, iraiRow.KensaIraiJokasoHokenjoCd);
                        blInput.Query.AddEqualCond(jokasoTemplateTable.JokasoTorokuNendoColumn.ColumnName, iraiRow.KensaIraiJokasoTorokuNendo);
                        blInput.Query.AddEqualCond(jokasoTemplateTable.JokasoRenbanColumn.ColumnName, iraiRow.KensaIraiJokasoRenban);

                        IStdFilteredGetDataBLOutput blOutput = new StdFilteredGetDataBusinessLogic().Execute(blInput);

                        output.EditDataTableDaicho = (JokasoDaichoMstDataSet.JokasoDaichoMstListDataTable)blOutput.GetDataTable;
                    }
                }

                // 前受金情報
                {
                    if (!string.IsNullOrEmpty(input.IraiHokenjoCd)
                        && !string.IsNullOrEmpty(input.IraiNendo)
                        && !string.IsNullOrEmpty(input.IraiRenban))
                    {
                        // 検査依頼番号指定の場合は、編集モードなので既に登録済の前受金情報を取得

                        ISelectMaeukekinTblByKensaIraiKeyDAInput selIn = new SelectMaeukekinTblByKensaIraiKeyDAInput();
                        selIn.KensaIraiHoteiKbn = KENSA_IRAI_7JO;
                        selIn.KensaIraiHokenjoCd = input.IraiHokenjoCd;
                        selIn.KensaIraiNendo = input.IraiNendo;
                        selIn.KensaIraiRenban = input.IraiRenban;
                        ISelectMaeukekinTblByKensaIraiKeyDAOutput selOut = new SelectMaeukekinTblByKensaIraiKeyDataAccess().Execute(selIn);
                        output.MaeukekinDT = selOut.MaeukekinTblDataTable;
                    }
                    else
                    {
                        output.MaeukekinDT = new MaeukekinTblDataSet.MaeukekinTblDataTable();
                    }
                }

                #endregion

                #region get lock object

                {
                    if (!string.IsNullOrEmpty(input.IraiHokenjoCd)
                        && !string.IsNullOrEmpty(input.IraiNendo)
                        && !string.IsNullOrEmpty(input.IraiRenban))
                    {
                        KensaIraiTblDataSet.KensaIraiTblDataTable lockTemplateTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

                        IStdGetDataForUpdateBLInput lockBlInput = new StdGetDataForUpdateBLInput();
                        lockBlInput.TableName = lockTemplateTable.TableName;
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiHoteiKbnColumn.ColumnName);
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiHokenjoCdColumn.ColumnName);
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiNendoColumn.ColumnName);
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiRenbanColumn.ColumnName);
                        lockBlInput.SelColNameList = lockBlInput.WhereColNameList;
                        // 法定区分は固定値を指定
                        lockBlInput.ValueList.Add(KENSA_IRAI_7JO);
                        lockBlInput.ValueList.Add(input.IraiHokenjoCd);
                        lockBlInput.ValueList.Add(input.IraiNendo);
                        lockBlInput.ValueList.Add(input.IraiRenban);
                        IStdGetDataForUpdateBLOutput lockBlOutput = new StdGetDataForUpdateBusinessLogic().Execute(lockBlInput);

                        output.LockTable = lockBlOutput.SelectDataTable;
                    }
                }

                {
                    // 検査依頼が登録済みの場合は検査依頼から、未登録の場合は引数の浄化槽キーから取得する

                    if (string.IsNullOrEmpty(input.IraiHokenjoCd)
                        || string.IsNullOrEmpty(input.IraiNendo)
                        || string.IsNullOrEmpty(input.IraiRenban))
                    {
                        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable lockTemplateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

                        IStdGetDataForUpdateBLInput lockBlInput = new StdGetDataForUpdateBLInput();
                        lockBlInput.TableName = lockTemplateTable.TableName;
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.JokasoHokenjoCdColumn.ColumnName);
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.JokasoTorokuNendoColumn.ColumnName);
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.JokasoRenbanColumn.ColumnName);
                        lockBlInput.SelColNameList = lockBlInput.WhereColNameList;
                        // 法定区分は固定値を指定
                        lockBlInput.ValueList.Add(input.JokasoHokenjoCd);
                        lockBlInput.ValueList.Add(input.JokasoNendo);
                        lockBlInput.ValueList.Add(input.JokasoRenban);
                        IStdGetDataForUpdateBLOutput lockBlOutput = new StdGetDataForUpdateBusinessLogic().Execute(lockBlInput);

                        output.DaichoLockTable = lockBlOutput.SelectDataTable;
                    }
                    else
                    {
                        // 検査依頼編集を行う場合は、検査依頼に設定済みの浄化槽台帳のキーから取得
                        
                        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable lockTemplateTable = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

                        IStdGetDataForUpdateBLInput lockBlInput = new StdGetDataForUpdateBLInput();
                        lockBlInput.TableName = lockTemplateTable.TableName;
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.JokasoHokenjoCdColumn.ColumnName);
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.JokasoTorokuNendoColumn.ColumnName);
                        lockBlInput.WhereColNameList.Add(lockTemplateTable.JokasoRenbanColumn.ColumnName);
                        lockBlInput.SelColNameList = lockBlInput.WhereColNameList;
                        KensaIraiTblDataSet.KensaIraiTblRow iraiRow = (KensaIraiTblDataSet.KensaIraiTblRow)output.EditDataTable[0];
                        lockBlInput.ValueList.Add(iraiRow.KensaIraiJokasoHokenjoCd);
                        lockBlInput.ValueList.Add(iraiRow.KensaIraiJokasoTorokuNendo);
                        lockBlInput.ValueList.Add(iraiRow.KensaIraiJokasoRenban);
                        IStdGetDataForUpdateBLOutput lockBlOutput = new StdGetDataForUpdateBusinessLogic().Execute(lockBlInput);

                        output.DaichoLockTable = lockBlOutput.SelectDataTable;
                    }

                    #region to be removed
                    //KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable lockTemplateTable = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();

                    //IStdGetDataForUpdateBLInput lockBlInput = new StdGetDataForUpdateBLInput();
                    //lockBlInput.TableName = lockTemplateTable.TableName;
                    //lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiHoteiKbnColumn.ColumnName);
                    //lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiHokenjoCdColumn.ColumnName);
                    //lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiNendoColumn.ColumnName);
                    //lockBlInput.WhereColNameList.Add(lockTemplateTable.KensaIraiRenbanColumn.ColumnName);
                    //lockBlInput.SelColNameList = lockBlInput.WhereColNameList;
                    //// 法定区分は固定値を指定
                    //lockBlInput.ValueList.Add(KENSA_IRAI_7JO);
                    //lockBlInput.ValueList.Add(input.IraiHokenjoCd);
                    //lockBlInput.ValueList.Add(input.IraiNendo);
                    //lockBlInput.ValueList.Add(input.IraiRenban);
                    //IStdGetDataForUpdateBLOutput lockBlOutput = new StdGetDataForUpdateBusinessLogic().Execute(lockBlInput);

                    //output.DaichoLockTable = lockBlOutput.SelectDataTable;
                    #endregion
                }

                #endregion
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
