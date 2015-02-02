using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SaisuiinKanri.JyukoYoteishaList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.JyukoYoteishaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutput1BtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutput1BtnClickALInput : IBseALInput, IPrintJukoMoshikomishoBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Output1BtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Output1BtnClickALInput : IOutput1BtnClickALInput
    {
        /// <summary>
        /// 保存ファイルモード
        /// </summary>
        public int SaveFileMode { get; set; }

        /// <summary>
        /// ＥＸＣＥＬ書式へのパス
        /// </summary>
        public string FormatPath { get; set; }

        /// <summary>
        /// 帳票ディレクトリパス
        /// </summary>
        public string PrintDirectory { get; set; }

        /// <summary>
        /// 指定保存パス
        /// 未指定の場合は、帳票出力ディレクトリに出力されます
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// 処理後ＥＸＣＥＬ表示フラグ
        /// </summary>
        public bool AfterDispFlg { get; set; }

        /// <summary>
        /// 処理後印刷フラグ
        /// </summary>
        public bool AfterPrintFlg { get; set; }

        /// <summary>
        /// 印刷プリンタ名
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// 印刷部数
        /// </summary>
        public int CopyCount { get; set; }

        /// <summary>
        /// 印刷単位(true:部単位,false:ページ単位)
        /// </summary>
        public bool Collate { get; set; }

        /// <summary>
        /// CurrentDate
        /// </summary>
        public DateTime CurrentDate { get; set; }

        /// <summary>
        /// JyukoYoteishaListDataTable
        /// </summary>
        public SaisuiinMstDataSet.JyukoYoteishaListDataTable ExportDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("保存ファイルモード[{0}], ＥＸＣＥＬ書式へのパス[{1}], 帳票ディレクトリパス[{2}], 指定保存パス[{3}], 処理後ＥＸＣＥＬ表示フラグ[{4}], CurrentDate[{5}], JyukoYoteishaListDataTable[{6}]", 
                    new string[] { 
                        SaveFileMode.ToString(),
                        FormatPath,
                        PrintDirectory,
                        SavePath,
                        AfterDispFlg.ToString(),
                        CurrentDate.ToString("yyyyMMdd"),
                        ExportDT[0].SaisuiinCd
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutput1BtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutput1BtnClickALOutput : IPrintJukoMoshikomishoBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Output1BtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Output1BtnClickALOutput : IOutput1BtnClickALOutput
    {
        /// <summary>
        /// 保存パス
        /// </summary>
        public string SavePath { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Output1BtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/07  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Output1BtnClickApplicationLogic : BaseApplicationLogic<IOutput1BtnClickALInput, IOutput1BtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JyukoYoteishaList：Output1BtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Output1BtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/07  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Output1BtnClickApplicationLogic()
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
        /// 2014/08/07  DatNT　  新規作成
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
        /// 2014/08/07  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IOutput1BtnClickALOutput Execute(IOutput1BtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IOutput1BtnClickALOutput output = new Output1BtnClickALOutput();

            try
            {
                IPrintJukoMoshikomishoBLInput blInput   = new PrintJukoMoshikomishoBLInput();
                blInput.FormatPath                      = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.JukoMoshikomishoShutsuryokuFormatFile;
                blInput.PrintDirectory                  = Properties.Settings.Default.PrintDirectory;
                blInput.AfterPrintFlg                   = true;
                blInput.CurrentDate                     = input.CurrentDate;
                blInput.ExportDT                        = input.ExportDT;
                new PrintJukoMoshikomishoBusinessLogic().Execute(blInput);
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
