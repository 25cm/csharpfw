using System.Reflection;
using FukjBizSystem.Application.DataAccess.WarekiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.WarekiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetWarekiMstByGengoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetWarekiMstByGengoBLInput : ISelectWarekiMstByGengoDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetWarekiMstByGengoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetWarekiMstByGengoBLInput : IGetWarekiMstByGengoBLInput
    {
        /// <summary>
        /// 和暦の元号
        /// </summary>
        public string Gengo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetWarekiMstByGengoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetWarekiMstByGengoBLOutput : ISelectWarekiMstByGengoDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetWarekiMstByGengoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetWarekiMstByGengoBLOutput : IGetWarekiMstByGengoBLOutput
    {
        /// <summary>
        /// 和暦マスタ情報
        /// </summary>
        public WarekiMstDataSet.WarekiMstDataTable WarekiMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetWarekiMstByGengoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetWarekiMstByGengoBusinessLogic : BaseBusinessLogic<IGetWarekiMstByGengoBLInput, IGetWarekiMstByGengoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetWarekiMstByGengoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetWarekiMstByGengoBusinessLogic()
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
        /// 2014/10/06　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetWarekiMstByGengoBLOutput Execute(IGetWarekiMstByGengoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetWarekiMstByGengoBLOutput output = new GetWarekiMstByGengoBLOutput();

            try
            {
                // 指定の和暦の元号に一致する和暦レコードを取得
                ISelectWarekiMstByGengoDAOutput daOutput = new SelectWarekiMstByGengoDataAccess().Execute(input);

                output.WarekiMstDataTable = daOutput.WarekiMstDataTable;

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
