using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.KenchikuyotoMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.KenchikuyotoMstShosai
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
    /// 2014/07/29　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateKenchikuyotoMstBLInput
    {
        /// <summary>
        /// DisplayMode
        /// </summary>
        KenchikuyotoMstShosaiForm.DispMode DisplayMode { get; set; }
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
    /// 2014/07/29　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// DisplayMode
        /// </summary>
        public KenchikuyotoMstShosaiForm.DispMode DisplayMode { get; set; }

        /// <summary>
        /// KenchikuyotoMstDataTable
        /// </summary>
        public KenchikuyotoMstDataSet.KenchikuyotoMstDataTable KenchikuyotoMstDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("建築用途大分類[{0}], 建築用途小分類[{1}], 建築用途連番[{2}]",
                    new string[] { KenchikuyotoMstDataTable[0].KenchikuyotoDaibunrui, KenchikuyotoMstDataTable[0].KenchikuyotoShobunrui, KenchikuyotoMstDataTable[0].KenchikuyotoRenban.ToString() });
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
    /// 2014/07/29　HuyTX　　    新規作成
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
    /// 2014/07/29　HuyTX　　    新規作成
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
    /// 2014/07/29　HuyTX　　    新規作成
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
        private const string FunctionName = "KenchikuyotoMstShosai：DecisionBtnClick";

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
        /// 2014/07/29　HuyTX　　    新規作成
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
        /// 2014/07/29　HuyTX　　    新規作成
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
        /// 2014/07/29　HuyTX　　    新規作成
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

                KenchikuyotoMstDataSet.KenchikuyotoMstDataTable existDataTable = GetExistData(input);

                if (input.DisplayMode == KenchikuyotoMstShosaiForm.DispMode.Add && existDataTable.Count > 0)
                {
                    output.ErrMessage = "既に登録済みです。[大分類：{0}][小分類：{1}][連番：{2}]";
                    return output;
                }

                if (input.DisplayMode == KenchikuyotoMstShosaiForm.DispMode.Edit)
                {
                    if (existDataTable.Count == 0)
                    {
                        output.ErrMessage = "該当するデータは登録されていません。[大分類：{0}][小分類：{1}][連番：{2}]";
                        return output;
                    }
                    else
                    {
                        if (input.KenchikuyotoMstDataTable[0].UpdateDt != existDataTable[0].UpdateDt)
                        {
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }

                        //更新日
                        input.KenchikuyotoMstDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();
                    }

                }

                new UpdateKenchikuyotoMstBusinessLogic().Execute(input);

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
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool isExistKey(IDecisionBtnClickALInput input)
        {
            IGetKenchiKuyotoMstByKeyBLInput blInput = new GetKenchiKuyotoMstByKeyBLInput();
            blInput.HenchikuyotoDaibunruiCd = input.KenchikuyotoMstDataTable[0].KenchikuyotoDaibunrui;
            blInput.KenchikuyotoShobunruiCd = input.KenchikuyotoMstDataTable[0].KenchikuyotoShobunrui;
            blInput.KenchikuyotoRenban = input.KenchikuyotoMstDataTable[0].KenchikuyotoRenban;

            IGetKenchiKuyotoMstByKeyBLOutput blOutput = new GetKenchiKuyotoMstByKeyBusinessLogic().Execute(blInput);

            if (blOutput.KenchikuyotoMstDataTable.Count != 0)
            {
                return true;
            }

            return false;
        }
        #endregion

        //#region RakkanCheck
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： RakkanCheck
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/07/03  HuyTX　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void RakkanCheck(IDecisionBtnClickALInput input)
        //{
        //    IGet blInput = new GetSuishitsuKekkaNmMstByKeyBLInput();
        //    blInput.ShishoCd = input.SuishitsuKekkaNmDT[0].SuishitsuKekkaShishoCd;
        //    blInput.SuishitsuKekkaNmCd = input.SuishitsuKekkaNmDT[0].SuishitsuKekkaNmCd;

        //    IGetSuishitsuKekkaNmMstByKeyBLOutput blOutput = new GetSuishitsuKekkaNmMstByKeyBusinessLogic().Execute(blInput);

        //    if (input.SuishitsuKekkaNmDT[0].UpdateDt != blOutput.SuishitsuKekkaNmMstDT[0].UpdateDt)
        //    {
        //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
        //    }

        //}
        //#endregion

        #region GetExistData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetExistData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KenchikuyotoMstDataSet.KenchikuyotoMstDataTable GetExistData(IDecisionBtnClickALInput input)
        {
            IGetKenchiKuyotoMstByKeyBLInput blInput = new GetKenchiKuyotoMstByKeyBLInput();
            blInput.HenchikuyotoDaibunruiCd = input.KenchikuyotoMstDataTable[0].KenchikuyotoDaibunrui;
            blInput.KenchikuyotoShobunruiCd = input.KenchikuyotoMstDataTable[0].KenchikuyotoShobunrui;
            blInput.KenchikuyotoRenban = input.KenchikuyotoMstDataTable[0].KenchikuyotoRenban;

            IGetKenchiKuyotoMstByKeyBLOutput blOutput = new GetKenchiKuyotoMstByKeyBusinessLogic().Execute(blInput);

            return blOutput.KenchikuyotoMstDataTable;
        }
        #endregion

        #endregion
    }
    #endregion
}
