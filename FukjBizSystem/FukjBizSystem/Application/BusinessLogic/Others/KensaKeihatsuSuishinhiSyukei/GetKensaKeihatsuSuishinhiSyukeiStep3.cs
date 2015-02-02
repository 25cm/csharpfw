using System.Reflection;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiSyukei
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinhiSyukeiStep3BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaKeihatsuSuishinhiSyukeiStep3BLInput : ISelectKensaKeihatsuSuishinhiSyukeiStep3DAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinhiSyukeiStep3BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKeihatsuSuishinhiSyukeiStep3BLInput : IGetKensaKeihatsuSuishinhiSyukeiStep3BLInput
    {
        /// <summary>
        /// 開始日
        /// </summary>
        public string KaishiDt { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        public string ShuryoDt { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinhiSyukeiStep3BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaKeihatsuSuishinhiSyukeiStep3BLOutput : ISelectKensaKeihatsuSuishinhiSyukeiStep3DAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinhiSyukeiStep3BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKeihatsuSuishinhiSyukeiStep3BLOutput : IGetKensaKeihatsuSuishinhiSyukeiStep3BLOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinhiSyukeiStep3DataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep3DataTable KensaKeihatsuSuishinhiSyukeiStep3DT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinhiSyukeiStep3BusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKeihatsuSuishinhiSyukeiStep3BusinessLogic : BaseBusinessLogic<IGetKensaKeihatsuSuishinhiSyukeiStep3BLInput, IGetKensaKeihatsuSuishinhiSyukeiStep3BLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaKeihatsuSuishinhiSyukeiStep3BusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaKeihatsuSuishinhiSyukeiStep3BusinessLogic()
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
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaKeihatsuSuishinhiSyukeiStep3BLOutput Execute(IGetKensaKeihatsuSuishinhiSyukeiStep3BLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaKeihatsuSuishinhiSyukeiStep3BLOutput output = new GetKensaKeihatsuSuishinhiSyukeiStep3BLOutput();

            try
            {
                output.KensaKeihatsuSuishinhiSyukeiStep3DT = new SelectKensaKeihatsuSuishinhiSyukeiStep3DataAccess().Execute(input).KensaKeihatsuSuishinhiSyukeiStep3DT;
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
