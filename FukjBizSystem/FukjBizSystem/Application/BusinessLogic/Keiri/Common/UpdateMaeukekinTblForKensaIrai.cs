using System;
using System.Data;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.MaeukekinTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Core.Generic.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.Common
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
    /// 2014/10/01  habu　　    新規作成
    /// </history>
    interface IUpdateMaeukekinTblForKensaIraiBLInput
    {
        /// <summary>
        /// 0:手動入力
        /// 1:自動採番
        /// </summary>
        string MaeukekinSyogoNo1 { get; set; }

        /// <summary>
        /// 前受金照合番号
        /// </summary>
        string MaeukekinSyogoNo2 { get; set; }

        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        string KensaIraiRenban { get; set; }
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
    /// 2014/10/01  habu　　    新規作成
    /// </history>
    class UpdateMaeukekinTblForKensaIraiBLInput : IUpdateMaeukekinTblForKensaIraiBLInput
    {
        /// <summary>
        /// 0:手動入力
        /// 1:自動採番
        /// </summary>
        public string MaeukekinSyogoNo1 { get; set; }

        /// <summary>
        /// 前受金照合番号
        /// </summary>
        public string MaeukekinSyogoNo2 { get; set; }

        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }
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
    /// 2014/10/01  habu　　    新規作成
    /// </history>
    interface IUpdateMaeukekinTblForKensaIraiBLOutput
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
    /// 2014/10/01  habu　　    新規作成
    /// </history>
    class UpdateMaeukekinTblForKensaIraiBLOutput : IUpdateMaeukekinTblForKensaIraiBLOutput
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
    /// 2014/10/01  habu　　    新規作成
    /// </history>
    class UpdateMaeukekinTblForKensaIraiBusinessLogic : BaseBusinessLogic<IUpdateMaeukekinTblForKensaIraiBLInput, IUpdateMaeukekinTblForKensaIraiBLOutput>
    {
        public enum ErrorCode
        {

        }

        #region コンストラクタ
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/01  habu　　    新規作成
        /// </history>
        public UpdateMaeukekinTblForKensaIraiBusinessLogic()
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
        /// 2014/10/01  habu　　    新規作成
        /// </history>
        public override IUpdateMaeukekinTblForKensaIraiBLOutput Execute(IUpdateMaeukekinTblForKensaIraiBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateMaeukekinTblForKensaIraiBLOutput output = new UpdateMaeukekinTblForKensaIraiBLOutput();

            try
            {
                DateTime nowDt = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();

                // 前受金照合番号から、前受金テーブルを取得する
                MaeukekinTblDataSet.MaeukekinTblDataTable templateTable = new MaeukekinTblDataSet.MaeukekinTblDataTable();
                IStdFilteredSelectDataDAInput getInput = new StdFilteredSelectDataDAInput();
                getInput.DataTableType = typeof(MaeukekinTblDataSet.MaeukekinTblDataTable);
                getInput.TableAdapterType = typeof(MaeukekinTblTableAdapter);
                getInput.Query.AddEqualCond(templateTable.MaeukekinSyogoNo1Column.ColumnName, input.MaeukekinSyogoNo1);
                getInput.Query.AddEqualCond(templateTable.MaeukekinSyogoNo2Column.ColumnName, input.MaeukekinSyogoNo2);

                IStdFilteredSelectDataDAOutput getOutput = new StdFilteredSelectDataDataAccess().Execute(getInput);

                // 前受金情報が未登録の場合はエラーとする
                if (getOutput.SelectDataTable.Rows.Count == 0)
                {
                    // Error
                    throw new CustomException(ResultCode.OperationError, 0, string.Format(
                        "前受金照合番号[{0}]は、未登録です。"
                        , input.MaeukekinSyogoNo2
                        ));
                    //return output;
                }

                DataRow selectedRow = getOutput.SelectDataTable.Rows[0];

                // 既に検査依頼情報が設定済みの場合は、エラーとする
                if (!selectedRow[templateTable.MaeukekinKensaIraiHokenjoCdColumn.ColumnName].Equals(string.Empty)
                    || !selectedRow[templateTable.MaeukekinKensaIraiHoteiKbnColumn.ColumnName].Equals(string.Empty)
                    || !selectedRow[templateTable.MaeukekinKensaIraiNendoColumn.ColumnName].Equals(string.Empty)
                    || !selectedRow[templateTable.MaeukekinKensaIraiRenbanColumn.ColumnName].Equals(string.Empty)
                   )
                {
                    // Error
                    throw new CustomException(ResultCode.OperationError, 1, string.Format(
                        "前受金照合番号[{4}]は、既に検査依頼[{0}-{1}-{2}-{3}]で使用されています。"
                        , (string)selectedRow[templateTable.MaeukekinKensaIraiHoteiKbnColumn.ColumnName]
                        , (string)selectedRow[templateTable.MaeukekinKensaIraiHokenjoCdColumn.ColumnName]
                        , (string)selectedRow[templateTable.MaeukekinKensaIraiNendoColumn.ColumnName]
                        , (string)selectedRow[templateTable.MaeukekinKensaIraiRenbanColumn.ColumnName]
                        , input.MaeukekinSyogoNo2
                        ));
                    //return output;
                }

                // 検査依頼情報を設定する
                selectedRow[templateTable.MaeukekinKensaIraiHokenjoCdColumn.ColumnName] = input.KensaIraiHokenjoCd;
                selectedRow[templateTable.MaeukekinKensaIraiHoteiKbnColumn.ColumnName] = input.KensaIraiHoteiKbn;
                selectedRow[templateTable.MaeukekinKensaIraiNendoColumn.ColumnName] = input.KensaIraiNendo;
                selectedRow[templateTable.MaeukekinKensaIraiRenbanColumn.ColumnName] = input.KensaIraiRenban;
                selectedRow[templateTable.UpdateDtColumn.ColumnName] = nowDt;
                selectedRow[templateTable.UpdateUserColumn.ColumnName] = loginUser;
                selectedRow[templateTable.UpdateTarmColumn.ColumnName] = pcUpdate;

                // テーブル更新実行
                IStdUpdateDataDAInput blInput = new StdUpdateDataDAInput();
                blInput.TableName = templateTable.TableName;
                blInput.TargetDataTable = getOutput.SelectDataTable;
                blInput.KeyColNameList.Add(templateTable.MaeukekinSyogoNo1Column.ColumnName);
                blInput.KeyColNameList.Add(templateTable.MaeukekinSyogoNo2Column.ColumnName);

                IStdUpdateDataDAOutput blOutput = new StdUpdateDataDataAccess().Execute(blInput);
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
