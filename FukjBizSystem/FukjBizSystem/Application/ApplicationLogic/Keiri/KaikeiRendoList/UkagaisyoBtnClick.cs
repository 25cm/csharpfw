using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiRendoList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.KaikeiRendoList
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
    /// 2014/09/15  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUkagaisyoBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// KaikeiRendoHdrTblKensakuRow
        /// </summary>
        KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuRow KaikeiRendoHdrTblKensakuRow { get; set; }
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
    /// 2014/09/15  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UkagaisyoBtnClickALInput : IUkagaisyoBtnClickALInput
    {
        /// <summary>
        /// KaikeiRendoHdrTblKensakuRow
        /// </summary>
        public KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuRow KaikeiRendoHdrTblKensakuRow { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("会計No[{0}]", KaikeiRendoHdrTblKensakuRow.KaikeiNo);
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
    /// 2014/09/15  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUkagaisyoBtnClickALOutput
    {
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
    /// 2014/09/15  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UkagaisyoBtnClickALOutput : IUkagaisyoBtnClickALOutput
    {
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
    /// 2014/09/15  HuyTX　　    新規作成
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
        private const string FunctionName = "KaikeiRendoList：UkagaisyoBtnClick";

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
        /// 2014/09/15  HuyTX　　    新規作成
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
        /// 2014/09/15  HuyTX　　    新規作成
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
        /// 2014/09/15  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUkagaisyoBtnClickALOutput Execute(IUkagaisyoBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUkagaisyoBtnClickALOutput output = new UkagaisyoBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                //print SuitouUkagaisho
                IPrintSuitouUkagaishoBLInput blInput = new PrintSuitouUkagaishoBLInput();
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SuitouUkagaishoFormatFile;
                blInput.AfterDispFlg = true;
                blInput.KaikeiRendoHdrTblKensakuRow = input.KaikeiRendoHdrTblKensakuRow;

                new PrintSuitouUkagaishoBusinessLogic().Execute(blInput);

                //update KaikeiRendoHdrTbl
                UpdateKaikeiRendoHdr(input.KaikeiRendoHdrTblKensakuRow);

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

        #region UpdateKaikeiRendoHdr
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateKaikeiRendoHdr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kaikeiRendoHdrRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateKaikeiRendoHdr(KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblKensakuRow kaikeiRendoHdrRow)
        {
            IGetKaikeiRendoHdrTblByKeyBLInput getKaikeiHdrBLInput = new GetKaikeiRendoHdrTblByKeyBLInput();
            getKaikeiHdrBLInput.KaikeiNo = kaikeiRendoHdrRow.KaikeiNo;
            IGetKaikeiRendoHdrTblByKeyBLOutput getKaikeiHdrBLOutput = new GetKaikeiRendoHdrTblByKeyBusinessLogic().Execute(getKaikeiHdrBLInput);

            if (getKaikeiHdrBLOutput.KaikeiRendoHdrTblDataTable.Count == 0) return;

            if (kaikeiRendoHdrRow.UpdateDt != getKaikeiHdrBLOutput.KaikeiRendoHdrTblDataTable[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            //伺書作成回数 
            getKaikeiHdrBLOutput.KaikeiRendoHdrTblDataTable[0].UkagaiMakeCnt = getKaikeiHdrBLOutput.KaikeiRendoHdrTblDataTable[0].UkagaiMakeCnt + 1;

            //更新日
            getKaikeiHdrBLOutput.KaikeiRendoHdrTblDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();

            //更新者
            getKaikeiHdrBLOutput.KaikeiRendoHdrTblDataTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            //更新端末
            getKaikeiHdrBLOutput.KaikeiRendoHdrTblDataTable[0].UpdateTarm = Dns.GetHostName();

            IUpdateKaikeiRendoHdrTblBLInput updateBLInput = new UpdateKaikeiRendoHdrTblBLInput();
            updateBLInput.KaikeiRendoHdrTblDataTable = getKaikeiHdrBLOutput.KaikeiRendoHdrTblDataTable;
            new UpdateKaikeiRendoHdrTblBusinessLogic().Execute(updateBLInput);

        }
        #endregion

        #endregion
    }
    #endregion
}
