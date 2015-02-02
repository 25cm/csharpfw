using System.Reflection;
using FukjBizSystem.Application.DataAccess.MemoDaibunruiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.MemoMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMemoDaibunruiMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMemoDaibunruiMstByKeyBLInput : ISelectMemoDaibunruiMstByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoDaibunruiMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMemoDaibunruiMstByKeyBLInput : IGetMemoDaibunruiMstByKeyBLInput
    {
        /// <summary>
        /// 大分類コード
        /// </summary>
        public string MemoDaibunruiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMemoDaibunruiMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMemoDaibunruiMstByKeyBLOutput : ISelectMemoDaibunruiMstByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoDaibunruiMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMemoDaibunruiMstByKeyBLOutput : IGetMemoDaibunruiMstByKeyBLOutput
    {
        /// <summary>
        /// MemoDaibunruiMstDataTable
        /// </summary>
        public MemoDaibunruiMstDataSet.MemoDaibunruiMstDataTable MemoDaibunruiMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoDaibunruiMstByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMemoDaibunruiMstByKeyBusinessLogic : BaseBusinessLogic<IGetMemoDaibunruiMstByKeyBLInput, IGetMemoDaibunruiMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMemoDaibunruiMstByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetMemoDaibunruiMstByKeyBusinessLogic()
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
        /// 2014/11/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetMemoDaibunruiMstByKeyBLOutput Execute(IGetMemoDaibunruiMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMemoDaibunruiMstByKeyBLOutput output = new GetMemoDaibunruiMstByKeyBLOutput();

            try
            {
                output.MemoDaibunruiMstDT = new SelectMemoDaibunruiMstByKeyDataAccess().Execute(input).MemoDaibunruiMstDT;
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
