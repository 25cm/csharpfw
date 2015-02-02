using System;
using System.Data;
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
    //  インターフェイス名 ： IUpdateBtnClickALInput
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
    interface IUpdateBtnClickALInput : IBseALInput, IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput
    {
        /// <summary>
        /// UpdateCheck
        /// </summary>
        bool UpdateCheck { get; set; }

        /// <summary>
        /// UpdateType
        /// </summary>
        int UpdateType { get; set; }

        /// <summary>
        /// IsGyosha
        /// </summary>
        bool IsGyosha { get; set; }

        /// <summary>
        /// 請求ヘッダテーブル
        /// </summary>
        SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }

        /// <summary>
        /// 請求ヘッダテーブル Insert
        /// </summary>
        SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblInsertDT { get; set; }

        /// <summary>
        /// SeikyuDtlTblDataTable
        /// </summary>
        SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }

        /// <summary>
        /// SeikyusyoKagamiHdrTblDataTable
        /// </summary>
        SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable KagamiHdrDT { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateBtnClickALInput
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
    class UpdateBtnClickALInput : IUpdateBtnClickALInput
    {
        /// <summary>
        /// 親請求No
        /// </summary>
        public string OyaSeikyuNo { get; set; }

        /// <summary>
        /// UpdateCheck
        /// </summary>
        public bool UpdateCheck { get; set; }

        /// <summary>
        /// UpdateType
        /// </summary>
        public int UpdateType { get; set; }

        /// <summary>
        /// IsGyosha
        /// </summary>
        public bool IsGyosha { get; set; }

        /// <summary>
        /// 請求ヘッダテーブル
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }

        /// <summary>
        /// 請求ヘッダテーブル Insert
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblInsertDT { get; set; }

        /// <summary>
        /// SeikyuDtlTblDataTable
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }

        /// <summary>
        /// SeikyusyoKagamiHdrTblDataTable
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable KagamiHdrDT { get; set; }
        
        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("UpdateCheck[{1}]", 
                    new string[] {
                        UpdateCheck.ToString()
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateBtnClickALOutput
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
    interface IUpdateBtnClickALOutput : IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput, IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput
    {
        /// <summary>
        /// UpdateCheckOutput
        /// </summary>
        bool UpdateCheckOutput { get; set; }

        /// <summary>
        /// UnCompletedUpdate
        /// </summary>
        string UnCompletedUpdate { get; set; }

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateBtnClickALOutput
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
    class UpdateBtnClickALOutput : IUpdateBtnClickALOutput
    {
        /// <summary>
        /// UpdateCheckOutput
        /// </summary>
        public bool UpdateCheckOutput { get; set; }

        /// <summary>
        /// SeikyuShosaiFormLoadHdrDataTable
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrDataTable SeikyuShosaiFormLoadHdrDT { get; set; }

        /// <summary>
        /// SeikyuShosaiFormLoadDtlDataTable
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlDataTable SeikyuShosaiFormLoadDtlDT { get; set; }

        /// <summary>
        /// UnCompletedUpdate
        /// </summary>
        public string UnCompletedUpdate { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateBtnClickApplicationLogic
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
    class UpdateBtnClickApplicationLogic : BaseApplicationLogic<IUpdateBtnClickALInput, IUpdateBtnClickALOutput>
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
        private const string FunctionName = "SeikyuShosai：UpdateBtnClickApplicationLogic";

        /// <summary>
        /// Login User
        /// </summary>
        string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// PC Update
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        /// <summary>
        /// SeikyuNo
        /// </summary>
        private string _seikyuNo = string.Empty;

        /// <summary>
        /// Deleted DgvRow
        /// </summary>
        private bool _isDelDgvRow = false;

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateBtnClickApplicationLogic
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
        public UpdateBtnClickApplicationLogic()
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
        public override IUpdateBtnClickALOutput Execute(IUpdateBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateBtnClickALOutput output = new UpdateBtnClickALOutput();

            try
            {
                StartTransaction();

                if (input.UpdateCheck)
                {
                    IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput blOuput = new GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBusinessLogic().Execute(input);

                    if (blOuput.SeikyuShosaiFormLoadHdrDT != null && blOuput.SeikyuShosaiFormLoadHdrDT.Count > 0)
                    {
                        if (!blOuput.SeikyuShosaiFormLoadHdrDT[0].IsNyukinTotalNull() && blOuput.SeikyuShosaiFormLoadHdrDT[0].NyukinTotal > 0)
                        {
                            output.UpdateCheckOutput = false;
                        }
                        else
                        {
                            output.UpdateCheckOutput = true;
                        }
                    }
                    else
                    {
                        output.UpdateCheckOutput = false;
                    }

                    output.SeikyuShosaiFormLoadHdrDT = blOuput.SeikyuShosaiFormLoadHdrDT;


                    IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput dtlInput = new GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput();
                    dtlInput.OyaSeikyuNo = input.OyaSeikyuNo;
                    output.SeikyuShosaiFormLoadDtlDT = new GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBusinessLogic().Execute(dtlInput).SeikyuShosaiFormLoadDtlDT;
                }
                else
                {
                    DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

                    // Update 請求書鑑ヘッダテーブル
                    UpdateKagamiHdr(input, now);

                    _isDelDgvRow = IsDeleteDgvRow(input);

                    if (input.UpdateType == 0)
                    {
                        // Update SeikyuHdrTbl
                        UpdateSeikyuHdr(input, now, string.Empty);
                    }
                    else
                    {
                        // 消費税率
                        decimal zeiritsu = Boundary.Common.Common.GetSyohizei(now.ToString("yyyyMMdd"));

                        if (CheckFlg(input))
                        {
                            // DELETE - INSERT SeikyuDtlTbl
                            DeleteInsertSeikyuDtlTbl(input, now, _seikyuNo);

                            // Update SeikyuHdrTbl
                            UpdateSeikyuHdr(input, now, _seikyuNo);
                        }
                        else
                        {
                            // Insert SeikyuDtl
                            InsertSeikyuDtlTbl(input, now);

                            // Insert SeikyuHdrTbl
                            InsertSeikyuHdrTbl(input, now);
                        }

                        // DELETE - INSERT SeikysyoKagamiTbl
                        DeleteInsertSeikyusyoKagamiTbl(input, now, zeiritsu);
                    }

                    // Update KensaIraiTbl
                    UpdateKensaIraiTbl(input, now);

                    // Update KeiryoShomeiIraiTbl
                    UpdateKeiryoShomeiIraiTbl(input, now);
                }

                CompleteTransaction();
            }
            catch (Exception e)
            {
                throw e;
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

        #region CreateDtlDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDtlDT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtlDT"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuDtlTblDataSet.SeikyuDtlTblDataTable CreateDtlDT(
            SeikyuDtlTblDataSet.SeikyuDtlTblDataTable dtlDT,
            DateTime now)
        {
            foreach (SeikyuDtlTblDataSet.SeikyuDtlTblRow dtlRow in dtlDT)
            {
                dtlRow.UpdateDt = now;
                dtlRow.InsertDt = now;
            }

            return dtlDT;
        }
        #endregion

        #region CreateHdrDT
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHdrDT
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuHdrTblDataSet.SeikyuHdrTblDataTable CreateHdrDT(
            SeikyuHdrTblDataSet.SeikyuHdrTblDataTable hdrDT)
        {
            //IGetSeikyuDtlTblBySeikyuNoBLInput blInput = new GetSeikyuDtlTblBySeikyuNoBLInput();
            //blInput.SeikyuNo = hdrDT[0].SeikyuNo;
            //IGetSeikyuDtlTblBySeikyuNoBLOutput blOutput = new GetSeikyuDtlTblBySeikyuNoBusinessLogic().Execute(blInput);

            //decimal seikyuGaku = 0;
            //decimal kurikoshiKingaku = 0;
            //decimal seikyuTotal = 0;

            //if (blOutput.SeikyuDtlTblDT != null && blOutput.SeikyuDtlTblDT.Count > 0)
            //{
            //    foreach (SeikyuDtlTblDataSet.SeikyuDtlTblRow row in blOutput.SeikyuDtlTblDT)
            //    {
            //        if (row.IsSeikyuGakuNull() || row.SeikyuGaku >= 0)
            //        {
            //            seikyuGaku += row.IsSeikyuGakuNull() ? 0 : row.SeikyuGaku;
            //        }
            //        else
            //        {
            //            kurikoshiKingaku += row.SeikyuGaku;
            //        }

            //        seikyuTotal += row.IsSeikyuKingakuKeiNull() ? 0 : row.SeikyuKingakuKei;
            //    }
            //}

            //// 請求合計金額
            //hdrDT[0].SeikyuTotal = seikyuTotal;

            //// 請求金額 
            //hdrDT[0].SeikyuKingaku = seikyuGaku;

            //// 繰り越し等合計
            //hdrDT[0].KurikoshiKingaku = kurikoshiKingaku;

            return hdrDT;
        }
        #endregion
        
        #region UpdateKagamiHdr
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateKagamiHdr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="now"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateKagamiHdr(IUpdateBtnClickALInput input, DateTime now)
        {
            IGetSeikyusyoKagamiHdrTblByKeyBLInput blInput = new GetSeikyusyoKagamiHdrTblByKeyBLInput();
            blInput.OyaSeikyuNo = input.KagamiHdrDT[0].OyaSeikyuNo;
            IGetSeikyusyoKagamiHdrTblByKeyBLOutput blOutput = new GetSeikyusyoKagamiHdrTblByKeyBusinessLogic().Execute(blInput);

            if (blOutput.SeikyusyoKagamiHdrTblDataTable != null && blOutput.SeikyusyoKagamiHdrTblDataTable.Count > 0)
            {
                if (blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateDt != input.KagamiHdrDT[0].UpdateDt)
                {
                    // 更新されている場合は、他のユーザから更新されていると判断し、楽観ロックエラーで例外を発生
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 請求先名称
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].SeikyusakiNm = input.KagamiHdrDT[0].SeikyusakiNm;

                // 請求先郵便番号
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].SeikyusakisakiZipCd = input.KagamiHdrDT[0].SeikyusakisakiZipCd;

                // 請求先住所
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].SeikyusakiAdr = input.KagamiHdrDT[0].SeikyusakiAdr;

                // 請求先電話番号
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].SekyusakiTel = input.KagamiHdrDT[0].SekyusakiTel;

                // 請求日
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].SeikyuDt = input.KagamiHdrDT[0].SeikyuDt;

                // 請求金額合計
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].SeikyuKingaku = input.KagamiHdrDT[0].SeikyuKingaku;

                blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateDt = now;
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateTarm = input.KagamiHdrDT[0].UpdateTarm;
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateUser = input.KagamiHdrDT[0].UpdateUser;

                IUpdateSeikyusyoKagamiHdrTblBLInput updateInput = new UpdateSeikyusyoKagamiHdrTblBLInput();
                updateInput.SeikyusyoKagamiHdrTblDataTable = blOutput.SeikyusyoKagamiHdrTblDataTable;
                new UpdateSeikyusyoKagamiHdrTblBusinessLogic().Execute(updateInput);
            }
        }
        #endregion
                
        #region UpdateSeikyuHdr
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateSeikyuHdr
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="now"></param>
        /// <param name="seikyuNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateSeikyuHdr(IUpdateBtnClickALInput input, DateTime now, string seikyuNo)
        {
            foreach (SeikyuHdrTblDataSet.SeikyuHdrTblRow row in input.SeikyuHdrTblDT)
            {
                IGetSeikyuHdrTblByKeyBLInput hdrInput = new GetSeikyuHdrTblByKeyBLInput();
                hdrInput.SeikyuNo = row.SeikyuNo;
                IGetSeikyuHdrTblByKeyBLOutput hdrOutput = new GetSeikyuHdrTblByKeyBusinessLogic().Execute(hdrInput);

                if (hdrOutput.SeikyuHdrTblDataTable[0].UpdateDt != row.UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 請求先名称
                hdrOutput.SeikyuHdrTblDataTable[0].SeikyusakiNm = row.SeikyusakiNm;

                // 請求日
                hdrOutput.SeikyuHdrTblDataTable[0].SeikyuDt = row.SeikyuDt;

                hdrOutput.SeikyuHdrTblDataTable[0].UpdateDt = now;

                hdrOutput.SeikyuHdrTblDataTable[0].UpdateTarm = pcUpdate;

                hdrOutput.SeikyuHdrTblDataTable[0].UpdateUser = loginUser;

                if (_isDelDgvRow || row.SeikyuNo == seikyuNo)
                {
                    decimal seikyuKingaku = 0;
                    decimal kurikoshiKingaku = 0;
                    decimal seikyuTotal = 0;

                    IGetSeikyuDtlTblBySeikyuNoBLInput dtlInput = new GetSeikyuDtlTblBySeikyuNoBLInput();
                    dtlInput.SeikyuNo = row.SeikyuNo;
                    IGetSeikyuDtlTblBySeikyuNoBLOutput dtlOutput = new GetSeikyuDtlTblBySeikyuNoBusinessLogic().Execute(dtlInput);

                    if (dtlOutput.SeikyuDtlTblDT != null && dtlOutput.SeikyuDtlTblDT.Count > 0)
                    {
                        foreach (SeikyuDtlTblDataSet.SeikyuDtlTblRow dtlRow in dtlOutput.SeikyuDtlTblDT)
                        {
                            seikyuKingaku += (!dtlRow.IsSeikyuGakuNull() && dtlRow.SeikyuGaku >= 0) ? dtlRow.SeikyuGaku : 0;

                            kurikoshiKingaku += (!dtlRow.IsSeikyuGakuNull() && dtlRow.SeikyuGaku < 0) ? dtlRow.SeikyuGaku : 0;

                            seikyuTotal += !dtlRow.IsSeikyuKingakuKeiNull() ? dtlRow.SeikyuKingakuKei : 0;
                        }
                    }

                    hdrOutput.SeikyuHdrTblDataTable[0].SeikyuKingaku = seikyuKingaku;

                    hdrOutput.SeikyuHdrTblDataTable[0].KurikoshiKingaku = kurikoshiKingaku;

                    hdrOutput.SeikyuHdrTblDataTable[0].SeikyuTotal = seikyuTotal;
                }

                IUpdateSeikyuHdrTblBLInput updateInput = new UpdateSeikyuHdrTblBLInput();
                updateInput.SeikyuHdrTblDataTable = hdrOutput.SeikyuHdrTblDataTable;
                new UpdateSeikyuHdrTblBusinessLogic().Execute(updateInput);
            }
            
        }
        #endregion

        #region DeleteInsertSeikyusyoKagamiTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteInsertSeikyusyoKagamiTbl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="now"></param>
        /// <param name="zeiritsu"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DeleteInsertSeikyusyoKagamiTbl(IUpdateBtnClickALInput input, DateTime now, decimal zeiritsu)
        {
            // Delete SeikyusyoKagamiTbl By Key
            IDeleteSeikyusyoKagamiTblByKeyBLInput delKagami008Input = new DeleteSeikyusyoKagamiTblByKeyBLInput();
            delKagami008Input.OyaSeikyuNo       = input.KagamiHdrDT[0].OyaSeikyuNo;
            delKagami008Input.KagamiMeisaiNo    = "008";
            new DeleteSeikyusyoKagamiTblByKeyBusinessLogic().Execute(delKagami008Input);

            IDeleteSeikyusyoKagamiTblByKeyBLInput delKagami009Input = new DeleteSeikyusyoKagamiTblByKeyBLInput();
            delKagami009Input.OyaSeikyuNo       = input.KagamiHdrDT[0].OyaSeikyuNo;
            delKagami009Input.KagamiMeisaiNo    = "009";
            new DeleteSeikyusyoKagamiTblByKeyBusinessLogic().Execute(delKagami009Input);

            IDeleteSeikyusyoKagamiTblByKeyBLInput delKagami010Input = new DeleteSeikyusyoKagamiTblByKeyBLInput();
            delKagami010Input.OyaSeikyuNo       = input.KagamiHdrDT[0].OyaSeikyuNo;
            delKagami010Input.KagamiMeisaiNo    = "010";
            new DeleteSeikyusyoKagamiTblByKeyBusinessLogic().Execute(delKagami010Input);
            
            // Insert SeikyusyoKagamiTbl with KagamiMeisaiNo = 008
            IInsertSeikyuShosaiKagami008BLInput insert008Input = new InsertSeikyuShosaiKagami008BLInput();
            insert008Input.Now          = now;
            insert008Input.LoginUser    = loginUser;
            insert008Input.PcUpdate     = pcUpdate;
            insert008Input.OyaSeikyuNo  = input.KagamiHdrDT[0].OyaSeikyuNo;
            new InsertSeikyuShosaiKagami008BusinessLogic().Execute(insert008Input);

            // Insert SeikyusyoKagamiTbl with KagamiMeisaiNo = 009
            IInsertSeikyuShosaiKagami009BLInput insert009Input = new InsertSeikyuShosaiKagami009BLInput();
            insert009Input.LoginUser    = loginUser;
            insert009Input.Now          = now;
            insert009Input.OyaSeikyuNo  = input.KagamiHdrDT[0].OyaSeikyuNo;
            insert009Input.PcUpdate     = pcUpdate;
            insert009Input.Zeiritsu     = zeiritsu;
            new InsertSeikyuShosaiKagami009BusinessLogic().Execute(insert009Input);

            // Insert SeikyusyoKagamiTbl with KagamiMeisaiNo = 010
            IInsertSeikyuShosaiKagami010BLInput insert010Input = new InsertSeikyuShosaiKagami010BLInput();
            insert010Input.LoginUser    = loginUser;
            insert010Input.Now          = now;
            insert010Input.OyaSeikyuNo  = input.KagamiHdrDT[0].OyaSeikyuNo;
            insert010Input.PcUpdate     = pcUpdate;
            new InsertSeikyuShosaiKagami010BusinessLogic().Execute(insert010Input);
        }
        #endregion

        #region DeleteInsertSeikyuDtlTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteInsertSeikyuDtlTbl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="now"></param>
        /// <param name="seikyuNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DeleteInsertSeikyuDtlTbl(IUpdateBtnClickALInput input, DateTime now, string seikyuNo)
        {
            foreach (SeikyuHdrTblDataSet.SeikyuHdrTblRow row in input.SeikyuHdrTblDT)
            {
                // Delete
                IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput delInput = new DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput();
                delInput.SeikyuNo           = row.SeikyuNo;
                delInput.SeikyuKomokuKbn    = "9";
                new DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic().Execute(delInput);
            }

            // Insert            
            foreach (SeikyuDtlTblDataSet.SeikyuDtlTblRow dtlRow in input.SeikyuDtlTblDT)
            {
                SeikyuDtlTblDataSet.SeikyuDtlTblDataTable insertDT = new SeikyuDtlTblDataSet.SeikyuDtlTblDataTable();

                if (!string.IsNullOrEmpty(dtlRow.SeikyuNo))
                {
                    IGetMaxSeikyuRenbanBySeikyuNoBLInput renbanInput = new GetMaxSeikyuRenbanBySeikyuNoBLInput();
                    renbanInput.SeikyuNo = dtlRow.SeikyuNo;
                    IGetMaxSeikyuRenbanBySeikyuNoBLOutput renbanOutput = new GetMaxSeikyuRenbanBySeikyuNoBusinessLogic().Execute(renbanInput);

                    dtlRow.SeikyuRenban = renbanOutput.SeikyuRenban + 1;

                    dtlRow.InsertDt = now;

                    dtlRow.UpdateDt = now;

                    insertDT.ImportRow(dtlRow);

                    IUpdateSeikyuDtlTblBLInput insertInput = new UpdateSeikyuDtlTblBLInput();
                    insertInput.SeikyuDtlTblDT = insertDT;
                    new UpdateSeikyuDtlTblBusinessLogic().Execute(insertInput);
                }
                else
                {
                    insertDT = new SeikyuDtlTblDataSet.SeikyuDtlTblDataTable();

                    IGetMaxSeikyuRenbanBySeikyuNoBLInput renbanInput = new GetMaxSeikyuRenbanBySeikyuNoBLInput();
                    renbanInput.SeikyuNo = seikyuNo;
                    IGetMaxSeikyuRenbanBySeikyuNoBLOutput renbanOutput = new GetMaxSeikyuRenbanBySeikyuNoBusinessLogic().Execute(renbanInput);

                    dtlRow.SeikyuRenban = renbanOutput.SeikyuRenban + 1;

                    dtlRow.SeikyuNo = seikyuNo;

                    dtlRow.InsertDt = now;

                    dtlRow.UpdateDt = now;

                    insertDT.ImportRow(dtlRow);

                    IUpdateSeikyuDtlTblBLInput insertInput = new UpdateSeikyuDtlTblBLInput();
                    insertInput.SeikyuDtlTblDT = insertDT;
                    new UpdateSeikyuDtlTblBusinessLogic().Execute(insertInput);
                }
            }
        }
        #endregion

        #region InsertSeikyuDtlTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteInsertSeikyuDtlTbl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="now"></param>
        /// <param name="seikyuNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void InsertSeikyuDtlTbl(IUpdateBtnClickALInput input, DateTime now)
        {
            foreach (SeikyuHdrTblDataSet.SeikyuHdrTblRow row in input.SeikyuHdrTblDT)
            {
                // Delete
                IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput delInput = new DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBLInput();
                delInput.SeikyuNo = row.SeikyuNo;
                delInput.SeikyuKomokuKbn = "9";
                new DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnBusinessLogic().Execute(delInput);
            }

            // Insert
            foreach (SeikyuDtlTblDataSet.SeikyuDtlTblRow dtlRow in input.SeikyuDtlTblDT)
            {
                SeikyuDtlTblDataSet.SeikyuDtlTblDataTable insertDT = new SeikyuDtlTblDataSet.SeikyuDtlTblDataTable();

                if (!string.IsNullOrEmpty(dtlRow.SeikyuNo))
                {
                    IGetMaxSeikyuRenbanBySeikyuNoBLInput renbanInput = new GetMaxSeikyuRenbanBySeikyuNoBLInput();
                    renbanInput.SeikyuNo = dtlRow.SeikyuNo;
                    IGetMaxSeikyuRenbanBySeikyuNoBLOutput renbanOutput = new GetMaxSeikyuRenbanBySeikyuNoBusinessLogic().Execute(renbanInput);

                    dtlRow.SeikyuRenban = renbanOutput.SeikyuRenban + 1;

                    dtlRow.InsertDt = now;

                    dtlRow.UpdateDt = now;

                    insertDT.ImportRow(dtlRow);

                    IUpdateSeikyuDtlTblBLInput insertInput = new UpdateSeikyuDtlTblBLInput();
                    insertInput.SeikyuDtlTblDT = insertDT;
                    new UpdateSeikyuDtlTblBusinessLogic().Execute(insertInput);
                }
                else
                {
                    insertDT = new SeikyuDtlTblDataSet.SeikyuDtlTblDataTable();

                    IGetMaxSeikyuRenbanBySeikyuNoBLInput renbanInput = new GetMaxSeikyuRenbanBySeikyuNoBLInput();
                    renbanInput.SeikyuNo = input.SeikyuHdrTblInsertDT[0].SeikyuNo;
                    IGetMaxSeikyuRenbanBySeikyuNoBLOutput renbanOutput = new GetMaxSeikyuRenbanBySeikyuNoBusinessLogic().Execute(renbanInput);

                    dtlRow.SeikyuRenban = renbanOutput.SeikyuRenban + 1;

                    dtlRow.SeikyuNo = input.SeikyuHdrTblInsertDT[0].SeikyuNo;

                    dtlRow.InsertDt = now;

                    dtlRow.UpdateDt = now;

                    insertDT.ImportRow(dtlRow);

                    IUpdateSeikyuDtlTblBLInput insertInput = new UpdateSeikyuDtlTblBLInput();
                    insertInput.SeikyuDtlTblDT = insertDT;
                    new UpdateSeikyuDtlTblBusinessLogic().Execute(insertInput);
                }
            }
        }
        #endregion

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
        private void UpdateKensaIraiTbl(IUpdateBtnClickALInput input, DateTime now)
        {
            IUpdateKensaIraiSeikyuShosaiBLInput updateInput = new UpdateKensaIraiSeikyuShosaiBLInput();
            updateInput.KensaIraiSeikyuKbn  = "1";
            updateInput.Now                 = now;
            updateInput.LoginUser           = loginUser;
            updateInput.PcUpdate            = pcUpdate;
            updateInput.OyaSeikyuNo         = input.KagamiHdrDT[0].OyaSeikyuNo;
            new UpdateKensaIraiSeikyuShosaiBusinessLogic().Execute(updateInput);
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
        private void UpdateKeiryoShomeiIraiTbl(IUpdateBtnClickALInput input, DateTime now)
        {
            IUpdateKeiryoShomeiSeikyuShosaiBLInput updateInput = new UpdateKeiryoShomeiSeikyuShosaiBLInput();
            updateInput.KeiryoShomeiSeikyuKbn   = "1";
            updateInput.Now                     = now;
            updateInput.LoginUser               = loginUser;
            updateInput.PcUpdate                = pcUpdate;
            updateInput.OyaSeikyuNo             = input.KagamiHdrDT[0].OyaSeikyuNo;
            new UpdateKeiryoShomeiSeikyuShosaiBusinessLogic().Execute(updateInput);
        }
        #endregion

        #region InsertSeikyuDtl
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： InsertSeikyuDtl
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <param name="now"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/12/16  DatNT    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void InsertSeikyuDtl(IUpdateBtnClickALInput input, DateTime now)
        //{
        //    int renban = 1;

        //    foreach (SeikyuDtlTblDataSet.SeikyuDtlTblRow row in input.SeikyuDtlTblDT)
        //    {
        //        row.SeikyuNo = input.SeikyuHdrTblInsertDT[0].SeikyuNo;

        //        row.SeikyuRenban = renban;

        //        row.InsertDt = now;

        //        row.UpdateDt = now;

        //        renban++;
        //    }

        //    IUpdateSeikyuDtlTblBLInput insertInput = new UpdateSeikyuDtlTblBLInput();
        //    insertInput.SeikyuDtlTblDT = input.SeikyuDtlTblDT;
        //    new UpdateSeikyuDtlTblBusinessLogic().Execute(insertInput);
        //}
        #endregion

        #region InsertSeikyuHdrTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： InsertSeikyuHdrTbl
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
        private void InsertSeikyuHdrTbl(IUpdateBtnClickALInput input, DateTime now)
        {
            decimal seikyuKingaku = 0;
            decimal kurikoshiKingaku = 0;
            decimal seikyuTotal = 0;

            IGetSeikyuDtlTblBySeikyuNoBLInput dtlInput = new GetSeikyuDtlTblBySeikyuNoBLInput();
            dtlInput.SeikyuNo = input.SeikyuHdrTblInsertDT[0].SeikyuNo;
            IGetSeikyuDtlTblBySeikyuNoBLOutput dtlOutput = new GetSeikyuDtlTblBySeikyuNoBusinessLogic().Execute(dtlInput);

            if (dtlOutput.SeikyuDtlTblDT != null && dtlOutput.SeikyuDtlTblDT.Count > 0)
            {
                foreach (SeikyuDtlTblDataSet.SeikyuDtlTblRow dtlRow in dtlOutput.SeikyuDtlTblDT)
                {
                    seikyuKingaku += (!dtlRow.IsSeikyuGakuNull() && dtlRow.SeikyuGaku >= 0) ? dtlRow.SeikyuGaku : 0;

                    kurikoshiKingaku += (!dtlRow.IsSeikyuGakuNull() && dtlRow.SeikyuGaku < 0) ? dtlRow.SeikyuGaku : 0;

                    seikyuTotal += !dtlRow.IsSeikyuKingakuKeiNull() ? dtlRow.SeikyuKingakuKei : 0;
                }
            }

            input.SeikyuHdrTblInsertDT[0].SeikyuKingaku = seikyuKingaku;

            input.SeikyuHdrTblInsertDT[0].KurikoshiKingaku = kurikoshiKingaku;

            input.SeikyuHdrTblInsertDT[0].SeikyuTotal = seikyuTotal;

            input.SeikyuHdrTblInsertDT[0].UpdateDt = now;

            input.SeikyuHdrTblInsertDT[0].InsertDt = now;

            IUpdateSeikyuHdrTblBLInput insertInput = new UpdateSeikyuHdrTblBLInput();
            insertInput.SeikyuHdrTblDataTable = input.SeikyuHdrTblInsertDT;
            new UpdateSeikyuHdrTblBusinessLogic().Execute(insertInput);
        }
        #endregion

        #region CheckFlg
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckFlg
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/22  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool CheckFlg(IUpdateBtnClickALInput input)
        {
            bool flg = false;

            if (input.IsGyosha)
            {
                IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLInput checkInput = new GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLInput();
                checkInput.SeikyusakiKbn    = input.KagamiHdrDT[0].SeikyusakiKbn;
                checkInput.SeikyuGyosyaCd   = input.KagamiHdrDT[0].IkkatsuSeikyuSakiCd;
                checkInput.OyaSeikyuNo      = input.KagamiHdrDT[0].OyaSeikyuNo;
                IGetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBLOutput checkOutput = new GetSeikyuHdrTblByOyaSeikyuNoKbnGyoshaCdBusinessLogic().Execute(checkInput);
                
                if (checkOutput.SeikyuHdrTblDT != null && checkOutput.SeikyuHdrTblDT.Count > 0)
                {
                    flg = true;
                    _seikyuNo = checkOutput.SeikyuHdrTblDT[0].SeikyuNo;
                }
                else
                {
                    flg = false;
                }
            }
            else
            {
                IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLInput checkInput = new GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLInput();
                checkInput.JokasoHokenjoCd      = input.KagamiHdrDT[0].JokasoHokenjoCd;
                checkInput.JokasoTorokuNendo    = input.KagamiHdrDT[0].JokasoTorokuNendo;
                checkInput.JokasoRenban         = input.KagamiHdrDT[0].JokasoRenban;
                checkInput.OyaSeikyuNo          = input.KagamiHdrDT[0].OyaSeikyuNo;
                checkInput.SeikyusakiKbn        = input.KagamiHdrDT[0].SeikyusakiKbn;
                IGetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBLOutput checkOutput = new GetSeikyuHdrTblByOyaSeikyuNoKbnJokasouDaichoKeyBusinessLogic().Execute(checkInput);

                if (checkOutput.SeikyuHdrTblDT != null && checkOutput.SeikyuHdrTblDT.Count > 0)
                {
                    flg = true;
                    _seikyuNo = checkOutput.SeikyuHdrTblDT[0].SeikyuNo;
                }
                else
                {
                    flg = false;
                }
            }

            return flg;
        }
        #endregion

        #region IsDeleteDgvRow
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： IsDeleteDgvRow
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/22  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private bool IsDeleteDgvRow(IUpdateBtnClickALInput input)
        {
            int countAfter = 0;
            int countBefore = 0;

            IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput blInput = new GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLInput();
            blInput.OyaSeikyuNo = input.KagamiHdrDT[0].OyaSeikyuNo;
            IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput blOutput = new GetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBusinessLogic().Execute(blInput);

            if (blOutput.SeikyuShosaiFormLoadDtlDT != null && blOutput.SeikyuShosaiFormLoadDtlDT.Count > 0)
            {
                countAfter = blOutput.SeikyuShosaiFormLoadDtlDT.Select("SeikyuKomokuKbn = '9'").Length;

                countBefore = input.SeikyuDtlTblDT.Select("ISNULL(SeikyuNo, '') <> ''").Length;

                if (countBefore < countAfter)
                {
                    return true;
                }
            }

            return false;
        }
        #endregion

        #endregion

    }
    #endregion
}
