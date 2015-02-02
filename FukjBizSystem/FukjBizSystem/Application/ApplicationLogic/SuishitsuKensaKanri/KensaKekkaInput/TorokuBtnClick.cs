using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaKekkaInput;
using FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl;
using FukjBizSystem.Application.DataAccess.KensaDaicho9joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KensaKekkaInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorokuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorokuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// KensaKekkaInputSearch1DataTable
        /// </summary>
        KensaDaicho11joHdrTblDataSet.KensaKekkaInputSearch1DataTable KensaKekkaInputSearch1DataTable { get; set; }

        /// <summary>
        /// KensaKekkaInputSearch2DataTable
        /// </summary>
        KensaDaicho9joHdrTblDataSet.KensaKekkaInputSearch2DataTable KensaKekkaInputSearch2DataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorokuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorokuBtnClickALInput : ITorokuBtnClickALInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// KensaKekkaInputSearch1DataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.KensaKekkaInputSearch1DataTable KensaKekkaInputSearch1DataTable { get; set; }

        /// <summary>
        /// KensaKekkaInputSearch2DataTable
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KensaKekkaInputSearch2DataTable KensaKekkaInputSearch2DataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査区分[{0}], 依頼年度[{1}], 支所コード[{2}]",
                    KensaKbn, IraiNendo, ShishoCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorokuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorokuBtnClickALOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorokuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorokuBtnClickALOutput : ITorokuBtnClickALOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorokuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03　HieuNH　　　新規作成
    /// 2014/12/25　小松  　　　計量証明時も温度を登録（pH時）
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorokuBtnClickApplicationLogic : BaseApplicationLogic<ITorokuBtnClickALInput, ITorokuBtnClickALOutput>
    {
        #region プロパティ

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKekkaInput：TorokuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TorokuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TorokuBtnClickApplicationLogic()
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
        /// 2014/12/03　HieuNH　　　新規作成
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
        /// 2014/12/03　HieuNH　　　新規作成
        /// 2014/12/24　小松　　　　採用区分は更新対象外
        /// 2015/01/13  小松　　　　確認検査種別を判定し設定
        /// 2015/01/14  小松　　　　現状の仕様では更新のみ想定。追加処理はコメントアウト
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ITorokuBtnClickALOutput Execute(ITorokuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ITorokuBtnClickALOutput output = new TorokuBtnClickALOutput();

            try
            {
                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();

                try
                {
                    // トランザクション開始
                    StartTransaction();

                    KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable updateDataTable = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();

                    #region Insert/Update

                    if (!string.IsNullOrEmpty(input.KensaKbn) && (input.KensaKbn.Equals("2") || input.KensaKbn.Equals("3")))
                    {
                        // 法定検査（水質、外観）

                        // 法定検査時は、ヘッダの更新も有り（スクリーニング候補、クロスチェック関連）
                        KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable updateHdrDT = new KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable();

                        #region Loop KensaKekkaInputSearch1DataTable
                        for (int i = 0; i < input.KensaKekkaInputSearch1DataTable.Count; i++)
                        {
                            if (input.KensaKekkaInputSearch1DataTable[i].IsHoteiUpdateFlgNull() || input.KensaKekkaInputSearch1DataTable[i].HoteiUpdateFlg.Equals("0"))
                                continue;

                            // 検査台帳ヘッダ取得
                            ISelectKensaDaicho11joHdrTblByKeyDAInput kdhInput = new SelectKensaDaicho11joHdrTblByKeyDAInput();
                            kdhInput.KensaKbn = input.KensaKbn;
                            kdhInput.IraiNendo = input.IraiNendo;
                            kdhInput.ShishoCd = input.ShishoCd;
                            kdhInput.SuishitsuKensaIraiNo = input.KensaKekkaInputSearch1DataTable[i].SuishitsuKensaIraiNo;
                            ISelectKensaDaicho11joHdrTblByKeyDAOutput kdhOutput = new SelectKensaDaicho11joHdrTblByKeyDataAccess().Execute(kdhInput);
                            if (kdhOutput.KensaDaicho11joHdrDT.Rows.Count <= 0)
                            {
                                continue;
                            }

                            // Check Rakkan Lock
                            IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput kddtRakkanBLInput = new GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput();
                            kddtRakkanBLInput.IraiNendo = input.IraiNendo;
                            kddtRakkanBLInput.KensaKbn = input.KensaKbn;
                            kddtRakkanBLInput.ShishoCd = input.ShishoCd;
                            kddtRakkanBLInput.SuishitsuKensaIraiNo = input.KensaKekkaInputSearch1DataTable[i].SuishitsuKensaIraiNo;
                            kddtRakkanBLInput.SaikensaKbn = input.KensaKekkaInputSearch1DataTable[i].SaikensaKbnDisp;	// 受入20141218 既存か見るのは、画面で編集した方の再検査区分。
                            kddtRakkanBLInput.ShikenkoumokuCd = input.KensaKekkaInputSearch1DataTable[i].ShikenkoumokuCd;
                            IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput kddtRakkanBLOutput = new GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBusinessLogic().Execute(kddtRakkanBLInput);

                            // Do Search (3)
                            IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput kddtBLInput = new GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput();
                            kddtBLInput.IraiNendo = input.IraiNendo;
                            kddtBLInput.KensaKbn = input.KensaKbn;
                            kddtBLInput.ShishoCd = input.ShishoCd;
                            kddtBLInput.SuishitsuKensaIraiNo = input.KensaKekkaInputSearch1DataTable[i].SuishitsuKensaIraiNo;
                            kddtBLInput.SaikensaKbn = input.KensaKekkaInputSearch1DataTable[i].SaikensaKbnDisp;
                            kddtBLInput.ShikenkoumokuCd = input.KensaKekkaInputSearch1DataTable[i].ShikenkoumokuCd;
                            IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput kddtBLOutput = new GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBusinessLogic().Execute(kddtBLInput);

                            if (kddtBLOutput.KensaDaichoDtlTblDT.Count > 0)
                            {
                                // Update mode

                                // 受入20141218 楽観ロックチェックは、更新時のみ行う。
                                if (kddtRakkanBLOutput.KensaDaichoDtlTblDT[0].UpdateDt != input.KensaKekkaInputSearch1DataTable[i].UpdateDt)
                                {
                                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                                }

                                // 確認検査種別
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsu = string.Empty;
                                // 確認検査種別（BOD/透視度）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = "0";
                                // 確認検査種別（過去との比較）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = "0";
                                // 確認検査種別（BOD基準値オーバー）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuBodOver = "0";
                                // 確認検査種別（塩化物イオン確認検査）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuEnkaIon = "0";
                                // 確認検査種別（SS/透視度）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuSsTr = "0";
                                // 確認検査種別（アンモニア確認検査）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmonia = "0";
                                // 確認検査種別（アンモニアと全窒素比較）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmoniaTn = "0";
                                // 確認検査種別（COD基準値オーバー）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuCodOver = "0";
                                // 結果値
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = input.KensaKbn.Equals("1") ? 0 : (input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiKekkaValueNull() ? 0 : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiKekkaValue);
                                // 結果値２
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = input.KensaKbn.Equals("1") ? "0" : (input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiKekkaValue2Null() ? "0" : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiKekkaValue2);
                                // 結果コード
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaCd = input.KensaKbn.Equals("1") ? "0" : (input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiKekkaCdNull() ? "0" : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiKekkaCd);
                                // 温度数
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaOndo = input.KensaKbn.Equals("1") ? 0 : (input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiKekkaOndoNull() ? 0 : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiKekkaOndo);
                                // 結果入力
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaNyuryoku = "1";
                                // 外部委託フラグ
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiGaibuItakuFlg = input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiGaibuItakuFlgNull() ? "0" : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiGaibuItakuFlg;
                                //// 採用区分
                                //kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";

                                // 更新日
                                kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateDt = now;

                                // 更新者
                                kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateUser = loginUser;

                                // 更新端末
                                kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateTarm = pcUpdate;

                                // 確認検査種別を判定し設定
                                Utility.KakuninKensaUtility.SetKakuninKensaShubetsuForHoteiKensa(
                                    kdhOutput.KensaDaicho11joHdrDT[0],
                                    kddtBLOutput.KensaDaichoDtlTblDT[0],
                                    input.KensaKekkaInputSearch1DataTable[i].KensaKekkaIraiHoteiKbn,
                                    input.KensaKekkaInputSearch1DataTable[i].KensaKekkaIraiHokenjoCd,
                                    input.KensaKekkaInputSearch1DataTable[i].KensaKekkaIraiNendo,
                                    input.KensaKekkaInputSearch1DataTable[i].KensaKekkaIraiRenban,
                                    input.KensaKbn,
                                    input.IraiNendo,
                                    input.ShishoCd,
                                    input.KensaKekkaInputSearch1DataTable[i].SuishitsuKensaIraiNo,
                                    input.KensaKekkaInputSearch1DataTable[i].ShikenkoumokuCd,
                                    input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiKekkaValue);

                                updateDataTable.ImportRow(kddtBLOutput.KensaDaichoDtlTblDT[0]);
                            }
                            else
                            {
                                // 現在の仕様では更新のみ。
                                continue;

                                #region 追加処理は想定外
                                //// Insert mode
                                //KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow insertRow = updateDataTable.NewKensaDaichoDtlTblRow();

                                //// 検査区分
                                //insertRow.KensaKbn = input.KensaKbn;
                                //// 依頼年度
                                //insertRow.IraiNendo = input.IraiNendo;
                                //// 支所コード
                                //insertRow.ShishoCd = input.ShishoCd;
                                //// 水質検査依頼番号
                                //insertRow.SuishitsuKensaIraiNo = input.KensaKekkaInputSearch1DataTable[i].SuishitsuKensaIraiNo;
                                //// 試験項目コード
                                //insertRow.ShikenkoumokuCd = input.KensaKekkaInputSearch1DataTable[i].ShikenkoumokuCd;
                                //// 再検査回数
                                //insertRow.SaikensaKbn = input.KensaKekkaInputSearch1DataTable[i].SaikensaKbnDisp;	// 受入20141218 画面で編集した方の再検査区分を登録する。
                                //// 確認検査種別
                                //insertRow.KensaShubetsu = string.Empty;
                                //// 確認検査種別（BOD/透視度）
                                //insertRow.KensaShubetsuBodTr = "0";
                                //// 確認検査種別（過去との比較）
                                //insertRow.KensaShubetsuKako = "0";
                                //// 確認検査種別（BOD基準値オーバー）
                                //insertRow.KensaShubetsuBodOver = "0";
                                //// 確認検査種別（塩化物イオン確認検査）
                                //insertRow.KensaShubetsuEnkaIon = "0";
                                //// 確認検査種別（SS/透視度）
                                //insertRow.KensaShubetsuSsTr = "0";
                                //// 確認検査種別（アンモニア確認検査）
                                //insertRow.KensaShubetsuAnmonia = "0";
                                //// 確認検査種別（アンモニアと全窒素比較）
                                //insertRow.KensaShubetsuAnmoniaTn = "0";
                                //// 確認検査種別（COD基準値オーバー）
                                //insertRow.KensaShubetsuCodOver = "0";
                                //// 結果値
                                //insertRow.KeiryoShomeiKekkaValue = input.KensaKbn.Equals("1") ? 0 : (input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiKekkaValueNull() ? 0 : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiKekkaValue);
                                //// 結果値２
                                //insertRow.KeiryoShomeiKekkaValue2 = input.KensaKbn.Equals("1") ? "0" : (input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiKekkaValue2Null() ? "0" : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiKekkaValue2);
                                //// 結果コード
                                //insertRow.KeiryoShomeiKekkaCd = input.KensaKbn.Equals("1") ? "0" : (input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiKekkaCdNull() ? "0" : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiKekkaCd);
                                //// 温度数
                                //insertRow.KeiryoShomeiKekkaOndo = input.KensaKbn.Equals("1") ? 0 : (input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiKekkaOndoNull() ? 0 : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiKekkaOndo);
                                //// 結果入力
                                //insertRow.KeiryoShomeiKekkaNyuryoku = "1";
                                //// 外部委託フラグ
                                //insertRow.KeiryoShomeiGaibuItakuFlg = input.KensaKekkaInputSearch1DataTable[i].IsKeiryoShomeiGaibuItakuFlgNull() ? "0" : input.KensaKekkaInputSearch1DataTable[i].KeiryoShomeiGaibuItakuFlg;
                                //// 採用区分
                                //insertRow.KeiryoShomeiSaiyoKbn = "0";


                                //// 登録日時
                                //insertRow.InsertDt = now;
                                //// 登録者
                                //insertRow.InsertUser = loginUser;
                                //// 登録端末
                                //insertRow.InsertTarm = pcUpdate;
                                //// 更新日
                                //insertRow.UpdateDt = now;
                                //// 更新者
                                //insertRow.UpdateUser = loginUser;
                                //// 更新端末
                                //insertRow.UpdateTarm = pcUpdate;

                                //updateDataTable.AddKensaDaichoDtlTblRow(insertRow);
                                #endregion
                            }

                            // 検査台帳ヘッダ情報
                            // 更新日
                            kdhOutput.KensaDaicho11joHdrDT[0].UpdateDt = now;
                            // 更新者
                            kdhOutput.KensaDaicho11joHdrDT[0].UpdateUser = loginUser;
                            // 更新端末
                            kdhOutput.KensaDaicho11joHdrDT[0].UpdateTarm = pcUpdate;
                            updateHdrDT.ImportRow(kdhOutput.KensaDaicho11joHdrDT[0]);
                        }
                        #endregion

                        if (updateHdrDT.Rows.Count > 0)
                        {
                            // ヘッダ情報を更新
                            IUpdateKensaDaicho11joHdrTblDAInput updateHdrInput = new UpdateKensaDaicho11joHdrTblDAInput();
                            updateHdrInput.KensaDaicho11joHdrTblDataTable = updateHdrDT;
                            new UpdateKensaDaicho11joHdrTblDataAccess().Execute(updateHdrInput);
                        }
                    }
                    else
                    {
                        // 計量証明

                        // 計量証明時は、ヘッダの更新は無し
                        //KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable updateHdrDT = new KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable();

                        #region Loop KensaKekkaInputSearch2DataTable
                        for (int i = 0; i < input.KensaKekkaInputSearch2DataTable.Count; i++)
                        {
                            if (input.KensaKekkaInputSearch2DataTable[i].IsKeiryoUpdateFlgNull() || input.KensaKekkaInputSearch2DataTable[i].KeiryoUpdateFlg.Equals("0"))
                                continue;

                            // 検査台帳ヘッダ取得
                            ISelectKensaDaicho9joHdrTblByKeyDAInput kdhInput = new SelectKensaDaicho9joHdrTblByKeyDAInput();
                            kdhInput.IraiNendo = input.IraiNendo;
                            kdhInput.ShishoCd = input.ShishoCd;
                            kdhInput.SuishitsuKensaIraiNo = input.KensaKekkaInputSearch2DataTable[i].SuishitsuKensaIraiNo;
                            ISelectKensaDaicho9joHdrTblByKeyDAOutput kdhOutput = new SelectKensaDaicho9joHdrTblByKeyDataAccess().Execute(kdhInput);
                            if (kdhOutput.KensaDaicho9joHdrDT.Rows.Count <= 0)
                            {
                                continue;
                            }

                            // 受入20141218 計量証明の場合も楽観ロック用のレコードを取得する。
                            // Check Rakkan Lock
                            IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput kddtRakkanBLInput = new GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput();
                            kddtRakkanBLInput.IraiNendo = input.IraiNendo;
                            kddtRakkanBLInput.KensaKbn = input.KensaKbn;
                            kddtRakkanBLInput.ShishoCd = input.ShishoCd;
                            kddtRakkanBLInput.SuishitsuKensaIraiNo = input.KensaKekkaInputSearch2DataTable[i].SuishitsuKensaIraiNo;
                            kddtRakkanBLInput.SaikensaKbn = input.KensaKekkaInputSearch2DataTable[i].SaikensaKbnDisp;	// 受入20141218 既存か見るのは、画面で編集した方の再検査区分。
                            kddtRakkanBLInput.ShikenkoumokuCd = input.KensaKekkaInputSearch2DataTable[i].ShikenkoumokuCd;
                            IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput kddtRakkanBLOutput = new GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBusinessLogic().Execute(kddtRakkanBLInput);

                            // Do Search (3)
                            IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput kddtBLInput = new GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput();
                            kddtBLInput.IraiNendo = input.IraiNendo;
                            kddtBLInput.KensaKbn = input.KensaKbn;
                            kddtBLInput.ShishoCd = input.ShishoCd;
                            kddtBLInput.SuishitsuKensaIraiNo = input.KensaKekkaInputSearch2DataTable[i].SuishitsuKensaIraiNo;
                            kddtBLInput.SaikensaKbn = input.KensaKekkaInputSearch2DataTable[i].SaikensaKbnDisp;	// 受入20141218 既存か見るのは、画面で編集した方の再検査区分。
                            kddtBLInput.ShikenkoumokuCd = input.KensaKekkaInputSearch2DataTable[i].ShikenkoumokuCd;
                            IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput kddtBLOutput = new GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBusinessLogic().Execute(kddtBLInput);

                            if (kddtBLOutput.KensaDaichoDtlTblDT.Count > 0)
                            {
                                // Update mode

                                // Check Rakkan Lock
                                //if (kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateDt != input.KensaKekkaInputSearch2DataTable[i].UpdateDt)	// 受入20141218 楽観ロック用に取得したレコードと比較する。
                                if (kddtRakkanBLOutput.KensaDaichoDtlTblDT[0].UpdateDt != input.KensaKekkaInputSearch2DataTable[i].UpdateDt)
                                {
                                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                                }

                                // 確認検査種別
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsu = string.Empty;
                                // 確認検査種別（BOD/透視度）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = "0";
                                // 確認検査種別（過去との比較）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = "0";
                                // 確認検査種別（BOD基準値オーバー）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuBodOver = "0";
                                // 確認検査種別（塩化物イオン確認検査）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuEnkaIon = "0";
                                // 確認検査種別（SS/透視度）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuSsTr = "0";
                                // 確認検査種別（アンモニア確認検査）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmonia = "0";
                                // 確認検査種別（アンモニアと全窒素比較）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmoniaTn = "0";
                                // 確認検査種別（COD基準値オーバー）
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KensaShubetsuCodOver = "0";
                                // 結果値
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = input.KensaKekkaInputSearch2DataTable[i].IsKeiryoShomeiKekkaValueNull() ? 0 : input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiKekkaValue;
                                // 結果値２
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = "0";
                                // 結果コード
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaCd = input.KensaKekkaInputSearch2DataTable[i].IsKeiryoShomeiKekkaCdNull() ? "0" : input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiKekkaCd;
                                // 温度数
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaOndo = input.KensaKekkaInputSearch2DataTable[i].IsKeiryoShomeiKekkaOndoNull() ? 0 : input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiKekkaOndo;
                                // 結果入力
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaNyuryoku = "1";
                                // 外部委託フラグ
                                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiGaibuItakuFlg = input.KensaKekkaInputSearch2DataTable[i].IsKeiryoShomeiGaibuItakuFlgNull() ? "0" : input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiGaibuItakuFlg;
                                //// 採用区分
                                //kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";

                                // 更新日
                                kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateDt = now;

                                // 更新者
                                kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateUser = loginUser;

                                // 更新端末
                                kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateTarm = pcUpdate;

                                // 確認検査種別を判定し設定
                                Utility.KakuninKensaUtility.SetKakuninKensaShubetsuForKeiryoShomei(
                                    kdhOutput.KensaDaicho9joHdrDT[0],
                                    kddtBLOutput.KensaDaichoDtlTblDT[0],
                                    input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiIraiNendo,
                                    input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiIraiSishoCd,
                                    input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiIraiRenban,
                                    input.KensaKbn,
                                    input.IraiNendo,
                                    input.ShishoCd,
                                    input.KensaKekkaInputSearch2DataTable[i].SuishitsuKensaIraiNo,
                                    input.KensaKekkaInputSearch2DataTable[i].ShikenkoumokuCd,
                                    input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiKekkaValue);

                                updateDataTable.ImportRow(kddtBLOutput.KensaDaichoDtlTblDT[0]);
                            }
                            else
                            {
                                // 現在の仕様では更新のみ。
                                continue;

                                #region 追加処理は想定外
                                //// Insert mode
                                //KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow insertRow = updateDataTable.NewKensaDaichoDtlTblRow();

                                //// 検査区分
                                //insertRow.KensaKbn = input.KensaKbn;
                                //// 依頼年度
                                //insertRow.IraiNendo = input.IraiNendo;
                                //// 支所コード
                                //insertRow.ShishoCd = input.ShishoCd;
                                //// 水質検査依頼番号
                                //insertRow.SuishitsuKensaIraiNo = input.KensaKekkaInputSearch2DataTable[i].SuishitsuKensaIraiNo;
                                //// 試験項目コード
                                //insertRow.ShikenkoumokuCd = input.KensaKekkaInputSearch2DataTable[i].ShikenkoumokuCd;
                                //// 再検査回数
                                //insertRow.SaikensaKbn = input.KensaKekkaInputSearch2DataTable[i].SaikensaKbnDisp;	// 受入20141218 画面で編集した方の再検査区分を登録する。
                                //// 確認検査種別
                                //insertRow.KensaShubetsu = string.Empty;
                                //// 確認検査種別（BOD/透視度）
                                //insertRow.KensaShubetsuBodTr = "0";
                                //// 確認検査種別（過去との比較）
                                //insertRow.KensaShubetsuKako = "0";
                                //// 確認検査種別（BOD基準値オーバー）
                                //insertRow.KensaShubetsuBodOver = "0";
                                //// 確認検査種別（塩化物イオン確認検査）
                                //insertRow.KensaShubetsuEnkaIon = "0";
                                //// 確認検査種別（SS/透視度）
                                //insertRow.KensaShubetsuSsTr = "0";
                                //// 確認検査種別（アンモニア確認検査）
                                //insertRow.KensaShubetsuAnmonia = "0";
                                //// 確認検査種別（アンモニアと全窒素比較）
                                //insertRow.KensaShubetsuAnmoniaTn = "0";
                                //// 確認検査種別（COD基準値オーバー）
                                //insertRow.KensaShubetsuCodOver = "0";
                                //// 結果値
                                //insertRow.KeiryoShomeiKekkaValue = input.KensaKbn.Equals("1") ? 0 : (input.KensaKekkaInputSearch2DataTable[i].IsKeiryoShomeiKekkaValueNull() ? 0 : input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiKekkaValue);
                                //// 結果値２
                                //insertRow.KeiryoShomeiKekkaValue2 = input.KensaKbn.Equals("1") ? "0" : (input.KensaKekkaInputSearch2DataTable[i].IsKeiryoShomeiKekkaValue2Null() ? "0" : input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiKekkaValue2);
                                //// 結果コード
                                //insertRow.KeiryoShomeiKekkaCd = input.KensaKbn.Equals("1") ? "0" : (input.KensaKekkaInputSearch2DataTable[i].IsKeiryoShomeiKekkaCdNull() ? "0" : input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiKekkaCd);
                                //// 温度数
                                //insertRow.KeiryoShomeiKekkaOndo = input.KensaKekkaInputSearch2DataTable[i].IsKeiryoShomeiKekkaOndoNull() ? 0 : input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiKekkaOndo;
                                //// 結果入力
                                //insertRow.KeiryoShomeiKekkaNyuryoku = "1";
                                //// 外部委託フラグ
                                //insertRow.KeiryoShomeiGaibuItakuFlg = input.KensaKekkaInputSearch2DataTable[i].IsKeiryoShomeiGaibuItakuFlgNull() ? "0" : input.KensaKekkaInputSearch2DataTable[i].KeiryoShomeiGaibuItakuFlg;
                                //// 採用区分
                                //insertRow.KeiryoShomeiSaiyoKbn = "0";


                                //// 登録日時
                                //insertRow.InsertDt = now;
                                //// 登録者
                                //insertRow.InsertUser = loginUser;
                                //// 登録端末
                                //insertRow.InsertTarm = pcUpdate;
                                //// 更新日
                                //insertRow.UpdateDt = now;
                                //// 更新者
                                //insertRow.UpdateUser = loginUser;
                                //// 更新端末
                                //insertRow.UpdateTarm = pcUpdate;

                                //updateDataTable.AddKensaDaichoDtlTblRow(insertRow);
                                #endregion
                            }

                            //// 検査台帳ヘッダ情報
                            //// 更新日
                            //kdhOutput.KensaDaicho9joHdrDT[0].UpdateDt = now;
                            //// 更新者
                            //kdhOutput.KensaDaicho9joHdrDT[0].UpdateUser = loginUser;
                            //// 更新端末
                            //kdhOutput.KensaDaicho9joHdrDT[0].UpdateTarm = pcUpdate;
                            //updateHdrDT.ImportRow(kdhOutput.KensaDaicho9joHdrDT[0]);
                        }
                        #endregion

                        //if (updateHdrDT.Rows.Count > 0)
                        //{
                        //    // ヘッダ情報を更新
                        //    IUpdateKensaDaicho9joHdrTblDAInput updateHdrInput = new UpdateKensaDaicho9joHdrTblDAInput();
                        //    updateHdrInput.KensaDaicho9joHdrTblDataTable = updateHdrDT;
                        //    new UpdateKensaDaicho9joHdrTblDataAccess().Execute(updateHdrInput);
                        //}
                    }

                    IUpdateKensaDaichoDtlTblBLInput updateBLInput = new UpdateKensaDaichoDtlTblBLInput();
                    updateBLInput.KensaDaichoDtlTblDT = updateDataTable;
                    new UpdateKensaDaichoDtlTblBusinessLogic().Execute(updateBLInput);

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
