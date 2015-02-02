using System.Reflection;
using FukjBizSystem.Application.DataAccess.NyukinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNyukinTblByMaeukekinShogoNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNyukinTblByMaeukekinShogoNoBLInput : ISelectNyukinTblByMaeukekinShogoNoDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinTblByMaeukekinShogoNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNyukinTblByMaeukekinShogoNoBLInput : IGetNyukinTblByMaeukekinShogoNoBLInput
    {
        /// <summary>
        /// 前受照合番号
        /// </summary>
        public string MaeukekinShogoNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNyukinTblByMaeukekinShogoNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNyukinTblByMaeukekinShogoNoBLOutput : ISelectNyukinTblByMaeukekinShogoNoDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinTblByMaeukekinShogoNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNyukinTblByMaeukekinShogoNoBLOutput : IGetNyukinTblByMaeukekinShogoNoBLOutput
    {
        /// <summary>
        /// 入金データ
        /// </summary>
        public NyukinTblDataSet.NyukinTblDataTable NyukinTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinTblByMaeukekinShogoNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNyukinTblByMaeukekinShogoNoBusinessLogic : BaseBusinessLogic<IGetNyukinTblByMaeukekinShogoNoBLInput, IGetNyukinTblByMaeukekinShogoNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetNyukinTblByMaeukekinShogoNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetNyukinTblByMaeukekinShogoNoBusinessLogic()
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
        /// 2014/10/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetNyukinTblByMaeukekinShogoNoBLOutput Execute(IGetNyukinTblByMaeukekinShogoNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetNyukinTblByMaeukekinShogoNoBLOutput output = new GetNyukinTblByMaeukekinShogoNoBLOutput();

            try
            {
                // 入金データ取得
                output.NyukinTblDT = new SelectNyukinTblByMaeukekinShogoNoDataAccess().Execute(input).NyukinTblDT;
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
