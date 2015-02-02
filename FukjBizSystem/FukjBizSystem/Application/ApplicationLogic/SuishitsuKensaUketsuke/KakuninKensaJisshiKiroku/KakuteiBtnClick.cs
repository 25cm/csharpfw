using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using System;
using System.Net;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALInput : IBseALInput, 
                                        IUpdateKensaDaichoDtlTblBLInput, 
                                        IUpdateKensaKekkaTblBLInput,
                                        IUpdateSaiSaisuiTblBLInput,
                                        IUpdateKeiryoShomeiKekkaTblBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALInput : IKakuteiBtnClickALInput
    {
        /// <summary>
        /// 検査台帳明細テーブル
        /// </summary>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }

        /// <summary>
        /// 検査結果テーブル
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaTblDataTable { get; set; }

        /// <summary>
        /// 再採水テーブル
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiTblDataTable { get; set; }

        /// <summary>
        /// KeiryoShomeiKekkaTblDataTable
        /// </summary>
        public KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable KeiryoShomeiKekkaTblDT { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALOutput : IKakuteiBtnClickALOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuteiBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickApplicationLogic : BaseApplicationLogic<IKakuteiBtnClickALInput, IKakuteiBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KakuninKensaJisshiKiroku：KakuteiBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KakuteiBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KakuteiBtnClickApplicationLogic()
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
        /// 2014/12/03  DatNT　  新規作成
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
        /// 2014/12/03  DatNT　  新規作成
        /// 2014/12/25  小松　　　　再検査のレコードが検査台帳明細TBLに存在しない場合は新規レコード追加
        /// 2014/12/26  小松　　　　結果コード、結果値２の初期値を正しく設定
        ///                         採用値がチェックされていたら前回分の採用区分を"0"に、登録する再検査の採用区分を"1"に設定
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuteiBtnClickALOutput Execute(IKakuteiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuteiBtnClickALOutput output = new KakuteiBtnClickALOutput();

            try
            {
                DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();

                StartTransaction();

                #region Table Update

                // KensaDaichoDtlTbl DataTable for update
                KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable dtlUpdateDT = new KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable();

                // KensaKekkaTbl DataTable for udpate
                KensaKekkaTblDataSet.KensaKekkaTblDataTable kekkaUpdateDT = new KensaKekkaTblDataSet.KensaKekkaTblDataTable();

                // SaiSaisuiTbl DataTable for update
                SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saisuiUpdateDT = new SaiSaisuiTblDataSet.SaiSaisuiTblDataTable();

                // KeiryoShomeiKekkaTbl DataTable for update
                KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable keiryoUpdateDT = new KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable();

                #endregion

                #region Get KensaDaichoDtlTbl DT

                if (input.KensaDaichoDtlTblDT != null && input.KensaDaichoDtlTblDT.Count > 0)
                {
                    foreach (KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow dtlRow in input.KensaDaichoDtlTblDT)
                    {
                        IGetKensaDaichoDtlTblByKeyBLInput dtlInput = new GetKensaDaichoDtlTblByKeyBLInput();
                        dtlInput.IraiNendo = dtlRow.IraiNendo;
                        dtlInput.IraiNo = dtlRow.SuishitsuKensaIraiNo;
                        dtlInput.Kbn = dtlRow.KensaKbn;
                        dtlInput.SaikensaKbn = dtlRow.SaikensaKbn;
                        dtlInput.ShikenkoumokuCd = dtlRow.ShikenkoumokuCd;
                        dtlInput.Sisho = dtlRow.ShishoCd;
                        IGetKensaDaichoDtlTblByKeyBLOutput dtlOutput = new GetKensaDaichoDtlTblByKeyBusinessLogic().Execute(dtlInput);

                        if (dtlOutput.KensaDaichoDtlTblDT != null && dtlOutput.KensaDaichoDtlTblDT.Count > 0)
                        {
                            // 確認検査種別
                            dtlOutput.KensaDaichoDtlTblDT[0].KensaShubetsu = string.Empty;
                            // 確認検査種別（BOD/透視度）
                            dtlOutput.KensaDaichoDtlTblDT[0].KensaShubetsuBodTr = "0";
                            // 確認検査種別（過去との比較）
                            dtlOutput.KensaDaichoDtlTblDT[0].KensaShubetsuKako = "0";
                            // 確認検査種別（BOD基準値オーバー）
                            dtlOutput.KensaDaichoDtlTblDT[0].KensaShubetsuBodOver = "0";
                            // 確認検査種別（塩化物イオン確認検査）
                            dtlOutput.KensaDaichoDtlTblDT[0].KensaShubetsuEnkaIon = "0";
                            // 確認検査種別（SS/透視度）
                            dtlOutput.KensaDaichoDtlTblDT[0].KensaShubetsuSsTr = "0";
                            // 確認検査種別（アンモニア確認検査）
                            dtlOutput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmonia = "0";
                            // 確認検査種別（アンモニアと全窒素比較）
                            dtlOutput.KensaDaichoDtlTblDT[0].KensaShubetsuAnmoniaTn = "0";
                            // 確認検査種別（COD基準値オーバー）
                            dtlOutput.KensaDaichoDtlTblDT[0].KensaShubetsuCodOver = "0";

                            // 確認検査の措置
                            dtlOutput.KensaDaichoDtlTblDT[0].KakuninKensaSoti = dtlRow.KakuninKensaSoti;

                            // 課長検印区分
                            dtlOutput.KensaDaichoDtlTblDT[0].KachoKeninKbn = dtlRow.KachoKeninKbn;

                            // 副課長検印区分
                            dtlOutput.KensaDaichoDtlTblDT[0].HukuKachoKeninKbn = dtlRow.HukuKachoKeninKbn;

                            // 計量管理者検印区分
                            dtlOutput.KensaDaichoDtlTblDT[0].KeiryoKanrishaKeninKbn = dtlRow.KeiryoKanrishaKeninKbn;

                            // 野帳記入確認区分
                            dtlOutput.KensaDaichoDtlTblDT[0].YachoKinyuKakuninKbn = dtlRow.YachoKinyuKakuninKbn;

                            // 採用区分
                            dtlOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiSaiyoKbn = dtlRow.KeiryoShomeiSaiyoKbn;

                            //20141217 HuyTX Add Start
                            // 20141219 sou Start
                            if (dtlRow.SaikensaKbn == "1")
                            {
                                // 20141219 sou End
                                //結果値
                                dtlOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue = !dtlRow.IsKeiryoShomeiKekkaValueNull() ? dtlRow.KeiryoShomeiKekkaValue : 0;

                                //結果値２
                                dtlOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaValue2 = !dtlRow.IsKeiryoShomeiKekkaValue2Null() ? (!string.IsNullOrEmpty(dtlRow.KeiryoShomeiKekkaValue2) ? dtlRow.KeiryoShomeiKekkaValue2 : "0") : "0";

                                //温度数
                                dtlOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaOndo = !dtlRow.IsKeiryoShomeiKekkaOndoNull() ? dtlRow.KeiryoShomeiKekkaOndo : 0;

                                // 20141219 sou Start
                                //結果コード
                                dtlOutput.KensaDaichoDtlTblDT[0].KeiryoShomeiKekkaCd = !dtlRow.IsKeiryoShomeiKekkaCdNull() ? (!string.IsNullOrEmpty(dtlRow.KeiryoShomeiKekkaCd) ? dtlRow.KeiryoShomeiKekkaCd : "0") : "0";
                            }
                            // 20141219 sou End

                            //20141217 HuyTX Add End

                            dtlOutput.KensaDaichoDtlTblDT[0].UpdateDt = dtlRow.UpdateDt;
                            dtlOutput.KensaDaichoDtlTblDT[0].UpdateTarm = dtlRow.UpdateTarm;
                            dtlOutput.KensaDaichoDtlTblDT[0].UpdateUser = dtlRow.UpdateUser;

                            dtlUpdateDT.ImportRow(dtlOutput.KensaDaichoDtlTblDT[0]);
                        }
                        else if (dtlRow.SaikensaKbn == "1")
                        {
                            // 再検査のレコードが検査台帳明細TBLに存在しない場合は新規レコード追加

                            // 012水質受付管理_003検査受付一覧のデータ更新⑦＋013水質検査管理_012確認検査実施記録のデータ更新②
                            KensaDaichoDtlTblDataSet.KensaDaichoDtlTblRow addDtlRow = dtlUpdateDT.NewKensaDaichoDtlTblRow();

                            // 検査区分（1:計量証明/2:水質検査/3:外観検査)）
                            addDtlRow.KensaKbn = dtlRow.KensaKbn;
                            // 依頼年度
                            addDtlRow.IraiNendo = dtlRow.IraiNendo;
                            // 支所コード
                            addDtlRow.ShishoCd = dtlRow.ShishoCd;
                            // 水質検査依頼番号
                            addDtlRow.SuishitsuKensaIraiNo = dtlRow.SuishitsuKensaIraiNo;
                            // 試験項目コード
                            addDtlRow.ShikenkoumokuCd = dtlRow.ShikenkoumokuCd;
                            // 再検査回数
                            addDtlRow.SaikensaKbn = "1";
                            // 確認検査種別
                            addDtlRow.KensaShubetsu = string.Empty;
                            // 確認検査種別（BOD/透視度）
                            addDtlRow.KensaShubetsuBodTr = "0";
                            // 確認検査種別（過去との比較）
                            addDtlRow.KensaShubetsuKako = "0";
                            // 確認検査種別（BOD基準値オーバー）
                            addDtlRow.KensaShubetsuBodOver = "0";
                            // 確認検査種別（塩化物イオン確認検査）
                            addDtlRow.KensaShubetsuEnkaIon = "0";
                            // 確認検査種別（SS/透視度）
                            addDtlRow.KensaShubetsuSsTr = "0";
                            // 確認検査種別（アンモニア確認検査）
                            addDtlRow.KensaShubetsuAnmonia = "0";
                            // 確認検査種別（アンモニアと全窒素比較）
                            addDtlRow.KensaShubetsuAnmoniaTn = "0";
                            // 確認検査種別（COD基準値オーバー）
                            addDtlRow.KensaShubetsuCodOver = "0";
                            // 結果値　　　※設定
                            addDtlRow.KeiryoShomeiKekkaValue = !dtlRow.IsKeiryoShomeiKekkaValueNull() ? dtlRow.KeiryoShomeiKekkaValue : 0;
                            // 結果値２　　※設定
                            addDtlRow.KeiryoShomeiKekkaValue2 = !dtlRow.IsKeiryoShomeiKekkaValue2Null() ? (!string.IsNullOrEmpty(dtlRow.KeiryoShomeiKekkaValue2) ? dtlRow.KeiryoShomeiKekkaValue2 : "0") : "0";
                            // 結果コード　※設定
                            addDtlRow.KeiryoShomeiKekkaCd = !dtlRow.IsKeiryoShomeiKekkaCdNull() ? (!string.IsNullOrEmpty(dtlRow.KeiryoShomeiKekkaCd) ? dtlRow.KeiryoShomeiKekkaCd : "0") : "0";
                            // 温度数　　　※設定
                            addDtlRow.KeiryoShomeiKekkaOndo = !dtlRow.IsKeiryoShomeiKekkaOndoNull() ? dtlRow.KeiryoShomeiKekkaOndo : 0;
                            // 結果入力（入力済）
                            addDtlRow.KeiryoShomeiKekkaNyuryoku = "1";
                            // 外部委託フラグ
                            addDtlRow.KeiryoShomeiGaibuItakuFlg = "0";
                            // 採用区分　　※設定
                            addDtlRow.KeiryoShomeiSaiyoKbn = !dtlRow.IsKeiryoShomeiSaiyoKbnNull() ? dtlRow.KeiryoShomeiSaiyoKbn : "0";
                            // 確認検査の措置　　　※設定
                            addDtlRow.KakuninKensaSoti = !dtlRow.IsKakuninKensaSotiNull() ? dtlRow.KakuninKensaSoti : "0";
                            // 課長検印区分　　　　※設定
                            addDtlRow.KachoKeninKbn = !dtlRow.IsKachoKeninKbnNull() ? dtlRow.KachoKeninKbn : "0";
                            // 副課長検印区分　　　※設定
                            addDtlRow.HukuKachoKeninKbn = !dtlRow.IsHukuKachoKeninKbnNull() ? dtlRow.HukuKachoKeninKbn : "0";
                            // 計量管理者検印区分　※設定
                            addDtlRow.KeiryoKanrishaKeninKbn = !dtlRow.IsKeiryoKanrishaKeninKbnNull() ? dtlRow.KeiryoKanrishaKeninKbn : "0";
                            // 野帳記入確認区分　　※設定
                            addDtlRow.YachoKinyuKakuninKbn = !dtlRow.IsYachoKinyuKakuninKbnNull() ? dtlRow.YachoKinyuKakuninKbn : "0";

                            addDtlRow.InsertDt = currentDateTime;
                            addDtlRow.InsertUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                            addDtlRow.InsertTarm = Dns.GetHostName();
                            addDtlRow.UpdateDt = currentDateTime;
                            addDtlRow.UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                            addDtlRow.UpdateTarm = Dns.GetHostName();

                            dtlUpdateDT.AddKensaDaichoDtlTblRow(addDtlRow);
                            addDtlRow.AcceptChanges();
                            addDtlRow.SetAdded();
                        }
                    }
                }
                #endregion

                #region Get KensaKekkaTbl DT

                if (input.KensaKekkaTblDataTable != null && input.KensaKekkaTblDataTable.Count > 0)
                {
                    foreach (KensaKekkaTblDataSet.KensaKekkaTblRow kekkaRow in input.KensaKekkaTblDataTable)
                    {
                        IGetKensaKekkaTblByKeyBLInput kekkaInput = new GetKensaKekkaTblByKeyBLInput();
                        kekkaInput.KensaKekkaIraiHokenjoCd  = kekkaRow.KensaKekkaIraiHokenjoCd;
                        kekkaInput.KensaKekkaIraiHoteiKbn   = kekkaRow.KensaKekkaIraiHoteiKbn;
                        kekkaInput.KensaKekkaIraiNendo      = kekkaRow.KensaKekkaIraiNendo;
                        kekkaInput.KensaKekkaIraiRenban     = kekkaRow.KensaKekkaIraiRenban;
                        IGetKensaKekkaTblByKeyBLOutput kekkaOutput = new GetKensaKekkaTblByKeyBusinessLogic().Execute(kekkaInput);

                        if (kekkaOutput.KensaKekkaTblDataTable != null && kekkaOutput.KensaKekkaTblDataTable.Count > 0)
                        {
                            // 20141220 sou Start Null判定を追加して更新する試験項目を切り分ける
                            //// 試験項目コード
                            //kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodo = kekkaRow.IsKensaKekkaSuisoIonNodoNull() ? 0 : kekkaRow.KensaKekkaSuisoIonNodo;
                            //
                            //// 温度
                            //kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaOndo = kekkaRow.IsKensaKekkaOndoNull() ? 0 : kekkaRow.KensaKekkaOndo;
                            //
                            //// 透視度
                            //kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshido = kekkaRow.IsKensaKekkaToshidoNull() ? 0 : kekkaRow.KensaKekkaToshido;
                            //
                            //// 透視度２
                            //kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshido2 = kekkaRow.IsKensaKekkaToshido2Null() ? string.Empty : kekkaRow.KensaKekkaToshido2;
                            //
                            //// 生物化学酸素要求量
                            //kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaBOD = kekkaRow.IsKensaKekkaBODNull() ? 0 : kekkaRow.KensaKekkaBOD;
                            //
                            //// 生物化学酸素要求量２
                            //kekkaOutput.KensaKekkaTblDataTable[0].KensaIraiBOD2 = kekkaRow.IsKensaIraiBOD2Null() ? string.Empty : kekkaRow.KensaIraiBOD2;
                            //
                            //// 残留塩素濃度
                            //kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodo = kekkaRow.IsKensaKekkaZanryuEnsoNodoNull() ? 0 : kekkaRow.KensaKekkaZanryuEnsoNodo;
                            //
                            //// 塩素イオン濃度
                            //kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodo = kekkaRow.IsKensaKekkaEnsoIonNodoNull() ? 0 : kekkaRow.KensaKekkaEnsoIonNodo;
                            //
                            //// 塩素イオン濃度２
                            //kekkaOutput.KensaKekkaTblDataTable[0].KensaIraiEnsoIonNodo2 = kekkaRow.IsKensaIraiEnsoIonNodo2Null() ? string.Empty : kekkaRow.KensaIraiEnsoIonNodo2;

                            // pH
                            if (!kekkaRow.IsKensaKekkaSuisoIonNodoNull())
                            {
                                // 水素イオン濃度
                                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodo = kekkaRow.KensaKekkaSuisoIonNodo;

                                // 温度
                                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaOndo = kekkaRow.IsKensaKekkaOndoNull() ? 0 : kekkaRow.KensaKekkaOndo;
                            }
                            // 透視度
                            if (!kekkaRow.IsKensaKekkaToshidoNull())
                            {
                                // 透視度
                                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshido = kekkaRow.KensaKekkaToshido;

                                // 透視度２
                                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshido2 = kekkaRow.IsKensaKekkaToshido2Null() ? string.Empty : kekkaRow.KensaKekkaToshido2;
                            }
                            // BOD
                            if (!kekkaRow.IsKensaKekkaBODNull())
                            {
                                // 生物化学酸素要求量
                                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaBOD = kekkaRow.KensaKekkaBOD;

                                // 生物化学酸素要求量２
                                kekkaOutput.KensaKekkaTblDataTable[0].KensaIraiBOD2 = kekkaRow.IsKensaIraiBOD2Null() ? string.Empty : kekkaRow.KensaIraiBOD2;
                            }
                            // 残塩
                            if (!kekkaRow.IsKensaKekkaZanryuEnsoNodoNull())
                            {
                                // 残留塩素濃度
                                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodo = kekkaRow.KensaKekkaZanryuEnsoNodo;
                            }
                            // 塩化物イオン
                            if (!kekkaRow.IsKensaKekkaEnsoIonNodoNull())
                            {
                                // 塩素イオン濃度
                                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodo = kekkaRow.KensaKekkaEnsoIonNodo;

                                // 塩素イオン濃度２
                                kekkaOutput.KensaKekkaTblDataTable[0].KensaIraiEnsoIonNodo2 = kekkaRow.IsKensaIraiEnsoIonNodo2Null() ? string.Empty : kekkaRow.KensaIraiEnsoIonNodo2;
                            }
                            // 20141220 sou End Null判定を追加して更新する試験項目を切り分ける

                            kekkaOutput.KensaKekkaTblDataTable[0].UpdateDt = kekkaRow.UpdateDt;
                            kekkaOutput.KensaKekkaTblDataTable[0].UpdateTarm = kekkaRow.UpdateTarm;
                            kekkaOutput.KensaKekkaTblDataTable[0].UpdateUser = kekkaRow.UpdateUser;

                            kekkaUpdateDT.ImportRow(kekkaOutput.KensaKekkaTblDataTable[0]);
                        }
                    }
                }
                #endregion

                #region Get SaisaisuiTbl DT

                if (input.SaiSaisuiTblDataTable != null && input.SaiSaisuiTblDataTable.Count > 0)
                {
                    foreach (SaiSaisuiTblDataSet.SaiSaisuiTblRow saisuiRow in input.SaiSaisuiTblDataTable)
                    {
                        IGetSaiSaisuiTblByKeyBLInput saisuiInput = new GetSaiSaisuiTblByKeyBLInput();
                        saisuiInput.SaiSaisuiIraiHokenjoCd  = saisuiRow.SaiSaisuiIraiHokenjoCd;
                        saisuiInput.SaiSaisuiIraiHoteiKbn   = saisuiRow.SaiSaisuiIraiHoteiKbn;
                        saisuiInput.SaiSaisuiIraiNendo      = saisuiRow.SaiSaisuiIraiNendo;
                        saisuiInput.SaiSaisuiIraiRrenban    = saisuiRow.SaiSaisuiIraiRrenban;
                        IGetSaiSaisuiTblByKeyBLOutput saisuiOutput = new GetSaiSaisuiTblByKeyBusinessLogic().Execute(saisuiInput);

                        if (saisuiOutput.SaiSaisuiTblDataTable != null && saisuiOutput.SaiSaisuiTblDataTable.Count > 0)
                        {
                            // 20141220 sou Start Null判定を追加して更新する試験項目を切り分ける
                            //// 水素イオン濃度
                            //saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiSuisoIonNodo = saisuiRow.IsSaiSaisuiSuisoIonNodoNull() ? 0 : saisuiRow.SaiSaisuiSuisoIonNodo;
                            //
                            //// 温度
                            //saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiOndo = saisuiRow.IsSaiSaisuiOndoNull() ? 0 : saisuiRow.SaiSaisuiOndo;
                            //
                            //// 透視度（度）
                            //saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido = saisuiRow.IsSaiSaisuiToshidoNull() ? 0 : saisuiRow.SaiSaisuiToshido;
                            //
                            //// 透視度２
                            //saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido2 = saisuiRow.IsSaiSaisuiToshido2Null() ? string.Empty : saisuiRow.SaiSaisuiToshido2;
                            //
                            //// 生物化学酸素要求量
                            //saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD = saisuiRow.IsSaiSaisuiBODNull() ? 0 : saisuiRow.SaiSaisuiBOD;
                            //
                            //// 生物化学酸素要求量２
                            //saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD2 = saisuiRow.IsSaiSaisuiBOD2Null() ? string.Empty : saisuiRow.SaiSaisuiBOD2;
                            //
                            //// 残留塩素濃度
                            //saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiZanryuEnsoNodo = saisuiRow.IsSaiSaisuiZanryuEnsoNodoNull() ? 0 : saisuiRow.SaiSaisuiZanryuEnsoNodo;
                            //
                            //// 塩化イオン濃度
                            //saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo = saisuiRow.IsSaiSaisuiEnkaIonNodoNull() ? 0 : saisuiRow.SaiSaisuiEnkaIonNodo;
                            //
                            //// 塩化イオン濃度２
                            //saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo2 = saisuiRow.IsSaiSaisuiEnkaIonNodo2Null() ? string.Empty : saisuiRow.SaiSaisuiEnkaIonNodo2;

                            // pH
                            if (!saisuiRow.IsSaiSaisuiSuisoIonNodoNull())
                            {
                                // 水素イオン濃度
                                saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiSuisoIonNodo = saisuiRow.SaiSaisuiSuisoIonNodo;

                                // 温度
                                saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiOndo = saisuiRow.IsSaiSaisuiOndoNull() ? 0 : saisuiRow.SaiSaisuiOndo;
                            }
                            // 透視度
                            if (!saisuiRow.IsSaiSaisuiToshidoNull())
                            {
                                // 透視度（度）
                                saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido = saisuiRow.SaiSaisuiToshido;

                                // 透視度２
                                saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido2 = saisuiRow.IsSaiSaisuiToshido2Null() ? string.Empty : saisuiRow.SaiSaisuiToshido2;
                            }
                            // BOD
                            if (!saisuiRow.IsSaiSaisuiBODNull())
                            {
                                // 生物化学酸素要求量
                                saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD = saisuiRow.SaiSaisuiBOD;

                                // 生物化学酸素要求量２
                                saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD2 = saisuiRow.IsSaiSaisuiBOD2Null() ? string.Empty : saisuiRow.SaiSaisuiBOD2;
                            }
                            // 残塩
                            if (!saisuiRow.IsSaiSaisuiZanryuEnsoNodoNull())
                            {
                                // 残留塩素濃度
                                saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiZanryuEnsoNodo = saisuiRow.SaiSaisuiZanryuEnsoNodo;
                            }
                            // 塩化物イオン
                            if (!saisuiRow.IsSaiSaisuiEnkaIonNodoNull())
                            {
                                // 塩化イオン濃度
                                saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo = saisuiRow.SaiSaisuiEnkaIonNodo;

                                // 塩化イオン濃度２
                                saisuiOutput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo2 = saisuiRow.IsSaiSaisuiEnkaIonNodo2Null() ? string.Empty : saisuiRow.SaiSaisuiEnkaIonNodo2;
                            }
                            // 20141220 sou End Null判定を追加して更新する試験項目を切り分ける

                            saisuiOutput.SaiSaisuiTblDataTable[0].UpdateDt = saisuiRow.UpdateDt;
                            saisuiOutput.SaiSaisuiTblDataTable[0].UpdateTarm = saisuiRow.UpdateTarm;
                            saisuiOutput.SaiSaisuiTblDataTable[0].UpdateUser = saisuiRow.UpdateUser;

                            saisuiUpdateDT.ImportRow(saisuiOutput.SaiSaisuiTblDataTable[0]);
                        }
                    }
                }
                #endregion

                #region Get KeiryoShomeiKekkaTbl DT

                if (input.KeiryoShomeiKekkaTblDT != null && input.KeiryoShomeiKekkaTblDT.Count > 0)
                {
                    foreach (KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblRow keiryoRow in input.KeiryoShomeiKekkaTblDT)
                    {
                        IGetKeiryoShomeiKekkaTblByKeyBLInput keiryoInput = new GetKeiryoShomeiKekkaTblByKeyBLInput();
                        keiryoInput.KeiryoShomeiKekkaIraiNendo      = keiryoRow.KeiryoShomeiKekkaIraiNendo;
                        keiryoInput.KeiryoShomeiKekkaIraiNo         = keiryoRow.KeiryoShomeiKekkaIraiNo;
                        keiryoInput.KeiryoShomeiKekkaIraiShishoCd   = keiryoRow.KeiryoShomeiKekkaIraiShishoCd;
                        keiryoInput.KeiryoShomeiShikenkoumokuCd     = keiryoRow.KeiryoShomeiShikenkoumokuCd;
                        IGetKeiryoShomeiKekkaTblByKeyBLOutput keiryoOuput = new GetKeiryoShomeiKekkaTblByKeyBusinessLogic().Execute(keiryoInput);

                        if (keiryoOuput.KeiryoShomeiKekkaTblDT != null && keiryoOuput.KeiryoShomeiKekkaTblDT.Count > 0)
                        {
                            // 結果値  
                            keiryoOuput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValue = keiryoRow.KeiryoShomeiKekkaValue;

                            // 結果コード
                            keiryoOuput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaCd = keiryoRow.KeiryoShomeiKekkaCd;

                            // 結果値表示用
                            keiryoOuput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaValueHyojiyo = keiryoRow.KeiryoShomeiKekkaValueHyojiyo;

                            //20141220 sou Start
                            // 温度数
                            keiryoOuput.KeiryoShomeiKekkaTblDT[0].KeiryoShomeiKekkaOndo = keiryoRow.KeiryoShomeiKekkaOndo;
                            //20141220 sou End

                            keiryoOuput.KeiryoShomeiKekkaTblDT[0].UpdateDt = keiryoRow.UpdateDt;
                            keiryoOuput.KeiryoShomeiKekkaTblDT[0].UpdateTarm = keiryoRow.UpdateTarm;
                            keiryoOuput.KeiryoShomeiKekkaTblDT[0].UpdateUser = keiryoRow.UpdateUser;

                            keiryoUpdateDT.ImportRow(keiryoOuput.KeiryoShomeiKekkaTblDT[0]);
                        }
                    }
                }
                #endregion

                #region UPDATE

                IUpdateKensaDaichoDtlTblBLInput updateDtlInput = new UpdateKensaDaichoDtlTblBLInput();
                updateDtlInput.KensaDaichoDtlTblDT = dtlUpdateDT;
                new UpdateKensaDaichoDtlTblBusinessLogic().Execute(updateDtlInput);

                IUpdateKensaKekkaTblBLInput updateKekkaInput = new UpdateKensaKekkaTblBLInput();
                updateKekkaInput.KensaKekkaTblDataTable = kekkaUpdateDT;
                new UpdateKensaKekkaTblBusinessLogic().Execute(updateKekkaInput);

                IUpdateSaiSaisuiTblBLInput updateSaisuiInput = new UpdateSaiSaisuiTblBLInput();
                updateSaisuiInput.SaiSaisuiTblDataTable = saisuiUpdateDT;
                new UpdateSaiSaisuiTblBusinessLogic().Execute(updateSaisuiInput);

                IUpdateKeiryoShomeiKekkaTblBLInput updateKeiryoInput = new UpdateKeiryoShomeiKekkaTblBLInput();
                updateKeiryoInput.KeiryoShomeiKekkaTblDT = keiryoUpdateDT;
                new UpdateKeiryoShomeiKekkaTblBusinessLogic().Execute(updateKeiryoInput);

                #endregion

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

    }
    #endregion
}
