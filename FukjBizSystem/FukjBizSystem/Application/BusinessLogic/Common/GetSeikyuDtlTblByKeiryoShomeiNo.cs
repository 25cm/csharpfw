using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuDtlTblByKeiryoShomeiNoBLInput
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
    interface IGetSeikyuDtlTblByKeiryoShomeiNoBLInput : ISelectSeikyuDtlTblByKeiryoShomeiNoDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuDtlTblByKeiryoShomeiNoBLInput
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
    class GetSeikyuDtlTblByKeiryoShomeiNoBLInput : IGetSeikyuDtlTblByKeiryoShomeiNoBLInput
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
    //  インターフェイス名 ： IGetSeikyuDtlTblByKeiryoShomeiNoBLOutput
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
    interface IGetSeikyuDtlTblByKeiryoShomeiNoBLOutput : ISelectSeikyuDtlTblByKeiryoShomeiNoDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuDtlTblByKeiryoShomeiNoBLOutput
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
    class GetSeikyuDtlTblByKeiryoShomeiNoBLOutput : IGetSeikyuDtlTblByKeiryoShomeiNoBLOutput
    {
        /// <summary>
        /// 請求明細データ
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuDtlTblByKeiryoShomeiNoBusinessLogic
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
    class GetSeikyuDtlTblByKeiryoShomeiNoBusinessLogic : BaseBusinessLogic<IGetSeikyuDtlTblByKeiryoShomeiNoBLInput, IGetSeikyuDtlTblByKeiryoShomeiNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuDtlTblByKeiryoShomeiNoBusinessLogic
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
        public GetSeikyuDtlTblByKeiryoShomeiNoBusinessLogic()
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
        public override IGetSeikyuDtlTblByKeiryoShomeiNoBLOutput Execute(IGetSeikyuDtlTblByKeiryoShomeiNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuDtlTblByKeiryoShomeiNoBLOutput output = new GetSeikyuDtlTblByKeiryoShomeiNoBLOutput();

            try
            {
                // 請求明細データ取得
                output.SeikyuDtlTblDT = new SelectSeikyuDtlTblByKeiryoShomeiNoDataAccess().Execute(input).SeikyuDtlTblDT;
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
