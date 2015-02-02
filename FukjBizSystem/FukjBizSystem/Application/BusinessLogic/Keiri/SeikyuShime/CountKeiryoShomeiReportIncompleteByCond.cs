using System.Reflection;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShime
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICountKeiryoShomeiReportIncompleteByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICountKeiryoShomeiReportIncompleteByCondBLInput : ICountKeiryoShomeiReportIncompleteByCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountKeiryoShomeiReportIncompleteByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountKeiryoShomeiReportIncompleteByCondBLInput : ICountKeiryoShomeiReportIncompleteByCondBLInput
    {

        /// <summary>
        /// 検査年月
        /// </summary>
        public string KensaIraiKensaNenTsuki { get; set; }

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        ///業者コード（終了）
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 締め区分
        /// </summary>
        public string ShimeKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICountKeiryoShomeiReportIncompleteByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICountKeiryoShomeiReportIncompleteByCondBLOutput : ICountKeiryoShomeiReportIncompleteByCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountKeiryoShomeiReportIncompleteByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountKeiryoShomeiReportIncompleteByCondBLOutput : ICountKeiryoShomeiReportIncompleteByCondBLOutput
    {
        /// <summary>
        /// KeiryouShomeiIncompleteCount
        /// </summary>
        public int KeiryouShomeiIncompleteCount { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountKeiryoShomeiReportIncompleteByCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountKeiryoShomeiReportIncompleteByCondBusinessLogic : BaseBusinessLogic<ICountKeiryoShomeiReportIncompleteByCondBLInput, ICountKeiryoShomeiReportIncompleteByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CountKeiryoShomeiReportIncompleteByCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CountKeiryoShomeiReportIncompleteByCondBusinessLogic()
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
        /// 2014/10/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ICountKeiryoShomeiReportIncompleteByCondBLOutput Execute(ICountKeiryoShomeiReportIncompleteByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICountKeiryoShomeiReportIncompleteByCondBLOutput output = new CountKeiryoShomeiReportIncompleteByCondBLOutput();

            try
            {
                output.KeiryouShomeiIncompleteCount = new CountKeiryoShomeiReportIncompleteByCondDataAccess().Execute(input).KeiryouShomeiIncompleteCount;
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
