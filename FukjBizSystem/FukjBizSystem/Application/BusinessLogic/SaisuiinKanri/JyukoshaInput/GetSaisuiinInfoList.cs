using System.Reflection;
using FukjBizSystem.Application.DataAccess.SaisuiinMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SaisuiinKanri.JyukoshaInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaisuiinInfoListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaisuiinInfoListBLInput : ISelectSaisuiinInfoListBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiinInfoListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiinInfoListBLInput : IGetSaisuiinInfoListBLInput
    {
        /// <summary>
        /// 採水員コード（開始）
        /// </summary>
        public string SaisuiinCdFrom { get; set; }

        /// <summary>
        /// 採水員コード（終了）
        /// </summary>
        public string SaisuiinCdTo { get; set; }

        /// <summary>
        /// 所属業者コード（開始）
        /// </summary>
        public string SyozokuGyosyaCdFrom { get; set; }

        /// <summary>
        /// 所属業者コード（開始）
        /// </summary>
        public string SyozokuGyosyaCdTo { get; set; }

        /// <summary>
        /// 採水員名
        /// </summary>
        public string SaisuiinNm { get; set; }

        /// <summary>
        /// 条件追加フラグ
        /// </summary>
        public bool AddConditionsFlg { get; set; }

        /// <summary>
        /// 受講日（開始）
        /// </summary>
        public string JukoDtFrom { get; set; }

        /// <summary>
        /// 受講日（終了）
        /// </summary>
        public string JukoDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaisuiinInfoListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaisuiinInfoListBLOutput : ISelectSaisuiinInfoListBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiinInfoListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiinInfoListBLOutput : IGetSaisuiinInfoListBLOutput
    {
        /// <summary>
        /// SaisuiinInfoListDataTable
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinInfoListDataTable SaisuiinInfoListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiinInfoListBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiinInfoListBusinessLogic : BaseBusinessLogic<IGetSaisuiinInfoListBLInput, IGetSaisuiinInfoListBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSaisuiinInfoListBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSaisuiinInfoListBusinessLogic()
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
        /// 2014/07/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSaisuiinInfoListBLOutput Execute(IGetSaisuiinInfoListBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSaisuiinInfoListBLOutput output = new GetSaisuiinInfoListBLOutput();

            try
            {
                output.SaisuiinInfoListDT = new SelectSaisuiinInfoListBySearchCondDataAccess().Execute(input).SaisuiinInfoListDT;
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
