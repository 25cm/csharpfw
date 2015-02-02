using System.Reflection;
using FukjBizSystem.Application.DataAccess.Sync.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJokasoDaichoMstByKeyFromSqlsvBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJokasoDaichoMstByKeyFromSqlsvBLInput : ISelectJokasoDaichoMstDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoMstByKeyFromSqlsvBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoMstByKeyFromSqlsvBLInput : IGetJokasoDaichoMstByKeyFromSqlsvBLInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// TorokuNendo
        /// </summary>
        public string TorokuNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        public string Renban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJokasoDaichoMstByKeyFromSqlsvBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJokasoDaichoMstByKeyFromSqlsvBLOutput : ISelectJokasoDaichoMstDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoMstByKeyFromSqlsvBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoMstByKeyFromSqlsvBLOutput : IGetJokasoDaichoMstByKeyFromSqlsvBLOutput
    {
        /// <summary>
        /// JokasoDaichoMst
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoMstByKeyFromSqlsvBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoMstByKeyFromSqlsvBusinessLogic : BaseBusinessLogic<IGetJokasoDaichoMstByKeyFromSqlsvBLInput, IGetJokasoDaichoMstByKeyFromSqlsvBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetJokasoDaichoMstByKeyFromSqlsvBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetJokasoDaichoMstByKeyFromSqlsvBusinessLogic()
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
        /// 2014/12/25　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetJokasoDaichoMstByKeyFromSqlsvBLOutput Execute(IGetJokasoDaichoMstByKeyFromSqlsvBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetJokasoDaichoMstByKeyFromSqlsvBLOutput output = new GetJokasoDaichoMstByKeyFromSqlsvBLOutput();

            try
            {
                // 検索
                output.JokasoDaichoMst = new SelectJokasoDaichoMstDataAccess().Execute(input).JokasoDaichoMst;
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
