using System.Collections.Generic;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.SuishitsuKensaSetMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuKensaSetMstShosai
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
    /// 2014/07/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateSuishitsuKensaSetMstBLInput, IUpdateSetShikenKomokuMstBLInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        SuishitsuKensaSetMstShosaiForm.DispMode DispMode { get; set; }

        //20150128 HuyTX Ver1.02 Add
        /// <summary>
        /// DeletedRows 
        /// </summary>
        List<string> DeletedRows { get; set; }
        //End
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
    /// 2014/07/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        public SuishitsuKensaSetMstShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// SetShikenKomokuMstDataTable
        /// </summary>
        public SetShikenKomokuMstDataSet.SetShikenKomokuMstDataTable SetShikenKomokuMstDataTable { get; set; }

        /// <summary>
        /// SuishitsuKensaSetMstDataTable
        /// </summary>
        public SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable SuishitsuKensaSetMstDataTable { get; set; }

        //20150128 HuyTX Ver1.02 Add
        /// <summary>
        /// DeletedRows 
        /// </summary>
        public List<string> DeletedRows { get; set; }
        //End

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("セットコード[{0}]", SuishitsuKensaSetMstDataTable[0].SetCd);
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
    /// 2014/07/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput
    {
        /// <summary>
        /// Error messages
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
    /// 2014/07/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALOutput : IDecisionBtnClickALOutput
    {
        /// <summary>
        /// Error messages
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
    /// 2014/07/07　AnhNV　　    新規作成
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
        private const string FunctionName = "SuishitsuKensaSetMstShosai：DecisionBtnClick";

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
        /// 2014/07/07　AnhNV　　    新規作成
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
        /// 2014/07/07　AnhNV　　    新規作成
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
        /// 2014/07/07　AnhNV　　    新規作成
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

                // Exist check
                string errCheckMsg = CheckExistSetCd(input.SuishitsuKensaSetMstDataTable[0].SetCd);

                // 登録
                if (input.DispMode == SuishitsuKensaSetMstShosaiForm.DispMode.Add)
                {
                    // SetCd code has already registered
                    if (string.IsNullOrEmpty(errCheckMsg))
                    {
                        output.ErrMsg = string.Format("既に登録済みです。[セットコード：{0}]", input.SuishitsuKensaSetMstDataTable[0].SetCd);
                        return output;
                    }

                    new UpdateSuishitsuKensaSetMstBusinessLogic().Execute(input);
                    new UpdateSetShikenKomokuMstBusinessLogic().Execute(input);
                    output.ErrMsg = string.Empty;

                    // コミット
                    CompleteTransaction();

                    return output;
                }

                // 変更 - Key does not exist
                if (!string.IsNullOrEmpty(errCheckMsg))
                {
                    output.ErrMsg = errCheckMsg;
                    return output;
                }

                // 変更
                RakkanCheck(input);

                //20150128 HuyTX Ver1.02 Add Start
                //remove row is deleted on datagridview
                IDeleteSetShikenKomokuMstByKeyBLInput delSetShikenKomokuInput;
                foreach (string setKomokuCd in input.DeletedRows)
                {
                    if (input.SetShikenKomokuMstDataTable.Select(string.Format("SetKomokuSetCd = '{0}' AND SetKomokuCd = '{1}'", 
                        input.SuishitsuKensaSetMstDataTable[0].SetCd, setKomokuCd)).Length > 0) continue;

                    delSetShikenKomokuInput = new DeleteSetShikenKomokuMstByKeyBLInput();
                    delSetShikenKomokuInput.SetKomokuSetCd = input.SuishitsuKensaSetMstDataTable[0].SetCd;
                    delSetShikenKomokuInput.SetKomokuCd = setKomokuCd;
                    new DeleteSetShikenKomokuMstByKeyBusinessLogic().Execute(delSetShikenKomokuInput);
                }
                //End

                new UpdateSuishitsuKensaSetMstBusinessLogic().Execute(input);
                new UpdateSetShikenKomokuMstBusinessLogic().Execute(input);

                // コミット
                CompleteTransaction();
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

        #region CheckExistSetCd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckExistSetCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="SetCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string CheckExistSetCd(string setCd)
        {
            // Get ShishoMst by key
            IGetSuishitsuKensaSetMstByKeyBLInput keyInp = new GetSuishitsuKensaSetMstByKeyBLInput();
            keyInp.SetCd = setCd;
            IGetSuishitsuKensaSetMstByKeyBLOutput keyOutp = new GetSuishitsuKensaSetMstByKeyBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.SuishitsuKensaSetMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[セットコード：{0}]", setCd);
            }

            return string.Empty;
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
        /// 2014/07/07  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            IGetSuishitsuKensaSetMstByKeyBLInput checkInput = new GetSuishitsuKensaSetMstByKeyBLInput();
            checkInput.SetCd = input.SuishitsuKensaSetMstDataTable[0].SetCd;
            IGetSuishitsuKensaSetMstByKeyBLOutput checkOutput = new GetSuishitsuKensaSetMstByKeyBusinessLogic().Execute(checkInput);

            // 更新日が違うか？
            if (checkOutput.SuishitsuKensaSetMstDataTable[0].UpdateDt != input.SuishitsuKensaSetMstDataTable[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // 更新日
            input.SuishitsuKensaSetMstDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
        }
        #endregion

        #endregion
    }
    #endregion
}
