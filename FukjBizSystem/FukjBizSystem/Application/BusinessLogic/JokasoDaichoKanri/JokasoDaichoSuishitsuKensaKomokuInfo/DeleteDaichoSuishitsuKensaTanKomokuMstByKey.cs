using System.Reflection;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaTanKomokuMst;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLInput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLInput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLInput
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
        /// 台帳検査項目枝番
        /// </summary>
        public string DaichoKensaKomokuEdaban { get; set; }

        /// <summary>
        /// 検査項目コード
        /// </summary>
        public string DaichoKensaKomokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLOutput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLOutput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteDaichoSuishitsuKensaTanKomokuMstByKeyBusinessLogic : BaseBusinessLogic<IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLInput, IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteDaichoSuishitsuKensaTanKomokuMstByKeyBusinessLogic()
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
        /// 2014/12/15　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLOutput Execute(IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLOutput output = new DeleteDaichoSuishitsuKensaTanKomokuMstByKeyBLOutput();

            try
            {
                new DeleteDaichoSuishitsuKensaTanKomokuMstByKeyDataAccess().Execute(input);
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
