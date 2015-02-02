using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.Common;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaTanKomokuMst;
using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLInput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLInput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLInput
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
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLOutput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLOutput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBusinessLogic : BaseBusinessLogic<IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLInput, IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBusinessLogic()
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLOutput Execute(IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLOutput output = new DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLOutput();

            try
            {
                new DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDataAccess().Execute(input);
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
