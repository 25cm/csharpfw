using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.Boundary.Common;
using FukjBizSystem.Application.BusinessLogic.JokasoDaichoKanri;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeReport;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Generic.BusinessLogic;

namespace FukjBizSystem.Application.Utility
{
    public class HoteiKensaUtility
    {
        #region GetHoteiKensaRyokin
        /// <summary>
        /// 040 法定検査料金取得
        /// </summary>
        /// <param name="kensaShubetsu"></param>
        /// <param name="shoriTaishouJinin"></param>
        /// <param name="shoriHoshikiKbn"></param>
        /// <param name="tandokuKingaku7Jo"></param>
        /// <param name="gappeiKingaku7Jo"></param>
        /// <param name="tandokuKingaku11Jo"></param>
        /// <param name="gappeiKingaku11Jo"></param>
        /// <param name="gappeiKingakuNew11Jo"></param>
        /// <returns></returns>
        public static decimal GetHoteiKensaRyokin(
            string kensaShubetsu, int shoriTaishouJinin, string shoriHoshikiKbn
            , decimal tandokuKingaku7Jo, decimal gappeiKingaku7Jo, decimal tandokuKingaku11Jo, decimal gappeiKingaku11Jo, decimal gappeiKingakuNew11Jo)
        {
            decimal kensaRyokin = 0m;

            if (kensaShubetsu == Constants.KensaShubetsuConstant.KENSA_SHUBETSU_1)
            {
                if (shoriHoshikiKbn == Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU)
                {
                    kensaRyokin = tandokuKingaku7Jo;
                }
                else
                {
                    kensaRyokin = gappeiKingaku7Jo;
                }
            }
            else if (kensaShubetsu == Constants.KensaShubetsuConstant.KENSA_SHUBETSU_2)
            {
                if (shoriHoshikiKbn == Constants.ShoriHoshikiKbnConstant.SHORI_HOSHIKI_KBN_TANDOKU)
                {
                    kensaRyokin = tandokuKingaku11Jo;
                }
                else
                {
                    // 新料金を使用する
                    kensaRyokin = gappeiKingakuNew11Jo;
                }
            }

            // TODO 検査種別3が来ることは無い、でよいか?

            return kensaRyokin;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensaShubetsu"></param>
        /// <param name="shoriTaishouJinin"></param>
        /// <param name="shoriHoshikiKbn"></param>
        /// <returns></returns>
        public static decimal GetHoteiKensaRyokin(string kensaShubetsu, int shoriTaishouJinin, string shoriHoshikiKbn)
        {
            decimal tandokuKingaku7Jo = 0m;
            decimal gappeiKingaku7Jo = 0m;
            decimal tandokuKingaku11Jo = 0m;
            decimal gappeiKingaku11Jo = 0m;
            decimal gappeiKingakuNew11Jo = 0m;

            HoteiKensaRyokinMstDataSet.HoteiKensaRyokinMstRow ryokinRow = Common.GetHoteiKensaRyokinMstByNinsou(shoriTaishouJinin);

            // 2014.01.06 toyoda modify Null判定を追加
            if (ryokinRow != null)
            {
                tandokuKingaku7Jo = ryokinRow.TandokuKingaku7Jo;
                gappeiKingaku7Jo = ryokinRow.GappeiKingaku7Jo;
                tandokuKingaku11Jo = ryokinRow.TandokuKingaku11Jo;
                gappeiKingaku11Jo = ryokinRow.GappeiKingaku11Jo;
                gappeiKingakuNew11Jo = ryokinRow.GappeiKingakuNew11Jo;
            }

            return GetHoteiKensaRyokin(kensaShubetsu, shoriTaishouJinin, shoriHoshikiKbn, tandokuKingaku7Jo, gappeiKingaku7Jo, tandokuKingaku11Jo, gappeiKingaku11Jo, gappeiKingakuNew11Jo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="kensaShubetsu"></param>
        /// <returns></returns>
        public static decimal GetHoteiKensaRyokin(string jokasoHokenjoCd, string jokasoTorokuNendo, string jokasoRenban, string kensaShubetsu)
        {
            int shoriTaishouJinin = 0;
            string shoriHoshikiKbn = string.Empty;

            IGetJokasoDaichoMstByKeyBLInput input = new GetJokasoDaichoMstByKeyBLInput();
            input.HokenjoCd = jokasoHokenjoCd;
            input.TorokuNendo = jokasoTorokuNendo;
            input.Renban = jokasoRenban;

            IGetJokasoDaichoMstByKeyBLOutput output = new GetJokasoDaichoMstByKeyBusinessLogic().Execute(input);

            if (output.JokasoDaichoMstDT.Count == 0)
            {
                return 0m;
            }

            shoriTaishouJinin = output.JokasoDaichoMstDT[0].IsJokasoShoriTaishoJininNull() ? 0 : output.JokasoDaichoMstDT[0].JokasoShoriTaishoJinin;
            shoriHoshikiKbn = output.JokasoDaichoMstDT[0].IsJokasoShoriHosikiKbnNull() ? String.Empty : output.JokasoDaichoMstDT[0].JokasoShoriHosikiKbn;

            return GetHoteiKensaRyokin(kensaShubetsu, shoriTaishouJinin, shoriHoshikiKbn);
        }
        #endregion

        #region GetEnkaIonKako
        /// <summary>
        /// 塩化物イオンの過去値を取得
        /// </summary>
        /// <param name="jokasoHokenjoCd"></param>
        /// <param name="jokasoTorokuNendo"></param>
        /// <param name="jokasoRenban"></param>
        /// <param name="rowLimit"></param>
        /// <returns></returns>
        public static string GetEnkaIonKako(string jokasoHokenjoCd, string jokasoTorokuNendo, string jokasoRenban, string uketsukeDt, int rowLimit)
        {
            int kakoDataCnt = 0;
            KensaKekkaTblDataSet.KakoKensaKekkaDataTable kakoKekkaTbl = new KensaKekkaTblDataSet.KakoKensaKekkaDataTable();

            // 検査結果取得
            KensaKekkaTblDataSet.KakoKensaKekkaDataTable template = new KensaKekkaTblDataSet.KakoKensaKekkaDataTable();
            IStdFilteredGetDataBLInput input = new StdFilteredGetDataBLInput();
            input.DataTableType = typeof(KensaKekkaTblDataSet.KakoKensaKekkaDataTable);
            input.TableAdapterType = typeof(KakoKensaKekkaTableAdapter);

            input.Query.AddEqualCond(template.KensaIraiJokasoHokenjoCdColumn.ColumnName, jokasoHokenjoCd);
            input.Query.AddEqualCond(template.KensaIraiJokasoTorokuNendoColumn.ColumnName, jokasoTorokuNendo);
            input.Query.AddEqualCond(template.KensaIraiJokasoRenbanColumn.ColumnName, jokasoRenban);
            input.Query.AddLesserCond(template.KensaIraiSuishitsuUketsukeDtColumn.ColumnName, uketsukeDt);

            input.Query.AddOrderCol(template.KensaIraiSuishitsuUketsukeDtColumn.ColumnName, false);

            // 直近n件までを対象とする
            input.RowLimit = rowLimit;

            IStdFilteredGetDataBLOutput output = new StdFilteredGetDataBusinessLogic().Execute(input);

            kakoDataCnt = output.GetDataTable.Rows.Count;
            kakoKekkaTbl = (KensaKekkaTblDataSet.KakoKensaKekkaDataTable)output.GetDataTable;

            // 取得した過去値を結合
            string kekkaVal = string.Empty;
            foreach (KensaKekkaTblDataSet.KakoKensaKekkaRow row in kakoKekkaTbl.Rows)
            {
                kekkaVal = kekkaVal + " " + (row.IsKensaKekkaEnsoIonNodoNull() ? string.Empty : (int.Parse(row.KensaKekkaEnsoIonNodo.ToString())).ToString());
            }
            kekkaVal = kekkaVal.Trim();

            return kekkaVal;
        }
        #endregion

        #region Hotei11joIjoListCountCheck
        /// <summary>
        /// 水質異常一覧の件数確認
        /// </summary>
        /// <param name="Nendo"></param>
        /// <param name="IraiDateKbn"></param>
        /// <param name="IraiDateFrom"></param>
        /// <param name="IraiDateTo"></param>
        /// <param name="IraiNoFrom"></param>
        /// <param name="IraiNoTo"></param>
        /// <returns></returns>
        public static bool Hotei11joIjoListCountCheck(string Nendo, string IraiDateKbn, string IraiDateFrom, string IraiDateTo, string IraiNoFrom, string IraiNoTo, string ShishoCd
            , string shikenCd_ph, string shikenCd_toshido, string shikenCd_zanen, string shikenCd_bod)
        {
            bool res = true;

            // 検査結果取得
            ISelectPrintHotei11joIjoListByConditionDAInput kensaInput = new SelectPrintHotei11joIjoListByConditionDAInput();
            kensaInput.ShikenKomokuCdPh = shikenCd_ph;
            kensaInput.ShikenKomokuCdToshido = shikenCd_toshido;
            kensaInput.ShikenKomokuCdZanen = shikenCd_zanen;
            kensaInput.ShikenKomokuCdBod = shikenCd_bod;
            kensaInput.Nendo = Nendo;
            kensaInput.IraiDateKbn = IraiDateKbn;
            kensaInput.IraiDateFrom = IraiDateFrom;
            kensaInput.IraiDateTo = IraiDateTo;
            kensaInput.IraiNoFrom = IraiNoFrom;
            kensaInput.IraiNoTo = IraiNoTo;
            kensaInput.ShishoCd = ShishoCd;

            ISelectPrintHotei11joIjoListByConditionDAOutput output = new SelectPrintHotei11joIjoListByConditionDataAccess().Execute(kensaInput);

            #region to be removed
            //ISelectPrintHotei11joIjoListCountByConditionDAInput input = new SelectPrintHotei11joIjoListCountByConditionDAInput();
            //input.Nendo = Nendo;
            //input.IraiDateKbn = IraiDateKbn;
            //input.IraiDateFrom = IraiDateFrom;
            //input.IraiDateTo = IraiDateTo;
            //input.IraiNoFrom = IraiNoFrom;
            //input.IraiNoTo = IraiNoTo;
            //ISelectPrintHotei11joIjoListCountByConditionDAOutput output = new SelectPrintHotei11joIjoListCountByConditionDataAccess().Execute(input);
            #endregion

            res = output.PrintHotei11joIjoList.Count > 0 ? true : false;

            return res;
        }
        #endregion

        #region FollowListCountCheck
        /// <summary>
        /// フォロー一覧の件数確認
        /// </summary>
        /// <param name="Nendo"></param>
        /// <param name="IraiDateKbn"></param>
        /// <param name="IraiDateFrom"></param>
        /// <param name="IraiDateTo"></param>
        /// <param name="IraiNoFrom"></param>
        /// <param name="IraiNoTo"></param>
        /// <returns></returns>
        public static bool FollowListCountCheck(string Nendo, string IraiDateKbn, string IraiDateFrom, string IraiDateTo, string IraiNoFrom, string IraiNoTo, string ShishoCd
            , string shikenCd_ph, string shikenCd_toshido, string shikenCd_zanen, string shikenCd_bod)
        {
            bool res = true;

            // 検査結果取得
            ISelectPrintFollowKensaListByConditionDAInput kensaInput = new SelectPrintFollowKensaListByConditionDAInput();
            kensaInput.ShikenKomokuCdPh = shikenCd_ph;
            kensaInput.ShikenKomokuCdToshido = shikenCd_toshido;
            kensaInput.ShikenKomokuCdZanen = shikenCd_zanen;
            kensaInput.ShikenKomokuCdBod = shikenCd_bod;
            kensaInput.Nendo = Nendo;
            kensaInput.IraiDateKbn = IraiDateKbn;
            kensaInput.IraiDateFrom = IraiDateFrom;
            kensaInput.IraiDateTo = IraiDateTo;
            kensaInput.IraiNoFrom = IraiNoFrom;
            kensaInput.IraiNoTo = IraiNoTo;
            kensaInput.ShishoCd = ShishoCd;

            ISelectPrintFollowKensaListByConditionDAOutput output = new SelectPrintFollowKensaListByConditionDataAccess().Execute(kensaInput);

            #region to be removed
            //ISelectPrintFollowKensaListCountByConditionDAInput input = new SelectPrintFollowKensaListCountByConditionDAInput();
            //input.Nendo = Nendo;
            //input.IraiDateKbn = IraiDateKbn;
            //input.IraiDateFrom = IraiDateFrom;
            //input.IraiDateTo = IraiDateTo;
            //input.IraiNoFrom = IraiNoFrom;
            //input.IraiNoTo = IraiNoTo;
            //ISelectPrintFollowKensaListCountByConditionDAOutput output = new SelectPrintFollowKensaListCountByConditionDataAccess().Execute(input);
            #endregion

            res = output.PrintFollowKensaList.Count > 0 ? true : false;

            return res;
        }
        #endregion

    }
}
