using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.SuishitsuKensaSetMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuKensaSetMstShosai
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
    /// 2014/07/04　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// セットコード
        /// </summary>
        string SetCd { get; set; }
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
    /// 2014/07/04　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// セットコード
        /// </summary>
        public string SetCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("セットコード[{0}]", SetCd);
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
    /// 2014/07/04　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// 水質検査セットマスタ
        /// </summary>
        SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable SuishitsuKensaSetMstDataTable { get; set; }

        /// <summary>
        /// セット試験項目マスタ
        /// </summary>
        SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable SetShikenKomokuMstDataTable { get; set; }

        /// <summary>
        /// SuishitsuKensaSetMstShosaiDataTable
        /// </summary>
        SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstShosaiDataTable SuishitsuKensaSetMstShosaiDataTable { get; set; }
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
    /// 2014/07/04　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// 水質検査セットマスタ
        /// </summary>
        public SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable SuishitsuKensaSetMstDataTable { get; set; }

        /// <summary>
        /// セット試験項目マスタ
        /// </summary>
        public SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable SetShikenKomokuMstDataTable { get; set; }

        /// <summary>
        /// SuishitsuKensaSetMstShosaiDataTable
        /// </summary>
        public SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstShosaiDataTable SuishitsuKensaSetMstShosaiDataTable { get; set; }
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
    /// 2014/07/04　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaSetMstShosai：FormLoad";

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
        /// 2014/07/04　AnhNV　　    新規作成
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
        /// 2014/07/04　AnhNV　　    新規作成
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
        /// 2014/07/04　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // Display mode
                if (!string.IsNullOrEmpty(input.SetCd))
                {
                    // Get SuishitsuKensaSetMst by key
                    IGetSuishitsuKensaSetMstByKeyBLInput setInp = new GetSuishitsuKensaSetMstByKeyBLInput();
                    setInp.SetCd = input.SetCd;
                    IGetSuishitsuKensaSetMstByKeyBLOutput setOutp = new GetSuishitsuKensaSetMstByKeyBusinessLogic().Execute(setInp);
                    output.SuishitsuKensaSetMstDataTable = setOutp.SuishitsuKensaSetMstDataTable;

                    // Get SuishitsuKensaSetMstShosai by SetCd
                    IGetSuishitsuKensaSetMstShosaiBySetCdBLInput shosaiInp = new GetSuishitsuKensaSetMstShosaiBySetCdBLInput();
                    shosaiInp.SetCd = input.SetCd;
                    IGetSuishitsuKensaSetMstShosaiBySetCdBLOutput shosaiOutp = new GetSuishitsuKensaSetMstShosaiBySetCdBusinessLogic().Execute(shosaiInp);
                    output.SuishitsuKensaSetMstShosaiDataTable = shosaiOutp.SuishitsuKensaSetMstShosaiDataTable;

                    // Get SetShikenKomokuMst by SetCd
                    IGetSetShikenKomokuMstBySetKomokuSetCdBLInput koInp = new GetSetShikenKomokuMstBySetKomokuSetCdBLInput();
                    koInp.SetKomokuSetCd = input.SetCd;
                    IGetSetShikenKomokuMstBySetKomokuSetCdBLOutput koOupt = new GetSetShikenKomokuMstBySetKomokuSetCdBusinessLogic().Execute(koInp);
                    output.SetShikenKomokuMstDataTable = koOupt.SetShikenKomokuMstDataTable;
                }
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
