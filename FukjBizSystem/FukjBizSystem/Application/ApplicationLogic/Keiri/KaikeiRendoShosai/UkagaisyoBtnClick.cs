using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiRendoList;
using FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiRendoShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.KaikeiRendoShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUkagaisyoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUkagaisyoBtnClickALInput : IBseALInput, IUpdateKaikeiRendoHdrTblBLInput
    {
        /// <summary>
        /// KaikeiNo
        /// </summary>
        string KaikeiNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UkagaisyoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UkagaisyoBtnClickALInput : IUkagaisyoBtnClickALInput
    {
        /// <summary>
        /// KaikeiRendoHdrTblDataTable
        /// </summary>
        public KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable KaikeiRendoHdrTblDataTable { get; set; }

        /// <summary>
        /// KaikeiNo
        /// </summary>
        public string KaikeiNo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("KaikeiRendoHdrTblDataTable[{0}]", KaikeiRendoHdrTblDataTable[0].KaikeiNo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUkagaisyoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUkagaisyoBtnClickALOutput
    {
        /// <summary>
        /// KaikeiRendoHdrTblDataTable
        /// </summary>
        KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable KaikeiRendoHdrTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UkagaisyoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UkagaisyoBtnClickALOutput : IUkagaisyoBtnClickALOutput
    {
        /// <summary>
        /// KaikeiRendoHdrTblDataTable
        /// </summary>
        public KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable KaikeiRendoHdrTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UkagaisyoBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UkagaisyoBtnClickApplicationLogic : BaseApplicationLogic<IUkagaisyoBtnClickALInput, IUkagaisyoBtnClickALOutput>
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
        private const string FunctionName = "KaikeiRendoShosai：UkagaisyoBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UkagaisyoBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UkagaisyoBtnClickApplicationLogic()
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
        /// 2014/09/17  DatNT　  新規作成
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
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUkagaisyoBtnClickALOutput Execute(IUkagaisyoBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUkagaisyoBtnClickALOutput output = new UkagaisyoBtnClickALOutput();

            try
            {
                StartTransaction();

                //print SuitouUkagaisho
                IGetKaikeiRendoKensakuByKaikeiNoBLInput getKaikeiRendoKensakuBLInput = new GetKaikeiRendoKensakuByKaikeiNoBLInput();
                getKaikeiRendoKensakuBLInput.KaikeiNo = input.KaikeiNo;
                IGetKaikeiRendoKensakuByKaikeiNoBLOutput getKaikeiRendoKensakuBLOutput = new GetKaikeiRendoKensakuByKaikeiNoBusinessLogic().Execute(getKaikeiRendoKensakuBLInput);

                IPrintSuitouUkagaishoBLInput printBLInput = new PrintSuitouUkagaishoBLInput();
                printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SuitouUkagaishoFormatFile;
                printBLInput.AfterDispFlg = true;

                printBLInput.KaikeiRendoHdrTblKensakuRow = getKaikeiRendoKensakuBLOutput.KaikeiRendoHdrTblKensakuDataTable[0];

                new PrintSuitouUkagaishoBusinessLogic().Execute(printBLInput);

                //Update DB

                IGetKaikeiRendoHdrTblByKeyBLInput hdrByKeyInput = new GetKaikeiRendoHdrTblByKeyBLInput();
                hdrByKeyInput.KaikeiNo = input.KaikeiRendoHdrTblDataTable[0].KaikeiNo;
                IGetKaikeiRendoHdrTblByKeyBLOutput hdrByKeyOutput = new GetKaikeiRendoHdrTblByKeyBusinessLogic().Execute(hdrByKeyInput);

                if (hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].UpdateDt != input.KaikeiRendoHdrTblDataTable[0].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 伺書作成回数 
                hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].UkagaiMakeCnt = input.KaikeiRendoHdrTblDataTable[0].UkagaiMakeCnt;

                // 更新日
                hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();

                // 更新者
                hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                // 更新端末
                hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].UpdateTarm = Dns.GetHostName();

                IUpdateKaikeiRendoHdrTblBLInput updateHdrInput = new UpdateKaikeiRendoHdrTblBLInput();
                updateHdrInput.KaikeiRendoHdrTblDataTable = hdrByKeyOutput.KaikeiRendoHdrTblDataTable;
                IUpdateKaikeiRendoHdrTblBLOutput updateHdrOutput = new UpdateKaikeiRendoHdrTblBusinessLogic().Execute(updateHdrInput);

                // Get KaikeiRendoHdrTbl by key
                IGetKaikeiRendoHdrTblByKeyBLInput hdrInput = new GetKaikeiRendoHdrTblByKeyBLInput();
                hdrInput.KaikeiNo = updateHdrInput.KaikeiRendoHdrTblDataTable[0].KaikeiNo;
                output.KaikeiRendoHdrTblDT = new GetKaikeiRendoHdrTblByKeyBusinessLogic().Execute(hdrInput).KaikeiRendoHdrTblDataTable;

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
    }
    #endregion
}
