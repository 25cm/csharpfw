using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.Common;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaKomokuMst;
using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateDaichoSuishitsuKensaKomokuMstBLInput
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
    interface IUpdateDaichoSuishitsuKensaKomokuMstBLInput : IUpdateDaichoSuishitsuKensaKomokuMstDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateDaichoSuishitsuKensaKomokuMstBLInput
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
    class UpdateDaichoSuishitsuKensaKomokuMstBLInput : IUpdateDaichoSuishitsuKensaKomokuMstBLInput
    {
        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ
        /// </summary>
        public DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateDaichoSuishitsuKensaKomokuMstBLOutput
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
    interface IUpdateDaichoSuishitsuKensaKomokuMstBLOutput : IUpdateDaichoSuishitsuKensaKomokuMstDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateDaichoSuishitsuKensaKomokuMstBLOutput
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
    class UpdateDaichoSuishitsuKensaKomokuMstBLOutput : IUpdateDaichoSuishitsuKensaKomokuMstBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateDaichoSuishitsuKensaKomokuMstBusinessLogic
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
    class UpdateDaichoSuishitsuKensaKomokuMstBusinessLogic : BaseBusinessLogic<IUpdateDaichoSuishitsuKensaKomokuMstBLInput, IUpdateDaichoSuishitsuKensaKomokuMstBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateDaichoSuishitsuKensaKomokuMstBusinessLogic
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
        public UpdateDaichoSuishitsuKensaKomokuMstBusinessLogic()
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
        public override IUpdateDaichoSuishitsuKensaKomokuMstBLOutput Execute(IUpdateDaichoSuishitsuKensaKomokuMstBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateDaichoSuishitsuKensaKomokuMstBLOutput output = new UpdateDaichoSuishitsuKensaKomokuMstBLOutput();

            try
            {
                new UpdateDaichoSuishitsuKensaKomokuMstDataAccess().Execute(input);
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
