using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsuke;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiKensaAmtInfoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiKensaAmtInfoALInput : IBseALInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        string JokasoHokenjoCd { get; set; }
        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        string JokasoTorokuNendo { get; set; }
        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        string JokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiKensaAmtInfoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiKensaAmtInfoALInput : IGetKensaIraiKensaAmtInfoALInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        public string JokasoHokenjoCd { get; set; }
        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        public string JokasoTorokuNendo { get; set; }
        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string JokasoRenban { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("浄化槽台帳保健所コード[{0}], 浄化槽台帳登録年度[{1}], 浄化槽台帳連番[{2}]",
                    new string[] { JokasoHokenjoCd, JokasoTorokuNendo, JokasoRenban });
            }
        }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiKensaAmtInfoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiKensaAmtInfoALOutput
    {
        /// <summary>
        /// 検査依頼検査料金
        /// </summary>
        decimal KensaIraiKensaAmt { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiKensaAmtInfoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiKensaAmtInfoALOutput : IGetKensaIraiKensaAmtInfoALOutput
    {
        /// <summary>
        /// 検査依頼検査料金
        /// </summary>
        public decimal KensaIraiKensaAmt { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiKensaAmtInfoApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiKensaAmtInfoApplicationLogic : BaseApplicationLogic<IGetKensaIraiKensaAmtInfoALInput, IGetKensaIraiKensaAmtInfoALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaUketsukeList：GetKensaIraiKensaAmtInfo";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaIraiKensaAmtInfoApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaIraiKensaAmtInfoApplicationLogic()
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
        /// 2014/12/09　小松　　    新規作成
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
        /// 2014/12/09　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaIraiKensaAmtInfoALOutput Execute(IGetKensaIraiKensaAmtInfoALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaIraiKensaAmtInfoALOutput output = new GetKensaIraiKensaAmtInfoALOutput();

            try
            {
                // 検査依頼検査料金を取得
                // データ検索⑦
                ISelectSuishitsuKensaEntryInfoDAInput selIn = new SelectSuishitsuKensaEntryInfoDAInput();
                selIn.JokasoHokenjoCd = input.JokasoHokenjoCd;
                selIn.JokasoTorokuNendo = input.JokasoTorokuNendo;
                selIn.JokasoRenban = input.JokasoRenban;
                ISelectSuishitsuKensaEntryInfoDAOutput selOut = new SelectSuishitsuKensaEntryInfoDAOutput();
                selOut.KensaEntryInfoDT = new SelectSuishitsuKensaEntryInfoDataAccess().Execute(selIn).KensaEntryInfoDT;
                if (selOut.KensaEntryInfoDT.Rows.Count > 0)
                {
                    // 検査依頼検査料金
                    output.KensaIraiKensaAmt = selOut.KensaEntryInfoDT[0].KensaAmt;
                }
                else
                {
                    output.KensaIraiKensaAmt = 0;
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
