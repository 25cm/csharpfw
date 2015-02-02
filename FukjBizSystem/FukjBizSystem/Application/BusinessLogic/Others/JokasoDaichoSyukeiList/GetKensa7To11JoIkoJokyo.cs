using System.Reflection;
using FukjBizSystem.Application.DataAccess.IkoJokyoShukeiWrk;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.JokasoDaichoSyukeiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensa7To11JoIkoJokyoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensa7To11JoIkoJokyoBLInput : ISelectKensa7To11JoIkoJokyoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensa7To11JoIkoJokyoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensa7To11JoIkoJokyoBLInput : IGetKensa7To11JoIkoJokyoBLInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensa7To11JoIkoJokyoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensa7To11JoIkoJokyoBLOutput : ISelectKensa7To11JoIkoJokyoDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensa7To11JoIkoJokyoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensa7To11JoIkoJokyoBLOutput : IGetKensa7To11JoIkoJokyoBLOutput
    {
        /// <summary>
        /// Kensa7To11JoIkoJokyoDataTable
        /// </summary>
        public IkoJokyoShukeiWrkDataSet.Kensa7To11JoIkoJokyoDataTable Kensa7To11JoIkoJokyoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensa7To11JoIkoJokyoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensa7To11JoIkoJokyoBusinessLogic : BaseBusinessLogic<IGetKensa7To11JoIkoJokyoBLInput, IGetKensa7To11JoIkoJokyoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensa7To11JoIkoJokyoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensa7To11JoIkoJokyoBusinessLogic()
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
        /// 2014/10/30  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensa7To11JoIkoJokyoBLOutput Execute(IGetKensa7To11JoIkoJokyoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensa7To11JoIkoJokyoBLOutput output = new GetKensa7To11JoIkoJokyoBLOutput();

            try
            {
                output.Kensa7To11JoIkoJokyoDataTable = new SelectKensa7To11JoIkoJokyoDataAccess().Execute(input).Kensa7To11JoIkoJokyoDataTable;

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
