using System.Reflection;
using FukjBizSystem.Application.DataAccess.HoshoTorokuTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoshoTorokuTblBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoshoTorokuTblBySearchCondBLInput : ISelectHoshoTorokuTblBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoTorokuTblBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoTorokuTblBySearchCondBLInput : IGetHoshoTorokuTblBySearchCondBLInput
    {
        /// <summary>
        /// KenshakikanFrom
        /// </summary>
        public string KenshakikanFrom { get; set; }

        /// <summary>
        /// KenshakikanTo
        /// </summary>
        public string KenshakikanTo { get; set; }

        /// <summary>
        /// NendoFrom
        /// </summary>
        public string NendoFrom { get; set; }

        /// <summary>
        /// NendoTo 
        /// </summary>
        public string NendoTo { get; set; }

        /// <summary>
        /// RenbanFrom 
        /// </summary>
        public string RenbanFrom { get; set; }

        /// <summary>
        /// RenbanTo 
        /// </summary>
        public string RenbanTo { get; set; }

        /// <summary>
        /// KakuninDtFrom 
        /// </summary>
        public string KakuninDtFrom { get; set; }

        /// <summary>
        /// KakuninDtTo 
        /// </summary>
        public string KakuninDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoshoTorokuTblBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoshoTorokuTblBySearchCondBLOutput : ISelectHoshoTorokuTblBySearchCondDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoTorokuTblBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoTorokuTblBySearchCondBLOutput : IGetHoshoTorokuTblBySearchCondBLOutput
    {
        /// <summary>
        /// HoshoTorokuTblDT
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblKensakuDataTable HoshoTorokuTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoTorokuTblBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoTorokuTblBySearchCondBusinessLogic : BaseBusinessLogic<IGetHoshoTorokuTblBySearchCondBLInput, IGetHoshoTorokuTblBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetHoshoTorokuTblBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetHoshoTorokuTblBySearchCondBusinessLogic()
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
        /// 2014/07/17　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetHoshoTorokuTblBySearchCondBLOutput Execute(IGetHoshoTorokuTblBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetHoshoTorokuTblBySearchCondBLOutput output = new GetHoshoTorokuTblBySearchCondBLOutput();

            try
            {
                output.HoshoTorokuTblDT = new SelectHoshoTorokuTblBySearchCondDataAccess().Execute(input).HoshoTorokuTblDT;

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
