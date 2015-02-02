using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaKomokuMst;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl;
using FukjBizSystem.Application.DataAccess.KensaDaichoDtlTbl;
using FukjBizSystem.Application.DataAccess.KensaKekkaTbl;
using FukjBizSystem.Application.DataAccess.SaiSaisuiTbl;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 水質検査区分(1:計量証明/2:水質検査/3:外観検査)
        /// </summary>
        string SuishitsuKensaKbn { get; set; }

        /// <summary>
        /// 画面モード(2:登録(INSERT)/3:更新(UPDATE))
        /// </summary>
        string GamenMode { get; set; }

        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// 受付日(YYYYMMDD)
        /// </summary>
        string KensaIraiUketsukeDt { get; set; }

        /// <summary>
        /// 取込結果一覧データ
        /// </summary>
        SuishitsuKensaIraiDataSet.UketsukeImportListDataTable UketsukeImportListDT { get; set; }

        /// <summary>
        /// ListKeyDelete
        /// </summary>
        List<string> ListKeyDelete { get; set; }


    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALInput : IKakuteiBtnClickALInput
    {
        /// <summary>
        /// 水質検査区分(1:計量証明/2:水質/3:外観)
        /// </summary>
        public string SuishitsuKensaKbn { get; set; }

        /// <summary>
        /// 画面モード(2:登録(INSERT)/3:更新(UPDATE))
        /// </summary>
        public string GamenMode { get; set; }

        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 受付日(YYYYMMDD)
        /// </summary>
        public string KensaIraiUketsukeDt { get; set; }

        /// <summary>
        /// 取込結果一覧データ
        /// </summary>
        public SuishitsuKensaIraiDataSet.UketsukeImportListDataTable UketsukeImportListDT { get; set; }

        /// <summary>
        /// ListKeyDelete
        /// </summary>
        public List<string> ListKeyDelete { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("水質検査区分[{0}], 画面モード[{1}], 依頼年度[{2}], 支所コード[{3}], 受付日[{4}]", SuishitsuKensaKbn, GamenMode, IraiNendo, ShishoCd, KensaIraiUketsukeDt);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALOutput : IKakuteiBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickApplicationLogic : BaseApplicationLogic<IKakuteiBtnClickALInput, IKakuteiBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaIraiUketsukeList：KakuteiBtnClick";

        // 内部変数
        private DateTime _currentDateTime;
        private string _loginUser;
        private string _tarmName;
        private string _nowDtStr;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KakuteiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KakuteiBtnClickApplicationLogic()
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
        /// 2014/12/02　小松　　    新規作成
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
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuteiBtnClickALOutput Execute(IKakuteiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuteiBtnClickALOutput output = new KakuteiBtnClickALOutput();

            try
            {
                _currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
                _loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                _tarmName = Dns.GetHostName();
                // 文字列形式の当日を取得
                _nowDtStr = _currentDateTime.ToString("yyyyMMdd");

                // トランザクション開始
                StartTransaction();

                if (input.SuishitsuKensaKbn == "1")
                {
                    // 計量証明
                    if (input.GamenMode == "2")
                    {
                        // 登録
                        InsertDataKeiryoShomei(input);
                    }
                    else if (input.GamenMode == "3")
                    {
                        // 更新
                        UpdateDataKeiryoShomei(input);
                    }
                }
                else if (input.SuishitsuKensaKbn == "2")
                {
                    // 水質検査
                    if (input.GamenMode == "2")
                    {
                        // 登録
                        InsertDataSuishitsuKensa(input);
                    }
                    else if (input.GamenMode == "3")
                    {
                        // 更新
                        UpdateDataSuishitsuKensa(input);
                    }
                }
                else
                {
                    // 外観検査
                    if (input.GamenMode == "2")
                    {
                        // 登録
                        InsertDataGaikanKensa(input);
                    }
                    else if (input.GamenMode == "3")
                    {
                        // 更新
                        UpdateDataGaikanKensa(input);
                    }
                }

                // コミット
                CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                // トランザクション終了
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #region CheckSuishitsuMaster
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckSuishitsuMaster
        /// <summary>
        /// 検査依頼に関連付いている処理方式別水質検査実施マスタが正しく設定されているか確認
        /// </summary>
        /// <param name="kensaIraiHoteiKbn">検査依頼法定区分</param>
        /// <param name="kensaIraiHokenjoCd">検査依頼保健所CD</param>
        /// <param name="kensaIraiNendo">検査依頼年度</param>
        /// <param name="kensaIraiRenban">検査依頼連番</param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/08　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool CheckSuishitsuMaster(string kensaIraiHoteiKbn, string kensaIraiHokenjoCd, string kensaIraiNendo, string kensaIraiRenban)
        {
            // 処理方式別水質検査実施マスタの情報を取得する
            // データ検索⑫
            ISelectSuishitsuKensaJisshiKomokuInfoDAInput selIn = new SelectSuishitsuKensaJisshiKomokuInfoDAInput();
            selIn.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
            selIn.KensaIraiHokenjoCd = kensaIraiHokenjoCd;
            selIn.KensaIraiNendo = kensaIraiNendo;
            selIn.KensaIraiRenban = kensaIraiRenban;
            ISelectSuishitsuKensaJisshiKomokuInfoDAOutput selOut = new SelectSuishitsuKensaJisshiKomokuInfoDAOutput();
            selOut.KensaKomokuInfoDT = new SelectSuishitsuKensaJisshiKomokuInfoDataAccess().Execute(selIn).KensaKomokuInfoDT;

            if (selOut.KensaKomokuInfoDT.Rows.Count > 0)
            {
                // マスタあり
                return true;
            }
            // なし
            return false;
        }
        #endregion

        #region CheckKeiryoShomeiMaster
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckKeiryoShomeiMaster
        /// <summary>
        /// 計量証明に関連付いている浄化槽台帳水質検査項目マスタが正しく設定されているか確認
        /// </summary>
        /// <param name="JokasoDaichoHokenjoCd">浄化槽台帳保健所コード</param>
        /// <param name="JokasoDaichoNendo">浄化槽台帳登録年度</param>
        /// <param name="JokasoDaichoRenban">浄化槽台帳連番</param>
        /// <param name="Edaban">枝番</param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/08　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool CheckKeiryoShomeiMaster(string JokasoDaichoHokenjoCd, string JokasoDaichoNendo, string JokasoDaichoRenban, string Edaban)
        {
            // 計量証明の場合
            // 浄化槽台帳マスタ、浄化槽台帳水質検査項目マスタから検査台帳と計量証明TBLの登録に必要なデータを取得
            // データ検索⑧
            DaichoSuishitsuKensaKomokuMstDataSet.KeiryoShomeiKensaDaichoEntryInfoDataTable entryInfoDT = null;
            {
                IGetKeiryoShomeiKensaDaichoEntryInfoBLInput getInput = new GetKeiryoShomeiKensaDaichoEntryInfoBLInput();
                // 浄化槽台帳保健所コード
                getInput.JokasoHokenjoCd = JokasoDaichoHokenjoCd;
                // 浄化槽台帳登録年度
                getInput.JokasoTorokuNendo = JokasoDaichoNendo;
                // 浄化槽台帳連番
                getInput.JokasoRenban = JokasoDaichoRenban;
                // 台帳検査項目枝番
                getInput.DaichoKensaKomokuEdaban = Edaban;

                // 浄化槽台帳水質検査単項目マスタ情報取得
                IGetKeiryoShomeiKensaDaichoEntryInfoBLOutput getOutput = new GetKeiryoShomeiKensaDaichoEntryInfoBusinessLogic().Execute(getInput);
                entryInfoDT = getOutput.EntryInfoDT;
            }
            if (entryInfoDT.Rows.Count > 0)
            {
                // マスタあり
                return true;
            }
            // なし
            return false;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region 計量証明用

        #region InsertDataKeiryoShomei
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InsertDataKeiryoShomei
        /// <summary>
        /// 依頼取込後の登録処理
        /// ・計量証明依頼テーブル追加
        /// ・検査台帳（9条）ヘッダテーブル追加
        /// ・計量証明結果テーブル追加
        /// ・検査台帳明細テーブル追加
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  小松　　    新規作成
        /// 2014/12/25  小松　　　　計量証明セットコードが空白の場合はデフォルトのセットコードと料金を設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InsertDataKeiryoShomei(IKakuteiBtnClickALInput input)
        {
            foreach (SuishitsuKensaIraiDataSet.UketsukeImportListRow hdrRow in input.UketsukeImportListDT)
            {

                // 新規の場合

                // 更新フラグ＝対象の場合のみ登録。以外はスキップ
                if (!hdrRow.KoshinFlg)
                {
                    continue;
                }

                // 計量証明の場合
                // 浄化槽台帳マスタ、浄化槽台帳水質検査項目マスタから検査台帳と計量証明TBLの登録に必要なデータを取得
                // データ検索⑧
                DaichoSuishitsuKensaKomokuMstDataSet.KeiryoShomeiKensaDaichoEntryInfoDataTable entryInfoDT = null;
                {
                    IGetKeiryoShomeiKensaDaichoEntryInfoBLInput getInput = new GetKeiryoShomeiKensaDaichoEntryInfoBLInput();
                    // 浄化槽台帳保健所コード
                    getInput.JokasoHokenjoCd = hdrRow.JokasoDaichoHokenjoCd;
                    // 浄化槽台帳登録年度
                    getInput.JokasoTorokuNendo = hdrRow.JokasoDaichoNendo;
                    // 浄化槽台帳連番
                    getInput.JokasoRenban = hdrRow.JokasoDaichoRenban;
                    // 台帳検査項目枝番
                    getInput.DaichoKensaKomokuEdaban = hdrRow.Edaban;

                    // 浄化槽台帳水質検査単項目マスタ情報取得
                    IGetKeiryoShomeiKensaDaichoEntryInfoBLOutput getOutput = new GetKeiryoShomeiKensaDaichoEntryInfoBusinessLogic().Execute(getInput);
                    entryInfoDT = getOutput.EntryInfoDT;
                }
                if (entryInfoDT.Rows.Count <= 0)
                {
                    // 次の行へ
                    continue;
                }
                DaichoSuishitsuKensaKomokuMstDataSet.KeiryoShomeiKensaDaichoEntryInfoRow entryInfoRow =
                    (DaichoSuishitsuKensaKomokuMstDataSet.KeiryoShomeiKensaDaichoEntryInfoRow)entryInfoDT[0];

                // 計量証明依頼登録用の計量証明書発行対象フラグ取得
                // データ検索⑭
                string keiryoShomeiHakkoFlg = "0";
                {
                    ISelectKeiryoShomeiHakkoFlgInfoDAInput selInput = new SelectKeiryoShomeiHakkoFlgInfoDAInput();
                    // 浄化槽台帳保健所コード
                    selInput.JokasoHokenjoCd = hdrRow.JokasoDaichoHokenjoCd;
                    // 浄化槽台帳登録年度
                    selInput.JokasoTorokuNendo = hdrRow.JokasoDaichoNendo;
                    // 浄化槽台帳連番
                    selInput.JokasoRenban = hdrRow.JokasoDaichoRenban;
                    // 台帳検査項目枝番
                    selInput.DaichoKensaKomokuEdaban = hdrRow.Edaban;

                    // 計量証明書発行対象フラグ取得
                    // 検査セットの検査項目で１つでも 1(証明書発行対象)の場合
                    //    MAX(1) ->0: 計量証明書
                    // 検査セットの検査項目が全て 0(証明書発行非対象)の場合
                    //    MAX(0) -> 1:分析報告書
                    ISelectKeiryoShomeiHakkoFlgInfoDAOutput selOutput = new SelectKeiryoShomeiHakkoFlgInfoDataAccess().Execute(selInput);
                    keiryoShomeiHakkoFlg = selOutput.KeiryoShomeiHakkoFlg;
                }

                // 計量証明依頼テーブルを登録する
                // データ更新①
                {
                    KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable keiryoShomeiIraiDT = new KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable();
                    KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblRow addHdrRow = keiryoShomeiIraiDT.NewKeiryoShomeiIraiTblRow();

                    // 計量証明検査依頼年度
                    addHdrRow.KeiryoShomeiIraiNendo = input.IraiNendo;
                    // 計量証明支所コード
                    addHdrRow.KeiryoShomeiIraiSishoCd = input.ShishoCd;
                    // 計量証明依頼連番
                    addHdrRow.KeiryoShomeiIraiRenban = hdrRow.KentaiNo;
                    // 計量証明依頼受付日
                    //addHdrRow.KeiryoShomeiIraiUketsukeDt = _nowDtStr;
                    addHdrRow.KeiryoShomeiIraiUketsukeDt = input.KensaIraiUketsukeDt;
                    // 台帳保健所コード
                    addHdrRow.KeiryoShomeiJokasoDaichoHokenjoCd = hdrRow.JokasoDaichoHokenjoCd;
                    // 台帳登録年度
                    addHdrRow.KeiryoShomeiJokasoDaichoNendo = hdrRow.JokasoDaichoNendo;
                    // 台帳連番
                    addHdrRow.KeiryoShomeiJokasoDaichoRenban = hdrRow.JokasoDaichoRenban;
                    // 設置者区分
                    addHdrRow.KeiryoShomeiSetchishaKbn = entryInfoRow.JokasoSetchishaKbn;
                    // 設置者コード
                    addHdrRow.KeiryoShomeiSetchishaCd = entryInfoRow.JokasoSetchishaCd;
                    // 検査項目枝番
                    addHdrRow.KeiryoShomeiKensakomokuEdaban = hdrRow.Edaban;
                    // 計量証明受付区分
                    addHdrRow.KeiryoShomeiUketsukeKbn = "1";
                    if (hdrRow.MotikomiFlg)
                    {
                        // 計量証明受付区分（1:持込）
                        addHdrRow.KeiryoShomeiUketsukeKbn = "1";
                    }
                    else if (hdrRow.ShushuFlg)
                    {
                        // 計量証明受付区分（2:収集）
                        addHdrRow.KeiryoShomeiUketsukeKbn = "2";
                    }
                    // 計量証明現金収入フラグ（2:請求）
                    addHdrRow.KeiryoShomeiGenkinShunyuFlg = "2";
                    if (hdrRow.GenkinFlg)
                    {
                        // 1:現金
                        addHdrRow.KeiryoShomeiGenkinShunyuFlg = "1";
                    }
                    // 計量証明採水業者コード
                    addHdrRow.KeiryoShomeiSaisuiGyoshaCd = entryInfoRow.IsJokasoSaisuiGyoshaCdNull() ? string.Empty : entryInfoRow.JokasoSaisuiGyoshaCd;
                    // 計量証明請求業者コード
                    addHdrRow.KeiryoShomeiSeikyuGyoshaCd = entryInfoRow.IsJokasoSeikyuGyoshaCdNull() ? string.Empty : entryInfoRow.JokasoSeikyuGyoshaCd;
                    // 計量証明持込業者コード
                    addHdrRow.KeiryoShomeiMochikonmiGyoshaCd = entryInfoRow.IsJokasoMochikomiGyoshaCdNull() ? string.Empty : entryInfoRow.JokasoMochikomiGyoshaCd;
                    // 計量証明保健所コード
                    addHdrRow.KeiryoShomeiHokenjoCd = string.Empty;
                    // 計量証明水質コード
                    addHdrRow.KeiryoShomeiSuisitsuCd = entryInfoRow.IsDaichoKensaKomokuSuishitsuCdNull() ? string.Empty : entryInfoRow.DaichoKensaKomokuSuishitsuCd;
                    // 計量証明処理方式区分
                    addHdrRow.KeiryoShomeiShoriHousikiKbn = entryInfoRow.IsJokasoShoriHosikiKbnNull() ? string.Empty : entryInfoRow.JokasoShoriHosikiKbn;
                    // 計量証明処理方式コード
                    addHdrRow.KeiryoShomeiShoriHousikiCd = entryInfoRow.IsJokasoShoriHosikiCdNull() ? string.Empty : entryInfoRow.JokasoShoriHosikiCd;
                    // 計量証明水温
                    addHdrRow.KeiryoShomeiSuion = 0;
                    // 計量証明気温
                    addHdrRow.KeiryoShomeiKion = 0;
                    // 計量証明人槽
                    addHdrRow.KeiryoShomeiNinsou = entryInfoRow.IsJokasoShoriTaishoJininNull() ? string.Empty : entryInfoRow.JokasoShoriTaishoJinin.ToString(); ;
                    // 計量証明日平均汚水量
                    addHdrRow.KeiryoShomeiHiHeikinOsuiRyo = 0;
                    // 計量証明セットコード
                    addHdrRow.KeiryoShomeiSetCd = entryInfoRow.IsDaichoKensaKomokuSetCdNull() ? string.Empty : entryInfoRow.DaichoKensaKomokuSetCd;
                    //// 計量証明検査料金（税抜金額）
                    //addHdrRow.KeiryoShomeiKensaRyokin = kensaRyokin;
                    //// 計量証明消費税額（小数以下切捨）
                    //addHdrRow.KeiryoShomeiShohizei = shohizei;
                    // 計量証明還付金
                    addHdrRow.KeiryoShomeiKanpuKin = 0;
                    // 計量証明検査手数料
                    addHdrRow.KeiryoShomeiKensaTesuryo = 0;
                    // 証明書発行フラグ
                    addHdrRow.KeiryoShomeiShomeishoHakkouFlg = "0";
                    // 計量証明一括依頼フラグ
                    addHdrRow.KeiryoShomeiItkatsuIraiFlg = "0";
                    // 計量証明締次更新フラグ
                    addHdrRow.KeiryoShomeiSimejiKoushinFlg = "0";
                    // 計量証明削除フラグ
                    addHdrRow.KeiryoShomeiSakujoFlg = "0";
                    // 計量証明旧地区コード
                    addHdrRow.KeiryoShomeiKyuChikuCd = entryInfoRow.IsJokasoKyuChikuCdNull() ? string.Empty : entryInfoRow.JokasoKyuChikuCd;
                    // 計量証明新地区コード
                    addHdrRow.KeiryoShomeiShinChikuCd = entryInfoRow.IsJokasoGenChikuCdNull() ? string.Empty : entryInfoRow.JokasoGenChikuCd;
                    // ステータス区分（新規時は 50:水質検査受付済み）
                    addHdrRow.KeiryoShomeiStatusKbn = FukjBizSystem.Application.Utility.Constants.KensaIraiStatusConstant.STATUS_KENSA_SUISHITSU_KEKKA_UKETUKE_ZUMI;
                    // 水質日報区分(0:未登録)
                    addHdrRow.KeiryoShomeiSuishitsuNippoKbn = "0";
                    // 請求区分(0:未請求)
                    addHdrRow.KeiryoShomeiSeikyuKbn = "0";
                    // 採水員コード
                    addHdrRow.KeiryoShomeiSaisuiinCd = hdrRow.SaisuiinCd;
                    // 計量証明分析報告書フラグ
                    // 1：検査セットの検査項目で１つでも 1(証明書発行対象)有の場合
                    //    0（計量証明書）
                    // 0：検査セットの検査項目が全て 0(証明書発行非対象)の場合
                    //    1（分析報告書）
                    if (keiryoShomeiHakkoFlg == "1")
                    {
                        // 0（計量証明書）
                        addHdrRow.KeiryoShomeiBunsekiKekkashoFlg = "0";
                    }
                    else
                    {
                        // 1（分析報告書）
                        addHdrRow.KeiryoShomeiBunsekiKekkashoFlg = "1";
                    }
                    // 採水日付
                    addHdrRow.KeiryoShomeiSaisuiDt = hdrRow.SaisuiDt;
                    // 採水時分
                    addHdrRow.KeiryoShomeiSaisuiTime = hdrRow.SaisuiTime;
                    // 計量証明水温
                    addHdrRow.KeiryoShomeiSuion = (double)hdrRow.KeiryoShomeiSuion;
                    // 計量証明気温
                    addHdrRow.KeiryoShomeiKion = (double)hdrRow.KeiryoShomeiKion;
                    // 計量証明セットコード
                    addHdrRow.KeiryoShomeiSetCd = hdrRow.KeiryoShomeiSetCd;
                    // 計量証明検査料金
                    addHdrRow.KeiryoShomeiKensaRyokin = hdrRow.KeiryoShomeiKensaRyokin;
                    // 計量証明消費税額
                    addHdrRow.KeiryoShomeiShohizei = hdrRow.KeiryoShomeiShohizei;
                    // 検査項目枝番
                    addHdrRow.KeiryoShomeiKensakomokuEdaban = hdrRow.KeiryoShomeiKensakomokuEdaban;
                    // 証明書印刷回数
                    addHdrRow.KeiryoShomeiShomeishoInsatsuCnt = 0;

                    // 詳細画面で設定されていない場合
                    if (string.IsNullOrEmpty(hdrRow.KeiryoShomeiSetCd))
                    {
                        // デフォルトの料金セットを使用

                        // 検査料金
                        decimal kensaRyokin = 0;
                        // 消費税
                        decimal shohizei = 0;
                        FukjBizSystem.Application.Utility.KeiryoShomeiUtility.KeiryoshomeiKensaRyokinShukei(
                            input.KensaIraiUketsukeDt, hdrRow.JokasoDaichoHokenjoCd, hdrRow.JokasoDaichoNendo, hdrRow.JokasoDaichoRenban, hdrRow.Edaban, out kensaRyokin, out shohizei);

                        // 計量証明セットコード
                        addHdrRow.KeiryoShomeiSetCd = entryInfoRow.IsDaichoKensaKomokuSetCdNull() ? string.Empty : entryInfoRow.DaichoKensaKomokuSetCd;
                        // 計量証明検査料金（税抜金額）
                        addHdrRow.KeiryoShomeiKensaRyokin = kensaRyokin;
                        // 計量証明消費税額（小数以下切捨）
                        addHdrRow.KeiryoShomeiShohizei = shohizei;
                        // 検査項目枝番
                        addHdrRow.KeiryoShomeiKensakomokuEdaban = hdrRow.Edaban;
                    }

                    addHdrRow.InsertDt = _currentDateTime;
                    addHdrRow.InsertUser = _loginUser;
                    addHdrRow.InsertTarm = _tarmName;
                    addHdrRow.UpdateDt = _currentDateTime;
                    addHdrRow.UpdateUser = _loginUser;
                    addHdrRow.UpdateTarm = _tarmName;

                    keiryoShomeiIraiDT.AddKeiryoShomeiIraiTblRow(addHdrRow);
                    addHdrRow.AcceptChanges();
                    addHdrRow.SetAdded();

                    // 登録
                    IUpdateKeiryoShomeiIraiTblBLInput updIn = new UpdateKeiryoShomeiIraiTblBLInput();
                    updIn.KeiryoShomeiIraiTblDT = keiryoShomeiIraiDT;
                    new UpdateKeiryoShomeiIraiTblBusinessLogic().Execute(updIn);
                }

                // 検査台帳（9条）ヘッダテーブルを登録する
                // データ更新①
                {
                    KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable kensaDaicho9HdrDT = new KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable();
                    KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblRow addHdrRow = kensaDaicho9HdrDT.NewKensaDaicho9joHdrTblRow();

                    // 依頼年度
                    addHdrRow.IraiNendo = input.IraiNendo;
                    // 支所コード
                    addHdrRow.ShishoCd = input.ShishoCd;
                    // 水質検査依頼番号
                    addHdrRow.SuishitsuKensaIraiNo = hdrRow.KentaiNo;
                    // 計量証明検査依頼年度
                    addHdrRow.KeiryoShomeiIraiNendo = input.IraiNendo;
                    // 計量証明支所コード
                    addHdrRow.KeiryoShomeiIraiSishoCd = input.ShishoCd;
                    // 計量証明依頼連番
                    addHdrRow.KeiryoShomeiIraiRenban = hdrRow.KentaiNo;
                    // 結果確定日
                    addHdrRow.KensaKekkaKakuteiDt = string.Empty;
                    // 課長検印区分
                    addHdrRow.KachoKeninKbn = "0";
                    // 副課長検印区分
                    addHdrRow.HukuKachoKeninKbn = "0";
                    // 計量管理者検印区分
                    addHdrRow.KeiryoKanrishaKeninKbn = "0";
                    // 検査依頼受付日
                    //addHdrRow.KensaIraiUketsukeDt = _nowDtStr;
                    addHdrRow.KensaIraiUketsukeDt = input.KensaIraiUketsukeDt;

                    addHdrRow.InsertDt = _currentDateTime;
                    addHdrRow.InsertUser = _loginUser;
                    addHdrRow.InsertTarm = _tarmName;
                    addHdrRow.UpdateDt = _currentDateTime;
                    addHdrRow.UpdateUser = _loginUser;
                    addHdrRow.UpdateTarm = _tarmName;

                    kensaDaicho9HdrDT.AddKensaDaicho9joHdrTblRow(addHdrRow);
                    addHdrRow.AcceptChanges();
                    addHdrRow.SetAdded();

                    // 登録
                    IUpdateKensaDaicho9joHdrTblBLInput updIn = new UpdateKensaDaicho9joHdrTblBLInput();
                    updIn.KensaDaicho9joHdrTblDataTable = kensaDaicho9HdrDT;
                    new UpdateKensaDaicho9joHdrTblBusinessLogic().Execute(updIn);
                }

                // 浄化槽台帳水質検査単項目マスタ情報取得
                // データ検索⑩
                DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable TanKomokuDT =
                    Boundary.Common.Common.GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPK(
                        hdrRow.JokasoDaichoHokenjoCd, hdrRow.JokasoDaichoNendo, hdrRow.JokasoDaichoRenban, hdrRow.Edaban);

                // 明細情報登録
                KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable keiryoShomeiKekkaDT = new KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable();
                KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();
                foreach (DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstRow dtlRow in TanKomokuDT)
                {
                    // 計量証明結果テーブルに登録する
                    // データ更新⑧
                    {
                        KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblRow addDtlRow = keiryoShomeiKekkaDT.NewKeiryoShomeiKekkaTblRow();

                        // 計量証明結果依頼年度
                        addDtlRow.KeiryoShomeiKekkaIraiNendo = input.IraiNendo;
                        // 計量証明結果依頼支所コード
                        addDtlRow.KeiryoShomeiKekkaIraiShishoCd = input.ShishoCd;
                        // 計量証明結果依頼番号
                        addDtlRow.KeiryoShomeiKekkaIraiNo = hdrRow.KentaiNo;
                        // 計量証明試験項目コード
                        addDtlRow.KeiryoShomeiShikenkoumokuCd = dtlRow.DaichoKensaKomokuCd;
                        // 結果値
                        addDtlRow.KeiryoShomeiKekkaValue = 0;
                        // 結果コード
                        addDtlRow.KeiryoShomeiKekkaCd = "0";
                        // 結果値表示用
                        addDtlRow.KeiryoShomeiKekkaValueHyojiyo = "0";
                        // 温度数
                        addDtlRow.KeiryoShomeiKekkaOndo = 0;
                        // 再検査回数
                        addDtlRow.KeiryoShomeiKekkaSaikensaKaisu = "0";
                        // 証明書発行区分
                        addDtlRow.KeiryoShomeishoHakkoKbn = "0";
                        // 結果入力
                        addDtlRow.KeiryoShomeiKekkaNyuryoku = "0";
                        // 請求区分
                        addDtlRow.KeiryoShomeiSeikyuKbn = "0";
                        // 外部委託フラグ
                        addDtlRow.KeiryoShomeiGaibuItakuFlg = "0";
                        // 日次更新フラグ
                        addDtlRow.KeiryoShomeiKekkaNichijiFlg = "0";
                        // 締次更新フラグ
                        addDtlRow.KeiryoShomeiKekkaShimejiFlg = "0";
                        // 月次更新フラグ
                        addDtlRow.KeiryoShomeiKekkaGetsujiFlg = "0";
                        // 年次更新フラグ
                        addDtlRow.KeiryoShomeiKekkaNenjiFlg = "0";

                        addDtlRow.InsertDt = _currentDateTime;
                        addDtlRow.InsertUser = _loginUser;
                        addDtlRow.InsertTarm = _tarmName;
                        addDtlRow.UpdateDt = _currentDateTime;
                        addDtlRow.UpdateUser = _loginUser;
                        addDtlRow.UpdateTarm = _tarmName;

                        keiryoShomeiKekkaDT.AddKeiryoShomeiKekkaTblRow(addDtlRow);
                        addDtlRow.AcceptChanges();
                        addDtlRow.SetAdded();
                    }

                    // 検査台帳明細テーブルに登録する
                    // データ更新⑦
                    {
                        setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "1", dtlRow.DaichoKensaKomokuCd);
                    }
                    if (keiryoShomeiKekkaDT.Rows.Count > 0)
                    {
                        // 計量証明結果テーブル登録（明細一括登録）
                        IUpdateKeiryoShomeiKekkaTblBLInput updIn = new UpdateKeiryoShomeiKekkaTblBLInput();
                        updIn.KeiryoShomeiKekkaTblDT = keiryoShomeiKekkaDT;
                        new UpdateKeiryoShomeiKekkaTblBusinessLogic().Execute(updIn);
                    }

                    if (kensaDaichoDtlDT.Rows.Count > 0)
                    {
                        // 検査台帳明細テーブル登録（明細一括登録）
                        IUpdateKensaDaichoDtlTblBLInput updIn = new UpdateKensaDaichoDtlTblBLInput();
                        updIn.KensaDaichoDtlTblDT = kensaDaichoDtlDT;
                        new UpdateKensaDaichoDtlTblBusinessLogic().Execute(updIn);
                    }
                }
            }
        }
        #endregion

        #region UpdateDataKeiryoShomei
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateDataKeiryoShomei
        /// <summary>
        /// 検索実行後の更新処理（計量証明用）
        /// ・計量証明依頼テーブル更新
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateDataKeiryoShomei(IKakuteiBtnClickALInput input)
        {
            foreach (SuishitsuKensaIraiDataSet.UketsukeImportListRow hdrRow in input.UketsukeImportListDT)
            {
                // 更新の場合

                // 更新フラグ＝対象の場合のみ登録。以外はスキップ
                if (!hdrRow.KoshinFlg)
                {
                    continue;
                }

                // 計量証明の場合

                // 計量証明依頼テーブル
                // データ更新④
                {
                    // 最新の計量証明依頼レコード取得
                    ISelectKeiryoShomeiIraiTblByKeyDAInput selIn = new SelectKeiryoShomeiIraiTblByKeyDAInput();
                    selIn.KeiryoShomeiIraiNendo = hdrRow.KeiryoShomeiIraiNendo;
                    selIn.KeiryoShomeiIraiSishoCd = hdrRow.KeiryoShomeiIraiSishoCd;
                    selIn.KeiryoShomeiIraiRenban = hdrRow.KeiryoShomeiIraiRenban;
                    ISelectKeiryoShomeiIraiTblByKeyDAOutput selOut = new SelectKeiryoShomeiIraiTblByKeyDAOutput();
                    selOut.KeiryoShomeiIraiTblDT = new SelectKeiryoShomeiIraiTblByKeyDataAccess().Execute(selIn).KeiryoShomeiIraiTblDT;

                    if (selOut.KeiryoShomeiIraiTblDT.Rows.Count <= 0)
                    {
                        continue;
                    }

                    // 存在すれば更新
                    KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblRow modHdrRow = selOut.KeiryoShomeiIraiTblDT[0];

                    // 楽観ロックチェック
                    if (hdrRow.KeiryoShomeiIraiUpdateDt != modHdrRow.UpdateDt)
                    {
                        // 楽観ロックエラー（更新された最新レコードあり）
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    // 計量証明受付区分
                    // ｛持込｝がチェックされている場合 "1"を設定。｛収集｝がチェックされている場合"2"を設定
                    modHdrRow.KeiryoShomeiUketsukeKbn = "1";
                    if (hdrRow.MotikomiFlg)
                    {
                        modHdrRow.KeiryoShomeiUketsukeKbn = "1";
                    }
                    else if (hdrRow.ShushuFlg)
                    {
                        modHdrRow.KeiryoShomeiUketsukeKbn = "2";
                    }
                    // 採水員コード
                    modHdrRow.KeiryoShomeiSaisuiinCd = hdrRow.SaisuiinCd;
                    // 採水日付
                    modHdrRow.KeiryoShomeiSaisuiDt = hdrRow.SaisuiDt;
                    // 採水時分
                    modHdrRow.KeiryoShomeiSaisuiTime = hdrRow.SaisuiTime;
                    // 計量証明水温
                    modHdrRow.KeiryoShomeiSuion = (double)hdrRow.KeiryoShomeiSuion;
                    // 計量証明気温
                    modHdrRow.KeiryoShomeiKion = (double)hdrRow.KeiryoShomeiKion;
                    // 計量証明セットコード
                    modHdrRow.KeiryoShomeiSetCd = hdrRow.KeiryoShomeiSetCd;
                    // 計量証明検査料金
                    modHdrRow.KeiryoShomeiKensaRyokin = hdrRow.KeiryoShomeiKensaRyokin;
                    // 計量証明消費税額
                    modHdrRow.KeiryoShomeiShohizei = hdrRow.KeiryoShomeiShohizei;
                    // 検査項目枝番
                    modHdrRow.KeiryoShomeiKensakomokuEdaban = hdrRow.KeiryoShomeiKensakomokuEdaban;

                    modHdrRow.UpdateDt = _currentDateTime;
                    modHdrRow.UpdateUser = _loginUser;
                    modHdrRow.UpdateTarm = _tarmName;

                    // 更新
                    IUpdateKeiryoShomeiIraiTblBLInput updIn = new UpdateKeiryoShomeiIraiTblBLInput();
                    updIn.KeiryoShomeiIraiTblDT = selOut.KeiryoShomeiIraiTblDT;
                    new UpdateKeiryoShomeiIraiTblBusinessLogic().Execute(updIn);
                }
            }
        }
        #endregion

        #endregion 計量証明用


        #region 水質検査用

        #region InsertDataSuishitsuKensa
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InsertDataSuishitsuKensa
        /// <summary>
        /// 依頼取込後の登録処理（水質検査用）
        /// ・検査依頼、検査結果、再採水、検査台帳ヘッダ、検査台帳明細テーブル追加
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  小松　　    新規作成
        /// 2014/12/24  小松　　　　水質検査時は、再採水テーブルの操作は不要
        /// 　　　　　　　　　　　　スクリーニング区分の初期値は"0"
        /// 2014/12/25  小松　　　　再採水区分の設定値修正
        /// 2015/01/08  土生、小松　初期値設定（合計金額、入金方法、入金完了区分、前回判定、水質検印区分）
        /// 2015/01/09  土生      　検査依頼採番区分修正( => 80)
        /// 2015/01/12  小松　　　　検査依頼のBOD処理性能を浄化槽台帳からセット（処理目標水質[JokasoSyoriMokuhyoBOD]）
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InsertDataSuishitsuKensa(IKakuteiBtnClickALInput input)
        {
            foreach (SuishitsuKensaIraiDataSet.UketsukeImportListRow hdrRow in input.UketsukeImportListDT)
            {
                // 新規の場合

                // 更新フラグ＝対象の場合のみ登録。以外はスキップ
                if (!hdrRow.KoshinFlg)
                {
                    continue;
                }

                // 登録用情報取得

                // 浄化槽台帳マスタの情報を取得
                // データ検索⑦
                SuishitsuKensaUketsukeDataSet.SuishitsuKensaEntryInfoRow kensaEntryInfoRow = null;
                {
                    ISelectSuishitsuKensaEntryInfoDAInput selIn = new SelectSuishitsuKensaEntryInfoDAInput();
                    selIn.JokasoHokenjoCd = hdrRow.JokasoDaichoHokenjoCd;
                    selIn.JokasoTorokuNendo = hdrRow.JokasoDaichoNendo;
                    selIn.JokasoRenban = hdrRow.JokasoDaichoRenban;
                    ISelectSuishitsuKensaEntryInfoDAOutput selOut = new SelectSuishitsuKensaEntryInfoDAOutput();
                    selOut.KensaEntryInfoDT = new SelectSuishitsuKensaEntryInfoDataAccess().Execute(selIn).KensaEntryInfoDT;
                    if (selOut.KensaEntryInfoDT.Rows.Count <= 0)
                    {
                        continue;
                    }
                    kensaEntryInfoRow = selOut.KensaEntryInfoDT[0];
                }

                // 前回の検査依頼情報を取得（検査結果の前回判定も取得）
                // データ検索⑨
                SuishitsuKensaUketsukeDataSet.ZenkaiKensaIraiInfoRow zenkaiKensaInfoRow = null;
                {
                    ISelectZenkaiKensaIraiInfoDAInput selIn = new SelectZenkaiKensaIraiInfoDAInput();
                    selIn.JokasoHokenjoCd = hdrRow.JokasoDaichoHokenjoCd;
                    selIn.JokasoTorokuNendo = hdrRow.JokasoDaichoNendo;
                    selIn.JokasoRenban = hdrRow.JokasoDaichoRenban;
                    selIn.TodayStr = _nowDtStr;
                    ISelectZenkaiKensaIraiInfoDAOutput selOut = new SelectZenkaiKensaIraiInfoDAOutput();
                    selOut.ZenkaiKensaInfoDT = new SelectZenkaiKensaIraiInfoDataAccess().Execute(selIn).ZenkaiKensaInfoDT;
                    if (selOut.ZenkaiKensaInfoDT.Rows.Count > 0)
                    {
                        // 前回あり
                        zenkaiKensaInfoRow = selOut.ZenkaiKensaInfoDT[0];
                    }
                }

                // 所見結果テーブルからフォロー対象の所見情報を取得
                // データ検索⑪
                string followFlg = "0";
                if (zenkaiKensaInfoRow != null)
                {
                    ISelectKensaShokenFollowInfoDAInput selIn = new SelectKensaShokenFollowInfoDAInput();
                    selIn.KensaIraiHoteiKbn = zenkaiKensaInfoRow.KensaIraiHoteiKbn;
                    selIn.KensaIraiHokenjoCd = zenkaiKensaInfoRow.KensaIraiHokenjoCd;
                    selIn.KensaIraiNendo = zenkaiKensaInfoRow.KensaIraiNendo;
                    selIn.KensaIraiRenban = zenkaiKensaInfoRow.KensaIraiRenban;
                    ISelectKensaShokenFollowInfoDAOutput selOut = new SelectKensaShokenFollowInfoDAOutput();
                    selOut.KensaFollowInfoDT = new SelectKensaShokenFollowInfoDataAccess().Execute(selIn).KensaFollowInfoDT;
                    if (selOut.KensaFollowInfoDT.Rows.Count > 0)
                    {
                        // 取得された場合は、フォロー対象
                        followFlg = "1";
                    }
                }

                #region データ更新②
                // 検査依頼テーブル、検査結果テーブル、検査台帳（11条）ヘッダテーブルに登録する
                // データ更新②

                // 検査依頼テーブル追加
                {
                    KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                    KensaIraiTblDataSet.KensaIraiTblRow addIraiRow = kensaIraiDT.NewKensaIraiTblRow();

                    // 検査依頼法定区分
                    hdrRow.KensaIraiHoteiKbn = "3";
                    addIraiRow.KensaIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                    // 検査依頼保健所コード
                    hdrRow.KensaIraiHokenjoCd = kensaEntryInfoRow.JokasoHokenjoCd;
                    addIraiRow.KensaIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                    // 検査依頼年度
                    hdrRow.KensaIraiNendo = input.IraiNendo;
                    addIraiRow.KensaIraiNendo = hdrRow.KensaIraiNendo;
                    // 検査依頼連番
                    hdrRow.KensaIraiRenban = Utility.Saiban.GetSaibanRenban(addIraiRow.KensaIraiNendo, Constants.SaibanKbnConstant.SAIBAN_KBN_SUISHITSU_KENSA);
                    //hdrRow.KensaIraiRenban = Utility.Saiban.GetSaibanRenban(addIraiRow.KensaIraiNendo, "8" + input.ShishoCd);
                    addIraiRow.KensaIraiRenban = hdrRow.KensaIraiRenban;

                    // 検査依頼受付支所
                    addIraiRow.KensaIraiUketsukeShishoKbn = input.ShishoCd;
                    // 検査依頼支店区分
                    addIraiRow.KensaIraiShitenKbn = string.Empty;
                    // 浄化槽保健所コード
                    addIraiRow.KensaIraiJokasoHokenjoCd = hdrRow.JokasoDaichoHokenjoCd;
                    // 浄化槽台帳登録年度
                    addIraiRow.KensaIraiJokasoTorokuNendo = hdrRow.JokasoDaichoNendo;
                    // 浄化槽台帳連番
                    addIraiRow.KensaIraiJokasoRenban = hdrRow.JokasoDaichoRenban;
                    // 水質検査依頼番号
                    addIraiRow.KensaIraiSuishitsuIraiNo = hdrRow.KentaiNo;
                    // 水質検査受付日
                    //addIraiRow.KensaIraiSuishitsuUketsukeDt = _nowDtStr;
                    addIraiRow.KensaIraiSuishitsuUketsukeDt = input.KensaIraiUketsukeDt;
                    // 新方式区分
                    addIraiRow.KensaIraiShinHoshikiKbn = string.Empty;
                    // スクリーニング区分
                    //addIraiRow.KensaIraiScreeningKbn = string.Empty;
                    addIraiRow.KensaIraiScreeningKbn = "0";
                    // 受付区分
                    addIraiRow.KensaIraiUketsukeKbn = "1";
                    if (hdrRow.MotikomiFlg)
                    {
                        // 1:持込
                        addIraiRow.KensaIraiUketsukeKbn = "1";
                    }
                    else if (hdrRow.ShushuFlg)
                    {
                        // 2:収集
                        addIraiRow.KensaIraiUketsukeKbn = "2";
                    }
                    // 現金収入区分（2:請求）
                    addIraiRow.KensaIraiGenkinShunyuKbn = "2";
                    if (hdrRow.GenkinFlg)
                    {
                        // 1:現金
                        addIraiRow.KensaIraiGenkinShunyuKbn = "1";
                    }
                    // 法根拠区分
                    addIraiRow.KensaIraiHokonkyoKbn = kensaEntryInfoRow.IsJokasoHouKonkyoKbnNull() ? string.Empty : kensaEntryInfoRow.JokasoHouKonkyoKbn;
                    // 保健所受理保健所コード
                    addIraiRow.KensaIraiHokenjoJyuriHokenjoCd = kensaEntryInfoRow.IsJokasoHokenjoJuriNoHokenCdNull() ? string.Empty : kensaEntryInfoRow.JokasoHokenjoJuriNoHokenCd;
                    // 保健所受理年度
                    addIraiRow.KensaIraiHokenjoJyuriNendo = kensaEntryInfoRow.IsJokasoHokenjoJuriNoNendoNull() ? string.Empty : kensaEntryInfoRow.JokasoHokenjoJuriNoNendo;
                    // 保健所受理市町村コード
                    addIraiRow.KensaIraiHokenjoJyuriShichosonCd = kensaEntryInfoRow.IsJokasoHokenjoJuriNoSichosonCdNull() ? string.Empty : kensaEntryInfoRow.JokasoHokenjoJuriNoSichosonCd;
                    // 保健所受理連番
                    addIraiRow.KensaIraiHokenjoJyuriRenban = kensaEntryInfoRow.IsJokasoHokenjoJuriNoRenbanNull() ? string.Empty : kensaEntryInfoRow.JokasoHokenjoJuriNoRenban;
                    // 保証登録検査機関
                    addIraiRow.KensaIraiHoshoTorokuKensakikanCd = kensaEntryInfoRow.IsJokasoHoshoNoKensakikanNull() ? string.Empty : kensaEntryInfoRow.JokasoHoshoNoKensakikan;
                    // 保証登録年度
                    addIraiRow.KensaIraiHoshoTorokuNendo = kensaEntryInfoRow.IsJokasoHoshoNoNendoNull() ? string.Empty : kensaEntryInfoRow.JokasoHoshoNoNendo;
                    // 保証登録連番
                    addIraiRow.KensaIraiHoshoTorokuRenban = kensaEntryInfoRow.IsJokasoHoshoNoRenbanNull() ? string.Empty : kensaEntryInfoRow.JokasoHoshoNoRenban;
                    // 依頼年
                    addIraiRow.KensaIraiNen = _nowDtStr.Substring(0, 4);
                    // 依頼月
                    addIraiRow.KensaIraiTsuki = _nowDtStr.Substring(4, 2);
                    // 依頼日
                    addIraiRow.KensaIraiBi = _nowDtStr.Substring(6, 2);
                    // 検査年
                    addIraiRow.KensaIraiKensaNen = string.Empty;
                    // 検査月
                    addIraiRow.KensaIraiKensaTsuki = string.Empty;
                    // 検査日
                    addIraiRow.KensaIraiKensaBi = string.Empty;
                    // 検査予定年
                    addIraiRow.KensaIraiKensaYoteiNen = string.Empty;
                    // 検査予定月
                    addIraiRow.KensaIraiKensaYoteiTsuki = string.Empty;
                    // 検査予定日
                    addIraiRow.KensaIraiKensaYoteiBi = string.Empty;
                    // 取下年
                    addIraiRow.KensaIraiTorisageNen = string.Empty;
                    // 取下月
                    addIraiRow.KensaIraiTorisageTsuki = string.Empty;
                    // 取下日
                    addIraiRow.KensaIraiTorisageBi = string.Empty;
                    // 検査料金
                    addIraiRow.KensaIraiKensaAmt = hdrRow.KensaIraiKensaAmt;
                    // 前渡還付金
                    addIraiRow.KensaIraiMaewatashiKanpuAmt = 0;
                    // 20150108 habu 
                    // 合計金額
                    addIraiRow.KensaIraiGokeiAmt = hdrRow.KensaIraiKensaAmt;
                    //addIraiRow.KensaIraiGokeiAmt = 0;
                    // 入金済金額
                    addIraiRow.KensaIraiNyukinzumiAmt = hdrRow.KensaIraiNyukinzumiAmt;
                    // 入金方法
                    addIraiRow.KensaIraiNyukinHohoKbn = "005";
                    //addIraiRow.KensaIraiNyukinHohoKbn = "5";
                    // 最終入金年
                    addIraiRow.KensaIraiSaishuNyukinNen = string.Empty;
                    // 最終入金月
                    addIraiRow.KensaIraiSaishuNyukinTsuki = string.Empty;
                    // 最終入金日
                    addIraiRow.KensaIraiSaishuNyukinBi = string.Empty;
                    // 請求番号
                    addIraiRow.KensaIraiSeikyuNo = string.Empty;
                    // 請求年
                    addIraiRow.KensaIraiSeikyuNen = string.Empty;
                    // 請求月
                    addIraiRow.KensaIraiSeikyuTsuki = string.Empty;
                    // 請求日
                    addIraiRow.KensaIraiSeikyuBi = string.Empty;
                    // 請求額
                    addIraiRow.KensaIraiSeikyuAmt = 0;
                    // 再請求番号
                    addIraiRow.KensaIraiSaiseikyuNo = string.Empty;
                    // 再請求年
                    addIraiRow.KensaIraiSaiseikyuNen = string.Empty;
                    // 再請求月
                    addIraiRow.KensaIraiSaiseikyuTsuki = string.Empty;
                    // 再請求日
                    addIraiRow.KensaIraiSaiseikyuBi = string.Empty;
                    // 再請求額
                    addIraiRow.KensaIraiSaiseikyuAmt = 0;
                    // 入金完了区分
                    addIraiRow.KensaIraiNyukinKanryoKbn = "0";
                    //addIraiRow.KensaIraiNyukinKanryoKbn = string.Empty;
                    // 請求書発行区分
                    addIraiRow.KensaIraiSeikyushoHakkoKbn = string.Empty;
                    // 結果書発行区分
                    addIraiRow.KensaIraiKekkashoHakkoKbn = string.Empty;
                    // 前回法定区分
                    addIraiRow.KensaIraiZenkaiHoteiKbn = string.Empty;
                    // 前回依頼保健所コード
                    addIraiRow.KensaIraiZenkaiHokenjoCd = string.Empty;
                    // 前回依頼年度
                    addIraiRow.KensaIraiZenkaiNendo = string.Empty;
                    // 前回依頼連番
                    addIraiRow.KensaIraiZenkaiRenban = string.Empty;
                    if (zenkaiKensaInfoRow != null)
                    {
                        // 前回法定区分
                        addIraiRow.KensaIraiZenkaiHoteiKbn = zenkaiKensaInfoRow.KensaIraiHoteiKbn;
                        // 前回依頼保健所コード
                        addIraiRow.KensaIraiZenkaiHokenjoCd = zenkaiKensaInfoRow.KensaIraiHokenjoCd;
                        // 前回依頼年度
                        addIraiRow.KensaIraiZenkaiNendo = zenkaiKensaInfoRow.KensaIraiNendo;
                        // 前回依頼連番
                        addIraiRow.KensaIraiZenkaiRenban = zenkaiKensaInfoRow.KensaIraiRenban;
                    }
                    // 月次更新区分
                    addIraiRow.KensaIraiGetsujiKoshinKbn = string.Empty;
                    // 一括請求区分
                    addIraiRow.KensaIraiIkkatsuSeikyuKbn = string.Empty;
                    // 料金区分
                    addIraiRow.KensaIraiRyokinKbn = string.Empty;
                    // 月次請求区分
                    addIraiRow.KensaIraiGetsujiSeikyuKbn = string.Empty;
                    // 更新区分
                    addIraiRow.KensaIraiKoshinKbn = string.Empty;
                    // 送付日
                    addIraiRow.KensaIraiSofuDt = string.Empty;
                    // 引落年
                    addIraiRow.KensaIraiHikiotoshiNen = string.Empty;
                    // 引落月
                    addIraiRow.KensaIraiHikiotoshiTsuki = string.Empty;
                    // 引落日
                    addIraiRow.KensaIraiHikiotoshiBi = string.Empty;
                    // 発行区分１
                    addIraiRow.KensaIraiHakkoKbn1 = string.Empty;
                    // 発行区分２
                    addIraiRow.KensaIraiHakkoKbn2 = string.Empty;
                    // 発行区分３
                    addIraiRow.KensaIraiHakkoKbn3 = string.Empty;
                    // 発行区分４
                    addIraiRow.KensaIraiHakkoKbn4 = hdrRow.KensaIraiHakkoKbn4;
                    // 発行区分５
                    addIraiRow.KensaIraiHakkoKbn5 = hdrRow.KensaIraiHakkoKbn5;
                    // 発行区分６
                    addIraiRow.KensaIraiHakkoKbn6 = string.Empty;
                    // 発行区分７
                    addIraiRow.KensaIraiHakkoKbn7 = string.Empty;
                    // 発行区分８
                    addIraiRow.KensaIraiHakkoKbn8 = string.Empty;
                    // 発行区分９
                    addIraiRow.KensaIraiGyoseiHokokuLevel = string.Empty;
                    // 発行区分１０
                    addIraiRow.KensaIraiHakkoKbn10 = string.Empty;
                    // 保守点検回数
                    addIraiRow.KensaIraiHoshuTenkenKaisu = string.Empty;
                    // 前回判定
                    addIraiRow.KensaIraiZenkaiHantei = string.Empty;
                    if (zenkaiKensaInfoRow != null)
                    {
                        // 前回判定
                        addIraiRow.KensaIraiZenkaiHantei = zenkaiKensaInfoRow.IsKensaKekkaHanteiNull() ? string.Empty : zenkaiKensaInfoRow.KensaKekkaHantei;
                    }
                    // 前回検査日
                    addIraiRow.KensaIraiZenkaiKensaDt = kensaEntryInfoRow.IsKensaIraiKensaDtNull() ? string.Empty : kensaEntryInfoRow.KensaIraiKensaDt;
                    // 前回所見手書き
                    addIraiRow.KensaIraiZenkaiShokenTegaki = string.Empty;
                    // 設置者名（漢字）
                    addIraiRow.KensaIraiSetchishaNm = kensaEntryInfoRow.IsJokasoSetchishaNmNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchishaNm;
                    // 検査依頼設置者（住所）
                    addIraiRow.KensaIraiSetchishaAdr = kensaEntryInfoRow.IsJokasoSetchishaAdrNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchishaAdr;
                    // 設置者（郵便番号）
                    addIraiRow.KensaIraiSetchishaZipCd = kensaEntryInfoRow.IsJokasoSetchishaZipCdNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchishaZipCd;
                    // 設置者（電話番号）
                    addIraiRow.KensaIraiSetchishaTelNo = kensaEntryInfoRow.IsJokasoSetchishaTelNoNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchishaTelNo;
                    // 検査依頼設置場所（住所）
                    addIraiRow.KensaIraiSetchibashoAdr = kensaEntryInfoRow.IsJokasoSetchiBashoAdrNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchiBashoAdr;
                    // 設置場所（郵便番号）
                    addIraiRow.KensaIraiSetchibashoZipCd = kensaEntryInfoRow.IsJokasoSetchiBashoZipCdNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchiBashoZipCd;
                    // 設置場所（電話番号）
                    addIraiRow.KensaIraiSetchibashoTelNo = kensaEntryInfoRow.IsJokasoSetchiBashoTelNoNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchiBashoTelNo;
                    // 施設名称
                    addIraiRow.KensaIraiShisetsuNm = kensaEntryInfoRow.IsJokasoShisetsuNmNull() ? string.Empty : kensaEntryInfoRow.JokasoShisetsuNm;
                    // 保健所コード
                    addIraiRow.KensaIraiSetchibashoHokenjoCd = kensaEntryInfoRow.IsJokasoSetchiBashoHokenjoCdNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchiBashoHokenjoCd;
                    // 採水業者コード
                    addIraiRow.KensaIraiSaisuiGyoshaCd = kensaEntryInfoRow.IsJokasoSaisuiGyoshaCdNull() ? string.Empty : kensaEntryInfoRow.JokasoSaisuiGyoshaCd;
                    // 請求業者コード
                    addIraiRow.KensaIraiSeikyuGyoshaCd = kensaEntryInfoRow.IsJokasoSeikyuGyoshaCdNull() ? string.Empty : kensaEntryInfoRow.JokasoSeikyuGyoshaCd;
                    // 持込業者コード
                    addIraiRow.KensaIraiMochikomiGyoshaCd = kensaEntryInfoRow.IsJokasoMochikomiGyoshaCdNull() ? string.Empty : kensaEntryInfoRow.JokasoMochikomiGyoshaCd;
                    // 送付先名
                    addIraiRow.KensaIraiSofusakiNm = kensaEntryInfoRow.IsJokasoSoufusakiNmNull() ? string.Empty : kensaEntryInfoRow.JokasoSoufusakiNm;
                    // 送付先（郵便番号）
                    addIraiRow.KensaIraiSofusakiZipCd = kensaEntryInfoRow.IsJokasoSoufusakiZipCdNull() ? string.Empty : kensaEntryInfoRow.JokasoSoufusakiZipCd;
                    // 検査依頼送付先（住所）
                    addIraiRow.KensaIraiSofusakiAdr = kensaEntryInfoRow.IsJokasoSoufusakiAdrNull() ? string.Empty : kensaEntryInfoRow.JokasoSoufusakiAdr;
                    // 送付先（電話番号）
                    addIraiRow.KensaIraiSofusakiTelNo = kensaEntryInfoRow.IsJokasoSoufusakiTelNoNull() ? string.Empty : kensaEntryInfoRow.JokasoSoufusakiTelNo;
                    // 請求先名
                    addIraiRow.KensaIraiSeikyusakiNm = kensaEntryInfoRow.IsJokasoSeikyusakiNmNull() ? string.Empty : kensaEntryInfoRow.JokasoSeikyusakiNm;
                    // 請求先（郵便番号）
                    addIraiRow.KensaIraiSeikyusakiZipCd = kensaEntryInfoRow.IsJokasoSeikyusakiZipCdNull() ? string.Empty : kensaEntryInfoRow.JokasoSeikyusakiZipCd;
                    // 検査依頼請求先（住所）
                    addIraiRow.KensaIraiSeikyusakiAdr = kensaEntryInfoRow.IsJokasoSeikyusakiAdrNull() ? string.Empty : kensaEntryInfoRow.JokasoSeikyusakiAdr;
                    // 請求先（電話番号）
                    addIraiRow.KensaIraiSeikyusakiTelNo = kensaEntryInfoRow.IsJokasoSeikyusakiTelNoNull() ? string.Empty : kensaEntryInfoRow.JokasoSeikyusakiTelNo;
                    // 一括請求先コード
                    addIraiRow.KensaIraiIkkatsuSeikyusakiCd = kensaEntryInfoRow.IsJokasoItkatsuSeikyuGyoshaCdNull() ? string.Empty : kensaEntryInfoRow.JokasoItkatsuSeikyuGyoshaCd;
                    // 建築用途大分類１
                    addIraiRow.KenchikuyotoDaibunrui1 = kensaEntryInfoRow.IsKenchikuyotoDaibunrui1Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoDaibunrui1;
                    // 建築用途小分類１
                    addIraiRow.KenchikuyotoShobunrui1 = kensaEntryInfoRow.IsKenchikuyotoShobunrui1Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoShobunrui1;
                    // 建築用途連番１
                    addIraiRow.KenchikuyotoRenban1 = kensaEntryInfoRow.IsKenchikuyotoRenban1Null() ? 0 : kensaEntryInfoRow.KenchikuyotoRenban1;
                    // 建築用途大分類２
                    addIraiRow.KenchikuyotoDaibunrui2 = kensaEntryInfoRow.IsKenchikuyotoDaibunrui2Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoDaibunrui2;
                    // 建築用途小分類２
                    addIraiRow.KenchikuyotoShobunrui2 = kensaEntryInfoRow.IsKenchikuyotoShobunrui2Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoShobunrui2;
                    // 建築用途連番２
                    addIraiRow.KenchikuyotoRenban2 = kensaEntryInfoRow.IsKenchikuyotoRenban2Null() ? 0 : kensaEntryInfoRow.KenchikuyotoRenban2;
                    // 建築用途大分類３
                    addIraiRow.KenchikuyotoDaibunrui3 = kensaEntryInfoRow.IsKenchikuyotoDaibunrui3Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoDaibunrui3;
                    // 建築用途小分類３
                    addIraiRow.KenchikuyotoShobunrui3 = kensaEntryInfoRow.IsKenchikuyotoShobunrui3Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoShobunrui3;
                    // 建築用途連番３
                    addIraiRow.KenchikuyotoRenban3 = kensaEntryInfoRow.IsKenchikuyotoRenban3Null() ? 0 : kensaEntryInfoRow.KenchikuyotoRenban3;
                    // 建築用途大分類４
                    addIraiRow.KenchikuyotoDaibunrui4 = kensaEntryInfoRow.IsKenchikuyotoDaibunrui4Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoDaibunrui4;
                    // 建築用途小分類４
                    addIraiRow.KenchikuyotoShobunrui4 = kensaEntryInfoRow.IsKenchikuyotoShobunrui4Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoShobunrui4;
                    // 建築用途連番４
                    addIraiRow.KenchikuyotoRenban4 = kensaEntryInfoRow.IsKenchikuyotoRenban4Null() ? 0 : kensaEntryInfoRow.KenchikuyotoRenban4;
                    // 建築用途大分類５
                    addIraiRow.KenchikuyotoDaibunrui5 = kensaEntryInfoRow.IsKenchikuyotoDaibunrui5Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoDaibunrui5;
                    // 建築用途小分類５
                    addIraiRow.KenchikuyotoShobunrui5 = kensaEntryInfoRow.IsKenchikuyotoShobunrui5Null() ? string.Empty : kensaEntryInfoRow.KenchikuyotoShobunrui5;
                    // 建築用途連番５
                    addIraiRow.KenchikuyotoRenban5 = kensaEntryInfoRow.IsKenchikuyotoRenban5Null() ? 0 : kensaEntryInfoRow.KenchikuyotoRenban5;
                    // 旧建築用途コード
                    addIraiRow.KensaIraiTatemonoYoto = kensaEntryInfoRow.IsJokasoOldKentikuYoutoCdNull() ? string.Empty : kensaEntryInfoRow.JokasoOldKentikuYoutoCd;
                    // メーカコード
                    addIraiRow.KensaIraiMakerCd = kensaEntryInfoRow.IsJokasoMekaGyoshaCdNull() ? string.Empty : kensaEntryInfoRow.JokasoMekaGyoshaCd;
                    // 型式コード
                    addIraiRow.KensaIraiKatashikiCd = kensaEntryInfoRow.IsJokasoKatashikiCdNull() ? string.Empty : kensaEntryInfoRow.JokasoKatashikiCd;
                    // 工事業者コード
                    addIraiRow.KensaIraiKojiGyoshaCd = kensaEntryInfoRow.IsJokasoKojiGyoshaKbnNull() ? string.Empty : kensaEntryInfoRow.JokasoKojiGyoshaKbn;
                    // 保守点検業者コード
                    addIraiRow.KensaIraiHoshutenkenGyoshaCd = kensaEntryInfoRow.IsJokasoHoshutenkenGyoshaCdNull() ? string.Empty : kensaEntryInfoRow.JokasoHoshutenkenGyoshaCd;
                    // 清掃業者コード
                    addIraiRow.KensaIraiSeisoGyoshaCd = kensaEntryInfoRow.IsJokasoSeisouGyoshaCdNull() ? string.Empty : kensaEntryInfoRow.JokasoSeisouGyoshaCd;
                    // 放流先コード
                    addIraiRow.KensaIraiHoryusakiCd = kensaEntryInfoRow.IsJokasoHoryusakiCdNull() ? string.Empty : kensaEntryInfoRow.JokasoHoryusakiCd;
                    // 実使用人員
                    addIraiRow.KensaIraiJitsushiyoJinin = kensaEntryInfoRow.IsJokasoJitsuSiyoJininNull() ? string.Empty : kensaEntryInfoRow.JokasoJitsuSiyoJinin;
                    // 処理対象人員
                    addIraiRow.KensaIraiShoritaishoJinin = kensaEntryInfoRow.IsJokasoShoriTaishoJininNull() ? 0 : kensaEntryInfoRow.JokasoShoriTaishoJinin;
                    // 処理方式区分
                    addIraiRow.KensaIraiShorihoshikiKbn = kensaEntryInfoRow.IsJokasoShoriHosikiKbnNull() ? string.Empty : kensaEntryInfoRow.JokasoShoriHosikiKbn;
                    // 処理方式コード
                    addIraiRow.KensaIraiShorihoshikiCd = kensaEntryInfoRow.IsJokasoShoriHosikiCdNull() ? string.Empty : kensaEntryInfoRow.JokasoShoriHosikiCd;
                    // 地域コード
                    addIraiRow.KensaIraiChiikiCd = string.Empty;
                    // 変更前メーカー
                    addIraiRow.KensaIraiHenkomaeMakerCd = string.Empty;
                    // 変更前工事業者
                    addIraiRow.KensaIraiHenkomaeKojiGyoshaCd = string.Empty;
                    // はがき送付先
                    addIraiRow.KensaIraiHagakiSofusakiKbn = kensaEntryInfoRow.IsJokasoHagakiSoufusakiKbnNull() ? string.Empty : kensaEntryInfoRow.JokasoHagakiSoufusakiKbn;
                    // 三次処理有無
                    addIraiRow.KensaIraiSanjishoriUmuKbn = kensaEntryInfoRow.IsJokaso3JiShoriFlgNull() ? string.Empty : kensaEntryInfoRow.Jokaso3JiShoriFlg;
                    // 処理目標水質
                    addIraiRow.KensaIraiShorimokuhyoSuishitsu = kensaEntryInfoRow.IsJokasoSyoriMokuhyoBODNull() ? 0 : kensaEntryInfoRow.JokasoSyoriMokuhyoBOD;
                    // 種類
                    addIraiRow.KensaIraiShurui = string.Empty;
                    // 市町村設置型
                    addIraiRow.KensaIraiShichosonSetchigata = kensaEntryInfoRow.IsJokasoSichosonSetchiKbnNull() ? string.Empty : kensaEntryInfoRow.JokasoSichosonSetchiKbn;
                    // 告示区分
                    addIraiRow.KensaIraiKokujiKbn = kensaEntryInfoRow.IsJokasoKoujiKbnNull() ? string.Empty : kensaEntryInfoRow.JokasoKoujiKbn;
                    // 告示年度
                    addIraiRow.KensaIraiKokujiNendo = kensaEntryInfoRow.IsJokasoKoujiNenNull() ? string.Empty : kensaEntryInfoRow.JokasoKoujiNen;
                    // 告示番号
                    addIraiRow.KensaIraiKokujiNo = kensaEntryInfoRow.IsJokasoKoujiNoNull() ? string.Empty : kensaEntryInfoRow.JokasoKoujiNo;
                    // 延べ面積
                    addIraiRow.KensaIraiNobeMensaeki = kensaEntryInfoRow.IsJokasoTatemonoNobeMensekiNull() ? 0 : (decimal)kensaEntryInfoRow.JokasoTatemonoNobeMenseki;
                    // 認定番号
                    addIraiRow.KensaIraiNinteiNo = kensaEntryInfoRow.IsJokasoNinteiNoNull() ? string.Empty : kensaEntryInfoRow.JokasoNinteiNo;
                    // BOD処理性能
                    //addIraiRow.KensaIraiBODShoriSeino = string.Empty;
                    addIraiRow.KensaIraiBODShoriSeino = kensaEntryInfoRow.IsJokasoSyoriMokuhyoBODNull() ? string.Empty : kensaEntryInfoRow.JokasoSyoriMokuhyoBOD.ToString();
                    // 設置年
                    addIraiRow.KensaIraiSetchiNen = kensaEntryInfoRow.IsJokasoSetchiNenNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchiNen;
                    // 設置月
                    addIraiRow.KensaIraiSetchiTsuki = kensaEntryInfoRow.IsJokasoSetchiTsukiNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchiTsuki;
                    // 設置日
                    addIraiRow.KensaIraiSetchiBi = kensaEntryInfoRow.IsJokasoSetchiBiNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchiBi;
                    // 使用開始年
                    addIraiRow.KensaIraiShiyoKaishiNen = kensaEntryInfoRow.IsJokasoSiyokaisiNenNull() ? string.Empty : kensaEntryInfoRow.JokasoSiyokaisiNen;
                    // 使用開始月
                    addIraiRow.KensaIraiShiyoKaishiTsuki = kensaEntryInfoRow.IsJokasoSiyokaisiTsukiNull() ? string.Empty : kensaEntryInfoRow.JokasoSiyokaisiTsuki;
                    // 使用開始日
                    addIraiRow.KensaIraiShiyoKaishiBi = kensaEntryInfoRow.IsJokasoSiyokaisiBiNull() ? string.Empty : kensaEntryInfoRow.JokasoSiyokaisiBi;
                    // 使用開始届
                    addIraiRow.KensaIraiShiyoKaishiTodoke = string.Empty;
                    // 取下理由
                    addIraiRow.KensaIraiTorisageRiyu = string.Empty;
                    // 設置者（カナ）
                    addIraiRow.KensaIraiSetchishaKana = kensaEntryInfoRow.IsJokasoSetchishaKanaNull() ? string.Empty : kensaEntryInfoRow.JokasoSetchishaKana;
                    // 現地区コード
                    addIraiRow.KensaIraiGenChikuCd = kensaEntryInfoRow.IsJokasoGenChikuCdNull() ? string.Empty : kensaEntryInfoRow.JokasoGenChikuCd;
                    // 検査完了区分
                    addIraiRow.KensaIraiKensaKanryoKbn = string.Empty;
                    // 検印区分
                    addIraiRow.KensaIraiKeninKbn = string.Empty;
                    // 水質検印区分
                    addIraiRow.KensaIraiSuishitsuKeninKbn = string.Empty;
                    // BOD入力済区分
                    addIraiRow.KensaIraiBODNyuryokuzumiKbn = string.Empty;
                    // 塩素イオン入力済区分
                    addIraiRow.KensaIraiEnsoIonNyuryokuzumiKbn = string.Empty;
                    // MLSS入力済区分
                    addIraiRow.KensaIraiMLSSNyuryokuzumiKbn = string.Empty;
                    // 検査票印刷済区分
                    addIraiRow.KensaIraiKensahyoInsatsuzumiKbn = string.Empty;
                    // ハガキ印刷済区分
                    addIraiRow.KensaIraiHagakiInsatsuzumiKbn = string.Empty;
                    // ７条保留区分
                    addIraiRow.KensaIrai7joHoryuKbn = string.Empty;
                    // 実使用人員（数値）
                    addIraiRow.KensaIraiJitsushiyoJininValue = kensaEntryInfoRow.IsJokasoJitsuSiyouJininSuchiNull() ? string.Empty : kensaEntryInfoRow.JokasoJitsuSiyouJininSuchi;
                    // 点検回数月毎
                    addIraiRow.KensaIraiTenkenKaisuTsukiGoto = string.Empty;
                    // 点検回数週毎
                    addIraiRow.KensaIraiTenkenKaisuShuGoto = string.Empty;
                    // 嵩上げ
                    addIraiRow.KensaIraiKasaage = kensaEntryInfoRow.IsJokasoKasaageTakasaNull() ? string.Empty : kensaEntryInfoRow.JokasoKasaageTakasa;
                    // 流入滞留
                    addIraiRow.KensaIraiRyunyuTairyu = kensaEntryInfoRow.IsJokasoRyunyuTairyuTakasaNull() ? string.Empty : kensaEntryInfoRow.JokasoRyunyuTairyuTakasa;
                    // 放流滞留
                    addIraiRow.KensaIraiHoryuTairyu = kensaEntryInfoRow.IsJokasoHouryuTairyuTakasaNull() ? string.Empty : kensaEntryInfoRow.JokasoHouryuTairyuTakasa;
                    // ブロワ
                    addIraiRow.KensaIraiBurowa = string.Empty;
                    // ブロワ規定風量
                    addIraiRow.KensaIraiBurowaKiteFuryo = string.Empty;
                    // ブロワ設置風量
                    addIraiRow.KensaIraiBurowaSetchiFuryo = string.Empty;
                    // ７条保留確認日
                    addIraiRow.KensaIrai7joHoryuKakuninDt = string.Empty;
                    // 次回確認予定日
                    addIraiRow.KensaIraiJikaiKakuninYoteiDt = string.Empty;
                    // 保留理由
                    addIraiRow.KensaIraiHoryuRiyu = string.Empty;
                    // 保守点検（内容）
                    addIraiRow.KensaIraiHoshuTenkenNiayo = string.Empty;
                    // 清掃回数（年）
                    addIraiRow.KensaIraiSeisoKaisuNenkan = string.Empty;
                    // ブロワ１
                    addIraiRow.KensaIraiBurowa1 = string.Empty;
                    // ブロワ規定風量１
                    addIraiRow.KensaIraiBurowaKiteFuryo1 = string.Empty;
                    // ブロワ設置風量１
                    addIraiRow.KensaIraiBurowaSetchiFuryo1 = string.Empty;
                    // ブロワ２
                    addIraiRow.KensaIraiBurowa2 = string.Empty;
                    // ブロワ規定風量２
                    addIraiRow.KensaIraiBurowaKiteFuryo2 = string.Empty;
                    // ブロワ設置風量２
                    addIraiRow.KensaIraiBurowaSetchiFuryo2 = string.Empty;
                    // ブロワ３
                    addIraiRow.KensaIraiBurowa3 = string.Empty;
                    // ブロワ規定風量３
                    addIraiRow.KensaIraiBurowaKiteFuryo3 = string.Empty;
                    // ブロワ設置風量３
                    addIraiRow.KensaIraiBurowaSetchiFuryo3 = string.Empty;
                    // 検査担当者コード
                    addIraiRow.KensaIraiKensaTantoshaCd = string.Empty;
                    // 検査担当者
                    addIraiRow.KensaIraiKensaTantoshaNm = string.Empty;
                    // 保留区分
                    addIraiRow.KensaIraiHoryuKbn = string.Empty;
                    // 保留取消日
                    addIraiRow.KensaIraiHoryuTorikeshiDt = string.Empty;
                    // メモ確認フラグ
                    addIraiRow.KensaIraiMemoKakuninFlg = string.Empty;
                    // 採水員コード
                    addIraiRow.KensaIraiSaisuiinCd = hdrRow.SaisuiinCd;
                    // クロスチェック
                    addIraiRow.KensaIraiCrossCheck = string.Empty;
                    // クロスチェック判定
                    addIraiRow.KensaIraiCrossCheckHantei = string.Empty;
                    // クロスチェック理由
                    addIraiRow.KensaIraiCrossCheckRiyu = string.Empty;
                    // 検査責任者
                    addIraiRow.KensaIraiKensaSekininsha = string.Empty;
                    // 判定区分
                    addIraiRow.KensaIraiHanteiKbn = string.Empty;
                    // スクリーニング実施
                    addIraiRow.KensaIraiScreeningJisshi = string.Empty;
                    // スクリーニング保健所コード
                    addIraiRow.KensaIraiScreeningHokenjoCd = string.Empty;
                    // スクリーニング年度
                    addIraiRow.KensaIraiScreeningNendo = string.Empty;
                    // スクリーニング連番
                    addIraiRow.KensaIraiScreeningRenban = string.Empty;
                    // ステータス区分（50：水質検査受付済み）
                    addIraiRow.KensaIraiStatusKbn = FukjBizSystem.Application.Utility.Constants.KensaIraiStatusConstant.STATUS_KENSA_SUISHITSU_KEKKA_UKETUKE_ZUMI;
                    // 外観日報区分
                    addIraiRow.KensaIraiGaikanNippoKbn = "0";
                    // 水質日報区分
                    addIraiRow.KensaIraiSuishitsuNippoKbn = "0";
                    // 請求区分
                    addIraiRow.KensaIraiSeikyuKbn = "0";
                    // 結果書印刷回数
                    addIraiRow.KensaIraiKekkashoInsatsuCnt = 0;
                    // 20150126 habu Add
                    // 遅延報告作成区分
                    addIraiRow.ChienHokokuMakeKbn = "0";

                    addIraiRow.InsertDt = _currentDateTime;
                    addIraiRow.InsertUser = _loginUser;
                    addIraiRow.InsertTarm = _tarmName;
                    addIraiRow.UpdateDt = _currentDateTime;
                    addIraiRow.UpdateUser = _loginUser;
                    addIraiRow.UpdateTarm = _tarmName;

                    kensaIraiDT.AddKensaIraiTblRow(addIraiRow);
                    addIraiRow.AcceptChanges();
                    addIraiRow.SetAdded();

                    // 登録
                    IUpdateKensaIraiTblBLInput updIn = new UpdateKensaIraiTblBLInput();
                    updIn.KensaIraiTblDataTable = kensaIraiDT;
                    new UpdateKensaIraiTblBusinessLogic().Execute(updIn);
                }

                // 検査台帳（11条）ヘッダテーブル追加
                {
                    KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable kensaDaicho11HdrDT = new KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable();
                    KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblRow addHdrRow = kensaDaicho11HdrDT.NewKensaDaicho11joHdrTblRow();

                    // 検査区分(2:水質)
                    addHdrRow.KensaKbn = "2";
                    // 依頼年度
                    addHdrRow.IraiNendo = input.IraiNendo;
                    // 支所コード
                    addHdrRow.ShishoCd = input.ShishoCd;
                    // 水質検査依頼番号
                    addHdrRow.SuishitsuKensaIraiNo = hdrRow.KentaiNo;
                    // スクリーニング区分が0の場合
                    if (hdrRow.ScreeningKbn == "0")
                    {
                        // 再採水区分
                        //addHdrRow.SaisaisuiKbn = "1";
                        addHdrRow.SaisaisuiKbn = "0";
                    }
                    else
                    {
                        // 再採水区分
                        //addHdrRow.SaisaisuiKbn = "2";
                        addHdrRow.SaisaisuiKbn = "1";
                    }
                    // 検査依頼法定区分
                    addHdrRow.KensaKekkaIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                    // 検査依頼保健所コード
                    addHdrRow.KensaKekkaIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                    // 検査依頼年度
                    addHdrRow.KensaKekkaIraiNendo = hdrRow.KensaIraiNendo;
                    // 検査依頼連番
                    addHdrRow.KensaKekkaIraiRenban = hdrRow.KensaIraiRenban;
                    // スクリーニング候補
                    addHdrRow.ScreeningKoho = "0";
                    // フォロー候補
                    addHdrRow.FollowKoho = followFlg;
                    // クロスチェック異常（水質判定表）
                    addHdrRow.CrossCheckSuishitsu = "0";
                    // クロスチェック異常（過去履歴）
                    addHdrRow.CrossCheckKako = "0";
                    // 判定コード
                    addHdrRow.HanteiCd = "0";
                    // 結果確定日
                    addHdrRow.KensaKekkaKakuteiDt = string.Empty;
                    // 課長検印区分
                    addHdrRow.KachoKeninKbn = "0";
                    // 課長検印区分（再採水）
                    addHdrRow.KachoKeninKbnScreening = "0";
                    // 副課長検印区分
                    addHdrRow.HukuKachoKeninKbn = "0";
                    // 副課長検印区分（再採水）
                    addHdrRow.HukuKachoKeninKbnScreening = "0";
                    // 検査依頼受付日
                    //addHdrRow.KensaIraiUketsukeDt = _nowDtStr;
                    addHdrRow.KensaIraiUketsukeDt = input.KensaIraiUketsukeDt;
                    // 塩化物イオン過去１
                    addHdrRow.EnkaIonKako1 = 0;
                    // 塩化物イオン過去２
                    addHdrRow.EnkaIonKako2 = 0;
                    // 塩化物イオン過去３
                    addHdrRow.EnkaIonKako3 = 0;
                    // 塩化物イオン過去４
                    addHdrRow.EnkaIonKako4 = 0;
                    // 塩化物イオン過去５
                    addHdrRow.EnkaIonKako5 = 0;

                    addHdrRow.InsertDt = _currentDateTime;
                    addHdrRow.InsertUser = _loginUser;
                    addHdrRow.InsertTarm = _tarmName;
                    addHdrRow.UpdateDt = _currentDateTime;
                    addHdrRow.UpdateUser = _loginUser;
                    addHdrRow.UpdateTarm = _tarmName;

                    kensaDaicho11HdrDT.AddKensaDaicho11joHdrTblRow(addHdrRow);
                    addHdrRow.AcceptChanges();
                    addHdrRow.SetAdded();

                    // 登録
                    IUpdateKensaDaicho11joHdrTblBLInput updIn = new UpdateKensaDaicho11joHdrTblBLInput();
                    updIn.KensaDaicho11joHdrTblDataTable = kensaDaicho11HdrDT;
                    new UpdateKensaDaicho11joHdrTblBusinessLogic().Execute(updIn);
                }

                // 検査結果テーブル追加
                {
                    KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT = new KensaKekkaTblDataSet.KensaKekkaTblDataTable();
                    KensaKekkaTblDataSet.KensaKekkaTblRow addKekkaRow = kensaKekkaDT.NewKensaKekkaTblRow();

                    // 検査依頼法定区分
                    addKekkaRow.KensaKekkaIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                    // 検査依頼保健所コード
                    addKekkaRow.KensaKekkaIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                    // 検査依頼年度
                    addKekkaRow.KensaKekkaIraiNendo = hdrRow.KensaIraiNendo;
                    // 検査依頼連番
                    addKekkaRow.KensaKekkaIraiRenban = hdrRow.KensaIraiRenban;
                    // 法１１条検査
                    addKekkaRow.KensaKekka11joKensa = string.Empty;
                    // 判定
                    addKekkaRow.KensaKekkaHantei = string.Empty;
                    // 主な原因１
                    addKekkaRow.KensaKekkaGenin1 = string.Empty;
                    // 主な原因２
                    addKekkaRow.KensaKekkaGenin2 = string.Empty;
                    // 主な原因３
                    addKekkaRow.KensaKekkaGenin3 = string.Empty;
                    // 主な原因４
                    addKekkaRow.KensaKekkaGenin4 = string.Empty;
                    // 主な原因５
                    addKekkaRow.KensaKekkaGenin5 = string.Empty;
                    // 主な原因６
                    addKekkaRow.KensaKekkaGenin6 = string.Empty;
                    // 水質検査依頼番号
                    addKekkaRow.KensaKekkaSuishitsuIraiNo = hdrRow.KentaiNo;
                    // 水質検査測定不能
                    addKekkaRow.KensaKekkaSuishitsuSokuteifuno = string.Empty;
                    // 水質検査採水日付
                    addKekkaRow.KensaKekkaSaisuiDt = string.Empty;
                    // 水質検査持込日付
                    addKekkaRow.KensaKekkaMochikomiDt = string.Empty;
                    // 温度
                    addKekkaRow.KensaKekkaOndo = 0;
                    // 水素イオン濃度
                    //addKekkaRow.KensaKekkaSuisoIonNodo = 0;
                    addKekkaRow.SetKensaKekkaSuisoIonNodoNull();
                    // 水素イオン濃度ー判定
                    addKekkaRow.KensaKekkaSuisoIonNodoHantei = string.Empty;
                    // 汚泥沈殿率
                    //addKekkaRow.KensaKekkaOdeiChindenritsu = 0;
                    addKekkaRow.SetKensaKekkaOdeiChindenritsuNull();
                    // 汚泥沈殿率２
                    addKekkaRow.KensaKekkaOdeiChindenritsu2 = string.Empty;
                    // 汚泥沈殿率ー判定
                    addKekkaRow.KensaKekkaOdeiChindenritsuHantei = string.Empty;
                    // 溶存酸素量１
                    //addKekkaRow.KensaKekkaYozonSansoryo1 = 0;
                    addKekkaRow.SetKensaKekkaYozonSansoryo1Null();
                    // 溶存酸素量２
                    //addKekkaRow.KensaKekkaYozonSansoryo2 = 0;
                    addKekkaRow.SetKensaKekkaYozonSansoryo2Null();
                    // 溶存酸素量ー判定
                    addKekkaRow.KensaKekkaYozonSansoryoHantei = string.Empty;
                    // 亜硝酸性窒素
                    //addKekkaRow.KensaKekkaAsyosanseiChisso = string.Empty;
                    addKekkaRow.SetKensaKekkaAsyosanseiChissoNull();
                    // 亜硝酸性窒素ー判定
                    addKekkaRow.KensaKekkaAsyosanseiChissoHantei = string.Empty;
                    // 透視度
                    //addKekkaRow.KensaKekkaToshido = 0;
                    addKekkaRow.SetKensaKekkaToshidoNull();
                    // 透視度２
                    addKekkaRow.KensaKekkaToshido2 = string.Empty;
                    // 透視度ー判定
                    addKekkaRow.KensaKekkaToshidoHantei = string.Empty;
                    // 透視度２次処理水
                    //addKekkaRow.KensaKekkaToshido2jiSyorisui = 0;
                    addKekkaRow.SetKensaKekkaToshido2jiSyorisuiNull();
                    // 透視度２２次処理水
                    addKekkaRow.KensaKekkaToshido22jiSyorisui = string.Empty;
                    // 透視度ー判定２次処理水
                    addKekkaRow.KensaKekkaToshidoHantei2jiSyorisui = string.Empty;
                    // 塩素イオン濃度
                    //addKekkaRow.KensaKekkaEnsoIonNodo = 0;
                    addKekkaRow.SetKensaKekkaEnsoIonNodoNull();
                    // 塩素イオン濃度２
                    addKekkaRow.KensaIraiEnsoIonNodo2 = string.Empty;
                    // 塩素イオン濃度ー判定
                    addKekkaRow.KensaKekkaEnsoIonNodoHantei = string.Empty;
                    // 残留塩素濃度
                    //addKekkaRow.KensaKekkaZanryuEnsoNodo = 0;
                    addKekkaRow.SetKensaKekkaZanryuEnsoNodoNull();
                    // 残留塩素濃度ー判定
                    addKekkaRow.KensaKekkaZanryuEnsoNodoHantei = string.Empty;
                    // 生物化学酸素要求量
                    //addKekkaRow.KensaKekkaBOD = 0;
                    addKekkaRow.SetKensaKekkaBODNull();
                    // 生物化学酸素要求量２
                    addKekkaRow.KensaIraiBOD2 = string.Empty;
                    // 生物化学酸素要求量ー判定
                    addKekkaRow.KensaKekkaBODHantei = string.Empty;
                    // ＭＬＳＳ
                    //addKekkaRow.KensaKekkaMLSS = 0;
                    addKekkaRow.SetKensaKekkaMLSSNull();
                    // ＭＬＳＳ－判定
                    addKekkaRow.KensaKekkaMLSSHantei = string.Empty;
                    // 入力担当者
                    addKekkaRow.KensaKekkaNyuryokuTanto = string.Empty;
                    // 点検記録保存
                    addKekkaRow.KensaKekkaTenkenKirokuHozon = string.Empty;
                    // 清掃日付
                    addKekkaRow.KensaKekkaSeisoDt = string.Empty;
                    // 清掃記録保存
                    addKekkaRow.KensaKekkaSeisoKirokuHozon = string.Empty;
                    // 保守点検記録有無
                    addKekkaRow.KensaKekkaHoshuTenkenKirokuUmu = string.Empty;
                    // 保守点検回数
                    addKekkaRow.KensaKekkaHoshuTenkenKaisu = string.Empty;
                    // 保守点検内容
                    addKekkaRow.KensaKekkaHoshuTenkenNaiyo = string.Empty;
                    // 清掃記録有無
                    addKekkaRow.KensaKekkaSeisoKirokuUmu = string.Empty;
                    // 清掃回数
                    addKekkaRow.KensaKekkaSeisoKaisu = string.Empty;
                    // 清掃内容
                    addKekkaRow.KensaKekkaSeisoNaiyo = string.Empty;
                    // 特記事項手書き
                    addKekkaRow.KensaKekkaTokkijikoTegaki = string.Empty;
                    // メモ手書き
                    addKekkaRow.KensaKekkaMemoTegaki = string.Empty;
                    // 所見変更フラグ
                    addKekkaRow.KensaKekkaShokenHenkoFlg = string.Empty;
                    // ATUBOD
                    //addKekkaRow.KensaKekkaATUBOD = 0;
                    addKekkaRow.SetKensaKekkaATUBODNull();
                    // ATUBOD２
                    addKekkaRow.KensaKekkaATUBOD2 = string.Empty;
                    // 保守点検実施回数区分    
                    addKekkaRow.KensaKekkaTenkenKaisuKbn = string.Empty;
                    // 在宅有無フラグ    
                    addKekkaRow.KensaKekkaZaitakuUmu = string.Empty;
                    // 検査時間    
                    addKekkaRow.KensaKekkaKensaTimes = 0;
                    // 検査状況    
                    addKekkaRow.KensaKekkaKensaJoukyouKbn = string.Empty;

                    addKekkaRow.InsertDt = _currentDateTime;
                    addKekkaRow.InsertUser = _loginUser;
                    addKekkaRow.InsertTarm = _tarmName;
                    addKekkaRow.UpdateDt = _currentDateTime;
                    addKekkaRow.UpdateUser = _loginUser;
                    addKekkaRow.UpdateTarm = _tarmName;

                    kensaKekkaDT.AddKensaKekkaTblRow(addKekkaRow);
                    addKekkaRow.AcceptChanges();
                    addKekkaRow.SetAdded();

                    // 登録
                    IUpdateKensaKekkaTblBLInput updIn = new UpdateKensaKekkaTblBLInput();
                    updIn.KensaKekkaTblDataTable = kensaKekkaDT;
                    new UpdateKensaKekkaTblBusinessLogic().Execute(updIn);
                }

                #region DELETE（2014/12/24  小松　水質検査時は、再採水テーブルの操作は不要）
                //// 再採水テーブル追加
                //{
                //    SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saiSaisuiDT = new SaiSaisuiTblDataSet.SaiSaisuiTblDataTable();
                //    SaiSaisuiTblDataSet.SaiSaisuiTblRow addSaiSaisuiRow = saiSaisuiDT.NewSaiSaisuiTblRow();

                //    // 検査依頼法定区分
                //    addSaiSaisuiRow.SaiSaisuiIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                //    // 検査依頼保健所コード
                //    addSaiSaisuiRow.SaiSaisuiIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                //    // 検査依頼年度
                //    addSaiSaisuiRow.SaiSaisuiIraiNendo = hdrRow.KensaIraiNendo;
                //    // 検査依頼連番
                //    addSaiSaisuiRow.SaiSaisuiIraiRrenban = hdrRow.KensaIraiRenban;
                //    // 温度
                //    addSaiSaisuiRow.SaiSaisuiOndo = 0;
                //    // 水素イオン濃度
                //    addSaiSaisuiRow.SaiSaisuiSuisoIonNodo = 0;
                //    // 水素イオン濃度ー判定
                //    addSaiSaisuiRow.SaiSaisuiSuisoIonNodoHantei = string.Empty;
                //    // 汚泥沈殿率（％）
                //    addSaiSaisuiRow.SaiSaisuiOdeichindenritsu = 0;
                //    // 汚泥沈殿率２
                //    addSaiSaisuiRow.SaiSaisuiOdeichindenritsu2 = string.Empty;
                //    // 汚泥沈殿率ー判定
                //    addSaiSaisuiRow.SaiSaisuiOdeichindenritsuHantei = string.Empty;
                //    // 溶存酸素量１
                //    addSaiSaisuiRow.SaiSaisuiYozonSansoryo1 = 0;
                //    // 溶存酸素量２
                //    addSaiSaisuiRow.SaiSaisuiYozonSansoryo2 = 0;
                //    // 溶存酸素量ー判定
                //    addSaiSaisuiRow.SaiSaisuiYozonSansoryoHantei = string.Empty;
                //    // 亜硝酸性窒素
                //    addSaiSaisuiRow.SaiSaisuiAshosanseichisso = string.Empty;
                //    // 亜硝酸性窒素ー判定
                //    addSaiSaisuiRow.SaiSaisuiAshosanseichissoHantei = string.Empty;
                //    // 透視度（度）
                //    addSaiSaisuiRow.SaiSaisuiToshido = 0;
                //    // 透視度２
                //    addSaiSaisuiRow.SaiSaisuiToshido2 = string.Empty;
                //    // 透視度ー判定
                //    addSaiSaisuiRow.SaiSaisuiToshidoHantei = string.Empty;
                //    // 透視度（度）２次処理水
                //    addSaiSaisuiRow.SaiSaisuiToshido2jishorisui = 0;
                //    // 透視度２２次処理水
                //    addSaiSaisuiRow.SaiSaisuiToshido22jishorisui = string.Empty;
                //    // 透視度ー判定２次処理水
                //    addSaiSaisuiRow.SaiSaisuiToshidoHantei2jishorisui = string.Empty;
                //    // 塩化イオン濃度
                //    addSaiSaisuiRow.SaiSaisuiEnkaIonNodo = 0;
                //    // 塩化イオン濃度ー判定
                //    addSaiSaisuiRow.SaiSaisuiEnkaIonNodoHantei = string.Empty;
                //    // 塩化イオン濃度２
                //    addSaiSaisuiRow.SaiSaisuiEnkaIonNodo2 = string.Empty;
                //    // 残留塩素濃度
                //    addSaiSaisuiRow.SaiSaisuiZanryuEnsoNodo = 0;
                //    // 残留塩素濃度ー判定
                //    addSaiSaisuiRow.SaiSaisuiZanryuEnsoNodoHantei = string.Empty;
                //    // 生物化学酸素要求量
                //    addSaiSaisuiRow.SaiSaisuiBOD = 0;
                //    // 生物化学酸素要求量ー判定
                //    addSaiSaisuiRow.SaiSaisuiBODHantei = string.Empty;
                //    // 生物化学酸素要求量２
                //    addSaiSaisuiRow.SaiSaisuiBOD2 = string.Empty;
                //    // ＭＬＳＳ
                //    addSaiSaisuiRow.SaiSaisuiMLSS = 0;
                //    // ＭＬＳＳ－判定
                //    addSaiSaisuiRow.SaiSaisuiMLSSHantei = string.Empty;
                //    // 水質検査（測定不能）
                //    addSaiSaisuiRow.SaiSaisuiSuishitsuSokuteifuno = string.Empty;
                //    // 水質検査依頼番号
                //    addSaiSaisuiRow.SaiSaisuiSuishitsuIraiNo = string.Empty;
                //    // 再採水日
                //    addSaiSaisuiRow.SaiSaisuiDt = string.Empty;
                //    // ATUBOD
                //    addSaiSaisuiRow.SaiSaisuiATUBOD = 0;
                //    // ATUBOD２
                //    addSaiSaisuiRow.SaiSaisuiATUBOD2 = string.Empty;

                //    addSaiSaisuiRow.InsertDt = _currentDateTime;
                //    addSaiSaisuiRow.InsertUser = _loginUser;
                //    addSaiSaisuiRow.InsertTarm = _tarmName;
                //    addSaiSaisuiRow.UpdateDt = _currentDateTime;
                //    addSaiSaisuiRow.UpdateUser = _loginUser;
                //    addSaiSaisuiRow.UpdateTarm = _tarmName;

                //    saiSaisuiDT.AddSaiSaisuiTblRow(addSaiSaisuiRow);
                //    addSaiSaisuiRow.AcceptChanges();
                //    addSaiSaisuiRow.SetAdded();

                //    // 登録
                //    IUpdateSaiSaisuiTblBLInput updIn = new UpdateSaiSaisuiTblBLInput();
                //    updIn.SaiSaisuiTblDataTable = saiSaisuiDT;
                //    new UpdateSaiSaisuiTblBusinessLogic().Execute(updIn);
                //}
                #endregion

                #endregion データ更新②

                // 水質検査項目コードを取得
                // pH
                string kensaKomokuCd001 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                // 透視度
                string kensaKomokuCd002 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_002);
                // BOD
                string kensaKomokuCd003 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_003);
                // 残留塩素
                string kensaKomokuCd004 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_004);
                // 塩化物イオン
                string kensaKomokuCd005 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_005);

                KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();
                {
                    // データ更新⑦
                    // pH
                    setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "2", kensaKomokuCd001);
                    // 透視度
                    setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "2", kensaKomokuCd002);
                    // BOD
                    setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "2", kensaKomokuCd003);
                    // 残留塩素(070)
                    setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "2", kensaKomokuCd004, hdrRow.ZanryuEnso);
                    // 塩化物イオン
                    setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "2", kensaKomokuCd005);
                }
                if (kensaDaichoDtlDT.Rows.Count > 0)
                {
                    // 検査台帳明細テーブル登録（明細一括登録）
                    IUpdateKensaDaichoDtlTblBLInput updIn = new UpdateKensaDaichoDtlTblBLInput();
                    updIn.KensaDaichoDtlTblDT = kensaDaichoDtlDT;
                    new UpdateKensaDaichoDtlTblBusinessLogic().Execute(updIn);
                }
            }
        }
        #endregion

        #region UpdateDataSuishitsuKensa
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateDataSuishitsuKensa
        /// <summary>
        /// 検索実行後の更新処理（水質検査用）
        /// ・検査依頼、検査台帳明細、検査結果、再採水テーブル更新
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  小松　　    新規作成
        /// 2014/12/24  小松　　　　水質検査時は、再採水テーブルの操作は不要
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateDataSuishitsuKensa(IKakuteiBtnClickALInput input)
        {
            foreach (SuishitsuKensaIraiDataSet.UketsukeImportListRow hdrRow in input.UketsukeImportListDT)
            {
                // 更新の場合

                // 更新フラグ＝対象の場合のみ登録。以外はスキップ
                if (!hdrRow.KoshinFlg)
                {
                    continue;
                }

                // データ更新⑤

                // 検査依頼テーブル更新
                KensaIraiTblDataSet.KensaIraiTblRow modIraiRow = null;
                {
                    // 検査依頼テーブル取得
                    KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT =
                        Boundary.Common.Common.GetKensaIraiTblByKey(hdrRow.KensaIraiHoteiKbn, hdrRow.KensaIraiHokenjoCd, hdrRow.KensaIraiNendo, hdrRow.KensaIraiRenban);
                    if (kensaIraiDT.Rows.Count <= 0)
                    {
                        continue;
                    }
                    modIraiRow = kensaIraiDT[0];

                    // 楽観ロックチェック
                    if (hdrRow.KensaIraiUpdateDt != modIraiRow.UpdateDt)
                    {
                        // 楽観ロックエラー（更新された最新レコードあり）
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    // 検査依頼テーブル更新
                    // 受付区分
                    modIraiRow.KensaIraiUketsukeKbn = "1";
                    if (hdrRow.MotikomiFlg)
                    {
                        // 1:持込
                        modIraiRow.KensaIraiUketsukeKbn = "1";
                    }
                    else if (hdrRow.ShushuFlg)
                    {
                        // 2:収集
                        modIraiRow.KensaIraiUketsukeKbn = "2";
                    }
                    // 採水員コード
                    modIraiRow.KensaIraiSaisuiinCd = hdrRow.SaisuiinCd;
                    // 検査料金
                    modIraiRow.KensaIraiKensaAmt = hdrRow.KensaIraiKensaAmt;
                    // 入金済金額
                    modIraiRow.KensaIraiNyukinzumiAmt = hdrRow.KensaIraiNyukinzumiAmt;
                    // 発行区分４
                    modIraiRow.KensaIraiHakkoKbn4 = hdrRow.KensaIraiHakkoKbn4;
                    // 発行区分５
                    modIraiRow.KensaIraiHakkoKbn5 = hdrRow.KensaIraiHakkoKbn5;

                    modIraiRow.UpdateDt = _currentDateTime;
                    modIraiRow.UpdateUser = _loginUser;
                    modIraiRow.UpdateTarm = _tarmName;

                    // 更新
                    IUpdateKensaIraiTblBLInput updIn = new UpdateKensaIraiTblBLInput();
                    updIn.KensaIraiTblDataTable = kensaIraiDT;
                    new UpdateKensaIraiTblBusinessLogic().Execute(updIn);
                }

                // 試験項目コード取得
                // 残留塩素(070)
                string kensaKomokuCd004 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_004);

                // 検査台帳明細テーブル更新
                {
                    KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDT = null;
                    ISelectKensaDaichoDtlTblByKeyDAInput selIn = new SelectKensaDaichoDtlTblByKeyDAInput();
                    selIn.Kbn = "2";
                    selIn.IraiNendo = input.IraiNendo;
                    selIn.Sisho = input.ShishoCd;
                    selIn.IraiNo = hdrRow.KentaiNo;
                    selIn.ShikenkoumokuCd = kensaKomokuCd004;
                    selIn.SaikensaKbn = "0";
                    ISelectKensaDaichoDtlTblByKeyDAOutput selOut = new SelectKensaDaichoDtlTblByKeyDAOutput();
                    kensaDaichoDT = new SelectKensaDaichoDtlTblByKeyDataAccess().Execute(selIn).KensaDaichoDtlTblDT;
                    if (kensaDaichoDT.Rows.Count > 0)
                    {
                        KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow modDtlRow = kensaDaichoDT[0];

                        // 楽観ロックチェック
                        if (hdrRow.KensaDaichoDtlUpdateDt != modDtlRow.UpdateDt)
                        {
                            // 楽観ロックエラー（更新された最新レコードあり）
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }

                        // 残留塩素→結果値
                        modDtlRow.KeiryoShomeiKekkaValue = hdrRow.ZanryuEnso;

                        modDtlRow.UpdateDt = _currentDateTime;
                        modDtlRow.UpdateUser = _loginUser;
                        modDtlRow.UpdateTarm = _tarmName;

                        // 更新
                        IUpdateKensaDaichoDtlTblBLInput updIn = new UpdateKensaDaichoDtlTblBLInput();
                        updIn.KensaDaichoDtlTblDT = kensaDaichoDT;
                        new UpdateKensaDaichoDtlTblBusinessLogic().Execute(updIn);
                    }
                }

                // 検査結果テーブル更新
                {
                    KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT = null;
                    ISelectKensaKekkaTblByKeyDAInput selIn = new SelectKensaKekkaTblByKeyDAInput();
                    selIn.KensaKekkaIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                    selIn.KensaKekkaIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                    selIn.KensaKekkaIraiNendo = hdrRow.KensaIraiNendo;
                    selIn.KensaKekkaIraiRenban = hdrRow.KensaIraiRenban;
                    ISelectKensaKekkaTblByKeyDAOutput selOut = new SelectKensaKekkaTblByKeyDAOutput();
                    kensaKekkaDT = new SelectKensaKekkaTblByKeyDataAccess().Execute(selIn).KensaKekkaTblDataTable;
                    if (kensaKekkaDT.Rows.Count > 0)
                    {
                        KensaKekkaTblDataSet.KensaKekkaTblRow modKekkaRow = kensaKekkaDT[0];

                        // 残留塩素濃度
                        modKekkaRow.KensaKekkaZanryuEnsoNodo = (double)hdrRow.ZanryuEnso;
                        // 残留塩素濃度－判定
                        // 019_関数_水質検査判断：検査依頼テーブル.処理方式区分, BOD処理性能
                        modKekkaRow.KensaKekkaZanryuEnsoNodoHantei = SuishitsuUtility.SuishitsuHyokaHantei(
                            modIraiRow.KensaIraiShorihoshikiKbn, modIraiRow.KensaIraiBODShoriSeino,
                            SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso, hdrRow.ZanryuEnso.ToString()).ToString();

                        modKekkaRow.UpdateDt = _currentDateTime;
                        modKekkaRow.UpdateUser = _loginUser;
                        modKekkaRow.UpdateTarm = _tarmName;

                        // 更新
                        IUpdateKensaKekkaTblBLInput updIn = new UpdateKensaKekkaTblBLInput();
                        updIn.KensaKekkaTblDataTable = kensaKekkaDT;
                        new UpdateKensaKekkaTblBusinessLogic().Execute(updIn);
                    }
                }

                #region DELETE 2014/12/24  小松  水質検査時は、再採水テーブルの操作は不要
                //if (hdrRow.SaisaisuiKbn == "1")
                //{
                //    // 検査結果テーブル更新
                //    KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT = null;
                //    ISelectKensaKekkaTblByKeyDAInput selIn = new SelectKensaKekkaTblByKeyDAInput();
                //    selIn.KensaKekkaIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                //    selIn.KensaKekkaIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                //    selIn.KensaKekkaIraiNendo = hdrRow.KensaIraiNendo;
                //    selIn.KensaKekkaIraiRenban = hdrRow.KensaIraiRenban;
                //    ISelectKensaKekkaTblByKeyDAOutput selOut = new SelectKensaKekkaTblByKeyDAOutput();
                //    kensaKekkaDT = new SelectKensaKekkaTblByKeyDataAccess().Execute(selIn).KensaKekkaTblDataTable;
                //    if (kensaKekkaDT.Rows.Count > 0)
                //    {
                //        KensaKekkaTblDataSet.KensaKekkaTblRow modKekkaRow = kensaKekkaDT[0];

                //        // 残留塩素濃度
                //        modKekkaRow.KensaKekkaZanryuEnsoNodo = (double)hdrRow.ZanryuEnso;
                //        // 残留塩素濃度－判定
                //        // 019_関数_水質検査判断：検査依頼テーブル.処理方式区分, BOD処理性能
                //        modKekkaRow.KensaKekkaZanryuEnsoNodoHantei = SuishitsuUtility.SuishitsuHyokaHantei(
                //            modIraiRow.KensaIraiShorihoshikiKbn, modIraiRow.KensaIraiBODShoriSeino,
                //            SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso, hdrRow.ZanryuEnso.ToString()).ToString();

                //        modKekkaRow.UpdateDt = _currentDateTime;
                //        modKekkaRow.UpdateUser = _loginUser;
                //        modKekkaRow.UpdateTarm = _tarmName;

                //        // 更新
                //        IUpdateKensaKekkaTblBLInput updIn = new UpdateKensaKekkaTblBLInput();
                //        updIn.KensaKekkaTblDataTable = kensaKekkaDT;
                //        new UpdateKensaKekkaTblBusinessLogic().Execute(updIn);
                //    }
                //}
                //else
                //{

                //    // 再採水テーブル更新
                //    SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saiSaisuiDT = null;
                //    ISelectSaiSaisuiTblByKeyDAInput selIn = new SelectSaiSaisuiTblByKeyDAInput();
                //    selIn.SaiSaisuiIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                //    selIn.SaiSaisuiIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                //    selIn.SaiSaisuiIraiNendo = hdrRow.KensaIraiNendo;
                //    selIn.SaiSaisuiIraiRrenban = hdrRow.KensaIraiRenban;
                //    ISelectSaiSaisuiTblByKeyDAOutput selOut = new SelectSaiSaisuiTblByKeyDAOutput();
                //    saiSaisuiDT = new SelectSaiSaisuiTblByKeyDataAccess().Execute(selIn).SaiSaisuiTblDataTable;
                //    if (saiSaisuiDT.Rows.Count > 0)
                //    {
                //        SaiSaisuiTblDataSet.SaiSaisuiTblRow modKekkaRow = saiSaisuiDT[0];

                //        // 残留塩素濃度
                //        modKekkaRow.SaiSaisuiZanryuEnsoNodo = (double)hdrRow.ZanryuEnso;
                //        // 残留塩素濃度－判定
                //        // 019_関数_水質検査判断：検査依頼テーブル.処理方式区分, BOD処理性能
                //        modKekkaRow.SaiSaisuiZanryuEnsoNodoHantei = SuishitsuUtility.SuishitsuHyokaHantei(
                //            modIraiRow.KensaIraiShorihoshikiKbn, modIraiRow.KensaIraiBODShoriSeino,
                //            SuishitsuUtility.SuishitsuKensaKbn.Zanryuenso, hdrRow.ZanryuEnso.ToString()).ToString();

                //        modKekkaRow.UpdateDt = _currentDateTime;
                //        modKekkaRow.UpdateUser = _loginUser;
                //        modKekkaRow.UpdateTarm = _tarmName;

                //        // 更新
                //        IUpdateSaiSaisuiTblBLInput updIn = new UpdateSaiSaisuiTblBLInput();
                //        updIn.SaiSaisuiTblDataTable = saiSaisuiDT;
                //        new UpdateSaiSaisuiTblBusinessLogic().Execute(updIn);
                //    }
                //}
                #endregion
            }
        }
        #endregion

        #endregion 水質検査用


        #region 外観検査用

        #region InsertDataGaikanKensa
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InsertDataGaikanKensa
        /// <summary>
        /// 依頼取込後の登録処理（外観検査用）
        /// ・検査依頼テーブル更新、検査台帳ヘッダ追加、検査台帳明細テーブル追加、再採水テーブル追加
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  小松　　    新規作成
        /// 2014/12/24  小松　　　　スクリーングの場合は、再採水テーブルを追加
        /// 2014/12/25  小松　　　　再採水区分の設定値修正
        /// 2014/12/26  小松　　　　再採水テーブルが存在した場合は、更新
        /// 2014/12/28　小松　　　　ステータス更新の判定条件を修正
        /// 2015/01/05　小松　　　　外観受付時は、外観日報、水質日報、請求区分を0にしているが全て不要
        /// 2015/01/08　小松　　　　外観受付時は、結果・再採水テーブルの水質検査依頼番号を更新
        /// 2015/01/11  小松　　　　11条水質のスクリーニングの場合は、処理方式別水質検査実施マスタの内容で登録せず、[pH], [透視度], [BOD], [残留塩素], [塩化物イオン]の明細を固定で登録
        /// 　　　　　　　　　　　　７条、11条外観の場合は、今まで通りに処理方式別水質検査実施マスタに登録されている検査項目を登録
        /// 2015/01/26　小松　　　　再採水の場合は、検査依頼の受付日、検体Noの更新は行わない。
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// 2015/01/29  宗          外観検査時の検査台帳明細の登録項目を変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InsertDataGaikanKensa(IKakuteiBtnClickALInput input)
        {
            foreach (SuishitsuKensaIraiDataSet.UketsukeImportListRow hdrRow in input.UketsukeImportListDT)
            {
                // 新規の場合

                // 更新フラグ＝対象の場合のみ登録。以外はスキップ
                if (!hdrRow.KoshinFlg)
                {
                    continue;
                }

                // データ更新③
                // 検査依頼テーブル取得
                KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiDT =
                    Boundary.Common.Common.GetKensaIraiTblByKey(hdrRow.KensaIraiHoteiKbn, hdrRow.KensaIraiHokenjoCd, hdrRow.KensaIraiNendo, hdrRow.KensaIraiRenban);
                if (kensaIraiDT.Rows.Count <= 0)
                {
                    continue;
                }

                // 存在すれば更新
                KensaIraiTblDataSet.KensaIraiTblRow modHdrRow = kensaIraiDT[0];
                // 検査依頼テーブル更新
                {
                    string kensaKekkaKensaJoukyouKbn = string.Empty;
                    {
                        ISelectKensaKekkaTblByKeyDAInput selKekkaIn = new SelectKensaKekkaTblByKeyDAInput();
                        selKekkaIn.KensaKekkaIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                        selKekkaIn.KensaKekkaIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                        selKekkaIn.KensaKekkaIraiNendo = hdrRow.KensaIraiNendo;
                        selKekkaIn.KensaKekkaIraiRenban = hdrRow.KensaIraiRenban;
                        ISelectKensaKekkaTblByKeyDAOutput selKekkaOut = new SelectKensaKekkaTblByKeyDAOutput();
                        selKekkaOut.KensaKekkaTblDataTable = new SelectKensaKekkaTblByKeyDataAccess().Execute(selKekkaIn).KensaKekkaTblDataTable;
                        if (selKekkaOut.KensaKekkaTblDataTable.Rows.Count > 0)
                        {
                            // 検査状況取得
                            kensaKekkaKensaJoukyouKbn = selKekkaOut.KensaKekkaTblDataTable[0].IsKensaKekkaKensaJoukyouKbnNull() ? string.Empty : selKekkaOut.KensaKekkaTblDataTable[0].KensaKekkaKensaJoukyouKbn;
                        }
                    }

                    // 再採水かどうかの判定
                    // 再採水の場合は、検査依頼の受付日、検体Noの更新は行わない。
                    if (!Utility.Utility.IsSaiSaisuiTarget(hdrRow.KensaIraiHoteiKbn, hdrRow.ScreeningKbn))
                    {
                        // 水質検査依頼番号
                        modHdrRow.KensaIraiSuishitsuIraiNo = hdrRow.KentaiNo;
                        // 水質検査受付日
                        //modHdrRow.KensaIraiSuishitsuUketsukeDt = _nowDtStr;
                        modHdrRow.KensaIraiSuishitsuUketsukeDt = input.KensaIraiUketsukeDt;
                    }

                    //// 検査完了区分 = 3（完了）の場合 → "50"　
                    //if (modHdrRow.KensaIraiKensaKanryoKbn == "3")
                    // 検査結果テーブル．検査状況 = "003"=完了の場合 → "50"。その他はステータスを変更しない。　
                    if (kensaKekkaKensaJoukyouKbn == "003")
                    {
                        // ステータス区分(50:水質検査受付済み)
                        modHdrRow.KensaIraiStatusKbn = FukjBizSystem.Application.Utility.Constants.KensaIraiStatusConstant.STATUS_KENSA_SUISHITSU_KEKKA_UKETUKE_ZUMI;
                    }
                    //// 外観日報区分
                    //modHdrRow.KensaIraiGaikanNippoKbn = "0";
                    //// 水質日報区分
                    //modHdrRow.KensaIraiSuishitsuNippoKbn = "0";
                    //// 請求区分
                    //modHdrRow.KensaIraiSeikyuKbn = "0";

                    modHdrRow.UpdateDt = _currentDateTime;
                    modHdrRow.UpdateUser = _loginUser;
                    modHdrRow.UpdateTarm = _tarmName;

                    // 更新
                    IUpdateKensaIraiTblBLInput updIn = new UpdateKensaIraiTblBLInput();
                    updIn.KensaIraiTblDataTable = kensaIraiDT;
                    new UpdateKensaIraiTblBusinessLogic().Execute(updIn);
                }

                // 検査台帳（11条）ヘッダテーブル追加
                {
                    KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable kensaDaicho11HdrDT = new KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable();
                    KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblRow addHdrRow = kensaDaicho11HdrDT.NewKensaDaicho11joHdrTblRow();

                    // 検査区分(3:外観検査)
                    addHdrRow.KensaKbn = "3";
                    // 依頼年度
                    addHdrRow.IraiNendo = input.IraiNendo;
                    // 支所コード
                    addHdrRow.ShishoCd = input.ShishoCd;
                    // 水質検査依頼番号
                    addHdrRow.SuishitsuKensaIraiNo = hdrRow.KentaiNo;
                    // スクリーニング区分が0の場合
                    if (hdrRow.ScreeningKbn == "0")
                    {
                        // 再採水区分
                        //addHdrRow.SaisaisuiKbn = "1";
                        addHdrRow.SaisaisuiKbn = "0";
                    }
                    else
                    {
                        // 再採水区分
                        //addHdrRow.SaisaisuiKbn = "2";
                        addHdrRow.SaisaisuiKbn = "1";
                    }
                    // 検査依頼法定区分
                    addHdrRow.KensaKekkaIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                    // 検査依頼保健所コード
                    addHdrRow.KensaKekkaIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                    // 検査依頼年度
                    addHdrRow.KensaKekkaIraiNendo = hdrRow.KensaIraiNendo;
                    // 検査依頼連番
                    addHdrRow.KensaKekkaIraiRenban = hdrRow.KensaIraiRenban;
                    // スクリーニング候補
                    addHdrRow.ScreeningKoho = "0";
                    // フォロー候補
                    addHdrRow.FollowKoho = "0";
                    // クロスチェック異常（水質判定表）
                    addHdrRow.CrossCheckSuishitsu = "0";
                    // クロスチェック異常（過去履歴）
                    addHdrRow.CrossCheckKako = "0";
                    // 判定コード
                    addHdrRow.HanteiCd = "0";
                    // 結果確定日
                    addHdrRow.KensaKekkaKakuteiDt = string.Empty;
                    // 課長検印区分
                    addHdrRow.KachoKeninKbn = "0";
                    // 課長検印区分（再採水）
                    addHdrRow.KachoKeninKbnScreening = "0";
                    // 副課長検印区分
                    addHdrRow.HukuKachoKeninKbn = "0";
                    // 副課長検印区分（再採水）
                    addHdrRow.HukuKachoKeninKbnScreening = "0";
                    // 検査依頼受付日
                    //addHdrRow.KensaIraiUketsukeDt = _nowDtStr;
                    addHdrRow.KensaIraiUketsukeDt = input.KensaIraiUketsukeDt;
                    // 塩化物イオン過去１
                    addHdrRow.EnkaIonKako1 = 0;
                    // 塩化物イオン過去２
                    addHdrRow.EnkaIonKako2 = 0;
                    // 塩化物イオン過去３
                    addHdrRow.EnkaIonKako3 = 0;
                    // 塩化物イオン過去４
                    addHdrRow.EnkaIonKako4 = 0;
                    // 塩化物イオン過去５
                    addHdrRow.EnkaIonKako5 = 0;

                    addHdrRow.InsertDt = _currentDateTime;
                    addHdrRow.InsertUser = _loginUser;
                    addHdrRow.InsertTarm = _tarmName;
                    addHdrRow.UpdateDt = _currentDateTime;
                    addHdrRow.UpdateUser = _loginUser;
                    addHdrRow.UpdateTarm = _tarmName;

                    kensaDaicho11HdrDT.AddKensaDaicho11joHdrTblRow(addHdrRow);
                    addHdrRow.AcceptChanges();
                    addHdrRow.SetAdded();

                    // 登録
                    IUpdateKensaDaicho11joHdrTblBLInput updIn = new UpdateKensaDaicho11joHdrTblBLInput();
                    updIn.KensaDaicho11joHdrTblDataTable = kensaDaicho11HdrDT;
                    new UpdateKensaDaicho11joHdrTblBusinessLogic().Execute(updIn);
                }

                // 20150129 sou Start
                // 水質検査項目コードを取得
                //// pH
                //string kensaKomokuCd001 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                //// 透視度
                //string kensaKomokuCd002 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_002);
                //// BOD
                //string kensaKomokuCd003 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_003);
                //// 残留塩素
                //string kensaKomokuCd004 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_004);
                //// 塩化物イオン
                //string kensaKomokuCd005 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_005);

                // 検査検査項目コードを取得
                // BOD
                string kensaKomokuCd001 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_078, Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                // 塩化物イオン
                string kensaKomokuCd002 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_078, Constants.ConstRenbanConstanst.CONST_RENBAN_002);
                // ATUBOD
                string kensaKomokuCd003 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_078, Constants.ConstRenbanConstanst.CONST_RENBAN_003);
                // 20150129 sou End

                // 検査依頼が11条水質のスクリーニングか
                if (Utility.Utility.IsSaiSaisuiTarget(modHdrRow.KensaIraiHoteiKbn, modHdrRow.KensaIraiScreeningKbn))
                {
                    // 11条水質のスクリーニング
                    // 11条水質と同じ検査項目を登録

                    KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();
                    {
                        // データ更新⑦
                        // 20150129 sou Start
                        //// pH
                        //setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", kensaKomokuCd001);
                        //// 透視度
                        //setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", kensaKomokuCd002, hdrRow.Toshido);
                        //// BOD
                        //setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", kensaKomokuCd003);
                        //// 残留塩素(070)
                        //setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", kensaKomokuCd004);
                        //// 塩化物イオン
                        //setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", kensaKomokuCd005);
                        // BOD
                        setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", kensaKomokuCd001);
                        // 塩化物イオン
                        setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", kensaKomokuCd002);
                        // ATUBOD
                        setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", kensaKomokuCd003);
                        // 20150129 sou End
                    }
                    if (kensaDaichoDtlDT.Rows.Count > 0)
                    {
                        // 検査台帳明細テーブル登録（明細一括登録）
                        IUpdateKensaDaichoDtlTblBLInput updIn = new UpdateKensaDaichoDtlTblBLInput();
                        updIn.KensaDaichoDtlTblDT = kensaDaichoDtlDT;
                        new UpdateKensaDaichoDtlTblBusinessLogic().Execute(updIn);
                    }
                }
                else
                {
                    // 11条水質＋スクリーニング以外（７条、11条外観）
                    // 処理方式別水質検査実施マスタに登録されている検査項目を登録

                    // 処理方式別水質検査実施マスタの情報を取得する
                    // データ検索⑫
                    ISelectSuishitsuKensaJisshiKomokuInfoDAInput selIn = new SelectSuishitsuKensaJisshiKomokuInfoDAInput();
                    selIn.KensaIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                    selIn.KensaIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                    selIn.KensaIraiNendo = hdrRow.KensaIraiNendo;
                    selIn.KensaIraiRenban = hdrRow.KensaIraiRenban;
                    ISelectSuishitsuKensaJisshiKomokuInfoDAOutput selOut = new SelectSuishitsuKensaJisshiKomokuInfoDAOutput();
                    selOut.KensaKomokuInfoDT = new SelectSuishitsuKensaJisshiKomokuInfoDataAccess().Execute(selIn).KensaKomokuInfoDT;

                    // 検査台帳明細テーブルに登録する
                    {
                        KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();

                        // データ検索⑫で取得した件数分処理を繰返
                        foreach (SuishitsuKensaUketsukeDataSet.SuishitsuKensaJisshiKomokuInfoRow komokuRow in selOut.KensaKomokuInfoDT)
                        {
                            // 20150129 sou Start
                            //if (komokuRow.KensaKomokuCd == kensaKomokuCd001 || komokuRow.KensaKomokuCd == kensaKomokuCd003 ||
                            //    komokuRow.KensaKomokuCd == kensaKomokuCd004 || komokuRow.KensaKomokuCd == kensaKomokuCd005)
                            //{
                            //    // pH、BOD、残留塩素、塩化物イオン
                            //    // データ更新⑦
                            //    setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", komokuRow.KensaKomokuCd);
                            //}
                            //else if (komokuRow.KensaKomokuCd == kensaKomokuCd002)
                            //{
                            //    // 透視度(082)
                            //    // データ更新⑦
                            //    setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", komokuRow.KensaKomokuCd, hdrRow.Toshido);
                            //}
                            if (komokuRow.KensaKomokuCd == kensaKomokuCd001 
                                || komokuRow.KensaKomokuCd == kensaKomokuCd002 
                                || komokuRow.KensaKomokuCd == kensaKomokuCd003)
                            {
                                // BOD、塩化物イオン、ATUBOD
                                // データ更新⑦
                                setKensaDaichoDtlRow(input, kensaDaichoDtlDT, hdrRow, "3", komokuRow.KensaKomokuCd);
                            }
                            // 20150129 sou End
                        }

                        if (kensaDaichoDtlDT.Rows.Count > 0)
                        {
                            // 検査台帳明細テーブル登録（明細一括登録）
                            IUpdateKensaDaichoDtlTblBLInput updIn = new UpdateKensaDaichoDtlTblBLInput();
                            updIn.KensaDaichoDtlTblDT = kensaDaichoDtlDT;
                            new UpdateKensaDaichoDtlTblBusinessLogic().Execute(updIn);
                        }
                    }
                }

                // スクリーニング区分が 0以外の場合
                if (hdrRow.ScreeningKbn != "0")
                {
                    // 再採水テーブルレコードチェック
                    SaiSaisuiTblDataSet.SaiSaisuiTblDataTable chkSaiSaisuiDT = null;
                    ISelectSaiSaisuiTblByKeyDAInput selSaiIn = new SelectSaiSaisuiTblByKeyDAInput();
                    selSaiIn.SaiSaisuiIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                    selSaiIn.SaiSaisuiIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                    selSaiIn.SaiSaisuiIraiNendo = hdrRow.KensaIraiNendo;
                    selSaiIn.SaiSaisuiIraiRrenban = hdrRow.KensaIraiRenban;
                    ISelectSaiSaisuiTblByKeyDAOutput selSaiOut = new SelectSaiSaisuiTblByKeyDAOutput();
                    chkSaiSaisuiDT = new SelectSaiSaisuiTblByKeyDataAccess().Execute(selSaiIn).SaiSaisuiTblDataTable;
                    if (chkSaiSaisuiDT.Rows.Count > 0)
                    {
                        // 再採水テーブル更新

                        SaiSaisuiTblDataSet.SaiSaisuiTblRow modSaiSaisuiRow = chkSaiSaisuiDT[0];

                        // 水質検査依頼番号
                        modSaiSaisuiRow.SaiSaisuiSuishitsuIraiNo = hdrRow.KentaiNo;
                        // 透視度（度）
                        modSaiSaisuiRow.SaiSaisuiToshido = (double)hdrRow.Toshido;
                        // 019_関数_水質検査判断：検査依頼テーブル.処理方式区分, BOD処理性能
                        modSaiSaisuiRow.SaiSaisuiToshidoHantei = SuishitsuUtility.SuishitsuHyokaHantei(
                            modHdrRow.KensaIraiShorihoshikiKbn, modHdrRow.KensaIraiBODShoriSeino,
                            SuishitsuUtility.SuishitsuKensaKbn.Toshido, hdrRow.Toshido.ToString()).ToString();

                        modSaiSaisuiRow.UpdateDt = _currentDateTime;
                        modSaiSaisuiRow.UpdateUser = _loginUser;
                        modSaiSaisuiRow.UpdateTarm = _tarmName;

                        // 更新
                        IUpdateSaiSaisuiTblBLInput updIn = new UpdateSaiSaisuiTblBLInput();
                        updIn.SaiSaisuiTblDataTable = chkSaiSaisuiDT;
                        new UpdateSaiSaisuiTblBusinessLogic().Execute(updIn);
                    }
                    else
                    {
                        // 再採水テーブル追加

                        SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saiSaisuiDT = new SaiSaisuiTblDataSet.SaiSaisuiTblDataTable();
                        SaiSaisuiTblDataSet.SaiSaisuiTblRow addSaiSaisuiRow = saiSaisuiDT.NewSaiSaisuiTblRow();

                        // 検査依頼法定区分
                        addSaiSaisuiRow.SaiSaisuiIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                        // 検査依頼保健所コード
                        addSaiSaisuiRow.SaiSaisuiIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                        // 検査依頼年度
                        addSaiSaisuiRow.SaiSaisuiIraiNendo = hdrRow.KensaIraiNendo;
                        // 検査依頼連番
                        addSaiSaisuiRow.SaiSaisuiIraiRrenban = hdrRow.KensaIraiRenban;
                        // 温度
                        addSaiSaisuiRow.SaiSaisuiOndo = 0;
                        // 水素イオン濃度
                        //addSaiSaisuiRow.SaiSaisuiSuisoIonNodo = 0;
                        addSaiSaisuiRow.SetSaiSaisuiSuisoIonNodoNull();
                        // 水素イオン濃度ー判定
                        addSaiSaisuiRow.SaiSaisuiSuisoIonNodoHantei = string.Empty;
                        // 汚泥沈殿率（％）
                        //addSaiSaisuiRow.SaiSaisuiOdeichindenritsu = 0;
                        addSaiSaisuiRow.SetSaiSaisuiOdeichindenritsuNull();
                        // 汚泥沈殿率２
                        addSaiSaisuiRow.SaiSaisuiOdeichindenritsu2 = string.Empty;
                        // 汚泥沈殿率ー判定
                        addSaiSaisuiRow.SaiSaisuiOdeichindenritsuHantei = string.Empty;
                        // 溶存酸素量１
                        //addSaiSaisuiRow.SaiSaisuiYozonSansoryo1 = 0;
                        addSaiSaisuiRow.SetSaiSaisuiYozonSansoryo1Null();
                        // 溶存酸素量２
                        //addSaiSaisuiRow.SaiSaisuiYozonSansoryo2 = 0;
                        addSaiSaisuiRow.SetSaiSaisuiYozonSansoryo2Null();
                        // 溶存酸素量ー判定
                        addSaiSaisuiRow.SaiSaisuiYozonSansoryoHantei = string.Empty;
                        // 亜硝酸性窒素
                        //addSaiSaisuiRow.SaiSaisuiAshosanseichisso = string.Empty;
                        addSaiSaisuiRow.SetSaiSaisuiAshosanseichissoNull();
                        // 亜硝酸性窒素ー判定
                        addSaiSaisuiRow.SaiSaisuiAshosanseichissoHantei = string.Empty;
                        // 透視度（度）
                        addSaiSaisuiRow.SaiSaisuiToshido = (double)hdrRow.Toshido;
                        // 透視度２
                        addSaiSaisuiRow.SaiSaisuiToshido2 = string.Empty;
                        // 透視度ー判定
                        //addSaiSaisuiRow.SaiSaisuiToshidoHantei = string.Empty;
                        // 019_関数_水質検査判断：検査依頼テーブル.処理方式区分, BOD処理性能
                        addSaiSaisuiRow.SaiSaisuiToshidoHantei = SuishitsuUtility.SuishitsuHyokaHantei(
                            modHdrRow.KensaIraiShorihoshikiKbn, modHdrRow.KensaIraiBODShoriSeino,
                            SuishitsuUtility.SuishitsuKensaKbn.Toshido, hdrRow.Toshido.ToString()).ToString();
                        // 透視度（度）２次処理水
                        //addSaiSaisuiRow.SaiSaisuiToshido2jishorisui = 0;
                        addSaiSaisuiRow.SetSaiSaisuiToshido2jishorisuiNull();
                        // 透視度２２次処理水
                        addSaiSaisuiRow.SaiSaisuiToshido22jishorisui = string.Empty;
                        // 透視度ー判定２次処理水
                        addSaiSaisuiRow.SaiSaisuiToshidoHantei2jishorisui = string.Empty;
                        // 塩化イオン濃度
                        //addSaiSaisuiRow.SaiSaisuiEnkaIonNodo = 0;
                        addSaiSaisuiRow.SetSaiSaisuiEnkaIonNodoNull();
                        // 塩化イオン濃度ー判定
                        addSaiSaisuiRow.SaiSaisuiEnkaIonNodoHantei = string.Empty;
                        // 塩化イオン濃度２
                        addSaiSaisuiRow.SaiSaisuiEnkaIonNodo2 = string.Empty;
                        // 残留塩素濃度
                        //addSaiSaisuiRow.SaiSaisuiZanryuEnsoNodo = 0;
                        addSaiSaisuiRow.SetSaiSaisuiZanryuEnsoNodoNull();
                        // 残留塩素濃度ー判定
                        addSaiSaisuiRow.SaiSaisuiZanryuEnsoNodoHantei = string.Empty;
                        // 生物化学酸素要求量
                        //addSaiSaisuiRow.SaiSaisuiBOD = 0;
                        addSaiSaisuiRow.SetSaiSaisuiBODNull();
                        // 生物化学酸素要求量ー判定
                        addSaiSaisuiRow.SaiSaisuiBODHantei = string.Empty;
                        // 生物化学酸素要求量２
                        addSaiSaisuiRow.SaiSaisuiBOD2 = string.Empty;
                        // ＭＬＳＳ
                        //addSaiSaisuiRow.SaiSaisuiMLSS = 0;
                        addSaiSaisuiRow.SetSaiSaisuiMLSSNull();
                        // ＭＬＳＳ－判定
                        addSaiSaisuiRow.SaiSaisuiMLSSHantei = string.Empty;
                        // 水質検査（測定不能）
                        addSaiSaisuiRow.SaiSaisuiSuishitsuSokuteifuno = string.Empty;
                        // 水質検査依頼番号
                        //addSaiSaisuiRow.SaiSaisuiSuishitsuIraiNo = string.Empty;
                        addSaiSaisuiRow.SaiSaisuiSuishitsuIraiNo = hdrRow.KentaiNo;
                        // 再採水日
                        addSaiSaisuiRow.SaiSaisuiDt = string.Empty;
                        // ATUBOD
                        //addSaiSaisuiRow.SaiSaisuiATUBOD = 0;
                        addSaiSaisuiRow.SetSaiSaisuiATUBODNull();
                        // ATUBOD２
                        addSaiSaisuiRow.SaiSaisuiATUBOD2 = string.Empty;

                        addSaiSaisuiRow.InsertDt = _currentDateTime;
                        addSaiSaisuiRow.InsertUser = _loginUser;
                        addSaiSaisuiRow.InsertTarm = _tarmName;
                        addSaiSaisuiRow.UpdateDt = _currentDateTime;
                        addSaiSaisuiRow.UpdateUser = _loginUser;
                        addSaiSaisuiRow.UpdateTarm = _tarmName;

                        saiSaisuiDT.AddSaiSaisuiTblRow(addSaiSaisuiRow);
                        addSaiSaisuiRow.AcceptChanges();
                        addSaiSaisuiRow.SetAdded();

                        // 登録
                        IUpdateSaiSaisuiTblBLInput updIn = new UpdateSaiSaisuiTblBLInput();
                        updIn.SaiSaisuiTblDataTable = saiSaisuiDT;
                        new UpdateSaiSaisuiTblBusinessLogic().Execute(updIn);
                    }
                }
                else
                {
                    // 検査結果テーブル更新
                    KensaKekkaTblDataSet.KensaKekkaTblDataTable kensaKekkaDT = null;
                    ISelectKensaKekkaTblByKeyDAInput selKekkaIn = new SelectKensaKekkaTblByKeyDAInput();
                    selKekkaIn.KensaKekkaIraiHoteiKbn = hdrRow.KensaIraiHoteiKbn;
                    selKekkaIn.KensaKekkaIraiHokenjoCd = hdrRow.KensaIraiHokenjoCd;
                    selKekkaIn.KensaKekkaIraiNendo = hdrRow.KensaIraiNendo;
                    selKekkaIn.KensaKekkaIraiRenban = hdrRow.KensaIraiRenban;
                    kensaKekkaDT = new SelectKensaKekkaTblByKeyDataAccess().Execute(selKekkaIn).KensaKekkaTblDataTable;
                    if (kensaKekkaDT.Rows.Count > 0)
                    {
                        KensaKekkaTblDataSet.KensaKekkaTblRow modKekkaRow = kensaKekkaDT[0];

                        // 水質検査依頼番号
                        modKekkaRow.KensaKekkaSuishitsuIraiNo = hdrRow.KentaiNo;
                        // 透視度（度）
                        modKekkaRow.KensaKekkaToshido = (double)hdrRow.Toshido;
                        // 019_関数_水質検査判断：検査依頼テーブル.処理方式区分, BOD処理性能
                        modKekkaRow.KensaKekkaToshidoHantei = SuishitsuUtility.SuishitsuHyokaHantei(
                            modHdrRow.KensaIraiShorihoshikiKbn, modHdrRow.KensaIraiBODShoriSeino,
                            SuishitsuUtility.SuishitsuKensaKbn.Toshido, hdrRow.Toshido.ToString()).ToString();

                        modKekkaRow.UpdateDt = _currentDateTime;
                        modKekkaRow.UpdateUser = _loginUser;
                        modKekkaRow.UpdateTarm = _tarmName;

                        // 更新
                        IUpdateKensaKekkaTblBLInput updKekkaIn = new UpdateKensaKekkaTblBLInput();
                        updKekkaIn.KensaKekkaTblDataTable = kensaKekkaDT;
                        new UpdateKensaKekkaTblBusinessLogic().Execute(updKekkaIn);
                    }
                }
            }
        }
        #endregion

        #region UpdateDataGaikanKensa
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateDataGaikanKensa
        /// <summary>
        /// 検索実行後の更新処理（外観検査用）
        /// ・検査台帳明細テーブル更新
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateDataGaikanKensa(IKakuteiBtnClickALInput input)
        {
            // 検索実行後の更新処理（外観検査用）
            foreach (SuishitsuKensaIraiDataSet.UketsukeImportListRow hdrRow in input.UketsukeImportListDT)
            {
                // 更新の場合

                // 更新フラグ＝対象の場合のみ更新。以外はスキップ
                if (!hdrRow.KoshinFlg)
                {
                    continue;
                }

                // 試験項目コード取得
                // 透視度(082)
                string kensaKomokuCd002 = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_002);

                // 検査台帳明細テーブル更新
                {
                    KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDT = null;
                    ISelectKensaDaichoDtlTblByKeyDAInput selIn = new SelectKensaDaichoDtlTblByKeyDAInput();
                    selIn.Kbn = "3";
                    selIn.IraiNendo = input.IraiNendo;
                    selIn.Sisho = input.ShishoCd;
                    selIn.IraiNo = hdrRow.KentaiNo;
                    selIn.ShikenkoumokuCd = kensaKomokuCd002;
                    selIn.SaikensaKbn = "0";
                    ISelectKensaDaichoDtlTblByKeyDAOutput selOut = new SelectKensaDaichoDtlTblByKeyDAOutput();
                    kensaDaichoDT = new SelectKensaDaichoDtlTblByKeyDataAccess().Execute(selIn).KensaDaichoDtlTblDT;
                    if (kensaDaichoDT.Rows.Count > 0)
                    {
                        KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow modDtlRow = kensaDaichoDT[0];

                        // 楽観ロックチェック
                        if (hdrRow.KensaDaichoDtlUpdateDt != modDtlRow.UpdateDt)
                        {
                            // 楽観ロックエラー（更新された最新レコードあり）
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }

                        // 透視度→結果値
                        modDtlRow.KeiryoShomeiKekkaValue = hdrRow.Toshido;

                        modDtlRow.UpdateDt = _currentDateTime;
                        modDtlRow.UpdateUser = _loginUser;
                        modDtlRow.UpdateTarm = _tarmName;

                        // 更新
                        IUpdateKensaDaichoDtlTblBLInput updIn = new UpdateKensaDaichoDtlTblBLInput();
                        updIn.KensaDaichoDtlTblDT = kensaDaichoDT;
                        new UpdateKensaDaichoDtlTblBusinessLogic().Execute(updIn);
                    }
                }
            }
        }
        #endregion

        #endregion 外観検査用

        #region 検査台帳明細のレコードセット
        // データ更新⑦
        private void setKensaDaichoDtlRow(IKakuteiBtnClickALInput input,
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable kensaDaichoDtlDT,
            SuishitsuKensaIraiDataSet.UketsukeImportListRow hdrRow,
            string kensaKbn,
            string kensaKomokuCd,
            decimal kekkaValue = 0)
        {
            // データ更新⑦
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow addDtlRow = kensaDaichoDtlDT.NewKensaDaichoDtlTblRow();

            // 検査区分（1:計量証明/2:水質検査/3:外観検査)）
            addDtlRow.KensaKbn = kensaKbn;
            // 依頼年度
            addDtlRow.IraiNendo = input.IraiNendo;
            // 支所コード
            addDtlRow.ShishoCd = input.ShishoCd;
            // 水質検査依頼番号
            addDtlRow.SuishitsuKensaIraiNo = hdrRow.KentaiNo;
            // 試験項目コード
            addDtlRow.ShikenkoumokuCd = kensaKomokuCd;
            // 再検査回数
            addDtlRow.SaikensaKbn = "0";
            // 確認検査種別
            addDtlRow.KensaShubetsu = string.Empty;
            // 確認検査種別（BOD/透視度）
            addDtlRow.KensaShubetsuBodTr = "0";
            // 確認検査種別（過去との比較）
            addDtlRow.KensaShubetsuKako = "0";
            // 確認検査種別（BOD基準値オーバー）
            addDtlRow.KensaShubetsuBodOver = "0";
            // 確認検査種別（塩化物イオン確認検査）
            addDtlRow.KensaShubetsuEnkaIon = "0";
            // 確認検査種別（SS/透視度）
            addDtlRow.KensaShubetsuSsTr = "0";
            // 確認検査種別（アンモニア確認検査）
            addDtlRow.KensaShubetsuAnmonia = "0";
            // 確認検査種別（アンモニアと全窒素比較）
            addDtlRow.KensaShubetsuAnmoniaTn = "0";
            // 確認検査種別（COD基準値オーバー）
            addDtlRow.KensaShubetsuCodOver = "0";
            // 結果値
            addDtlRow.KeiryoShomeiKekkaValue = kekkaValue;
            // 結果値２
            addDtlRow.KeiryoShomeiKekkaValue2 = "0";
            // 結果コード
            addDtlRow.KeiryoShomeiKekkaCd = "0";
            // 温度数
            addDtlRow.KeiryoShomeiKekkaOndo = 0;
            // 結果入力
            addDtlRow.KeiryoShomeiKekkaNyuryoku = "0";
            // 外部委託フラグ
            addDtlRow.KeiryoShomeiGaibuItakuFlg = "0";
            // 採用区分
            addDtlRow.KeiryoShomeiSaiyoKbn = "1";
            // 確認検査の措置
            addDtlRow.KakuninKensaSoti = "0";
            // 課長検印区分
            addDtlRow.KachoKeninKbn = "0";
            // 副課長検印区分
            addDtlRow.HukuKachoKeninKbn = "0";
            // 計量管理者検印区分
            addDtlRow.KeiryoKanrishaKeninKbn = "0";
            // 野帳記入確認区分
            addDtlRow.YachoKinyuKakuninKbn = "0";

            addDtlRow.InsertDt = _currentDateTime;
            addDtlRow.InsertUser = _loginUser;
            addDtlRow.InsertTarm = _tarmName;
            addDtlRow.UpdateDt = _currentDateTime;
            addDtlRow.UpdateUser = _loginUser;
            addDtlRow.UpdateTarm = _tarmName;

            kensaDaichoDtlDT.AddKensaDaichoDtlTblRow(addDtlRow);
            addDtlRow.AcceptChanges();
            addDtlRow.SetAdded();
        }
        #endregion

        #endregion メソッド(private)
    }
    #endregion
}
