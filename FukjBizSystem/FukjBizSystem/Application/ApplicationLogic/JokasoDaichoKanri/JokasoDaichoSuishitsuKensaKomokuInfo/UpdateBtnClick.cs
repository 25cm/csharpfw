using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo;
using System.Net;

namespace FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo
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
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable { get; set; }

        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ For Rakkan Check
        /// </summary>
        DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTableRakkan { get; set; }

        /// <summary>
        /// 検査セットコード 
        /// </summary>
        string DaichoKensaKomokuSetCd { get; set; }

        /// <summary>
        /// 検査セット名称 
        /// </summary>
        string DaichoKensaSetNm { get; set; }

        /// <summary>
        /// 水質コード 
        /// </summary>
        string SuishitsuCd { get; set; }

        /// <summary>
        /// 浄化槽台帳保健所コード 
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        string TorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        string Renban { get; set; }

        // 20150201 sou Start
        /// <summary>
        /// 料金
        /// </summary>
        decimal Ryokin { get; set; }
        // 20150201 sou End
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
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateBtnClickALInput : IUpdateBtnClickALInput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable { get; set; }

        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ For Rakkan Check
        /// </summary>
        public DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTableRakkan { get; set; }

        /// <summary>
        /// 検査セットコード 
        /// </summary>
        public string DaichoKensaKomokuSetCd { get; set; }

        /// <summary>
        /// 検査セット名称 
        /// </summary>
        public string DaichoKensaSetNm { get; set; }

        /// <summary>
        /// 水質コード 
        /// </summary>
        public string SuishitsuCd { get; set; }

        /// <summary>
        /// 浄化槽台帳保健所コード 
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        public string TorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        public string Renban { get; set; }

        // 20150201 sou Start
        /// <summary>
        /// 料金
        /// </summary>
        public　decimal Ryokin { get; set; }
        // 20150201 sou End

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査セットコード {0}, 検査セット名称 {1},  浄化槽台帳保健所コード {2}, 浄化槽台帳年度  {3}, 浄化槽台帳連番 {4} ",
                    DaichoKensaKomokuSetCd, DaichoKensaSetNm, HokenjoCd, TorokuNendo, Renban);
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
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateBtnClickALOutput
    {

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
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateBtnClickALOutput : IUpdateBtnClickALOutput
    {

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
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateBtnClickApplicationLogic : BaseApplicationLogic<IUpdateBtnClickALInput, IUpdateBtnClickALOutput>
    {
        #region プロパティ

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "浄化槽台帳水質検査項目情報：KensakuBtnClick";

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
        /// 2014/12/11　HieuNH　　　新規作成
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
        /// 2014/12/11　HieuNH　　　新規作成
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/23  小松　　　　単独項目フラグのセット仕様の修正
        /// 　　　　　　　　　　　　・単独で追加チェックが入っているものが1件でもあれば→１：あり
        /// 　　　　　　　　　　　　・セットのみしかない場合→２：なし
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateBtnClickALOutput Execute(IUpdateBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateBtnClickALOutput output = new UpdateBtnClickALOutput();

            try
            {
                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();

                try
                {
                    // トランザクション開始
                    StartTransaction();

                    DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable dskkmUpdateDataTable = new DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable();

                    DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable dsktkmUpdateDataTable = new DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable();

                    IGetDaichoSuishitsuKensaKomokuMstByKeyBLInput dskkmRakkanBLInput = new GetDaichoSuishitsuKensaKomokuMstByKeyBLInput();
                    dskkmRakkanBLInput.DaichoKensaKomokuEdaban = input.DaichoSuishitsuKensaKomokuMstDataTableRakkan[0].DaichoKensaKomokuEdaban;
                    dskkmRakkanBLInput.HokenjoCd = input.HokenjoCd;
                    dskkmRakkanBLInput.Renban = input.Renban;
                    dskkmRakkanBLInput.TorokuNendo = input.TorokuNendo;
                    IGetDaichoSuishitsuKensaKomokuMstByKeyBLOutput dskkmRakkanBLOutput = new GetDaichoSuishitsuKensaKomokuMstByKeyBusinessLogic().Execute(dskkmRakkanBLInput);

                    // Check Rakkan 
                    if (dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].UpdateDt != input.DaichoSuishitsuKensaKomokuMstDataTableRakkan[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    string tankomokuFlg = "2";

                    foreach (SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchRow row in input.SuishitsuKensaKomokuInfoSearchDataTable)
                    {
                        //if (row.DaichoKensaSetKomokuKbn.Equals("2"))
                        if (row.DaichoKensaSetKomokuKbn.Equals("2") && row.AddFlg.Equals("1"))
                        {
                            tankomokuFlg = "1";
                            break;
                        }
                    }

                    // 検査セット名称
                    dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaSetNm = input.DaichoKensaSetNm;
                    // 検査セットコード
                    dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuSetCd = input.DaichoKensaKomokuSetCd;
                    // 水質コード 
                    dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuSuishitsuCd = input.SuishitsuCd;
                    // 単独項目フラグ
                    dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuTankomokuFlg = tankomokuFlg;
                    // 20150201 sou Start
                    // 検査料金
                    dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuKensaAmt = input.Ryokin;
                    // 手数料
                    dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].DaichoKensaKomokuTesuRyo = input.Ryokin;
                    // 20150201 sou End

                    // 更新日
                    dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].UpdateDt = now;
                    // 更新者
                    dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].UpdateUser = loginUser;
                    // 更新端末
                    dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0].UpdateTarm = pcUpdate;

                    dskkmUpdateDataTable.ImportRow(dskkmRakkanBLOutput.DaichoSuishitsuKensaKomokuMstDataTable[0]);

                    IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLInput dsktkmDeleteBLInput = new DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBLInput();
                    dsktkmDeleteBLInput.DaichoKensaKomokuEdaban = input.DaichoSuishitsuKensaKomokuMstDataTableRakkan[0].DaichoKensaKomokuEdaban;
                    dsktkmDeleteBLInput.HokenjoCd = input.HokenjoCd;
                    dsktkmDeleteBLInput.Renban = input.Renban;
                    dsktkmDeleteBLInput.TorokuNendo = input.TorokuNendo;
                    new DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdBusinessLogic().Execute(dsktkmDeleteBLInput);

                    foreach (SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchRow row in input.SuishitsuKensaKomokuInfoSearchDataTable)
                    {
                        if (row.AddFlg.Equals("0"))
                            continue;

                        DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstRow dsktkmNewRow = dsktkmUpdateDataTable.NewDaichoSuishitsuKensaTanKomokuMstRow();

                        // 浄化槽台帳保健所コード
                        dsktkmNewRow.JokasoHokenjoCd = input.HokenjoCd;
                        // 浄化槽台帳登録年度
                        dsktkmNewRow.JokasoTorokuNendo = input.TorokuNendo;
                        // 浄化槽台帳連番
                        dsktkmNewRow.JokasoRenban = input.Renban;
                        // 台帳検査項目枝番
                        dsktkmNewRow.DaichoKensaKomokuEdaban = input.DaichoSuishitsuKensaKomokuMstDataTableRakkan[0].DaichoKensaKomokuEdaban;
                        // 検査項目コード
                        dsktkmNewRow.DaichoKensaKomokuCd = row.SuishitsuShikenKoumokuCd;
                        // 証明書記載区分
                        dsktkmNewRow.DaichoKensaKomokuKisaiKbn = "1";
                        // 請求有無区分
                        dsktkmNewRow.DaichoKensaKomokuSeikyuUmuKbn = "1";
                        // セット項目
                        dsktkmNewRow.DaichoKensaSetKomokuKbn = row.DaichoKensaSetKomokuKbn;

                        // 登録日時
                        dsktkmNewRow.InsertDt = now;
                        // 登録者
                        dsktkmNewRow.InsertUser = loginUser;
                        // 登録端末
                        dsktkmNewRow.InsertTarm = pcUpdate;
                        // 更新日
                        dsktkmNewRow.UpdateDt = now;
                        // 更新者
                        dsktkmNewRow.UpdateUser = loginUser;
                        // 更新端末
                        dsktkmNewRow.UpdateTarm = pcUpdate;

                        dsktkmUpdateDataTable.AddDaichoSuishitsuKensaTanKomokuMstRow(dsktkmNewRow);
                    }

                    IUpdateDaichoSuishitsuKensaKomokuMstBLInput dskkmUpdateBLInput = new UpdateDaichoSuishitsuKensaKomokuMstBLInput();
                    dskkmUpdateBLInput.DaichoSuishitsuKensaKomokuMstDataTable = dskkmUpdateDataTable;
                    new UpdateDaichoSuishitsuKensaKomokuMstBusinessLogic().Execute(dskkmUpdateBLInput);

                    IUpdateDaichoSuishitsuKensaTanKomokuMstBLInput dsktkmUpdateBLInput = new UpdateDaichoSuishitsuKensaTanKomokuMstBLInput();
                    dsktkmUpdateBLInput.DaichoSuishitsuKensaTanKomokuMstDataTable = dsktkmUpdateDataTable;
                    new UpdateDaichoSuishitsuKensaTanKomokuMstBusinessLogic().Execute(dsktkmUpdateBLInput);

                    CompleteTransaction();
                }
                catch
                {
                    throw;
                }
                finally
                {
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
    }
    #endregion
}
