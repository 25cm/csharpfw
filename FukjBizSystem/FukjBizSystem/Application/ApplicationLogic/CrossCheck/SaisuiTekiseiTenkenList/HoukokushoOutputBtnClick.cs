using System;
using System.IO;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.CrossCheck.SaisuiTekiseiTenkenList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.CrossCheck.SaisuiTekiseiTenkenList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IHoukokushoOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IHoukokushoOutputBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 指定保存パス
        /// 未指定の場合は、帳票出力ディレクトリに出力されます
        /// </summary>
        string SavePath { get; set; }

        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoukokushoOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class HoukokushoOutputBtnClickALInput : IHoukokushoOutputBtnClickALInput
    {
        /// <summary>
        /// 指定保存パス
        /// 未指定の場合は、帳票出力ディレクトリに出力されます
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        public KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable PrintTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("指定保存パス[{0}]", SavePath);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IHoukokushoOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IHoukokushoOutputBtnClickALOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoukokushoOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class HoukokushoOutputBtnClickALOutput : IHoukokushoOutputBtnClickALOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： HoukokushoOutputBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class HoukokushoOutputBtnClickApplicationLogic : BaseApplicationLogic<IHoukokushoOutputBtnClickALInput, IHoukokushoOutputBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SaisuiTekiseiTenkenList：HoukokushoOutputBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： HoukokushoOutputBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public HoukokushoOutputBtnClickApplicationLogic()
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
        /// 2014/12/23　AnhNV　　    新規作成
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
        /// 2014/12/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IHoukokushoOutputBtnClickALOutput Execute(IHoukokushoOutputBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IHoukokushoOutputBtnClickALOutput output = new HoukokushoOutputBtnClickALOutput();

            try
            {
                KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable printTable = new KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable();
                string tempIraiNo = null;

                foreach (KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row in input.PrintTable.Select(string.Empty, "KensaKekkaSuishitsuIraiNo"))
                {
                    if (row.KensaIraiCrossCheckRiyu != "8"/*"分からない"*/) continue;

                    /*if (tempIraiNo == row.KensaKekkaSuishitsuIraiNo || tempIraiNo == null)
                    {
                        printTable.ImportRow(row);
                    }
                    else if (tempIraiNo != row.KensaKekkaSuishitsuIraiNo && tempIraiNo != null)
                    {
                        
                    }*/

                    printTable.ImportRow(row);

                    // Avoid duplicates file name
                    DateTime systemDt = Boundary.Common.Common.GetCurrentTimestamp();
                    string savePath = Path.Combine(input.SavePath, string.Format("クロスチェック_調査報告書_{0}_{1}_{2}",
                        row.ShishoNm, row.KensaKekkaSuishitsuIraiNo, systemDt.ToString("yyyyMMdd_hhmmss")));

                    IPrintKurosuChekkuHokokuBLInput blInput = new PrintKurosuChekkuHokokuBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KurosuChekkuChosaHokokushoFormatFile;
                    blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.PrintTable = printTable;
                    blInput.SavePath = savePath;
                    new PrintKurosuChekkuHokokuBusinessLogic().Execute(blInput);

                    tempIraiNo = row.KensaKekkaSuishitsuIraiNo;
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
