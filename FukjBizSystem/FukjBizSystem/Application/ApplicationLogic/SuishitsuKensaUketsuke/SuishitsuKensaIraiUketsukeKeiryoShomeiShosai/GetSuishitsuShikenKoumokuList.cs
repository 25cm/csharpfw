using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeKeiryoShomeiShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeKeiryoShomeiShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuShikenKoumokuListALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuShikenKoumokuListALInput : IBseALInput, IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuShikenKoumokuListALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuShikenKoumokuListALInput : IGetSuishitsuShikenKoumokuListALInput
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
        
        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return String.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuShikenKoumokuListALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuShikenKoumokuListALOutput : IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuShikenKoumokuListALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuShikenKoumokuListALOutput : IGetSuishitsuShikenKoumokuListALOutput
    {
        /// <summary>
        /// SuishitsuShikenKoumokuList
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.SuishitsuShikenKoumokuListDataTable SuishitsuShikenKoumokuList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuShikenKoumokuListApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuShikenKoumokuListApplicationLogic : BaseApplicationLogic<IGetSuishitsuShikenKoumokuListALInput, IGetSuishitsuShikenKoumokuListALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            NoDataFound,     // データ無し
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaIraiUketsukeKeiryoShomeiShosai：GetSuishitsuShikenKoumokuList";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuShikenKoumokuListApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10  豊田  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuShikenKoumokuListApplicationLogic()
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
        /// 2014/12/10  豊田  　    新規作成
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
        /// 2014/12/10  豊田  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuShikenKoumokuListALOutput Execute(IGetSuishitsuShikenKoumokuListALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuShikenKoumokuListALOutput output = new GetSuishitsuShikenKoumokuListALOutput();

            try
            {
                // 水質検査項目リスト取得
                IGetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput suishitsuInput = new GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBLInput();
                suishitsuInput.KensaIraiJokasoHokenjoCd = input.KensaIraiJokasoHokenjoCd;
                suishitsuInput.KensaIraiJokasoTorokuNendo = input.KensaIraiJokasoTorokuNendo;
                suishitsuInput.KensaIraiJokasoRenban = input.KensaIraiJokasoRenban;
                suishitsuInput.DaichoKensaKomokuEdaban = input.DaichoKensaKomokuEdaban;

                // 検索実行
                output.SuishitsuShikenKoumokuList = new GetSuishitsuShikenKoumokuListByDaichoKensaKomokuKeyBusinessLogic().Execute(suishitsuInput).SuishitsuShikenKoumokuList;

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
