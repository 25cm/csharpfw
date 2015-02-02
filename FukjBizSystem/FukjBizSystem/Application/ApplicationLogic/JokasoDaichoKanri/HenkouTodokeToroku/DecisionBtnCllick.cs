using System.Collections.Generic;
using System.Data;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Common.DataAccess;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.HenkouTodokeToroku
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    interface IDecisionBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 更新データ
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable UpdateDataTable { get; set; }

        /// <summary>
        /// 楽観ロックオブジェクト
        /// </summary>
        DataTable LockDataTable { get; set; }
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    class DecisionBtnClickALInput : IBseALInputImpl, IDecisionBtnClickALInput
    {
        /// <summary>
        /// 更新データ
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstDataTable UpdateDataTable { get; set; }

        /// <summary>
        /// 楽観ロックオブジェクト
        /// </summary>
        public DataTable LockDataTable { get; set; }
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    interface IDecisionBtnClickALOutput
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    class DecisionBtnCllickALOutput : IDecisionBtnClickALOutput
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
    /// 2014/11/12　habu　　    新規作成
    /// </history>
    class DecisionBtnClickApplicationLogic : BaseApplicationLogic<IDecisionBtnClickALInput, IDecisionBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HenkouTodokeToroku：DecisionBtnCllick";

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
        /// 2014/11/12　habu　　    新規作成
        /// </history>
        public DecisionBtnClickApplicationLogic()
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
        /// 2014/11/12　habu　　    新規作成
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
        /// 2014/11/12　habu　　    新規作成
        /// </history>
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnCllickALOutput();

            try
            {
                StartTransaction();

                #region define key colmn and value

                List<string> keyColList = new List<string>();
                keyColList.Add(input.UpdateDataTable.JokasoHokenjoCdColumn.ColumnName);
                keyColList.Add(input.UpdateDataTable.JokasoTorokuNendoColumn.ColumnName);
                keyColList.Add(input.UpdateDataTable.JokasoRenbanColumn.ColumnName);

                List<object> keyValueList = new List<object>();
                keyValueList.Add(input.UpdateDataTable[0].JokasoHokenjoCd);
                keyValueList.Add(input.UpdateDataTable[0].JokasoTorokuNendo);
                keyValueList.Add(input.UpdateDataTable[0].JokasoRenban);

                #endregion

                #region get lock object(and exists object)

                IStdGetDataForUpdateBLInput lockBlInput = new StdGetDataForUpdateBLInput();
                lockBlInput.TableName = input.UpdateDataTable.TableName;
                lockBlInput.WhereColNameList = keyColList;
                lockBlInput.SelColNameList = keyColList;
                lockBlInput.ValueList = keyValueList;

                IStdGetDataForUpdateBLOutput lockBlOutput = new StdGetDataForUpdateBusinessLogic().Execute(lockBlInput);

                #endregion

                {
                    // check exist data
                    if (lockBlOutput.SelectDataTable.Rows.Count == 0)
                    {
                        output.ErrMessage = "該当するデータは登録されていません。" + MessageUtility.FormatParamList(
                            new string[] { "保健所コード", "登録年度", "連番" }
                            , new object[] { input.UpdateDataTable[0].JokasoHokenjoCd, input.UpdateDataTable[0].JokasoTorokuNendo, input.UpdateDataTable[0].JokasoRenban }
                            );

                        return output;
                    }
                    else
                    {
                        // check lock
                        if (!OptimisticLockUtility.CheckOptimisticLockTable(keyColList, input.LockDataTable, lockBlOutput.SelectDataTable))
                        {
                            throw new CustomException((int)ResultCode.LockError, string.Empty);
                        }
                    }
                }

                #region 浄化槽台帳履歴更新(Update JokasoDaichoRireki)

                // except new insert data, update rireki(history)
                if (input.UpdateDataTable[0].RowState != DataRowState.Added)
                {
                    // 浄化槽台帳更新ロジックを呼出
                    IUpdateJokasoDaichoRirekiBLInput rirekiBlInput = new UpdateJokasoDaichoRirekiBLInput();
                    rirekiBlInput.HokenjoCd = input.UpdateDataTable[0].JokasoHokenjoCd;
                    rirekiBlInput.TorokuNendo = input.UpdateDataTable[0].JokasoTorokuNendo;
                    rirekiBlInput.Renban = input.UpdateDataTable[0].JokasoRenban;

                    IUpdateJokasoDaichoRirekiBLOutput rirekiBlOutput = new UpdateJokasoDaichoRirekiBusinessLogic().Execute(rirekiBlInput);
                }

                #endregion

                #region update db

                IStdUpdateDataBLInput blInput = new StdUpdateDataBLInput();
                blInput.TableName = input.UpdateDataTable.TableName;
                blInput.TargetDataTable = input.UpdateDataTable;
                blInput.KeyColNameList = keyColList;

                IStdUpdateDataBLOutput blOutput = new StdUpdateDataBusinessLogic().Execute(blInput);

                #endregion

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
