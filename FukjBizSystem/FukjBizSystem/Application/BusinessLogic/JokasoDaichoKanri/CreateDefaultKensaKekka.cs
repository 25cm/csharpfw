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
// TODO フォルダを移動する
namespace FukjBizSystem.Application.BusinessLogic.KensaIraiKanri
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
    interface ICreateDefaultKensaKekkaBLInput
    {
        /// <summary>
        /// HoteiKbn
        /// </summary>
        string HoteiKbn { get; set; }

        /// <summary>
        /// HokenjoCd
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// TorokuNengetsu
        /// </summary>
        string IraiNendo { get; set; }

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
    class CreateDefaultKensaKekkaBLInput : ICreateDefaultKensaKekkaBLInput
    {
        /// <summary>
        /// HoteiKbn
        /// </summary>
        public string HoteiKbn { get; set; }

        /// <summary>
        /// HokenjoCd
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// TorokuNengetsu
        /// </summary>
        public string IraiNendo { get; set; }

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
    interface ICreateDefaultKensaKekkaBLOutput
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
    class CreateDefaultKensaKekkaBLOutput : ICreateDefaultKensaKekkaBLOutput
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
    class CreateDefaultKensaKekkaBusinessLogic : BaseBusinessLogic<ICreateDefaultKensaKekkaBLInput, ICreateDefaultKensaKekkaBLOutput>
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
        public CreateDefaultKensaKekkaBusinessLogic()
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
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// </history>
        public override ICreateDefaultKensaKekkaBLOutput Execute(ICreateDefaultKensaKekkaBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICreateDefaultKensaKekkaBLOutput output = new CreateDefaultKensaKekkaBLOutput();

            try
            {
                // 検査依頼登録時に、デフォルト(ダミー)の検査結果を登録する

                // システム日時取得
                DateTime currentDt = FukjBizSystem.Application.Boundary.Common.Common.GetCurrentTimestamp();
                string user = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string term = Dns.GetHostName();

                // 検査結果
                {
                    KensaKekkaTblDataSet.KensaKekkaTblDataTable newTable = new KensaKekkaTblDataSet.KensaKekkaTblDataTable();

                    KensaKekkaTblDataSet.KensaKekkaTblRow newRow = newTable.NewKensaKekkaTblRow();

                    // デフォルト値を設定する
                    SetDefaultDBColumnValue(newTable, newRow, currentDt, user, term);

                    // 検査依頼キーを設定
                    newRow.KensaKekkaIraiHoteiKbn = input.HoteiKbn;
                    newRow.KensaKekkaIraiHokenjoCd = input.HokenjoCd;
                    newRow.KensaKekkaIraiNendo = input.IraiNendo;
                    newRow.KensaKekkaIraiRenban = input.Renban;

                    // 結果値は未入力(初期値)はNULL
                    // 水素イオン濃度
                    newRow.SetKensaKekkaSuisoIonNodoNull();
                    // 汚泥沈殿率
                    newRow.SetKensaKekkaOdeiChindenritsuNull();
                    // 溶存酸素量１
                    newRow.SetKensaKekkaYozonSansoryo1Null();
                    // 溶存酸素量２
                    newRow.SetKensaKekkaYozonSansoryo2Null();
                    // 亜硝酸性窒素
                    newRow.SetKensaKekkaAsyosanseiChissoNull();
                    // 透視度
                    newRow.SetKensaKekkaToshidoNull();
                    // 透視度２次処理水
                    newRow.SetKensaKekkaToshido2jiSyorisuiNull();
                    // 塩素イオン濃度
                    newRow.SetKensaKekkaEnsoIonNodoNull();
                    // 残留塩素濃度
                    newRow.SetKensaKekkaZanryuEnsoNodoNull();
                    // 生物化学酸素要求量
                    newRow.SetKensaKekkaBODNull();
                    // ＭＬＳＳ
                    newRow.SetKensaKekkaMLSSNull();
                    // ATUBOD
                    newRow.SetKensaKekkaATUBODNull();

                    newTable.AddKensaKekkaTblRow(newRow);

                    IStdUpdateDataDAInput updateInput = new StdUpdateDataDAInput();
                    updateInput.TargetDataTable = newTable;
                    updateInput.TableName = newTable.TableName;
                    updateInput.KeyColNameList.Add(newTable.KensaKekkaIraiHoteiKbnColumn.ColumnName);
                    updateInput.KeyColNameList.Add(newTable.KensaKekkaIraiHokenjoCdColumn.ColumnName);
                    updateInput.KeyColNameList.Add(newTable.KensaKekkaIraiNendoColumn.ColumnName);
                    updateInput.KeyColNameList.Add(newTable.KensaKekkaIraiRenbanColumn.ColumnName);

                    IStdUpdateDataDAOutput updateOutput = new StdUpdateDataDataAccess().Execute(updateInput);
                }

                // TODO 他のテーブルの登録も必要な場合は追加する

                // 検査台帳ヘッダ
                // 検査台帳明細
                // 所見結果
                // 再採水
                // 現場写真
                // 現場写真
                // 日報ヘッダ
                // 日報明細
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
