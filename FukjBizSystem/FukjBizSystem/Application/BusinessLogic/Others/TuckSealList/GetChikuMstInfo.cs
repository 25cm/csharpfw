using System.Reflection;
using FukjBizSystem.Application.DataAccess.TuckSealList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.TuckSealList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetChikuMstInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetChikuMstInfoBLInput : ISelectChikuMstInfoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetChikuMstInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetChikuMstInfoBLInput : IGetChikuMstInfoBLInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetChikuMstInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetChikuMstInfoBLOutput : ISelectChikuMstInfoDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetChikuMstInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetChikuMstInfoBLOutput : IGetChikuMstInfoBLOutput
    {
        /// <summary>
        /// 地区マスタ
        /// </summary>
        public TuckSealListDataSet.ChikuMstDataTable ChikuMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetChikuMstInfoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetChikuMstInfoBusinessLogic : BaseBusinessLogic<IGetChikuMstInfoBLInput, IGetChikuMstInfoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetChikuMstInfoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetChikuMstInfoBusinessLogic()
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
        /// 2014/12/26　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetChikuMstInfoBLOutput Execute(IGetChikuMstInfoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetChikuMstInfoBLOutput output = new GetChikuMstInfoBLOutput();

            try
            {
                ISelectChikuMstInfoDAOutput daOutput = new SelectChikuMstInfoDataAccess().Execute(input);
                output.ChikuMstDataTable = daOutput.ChikuMstDataTable;
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
