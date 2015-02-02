using System.Reflection;
using FukjBizSystem.Application.DataAccess.WarekiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.WarekiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetWarekiMstByKaishiDtBLInput
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
    interface IGetWarekiMstByKaishiDtBLInput : ISelectWarekiMstByKaishiDtDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetWarekiMstByKaishiDtBLInput
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
    class GetWarekiMstByKaishiDtBLInput : IGetWarekiMstByKaishiDtBLInput
    {
        /// <summary>
        /// 対象日付
        /// </summary>
        public string KaishiDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetWarekiMstByKaishiDtBLOutput
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
    interface IGetWarekiMstByKaishiDtBLOutput : ISelectWarekiMstByKaishiDtDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetWarekiMstByKaishiDtBLOutput
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
    class GetWarekiMstByKaishiDtBLOutput : IGetWarekiMstByKaishiDtBLOutput
    {
        /// <summary>
        /// 和暦マスタ情報
        /// </summary>
        public WarekiMstDataSet.WarekiMstDataTable WarekiMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetWarekiMstByKaishiDtBusinessLogic
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
    class GetWarekiMstByKaishiDtBusinessLogic : BaseBusinessLogic<IGetWarekiMstByKaishiDtBLInput, IGetWarekiMstByKaishiDtBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetWarekiMstByKaishiDtBusinessLogic
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
        public GetWarekiMstByKaishiDtBusinessLogic()
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
        public override IGetWarekiMstByKaishiDtBLOutput Execute(IGetWarekiMstByKaishiDtBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetWarekiMstByKaishiDtBLOutput output = new GetWarekiMstByKaishiDtBLOutput();

            try
            {
                // 対象日付の和暦レコードを取得
                ISelectWarekiMstByKaishiDtDAOutput daOutput = new SelectWarekiMstByKaishiDtDataAccess().Execute(input);

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
