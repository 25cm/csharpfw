using System.Reflection;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.JokasoDaichoSyukeiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJokasoDaichoSyukeiListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJokasoDaichoSyukeiListBySearchCondBLInput : ISelectJokasoDaichoSyukeiListBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoSyukeiListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoSyukeiListBySearchCondBLInput : IGetJokasoDaichoSyukeiListBySearchCondBLInput
    {
        /// <summary>
        /// 出力帳票
        /// </summary>
        public string ShutsuryokuChohyo { get; set; }

        /// <summary>
        /// 保健所コード
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// 受付日使用有無
        /// </summary>
        public bool UketsukeUse { get; set; }

        /// <summary>
        /// 受付日（開始）
        /// </summary>
        public string UketsukeDtFrom { get; set; }

        /// <summary>
        /// 受付日（終了）
        /// </summary>
        public string UketsukeDtTo { get; set; }

        /// <summary>
        /// 検査日使用有無
        /// </summary>
        public bool KensaUse { get; set; }

        /// <summary>
        /// 検査日（開始）
        /// </summary>
        public string KensaDtFrom { get; set; }

        /// <summary>
        /// 検査日（終了）
        /// </summary>
        public string KensaDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJokasoDaichoSyukeiListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJokasoDaichoSyukeiListBySearchCondBLOutput : ISelectJokasoDaichoSyukeiListBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoSyukeiListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoSyukeiListBySearchCondBLOutput : IGetJokasoDaichoSyukeiListBySearchCondBLOutput
    {
        /// <summary>
        /// JokasoDaichoSyukeiListDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable JokasoDaichoSyukeiListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoSyukeiListBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoSyukeiListBySearchCondBusinessLogic : BaseBusinessLogic<IGetJokasoDaichoSyukeiListBySearchCondBLInput, IGetJokasoDaichoSyukeiListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetJokasoDaichoSyukeiListBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetJokasoDaichoSyukeiListBySearchCondBusinessLogic()
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
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetJokasoDaichoSyukeiListBySearchCondBLOutput Execute(IGetJokasoDaichoSyukeiListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetJokasoDaichoSyukeiListBySearchCondBLOutput output = new GetJokasoDaichoSyukeiListBySearchCondBLOutput();

            try
            {
                output.JokasoDaichoSyukeiListDT = new SelectJokasoDaichoSyukeiListBySearchCondDataAccess().Execute(input).JokasoDaichoSyukeiListDT;
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
