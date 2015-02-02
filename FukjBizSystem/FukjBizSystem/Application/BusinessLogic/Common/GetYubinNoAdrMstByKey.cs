using System.Reflection;
using FukjBizSystem.Application.DataAccess.YubinNoAdrMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYubinNoAdrMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYubinNoAdrMstByKeyBLInput : ISelectYubinNoAdrMstByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstByKeyBLInput : IGetYubinNoAdrMstByKeyBLInput
    {
        /// <summary>
        /// 郵便番号
        /// </summary>
        public string ZipCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYubinNoAdrMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYubinNoAdrMstByKeyBLOutput : ISelectYubinNoAdrMstByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstByKeyBLOutput : IGetYubinNoAdrMstByKeyBLOutput
    {
        /// <summary>
        /// YubinNoAdrMstDataTable
        /// </summary>
        public YubinNoAdrMstDataSet.YubinNoAdrMstDataTable YubinNoAdrMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstByKeyBusinessLogic : BaseBusinessLogic<IGetYubinNoAdrMstByKeyBLInput, IGetYubinNoAdrMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetYubinNoAdrMstByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetYubinNoAdrMstByKeyBusinessLogic()
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
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetYubinNoAdrMstByKeyBLOutput Execute(IGetYubinNoAdrMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetYubinNoAdrMstByKeyBLOutput output = new GetYubinNoAdrMstByKeyBLOutput();

            try
            {
                ISelectYubinNoAdrMstByKeyDAOutput daOutput = new SelectYubinNoAdrMstByKeyDataAccess().Execute(input);
                output.YubinNoAdrMstDataTable = daOutput.YubinNoAdrMstDataTable;
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
