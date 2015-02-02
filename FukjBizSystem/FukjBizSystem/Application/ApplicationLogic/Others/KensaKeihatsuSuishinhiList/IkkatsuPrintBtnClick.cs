using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.KensaKeihatsuSuishinhiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IIkkatsuPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IIkkatsuPrintBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 支払票印刷第○号
        /// </summary>
        string PrintNo { get; set; }

        /// <summary>
        /// System datetime
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDataTable { get; set; }

        /// <summary>
        /// LoginNm 
        /// </summary>
        string LoginNm { get; set; }

        /// <summary>
        /// SuishinhiNo 
        /// </summary>
        string SuishinhiNo { get; set; }

        /// <summary>
        /// GyoshaCd 
        /// </summary>
        string GyoshaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IkkatsuPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IkkatsuPrintBtnClickALInput : IIkkatsuPrintBtnClickALInput
    {
        /// <summary>
        /// 支払票印刷第○号
        /// </summary>
        public string PrintNo { get; set; }

        /// <summary>
        /// System datetime
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDataTable { get; set; }

        /// <summary>
        /// LoginNm 
        /// </summary>
        public string LoginNm { get; set; }

        /// <summary>
        /// SuishinhiNo 
        /// </summary>
        public string SuishinhiNo { get; set; }

        /// <summary>
        /// GyoshaCd 
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支払票印刷第○号[{0}]", PrintNo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IIkkatsuPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IIkkatsuPrintBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IkkatsuPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IkkatsuPrintBtnClickALOutput : IIkkatsuPrintBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IkkatsuPrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IkkatsuPrintBtnClickApplicationLogic : BaseApplicationLogic<IIkkatsuPrintBtnClickALInput, IIkkatsuPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKeihatsuSuishinhiList：IkkatsuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： IkkatsuPrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public IkkatsuPrintBtnClickApplicationLogic()
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
        /// 2014/08/21　HuyTX　　    新規作成
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
        /// 2014/08/21　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IIkkatsuPrintBtnClickALOutput Execute(IIkkatsuPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IIkkatsuPrintBtnClickALOutput output = new IkkatsuPrintBtnClickALOutput();

            try
            {
                KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[] mochikomiGyoshaRows
                    = (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[])input.KensaKeihatsuSuishinListDataTable.Select(string.Format("SuishinhiNo = '{0}' AND GyoshaCd = '{1}' AND ToriatsukaiGyoshaKbn = '2' AND ISNULL(ToriatsukaiGyoshaCd, '') = ''", input.SuishinhiNo, input.GyoshaCd));
                KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[] shushuToriatsukaiGyoshaRows
                    = (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[])input.KensaKeihatsuSuishinListDataTable.Select(string.Format("SuishinhiNo = '{0}' AND GyoshaCd = '{1}' AND ToriatsukaiGyoshaKbn <> '2' OR ISNULL(ToriatsukaiGyoshaCd, '') <> ''", input.SuishinhiNo, input.GyoshaCd));
                KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[] kumiaiRows
                    = (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[])input.KensaKeihatsuSuishinListDataTable.Select("ToriatsukaiGyoshaKbn = '2'");

                //print MochikomiGyosha (019)
                if (mochikomiGyoshaRows.Length > 0)
                {
                    IPrintMochikomiGyoshaBLInput printMochikomiGyoshaBLInput = new PrintMochikomiGyoshaBLInput();
                    printMochikomiGyoshaBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    printMochikomiGyoshaBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.MoshiKomiGyoshaFormatFile;
                    printMochikomiGyoshaBLInput.AfterPrintFlg = true;

                    printMochikomiGyoshaBLInput.KensaKeihatsuSuishinListRows = mochikomiGyoshaRows;
                    printMochikomiGyoshaBLInput.PrintNo = input.PrintNo;
                    printMochikomiGyoshaBLInput.SystemDt = input.SystemDt;
                    printMochikomiGyoshaBLInput.LoginNm = input.LoginNm;

                    new PrintMochikomiGyoshaBusinessLogic().Execute(printMochikomiGyoshaBLInput);
                }

                //print ShushuToriatsukaiGyosha (020)
                if (shushuToriatsukaiGyoshaRows.Length > 0)
                {
                    IPrintShushuToriatsukaiGyoshaBLInput printShushuToriatsukaiGyoshaBLInput = new PrintShushuToriatsukaiGyoshaBLInput();
                    printShushuToriatsukaiGyoshaBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    printShushuToriatsukaiGyoshaBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.ShushuToriatsukaiGyoshaFormatFile;
                    printShushuToriatsukaiGyoshaBLInput.AfterPrintFlg = true;

                    printShushuToriatsukaiGyoshaBLInput.KensaKeihatsuSuishinListRows = shushuToriatsukaiGyoshaRows;
                    printShushuToriatsukaiGyoshaBLInput.PrintNo = input.PrintNo;
                    printShushuToriatsukaiGyoshaBLInput.SystemDt = input.SystemDt;
                    printShushuToriatsukaiGyoshaBLInput.LoginNm = input.LoginNm;

                    new PrintShushuToriatsukaiGyoshaBusinessLogic().Execute(printShushuToriatsukaiGyoshaBLInput);
                }

                // Print 021
                if (kumiaiRows.Length > 0)
                {
                    IPrintKensaKeihatsuKyodoKumiaisBLInput blInput = new PrintKensaKeihatsuKyodoKumiaisBLInput();
                    //blInput.AfterDispFlg = true;
                    blInput.AfterPrintFlg = true;
                    //blInput.PrinterName = ;
                    blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KensaKeihatsuKyodoKumiaiFormatFile;
                    blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    blInput.SystemDt = input.SystemDt;
                    blInput.PrintNo = input.PrintNo;
                    blInput.LoginNm = input.LoginNm;
                    //blInput.KyodoKumiaiCd = input.KyodoKumiaiCd;
                    blInput.KensaKeihatsuSuishinListDataTable = input.KensaKeihatsuSuishinListDataTable;
                    new PrintKensaKeihatsuKyodoKumiaisBusinessLogic().Execute(blInput);
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
