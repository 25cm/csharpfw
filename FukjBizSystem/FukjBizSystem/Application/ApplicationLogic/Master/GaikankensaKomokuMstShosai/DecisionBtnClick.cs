using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.GaikankensaKomokuMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.GaikankensaKomokuMstShosai
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
    /// 2014/07/02  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateGaikankensaKomokuMstBLInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        GaikankensaKomokuMstShosaiForm.DispMode DispMode { get; set; }
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
    /// 2014/07/02  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        public GaikankensaKomokuMstShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// GaikankensaKomokuMstDataTable
        /// </summary>
        public GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable GaikankensaKomokuMstDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("DispMode[{0}], GaikankensaKomokuMstDataTable[{1}]", 
                    new string[]{
                        DispMode.ToString(),
                        GaikankensaKomokuMstDT[0].GaikankensaKomokuCd
                    });
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
    /// 2014/07/02  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput : IUpdateGaikankensaKomokuMstBLOutput
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
    /// 2014/07/02  DatNT　　    新規作成
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
    /// 2014/07/02  DatNT　　    新規作成
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
        private const string FunctionName = "GaikankesaKomokuMstShosai：DecisionBtnClickApplicationLogic";

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
        /// 2014/07/02  DatNT　　    新規作成
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
        /// 2014/07/02  DatNT　　    新規作成
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
        /// 2014/07/02  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnClickALOutput();

            try
            {
                GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable dataTable = new GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable();

                StartTransaction();

                if (input.DispMode == GaikankensaKomokuMstShosaiForm.DispMode.Edit)
                {
                    if (CheckExist(input.GaikankensaKomokuMstDT))
                    {
                        output.ErrMessage = string.Format("該当するデータは登録されていません。[外観検査項目コード：{0}]",
                            new string[] { input.GaikankensaKomokuMstDT[0].GaikankensaKomokuCd });

                        return output;
                    }

                    dataTable = CreateDataUpdate(input);
                }
                else
                {
                    if (!CheckExist(input.GaikankensaKomokuMstDT))
                    {
                        output.ErrMessage = string.Format("既に登録済みです。[外観検査項目コード：{0}]",
                            new string[] { input.GaikankensaKomokuMstDT[0].GaikankensaKomokuCd });

                        return output;
                    }

                    dataTable = input.GaikankensaKomokuMstDT;
                }

                // insert/update
                IUpdateGaikankensaKomokuMstBLInput blInput   = new UpdateGaikankensaKomokuMstBLInput();
                blInput.GaikankensaKomokuMstDT               = dataTable;
                IUpdateGaikankensaKomokuMstBLOutput blOutput = new UpdateGaikankensaKomokuMstBusinessLogic().Execute(blInput);

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
        /// 2014/07/02　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable CreateDataUpdate(IDecisionBtnClickALInput input)
        {
            GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable updateDT = new GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable();

            IGetGaikankensaKomokuMstByKeyBLInput blInput    = new GetGaikankensaKomokuMstByKeyBLInput();
            blInput.GaikankensaKomokuCd                     = input.GaikankensaKomokuMstDT[0].GaikankensaKomokuCd;
            IGetGaikankensaKomokuMstByKeyBLOutput blOutput  = new GetGaikankensaKomokuMstByKeyBusinessLogic().Execute(blInput);

            GaikankensaKomokuMstDataSet.GaikankensaKomokuMstRow row = blOutput.GaikankensaKomokuMstDT[0];

            // 更新日が違うか？
            if (row.UpdateDt != input.GaikankensaKomokuMstDT[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // 外観検査項目コード
            row.GaikankensaKomokuCd = input.GaikankensaKomokuMstDT[0].GaikankensaKomokuCd;

            // 外観検査項目名称
            row.GaikankensaKomokuNm = input.GaikankensaKomokuMstDT[0].GaikankensaKomokuNm;

            // 前外観検査項目コード
            row.ZenGaikankensaKomokuCd = input.GaikankensaKomokuMstDT[0].ZenGaikankensaKomokuCd;

            // 前外観検査項目略名
            row.ZenGaikankensaKomokuRyakumei = input.GaikankensaKomokuMstDT[0].ZenGaikankensaKomokuRyakumei;

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
        /// 2014/07/02　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckExist(GaikankensaKomokuMstDataSet.GaikankensaKomokuMstDataTable dataTable)
        {
            IGetGaikankensaKomokuMstByKeyBLInput blInput    = new GetGaikankensaKomokuMstByKeyBLInput();
            blInput.GaikankensaKomokuCd                     = dataTable[0].GaikankensaKomokuCd;
            IGetGaikankensaKomokuMstByKeyBLOutput blOutput  = new GetGaikankensaKomokuMstByKeyBusinessLogic().Execute(blInput);

            if (blOutput.GaikankensaKomokuMstDT != null && blOutput.GaikankensaKomokuMstDT.Count > 0)
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
