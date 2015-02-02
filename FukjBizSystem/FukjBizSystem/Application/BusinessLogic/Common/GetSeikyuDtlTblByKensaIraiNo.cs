using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuDtlTblByKensaIraiNoBLInput
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
    interface IGetSeikyuDtlTblByKensaIraiNoBLInput : ISelectSeikyuDtlTblByKensaIraiNoDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuDtlTblByKensaIraiNoBLInput
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
    class GetSeikyuDtlTblByKensaIraiNoBLInput : IGetSeikyuDtlTblByKensaIraiNoBLInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }
        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }
        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }
        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSeikyuDtlTblByKensaIraiNoBLOutput
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
    interface IGetSeikyuDtlTblByKensaIraiNoBLOutput : ISelectSeikyuDtlTblByKensaIraiNoDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuDtlTblByKensaIraiNoBLOutput
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
    class GetSeikyuDtlTblByKensaIraiNoBLOutput : IGetSeikyuDtlTblByKensaIraiNoBLOutput
    {
        /// <summary>
        /// 請求明細データ
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSeikyuDtlTblByKensaIraiNoBusinessLogic
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
    class GetSeikyuDtlTblByKensaIraiNoBusinessLogic : BaseBusinessLogic<IGetSeikyuDtlTblByKensaIraiNoBLInput, IGetSeikyuDtlTblByKensaIraiNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSeikyuDtlTblByKensaIraiNoBusinessLogic
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
        public GetSeikyuDtlTblByKensaIraiNoBusinessLogic()
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
        public override IGetSeikyuDtlTblByKensaIraiNoBLOutput Execute(IGetSeikyuDtlTblByKensaIraiNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSeikyuDtlTblByKensaIraiNoBLOutput output = new GetSeikyuDtlTblByKensaIraiNoBLOutput();

            try
            {
                // 請求明細データ取得
                output.SeikyuDtlTblDT = new SelectSeikyuDtlTblByKensaIraiNoDataAccess().Execute(input).SeikyuDtlTblDT;
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
