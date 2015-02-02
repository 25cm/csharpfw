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
    //  インターフェイス名 ： IUpdateDaichoSuishitsuKensaTanKomokuMstBLInput
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
    interface IUpdateDaichoSuishitsuKensaTanKomokuMstBLInput : IUpdateDaichoSuishitsuKensaTanKomokuMstDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateDaichoSuishitsuKensaTanKomokuMstBLInput
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
    class UpdateDaichoSuishitsuKensaTanKomokuMstBLInput : IUpdateDaichoSuishitsuKensaTanKomokuMstBLInput
    {
        /// <summary>
        /// 浄化槽台帳水質検査単項目マスタ
        /// </summary>
        public DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable DaichoSuishitsuKensaTanKomokuMstDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateDaichoSuishitsuKensaTanKomokuMstBLOutput
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
    interface IUpdateDaichoSuishitsuKensaTanKomokuMstBLOutput : IUpdateDaichoSuishitsuKensaTanKomokuMstDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateDaichoSuishitsuKensaTanKomokuMstBLOutput
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
    class UpdateDaichoSuishitsuKensaTanKomokuMstBLOutput : IUpdateDaichoSuishitsuKensaTanKomokuMstBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateDaichoSuishitsuKensaTanKomokuMstBusinessLogic
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
    class UpdateDaichoSuishitsuKensaTanKomokuMstBusinessLogic : BaseBusinessLogic<IUpdateDaichoSuishitsuKensaTanKomokuMstBLInput, IUpdateDaichoSuishitsuKensaTanKomokuMstBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateDaichoSuishitsuKensaTanKomokuMstBusinessLogic
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
        public UpdateDaichoSuishitsuKensaTanKomokuMstBusinessLogic()
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
        public override IUpdateDaichoSuishitsuKensaTanKomokuMstBLOutput Execute(IUpdateDaichoSuishitsuKensaTanKomokuMstBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateDaichoSuishitsuKensaTanKomokuMstBLOutput output = new UpdateDaichoSuishitsuKensaTanKomokuMstBLOutput();

            try
            {
                new UpdateDaichoSuishitsuKensaTanKomokuMstDataAccess().Execute(input);
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
