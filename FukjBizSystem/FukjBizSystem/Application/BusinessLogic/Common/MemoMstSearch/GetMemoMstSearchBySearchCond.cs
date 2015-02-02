using System.Reflection;
using FukjBizSystem.Application.DataAccess.MemoMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common.MemoMstSearch
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMemoMstSearchBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMemoMstSearchBySearchCondBLInput : ISelectMemoMstSearchBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoMstSearchBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMemoMstSearchBySearchCondBLInput : IGetMemoMstSearchBySearchCondBLInput
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
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMemoMstSearchBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMemoMstSearchBySearchCondBLOutput : ISelectMemoMstSearchBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoMstSearchBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMemoMstSearchBySearchCondBLOutput : IGetMemoMstSearchBySearchCondBLOutput
    {
        /// <summary>
        /// MemoMstSearchListDataTable
        /// </summary>
        public MemoMstDataSet.MemoMstSearchListDataTable MemoMstSearchListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoMstSearchBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMemoMstSearchBySearchCondBusinessLogic : BaseBusinessLogic<IGetMemoMstSearchBySearchCondBLInput, IGetMemoMstSearchBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMemoMstSearchBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetMemoMstSearchBySearchCondBusinessLogic()
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
        /// 2014/09/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetMemoMstSearchBySearchCondBLOutput Execute(IGetMemoMstSearchBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMemoMstSearchBySearchCondBLOutput output = new GetMemoMstSearchBySearchCondBLOutput();

            try
            {
                output.MemoMstSearchListDT = new SelectMemoMstSearchBySearchCondDataAccess().Execute(input).MemoMstSearchListDT;
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
