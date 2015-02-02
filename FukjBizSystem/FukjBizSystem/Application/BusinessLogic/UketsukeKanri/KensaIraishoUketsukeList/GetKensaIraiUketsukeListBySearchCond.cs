using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuIraiUketsukeWrk;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.KensaIraishoUketsukeList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiUketsukeListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiUketsukeListBySearchCondBLInput : ISelectKensaIraiUketsukeListBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiUketsukeListBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiUketsukeListBySearchCondBLInput : IGetKensaIraiUketsukeListBySearchCondBLInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string kensaKbn { get; set; }

        /// <summary>
        /// 支所コード（必須）
        /// </summary>
        public string shishoCd { get; set; }

        /// <summary>
        /// 受付番号（from）
        /// </summary>
        public string uketsukeNoFrom { get; set; }

        /// <summary>
        /// 受付番号（to）
        /// </summary>
        public string uketsukeNoTo { get; set; }

        /// <summary>
        /// 受付日（from）
        /// </summary>
        public DateTime? uketsukeDateFrom { get; set; }

        /// <summary>
        /// 受付日（to）
        /// </summary>
        public DateTime? uketsukeDateTo { get; set; }

        /// <summary>
        /// 出力済みを含めるか
        /// </summary>
        public bool includeOutput { get; set; }

        /// <summary>
        /// 出力日（from）
        /// </summary>
        public DateTime? outputDateFrom { get; set; }

        /// <summary>
        /// 出力日（to）
        /// </summary>
        public DateTime? outputDateTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiUketsukeListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiUketsukeListBySearchCondBLOutput : ISelectKensaIraiUketsukeListBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiUketsukeListBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiUketsukeListBySearchCondBLOutput : IGetKensaIraiUketsukeListBySearchCondBLOutput
    {
        /// <summary>
        /// KensaIraiUketsukeList
        /// </summary>
        public SuishitsuIraiUketsukeWrkDataSet.KensaIraiUketsukeListDataTable KensaIraiUketsukeList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiUketsukeListBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06　豊田        新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiUketsukeListBySearchCondBusinessLogic : BaseBusinessLogic<IGetKensaIraiUketsukeListBySearchCondBLInput, IGetKensaIraiUketsukeListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaIraiUketsukeListBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06　豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaIraiUketsukeListBySearchCondBusinessLogic()
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
        /// 2014/10/06　豊田        新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaIraiUketsukeListBySearchCondBLOutput Execute(IGetKensaIraiUketsukeListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaIraiUketsukeListBySearchCondBLOutput output = new GetKensaIraiUketsukeListBySearchCondBLOutput();

            try
            {
                ISelectKensaIraiUketsukeListBySearchCondDAOutput daOutput = new SelectKensaIraiUketsukeListBySearchCondDataAccess().Execute(input);
                output.KensaIraiUketsukeList = daOutput.KensaIraiUketsukeList;

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
