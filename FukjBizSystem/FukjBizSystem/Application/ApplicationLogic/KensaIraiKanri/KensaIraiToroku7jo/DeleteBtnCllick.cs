using System.Collections.Generic;
using System.Data;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Common.DataAccess;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaIraiToroku7jo
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
    interface IDeleteBtnCllickALInput : IBseALInput
    {
        /// <summary>
        /// 
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string IraiNendo { get; set; }

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
    /// 2014/09/02　habu　　    新規作成
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
        public string IraiNendo { get; set; }

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
    /// 2014/09/02　habu　　    新規作成
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
    /// 2014/09/02　habu　　    新規作成
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
    /// 2014/09/02　habu　　    新規作成
    /// </history>
    class DeleteBtnCllickApplicationLogic : BaseApplicationLogic<IDeleteBtnCllickALInput, IDeleteBtnCllickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaIraiTorku7jjo：DeleteBtnCllick";

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
        /// 2014/09/02　habu　　    新規作成
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
        /// 2014/09/02　habu　　    新規作成
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
        /// 2014/09/02　habu　　    新規作成
        /// </history>
        public override IDeleteBtnCllickALOutput Execute(IDeleteBtnCllickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnCllickALOutput output = new DeleteBtnCllickALOutput();

            try
            {
                string KENSA_IRAI_7JO = Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN;

                StartTransaction();

                #region define key colmn and value

                KensaIraiTblDataSet.KensaIraiTblDataTable templateTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

                List<string> keyColList = new List<string>();
                keyColList.Add(templateTable.KensaIraiHoteiKbnColumn.ColumnName);
                keyColList.Add(templateTable.KensaIraiHokenjoCdColumn.ColumnName);
                keyColList.Add(templateTable.KensaIraiNendoColumn.ColumnName);
                keyColList.Add(templateTable.KensaIraiRenbanColumn.ColumnName);

                List<object> keyValueList = new List<object>();
                keyValueList.Add(KENSA_IRAI_7JO);
                keyValueList.Add(input.HokenjoCd);
                keyValueList.Add(input.IraiNendo);
                keyValueList.Add(input.Renban);

                #endregion

                #region delete from db

                {
                    IStdDeleteDataBLInput blInput = new StdDeleteDataBLInput();
                    blInput.TableName = templateTable.TableName;
                    blInput.KeyColNameList = keyColList;
                    blInput.ValueList = keyValueList;

                    IStdDeleteDataBLOutput blOutput = new StdDeleteDataBusinessLogic().Execute(blInput);

                    if (blOutput.RowCount == 0)
                    {
                        output.ErrMessage = "該当するデータは登録されていません。"
                            + MessageUtility.FormatParamList(
                            new string[] { "保健所コード", "依頼年度", "連番" }
                            , new object[] { input.HokenjoCd, input.IraiNendo, input.Renban });

                        return output;
                    }
                }

                {
                    KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable fileTemplateTable = new KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();

                    IStdDeleteDataBLInput blInput = new StdDeleteDataBLInput();
                    blInput.TableName = fileTemplateTable.TableName;
                    blInput.KeyColNameList = keyColList;
                    blInput.ValueList = keyValueList;

                    IStdDeleteDataBLOutput blOutput = new StdDeleteDataBusinessLogic().Execute(blInput);

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
