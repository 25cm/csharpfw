using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.KensaKeihatsuSuishinhiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput, IGetKensaKeihatsuSuishinListBySearchCondBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// 2014/10/09  DatNT    v1.01
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        // 2014/10/09 DatNT v1.01 DEL Start
        ///// <summary>
        ///// 集計年度
        ///// </summary>
        //public string SuishinhiNendo { get; set; }

        ///// <summary>
        ///// 上下期区分
        ///// </summary>
        //public string KamiShimoKbn { get; set; }
        // 2014/10/09 DatNT v1.01 DEL End

        // 2014/10/09 DatNT v1.01 ADD Start
        /// <summary>
        /// 集計日FROM
        /// </summary>
        public string ShukeiDtFrom { get; set; }
        /// <summary>
        /// 集計日TO
        /// </summary>
        public string ShukeiDtTo { get; set; }
        // 2014/10/09 DatNT v1.01 ADD End

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyosyaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string GyosyaCdTo { get; set; }

        /// <summary>
        /// 組合コード
        /// </summary>
        public string KumiaiCd { get; set; }

        /// <summary>
        /// 対象業者/持込
        /// </summary>
        public bool Mochikomi { get; set; }

        /// <summary>
        /// 対象業者/収集
        /// </summary>
        public bool Syusyu { get; set; }

        /// <summary>
        /// 対象業者/取扱
        /// </summary>
        public bool Toriatsukai { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("集計日FROM[{0}], 集計日TO[{1}], 業者コード（開始）[{2}], 業者コード（終了）[{3}], 組合コード[{4}], 対象業者/持込[{5}], 対象業者/収集[{6}], 対象業者/取扱[{7}]",
                    new string[] {
                        //SuishinhiNendo,
                        //KamiShimoKbn,
                        ShukeiDtFrom,
                        ShukeiDtTo,
                        GyosyaCdFrom,
                        GyosyaCdTo,
                        KumiaiCd,
                        Mochikomi.ToString(),
                        Syusyu.ToString(),
                        Toriatsukai.ToString(),
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput : IGetKensaKeihatsuSuishinListBySearchCondBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKeihatsuSuishinhiList：KensakuBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensakuBtnClickApplicationLogic()
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
        /// 2014/08/18  DatNT　  新規作成
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                output.KensaKeihatsuSuishinListDT = new GetKensaKeihatsuSuishinListBySearchCondBusinessLogic().Execute(input).KensaKeihatsuSuishinListDT;
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
