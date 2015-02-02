using System.Reflection;
using FukjBizSystem.Application.Boundary.KensaKekka;
using FukjBizSystem.Application.BusinessLogic.KensaKekka.KensaKekkaList;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaKekkaInputShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFaxSofuKojiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFaxSofuKojiBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        string KensaIraiRenban { get; set; }

        /// <summary>
        /// PrintMode
        /// </summary>
        KensaKekkaListForm.PrintMode PrintMode { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FaxSofuKojiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FaxSofuKojiBtnClickALInput : IFaxSofuKojiBtnClickALInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }

        /// <summary>
        /// PrintMode
        /// </summary>
        public KensaKekkaListForm.PrintMode PrintMode { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査依頼法定区分[{0}], 検査依頼保健所コード[{1}], 検査依頼年度[{2}], 検査依頼連番[{3}]",
                    KensaIraiHoteiKbn, KensaIraiHokenjoCd, KensaIraiNendo, KensaIraiRenban);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFaxSofuKojiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFaxSofuKojiBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FaxSofuKojiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FaxSofuKojiBtnClickALOutput : IFaxSofuKojiBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FaxSofuKojiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FaxSofuKojiBtnClickApplicationLogic : BaseApplicationLogic<IFaxSofuKojiBtnClickALInput, IFaxSofuKojiBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKekkaInputShosai：FaxSofuKojiBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FaxSofuKojiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FaxSofuKojiBtnClickApplicationLogic()
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
        /// 2014/11/11　AnhNV　　    新規作成
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
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFaxSofuKojiBtnClickALOutput Execute(IFaxSofuKojiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFaxSofuKojiBtnClickALOutput output = new FaxSofuKojiBtnClickALOutput();

            try
            {
                // Prepares printing data
                IGetSouShinhyo2PrintInfoBLInput blInput = new GetSouShinhyo2PrintInfoBLInput();
                blInput.KensaIraiHoteiKbn = input.KensaIraiHoteiKbn;
                blInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                blInput.KensaIraiNendo = input.KensaIraiNendo;
                blInput.KensaIraiRenban = input.KensaIraiRenban;
                IGetSouShinhyo2PrintInfoBLOutput printInfoBLOutput = new GetSouShinhyo2PrintInfoBusinessLogic().Execute(blInput);

                // Print 006_ＦＡＸ送信票２_帳票設計書
                IPrintSouShinhyo2InfoBLInput printBLInput = new PrintSouShinhyo2InfoBLInput();
                printBLInput.PrintMode = input.PrintMode;
                printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printBLInput.AfterDispFlg = true;
                printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SouShishyo2FormatFile;
                printBLInput.SouShinhyo2PrintInfoDataTable = printInfoBLOutput.SouShinhyo2PrintInfoDataTable;
                new PrintSouShinhyo2InfoBusinessLogic().Execute(printBLInput);
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
