using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinListBySearchCondBLInput
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
    interface IGetKensaKeihatsuSuishinListBySearchCondBLInput : ISelectKensaKeihatsuSuishinListBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinListBySearchCondBLInput
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
    class GetKensaKeihatsuSuishinListBySearchCondBLInput : IGetKensaKeihatsuSuishinListBySearchCondBLInput
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
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinListBySearchCondBLOutput
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
    interface IGetKensaKeihatsuSuishinListBySearchCondBLOutput : ISelectKensaKeihatsuSuishinListBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinListBySearchCondBLOutput
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
    class GetKensaKeihatsuSuishinListBySearchCondBLOutput : IGetKensaKeihatsuSuishinListBySearchCondBLOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinListBySearchCondBusinessLogic
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
    class GetKensaKeihatsuSuishinListBySearchCondBusinessLogic : BaseBusinessLogic<IGetKensaKeihatsuSuishinListBySearchCondBLInput, IGetKensaKeihatsuSuishinListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaKeihatsuSuishinListBySearchCondBusinessLogic
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
        public GetKensaKeihatsuSuishinListBySearchCondBusinessLogic()
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaKeihatsuSuishinListBySearchCondBLOutput Execute(IGetKensaKeihatsuSuishinListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaKeihatsuSuishinListBySearchCondBLOutput output = new GetKensaKeihatsuSuishinListBySearchCondBLOutput();

            try
            {
                output.KensaKeihatsuSuishinListDT = new SelectKensaKeihatsuSuishinListBySearchCondDataAccess().Execute(input).KensaKeihatsuSuishinListDT;
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
