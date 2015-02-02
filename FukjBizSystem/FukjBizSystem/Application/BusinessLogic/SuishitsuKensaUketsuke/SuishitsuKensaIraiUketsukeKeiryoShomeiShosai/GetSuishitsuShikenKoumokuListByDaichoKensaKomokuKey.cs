using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeKeiryoShomeiShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput : ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput : IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput
    {
        /// <summary>
        /// KensaIraiJokasoHokenjoCd
        /// </summary>
        public string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiJokasoTorokuNendo
        /// </summary>
        public string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// KensaIraiJokasoRenban
        /// </summary>
        public string KensaIraiJokasoRenban { get; set; }

        /// <summary>
        /// DaichoKensaKomokuEdaban
        /// </summary>
        public string DaichoKensaKomokuEdaban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput : ISelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput : IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput
    {
        /// <summary>
        /// SuishitsuShikenKoumokuList
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.SuishitsuShikenKoumokuListDataTable SuishitsuShikenKoumokuList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBusinessLogic : BaseBusinessLogic<IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput, IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBusinessLogic()
        {
            
        }
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
        /// 2014/12/10  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput Execute(IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput output = new GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput();

            try
            {
                output.SuishitsuShikenKoumokuList = new SelectSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyDataAccess().Execute(input).SuishitsuShikenKoumokuList;
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
