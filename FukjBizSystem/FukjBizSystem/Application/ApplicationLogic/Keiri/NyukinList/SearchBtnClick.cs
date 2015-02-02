using System.Reflection;
using System.Text;
using FukjBizSystem.Application.BusinessLogic.Keiri.NyukinList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.NyukinList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISearchBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISearchBtnClickALInput : IBseALInput, IGetNyukinListKensakuBySearchCondBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SearchBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SearchBtnClickALInput : ISearchBtnClickALInput
    {
        /// <summary>
        /// Search condition
        /// </summary>
        public NyukinKensakuSearchCond SearchCond { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return GetDataString();
            }
        }

        #region GetDataString
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDataString
        /// <summary>
        /// 
        /// </summary>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetDataString()
        {
            StringBuilder dataStr = new StringBuilder();

            dataStr.AppendLine(string.Format("支所[{0}]", SearchCond.NyukinShisyoCd));
            dataStr.AppendLine(string.Format("業者コード（開始）[{0}]", SearchCond.NyukinGyosyaCdFrom));
            dataStr.AppendLine(string.Format("業者コード（終了）[{0}]", SearchCond.NyukinGyosyaCdTo));
            dataStr.AppendLine(string.Format("名称[{0}]", SearchCond.NyukinsyaNm));
            dataStr.AppendLine(string.Format("入金種別[{0}]", SearchCond.NyukinSyubetsu[0]));
            dataStr.AppendLine(string.Format("入金方法[{0}]", SearchCond.NyukinHoho[0]));
            dataStr.AppendLine(string.Format("入金日（開始）[{0}]", SearchCond.NyukinDtFrom));
            dataStr.AppendLine(string.Format("入金日（終了）[{0}]", SearchCond.NyukinDtTo));
            dataStr.AppendLine(string.Format("追加条件[{0}]", SearchCond.TsuikaJoken));

            return dataStr.ToString();
        }
        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISearchBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISearchBtnClickALOutput : IGetNyukinListKensakuBySearchCondBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SearchBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SearchBtnClickALOutput : ISearchBtnClickALOutput
    {
        /// <summary>
        /// NyukinListKensakuDataTable
        /// </summary>
        public NyukinTblDataSet.NyukinListKensakuDataTable NyukinListKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SearchBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SearchBtnClickApplicationLogic : BaseApplicationLogic<ISearchBtnClickALInput, ISearchBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "NyukinList：SearchBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SearchBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SearchBtnClickApplicationLogic()
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
        /// 2014/09/15　AnhNV　　    新規作成
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
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISearchBtnClickALOutput Execute(ISearchBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISearchBtnClickALOutput output = new SearchBtnClickALOutput();

            try
            {
                IGetNyukinListKensakuBySearchCondBLOutput blOutput = new GetNyukinListKensakuBySearchCondBusinessLogic().Execute(input);
                output.NyukinListKensakuDataTable = blOutput.NyukinListKensakuDataTable;
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
