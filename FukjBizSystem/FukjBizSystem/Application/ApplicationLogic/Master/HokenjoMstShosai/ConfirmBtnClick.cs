using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.HokenjoMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.HokenjoMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IConfirmBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IConfirmBtnClickALInput : IBseALInput, IUpdateHokenjoMstBLInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        HokenjoMstShosaiForm.DispMode DispMode { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ConfirmBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ConfirmBtnClickALInput : IConfirmBtnClickALInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        public HokenjoMstShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// HokenjoMstDataTable
        /// </summary>
        public HokenjoMstDataSet.HokenjoMstDataTable HokenjoMstDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("DispMode[{0}], HokenjoMstDT[{1}]", 
                    new string[] { 
                        DispMode.ToString(),
                        HokenjoMstDT[0].HokenjoCd.ToString() 
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IConfirmBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IConfirmBtnClickALOutput : IUpdateHokenjoMstBLOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        string ErrMessage { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ConfirmBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ConfirmBtnClickALOutput : IConfirmBtnClickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        public string ErrMessage { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ConfirmBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/20  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ConfirmBtnClickApplicationLogic : BaseApplicationLogic<IConfirmBtnClickALInput, IConfirmBtnClickALOutput>
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
        private const string FunctionName = "HokenjoMstShosai：ConfirmBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ConfirmBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ConfirmBtnClickApplicationLogic()
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
        /// 2014/06/20  DatNT　　    新規作成
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
        /// 2014/06/20  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IConfirmBtnClickALOutput Execute(IConfirmBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IConfirmBtnClickALOutput output = new ConfirmBtnClickALOutput();

            try
            {
                HokenjoMstDataSet.HokenjoMstDataTable dataTable = new HokenjoMstDataSet.HokenjoMstDataTable();

                StartTransaction();

                if (input.DispMode == HokenjoMstShosaiForm.DispMode.Edit)
                {
                    if (!string.IsNullOrEmpty(CheckExistHokenjoCd(input)))
                    {
                        output.ErrMessage = CheckExistHokenjoCd(input);
                        return output;
                    }
                    

                    dataTable = CreateDataUpdate(input);                    
                }
                else
                {
                    if (string.IsNullOrEmpty(CheckExistHokenjoCd(input)))
                    {
                        output.ErrMessage = string.Format("既に登録済みです。[保健所コード：{0}]", input.HokenjoMstDT[0].HokenjoCd);
                        return output;
                    }
                    dataTable = input.HokenjoMstDT;
                }

                // insert/update
                IUpdateHokenjoMstBLInput blInput    = new UpdateHokenjoMstBLInput();
                blInput.HokenjoMstDT                = dataTable;
                IUpdateHokenjoMstBLOutput blOutput  = new UpdateHokenjoMstBusinessLogic().Execute(blInput);

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
        /// 2014/06/24　DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HokenjoMstDataSet.HokenjoMstDataTable CreateDataUpdate(IConfirmBtnClickALInput input)
        {
            HokenjoMstDataSet.HokenjoMstDataTable updateDT = new HokenjoMstDataSet.HokenjoMstDataTable();

            IGetHokenjoMstByKeyBLInput blInput = new GetHokenjoMstByKeyBLInput();
            blInput.HokenjoCd = input.HokenjoMstDT[0].HokenjoCd;
            IGetHokenjoMstByKeyBLOutput blOutput = new GetHokenjoMstByKeyBusinessLogic().Execute(blInput);

            HokenjoMstDataSet.HokenjoMstRow row = blOutput.HokenjoMstDT[0];

            // 更新日が違うか？
            if (row.UpdateDt != input.HokenjoMstDT[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            row.HokenjoNm = input.HokenjoMstDT[0].HokenjoNm;

            row.HokenjoZipCd = input.HokenjoMstDT[0].HokenjoZipCd;

            row.HokenjoTelNo = input.HokenjoMstDT[0].HokenjoTelNo;

            row.HokenjoAdr = input.HokenjoMstDT[0].HokenjoAdr;

            //20150123 HuyTX Ver1.01
            row.DelFlg = input.HokenjoMstDT[0].DelFlg;
            //End

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

        #region CheckExistHokenjoCd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckExistHokenjoCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string CheckExistHokenjoCd(IConfirmBtnClickALInput input)
        {
            IGetHokenjoMstByKeyBLInput blInput = new GetHokenjoMstByKeyBLInput();
            blInput.HokenjoCd = input.HokenjoMstDT[0].HokenjoCd;

            IGetHokenjoMstByKeyBLOutput blOutput = new GetHokenjoMstByKeyBusinessLogic().Execute(blInput);

            if (blOutput.HokenjoMstDT.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[保健所コード：{0}]", input.HokenjoMstDT[0].HokenjoCd);
            }

            return string.Empty;
        }
        #endregion        

        #endregion

    }
    #endregion
}
