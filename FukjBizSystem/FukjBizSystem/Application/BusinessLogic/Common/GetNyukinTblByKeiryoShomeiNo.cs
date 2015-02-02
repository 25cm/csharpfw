using System.Reflection;
using FukjBizSystem.Application.DataAccess.NyukinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNyukinTblByKeiryoShomeiNoBLInput
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
    interface IGetNyukinTblByKeiryoShomeiNoBLInput : ISelectNyukinTblByKeiryoShomeiNoDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinTblByKeiryoShomeiNoBLInput
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
    class GetNyukinTblByKeiryoShomeiNoBLInput : IGetNyukinTblByKeiryoShomeiNoBLInput
    {
        /// <summary>
        /// 計量証明検査依頼年度
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }
        /// <summary>
        /// 計量証明支所コード
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }
        /// <summary>
        /// 計量証明依頼連番
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNyukinTblByKeiryoShomeiNoBLOutput
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
    interface IGetNyukinTblByKeiryoShomeiNoBLOutput : ISelectNyukinTblByKeiryoShomeiNoDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinTblByKeiryoShomeiNoBLOutput
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
    class GetNyukinTblByKeiryoShomeiNoBLOutput : IGetNyukinTblByKeiryoShomeiNoBLOutput
    {
        /// <summary>
        /// 入金データ
        /// </summary>
        public NyukinTblDataSet.NyukinTblDataTable NyukinTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNyukinTblByKeiryoShomeiNoBusinessLogic
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
    class GetNyukinTblByKeiryoShomeiNoBusinessLogic : BaseBusinessLogic<IGetNyukinTblByKeiryoShomeiNoBLInput, IGetNyukinTblByKeiryoShomeiNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetNyukinTblByKeiryoShomeiNoBusinessLogic
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
        public GetNyukinTblByKeiryoShomeiNoBusinessLogic()
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
        public override IGetNyukinTblByKeiryoShomeiNoBLOutput Execute(IGetNyukinTblByKeiryoShomeiNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetNyukinTblByKeiryoShomeiNoBLOutput output = new GetNyukinTblByKeiryoShomeiNoBLOutput();

            try
            {
                // 入金データ取得
                output.NyukinTblDT = new SelectNyukinTblByKeiryoShomeiNoDataAccess().Execute(input).NyukinTblDT;
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
