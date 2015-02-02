using System.Reflection;
using FukjBizSystem.Application.DataAccess.SetShikenKomokuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.SuishitsuKensaSetMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSetShikenKomokuMstBySetKomokuSetCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSetShikenKomokuMstBySetKomokuSetCdBLInput : ISelectSetShikenKomokuMstBySetKomokuSetCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSetShikenKomokuMstBySetKomokuSetCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSetShikenKomokuMstBySetKomokuSetCdBLInput : IGetSetShikenKomokuMstBySetKomokuSetCdBLInput
    {
        /// <summary>
        /// セットコード
        /// </summary>
        public string SetKomokuSetCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSetShikenKomokuMstBySetKomokuSetCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSetShikenKomokuMstBySetKomokuSetCdBLOutput : ISelectSetShikenKomokuMstBySetKomokuSetCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSetShikenKomokuMstBySetKomokuSetCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSetShikenKomokuMstBySetKomokuSetCdBLOutput : IGetSetShikenKomokuMstBySetKomokuSetCdBLOutput
    {
        /// <summary>
        /// SetShikenKomokuMstDataTable
        /// </summary>
        public SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable SetShikenKomokuMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSetShikenKomokuMstBySetKomokuSetCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSetShikenKomokuMstBySetKomokuSetCdBusinessLogic : BaseBusinessLogic<IGetSetShikenKomokuMstBySetKomokuSetCdBLInput, IGetSetShikenKomokuMstBySetKomokuSetCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSetShikenKomokuMstBySetKomokuSetCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSetShikenKomokuMstBySetKomokuSetCdBusinessLogic()
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
        /// 2014/07/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSetShikenKomokuMstBySetKomokuSetCdBLOutput Execute(IGetSetShikenKomokuMstBySetKomokuSetCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSetShikenKomokuMstBySetKomokuSetCdBLOutput output = new GetSetShikenKomokuMstBySetKomokuSetCdBLOutput();

            try
            {
                ISelectSetShikenKomokuMstBySetKomokuSetCdDAOutput daOutput = new SelectSetShikenKomokuMstBySetKomokuSetCdDataAccess().Execute(input);
                output.SetShikenKomokuMstDataTable = daOutput.SetShikenKomokuMstDataTable;
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
