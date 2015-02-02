using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.MemoMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.MemoMstShosai
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
    /// 2014/08/13  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput, IUpdateMemoMstBLInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        MemoMstShosaiForm.DispMode DispMode { get; set; }
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
    /// 2014/08/13  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// MemoMstDataTable
        /// </summary>
        public MemoMstDataSet.MemoMstDataTable MemoMstDT { get; set; }

        /// <summary>
        /// DispMode
        /// </summary>
        public MemoMstShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("MemoMstDataTable[{0}], DispMode[{1}]", 
                    new string[] {
                        MemoMstDT[0].MemoCd,
                        DispMode.ToString(),
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
    /// 2014/08/13  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput : IUpdateMemoMstBLOutput
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
    /// 2014/08/13  DatNT　  新規作成
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
    /// 2014/08/13  DatNT　  新規作成
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
        private const string FunctionName = "MemoMstShosai：DecisionBtnClickApplicationLogic";

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
        /// 2014/08/13  DatNT　  新規作成
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
        /// 2014/08/13  DatNT　  新規作成
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
        /// 2014/08/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnClickALOutput();

            try
            {
                MemoMstDataSet.MemoMstDataTable dataTable = new MemoMstDataSet.MemoMstDataTable();

                StartTransaction();

                if (input.DispMode == MemoMstShosaiForm.DispMode.Edit)
                {
                    if (CheckExist(input.MemoMstDT))
                    {
                        output.ErrMessage = string.Format("該当するデータは登録されていません。[大分類コード：{0}][メモコード：{1}]",
                            new string[] { input.MemoMstDT[0].MemoDaibunruiCd, input.MemoMstDT[0].MemoCd });

                        return output;
                    }

                    dataTable = CreateDataUpdate(input);
                }
                else
                {
                    if (!CheckExist(input.MemoMstDT))
                    {
                        output.ErrMessage = string.Format("既に登録済みです。[大分類コード：{0}][メモコード：{1}]",
                            new string[] { input.MemoMstDT[0].MemoDaibunruiCd, input.MemoMstDT[0].MemoCd });

                        return output;
                    }

                    dataTable = input.MemoMstDT;
                }

                // insert/update
                IUpdateMemoMstBLInput blInput   = new UpdateMemoMstBLInput();
                blInput.MemoMstDT               = dataTable;
                IUpdateMemoMstBLOutput blOutput = new UpdateMemoMstBusinessLogic().Execute(blInput);

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
        /// 2014/08/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private MemoMstDataSet.MemoMstDataTable CreateDataUpdate(IDecisionBtnClickALInput input)
        {
            MemoMstDataSet.MemoMstDataTable updateDT = new MemoMstDataSet.MemoMstDataTable();

            IGetMemoMstByKeyBLInput blInput     = new GetMemoMstByKeyBLInput();
            blInput.MemoDaibunruiCd             = input.MemoMstDT[0].MemoDaibunruiCd;
            blInput.MemoCd                      = input.MemoMstDT[0].MemoCd;
            IGetMemoMstByKeyBLOutput blOutput   = new GetMemoMstByKeyBusinessLogic().Execute(blInput);

            MemoMstDataSet.MemoMstRow row = blOutput.MemoMstDT[0];

            //// 更新日が違うか？
            if (row.UpdateDt != input.MemoMstDT[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // メモ大分類コード
            row.MemoDaibunruiCd = input.MemoMstDT[0].MemoDaibunruiCd;

            // メモコード
            row.MemoCd = input.MemoMstDT[0].MemoCd;

            // メモ
            row.Memo = input.MemoMstDT[0].Memo;

            // 重要フラグ
            row.MemoJuyoFlg = input.MemoMstDT[0].MemoJuyoFlg;

            // 選択フラグ
            row.MemoSelectFlg = input.MemoMstDT[0].MemoSelectFlg;        

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
        /// 2014/08/13  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckExist(MemoMstDataSet.MemoMstDataTable dataTable)
        {
            IGetMemoMstByKeyBLInput blInput     = new GetMemoMstByKeyBLInput();
            blInput.MemoDaibunruiCd             = dataTable[0].MemoDaibunruiCd;
            blInput.MemoCd                      = dataTable[0].MemoCd;
            IGetMemoMstByKeyBLOutput blOutput   = new GetMemoMstByKeyBusinessLogic().Execute(blInput);

            if (blOutput.MemoMstDT != null && blOutput.MemoMstDT.Count > 0)
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
