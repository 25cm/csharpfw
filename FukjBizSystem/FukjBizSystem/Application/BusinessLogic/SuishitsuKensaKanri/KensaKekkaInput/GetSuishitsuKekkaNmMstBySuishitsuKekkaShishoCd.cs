using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataAccess.SuishitsuKekkaNmMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaKekkaInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLInput : ISelectSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLInput : IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string SuishitsuKekkaShishoCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLOutput : ISelectSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLOutput : IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLOutput
    {
        /// <summary>
        /// 水質結果名称マスタ
        /// </summary>
        public SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable SuishitsuKekkaNmMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBusinessLogic : BaseBusinessLogic<IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLInput, IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBusinessLogic()
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
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLOutput Execute(IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLOutput output = new GetSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdBLOutput();

            try
            {
                output.SuishitsuKekkaNmMstDataTable = new SelectSuishitsuKekkaNmMstBySuishitsuKekkaShishoCdDataAccess().Execute(input).SuishitsuKekkaNmMstDataTable;
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
