using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri;
using FukjBizSystem.Application.BusinessLogic.Keiri.Common;
using FukjBizSystem.Application.BusinessLogic.KensaIraiKanri;
using FukjBizSystem.Application.DataAccess.MaeukekinTbl;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.MaeukekinTblDataSetTableAdapters;
using FukjBizSystem.Application.Utility;
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
    /// 2015/01/30　小松　　    ７条依頼入力の編集可能対応
    /// 2015/01/31　小松　　    前受金５項目対応
    /// </history>
    interface IDecisionBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 更新データ
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable UpdateDataTable { get; set; }

        /// <summary>
        /// 更新データ(検査依頼関連ファイル)
        /// </summary>
        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KanrenFileUpdateDataTable { get; set; }

        /// <summary>
        /// 更新データ(浄化槽台帳マスタ)
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstUpdateDataTable { get; set; }

        /// <summary>
        /// 楽観ロックオブジェクト
        /// </summary>
        DataTable LockDataTable { get; set; }

        /// <summary>
        /// 前受金照合番号1
        /// </summary>
        string MaeukekinSyogoNo1 { get; set; }

        /// <summary>
        /// 前受金照合番号2(1項目目)
        /// </summary>
        string MaeukekinSyogoNo21 { get; set; }
        /// <summary>
        /// 前受金照合番号2(2項目目)
        /// </summary>
        string MaeukekinSyogoNo22 { get; set; }
        /// <summary>
        /// 前受金照合番号2(3項目目)
        /// </summary>
        string MaeukekinSyogoNo23 { get; set; }
        /// <summary>
        /// 前受金照合番号2(4項目目)
        /// </summary>
        string MaeukekinSyogoNo24 { get; set; }
        /// <summary>
        /// 前受金照合番号2(5項目目)
        /// </summary>
        string MaeukekinSyogoNo25 { get; set; }

        /// <summary>
        /// 人槽
        /// </summary>
        int Ninsou { get; set; }

        /// <summary>
        /// 処理方式区分
        /// </summary>
        string ShoriHoshikiKbn { get; set; }
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
    class DecisionBtnClickALInput : IBseALInputImpl, IDecisionBtnClickALInput
    {
        /// <summary>
        /// 更新データ
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable UpdateDataTable { get; set; }

        /// <summary>
        /// 更新データ(検査依頼関連ファイル)
        /// </summary>
        public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KanrenFileUpdateDataTable { get; set; }

        /// <summary>
        /// 更新データ(浄化槽台帳マスタ)
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstUpdateDataTable { get; set; }

        /// <summary>
        /// 楽観ロックオブジェクト
        /// </summary>
        public DataTable LockDataTable { get; set; }

        /// <summary>
        /// 前受金照合番号1
        /// </summary>
        public string MaeukekinSyogoNo1 { get; set; }

        /// <summary>
        /// 前受金照合番号2(1項目目)
        /// </summary>
        public string MaeukekinSyogoNo21 { get; set; }
        /// <summary>
        /// 前受金照合番号2(2項目目)
        /// </summary>
        public string MaeukekinSyogoNo22 { get; set; }
        /// <summary>
        /// 前受金照合番号2(3項目目)
        /// </summary>
        public string MaeukekinSyogoNo23 { get; set; }
        /// <summary>
        /// 前受金照合番号2(4項目目)
        /// </summary>
        public string MaeukekinSyogoNo24 { get; set; }
        /// <summary>
        /// 前受金照合番号2(5項目目)
        /// </summary>
        public string MaeukekinSyogoNo25 { get; set; }

        /// <summary>
        /// 人槽
        /// </summary>
        public int Ninsou { get; set; }

        /// <summary>
        /// 処理方式区分
        /// </summary>
        public string ShoriHoshikiKbn { get; set; }
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
    /// 2014/09/02　habu　　    新規作成
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
    /// 2014/09/02　habu　　    新規作成
    /// </history>
    class DecisionBtnClickApplicationLogic : BaseApplicationLogic<IDecisionBtnClickALInput, IDecisionBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaIraiTorku7jo：DecisionBtnCllick";

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
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnCllickALOutput();

            try
            {
                DateTime nowDt = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();

                List<string> maeukekinSyogoNoList = new List<string>();
                if (!string.IsNullOrEmpty(input.MaeukekinSyogoNo21))
                {
                    maeukekinSyogoNoList.Add(input.MaeukekinSyogoNo21);
                }
                if (!string.IsNullOrEmpty(input.MaeukekinSyogoNo22))
                {
                    maeukekinSyogoNoList.Add(input.MaeukekinSyogoNo22);
                }
                if (!string.IsNullOrEmpty(input.MaeukekinSyogoNo23))
                {
                    maeukekinSyogoNoList.Add(input.MaeukekinSyogoNo23);
                }
                if (!string.IsNullOrEmpty(input.MaeukekinSyogoNo24))
                {
                    maeukekinSyogoNoList.Add(input.MaeukekinSyogoNo24);
                }
                if (!string.IsNullOrEmpty(input.MaeukekinSyogoNo25))
                {
                    maeukekinSyogoNoList.Add(input.MaeukekinSyogoNo25);
                }

                StartTransaction();

                #region define key colmn and value

                List<string> keyColList = new List<string>();
                keyColList.Add(input.UpdateDataTable.KensaIraiHokenjoCdColumn.ColumnName);
                keyColList.Add(input.UpdateDataTable.KensaIraiNendoColumn.ColumnName);
                keyColList.Add(input.UpdateDataTable.KensaIraiRenbanColumn.ColumnName);

                List<object> keyValueList = new List<object>();
                keyValueList.Add(input.UpdateDataTable[0].KensaIraiHokenjoCd);
                keyValueList.Add(input.UpdateDataTable[0].KensaIraiNendo);
                keyValueList.Add(input.UpdateDataTable[0].KensaIraiRenban);

                List<string> keyColListFile = new List<string>();
                if (input.KanrenFileUpdateDataTable != null && input.KanrenFileUpdateDataTable.Rows.Count > 0)
                {
                    keyColListFile.Add(input.KanrenFileUpdateDataTable.KensaIraiHokenjoCdColumn.ColumnName);
                    keyColListFile.Add(input.KanrenFileUpdateDataTable.KensaIraiNendoColumn.ColumnName);
                    keyColListFile.Add(input.KanrenFileUpdateDataTable.KensaIraiRenbanColumn.ColumnName);
                    keyColListFile.Add(input.KanrenFileUpdateDataTable.KensaIraiFileShubetsuCdColumn.ColumnName);
                }

                List<string> keyColListMst = new List<string>();
                keyColListMst.Add(input.JokasoDaichoMstUpdateDataTable.JokasoHokenjoCdColumn.ColumnName);
                keyColListMst.Add(input.JokasoDaichoMstUpdateDataTable.JokasoTorokuNendoColumn.ColumnName);
                keyColListMst.Add(input.JokasoDaichoMstUpdateDataTable.JokasoRenbanColumn.ColumnName);

                #endregion

                #region get lock object(and exists object)

                IStdGetDataForUpdateBLInput lockBlInput = new StdGetDataForUpdateBLInput();
                lockBlInput.TableName = input.UpdateDataTable.TableName;
                lockBlInput.WhereColNameList = keyColList;
                lockBlInput.SelColNameList = keyColList;
                lockBlInput.ValueList = keyValueList;

                IStdGetDataForUpdateBLOutput lockBlOutput = new StdGetDataForUpdateBusinessLogic().Execute(lockBlInput);

                #endregion

                if (input.UpdateDataTable[0].RowState == DataRowState.Added)
                {
                    // check exist data
                    if (lockBlOutput.SelectDataTable.Rows.Count > 0)
                    {
                        output.ErrMessage = "既に登録済みです。" + MessageUtility.FormatParamList(
                            new string[] { "保健所コード", "依頼年度", "連番" }
                            , new object[] { input.UpdateDataTable[0].KensaIraiHokenjoCd, input.UpdateDataTable[0].KensaIraiNendo, input.UpdateDataTable[0].KensaIraiRenban }
                            );

                        return output;
                    }
                }
                else
                {
                    // check exist data
                    if (lockBlOutput.SelectDataTable.Rows.Count == 0)
                    {
                        output.ErrMessage = "該当するデータは登録されていません。" + MessageUtility.FormatParamList(
                            new string[] { "保健所コード", "依頼年度", "連番" }
                            , new object[] { input.UpdateDataTable[0].KensaIraiHokenjoCd, input.UpdateDataTable[0].KensaIraiNendo, input.UpdateDataTable[0].KensaIraiRenban }
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

                // DBデフォルト値設定
                DataAccessUtility.SetDefaultDBColumnValue(input.UpdateDataTable);
                DataAccessUtility.SetDefaultDBColumnValue(input.JokasoDaichoMstUpdateDataTable);
                if (input.KanrenFileUpdateDataTable != null && input.KanrenFileUpdateDataTable.Rows.Count > 0)
                {
                    DataAccessUtility.SetDefaultDBColumnValue(input.KanrenFileUpdateDataTable);
                }

                #region 浄化槽台帳履歴更新(Update JokasoDaichoRireki)

                // except new insert data, update rireki(history)
                if (input.UpdateDataTable[0].RowState != DataRowState.Added)
                {
                    // 浄化槽台帳更新ロジックを呼出
                    IUpdateJokasoDaichoRirekiBLInput rirekiBlInput = new UpdateJokasoDaichoRirekiBLInput();
                    rirekiBlInput.HokenjoCd = input.UpdateDataTable[0].KensaIraiJokasoHokenjoCd;
                    rirekiBlInput.TorokuNendo = input.UpdateDataTable[0].KensaIraiJokasoTorokuNendo;
                    rirekiBlInput.Renban = input.UpdateDataTable[0].KensaIraiJokasoRenban;

                    IUpdateJokasoDaichoRirekiBLOutput rirekiBlOutput = new UpdateJokasoDaichoRirekiBusinessLogic().Execute(rirekiBlInput);
                }

                #endregion

                // 後工程のデータ(検査結果など)をこの時点で予め作成する
                if (input.UpdateDataTable[0].RowState == DataRowState.Added)
                {
                    ICreateDefaultKensaKekkaBLInput kekkaInput = new CreateDefaultKensaKekkaBLInput();
                    kekkaInput.HoteiKbn = input.UpdateDataTable[0].KensaIraiHoteiKbn;
                    kekkaInput.HokenjoCd = input.UpdateDataTable[0].KensaIraiHokenjoCd;
                    kekkaInput.IraiNendo = input.UpdateDataTable[0].KensaIraiNendo;
                    kekkaInput.Renban = input.UpdateDataTable[0].KensaIraiRenban;

                    ICreateDefaultKensaKekkaBLOutput kekkaOutput = new CreateDefaultKensaKekkaBusinessLogic().Execute(kekkaInput);
                }

                #region 浄化槽保有単位装置登録

                // 新規登録時は、保有単位装置を初期登録する
                if (input.JokasoDaichoMstUpdateDataTable[0].RowState == DataRowState.Added)
                {
                    // デフォルト保有単位装置設定ロジックを呼出
                    ICreateDefaultDaichoTblBLInput rirekiBlInput = new CreateDefaultDaichoTblBLInput();
                    rirekiBlInput.HokenjoCd = input.UpdateDataTable[0].KensaIraiJokasoHokenjoCd;
                    rirekiBlInput.Nendo = input.UpdateDataTable[0].KensaIraiJokasoTorokuNendo;
                    rirekiBlInput.Renban = input.UpdateDataTable[0].KensaIraiJokasoRenban;

                    ICreateDefaultDaichoTblBLOutput rirekiBlOutput = new CreateDefaultDaichoTblBusinessLogic().Execute(rirekiBlInput);
                }

                #endregion

                #region set kensaRyokin

                // 法定検査料金マスタ取得(人槽から)
                HoteiKensaRyokinMstDataSet.HoteiKensaRyokinMstRow ryokinRow = Boundary.Common.Common.GetHoteiKensaRyokinMstByNinsou(input.Ninsou);

                decimal kensaRyokin = 0m;
                if (input.ShoriHoshikiKbn == Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU)
                {
                    kensaRyokin = ryokinRow.TandokuKingaku7Jo;
                }
                else
                {
                    kensaRyokin = ryokinRow.GappeiKingaku7Jo;
                }

                if (maeukekinSyogoNoList.Count > 0)
                {

                    MaeukekinTblDataSet.MaeukekinTblDataTable maeukeDT = new MaeukekinTblDataSet.MaeukekinTblDataTable();
                    decimal maeukekinNyukinAmtSum = 0;
                    foreach (string maeukekinSyogoNo in maeukekinSyogoNoList)
                    {
                        // 前受金情報を取得
                        MaeukekinTblDataSet.MaeukekinTblDataTable template = new MaeukekinTblDataSet.MaeukekinTblDataTable();
                        IStdFilteredGetDataBLInput getKeiriInput = new StdFilteredGetDataBLInput();
                        getKeiriInput.DataTableType = typeof(MaeukekinTblDataSet.MaeukekinTblDataTable);
                        getKeiriInput.TableAdapterType = typeof(MaeukekinTblTableAdapter);
                        getKeiriInput.Query.AddEqualCond(template.MaeukekinSyogoNo1Column.ColumnName, input.MaeukekinSyogoNo1);
                        getKeiriInput.Query.AddEqualCond(template.MaeukekinSyogoNo2Column.ColumnName, maeukekinSyogoNo);

                        IStdFilteredGetDataBLOutput getKeiriOuptut = new StdFilteredGetDataBusinessLogic().Execute(getKeiriInput);

                        // 前受金情報が取得できない場合
                        if (getKeiriOuptut.GetDataTable.Rows.Count == 0)
                        {
                            output.ErrMessage = "該当する前受金は登録されていません。" + MessageUtility.FormatParamList(
                                new string[] { "照合番号" }
                                , new object[] { maeukekinSyogoNo }
                                );

                            return output;
                        }
                        MaeukekinTblDataSet.MaeukekinTblDataTable nyukinTbl = (MaeukekinTblDataSet.MaeukekinTblDataTable)getKeiriOuptut.GetDataTable;
                        maeukeDT.ImportRow(nyukinTbl[0]);
                        maeukekinNyukinAmtSum += nyukinTbl[0].MaeukekinNyukinAmt;
                    }
                    // 直近の入力分を取得
                    DataRow[] rows = maeukeDT.Select(string.Empty, "MaeukekinNyukinDt desc");
                    MaeukekinTblDataSet.MaeukekinTblRow maeukeRow = (MaeukekinTblDataSet.MaeukekinTblRow)rows[0];

                    // 前受金情報を検査依頼に設定
                    {
                        // 入金方法
                        input.UpdateDataTable[0].KensaIraiNyukinHohoKbn = Utility.Constants.KensaIraiNyukinHohoConstant.NYUKIN_RYOSHU_ZUMI;
                        // 検査料金
                        input.UpdateDataTable[0].KensaIraiKensaAmt = kensaRyokin;
                        // 合計金額
                        input.UpdateDataTable[0].KensaIraiGokeiAmt = input.UpdateDataTable[0].KensaIraiKensaAmt;
                        // 入金済金額
                        input.UpdateDataTable[0].KensaIraiNyukinzumiAmt = maeukekinNyukinAmtSum;
                        // 請求額
                        input.UpdateDataTable[0].KensaIraiSeikyuAmt = input.UpdateDataTable[0].KensaIraiKensaAmt - input.UpdateDataTable[0].KensaIraiNyukinzumiAmt;

                        // 最終入金日
                        input.UpdateDataTable[0].KensaIraiSaishuNyukinNen = maeukeRow.MaeukekinNyukinDt.Substring(0, 4);
                        input.UpdateDataTable[0].KensaIraiSaishuNyukinTsuki = maeukeRow.MaeukekinNyukinDt.Substring(4, 2);
                        input.UpdateDataTable[0].KensaIraiSaishuNyukinBi = maeukeRow.MaeukekinNyukinDt.Substring(6, 2);

                        if (input.UpdateDataTable[0].KensaIraiSeikyuAmt == 0)
                        {
                            // 入金完了
                            input.UpdateDataTable[0].KensaIraiNyukinKanryoKbn = Utility.Constants.KensaIraiNyukinKanryoConstant.NYUKIN_DONE;
                        }
                        else
                        {
                            // 入金未完了
                            input.UpdateDataTable[0].KensaIraiNyukinKanryoKbn = Utility.Constants.KensaIraiNyukinKanryoConstant.NYUKIN_NONE;
                        }
                    }
                }
                else
                {
                    // 入金方法                   
                    // TODO 一括請求業者で良いか?
                    string seikyuGyosya = input.JokasoDaichoMstUpdateDataTable[0].JokasoItkatsuSeikyuGyoshaCd;
                    if (string.IsNullOrEmpty(seikyuGyosya))
                    {
                        input.UpdateDataTable[0].KensaIraiNyukinHohoKbn = Utility.Constants.KensaIraiNyukinHohoConstant.NYUKIN_SEIKYU;
                    }
                    else
                    {
                        input.UpdateDataTable[0].KensaIraiNyukinHohoKbn = Utility.Constants.KensaIraiNyukinHohoConstant.NYUKIN_SEIKYU_ITKATSU;
                    }
                    // 検査料金
                    input.UpdateDataTable[0].KensaIraiKensaAmt = kensaRyokin;
                    // 合計金額
                    input.UpdateDataTable[0].KensaIraiGokeiAmt = input.UpdateDataTable[0].KensaIraiKensaAmt;
                    // 入金済金額
                    input.UpdateDataTable[0].KensaIraiNyukinzumiAmt = 0;
                    // 請求額
                    input.UpdateDataTable[0].KensaIraiSeikyuAmt = input.UpdateDataTable[0].KensaIraiKensaAmt;
                    // 入金未完了
                    input.UpdateDataTable[0].KensaIraiNyukinKanryoKbn = Utility.Constants.KensaIraiNyukinKanryoConstant.NYUKIN_NONE;
                }
                #endregion

                #region update db

                // 検査依頼
                {
                    IStdUpdateDataBLInput blInput = new StdUpdateDataBLInput();
                    blInput.TableName = input.UpdateDataTable.TableName;
                    blInput.TargetDataTable = input.UpdateDataTable;
                    blInput.KeyColNameList = keyColList;

                    IStdUpdateDataBLOutput blOutput = new StdUpdateDataBusinessLogic().Execute(blInput);
                }
                // 浄化槽台帳マスタ
                {
                    IStdUpdateDataBLInput blInput = new StdUpdateDataBLInput();
                    blInput.TableName = input.JokasoDaichoMstUpdateDataTable.TableName;
                    blInput.TargetDataTable = input.JokasoDaichoMstUpdateDataTable;
                    blInput.KeyColNameList = keyColListMst;

                    IStdUpdateDataBLOutput blOutput = new StdUpdateDataBusinessLogic().Execute(blInput);
                }
                // 検査依頼関連ファイル
                if (input.KanrenFileUpdateDataTable != null && input.KanrenFileUpdateDataTable.Rows.Count > 0)
                {
                    IStdUpdateDataBLInput blInput = new StdUpdateDataBLInput();
                    blInput.TableName = input.KanrenFileUpdateDataTable.TableName;
                    blInput.TargetDataTable = input.KanrenFileUpdateDataTable;
                    blInput.KeyColNameList = keyColListFile;

                    IStdUpdateDataBLOutput blOutput = new StdUpdateDataBusinessLogic().Execute(blInput);
                }

                #endregion

                #region update MaeukekinTbl

                // 一旦解除
                {
                    ISelectMaeukekinTblByKensaIraiKeyDAInput selIn = new SelectMaeukekinTblByKensaIraiKeyDAInput();
                    selIn.KensaIraiHoteiKbn = input.UpdateDataTable[0].KensaIraiHoteiKbn;
                    selIn.KensaIraiHokenjoCd = input.UpdateDataTable[0].KensaIraiHokenjoCd;
                    selIn.KensaIraiNendo = input.UpdateDataTable[0].KensaIraiNendo;
                    selIn.KensaIraiRenban = input.UpdateDataTable[0].KensaIraiRenban;
                    ISelectMaeukekinTblByKensaIraiKeyDAOutput selOut = new SelectMaeukekinTblByKensaIraiKeyDataAccess().Execute(selIn);
                    // 前受金の更新
                    MaeukekinTblDataSet.MaeukekinTblDataTable updMaeukeDT = selOut.MaeukekinTblDataTable;
                    foreach (MaeukekinTblDataSet.MaeukekinTblRow maeukeRow in selOut.MaeukekinTblDataTable)
                    {
                        maeukeRow.MaeukekinKensaIraiHoteiKbn = string.Empty;
                        maeukeRow.MaeukekinKensaIraiHokenjoCd = string.Empty;
                        maeukeRow.MaeukekinKensaIraiNendo = string.Empty;
                        maeukeRow.MaeukekinKensaIraiRenban = string.Empty;
                        maeukeRow.UpdateDt = nowDt;
                        maeukeRow.UpdateUser = loginUser;
                        maeukeRow.UpdateTarm = pcUpdate;
                    }
                    if (updMaeukeDT.Rows.Count > 0)
                    {
                        IUpdateMaeukekinTblDAInput updIn = new UpdateMaeukekinTblDAInput();
                        updIn.MaeukekinTblDT = updMaeukeDT;
                        new UpdateMaeukekinTblDataAccess().Execute(updIn);
                    }
                }

                // 前受金の更新
                foreach (string maeukekinSyogoNo in maeukekinSyogoNoList)
                {
                    IUpdateMaeukekinTblForKensaIraiBLInput keiriInput = new UpdateMaeukekinTblForKensaIraiBLInput();
                    keiriInput.KensaIraiHoteiKbn = input.UpdateDataTable[0].KensaIraiHoteiKbn;
                    keiriInput.KensaIraiHokenjoCd = input.UpdateDataTable[0].KensaIraiHokenjoCd;
                    keiriInput.KensaIraiNendo = input.UpdateDataTable[0].KensaIraiNendo;
                    keiriInput.KensaIraiRenban = input.UpdateDataTable[0].KensaIraiRenban;

                    keiriInput.MaeukekinSyogoNo1 = input.MaeukekinSyogoNo1;
                    keiriInput.MaeukekinSyogoNo2 = maeukekinSyogoNo;

                    try
                    {
                        IUpdateMaeukekinTblForKensaIraiBLOutput keiriOutput = new UpdateMaeukekinTblForKensaIraiBusinessLogic().Execute(keiriInput);
                    }
                    catch (CustomException ce)
                    {
                        // 前受金テーブルが未登録の場合は、エラーとする
                        // 前受金が既に他の検査依頼と紐付け済の場合は、エラーとする
                        output.ErrMessage = ce.Message;

                        return output;
                    }
                }

                #endregion

                // トランザクション完了前に呼び出す必要がある
                string destPath = SharedFolderUtility.GetKensaIraiKeyFolder(
                    Constants.ConstKbnConstanst.CONST_KBN_074, Constants.ConstRenbanConstanst.CONST_RENBAN_001
                    , input.UpdateDataTable[0].KensaIraiHoteiKbn
                    , input.UpdateDataTable[0].KensaIraiHokenjoCd
                    , input.UpdateDataTable[0].KensaIraiNendo
                    , input.UpdateDataTable[0].KensaIraiRenban
                    );

                #region 関連ファイル移動

                // サーバー接続開始
                if (!SharedFolderUtility.Connect())
                {
                    output.ErrMessage = "検査依頼書のサーバーへの保存に失敗しました。";

                    return output;
                }

                if (input.KanrenFileUpdateDataTable != null && input.KanrenFileUpdateDataTable.Rows.Count > 0)
                {
                    try
                    {
                        foreach (KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow fileRow in input.KanrenFileUpdateDataTable)
                        {
                            string kensaFileName =
                                string.Join("_"
                                , new string[] { fileRow.KensaIraiHoteiKbn, fileRow.KensaIraiHokenjoCd, fileRow.KensaIraiNendo, fileRow.KensaIraiRenban })
                                + ".pdf";

                            string kensaFilePath = Path.Combine(destPath, kensaFileName);

                            string srcPath = fileRow.KensaIraiKanrenFilePath;

                            fileRow.KensaIraiKanrenFilePath = kensaFilePath;

                            // ファイル移動実行
                            File.Move(srcPath, kensaFilePath);
                        }
                    }
                    finally
                    {
                        // サーバー接続終了
                        SharedFolderUtility.Disconnect();
                    }
                }

                CompleteTransaction();

                #endregion

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
