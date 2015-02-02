using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiInput;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiInput
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
    /// 2014/09/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 検査年度
        /// </summary>
        string KensaNendoTxt { get; set; }

        /// <summary>
        /// 検査依頼一覧
        /// </summary>
        DataGridView KensaIraiListDgv { get; set; }
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
    /// 2014/09/24　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALInput : IKakuteiBtnClickALInput
    {
        /// <summary>
        /// 検査年度
        /// </summary>
        public string KensaNendoTxt { get; set; }

        /// <summary>
        /// 検査依頼一覧
        /// </summary>
        public DataGridView KensaIraiListDgv { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査年度[{0}]", KensaNendoTxt);
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
    /// 2014/09/24　AnhNV　　    新規作成
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
    /// 2014/09/24　AnhNV　　    新規作成
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
    /// 2014/09/24　AnhNV　　    新規作成
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
        private const string FunctionName = "JinendoGaikanKensaYoteiInput：KakuteiBtnClick";

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
        /// 2014/09/24　AnhNV　　    新規作成
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
        /// 2014/09/24　AnhNV　　    新規作成
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
        /// 2014/09/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuteiBtnClickALOutput Execute(IKakuteiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuteiBtnClickALOutput output = new KakuteiBtnClickALOutput();

            try
            {
                // Preparing data for update
                KensaIraiTblDataSet.KensaIraiTblDataTable updateTable = MakeUpdateData(input);

                // トランザクション開始
                StartTransaction();

                IUpdateKensaIraiTblBLInput blInput = new UpdateKensaIraiTblBLInput();
                blInput.KensaIraiTblDataTable = updateTable;
                new UpdateKensaIraiTblBusinessLogic().Execute(blInput);

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

        #endregion

        #region メソッド(private)

        #region MakeUpdateData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeUpdateData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable MakeUpdateData(IKakuteiBtnClickALInput input)
        {
            // Initiator
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTblTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();
            JokasoDaichoMstDataSet.JinendoInputUpdateDataTable jinendoTable = new JokasoDaichoMstDataSet.JinendoInputUpdateDataTable();
            IGetJinendoInputUpdateByKbnCdBLInput jinInput = new GetJinendoInputUpdateByKbnCdBLInput();

            // Current system date
            DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
            // Login name
            string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Machine name
            string hostname = Dns.GetHostName();

            foreach (DataGridViewRow dgvr in input.KensaIraiListDgv.Rows)
            {
                // 検査依頼法定区分(10) is blank
                if (dgvr.Cells["kensaIraiHoteiKbnCol"].Value == null || string.IsNullOrEmpty(dgvr.Cells["kensaIraiHoteiKbnCol"].Value.ToString().Trim()))
                {
                    // 設置者区分(14)
                    jinInput.JokasoSetchishaKbn = dgvr.Cells["settisyaKbnCol"].Value.ToString();

                    // 設置者コード(15)
                    jinInput.JokasoSetchishaCd = dgvr.Cells["setchishaCdCol"].Value.ToString();

                    // Execute
                    IGetJinendoInputUpdateByKbnCdBLOutput jinOutput = new GetJinendoInputUpdateByKbnCdBusinessLogic().Execute(jinInput);

                    // Bind 予定月(16) value to output table
                    foreach (JokasoDaichoMstDataSet.JinendoInputUpdateRow row in jinOutput.JinendoInputUpdateDataTable)
                    {
                        // 予定月(16)
                        row.KensaIraiNendoCol = dgvr.Cells["nendoCol"].Value.ToString();
                    }

                    // Merge to result table
                    jinendoTable.Merge(jinOutput.JinendoInputUpdateDataTable);
                }
                else
                {
                    // Make update tables
                    kensaIraiTblTable.Merge(CreateKensaIraiTblUpdate(dgvr, now, input.KensaNendoTxt, username, hostname));
                }
            }

            // Merge Insert table
            if (jinendoTable.Count > 0)
            {
                kensaIraiTblTable.Merge(CreateKensaIraiTblInsert(now, jinendoTable, input.KensaNendoTxt, username, hostname));
            }

            return kensaIraiTblTable;
        }
        #endregion

        #region CreateKensaIraiTblInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="table"></param>
        /// <param name="kensaNendoTxt"></param>
        /// <param name="username"></param>
        /// <param name="hostname"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblInsert
            (
                DateTime now,
                JokasoDaichoMstDataSet.JinendoInputUpdateDataTable table,
                string kensaNendoTxt,
                string username,
                string hostname
            )
        {
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            // For checking new row
            string tempSetchisaKbn = string.Empty;
            string tempSetchisaCd = string.Empty;
            // 検査日
            string maxKensaDt = string.Empty;
            // ShishoCd of login user
            string shishoCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinShozokuShishoCd;

            foreach (JokasoDaichoMstDataSet.JinendoInputUpdateRow row in table)
            {
                // 検査日
                if (tempSetchisaKbn != row.JokasoSetchishaKbn || tempSetchisaCd != row.JokasoSetchishaCd)
                {
                    maxKensaDt = (string)table.Compute("max(KensaDt)", string.Format("JokasoSetchishaKbn='{0}' and JokasoSetchishaCd='{1}'", row.JokasoSetchishaKbn, row.JokasoSetchishaCd));
                }

                // Create a new KensaIraiTbl row
                KensaIraiTblDataSet.KensaIraiTblRow newRow = kensaTable.NewKensaIraiTblRow();

                // 検査依頼法定区分
                newRow.KensaIraiHoteiKbn = "2";
                // 検査依頼保健所コード
                newRow.KensaIraiHokenjoCd = row.JokasoHokenjoCd;
                // 検査依頼年度
                newRow.KensaIraiNendo = kensaNendoTxt;
                // 検査依頼連番
                newRow.KensaIraiRenban = Utility.Saiban.GetKeyRenban("KensaIraiTbl", "2", row.JokasoHokenjoCd, kensaNendoTxt);
                // 検査依頼受付支所
                newRow.KensaIraiUketsukeShishoKbn = shishoCd;
                // 検査依頼支店区分
                //newRow.KensaIraiShitenKbn = string.Empty;
                // 浄化槽保健所コード
                newRow.KensaIraiJokasoHokenjoCd = row.JokasoHokenjoCd;
                // 浄化槽台帳登録年度
                newRow.KensaIraiJokasoTorokuNendo = row.JokasoTorokuNendo;
                // 浄化槽台帳連番
                newRow.KensaIraiJokasoRenban = row.JokasoRenban;
                //// 水質検査受付日
                //newRow.KensaIraiSuishitsuUketsukeDt = string.Empty;
                //// 新方式区分
                //newRow.KensaIraiShinHoshikiKbn = string.Empty;
                //// スクリーニング区分
                //newRow.KensaIraiScreeningKbn = string.Empty;
                //// 受付区分
                //newRow.KensaIraiUketsukeKbn = string.Empty;
                //// 現金収入区分
                //newRow.KensaIraiGenkinShunyuKbn = string.Empty;
                // 法根拠区分
                newRow.KensaIraiHokonkyoKbn = row.JokasoHouKonkyoKbn;
                // 保健所受理保健所コード
                newRow.KensaIraiHokenjoJyuriHokenjoCd = row.JokasoHokenjoJuriNoHokenCd;
                // 保健所受理年度
                newRow.KensaIraiHokenjoJyuriNendo = row.JokasoHokenjoJuriNoNendo;
                // 保健所受理市町村コード
                newRow.KensaIraiHokenjoJyuriShichosonCd = row.JokasoHokenjoJuriNoSichosonCd;
                // 保健所受理連番
                newRow.KensaIraiHokenjoJyuriRenban = row.JokasoHokenjoJuriNoRenban;
                // 保証登録検査機関
                newRow.KensaIraiHoshoTorokuKensakikanCd = row.JokasoHoshoNoKensakikan;
                // 保証登録年度
                newRow.KensaIraiHoshoTorokuNendo = row.JokasoHoshoNoNendo;
                // 保証登録連番
                newRow.KensaIraiHoshoTorokuRenban = row.JokasoHoshoNoRenban;
                // 依頼年
                newRow.KensaIraiNen = now.ToString("yyyy");
                // 依頼月
                newRow.KensaIraiTsuki = now.ToString("MM");
                // 依頼日
                newRow.KensaIraiBi = now.ToString("dd");
                //// 検査年
                //newRow.KensaIraiKensaNen = string.Empty;
                //// 検査月
                //newRow.KensaIraiKensaTsuki = string.Empty;
                //// 検査日
                //newRow.KensaIraiKensaBi = string.Empty;
                // 検査予定年
                newRow.KensaIraiKensaYoteiNen = kensaNendoTxt;
                // 検査予定月
                newRow.KensaIraiKensaYoteiTsuki = row.KensaIraiNendoCol;
                // 検査予定日
                newRow.KensaIraiKensaYoteiBi = "01";
                //// 取下年
                //newRow.KensaIraiTorisageNen = string.Empty;
                //// 取下月
                //newRow.KensaIraiTorisageTsuki = string.Empty;
                //// 取下日
                //newRow.KensaIraiTorisageBi = string.Empty;
                // 検査料金
                newRow.KensaIraiKensaAmt = row.KensaAmt;
                //// 前渡還付金
                //newRow.KensaIraiMaewatashiKanpuAmt = string.Empty;
                //// 合計金額
                //newRow.KensaIraiGokeiAmt = string.Empty;
                //// 入金済金額
                //newRow.KensaIraiNyukinzumiAmt = string.Empty;
                //// 入金方法
                //newRow.KensaIraiNyukinHohoKbn = string.Empty;
                //// 最終入金年
                //newRow.KensaIraiSaishuNyukinNen = string.Empty;
                //// 最終入金月
                //newRow.KensaIraiSaishuNyukinTsuki = string.Empty;
                //// 最終入金日
                //newRow.KensaIraiSaishuNyukinBi = string.Empty;
                //// 請求番号
                //newRow.KensaIraiSeikyuNo = string.Empty;
                //// 請求年
                //newRow.KensaIraiSeikyuNen = string.Empty;
                //// 請求月
                //newRow.KensaIraiSeikyuTsuki = string.Empty;
                //// 請求日
                //newRow.KensaIraiSeikyuBi = string.Empty;
                //// 請求額
                //newRow.KensaIraiSeikyuAmt = string.Empty;
                //// 再請求番号
                //newRow.KensaIraiSaiseikyuNo = string.Empty;
                //// 再請求年
                //newRow.KensaIraiSaiseikyuNen = string.Empty;
                //// 再請求月
                //newRow.KensaIraiSaiseikyuTsuki = string.Empty;
                //// 再請求日
                //newRow.KensaIraiSaiseikyuBi = string.Empty;
                //// 再請求額
                //newRow.KensaIraiSaiseikyuAmt = string.Empty;
                //// 入金完了区分
                //newRow.KensaIraiNyukinKanryoKbn = string.Empty;
                //// 請求書発行区分
                //newRow.KensaIraiSeikyushoHakkoKbn = string.Empty;
                //// 結果書発行区分
                //newRow.KensaIraiKekkashoHakkoKbn = string.Empty;
                // 前回法定区分
                newRow.KensaIraiZenkaiHoteiKbn = row.KensaIraiHoteiKbn;
                // 前回依頼保健所コード
                newRow.KensaIraiZenkaiHokenjoCd = row.KensaIraiHokenjoCd;
                // 前回依頼年度
                newRow.KensaIraiZenkaiNendo = row.KensaIraiNendo;
                // 前回依頼連番
                newRow.KensaIraiZenkaiRenban = row.KensaIraiRenban;
                //// 月次更新区分
                //newRow.KensaIraiGetsujiKoshinKbn = string.Empty;
                //// 一括請求区分
                //newRow.KensaIraiIkkatsuSeikyuKbn = string.Empty;
                //// 料金区分
                //newRow.KensaIraiRyokinKbn = string.Empty;
                //// 月次請求区分
                //newRow.KensaIraiGetsujiSeikyuKbn = string.Empty;
                //// 更新区分
                //newRow.KensaIraiKoshinKbn = string.Empty;
                //// 送付日
                //newRow.KensaIraiSofuDt = string.Empty;
                //// 引落年
                //newRow.KensaIraiHikiotoshiNen = string.Empty;
                //// 引落月
                //newRow.KensaIraiHikiotoshiTsuki = string.Empty;
                //// 引落日
                //newRow.KensaIraiHikiotoshiBi = string.Empty;
                //// 発行区分１
                //newRow.KensaIraiHakkoKbn1 = string.Empty;
                //// 発行区分２
                //newRow.KensaIraiHakkoKbn2 = string.Empty;
                //// 発行区分３
                //newRow.KensaIraiHakkoKbn3 = string.Empty;
                //// 発行区分４
                //newRow.KensaIraiHakkoKbn4 = string.Empty;
                //// 発行区分５
                //newRow.KensaIraiHakkoKbn5 = string.Empty;
                //// 発行区分６
                //newRow.KensaIraiHakkoKbn6 = string.Empty;
                //// 発行区分７
                //newRow.KensaIraiHakkoKbn7 = string.Empty;
                //// 発行区分８
                //newRow.KensaIraiHakkoKbn8 = string.Empty;
                //// 発行区分９
                //newRow.KensaIraiGyoseiHokokuLevel = string.Empty;
                //// 発行区分１０
                //newRow.KensaIraiHakkoKbn10 = string.Empty;
                //// 保守点検回数
                //newRow.KensaIraiHoshuTenkenKaisu = string.Empty;
                //// 前回判定
                //newRow.KensaIraiZenkaiHantei = string.Empty;
                // 前回検査日
                newRow.KensaIraiZenkaiKensaDt = maxKensaDt;
                //// 前回所見手書き
                //newRow.KensaIraiZenkaiShokenTegaki = string.Empty;
                // 設置者名（漢字）
                newRow.KensaIraiSetchishaNm = row.JokasoSetchishaNm;
                // 検査依頼設置者（住所）
                newRow.KensaIraiSetchishaAdr = row.JokasoSetchishaAdr;
                // 設置者（郵便番号）
                newRow.KensaIraiSetchishaZipCd = row.JokasoSetchishaZipCd;
                // 設置者（電話番号）
                newRow.KensaIraiSetchishaTelNo = row.JokasoSetchishaTelNo;
                // 検査依頼設置場所（住所）
                newRow.KensaIraiSetchibashoAdr = row.JokasoSetchiBashoAdr;
                // 設置場所（郵便番号）
                newRow.KensaIraiSetchibashoZipCd = row.JokasoSetchiBashoZipCd;
                // 設置場所（電話番号）
                newRow.KensaIraiSetchibashoTelNo = row.JokasoSetchiBashoTelNo;
                // 施設名称
                newRow.KensaIraiShisetsuNm = row.JokasoShisetsuNm;
                // 保健所コード
                newRow.KensaIraiSetchibashoHokenjoCd = row.JokasoSetchiBashoHokenjoCd;
                // 採水業者コード
                newRow.KensaIraiSaisuiGyoshaCd = row.JokasoSaisuiGyoshaCd;
                // 請求業者コード
                newRow.KensaIraiSeikyuGyoshaCd = row.JokasoSeikyuGyoshaCd;
                // 持込業者コード
                newRow.KensaIraiMochikomiGyoshaCd = row.JokasoMochikomiGyoshaCd;
                // 送付先名
                newRow.KensaIraiSofusakiNm = row.JokasoSoufusakiNm;
                // 送付先（郵便番号）
                newRow.KensaIraiSofusakiZipCd = row.JokasoSoufusakiZipCd;
                // 検査依頼送付先（住所）
                newRow.KensaIraiSofusakiAdr = row.JokasoSoufusakiAdr;
                // 送付先（電話番号）
                newRow.KensaIraiSofusakiTelNo = row.JokasoSoufusakiTelNo;
                // 請求先名
                newRow.KensaIraiSeikyusakiNm = row.JokasoSeikyusakiNm;
                // 請求先（郵便番号）
                newRow.KensaIraiSeikyusakiZipCd = row.JokasoSeikyusakiZipCd;
                // 検査依頼請求先（住所）
                newRow.KensaIraiSeikyusakiAdr = row.JokasoSeikyusakiAdr;
                // 請求先（電話番号）
                newRow.KensaIraiSeikyusakiTelNo = row.JokasoSeikyusakiTelNo;
                // 一括請求先コード
                newRow.KensaIraiIkkatsuSeikyusakiCd = row.JokasoItkatsuSeikyuGyoshaCd;
                // 建築用途大分類１
                newRow.KenchikuyotoDaibunrui1 = row.KenchikuyotoDaibunrui1;
                // 建築用途小分類１
                newRow.KenchikuyotoShobunrui1 = row.KenchikuyotoShobunrui1;
                // 建築用途連番１
                if (!row.IsKenchikuyotoRenban1Null())
                {
                    newRow.KenchikuyotoRenban1 = row.KenchikuyotoRenban1;
                }
                // 建築用途大分類２
                newRow.KenchikuyotoDaibunrui2 = row.KenchikuyotoDaibunrui2;
                // 建築用途小分類２
                newRow.KenchikuyotoShobunrui2 = row.KenchikuyotoShobunrui2;
                // 建築用途連番２
                if (!row.IsKenchikuyotoRenban2Null())
                {
                    newRow.KenchikuyotoRenban2 = row.KenchikuyotoRenban2;
                }
                // 建築用途大分類３
                newRow.KenchikuyotoDaibunrui3 = row.KenchikuyotoDaibunrui3;
                // 建築用途小分類３
                newRow.KenchikuyotoShobunrui3 = row.KenchikuyotoShobunrui3;
                // 建築用途連番３
                if (!row.IsKenchikuyotoRenban3Null())
                {
                    newRow.KenchikuyotoRenban3 = row.KenchikuyotoRenban3;
                }
                // 建築用途大分類４
                newRow.KenchikuyotoDaibunrui4 = row.KenchikuyotoDaibunrui4;
                // 建築用途小分類４
                newRow.KenchikuyotoShobunrui4 = row.KenchikuyotoShobunrui4;
                // 建築用途連番４
                if (!row.IsKenchikuyotoRenban4Null())
                {
                    newRow.KenchikuyotoRenban4 = row.KenchikuyotoRenban4;
                }
                // 建築用途大分類５
                newRow.KenchikuyotoDaibunrui5 = row.KenchikuyotoDaibunrui5;
                // 建築用途小分類５
                newRow.KenchikuyotoShobunrui5 = row.KenchikuyotoShobunrui5;
                // 建築用途連番５
                if (!row.IsKenchikuyotoRenban5Null())
                {
                    newRow.KenchikuyotoRenban5 = row.KenchikuyotoRenban5;
                }
                // 旧建築用途コード
                newRow.KensaIraiTatemonoYoto = row.JokasoOldKentikuYoutoCd;
                // メーカコード
                newRow.KensaIraiMakerCd = row.JokasoMekaGyoshaCd;
                // 型式コード
                newRow.KensaIraiKatashikiCd = row.JokasoKatashikiCd;
                // 工事業者コード
                newRow.KensaIraiKojiGyoshaCd = row.JokasoKojiGyoshaKbn;
                // 保守点検業者コード
                newRow.KensaIraiHoshutenkenGyoshaCd = row.JokasoHoshutenkenGyoshaCd;
                // 清掃業者コード
                newRow.KensaIraiSeisoGyoshaCd = row.JokasoSeisouGyoshaCd;
                // 放流先コード
                newRow.KensaIraiHoryusakiCd = row.JokasoHoryusakiCd;
                // 実使用人員
                newRow.KensaIraiJitsushiyoJinin = row.IsJokasoJitsuSiyoJininNull() ? null : row.JokasoJitsuSiyoJinin.ToString();
                // 処理対象人員
                // TODO HotFix
                newRow.KensaIraiShoritaishoJinin = row.IsJokasoShoriTaishoJininNull() ? 0 : row.JokasoShoriTaishoJinin;
                //newRow.KensaIraiShoritaishoJinin = row.IsJokasoShoriTaishoJininNull() ? null : row.JokasoShoriTaishoJinin.ToString();
                // 処理方式区分
                newRow.KensaIraiShorihoshikiKbn = row.JokasoShoriHosikiKbn;
                // 処理方式コード
                newRow.KensaIraiShorihoshikiCd = row.JokasoShoriHosikiCd;
                //// 地域コード
                //newRow.KensaIraiChiikiCd = string.Empty;
                //// 変更前メーカー
                //newRow.KensaIraiHenkomaeMakerCd = string.Empty;
                //// 変更前工事業者
                //newRow.KensaIraiHenkomaeKojiGyoshaCd = string.Empty;
                // はがき送付先
                newRow.KensaIraiHagakiSofusakiKbn = row.JokasoHagakiSoufusakiKbn;
                // 三次処理有無
                newRow.KensaIraiSanjishoriUmuKbn = row.Jokaso3JiShoriFlg;
                // 処理目標水質 V1.36 DB定義書 KensaIraiShorimokuhyoSuishitsu from nvarchar(1) -> int
                newRow.KensaIraiShorimokuhyoSuishitsu = row.IsJokasoSyoriMokuhyoBODNull() ? 0 : row.JokasoSyoriMokuhyoBOD;
                //// 種類
                //newRow.KensaIraiShurui = string.Empty;
                // 市町村設置型
                newRow.KensaIraiShichosonSetchigata = row.JokasoSichosonSetchiKbn;
                //// 告示区分
                //newRow.KensaIraiKokujiKbn = string.Empty;
                //// 告示年度
                //newRow.KensaIraiKokujiNendo = string.Empty;
                //// 告示番号
                //newRow.KensaIraiKokujiNo = string.Empty;
                // 延べ面積
                newRow.KensaIraiNobeMensaeki = row.IsJokasoTatemonoNobeMensekiNull() ? 0 : (decimal)row.JokasoTatemonoNobeMenseki;
                // 認定番号
                newRow.KensaIraiNinteiNo = row.JokasoNinteiNo;
                //// BOD処理性能
                //newRow.KensaIraiBODShoriSeino = string.Empty;
                // 設置年
                newRow.KensaIraiSetchiNen = row.JokasoSetchiNen;
                // 設置月
                newRow.KensaIraiSetchiTsuki = row.JokasoSetchiTsuki;
                // 設置日
                newRow.KensaIraiSetchiBi = row.JokasoSetchiBi;
                // 使用開始年
                newRow.KensaIraiShiyoKaishiNen = row.JokasoSiyokaisiNen;
                // 使用開始月
                newRow.KensaIraiShiyoKaishiTsuki = row.JokasoSiyokaisiTsuki;
                // 使用開始日
                newRow.KensaIraiShiyoKaishiBi = row.JokasoSiyokaisiBi;
                //// 使用開始届
                //newRow.KensaIraiShiyoKaishiTodoke = string.Empty;
                //// 取下理由
                //newRow.KensaIraiTorisageRiyu = string.Empty;
                // 設置者（カナ）
                newRow.KensaIraiSetchishaKana = row.JokasoSetchishaKana;
                // 20141218 habu column changed
                // 新市町村コード
                newRow.KensaIraiGenChikuCd = row.JokasoGenChikuCd;
                //// 検査完了区分
                //newRow.KensaIraiKensaKanryoKbn = string.Empty;
                //// 検印区分
                //newRow.KensaIraiKeninKbn = string.Empty;
                //// BOD入力済区分
                //newRow.KensaIraiBODNyuryokuzumiKbn = string.Empty;
                //// 塩素イオン入力済区分
                //newRow.KensaIraiEnsoIonNyuryokuzumiKbn = string.Empty;
                //// MLSS入力済区分
                //newRow.KensaIraiMLSSNyuryokuzumiKbn = string.Empty;
                //// 検査票印刷済区分
                //newRow.KensaIraiKensahyoInsatsuzumiKbn = string.Empty;
                //// ハガキ印刷済区分
                //newRow.KensaIraiHagakiInsatsuzumiKbn = string.Empty;
                //// ７条保留区分
                //newRow.KensaIrai7joHoryuKbn = string.Empty;
                // 実使用人員（数値）
                newRow.KensaIraiJitsushiyoJininValue = row.JokasoJitsuSiyouJininSuchi;
                //// 点検回数月毎
                //newRow.KensaIraiTenkenKaisuTsukiGoto = string.Empty;
                //// 点検回数週毎
                //newRow.KensaIraiTenkenKaisuShuGoto = string.Empty;
                // 嵩上げ
                newRow.KensaIraiKasaage = row.JokasoKasaageTakasa;
                // 流入滞留
                newRow.KensaIraiRyunyuTairyu = row.JokasoRyunyuTairyuTakasa;
                // 放流滞留
                newRow.KensaIraiHoryuTairyu = row.JokasoHouryuTairyuTakasa;
                // ブロワ
                //newRow.KensaIraiBurowa = string.Empty;
                //// ブロワ規定風量
                //newRow.KensaIraiBurowaKiteFuryo = string.Empty;
                //// ブロワ設置風量
                //newRow.KensaIraiBurowaSetchiFuryo = string.Empty;
                //// ７条保留確認日
                //newRow.KensaIrai7joHoryuKakuninDt = string.Empty;
                //// 次回確認予定日
                //newRow.KensaIraiJikaiKakuninYoteiDt = string.Empty;
                //// 保留理由
                //newRow.KensaIraiHoryuRiyu = string.Empty;
                //// 保守点検（内容）
                //newRow.KensaIraiHoshuTenkenNiayo = string.Empty;
                //// 清掃回数（年）
                //newRow.KensaIraiSeisoKaisuNenkan = string.Empty;
                //// ブロワ１
                //newRow.KensaIraiBurowa1 = string.Empty;
                //// ブロワ規定風量１
                //newRow.KensaIraiBurowaKiteFuryo1 = string.Empty;
                //// ブロワ設置風量１
                //newRow.KensaIraiBurowaSetchiFuryo1 = string.Empty;
                //// ブロワ２
                //newRow.KensaIraiBurowa2 = string.Empty;
                //// ブロワ規定風量２
                //newRow.KensaIraiBurowaKiteFuryo2 = string.Empty;
                //// ブロワ設置風量２
                //newRow.KensaIraiBurowaSetchiFuryo2 = string.Empty;
                //// ブロワ３
                //newRow.KensaIraiBurowa3 = string.Empty;
                //// ブロワ規定風量３
                //newRow.KensaIraiBurowaKiteFuryo3 = string.Empty;
                //// ブロワ設置風量３
                //newRow.KensaIraiBurowaSetchiFuryo3 = string.Empty;
                //// 検査担当者コード
                //newRow.KensaIraiKensaTantoshaCd = string.Empty;
                //// 検査担当者
                //newRow.KensaIraiKensaTantoshaNm = string.Empty;
                //// 保留区分
                //newRow.KensaIraiHoryuKbn = string.Empty;
                //// 保留取消日
                //newRow.KensaIraiHoryuTorikeshiDt = string.Empty;
                //// メモ確認フラグ
                //newRow.KensaIraiMemoKakuninFlg = string.Empty;
                //// 採水員コード
                //newRow.KensaIraiSaisuiinCd = string.Empty;
                //// クロスチェック
                //newRow.KensaIraiCrossCheck = string.Empty;
                //// クロスチェック判定
                //newRow.KensaIraiCrossCheckHantei = string.Empty;
                //// クロスチェック理由
                //newRow.KensaIraiCrossCheckRiyu = string.Empty;
                //// 検査責任者
                //newRow.KensaIraiKensaSekininsｈa = string.Empty;
                //// 判定区分
                //newRow.KensaIraiHanteiKbn = string.Empty;
                //// スクリーニング実施
                //newRow.KensaIraiScreeningJisshi = string.Empty;
                //// スクリーニング保健所コード
                //newRow.KensaIraiScreeningHokenjoCd = string.Empty;
                //// スクリーニング年度
                //newRow.KensaIraiScreeningNendo = string.Empty;
                //// スクリーニング連番
                //newRow.KensaIraiScreeningRenban = string.Empty;
                // 20150126 habu
                // 遅延報告作成
                newRow.ChienHokokuMakeKbn = "0";
                // 登録日
                newRow.InsertDt = now;
                // 登録者
                newRow.InsertUser = username;
                // 登録端末
                newRow.InsertTarm = hostname;
                // 更新日
                newRow.UpdateDt = now;
                // 更新者
                newRow.UpdateUser = username;
                // 更新端末
                newRow.UpdateTarm = hostname;

                // 行を挿入
                kensaTable.AddKensaIraiTblRow(newRow);
                // 行の状態を設定
                newRow.AcceptChanges();
                // 行の状態を設定（新規）
                newRow.SetAdded();
            }

            return kensaTable;
        }
        #endregion

        #region CreateKensaIraiTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dgvr"></param>
        /// <param name="now"></param>
        /// <param name="kensaNendoTxt"></param>
        /// <param name="username"></param>
        /// <param name="hostname"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblUpdate
            (
                DataGridViewRow dgvr,
                DateTime now,
                string kensaNendoTxt,
                string username,
                string hostname
            )
        {
            // 予定月(16)
            string nendo16 = dgvr.Cells["nendoCol"].Value.ToString();

            // Get KensaIraiTbl by key
            IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
            // 検査依頼法定区分(10)
            blInput.KensaIraiHoteiKbn = dgvr.Cells["kensaIraiHoteiKbnCol"].Value.ToString();
            // 検査依頼保健所コード(11)
            blInput.KensaIraiHokenjoCd = dgvr.Cells["kensaIraiHokenjoCdCol"].Value.ToString();
            // 検査依頼年度(12)
            blInput.KensaIraiNendo = dgvr.Cells["kensaIraiNendoCol"].Value.ToString();
            // 検査依頼連番(13)
            blInput.KensaIraiRenban = dgvr.Cells["kensaIraiRenbanCol"].Value.ToString();
            IGetKensaIraiTblByKeyBLOutput blOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);

            // No record was found
            if (blOutput.KensaIraiTblDataTable.Count == 0)
            {
                return new KensaIraiTblDataSet.KensaIraiTblDataTable();
            }

            //ADD_20141114_HuyTX Start
            if (dgvr.Cells["UpdateDtCol"].Value != null && (DateTime)(dgvr.Cells["UpdateDtCol"].Value) != blOutput.KensaIraiTblDataTable[0].UpdateDt)
            {
                // 更新されている場合は、他のユーザから更新されていると判断し、楽観ロックエラーで例外を発生
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }
            //ADD_20141114_HuyTX End

            // 検査予定年
            blOutput.KensaIraiTblDataTable[0].KensaIraiKensaYoteiNen = Convert.ToInt32(nendo16) < 3 
                ? (Convert.ToInt32(kensaNendoTxt) + 1).ToString() : kensaNendoTxt;

            // 検査予定月
            blOutput.KensaIraiTblDataTable[0].KensaIraiKensaYoteiTsuki = nendo16;

            // 検査予定日
            blOutput.KensaIraiTblDataTable[0].KensaIraiKensaYoteiBi = "01";

            // 更新日
            blOutput.KensaIraiTblDataTable[0].UpdateDt = now;

            // 更新者
            blOutput.KensaIraiTblDataTable[0].UpdateUser = username;

            // 更新端末
            blOutput.KensaIraiTblDataTable[0].UpdateTarm = hostname;

            return blOutput.KensaIraiTblDataTable;
        }
        #endregion

        #endregion
    }
    #endregion
}
