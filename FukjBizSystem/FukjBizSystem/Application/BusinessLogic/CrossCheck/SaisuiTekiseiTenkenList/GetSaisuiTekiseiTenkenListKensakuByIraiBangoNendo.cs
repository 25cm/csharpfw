using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.CrossCheck.SaisuiTekiseiTenkenList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLInput : ISelectSaisuiTekiseiTenkenListKensakuByIraiBangoNendoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLInput : IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLInput
    {
        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        public string IraiBangoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        public string IraiBangoTo { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput : ISelectSaisuiTekiseiTenkenListKensakuByIraiBangoNendoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput : IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput
    {
        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        public KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable SaisuiTekiseiTenkenListKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBusinessLogic : BaseBusinessLogic<IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLInput, IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBusinessLogic()
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
        /// 2014/10/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput Execute(IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput output = new GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput();

            try
            {
                ISelectSaisuiTekiseiTenkenListKensakuByIraiBangoNendoDAOutput daOutput
                    = new SelectSaisuiTekiseiTenkenListKensakuByIraiBangoNendoDataAccess().Execute(input);

                output.SaisuiTekiseiTenkenListKensakuDataTable = daOutput.SaisuiTekiseiTenkenListKensakuDataTable;
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
