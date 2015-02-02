using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SaisuiinKanri.JyukoYoteishaList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.JyukoYoteishaList
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
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput, IGetJyukoYoteishaListBySearchCondBLInput
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
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 前回受講日追加フラグ
        /// </summary>
        public bool ZenkaiJukoDtAddFlg { get; set; }

        /// <summary>
        /// 前回受講日（開始）
        /// </summary>
        public string ZenkaiJukoDtFrom { get; set; }

        /// <summary>
        /// 前回受講日（終了）
        /// </summary>
        public string ZenkaiJukoDtTo { get; set; }

        /// <summary>
        /// 有効期限追加フラグ
        /// </summary>
        public bool SaisuiinYukokigenDtAddFlg { get; set; }

        /// <summary>
        /// 有効期限（開始）
        /// </summary>
        public string SaisuiinYukokigenDtFrom { get; set; }

        /// <summary>
        /// 有効期限（終了）
        /// </summary>
        public string SaisuiinYukokigenDtTo { get; set; }

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
        /// 所属業者コード（終了）
        /// </summary>
        public string SyozokuGyosyaCdTo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("前回受講日追加フラグ[{0}], 前回受講日（開始）[{1}], 前回受講日（終了）[{2}], 有効期限追加フラグ[{3}], 有効期限（開始）[{4}], 有効期限（終了）[{5}], 採水員コード（開始）[{6}], 採水員コード（終了）[{7}], 所属業者コード（開始）[{8}], 所属業者コード（終了）[{9}]",
                    new string[] { 
                        ZenkaiJukoDtAddFlg.ToString(),
                        ZenkaiJukoDtFrom,
                        ZenkaiJukoDtTo,
                        SaisuiinYukokigenDtAddFlg.ToString(),
                        SaisuiinYukokigenDtFrom,
                        SaisuiinYukokigenDtTo,
                        SaisuiinCdFrom,
                        SaisuiinCdTo,
                        SyozokuGyosyaCdFrom,
                        SyozokuGyosyaCdTo
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
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput : IGetJyukoYoteishaListBySearchCondBLOutput
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
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// JyukoYoteishaListDataTable
        /// </summary>
        public SaisuiinMstDataSet.JyukoYoteishaListDataTable JyukoYoteishaListDT { get; set; }
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
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JyukoYoteishaList：FormLoadApplicationLogic";

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
        /// 2014/07/29  DatNT　  新規作成
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
        /// 2014/07/29  DatNT　  新規作成
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
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                output.JyukoYoteishaListDT = new GetJyukoYoteishaListBySearchCondBusinessLogic().Execute(input).JyukoYoteishaListDT;
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
