using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KeiryoShomeiOutputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKeiryoShomeiOutputListByCondBLInput
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
    interface IGetKeiryoShomeiOutputListByCondBLInput : ISelectKeiryoShomeiOutputListByCondDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiOutputListByCondBLInput
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
    class GetKeiryoShomeiOutputListByCondBLInput : IGetKeiryoShomeiOutputListByCondBLInput
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
        /// 設置者
        /// </summary>
        public string Settisha { get; set; }
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
        /// <summary>
        /// ChouhyouKubunFlg
        /// </summary>
        public string ChouhyouKubunFlg { get; set; }
        // 20150201 sou Start
        /// <summary>
        /// 表示順
        /// </summary>
        public string DispOrder { get; set; }
        // 20150201 sou End
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
    interface IGetKeiryoShomeiOutputListByCondBLOutput : ISelectKeiryoShomeiOutputListByCondDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiOutputListByCondBLOutput
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
    class GetKeiryoShomeiOutputListByCondBLOutput : IGetKeiryoShomeiOutputListByCondBLOutput
    {
        /// <summary>
        /// KeiryoShomeiOutputListDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable KeiryoShomeiOutputListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiOutputListByCondBusinessLogic
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
    class GetKeiryoShomeiOutputListByCondBusinessLogic : BaseBusinessLogic<IGetKeiryoShomeiOutputListByCondBLInput, IGetKeiryoShomeiOutputListByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKeiryoShomeiOutputListByCondBusinessLogic
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
        public GetKeiryoShomeiOutputListByCondBusinessLogic()
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
        public override IGetKeiryoShomeiOutputListByCondBLOutput Execute(IGetKeiryoShomeiOutputListByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKeiryoShomeiOutputListByCondBLOutput output = new GetKeiryoShomeiOutputListByCondBLOutput();

            try
            {
                output.KeiryoShomeiOutputListDataTable = new SelectKeiryoShomeiOutputListByCondDataAccess().Execute(input).KeiryoShomeiOutputListDataTable;
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
