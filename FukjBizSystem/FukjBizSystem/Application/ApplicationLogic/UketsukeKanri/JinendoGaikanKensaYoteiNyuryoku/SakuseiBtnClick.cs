using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaKekkaInputShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISakuseiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISakuseiBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 作成年度
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// 作成年度
        /// </summary>
        JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable JinendoGaikanKensaYoteiNyuryokuDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SakuseiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SakuseiBtnClickALInput : ISakuseiBtnClickALInput
    {
        /// <summary>
        /// 作成年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// 作成年度
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable JinendoGaikanKensaYoteiNyuryokuDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("作成年度 [{0}],  ",
                    new string[] {
                        Nendo, });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISakuseiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISakuseiBtnClickALOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SakuseiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SakuseiBtnClickALOutput : ISakuseiBtnClickALOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SakuseiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SakuseiBtnClickApplicationLogic : BaseApplicationLogic<ISakuseiBtnClickALInput, ISakuseiBtnClickALOutput>
    {
        #region プロパティ

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JinendoGaikanKensaYoteiNyuryoku：SakuseiBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SakuseiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SakuseiBtnClickApplicationLogic()
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
        /// 2014/11/20　HieuNH　　　新規作成
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
        /// 2014/11/20　HieuNH　　　新規作成
        /// 2014/12/01　HieuNH　　　v1.01
        /// 2014/12/02　HieuNH　　　v1.36 DB定義書
        /// 2014/12/04　HieuNH　　　Skip record have JokasoNo = null
        /// 2014/12/15　HieuNH　　　Check ZenkaiKensaDt null
        /// 2014/12/18  kiyokuni    DateTime.TryParseではyyyyMMddを判定できないため修正
        /// 2015/01/08  habu        検査依頼採番区分を修正 ( -> 70 )
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISakuseiBtnClickALOutput Execute(ISakuseiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISakuseiBtnClickALOutput output = new SakuseiBtnClickALOutput();

            try
            {
                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();

                // トランザクション開始
                StartTransaction();

                #region Update JinendoGaikanYoteiOutputTblDataTable

                JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable jinendoGaikanYoteiOutputTblDataTable = new JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable();

                // 一覧をループしながら更新処理を行う。
                for (int i = 0; i < input.JinendoGaikanKensaYoteiNyuryokuDataTable.Count; i++)
                {
                    //// MODIFY HieuNH 2014/12/04 BEGIN
                    if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsJokasoNoNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoNo))
                        continue;
                    //if (string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoNo))
                    //    continue;
                    //// MODIFY HieuNH 2014/12/04 END

                    IGetJinendoGaikanYoteiOutputTblByKeyBLInput blInput = new GetJinendoGaikanYoteiOutputTblByKeyBLInput();
                    blInput.Nendo = input.Nendo;
                    blInput.JokasoHokenjoCd = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoHokenjoCd;
                    blInput.JokasoTorokuNendo = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoTorokuNendo;
                    blInput.JokasoRenban = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoRenban;
                    IGetJinendoGaikanYoteiOutputTblByKeyBLOutput blOutput = new GetJinendoGaikanYoteiOutputTblByKeyBusinessLogic().Execute(blInput);

                    if (blOutput.JinendoGaikanYoteiOutputTblDT.Count > 0)
                    {
                        // UPDATE
                        // Check Rakkan Lock
                        if (blOutput.JinendoGaikanYoteiOutputTblDT[0].UpdateDt != input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].UpdateDt)
                        {
                            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                        }

                        // 更新日
                        blOutput.JinendoGaikanYoteiOutputTblDT[0].UpdateDt = now;

                        // 更新者
                        blOutput.JinendoGaikanYoteiOutputTblDT[0].UpdateUser = loginUser;

                        // 更新端末
                        blOutput.JinendoGaikanYoteiOutputTblDT[0].UpdateTarm = pcUpdate;

                        // 業者コード
                        blOutput.JinendoGaikanYoteiOutputTblDT[0].SeikyuGyoshaCd = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].SeikyuGyoshaCd;

                        //// MODIFY HieuNH 2014/12/15 BEGIN
                        // 予定年月
                        bool isValid = true;
                        // MM
                        string mm = string.Empty;
                        //if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                        //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                        //else
                        //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                        //// yyyy
                        string yyyy = string.Empty;
                        //if (int.Parse(mm) >= 4)
                        //    yyyy = input.Nendo;
                        //else
                        //    yyyy = (int.Parse(input.Nendo) + 1).ToString();
                        //blOutput.JinendoGaikanYoteiOutputTblDT[0].YoteiNengetsu = yyyy + mm;

                        //DateTime zenkaikensaDt;
                        if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                        {
                            if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsZenkaiKensaDtNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt))
                                isValid = false;
                            else
                            {
                                if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Length == 8)
                                    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                                //if (DateTime.TryParse(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt, out zenkaikensaDt))
                                //mm = zenkaikensaDt.Month.ToString().PadLeft(2, '0');
                                else
                                    isValid = false;
                            }
                        }
                        else
                        {
                            mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                        }
                        if (isValid)
                        {
                            if (int.Parse(mm) >= 4)
                                yyyy = input.Nendo;
                            else
                                yyyy = (int.Parse(input.Nendo) + 1).ToString();
                            blOutput.JinendoGaikanYoteiOutputTblDT[0].YoteiNengetsu = yyyy + mm;
                        }
                        else
                            blOutput.JinendoGaikanYoteiOutputTblDT[0].YoteiNengetsu = string.Empty;

                        //// MODIFY HieuNH 2014/12/15 END

                        // 依頼作成区分
                        blOutput.JinendoGaikanYoteiOutputTblDT[0].IraiMakeKbn = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].Sakusei;

                        jinendoGaikanYoteiOutputTblDataTable.ImportRow(blOutput.JinendoGaikanYoteiOutputTblDT[0]);
                    }
                    else
                    {
                        // INSERT

                        JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblRow newRow = jinendoGaikanYoteiOutputTblDataTable.NewJinendoGaikanYoteiOutputTblRow();

                        // 年度
                        newRow.Nendo = input.Nendo;

                        // 浄化槽台帳保健所コード
                        newRow.JokasoHokenjoCd = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoHokenjoCd;

                        // 浄化槽台帳年度
                        newRow.JokasoTorokuNendo = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoTorokuNendo;

                        // 浄化槽台帳連番
                        newRow.JokasoRenban = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoRenban;

                        // 登録日時
                        newRow.InsertDt = now;

                        // 登録者
                        newRow.InsertUser = loginUser;

                        // 登録端末
                        newRow.InsertTarm = pcUpdate;

                        // 更新日
                        newRow.UpdateDt = now;

                        // 更新者
                        newRow.UpdateUser = loginUser;

                        // 更新端末
                        newRow.UpdateTarm = pcUpdate;

                        // 業者コード
                        newRow.SeikyuGyoshaCd = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].SeikyuGyoshaCd;

                        //// MODIFY HieuNH 2014/12/15 BEGIN
                        // 予定年月
                        // MM
                        string mm = string.Empty;
                        //if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                        //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                        //else
                        //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                        //// yyyy
                        string yyyy = string.Empty;
                        //if (int.Parse(mm) >= 4)
                        //    yyyy = input.Nendo;
                        //else
                        //    yyyy = (int.Parse(input.Nendo) + 1).ToString();
                        //newRow.YoteiNengetsu = yyyy + mm;
                        bool isValid = true;

                        //DateTime zenkaikensaDt;
                        if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                        {
                            if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsZenkaiKensaDtNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt))
                                isValid = false;
                            else
                            {
                                if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Length == 8)
                                    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                                //if (DateTime.TryParse(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt, out zenkaikensaDt))
                                //    mm = zenkaikensaDt.Month.ToString().PadLeft(2, '0');
                                else
                                    isValid = false;
                            }
                        }
                        else
                        {
                            mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                        }
                        if (isValid)
                        {
                            if (int.Parse(mm) >= 4)
                                yyyy = input.Nendo;
                            else
                                yyyy = (int.Parse(input.Nendo) + 1).ToString();
                            newRow.YoteiNengetsu = yyyy + mm;
                        }
                        else
                            newRow.YoteiNengetsu = string.Empty;

                        //// MODIFY HieuNH 2014/12/15 END

                        // 依頼作成区分
                        newRow.IraiMakeKbn = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].Sakusei;

                        // 連携作成区分
                        newRow.RenkeiMakeKbn = "2";

                        jinendoGaikanYoteiOutputTblDataTable.AddJinendoGaikanYoteiOutputTblRow(newRow);
                    }
                }

                IUpdateJinendoGaikanYoteiOutputTblBLInput updateBLInput = new UpdateJinendoGaikanYoteiOutputTblBLInput();
                updateBLInput.JinendoGaikanYoteiOutputTblDT = jinendoGaikanYoteiOutputTblDataTable;
                new UpdateJinendoGaikanYoteiOutputTblBusinessLogic().Execute(updateBLInput);

                #endregion

                #region Update KensaIraiTbl & KensaKekkaTbl

                KensaIraiTblDataSet.KensaIraiTblDataTable insertKensaIraiTbl = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                KensaKekkaTblDataSet.KensaKekkaTblDataTable insertKensaKekkaTbl = new KensaKekkaTblDataSet.KensaKekkaTblDataTable();

                for (int i = 0; i < input.JinendoGaikanKensaYoteiNyuryokuDataTable.Count; i++)
                {
                    // 一覧で作成チェックがONのもののみを追加。
                    //// MODIFY HieuNH 2014/12/03 BEGIN
                    if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsJokasoNoNull() || input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].Sakusei.Equals("0"))
                        continue;
                    //if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].Sakusei.Equals("0"))
                    //    continue;
                    //// MODIFY HieuNH 2014/12/03 END

                    IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLInput blSearchForUpdateInput = new GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLInput();
                    blSearchForUpdateInput.JokasoHokenjoCd = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoHokenjoCd;
                    blSearchForUpdateInput.JokasoTorokuNendo = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoTorokuNendo;
                    blSearchForUpdateInput.JokasoRenban = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoRenban;
                    IGetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBLOutput blSearchForUpdateOutput = new GetJinendoGaikanKensaYoteiNyuryokuUpdateByHokenjoNendoRenbanBusinessLogic().Execute(blSearchForUpdateInput);

                    if (blSearchForUpdateOutput.JinendoGaikanKensaYoteiNyuryokuUpdateDataTable.Count == 0)
                        continue;

                    JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuUpdateRow tempRow = blSearchForUpdateOutput.JinendoGaikanKensaYoteiNyuryokuUpdateDataTable[0];

                    #region Update KensaIraiTbl

                    KensaIraiTblDataSet.KensaIraiTblRow insertKensaIraiRow = insertKensaIraiTbl.NewKensaIraiTblRow();

                    // 検査依頼法定区分
                    insertKensaIraiRow.KensaIraiHoteiKbn = "2";
                    // 検査依頼保健所コード
                    insertKensaIraiRow.KensaIraiHokenjoCd = tempRow.JokasoHokenjoCd;
                    // 検査依頼年度
                    insertKensaIraiRow.KensaIraiNendo = input.Nendo;
                    // 検査依頼連番
                    insertKensaIraiRow.KensaIraiRenban = Utility.Saiban.GetSaibanRenban(input.Nendo, string.Concat(Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_GAIKAN_KENSA));
                    //insertKensaIraiRow.KensaIraiRenban = Utility.Saiban.GetSaibanRenban(input.Nendo, string.Concat("7", tempRow.JokasoHoteiSishoCd));
                    // 検査依頼受付支所
                    insertKensaIraiRow.KensaIraiUketsukeShishoKbn = tempRow.JokasoHoteiSishoCd;
                    // 検査依頼支店区分
                    insertKensaIraiRow.KensaIraiShitenKbn = "";
                    // 浄化槽保健所コード
                    insertKensaIraiRow.KensaIraiJokasoHokenjoCd = tempRow.JokasoHokenjoCd;
                    // 浄化槽台帳登録年度
                    insertKensaIraiRow.KensaIraiJokasoTorokuNendo = tempRow.JokasoTorokuNendo;
                    // 浄化槽台帳連番
                    insertKensaIraiRow.KensaIraiJokasoRenban = tempRow.JokasoRenban;
                    // 水質検査依頼番号
                    insertKensaIraiRow.KensaIraiSuishitsuIraiNo = string.Empty;
                    // 水質検査受付日
                    insertKensaIraiRow.KensaIraiSuishitsuUketsukeDt = string.Empty;
                    // 新方式区分
                    insertKensaIraiRow.KensaIraiShinHoshikiKbn = string.Empty;
                    // スクリーニング区分
                    insertKensaIraiRow.KensaIraiScreeningKbn = "0";
                    // 受付区分
                    insertKensaIraiRow.KensaIraiUketsukeKbn = string.Empty;
                    // 現金収入区分
                    insertKensaIraiRow.KensaIraiGenkinShunyuKbn = string.Empty;
                    // 法根拠区分
                    insertKensaIraiRow.KensaIraiHokonkyoKbn = tempRow.IsJokasoHouKonkyoKbnNull() ? string.Empty : tempRow.JokasoHouKonkyoKbn;
                    // 保健所受理保健所コード
                    insertKensaIraiRow.KensaIraiHokenjoJyuriHokenjoCd = tempRow.IsJokasoHokenjoJuriNoHokenCdNull() ? string.Empty : tempRow.JokasoHokenjoJuriNoHokenCd;
                    // 保健所受理年度
                    insertKensaIraiRow.KensaIraiHokenjoJyuriNendo = tempRow.IsJokasoHokenjoJuriNoNendoNull() ? string.Empty : tempRow.JokasoHokenjoJuriNoNendo;
                    // 保健所受理市町村コード
                    insertKensaIraiRow.KensaIraiHokenjoJyuriShichosonCd = tempRow.IsJokasoHokenjoJuriNoSichosonCdNull() ? string.Empty : tempRow.JokasoHokenjoJuriNoSichosonCd;
                    // 保健所受理連番
                    insertKensaIraiRow.KensaIraiHokenjoJyuriRenban = tempRow.IsJokasoHokenjoJuriNoRenbanNull() ? string.Empty : tempRow.JokasoHokenjoJuriNoRenban;
                    // 保証登録検査機関
                    insertKensaIraiRow.KensaIraiHoshoTorokuKensakikanCd = tempRow.IsJokasoHoshoNoKensakikanNull() ? string.Empty : tempRow.JokasoHoshoNoKensakikan;
                    // 保証登録年度
                    insertKensaIraiRow.KensaIraiHoshoTorokuNendo = tempRow.IsJokasoHoshoNoNendoNull() ? string.Empty : tempRow.JokasoHoshoNoNendo;
                    // 保証登録連番
                    insertKensaIraiRow.KensaIraiHoshoTorokuRenban = tempRow.IsJokasoHoshoNoRenbanNull() ? string.Empty : tempRow.JokasoHoshoNoRenban;
                    // 依頼年
                    insertKensaIraiRow.KensaIraiNen = now.ToString("yyyy");
                    // 依頼月
                    insertKensaIraiRow.KensaIraiTsuki = now.ToString("MM");
                    // 依頼日
                    insertKensaIraiRow.KensaIraiBi = now.ToString("dd");
                    // 検査年
                    insertKensaIraiRow.KensaIraiKensaNen = string.Empty;
                    // 検査月
                    insertKensaIraiRow.KensaIraiKensaTsuki = string.Empty;
                    // 検査日
                    insertKensaIraiRow.KensaIraiKensaBi = string.Empty;

                    //// MODIFY HieuNH 2014/12/15 BEGIN
                    // 検査予定月
                    string mm = string.Empty;
                    //if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                    //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                    //else
                    //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                    //insertKensaIraiRow.KensaIraiKensaYoteiTsuki = mm;

                    // 検査予定年
                    string yyyy = string.Empty;
                    //if (int.Parse(mm) >= 4)
                    //    yyyy = input.Nendo;
                    //else
                    //    yyyy = (int.Parse(input.Nendo) + 1).ToString();
                    //insertKensaIraiRow.KensaIraiKensaYoteiNen = yyyy;
                    bool isValid = true;

                    //DateTime zenkaikensaDt;
                    if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                    {
                        if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsZenkaiKensaDtNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt))
                            isValid = false;
                        else
                        {
                            if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Length == 8)
                                mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                            //if (DateTime.TryParse(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt, out zenkaikensaDt))
                            //    mm = zenkaikensaDt.Month.ToString().PadLeft(2, '0');
                            else
                                isValid = false;
                        }
                    }
                    else
                    {
                        mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                    }
                    if (isValid)
                    {
                        insertKensaIraiRow.KensaIraiKensaYoteiTsuki = mm;

                        if (int.Parse(mm) >= 4)
                            yyyy = input.Nendo;
                        else
                            yyyy = (int.Parse(input.Nendo) + 1).ToString();
                        insertKensaIraiRow.KensaIraiKensaYoteiNen = yyyy;
                    }
                    else
                    {
                        insertKensaIraiRow.KensaIraiKensaYoteiTsuki = string.Empty;
                        insertKensaIraiRow.KensaIraiKensaYoteiNen = string.Empty;
                    }

                    //// MODIFY HieuNH 2014/12/15 END

                    // 検査予定日
                    insertKensaIraiRow.KensaIraiKensaYoteiBi = "00";
                    // 取下年
                    insertKensaIraiRow.KensaIraiTorisageNen = string.Empty;
                    // 取下月
                    insertKensaIraiRow.KensaIraiTorisageTsuki = string.Empty;
                    // 取下日
                    insertKensaIraiRow.KensaIraiTorisageBi = string.Empty;
                    // 検査料金
                    if ("1".Equals(tempRow.JokasoShoriHosikiKbn))
                        insertKensaIraiRow.KensaIraiKensaAmt = tempRow.TandokuKingaku11Jo;
                    else
                        insertKensaIraiRow.KensaIraiKensaAmt = tempRow.GappeiKingakuNew11Jo;
                    // TODO 処理方式0,4の場合の対応が必要

                    // 前渡還付金
                    insertKensaIraiRow.KensaIraiMaewatashiKanpuAmt = 0;
                    // 合計金額 
                    insertKensaIraiRow.KensaIraiGokeiAmt = insertKensaIraiRow.KensaIraiKensaAmt;
                    // 入金済金額
                    insertKensaIraiRow.KensaIraiNyukinzumiAmt = 0;
                    // 入金方法 v1.01: From string.Empty -> "005"
                    insertKensaIraiRow.KensaIraiNyukinHohoKbn = "005";
                    // 最終入金年
                    insertKensaIraiRow.KensaIraiSaishuNyukinNen = string.Empty;
                    // 最終入金月
                    insertKensaIraiRow.KensaIraiSaishuNyukinTsuki = string.Empty;
                    // 最終入金日
                    insertKensaIraiRow.KensaIraiSaishuNyukinBi = string.Empty;
                    // 請求番号
                    insertKensaIraiRow.KensaIraiSeikyuNo = string.Empty;
                    // 請求年
                    insertKensaIraiRow.KensaIraiSeikyuNen = string.Empty;
                    // 請求月
                    insertKensaIraiRow.KensaIraiSeikyuTsuki = string.Empty;
                    // 請求日
                    insertKensaIraiRow.KensaIraiSeikyuBi = string.Empty;
                    // 請求額
                    insertKensaIraiRow.KensaIraiSeikyuAmt = 0;
                    // 再請求番号
                    insertKensaIraiRow.KensaIraiSaiseikyuNo = string.Empty;
                    // 再請求年
                    insertKensaIraiRow.KensaIraiSaiseikyuNen = string.Empty;
                    // 再請求月
                    insertKensaIraiRow.KensaIraiSaiseikyuTsuki = string.Empty;
                    // 再請求日
                    insertKensaIraiRow.KensaIraiSaiseikyuBi = string.Empty;
                    // 再請求額
                    insertKensaIraiRow.KensaIraiSaiseikyuAmt = 0;
                    // 入金完了区分
                    insertKensaIraiRow.KensaIraiNyukinKanryoKbn = "0";
                    // 請求書発行区分
                    insertKensaIraiRow.KensaIraiSeikyushoHakkoKbn = "0";
                    // 結果書発行区分
                    insertKensaIraiRow.KensaIraiKekkashoHakkoKbn = "0";
                    // 前回法定区分
                    insertKensaIraiRow.KensaIraiZenkaiHoteiKbn = tempRow.IsKensaIraiHoteiKbnNull() ? string.Empty : tempRow.KensaIraiHoteiKbn;
                    // 前回依頼保健所コード
                    insertKensaIraiRow.KensaIraiZenkaiHokenjoCd = tempRow.IsKensaIraiHokenjoCdNull() ? string.Empty : tempRow.KensaIraiHokenjoCd;
                    // 前回依頼年度
                    insertKensaIraiRow.KensaIraiZenkaiNendo = tempRow.IsKensaIraiNendoNull() ? string.Empty : tempRow.KensaIraiNendo;
                    // 前回依頼連番
                    insertKensaIraiRow.KensaIraiZenkaiRenban = tempRow.IsKensaIraiRenbanNull() ? string.Empty : tempRow.KensaIraiRenban;
                    // 月次更新区分
                    insertKensaIraiRow.KensaIraiGetsujiKoshinKbn = string.Empty;
                    // 一括請求区分
                    insertKensaIraiRow.KensaIraiIkkatsuSeikyuKbn = string.Empty;
                    // 料金区分
                    insertKensaIraiRow.KensaIraiRyokinKbn = string.Empty;
                    // 月次請求区分
                    insertKensaIraiRow.KensaIraiGetsujiSeikyuKbn = string.Empty;
                    // 更新区分
                    insertKensaIraiRow.KensaIraiKoshinKbn = string.Empty;
                    // 送付日
                    insertKensaIraiRow.KensaIraiSofuDt = string.Empty;
                    // 引落年
                    insertKensaIraiRow.KensaIraiHikiotoshiNen = string.Empty;
                    // 引落月
                    insertKensaIraiRow.KensaIraiHikiotoshiTsuki = string.Empty;
                    // 引落日
                    insertKensaIraiRow.KensaIraiHikiotoshiBi = string.Empty;
                    // 発行区分1
                    insertKensaIraiRow.KensaIraiHakkoKbn1 = "0";
                    // 発行区分2
                    insertKensaIraiRow.KensaIraiHakkoKbn2 = "0";
                    // 発行区分3
                    insertKensaIraiRow.KensaIraiHakkoKbn3 = "0";
                    // 発行区分4
                    insertKensaIraiRow.KensaIraiHakkoKbn4 = "0";
                    // 発行区分5
                    insertKensaIraiRow.KensaIraiHakkoKbn5 = "0";
                    // 発行区分6
                    insertKensaIraiRow.KensaIraiHakkoKbn6 = "0";
                    // 発行区分7
                    insertKensaIraiRow.KensaIraiHakkoKbn7 = "0";
                    // 発行区分8
                    insertKensaIraiRow.KensaIraiHakkoKbn8 = "0";
                    // 発行区分9
                    insertKensaIraiRow.KensaIraiGyoseiHokokuLevel = "0";
                    // 発行区分10
                    insertKensaIraiRow.KensaIraiHakkoKbn10 = "0";
                    // 保守点検回数
                    insertKensaIraiRow.KensaIraiHoshuTenkenKaisu = string.Empty;
                    // 前回判定
                    insertKensaIraiRow.KensaIraiZenkaiHantei = tempRow.IsKensaKekkaHanteiNull() ? string.Empty : tempRow.KensaKekkaHantei;
                    // 前回検査日
                    insertKensaIraiRow.KensaIraiZenkaiKensaDt = (tempRow.IsKensaIraiKensaNenNull() || tempRow.IsKensaIraiKensaTsukiNull() || tempRow.IsKensaIraiKensaBiNull())
                        ? string.Empty : tempRow.KensaIraiKensaNen + tempRow.KensaIraiKensaTsuki + tempRow.KensaIraiKensaBi;
                    // 前回所見手書き
                    insertKensaIraiRow.KensaIraiZenkaiShokenTegaki = string.Empty;
                    // 設置者名（漢字）
                    insertKensaIraiRow.KensaIraiSetchishaNm = tempRow.IsJokasoSetchishaNmNull() ? string.Empty : tempRow.JokasoSetchishaNm;
                    // 検査依頼設置者（住所）
                    insertKensaIraiRow.KensaIraiSetchishaAdr = tempRow.IsJokasoSetchishaAdrNull() ? string.Empty : tempRow.JokasoSetchishaAdr;
                    // 設置者（郵便番号）
                    insertKensaIraiRow.KensaIraiSetchishaZipCd = tempRow.IsJokasoSetchishaZipCdNull() ? string.Empty : tempRow.JokasoSetchishaZipCd;
                    // 設置者（電話番号）
                    insertKensaIraiRow.KensaIraiSetchishaTelNo = tempRow.IsJokasoSetchishaTelNoNull() ? string.Empty : tempRow.JokasoSetchishaTelNo;
                    // 検査依頼設置場所（住所）
                    insertKensaIraiRow.KensaIraiSetchibashoAdr = tempRow.IsJokasoSetchiBashoAdrNull() ? string.Empty : tempRow.JokasoSetchiBashoAdr;
                    // 設置場所（郵便番号）
                    insertKensaIraiRow.KensaIraiSetchibashoZipCd = tempRow.IsJokasoSetchiBashoZipCdNull() ? string.Empty : tempRow.JokasoSetchiBashoZipCd;
                    // 設置場所（電話番号）
                    insertKensaIraiRow.KensaIraiSetchibashoTelNo = tempRow.IsJokasoSetchiBashoTelNoNull() ? string.Empty : tempRow.JokasoSetchiBashoTelNo;
                    // 施設名称
                    insertKensaIraiRow.KensaIraiShisetsuNm = tempRow.IsJokasoShisetsuNmNull() ? string.Empty : tempRow.JokasoShisetsuNm;
                    // 保健所コード
                    insertKensaIraiRow.KensaIraiSetchibashoHokenjoCd = tempRow.IsJokasoSetchiBashoHokenjoCdNull() ? string.Empty : tempRow.JokasoSetchiBashoHokenjoCd;
                    // 採水業者コード
                    insertKensaIraiRow.KensaIraiSaisuiGyoshaCd = tempRow.IsJokasoSaisuiGyoshaCdNull() ? string.Empty : tempRow.JokasoSaisuiGyoshaCd;
                    // 水質請求業者コード
                    insertKensaIraiRow.KensaIraiSeikyuGyoshaCd = tempRow.IsJokasoSeikyuGyoshaCdNull() ? string.Empty : tempRow.JokasoSeikyuGyoshaCd;
                    // 持込業者コード
                    insertKensaIraiRow.KensaIraiMochikomiGyoshaCd = tempRow.IsJokasoMochikomiGyoshaCdNull() ? string.Empty : tempRow.JokasoMochikomiGyoshaCd;
                    // 送付先名
                    insertKensaIraiRow.KensaIraiSofusakiNm = tempRow.IsJokasoSoufusakiNmNull() ? string.Empty : tempRow.JokasoSoufusakiNm;
                    // 送付先（郵便番号）
                    insertKensaIraiRow.KensaIraiSofusakiZipCd = tempRow.IsJokasoSoufusakiZipCdNull() ? string.Empty : tempRow.JokasoSoufusakiZipCd;
                    // 検査依頼送付先（住所）
                    insertKensaIraiRow.KensaIraiSofusakiAdr = tempRow.IsJokasoSoufusakiAdrNull() ? string.Empty : tempRow.JokasoSoufusakiAdr;
                    // 送付先（電話番号）
                    insertKensaIraiRow.KensaIraiSofusakiTelNo = tempRow.IsJokasoSoufusakiTelNoNull() ? string.Empty : tempRow.JokasoSoufusakiTelNo;
                    // 請求先名
                    insertKensaIraiRow.KensaIraiSeikyusakiNm = tempRow.IsJokasoSeikyusakiNmNull() ? string.Empty : tempRow.JokasoSeikyusakiNm;
                    // 請求先（郵便番号）
                    insertKensaIraiRow.KensaIraiSeikyusakiZipCd = tempRow.IsJokasoSeikyusakiZipCdNull() ? string.Empty : tempRow.JokasoSeikyusakiZipCd;
                    // 検査依頼請求先（住所）
                    insertKensaIraiRow.KensaIraiSeikyusakiAdr = tempRow.IsJokasoSeikyusakiAdrNull() ? string.Empty : tempRow.JokasoSeikyusakiAdr;
                    // 請求先（電話番号）
                    insertKensaIraiRow.KensaIraiSeikyusakiTelNo = tempRow.IsJokasoSeikyusakiTelNoNull() ? string.Empty : tempRow.JokasoSeikyusakiTelNo;
                    // 法定請求業者コード
                    insertKensaIraiRow.KensaIraiIkkatsuSeikyusakiCd = tempRow.IsJokasoItkatsuSeikyuGyoshaCdNull() ? string.Empty : tempRow.JokasoItkatsuSeikyuGyoshaCd;
                    // 建築用途大分類１
                    insertKensaIraiRow.KenchikuyotoDaibunrui1 = tempRow.IsKenchikuyotoDaibunrui1Null() ? string.Empty : tempRow.KenchikuyotoDaibunrui1;
                    // 建築用途小分類１
                    insertKensaIraiRow.KenchikuyotoShobunrui1 = tempRow.IsKenchikuyotoShobunrui1Null() ? string.Empty : tempRow.KenchikuyotoShobunrui1;
                    // 建築用途連番１
                    insertKensaIraiRow.KenchikuyotoRenban1 = tempRow.IsKenchikuyotoRenban1Null() ? 0 : tempRow.KenchikuyotoRenban1;
                    // 建築用途大分類2
                    insertKensaIraiRow.KenchikuyotoDaibunrui2 = tempRow.IsKenchikuyotoDaibunrui2Null() ? string.Empty : tempRow.KenchikuyotoDaibunrui2;
                    // 建築用途小分類2
                    insertKensaIraiRow.KenchikuyotoShobunrui2 = tempRow.IsKenchikuyotoShobunrui2Null() ? string.Empty : tempRow.KenchikuyotoShobunrui2;
                    // 建築用途連番2
                    insertKensaIraiRow.KenchikuyotoRenban2 = tempRow.IsKenchikuyotoRenban2Null() ? 0 : tempRow.KenchikuyotoRenban2;
                    // 建築用途大分類3
                    insertKensaIraiRow.KenchikuyotoDaibunrui3 = tempRow.IsKenchikuyotoDaibunrui3Null() ? string.Empty : tempRow.KenchikuyotoDaibunrui3;
                    // 建築用途小分類3
                    insertKensaIraiRow.KenchikuyotoShobunrui3 = tempRow.IsKenchikuyotoShobunrui3Null() ? string.Empty : tempRow.KenchikuyotoShobunrui3;
                    // 建築用途連番3
                    insertKensaIraiRow.KenchikuyotoRenban3 = tempRow.IsKenchikuyotoRenban3Null() ? 0 : tempRow.KenchikuyotoRenban3;
                    // 建築用途大分類4
                    insertKensaIraiRow.KenchikuyotoDaibunrui4 = tempRow.IsKenchikuyotoDaibunrui4Null() ? string.Empty : tempRow.KenchikuyotoDaibunrui4;
                    // 建築用途小分類4
                    insertKensaIraiRow.KenchikuyotoShobunrui4 = tempRow.IsKenchikuyotoShobunrui4Null() ? string.Empty : tempRow.KenchikuyotoShobunrui4;
                    // 建築用途連番4
                    insertKensaIraiRow.KenchikuyotoRenban4 = tempRow.IsKenchikuyotoRenban4Null() ? 0 : tempRow.KenchikuyotoRenban4;
                    // 建築用途大分類5
                    insertKensaIraiRow.KenchikuyotoDaibunrui5 = tempRow.IsKenchikuyotoDaibunrui5Null() ? string.Empty : tempRow.KenchikuyotoDaibunrui5;
                    // 建築用途小分類5
                    insertKensaIraiRow.KenchikuyotoShobunrui5 = tempRow.IsKenchikuyotoShobunrui5Null() ? string.Empty : tempRow.KenchikuyotoShobunrui5;
                    // 建築用途連番5
                    insertKensaIraiRow.KenchikuyotoRenban5 = tempRow.IsKenchikuyotoRenban5Null() ? 0 : tempRow.KenchikuyotoRenban5;
                    // 旧建築用途コード
                    insertKensaIraiRow.KensaIraiTatemonoYoto = tempRow.IsJokasoOldKentikuYoutoCdNull() ? string.Empty : tempRow.JokasoOldKentikuYoutoCd;
                    // メーカコード
                    insertKensaIraiRow.KensaIraiMakerCd = tempRow.IsJokasoMekaGyoshaCdNull() ? string.Empty : tempRow.JokasoMekaGyoshaCd;
                    // 型式コード
                    insertKensaIraiRow.KensaIraiKatashikiCd = tempRow.IsJokasoKatashikiCdNull() ? string.Empty : tempRow.JokasoKatashikiCd;
                    // 工事業者コード
                    insertKensaIraiRow.KensaIraiKojiGyoshaCd = tempRow.IsJokasoKojiGyoshaKbnNull() ? string.Empty : tempRow.JokasoKojiGyoshaKbn;
                    // 保守点検業者コード
                    insertKensaIraiRow.KensaIraiHoshutenkenGyoshaCd = tempRow.IsJokasoHoshutenkenGyoshaCdNull() ? string.Empty : tempRow.JokasoHoshutenkenGyoshaCd;
                    // 清掃業者コード
                    insertKensaIraiRow.KensaIraiSeisoGyoshaCd = tempRow.IsJokasoSeisouGyoshaCdNull() ? string.Empty : tempRow.JokasoSeisouGyoshaCd;
                    // 放流先コード
                    insertKensaIraiRow.KensaIraiHoryusakiCd = tempRow.IsJokasoHoryusakiCdNull() ? string.Empty : tempRow.JokasoHoryusakiCd;
                    // 実使用人員
                    insertKensaIraiRow.KensaIraiJitsushiyoJinin = tempRow.IsJokasoJitsuSiyoJininNull() ? string.Empty : tempRow.JokasoJitsuSiyoJinin.ToString();
                    // 処理対象人員
                    // TODO 20141203 HotFix
                    insertKensaIraiRow.KensaIraiShoritaishoJinin = tempRow.IsJokasoShoriTaishoJininNull() ? 0 : tempRow.JokasoShoriTaishoJinin;
                    //insertKensaIraiRow.KensaIraiShoritaishoJinin = tempRow.IsJokasoShoriTaishoJininNull() ? string.Empty : tempRow.JokasoShoriTaishoJinin.ToString();
                    // 処理方式区分
                    insertKensaIraiRow.KensaIraiShorihoshikiKbn = tempRow.IsJokasoShoriHosikiKbnNull() ? string.Empty : tempRow.JokasoShoriHosikiKbn;
                    // 処理方式コード
                    insertKensaIraiRow.KensaIraiShorihoshikiCd = tempRow.IsJokasoShoriHosikiCdNull() ? string.Empty : tempRow.JokasoShoriHosikiCd;
                    // 地域コード
                    insertKensaIraiRow.KensaIraiChiikiCd = string.Empty;
                    // 変更前メーカー
                    insertKensaIraiRow.KensaIraiHenkomaeMakerCd = string.Empty;
                    // 変更前工事業者
                    insertKensaIraiRow.KensaIraiHenkomaeKojiGyoshaCd = string.Empty;
                    // はがき送付先
                    insertKensaIraiRow.KensaIraiHagakiSofusakiKbn = tempRow.IsJokasoHagakiSoufusakiKbnNull() ? string.Empty : tempRow.JokasoHagakiSoufusakiKbn;
                    // 三次処理有無
                    insertKensaIraiRow.KensaIraiSanjishoriUmuKbn = tempRow.IsJokaso3JiShoriFlgNull() ? string.Empty : tempRow.Jokaso3JiShoriFlg;
                    // 処理目標水質 V1.36 DB定義書 KensaIraiShorimokuhyoSuishitsu from nvarchar(1) -> int
                    insertKensaIraiRow.KensaIraiShorimokuhyoSuishitsu = tempRow.IsJokasoSyoriMokuhyoBODNull() ? 0 : tempRow.JokasoSyoriMokuhyoBOD;
                    // 種類
                    insertKensaIraiRow.KensaIraiShurui = string.Empty;
                    // 市町村設置型
                    insertKensaIraiRow.KensaIraiShichosonSetchigata = tempRow.IsJokasoSichosonSetchiKbnNull() ? string.Empty : tempRow.JokasoSichosonSetchiKbn;
                    // 告示区分
                    insertKensaIraiRow.KensaIraiKokujiKbn = tempRow.IsJokasoKoujiKbnNull() ? string.Empty : tempRow.JokasoKoujiKbn;
                    // 告示年度
                    insertKensaIraiRow.KensaIraiKokujiNendo = tempRow.IsJokasoKoujiNenNull() ? string.Empty : tempRow.JokasoKoujiNen;
                    // 告示番号
                    insertKensaIraiRow.KensaIraiKokujiNo = tempRow.IsJokasoKoujiNoNull() ? string.Empty : tempRow.JokasoKoujiNo;
                    // 延べ面積
                    insertKensaIraiRow.KensaIraiNobeMensaeki = tempRow.IsJokasoTatemonoNobeMensekiNull() ? 0 : (decimal)tempRow.JokasoTatemonoNobeMenseki;
                    // 認定番号
                    insertKensaIraiRow.KensaIraiNinteiNo = tempRow.IsJokasoNinteiNoNull() ? string.Empty : tempRow.JokasoNinteiNo;
                    // BOD処理性能
                    insertKensaIraiRow.KensaIraiBODShoriSeino = tempRow.IsJokasoSyoriMokuhyoBODNull() ? string.Empty : tempRow.JokasoSyoriMokuhyoBOD.ToString();
                    // 設置年
                    insertKensaIraiRow.KensaIraiSetchiNen = tempRow.IsJokasoSetchiNenNull() ? string.Empty : tempRow.JokasoSetchiNen;
                    // 設置月
                    insertKensaIraiRow.KensaIraiSetchiTsuki = tempRow.IsJokasoSetchiTsukiNull() ? string.Empty : tempRow.JokasoSetchiTsuki;
                    // 設置日
                    insertKensaIraiRow.KensaIraiSetchiBi = tempRow.IsJokasoSetchiBiNull() ? string.Empty : tempRow.JokasoSetchiBi;
                    // 使用開始年
                    insertKensaIraiRow.KensaIraiShiyoKaishiNen = tempRow.IsJokasoSiyokaisiNenNull() ? string.Empty : tempRow.JokasoSiyokaisiNen;
                    // 使用開始月
                    insertKensaIraiRow.KensaIraiShiyoKaishiTsuki = tempRow.IsJokasoSiyokaisiTsukiNull() ? string.Empty : tempRow.JokasoSiyokaisiTsuki;
                    // 使用開始日
                    insertKensaIraiRow.KensaIraiShiyoKaishiBi = tempRow.IsJokasoSiyokaisiBiNull() ? string.Empty : tempRow.JokasoSiyokaisiBi;
                    // 使用開始届
                    insertKensaIraiRow.KensaIraiShiyoKaishiTodoke = "0";
                    // 取下理由
                    insertKensaIraiRow.KensaIraiTorisageRiyu = string.Empty;
                    // 設置者（カナ）
                    insertKensaIraiRow.KensaIraiSetchishaKana = tempRow.IsJokasoSetchishaKanaNull() ? string.Empty : tempRow.JokasoSetchishaKana;
                    // 現地区コード
                    insertKensaIraiRow.KensaIraiGenChikuCd = tempRow.IsJokasoGenChikuCdNull() ? string.Empty : tempRow.JokasoGenChikuCd;
                    // 検査完了区分
                    insertKensaIraiRow.KensaIraiKensaKanryoKbn = "0";
                    // 検印区分
                    insertKensaIraiRow.KensaIraiKeninKbn = "0";
                    // 水質検印区分
                    insertKensaIraiRow.KensaIraiSuishitsuKeninKbn = "0";
                    // BOD入力済区分
                    insertKensaIraiRow.KensaIraiBODNyuryokuzumiKbn = "0";
                    // 塩素イオン入力済区分
                    insertKensaIraiRow.KensaIraiEnsoIonNyuryokuzumiKbn = "0";
                    // MLSS入力済区分
                    insertKensaIraiRow.KensaIraiMLSSNyuryokuzumiKbn = "0";
                    // 検査票印刷済区分
                    insertKensaIraiRow.KensaIraiKensahyoInsatsuzumiKbn = "0";
                    // ハガキ印刷済区分
                    insertKensaIraiRow.KensaIraiHagakiInsatsuzumiKbn = "0";
                    // ７条保留区分
                    insertKensaIraiRow.KensaIrai7joHoryuKbn = "0";
                    // 20141217 habu 対応カラム変更
                    // 実使用人員（数値）
                    insertKensaIraiRow.KensaIraiJitsushiyoJininValue = tempRow.IsJokasoJitsuSiyouJininSuchiNull() ? string.Empty : tempRow.JokasoJitsuSiyouJininSuchi;
                    //insertKensaIraiRow.KensaIraiJitsushiyoJininValue = tempRow.IsJokasoJitsuSiyoJininNull() ? string.Empty : tempRow.JokasoJitsuSiyoJinin.ToString();
                    //// 点検回数月毎 v1.01
                    insertKensaIraiRow.KensaIraiTenkenKaisuTsukiGoto = string.Empty;
                    //// 点検回数週毎 v1.01
                    insertKensaIraiRow.KensaIraiTenkenKaisuShuGoto = string.Empty;
                    // 嵩上げ
                    insertKensaIraiRow.KensaIraiKasaage = tempRow.IsJokasoKasaageTakasaNull() ? string.Empty : tempRow.JokasoKasaageTakasa;
                    // 流入滞留
                    insertKensaIraiRow.KensaIraiRyunyuTairyu = tempRow.IsJokasoRyunyuTairyuTakasaNull() ? string.Empty : tempRow.JokasoRyunyuTairyuTakasa;
                    // 放流滞留
                    insertKensaIraiRow.KensaIraiHoryuTairyu = tempRow.IsJokasoHouryuTairyuTakasaNull() ? string.Empty : tempRow.JokasoHouryuTairyuTakasa;
                    // ブロワ
                    insertKensaIraiRow.KensaIraiBurowa = string.Empty;
                    // ブロワ規定風量
                    insertKensaIraiRow.KensaIraiBurowaKiteFuryo = string.Empty;
                    // ブロワ設置風量
                    insertKensaIraiRow.KensaIraiBurowaSetchiFuryo = string.Empty;
                    // ７条保留確認日
                    insertKensaIraiRow.KensaIrai7joHoryuKakuninDt = string.Empty;
                    // 次回確認予定日
                    insertKensaIraiRow.KensaIraiJikaiKakuninYoteiDt = string.Empty;
                    // 保留理由
                    insertKensaIraiRow.KensaIraiHoryuRiyu = string.Empty;
                    // 保守点検（内容）
                    insertKensaIraiRow.KensaIraiHoshuTenkenNiayo = string.Empty;
                    // 清掃回数（年）
                    insertKensaIraiRow.KensaIraiSeisoKaisuNenkan = string.Empty;
                    // ブロワ１
                    insertKensaIraiRow.KensaIraiBurowa1 = string.Empty;
                    // ブロワ規定風量１
                    insertKensaIraiRow.KensaIraiBurowaKiteFuryo1 = string.Empty;
                    // ブロワ設置風量１
                    insertKensaIraiRow.KensaIraiBurowaSetchiFuryo1 = string.Empty;
                    // ブロワ2
                    insertKensaIraiRow.KensaIraiBurowa2 = string.Empty;
                    // ブロワ規定風量2
                    insertKensaIraiRow.KensaIraiBurowaKiteFuryo2 = string.Empty;
                    // ブロワ設置風量2
                    insertKensaIraiRow.KensaIraiBurowaSetchiFuryo2 = string.Empty;
                    // ブロワ3
                    insertKensaIraiRow.KensaIraiBurowa3 = string.Empty;
                    // ブロワ規定風量3
                    insertKensaIraiRow.KensaIraiBurowaKiteFuryo3 = string.Empty;
                    // ブロワ設置風量3
                    insertKensaIraiRow.KensaIraiBurowaSetchiFuryo3 = string.Empty;
                    // 外観検査担当者コード
                    insertKensaIraiRow.KensaIraiKensaTantoshaCd = string.Empty;
                    // 書類点検担当者名
                    insertKensaIraiRow.KensaIraiKensaTantoshaNm = string.Empty;
                    // 保留区分
                    insertKensaIraiRow.KensaIraiHoryuKbn = "0";
                    // 保留取消日
                    insertKensaIraiRow.KensaIraiHoryuTorikeshiDt = string.Empty;
                    // メモ確認フラグ
                    insertKensaIraiRow.KensaIraiMemoKakuninFlg = string.Empty;
                    // 採水員コード
                    insertKensaIraiRow.KensaIraiSaisuiinCd = string.Empty;
                    // クロスチェック
                    insertKensaIraiRow.KensaIraiCrossCheck = string.Empty;
                    // クロスチェック判定
                    insertKensaIraiRow.KensaIraiCrossCheckHantei = string.Empty;
                    // クロスチェック理由
                    insertKensaIraiRow.KensaIraiCrossCheckRiyu = string.Empty;
                    // 検査責任者
                    insertKensaIraiRow.KensaIraiKensaSekininsha = string.Empty;
                    // 判定区分
                    insertKensaIraiRow.KensaIraiHanteiKbn = string.Empty;
                    // スクリーニング実施
                    insertKensaIraiRow.KensaIraiScreeningJisshi = string.Empty;
                    // スクリーニング保健所コード
                    insertKensaIraiRow.KensaIraiScreeningHokenjoCd = string.Empty;
                    // スクリーニング年度
                    insertKensaIraiRow.KensaIraiScreeningNendo = string.Empty;
                    // スクリーニング連番
                    insertKensaIraiRow.KensaIraiScreeningRenban = string.Empty;
                    // ステータス区分
                    insertKensaIraiRow.KensaIraiStatusKbn = "00";
                    // 外観日報区分
                    insertKensaIraiRow.KensaIraiGaikanNippoKbn = "0";
                    // 水質日報区分
                    insertKensaIraiRow.KensaIraiSuishitsuNippoKbn = "0";
                    // 請求区分
                    insertKensaIraiRow.KensaIraiSeikyuKbn = "0";
                    // 結果書印刷回数
                    insertKensaIraiRow.KensaIraiKekkashoInsatsuCnt = 0;
                    // 20150126 habu
                    // 遅延報告作成
                    insertKensaIraiRow.ChienHokokuMakeKbn = "0";

                    // 登録日時
                    insertKensaIraiRow.InsertDt = now;

                    // 登録者
                    insertKensaIraiRow.InsertUser = loginUser;

                    // 登録端末
                    insertKensaIraiRow.InsertTarm = pcUpdate;

                    // 更新日
                    insertKensaIraiRow.UpdateDt = now;

                    // 更新者
                    insertKensaIraiRow.UpdateUser = loginUser;

                    // 更新端末
                    insertKensaIraiRow.UpdateTarm = pcUpdate;

                    insertKensaIraiTbl.AddKensaIraiTblRow(insertKensaIraiRow);

                    #endregion

                    #region Update KensaKekkaTbl

                    KensaKekkaTblDataSet.KensaKekkaTblRow insertKensaKekkaRow = insertKensaKekkaTbl.NewKensaKekkaTblRow();


                    // 検査依頼法定区分
                    insertKensaKekkaRow.KensaKekkaIraiHoteiKbn = insertKensaIraiRow.KensaIraiHoteiKbn;
                    // 検査依頼保健所コード
                    insertKensaKekkaRow.KensaKekkaIraiHokenjoCd = insertKensaIraiRow.KensaIraiHokenjoCd;
                    // 検査依頼年度
                    insertKensaKekkaRow.KensaKekkaIraiNendo = insertKensaIraiRow.KensaIraiNendo;
                    // 検査依頼連番
                    insertKensaKekkaRow.KensaKekkaIraiRenban = insertKensaIraiRow.KensaIraiRenban;
                    // 法１１条検査
                    insertKensaKekkaRow.KensaKekka11joKensa = string.Empty;
                    // 判定
                    insertKensaKekkaRow.KensaKekkaHantei = string.Empty;
                    // 主な原因１
                    insertKensaKekkaRow.KensaKekkaGenin1 = string.Empty;
                    // 主な原因2
                    insertKensaKekkaRow.KensaKekkaGenin2 = string.Empty;
                    // 主な原因3
                    insertKensaKekkaRow.KensaKekkaGenin3 = string.Empty;
                    // 主な原因4
                    insertKensaKekkaRow.KensaKekkaGenin4 = string.Empty;
                    // 主な原因5
                    insertKensaKekkaRow.KensaKekkaGenin5 = string.Empty;
                    // 主な原因6
                    insertKensaKekkaRow.KensaKekkaGenin6 = string.Empty;
                    // 水質検査依頼番号
                    insertKensaKekkaRow.KensaKekkaSuishitsuIraiNo = string.Empty;
                    // 水質検査測定不能
                    insertKensaKekkaRow.KensaKekkaSuishitsuSokuteifuno = string.Empty;
                    // 水質検査採水日付
                    insertKensaKekkaRow.KensaKekkaSaisuiDt = string.Empty;
                    // 水質検査持込日付
                    insertKensaKekkaRow.KensaKekkaMochikomiDt = string.Empty;
                    // 温度
                    insertKensaKekkaRow.KensaKekkaOndo = 0;
                    // 水素イオン濃度
                    //insertKensaKekkaRow.KensaKekkaSuisoIonNodo = 0;
                    insertKensaKekkaRow.SetKensaKekkaSuisoIonNodoNull();
                    //水素イオン濃度ー判定
                    insertKensaKekkaRow.KensaKekkaSuisoIonNodoHantei = string.Empty;
                    // 汚泥沈殿率
                    //insertKensaKekkaRow.KensaKekkaOdeiChindenritsu = 0;
                    insertKensaKekkaRow.SetKensaKekkaOdeiChindenritsuNull();
                    // 汚泥沈殿率２
                    insertKensaKekkaRow.KensaKekkaOdeiChindenritsu2 = string.Empty;
                    // 汚泥沈殿率ー判定
                    insertKensaKekkaRow.KensaKekkaOdeiChindenritsuHantei = string.Empty;
                    // 溶存酸素量１
                    //insertKensaKekkaRow.KensaKekkaYozonSansoryo1 = 0;
                    insertKensaKekkaRow.SetKensaKekkaYozonSansoryo1Null();
                    // 溶存酸素量2
                    //insertKensaKekkaRow.KensaKekkaYozonSansoryo2 = 0;
                    insertKensaKekkaRow.SetKensaKekkaYozonSansoryo2Null();
                    // 溶存酸素量ー判定
                    insertKensaKekkaRow.KensaKekkaYozonSansoryoHantei = string.Empty;
                    // 亜硝酸性窒素
                    //insertKensaKekkaRow.KensaKekkaAsyosanseiChisso = string.Empty;
                    insertKensaKekkaRow.SetKensaKekkaAsyosanseiChissoNull();
                    // 亜硝酸性窒素ー判定
                    insertKensaKekkaRow.KensaKekkaAsyosanseiChissoHantei = string.Empty;
                    // 透視度
                    //insertKensaKekkaRow.KensaKekkaToshido = 0;
                    insertKensaKekkaRow.SetKensaKekkaToshidoNull();
                    // 透視度２
                    insertKensaKekkaRow.KensaKekkaToshido2 = string.Empty;
                    // 透視度ー判定
                    insertKensaKekkaRow.KensaKekkaToshidoHantei = string.Empty;
                    // 透視度２次処理水
                    //insertKensaKekkaRow.KensaKekkaToshido2jiSyorisui = 0;
                    insertKensaKekkaRow.SetKensaKekkaToshido2jiSyorisuiNull();
                    // 透視度２２次処理水
                    insertKensaKekkaRow.KensaKekkaToshido22jiSyorisui = string.Empty;
                    // 透視度ー判定２次処理水
                    insertKensaKekkaRow.KensaKekkaToshidoHantei2jiSyorisui = string.Empty;
                    // 塩素イオン濃度
                    //insertKensaKekkaRow.KensaKekkaEnsoIonNodo = "0";
                    //insertKensaKekkaRow.KensaKekkaEnsoIonNodo = 0;
                    insertKensaKekkaRow.SetKensaKekkaEnsoIonNodoNull();
                    // 塩素イオン濃度２
                    insertKensaKekkaRow.KensaIraiEnsoIonNodo2 = string.Empty;
                    // 塩素イオン濃度ー判定
                    insertKensaKekkaRow.KensaKekkaEnsoIonNodoHantei = string.Empty;
                    // 残留塩素濃度
                    //insertKensaKekkaRow.KensaKekkaZanryuEnsoNodo = 0;
                    insertKensaKekkaRow.SetKensaKekkaZanryuEnsoNodoNull();
                    // 残留塩素濃度ー判定
                    insertKensaKekkaRow.KensaKekkaZanryuEnsoNodoHantei = string.Empty;
                    // 生物化学酸素要求量
                    //insertKensaKekkaRow.KensaKekkaBOD = 0;
                    insertKensaKekkaRow.SetKensaKekkaBODNull();
                    // 生物化学酸素要求量２
                    insertKensaKekkaRow.KensaIraiBOD2 = string.Empty;
                    // 生物化学酸素要求量ー判定
                    insertKensaKekkaRow.KensaKekkaBODHantei = string.Empty;
                    // ＭＬＳＳ
                    //insertKensaKekkaRow.KensaKekkaMLSS = 0;
                    insertKensaKekkaRow.SetKensaKekkaMLSSNull();
                    // ＭＬＳＳ－判定
                    insertKensaKekkaRow.KensaKekkaMLSSHantei = string.Empty;
                    // 入力担当者
                    insertKensaKekkaRow.KensaKekkaNyuryokuTanto = string.Empty;
                    // 点検記録保存
                    insertKensaKekkaRow.KensaKekkaTenkenKirokuHozon = string.Empty;
                    // 清掃日付
                    insertKensaKekkaRow.KensaKekkaSeisoDt = string.Empty;
                    // 清掃記録保存
                    insertKensaKekkaRow.KensaKekkaSeisoKirokuHozon = string.Empty;
                    // 保守点検記録有無
                    insertKensaKekkaRow.KensaKekkaHoshuTenkenKirokuUmu = string.Empty;
                    // 保守点検回数
                    insertKensaKekkaRow.KensaKekkaHoshuTenkenKaisu = string.Empty;
                    // 保守点検内容
                    insertKensaKekkaRow.KensaKekkaHoshuTenkenNaiyo = string.Empty;
                    // 清掃記録有無
                    insertKensaKekkaRow.KensaKekkaSeisoKirokuUmu = string.Empty;
                    // 清掃回数
                    insertKensaKekkaRow.KensaKekkaSeisoKaisu = string.Empty;
                    // 清掃内容
                    insertKensaKekkaRow.KensaKekkaSeisoNaiyo = string.Empty;
                    // 特記事項手書き
                    insertKensaKekkaRow.KensaKekkaTokkijikoTegaki = string.Empty;
                    // メモ手書き
                    insertKensaKekkaRow.KensaKekkaMemoTegaki = string.Empty;
                    // 所見変更フラグ
                    insertKensaKekkaRow.KensaKekkaShokenHenkoFlg = "0";
                    // 在宅有無フラグ
                    insertKensaKekkaRow.KensaKekkaZaitakuUmu = "0";
                    // 検査開始日時
                    //insertKensaKekkaRow.KensaKekkaKensaStartDt = 
                    // 検査終了日時
                    //insertKensaKekkaRow.KensaKekkakensaEndDt = 
                    // 検査時間
                    insertKensaKekkaRow.KensaKekkaKensaTimes = 0;
                    // 検査状況
                    insertKensaKekkaRow.KensaKekkaKensaJoukyouKbn = string.Empty;

                    // 保守点検実施回数区分 v1.01
                    insertKensaKekkaRow.KensaKekkaTenkenKaisuKbn = string.Empty;

                    // ATUBOD
                    insertKensaKekkaRow.SetKensaKekkaATUBODNull();
                    // ATUBOD２
                    insertKensaKekkaRow.KensaKekkaATUBOD2 = string.Empty;

                    // 登録日時
                    insertKensaKekkaRow.InsertDt = now;

                    // 登録者
                    insertKensaKekkaRow.InsertUser = loginUser;

                    // 登録端末
                    insertKensaKekkaRow.InsertTarm = pcUpdate;

                    // 更新日
                    insertKensaKekkaRow.UpdateDt = now;

                    // 更新者
                    insertKensaKekkaRow.UpdateUser = loginUser;

                    // 更新端末
                    insertKensaKekkaRow.UpdateTarm = pcUpdate;

                    insertKensaKekkaTbl.AddKensaKekkaTblRow(insertKensaKekkaRow);

                    #endregion

                }

                IUpdateKensaIraiTblBLInput updateKensaIraiBLInput = new UpdateKensaIraiTblBLInput();
                updateKensaIraiBLInput.KensaIraiTblDataTable = insertKensaIraiTbl;
                new UpdateKensaIraiTblBusinessLogic().Execute(updateKensaIraiBLInput);

                IUpdateKensaKekkaTblBLInput updateKensaKekkaBLInput = new UpdateKensaKekkaTblBLInput();
                updateKensaKekkaBLInput.KensaKekkaTblDataTable = insertKensaKekkaTbl;
                new UpdateKensaKekkaTblBusinessLogic().Execute(updateKensaKekkaBLInput);

                #endregion

                // コミット
                CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
                // トランザクション終了
                EndTransaction();
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
