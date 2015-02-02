using System;
using System.Collections.Generic;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.NyukinList;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.NyukinList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IIkkatsuSeikyuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IIkkatsuSeikyuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 入金日検索使用フラグ
        /// </summary>
        bool IsNyukinDtUse { get; set; }

        /// <summary>
        /// 入金No(s)
        /// </summary>
        List<string> NyukinNoList { get; set; }

        /// <summary>
        /// 入金日（開始）
        /// </summary>
        DateTime NyukinDtFrom { get; set; }

        /// <summary>
        /// 入金日（終了）
        /// </summary>
        DateTime NyukinDtTo { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IkkatsuSeikyuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IkkatsuSeikyuBtnClickALInput : IIkkatsuSeikyuBtnClickALInput
    {
        /// <summary>
        /// 入金日検索使用フラグ
        /// </summary>
        public bool IsNyukinDtUse { get; set; }

        /// <summary>
        /// 入金No(s)
        /// </summary>
        public List<string> NyukinNoList { get; set; }

        /// <summary>
        /// 入金日（開始）
        /// </summary>
        public DateTime NyukinDtFrom { get; set; }

        /// <summary>
        /// 入金日（終了）
        /// </summary>
        public DateTime NyukinDtTo { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("入金No[{0}], 入金日（開始）[{1}], 入金日（終了）[{2}], システム日付[{3}]",
                    NyukinNoList[0], NyukinDtFrom, NyukinDtTo, SystemDt);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IIkkatsuSeikyuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IIkkatsuSeikyuBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IkkatsuSeikyuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IkkatsuSeikyuBtnClickALOutput : IIkkatsuSeikyuBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IkkatsuSeikyuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IkkatsuSeikyuBtnClickApplicationLogic : BaseApplicationLogic<IIkkatsuSeikyuBtnClickALInput, IIkkatsuSeikyuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "NyukinList：IkkatsuSeikyuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： IkkatsuSeikyuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public IkkatsuSeikyuBtnClickApplicationLogic()
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
        /// 2014/09/15　AnhNV　　    新規作成
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
        /// 2014/09/15　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IIkkatsuSeikyuBtnClickALOutput Execute(IIkkatsuSeikyuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IIkkatsuSeikyuBtnClickALOutput output = new IkkatsuSeikyuBtnClickALOutput();

            try
            {
                IPrintNyukinUchiwakeBLInput blInput = new PrintNyukinUchiwakeBLInput();
                blInput.AfterDispFlg = true;
                //blInput.AfterPrintFlg = true;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.NyukinUchiwakeFormatFile;
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                // 2014/12/16 AnhNV ADD Start
                blInput.IsNyukinDtUse = input.IsNyukinDtUse;
                // 2014/12/16 AnhNV ADD End
                blInput.NyukinNoList = input.NyukinNoList;
                blInput.NyukinDtFrom = input.NyukinDtFrom;
                blInput.NyukinDtTo = input.NyukinDtTo;
                blInput.SystemDt = input.SystemDt;
                new PrintNyukinUchiwakeBusinessLogic().Execute(blInput);
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
