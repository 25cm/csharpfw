using System;
using System.IO;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KeiryoShomeiOutputList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KeiryoShomeiOutputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// Print Type = 1 export file 051 else 052
        /// </summary>
        int PrintType { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        string Renban { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        string SishoCd { get; set; }

        /// <summary>
        /// Convert file status
        /// </summary>
        bool ConvertStatus { get; set; }

        /// <summary>
        /// Pdf filename
        /// </summary>
        string FileNamePdf { get; set; }

        /// <summary>
        /// Edaban CheckBox
        /// </summary>
        bool EdabanChecked { get; set; }

        /// <summary>
        /// Save file directory
        /// </summary>
        string SavePath { get; set; }

        /// <summary>
        /// 更新日
        /// </summary>
        DateTime UpdateDt { get; set; }

        /// <summary>
        /// KeiryoShomeiShomeishoInsatsuCnt
        /// </summary>
        bool IsPlusCnt { get; set; }

        /// <summary>
        /// 部数 (busuTextBox)
        /// </summary>
        int PrintCnt { get; set; }

        /// <summary>
        /// KeiryoShomeiOutputListDataTable
        /// </summary>
        KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable KeiryoShomeiOutputListDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALInput : IPrintBtnClickALInput
    {
        /// <summary>
        /// Print Type = 1 export file 051 else 052
        /// </summary>
        public int PrintType { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        public string Renban { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        public string SishoCd { get; set; }

        /// <summary>
        /// Convert file status
        /// </summary>
        public bool ConvertStatus { get; set; }

        /// <summary>
        /// Pdf filename
        /// </summary>
        public string FileNamePdf { get; set; }

        /// <summary>
        /// Edaban CheckBox
        /// </summary>
        public bool EdabanChecked { get; set; }

        /// <summary>
        /// Save file directory
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// 更新日
        /// </summary>
        public DateTime UpdateDt { get; set; }

        /// <summary>
        /// KeiryoShomeiShomeishoInsatsuCnt
        /// </summary>
        public bool IsPlusCnt { get; set; }

        /// <summary>
        /// 部数 (busuTextBox)
        /// </summary>
        public int PrintCnt { get; set; }

        /// <summary>
        /// GaichuKensaListDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable KeiryoShomeiOutputListDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("KeiryoShomeiOutputListDataTable.KeiryoShomeiIraiSishoCd[{0}]", KeiryoShomeiOutputListDataTable[0].KeiryoShomeiIraiSishoCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALOutput
    {
        /// <summary>
        /// Print Exception
        /// </summary>
        bool PrintErr { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiTblDataTable
        /// </summary>
        KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALOutput : IPrintBtnClickALOutput
    {
        /// <summary>
        /// Print Exception
        /// </summary>
        public bool PrintErr { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiTblDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickApplicationLogic : BaseApplicationLogic<IPrintBtnClickALInput, IPrintBtnClickALOutput>
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
        private const string FunctionName = "KeiryoShomeiOutputList：PrintBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintBtnClickApplicationLogic()
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
        /// 2014/11/24  ThanhVX　    新規作成
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
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPrintBtnClickALOutput Execute(IPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPrintBtnClickALOutput output = new PrintBtnClickALOutput();

            try
            {
                if (input.PrintType == 1) // Print file 051_濃度計量証明書_帳票設計書
                {
                    IPrintKeiryoShomeiOutputListType1BLInput blInput = new PrintKeiryoShomeiOutputListType1BLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.AfterPrintFlg = true;
                    blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.NodoKeiryoShomeishoFormatFile;
                    blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.Nendo = input.Nendo;
                    blInput.Renban = input.Renban;
                    blInput.SishoCd = input.SishoCd;
                    blInput.IsPlusCnt = input.IsPlusCnt;
                    blInput.CopyCount = input.PrintCnt;
                    if (input.ConvertStatus)
                    {
                        blInput.SaveFileMode = 1;
                        if (!String.IsNullOrEmpty(input.SavePath))
                            blInput.SavePath = Path.Combine(input.SavePath, input.FileNamePdf);
                    }

                    IPrintKeiryoShomeiOutputListType1BLOutput blOutput = new PrintKeiryoShomeiOutputListType1BusinessLogic().Execute(blInput);
                    // Print Error status
                    output.PrintErr = blOutput.PrintErr;
                    // Update 
                    KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable updateTbl = blOutput.KeiryoShomeiIraiTblDataTable;                    
                    StartTransaction();
                    if (input.UpdateDt != null && input.UpdateDt != updateTbl[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }
                    UpdateValues(ref updateTbl, input.EdabanChecked);
                    UpdateKeiryoShomeiIraiTblBLInput blUpdateInput = new UpdateKeiryoShomeiIraiTblBLInput();
                    blUpdateInput.KeiryoShomeiIraiTblDT = updateTbl;
                    new UpdateKeiryoShomeiIraiTblBusinessLogic().Execute(blUpdateInput);
                    CompleteTransaction();
                }
                else // Print file 052_分析結果報告書_帳票設計書
                {
                    IPrintKeiryoShomeiOutputListType2BLInput blInput = new PrintKeiryoShomeiOutputListType2BLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.AfterPrintFlg = true;
                    blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.BunsekiKekkaHokokushoFormatFile;
                    blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.Nendo = input.Nendo;
                    blInput.Renban = input.Renban;
                    blInput.SishoCd = input.SishoCd;
                    blInput.IsPlusCnt = input.IsPlusCnt;
                    blInput.CopyCount = input.PrintCnt;
                    if (input.ConvertStatus)
                    {
                        blInput.SaveFileMode = 1;
                        if (!String.IsNullOrEmpty(input.SavePath))
                            blInput.SavePath = Path.Combine(input.SavePath, input.FileNamePdf);
                    }
                    IPrintKeiryoShomeiOutputListType2BLOutput blOutput = new PrintKeiryoShomeiOutputListType2BusinessLogic().Execute(blInput);
                    // Print Error status
                    output.PrintErr = blOutput.PrintErr;
                    // Update 
                    KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable updateTbl = blOutput.KeiryoShomeiIraiTblDataTable;
                    StartTransaction();
                    if (input.UpdateDt != null && input.UpdateDt != updateTbl[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }
                    UpdateValues(ref updateTbl, input.EdabanChecked);
                    UpdateKeiryoShomeiIraiTblBLInput blUpdateInput = new UpdateKeiryoShomeiIraiTblBLInput();
                    blUpdateInput.KeiryoShomeiIraiTblDT = updateTbl;
                    new UpdateKeiryoShomeiIraiTblBusinessLogic().Execute(blUpdateInput);
                    CompleteTransaction();
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
                EndTransaction();
            }

            return output;
        }


        private void UpdateValues(ref KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable input, bool ebadanChecked)
        {
            // 証明書発行フラグ 
            input[0].KeiryoShomeiShomeishoHakkouFlg = "1";
            // ステータス区分 
            input[0].KeiryoShomeiStatusKbn = "80";
            // 証明書印刷回数 
            if (ebadanChecked)
            {
                int cnt = input[0].IsKeiryoShomeiShomeishoInsatsuCntNull() ? 0 : input[0].KeiryoShomeiShomeishoInsatsuCnt;
                input[0].KeiryoShomeiShomeishoInsatsuCnt = cnt + 1;
            }               
            // 更新日
            input[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
            // 更新者
            input[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 更新端末
            input[0].UpdateTarm = Dns.GetHostName();
        }
        #endregion

        #endregion
    }
    #endregion
}
