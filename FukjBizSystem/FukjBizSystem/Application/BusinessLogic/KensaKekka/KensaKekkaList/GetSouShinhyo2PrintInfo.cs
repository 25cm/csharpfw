using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.KensaKekka.KensaKekkaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSouShinhyo2PrintInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSouShinhyo2PrintInfoBLInput : ISelectSouShinhyo2PrintInfoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSouShinhyo2PrintInfoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSouShinhyo2PrintInfoBLInput : IGetSouShinhyo2PrintInfoBLInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban 
        /// </summary>
        public string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSouShinhyo2PrintInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSouShinhyo2PrintInfoBLOutput : ISelectSouShinhyo2PrintInfoDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSouShinhyo2PrintInfoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSouShinhyo2PrintInfoBLOutput : IGetSouShinhyo2PrintInfoBLOutput
    {
        /// <summary>
        /// SouShinhyo2PrintInfoDataTable
        /// </summary>
        public KensaIraiTblDataSet.SouShinhyo2PrintInfoDataTable SouShinhyo2PrintInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSouShinhyo2PrintInfoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSouShinhyo2PrintInfoBusinessLogic : BaseBusinessLogic<IGetSouShinhyo2PrintInfoBLInput, IGetSouShinhyo2PrintInfoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSouShinhyo2PrintInfoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSouShinhyo2PrintInfoBusinessLogic()
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
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSouShinhyo2PrintInfoBLOutput Execute(IGetSouShinhyo2PrintInfoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSouShinhyo2PrintInfoBLOutput output = new GetSouShinhyo2PrintInfoBLOutput();

            try
            {
                output.SouShinhyo2PrintInfoDataTable = new SelectSouShinhyo2PrintInfoDataAccess().Execute(input).SouShinhyo2PrintInfoDataTable;

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
