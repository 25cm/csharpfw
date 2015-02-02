using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.ZandakaList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.ZandakaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISaiseikyuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISaiseikyuBtnClickALInput : IBseALInput
    {
        ///// <summary>
        ///// システム日付（YYYYMMDD）
        ///// </summary>
        //DateTime SystemDt { get; set; }

        /// <summary>
        /// 請求日（終了）
        /// </summary>
        DateTime SeikyuDtTo { get; set; }

        /// <summary>
        /// 再請求番号
        /// </summary>
        string SaiSeikyuNo { get; set; }

        ///// <summary>
        ///// ZandakaListKensakuDataTable
        ///// </summary>
        //SeikyuHdrTblDataSet.ZandakaListKensakuDataTable ZandakaListKensakuDataTable { get; set; }

        /// <summary>
        /// SearchCond 
        /// </summary>
        SeikyuSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaiseikyuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SaiseikyuBtnClickALInput : ISaiseikyuBtnClickALInput
    {
        ///// <summary>
        ///// システム日付（YYYYMMDD）
        ///// </summary>
        //public DateTime SystemDt { get; set; }

        /// <summary>
        /// 請求日（終了）
        /// </summary>
        public DateTime SeikyuDtTo { get; set; }

        /// <summary>
        /// 再請求番号
        /// </summary>
        public string SaiSeikyuNo { get; set; }

        ///// <summary>
        ///// ZandakaListKensakuDataTable
        ///// </summary>
        //public SeikyuHdrTblDataSet.ZandakaListKensakuDataTable ZandakaListKensakuDataTable { get; set; }

        /// <summary>
        /// SearchCond 
        /// </summary>
        public SeikyuSearchCond SearchCond { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("再請求番号[{0}]", SaiSeikyuNo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISaiseikyuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISaiseikyuBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaiseikyuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SaiseikyuBtnClickALOutput : ISaiseikyuBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SaiseikyuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/18　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SaiseikyuBtnClickApplicationLogic : BaseApplicationLogic<ISaiseikyuBtnClickALInput, ISaiseikyuBtnClickALOutput>
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
        private const string FunctionName = "ZandakaList：SaiseikyuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SaiseikyuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SaiseikyuBtnClickApplicationLogic()
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
        /// 2014/09/18　AnhNV　　    新規作成
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
        /// 2014/09/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISaiseikyuBtnClickALOutput Execute(ISaiseikyuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISaiseikyuBtnClickALOutput output = new SaiseikyuBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                //20150121 HuyTX Del Start
                // Update 再請求集計ワーク
                //UpdateSaiSeikyuSyukeiWrk(input);

                // Delete all records from SaiSeikyuSyukeiWrk
                new DeleteSaiSeikyuSyukeiWrkBusinessLogic().Execute(new DeleteSaiSeikyuSyukeiWrkBLInput());

                IUpdateSaiSeikyuSyukeiWrkBySearchCondBLInput updateSaiSeikyuSyukeiWrkInput = new UpdateSaiSeikyuSyukeiWrkBySearchCondBLInput();
                updateSaiSeikyuSyukeiWrkInput.SearchCond = input.SearchCond;
                new UpdateSaiSeikyuSyukeiWrkBySearchCondBusinessLogic().Execute(updateSaiSeikyuSyukeiWrkInput);

                //End

                // Export 011_再請求書_帳票設計書
                IPrintSaiSeikyuBLInput blInput = new PrintSaiSeikyuBLInput();
                blInput.AfterDispFlg = true;
                blInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.SaiSeikyuFormatFile;
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blInput.SaiSeikyuNo = input.SaiSeikyuNo;
                blInput.SeikyuDtTo = input.SeikyuDtTo;
                new PrintSaiSeikyuBusinessLogic().Execute(blInput);

                //20150121 Del
                // Update 請求ヘッダテーブル
                //UpdateSeikyuHdr(input);
                //End

                //update SeikyuHdrTbl 
                IUpdateSeikyuHdrTblBySearchCondBLInput updateSeikyuHdrInput = new UpdateSeikyuHdrTblBySearchCondBLInput();
                updateSeikyuHdrInput.SearchCond = input.SearchCond;
                new UpdateSeikyuHdrTblBySearchCondBusinessLogic().Execute(updateSeikyuHdrInput);

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
        #region 20150121 HuyTX Del 
        /*
        #region UpdateSaiSeikyuSyukeiWrk
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateSaiSeikyuSyukeiWrk
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18　AnhNV　　    新規作成
        /// 2014/11/05　AnhNV　　 基本設計書_006_009_画面_ZandakaList_Ver1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateSaiSeikyuSyukeiWrk(ISaiseikyuBtnClickALInput input)
        {
            try
            {
                // Instances a SaiSeikyuSyukeiWrk
                SaiSeikyuSyukeiWrkDataSet.SaiSeikyuSyukeiWrkDataTable updateTable = new SaiSeikyuSyukeiWrkDataSet.SaiSeikyuSyukeiWrkDataTable();

                // Data table
                SeikyuHdrTblDataSet.ZandakaListKensakuDataTable sourceTable = input.ZandakaListKensakuDataTable;

                // Login name
                string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                // Host name
                string host = Dns.GetHostName();

                // How to check new row?
                string tempGyoshaCd = null;
                string tempSeikyuYM = null;

                // Counting variables
                object kensa11Suishitsu;
                object kensa11Gaikan;
                object keiryoShomei;
                object yoshiHanbai;
                object nenkaihi;

                SeikyuHdrTblDataSet.ZandakaListKensakuDataTable seikyuTable = new SeikyuHdrTblDataSet.ZandakaListKensakuDataTable();
                foreach (SeikyuHdrTblDataSet.ZandakaListKensakuRow row in sourceTable.Select(string.Empty, "IkkatsuSeikyuSakiCd, SeikyuNenGetsu asc"))
                {
                    // New row?
                    if (tempGyoshaCd != row.IkkatsuSeikyuSakiCd || tempSeikyuYM != row.SeikyuNenGetsu)
                    {
                        //20141224 HuyTX Mod Start
                        //kensa11Suishitsu = ComputeTotal(sourceTable, string.Format("SeikyuGyosyaCd = '{0}' and SeikyuYM = '{1}' and SeikyuKomokuKbn = '1' and KensaIraiHoteiKbn = '3'", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));
                        //kensa11Gaikan = ComputeTotal(sourceTable, string.Format("SeikyuGyosyaCd = '{0}' and SeikyuYM = '{1}' and SeikyuKomokuKbn = '1' and KensaIraiHoteiKbn = '2'", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));
                        //keiryoShomei = ComputeTotal(sourceTable, string.Format("SeikyuGyosyaCd = '{0}' and SeikyuYM = '{1}' and SeikyuKomokuKbn = '2'", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));
                        //yoshiHanbai = ComputeTotal(sourceTable, string.Format("SeikyuGyosyaCd = '{0}' and SeikyuYM = '{1}' and SeikyuKomokuKbn in ('3', '4', '7')", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));
                        //nenkaihi = ComputeTotal(sourceTable, string.Format("SeikyuGyosyaCd = '{0}' and SeikyuYM = '{1}' and SeikyuKomokuKbn = '5'", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));

                        // 2014/12/27 AnhNV ADD Start
                        IGetZandakaListKensakuBySearchCondBLInput zInput = new GetZandakaListKensakuBySearchCondBLInput();
                        zInput.SearchCond = new SeikyuSearchCond();
                        IGetZandakaListKensakuBySearchCondBLOutput zOutput = new GetZandakaListKensakuBySearchCondBusinessLogic().Execute(zInput);
                        seikyuTable = zOutput.ZandakaListKensakuDataTable;
                        // 2014/12/27 AnhNV ADD End

                        // 2014/12/27 AnhNV changes sourceTable to seikyuTable
                        kensa11Suishitsu = ComputeTotal(seikyuTable, string.Format("IkkatsuSeikyuSakiCd = '{0}' and SeikyuNenGetsu = '{1}' and SeikyuKomokuKbn = '1' and KensaIraiHoteiKbn = '3'", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));
                        kensa11Gaikan = ComputeTotal(seikyuTable, string.Format("IkkatsuSeikyuSakiCd = '{0}' and SeikyuNenGetsu = '{1}' and SeikyuKomokuKbn = '1' and KensaIraiHoteiKbn = '2'", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));
                        keiryoShomei = ComputeTotal(seikyuTable, string.Format("IkkatsuSeikyuSakiCd = '{0}' and SeikyuNenGetsu = '{1}' and SeikyuKomokuKbn = '2'", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));
                        yoshiHanbai = ComputeTotal(seikyuTable, string.Format("IkkatsuSeikyuSakiCd = '{0}' and SeikyuNenGetsu = '{1}' and SeikyuKomokuKbn in ('3', '4', '7')", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));
                        nenkaihi = ComputeTotal(seikyuTable, string.Format("IkkatsuSeikyuSakiCd = '{0}' and SeikyuNenGetsu = '{1}' and SeikyuKomokuKbn = '5'", row.IkkatsuSeikyuSakiCd, row.SeikyuNenGetsu));
                        //20141224 HuyTX Mod End

                        // New SaiSeikyuSyukeiWrk row
                        SaiSeikyuSyukeiWrkDataSet.SaiSeikyuSyukeiWrkRow newRow = updateTable.NewSaiSeikyuSyukeiWrkRow();

                        // 業者コード 
                        newRow.SeikyuGyosyaCd = row.IkkatsuSeikyuSakiCd;
                        // 請求年月
                        newRow.SeikyuYM = row.SeikyuNenGetsu;
                        // 業者名称
                        newRow.GyoshaNm = row.KagamiSeikyusakiNm;
                        // 11条水質検査
                        if (null != kensa11Suishitsu)
                        {
                            newRow.Kensa11Suishitsu = Convert.ToDecimal(kensa11Suishitsu);
                        }
                        // 11条外観検査
                        if (null != kensa11Gaikan)
                        {
                            newRow.Kensa11Gaikan = Convert.ToDecimal(kensa11Gaikan);
                        }
                        // 計量証明
                        if (null != keiryoShomei)
                        {
                            newRow.KeiryoShomei = Convert.ToDecimal(keiryoShomei);
                        }
                        // 用紙販売
                        if (null != yoshiHanbai)
                        {
                            newRow.YoshiHanbai = Convert.ToDecimal(yoshiHanbai);
                        }
                        // 年会費
                        if (null != nenkaihi)
                        {
                            newRow.Nenkaihi = Convert.ToDecimal(nenkaihi);
                        }
                        // 登録日
                        newRow.InsertDt = input.SystemDt;
                        // 登録者
                        newRow.InsertUser = user;
                        // 登録端末
                        newRow.InsertTarm = host;
                        // 更新日
                        newRow.UpdateDt = input.SystemDt;
                        // 更新者
                        newRow.UpdateUser = user;
                        // 更新端末
                        newRow.UpdateTarm = host;

                        // 行を挿入
                        updateTable.AddSaiSeikyuSyukeiWrkRow(newRow);
                        // 行の状態を設定
                        newRow.AcceptChanges();
                        // 行の状態を設定（新規）
                        newRow.SetAdded();
                    }

                    // No change, no new row
                    tempGyoshaCd = row.IkkatsuSeikyuSakiCd;
                    tempSeikyuYM = row.SeikyuNenGetsu;
                }

                // Delete all records from SaiSeikyuSyukeiWrk
                new DeleteSaiSeikyuSyukeiWrkBusinessLogic().Execute(new DeleteSaiSeikyuSyukeiWrkBLInput());

                // Update 再請求集計ワーク
                IUpdateSaiSeikyuSyukeiWrkBLInput wrkInput = new UpdateSaiSeikyuSyukeiWrkBLInput();
                wrkInput.SaiSeikyuSyukeiWrkDataTable = updateTable;
                new UpdateSaiSeikyuSyukeiWrkBusinessLogic().Execute(wrkInput);
            }
            catch
            {
                throw;
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
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateSeikyuHdr(ISaiseikyuBtnClickALInput input)
        {
            // Get SeikyuHdrTbl by key
            IGetSeikyuHdrTblByKeyBLInput hdrInput = new GetSeikyuHdrTblByKeyBLInput();
            // Instances an update table
            SeikyuHdrTblDataSet.SeikyuHdrTblDataTable table = new SeikyuHdrTblDataSet.SeikyuHdrTblDataTable();
            // Login name
            string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            // Host name
            string host = Dns.GetHostName();
            string tempSeikyuNo = string.Empty;

            foreach (SeikyuHdrTblDataSet.ZandakaListKensakuRow row in input.ZandakaListKensakuDataTable.Select(string.Empty, "SeikyuNo"))
            {
                if (tempSeikyuNo != row.SeikyuNo)
                {
                    // Execute
                    hdrInput.SeikyuNo = row.SeikyuNo;
                    IGetSeikyuHdrTblByKeyBLOutput hdrOutput = new GetSeikyuHdrTblByKeyBusinessLogic().Execute(hdrInput);

                    // SeikyuNo does not match
                    if (hdrOutput.SeikyuHdrTblDataTable.Count == 0) continue;

                    //Rakkan check
                    if (row.UpdateDt != hdrOutput.SeikyuHdrTblDataTable[0].UpdateDt)
                    {
                        // 更新されている場合は、他のユーザから更新されていると判断し、楽観ロックエラーで例外を発生
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    // 再請求回数
                    hdrOutput.SeikyuHdrTblDataTable[0].SaiseikyuCnt += 1;
                    // 再請求日
                    hdrOutput.SeikyuHdrTblDataTable[0].SaiseikyuDt = input.SystemDt.ToString("yyyyMMdd");
                    // 更新日
                    hdrOutput.SeikyuHdrTblDataTable[0].UpdateDt = input.SystemDt;
                    // 更新者
                    hdrOutput.SeikyuHdrTblDataTable[0].UpdateUser = user;
                    // 更新端末
                    hdrOutput.SeikyuHdrTblDataTable[0].UpdateTarm = host;

                    // Merge to result
                    table.Merge(hdrOutput.SeikyuHdrTblDataTable);
                }

                tempSeikyuNo = row.SeikyuNo;
            }

            // Update 再請求集計ワーク
            IUpdateSeikyuHdrTblBLInput seikyuInput = new UpdateSeikyuHdrTblBLInput();
            seikyuInput.SeikyuHdrTblDataTable = table;
            new UpdateSeikyuHdrTblBusinessLogic().Execute(seikyuInput);
        }
        #endregion

        #region ComputeTotal
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ComputeTotal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="table"></param>
        /// <param name="filter"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/18　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private object ComputeTotal(SeikyuHdrTblDataSet.ZandakaListKensakuDataTable table, string filter)
        {
            object sum1;
            object sum2;
            object total = null;

            sum1 = table.Compute("sum(SeikyuKingakuKei)", filter);
            sum2 = table.Compute("sum(NyukinTotal)", filter);

            if (sum1 is DBNull && sum2 is DBNull)
            {
                return null;
            }
            else
            {
                total = Convert.ToDecimal(sum1 is DBNull ? "0" : sum1) - Convert.ToDecimal(sum2 is DBNull ? "0" : sum2);
            }

            return total;
        }
        #endregion
        */
        #endregion
        #endregion
    }
    #endregion
}
