using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo;
using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード 
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        string TorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        string Renban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード 
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        public string TorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        public string Renban { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("浄化槽番号(保健所コード) {0}, 浄化槽番号 (年度) {1}, 浄化槽番号(連番){2}", HokenjoCd, TorokuNendo, Renban);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// JokasoDaichoMstDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDT { get; set; }

        /// <summary>
        /// 水質検査セットマスタ
        /// </summary>
        SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable SuishitsuKensaSetMstDataTable { get; set; }

        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ
        /// </summary>
        DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTable { get; set; }

        /// <summary>
        /// 水質マスタ
        /// </summary>
        SuishitsuMstDataSet.SuishitsuMstDataTable SuishitsuMstDataTable { get; set; }

        // 20150201 sou Start
        /// <summary>
        /// 業者マスタ
        /// </summary>
        GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDT { get; set; }
        // 20150201 sou End
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// JokasoDaichoMstDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMstDT { get; set; }

        /// <summary>
        /// 水質検査セットマスタ
        /// </summary>
        public SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable SuishitsuKensaSetMstDataTable { get; set; }

        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ
        /// </summary>
        public DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTable { get; set; }

        /// <summary>
        /// 水質マスタ
        /// </summary>
        public SuishitsuMstDataSet.SuishitsuMstDataTable SuishitsuMstDataTable { get; set; }

        // 20150201 sou Start
        /// <summary>
        /// 業者マスタ
        /// </summary>
        public GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDT { get; set; }
        // 20150201 sou End
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "浄化槽台帳水質検査項目情報：FormLoad";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FormLoadApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FormLoadApplicationLogic()
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
        /// 2014/12/10　HieuNH　　　新規作成
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
        /// 2014/12/10　HieuNH　　　新規作成
        /// 2014/12/17　HieuNH　　　Check JokasoSuisitsuSishoCd Null
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                IGetJokasoDaichoMstByJokasoDaichoNoBLInput jokasoDaichoMstBLInput = new GetJokasoDaichoMstByJokasoDaichoNoBLInput();
                jokasoDaichoMstBLInput.HokenjoCd = input.HokenjoCd;
                jokasoDaichoMstBLInput.TorokuNendo = input.TorokuNendo;
                jokasoDaichoMstBLInput.Renban = input.Renban;
                IGetJokasoDaichoMstByJokasoDaichoNoBLOutput jokasoDaichoMstBLOutput = new GetJokasoDaichoMstByJokasoDaichoNoBusinessLogic().Execute(jokasoDaichoMstBLInput);
                output.JokasoDaichoMstDT = jokasoDaichoMstBLOutput.JokasoDaichoMstDT;

                IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput dskkmBLInput = new GetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput();
                dskkmBLInput.HokenjoCd = input.HokenjoCd;
                dskkmBLInput.TorokuNendo = input.TorokuNendo;
                dskkmBLInput.Renban = input.Renban;
                IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput dskkmBLOutput = new GetDaichoSuishitsuKensaKomokuMstByJokasoCdBusinessLogic().Execute(dskkmBLInput);
                output.DaichoSuishitsuKensaKomokuMstDataTable = dskkmBLOutput.DaichoSuishitsuKensaKomokuMstDataTable;

                IGetSuishitsuKensaSetMstInfoBLInput sksmBLInput = new GetSuishitsuKensaSetMstInfoBLInput();
                IGetSuishitsuKensaSetMstInfoBLOutput sksmBLOutput = new GetSuishitsuKensaSetMstInfoBusinessLogic().Execute(sksmBLInput);
                output.SuishitsuKensaSetMstDataTable = sksmBLOutput.SuishitsuKensaSetMstDataTable;

                //// MODIFY HieuNH 2014/12/17 BEGIN
                //if (output.JokasoDaichoMstDT != null && output.JokasoDaichoMstDT.Count > 0)
                if (output.JokasoDaichoMstDT != null && output.JokasoDaichoMstDT.Count > 0 && !output.JokasoDaichoMstDT[0].IsJokasoSuisitsuSishoCdNull() && !string.IsNullOrEmpty(output.JokasoDaichoMstDT[0].JokasoSuisitsuSishoCd))
                //// MODIFY HieuNH 2014/12/17 END
                {
                    IGetSuishitsuMstBySuishitsuShishoCdBLInput smBLInput = new GetSuishitsuMstBySuishitsuShishoCdBLInput();
                    smBLInput.SuishitsuShishoCd = output.JokasoDaichoMstDT[0].JokasoSuisitsuSishoCd;
                    IGetSuishitsuMstBySuishitsuShishoCdBLOutput smBLOutput = new GetSuishitsuMstBySuishitsuShishoCdBusinessLogic().Execute(smBLInput);
                    output.SuishitsuMstDataTable = smBLOutput.SuishitsuMstDataTable;

                    // 20150201 sou Start
                    IGetGyoshaMstByGyoshaCdBLInput gmInput = new GetGyoshaMstByGyoshaCdBLInput();
                    gmInput.GyoshaCd = output.JokasoDaichoMstDT[0].JokasoSeikyuGyoshaCd;
                    IGetGyoshaMstByGyoshaCdBLOutput gmOutput = new GetGyoshaMstByGyoshaCdBusinessLogic().Execute(gmInput);
                    output.GyoshaMstDT = gmOutput.GyoshaMstDataTable;
                    // 20150201 sou End
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
