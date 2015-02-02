using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.SuishitsuKensaNippo;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.SuishitsuKensaNippo
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
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALInput : IBseALInput, IUpdateSuishitsuNippoHdrTblBLInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        string UketsukeDt { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// UpdateCheck
        /// </summary>
        bool UpdateCheck { get; set; }
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
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALInput : IKoshinBtnClickALInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        public string UketsukeDt { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// UpdateCheck
        /// </summary>
        public bool UpdateCheck { get; set; }

        /// <summary>
        /// Kbn
        /// </summary>
        public string Kbn { get; set; }

        /// <summary>
        /// SuishitsuNippoHdrTblDataTable
        /// </summary>
        public SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblDataTable SuishitsuNippoHdrTblDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("受付日[{0}], 支所コード[{1}], UpdateCheck[{2}]", new string[] { UketsukeDt, ShishoCd, UpdateCheck.ToString(),});
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
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALOutput
    {
        /// <summary>
        /// UpdateCheckOuput
        /// </summary>
        bool UpdateCheckOutput { get; set; }

        /// <summary>
        /// Update Success
        /// </summary>
        bool UpdateSuccess { get; set; }

        /// <summary>
        /// SuisitsuKensaNippoKensakuDataTable
        /// </summary>
        SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuDataTable SuisitsuKensaNippoKensakuDT { get; set; }
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
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALOutput : IKoshinBtnClickALOutput
    {
        /// <summary>
        /// UpdateCheckOuput
        /// </summary>
        public bool UpdateCheckOutput { get; set; }

        /// <summary>
        /// Update Success
        /// </summary>
        public bool UpdateSuccess { get; set; }

        /// <summary>
        /// SuisitsuKensaNippoKensakuDataTable
        /// </summary>
        public SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuDataTable SuisitsuKensaNippoKensakuDT { get; set; }
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
    /// 2014/12/05  DatNT　  新規作成
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
        private const string FunctionName = "SuishitsuKensaNippo：KoshinBtnClickApplicationLogic";

        /// <summary>
        /// Update Success
        /// </summary>
        private bool updateSuccess = false;

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
        /// 2014/12/05  DatNT　  新規作成
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
        /// 2014/12/05  DatNT　  新規作成
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
        /// 2014/12/05  DatNT　  新規作成
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

                if (input.UpdateCheck)
                {
                    // 水質日報明細テーブル/検査依頼テーブル（モード判定２）
                    ICountDecide2KensaIraiBLInput decide2KensaIraiInput = new CountDecide2KensaIraiBLInput();
                    decide2KensaIraiInput.UketsukeDt = input.UketsukeDt;
                    ICountDecide2KensaIraiBLOutput decide2KensaIraiOutput = new CountDecide2KensaIraiBusinessLogic().Execute(decide2KensaIraiInput);

                    // 水質日報明細テーブル/計量証明依頼テーブル（モード判定２）
                    ICountDecideKeiryoShomeiBLInput decide2KeiryoInput = new CountDecideKeiryoShomeiBLInput();
                    decide2KeiryoInput.UketsukeDt = input.UketsukeDt;
                    ICountDecideKeiryoShomeiBLOutput decide2KeiryoOuput = new CountDecideKeiryoShomeiBusinessLogic().Execute(decide2KeiryoInput);

                    if (decide2KensaIraiOutput.RecordCount > 0 || decide2KeiryoOuput.RecordCount > 0)
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
                    // Update
                    UpdateData(input);

                    output.UpdateSuccess = updateSuccess;

                    // 水質日報データ取得
                    IGetSuisitsuKensaNippoBySearchCondBLInput searchInput = new GetSuisitsuKensaNippoBySearchCondBLInput();
                    searchInput.UketsukeDt = input.UketsukeDt;
                    searchInput.ShishoCd = input.ShishoCd;
                    IGetSuisitsuKensaNippoBySearchCondBLOutput searchOuput = new GetSuisitsuKensaNippoBySearchCondBusinessLogic().Execute(searchInput);

                    output.SuisitsuKensaNippoKensakuDT = searchOuput.SuisitsuKensaNippoKensakuDT;
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

        #region UpdateData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/06  DatNT　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateData(IKoshinBtnClickALInput input)
        {
            DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

            string updateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            string updateTarm = Dns.GetHostName();
            
            if (input.SuishitsuNippoHdrTblDT != null && input.SuishitsuNippoHdrTblDT.Count > 0)
            {
                foreach (SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblRow row in input.SuishitsuNippoHdrTblDT)
                {
                    #region Update SuishitsuNippoHdrTbl

                    IGetSuishitsuNippoHdrTblByKeyBLInput blInput = new GetSuishitsuNippoHdrTblByKeyBLInput();
                    blInput.ShishoCd                    = row.ShishoCd;
                    blInput.SuishitsuGyoshaCd           = row.SuishitsuGyoshaCd;
                    blInput.SuishitsuKensaAmt           = row.SuishitsuKensaAmt;
                    blInput.SuishitsuKensaKbn           = row.SuishitsuKensaKbn;
                    blInput.SuishitsuKensaShubetsuCd    = row.SuishitsuKensaShubetsuCd;
                    blInput.SuishitsuUketsukeDt         = row.SuishitsuUketsukeDt;
                    IGetSuishitsuNippoHdrTblByKeyBLOutput blOutput = new GetSuishitsuNippoHdrTblByKeyBusinessLogic().Execute(blInput);

                    if (row.UpdateDt != blOutput.SuishitsuNippoHdrTblDT[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    // 支所コード
                    blOutput.SuishitsuNippoHdrTblDT[0].ShishoCd = row.ShishoCd;

                    // 受付日
                    blOutput.SuishitsuNippoHdrTblDT[0].SuishitsuUketsukeDt = row.SuishitsuUketsukeDt;

                    // 業者コード
                    blOutput.SuishitsuNippoHdrTblDT[0].SuishitsuGyoshaCd = row.SuishitsuGyoshaCd;

                    // 法定検査区分
                    blOutput.SuishitsuNippoHdrTblDT[0].SuishitsuKensaKbn = row.SuishitsuKensaKbn;

                    // 検査種別コード
                    blOutput.SuishitsuNippoHdrTblDT[0].SuishitsuKensaShubetsuCd = row.SuishitsuKensaShubetsuCd;

                    // 検査料金
                    blOutput.SuishitsuNippoHdrTblDT[0].SuishitsuKensaAmt = row.SuishitsuKensaAmt;

                    // チェックフラグ
                    blOutput.SuishitsuNippoHdrTblDT[0].CheckFlg = row.CheckFlg;

                    blOutput.SuishitsuNippoHdrTblDT[0].UpdateTarm = row.UpdateTarm;
                    blOutput.SuishitsuNippoHdrTblDT[0].UpdateUser = row.UpdateUser;
                    blOutput.SuishitsuNippoHdrTblDT[0].UpdateDt = now;
                    
                    IUpdateSuishitsuNippoHdrTblBLInput updateInput = new UpdateSuishitsuNippoHdrTblBLInput();
                    updateInput.SuishitsuNippoHdrTblDT = blOutput.SuishitsuNippoHdrTblDT;
                    new UpdateSuishitsuNippoHdrTblBusinessLogic().Execute(updateInput);

                    updateSuccess = true;

                    #endregion

                    #region Update KensaIraiTbl

                    IUpdateKensaIraiSuishitsuKensaNippoBLInput updateIraiInput = new UpdateKensaIraiSuishitsuKensaNippoBLInput();
                    updateIraiInput.KensaIraiSuishitsuNippoKbn = row.CheckFlg;
                    updateIraiInput.UpdateDt = now;
                    updateIraiInput.UpdateUser = updateUser;
                    updateIraiInput.UpdateTarm = updateTarm;
                    updateIraiInput.ShishoCd = row.ShishoCd;
                    updateIraiInput.UketsukeDt = row.SuishitsuUketsukeDt;
                    updateIraiInput.GyoshaCd = row.SuishitsuGyoshaCd;
                    updateIraiInput.ShubetsuCd = row.SuishitsuKensaShubetsuCd;
                    new UpdateKensaIraiSuishitsuKensaNippoBusinessLogic().Execute(updateIraiInput);

                    #endregion

                    #region Update KeiryoShomeiIraiTbl

                    IUpdateKeiryoShomeiSuishitsuKensaNippoBLInput updateKeiryoInput = new UpdateKeiryoShomeiSuishitsuKensaNippoBLInput();
                    updateKeiryoInput.KeiryoShomeiSuishitsuNippoKbn = row.CheckFlg;
                    updateKeiryoInput.UpdateDt = now;
                    updateKeiryoInput.UpdateUser = updateUser;
                    updateKeiryoInput.UpdateTarm = updateTarm;
                    updateKeiryoInput.ShishoCd = row.ShishoCd;
                    updateKeiryoInput.UketsukeDt = row.SuishitsuUketsukeDt;
                    updateKeiryoInput.GyoshaCd = row.SuishitsuGyoshaCd;
                    updateKeiryoInput.ShubetsuCd = row.SuishitsuKensaShubetsuCd;     
                    new UpdateKeiryoShomeiSuishitsuKensaNippoBusinessLogic().Execute(updateKeiryoInput);

                    #endregion
                }
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
