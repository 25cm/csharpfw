using System.Reflection;
using System.Text;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaHoryuList;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaHoryuList
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
    /// 2014/08/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISearchBtnClickALInput : IBseALInput, IGetKensaHoryuListBySearchCondBLInput
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
    /// 2014/08/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SearchBtnClickALInput : ISearchBtnClickALInput
    {
        /// <summary>
        /// Search condition
        /// </summary>
        public KensaIraiTblSearchCond SearchCond { get; set; }

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
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GetDataString()
        {
            StringBuilder dataString = new StringBuilder();

            // 保健所コード（開始）
            if (!string.IsNullOrEmpty(SearchCond.HokenjoCdFrom))
            {
                dataString.Append(string.Format("保健所コード（開始）[{0}]\r\n", SearchCond.HokenjoCdFrom));
            }

            // 保健所コード（終了）
            if (!string.IsNullOrEmpty(SearchCond.HokenjoCdTo))
            {
                dataString.Append(string.Format("保健所コード（終了）[{0}]\r\n", SearchCond.HokenjoCdTo));
            }

            // 年度（開始）
            if (!string.IsNullOrEmpty(SearchCond.NendoFrom))
            {
                dataString.Append(string.Format("年度（開始）[{0}]\r\n", SearchCond.NendoFrom));
            }

            // 年度（終了）
            if (!string.IsNullOrEmpty(SearchCond.NendoTo))
            {
                dataString.Append(string.Format("年度（終了）[{0}]\r\n", SearchCond.NendoTo));
            }

            // 連番（開始）
            if (!string.IsNullOrEmpty(SearchCond.RenbanFrom))
            {
                dataString.Append(string.Format("連番（開始）[{0}]\r\n", SearchCond.RenbanFrom));
            }

            // 連番（終了）
            if (!string.IsNullOrEmpty(SearchCond.RenbanTo))
            {
                dataString.Append(string.Format("連番（終了）[{0}]\r\n", SearchCond.RenbanTo));
            }

            // 保留区分
            if (!string.IsNullOrEmpty(SearchCond.KensaIraiHoryuKbn))
            {
                dataString.Append(string.Format("保留区分[{0}]\r\n", SearchCond.KensaIraiHoryuKbn));
            }

            // 検査責任者
            if (!string.IsNullOrEmpty(SearchCond.KensaIraiKensaSekininsha))
            {
                dataString.Append(string.Format("検査責任者[{0}]\r\n", SearchCond.KensaIraiKensaSekininsha));
            }

            return dataString.ToString();
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
    /// 2014/08/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISearchBtnClickALOutput : IGetKensaHoryuListBySearchCondBLOutput
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
    /// 2014/08/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SearchBtnClickALOutput : ISearchBtnClickALOutput
    {
        /// <summary>
        /// KensaHoryuListDataTable
        /// </summary>
        public KensaHoryuDataSet.KensaHoryuListDataTable KensaHoryuListDataTable { get; set; }
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
    /// 2014/08/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SearchBtnClickApplicationLogic : BaseApplicationLogic<ISearchBtnClickALInput, ISearchBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaHoryuList：SearchBtnClick";

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
        /// 2014/08/27　AnhNV　　    新規作成
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
        /// 2014/08/27　AnhNV　　    新規作成
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
        /// 2014/08/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISearchBtnClickALOutput Execute(ISearchBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISearchBtnClickALOutput output = new SearchBtnClickALOutput();

            try
            {
                IGetKensaHoryuListBySearchCondBLOutput blOutput = new GetKensaHoryuListBySearchCondBusinessLogic().Execute(input);
                output.KensaHoryuListDataTable = blOutput.KensaHoryuListDataTable;
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
