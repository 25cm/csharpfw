using System.Collections.Generic;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.KaiinKanri.KaiinList;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Application.ApplicationLogic.KaiinKanri.KaiinList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuninsyoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuninsyoBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// GyoshaCd
        /// </summary>
        //string GyoshaCd { get; set; }
        List<string> GyoshaCdList { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuninsyoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuninsyoBtnClickALInput : IKakuninsyoBtnClickALInput
    {
        /// <summary>
        /// GyoshaCd
        /// </summary>
        //public string GyoshaCd { get; set; }
        public List<string> GyoshaCdList { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("業者コード{0}", GyoshaCdList[0]);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuninsyoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuninsyoBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuninsyoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuninsyoBtnClickALOutput : IKakuninsyoBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuninsyoBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuninsyoBtnClickApplicationLogic : BaseApplicationLogic<IKakuninsyoBtnClickALInput, IKakuninsyoBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KaiinList：KakuninsyoBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KakuninsyoBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KakuninsyoBtnClickApplicationLogic()
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
        /// 2014/08/06　HuyTX　　    新規作成
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
        /// 2014/08/06　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuninsyoBtnClickALOutput Execute(IKakuninsyoBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuninsyoBtnClickALOutput output = new KakuninsyoBtnClickALOutput();

            try
            {
                // 2015.01.30 AnhNV MOD Start
                GyoshaBukaiMstDataSet.KaiinPrintInfoDataTable printTable = new GyoshaBukaiMstDataSet.KaiinPrintInfoDataTable();
                foreach (string gyoshaCd in input.GyoshaCdList)
                {
                    IGetKaiinPrintInfoByGyoshaCdBLInput kaiinInput = new GetKaiinPrintInfoByGyoshaCdBLInput();
                    //getKaiinInfoInput.GyoshaCd = input.GyoshaCd;
                    kaiinInput.GyoshaCd = gyoshaCd;
                    IGetKaiinPrintInfoByGyoshaCdBLOutput kaiinOutput = new GetKaiinPrintInfoByGyoshaCdBusinessLogic().Execute(kaiinInput);
                    
                    // Merge to result
                    printTable.Merge(kaiinOutput.KaiinPrintInfoDataTable);
                }
                // 2015.01.30 AnhNV MOD End

                IPrintKaiinInfoBLInput printInput = new PrintKaiinInfoBLInput();

                printInput.AfterPrintFlg = true;
                printInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KaiinJouhouKakuninshoFormatFile;
                //printInput.KaiinPrintInfoDataTable = getKaiinInfoOutput.KaiinPrintInfoDataTable;
                printInput.KaiinPrintInfoDataTable = printTable;

                new PrintKaiinInfoBusinessLogic().Execute(printInput);

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
