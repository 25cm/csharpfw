using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zynas.Framework.Core.Base.ApplicationLogic;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KeiryoShomeiOutputList;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KeiryoShomeiOutputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        #region プロパティ

        /// <summary>
        /// 支所
        /// </summary>
        string ShishoCd { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }
        /// <summary>
        /// 設置者
        /// </summary>
        string Settisha { get; set; }
        /// <summary>
        /// 水検No (開始)
        /// </summary>
        string SuikenNoFrom { get; set; }
        /// <summary>
        /// 水検No (終了)
        /// </summary>
        string SuikenNoTo { get; set; }
        /// <summary>
        /// 受付日（開始）
        /// </summary>
        string UketsukeDtFrom { get; set; }
        /// <summary>
        /// 受付日（終了）
        /// </summary>
        string UketsukeDtTo { get; set; }
        /// <summary>
        /// ChouhyouKubunFlg
        /// </summary>
        string ChouhyouKubunFlg { get; set; }
        // 20150201 sou Start
        /// <summary>
        /// 表示順
        /// </summary>
        string DispOrder { get; set; }
        // 20150201 sou End

        #endregion
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        #region プロパティ
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

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("ShishoCd[{0}], Nendo[{1}], SuikenNoFrom[{2}], SuikenNoTo[{3}], UketsukeDtFrom[{4}], UketsukeDtTo[{5}], Settisha[{6}], ChouhyouKubunFlg[{7}]",
                                        ShishoCd, Nendo, SuikenNoFrom, SuikenNoTo, UketsukeDtFrom, UketsukeDtTo, Settisha, ChouhyouKubunFlg);
            }
        }

        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KeiryoShomeiOutputListDataTable
        /// </summary>
        KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable KeiryoShomeiOutputListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
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
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KeiryoShomeiOutputListDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable KeiryoShomeiOutputListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
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
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KeiryoShomeiOutputList：KensakuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
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
        public KensakuBtnClickApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();
            try
            {
                IGetKeiryoShomeiOutputListByCondBLInput blInput = new GetKeiryoShomeiOutputListByCondBLInput();
                blInput.Nendo = input.Nendo;
                blInput.ShishoCd = input.ShishoCd;
                blInput.SuikenNoFrom = input.SuikenNoFrom;
                blInput.SuikenNoTo = input.SuikenNoTo;
                blInput.UketsukeDtFrom = input.UketsukeDtFrom;
                blInput.UketsukeDtTo = input.UketsukeDtTo;
                blInput.Settisha = input.Settisha;
                blInput.ChouhyouKubunFlg = input.ChouhyouKubunFlg;
                blInput.DispOrder = input.DispOrder;
                output.KeiryoShomeiOutputListDataTable = new GetKeiryoShomeiOutputListByCondBusinessLogic().Execute(blInput).KeiryoShomeiOutputListDataTable;
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
