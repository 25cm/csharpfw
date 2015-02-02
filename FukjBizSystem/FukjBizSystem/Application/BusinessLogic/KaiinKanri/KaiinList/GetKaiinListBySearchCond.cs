using System.Reflection;
using FukjBizSystem.Application.DataAccess.GyoshaBukaiMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.KaiinKanri.KaiinList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKaiinListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKaiinListBySearchCondBLInput : ISelectKaiinListBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKaiinListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// 2015/01/30  DatNT   v1.04
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKaiinListBySearchCondBLInput : IGetKaiinListBySearchCondBLInput
    {
        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyosyaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string GyosyaCdTo { get; set; }

        /// <summary>
        /// 業者名称
        /// </summary>
        public string GyosyaNm { get; set; }

        // 2015/01/30 DatNT v1.04 DEL Start
        ///// <summary>
        ///// 入会日検索使用フラグ
        ///// </summary>
        //public bool NyukaiDtUse { get; set; }

        ///// <summary>
        ///// 入会日（開始）
        ///// </summary>
        //public string NyukaiDtFrom { get; set; }

        ///// <summary>
        ///// 入会日（終了）
        ///// </summary>
        //public string NyukaiDtTo { get; set; }
        // 2015/01/30 DatNT v1.04 DEL End

        /// <summary>
        /// 製造
        /// </summary>
        public bool Seizo { get; set; }

        /// <summary>
        /// 工事
        /// </summary>
        public bool Koji { get; set; }

        /// <summary>
        /// 保守
        /// </summary>
        public bool Hosyu { get; set; }

        /// <summary>
        /// 清掃
        /// </summary>
        public bool Seiso { get; set; }

        /// <summary>
        /// 未加入
        /// </summary>
        public bool Mikanyu { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKaiinListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKaiinListBySearchCondBLOutput : ISelectKaiinListBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKaiinListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKaiinListBySearchCondBLOutput : IGetKaiinListBySearchCondBLOutput
    {
        /// <summary>
        /// KaiinListDataTable
        /// </summary>
        public GyoshaBukaiMstDataSet.KaiinListDataTable KaiinListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKaiinListBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKaiinListBySearchCondBusinessLogic : BaseBusinessLogic<IGetKaiinListBySearchCondBLInput, IGetKaiinListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKaiinListBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKaiinListBySearchCondBusinessLogic()
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
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKaiinListBySearchCondBLOutput Execute(IGetKaiinListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKaiinListBySearchCondBLOutput output = new GetKaiinListBySearchCondBLOutput();

            try
            {
                output.KaiinListDT = new SelectKaiinListBySearchCondDataAccess().Execute(input).KaiinListDT;
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
