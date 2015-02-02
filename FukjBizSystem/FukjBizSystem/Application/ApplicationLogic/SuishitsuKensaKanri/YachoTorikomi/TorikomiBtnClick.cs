using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.Boundary.SuishitsuKensaKanri;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.Master.ConstMst;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.YachoTorikomi;
using FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl;
using FukjBizSystem.Application.DataAccess.SuishitsuKekkaNmMst;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using Microsoft.Office.Interop.Excel;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.YachoTorikomi
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorikomiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorikomiBtnClickALInput : IBseALInput, IGetYachoExcelDataBLInput
    {
        /// <summary>
        /// 1 : 計量証明
        /// 2 : 水質
        /// 3 : 外観
        /// </summary>
        string KensaShubetsu { get; set; }

        /// <summary>
        /// RadioBtnNm
        /// </summary>
        string RadioBtnNm { get; set; }

        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// 支所CD
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// 支所名
        /// </summary>
        string ShishoNm { get; set; }

        /// <summary>
        /// 水質試験項目コード
        /// </summary>
        string KoumokuCd { get; set; }

        /// <summary>
        /// 検査項目名
        /// </summary>
        string SeishikiNm { get; set; }

        /// <summary>
        /// 取込検査(0:通常/1:確認)
        /// </summary>
        string TorikomiKensa { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorikomiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorikomiBtnClickALInput : ITorikomiBtnClickALInput
    {
        /// <summary>
        /// 1 : 計量証明
        /// 2 : 水質
        /// 3 : 外観
        /// </summary>
        public string KensaShubetsu { get; set; }

        /// <summary>
        /// RadioBtnNm
        /// </summary>
        public string RadioBtnNm { get; set; }

        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// 支所CD
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 支所名
        /// </summary>
        public string ShishoNm { get; set; }

        /// <summary>
        /// 水質試験項目コード
        /// </summary>
        public string KoumokuCd { get; set; }

        /// <summary>
        /// 検査項目名
        /// </summary>
        public string SeishikiNm { get; set; }

        /// <summary>
        /// ExcelPath
        /// </summary>
        public string ExcelPath { get; set; }

        /// <summary>
        /// 取込検査(0:通常/1:確認)
        /// </summary>
        public string TorikomiKensa { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("Excel Path {0}", ExcelPath);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorikomiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ITorikomiBtnClickALOutput
    {
        /// <summary>
        /// YachoTorikomiDataTable
        /// </summary>
        YachoDataSet.YachoTorikomiDataTable YachoTorikomiDataTable { get; set; }

        /// <summary>
        /// ErrorCode
        /// 1: Column mismatch
        /// 2: Numeric check
        /// 3: ファイルアップロードエラー
        /// 11:確認検査時に通常検査無し
        /// 12:既に通常検査の取込あり
        /// 13:既に確認検査の取込あり
        /// </summary>
        int ErrorCode { get; set; }

        /// <summary>
        /// ErrorMessage
        /// </summary>
        string ErrorMessage { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorikomiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorikomiBtnClickALOutput : ITorikomiBtnClickALOutput
    {
        /// <summary>
        /// YachoTorikomiDataTable
        /// </summary>
        public YachoDataSet.YachoTorikomiDataTable YachoTorikomiDataTable { get; set; }

        /// <summary>
        /// ErrorCode
        /// 1: Column mismatch
        /// 2: Numeric check
        /// 3: ファイルアップロードエラー
        /// 11:確認検査時に通常検査無し
        /// 12:既に通常検査の取込あり
        /// 13:既に確認検査の取込あり
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// ErrorMessage
        /// </summary>
        public string ErrorMessage { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorikomiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class TorikomiBtnClickApplicationLogic : BaseApplicationLogic<ITorikomiBtnClickALInput, ITorikomiBtnClickALOutput>
    {
        #region プロパティ

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "YachoTorikomi：TorikomiBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TorikomiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public TorikomiBtnClickApplicationLogic()
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
        /// 2014/12/05　HieuNH　　　新規作成
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
        /// 2014/12/05　HieuNH　　　新規作成
        /// 2014/12/20　小松  　　　計量証明時の結果を正しく表示、アップロードをサーバに等修正
        /// 2015/01/11  小松　　　　通常検査の場合のみ野帳ファイルをPDF化してアップロード
        /// 2015/01/15  小松　　　　確認検査種別を判定し設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ITorikomiBtnClickALOutput Execute(ITorikomiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ITorikomiBtnClickALOutput output = new TorikomiBtnClickALOutput();

            try
            {
                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();
                YachoDataSet.YachoTorikomiDataTable yachoDT = new YachoDataSet.YachoTorikomiDataTable();

                #region Update DB

                try
                {
                    StartTransaction();
                    string ext = Path.GetExtension(input.ExcelPath).ToLower();
                    if (ext.Equals(".csv"))
                    {
                        IGetYachoCsvDataBLInput yachoCsvBLInput = new GetYachoCsvDataBLInput();
                        yachoCsvBLInput.CsvFilePath = input.ExcelPath;
                        yachoCsvBLInput.KoumokuCd = input.KoumokuCd;
                        IGetYachoCsvDataBLOutput yachoCsvBLOutput = new GetYachoCsvDataBusinessLogic().Execute(yachoCsvBLInput);
                        output.ErrorCode = yachoCsvBLOutput.ErrorCode;
                        output.ErrorMessage = yachoCsvBLOutput.ErrorMessage;
                        yachoDT = yachoCsvBLOutput.YachoTorikomiDataTable;
                        if (output.ErrorCode != 0)
                            return output;
                    }
                    else
                    {
                        IGetYachoExcelDataBLOutput yachoExcelBLOutput = new GetYachoExcelDataBusinessLogic().Execute(input);
                        output.ErrorCode = yachoExcelBLOutput.ErrorCode;
                        output.ErrorMessage = yachoExcelBLOutput.ErrorMessage;
                        yachoDT = yachoExcelBLOutput.YachoTorikomiDataTable;
                        if (output.ErrorCode != 0)
                            return output;
                    }

                    KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable updateDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();

                    if (input.KensaShubetsu == "1")
                    {
                        // 計量証明

                        // 野帳取込ループ処理開始
                        int i = 1;
                        foreach (YachoDataSet.YachoTorikomiRow row in yachoDT)
                        {
                            row.RowNumber = i.ToString();
                            // 取込結果
                            string torikomiKekka = string.Empty;

                            // エラー内容
                            string errContent = string.Empty;

                            // 検査台帳ヘッダ情報を取得
                            IGetKensaDaicho9joHdrTblByKeyBLInput hdrInput = new GetKensaDaicho9joHdrTblByKeyBLInput();
                            hdrInput.IraiNendo = input.IraiNendo;
                            hdrInput.ShishoCd = input.ShishoCd;
                            hdrInput.SuishitsuKensaIraiNo = row.SuishitsuKensaIraiNo;
                            IGetKensaDaicho9joHdrTblByKeyBLOutput hdrOutput = new GetKensaDaicho9joHdrTblByKeyBusinessLogic().Execute(hdrInput);

                            IGetKensaDaichoMeisai9joBLInput meisaiBLInput = new GetKensaDaichoMeisai9joBLInput();
                            meisaiBLInput.IraiNendo = input.IraiNendo;
                            meisaiBLInput.ShikenkoumokuCd = input.KoumokuCd;
                            meisaiBLInput.ShishoCd = input.ShishoCd;
                            meisaiBLInput.SuishitsuKensaIraiNo = row.SuishitsuKensaIraiNo;
                            IGetKensaDaichoMeisai9joBLOutput meisaiBLOutput = new GetKensaDaichoMeisai9joBusinessLogic().Execute(meisaiBLInput);

                            if (meisaiBLOutput.KensaDaichoMeisaiDT.Count == 0)
                            {
                                row.TorikomiKekka = "取込エラー";
                                row.ErrorContent = "該当の水質検査依頼番号が存在しない";
                            }
                            else
                            {
                                if (!meisaiBLOutput.KensaDaichoMeisaiDT[0].IsKachoKeninKbnNull() && !meisaiBLOutput.KensaDaichoMeisaiDT[0].IsHukuKachoKeninKbnNull() && !meisaiBLOutput.KensaDaichoMeisaiDT[0].IsKeiryoKanrishaKeninKbnNull())
                                {
                                    if (meisaiBLOutput.KensaDaichoMeisaiDT[0].KachoKeninKbn.Equals("1") || meisaiBLOutput.KensaDaichoMeisaiDT[0].HukuKachoKeninKbn.Equals("1") || meisaiBLOutput.KensaDaichoMeisaiDT[0].KeiryoKanrishaKeninKbn.Equals("1"))
                                    {
                                        row.TorikomiKekka = "取込エラー";
                                        row.ErrorContent = "検印済";
                                    }
                                    else if (meisaiBLOutput.KensaDaichoMeisaiDT[0].KachoKeninKbn.Equals("0") && meisaiBLOutput.KensaDaichoMeisaiDT[0].HukuKachoKeninKbn.Equals("0") && meisaiBLOutput.KensaDaichoMeisaiDT[0].KeiryoKanrishaKeninKbn.Equals("0"))
                                    {
                                        //if (meisaiBLOutput.KensaDaichoMeisaiDT.Count == 1 && (meisaiBLOutput.KensaDaichoMeisaiDT[0].SaikensaKbn.Equals("0")))
                                        //{
                                        //    // Update DB (1)
                                        //    UpdateKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, meisaiBLOutput.KensaDaichoMeisaiDT[0].UpdateDt, "0", updateDT);

                                        //    row.TorikomiKekka = "正常取込";
                                        //}
                                        //else
                                        //{
                                        //    // Update DB (2)
                                        //    KensaDaicho9joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho9joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiBLOutput.KensaDaichoMeisaiDT.Select("SaikensaKbn = '1'");
                                        //    UpdateKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, rows[0].UpdateDt, "1", updateDT);

                                        //    row.TorikomiKekka = "正常取込";
                                        //}

                                        // 通常検査時は初回レコード(SaikensaKbn=0)を処理対象とし、確認検査時は確認検査レコード(SaikensaKbn=1)を処理対象とする
                                        // 存在すれば更新し、存在しない場合は追加を行う。
                                        string selectStr = string.Format("SaikensaKbn = '{0}'", input.TorikomiKensa);
                                        KensaDaicho9joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho9joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiBLOutput.KensaDaichoMeisaiDT.Select(selectStr);
                                        if (rows.Length > 0)
                                        {
                                            // 更新
                                            UpdateKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, rows[0].UpdateDt, input.TorikomiKensa, updateDT,
                                                null, hdrOutput.KensaDaicho9joHdrDT[0]);
                                        }
                                        else
                                        {
                                            // 追加
                                            // ※受付時に初回のレコードは登録されるので、SaikensaKbn=0(初回)のレコードは、ここで作成されることはないはず。
                                            // 　SaikensaKbn=1(確認検査)は追加有り
                                            InsertKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, input.TorikomiKensa, updateDT, 
                                                null, hdrOutput.KensaDaicho9joHdrDT[0]);
                                        }
                                        row.TorikomiKekka = "正常取込";
                                    }
                                }
                            }

                            // 結果コード
                            row.SuishitsuKekkaNm = string.Empty;
                            if (!string.IsNullOrEmpty(row.KekkaCd))
                            {
                                ISelectSuishitsuKekkaNmMstByKeyDAInput selIn = new SelectSuishitsuKekkaNmMstByKeyDAInput();
                                selIn.ShishoCd = input.ShishoCd;
                                selIn.SuishitsuKekkaNmCd = row.KekkaCd.PadLeft(3, '0');
                                ISelectSuishitsuKekkaNmMstByKeyDAOutput selOut = new SelectSuishitsuKekkaNmMstByKeyDAOutput();
                                selOut.SuishitsuKekkaNmMstDT = new SelectSuishitsuKekkaNmMstByKeyDataAccess().Execute(selIn).SuishitsuKekkaNmMstDT;

                                if (selOut.SuishitsuKekkaNmMstDT.Rows.Count > 0)
                                {
                                    row.SuishitsuKekkaNm = selOut.SuishitsuKekkaNmMstDT[0].SuishitsuKekkaNm;
                                }
                            }

                            // 判定名
                            row.HaniNm = string.Empty;
                            {
                                IGetConstMstByKbnValueBLInput cmBLInput = new GetConstMstByKbnValueBLInput();
                                cmBLInput.ConstKbn = Utility.Constants.ConstKbnConstanst.CONST_KBN_027;
                                cmBLInput.ConstValue = row.Hani;
                                IGetConstMstByKbnValueBLOutput cmBLOutput = new GetConstMstByKbnValueBusinessLogic().Execute(cmBLInput);
                                if (cmBLOutput.ConstMstDT.Rows.Count > 0)
                                {
                                    row.HaniNm = cmBLOutput.ConstMstDT[0].ConstNm;
                                }
                            }

                            if (hdrOutput.KensaDaicho9joHdrDT.Count > 0)
                            {
                                //row.SuishitsuKekkaNm = (meisaiBLOutput.KensaDaichoMeisaiDT.Count == 0 || meisaiBLOutput.KensaDaichoMeisaiDT[0].IsSuishitsuKekkaNmNull()) ? string.Empty : meisaiBLOutput.KensaDaichoMeisaiDT[0].SuishitsuKekkaNm;
                                row.KensaIraiNendo = hdrOutput.KensaDaicho9joHdrDT[0].KeiryoShomeiIraiNendo;
                                row.KensaIraiHokenjo = hdrOutput.KensaDaicho9joHdrDT[0].KeiryoShomeiIraiSishoCd;
                                row.KensaIraiRenban = hdrOutput.KensaDaicho9joHdrDT[0].KeiryoShomeiIraiRenban;
                                row.KensaIraiNo = string.Concat(row.KensaIraiHokenjo, "-", Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo, "yy"), "-", row.KensaIraiRenban);
                            }
                            i++;
                        }
                    }
                    else
                    {
                        // 水質検査 or 外観検査

                        // 法定検査時は、ヘッダの更新も有り（スクリーニング候補、クロスチェック関連）
                        KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable updateHdrDT = new KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable();

                        // 野帳取込ループ処理開始
                        int i = 1;
                        foreach (YachoDataSet.YachoTorikomiRow row in yachoDT)
                        {
                            row.RowNumber = i.ToString();

                            // 検査台帳ヘッダ情報を取得
                            IGetKensaDaicho11joHdrTblByKeyBLInput hdrInput = new GetKensaDaicho11joHdrTblByKeyBLInput();
                            hdrInput.IraiNendo = input.IraiNendo;
                            hdrInput.KensaKbn = input.KensaShubetsu;
                            hdrInput.ShishoCd = input.ShishoCd;
                            hdrInput.SuishitsuKensaIraiNo = row.SuishitsuKensaIraiNo;
                            IGetKensaDaicho11joHdrTblByKeyBLOutput hdrOutput = new GetKensaDaicho11joHdrTblByKeyBusinessLogic().Execute(hdrInput);

                            // 検査台帳明細情報を取得
                            IGetKensaDaichoMeisai11joBLInput meisaiInput = new GetKensaDaichoMeisai11joBLInput();
                            meisaiInput.IraiNo = row.SuishitsuKensaIraiNo;
                            meisaiInput.Kbn = hdrInput.KensaKbn;
                            meisaiInput.KomokuCd = input.KoumokuCd;
                            meisaiInput.Nendo = input.IraiNendo;
                            meisaiInput.ShishoCd = input.ShishoCd;
                            IGetKensaDaichoMeisai11joBLOutput meisaiOutput = new GetKensaDaichoMeisai11joBusinessLogic().Execute(meisaiInput);

                            // 検査台帳明細情報の追加・更新
                            if (hdrOutput.KensaDaicho11joHdrDT != null && hdrOutput.KensaDaicho11joHdrDT.Count > 0
                                && meisaiOutput.KensaDaichoMeisaiDT != null && meisaiOutput.KensaDaichoMeisaiDT.Count > 0)
                            {
                                KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblRow hdrRow = hdrOutput.KensaDaicho11joHdrDT[0];

                                #region Check SaisaisuiKbn
                                if (hdrRow.SaisaisuiKbn == "0")
                                {
                                    // 再採水区分が 0:初回採水の場合

                                    // 検印済の場合（課長検印区分=1 OR 副課長検印区分=1）
                                    if ((!hdrRow.IsKachoKeninKbnNull() && hdrRow.KachoKeninKbn.Equals("1"))
                                        || (!hdrRow.IsHukuKachoKeninKbnNull() && hdrRow.HukuKachoKeninKbn.Equals("1")))
                                    {
                                        row.TorikomiKekka = "取込エラー";
                                        row.ErrorContent = "検印済";
                                    }
                                    // 未検印の場合（課長検印区分=0 AND 副課長検印区分=0）
                                    else if ((!hdrRow.IsKachoKeninKbnNull() && hdrRow.KachoKeninKbn.Equals("0"))
                                                && (!hdrRow.IsHukuKachoKeninKbnNull() && hdrRow.HukuKachoKeninKbn.Equals("0")))
                                    {
                                        //// 取得レコードが１レコードの場合（再検査回数=0のみ）
                                        //if (meisaiOutput.KensaDaichoMeisaiDT.Count == 1 && meisaiOutput.KensaDaichoMeisaiDT[0].SaikensaKbn.Equals("0"))
                                        //{
                                        //    // DB Update (1)
                                        //    UpdateKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, meisaiOutput.KensaDaichoMeisaiDT[0].UpdateDt, "0", updateDT);

                                        //    row.TorikomiKekka = "正常取込";
                                        //}
                                        //// 取得レコードが２レコードの場合（再検査回数=0,1の両方あり）
                                        //else if (meisaiOutput.KensaDaichoMeisaiDT.Count == 2)
                                        //{
                                        //    // DB Update (2)
                                        //    KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiOutput.KensaDaichoMeisaiDT.Select("SaikensaKbn = '1'");
                                        //    UpdateKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, rows[0].UpdateDt, "1", updateDT);

                                        //    row.TorikomiKekka = "正常取込";
                                        //}

                                        // 通常検査時は初回レコード(SaikensaKbn=0)を処理対象とし、確認検査時は確認検査レコード(SaikensaKbn=1)を処理対象とする
                                        // 存在すれば更新し、存在しない場合は追加を行う。
                                        string selectStr = string.Format("SaikensaKbn = '{0}'", input.TorikomiKensa);
                                        KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiOutput.KensaDaichoMeisaiDT.Select(selectStr);
                                        if (rows.Length > 0)
                                        {
                                            // 更新
                                            UpdateKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, rows[0].UpdateDt, input.TorikomiKensa, updateDT,
                                                hdrOutput.KensaDaicho11joHdrDT[0], null);
                                        }
                                        else
                                        {
                                            // 追加
                                            // ※受付時に初回のレコードは登録されるので、SaikensaKbn=0(初回)のレコードは、ここで作成されることはないはず。
                                            // 　SaikensaKbn=1(確認検査)は追加有り
                                            InsertKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, input.TorikomiKensa, updateDT,
                                                hdrOutput.KensaDaicho11joHdrDT[0], null);
                                        }
                                        row.TorikomiKekka = "正常取込";
                                    }
                                }
                                else
                                {
                                    // 再採水区分が 1:再採水の場合

                                    // 検印済の場合（課長検印区分（再採水）=1 OR 副課長検印区分（再採水）=1）
                                    if ((!hdrRow.IsKachoKeninKbnScreeningNull() && hdrRow.KachoKeninKbnScreening.Equals("1"))
                                        || (!hdrRow.IsHukuKachoKeninKbnScreeningNull() && hdrRow.HukuKachoKeninKbnScreening.Equals("1")))
                                    {
                                        row.TorikomiKekka = "取込エラー";
                                        row.ErrorContent = "検印済";
                                    }
                                    else if (!hdrRow.IsKachoKeninKbnScreeningNull() && hdrRow.KachoKeninKbnScreening.Equals("0")
                                                && !hdrRow.IsHukuKachoKeninKbnScreeningNull() && hdrRow.HukuKachoKeninKbnScreening.Equals("0"))
                                    {
                                        //// 取得レコードが１レコードの場合（再検査回数=0のみ）
                                        //if (meisaiOutput.KensaDaichoMeisaiDT.Count == 1 && meisaiOutput.KensaDaichoMeisaiDT[0].SaikensaKbn.Equals("0"))
                                        //{
                                        //    // DB Update (1)

                                        //    UpdateKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, meisaiOutput.KensaDaichoMeisaiDT[0].UpdateDt, "0", updateDT);

                                        //    row.TorikomiKekka = "正常取込";
                                        //}
                                        //// 取得レコードが２レコードの場合（再検査回数=0,1の両方あり）
                                        //else if (meisaiOutput.KensaDaichoMeisaiDT.Count == 2)
                                        //{
                                        //    // DB Update (2)

                                        //    KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiOutput.KensaDaichoMeisaiDT.Select("SaikensaKbn = '1'");
                                        //    UpdateKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, rows[0].UpdateDt, "1", updateDT);

                                        //    row.TorikomiKekka = "正常取込";
                                        //}

                                        // 通常検査時は初回レコード(SaikensaKbn=0)を処理対象とし、確認検査時は確認検査レコード(SaikensaKbn=1)を処理対象とする
                                        // 存在すれば更新し、存在しない場合は追加を行う。
                                        string selectStr = string.Format("SaikensaKbn = '{0}'", input.TorikomiKensa);
                                        KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiOutput.KensaDaichoMeisaiDT.Select(selectStr);
                                        if (rows.Length > 0)
                                        {
                                            // 更新
                                            UpdateKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, rows[0].UpdateDt, input.TorikomiKensa, updateDT,
                                                hdrOutput.KensaDaicho11joHdrDT[0], null);
                                        }
                                        else
                                        {
                                            // 追加
                                            // ※受付時に初回のレコードは登録されるので、SaikensaKbn=0(初回)のレコードは、ここで作成されることはないはず。
                                            // 　SaikensaKbn=1(確認検査)は追加有り
                                            InsertKensaDaichoMeisai(row, input, now, loginUser, pcUpdate, input.TorikomiKensa, updateDT,
                                                hdrOutput.KensaDaicho11joHdrDT[0], null);
                                        }
                                        row.TorikomiKekka = "正常取込";
                                    }
                                }
                                #endregion
                            }
                            else
                            {
                                row.TorikomiKekka = "取込エラー";
                                row.ErrorContent = "該当の水質検査依頼番号が存在しない";
                            }

                            IGetConstMstByKbnValueBLInput cmBLInput = new GetConstMstByKbnValueBLInput();
                            cmBLInput.ConstKbn = Utility.Constants.ConstKbnConstanst.CONST_KBN_027;
                            cmBLInput.ConstValue = row.Hani;
                            IGetConstMstByKbnValueBLOutput cmBLOutput = new GetConstMstByKbnValueBusinessLogic().Execute(cmBLInput);
                            row.HaniNm = cmBLOutput.ConstMstDT.Count > 0 ? cmBLOutput.ConstMstDT[0].ConstNm : string.Empty;
                            row.KensaIraiHoteiKbnNm = meisaiOutput.KensaDaichoMeisaiDT.Count > 0 ? meisaiOutput.KensaDaichoMeisaiDT[0].HoteiKbnNm : string.Empty;

                            if (hdrOutput.KensaDaicho11joHdrDT.Count > 0)
                            {
                                row.KensaIraiHoteiKbn = hdrOutput.KensaDaicho11joHdrDT[0].KensaKekkaIraiHoteiKbn;
                                row.KensaIraiNendo = hdrOutput.KensaDaicho11joHdrDT[0].KensaKekkaIraiNendo;
                                row.KensaIraiRenban = hdrOutput.KensaDaicho11joHdrDT[0].KensaKekkaIraiRenban;
                                row.KensaIraiHokenjo = hdrOutput.KensaDaicho11joHdrDT[0].KensaKekkaIraiHokenjoCd;
                                row.KensaIraiNo = string.Concat(row.KensaIraiHokenjo, "-", Utility.DateUtility.ConvertToWareki(row.KensaIraiNendo, "yy"), "-", row.KensaIraiRenban);
                            }

                            i++;

                            if (row.TorikomiKekka == "正常取込")
                            {
                                // 検査台帳ヘッダ情報
                                // 更新日
                                hdrOutput.KensaDaicho11joHdrDT[0].UpdateDt = now;
                                // 更新者
                                hdrOutput.KensaDaicho11joHdrDT[0].UpdateUser = loginUser;
                                // 更新端末
                                hdrOutput.KensaDaicho11joHdrDT[0].UpdateTarm = pcUpdate;
                                updateHdrDT.ImportRow(hdrOutput.KensaDaicho11joHdrDT[0]);
                            }
                        }

                        if (updateHdrDT.Rows.Count > 0)
                        {
                            // ヘッダ情報を更新
                            IUpdateKensaDaicho11joHdrTblDAInput updateHdrInput = new UpdateKensaDaicho11joHdrTblDAInput();
                            updateHdrInput.KensaDaicho11joHdrTblDataTable = updateHdrDT;
                            new UpdateKensaDaicho11joHdrTblDataAccess().Execute(updateHdrInput);
                        }
                    }

                    if (updateDT.Count > 0)
                    {
                        IUpdateKensaDaichoDtlTblBLInput updateBLInput = new UpdateKensaDaichoDtlTblBLInput();
                        updateBLInput.KensaDaichoDtlTblDT = updateDT;
                        new UpdateKensaDaichoDtlTblBusinessLogic().Execute(updateBLInput);
                    }

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

                #endregion

                #region Upload file

//                if (yachoDT.Count > 0)
                if (yachoDT.Count > 0 && input.TorikomiKensa == "0")
                {
                    // 取込データあり　&&　通常検査の場合

                    YachoDataSet.YachoTorikomiRow[] rows = (YachoDataSet.YachoTorikomiRow[])yachoDT.Select(string.Empty, "SuishitsuKensaIraiNo ASC");

                    string minSuishitsuKensaIraiNo = rows[0].SuishitsuKensaIraiNo;
                    string maxSuishitsuKensaIraiNo = rows[rows.Length - 1].SuishitsuKensaIraiNo;


                    // Ｅｘｃｅｌのアプリケーションオブジェクトを定義
                    Microsoft.Office.Interop.Excel.Application excel = null;
                    // Ｅｘｃｅｌのブックオブジェクトを定義
                    Microsoft.Office.Interop.Excel.Workbook book = null;
                    // Ｅｘｃｅｌのシートオブジェクトを定義
                    Worksheet sheet = null;

                    try
                    {

                        // Ｅｘｃｅｌのアプリケーションオブジェクトを作成
                        excel = new Microsoft.Office.Interop.Excel.Application();

                        // 非表示状態に設定
                        excel.Visible = false;

                        // Ｅｘｃｅｌを開いてブックオブジェクトを取得
                        book = excel.Workbooks.Open(
                            input.ExcelPath,
                            Type.Missing,
                            true,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing,
                            Type.Missing);

                        string pdfFileName = Path.Combine(FukjBizSystem.Properties.Settings.Default.PrintDirectory, String.Concat(Path.GetFileNameWithoutExtension(input.ExcelPath), ".PDF"));

                        // 出力先存在チェック
                        if (!Directory.Exists(Path.GetDirectoryName(pdfFileName)))
                        {
                            // 存在しない場合、フォルダ作成
                            Directory.CreateDirectory(Path.GetDirectoryName(pdfFileName));
                        }

                        book.ExportAsFixedFormat(XlFixedFormatType.xlTypePDF, pdfFileName);

                        string serverFolder = SharedFolderUtility.GetConstServerFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_051, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002);
                        string uploadFolder = serverFolder + @"\" + input.IraiNendo + @"\" + input.ShishoNm + @"\" + input.RadioBtnNm + @"\" + input.SeishikiNm + @"\" + minSuishitsuKensaIraiNo + @"-" + maxSuishitsuKensaIraiNo;
                        string newFilePath = Path.Combine(uploadFolder, string.Concat(Path.GetFileNameWithoutExtension(input.ExcelPath), ".PDF"));

                        // ダウンロード
                        try
                        {
                            // 共有フォルダに接続
                            if (!SharedFolderUtility.Connect())
                            {
                                // サーバに接続できません
                                // 「サーバに接続できません。{0}」
                                output.ErrorCode = 3;
                                output.ErrorMessage = string.Format("サーバに接続できません。{0}", Path.GetDirectoryName(newFilePath));
                                return output;
                            }

                            if (!Directory.Exists(uploadFolder))
                            {
                                Directory.CreateDirectory(uploadFolder);
                            }

                            if (File.Exists(newFilePath))
                            {
                                // 共有フォルダにアップロード
                                if (!SharedFolderUtility.UploadFile(pdfFileName, newFilePath, true))
                                {
                                    // サーバへのアップロードに失敗しました。
                                    // 「サーバへのアップロードに失敗しました。{0}」
                                    output.ErrorCode = 3;
                                    output.ErrorMessage = string.Format("サーバへのアップロードに失敗しました。{0} {1}", newFilePath, pdfFileName);
                                    return output;
                                }
                            }
                            else
                            {
                                // 共有フォルダにアップロード
                                if (!SharedFolderUtility.UploadFile(pdfFileName, newFilePath, true))
                                {
                                    // サーバへのアップロードに失敗しました。
                                    // 「サーバへのアップロードに失敗しました。{0}」
                                    output.ErrorCode = 3;
                                    output.ErrorMessage = string.Format("サーバへのアップロードに失敗しました。{0} {1}", newFilePath, pdfFileName);
                                    return output;
                                }
                            }
                        }
                        catch (Exception)
                        {
                            // エラー処理
                            // 共有フォルダへのアクセスに失敗しました。
                            output.ErrorCode = 3;
                            output.ErrorMessage = string.Format("共有フォルダへのアクセスに失敗しました。{0}", Path.GetDirectoryName(newFilePath));
                            return output;
                        }
                        finally
                        {
                            // 共有フォルダから切断
                            SharedFolderUtility.Disconnect();
                        }
                    }
                    catch
                    {
                        throw;
                    }
                    finally
                    {
                        TraceLog.EndWrite(MethodInfo.GetCurrentMethod());

                        //ExcelApplicationを終了させる             
                        if (excel != null)
                        {
                            if (book != null)
                            {
                                if (sheet != null)
                                {
                                    Marshal.ReleaseComObject(sheet);
                                }
                                book.Close(false, false, Type.Missing);
                                Marshal.ReleaseComObject(book);
                            }
                            excel.DisplayAlerts = false;
                            excel.Quit();
                            Marshal.ReleaseComObject(excel);
                        }

                        GC.Collect();
                    }
                }

                #endregion

                output.YachoTorikomiDataTable = yachoDT;
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

        #region TorikomiCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： TorikomiCheck
        /// <summary>
        /// 取込前の事前チェック
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/09　小松  　　　新規追加
        /// 2015/01/11　小松  　　　桁数チェック、結果コードのマスタチェック
        /// 2015/01/21　小松  　　　チェックエラー時にトランザクション管理が正しく行われていない
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ITorikomiBtnClickALOutput TorikomiCheck(ITorikomiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ITorikomiBtnClickALOutput output = new TorikomiBtnClickALOutput();

            try
            {
                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();
                YachoDataSet.YachoTorikomiDataTable yachoDT = new YachoDataSet.YachoTorikomiDataTable();

                #region Update DB
                try
                {
                    StartTransaction();
                    string ext = Path.GetExtension(input.ExcelPath).ToLower();
                    if (ext.Equals(".csv"))
                    {
                        IGetYachoCsvDataBLInput yachoCsvBLInput = new GetYachoCsvDataBLInput();
                        yachoCsvBLInput.CsvFilePath = input.ExcelPath;
                        yachoCsvBLInput.KoumokuCd = input.KoumokuCd;
                        IGetYachoCsvDataBLOutput yachoCsvBLOutput = new GetYachoCsvDataBusinessLogic().Execute(yachoCsvBLInput);
                        output.ErrorCode = yachoCsvBLOutput.ErrorCode;
                        output.ErrorMessage = yachoCsvBLOutput.ErrorMessage;
                        yachoDT = yachoCsvBLOutput.YachoTorikomiDataTable;
                        if (output.ErrorCode != 0)
                        {
                            return output;
                        }
                    }
                    else
                    {
                        IGetYachoExcelDataBLOutput yachoExcelBLOutput = new GetYachoExcelDataBusinessLogic().Execute(input);
                        output.ErrorCode = yachoExcelBLOutput.ErrorCode;
                        output.ErrorMessage = yachoExcelBLOutput.ErrorMessage;
                        yachoDT = yachoExcelBLOutput.YachoTorikomiDataTable;
                        if (output.ErrorCode != 0)
                        {
                            return output;
                        }
                    }

                    KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable updateDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();

                    if (input.KensaShubetsu.Equals("1"))
                    {
                        // 計量証明

                        // 結果値、結果コードの事前チェック
                        foreach (YachoDataSet.YachoTorikomiRow row in yachoDT)
                        {
                            // 結果値の桁数チェック
                            if (!row.IsKekkaValueNull() && !checkKekkaValue(row.KekkaValue))
                            {
                                // 範囲外の数値
                                output.ErrorCode = 2;
                                output.ErrorMessage = string.Format("結果値が範囲外の試験結果が存在します。\n依頼番号:[{0}]  結果値:[{1}]", row.SuishitsuKensaIraiNo, row.KekkaValue);
                                return output;
                            }

                            // 温度の桁数チェック
                            if (!row.IsOndoNull() && !checkOndo(row.Ondo))
                            {
                                // 範囲外の数値
                                output.ErrorCode = 2;
                                output.ErrorMessage = string.Format("温度が範囲外の試験結果が存在します。\n依頼番号:[{0}]  温度:[{1}]", row.SuishitsuKensaIraiNo, row.Ondo);
                                return output;
                            }

                            // 結果コードの有無をチェック
                            row.SuishitsuKekkaNm = string.Empty;
                            if (!string.IsNullOrEmpty(row.KekkaCd))
                            {
                                ISelectSuishitsuKekkaNmMstByKeyDAInput selIn = new SelectSuishitsuKekkaNmMstByKeyDAInput();
                                selIn.ShishoCd = input.ShishoCd;
                                selIn.SuishitsuKekkaNmCd = row.KekkaCd.PadLeft(3, '0');
                                ISelectSuishitsuKekkaNmMstByKeyDAOutput selOut = new SelectSuishitsuKekkaNmMstByKeyDAOutput();
                                selOut.SuishitsuKekkaNmMstDT = new SelectSuishitsuKekkaNmMstByKeyDataAccess().Execute(selIn).SuishitsuKekkaNmMstDT;

                                if (selOut.SuishitsuKekkaNmMstDT.Rows.Count == 0)
                                {
                                    // 範囲外の結果コード
                                    output.ErrorCode = 2;
                                    output.ErrorMessage = string.Format("結果コードが水質結果名称マスタに存在しない試験結果が存在します。\n依頼番号:[{0}]  結果コード[{1}]", row.SuishitsuKensaIraiNo, row.KekkaCd);
                                    return output;
                                }
                            }
                        }

                        // 野帳取込ループ処理開始
                        foreach (YachoDataSet.YachoTorikomiRow row in yachoDT)
                        {
                            // 取込結果
                            string torikomiKekka = string.Empty;

                            // エラー内容
                            string errContent = string.Empty;

                            // 検査台帳ヘッダ情報を取得
                            IGetKensaDaicho9joHdrTblByKeyBLInput hdrInput = new GetKensaDaicho9joHdrTblByKeyBLInput();
                            hdrInput.IraiNendo = input.IraiNendo;
                            hdrInput.ShishoCd = input.ShishoCd;
                            hdrInput.SuishitsuKensaIraiNo = row.SuishitsuKensaIraiNo;
                            IGetKensaDaicho9joHdrTblByKeyBLOutput hdrOutput = new GetKensaDaicho9joHdrTblByKeyBusinessLogic().Execute(hdrInput);

                            IGetKensaDaichoMeisai9joBLInput meisaiBLInput = new GetKensaDaichoMeisai9joBLInput();
                            meisaiBLInput.IraiNendo = input.IraiNendo;
                            meisaiBLInput.ShikenkoumokuCd = input.KoumokuCd;
                            meisaiBLInput.ShishoCd = input.ShishoCd;
                            meisaiBLInput.SuishitsuKensaIraiNo = row.SuishitsuKensaIraiNo;
                            IGetKensaDaichoMeisai9joBLOutput meisaiBLOutput = new GetKensaDaichoMeisai9joBusinessLogic().Execute(meisaiBLInput);

                            // 登録可能かの確認チェック
                            {
                                if (input.TorikomiKensa == "0")
                                {
                                    // 通常検査の場合

                                    // 通常検査の重複レコード確認
                                    KensaDaicho9joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho9joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiBLOutput.KensaDaichoMeisaiDT.Select("SaikensaKbn = '0'");
                                    if (rows.Length > 0 && rows[0].KeiryoShomeiKekkaNyuryoku == "1")
                                    {
                                        // 12:既に通常検査の取込あり
                                        output.ErrorCode = 12;
                                        return output;
                                    }
                                }
                                else
                                {
                                    // 確認検査の場合

                                    // 通常検査のレコード有無確認(再検査：0(初回)、結果入力：1(入力済))
                                    KensaDaicho9joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho9joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiBLOutput.KensaDaichoMeisaiDT.Select("SaikensaKbn = '0' and KeiryoShomeiKekkaNyuryoku = '1'");
                                    if (rows.Length <= 0)
                                    {
                                        // 11:確認検査時に通常検査無し
                                        output.ErrorCode = 11;
                                        return output;
                                    }
                                    // 確認検査の重複レコード確認
                                    rows = (KensaDaicho9joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiBLOutput.KensaDaichoMeisaiDT.Select("SaikensaKbn = '1'");
                                    if (rows.Length > 0 && rows[0].KeiryoShomeiKekkaNyuryoku == "1")
                                    {
                                        // 13:既に確認検査の取込あり
                                        output.ErrorCode = 13;
                                        return output;
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        // 水質検査 or 外観検査

                        // 結果値の事前チェック
                        foreach (YachoDataSet.YachoTorikomiRow row in yachoDT)
                        {
                            // 結果値の桁数チェック
                            if (!row.IsKekkaValueNull() && !checkKekkaValue(row.KekkaValue))
                            {
                                // 範囲外の数値
                                output.ErrorCode = 2;
                                output.ErrorMessage = string.Format("結果値が範囲外の試験結果が存在します。\n依頼番号:[{0}]  結果値:[{1}]", row.SuishitsuKensaIraiNo, row.KekkaValue);
                                return output;
                            }

                            // 温度の桁数チェック
                            if (!row.IsOndoNull() && !checkOndo(row.Ondo))
                            {
                                // 範囲外の数値
                                output.ErrorCode = 2;
                                output.ErrorMessage = string.Format("温度が範囲外の試験結果が存在します。\n依頼番号:[{0}]  温度:[{1}]", row.SuishitsuKensaIraiNo, row.Ondo);
                                return output;
                            }
                        }

                        // 野帳取込ループ処理開始
                        int i = 1;
                        foreach (YachoDataSet.YachoTorikomiRow row in yachoDT)
                        {
                            row.RowNumber = i.ToString();

                            // 検査台帳ヘッダ情報を取得
                            IGetKensaDaicho11joHdrTblByKeyBLInput hdrInput = new GetKensaDaicho11joHdrTblByKeyBLInput();
                            hdrInput.IraiNendo = input.IraiNendo;
                            hdrInput.KensaKbn = input.KensaShubetsu;
                            hdrInput.ShishoCd = input.ShishoCd;
                            hdrInput.SuishitsuKensaIraiNo = row.SuishitsuKensaIraiNo;
                            IGetKensaDaicho11joHdrTblByKeyBLOutput hdrOutput = new GetKensaDaicho11joHdrTblByKeyBusinessLogic().Execute(hdrInput);

                            // 検査台帳明細情報を取得
                            IGetKensaDaichoMeisai11joBLInput meisaiInput = new GetKensaDaichoMeisai11joBLInput();
                            meisaiInput.IraiNo = row.SuishitsuKensaIraiNo;
                            meisaiInput.Kbn = hdrInput.KensaKbn;
                            meisaiInput.KomokuCd = input.KoumokuCd;
                            meisaiInput.Nendo = input.IraiNendo;
                            meisaiInput.ShishoCd = input.ShishoCd;
                            IGetKensaDaichoMeisai11joBLOutput meisaiOutput = new GetKensaDaichoMeisai11joBusinessLogic().Execute(meisaiInput);

                            // 登録可能かの確認チェック
                            {
                                if (input.TorikomiKensa == "0")
                                {
                                    // 通常検査の場合

                                    // 通常検査の重複レコード確認
                                    KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiOutput.KensaDaichoMeisaiDT.Select("SaikensaKbn = '0'");
                                    if (rows.Length > 0 && rows[0].KeiryoShomeiKekkaNyuryoku == "1")
                                    {
                                        // 12:既に通常検査の取込あり
                                        output.ErrorCode = 12;
                                        return output;
                                    }
                                }
                                else
                                {
                                    // 確認検査の場合

                                    // 通常検査のレコード有無確認(再検査：0(初回)、結果入力：1(入力済))
                                    KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[] rows = (KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiOutput.KensaDaichoMeisaiDT.Select("SaikensaKbn = '0' and KeiryoShomeiKekkaNyuryoku = '1'");
                                    if (rows.Length <= 0)
                                    {
                                        // 11:確認検査時に通常検査無し
                                        output.ErrorCode = 11;
                                        return output;
                                    }
                                    // 確認検査の重複レコード確認
                                    rows = (KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiRow[])meisaiOutput.KensaDaichoMeisaiDT.Select("SaikensaKbn = '1'");
                                    if (rows.Length > 0 && rows[0].KeiryoShomeiKekkaNyuryoku == "1")
                                    {
                                        // 13:既に確認検査の取込あり
                                        output.ErrorCode = 13;
                                        return output;
                                    }
                                }
                            }
                        }
                    }
                }
                finally
                {
                    EndTransaction();
                }
                #endregion
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

        #region Private

        #region UpdateKensaDaichoMeisai
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateKensaDaichoMeisai
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="loginUser"></param>
        /// <param name="now"></param>
        /// <param name="pcUpdate"></param>
        /// <param name="row"></param>
        /// <param name="saikensaKbn"></param>
        /// <param name="updateDt"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　HieuNH　　　新規作成
        /// 2014/12/24　小松　　　　採用区分は更新対象外
        /// 　　　　　　　　　　　　計量証明時：結果値２=0、法定検査時：結果コード=0をセット
        /// 2015/01/15  小松　　　　確認検査種別を判定し設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateKensaDaichoMeisai(YachoDataSet.YachoTorikomiRow row, ITorikomiBtnClickALInput input, DateTime now, string loginUser, string pcUpdate, DateTime updateDt, string saikensaKbn, 
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable updateDataTable,
            KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblRow kensaDaicho11HdrRow,
            KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblRow kensaDaicho9HdrRow
        )
        {
            IGetKensaDaichoDtlTblByKeyBLInput kddtBLInput = new GetKensaDaichoDtlTblByKeyBLInput();
            kddtBLInput.IraiNendo = input.IraiNendo;
            kddtBLInput.IraiNo = row.SuishitsuKensaIraiNo;
            kddtBLInput.Kbn = input.KensaShubetsu;
            kddtBLInput.SaikensaKbn = saikensaKbn;
            kddtBLInput.ShikenkoumokuCd = input.KoumokuCd;
            kddtBLInput.Sisho = input.ShishoCd;
            IGetKensaDaichoDtlTblByKeyBLOutput kddtBLOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(kddtBLInput);

            // Check Rakkan Lock
            if (kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateDt != updateDt)
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
            if (row.IsKekkaValueNull())
            {
                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = 0;
            }
            else
            {
                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = row.KekkaValue;
            }
            // 結果値２
            if (row.IsHaniNull() || row.Hani == null || input.KensaShubetsu == "1")
            {
                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = "0";
            }
            else
            {
                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = row.Hani;
            }
            // 結果コード
            if (row.IsKekkaCdNull() || row.KekkaCd == null || input.KensaShubetsu != "1")
            {
                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaCd = "0";
            }
            else
            {
                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaCd = row.KekkaCd;
            }
            // 温度数
            if (row.IsOndoNull())
            {
                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaOndo = 0;
            }
            else
            {
                kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaOndo = row.Ondo;
            }
            // 結果入力
            kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaNyuryoku = "1";
            // 外部委託フラグ
            kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiGaibuItakuFlg = "0";
            //// 採用区分
            //kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = "0";

            // 更新日
            kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateDt = now;

            // 更新者
            kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateUser = loginUser;

            // 更新端末
            kddtBLOutput.KensaDaichoDtlTblDT[0].UpdateTarm = pcUpdate;

            // 確認検査種別を判定し設定
            if (input.KensaShubetsu == "1")
            {
                // 計量証明
                Utility.KakuninKensaUtility.SetKakuninKensaShubetsuForKeiryoShomei(
                    kensaDaicho9HdrRow,
                    kddtBLOutput.KensaDaichoDtlTblDT[0],
                    kensaDaicho9HdrRow.KeiryoShomeiIraiNendo,
                    kensaDaicho9HdrRow.KeiryoShomeiIraiSishoCd,
                    kensaDaicho9HdrRow.KeiryoShomeiIraiRenban,
                    input.KensaShubetsu,
                    input.IraiNendo,
                    input.ShishoCd,
                    kddtBLOutput.KensaDaichoDtlTblDT[0].SuishitsuKensaIraiNo,
                    kddtBLOutput.KensaDaichoDtlTblDT[0].ShikenkoumokuCd,
                    kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue);
            }
            else
            {
                // 法定検査
                Utility.KakuninKensaUtility.SetKakuninKensaShubetsuForHoteiKensa(
                    kensaDaicho11HdrRow,
                    kddtBLOutput.KensaDaichoDtlTblDT[0],
                    kensaDaicho11HdrRow.KensaKekkaIraiHoteiKbn,
                    kensaDaicho11HdrRow.KensaKekkaIraiHokenjoCd,
                    kensaDaicho11HdrRow.KensaKekkaIraiNendo,
                    kensaDaicho11HdrRow.KensaKekkaIraiRenban,
                    input.KensaShubetsu,
                    input.IraiNendo,
                    input.ShishoCd,
                    kddtBLOutput.KensaDaichoDtlTblDT[0].SuishitsuKensaIraiNo,
                    kddtBLOutput.KensaDaichoDtlTblDT[0].ShikenkoumokuCd,
                    kddtBLOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue);
            }

            updateDataTable.ImportRow(kddtBLOutput.KensaDaichoDtlTblDT[0]);
        }
        #endregion

        #region InsertKensaDaichoMeisai
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InsertKensaDaichoMeisai
        /// <summary>
        /// 検査台帳明細テーブルにレコード追加
        /// </summary>
        /// <param name="row"></param>
        /// <param name="input"></param>
        /// <param name="now"></param>
        /// <param name="loginUser"></param>
        /// <param name="pcUpdate"></param>
        /// <param name="saikensaKbn"></param>
        /// <param name="updateDataTable"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/09　小松    　　新規作成
        /// 2015/01/15  小松　　　　確認検査種別を判定し設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InsertKensaDaichoMeisai(YachoDataSet.YachoTorikomiRow row, ITorikomiBtnClickALInput input, DateTime now, string loginUser, string pcUpdate, string saikensaKbn, 
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable updateDataTable,
            KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblRow kensaDaicho11HdrRow,
            KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblRow kensaDaicho9HdrRow
        )
        {
            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow addDtlRow = updateDataTable.NewKensaDaichoDtlTblRow();

            // 検査区分（1:計量証明/2:水質検査/3:外観検査)）
            addDtlRow.KensaKbn = input.KensaShubetsu;
            // 依頼年度
            addDtlRow.IraiNendo = input.IraiNendo;
            // 支所コード
            addDtlRow.ShishoCd = input.ShishoCd;
            // 水質検査依頼番号
            addDtlRow.SuishitsuKensaIraiNo = row.SuishitsuKensaIraiNo;
            // 試験項目コード
            addDtlRow.ShikenkoumokuCd = input.KoumokuCd; 
            // 再検査回数
            addDtlRow.SaikensaKbn = saikensaKbn;
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
            if (row.IsKekkaValueNull())
            {
                addDtlRow.KeiryoShomeiKekkaValue = 0;
            }
            else
            {
                addDtlRow.KeiryoShomeiKekkaValue = row.KekkaValue;
            }
            // 結果値２
            if (row.IsHaniNull() || row.Hani == null || input.KensaShubetsu == "1")
            {
                addDtlRow.KeiryoShomeiKekkaValue2 = "0";
            }
            else
            {
                addDtlRow.KeiryoShomeiKekkaValue2 = row.Hani;
            }
            // 結果コード
            if (row.IsKekkaCdNull() || row.KekkaCd == null || input.KensaShubetsu != "1")
            {
                addDtlRow.KeiryoShomeiKekkaCd = "0";
            }
            else
            {
                addDtlRow.KeiryoShomeiKekkaCd = row.KekkaCd;
            }
            // 温度数
            if (row.IsOndoNull())
            {
                addDtlRow.KeiryoShomeiKekkaOndo = 0;
            }
            else
            {
                addDtlRow.KeiryoShomeiKekkaOndo = row.Ondo;
            }
            // 結果入力
            addDtlRow.KeiryoShomeiKekkaNyuryoku = "1";
            // 外部委託フラグ
            addDtlRow.KeiryoShomeiGaibuItakuFlg = "0";
            // 採用区分
            addDtlRow.KeiryoShomeiSaiyoKbn = "0";
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

            addDtlRow.InsertDt = now;
            addDtlRow.InsertUser = loginUser;
            addDtlRow.InsertTarm = pcUpdate;
            addDtlRow.UpdateDt = now;
            addDtlRow.UpdateUser = loginUser;
            addDtlRow.UpdateTarm = pcUpdate;

            // 確認検査種別を判定し設定
            if (input.KensaShubetsu == "1")
            {
                // 計量証明
                Utility.KakuninKensaUtility.SetKakuninKensaShubetsuForKeiryoShomei(
                    kensaDaicho9HdrRow,
                    addDtlRow,
                    kensaDaicho9HdrRow.KeiryoShomeiIraiNendo,
                    kensaDaicho9HdrRow.KeiryoShomeiIraiSishoCd,
                    kensaDaicho9HdrRow.KeiryoShomeiIraiRenban,
                    input.KensaShubetsu,
                    input.IraiNendo,
                    input.ShishoCd,
                    addDtlRow.SuishitsuKensaIraiNo,
                    addDtlRow.ShikenkoumokuCd,
                    addDtlRow.KeiryoShomeiKekkaValue);
            }
            else
            {
                // 法定検査
                Utility.KakuninKensaUtility.SetKakuninKensaShubetsuForHoteiKensa(
                    kensaDaicho11HdrRow,
                    addDtlRow,
                    kensaDaicho11HdrRow.KensaKekkaIraiHoteiKbn,
                    kensaDaicho11HdrRow.KensaKekkaIraiHokenjoCd,
                    kensaDaicho11HdrRow.KensaKekkaIraiNendo,
                    kensaDaicho11HdrRow.KensaKekkaIraiRenban,
                    input.KensaShubetsu,
                    input.IraiNendo,
                    input.ShishoCd,
                    addDtlRow.SuishitsuKensaIraiNo,
                    addDtlRow.ShikenkoumokuCd,
                    addDtlRow.KeiryoShomeiKekkaValue);
            }

            updateDataTable.AddKensaDaichoDtlTblRow(addDtlRow);
            addDtlRow.AcceptChanges();
            addDtlRow.SetAdded();
        }
        #endregion

        #region getPrecision
        /// <summary>
        /// 小数点以下の桁数を取得
        /// </summary>
        private int getPrecision(decimal value)
        {
            string valueString = value.ToString().TrimEnd('0');

            int index = valueString.IndexOf('.');
            if (index == -1)
            {
                return 0;
            }
            return valueString.Substring(index + 1).Length;
        }
        #endregion

        #region checkKekkaValue
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： checkKekkaValue
        /// <summary>
        /// 結果値の桁数が正しいかチェック
        /// 整数部6桁、小数部3桁
        /// </summary>
        /// <param name="value">結果値</param>
        /// <returns>true:範囲内/false:範囲外</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/11　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private bool checkKekkaValue(decimal value)
        {
            if (getPrecision(value) >= 4)
            {
                // 小数部4桁以上：範囲外
                return false;
            }
            if (value >= 1000000)
            {
                // 小数部7桁以上：範囲外
                return false;
            }
            return true;
        }
        #endregion

        #region checkOndo
        ///////////////////////////////////////////////////////////////
        //  メソッド名 ： checkOndo
        /// <summary>
        /// 温度の桁数が正しいかチェック
        /// 整数部2桁、小数部3桁
        /// </summary>
        /// <param name="value">温度</param>
        /// <returns>true:範囲内/false:範囲外</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/11　小松　　    新規作成
        /// </history>
        ///////////////////////////////////////////////////////////////
        private bool checkOndo(decimal value)
        {
            if (getPrecision(value) >= 4)
            {
                // 小数部4桁以上：範囲外
                return false;
            }
            if (value >= 100)
            {
                // 小数部3桁以上：範囲外
                return false;
            }
            return true;
        }
        #endregion

        #endregion
    }
    #endregion
}
