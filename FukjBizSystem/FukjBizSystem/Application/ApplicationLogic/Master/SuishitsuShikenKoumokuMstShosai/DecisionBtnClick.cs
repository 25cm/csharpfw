using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.SuishitsuShikenKoumokuMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuShikenKoumokuMstShosai
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
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateSuishitsuShikenKoumokuMstBLInput
    {
        /// <summary>
        /// DisplayMode
        /// </summary>
        SuishitsuShikenKoumokuMstShosaiForm.DispMode DisplayMode { get; set; }
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
        /// SuishitsuShikenKoumokuMstDataTable
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstDataTable SuishitsuShikenKoumokuMstDataTable { get; set; }

        /// <summary>
        /// DisplayMode
        /// </summary>
        public SuishitsuShikenKoumokuMstShosaiForm.DispMode DisplayMode { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("水質試験項目コード[{0}]", SuishitsuShikenKoumokuMstDataTable[0].SuishitsuShikenKoumokuCd);
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
        private const string FunctionName = "SuishitsuShikenKoumokuMstShosai：DecisionBtnClick";

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

                bool isRegisted = isExistCd(input.SuishitsuShikenKoumokuMstDataTable[0].SuishitsuShikenKoumokuCd);

                if (input.DisplayMode == SuishitsuShikenKoumokuMstShosaiForm.DispMode.Add && isRegisted)
                {
                    output.ErrMessage = string.Format("既に登録済みです。[水質試験項目コード：{0}]", input.SuishitsuShikenKoumokuMstDataTable[0].SuishitsuShikenKoumokuCd);
                    return output;
                }

                if (input.DisplayMode == SuishitsuShikenKoumokuMstShosaiForm.DispMode.Edit)
                {
                    if (!isRegisted)
                    {
                        output.ErrMessage = string.Format("該当するデータは登録されていません。[水質試験項目コード：{0}]", input.SuishitsuShikenKoumokuMstDataTable[0].SuishitsuShikenKoumokuCd);
                        return output;
                    }
                    else
                    {
                        //RakkanCheck
                        RakkanCheck(input);

                        //更新日
                        input.SuishitsuShikenKoumokuMstDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
                    }

                }

                new UpdateSuishitsuShikenKoumokuMstBusinessLogic().Execute(input);

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

        #region isExistCd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： isExistCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool isExistCd(string suishitsuShikenKoumokuCd)
        {
            IGetSuishitsuShikenKoumokuMstByKeyBLInput blInput = new GetSuishitsuShikenKoumokuMstByKeyBLInput();
            blInput.SuishitsuShikenKoumokuCd = suishitsuShikenKoumokuCd;

            IGetSuishitsuShikenKoumokuMstByKeyBLOutput blOutput = new GetSuishitsuShikenKoumokuMstByKeyBusinessLogic().Execute(blInput);

            if (blOutput.SuishitsuShikenKoumokuMstDataTable.Count != 0)
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
        /// <param name="chikuCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            IGetSuishitsuShikenKoumokuMstByKeyBLInput blInput = new GetSuishitsuShikenKoumokuMstByKeyBLInput();
            blInput.SuishitsuShikenKoumokuCd = input.SuishitsuShikenKoumokuMstDataTable[0].SuishitsuShikenKoumokuCd;

            IGetSuishitsuShikenKoumokuMstByKeyBLOutput blOutput = new GetSuishitsuShikenKoumokuMstByKeyBusinessLogic().Execute(blInput);

            if (input.SuishitsuShikenKoumokuMstDataTable[0].UpdateDt != blOutput.SuishitsuShikenKoumokuMstDataTable[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

        }
        #endregion

        #endregion
    }
    #endregion
}
