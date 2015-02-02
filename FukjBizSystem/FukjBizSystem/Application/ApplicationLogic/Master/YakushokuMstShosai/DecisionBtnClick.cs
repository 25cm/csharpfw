using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.YakushokuMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.YakushokuMstShosai
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
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateYakushokuMstBLInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        YakushokuMstShosaiForm.DispMode DispMode { get; set; }
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
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        public YakushokuMstShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// YakushokuMstDataTable
        /// </summary>
        public YakushokuMstDataSet.YakushokuMstDataTable YakushokuMstDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("DispMode[{0}], YakushokuMstDataTable[{1}]", 
                    new string[] { DispMode.ToString(), YakushokuMstDT[0].YakushokuCd });
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
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput : IUpdateYakushokuMstBLOutput
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
    /// 2014/07/07  DatNT　　    新規作成
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
    /// 2014/07/07  DatNT　　    新規作成
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
        private const string FunctionName = "YakushokuMstShosai：DecisionBtnClickApplicationLogic";

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
        /// 2014/07/07  DatNT　　    新規作成
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
        /// 2014/07/07  DatNT　　    新規作成
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnClickALOutput();

            try
            {
                YakushokuMstDataSet.YakushokuMstDataTable dataTable = new YakushokuMstDataSet.YakushokuMstDataTable();

                StartTransaction();

                if (input.DispMode == YakushokuMstShosaiForm.DispMode.Edit)
                {
                    if (CheckExist(input.YakushokuMstDT))
                    {
                        output.ErrMessage = string.Format("該当するデータは登録されていません。[役職コード：{0}]",
                            new string[] { input.YakushokuMstDT[0].YakushokuCd });

                        return output;
                    }

                    dataTable = CreateDataUpdate(input);
                }
                else
                {
                    if (!CheckExist(input.YakushokuMstDT))
                    {
                        output.ErrMessage = string.Format("既に登録済みです。[役職コード：{0}]",
                            new string[] { input.YakushokuMstDT[0].YakushokuCd });

                        return output;
                    }

                    dataTable = input.YakushokuMstDT;
                }

                // insert/update
                IUpdateYakushokuMstBLInput blInput = new UpdateYakushokuMstBLInput();
                blInput.YakushokuMstDT = dataTable;
                IUpdateYakushokuMstBLOutput blOutput = new UpdateYakushokuMstBusinessLogic().Execute(blInput);

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

        #region メソッド(private)

        #region CreateDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="input">AL入力情報</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YakushokuMstDataSet.YakushokuMstDataTable CreateDataUpdate(IDecisionBtnClickALInput input)
        {
            YakushokuMstDataSet.YakushokuMstDataTable updateDT = new YakushokuMstDataSet.YakushokuMstDataTable();

            IGetYakushokuMstByKeyBLInput blInput    = new GetYakushokuMstByKeyBLInput();
            blInput.YakushokuCd                     = input.YakushokuMstDT[0].YakushokuCd;
            IGetYakushokuMstByKeyBLOutput blOutput  = new GetYakushokuMstByKeyBusinessLogic().Execute(blInput);

            YakushokuMstDataSet.YakushokuMstRow row = blOutput.YakushokuMstDT[0];

            // 更新日が違うか？
            if (row.UpdateDt != input.YakushokuMstDT[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // 役職コード
            row.YakushokuCd = input.YakushokuMstDT[0].YakushokuCd;

            // 役職名
            row.YakushokuNm = input.YakushokuMstDT[0].YakushokuNm;

            // 役職区分
            row.YakushokuKbn = input.YakushokuMstDT[0].YakushokuKbn;

            // 更新日
            row.UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();

            // 更新者
            row.UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 更新端末
            row.UpdateTarm = Dns.GetHostName();

            updateDT.ImportRow(row);

            return updateDT;
        }
        #endregion

        #region CheckExist
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckExist
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="dataTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckExist(YakushokuMstDataSet.YakushokuMstDataTable dataTable)
        {
            IGetYakushokuMstByKeyBLInput blInput    = new GetYakushokuMstByKeyBLInput();
            blInput.YakushokuCd                     = dataTable[0].YakushokuCd;
            IGetYakushokuMstByKeyBLOutput blOutput  = new GetYakushokuMstByKeyBusinessLogic().Execute(blInput);

            if (blOutput.YakushokuMstDT != null && blOutput.YakushokuMstDT.Count > 0)
            {
                return false;
            }

            return true;
        }
        #endregion

        #endregion
    }
    #endregion
}
