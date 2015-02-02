using System.Data;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanrenFileTblDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaYoteiWariate
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiUpdateData { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IBseALInputImpl, IDecisionBtnClickALInput
    {
        /// <summary>
        /// 
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiUpdateData { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALOutput : IDecisionBtnClickALOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/20　habu　　    新規作成
    /// 2015/02/01　habu　　    書類点検担当者を変更しないように修正
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickApplicationLogic : BaseApplicationLogic<IDecisionBtnClickALInput, IDecisionBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKeikaku：DecisionBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DecisionBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/20　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DecisionBtnClickApplicationLogic()
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
        /// 2014/12/20　habu　　    新規作成
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
        /// 2014/12/20　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnClickALOutput();

            try
            {
                StartTransaction();

                #region check lock object

                {
                    // TODO CheckExistsData
                }

                #endregion

                #region update edit data

                {
                    KensaIraiTblDataSet.KensaIraiTblDataTable templateTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

                    IStdUpdateDataBLInput blInput = new StdUpdateDataBLInput();
                    blInput.KeyColNameList.Add(templateTable.KensaIraiHoteiKbnColumn.ColumnName);
                    blInput.KeyColNameList.Add(templateTable.KensaIraiHokenjoCdColumn.ColumnName);
                    blInput.KeyColNameList.Add(templateTable.KensaIraiNendoColumn.ColumnName);
                    blInput.KeyColNameList.Add(templateTable.KensaIraiRenbanColumn.ColumnName);
                    blInput.TableName = templateTable.TableName;
                    blInput.TargetDataTable = input.KensaIraiUpdateData;

                    // 更新対象カラムを指定する
                    blInput.AddTargetColumn(templateTable.KensaIraiHoteiKbnColumn.ColumnName);
                    blInput.AddTargetColumn(templateTable.KensaIraiHokenjoCdColumn.ColumnName);
                    blInput.AddTargetColumn(templateTable.KensaIraiNendoColumn.ColumnName);
                    blInput.AddTargetColumn(templateTable.KensaIraiRenbanColumn.ColumnName);

                    blInput.AddTargetColumn(templateTable.KensaIraiStatusKbnColumn.ColumnName);

                    blInput.AddTargetColumn(templateTable.KensaIraiKensaYoteiNenColumn.ColumnName);
                    blInput.AddTargetColumn(templateTable.KensaIraiKensaYoteiTsukiColumn.ColumnName);
                    blInput.AddTargetColumn(templateTable.KensaIraiKensaYoteiBiColumn.ColumnName);

                    blInput.AddTargetColumn(templateTable.KensaIraiKensaTantoshaCdColumn.ColumnName);

                    blInput.AddTargetColumn(templateTable.UpdateDtColumn.ColumnName);
                    blInput.AddTargetColumn(templateTable.UpdateUserColumn.ColumnName);
                    blInput.AddTargetColumn(templateTable.UpdateTarmColumn.ColumnName);

                    IStdUpdateDataBLOutput blOutput = new StdUpdateDataBusinessLogic().Execute(blInput);
                }

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
