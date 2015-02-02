using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.CrossCheck.SaisuiTekiseiTenkenList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.CrossCheck.SaisuiTekiseiTenkenList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISearchBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISearchBtnClickALInput : IBseALInput, IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SearchBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SearchBtnClickALInput : ISearchBtnClickALInput
    {
        /// <summary>
        /// 依頼番号（開始）
        /// </summary>
        public string IraiBangoFrom { get; set; }

        /// <summary>
        /// 依頼番号（終了）
        /// </summary>
        public string IraiBangoTo { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("依頼番号（開始）[{0}], 依頼番号（終了）[{1}], 年度[{2}]", IraiBangoFrom, IraiBangoTo, Nendo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISearchBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISearchBtnClickALOutput : IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SearchBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SearchBtnClickALOutput : ISearchBtnClickALOutput
    {
        /// <summary>
        /// SaisuiTekiseiTenkenListKensakuDataTable
        /// </summary>
        public KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable SaisuiTekiseiTenkenListKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SearchBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SearchBtnClickApplicationLogic : BaseApplicationLogic<ISearchBtnClickALInput, ISearchBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SaisuiTekiseiTenkenList：SearchBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SearchBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SearchBtnClickApplicationLogic()
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
        /// 2014/10/17　AnhNV　　    新規作成
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
        /// 2014/10/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISearchBtnClickALOutput Execute(ISearchBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISearchBtnClickALOutput output = new SearchBtnClickALOutput();

            try
            {
                // 検索ボタンクリック
                IGetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBLOutput blOutput
                    = new GetSaisuiTekiseiTenkenListKensakuByIraiBangoNendoBusinessLogic().Execute(input);
                KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuDataTable resultTable = blOutput.SaisuiTekiseiTenkenListKensakuDataTable;

                // 過去の塩化物イオン値取得
                IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLInput kakoInput = new GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLInput();

                foreach (KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row in resultTable)
                {
                    kakoInput.KensaIraiJokasoHokenjoCd = row.KensaIraiJokasoHokenjoCd;
                    kakoInput.KensaIraiJokasoTorokuNendo = row.KensaIraiJokasoTorokuNendo;
                    kakoInput.KensaIraiJokasoRenban = row.KensaIraiJokasoRenban;
                    kakoInput.KensaKekkaMochikomiDt = row.KensaKekkaMochikomiDt;
                    IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput kakoOutput = new GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBusinessLogic().Execute(kakoInput);

                    int kaiNo = 1; // maximum of 5 execution times
                    foreach (KensaKekkaTblDataSet.Kako5SaisuiTekiseiTenkenListRow kakoRow in kakoOutput.Kako5SaisuiTekiseiTenkenListDataTable)
                    {
                        row[string.Format("PastHoteiKbn{0}Col", kaiNo)] = kakoRow.KensaIraiHoteiKbn;
                        row[string.Format("PastDate{0}Col", kaiNo)] = kakoRow.PastDate;
                        if (!kakoRow.IsKensaKekkaSuisoIonNodoNull())
                        {
                            row[string.Format("PastPH{0}Col", kaiNo)] = kakoRow.KensaKekkaSuisoIonNodo;
                        }
                        if (!kakoRow.IsKensaKekkaYozonSansoryo1Null())
                        {
                            row[string.Format("PastYozonSansoRyoFrom{0}Col", kaiNo)] = kakoRow.KensaKekkaYozonSansoryo1;
                        }
                        if (!kakoRow.IsKensaKekkaYozonSansoryo2Null())
                        {
                            row[string.Format("PastYozonSansoRyoTo{0}Col", kaiNo)] = kakoRow.KensaKekkaYozonSansoryo2;
                        }
                        if (!kakoRow.IsKensaKekkaToshidoNull())
                        {
                            row[string.Format("PastToshido{0}Col", kaiNo)] = kakoRow.KensaKekkaToshido;
                        }
                        row[string.Format("PastToshidoHani{0}Col", kaiNo)] = kakoRow.KensaKekkaToshido2;
                        if (!kakoRow.IsKensaKekkaBODNull())
                        {
                            row[string.Format("PastBOD{0}Col", kaiNo)] = kakoRow.KensaKekkaBOD;
                        }
                        row[string.Format("PastBODHani{0}Col", kaiNo)] = kakoRow.KensaIraiBOD2;
                        row[string.Format("PastHyoka{0}Col", kaiNo)] = kakoRow.KensaKekkaEnsoIonNodoHantei;
                        if (!kakoRow.IsKensaKekkaEnsoIonNodoNull())
                        {
                            row[string.Format("PastValue{0}Col", kaiNo)] = kakoRow.KensaKekkaEnsoIonNodo;
                        }

                        kaiNo++;
                    }

                    // 平均(39), 発生率(98)
                    MakeHasseiRateAndAvg(row);
                }

                // Final result
                output.SaisuiTekiseiTenkenListKensakuDataTable = resultTable;
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

        #region MakeHasseiRateAndAvg
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeHasseiRateAndAvg
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/27　AnhNV    基本設計書_014_001_画面_SaisuiTekiseiTenken_V1.01
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void MakeHasseiRateAndAvg(KensaKekkaTblDataSet.SaisuiTekiseiTenkenListKensakuRow row)
        {
            int avgNum = 0;
            decimal pastValue = 0;
            if (!row.IsPastValue1ColNull())
            {
                pastValue += row.PastValue1Col;
                avgNum++;
            }
            if (!row.IsPastValue2ColNull())
            {
                pastValue += row.PastValue2Col;
                avgNum++;
            }
            if (!row.IsPastValue3ColNull())
            {
                pastValue += row.PastValue3Col;
                avgNum++;
            }
            if (!row.IsPastValue4ColNull())
            {
                pastValue += row.PastValue4Col;
                avgNum++;
            }
            if (!row.IsPastValue5ColNull())
            {
                pastValue += row.PastValue5Col;
                avgNum++;
            }

            // 平均(39)
            if (avgNum > 0)
            {
                //row.AverageValueCol = Math.Round(pastValue / avgNum, 1);
                row.AverageValueCol = Math.Round(pastValue / avgNum, 1, MidpointRounding.AwayFromZero);
            }
            // 発生率(98)
            if (!row.IsSoSuuColNull() && row.SoSuuCol != 0)
            {
                //row.HasseiRateCol = Math.Round((decimal)row.KakuninSuuCol / row.SoSuuCol * 100, 1);
                row.HasseiRateCol = Math.Round((decimal)row.KakuninSuuCol / row.SoSuuCol * 100, 1, MidpointRounding.AwayFromZero);
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
