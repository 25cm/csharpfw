using System.Reflection;
using FukjBizSystem.Application.DataAccess.ZenkaiKensaDataWrk;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiListOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetZenkaiKensaDataWrkBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetZenkaiKensaDataWrkBySearchCondBLInput : ISelectZenkaiKensaDataWrkBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetZenkaiKensaDataWrkBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetZenkaiKensaDataWrkBySearchCondBLInput : IGetZenkaiKensaDataWrkBySearchCondBLInput
    {
        ///// <summary>
        ///// ChikuCdFrom
        ///// </summary>
        //public string ChikuCdFrom { get; set; }

        ///// <summary>
        ///// ChikuCdTo
        ///// </summary>
        //public string ChikuCdTo { get; set; }

        /// <summary>
        /// GyohsaCdFrom
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// Nendo
        /// </summary>
        public string Nendo { get; set; }

        ///// <summary>
        ///// ExistFlg
        ///// </summary>
        //public bool ExistFlg { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetZenkaiKensaDataWrkBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetZenkaiKensaDataWrkBySearchCondBLOutput : ISelectZenkaiKensaDataWrkBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetZenkaiKensaDataWrkBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetZenkaiKensaDataWrkBySearchCondBLOutput : IGetZenkaiKensaDataWrkBySearchCondBLOutput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        public ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable ZenkaiKensaDataWrkKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetZenkaiKensaDataWrkBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/25  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetZenkaiKensaDataWrkBySearchCondBusinessLogic : BaseBusinessLogic<IGetZenkaiKensaDataWrkBySearchCondBLInput, IGetZenkaiKensaDataWrkBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetZenkaiKensaDataWrkBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/25  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetZenkaiKensaDataWrkBySearchCondBusinessLogic()
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
        /// 2014/09/25  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetZenkaiKensaDataWrkBySearchCondBLOutput Execute(IGetZenkaiKensaDataWrkBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetZenkaiKensaDataWrkBySearchCondBLOutput output = new GetZenkaiKensaDataWrkBySearchCondBLOutput();

            try
            {
                output.ZenkaiKensaDataWrkKensakuDataTable = new SelectZenkaiKensaDataWrkBySearchCondDataAccess().Execute(input).ZenkaiKensaDataWrkKensakuDataTable;

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
