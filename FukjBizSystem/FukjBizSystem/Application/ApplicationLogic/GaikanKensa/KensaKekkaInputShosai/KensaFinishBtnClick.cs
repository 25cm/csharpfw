using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaKekkaInputShosai;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaKekkaInputShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensaFinishBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensaFinishBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// 検査結果テーブル
        /// </summary>
        KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaTblDataTable { get; set; }

        /// <summary>
        /// 外観検査結果テーブル
        /// </summary>
        GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaTblDataTable { get; set; }

        /// <summary>
        /// 再採水テーブル
        /// </summary>
        SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiTblDataTable { get; set; }

        /// <summary>
        /// 浄化槽定型メモテーブル
        /// </summary>
        JokasoMemoTblDataSet.JokasoMemoTblDataTable JokasoMemoTblDataTable { get; set; }

        #region Optimistic lock checking tables
        /// <summary>
        /// 検査結果テーブル
        /// </summary>
        KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaRakTblDataTable { get; set; }

        /// <summary>
        /// 外観検査結果テーブル
        /// </summary>
        GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaRakTblDataTable { get; set; }

        /// <summary>
        /// 再採水テーブル
        /// </summary>
        SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiRakTblDataTable { get; set; }

        /// <summary>
        /// 浄化槽定型メモテーブル
        /// </summary>
        JokasoMemoTblDataSet.JokasoMemoTblDataTable JokasoMemoRakTblDataTable { get; set; }
        #endregion
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaFinishBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensaFinishBtnClickALInput : IKensaFinishBtnClickALInput
    {
        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// For optimistic lock checking
        /// </summary>
        public DateTime KensaKekkaUpdateDt { get; set; }

        /// <summary>
        /// For optimistic lock checking
        /// </summary> 
        public DateTime SaisuiUpdateDt { get; set; }

        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// 検査結果テーブル
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaTblDataTable { get; set; }

        /// <summary>
        /// 外観検査結果テーブル
        /// </summary>
        public GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaTblDataTable { get; set; }

        /// <summary>
        /// 再採水テーブル
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiTblDataTable { get; set; }

        /// <summary>
        /// 浄化槽定型メモテーブル
        /// </summary>
        public JokasoMemoTblDataSet.JokasoMemoTblDataTable JokasoMemoTblDataTable { get; set; }

        #region Optimistic lock checking tables
        /// <summary>
        /// 検査結果テーブル
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaRakTblDataTable { get; set; }

        /// <summary>
        /// 外観検査結果テーブル
        /// </summary>
        public GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaRakTblDataTable { get; set; }

        /// <summary>
        /// 再採水テーブル
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiRakTblDataTable { get; set; }

        /// <summary>
        /// 浄化槽定型メモテーブル
        /// </summary>
        public JokasoMemoTblDataSet.JokasoMemoTblDataTable JokasoMemoRakTblDataTable { get; set; }
        #endregion

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査依頼法定区分[{0}], 検査依頼保健所コード[{1}], 検査依頼年度[{2}], 検査依頼連番[{3}]",
                    KensaIraiTblDataTable[0].KensaIraiHoteiKbn,
                    KensaIraiTblDataTable[0].KensaIraiHokenjoCd,
                    KensaIraiTblDataTable[0].KensaIraiNendo,
                    KensaIraiTblDataTable[0].KensaIraiRenban);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensaFinishBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensaFinishBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaFinishBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensaFinishBtnClickALOutput : IKensaFinishBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensaFinishBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensaFinishBtnClickApplicationLogic : BaseApplicationLogic<IKensaFinishBtnClickALInput, IKensaFinishBtnClickALOutput>
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
        private const string FunctionName = "KensaKekkaInputShosai：KensaFinishBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensaFinishBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensaFinishBtnClickApplicationLogic()
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
        /// 2014/10/29　AnhNV　　    新規作成
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
        /// 2014/10/29　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensaFinishBtnClickALOutput Execute(IKensaFinishBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensaFinishBtnClickALOutput output = new KensaFinishBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                // Concurrency?
                RakkanCheckForKensaIraiTbl(input);

                // Update 検査依頼テーブル
                IUpdateKensaIraiTblBLInput kitInput = new UpdateKensaIraiTblBLInput();
                kitInput.KensaIraiTblDataTable = input.KensaIraiTblDataTable;
                new UpdateKensaIraiTblBusinessLogic().Execute(kitInput);

                // Update 検査結果テーブル
                KensaKekkaTblDataSet.KensaKekkaTblDataTable kekkaTbl = CreateKensaKekkaTblDataTableUpdate(input);
                IUpdateKensaKekkaTblBLInput kktInput = new UpdateKensaKekkaTblBLInput();
                // ADD/UPDATE
                kktInput.KensaKekkaTblDataTable = kekkaTbl.Rows.Count > 0 ? kekkaTbl : input.KensaKekkaTblDataTable;
                new UpdateKensaKekkaTblBusinessLogic().Execute(kktInput);

                // Update 外観検査結果テーブル
                GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable gaikanTbl = CreateGaikanKensaKekkaTblDataTableUpdate(input);
                IUpdateGaikanKensaKekkaTblBLInput gktInput = new UpdateGaikanKensaKekkaTblBLInput();
                // ADD/UPDATE
                gktInput.GaikanKensaKekkaTblDataTable = gaikanTbl.Rows.Count > 0 ? gaikanTbl : input.GaikanKensaKekkaTblDataTable;
                new UpdateGaikanKensaKekkaTblBusinessLogic().Execute(gktInput);

                // Update 再採水テーブル
                SaiSaisuiTblDataSet.SaiSaisuiTblDataTable saisuiTbl = CreateSaiSaisuiTblDataTableUpdate(input);
                IUpdateSaiSaisuiTblBLInput sstInput = new UpdateSaiSaisuiTblBLInput();
                // ADD/UPDATE
                sstInput.SaiSaisuiTblDataTable = saisuiTbl.Rows.Count > 0 ? saisuiTbl : input.SaiSaisuiTblDataTable;
                new UpdateSaiSaisuiTblBusinessLogic().Execute(sstInput);

                // Update 浄化槽定型メモテーブル
                JokasoMemoTblDataSet.JokasoMemoTblDataTable memoTbl = CreateJokasoMemoTblDataTableUpdate(input);
                IUpdateJokasoMemoTblBLInput jmInput = new UpdateJokasoMemoTblBLInput();
                // ADD/UPDATE
                jmInput.JokasoMemoTblDataTable = memoTbl.Rows.Count > 0 ? memoTbl : input.JokasoMemoTblDataTable;
                new UpdateJokasoMemoTblBusinessLogic().Execute(jmInput);

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

        #region RakkanCheckForKensaIraiTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RakkanCheckForKensaIraiTbl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheckForKensaIraiTbl(IKensaFinishBtnClickALInput input)
        {
            // Get KensaIraiTbl by key
            IGetKensaIraiTblByKeyBLInput blInput = new GetKensaIraiTblByKeyBLInput();
            blInput.KensaIraiHoteiKbn = input.KensaIraiTblDataTable[0].KensaIraiHoteiKbn;
            blInput.KensaIraiHokenjoCd = input.KensaIraiTblDataTable[0].KensaIraiHokenjoCd;
            blInput.KensaIraiNendo = input.KensaIraiTblDataTable[0].KensaIraiNendo;
            blInput.KensaIraiRenban = input.KensaIraiTblDataTable[0].KensaIraiRenban;
            IGetKensaIraiTblByKeyBLOutput blOuput = new GetKensaIraiTblByKeyBusinessLogic().Execute(blInput);

            if (blOuput.KensaIraiTblDataTable.Count > 0)
            {
                // 更新日が違うか？
                if (blOuput.KensaIraiTblDataTable[0].UpdateDt != input.KensaIraiTblDataTable[0].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 更新日
                input.KensaIraiTblDataTable[0].UpdateDt = input.SystemDt;
            }
        }
        #endregion

        #region CreateKensaKekkaTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaKekkaTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaKekkaTblDataSet.KensaKekkaTblDataTable CreateKensaKekkaTblDataTableUpdate(IKensaFinishBtnClickALInput input)
        {
            KensaKekkaTblDataSet.KensaKekkaTblDataTable table = new KensaKekkaTblDataSet.KensaKekkaTblDataTable();
            KensaKekkaTblDataSet.KensaKekkaTblRow updateRow = input.KensaKekkaTblDataTable[0];

            // Get 検査結果テーブル by key
            IGetKensaKekkaTblByKeyBLInput kekkaInput = new GetKensaKekkaTblByKeyBLInput();
            kekkaInput.KensaKekkaIraiHoteiKbn = input.KensaKekkaTblDataTable[0].KensaKekkaIraiHoteiKbn;
            kekkaInput.KensaKekkaIraiHokenjoCd = input.KensaKekkaTblDataTable[0].KensaKekkaIraiHokenjoCd;
            kekkaInput.KensaKekkaIraiNendo = input.KensaKekkaTblDataTable[0].KensaKekkaIraiNendo;
            kekkaInput.KensaKekkaIraiRenban = input.KensaKekkaTblDataTable[0].KensaKekkaIraiRenban;
            IGetKensaKekkaTblByKeyBLOutput kekkaOutput = new GetKensaKekkaTblByKeyBusinessLogic().Execute(kekkaInput);

            if (kekkaOutput.KensaKekkaTblDataTable.Rows.Count > 0)
            {
                // 更新日が違うか？
                if (kekkaOutput.KensaKekkaTblDataTable[0].UpdateDt != input.KensaKekkaRakTblDataTable[0].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 判定(34)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaHantei = updateRow.KensaKekkaHantei;
                // 水素イオン濃度(49)
                if (updateRow.IsKensaKekkaSuisoIonNodoNull())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaSuisoIonNodoNull();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodo = updateRow.KensaKekkaSuisoIonNodo;
                }
                // 水素イオン濃度ー判定(50)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSuisoIonNodoHantei = updateRow.KensaKekkaSuisoIonNodoHantei;
                // 溶存酸素量１(51)
                if (updateRow.IsKensaKekkaYozonSansoryo1Null())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaYozonSansoryo1Null();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaYozonSansoryo1 = updateRow.KensaKekkaYozonSansoryo1;
                }
                // 溶存酸素量２(52)
                if (updateRow.IsKensaKekkaYozonSansoryo2Null())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaYozonSansoryo2Null();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaYozonSansoryo2 = updateRow.KensaKekkaYozonSansoryo2;
                }
                // 溶存酸素量ー判定(53)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaYozonSansoryoHantei = updateRow.KensaKekkaYozonSansoryoHantei;
                // 透視度２次処理水(54)
                if (updateRow.IsKensaKekkaToshido2jiSyorisuiNull())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaToshido2jiSyorisuiNull();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshido2jiSyorisui = updateRow.KensaKekkaToshido2jiSyorisui;
                }
                // 透視度２２次処理水(55)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshido22jiSyorisui = updateRow.KensaKekkaToshido22jiSyorisui;
                // 透視度ー判定２次処理水(56)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshidoHantei2jiSyorisui = updateRow.KensaKekkaToshidoHantei2jiSyorisui;
                // 透視度(57)
                if (updateRow.IsKensaKekkaToshidoNull())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaToshidoNull();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshido = updateRow.KensaKekkaToshido;
                }
                // 透視度２(58)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshido2 = updateRow.KensaKekkaToshido2;
                // 透視度ー判定(59)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaToshidoHantei = updateRow.KensaKekkaToshidoHantei;
                // 残留塩素濃度(60)
                if (updateRow.IsKensaKekkaZanryuEnsoNodoNull())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaZanryuEnsoNodoNull();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodo = updateRow.KensaKekkaZanryuEnsoNodo;
                }
                // 残留塩素濃度ー判定(61)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaZanryuEnsoNodoHantei = updateRow.KensaKekkaZanryuEnsoNodoHantei;
                // 生物化学酸素要求量(62)
                if (updateRow.IsKensaKekkaBODNull())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaBODNull();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaBOD = updateRow.KensaKekkaBOD;
                }
                // 生物化学酸素要求量２(63)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaIraiBOD2 = updateRow.KensaIraiBOD2;
                // 生物化学酸素要求量ー判定(64)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaBODHantei = updateRow.KensaKekkaBODHantei;
                // 塩素イオン濃度(65)
                if (updateRow.IsKensaKekkaEnsoIonNodoNull())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaEnsoIonNodoNull();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodo = updateRow.KensaKekkaEnsoIonNodo;
                }
                // 塩素イオン濃度２(66)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaIraiEnsoIonNodo2 = updateRow.KensaIraiEnsoIonNodo2;
                // 塩素イオン濃度ー判定(67)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaEnsoIonNodoHantei = updateRow.KensaKekkaEnsoIonNodoHantei;
                // 汚泥沈殿率(68)
                if (updateRow.IsKensaKekkaOdeiChindenritsuNull())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaOdeiChindenritsuNull();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaOdeiChindenritsu = updateRow.KensaKekkaOdeiChindenritsu;
                }
                // 汚泥沈殿率２(69)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaOdeiChindenritsu2 = updateRow.KensaKekkaOdeiChindenritsu2;
                // 汚泥沈殿率ー判定(70)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaOdeiChindenritsuHantei = updateRow.KensaKekkaOdeiChindenritsuHantei;
                // ＭＬＳＳ(71)
                if (updateRow.IsKensaKekkaMLSSNull())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaMLSSNull();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaMLSS = updateRow.KensaKekkaMLSS;
                }
                // 水質検査測定不能(72)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSuishitsuSokuteifuno = updateRow.KensaKekkaSuishitsuSokuteifuno;
                // 水質検査依頼番号(73)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSuishitsuIraiNo = updateRow.KensaKekkaSuishitsuIraiNo;
                // 保守点検記録有無(100)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaHoshuTenkenKirokuUmu = updateRow.KensaKekkaHoshuTenkenKirokuUmu;
                // 保守点検回数(101)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaHoshuTenkenKaisu = updateRow.KensaKekkaHoshuTenkenKaisu;
                // 清掃記録有無(105)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSeisoKirokuUmu = updateRow.KensaKekkaSeisoKirokuUmu;
                // 清掃回数(106)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSeisoKaisu = updateRow.KensaKekkaSeisoKaisu;
                // 清掃内容(107)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSeisoNaiyo = updateRow.KensaKekkaSeisoNaiyo;
                // 清掃回数（年）(108)
                // 清掃日付(109), (110), (111)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaSeisoDt = updateRow.KensaKekkaSeisoDt;
                // メモ手書き(118)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaMemoTegaki = updateRow.KensaKekkaMemoTegaki;
                // v1.13 Add start
                // 保守点検-内容(102)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaHoshuTenkenNaiyo = updateRow.KensaKekkaHoshuTenkenNaiyo;
                // 保守点検-実施(251)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaTenkenKaisuKbn = updateRow.KensaKekkaTenkenKaisuKbn;
                // ATUBOD(247)
                if (updateRow.IsKensaKekkaATUBODNull())
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].SetKensaKekkaATUBODNull();
                }
                else
                {
                    kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaATUBOD = updateRow.KensaKekkaATUBOD;
                }
                // ATUBOD２(248)
                kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaATUBOD2 = updateRow.KensaKekkaATUBOD2;
                // v1.13 Add end
                //// 入力担当者
                //kekkaOutput.KensaKekkaTblDataTable[0].KensaKekkaNyuryokuTanto = updateRow.KensaKekkaNyuryokuTanto;
                // 更新日
                kekkaOutput.KensaKekkaTblDataTable[0].UpdateDt = input.SystemDt;
                // 更新者
                kekkaOutput.KensaKekkaTblDataTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                // 更新端末
                kekkaOutput.KensaKekkaTblDataTable[0].UpdateTarm = Dns.GetHostName();

                // Merge to result
                table.Merge(kekkaOutput.KensaKekkaTblDataTable);
            }

            return table;
        }
        #endregion

        #region CreateGaikanKensaKekkaTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateGaikanKensaKekkaTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable CreateGaikanKensaKekkaTblDataTableUpdate(IKensaFinishBtnClickALInput input)
        {
            GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable table = new GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable();

            for (int i = 0; i < input.GaikanKensaKekkaTblDataTable.Rows.Count; i++)
            {
                GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow procRow = input.GaikanKensaKekkaTblDataTable[i];

                // Get GaikanKensaKekkaTbl by key
                IGetGaikanKensaKekkaTblByKeyBLInput blInput = new GetGaikanKensaKekkaTblByKeyBLInput();
                blInput.GaikanKensaKekkaIraiHoteiKbn = procRow.GaikanKensaKekkaIraiHoteiKbn;
                blInput.GaikanKensaKekkaIraiHokenjoCd = procRow.GaikanKensaKekkaIraiHokenjoCd;
                blInput.GaikanKensaKekkakuIraiNendo = procRow.GaikanKensaKekkakuIraiNendo;
                blInput.GaikanKensaKekkaIraiRenban = procRow.GaikanKensaKekkaIraiRenban;
                blInput.GaikanKensaKekkaRenban = procRow.GaikanKensaKekkaRenban;
                IGetGaikanKensaKekkaTblByKeyBLOutput blOutput = new GetGaikanKensaKekkaTblByKeyBusinessLogic().Execute(blInput);

                // Update
                if (blOutput.GaikanKensaKekkaTblDataTable.Rows.Count > 0)
                {
                    GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow[] rakkRow
                        = (GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow[])input.GaikanKensaKekkaRakTblDataTable.Select(string.Format("GaikanKensaKekkaRenban = '{0}'", procRow.GaikanKensaKekkaRenban));

                    // 更新日が違うか？
                    if (blOutput.GaikanKensaKekkaTblDataTable[0].UpdateDt != rakkRow[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    // 外観チェック項目判定
                    blOutput.GaikanKensaKekkaTblDataTable[0].GaikanKensaKekkaCheckKomokuHantei = procRow.GaikanKensaKekkaCheckKomokuHantei;
                    // 外観チェック項目コード
                    blOutput.GaikanKensaKekkaTblDataTable[0].GaikanKensaKekkaCheckKomokuCd = procRow.GaikanKensaKekkaCheckKomokuCd;
                    // 更新日
                    blOutput.GaikanKensaKekkaTblDataTable[0].UpdateDt = input.SystemDt;
                    // 更新者
                    blOutput.GaikanKensaKekkaTblDataTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    // 更新端末
                    blOutput.GaikanKensaKekkaTblDataTable[0].UpdateTarm = Dns.GetHostName();
                    // Merge to result
                    table.Merge(blOutput.GaikanKensaKekkaTblDataTable);
                }
                else
                {
                    // Insert
                    table.ImportRow(procRow);
                }
            }

            return table;
        }
        #endregion

        #region CreateSaiSaisuiTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSaiSaisuiTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11  AnhNV　　    基本設計書_009_005_画面_KensaKekkaInputShosai_V1.13
        /// 2015/01/28  小松　　　　検査結果の値（pH値、BOD値、残留塩素値など）は未入力時は、NULLとする。（0は 0を入力済と判断）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SaiSaisuiTblDataSet.SaiSaisuiTblDataTable CreateSaiSaisuiTblDataTableUpdate(IKensaFinishBtnClickALInput input)
        {
            SaiSaisuiTblDataSet.SaiSaisuiTblDataTable table = new SaiSaisuiTblDataSet.SaiSaisuiTblDataTable();
            SaiSaisuiTblDataSet.SaiSaisuiTblRow updateRow = input.SaiSaisuiTblDataTable[0];

            // Get SaisaisuiTbl by key
            IGetSaiSaisuiTblByKeyBLInput blInput = new GetSaiSaisuiTblByKeyBLInput();
            blInput.SaiSaisuiIraiHoteiKbn = updateRow.SaiSaisuiIraiHoteiKbn;
            blInput.SaiSaisuiIraiHokenjoCd = updateRow.SaiSaisuiIraiHokenjoCd;
            blInput.SaiSaisuiIraiNendo = updateRow.SaiSaisuiIraiNendo;
            blInput.SaiSaisuiIraiRrenban = updateRow.SaiSaisuiIraiRrenban;
            IGetSaiSaisuiTblByKeyBLOutput blOutput = new GetSaiSaisuiTblByKeyBusinessLogic().Execute(blInput);

            if (blOutput.SaiSaisuiTblDataTable.Rows.Count > 0)
            {
                // 更新日が違うか？
                if (blOutput.SaiSaisuiTblDataTable[0].UpdateDt != input.SaiSaisuiRakTblDataTable[0].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 水素イオン濃度(74)
                if (updateRow.IsSaiSaisuiSuisoIonNodoNull())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiSuisoIonNodoNull();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiSuisoIonNodo = updateRow.SaiSaisuiSuisoIonNodo;
                }
                // 水素イオン濃度ー判定(75)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiSuisoIonNodoHantei = updateRow.SaiSaisuiSuisoIonNodoHantei;
                // 溶存酸素量１(76)
                if (updateRow.IsSaiSaisuiYozonSansoryo1Null())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiYozonSansoryo1Null();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiYozonSansoryo1 = updateRow.SaiSaisuiYozonSansoryo1;
                }
                // 溶存酸素量２(77)
                if (updateRow.IsSaiSaisuiYozonSansoryo2Null())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiYozonSansoryo2Null();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiYozonSansoryo2 = updateRow.SaiSaisuiYozonSansoryo2;
                }
                // 溶存酸素量ー判定(78)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiYozonSansoryoHantei = updateRow.SaiSaisuiYozonSansoryoHantei;
                // 透視度（度）２次処理水(79)
                if (updateRow.IsSaiSaisuiToshido2jishorisuiNull())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiToshido2jishorisuiNull();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido2jishorisui = updateRow.SaiSaisuiToshido2jishorisui;
                }
                // 透視度２２次処理水(80)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido22jishorisui = updateRow.SaiSaisuiToshido22jishorisui;
                // 透視度ー判定２次処理水(81)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshidoHantei2jishorisui = updateRow.SaiSaisuiToshidoHantei2jishorisui;
                // 透視度（度）(82)
                if (updateRow.IsSaiSaisuiToshidoNull())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiToshidoNull();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido = updateRow.SaiSaisuiToshido;
                }
                // 透視度２(83)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshido2 = updateRow.SaiSaisuiToshido2;
                // 透視度ー判定(84)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiToshidoHantei = updateRow.SaiSaisuiToshidoHantei;
                // 残留塩素濃度(85)
                if (updateRow.IsSaiSaisuiZanryuEnsoNodoNull())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiZanryuEnsoNodoNull();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiZanryuEnsoNodo = updateRow.SaiSaisuiZanryuEnsoNodo;
                }
                // 残留塩素濃度ー判定(86)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiZanryuEnsoNodoHantei = updateRow.SaiSaisuiZanryuEnsoNodoHantei;
                // 生物化学酸素要求量(87)
                if (updateRow.IsSaiSaisuiBODNull())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiBODNull();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD = updateRow.SaiSaisuiBOD;
                }
                // 生物化学酸素要求量２(88)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiBOD2 = updateRow.SaiSaisuiBOD2;
                // 生物化学酸素要求量ー判定(89)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiBODHantei = updateRow.SaiSaisuiBODHantei;
                // 塩化イオン濃度(90)
                if (updateRow.IsSaiSaisuiEnkaIonNodoNull())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiEnkaIonNodoNull();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo = updateRow.SaiSaisuiEnkaIonNodo;
                }
                // 塩化イオン濃度２(91)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodo2 = updateRow.SaiSaisuiEnkaIonNodo2;
                // 塩化イオン濃度ー判定(92)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiEnkaIonNodoHantei = updateRow.SaiSaisuiEnkaIonNodoHantei;
                // 汚泥沈殿率（％）(93)
                if (updateRow.IsSaiSaisuiOdeichindenritsuNull())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiOdeichindenritsuNull();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiOdeichindenritsu = updateRow.SaiSaisuiOdeichindenritsu;
                }
                // 汚泥沈殿率２(94)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiOdeichindenritsu2 = updateRow.SaiSaisuiOdeichindenritsu2;
                // 汚泥沈殿率ー判定(95)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiOdeichindenritsuHantei = updateRow.SaiSaisuiOdeichindenritsuHantei;
                // ＭＬＳＳ(96)
                if (updateRow.IsSaiSaisuiMLSSNull())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiMLSSNull();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiMLSS = updateRow.SaiSaisuiMLSS;
                }
                // 水質検査（測定不能）(97)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiSuishitsuSokuteifuno = updateRow.SaiSaisuiSuishitsuSokuteifuno;
                // 水質検査依頼番号(98)
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiSuishitsuIraiNo = updateRow.SaiSaisuiSuishitsuIraiNo;

                // v1.11 Add start
                // ATUBOD
                if (updateRow.IsSaiSaisuiATUBODNull())
                {
                    blOutput.SaiSaisuiTblDataTable[0].SetSaiSaisuiATUBODNull();
                }
                else
                {
                    blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiATUBOD = updateRow.SaiSaisuiATUBOD;
                }
                // ATUBOD２
                blOutput.SaiSaisuiTblDataTable[0].SaiSaisuiATUBOD2 = updateRow.SaiSaisuiATUBOD2;
                // v1.11 Add end

                // 更新日
                blOutput.SaiSaisuiTblDataTable[0].UpdateDt = input.SystemDt;
                // 更新者
                blOutput.SaiSaisuiTblDataTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                // 更新端末
                blOutput.SaiSaisuiTblDataTable[0].UpdateTarm = Dns.GetHostName();

                // Merge to result
                table.Merge(blOutput.SaiSaisuiTblDataTable);
            }

            return table;
        }
        #endregion

        #region CreateJokasoMemoTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateJokasoMemoTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private JokasoMemoTblDataSet.JokasoMemoTblDataTable CreateJokasoMemoTblDataTableUpdate(IKensaFinishBtnClickALInput input)
        {
            JokasoMemoTblDataSet.JokasoMemoTblDataTable table = new JokasoMemoTblDataSet.JokasoMemoTblDataTable();

            for (int i = 0; i < input.JokasoMemoTblDataTable.Rows.Count; i++)
            {
                JokasoMemoTblDataSet.JokasoMemoTblRow updateRow = input.JokasoMemoTblDataTable[i];

                // Get JokasoMemoTbl by key
                IGetJokasoMemoTblByKeyBLInput blInput = new GetJokasoMemoTblByKeyBLInput();
                blInput.JokasoMemoCd = updateRow.JokasoMemoCd;
                blInput.JokasoMemoDaibunruiCd = updateRow.JokasoMemoDaibunruiCd;
                blInput.JokasoMemoJokasoHokenjoCd = updateRow.JokasoMemoJokasoHokenjoCd;
                blInput.JokasoMemoJokasoTorokuNendo = updateRow.JokasoMemoJokasoTorokuNendo;
                blInput.JokasoMemoJokasoRenban = updateRow.JokasoMemoJokasoRenban;
                IGetJokasoMemoTblByKeyBLOutput blOutput = new GetJokasoMemoTblByKeyBusinessLogic().Execute(blInput);

                // Update
                if (blOutput.JokasoMemoTblDataTable.Rows.Count > 0)
                {
                    string filterKey = string.Format("JokasoMemoCd = '{0}' and JokasoMemoDaibunruiCd = '{1}' and JokasoMemoJokasoHokenjoCd = '{2}' and JokasoMemoJokasoTorokuNendo = '{3}' and JokasoMemoJokasoRenban = '{4}'",
                        new string[]
                        {
                            updateRow.JokasoMemoCd,
                            updateRow.JokasoMemoDaibunruiCd,
                            updateRow.JokasoMemoJokasoHokenjoCd,
                            updateRow.JokasoMemoJokasoTorokuNendo,
                            updateRow.JokasoMemoJokasoRenban
                        });

                    JokasoMemoTblDataSet.JokasoMemoTblRow[] rakkRow = (JokasoMemoTblDataSet.JokasoMemoTblRow[])input.JokasoMemoRakTblDataTable.Select(filterKey);

                    // 更新日が違うか？
                    if (blOutput.JokasoMemoTblDataTable[0].UpdateDt != rakkRow[0].UpdateDt)
                    {
                        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    }

                    // 更新日
                    blOutput.JokasoMemoTblDataTable[0].UpdateDt = input.SystemDt;
                    // 更新者
                    blOutput.JokasoMemoTblDataTable[0].UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    // 更新端末
                    blOutput.JokasoMemoTblDataTable[0].UpdateTarm = Dns.GetHostName();

                    // Merge to result
                    table.Merge(blOutput.JokasoMemoTblDataTable);
                }
                else // Insert
                {
                    table.ImportRow(updateRow);
                }
            }

            return table;
        }
        #endregion

        #endregion
    }
    #endregion
}
