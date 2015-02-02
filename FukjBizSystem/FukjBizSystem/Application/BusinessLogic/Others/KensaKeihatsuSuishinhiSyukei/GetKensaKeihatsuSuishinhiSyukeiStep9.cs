using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiSyukei
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinhiSyukeiStep9BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaKeihatsuSuishinhiSyukeiStep9BLInput : ISelectKensaKeihatsuSuishinhiSyukeiStep9DAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinhiSyukeiStep9BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKeihatsuSuishinhiSyukeiStep9BLInput : IGetKensaKeihatsuSuishinhiSyukeiStep9BLInput
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
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinhiSyukeiStep9BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaKeihatsuSuishinhiSyukeiStep9BLOutput : ISelectKensaKeihatsuSuishinhiSyukeiStep9DAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinhiSyukeiStep9BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKeihatsuSuishinhiSyukeiStep9BLOutput : IGetKensaKeihatsuSuishinhiSyukeiStep9BLOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinhiSyukeiStep9DataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaKeihatsuSuishinhiSyukeiStep9DataTable KensaKeihatsuSuishinhiSyukeiStep9DT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinhiSyukeiStep9BusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKeihatsuSuishinhiSyukeiStep9BusinessLogic : BaseBusinessLogic<IGetKensaKeihatsuSuishinhiSyukeiStep9BLInput, IGetKensaKeihatsuSuishinhiSyukeiStep9BLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaKeihatsuSuishinhiSyukeiStep9BusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaKeihatsuSuishinhiSyukeiStep9BusinessLogic()
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
        /// 2014/09/26  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaKeihatsuSuishinhiSyukeiStep9BLOutput Execute(IGetKensaKeihatsuSuishinhiSyukeiStep9BLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaKeihatsuSuishinhiSyukeiStep9BLOutput output = new GetKensaKeihatsuSuishinhiSyukeiStep9BLOutput();

            try
            {
                output.KensaKeihatsuSuishinhiSyukeiStep9DT = new SelectKensaKeihatsuSuishinhiSyukeiStep9DataAccess().Execute(input).KensaKeihatsuSuishinhiSyukeiStep9DT;
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
