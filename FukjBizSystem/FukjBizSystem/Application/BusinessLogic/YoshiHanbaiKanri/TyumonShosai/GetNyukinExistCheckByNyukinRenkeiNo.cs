using System.Reflection;
using FukjBizSystem.Application.DataAccess.YoshiHanbaiKanri.TyumonShosai;
using FukjBizSystem.Application.DataSet.YoshiHanbaiKanri;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNyukinExistCheckByNyukinRenkeiNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNyukinExistCheckByNyukinRenkeiNoBLInput : ISelectNyukinExistCheckByNyukinRenkeiNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinExistCheckByNyukinRenkeiNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNyukinExistCheckByNyukinRenkeiNoBLInput : IGetNyukinExistCheckByNyukinRenkeiNoBLInput
    {
        /// <summary>
        /// 連携No
        /// </summary>
        public string NyukinRenkeiNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNyukinExistCheckByNyukinRenkeiNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNyukinExistCheckByNyukinRenkeiNoBLOutput : ISelectNyukinExistCheckByNyukinRenkeiNoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinExistCheckByNyukinRenkeiNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNyukinExistCheckByNyukinRenkeiNoBLOutput : IGetNyukinExistCheckByNyukinRenkeiNoBLOutput
    {
        /// <summary>
        /// NyukinExistCheckDataTable
        /// </summary>
        public TyumonShosaiDataSet.NyukinExistCheckDataTable NyukinExistCheckDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinExistCheckByNyukinRenkeiNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNyukinExistCheckByNyukinRenkeiNoBusinessLogic : BaseBusinessLogic<IGetNyukinExistCheckByNyukinRenkeiNoBLInput, IGetNyukinExistCheckByNyukinRenkeiNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetNyukinExistCheckByNyukinRenkeiNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetNyukinExistCheckByNyukinRenkeiNoBusinessLogic()
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
        /// 2015/01/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetNyukinExistCheckByNyukinRenkeiNoBLOutput Execute(IGetNyukinExistCheckByNyukinRenkeiNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetNyukinExistCheckByNyukinRenkeiNoBLOutput output = new GetNyukinExistCheckByNyukinRenkeiNoBLOutput();

            try
            {
                ISelectNyukinExistCheckByNyukinRenkeiNoDAOutput daOutput = new SelectNyukinExistCheckByNyukinRenkeiNoDataAccess().Execute(input);
                output.NyukinExistCheckDataTable = daOutput.NyukinExistCheckDataTable;
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
