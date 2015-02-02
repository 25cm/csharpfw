using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiShosai;
using FukjBizSystem.Application.BusinessLogic.Master.SaisuiinMstShosai;
using FukjBizSystem.Application.BusinessLogic.SaisuiinKanri.SaisuiinInfoShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.SaisuiinInfoShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// 採水員コード
        /// </summary>
        string SaisuiinCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 採水員コード
        /// </summary>
        public string SaisuiinCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("採水員コード[{0}]", SaisuiinCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// SaisuiinInfoShosaiDataTable
        /// </summary>
        SaisuiinMstDataSet.SaisuiinInfoShosaiDataTable SaisuiinInfoShosaiDataTable { get; set; }

        /// <summary>
        /// 採水員マスタ
        /// </summary>
        SaisuiinMstDataSet.SaisuiinMstDataTable SaisuiinMstDataTable { get; set; }

        /// <summary>
        /// 郵便番号住所マスタ
        /// </summary>
        YubinNoAdrMstDataSet.YubinNoAdrMstDataTable YubinNoAdrMstDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// SaisuiinInfoShosaiDataTable
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinInfoShosaiDataTable SaisuiinInfoShosaiDataTable { get; set; }

        /// <summary>
        /// 採水員マスタ
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinMstDataTable SaisuiinMstDataTable { get; set; }

        /// <summary>
        /// 郵便番号住所マスタ
        /// </summary>
        public YubinNoAdrMstDataSet.YubinNoAdrMstDataTable YubinNoAdrMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SaisuiinInfoShosai：FormLoad";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FormLoadApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FormLoadApplicationLogic()
        {
            
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/07/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                if (!string.IsNullOrEmpty(input.SaisuiinCd))
                {
                    // Get 採水員マスタ by key
                    IGetSaisuiinMstByKeyBLInput mstInput = new GetSaisuiinMstByKeyBLInput();
                    mstInput.SaisuiinCd = input.SaisuiinCd;
                    IGetSaisuiinMstByKeyBLOutput mstOutput = new GetSaisuiinMstByKeyBusinessLogic().Execute(mstInput);
                    output.SaisuiinMstDataTable = mstOutput.SaisuiinMstDataTable;

                    // Get display table
                    IGetSaisuiinInfoShosaiBySaisuiinCdBLInput shosaiInput = new GetSaisuiinInfoShosaiBySaisuiinCdBLInput();
                    shosaiInput.SaisuiinCd = input.SaisuiinCd;
                    IGetSaisuiinInfoShosaiBySaisuiinCdBLOutput shosaiOutput = new GetSaisuiinInfoShosaiBySaisuiinCdBusinessLogic().Execute(shosaiInput);
                    output.SaisuiinInfoShosaiDataTable = shosaiOutput.SaisuiinInfoShosaiDataTable;
                }

                // Get 郵便番号住所マスタ info
                IGetYubinNoAdrMstInfoBLOutput yubinOutput = new GetYubinNoAdrMstInfoBusinessLogic().Execute(new GetYubinNoAdrMstInfoBLInput());
                output.YubinNoAdrMstDataTable = yubinOutput.YubinNoAdrMstDataTable;
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
