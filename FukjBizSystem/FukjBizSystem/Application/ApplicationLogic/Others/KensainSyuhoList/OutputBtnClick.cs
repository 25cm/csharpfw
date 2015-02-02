using System.Collections.Generic;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Others;
using FukjBizSystem.Application.BusinessLogic.Others.KensainSyuhoList;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.KensainSyuhoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutputBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// WeekList
        /// </summary>
        List<string> WeekList { get; set; }

        /// <summary>
        /// KensainSyuhoListDT
        /// </summary>
        KensainSyuhoListDataSet.KensainSyuhoListDataTable KensainSyuhoListDT { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickALInput : IOutputBtnClickALInput
    {
        /// <summary>
        /// WeekList
        /// </summary>
        public List<string> WeekList { get; set; }

        /// <summary>
        /// KensainSyuhoListDT
        /// </summary>
        public KensainSyuhoListDataSet.KensainSyuhoListDataTable KensainSyuhoListDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("WeekList[{0}]", WeekList[0]);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutputBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickALOutput : IOutputBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/04  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickApplicationLogic : BaseApplicationLogic<IOutputBtnClickALInput, IOutputBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensainSyuhoList：OutputBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： OutputBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/04  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public OutputBtnClickApplicationLogic()
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
        /// 2014/09/04  HuyTX　　    新規作成
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
        /// 2014/09/04  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IOutputBtnClickALOutput Execute(IOutputBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IOutputBtnClickALOutput output = new OutputBtnClickALOutput();

            try
            {
                IPrintKensainbetsuKensaJicchisuuListBLInput blInput = new PrintKensainbetsuKensaJicchisuuListBLInput();
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KensainbetsuKensaJicchisuuListFormatFile;
                blInput.AfterDispFlg = true;

                blInput.KensainSyuhoListDT = input.KensainSyuhoListDT;
                blInput.WeekList = input.WeekList;

                new PrintKensainbetsuKensaJicchisuuListBusinessLogic().Execute(blInput);

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
