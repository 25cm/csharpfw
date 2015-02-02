using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.GaichuKensaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGenkinNyukinFormLoad1ByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGaichuKensaListTblByCondBLInput : ISelectGaichuKensaListTblByCondDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGenkinNyukinFormLoad1ByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGaichuKensaListTblByCondBLInput : IGetGaichuKensaListTblByCondBLInput
    {
        /// <summary>
        /// 支所
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }
        /// <summary>
        /// 水検No (開始)
        /// </summary>
        public string SuikenNoFrom { get; set; }
        /// <summary>
        /// 水検No (終了)
        /// </summary>
        public string SuikenNoTo { get; set; }
        /// <summary>
        /// 受付日（開始）
        /// </summary>
        public string UketsukeDtFrom { get; set; }
        /// <summary>
        /// 受付日（終了）
        /// </summary>
        public string UketsukeDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGenkinNyukinKbnOneByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGaichuKensaListTblByCondBLOutput : ISelectGaichuKensaListTblByCondDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGenkinNyukinKbnOneByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGaichuKensaListTblByCondBLOutput : IGetGaichuKensaListTblByCondBLOutput
    {
        /// <summary>
        /// GaichuKensaListDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.GaichuKensaListDataTable GaichuKensaListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGenkinNyukinKbnOneByCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGaichuKensaListTblByCondBusinessLogic : BaseBusinessLogic<IGetGaichuKensaListTblByCondBLInput, IGetGaichuKensaListTblByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetGenkinNyukinKbnOneByCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetGaichuKensaListTblByCondBusinessLogic()
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
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetGaichuKensaListTblByCondBLOutput Execute(IGetGaichuKensaListTblByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetGaichuKensaListTblByCondBLOutput output = new GetGaichuKensaListTblByCondBLOutput();

            try
            {
                output.GaichuKensaListDataTable = new SelectGaichuKensaListTblByCondDataAccess().Execute(input).GaichuKensaListDataTable;
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
