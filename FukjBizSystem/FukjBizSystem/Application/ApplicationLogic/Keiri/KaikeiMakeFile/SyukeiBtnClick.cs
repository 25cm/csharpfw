using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiMakeFile;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.KaikeiMakeFile
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISyukeiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISyukeiBtnClickALInput : IBseALInput, IExecProcSuitoSyukeiStdBLInput
    {
        /// <summary>
        /// Execute proc UriageSyukeiStd ?
        /// </summary>
        bool RunUriageSyukeiStd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyukeiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SyukeiBtnClickALInput : ISyukeiBtnClickALInput
    {
        /// <summary>
        /// 対象区分
        /// </summary>
        public string TaishoKbn { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 対象日（開始）
        /// </summary>
        public string TaisyoFrom { get; set; }

        /// <summary>
        /// 対象日（終了）
        /// </summary>
        public string TaisyoTo { get; set; }

        /// <summary>
        /// 作成対象
        /// </summary>
        public string SakuseiTaisho { get; set; }

        /// <summary>
        /// 作成範囲
        /// </summary>
        public string SakuseiHani { get; set; }

        /// <summary>
        /// 和暦
        /// </summary>
        public string Wareki { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// 更新端末
        /// </summary>
        public string PcUpdate { get; set; }

        /// <summary>
        /// 会計採番No
        /// </summary>
        public string KaikeiSaibanNo { get; set; }

        /// <summary>
        /// Execute proc UriageSyukeiStd ?
        /// </summary>
        public bool RunUriageSyukeiStd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("対象区分[{0}], 支所コード[{1}], 対象日（開始）[{2}], 対象日（終了）[{3}], 作成対象[{4}], 作成範囲[{5}], 和暦[{6}], 更新者[{7}], 更新端末[{8}], 会計採番No[{9}]", 
                    new string[] { 
                        TaishoKbn,
                        ShishoCd,
                        TaisyoFrom,
                        TaisyoTo,
                        SakuseiTaisho,
                        SakuseiHani,
                        Wareki,
                        LoginUser,
                        PcUpdate,
                        KaikeiSaibanNo
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISyukeiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISyukeiBtnClickALOutput : IExecProcSuitoSyukeiStdBLOutput
    {
        /// <summary>
        /// UriageErrorFlg
        /// </summary>
        string UriageErrorFlg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyukeiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SyukeiBtnClickALOutput : ISyukeiBtnClickALOutput
    {
        /// <summary>
        /// UriageErrorFlg
        /// </summary>
        public string UriageErrorFlg { get; set; }

        /// <summary>
        /// ListResult (ErrorFlg & KaikeiSaibanNo)
        /// </summary>
        public List<string> ListResult { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SyukeiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SyukeiBtnClickApplicationLogic : BaseApplicationLogic<ISyukeiBtnClickALInput, ISyukeiBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KaikeiMakeFile：SyukeiBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SyukeiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SyukeiBtnClickApplicationLogic()
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
        /// 2014/11/11  DatNT　  新規作成
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
        /// 2014/11/11  DatNT　  新規作成
        /// 2014/12/08  kiyokuni　パラメータが間違っていたので修正、ロールバックが考慮されていなかったので追加
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISyukeiBtnClickALOutput Execute(ISyukeiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISyukeiBtnClickALOutput output = new SyukeiBtnClickALOutput();

            try
            {
                StartTransaction();

                if (input.RunUriageSyukeiStd)
                {
                    IExecProcUriageSyukeiStdBLInput uriageInput = new ExecProcUriageSyukeiStdBLInput();
                    //2014.12.08 Mod kiyokuni
                    uriageInput.UriageDtFrom = DateTime.ParseExact(input.TaisyoFrom, "yyyyMMdd", CultureInfo.InvariantCulture);
                    uriageInput.UriageDtTo = DateTime.ParseExact(input.TaisyoTo, "yyyyMMdd", CultureInfo.InvariantCulture).AddDays(1);//売上バッチに合わせて1日加算
                    ;
                    //uriageInput.UriageDtTo = today;
                    //uriageInput.UriageDtTo = today;
                    uriageInput.LoginUser = input.LoginUser;
                    uriageInput.Machine = input.PcUpdate;

                    output.UriageErrorFlg = new ExecProcUriageSyukeiStdBusinessLogic().Execute(uriageInput).ErrorFlg;

                    if (output.UriageErrorFlg == "0")
                    {
                        CompleteTransaction();
                    }
                }
                else
                {
                    output.ListResult = new ExecProcSuitoSyukeiStdBusinessLogic().Execute(input).ListResult;

                    if (output.ListResult[0] == "0")
                    {
                        CompleteTransaction();
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
