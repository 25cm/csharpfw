using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetDataForKeiryoShomeiShosaiALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetDataForKeiryoShomeiShosaiALInput : IBseALInput
    {
        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        string KeiryoShomeiIraiRenban { get; set; }

        /// <summary>
        /// 取込結果一覧データ
        /// </summary>
        SuishitsuKensaIraiDataSet.UketsukeImportListRow ListRow { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDataForKeiryoShomeiShosaiALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDataForKeiryoShomeiShosaiALInput : IGetDataForKeiryoShomeiShosaiALInput
    {
        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }

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
    //  インターフェイス名 ： IGetDataForKeiryoShomeiShosaiALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetDataForKeiryoShomeiShosaiALOutput : IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput, IGetKensaSetPatternByKeiryoShomeiIraiKeyBLOutput, IGetKeiryoShomeiIraiTblByKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDataForKeiryoShomeiShosaiALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDataForKeiryoShomeiShosaiALOutput : IGetDataForKeiryoShomeiShosaiALOutput
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
    //  クラス名 ： GetDataForKeiryoShomeiShosaiApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  　　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDataForKeiryoShomeiShosaiApplicationLogic : BaseApplicationLogic<IGetDataForKeiryoShomeiShosaiALInput, IGetDataForKeiryoShomeiShosaiALOutput>
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
        private const string FunctionName = "SuishitsuKensaIraiUketsukeKeiryoShomeiShosai：GetDataForKeiryoShomeiShosai";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetDataForKeiryoShomeiShosaiApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10  　　  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetDataForKeiryoShomeiShosaiApplicationLogic()
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
        /// 2014/12/10  　　  　    新規作成
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
        /// 2014/12/10  　　  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetDataForKeiryoShomeiShosaiALOutput Execute(IGetDataForKeiryoShomeiShosaiALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetDataForKeiryoShomeiShosaiALOutput output = new GetDataForKeiryoShomeiShosaiALOutput();

            try
            {
                // 検査セットパターン取得
                {
                    IGetKensaSetPatternByKeiryoShomeiIraiKeyBLInput patternInput = new GetKensaSetPatternByKeiryoShomeiIraiKeyBLInput();
                    patternInput.KeiryoShomeiIraiNendo = input.KeiryoShomeiIraiNendo;
                    patternInput.KeiryoShomeiIraiSishoCd = input.KeiryoShomeiIraiSishoCd;
                    patternInput.KeiryoShomeiIraiRenban = input.KeiryoShomeiIraiRenban;

                    // 検索実行
                    output.KensaSetPattern = new GetKensaSetPatternByKeiryoShomeiIraiKeyBusinessLogic().Execute(patternInput).KensaSetPattern;
                }

                // 計量証明依頼情報取得
                {
                    IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLInput kensaInfoInput = new GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLInput();
                    kensaInfoInput.KeiryoShomeiIraiNendo = input.KeiryoShomeiIraiNendo;
                    kensaInfoInput.KeiryoShomeiIraiSishoCd = input.KeiryoShomeiIraiSishoCd;
                    kensaInfoInput.KeiryoShomeiIraiRenban = input.KeiryoShomeiIraiRenban;

                    // 検索実行
                    output.KeiryoShomeiIraiInfo = new GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBusinessLogic().Execute(kensaInfoInput).KeiryoShomeiIraiInfo;

                    if (output.KeiryoShomeiIraiInfo.Count == 0)
                    {
                        throw new CustomException((int)ResultCode.OperationError, (int)OperationErr.NoDataFound, string.Empty);
                    }

                    // 編集対象項目
                    {
                        SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoRow row = output.KeiryoShomeiIraiInfo[0];
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
                }

                // 計量証明依頼
                {
                    IGetKeiryoShomeiIraiTblByKeyBLInput keiryoShomeiInput = new GetKeiryoShomeiIraiTblByKeyBLInput();
                    keiryoShomeiInput.KeiryoShomeiIraiNendo = input.KeiryoShomeiIraiNendo;
                    keiryoShomeiInput.KeiryoShomeiIraiSishoCd = input.KeiryoShomeiIraiSishoCd;
                    keiryoShomeiInput.KeiryoShomeiIraiRenban = input.KeiryoShomeiIraiRenban;

                    // 検索実行
                    output.KeiryoShomeiIraiTblDT = new GetKeiryoShomeiIraiTblByKeyBusinessLogic().Execute(keiryoShomeiInput).KeiryoShomeiIraiTblDT;

                    if (output.KeiryoShomeiIraiTblDT.Count == 0)
                    {
                        throw new CustomException((int)ResultCode.OperationError, (int)OperationErr.NoDataFound, string.Empty);
                    }
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
