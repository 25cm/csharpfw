using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuList;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.SeikyuList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IIkkatsuSeikyuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IIkkatsuSeikyuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// Printer name
        /// </summary>
        string PrinterName { get; set; }

        /// <summary>
        /// List of SeikyuNo gets from result search
        /// </summary>
        List<string> SeikyuNoList { get; set; }

        /// <summary>
        /// Current system date
        /// </summary>
        DateTime Now { get; set; }

        /// <summary>
        /// SeikyuListKensakuDataTable
        /// </summary>
        SeikyuHdrTblDataSet.SeikyuListKensakuDataTable SeikyuListKensakuDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IkkatsuSeikyuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IkkatsuSeikyuBtnClickALInput : IIkkatsuSeikyuBtnClickALInput
    {
        /// <summary>
        /// Printer name
        /// </summary>
        public string PrinterName { get; set; }

        /// <summary>
        /// List of SeikyuNo gets from result search
        /// </summary>
        public List<string> SeikyuNoList { get; set; }

        /// <summary>
        /// Current system date
        /// </summary>
        public DateTime Now { get; set; }

        /// <summary>
        /// SeikyuListKensakuDataTable
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuListKensakuDataTable SeikyuListKensakuDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("請求No[{0}]", SeikyuNoList[0]);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IIkkatsuSeikyuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IIkkatsuSeikyuBtnClickALOutput
    {
        /// <summary>
        /// Unexpected error
        /// </summary>
        string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IkkatsuSeikyuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IkkatsuSeikyuBtnClickALOutput : IIkkatsuSeikyuBtnClickALOutput
    {
        /// <summary>
        /// Unexpected error
        /// </summary>
        public string ErrMsg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： IkkatsuSeikyuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class IkkatsuSeikyuBtnClickApplicationLogic : BaseApplicationLogic<IIkkatsuSeikyuBtnClickALInput, IIkkatsuSeikyuBtnClickALOutput>
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
        private const string FunctionName = "SeikyuList：IkkatsuSeikyuBtnClick";

        /// <summary>
        /// 更新者
        /// </summary>
        private string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// 更新端末
        /// </summary>
        private string host = Dns.GetHostName();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： IkkatsuSeikyuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public IkkatsuSeikyuBtnClickApplicationLogic()
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
        /// 2014/09/11　AnhNV　　    新規作成
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
        /// 2014/09/11　AnhNV　　    新規作成
        /// 2014/12/18　kiyokuni　　明細はデフォルトプリンター
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IIkkatsuSeikyuBtnClickALOutput Execute(IIkkatsuSeikyuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IIkkatsuSeikyuBtnClickALOutput output = new IkkatsuSeikyuBtnClickALOutput();

            try
            {
                // Print SeikyuSho (009)
                IPrintSeikyuShoBLInput seikyuShoInput = new PrintSeikyuShoBLInput();
                seikyuShoInput.AfterPrintFlg = true;
                seikyuShoInput.PrinterName = input.PrinterName;
                seikyuShoInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SeikyuShoFormatFile;
                seikyuShoInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                seikyuShoInput.SeikyuNoList = input.SeikyuNoList;
                new PrintSeikyuShoBusinessLogic().Execute(seikyuShoInput);

                // Print SeikyuMeisaiSho (010)
                IPrintSeikyuMeisaiShoBLInput meisaiInput = new PrintSeikyuMeisaiShoBLInput();
                meisaiInput.AfterPrintFlg = true;
                //Del kiyokuni
                //meisaiInput.PrinterName = input.PrinterName;  
                meisaiInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SeikyuMeisaiShoFormatFile;
                meisaiInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                meisaiInput.SeikyuNoList = input.SeikyuNoList;

                // 2014.12.29 toyoda Add Start
                meisaiInput.SeikyuKansaiFlg = "0";
                // 2014.12.29 toyoda Add End

                new PrintSeikyuMeisaiShoBusinessLogic().Execute(meisaiInput);

                try
                {
                    // トランザクション開始
                    StartTransaction();

                    // Update
                    DoUpdate(input);

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
                }
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

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27　AnhNV　　    基本設計書_006_006_画面_SeikyuList_Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate(IIkkatsuSeikyuBtnClickALInput input)
        {
            // Instantiates the update tables
            SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable seikyusyoTable = new SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable();
            KensaIraiTblDataSet.KensaIraiTblDataTable kensaIraiTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();
            KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable keiryoTable = new KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable();

            IGetOyaSeikyuByOyaSeikyuNoBLInput blInput = new GetOyaSeikyuByOyaSeikyuNoBLInput();

            foreach (SeikyuHdrTblDataSet.SeikyuListKensakuRow row in input.SeikyuListKensakuDataTable)
            {
                // Create 請求書鑑ヘッダテーブル  for update
                seikyusyoTable.Merge(CreateSeikyusyoKagamiHdrTblDataTableUpdate(row.OyaSeikyuNo, row.UpdateDt, input.Now));

                // Get data to update 検査依頼テーブル and 計量証明依頼テーブル
                blInput.OyaSeikyuNo = row.OyaSeikyuNo;
                IGetOyaSeikyuByOyaSeikyuNoBLOutput blOutput = new GetOyaSeikyuByOyaSeikyuNoBusinessLogic().Execute(blInput);

                foreach (SeikyuHdrTblDataSet.OyaSeikyuRow oyaRow in blOutput.OyaSeikyuDataTable)
                {
                    // Create 検査依頼テーブル for update
                    if (oyaRow.SeikyuKomokuKbn == "1")
                    {
                        kensaIraiTable.Merge(CreateKensaIraiTblDataTableUpdate(
                            oyaRow.KensaIraiHoteiKbn,
                            oyaRow.KensaIraiHokenjoCd,
                            oyaRow.KensaIraiNendo,
                            oyaRow.KensaIraiRenban,
                            input.Now));
                    }

                    // Create 計量証明依頼テーブル for update
                    if (oyaRow.SeikyuKomokuKbn == "2")
                    {
                        keiryoTable.Merge(CreateKeiryoShomeiIraiTblDataTableUpdate(
                            oyaRow.KeiryoShomeiIraiNendo,
                            oyaRow.KeiryoShomeiIraiSishoCd,
                            oyaRow.KeiryoShomeiIraiRenban,
                            input.Now));
                    }
                }
            }

            // Update 請求書鑑ヘッダテーブル
            IUpdateSeikyusyoKagamiHdrTblBLInput seikyuInput = new UpdateSeikyusyoKagamiHdrTblBLInput();
            seikyuInput.SeikyusyoKagamiHdrTblDataTable = seikyusyoTable;
            new UpdateSeikyusyoKagamiHdrTblBusinessLogic().Execute(seikyuInput);

            // Update 検査依頼テーブル
            IUpdateKensaIraiTblBLInput kensaInput = new UpdateKensaIraiTblBLInput();
            kensaInput.KensaIraiTblDataTable = kensaIraiTable;
            new UpdateKensaIraiTblBusinessLogic().Execute(kensaInput);

            // Update 計量証明依頼テーブル
            IUpdateKeiryoShomeiIraiTblBLInput keiryoInput = new UpdateKeiryoShomeiIraiTblBLInput();
            keiryoInput.KeiryoShomeiIraiTblDT = keiryoTable;
            new UpdateKeiryoShomeiIraiTblBusinessLogic().Execute(keiryoInput);
        }
        #endregion

        #region CreateSeikyusyoKagamiHdrTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSeikyusyoKagamiHdrTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="oyaSeikyuNo"></param>
        /// <param name="checkDt"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27　AnhNV　　    基本設計書_006_006_画面_SeikyuList_Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyusyoKagamiHdrTblDataSet.SeikyusyoKagamiHdrTblDataTable CreateSeikyusyoKagamiHdrTblDataTableUpdate
            (
                string oyaSeikyuNo,
                DateTime checkDt,
                DateTime now
            )
        {
            IGetSeikyusyoKagamiHdrTblByKeyBLInput blInput = new GetSeikyusyoKagamiHdrTblByKeyBLInput();
            blInput.OyaSeikyuNo = oyaSeikyuNo;
            IGetSeikyusyoKagamiHdrTblByKeyBLOutput blOutput = new GetSeikyusyoKagamiHdrTblByKeyBusinessLogic().Execute(blInput);

            // 1 record was found?
            if (blOutput.SeikyusyoKagamiHdrTblDataTable.Count > 0)
            {
                // 更新日が違うか？
                if (blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateDt != checkDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 請求書発行フラグ 
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].SeikyusyoHakkoFlg = "1";
                // 更新日
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateDt = now;
                // 更新者
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateUser = this.user;
                // 更新端末
                blOutput.SeikyusyoKagamiHdrTblDataTable[0].UpdateTarm = this.host;
            }

            return blOutput.SeikyusyoKagamiHdrTblDataTable;
        }
        #endregion

        #region CreateKensaIraiTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaIraiHoteiKbn"></param>
        /// <param name="kensaIraiHokenjoCd"></param>
        /// <param name="kensaIraiNendo"></param>
        /// <param name="kensaIraiRenban"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27　AnhNV　　    基本設計書_006_006_画面_SeikyuList_Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDataTableUpdate
            (
                string kensaIraiHoteiKbn,
                string kensaIraiHokenjoCd,
                string kensaIraiNendo,
                string kensaIraiRenban,
                DateTime now
            )
        {
            IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
            blInput.KensaIraiHoteiKbn = kensaIraiHoteiKbn;
            blInput.KensaIraiHokenjoCd = kensaIraiHokenjoCd;
            blInput.KensaIraiNendo = kensaIraiNendo;
            blInput.KensaIraiRenban = kensaIraiRenban;
            IGetKensaIraiTblByKeyBLOutput blOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);

            // 1 record was found?
            if (blOutput.KensaIraiTblDataTable.Count > 0)
            {
                // 請求区分
                blOutput.KensaIraiTblDataTable[0].KensaIraiSeikyuKbn = "2";
                // 更新日
                blOutput.KensaIraiTblDataTable[0].UpdateDt = now;
                // 更新者
                blOutput.KensaIraiTblDataTable[0].UpdateUser = this.user;
                // 更新端末
                blOutput.KensaIraiTblDataTable[0].UpdateTarm = this.host;
            }

            return blOutput.KensaIraiTblDataTable;
        }
        #endregion

        #region CreateKeiryoShomeiIraiTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKeiryoShomeiIraiTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="iraiNendo"></param>
        /// <param name="iraiShishoCd"></param>
        /// <param name="iraiRenban"></param>
        /// <param name="now"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/27　AnhNV　　    基本設計書_006_006_画面_SeikyuList_Ver1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable CreateKeiryoShomeiIraiTblDataTableUpdate
            (
                string iraiNendo,
                string iraiShishoCd,
                string iraiRenban,
                DateTime now
            )
        {
            IGetKeiryoShomeiIraiTblByKeyBLInput blInput = new GetKeiryoShomeiIraiTblByKeyBLInput();
            blInput.KeiryoShomeiIraiNendo = iraiNendo;
            blInput.KeiryoShomeiIraiSishoCd = iraiShishoCd;
            blInput.KeiryoShomeiIraiRenban = iraiRenban;
            IGetKeiryoShomeiIraiTblByKeyBLOutput blOutput = new GetKeiryoShomeiIraiTblByKeyBusinessLogic().Execute(blInput);

            // 1 record was found
            if (blOutput.KeiryoShomeiIraiTblDT.Count > 0)
            {
                // 請求区分
                blOutput.KeiryoShomeiIraiTblDT[0].KeiryoShomeiSeikyuKbn = "2";
                // 更新日
                blOutput.KeiryoShomeiIraiTblDT[0].UpdateDt = now;
                // 更新者
                blOutput.KeiryoShomeiIraiTblDT[0].UpdateUser = this.user;
                // 更新端末
                blOutput.KeiryoShomeiIraiTblDT[0].UpdateTarm = this.host;
            }

            return blOutput.KeiryoShomeiIraiTblDT;
        }
        #endregion

        #region MakeSeikyuHdrTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeSeikyuHdrTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SeikyuHdrTblDataSet.SeikyuHdrTblDataTable MakeSeikyuHdrTblUpdate(IIkkatsuSeikyuBtnClickALInput input)
        {
            // 更新者
            string loginName = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // 更新端末
            string host = Dns.GetHostName();

            SeikyuHdrTblDataSet.SeikyuHdrTblDataTable table = new SeikyuHdrTblDataSet.SeikyuHdrTblDataTable();
            IGetSeikyuHdrTblByKeyBLInput blInput = new GetSeikyuHdrTblByKeyBLInput();

            foreach (string seikyuNo in input.SeikyuNoList)
            {
                // Get SeikyuHdrTbl by key
                blInput.SeikyuNo = seikyuNo;
                IGetSeikyuHdrTblByKeyBLOutput blOutput = new GetSeikyuHdrTblByKeyBusinessLogic().Execute(blInput);

                if (blOutput.SeikyuHdrTblDataTable.Count > 0)
                {
                    //DEL_2014/11/12_HuyTX Start(DB_Design_Ver1.24 delete column 'SeikyusyoHakkoFlg' )
                    // 請求書発行フラグ
                    //blOutput.SeikyuHdrTblDataTable[0].SeikyusyoHakkoFlg = "1";
                    //DEL_2014/11/12_HuyTX End

                    // 更新日
                    blOutput.SeikyuHdrTblDataTable[0].UpdateDt = input.Now;

                    // 更新者
                    blOutput.SeikyuHdrTblDataTable[0].UpdateUser = loginName;

                    // 更新端末
                    blOutput.SeikyuHdrTblDataTable[0].UpdateTarm = host;
                }

                // Merge to result table
                table.Merge(blOutput.SeikyuHdrTblDataTable);
            }

            return table;
        }
        #endregion

        #endregion
    }
    #endregion
}
