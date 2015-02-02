using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaKomokuMst;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetInsertDataForSuisitsuKensaShosaiALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  小松  　    詳細画面の子画面化（詳細では更新しない。受付一覧で更新）
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetInsertDataForSuisitsuKensaShosaiALInput : IBseALInput
    {
        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
        /// <summary>
        /// 検査受付日付
        /// </summary>
        string SuishitsuUketsukeDt { get; set; }
        /// <summary>
        /// 取込結果一覧データ
        /// </summary>
        SuishitsuKensaIraiDataSet.UketsukeImportListRow ListRow { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetInsertDataForSuisitsuKensaShosaiALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetInsertDataForSuisitsuKensaShosaiALInput : IGetInsertDataForSuisitsuKensaShosaiALInput
    {
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 検査受付日付
        /// </summary>
        public string SuishitsuUketsukeDt { get; set; }
        /// <summary>
        /// 取込結果一覧データ
        /// </summary>
        public SuishitsuKensaIraiDataSet.UketsukeImportListRow ListRow { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return String.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetInsertDataForSuisitsuKensaShosaiALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetInsertDataForSuisitsuKensaShosaiALOutput : IGetSuishitsuIraiInfoByKensaIraiKeyBLOutput, IGetKensaDaichoDtlTblByKeyBLOutput, IGetKensaIraiTblByKeyBLOutput, IGetMaxKensaDtByJokasoDaichoKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetInsertDataForSuisitsuKensaShosaiALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetInsertDataForSuisitsuKensaShosaiALOutput : IGetInsertDataForSuisitsuKensaShosaiALOutput
    {
        /// <summary>
        /// SuishitsuIraiInfo
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable SuishitsuIraiInfo { get; set; }

        /// <summary>
        /// KensaDaichoDtlTblDataTable
        /// </summary>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }

        /// <summary>
        /// KensaIraiTblDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// MaxKensaDt
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtDataTable MaxKensaDt { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetInsertDataForSuisitsuKensaShosaiApplicationLogic
    /// <summary>
    /// 詳細画面表示情報取得（依頼取込時の詳細画面表示用）
    /// 依頼取込時は、検査台帳、依頼、結果テーブルは存在しないので、ダミーのレコードを準備して変更項目や表示項目を受け渡す。
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11  小松  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetInsertDataForSuisitsuKensaShosaiApplicationLogic : BaseApplicationLogic<IGetInsertDataForSuisitsuKensaShosaiALInput, IGetInsertDataForSuisitsuKensaShosaiALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            NoDataFound,     // データ無し
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaIraiUketsukeList：GetInsertDataForSuisitsuKensaShosai";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetInsertDataForSuisitsuKensaShosaiApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11  小松  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetInsertDataForSuisitsuKensaShosaiApplicationLogic()
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
        /// 2014/12/11  小松  　    新規作成
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
        /// 2014/12/11  小松  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetInsertDataForSuisitsuKensaShosaiALOutput Execute(IGetInsertDataForSuisitsuKensaShosaiALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetInsertDataForSuisitsuKensaShosaiALOutput output = new GetInsertDataForSuisitsuKensaShosaiALOutput();

            try
            {
                // 現在日時
                DateTime _currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

                // 表示用
                // 水質検査依頼情報
                {
                    output.SuishitsuIraiInfo = new SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable();
                    SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoRow row = output.SuishitsuIraiInfo.NewSuishitsuIraiInfoRow();
                    // 検査依頼保健所コード
                    row.KensaIraiHokenjoCd = input.ListRow.KensaIraiHokenjoCd;
                    // 検査依頼年度
                    row.KensaIraiNendo = input.ListRow.KensaIraiNendo;
                    // 検査依頼連番
                    row.KensaIraiRenban = input.ListRow.KensaIraiRenban;
                    // 検体番号（依頼書番号）
                    row.KensaIraiSuishitsuIraiNo = input.ListRow.KentaiNo;
                    // 検査受付日付
                    row.KensaIraiSuishitsuUketsukeDt = input.SuishitsuUketsukeDt;
                    // 検査料金
                    row.KensaIraiKensaAmt = input.ListRow.KensaIraiKensaAmt;
                    // 入金額
                    row.KensaIraiNyukinzumiAmt = input.ListRow.KensaIraiNyukinzumiAmt;

                    // 編集対象項目
                    {
                        // 受付区分(1=持込、2=収集)
                        row.KensaIraiUketsukeKbn = "1";
                        if (input.ListRow.MotikomiFlg)
                        {
                            // 1:持込
                            row.KensaIraiUketsukeKbn = "1";
                        }
                        else if (input.ListRow.ShushuFlg)
                        {
                            // 2:収集
                            row.KensaIraiUketsukeKbn = "2";
                        }
                        // 現金収入(1:現金/2:請求)
                        row.KensaIraiGenkinShunyuKbn = "2";
                        if (input.ListRow.GenkinFlg)
                        {
                            // 現金
                            row.KensaIraiGenkinShunyuKbn = "1";
                        }
                        // 採水員コード
                        row.KensaIraiSaisuiinCd = input.ListRow.SaisuiinCd;
                        // 採水員名
                        row.SaisuiinNm = input.ListRow.SaisuiinNm;
                        // 保健所非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                        row.KensaIraiHakkoKbn4 = input.ListRow.KensaIraiHakkoKbn4;
                        // 市町村非通知フラグ(0=通知する、1=通知しない)(デフォルト:0)
                        row.KensaIraiHakkoKbn5 = input.ListRow.KensaIraiHakkoKbn5;
                    }

                    // 詳細画面の登録時用の浄化槽台帳情報を取得（依頼取込時のみ）
                    {
                        ISelectDisplayJokasoDaichoInfoDAInput selInput = new SelectDisplayJokasoDaichoInfoDAInput();
                        // 浄化槽台帳保健所コード
                        selInput.JokasoHokenjoCd = input.ListRow.JokasoDaichoHokenjoCd;
                        // 浄化槽台帳登録年度
                        selInput.JokasoTorokuNendo = input.ListRow.JokasoDaichoNendo;
                        // 浄化槽台帳連番
                        selInput.JokasoRenban = input.ListRow.JokasoDaichoRenban;
                        ISelectDisplayJokasoDaichoInfoDAOutput selOutput = new SelectDisplayJokasoDaichoInfoDAOutput();
                        selOutput.jokasoDaichoInfoDT = new SelectDisplayJokasoDaichoInfoDataAccess().Execute(selInput).jokasoDaichoInfoDT;
                        if (selOutput.jokasoDaichoInfoDT.Rows.Count > 0)
                        {
                            SuishitsuKensaUketsukeDataSet.DisplayJokasoDaichoInfoRow jokasoDaichoRow = selOutput.jokasoDaichoInfoDT[0];
                            // 浄化槽台帳保健所コード
                            row.KensaIraiJokasoHokenjoCd = jokasoDaichoRow.JokasoHokenjoCd;
                            // 浄化槽台帳年度
                            row.KensaIraiJokasoTorokuNendo = jokasoDaichoRow.JokasoTorokuNendo;
                            // 浄化槽台帳連番
                            row.KensaIraiJokasoRenban = jokasoDaichoRow.JokasoRenban;
                            // 設置者氏名
                            row.KensaIraiSetchishaNm = jokasoDaichoRow.IsJokasoSetchishaNmNull() ? string.Empty : jokasoDaichoRow.JokasoSetchishaNm;
                            // 電話番号
                            row.KensaIraiSetchishaTelNo = jokasoDaichoRow.IsJokasoSetchishaTelNoNull() ? string.Empty : jokasoDaichoRow.JokasoSetchishaTelNo;
                            // カナ名
                            row.KensaIraiSetchishaKana = jokasoDaichoRow.IsJokasoSetchishaKanaNull() ? string.Empty : jokasoDaichoRow.JokasoSetchishaKana;
                            // 設置者住所
                            row.KensaIraiSetchishaAdr = jokasoDaichoRow.IsJokasoSetchishaAdrNull() ? string.Empty : jokasoDaichoRow.JokasoSetchishaAdr;
                            // 設置場所
                            row.KensaIraiSetchibashoAdr = jokasoDaichoRow.IsJokasoSetchiBashoAdrNull() ? string.Empty : jokasoDaichoRow.JokasoSetchiBashoAdr;
                            // 保守業者
                            row.HoshutenkenGyoshaNm = jokasoDaichoRow.IsHoshutenkenGyoshaNmNull() ? string.Empty : jokasoDaichoRow.HoshutenkenGyoshaNm;
                            // 清掃業者
                            row.SeisoGyoshaNm = jokasoDaichoRow.IsSeisoGyoshaNmNull() ? string.Empty : jokasoDaichoRow.SeisoGyoshaNm;
                            // 建築用途１    表示
                            row.KenchikuyotoNm = jokasoDaichoRow.IskentikuYotoNm1Null() ? string.Empty : jokasoDaichoRow.kentikuYotoNm1;
                            // 建築用途２    表示
                            row.kentikuYotoNm2 = jokasoDaichoRow.IskentikuYotoNm2Null() ? string.Empty : jokasoDaichoRow.kentikuYotoNm2;
                            // 建築用途３    表示
                            row.kentikuYotoNm3 = jokasoDaichoRow.IskentikuYotoNm3Null() ? string.Empty : jokasoDaichoRow.kentikuYotoNm3;
                            // 建築用途４    表示
                            row.kentikuYotoNm4 = jokasoDaichoRow.IskentikuYotoNm4Null() ? string.Empty : jokasoDaichoRow.kentikuYotoNm4;
                            // 建築用途５    表示
                            row.kentikuYotoNm5 = jokasoDaichoRow.IskentikuYotoNm5Null() ? string.Empty : jokasoDaichoRow.kentikuYotoNm5;
                            // メーカー
                            row.MakerGyoshaNm = jokasoDaichoRow.IsMakerGyoshaNmNull() ? string.Empty : jokasoDaichoRow.MakerGyoshaNm;
                            // 型式名
                            row.KatashikiNm = jokasoDaichoRow.IsKatashikiNmNull() ? string.Empty : jokasoDaichoRow.KatashikiNm;
                            // 処理方式
                            row.KensaIraiShorihoshikiKbn = jokasoDaichoRow.IsJokasoShoriHosikiKbnNull() ? string.Empty : jokasoDaichoRow.JokasoShoriHosikiKbn;
                            // 処理方式名 
                            row.ShoriHoshikiNm = jokasoDaichoRow.IsShoriHoshikiNmNull() ? string.Empty : jokasoDaichoRow.ShoriHoshikiNm;
                            // 人槽 
                            row.KensaIraiShoritaishoJinin = jokasoDaichoRow.IsJokasoShoriTaishoJininNull() ? 0 : jokasoDaichoRow.JokasoShoriTaishoJinin;
                        }
                    }

                    output.SuishitsuIraiInfo.AddSuishitsuIraiInfoRow(row);
                }

                // 更新用
                {
                    // 検査台帳明細
                    output.KensaDaichoDtlTblDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();
                    KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow row = output.KensaDaichoDtlTblDT.NewKensaDaichoDtlTblRow();
                    // 編集対象項目
                    {
                        // 残留塩素
                        row.KeiryoShomeiKekkaValue = input.ListRow.ZanryuEnso;
                    }
                    row.KensaKbn = "2";
                    row.IraiNendo = input.IraiNendo;
                    row.ShishoCd = input.ShishoCd;
                    row.SuishitsuKensaIraiNo = input.ListRow.KentaiNo;
                    row.ShikenkoumokuCd = Boundary.Common.Common.GetConstValue(Constants.ConstKbnConstanst.CONST_KBN_048, Constants.ConstRenbanConstanst.CONST_RENBAN_004);
                    row.SaikensaKbn = "0";
                    row.InsertDt = _currentDateTime;
                    row.InsertUser = string.Empty;
                    row.InsertTarm = string.Empty;
                    row.UpdateDt = _currentDateTime;
                    row.UpdateUser = string.Empty;
                    row.UpdateTarm = string.Empty;
                    output.KensaDaichoDtlTblDT.AddKensaDaichoDtlTblRow(row);
                }

                // 検査依頼情報
                {
                    output.KensaIraiTblDataTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                    KensaIraiTblDataSet.KensaIraiTblRow row = output.KensaIraiTblDataTable.NewKensaIraiTblRow();
                    // ダミー用レコード作成
                    row.KensaIraiHoteiKbn = "2";
                    row.KensaIraiHokenjoCd = input.ListRow.JokasoDaichoHokenjoCd;
                    row.KensaIraiNendo = input.ListRow.JokasoDaichoNendo;
                    row.KensaIraiRenban = input.ListRow.JokasoDaichoRenban;
                    row.KensaIraiUketsukeShishoKbn = input.ShishoCd;
                    row.KensaIraiJokasoHokenjoCd = input.ListRow.JokasoDaichoHokenjoCd;
                    row.KensaIraiJokasoTorokuNendo = input.ListRow.JokasoDaichoNendo;
                    row.KensaIraiJokasoRenban = input.ListRow.JokasoDaichoRenban;
                    row.InsertDt = _currentDateTime;
                    row.InsertUser = string.Empty;
                    row.InsertTarm = string.Empty;
                    row.UpdateDt = _currentDateTime;
                    row.UpdateUser = string.Empty;
                    row.UpdateTarm = string.Empty;
                    output.KensaIraiTblDataTable.AddKensaIraiTblRow(row);
                }

                // 最終検査日取得
                {
                    IGetMaxKensaDtByJokasoDaichoKeyBLInput kensaDtInput = new GetMaxKensaDtByJokasoDaichoKeyBLInput();
                    kensaDtInput.KensaIraiJokasoHokenjoCd = input.ListRow.JokasoDaichoHokenjoCd;
                    kensaDtInput.KensaIraiJokasoTorokuNendo = input.ListRow.JokasoDaichoNendo;
                    kensaDtInput.KensaIraiJokasoRenban = input.ListRow.JokasoDaichoRenban;

                    // 検索実行
                    output.MaxKensaDt = new GetMaxKensaDtByJokasoDaichoKeyBusinessLogic().Execute(kensaDtInput).MaxKensaDt;
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
