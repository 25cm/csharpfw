using System.Reflection;
using FukjBizSystem.Application.Boundary.SaisuiinKanri;
using FukjBizSystem.Application.BusinessLogic.Master.SaisuiinMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SaisuiinKanri.SaisuiinInfoShosai
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
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateSaisuiinMstBLInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        SaisuiinInfoShosaiForm.DispMode DispMode { get; set; }
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
    /// 2014/07/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        public SaisuiinInfoShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// 採水員マスタ
        /// </summary>
        public SaisuiinMstDataSet.SaisuiinMstDataTable SaisuiinMstDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("採水員コード[{0}]", SaisuiinMstDataTable[0].SaisuiinCd);
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
    /// 2014/07/29　AnhNV　　    新規作成
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
    /// 2014/07/29　AnhNV　　    新規作成
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
    /// 2014/07/29　AnhNV　　    新規作成
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
        private const string FunctionName = "SaisuiinInfoShosai：DecisionBtnClick";

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
        /// 2014/07/29　AnhNV　　    新規作成
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
        /// 2014/07/29　AnhNV　　    新規作成
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
        /// 2014/07/29　AnhNV　　    新規作成
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
                string errMsg = CheckExistSaisuiinCd(input.SaisuiinMstDataTable[0].SaisuiinCd);

                // 登録
                if (input.DispMode == SaisuiinInfoShosaiForm.DispMode.Add)
                {
                    if (string.IsNullOrEmpty(errMsg))
                    {
                        output.ErrMsg = string.Format("既に採水員マスタに登録済みです。[採水員コード：{0}]", input.SaisuiinMstDataTable[0].SaisuiinCd);
                        return output;
                    }

                    new UpdateSaisuiinMstBusinessLogic().Execute(input);
                    output.ErrMsg = string.Empty;

                    // コミット
                    CompleteTransaction();

                    return output;
                }

                // 変更 - Key does not exist
                if (!string.IsNullOrEmpty(errMsg))
                {
                    output.ErrMsg = errMsg;
                    return output;
                }

                // 変更
                RakkanCheck(input);
                new UpdateSaisuiinMstBusinessLogic().Execute(input);

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

        #region CheckExistSaisuiinCd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckExistSaisuiinCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="saisuiinCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string CheckExistSaisuiinCd(string saisuiinCd)
        {
            // Get saisuiinMst by key
            IGetSaisuiinMstByKeyBLInput keyInp = new GetSaisuiinMstByKeyBLInput();
            keyInp.SaisuiinCd = saisuiinCd;
            IGetSaisuiinMstByKeyBLOutput keyOutp = new GetSaisuiinMstByKeyBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.SaisuiinMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは採水員マスタに登録されていません。[採水員コード：{0}]", saisuiinCd);
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
        /// 2014/07/29  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            IGetSaisuiinMstByKeyBLInput checkInput = new GetSaisuiinMstByKeyBLInput();
            checkInput.SaisuiinCd = input.SaisuiinMstDataTable[0].SaisuiinCd;
            IGetSaisuiinMstByKeyBLOutput checkOutput = new GetSaisuiinMstByKeyBusinessLogic().Execute(checkInput);

            // 更新日が違うか？
            if (checkOutput.SaisuiinMstDataTable[0].UpdateDt != input.SaisuiinMstDataTable[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // 更新日
            input.SaisuiinMstDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
        }
        #endregion

        #endregion
    }
    #endregion
}
