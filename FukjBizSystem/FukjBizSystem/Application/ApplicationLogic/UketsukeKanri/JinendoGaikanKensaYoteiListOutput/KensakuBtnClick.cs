using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiListOutput;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiListOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// ChikuCdFrom
        /// </summary>
        string ChikuCdFrom { get; set; }

        /// <summary>
        /// ChikuCdTo
        /// </summary>
        string ChikuCdTo { get; set; }

        /// <summary>
        /// GyoshaCdFrom
        /// </summary>
        string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        string GyoshaCdTo { get; set; }

        /// <summary>
        /// 作表区分１－１
        /// </summary>
        bool SakuhyoKbn11 { get; set; }

        /// <summary>
        /// 作表区分１－２
        /// </summary>
        bool SakuhyoKbn12 { get; set; }

        /// <summary>
        /// 作表区分１－３
        /// </summary>
        bool SakuhyoKbn13 { get; set; }

        /// <summary>
        /// 作表区分２－１
        /// </summary>
        bool SakuhyoKbn21 { get; set; }

        /// <summary>
        /// 作表区分２－２
        /// </summary>
        bool SakuhyoKbn22 { get; set; }

        /// <summary>
        /// 作表区分２－３
        /// </summary>
        bool SakuhyoKbn23 { get; set; }

        /// <summary>
        /// 差分出力/出力差分
        /// </summary>
        bool SakuhyoKbn31 { get; set; }

        /// <summary>
        /// 差分出力/入力差分
        /// </summary>
        bool SakuhyoKbn32 { get; set; }

        /// <summary>
        /// 差分出力/すべて
        /// </summary>
        bool SakuhyoKbn33 { get; set; }

        /// <summary>
        /// KensaNendo 
        /// </summary>
        string KensaNendo { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// ChikuCdFrom
        /// </summary>
        public string ChikuCdFrom { get; set; }

        /// <summary>
        /// ChikuCdTo
        /// </summary>
        public string ChikuCdTo { get; set; }

        /// <summary>
        /// GyoshaCdFrom
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 作表区分１－１
        /// </summary>
        public bool SakuhyoKbn11 { get; set; }

        /// <summary>
        /// 作表区分１－２
        /// </summary>
        public bool SakuhyoKbn12 { get; set; }

        /// <summary>
        /// 作表区分１－３
        /// </summary>
        public bool SakuhyoKbn13 { get; set; }

        /// <summary>
        /// 作表区分２－１
        /// </summary>
        public bool SakuhyoKbn21 { get; set; }

        /// <summary>
        /// 作表区分２－２
        /// </summary>
        public bool SakuhyoKbn22 { get; set; }

        /// <summary>
        /// 作表区分２－３
        /// </summary>
        public bool SakuhyoKbn23 { get; set; }

        /// <summary>
        /// 差分出力/出力差分
        /// </summary>
        public bool SakuhyoKbn31 { get; set; }

        /// <summary>
        /// 差分出力/入力差分
        /// </summary>
        public bool SakuhyoKbn32 { get; set; }

        /// <summary>
        /// 差分出力/すべて
        /// </summary>
        public bool SakuhyoKbn33 { get; set; }

        /// <summary>
        /// KensaNendo 
        /// </summary>
        public string KensaNendo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("地区コード（開始）[0], 地区コード（終了）[{1}], 業者コード（開始）[{2}], 業者コード（終了）[{3}], 作表区分１－１[{4}], 作表区分１－２[{5}], 作表区分１－３[{6}], 作表区分２－１[{7}], 作表区分２－２[{8}], 作表区分２－３[{9}], 差分出力/出力差分[{10}], 差分出力/入力差分[{11}], 差分出力/すべて[{12}], KensaNendo[{13}]", 
                    new string[] {
                        ChikuCdFrom,
                        ChikuCdTo,
                        GyoshaCdFrom,
                        GyoshaCdTo,
                        SakuhyoKbn11.ToString(),
                        SakuhyoKbn12.ToString(),
                        SakuhyoKbn13.ToString(),
                        SakuhyoKbn21.ToString(),
                        SakuhyoKbn22.ToString(),
                        SakuhyoKbn23.ToString(),
                        SakuhyoKbn31.ToString(),
                        SakuhyoKbn32.ToString(),
                        SakuhyoKbn33.ToString(),
                        KensaNendo
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable ZenkaiKensaDataWrkKensakuDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        public ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable ZenkaiKensaDataWrkKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JinendoGaikanKensaYoteiListOutput：KensakuBtnCLick";

        /// <summary>
        /// loginUser
        /// </summary>
        private string _loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// loginTarm
        /// </summary>
        private string _loginTarm = Dns.GetHostName();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensakuBtnClickApplicationLogic()
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
        /// 2014/09/22  HuyTX　　    新規作成
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
        /// 2014/09/22  HuyTX　　 新規作成
        /// 2014/11/20  DatNT     v1.02  
        /// 2014/12/03  kiyokuni  仕様漏れ修正  
        /// 2014/12/03  DatNT       Update
        /// 2014/12/04  DatNT     v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

                //string sakuhyoKbn2 = input.SakuhyoKbn2;
                //IUpdateZenkaikensaDataWrkBLInput updateZenkaiBLInput;

                #region STEP 1 - ワークデータの削除

                IDeleteAllZenkaiKensaDataWrkBLInput deleteAllZenkaiKensaDataWrkBLInput = new DeleteAllZenkaiKensaDataWrkBLInput();
                new DeleteAllZenkaiKensaDataWrkBusinessLogic().Execute(deleteAllZenkaiKensaDataWrkBLInput);

                #endregion

                #region 2014/12/03 DatNT DEL

                //ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkDataTable wrkDT = new ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkDataTable();

                //#region STEP 2 - 対象浄化槽の追加

                //IGetDataInsertZenkaiKensaDataWrkBySearchCondBLInput blInput = new GetDataInsertZenkaiKensaDataWrkBySearchCondBLInput();
                //blInput.Nendo           = input.KensaNendo;
                //blInput.ChikuCdFrom     = input.ChikuCdFrom;
                //blInput.ChikuCdTo       = input.ChikuCdTo;
                //blInput.SakuhyoKbn11    = input.SakuhyoKbn11;
                //blInput.SakuhyoKbn12    = input.SakuhyoKbn12;
                //blInput.SakuhyoKbn13    = input.SakuhyoKbn13;
                //blInput.SakuhyoKbn31    = input.SakuhyoKbn31;
                //blInput.SakuhyoKbn32    = input.SakuhyoKbn32;
                //IGetDataInsertZenkaiKensaDataWrkBySearchCondBLOutput blOutput = new GetDataInsertZenkaiKensaDataWrkBySearchCondBusinessLogic().Execute(blInput);

                //if (blOutput.DataInsertZenkaiKensaDataWrkDT != null && blOutput.DataInsertZenkaiKensaDataWrkDT.Count > 0)
                //{
                //    foreach (JokasoDaichoMstDataSet.DataInsertZenkaiKensaDataWrkRow row in blOutput.DataInsertZenkaiKensaDataWrkDT)
                //    {
                //        ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkRow wrkRow = wrkDT.NewZenkaiKensaDataWrkRow();

                //        // 浄化槽台帳保健所コード
                //        wrkRow.JokasoHokenjoCd = row.JokasoHokenjoCd;

                //        // 浄化槽台帳年度
                //        wrkRow.JokasoTorokuNendo = row.JokasoTorokuNendo;

                //        // 浄化槽台帳連番
                //        wrkRow.JokasoRenban = row.JokasoRenban;

                //        // 検査依頼法定区分
                //        wrkRow.KensaIraiHoteiKbn = string.Empty;

                //        // 検査依頼保健所コード
                //        wrkRow.KensaIraiHokenjoCd = string.Empty;

                //        // 検査依頼年度
                //        wrkRow.KensaIraiNendo = string.Empty;

                //        // 検査依頼連番
                //        wrkRow.KensaIraiRenban = string.Empty;

                //        // 計量証明検査依頼年度
                //        wrkRow.KeiryoShomeiIraiNendo = string.Empty;

                //        // 計量証明支所コード
                //        wrkRow.KeiryoShomeiIraiShishoCd = string.Empty;

                //        // 計量証明依頼連番
                //        wrkRow.KeiryoShomeiIraiRenban = string.Empty;

                //        // 業者コード
                //        wrkRow.GyoshaCd = string.Empty;

                //        // 業者名称
                //        wrkRow.GyoshaNm = string.Empty;

                //        // 人槽区分
                //        if (!row.IsJokasoShoriTaishoJininNull())
                //        {
                //            wrkRow.NinsoKbn = row.JokasoShoriTaishoJinin <= 50 ? "1" : "2";
                //        }

                //        // 検査時期
                //        wrkRow.KensaPeriod = string.Empty;

                //        // 市町村
                //        wrkRow.ShichosonNm = row.ChikuNm;

                //        // 設置者名
                //        wrkRow.SetchishaNm = row.JokasoSetchishaNm;

                //        // 設置場所住所
                //        wrkRow.SetchishaAdr = row.JokasoSetchiBashoAdr;

                //        // 人槽
                //        wrkRow.Ninso = row.JokasoShoriTaishoJinin;

                //        // 処理方式
                //        wrkRow.ShoriHoshikiKbn = row.JokasoShoriHosikiKbn;

                //        // 前回検査日
                //        wrkRow.ZenkaiKensaDt = string.Empty;

                //        // 検査区分
                //        wrkRow.KensaKbn = string.Empty;

                //        // 設置者区分
                //        wrkRow.SetchishaKbn = row.JokasoSetchishaKbn;

                //        // 設置者コード
                //        wrkRow.SetchishaCd = row.JokasoSetchishaCd;

                //        // 設定区分
                //        wrkRow.SetteiKbn = "0";

                //        // 市町村コード
                //        wrkRow.ShichosonCd = row.JokasoGenChikuCd;

                //        // 連携区分
                //        if (row.IsIraiMakeKbnNull() || string.IsNullOrEmpty(row.IraiMakeKbn))
                //        {
                //            wrkRow.RenkeiKbn = "0";
                //        }
                //        else
                //        {
                //            wrkRow.RenkeiKbn = "1";
                //        }

                //        // 入力区分
                //        if (row.IsIraiMakeKbnNull())
                //        {
                //            wrkRow.NyuryokuKbn = "0";
                //        }
                //        else
                //        {
                //            wrkRow.NyuryokuKbn = row.IraiMakeKbn == "1" ? "1" : "0";
                //        }

                //        wrkRow.InsertDt = now;
                //        wrkRow.InsertTarm = _loginTarm;
                //        wrkRow.InsertUser = _loginUser;
                //        wrkRow.UpdateDt = now;
                //        wrkRow.UpdateTarm = _loginTarm;
                //        wrkRow.UpdateUser = _loginUser;

                //        wrkDT.AddZenkaiKensaDataWrkRow(wrkRow);
                //        wrkRow.AcceptChanges();
                //        wrkRow.SetAdded();
                //    }
                //}

                //#endregion

                //#region STEP 3 - 11条外観検査 判定

                //foreach (ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkRow wrkRow in wrkDT)
                //{
                //    IGetJinendoGaikanKensaYoteiListOutput3BLInput step3Input = new GetJinendoGaikanKensaYoteiListOutput3BLInput();
                //    step3Input.KensaIraiHoteiKbn = "2";
                //    step3Input.KensaIraiJokasoHokenjoCd = wrkRow.JokasoHokenjoCd;
                //    step3Input.KensaIraiJokasoTorokuNendo = wrkRow.JokasoTorokuNendo;
                //    step3Input.KensaIraiJokasoRenban = wrkRow.JokasoRenban;
                //    step3Input.Nendo = input.KensaNendo;
                //    IGetJinendoGaikanKensaYoteiListOutput3BLOutput step3Output = new GetJinendoGaikanKensaYoteiListOutput3BusinessLogic().Execute(step3Input);

                //    if (step3Output.JinendoGaikanKensaYoteiListOutput3DT != null && step3Output.JinendoGaikanKensaYoteiListOutput3DT.Count > 0)
                //    {
                //        KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput3Row step3Row = step3Output.JinendoGaikanKensaYoteiListOutput3DT[0];

                //        // 検査依頼法定区分
                //        wrkRow.KensaIraiHoteiKbn = step3Row.KensaIraiHoteiKbn;

                //        // 検査依頼保健所コード
                //        wrkRow.KensaIraiHokenjoCd = step3Row.KensaIraiHokenjoCd;

                //        // 検査依頼年度
                //        wrkRow.KensaIraiNendo = step3Row.KensaIraiNendo;

                //        // 検査依頼連番
                //        wrkRow.KensaIraiRenban = step3Row.KensaIraiRenban;

                //        // 業者コード
                //        wrkRow.GyoshaCd = step3Row.KensaIraiIkkatsuSeikyusakiCd;

                //        // 業者名称
                //        wrkRow.GyoshaNm = step3Row.GyoshaNm;

                //        // 検査時期
                //        wrkRow.KensaPeriod = "1";
                        
                //        if (!string.IsNullOrEmpty(step3Row.NenTsukiBi))
                //        {
                //            wrkRow.ZenkaiKensaDt = step3Row.NenTsukiBi;
                //        }
                //        else
                //        {
                //            wrkRow.ZenkaiKensaDt = step3Row.YoteiNenTsukiBi;
                //        }

                //        // 検査区分
                //        wrkRow.KensaKbn = "1";

                //        // 設定区分
                //        wrkRow.SetteiKbn = "1";
                //    }
                //}

                //#endregion

                //#region STEP 4 - 11条水質検査 判定

                //foreach (ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkRow wrkRow in wrkDT.Select("SetteiKbn = '0'"))
                //{
                //    IGetJinendoGaikanKensaYoteiListOutput4BLInput step4Input = new GetJinendoGaikanKensaYoteiListOutput4BLInput();
                //    step4Input.KensaIraiHoteiKbn = "3";
                //    step4Input.KensaIraiJokasoHokenjoCd = wrkRow.JokasoHokenjoCd;
                //    step4Input.KensaIraiJokasoTorokuNendo = wrkRow.JokasoTorokuNendo;
                //    step4Input.KensaIraiJokasoRenban = wrkRow.JokasoRenban;
                //    IGetJinendoGaikanKensaYoteiListOutput4BLOutput step4Output = new GetJinendoGaikanKensaYoteiListOutput4BusinessLogic().Execute(step4Input);

                //    if (step4Output.JinendoGaikanKensaYoteiListOutput4DT != null && step4Output.JinendoGaikanKensaYoteiListOutput4DT.Count > 0)
                //    {
                //        KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput4Row step4Row = step4Output.JinendoGaikanKensaYoteiListOutput4DT[0];

                //        // 検査依頼法定区分
                //        wrkRow.KensaIraiHoteiKbn = step4Row.KensaIraiHoteiKbn;

                //        // 検査依頼保健所コード
                //        wrkRow.KensaIraiHokenjoCd = step4Row.KensaIraiHokenjoCd;

                //        // 検査依頼年度
                //        wrkRow.KensaIraiNendo = step4Row.KensaIraiNendo;

                //        // 検査依頼連番
                //        wrkRow.KensaIraiRenban = step4Row.KensaIraiRenban;

                //        // 業者コード
                //        wrkRow.GyoshaCd = step4Row.KensaIraiSeikyuGyoshaCd;

                //        // 業者名称
                //        wrkRow.GyoshaNm = step4Row.GyoshaNm;

                //        // 検査時期
                //        wrkRow.KensaPeriod = "1";

                //        // 前回検査日
                //        wrkRow.ZenkaiKensaDt = step4Row.KensaIraiSuishitsuUketsukeDt;

                //        // 検査区分
                //        wrkRow.KensaKbn = "2";

                //        // 設定区分
                //        wrkRow.SetteiKbn = "1";
                //    }
                //}

                //#endregion

                //#region STEP 5 - 7条検査 判定

                //foreach (ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkRow wrkRow in wrkDT.Select("SetteiKbn = '0'"))
                //{
                //    IGetJinendoGaikanKensaYoteiListOutput5BLInput step5Input = new GetJinendoGaikanKensaYoteiListOutput5BLInput();
                //    step5Input.KensaIraiHoteiKbn = "1";
                //    step5Input.KensaIraiJokasoHokenjoCd = wrkRow.JokasoHokenjoCd;
                //    step5Input.KensaIraiJokasoTorokuNendo = wrkRow.JokasoTorokuNendo;
                //    step5Input.KensaIraiJokasoRenban = wrkRow.JokasoRenban;
                //    IGetJinendoGaikanKensaYoteiListOutput5BLOutput step5Output = new GetJinendoGaikanKensaYoteiListOutput5BusinessLogic().Execute(step5Input);

                //    if (step5Output.JinendoGaikanKensaYoteiListOutput5DT != null && step5Output.JinendoGaikanKensaYoteiListOutput5DT.Count > 0)
                //    {
                //        KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput5Row step5Row = step5Output.JinendoGaikanKensaYoteiListOutput5DT[0];

                //        // 検査依頼法定区分
                //        wrkRow.KensaIraiHoteiKbn = step5Row.KensaIraiHoteiKbn;

                //        // 検査依頼保健所コード
                //        wrkRow.KensaIraiHokenjoCd = step5Row.KensaIraiHokenjoCd;

                //        // 検査依頼年度
                //        wrkRow.KensaIraiNendo = step5Row.KensaIraiNendo;

                //        // 検査依頼連番
                //        wrkRow.KensaIraiRenban = step5Row.KensaIraiRenban;

                //        // 業者コード
                //        wrkRow.GyoshaCd = step5Row.KensaIraiHoshutenkenGyoshaCd;

                //        // 業者名称
                //        wrkRow.GyoshaNm = step5Row.GyoshaNm;

                //        // 検査時期
                //        wrkRow.KensaPeriod = "2";

                //        // 前回検査日
                //        wrkRow.ZenkaiKensaDt = step5Row.KensaIraiSuishitsuUketsukeDt;

                //        // 検査区分
                //        wrkRow.KensaKbn = "3";

                //        // 設定区分
                //        wrkRow.SetteiKbn = "1";
                //    }
                //}
                //#endregion

                //#region STEP 6 - 計量証明判定

                //foreach (ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkRow wrkRow in wrkDT.Select("SetteiKbn = '0'"))
                //{
                //    IGetJinendoGaikanKensaYoteiListOutput6BLInput step6Input = new GetJinendoGaikanKensaYoteiListOutput6BLInput();
                //    step6Input.KensaIraiJokasoHokenjoCd = wrkRow.JokasoHokenjoCd;
                //    step6Input.KensaIraiJokasoTorokuNendo = wrkRow.JokasoTorokuNendo;
                //    step6Input.KensaIraiJokasoRenban = wrkRow.JokasoRenban;
                //    step6Input.Nendo = input.KensaNendo;
                //    IGetJinendoGaikanKensaYoteiListOutput6BLOutput step6Output = new GetJinendoGaikanKensaYoteiListOutput6BusinessLogic().Execute(step6Input);

                //    if (step6Output.JinendoGaikanKensaYoteiListOutput6DT != null && step6Output.JinendoGaikanKensaYoteiListOutput6DT.Count > 0)
                //    {
                //        KeiryoShomeiIraiTblDataSet.JinendoGaikanKensaYoteiListOutput6Row step6Row = step6Output.JinendoGaikanKensaYoteiListOutput6DT[0];

                //        // 計量証明検査依頼年度
                //        wrkRow.KeiryoShomeiIraiNendo = step6Row.KeiryoShomeiIraiNendo;

                //        // 計量証明支所コード
                //        wrkRow.KeiryoShomeiIraiShishoCd = step6Row.KeiryoShomeiIraiSishoCd;

                //        // 計量証明依頼連番
                //        wrkRow.KeiryoShomeiIraiRenban = step6Row.KeiryoShomeiIraiRenban;

                //        // 業者コード
                //        wrkRow.GyoshaCd = step6Row.KeiryoShomeiSeikyuGyoshaCd;

                //        // 業者名称
                //        wrkRow.GyoshaNm = step6Row.GyoshaNm;

                //        // 検査時期
                //        wrkRow.KensaPeriod = "2";

                //        // 前回検査日
                //        wrkRow.ZenkaiKensaDt = step6Row.KeiryoShomeiIraiUketsukeDt;

                //        // 検査区分
                //        wrkRow.KensaKbn = "4";

                //        // 設定区分
                //        wrkRow.SetteiKbn = "1"; //2014.12.03 kiyokuni 仕様間違い修正 
                //    }
                //}

                //#endregion
                
                //// Insert
                //IUpdateZenkaikensaDataWrkBLInput insertInput = new UpdateZenkaikensaDataWrkBLInput();
                //insertInput.ZenkaiKensaDataWrkDataTable = wrkDT;
                //IUpdateZenkaikensaDataWrkBLOutput insertOutput = new UpdateZenkaikensaDataWrkBusinessLogic().Execute(insertInput);

                #endregion

                #region 2014/11/20 DatNT v1.02 DEL
                //#region case 1, 2

                ////get data from JokasoDaichoMst
                //IGetJinendoGaikanOutputStep1BySearchCondBLInput getJokasoDaichoMstBLInput = new GetJinendoGaikanOutputStep1BySearchCondBLInput();
                //getJokasoDaichoMstBLInput.SakuhyoKbn1 = input.SakuhyoKbn1;
                //getJokasoDaichoMstBLInput.KensaNendo = input.KensaNendo;
                //IGetJinendoGaikanOutputStep1BySearchCondBLOutput getJokasoDaichoMstBLOutput = new GetJinendoGaikanOutputStep1BySearchCondBusinessLogic().Execute(getJokasoDaichoMstBLInput);

                ////insert ZenkaiKensaDataWrk
                //if (getJokasoDaichoMstBLOutput.JinendoGaikanOutputStep1DataTable.Count > 0)
                //{
                //    //  insert
                //    updateZenkaiBLInput = new UpdateZenkaikensaDataWrkBLInput();
                //    updateZenkaiBLInput.ZenkaiKensaDataWrkDataTable = CreateZenkaiKensaDataWrkDTInsert(getJokasoDaichoMstBLOutput.JinendoGaikanOutputStep1DataTable);
                //    new UpdateZenkaikensaDataWrkBusinessLogic().Execute(updateZenkaiBLInput);
                //}

                //#endregion

                //#region case 3, 4

                //if (sakuhyoKbn2 == "1" || sakuhyoKbn2 == "3")
                //{
                //    //case 3
                //    IGetJinendoGaikanOutputStep2BySearchCondBLInput case3BLInput = new GetJinendoGaikanOutputStep2BySearchCondBLInput();
                //    case3BLInput.CaseOption = 3;
                //    case3BLInput.KensaNendo = input.KensaNendo;
                //    IGetJinendoGaikanOutputStep2BySearchCondBLOutput case3BLOutput = new GetJinendoGaikanOutputStep2BySearchCondBusinessLogic().Execute(case3BLInput);

                //    //  update
                //    updateZenkaiBLInput = new UpdateZenkaikensaDataWrkBLInput();
                //    updateZenkaiBLInput.ZenkaiKensaDataWrkDataTable = CreateZenkaiKensaDataWrkDTUpdateByKensaIrai(case3BLOutput.JinendoGaikanOutputStep2DataTable);
                //    new UpdateZenkaikensaDataWrkBusinessLogic().Execute(updateZenkaiBLInput);

                //    //case 4
                //    IGetJinendoGaikanOutputStep2BySearchCondBLInput case4BLInput = new GetJinendoGaikanOutputStep2BySearchCondBLInput();
                //    case4BLInput.CaseOption = 4;
                //    IGetJinendoGaikanOutputStep2BySearchCondBLOutput case4BLOutput = new GetJinendoGaikanOutputStep2BySearchCondBusinessLogic().Execute(case4BLInput);

                //    //  update
                //    updateZenkaiBLInput = new UpdateZenkaikensaDataWrkBLInput();
                //    updateZenkaiBLInput.ZenkaiKensaDataWrkDataTable = CreateZenkaiKensaDataWrkDTUpdateByKensaIrai(case4BLOutput.JinendoGaikanOutputStep2DataTable);
                //    new UpdateZenkaikensaDataWrkBusinessLogic().Execute(updateZenkaiBLInput);
                //}

                //#endregion

                //#region case 5,6

                //if (sakuhyoKbn2 == "2" || sakuhyoKbn2 == "3")
                //{
                //    //case 5
                //    IGetJinendoGaikanOutputStep2BySearchCondBLInput case5BLInput = new GetJinendoGaikanOutputStep2BySearchCondBLInput();
                //    case5BLInput.CaseOption = 5;
                //    IGetJinendoGaikanOutputStep2BySearchCondBLOutput case5BLOutput = new GetJinendoGaikanOutputStep2BySearchCondBusinessLogic().Execute(case5BLInput);

                //    //  update
                //    updateZenkaiBLInput = new UpdateZenkaikensaDataWrkBLInput();
                //    updateZenkaiBLInput.ZenkaiKensaDataWrkDataTable = CreateZenkaiKensaDataWrkDTUpdateByKensaIrai(case5BLOutput.JinendoGaikanOutputStep2DataTable);
                //    new UpdateZenkaikensaDataWrkBusinessLogic().Execute(updateZenkaiBLInput);

                //    //case 6
                //    IGetJinendoGaikanOutputStep3BySearchCondBLInput case6BLInput = new GetJinendoGaikanOutputStep3BySearchCondBLInput();
                //    IGetJinendoGaikanOutputStep3BySearchCondBLOutput case6BLOutput = new GetJinendoGaikanOutputStep3BySearchCondBusinessLogic().Execute(case6BLInput);

                //    //  update
                //    updateZenkaiBLInput = new UpdateZenkaikensaDataWrkBLInput();
                //    updateZenkaiBLInput.ZenkaiKensaDataWrkDataTable = CreateZenkaiKensaDataWrkDTUpdateByKeiryoShomei(case6BLOutput.JinendoGaikanOutputStep3DataTable);
                //    new UpdateZenkaikensaDataWrkBusinessLogic().Execute(updateZenkaiBLInput);

                //}

                //#endregion
                #endregion

                #region 2014/12/03 DatNT ADD

                // STEP 2 - 対象浄化槽の追加
                IInsertJinendoGaikenStep2BLInput blInput = new InsertJinendoGaikenStep2BLInput();
                blInput.Nendo           = input.KensaNendo;
                blInput.ChikuCdFrom     = input.ChikuCdFrom;
                blInput.ChikuCdTo       = input.ChikuCdTo;
                blInput.SakuhyoKbn11    = input.SakuhyoKbn11;
                blInput.SakuhyoKbn12    = input.SakuhyoKbn12;
                blInput.SakuhyoKbn13    = input.SakuhyoKbn13;
                blInput.SakuhyoKbn31    = input.SakuhyoKbn31;
                blInput.SakuhyoKbn32    = input.SakuhyoKbn32;
                blInput.Now             = now;
                IInsertJinendoGaikenStep2BLOutput blOuput = new InsertJinendoGaikenStep2BusinessLogic().Execute(blInput);

                // STEP 3 - 11条外観検査 判定
                if (input.SakuhyoKbn21 || input.SakuhyoKbn23)
                {
                    IUpdateJinendoGaikenStep3BLInput step3Input = new UpdateJinendoGaikenStep3BLInput();
                    step3Input.Nendo = input.KensaNendo;
                    IUpdateJinendoGaikenStep3BLOutput step3Ouput = new UpdateJinendoGaikenStep3BusinessLogic().Execute(step3Input);
                }

                // STEP 4 - 11条水質検査 判定
                if (input.SakuhyoKbn21 || input.SakuhyoKbn23)
                {
                    IUpdateJinendoGaikenStep4BLInput step4Input = new UpdateJinendoGaikenStep4BLInput();
                    step4Input.Nendo = input.KensaNendo;
                    IUpdateJinendoGaikenStep4BLOutput step4Output = new UpdateJinendoGaikenStep4BusinessLogic().Execute(step4Input);
                }

                // STEP 5 - 7条検査 判定
                if (input.SakuhyoKbn22 || input.SakuhyoKbn23)
                {
                    IUpdateJinendoGaikenStep5BLInput step5Input = new UpdateJinendoGaikenStep5BLInput();
                    IUpdateJinendoGaikenStep5BLOutput step5Output = new UpdateJinendoGaikenStep5BusinessLogic().Execute(step5Input);
                }

                // STEP 6 - 計量証明判定
                if (input.SakuhyoKbn22 || input.SakuhyoKbn23)
                {
                    IUpdateJinendoGaikenStep6BLInput step6Input = new UpdateJinendoGaikenStep6BLInput();
                    step6Input.Nendo = input.KensaNendo;
                    IUpdateJinendoGaikenStep6BLOutput step6Output = new UpdateJinendoGaikenStep6BusinessLogic().Execute(step6Input);
                }

                #endregion

                //search data 
                IGetZenkaiKensaDataWrkBySearchCondBLInput searchBLInput = new GetZenkaiKensaDataWrkBySearchCondBLInput();
                
                //searchBLInput.ChikuCdFrom = input.ChikuCdFrom;
                //searchBLInput.ChikuCdTo = input.ChikuCdTo;
                searchBLInput.GyoshaCdFrom = input.GyoshaCdFrom;
                searchBLInput.GyoshaCdTo = input.GyoshaCdTo;

                IGetZenkaiKensaDataWrkBySearchCondBLOutput searchBLOutput = new GetZenkaiKensaDataWrkBySearchCondBusinessLogic().Execute(searchBLInput);
                output.ZenkaiKensaDataWrkKensakuDataTable = searchBLOutput.ZenkaiKensaDataWrkKensakuDataTable;

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
        
        #endregion
    }
    #endregion
}
