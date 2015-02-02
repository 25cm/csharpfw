using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiRendoList;
using FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiRendoShosai;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.KaikeiRendoShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKobetsuUkagaishoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKobetsuUkagaishoBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// KaikeiNo
        /// </summary>
        string KaiKeiNo { get; set; }

        /// <summary>
        /// KeikeiRenban 
        /// </summary>
        string KeikeiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KobetsuUkagaishoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KobetsuUkagaishoBtnClickALInput : IKobetsuUkagaishoBtnClickALInput
    {
        /// <summary>
        /// KaikeiNo
        /// </summary>
        public string KaiKeiNo { get; set; }

        /// <summary>
        /// KeikeiRenban 
        /// </summary>
        public string KeikeiRenban { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("会計No [{0}], 連番 [{1}]", KaiKeiNo, KeikeiRenban);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKobetsuUkagaishoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKobetsuUkagaishoBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KobetsuUkagaishoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KobetsuUkagaishoBtnClickALOutput : IKobetsuUkagaishoBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KobetsuUkagaishoBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KobetsuUkagaishoBtnClickApplicationLogic : BaseApplicationLogic<IKobetsuUkagaishoBtnClickALInput, IKobetsuUkagaishoBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KaikeiRendoShosai：KobetsuUkagaishoBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KobetsuUkagaishoBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KobetsuUkagaishoBtnClickApplicationLogic()
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
        /// 2014/09/18  HuyTX　　    新規作成
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
        /// 2014/09/18  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKobetsuUkagaishoBtnClickALOutput Execute(IKobetsuUkagaishoBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKobetsuUkagaishoBtnClickALOutput output = new KobetsuUkagaishoBtnClickALOutput();

            try
            {
                IGetKaikeiRendoKensakuByKaikeiNoBLInput getKaikeiRendoBLInput = new GetKaikeiRendoKensakuByKaikeiNoBLInput();
                getKaikeiRendoBLInput.KaikeiNo = input.KaiKeiNo;
                IGetKaikeiRendoKensakuByKaikeiNoBLOutput getKaikeiRendoBLOutput = new GetKaikeiRendoKensakuByKaikeiNoBusinessLogic().Execute(getKaikeiRendoBLInput);

                if (getKaikeiRendoBLOutput.KaikeiRendoHdrTblKensakuDataTable.Count == 0) return output;

                //print SuitouUkagaisho (KaikeiNo-KeikeiRenban)
                IPrintSuitouUkagaishoBLInput printBLInput = new PrintSuitouUkagaishoBLInput();
                printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SuitouUkagaishoFormatFile;
                printBLInput.AfterDispFlg = true;

                printBLInput.KaikeiRendoHdrTblKensakuRow = getKaikeiRendoBLOutput.KaikeiRendoHdrTblKensakuDataTable[0];
                printBLInput.KeikeiRenban = input.KeikeiRenban;

                new PrintSuitouUkagaishoBusinessLogic().Execute(printBLInput);

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
