using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.BushoMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.BushoMstShosai
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
    /// 2014/07/04　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateBushoMstBLInput
    {
        /// <summary>
        /// DisplayMode
        /// </summary>
        BushoMstShosaiForm.DispMode DisplayMode { get; set; }
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
    /// 2014/07/04　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// BushoMstDT
        /// </summary>
        public BushoMstDataSet.BushoMstDataTable BushoMstDT { get; set; }

        /// <summary>
        /// DisplayMode
        /// </summary>
        public BushoMstShosaiForm.DispMode DisplayMode { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("部署コード[{0}]", BushoMstDT[0].BushoCd);
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
    /// 2014/07/04　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        string ErrMessage { get; set; }
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
    /// 2014/07/04　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALOutput : IDecisionBtnClickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        public string ErrMessage { get; set; }
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
    /// 2014/07/04　HuyTX　　    新規作成
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
        private const string FunctionName = "BushoMstShosai：DecisionBtnClick";

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
        /// 2014/07/04　HuyTX　　    新規作成
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
        /// 2014/07/04　HuyTX　　    新規作成
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
        /// 2014/07/04　HuyTX　　    新規作成
        /// 2014/10/14  小松        コメント追記
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

                bool isRegisted = isExistKey(input.BushoMstDT[0].BushoCd);

                if (input.DisplayMode == BushoMstShosaiForm.DispMode.Add && isRegisted)
                {
                    output.ErrMessage = string.Format("既に登録済みです。[部署コード：{0}]", input.BushoMstDT[0].BushoCd);
                    return output;
                }

                if (input.DisplayMode == BushoMstShosaiForm.DispMode.Edit)
                {
                    if (!isRegisted)
                    {
                        output.ErrMessage = string.Format("該当するデータは登録されていません。[部署コード：{0}]",input.BushoMstDT[0].BushoCd);
                        return output;
                    }
                    else
                    {
                        // 楽観ロックチェック
                        // 更新対象のレコードが更新されている場合は、楽観ロックエラーの例外が発生
                        RakkanCheck(input);

                        // 更新日に現在日時をセット
                        input.BushoMstDT[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
                    }
                }

                // レコードを更新
                new UpdateBushoMstBusinessLogic().Execute(input);

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

        #region isExistKey
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： isExistKey
        /// <summary>
        /// 
        /// </summary>
        /// <param name="bushoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool isExistKey(string bushoCd)
        {
            IGetBushoMstByKeyBLInput blInput = new GetBushoMstByKeyBLInput();
            blInput.BushoCd = bushoCd;

            IGetBushoMstByKeyBLOutput blOutput = new GetBushoMstByKeyBusinessLogic().Execute(blInput);

            if (blOutput.BushoMstDt.Count != 0)
            {
                return true;
            }

            return false;
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
        /// 2014/07/04  HuyTX　　    新規作成
        /// 2014/10/14  小松        コメント追記
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            // 更新対象のレコードの最新情報を取得
            IGetBushoMstByKeyBLInput blInput = new GetBushoMstByKeyBLInput();
            // レコードのキー情報をセット
            blInput.BushoCd = input.BushoMstDT[0].BushoCd;
            // 対象レコード取得
            IGetBushoMstByKeyBLOutput blOutput = new GetBushoMstByKeyBusinessLogic().Execute(blInput);

            // 更新日が変更されているかで、編集開始時から更新されているかを確認
            if (input.BushoMstDT[0].UpdateDt != blOutput.BushoMstDt[0].UpdateDt)
            {
                // 更新されている場合は、他のユーザから更新されていると判断し、楽観ロックエラーで例外を発生
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

        }
        #endregion

        #endregion
    }
    #endregion
}
