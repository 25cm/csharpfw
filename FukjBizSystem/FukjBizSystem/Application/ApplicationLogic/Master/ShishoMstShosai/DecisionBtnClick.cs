using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.ShishoMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.ShishoMstShosai
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
    /// 2014/06/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateShishoMstBLInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        ShishoMstShosaiForm.DispMode DispMode {get;set;}
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
    /// 2014/06/26　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        public ShishoMstShosaiForm.DispMode DispMode {get;set;}

        /// <summary>
        /// ShishoMstDataTable
        /// </summary>
        public ShishoMstDataSet.ShishoMstDataTable ShishoMstDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所コード[{0}]", ShishoMstDataTable[0].ShishoCd);
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
    /// 2014/06/26　AnhNV　　    新規作成
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
    /// 2014/06/26　AnhNV　　    新規作成
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
    /// 2014/06/26　AnhNV　　    新規作成
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
        private const string FunctionName = "ShishoMstShosai：DecisionBtnClick";

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
        /// 2014/06/26　AnhNV　　    新規作成
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
        /// 2014/06/26　AnhNV　　    新規作成
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
        /// 2014/06/26　AnhNV　　    新規作成
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

                // Generate a key for insert
                if (input.DispMode == ShishoMstShosaiForm.DispMode.Add
                    && input.ShishoMstDataTable[0].ShishoCd == " ")
                {
                    KeyGenerate(input);
                }

                // Exist check
                string errCheckMsg = CheckExistShishoCd(input.ShishoMstDataTable[0].ShishoCd);

                // 登録
                if (input.DispMode == ShishoMstShosaiForm.DispMode.Add)
                {
                    // Shisho code has already registered
                    if (string.IsNullOrEmpty(errCheckMsg))
                    {
                        output.ErrMsg = string.Format("既に登録済みです。[支所コード：{0}]", input.ShishoMstDataTable[0].ShishoCd);
                        return output;
                    }

                    new UpdateShishoMstBusinessLogic().Execute(input);
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
                new UpdateShishoMstBusinessLogic().Execute(input);

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

        #region KeyGenerate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KeyGenerate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void KeyGenerate(IDecisionBtnClickALInput input)
        {
            // Get shishomst by key
            IGetShishoMstByKeyBLInput blInput = new GetShishoMstByKeyBLInput();
            for (int i = 1; i <= 9; i++)
            {
                blInput.ShishoCd = i.ToString();
                IGetShishoMstByKeyBLOutput blOutput = new GetShishoMstByKeyBusinessLogic().Execute(blInput);
                if (blOutput.ShishoMstDataTable.Count == 0)
                {
                    input.ShishoMstDataTable[0].ShishoCd = i.ToString();
                    break;
                }
            }

            // All keys have been used!
            if (input.ShishoMstDataTable[0].ShishoCd == " ")
            {
                input.ShishoMstDataTable[0].ShishoCd = "9";
            }
        }
        #endregion

        #region CheckExistShishoCd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckExistShishoCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string CheckExistShishoCd(string shishoCd)
        {
            // Get ShishoMst by key
            IGetShishoMstByKeyBLInput keyInp = new GetShishoMstByKeyBLInput();
            keyInp.ShishoCd = shishoCd;
            IGetShishoMstByKeyBLOutput keyOutp = new GetShishoMstByKeyBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.ShishoMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[支所コード：{0}]", shishoCd);
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
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            IGetShishoMstByKeyBLInput checkInput = new GetShishoMstByKeyBLInput();
            checkInput.ShishoCd = input.ShishoMstDataTable[0].ShishoCd;
            IGetShishoMstByKeyBLOutput checkOutput = new GetShishoMstByKeyBusinessLogic().Execute(checkInput);

            // 更新日が違うか？
            if (checkOutput.ShishoMstDataTable[0].UpdateDt != input.ShishoMstDataTable[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // 更新日
            input.ShishoMstDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();

            // 更新者
            input.ShishoMstDataTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 更新端末
            input.ShishoMstDataTable[0].UpdateTarm = Dns.GetHostName();
        }
        #endregion

        #endregion
    }
    #endregion
}
