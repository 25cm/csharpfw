using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.ShoriHoshikiMstShosai;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using System.Text;

namespace FukjBizSystem.Application.ApplicationLogic.Master.ShoriHoshikiMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALInput : IBseALInput, IDeleteShoriHoshikiMstByKeyBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALInput : IDeleteBtnClickALInput
    {
        /// <summary>
        /// 処理方式区分
        /// </summary>
        public String ShoriHoshikiKbn { get; set; }

        /// <summary>
        /// 処理方式コード
        /// </summary>
        public String ShoriHoshikiCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("処理方式区分[{0}], 処理方式コード[{1}]",
                    new string[]{
                        ShoriHoshikiKbn,
                        ShoriHoshikiCd
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALOutput : IDeleteShoriHoshikiMstByKeyBLOutput
    {
        //20150128 HuyTX Mod Start
        ///// <summary>
        ///// Result delete
        ///// </summary>
        //bool Result { get; set; }

        /// <summary>
        /// ErrorMessage 
        /// </summary>
        string ErrorMessage { get; set; }
        //20150128 HuyTX Mod End
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
    {
        //20150128 HuyTX Ver1.02 Mod Start
        ///// <summary>
        ///// Result delete
        ///// </summary>
        //public bool Result { get; set; }

        /// <summary>
        /// ErrorMessage 
        /// </summary>
        public string ErrorMessage { get; set; }
        //20150128 HuyTX Ver1.02 Mod End
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "ShoriHoshikiMstShosai：DeleteBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteBtnClickApplicationLogic()
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
        /// 2014/07/01  DatNT　　    新規作成
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
        /// 2014/07/01  DatNT　　    新規作成
        /// 2015/01/28  HuyTX　　    Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteBtnClickALOutput Execute(IDeleteBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnClickALOutput output = new DeleteBtnClickALOutput();

            try
            {
                StartTransaction();

                IGetShoriHoshikiMstByKeyBLInput blInput     = new GetShoriHoshikiMstByKeyBLInput();
                blInput.ShoriHoshikiKbn                     = input.ShoriHoshikiKbn;
                blInput.ShoriHoshikiCd                      = input.ShoriHoshikiCd;
                IGetShoriHoshikiMstByKeyBLOutput blOutput   = new GetShoriHoshikiMstByKeyBusinessLogic().Execute(blInput);

                //Ver1.02 Mod Start
                //if (blOutput.ShoriHoshikiMstDT != null && blOutput.ShoriHoshikiMstDT.Count > 0)
                //{
                //    new DeleteShoriHoshikiMstByKeyBusinessLogic().Execute(input);

                //    output.Result = true;
                //}
                //else
                //{
                //    output.Result = false;
                //}
                StringBuilder errMsg = new StringBuilder();
                IGetShoriHoshikiSuishitsuKensaJisshiByCondBLInput getSuiKensaJisshiInput = new GetShoriHoshikiSuishitsuKensaJisshiByCondBLInput();
                getSuiKensaJisshiInput.ShoriHoshikiKbn = input.ShoriHoshikiKbn;
                getSuiKensaJisshiInput.ShoriHoshikiCd = input.ShoriHoshikiCd;
                IGetShoriHoshikiSuishitsuKensaJisshiByCondBLOutput getSuiKensaJisshiOutput = new GetShoriHoshikiSuishitsuKensaJisshiByCondBusinessLogic().Execute(getSuiKensaJisshiInput);

                if (blOutput.ShoriHoshikiMstDT == null || blOutput.ShoriHoshikiMstDT.Count == 0)
                {
                    errMsg.AppendLine(string.Format("該当するデータは登録されていません。[処理方式マスタ][処理方式区分：{0}、処理方式コード：{1}]",
                            new string[] { input.ShoriHoshikiKbn, input.ShoriHoshikiCd}));
                }

                if (getSuiKensaJisshiOutput.ShoriHoshikiSuishitsuKensaJisshiListDataTable == null
                    || getSuiKensaJisshiOutput.ShoriHoshikiSuishitsuKensaJisshiListDataTable.Count == 0)
                {
                    errMsg.AppendLine(string.Format("該当するデータは登録されていません。[処理方式別水質検査実施マスタ][処理方式区分：{0}、処理方式コード：{1}]",
                            new string[] { input.ShoriHoshikiKbn, input.ShoriHoshikiCd }));
                }

                if (!string.IsNullOrEmpty(errMsg.ToString()))
                {
                    output.ErrorMessage = errMsg.ToString();
                    return output;
                }

                //delete ShoriHoshikiMst
                new DeleteShoriHoshikiMstByKeyBusinessLogic().Execute(input);

                //delete ShoriHoshikiSuishitsuKensaJisshiMst
                IDeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput delInput = new DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBLInput();
                delInput.ShoriHoshikiKbn = input.ShoriHoshikiKbn;
                delInput.ShoriHoshikiCd = input.ShoriHoshikiCd;
                new DeleteShoriHoshikiSuishitsuKensaJisshiMstByShoriHoshikiBusinessLogic().Execute(delInput);
                //Ver1.02 Mod End

                CompleteTransaction();
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
