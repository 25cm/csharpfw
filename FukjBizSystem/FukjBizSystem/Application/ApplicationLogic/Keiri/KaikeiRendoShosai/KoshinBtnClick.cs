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
    //  インターフェイス名 ： IKoshinBtnClickALInput
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
    interface IKoshinBtnClickALInput : IBseALInput, IUpdateKaikeiRendoHdrTblBLInput, IUpdateKaikeiRendoDtlTblBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickALInput
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
    class KoshinBtnClickALInput : IKoshinBtnClickALInput
    {
        /// <summary>
        /// KaikeiRendoHdrTblDataTable
        /// </summary>
        public KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable KaikeiRendoHdrTblDataTable { get; set; }

        /// <summary>
        /// KaikeiRendoDtlTblDataTable
        /// </summary>
        public KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblDataTable KaikeiRendoDtlTblDT { get; set; }

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
    //  インターフェイス名 ： IKoshinBtnClickALOutput
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
    interface IKoshinBtnClickALOutput : IGetKaikeiRendoShosaiByKaikeiNoBLOutput, IGetKaikeiRendoHdrTblByKeyBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickALOutput
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
    class KoshinBtnClickALOutput : IKoshinBtnClickALOutput
    {
        /// <summary>
        /// KaikeiRendoShosaiDataTable
        /// </summary>
        public KaikeiRendoHdrTblDataSet.KaikeiRendoShosaiDataTable KaikeiRendoShosaiDT { get; set; }

        /// <summary>
        /// KaikeiRendoHdrTblDataTable
        /// </summary>
        public KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable KaikeiRendoHdrTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickApplicationLogic
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
    class KoshinBtnClickApplicationLogic : BaseApplicationLogic<IKoshinBtnClickALInput, IKoshinBtnClickALOutput>
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
        private const string FunctionName = "KaikeiRendoList：KoshinBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KoshinBtnClickApplicationLogic
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
        public KoshinBtnClickApplicationLogic()
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
        public override IKoshinBtnClickALOutput Execute(IKoshinBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKoshinBtnClickALOutput output = new KoshinBtnClickALOutput();

            try
            {
                StartTransaction();

                #region update KaikeiRendoHdrTbl

                IGetKaikeiRendoHdrTblByKeyBLInput hdrByKeyInput = new GetKaikeiRendoHdrTblByKeyBLInput();
                hdrByKeyInput.KaikeiNo = input.KaikeiRendoHdrTblDataTable[0].KaikeiNo;
                IGetKaikeiRendoHdrTblByKeyBLOutput hdrByKeyOutput = new GetKaikeiRendoHdrTblByKeyBusinessLogic().Execute(hdrByKeyInput);

                if (hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].UpdateDt != input.KaikeiRendoHdrTblDataTable[0].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 承認フラグ 
                hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].SyoninFlg = input.KaikeiRendoHdrTblDataTable[0].SyoninFlg;

                // 更新日
                hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();

                // 更新者
                hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                // 更新端末
                hdrByKeyOutput.KaikeiRendoHdrTblDataTable[0].UpdateTarm = Dns.GetHostName();

                IUpdateKaikeiRendoHdrTblBLInput updateHdrInput = new UpdateKaikeiRendoHdrTblBLInput();
                updateHdrInput.KaikeiRendoHdrTblDataTable = hdrByKeyOutput.KaikeiRendoHdrTblDataTable;
                IUpdateKaikeiRendoHdrTblBLOutput updateHdrOutput = new UpdateKaikeiRendoHdrTblBusinessLogic().Execute(updateHdrInput);

                #endregion


                #region update KaikeiRendoDtlTbl

                KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblDataTable dtlUpdateDT = new KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblDataTable();

                foreach (KaikeiRendoDtlTblDataSet.KaikeiRendoDtlTblRow dtlRow in input.KaikeiRendoDtlTblDT)
                {
                    IGetKaikeiRendoDtlTblByKeyBLInput dtlByKeyInput = new GetKaikeiRendoDtlTblByKeyBLInput();
                    dtlByKeyInput.KaikeiNo      = dtlRow.KaikeiNo;
                    dtlByKeyInput.KeikeiRenban  = dtlRow.KeikeiRenban;
                    IGetKaikeiRendoDtlTblByKeyBLOutput dtlByKeyOutput = new GetKaikeiRendoDtlTblByKeyBusinessLogic().Execute(dtlByKeyInput);

                    // 出力区分
                    dtlByKeyOutput.KaikeiRendoDtlTblDT[0].OutputKbn = dtlRow.OutputKbn;

                    // 更新日
                    dtlByKeyOutput.KaikeiRendoDtlTblDT[0].UpdateDt = updateHdrInput.KaikeiRendoHdrTblDataTable[0].UpdateDt;

                    // 更新者
                    dtlByKeyOutput.KaikeiRendoDtlTblDT[0].UpdateUser = updateHdrInput.KaikeiRendoHdrTblDataTable[0].UpdateUser;

                    // 更新端末
                    dtlByKeyOutput.KaikeiRendoDtlTblDT[0].UpdateTarm = updateHdrInput.KaikeiRendoHdrTblDataTable[0].UpdateTarm;

                    dtlUpdateDT.ImportRow(dtlByKeyOutput.KaikeiRendoDtlTblDT[0]);
                }
                
                IUpdateKaikeiRendoDtlTblBLInput updateDtlInput = new UpdateKaikeiRendoDtlTblBLInput();
                updateDtlInput.KaikeiRendoDtlTblDT = dtlUpdateDT;
                IUpdateKaikeiRendoDtlTblBLOutput updateDtlOutput = new UpdateKaikeiRendoDtlTblBusinessLogic().Execute(updateDtlInput);

                #endregion


                #region search

                IGetKaikeiRendoShosaiByKaikeiNoBLInput displayInput = new GetKaikeiRendoShosaiByKaikeiNoBLInput();
                displayInput.KaikeiNo = updateHdrInput.KaikeiRendoHdrTblDataTable[0].KaikeiNo;
                output.KaikeiRendoShosaiDT = new GetKaikeiRendoShosaiByKaikeiNoBusinessLogic().Execute(displayInput).KaikeiRendoShosaiDT;

                IGetKaikeiRendoHdrTblByKeyBLInput hdrInput = new GetKaikeiRendoHdrTblByKeyBLInput();
                hdrInput.KaikeiNo = updateHdrInput.KaikeiRendoHdrTblDataTable[0].KaikeiNo;
                output.KaikeiRendoHdrTblDataTable = new GetKaikeiRendoHdrTblByKeyBusinessLogic().Execute(hdrInput).KaikeiRendoHdrTblDataTable;

                #endregion

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
