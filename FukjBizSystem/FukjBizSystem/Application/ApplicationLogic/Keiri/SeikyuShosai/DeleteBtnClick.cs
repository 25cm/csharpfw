using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/01  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALInput : IBseALInput, IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLInput
    {
        /// <summary>
        /// 削除チェック
        /// </summary>
        bool DeleteCheck { get; set; }

        /// <summary>
        /// DeleteFlg
        /// </summary>
        bool DeleteFlg { get; set; }

        /// <summary>
        /// 請求ヘッダテーブル
        /// </summary>
        SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }

        /// <summary>
        /// SeikyuDtlTblDataTable
        /// </summary>
        SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/01  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALInput : IDeleteBtnClickALInput
    {
        /// <summary>
        /// 削除チェック
        /// </summary>
        public bool DeleteCheck { get; set; }
        
        /// <summary>
        /// 親請求No
        /// </summary>
        public string OyaSeikyuNo { get; set; }

        /// <summary>
        /// DeleteFlg
        /// </summary>
        public bool DeleteFlg { get; set; }

        /// <summary>
        /// 請求ヘッダテーブル
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuHdrTblDataTable SeikyuHdrTblDT { get; set; }

        /// <summary>
        /// SeikyuDtlTblDataTable
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("削除チェック[{0}], DeleteFlg[{1}]", 
                    new string[] { DeleteCheck.ToString(),  DeleteFlg.ToString() });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/01  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALOutput : IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput, IGetSeikyuShosaiFormLoadDtlByOyaSeikyuNoBLOutput
    {
        /// <summary>
        /// 削除チェック Output
        /// </summary>
        bool DeleteCheckOutput { get; set; }

        /// <summary>
        /// 削除確認チェック Output
        /// </summary>
        bool DeleteConfirmCheckOutput { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/01  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
    {
        /// <summary>
        /// 削除チェック Output
        /// </summary>
        public bool DeleteCheckOutput { get; set; }

        /// <summary>
        /// 削除確認チェック Output
        /// </summary>
        public bool DeleteConfirmCheckOutput { get; set; }

        /// <summary>
        /// SeikyuShosaiFormLoadHdrDataTable
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrDataTable SeikyuShosaiFormLoadHdrDT { get; set; }

        /// <summary>
        /// SeikyuShosaiFormLoadDtlDataTable
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuShosaiFormLoadDtlDataTable SeikyuShosaiFormLoadDtlDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/01  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SeikyuShosai：DeleteBtnClickApplicationLogic";

        /// <summary>
        /// Login User
        /// </summary>
        string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// PC Update
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteBtnClickApplicationLogic()
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
        /// 2014/10/01  DatNT　  新規作成
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
        /// 2014/10/01  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteBtnClickALOutput Execute(IDeleteBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnClickALOutput output = new DeleteBtnClickALOutput();

            try
            {
                StartTransaction();

                if (input.DeleteCheck)
                {
                    IGetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBLOutput blOuput = new GetSeikyuShosaiFormLoadHdrByOyaSeikyuNoBusinessLogic().Execute(input);

                    if (blOuput.SeikyuShosaiFormLoadHdrDT != null && blOuput.SeikyuShosaiFormLoadHdrDT.Count > 0)
                    {
                        if (!blOuput.SeikyuShosaiFormLoadHdrDT[0].IsNyukinTotalNull() && blOuput.SeikyuShosaiFormLoadHdrDT[0].NyukinTotal > 0)
                        {
                            output.DeleteCheckOutput = false;
                        }
                        else
                        {
                            output.DeleteCheckOutput = true;
                        }
                    }
                    else
                    {
                        output.DeleteCheckOutput = false;
                    }

                    output.SeikyuShosaiFormLoadHdrDT = blOuput.SeikyuShosaiFormLoadHdrDT;

                }

                if (input.DeleteFlg)
                {
                    DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

                    // Update KensaIraiTbl
                    UpdateKensaIraiTbl(input, now);

                    // Update KeiryoShomeiIraiTbl
                    UpdateKeiryoShomeiIraiTbl(input, now);

                    // Delete SeikyuDtlTbl By SeikyuNo
                    IGetSeikyuHdrTblByOyaSeikyuNoBLInput getHdrInput = new GetSeikyuHdrTblByOyaSeikyuNoBLInput();
                    getHdrInput.OyaSeikyuNo = input.OyaSeikyuNo;
                    IGetSeikyuHdrTblByOyaSeikyuNoBLOutput getHdrOutput = new GetSeikyuHdrTblByOyaSeikyuNoBusinessLogic().Execute(getHdrInput);

                    foreach (SeikyuHdrTblDataSet.SeikyuHdrTblRow row in getHdrOutput.SeikyuHdrTblDT)
                    {
                        IDeleteSeikyuDtlTblBySeikyuNoBLInput dtlInput = new DeleteSeikyuDtlTblBySeikyuNoBLInput();
                        dtlInput.SeikyuNo = row.SeikyuNo;
                        new DeleteSeikyuDtlTblBySeikyuNoBusinessLogic().Execute(dtlInput);
                    }

                    // Delete SeikyuHdrTbl By Key
                    IDeleteSeikyuHdrTblByOyaSeikyuNoBLInput hdrInput = new DeleteSeikyuHdrTblByOyaSeikyuNoBLInput();
                    hdrInput.OyaSeikyuNo = input.OyaSeikyuNo;
                    new DeleteSeikyuHdrTblByOyaSeikyuNoBusinessLogic().Execute(hdrInput);

                    // Delete SeikyusyoKagamiTbl
                    IDeleteSeikyusyoKagamiTblByOyaSeikyuNoBLInput kagamiInput = new DeleteSeikyusyoKagamiTblByOyaSeikyuNoBLInput();
                    kagamiInput.OyaSeikyuNo = input.OyaSeikyuNo;
                    new DeleteSeikyusyoKagamiTblByOyaSeikyuNoBusinessLogic().Execute(kagamiInput);

                    // SeikyusyoKagamiHdrTbl
                    IDeleteSeikyusyoKagamiHdrTblByKeyBLInput kagamiHdrInput = new DeleteSeikyusyoKagamiHdrTblByKeyBLInput();
                    kagamiHdrInput.OyaSeikyuNo = input.OyaSeikyuNo;
                    new DeleteSeikyusyoKagamiHdrTblByKeyBusinessLogic().Execute(kagamiHdrInput);
                }

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
        private void UpdateKensaIraiTbl(IDeleteBtnClickALInput input, DateTime now)
        {
            IUpdateKensaIraiSeikyuShosaiBLInput updateInput = new UpdateKensaIraiSeikyuShosaiBLInput();
            updateInput.KensaIraiSeikyuKbn      = "0";
            updateInput.Now                     = now;
            updateInput.LoginUser               = loginUser;
            updateInput.PcUpdate                = pcUpdate;
            updateInput.OyaSeikyuNo             = input.OyaSeikyuNo;
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
        private void UpdateKeiryoShomeiIraiTbl(IDeleteBtnClickALInput input, DateTime now)
        {
            IUpdateKeiryoShomeiSeikyuShosaiBLInput updateInput = new UpdateKeiryoShomeiSeikyuShosaiBLInput();
            updateInput.KeiryoShomeiSeikyuKbn   = "0";
            updateInput.Now                     = now;
            updateInput.LoginUser               = loginUser;
            updateInput.PcUpdate                = pcUpdate;
            updateInput.OyaSeikyuNo             = input.OyaSeikyuNo;
            new UpdateKeiryoShomeiSeikyuShosaiBusinessLogic().Execute(updateInput);
        }
        #endregion

        #endregion
    }
    #endregion
}
