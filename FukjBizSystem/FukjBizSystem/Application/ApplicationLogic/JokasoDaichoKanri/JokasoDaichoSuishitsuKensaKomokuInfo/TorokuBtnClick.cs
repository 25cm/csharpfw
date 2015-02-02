using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.ApplicationLogic;
using FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Application.DataSet;
using System.Net;

namespace FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorokuBtnClickALInput
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
    interface ITorokuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable {get; set;}

        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ
        /// </summary>
        DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTable { get; set; }

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
    //  クラス名 ： TorokuBtnClickALInput
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
    class TorokuBtnClickALInput : ITorokuBtnClickALInput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable { get; set; }

        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ
        /// </summary>
        public DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTable { get; set; }

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
        public decimal Ryokin { get; set; }
        // 20150201 sou End

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査セットコード {0}, 検査セット名称 {1}, 水質コード {2}, 浄化槽台帳保健所コード {3}, 浄化槽台帳年度  {4}, 浄化槽台帳連番 {5} ", 
                    DaichoKensaKomokuSetCd, DaichoKensaSetNm, SuishitsuCd, HokenjoCd, TorokuNendo, Renban);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ITorokuBtnClickALOutput
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
    interface ITorokuBtnClickALOutput
    {
        /// <summary>
        /// ErrorCode
        /// </summary>
        int ErrorCode { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorokuBtnClickALOutput
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
    class TorokuBtnClickALOutput : ITorokuBtnClickALOutput
    {
        /// <summary>
        /// ErrorCode
        /// </summary>
        public int ErrorCode { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TorokuBtnClickApplicationLogic
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
    class TorokuBtnClickApplicationLogic : BaseApplicationLogic<ITorokuBtnClickALInput, ITorokuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "浄化槽台帳水質検査項目情報：KensakuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： TorokuBtnClickApplicationLogic
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
        public TorokuBtnClickApplicationLogic()
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
        /// 2014/12/22　HieuNH　　　Fix bug
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ITorokuBtnClickALOutput Execute(ITorokuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ITorokuBtnClickALOutput output = new TorokuBtnClickALOutput();

            try
            {
                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();

                try
                {
                    // トランザクション開始
                    StartTransaction();

                    //// ADD HieuNH 2014/12/22 BEGIN
                    IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput dskkmBLInput = new GetDaichoSuishitsuKensaKomokuMstByJokasoCdBLInput();
                    dskkmBLInput.HokenjoCd = input.HokenjoCd;
                    dskkmBLInput.TorokuNendo = input.TorokuNendo;
                    dskkmBLInput.Renban = input.Renban;
                    IGetDaichoSuishitsuKensaKomokuMstByJokasoCdBLOutput dskkmBLOutput = new GetDaichoSuishitsuKensaKomokuMstByJokasoCdBusinessLogic().Execute(dskkmBLInput);
                    if (dskkmBLOutput.DaichoSuishitsuKensaKomokuMstDataTable != null && dskkmBLOutput.DaichoSuishitsuKensaKomokuMstDataTable.Count == 10)
                    {
                        output.ErrorCode = 1;
                        return output;
                    }
                    //// ADD HieuNH 2014/12/22 END

                    DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable dskkmUpdateDataTable = new DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable();

                    DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable dsktkmUpdateDataTable = new DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable();

                    string tankomokuFlg = "2";

                    foreach (SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchRow row in input.SuishitsuKensaKomokuInfoSearchDataTable)
                    {
                        if (row.DaichoKensaSetKomokuKbn.Equals("2") && row.AddFlg.Equals("1"))
                        {
                            tankomokuFlg = "1";
                            break;
                        }
                    }

                    DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstRow dskkmNewRow = dskkmUpdateDataTable.NewDaichoSuishitsuKensaKomokuMstRow();

                    // 浄化槽台帳保健所コード
                    dskkmNewRow.JokasoHokenjoCd = input.HokenjoCd;
                    // 浄化槽台帳登録年度
                    dskkmNewRow.JokasoTorokuNendo = input.TorokuNendo;
                    // 浄化槽台帳連番
                    dskkmNewRow.JokasoRenban = input.Renban;

                    string edaban = "0";

                    for (int i = 0; i < 10; i++)
                    {
                        if (input.DaichoSuishitsuKensaKomokuMstDataTable.Select("DaichoKensaKomokuEdaban = '" + i.ToString() + "'").Length == 0)
                        {
                            edaban = i.ToString();
                            break;
                        }
                    }
                    // 検査項目枝番
                    dskkmNewRow.DaichoKensaKomokuEdaban = edaban;
                    // 検査セット名称
                    dskkmNewRow.DaichoKensaSetNm = input.DaichoKensaSetNm;
                    // 検査セットコード
                    dskkmNewRow.DaichoKensaKomokuSetCd = input.DaichoKensaKomokuSetCd;
                    // 水質コード 
                    dskkmNewRow.DaichoKensaKomokuSuishitsuCd = input.SuishitsuCd;
                    // 単独項目フラグ
                    dskkmNewRow.DaichoKensaKomokuTankomokuFlg = tankomokuFlg;
                    // 20150201 sou Start
                    // 検査料金
                    dskkmNewRow.DaichoKensaKomokuKensaAmt = input.Ryokin;
                    // 手数料
                    dskkmNewRow.DaichoKensaKomokuTesuRyo = input.Ryokin;
                    // 20150201 sou End

                    // 登録日時
                    dskkmNewRow.InsertDt = now;
                    // 登録者
                    dskkmNewRow.InsertUser = loginUser;
                    // 登録端末
                    dskkmNewRow.InsertTarm = pcUpdate;
                    // 更新日
                    dskkmNewRow.UpdateDt = now;
                    // 更新者
                    dskkmNewRow.UpdateUser = loginUser;
                    // 更新端末
                    dskkmNewRow.UpdateTarm = pcUpdate;

                    dskkmUpdateDataTable.AddDaichoSuishitsuKensaKomokuMstRow(dskkmNewRow);


                    foreach (SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchRow row in input.SuishitsuKensaKomokuInfoSearchDataTable)
                    {
                        if(row.AddFlg.Equals("0"))
                            continue;

                        DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstRow dsktkmNewRow = dsktkmUpdateDataTable.NewDaichoSuishitsuKensaTanKomokuMstRow();

                        // 浄化槽台帳保健所コード
                        dsktkmNewRow.JokasoHokenjoCd = input.HokenjoCd;
                        // 浄化槽台帳登録年度
                        dsktkmNewRow.JokasoTorokuNendo = input.TorokuNendo;
                        // 浄化槽台帳連番
                        dsktkmNewRow.JokasoRenban = input.Renban;
                        // 台帳検査項目枝番
                        dsktkmNewRow.DaichoKensaKomokuEdaban = dskkmNewRow.DaichoKensaKomokuEdaban;
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
