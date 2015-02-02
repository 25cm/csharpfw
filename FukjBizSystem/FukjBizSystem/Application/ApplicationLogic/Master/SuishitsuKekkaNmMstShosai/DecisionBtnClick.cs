using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.SuishitsuKekkaNmMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuKekkaNmMstShosai
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
    /// 2014/07/03　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateSuishitsuKekkaNmMstBLInput
    {
        /// <summary>
        /// DisplayMode
        /// </summary>
        SuishitsuKekkaNmMstShosaiForm.DispMode DisplayMode { get; set; }
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
    /// 2014/07/03　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// SuishitsuKekkaNmDataTable
        /// </summary>
        public SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable SuishitsuKekkaNmDT { get; set; }

        /// <summary>
        /// DisplayMode
        /// </summary>
        public SuishitsuKekkaNmMstShosaiForm.DispMode DisplayMode { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所コード[{0}], 水質結果名称コード[{1}]", new string[] { SuishitsuKekkaNmDT[0].SuishitsuKekkaShishoCd, SuishitsuKekkaNmDT[0].SuishitsuKekkaNmCd });
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
    /// 2014/07/03　HuyTX　　    新規作成
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
    /// 2014/07/03　HuyTX　　    新規作成
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
    /// 2014/07/03　HuyTX　　    新規作成
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
        private const string FunctionName = "SuishitsuKekkaNmMstShosai：DecisionBtnClick";

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
        /// 2014/07/03　HuyTX　　    新規作成
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
        /// 2014/07/03　HuyTX　　    新規作成
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
        /// 2014/07/03　HuyTX　　    新規作成
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

                bool isRegisted = isExistKey(input.SuishitsuKekkaNmDT[0].SuishitsuKekkaShishoCd, input.SuishitsuKekkaNmDT[0].SuishitsuKekkaNmCd);

                if (input.DisplayMode == SuishitsuKekkaNmMstShosaiForm.DispMode.Add && isRegisted)
                {
                    output.ErrMessage = string.Format("既に登録済みです。[支所コード：{0}][水質結果名称コード：{1}]",
                        new string[] { input.SuishitsuKekkaNmDT[0].SuishitsuKekkaShishoCd, input.SuishitsuKekkaNmDT[0].SuishitsuKekkaNmCd });
                    return output;
                }

                if (input.DisplayMode == SuishitsuKekkaNmMstShosaiForm.DispMode.Edit)
                {
                    if (!isRegisted)
                    {
                        output.ErrMessage = string.Format("該当するデータは登録されていません。[支所コード：{0}][水質結果名称コード：{1}]",
                            new string[] { input.SuishitsuKekkaNmDT[0].SuishitsuKekkaShishoCd, input.SuishitsuKekkaNmDT[0].SuishitsuKekkaNmCd });
                        return output;
                    }
                    else
                    {
                        //RakkanCheck
                        RakkanCheck(input);

                        //更新日
                        input.SuishitsuKekkaNmDT[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
                    }

                }

                new UpdateSuishitsuKekkaNmMstBusinessLogic().Execute(input);

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
        /// <param name="shishoCd"></param>
        /// <param name="suishitsuKekkaNmCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool isExistKey(string shishoCd, string suishitsuKekkaNmCd)
        {
            IGetSuishitsuKekkaNmMstByKeyBLInput blInput = new GetSuishitsuKekkaNmMstByKeyBLInput();
            blInput.ShishoCd = shishoCd;
            blInput.SuishitsuKekkaNmCd = suishitsuKekkaNmCd;

            IGetSuishitsuKekkaNmMstByKeyBLOutput blOutput = new GetSuishitsuKekkaNmMstByKeyBusinessLogic().Execute(blInput);

            if (blOutput.SuishitsuKekkaNmMstDT.Count != 0)
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
        /// 2014/07/03  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            IGetSuishitsuKekkaNmMstByKeyBLInput blInput = new GetSuishitsuKekkaNmMstByKeyBLInput();
            blInput.ShishoCd = input.SuishitsuKekkaNmDT[0].SuishitsuKekkaShishoCd;
            blInput.SuishitsuKekkaNmCd = input.SuishitsuKekkaNmDT[0].SuishitsuKekkaNmCd;

            IGetSuishitsuKekkaNmMstByKeyBLOutput blOutput = new GetSuishitsuKekkaNmMstByKeyBusinessLogic().Execute(blInput);

            if (input.SuishitsuKekkaNmDT[0].UpdateDt != blOutput.SuishitsuKekkaNmMstDT[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

        }
        #endregion

        #endregion
    }
    #endregion
}
