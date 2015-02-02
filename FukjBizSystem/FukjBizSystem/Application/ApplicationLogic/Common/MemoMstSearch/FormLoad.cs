using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common.MemoMstSearch;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Common.MemoMstSearch
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
    /// 2014/11/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput, IGetMemoMstSearchBySearchCondBLInput
    {
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
    /// 2014/11/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 大分類コード（開始）
        /// </summary>
        public string MemoDaibunruiCdFrom { get; set; }

        /// <summary>
        /// 大分類コード（終了）
        /// </summary>
        public string MemoDaibunruiCdTo { get; set; }

        /// <summary>
        /// メモコード（開始）
        /// </summary>
        public string MemoCdFrom { get; set; }

        /// <summary>
        /// メモコード（終了）
        /// </summary>
        public string MemoCdTo { get; set; }

        /// <summary>
        /// メモ内容
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("大分類コード（開始）[{0}], 大分類コード（終了）[{1}], メモコード（開始）[{2}], メモコード（終了）[{3}], メモ内容[{4}] ",
                    new string[] { 
                        MemoDaibunruiCdFrom,
                        MemoDaibunruiCdTo,
                        MemoCdFrom,
                        MemoCdTo,
                        Memo
                    });
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
    /// 2014/11/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput : IGetMemoMstSearchBySearchCondBLOutput
    {
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
    /// 2014/11/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// MemoMstSearchListDataTable
        /// </summary>
        public MemoMstDataSet.MemoMstSearchListDataTable MemoMstSearchListDT { get; set; }
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
    /// 2014/11/03  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "MemoMstSearch：FormLoad";

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
        /// 2014/11/03  HuyTX　    新規作成
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
        /// 2014/11/03  HuyTX　    新規作成
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
        /// 2014/11/03  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                output.MemoMstSearchListDT = new GetMemoMstSearchBySearchCondBusinessLogic().Execute(input).MemoMstSearchListDT;

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
