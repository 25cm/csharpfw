using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShoriHoshikiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiMstInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShoriHoshikiMstInfoBLInput : ISelectShoriHoshikiMstInfoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiMstInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiMstInfoBLInput : IGetShoriHoshikiMstInfoBLInput
    {
        
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiMstInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShoriHoshikiMstInfoBLOutput : ISelectShoriHoshikiMstInfoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiMstInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiMstInfoBLOutput : IGetShoriHoshikiMstInfoBLOutput
    {
        /// <summary>
        /// ShoriHoshikiMstDataTable
        /// </summary>
        public ShoriHoshikiMstDataSet.ShoriHoshikiMstDataTable ShoriHoshikiMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiMstInfoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiMstInfoBusinessLogic : BaseBusinessLogic<IGetShoriHoshikiMstInfoBLInput, IGetShoriHoshikiMstInfoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShoriHoshikiMstInfoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShoriHoshikiMstInfoBusinessLogic()
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShoriHoshikiMstInfoBLOutput Execute(IGetShoriHoshikiMstInfoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShoriHoshikiMstInfoBLOutput output = new GetShoriHoshikiMstInfoBLOutput();

            try
            {
                output.ShoriHoshikiMstDT = new SelectShoriHoshikiMstInfoDataAccess().Execute(input).ShoriHoshikiMstDT;
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
