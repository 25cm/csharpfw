using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShozokuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ShokuinMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertShozokuMstBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertShozokuMstBLInput : IInsertShozokuMstDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertShozokuMstBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertShozokuMstBLInput : IInsertShozokuMstBLInput
    {
        /// <summary>
        /// ShozokuMstRow
        /// </summary>
        public ShozokuMstDataSet.ShozokuMstRow ShozokuMstRow { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertShozokuMstBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertShozokuMstBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertShozokuMstBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertShozokuMstBLOutput : IInsertShozokuMstBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertShozokuMstBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertShozokuMstBusinessLogic : BaseBusinessLogic<IInsertShozokuMstBLInput, IInsertShozokuMstBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InsertShozokuMstBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public InsertShozokuMstBusinessLogic()
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
        /// 2015/01/27　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IInsertShozokuMstBLOutput Execute(IInsertShozokuMstBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertShozokuMstBLOutput output = new InsertShozokuMstBLOutput();

            try
            {
                new InsertShozokuMstDataAccess().Execute(input);
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
