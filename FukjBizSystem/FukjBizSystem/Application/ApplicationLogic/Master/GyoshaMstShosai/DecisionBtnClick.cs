using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.GyoshaMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.GyoshaMstShosai
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateGyoshaMstBLInput,
        IUpdateGyoshaEigyoshoMstBLInput, IUpdateGyoshaEigyoChikuMstBLInput, IUpdateGyoshaBukaiMstBLInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        GyoshaMstShosaiForm.DispMode DispMode { get; set; }
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        public GyoshaMstShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// 業者マスタ
        /// </summary>
        public GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDataTable { get; set; }

        /// <summary>
        /// 業者営業所マスタ
        /// </summary>
        public GyoshaEigyoshoMstDataSet.GyoshaEigyoshoMstDataTable GyoshaEigyoshoMstDataTable { get; set; }

        /// <summary>
        /// 業者営業地区マスタ
        /// </summary>
        public GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstDataTable GyoshaEigyoChikuMstDataTable { get; set; }

        /// <summary>
        /// 業者部会マスタ
        /// </summary>
        public GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable GyoshaBukaiMstDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("業者コード[{0}]", GyoshaMstDataTable[0].GyoshaCd);
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
    /// 2014/07/02　AnhNV　　    新規作成
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
    /// 2014/07/02　AnhNV　　    新規作成
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
    /// 2014/07/02　AnhNV　　    新規作成
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
        private const string FunctionName = "GyoshaMstShosai：DecisionBtnClick";

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
        /// 2014/07/02　AnhNV　　    新規作成
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
        /// 2014/07/02　AnhNV　　    新規作成
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
        /// 2014/07/02　AnhNV　　    新規作成
        /// 2014/10/15　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
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

                // 業者コード
                string gyoshaCd = input.GyoshaMstDataTable[0].GyoshaCd;

                // Exist check
                string errMsg = string.Empty;

                #region 登録

                if (input.DispMode == GyoshaMstShosaiForm.DispMode.Add)
                {
                    // Check exist for add mode
                    errMsg = AddModeCheck(gyoshaCd);

                    if (!string.IsNullOrEmpty(errMsg))
                    {
                        output.ErrMsg = errMsg;
                        return output;
                    }

                    // 登録
                    new UpdateGyoshaMstBusinessLogic().Execute(input);
                    new UpdateGyoshaEigyoshoMstBusinessLogic().Execute(input);
                    new UpdateGyoshaEigyoChikuMstBusinessLogic().Execute(input);
                    new UpdateGyoshaBukaiMstBusinessLogic().Execute(input);

                    // コミット
                    CompleteTransaction();

                    return output;
                }

                #endregion

                #region 変更

                errMsg = GyoshaMstCheck(gyoshaCd);

                // 変更 - Key does not exist
                if (!string.IsNullOrEmpty(errMsg))
                {
                    output.ErrMsg = errMsg;
                    return output;
                }

                // 変更
                RakkanCheck(input);
                new UpdateGyoshaMstBusinessLogic().Execute(input);
                new UpdateGyoshaEigyoshoMstBusinessLogic().Execute(input);
                new UpdateGyoshaEigyoChikuMstBusinessLogic().Execute(input);
                //new UpdateGyoshaBukaiMstBusinessLogic().Execute(input);

                // コミット
                CompleteTransaction();

                #endregion
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

        #region AddModeCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： AddModeCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  AnhNV　　    新規作成
        /// 2014/10/20　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string AddModeCheck(string gyoshaCd)
        {
            // Message check
            string errMsg = string.Empty;
            string gyoshaErrMsg = GyoshaMstCheck(gyoshaCd);
            string eigyoErrMsg = GyoshaEigyoshoMstCheck(gyoshaCd);
            string chikuErrMsg = GyoshaEigyoChikuMstCheck(gyoshaCd);
            string bukaiErrMsg = GyoshaBukaiMstCheck(gyoshaCd);

            if (string.IsNullOrEmpty(gyoshaErrMsg))
            {
                errMsg += string.Format("既に登録済みです。[業者マスタ][業者コード：{0}]", gyoshaCd);
            }

            if (string.IsNullOrEmpty(eigyoErrMsg))
            {
                errMsg += Environment.NewLine + string.Format("既に登録済みです。[業者営業所マスタ][業者コード：{0}]", gyoshaCd);
            }

            if (string.IsNullOrEmpty(chikuErrMsg))
            {
                errMsg += Environment.NewLine + string.Format("既に登録済みです。[業者営業地区マスタ][業者コード：{0}]", gyoshaCd);
            }

            if (string.IsNullOrEmpty(bukaiErrMsg))
            {
                errMsg += Environment.NewLine + string.Format("既に登録済みです。[業者部会マスタ][業者コード：{0}]", gyoshaCd);
            }

            return string.IsNullOrEmpty(errMsg.Replace(Environment.NewLine, string.Empty)) ? string.Empty : errMsg;
        }
        #endregion

        #region GyoshaMstCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaMstCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GyoshaMstCheck(string gyoshaCd)
        {
            // Get GyoshaMst by key
            IGetGyoshaMstByKeyBLInput keyInp = new GetGyoshaMstByKeyBLInput();
            keyInp.GyoshaCd = gyoshaCd;
            IGetGyoshaMstByKeyBLOutput keyOutp = new GetGyoshaMstByKeyBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.GyoshaMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[業者マスタ][業者コード：{0}]", gyoshaCd);
            }

            return string.Empty;
        }
        #endregion

        #region GyoshaEigyoshoMstCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaEigyoshoMstCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GyoshaEigyoshoMstCheck(string gyoshaCd)
        {
            // Get GyoshaMst by key
            IGetGyoshaEigyoshoMstByGyoshaCdBLInput keyInp = new GetGyoshaEigyoshoMstByGyoshaCdBLInput();
            keyInp.GyoshaCd = gyoshaCd;
            IGetGyoshaEigyoshoMstByGyoshaCdBLOutput keyOutp = new GetGyoshaEigyoshoMstByGyoshaCdBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.GyoshaEigyoshoMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[業者営業所マスタ][業者コード：{0}]", gyoshaCd);
            }

            return string.Empty;
        }
        #endregion

        #region GyoshaEigyoChikuMstCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaEigyoChikuMstCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GyoshaEigyoChikuMstCheck(string gyoshaCd)
        {
            // Get GyoshaMst by key
            IGetGyoshaEigyoChikuMstByGyoshaCdBLInput keyInp = new GetGyoshaEigyoChikuMstByGyoshaCdBLInput();
            keyInp.GyoshaCd = gyoshaCd;
            IGetGyoshaEigyoChikuMstByGyoshaCdBLOutput keyOutp = new GetGyoshaEigyoChikuMstByGyoshaCdBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.GyoshaEigyoChikuMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[業者営業地区マスタ][業者コード：{0}]", gyoshaCd);
            }

            return string.Empty;
        }
        #endregion

        #region GyoshaBukaiMstCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaBukaiMstCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  AnhNV　　    新規作成
        /// 2014/10/20　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GyoshaBukaiMstCheck(string gyoshaCd)
        {
            // Get GyoshaMst by key
            IGetGyoshaBukaiMstByGyoshaCdBLInput keyInp = new GetGyoshaBukaiMstByGyoshaCdBLInput();
            keyInp.GyoshaCd = gyoshaCd;
            IGetGyoshaBukaiMstByGyoshaCdBLOutput keyOutp = new GetGyoshaBukaiMstByGyoshaCdBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.GyoshaBukaiMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[業者部会マスタ][業者コード：{0}]", gyoshaCd);
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
        /// 2014/07/03  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            IGetGyoshaMstByKeyBLInput checkInput = new GetGyoshaMstByKeyBLInput();
            checkInput.GyoshaCd = input.GyoshaMstDataTable[0].GyoshaCd;
            IGetGyoshaMstByKeyBLOutput checkOutput = new GetGyoshaMstByKeyBusinessLogic().Execute(checkInput);

            // 更新日が違うか？
            if (checkOutput.GyoshaMstDataTable[0].UpdateDt != input.GyoshaMstDataTable[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // 更新日
            input.GyoshaMstDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
        }
        #endregion

        #endregion
    }
    #endregion
}
