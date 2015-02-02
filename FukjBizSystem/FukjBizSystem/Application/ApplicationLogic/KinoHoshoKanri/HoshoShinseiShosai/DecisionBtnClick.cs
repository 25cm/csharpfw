using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.KinoHoshoKanri;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoNoPrint;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiShosai;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoShinseiShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18　AnhNV　　    新規作成
    /// 2015/01/20　AnhNV　　    v1.03
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateHoshoTorokuTblBLInput, IUpdateJokasoMstBLInput
    {
        /// <summary>
        /// システム日
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// 表示モード
        /// </summary>
        HoshoShinseiShosaiForm.DispMode DispMode { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18　AnhNV　　    新規作成
    /// 2015/01/20　AnhNV　　    v1.03
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// システム日
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// 表示モード
        /// </summary>
        public HoshoShinseiShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// 保証登録テーブル
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDT { get; set; }

        /// <summary>
        /// 浄化槽マスタ
        /// </summary>
        public JokasoMstDataSet.JokasoMstDataTable JokasoMstDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("保証登録検査機関[{0}], 保証登録年度[{1}], 保証登録連番[{2}]",
                    new string[] { HoshoTorokuTblDT[0].HoshoTorokuKensakikan, HoshoTorokuTblDT[0].HoshoTorokuNendo, HoshoTorokuTblDT[0].HoshoTorokuRenban });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput
    {
        /// <summary>
        /// Error message for update
        /// </summary>
        string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALOutput : IDecisionBtnClickALOutput
    {
        /// <summary>
        /// Error message for update
        /// </summary>
        public string ErrMsg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18　AnhNV　　    新規作成
    /// 2015/01/20　AnhNV　　    v1.03
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickApplicationLogic : BaseApplicationLogic<IDecisionBtnClickALInput, IDecisionBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HoshoShinseiShosai：DecisionBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DecisionBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DecisionBtnClickApplicationLogic()
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
        /// 2014/07/18　AnhNV　　    新規作成
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
        /// 2014/07/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                // Message check
                string errMsg = string.Empty;

                if (input.DispMode == HoshoShinseiShosaiForm.DispMode.Edit)
                {
                    // Logical delete check
                    errMsg = LogicDeleteCheck(input);
                }

                if (string.IsNullOrEmpty(errMsg))
                {
                    // Check key exist or not
                    errMsg = ExistCheck(input);

                    // Key does not exist
                    if (string.IsNullOrEmpty(errMsg))
                    {
                        // 変更
                        RakkanCheck(input);
                        new UpdateHoshoTorokuTblBusinessLogic().Execute(input);

                        // v1.03 Update JokasoMst
                        if (input.DispMode == HoshoShinseiShosaiForm.DispMode.Edit)
                        {
                            new UpdateJokasoMstBusinessLogic().Execute(input);
                        }

                        // コミット
                        CompleteTransaction();
                    }
                    else
                    {
                        // Output message
                        output.ErrMsg = errMsg;
                    }
                }
                else
                {
                    output.ErrMsg = errMsg;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                // トランザクション終了
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region ExistCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ExistCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string ExistCheck(IDecisionBtnClickALInput input)
        {
            // Message check
            string errMsg = string.Empty;

            // Get HoshoTorokuTbl by key
            IGetHoshoTorokuTblByKeyBLInput blInput = new GetHoshoTorokuTblByKeyBLInput();
            blInput.HoshoTorokuKensakikan = input.HoshoTorokuTblDT[0].HoshoTorokuKensakikan;
            blInput.HoshoTorokuNendo = input.HoshoTorokuTblDT[0].HoshoTorokuNendo;
            blInput.HoshoTorokuRenban = input.HoshoTorokuTblDT[0].HoshoTorokuRenban;
            IGetHoshoTorokuTblByKeyBLOutput blOutput = new GetHoshoTorokuTblByKeyBusinessLogic().Execute(blInput);

            // No record was found
            if (blOutput.HoshoTorokuTblDataTable.Count == 0)
            {
                errMsg = string.Format("該当するデータは登録されていません。[保証登録番号：{0}-{1}-{2}]",
                    input.HoshoTorokuTblDT[0].HoshoTorokuKensakikan,
                    // 20140811 habu Aggregated Hoshou Toroku No Convertion To Common Utility
                    //Boundary.Common.Common.ConvertToHoshouNendoWareki(input.HoshoTorokuTblDT[0].HoshoTorokuNendo),
                    //Utility.Utility.ConvertToHeisei(Convert.ToInt32(input.HoshoTorokuTblDT[0].HoshoTorokuNendo)),
                    // 20140811 habu End
                    Utility.DateUtility.ConvertToWareki(input.HoshoTorokuTblDT[0].HoshoTorokuNendo, "yy"),
                    input.HoshoTorokuTblDT[0].HoshoTorokuRenban);
            }

            return errMsg;
        }
        #endregion

        #region RakkanCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RakkanCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            // Get HoshoTorokuTbl by key
            IGetHoshoTorokuTblByKeyBLInput blInput = new GetHoshoTorokuTblByKeyBLInput();
            blInput.HoshoTorokuKensakikan = input.HoshoTorokuTblDT[0].HoshoTorokuKensakikan;
            blInput.HoshoTorokuNendo = input.HoshoTorokuTblDT[0].HoshoTorokuNendo;
            blInput.HoshoTorokuRenban = input.HoshoTorokuTblDT[0].HoshoTorokuRenban;
            IGetHoshoTorokuTblByKeyBLOutput blOutput = new GetHoshoTorokuTblByKeyBusinessLogic().Execute(blInput);

            // 更新日が違うか？
            if (blOutput.HoshoTorokuTblDataTable[0].UpdateDt != input.HoshoTorokuTblDT[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // 更新日
            input.HoshoTorokuTblDT[0].UpdateDt = input.SystemDt;
        }
        #endregion

        #region LogicDeleteCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： LogicDeleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/21  AnhNV　　    新規作成
        /// 2015/01/29  AnhNV　　    v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string LogicDeleteCheck(IDecisionBtnClickALInput input)
        {
            string errMsg = string.Empty;

            // Get HoshoTorokuTbl info
            IGetHoshoTorokuTblInfoBLOutput blOutput = new GetHoshoTorokuTblInfoBusinessLogic().Execute(new GetHoshoTorokuTblInfoBLInput());

            string filter = string.Format("HoshoTorokuKensakikan <> '{0}' and HoshoTorokuNendo <> '{1}' and HoshoTorokuRenban <> '{2}' and HoshoTorokuJokasoTorokuNo = '{3}' and HoshoTorokuDeleteFlg = 0",
                input.HoshoTorokuTblDT[0].HoshoTorokuKensakikan,
                input.HoshoTorokuTblDT[0].HoshoTorokuNendo,
                input.HoshoTorokuTblDT[0].HoshoTorokuRenban,
                input.HoshoTorokuTblDT[0].HoshoTorokuJokasoTorokuNo);

            HoshoTorokuTblDataSet.HoshoTorokuTblRow[] hoshoRow = (HoshoTorokuTblDataSet.HoshoTorokuTblRow[])blOutput.HoshoTorokuTblDataTable.Select(filter);

            // Exist?
            if (hoshoRow.Length > 0)
            {
                errMsg = string.Format("入力された浄化槽登録番号は既に以下の保障登録番号で登録されています。[{0}]",
                    string.Concat(input.HoshoTorokuTblDT[0].HoshoTorokuKensakikan, "-",
                    // v1.04 Convert nendo to wareki
                    Utility.DateUtility.ConvertToWareki(input.HoshoTorokuTblDT[0].HoshoTorokuNendo, "yy"), "-",
                    input.HoshoTorokuTblDT[0].HoshoTorokuRenban));
            }

            return errMsg;
        }
        #endregion

        #endregion
    }
    #endregion
}
