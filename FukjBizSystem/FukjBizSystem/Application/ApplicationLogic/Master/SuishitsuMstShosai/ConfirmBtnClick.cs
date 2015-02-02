using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.Master;
using FukjBizSystem.Application.BusinessLogic.Master.SuishitsuMstShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.SuishitsuMstShosai
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
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IConfirmBtnClickALInput : IBseALInput, IUpdateSuishitsuMstBLInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        SuishitsuMstShosaiForm.DispMode DispMode { get; set; }
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
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ConfirmBtnClickALInput : IConfirmBtnClickALInput
    {
        /// <summary>
        /// DispMode
        /// </summary>
        public SuishitsuMstShosaiForm.DispMode DispMode { get; set; }

        /// <summary>
        /// SuishitsuMstDataTable
        /// </summary>
        public SuishitsuMstDataSet.SuishitsuMstDataTable SuishitsuMstDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("DispMode[{0}], SuishitsuMstDT[{1}]", 
                    new string[]{
                        DispMode.ToString(),
                        SuishitsuMstDT[0].SuishitsuCd
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
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IConfirmBtnClickALOutput : IUpdateSuishitsuMstBLOutput
    {
        /// <summary>
        /// Duplicate key error message
        /// </summary>
        string ErrMsg { get; set; }
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
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ConfirmBtnClickALOutput : IConfirmBtnClickALOutput
    {
        /// <summary>
        /// Duplicate key error message
        /// </summary>
        public string ErrMsg { get; set; }
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
    /// 2014/06/24  DatNT　　    新規作成
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
        private const string FunctionName = "SuishitsuMstShosai：ConfirmBtnClickApplicationLogic";

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
        /// 2014/06/24  DatNT　　    新規作成
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
        /// 2014/06/24  DatNT　　    新規作成
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
        /// 2014/06/24  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IConfirmBtnClickALOutput Execute(IConfirmBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IConfirmBtnClickALOutput output = new ConfirmBtnClickALOutput();

            try
            {
                StartTransaction();

                SuishitsuMstDataSet.SuishitsuMstDataTable dataTable = new SuishitsuMstDataSet.SuishitsuMstDataTable();

                // Duplication check
                bool isKeyExist = DuplicateKeyCheck(input);

                if (input.DispMode == SuishitsuMstShosaiForm.DispMode.Edit)
                {
                    // Key update does not exist
                    if (!isKeyExist)
                    {
                        output.ErrMsg = string.Format("該当するデータは登録されていません。[水質コード：{0}]", input.SuishitsuMstDT[0].SuishitsuCd);
                        return output;
                    }

                    dataTable = CreateDataUpdate(input);
                }
                else
                {
                    // Key update already exist
                    if (isKeyExist)
                    {
                        output.ErrMsg = string.Format("既に登録済みです。[水質コード：{0}]", input.SuishitsuMstDT[0].SuishitsuCd);
                        return output;
                    }

                    dataTable = input.SuishitsuMstDT;
                }

                // insert/update
                IUpdateSuishitsuMstBLInput blInput = new UpdateSuishitsuMstBLInput();
                blInput.SuishitsuMstDT = dataTable;
                IUpdateSuishitsuMstBLOutput blOutput = new UpdateSuishitsuMstBusinessLogic().Execute(blInput);

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
        private SuishitsuMstDataSet.SuishitsuMstDataTable CreateDataUpdate(IConfirmBtnClickALInput input)
        {
            SuishitsuMstDataSet.SuishitsuMstDataTable updateDT = new SuishitsuMstDataSet.SuishitsuMstDataTable();

            IGetSuishitsuMstByKeyBLInput blInput   = new GetSuishitsuMstByKeyBLInput();
            blInput.SuishitsuShishoCd              = input.SuishitsuMstDT[0].SuishitsuShishoCd;
            blInput.SuishitsuCd                    = input.SuishitsuMstDT[0].SuishitsuCd;
            IGetSuishitsuMstByKeyBLOutput blOutput = new GetSuishitsuMstByKeyBusinessLogic().Execute(blInput);

            SuishitsuMstDataSet.SuishitsuMstRow row = blOutput.SuishitsuMstDT[0];

            // 更新日が違うか？
            if (row.UpdateDt != input.SuishitsuMstDT[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // 水質名称 4
            row.SuishitsuNm = input.SuishitsuMstDT[0].SuishitsuNm;

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

        #region DuplicateKeyCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DuplicateKeyCheck
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="input">AL入力情報</param>
        /// <returns>
        /// TRUE: Key exist
        /// FALSE: Key does not exist
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool DuplicateKeyCheck(IConfirmBtnClickALInput input)
        {
            IGetSuishitsuMstByKeyBLInput keyInput = new GetSuishitsuMstByKeyBLInput();
            keyInput.SuishitsuCd = input.SuishitsuMstDT[0].SuishitsuCd;
            keyInput.SuishitsuShishoCd = input.SuishitsuMstDT[0].SuishitsuShishoCd;
            IGetSuishitsuMstByKeyBLOutput keyOutput = new GetSuishitsuMstByKeyBusinessLogic().Execute(keyInput);

            return keyOutput.SuishitsuMstDT.Count > 0 ? true : false;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion
}
