using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.GaikankensaKomokuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.GaikankensaKomokuMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGaikankensaKomokuMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGaikankensaKomokuMstBySearchCondBLInput : ISelectGaikankensaKomokuMstBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGaikankensaKomokuMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGaikankensaKomokuMstBySearchCondBLInput : IGetGaikankensaKomokuMstBySearchCondBLInput
    {
        /// <summary>
        /// 外観検査項目コード（開始）
        /// </summary>
        public String GaikankensaKomokuCdFrom { get; set; }

        /// <summary>
        /// 外観検査項目コード（終了）
        /// </summary>
        public String GaikankensaKomokuCdTo { get; set; }

        /// <summary>
        /// 外観検査項目名称
        /// </summary>
        public String GaikankensaKomokuNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGaikankensaKomokuMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGaikankensaKomokuMstBySearchCondBLOutput : ISelectGaikankensaKomokuMstBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGaikankensaKomokuMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGaikankensaKomokuMstBySearchCondBLOutput : IGetGaikankensaKomokuMstBySearchCondBLOutput
    {
        /// <summary>
        /// GaikankensaKomokuMstKensakuDataTable
        /// </summary>
        public GaikankensaKomokuMstDataSet.GaikankensaKomokuMstKensakuDataTable GaikankensaKomokuMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGaikankensaKomokuMstBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGaikankensaKomokuMstBySearchCondBusinessLogic : BaseBusinessLogic<IGetGaikankensaKomokuMstBySearchCondBLInput, IGetGaikankensaKomokuMstBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetGaikankensaKomokuMstBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetGaikankensaKomokuMstBySearchCondBusinessLogic()
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
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetGaikankensaKomokuMstBySearchCondBLOutput Execute(IGetGaikankensaKomokuMstBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetGaikankensaKomokuMstBySearchCondBLOutput output = new GetGaikankensaKomokuMstBySearchCondBLOutput();

            try
            {
                output.GaikankensaKomokuMstKensakuDT = new SelectGaikankensaKomokuMstBySearchCondDataAccess().Execute(input).GaikankensaKomokuMstKensakuDT;
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
