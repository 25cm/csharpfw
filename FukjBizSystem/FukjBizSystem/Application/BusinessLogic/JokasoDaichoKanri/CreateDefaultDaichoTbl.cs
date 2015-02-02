using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Reflection;
using System.Text;
using FukjBizSystem.Application.DataAccess;
using FukjBizSystem.Application.DataAccess.Common;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.JokasoDaichiRirekiTblDataSetTableAdapters;
using FukjBizSystem.Application.Utility;
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
    /// 2015/01/08　habu　　    新規作成
    /// </history>
    interface ICreateDefaultDaichoTblBLInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        string Nendo { get; set; }

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
    /// 2015/01/08　habu　　    新規作成
    /// </history>
    class CreateDefaultDaichoTblBLInput : ICreateDefaultDaichoTblBLInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        public string Nendo { get; set; }

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
    /// 2015/01/08　habu　　    新規作成
    /// </history>
    interface ICreateDefaultDaichoTblBLOutput
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
    /// 2015/01/08　habu　　    新規作成
    /// </history>
    class CreateDefaultDaichoTblBLOutput : ICreateDefaultDaichoTblBLOutput
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
    /// 2015/01/08　habu　　    新規作成
    /// </history>
    class CreateDefaultDaichoTblBusinessLogic : BaseBusinessLogic<ICreateDefaultDaichoTblBLInput, ICreateDefaultDaichoTblBLOutput>
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
        /// 2015/01/08　habu　　    新規作成
        /// </history>
        public CreateDefaultDaichoTblBusinessLogic()
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
        /// 2015/01/08　habu　　    新規作成
        /// </history>
        public override ICreateDefaultDaichoTblBLOutput Execute(ICreateDefaultDaichoTblBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICreateDefaultDaichoTblBLOutput output = new CreateDefaultDaichoTblBLOutput();

            try
            {
                // 浄化槽台帳新規登録時に、デフォルトの保有単位装置を登録する

                // システム日時取得
                DateTime currentDt = FukjBizSystem.Application.Boundary.Common.Common.GetCurrentTimestamp();
                string user = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string term = Dns.GetHostName();

                // 浄化槽保有単位装置グループ
                {
                    JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable newTable = new JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable();

                    string[] sochiGrpCdList = new string[] { 
                        Utility.Constants.TaniSochiGroupCdConstant.JOKASO_DEFAULT_CD_TITLE,
                        Utility.Constants.TaniSochiGroupCdConstant.JOKASO_DEFAULT_CD_SHORISUI,
                        Utility.Constants.TaniSochiGroupCdConstant.JOKASO_DEFAULT_CD_SHORUI,
                        Utility.Constants.TaniSochiGroupCdConstant.JOKASO_DEFAULT_CD_GAIKAN_HOSOKU,
                        Utility.Constants.TaniSochiGroupCdConstant.JOKASO_DEFAULT_CD_SHUISHITSU_HOSOKU,
                        Utility.Constants.TaniSochiGroupCdConstant.JOKASO_DEFAULT_CD_SHORUI_HOSOKU,
                    };

                    foreach (string sochiGrpCd in sochiGrpCdList)
                    {
                        JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblRow newRow = newTable.NewJokasoHoyuTaniSochiGroupTblRow();

                        // デフォルト値を設定する
                        SetDefaultDBColumnValue(newTable, newRow, currentDt, user, term);

                        // 浄化槽台帳キーを設定
                        newRow.JokasoHokenjoCd = input.HokenjoCd;
                        newRow.JokasoTorokuNendo = input.Nendo;
                        newRow.JokasoRenban = input.Renban;
                        newRow.TaniSochiGroupCd = sochiGrpCd;

                        newTable.AddJokasoHoyuTaniSochiGroupTblRow(newRow);
                    }

                    IStdUpdateDataDAInput updateInput = new StdUpdateDataDAInput();
                    updateInput.TargetDataTable = newTable;
                    updateInput.TableName = newTable.TableName;
                    updateInput.KeyColNameList.Add(newTable.JokasoHokenjoCdColumn.ColumnName);
                    updateInput.KeyColNameList.Add(newTable.JokasoTorokuNendoColumn.ColumnName);
                    updateInput.KeyColNameList.Add(newTable.JokasoRenbanColumn.ColumnName);
                    updateInput.KeyColNameList.Add(newTable.TaniSochiGroupCdColumn.ColumnName);

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

        private void SetDefaultDBColumnValue(DataTable newTable, DataRow newRow, DateTime currentDt, string user, string term)
        {
            foreach (DataColumn col in newTable.Columns)
            {
                // framework既定のデフォルト値を設定
                Zynas.Framework.Core.Common.DataAccess.DataAccessUtility.SetDefaultDBColumnValue(newTable, newRow);
            }

            // 共通列設定(日時はシステム日時を使用する)
            newRow["InsertDt"] = currentDt;
            newRow["InsertUser"] = user;
            newRow["InsertTarm"] = term;
            newRow["UpdateDt"] = currentDt;
            newRow["UpdateUser"] = user;
            newRow["UpdateTarm"] = term;
        }

        #endregion

    }
    #endregion
}
