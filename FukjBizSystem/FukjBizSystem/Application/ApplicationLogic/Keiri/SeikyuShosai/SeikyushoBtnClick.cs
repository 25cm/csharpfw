using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuList;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISeikyushoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISeikyushoBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// SeikyusyoKagamiHdrTblDataTable
        /// </summary>
        SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable KagamiHdrDT { get; set; }

        /// <summary>
        /// PrinterName
        /// </summary>
        string PrinterName { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyushoBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SeikyushoBtnClickALInput : ISeikyushoBtnClickALInput
    {
        /// <summary>
        /// SeikyusyoKagamiHdrTblDataTable
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable KagamiHdrDT { get; set; }

        /// <summary>
        /// PrinterName
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("親請求No [{0}], PrinterName[{1}]", KagamiHdrDT[0].OyaSeikyuNo, PrinterName);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISeikyushoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISeikyushoBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyushoBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SeikyushoBtnClickALOutput : ISeikyushoBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SeikyushoBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SeikyushoBtnClickApplicationLogic : BaseApplicationLogic<ISeikyushoBtnClickALInput, ISeikyushoBtnClickALOutput>
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
        private const string FunctionName = "SeikyuShosai：SeikyushoBtnClickApplicationLogic";

        /// <summary>
        /// Login User
        /// </summary>
        string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// PC Update
        /// </summary>
        string pcUpdate = Dns.GetHostName();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SeikyushoBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SeikyushoBtnClickApplicationLogic()
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
        /// 2014/10/03  DatNT　  新規作成
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
        /// 2014/10/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISeikyushoBtnClickALOutput Execute(ISeikyushoBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISeikyushoBtnClickALOutput output = new SeikyushoBtnClickALOutput();

            try
            {
                #region Print

                List<string> oyaSeikyuNoList = new List<string>();

                oyaSeikyuNoList.Add(input.KagamiHdrDT[0].OyaSeikyuNo);

                // Print SeikyuSho (009)
                IPrintSeikyuShoBLInput seikyuShoInput = new PrintSeikyuShoBLInput();
                seikyuShoInput.AfterPrintFlg = true;
                seikyuShoInput.PrinterName = input.PrinterName;
                seikyuShoInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SeikyuShoFormatFile;
                seikyuShoInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                seikyuShoInput.SeikyuNoList = oyaSeikyuNoList;
                new PrintSeikyuShoBusinessLogic().Execute(seikyuShoInput);

                #endregion

                #region Update

                try
                {
                    StartTransaction();

                    DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

                    IGetSeikyusyoKagamiHdrTblByKeyBLInput blInput = new GetSeikyusyoKagamiHdrTblByKeyBLInput();
                    blInput.OyaSeikyuNo = input.KagamiHdrDT[0].OyaSeikyuNo;
                    IGetSeikyusyoKagamiHdrTblByKeyBLOutput blOutput = new GetSeikyusyoKagamiHdrTblByKeyBusinessLogic().Execute(blInput);

                    if (blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateDt != input.KagamiHdrDT[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    // 請求書発行フラグ
                    blOutput.SeikyusyoKagamiHdrTblDataTable[0].SeikyusyoHakkoFlg = "1";

                    blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateDt = now;

                    blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateTarm = pcUpdate;

                    blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateUser = loginUser;

                    IUpdateSeikyusyoKagamiHdrTblBLInput updateHdrInput = new UpdateSeikyusyoKagamiHdrTblBLInput();
                    updateHdrInput.SeikyusyoKagamiHdrTblDataTable = blOutput.SeikyusyoKagamiHdrTblDataTable;
                    new UpdateSeikyusyoKagamiHdrTblBusinessLogic().Execute(updateHdrInput);

                    UpdateKensaIraiTbl(input, now);

                    UpdateKeiryoShomeiIraiTbl(input, now);

                    CompleteTransaction();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    EndTransaction();
                }                

                #endregion
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region UpdateKensaIraiTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateKensaIraiTbl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateKensaIraiTbl(ISeikyushoBtnClickALInput input, DateTime now)
        {
            IUpdateKensaIraiSeikyuShosaiPrintBLInput updateInput = new UpdateKensaIraiSeikyuShosaiPrintBLInput();
            updateInput.KensaIraiSeikyuKbn  = "2";
            updateInput.Now                 = now;
            updateInput.LoginUser           = loginUser;
            updateInput.PcUpdate            = pcUpdate;
            updateInput.OyaSeikyuNo         = input.KagamiHdrDT[0].OyaSeikyuNo;
            new UpdateKensaIraiSeikyuShosaiPrintBusinessLogic().Execute(updateInput);
        }
        #endregion

        #region UpdateKeiryoShomeiIraiTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateKeiryoShomeiIraiTbl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateKeiryoShomeiIraiTbl(ISeikyushoBtnClickALInput input, DateTime now)
        {
            IUpdateKeiryoShomeiSeikyuShosaiPrintBLInput updateInput = new UpdateKeiryoShomeiSeikyuShosaiPrintBLInput();
            updateInput.KeiryoShomeiSeikyuKbn   = "2";
            updateInput.Now                     = now;
            updateInput.LoginUser               = loginUser;
            updateInput.PcUpdate                = pcUpdate;
            updateInput.OyaSeikyuNo             = input.KagamiHdrDT[0].OyaSeikyuNo;
            new UpdateKeiryoShomeiSeikyuShosaiPrintBusinessLogic().Execute(updateInput);
        }
        #endregion

        #endregion
    }
    #endregion
}
