using System;
using System.Collections.Generic;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.DaichoSuishitsuKensaKomokuMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.DaichoSuishitsuKensaTanKomokuMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.SuishitsuKensaSetMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.SuishitsuShikenKoumokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.Utility
{
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KeiryoShomeiUtility
    /// <summary>
    /// 計量証明関連のユーティリティクラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/18　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class KeiryoShomeiUtility
    {
        #region 定数定義


        #endregion


        #region public メソッド

        #region KeiryoshomeiKensaRyokinShukei
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KeiryoshomeiKensaRyokinShukei
        /// <summary>
        /// 計量証明の検査料金集計の結果を取得
        /// </summary>
        /// <param name="kensaIraiDt">検査依頼日</param>
        /// <param name="jokasoHokenjoCd">浄化槽台帳保健所コード</param>
        /// <param name="jokasoTorokuNendo">浄化槽台帳年度</param>
        /// <param name="jokasoRenban">浄化槽台帳連番</param>
        /// <param name="kensaKomokuEdaban">検査項目枝番</param>
        /// <param name="kensaRyokin">検査料金(OUT)</param>
        /// <param name="shohizei">消費税(OUT)</param>
        /// <returns>処理結果（true：正常/false：異常）</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/18　小松　　    新規作成
        /// 2015/01/07　宗          単独検査項目のみの時にエラーになってしまう為、
        ///                         検査セットの料金取得で検索結果0件の場合はエラーを返さずにセット分の検査料金を0円にする。
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public static bool KeiryoshomeiKensaRyokinShukei(
                                                        string kensaIraiDt,
                                                        string jokasoHokenjoCd,
                                                        string jokasoTorokuNendo,
                                                        string jokasoRenban,
                                                        string kensaKomokuEdaban,
                                                        out decimal kensaRyokin,
                                                        out decimal shohizei)
        {
            // 戻り値を初期化
            kensaRyokin = 0;
            shohizei = 0;
            try
            {
                // パラメータチェック
                if (string.IsNullOrEmpty(kensaIraiDt) ||
                    string.IsNullOrEmpty(jokasoHokenjoCd) ||
                    string.IsNullOrEmpty(jokasoTorokuNendo) ||
                    string.IsNullOrEmpty(jokasoRenban) ||
                    string.IsNullOrEmpty(kensaKomokuEdaban))
                {
                    // 引数が不正
                    TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("引数が不正です。:{0}, {1}, {2}, {3}, {4}",
                                                        kensaIraiDt, jokasoHokenjoCd, jokasoTorokuNendo, jokasoRenban, kensaKomokuEdaban));
                    return false;
                }

                // 業者コード取得
                string gyoshaCd = string.Empty;
                {
                    IGetJokasoDaichoMstByJokasoDaichoNoBLInput input = new GetJokasoDaichoMstByJokasoDaichoNoBLInput();
                    // 浄化槽台帳保健所コード
                    input.HokenjoCd = jokasoHokenjoCd;
                    // 浄化槽台帳年度
                    input.TorokuNendo = jokasoTorokuNendo;
                    // 浄化槽台帳連番
                    input.Renban = jokasoRenban;
                    // 指定された浄化槽台帳番号と一致する浄化槽台帳マスタデータ取得を取得
                    IGetJokasoDaichoMstByJokasoDaichoNoBLOutput output = new GetJokasoDaichoMstByJokasoDaichoNoBusinessLogic().Execute(input);
                    if (output.JokasoDaichoMstDT == null || output.JokasoDaichoMstDT.Rows.Count == 0)
                    {
                        // 一致するデータなし
                        return false;
                    }
                    gyoshaCd = output.JokasoDaichoMstDT[0].JokasoSeikyuGyoshaCd;
                }

                // 検査セット料金を取得
                decimal setRyokin = 0;
                {
                    IGetSuishitsuKensaSetMstRyokinByJokasoDaichoNoBLInput input = new GetSuishitsuKensaSetMstRyokinByJokasoDaichoNoBLInput();
                    // 浄化槽台帳保健所コード
                    input.JokasoHokenjoCd = jokasoHokenjoCd;
                    // 浄化槽台帳年度
                    input.JokasoTorokuNendo = jokasoTorokuNendo;
                    // 浄化槽台帳連番
                    input.JokasoRenban = jokasoRenban;
                    // 検査項目枝番
                    input.DaichoKensaKomokuEdaban = kensaKomokuEdaban;
                    // 指定された浄化槽台帳番号＋検査項目枝番と一致する水質検査セットマスタ料金取得を取得
                    IGetSuishitsuKensaSetMstRyokinByJokasoDaichoNoBLOutput output = new GetSuishitsuKensaSetMstRyokinByJokasoDaichoNoBusinessLogic().Execute(input);
                    if (output.SuishitsuKensaSetMstRyokinDT == null || output.SuishitsuKensaSetMstRyokinDT.Rows.Count == 0)
                    {
                        // 一致するデータなし
                        setRyokin = 0;
                    }
                    else
                    {
                        // 会員価格適用判定を取得
                        if (KaiinUtility.KaiinKakakuTekiyoHantei(gyoshaCd) == 1)
                        {
                            // 会員価格適用対象：セット会員料金で計算
                            setRyokin = output.SuishitsuKensaSetMstRyokinDT[0].SetRyoukin;
                        }
                        else
                        {
                            // 会員価格適用非対象：セット非会員料金で計算
                            setRyokin = output.SuishitsuKensaSetMstRyokinDT[0].SetHikaiinRyoukin;
                        }
                    }
                }

                // 単項目料金を取得
                decimal tanRyokin = 0;
                {
                    IGetSuishitsuShikenAmtSumByJokasoDaichoNoBLInput input = new GetSuishitsuShikenAmtSumByJokasoDaichoNoBLInput();
                    // 浄化槽台帳保健所コード
                    input.JokasoHokenjoCd = jokasoHokenjoCd;
                    // 浄化槽台帳年度
                    input.JokasoTorokuNendo = jokasoTorokuNendo;
                    // 浄化槽台帳連番
                    input.JokasoRenban = jokasoRenban;
                    // 検査項目枝番
                    input.DaichoKensaKomokuEdaban = kensaKomokuEdaban;
                    // 指定された浄化槽台帳番号＋検査項目枝番と一致する水質試験料金合計取得を取得
                    IGetSuishitsuShikenAmtSumByJokasoDaichoNoBLOutput output = new GetSuishitsuShikenAmtSumByJokasoDaichoNoBusinessLogic().Execute(input);
                    if (output.SuishitsuShikenAmtSumDT == null || output.SuishitsuShikenAmtSumDT.Rows.Count == 0)
                    {
                        // 一致するデータなし
                        return false;
                    }
                    tanRyokin = output.SuishitsuShikenAmtSumDT[0].SuishitsuShikenKomokuAmtSum;
                }

                // 検査料金算出
                // 検査セット料金＋単項目料金
                kensaRyokin = setRyokin + tanRyokin;

                // 消費税率を取得
                decimal zeiRitsu = Boundary.Common.Common.GetSyohizei(kensaIraiDt);
                // 消費税計算
                // 消費税計算の端数処理（切り捨て）
                shohizei = Math.Floor(kensaRyokin * zeiRitsu);

            }
            catch (Exception ex)
            {
                // エラー処理
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("計量証明の検査料金集計エラー　ex:{1}", ex.Message));
            }

            return true;
        }
        #endregion

        #region GetSuishitsuSetKomokuNm
        /// <summary>
        /// 041 計量証明のセット検査項目名称取得
        /// </summary>
        /// <param name="setCd"></param>
        /// <param name="setNm"></param>
        /// <param name="komokuNm"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04　habu　　    新規作成
        /// 2014/12/04　habu　　    Moved from KensaHanteiUtility
        /// 2014/12/19　habu　　    クエリに誤りがあったため修正
        /// </history>
        /// <returns></returns>
        public static bool GetSuishitsuSetKomokuNm(string setCd, out string setNm, out string komokuNm)
        {
            bool result = false;

            // 水質検査セットマスタ取得
            setNm = string.Empty;
            {
                SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable template = new SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable();
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable);
                input.TableAdapterType = typeof(SuishitsuKensaSetMstTableAdapter);
                input.Query.AddEqualCond(template.SetCdColumn.ColumnName, setCd);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count > 0)
                {
                    setNm = ((SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable)output.GetDataTable)[0].SetNm;
                }
            }

            // 水質試験項目マスタ取得
            SuishitsuKensaSetMstDataSet.SuishitsuKensaKomokuListDataTable komokuTbl = new SuishitsuKensaSetMstDataSet.SuishitsuKensaKomokuListDataTable();
            {
                SuishitsuKensaSetMstDataSet.SuishitsuKensaKomokuListDataTable template = new SuishitsuKensaSetMstDataSet.SuishitsuKensaKomokuListDataTable();
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(SuishitsuKensaSetMstDataSet.SuishitsuKensaKomokuListDataTable);
                input.TableAdapterType = typeof(SuishitsuKensaKomokuListTableAdapter);
                input.Query.AddEqualCond(template.SetKomokuSetCdColumn.ColumnName, setCd);

                input.Query.AddOrderColAsInt(template.InjiJyunColumn.ColumnName);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                komokuTbl = (SuishitsuKensaSetMstDataSet.SuishitsuKensaKomokuListDataTable)output.GetDataTable;
            }

            // セット内の各項目を連結・表示
            List<string> koumokuList = new List<string>();

            foreach (SuishitsuKensaSetMstDataSet.SuishitsuKensaKomokuListRow komokuRow in komokuTbl)
            {
                koumokuList.Add(komokuRow.SeishikiNm);
            }

            // 連結結果を返す
            komokuNm = string.Join("、", koumokuList.ToArray());

            result = true;

            return result;
        }

        /// <summary>
        /// 041 計量証明のセット検査項目名称取得
        /// </summary>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKomokuEdaban"></param>
        /// <param name="setNm"></param>
        /// <param name="komokuNm"></param>
        /// <returns></returns>
        public static bool GetJokasoSuishitsuSetKomokuNm(string jokasoHokenjoCd, string jokasoTorokuNendo, string jokasoRenban, string kensaKomokuEdaban, out string setNm, out string komokuNm)
        {
            bool result = false;

            // 浄化槽台帳水質検査項目マスタ取得
            string setCd = string.Empty;
            string tankomokuFlg = string.Empty;
            {
                DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable template = new DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable();
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable);
                input.TableAdapterType = typeof(DaichoSuishitsuKensaKomokuMstTableAdapter);
                input.Query.AddEqualCond(template.JokasoHokenjoCdColumn.ColumnName, jokasoHokenjoCd);
                input.Query.AddEqualCond(template.JokasoTorokuNendoColumn.ColumnName, jokasoTorokuNendo);
                input.Query.AddEqualCond(template.JokasoRenbanColumn.ColumnName, jokasoRenban);
                input.Query.AddEqualCond(template.DaichoKensaKomokuEdabanColumn.ColumnName, kensaKomokuEdaban);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                if (output.GetDataTable.Rows.Count > 0)
                {
                    setCd = ((DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable)output.GetDataTable)[0].DaichoKensaKomokuSetCd;
                    tankomokuFlg = ((DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable)output.GetDataTable)[0].DaichoKensaKomokuTankomokuFlg;
                }
            }

            GetSuishitsuSetKomokuNm(setCd, out setNm, out komokuNm);

            // 単独項目フラグ = 1 の場合、浄化槽台帳水質検査単項目マスタを取得する
            DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuShikenKomokuDataTable komokuTbl = new DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuShikenKomokuDataTable();
            if (tankomokuFlg == "1")
            {
                // 浄化槽台帳水質検査単項目マスタ取得
                {
                    DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuShikenKomokuDataTable template = new DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuShikenKomokuDataTable();
                    IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                    input.DataTableType = typeof(DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuShikenKomokuDataTable);
                    input.TableAdapterType = typeof(DaichoSuishitsuShikenKomokuTableAdapter);
                    input.Query.AddEqualCond(template.JokasoHokenjoCdColumn.ColumnName, jokasoHokenjoCd);
                    input.Query.AddEqualCond(template.JokasoTorokuNendoColumn.ColumnName, jokasoTorokuNendo);
                    input.Query.AddEqualCond(template.JokasoRenbanColumn.ColumnName, jokasoRenban);
                    input.Query.AddEqualCond(template.DaichoKensaKomokuEdabanColumn.ColumnName, kensaKomokuEdaban);
                    input.Query.AddEqualCond(template.DaichoKensaSetKomokuKbnColumn.ColumnName, "2");

                    IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                    //20141204_HuyTX  set DataTable return from Output
                    komokuTbl = (DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuShikenKomokuDataTable)output.GetDataTable;
                    //End
                }
            }

            List<string> koumokuList = new List<string>();

            // 各項目を連結・表示
            foreach (DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuShikenKomokuRow komokuRow in komokuTbl)
            {
                koumokuList.Add(komokuRow.SeishikiNm);
            }

            // 連結結果を返す
            komokuNm += ("、" + string.Join("、", koumokuList.ToArray()));

            result = true;

            return result;
        }

        /// <summary>
        /// 041 計量証明のセット検査項目名称取得
        /// </summary>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaKomokuEdaban"></param>
        /// <param name="komokuNm"></param>
        /// <returns></returns>
        public static bool GetJokasoSuishitsuTanKigoNm(string jokasoHokenjoCd, string jokasoTorokuNendo, string jokasoRenban, string kensaKomokuEdaban, out string komokuNm)
        {
            bool result = false;

            DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoShikenKomokuTankigoDataTable komokuTbl = new DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoShikenKomokuTankigoDataTable();

            {
                DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoShikenKomokuTankigoDataTable template = new DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoShikenKomokuTankigoDataTable();
                IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
                input.DataTableType = typeof(DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoShikenKomokuTankigoDataTable);
                input.TableAdapterType = typeof(DaichoShikenKomokuTankigoTableAdapter);
                input.Query.AddEqualCond(template.JokasoHokenjoCdColumn.ColumnName, jokasoHokenjoCd);
                input.Query.AddEqualCond(template.JokasoTorokuNendoColumn.ColumnName, jokasoTorokuNendo);
                input.Query.AddEqualCond(template.JokasoRenbanColumn.ColumnName, jokasoRenban);
                input.Query.AddEqualCond(template.DaichoKensaKomokuEdabanColumn.ColumnName, kensaKomokuEdaban);
                input.Query.AddEqualCond(template.DaichoKensaSetKomokuKbnColumn.ColumnName, "2");

                input.Query.AddOrderCol(template.ConstRenbanColumn.ColumnName);

                IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

                //20141204_HuyTX  set DataTable return from Output
                komokuTbl = (DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoShikenKomokuTankigoDataTable)output.GetDataTable;
                //End
            }

            komokuNm = string.Empty;

            List<string> koumokuList = new List<string>();

            // 各項目を連結・表示
            foreach (DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoShikenKomokuTankigoRow komokuRow in komokuTbl)
            {
                koumokuList.Add(komokuRow.ConstNm);
            }

            // 連結結果を返す
            komokuNm += string.Join("、", koumokuList.ToArray());

            result = true;

            return result;
        }
        #endregion

        #endregion
    }
}
