using System.Reflection;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaKomokuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput
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
    interface IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput : ISelectDaichoSuishitsuKensaKomokuMstByJokasoCdDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput
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
    class GetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput : IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput
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
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput
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
    interface IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput : ISelectDaichoSuishitsuKensaKomokuMstByJokasoCdDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput
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
    class GetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput : IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput
    {
        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ
        /// </summary>
        public DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDaichoSuishitsuKensaKomokuMstByJokasoCdBusinessLogic
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
    class GetDaichoSuishitsuKensaKomokuMstByJokasoCdBusinessLogic : BaseBusinessLogic<IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput, IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetDaichoSuishitsuKensaKomokuMstByJokasoCdBusinessLogic
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
        public GetDaichoSuishitsuKensaKomokuMstByJokasoCdBusinessLogic()
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
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput Execute(IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput output = new GetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput();

            try
            {
                output.DaichoSuishitsuKensaKomokuMstDataTable = new SelectDaichoSuishitsuKensaKomokuMstByJokasoCdDataAccess().Execute(input).DaichoSuishitsuKensaKomokuMstDataTable;
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
