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
    //  インターフェイス名 ： IKobetsuGyosyaBtnClickALInput
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
    interface IKobetsuGyosyaBtnClickALInput : IBseALInput
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
        /// KensaKeihatsuSuishinListRows
        /// </summary>
        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[] KensaKeihatsuSuishinListRows { get; set; }

        /// <summary>
        /// LoginNm 
        /// </summary>
        string LoginNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KobetsuGyosyaBtnClickALInput
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
    class KobetsuGyosyaBtnClickALInput : IKobetsuGyosyaBtnClickALInput
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
        /// KensaKeihatsuSuishinListRows
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListRow[] KensaKeihatsuSuishinListRows { get; set; }

        /// <summary>
        /// LoginNm 
        /// </summary>
        public string LoginNm { get; set; }

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
    //  インターフェイス名 ： IKobetsuGyosyaBtnClickALOutput
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
    interface IKobetsuGyosyaBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KobetsuGyosyaBtnClickALOutput
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
    class KobetsuGyosyaBtnClickALOutput : IKobetsuGyosyaBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KobetsuGyosyaBtnClickApplicationLogic
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
    class KobetsuGyosyaBtnClickApplicationLogic : BaseApplicationLogic<IKobetsuGyosyaBtnClickALInput, IKobetsuGyosyaBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKeihatsuSuishinhiList：KobetsuGyoshaBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KobetsuGyosyaBtnClickApplicationLogic
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
        public KobetsuGyosyaBtnClickApplicationLogic()
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
        public override IKobetsuGyosyaBtnClickALOutput Execute(IKobetsuGyosyaBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKobetsuGyosyaBtnClickALOutput output = new KobetsuGyosyaBtnClickALOutput();

            try
            {
                //print MochikomiGyosha (019)
                if (input.KensaKeihatsuSuishinListRows[0].ToriatsukaiGyoshaKbn == "2" && string.IsNullOrEmpty(input.KensaKeihatsuSuishinListRows[0].ToriatsukaiGyoshaCd))
                {
                    IPrintMochikomiGyoshaBLInput printMochikomiGyoshaBLInput = new PrintMochikomiGyoshaBLInput();
                    printMochikomiGyoshaBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    printMochikomiGyoshaBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.MoshiKomiGyoshaFormatFile;
                    printMochikomiGyoshaBLInput.AfterDispFlg = true;

                    printMochikomiGyoshaBLInput.KensaKeihatsuSuishinListRows = input.KensaKeihatsuSuishinListRows;
                    printMochikomiGyoshaBLInput.PrintNo = input.PrintNo;
                    printMochikomiGyoshaBLInput.SystemDt = input.SystemDt;
                    printMochikomiGyoshaBLInput.LoginNm = input.LoginNm;

                    new PrintMochikomiGyoshaBusinessLogic().Execute(printMochikomiGyoshaBLInput);
                }else{
                    //print ShushuToriatsukaiGyosha (020)
                    IPrintShushuToriatsukaiGyoshaBLInput printShushuToriatsukaiGyoshaBLInput = new PrintShushuToriatsukaiGyoshaBLInput();
                    printShushuToriatsukaiGyoshaBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                    printShushuToriatsukaiGyoshaBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.ShushuToriatsukaiGyoshaFormatFile;
                    printShushuToriatsukaiGyoshaBLInput.AfterDispFlg = true;

                    printShushuToriatsukaiGyoshaBLInput.KensaKeihatsuSuishinListRows = input.KensaKeihatsuSuishinListRows;
                    printShushuToriatsukaiGyoshaBLInput.PrintNo = input.PrintNo;
                    printShushuToriatsukaiGyoshaBLInput.SystemDt = input.SystemDt;
                    printShushuToriatsukaiGyoshaBLInput.LoginNm = input.LoginNm;

                    new PrintShushuToriatsukaiGyoshaBusinessLogic().Execute(printShushuToriatsukaiGyoshaBLInput);
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
