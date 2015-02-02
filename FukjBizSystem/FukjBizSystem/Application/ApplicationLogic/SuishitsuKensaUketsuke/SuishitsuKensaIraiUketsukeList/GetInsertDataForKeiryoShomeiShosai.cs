using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaKomokuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetInsertDataForKeiryoShomeiShosaiALInput
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
    interface IGetInsertDataForKeiryoShomeiShosaiALInput : IBseALInput
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
    //  クラス名 ： GetInsertDataForKeiryoShomeiShosaiALInput
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
    class GetInsertDataForKeiryoShomeiShosaiALInput : IGetInsertDataForKeiryoShomeiShosaiALInput
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
    //  インターフェイス名 ： IGetInsertDataForKeiryoShomeiShosaiALOutput
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
    interface IGetInsertDataForKeiryoShomeiShosaiALOutput : IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput, IGetKensaSetPatternByKeiryoShomeiIraiKeyBLOutput, IGetKeiryoShomeiIraiTblByKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetInsertDataForKeiryoShomeiShosaiALOutput
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
    class GetInsertDataForKeiryoShomeiShosaiALOutput : IGetInsertDataForKeiryoShomeiShosaiALOutput
    {
        /// <summary>
        /// KeiryoShomeiIraiInfo
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoDataTable KeiryoShomeiIraiInfo { get; set; }

        /// <summary>
        /// KensaSetPattern
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternDataTable KensaSetPattern { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiTblDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetInsertDataForKeiryoShomeiShosaiApplicationLogic
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
    class GetInsertDataForKeiryoShomeiShosaiApplicationLogic : BaseApplicationLogic<IGetInsertDataForKeiryoShomeiShosaiALInput, IGetInsertDataForKeiryoShomeiShosaiALOutput>
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
        private const string FunctionName = "SuishitsuKensaIraiUketsukeList：GetInsertDataForKeiryoShomeiShosai";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetInsertDataForKeiryoShomeiShosaiApplicationLogic
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
        public GetInsertDataForKeiryoShomeiShosaiApplicationLogic()
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
        public override IGetInsertDataForKeiryoShomeiShosaiALOutput Execute(IGetInsertDataForKeiryoShomeiShosaiALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetInsertDataForKeiryoShomeiShosaiALOutput output = new GetInsertDataForKeiryoShomeiShosaiALOutput();

            try
            {
                // 現在日時
                DateTime _currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

                // 表示用

                // 検査セットパターン取得
                {
                    IGetKensaSetPatternByKyokaiNoBLInput patternInput = new GetKensaSetPatternByKyokaiNoBLInput();
                    patternInput.JokasoHokenjoCd = input.ListRow.JokasoDaichoHokenjoCd;
                    patternInput.JokasoTorokuNendo = input.ListRow.JokasoDaichoNendo;
                    patternInput.JokasoRenban = input.ListRow.JokasoDaichoRenban;

                    // 検索実行
                    output.KensaSetPattern = new GetKensaSetPatternByKyokaiNoBusinessLogic().Execute(patternInput).KensaSetPattern;
                }

                // 計量証明依頼情報
                {
                    output.KeiryoShomeiIraiInfo = new SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoDataTable();
                    SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoRow row = output.KeiryoShomeiIraiInfo.NewKeiryoShomeiIraiInfoRow();
                    // 検体番号（依頼書番号）
                    row.KeiryoShomeiIraiRenban = input.ListRow.KentaiNo;
                    // 検査受付日付
                    row.KeiryoShomeiIraiUketsukeDt = input.SuishitsuUketsukeDt;

                    // 編集対象項目
                    {
                        // 受付区分(1=持込、2=収集)
                        row.KeiryoShomeiUketsukeKbn = "1";
                        if (input.ListRow.MotikomiFlg)
                        {
                            // 1:持込
                            row.KeiryoShomeiUketsukeKbn = "1";
                        }
                        else if (input.ListRow.ShushuFlg)
                        {
                            // 2:収集
                            row.KeiryoShomeiUketsukeKbn = "2";
                        }
                        // 現金収入(1:現金/2:請求)
                        row.KeiryoShomeiGenkinShunyuFlg = "2";
                        if (input.ListRow.GenkinFlg)
                        {
                            // 現金
                            row.KeiryoShomeiGenkinShunyuFlg = "1";
                        }
                        // 採水員コード
                        row.KeiryoShomeiSaisuiinCd = input.ListRow.SaisuiinCd;
                        // 採水員名
                        row.SaisuiinNm = input.ListRow.SaisuiinNm;
                        // 採水日
                        row.KeiryoShomeiSaisuiDt = input.ListRow.SaisuiDt;
                        // 採水時刻
                        row.KeiryoShomeiSaisuiTime = input.ListRow.SaisuiTime;
                        // 水温
                        row.KeiryoShomeiSuion = (double)input.ListRow.KeiryoShomeiSuion;
                        // 気温
                        row.KeiryoShomeiKion = (double)input.ListRow.KeiryoShomeiKion;
                        // 計量証明セットコード
                        row.KeiryoShomeiSetCd = input.ListRow.KeiryoShomeiSetCd;
                        // 計量証明検査料金
                        row.KeiryoShomeiKensaRyokin = input.ListRow.KeiryoShomeiKensaRyokin;
                        // 計量証明消費税額
                        row.KeiryoShomeiShohizei = input.ListRow.KeiryoShomeiShohizei;
                        // 検査項目枝番
                        row.KeiryoShomeiKensakomokuEdaban = input.ListRow.KeiryoShomeiKensakomokuEdaban;
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
                            row.JokasoHokenjoCd = jokasoDaichoRow.JokasoHokenjoCd;
                            // 浄化槽台帳年度
                            row.JokasoTorokuNendo = jokasoDaichoRow.JokasoTorokuNendo;
                            // 浄化槽台帳連番
                            row.JokasoRenban = jokasoDaichoRow.JokasoRenban;
                            // 設置者氏名
                            row.JokasoSetchishaNm = jokasoDaichoRow.IsJokasoSetchishaNmNull() ? string.Empty : jokasoDaichoRow.JokasoSetchishaNm;
                            // 電話番号
                            row.JokasoSetchishaTelNo = jokasoDaichoRow.IsJokasoSetchishaTelNoNull() ? string.Empty : jokasoDaichoRow.JokasoSetchishaTelNo;
                            // カナ名
                            row.JokasoSetchishaKana = jokasoDaichoRow.IsJokasoSetchishaKanaNull() ? string.Empty : jokasoDaichoRow.JokasoSetchishaKana;
                            // 設置者住所
                            row.JokasoSetchishaAdr = jokasoDaichoRow.IsJokasoSetchishaAdrNull() ? string.Empty : jokasoDaichoRow.JokasoSetchishaAdr;
                            // 設置場所
                            row.JokasoSetchiBashoAdr = jokasoDaichoRow.IsJokasoSetchiBashoAdrNull() ? string.Empty : jokasoDaichoRow.JokasoSetchiBashoAdr;
                            // 採水業者
                            row.SaisuiGyoshaNm = jokasoDaichoRow.IsHoshutenkenGyoshaNmNull() ? string.Empty : jokasoDaichoRow.HoshutenkenGyoshaNm;
                            // 建築用途１    表示
                            row.kentikuYotoNm1 = jokasoDaichoRow.IskentikuYotoNm1Null() ? string.Empty : jokasoDaichoRow.kentikuYotoNm1;
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
                            row.JokasoShoriHosikiKbn = jokasoDaichoRow.IsJokasoShoriHosikiKbnNull() ? string.Empty : jokasoDaichoRow.JokasoShoriHosikiKbn;
                            // 処理方式名 
                            row.ShoriHoshikiNm = jokasoDaichoRow.IsShoriHoshikiNmNull() ? string.Empty : jokasoDaichoRow.ShoriHoshikiNm;
                            // 人槽 
                            row.JokasoShoriTaishoJinin = jokasoDaichoRow.IsJokasoShoriTaishoJininNull() ? 0 : jokasoDaichoRow.JokasoShoriTaishoJinin;
                            // 目標 
                            row.JokasoSyoriMokuhyoBOD = jokasoDaichoRow.IsJokasoSyoriMokuhyoBODNull() ? 0 : jokasoDaichoRow.JokasoSyoriMokuhyoBOD;
                        }
                    }

                    output.KeiryoShomeiIraiInfo.AddKeiryoShomeiIraiInfoRow(row);
                }

                // 更新用

                // 計量証明依頼
                {
                    output.KeiryoShomeiIraiTblDT = new KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable();
                    KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblRow row = output.KeiryoShomeiIraiTblDT.NewKeiryoShomeiIraiTblRow();
                    // ダミー用レコード作成
                    row.KeiryoShomeiIraiNendo = input.ListRow.JokasoDaichoNendo;
                    row.KeiryoShomeiIraiSishoCd = input.ShishoCd;
                    row.KeiryoShomeiIraiRenban = input.ListRow.JokasoDaichoRenban;
                    row.KeiryoShomeiJokasoDaichoHokenjoCd = input.ListRow.JokasoDaichoHokenjoCd;
                    row.KeiryoShomeiJokasoDaichoNendo = input.ListRow.JokasoDaichoNendo;
                    row.KeiryoShomeiJokasoDaichoRenban = input.ListRow.JokasoDaichoRenban;
                    row.InsertDt = _currentDateTime;
                    row.InsertUser = string.Empty;
                    row.InsertTarm = string.Empty;
                    row.UpdateDt = _currentDateTime;
                    row.UpdateUser = string.Empty;
                    row.UpdateTarm = string.Empty;
                    output.KeiryoShomeiIraiTblDT.AddKeiryoShomeiIraiTblRow(row);
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
