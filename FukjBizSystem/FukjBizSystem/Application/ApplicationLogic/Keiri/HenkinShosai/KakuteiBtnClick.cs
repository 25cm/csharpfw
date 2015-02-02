using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.KaiinKanri.KaiinNyukin;
using FukjBizSystem.Application.BusinessLogic.Keiri.HenkinShosai;
using FukjBizSystem.Application.BusinessLogic.Keiri.MaeukekinShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.HenkinShosai
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
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuteiBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 入金No
        /// </summary>
        string NyukinNo { get; set; }

        /// <summary>
        /// 完済フラグ
        /// </summary>
        string KansaiFlg { get; set; }

        /// <summary>
        /// 入金種別
        /// </summary>
        string NyukinSyubetsu { get; set; }

        ///// <summary>
        ///// 返金額合計
        ///// </summary>
        //Decimal HenkinGaku { get; set; }

        /// <summary>
        /// 返金可能額
        /// </summary>
        decimal NyukinGaku { get; set; }

        /// <summary>
        /// 返金済額
        /// </summary>
        decimal HeninsumiGaku { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// DataGrid source in screen
        /// </summary>
        HenkinTblDataSet.HenkinShosaiDataTable DgvSource { get; set; }

        // 2014.12.28 toyoda Delete Start
        ///// <summary>
        ///// 入金テーブル
        ///// </summary>
        //NyukinTblDataSet.NyukinTblDataTable RakkanNyukinTblDataTable { get; set; }

        ///// <summary>
        ///// 繰越金テーブル
        ///// </summary>
        //KurikoshiKinTblDataSet.KurikoshiKinTblDataTable RakkanKurikoshiKinTblDataTable { get; set; }

        ///// <summary>
        ///// 検査依頼テーブル
        ///// </summary>
        //KensaIraiTblDataSet.KensaIraiTblDataTable RakkanKensaIraiTblDataTable { get; set; }

        ///// <summary>
        ///// 前受金テーブル
        ///// </summary>
        //MaeukekinTblDataSet.MaeukekinTblDataTable RakkanMaeukekinTblDataTable { get; set; }
        // 2014.12.28 toyoda Delete End
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
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickALInput : IKakuteiBtnClickALInput
    {
        /// <summary>
        /// 入金No
        /// </summary>
        public string NyukinNo { get; set; }

        /// <summary>
        /// 完済フラグ
        /// </summary>
        public string KansaiFlg { get; set; }

        /// <summary>
        /// 入金種別
        /// </summary>
        public string NyukinSyubetsu { get; set; }

        ///// <summary>
        ///// 返金額合計
        ///// </summary>
        //public Decimal HenkinGaku { get; set; }

        /// <summary>
        /// 返金可能額
        /// </summary>
        public decimal NyukinGaku { get; set; }

        /// <summary>
        /// 返金済額
        /// </summary>
        public decimal HeninsumiGaku { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// DataGrid source in screen
        /// </summary>
        public HenkinTblDataSet.HenkinShosaiDataTable DgvSource { get; set; }

        // 2014.12.28 toyoda Delete Start
        ///// <summary>
        ///// 入金テーブル
        ///// </summary>
        //public NyukinTblDataSet.NyukinTblDataTable RakkanNyukinTblDataTable { get; set; }

        ///// <summary>
        ///// 繰越金テーブル
        ///// </summary>
        //public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable RakkanKurikoshiKinTblDataTable { get; set; }

        ///// <summary>
        ///// 検査依頼テーブル
        ///// </summary>
        //public KensaIraiTblDataSet.KensaIraiTblDataTable RakkanKensaIraiTblDataTable { get; set; }

        ///// <summary>
        ///// 前受金テーブル
        ///// </summary>
        //public MaeukekinTblDataSet.MaeukekinTblDataTable RakkanMaeukekinTblDataTable { get; set; }
        // 2014.12.28 toyoda Delete End

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("入金No[{0}]", NyukinNo);
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
    /// 2014/11/06　AnhNV　　    新規作成
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
    /// 2014/11/06　AnhNV　　    新規作成
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
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuteiBtnClickApplicationLogic : BaseApplicationLogic<IKakuteiBtnClickALInput, IKakuteiBtnClickALOutput>
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
        private const string FunctionName = "HenkinShosai：KakuteiBtnClick";

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
        /// 2014/11/06　AnhNV　　    新規作成
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
        /// 2014/11/06　AnhNV　　    新規作成
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
        /// 2014/11/06　AnhNV　　    新規作成
        /// 2014/12/12  AnhNV　　    基本設計書_006_021_画面_HenkinShosai_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuteiBtnClickALOutput Execute(IKakuteiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuteiBtnClickALOutput output = new KakuteiBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                // Login name
                string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                // Machine name
                string host = Dns.GetHostName();

                // Delete from HenkinTbl by NyukinNo
                IDeleteHenkinTblByNyukinNoBLInput blInput = new DeleteHenkinTblByNyukinNoBLInput();
                blInput.NyukinNo = input.NyukinNo;
                new DeleteHenkinTblByNyukinNoBusinessLogic().Execute(blInput);

                // Insert into HenkinTbl
                IUpdateHenkinTblBLInput henkinInput = new UpdateHenkinTblBLInput();
                henkinInput.HenkinTblDataTable = CreateHenkinTblDataTableInsert(input, user, host);
                new UpdateHenkinTblBusinessLogic().Execute(henkinInput);

                // Update NyukinTbl
                IUpdateNyukinTblBLInput nyukinInput = new UpdateNyukinTblBLInput();
                nyukinInput.NyukinTblDataTable = CreateNyukinTblDataTableUpdate(input, user, host);
                new UpdateNyukinTblBusinessLogic().Execute(nyukinInput);

                if (input.NyukinSyubetsu == "1")
                {
                    // Update KurikoshiKinTbl
                    IUpdateKurikoshiKinTblBLInput kInput = new UpdateKurikoshiKinTblBLInput();
                    kInput.KurikoshiKinTblDataTable = CreateKurikoshiKinTblDataTableUpdate(input, nyukinInput.NyukinTblDataTable, user, host);
                    new UpdateKurikoshiKinTblBusinessLogic().Execute(kInput);
                }
                else if (input.NyukinSyubetsu == "2")
                {
                    KensaIraiTblDataSet.KensaIraiTblDataTable kitTable;

                    // Update MaeukekinTbl
                    IUpdateMaeukekinTblBLInput mInput = new UpdateMaeukekinTblBLInput();
                    mInput.MaeukekinTblDT = CreateMaeukekinTblDataTableUpdate(input, nyukinInput.NyukinTblDataTable, user, host, out kitTable);
                    new UpdateMaeukekinTblBusinessLogic().Execute(mInput);

                    // v1.04 AnhNV ADD Start
                    IUpdateKensaIraiTblBLInput kensaInput = new UpdateKensaIraiTblBLInput();
                    kensaInput.KensaIraiTblDataTable = CreateKensaIraiTblDataTableUpdate(input, kitTable, user, host);
                    new UpdateKensaIraiTblBusinessLogic().Execute(kensaInput);
                    // v1.04 AnhNV ADD End
                }

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

        #region CreateHenkinTblDataTableInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHenkinTblDataTableInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06  AnhNV　　    新規作成
        /// 2014/12/21  小松        削除行は処理対象外
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HenkinTblDataSet.HenkinTblDataTable CreateHenkinTblDataTableInsert(IKakuteiBtnClickALInput input, string user, string host)
        {
            HenkinTblDataSet.HenkinTblDataTable table = new HenkinTblDataSet.HenkinTblDataTable();
            string henkinDt = string.Empty;

            foreach (HenkinTblDataSet.HenkinShosaiRow row in input.DgvSource)
            {
                if (row.RowState == System.Data.DataRowState.Deleted)
                {
                    // 削除行は処理対象外
                    continue;
                }

                HenkinTblDataSet.HenkinTblRow newRow = table.NewHenkinTblRow();

                // Get HenkinDt
                henkinDt = row.HenkinDt.Replace("/", string.Empty);

                // 入金No 
                newRow.NyukinNo = input.NyukinNo;
                // 返金連番 
                newRow.HenkinRenban = row.HenkinRenban;
                // 返金日 
                newRow.HenkinDt = henkinDt;
                // 返金額 
                newRow.HenkinGaku = Convert.ToDecimal(row.HenkinGaku);
                // 会計済フラグ 
                newRow.KaikeiRendoFlag = row.KaikeiRendoFlag;
                // 登録日
                newRow.InsertDt = row.IsInsertDtNull() ? input.SystemDt : row.InsertDt;
                // 登録者
                newRow.InsertUser = string.IsNullOrEmpty(row.InsertUser) ? user : row.InsertUser;
                // 登録端末
                newRow.InsertTarm = string.IsNullOrEmpty(row.InsertTarm) ? host : row.InsertTarm;
                // 更新日
                newRow.UpdateDt = input.SystemDt;
                // 更新者
                newRow.UpdateUser = user;
                // 更新端末
                newRow.UpdateTarm = host;

                table.AddHenkinTblRow(newRow);
                newRow.AcceptChanges();
                newRow.SetAdded();
            }

            return table;
        }
        #endregion

        #region CreateNyukinTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNyukinTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06  AnhNV　　    新規作成
        /// 2014/12/21  小松　　    楽観ロックチェック修正
        /// 2014/12/21  小松　　    返金額合計を正しくセット
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NyukinTblDataSet.NyukinTblDataTable CreateNyukinTblDataTableUpdate(IKakuteiBtnClickALInput input, string user, string host)
        {
            // Get NyukinTbl by key
            IGetNyukinTblByKeyBLInput blInput = new GetNyukinTblByKeyBLInput();
            blInput.NyukinNo = input.NyukinNo;
            IGetNyukinTblByKeyBLOutput blOuput = new GetNyukinTblByKeyBusinessLogic().Execute(blInput);

            if (blOuput.NyukinTblDataTable.Count > 0)
            {
                // 2014.12.28 toyoda Delete Start
                //if (input.RakkanNyukinTblDataTable != null)
                //{
                //    // 既存の対象行が存在する場合のみ楽観ロックチェック

                //    NyukinTblDataSet.NyukinTblRow[] nyukinRow = (NyukinTblDataSet.NyukinTblRow[])input.RakkanNyukinTblDataTable.Select(string.Format("NyukinNo = '{0}'", input.NyukinNo));
                //    // 更新日が違うか？
                //    if (blOuput.NyukinTblDataTable[0].UpdateDt != nyukinRow[0].UpdateDt)
                //    {
                //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                //    }
                //}
                // 2014.12.28 toyoda Delete End

                // 返金額合計
                //  返金額合計を正しくセット
                //blOuput.NyukinTblDataTable[0].NyukinGaku = input.NyukinGaku;
                blOuput.NyukinTblDataTable[0].HenkinGaku = input.HeninsumiGaku;
                // 次回繰り越し金
                if (input.NyukinSyubetsu == "1")
                {
                    blOuput.NyukinTblDataTable[0].JikaiKurikoshiKin = input.NyukinGaku - input.HeninsumiGaku;
                }
                // 完済フラグ 
                blOuput.NyukinTblDataTable[0].KansaiFlag = input.KansaiFlg;
                // 更新日
                blOuput.NyukinTblDataTable[0].UpdateDt = input.SystemDt;
                // 更新者
                blOuput.NyukinTblDataTable[0].UpdateUser = user;
                // 更新端末
                blOuput.NyukinTblDataTable[0].UpdateTarm = host;
            }

            return blOuput.NyukinTblDataTable;
        }
        #endregion

        #region CreateKurikoshiKinTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKurikoshiKinTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06  AnhNV　　    新規作成
        /// 2014/12/21  小松　　    楽観ロックチェック修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KurikoshiKinTblDataSet.KurikoshiKinTblDataTable CreateKurikoshiKinTblDataTableUpdate
            (
                IKakuteiBtnClickALInput input,
                NyukinTblDataSet.NyukinTblDataTable nyukinTable,
                string user,
                string host
            )
        {
            KurikoshiKinTblDataSet.KurikoshiKinTblDataTable table = new KurikoshiKinTblDataSet.KurikoshiKinTblDataTable();

            // Get KurikoshiKinTbl for update
            if (nyukinTable[0].NyukinmotoKbn == "1")
            {
                IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput kbnInput = new GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput();
                kbnInput.GyoshaCd = nyukinTable[0].NyukinGyosyaCd;
                kbnInput.GyosyaKojinKbn = nyukinTable[0].NyukinmotoKbn;
                IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput kbnOutput = new GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBusinessLogic().Execute(kbnInput);
                table = kbnOutput.KurikoshiKinTblDataTable;
            }
            else if (nyukinTable[0].NyukinmotoKbn == "2")
            {
                IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput jKeyInput = new GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput();
                jKeyInput.GyosyaKojinKbn = nyukinTable[0].NyukinmotoKbn;
                jKeyInput.JokasoHokenjoCd = nyukinTable[0].JokasoHokenjoCd;
                jKeyInput.JokasoTorokuNendo = nyukinTable[0].JokasoTorokuNendo;
                jKeyInput.JokasoRenban = nyukinTable[0].JokasoRenban;
                IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput jKeyOutput = new GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBusinessLogic().Execute(jKeyInput);
                table = jKeyOutput.KurikoshiKinTblDataTable;
            }

            for (int i = 0; i < table.Rows.Count; i++)
            {
                // 2014.12.28 toyoda Delete Start
                //if (input.RakkanKurikoshiKinTblDataTable != null)
                //{
                //    // 既存の対象行が存在する場合のみ楽観ロックチェック
                //    KurikoshiKinTblDataSet.KurikoshiKinTblRow[] kurikoshikinRow =
                //        (KurikoshiKinTblDataSet.KurikoshiKinTblRow[])input.RakkanKurikoshiKinTblDataTable.Select(string.Format("KurikoshikinNo = '{0}'", table[i].KurikoshikinNo));

                //    // 更新日が違うか？
                //    if (table[i].UpdateDt != kurikoshikinRow[0].UpdateDt)
                //    {
                //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                //    }
                //}
                // 2014.12.28 toyoda Delete End

                // 最終更新日 
                table[i].SaisyuKoshinDt = input.SystemDt.ToString("yyyyMMdd");
                // 繰り越し金 
                table[i].KurikoshiKin = input.NyukinGaku - input.HeninsumiGaku;
                // 更新日
                table[i].UpdateDt = input.SystemDt;
                // 更新者
                table[i].UpdateUser = user;
                // 更新端末
                table[i].UpdateTarm = host;
            }

            return table;
        }
        #endregion

        #region CreateMaeukekinTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateMaeukekinTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="nyukinTable"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <param name="kitTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06  AnhNV　　    新規作成
        /// 2014/12/21  小松　　    楽観ロックチェック修正
        /// 2014/12/22  kiyokuni    仕様変更 前受金更新項目変更
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private MaeukekinTblDataSet.MaeukekinTblDataTable CreateMaeukekinTblDataTableUpdate
            (
                IKakuteiBtnClickALInput input,
                NyukinTblDataSet.NyukinTblDataTable nyukinTable,
                string user,
                string host,
                out KensaIraiTblDataSet.KensaIraiTblDataTable kitTable
            )
        {
            MaeukekinTblDataSet.MaeukekinTblDataTable table = new MaeukekinTblDataSet.MaeukekinTblDataTable();
            kitTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

            string keyUpdate = nyukinTable[0].NyukinRenkeiNo;

            if (!string.IsNullOrEmpty(keyUpdate))
            {
                IGetMaeukekinTblBySyogoNoNyukinDtBLInput blInput = new GetMaeukekinTblBySyogoNoNyukinDtBLInput();
                blInput.MaeukekinSyogoNo1 = keyUpdate.Substring(0, 1);
                blInput.MaeukekinSyogoNo2 = keyUpdate.Substring(1);
                blInput.MaeukekinNyukinDt = nyukinTable[0].NyukinDt;
                IGetMaeukekinTblBySyogoNoNyukinDtBLOutput blOutput = new GetMaeukekinTblBySyogoNoNyukinDtBusinessLogic().Execute(blInput);
                table = blOutput.MaeukekinTblDataTable;

                if (table.Count > 0)
                {
                    // Get KensaIraiTbl by key - to update KensaIrai
                    IGetKensaIraiTblByKeyBLInput kitInput = new GetKensaIraiTblByKeyBLInput();
                    kitInput.KensaIraiHokenjoCd = table[0].MaeukekinKensaIraiHokenjoCd;
                    kitInput.KensaIraiHoteiKbn = table[0].MaeukekinKensaIraiHoteiKbn;
                    kitInput.KensaIraiNendo = table[0].MaeukekinKensaIraiNendo;
                    kitInput.KensaIraiRenban = table[0].MaeukekinKensaIraiRenban;
                    IGetKensaIraiTblByKeyBLOutput kitOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(kitInput);
                    kitTable = kitOutput.KensaIraiTblDataTable;

                    // 2014.12.28 toyoda Delete Start
                    //if (input.RakkanMaeukekinTblDataTable != null)
                    //{
                    //    // 既存の対象行が存在する場合のみ楽観ロックチェック

                    //    // Optimistic lock
                    //    MaeukekinTblDataSet.MaeukekinTblRow[] maeuRow =
                    //        (MaeukekinTblDataSet.MaeukekinTblRow[])input.RakkanMaeukekinTblDataTable.Select(string.Format("MaeukekinSyogoNo1 = '{0}' and MaeukekinSyogoNo2 = '{1}'", table[0].MaeukekinSyogoNo1, table[0].MaeukekinSyogoNo2));
                    //    // 更新日が違うか？
                    //    if (table[0].UpdateDt != maeuRow[0].UpdateDt)
                    //    {
                    //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                    //    }
                    //}
                    // 2014.12.28 toyoda Delete End

                    // Get 返金日の直近日付
                    HenkinTblDataSet.HenkinShosaiRow[] henkinRows = (HenkinTblDataSet.HenkinShosaiRow[])input.DgvSource.Select(string.Empty, "HenkinDt desc");
                    string maxHenkinDt = henkinRows[0].HenkinDt.Length >= 10 ? string.Concat(henkinRows[0].HenkinDt.Substring(0, 4),
                                                        henkinRows[0].HenkinDt.Substring(5, 2),
                                                        henkinRows[0].HenkinDt.Substring(8, 2)) : string.Empty;

                    // 取下日付 
                    table[0].MaeukekinTorisageDt = maxHenkinDt;
                    // 一部返金日
                    table[0].MaeukekinIchibuHenkinDt = maxHenkinDt;
                    // 一部返金額
                    table[0].MaeukekinIchibuHenkinAmt = input.HeninsumiGaku;
                    //// 検査依頼法定区分
                    //table[0].MaeukekinKensaIraiHoteiKbn = string.Empty;
                    //// 検査依頼保健所コード
                    //table[0].MaeukekinKensaIraiHokenjoCd = string.Empty;
                    //// 検査依頼年度
                    //table[0].MaeukekinKensaIraiNendo = string.Empty;
                    //// 検査依頼連番
                    //table[0].MaeukekinKensaIraiRenban = string.Empty;
                    // 残金 
                    table[0].MaeukekinZanAmt = input.NyukinGaku - input.HeninsumiGaku;
                    // 更新日
                    table[0].UpdateDt = input.SystemDt;
                    // 更新者
                    table[0].UpdateUser = user;
                    // 更新端末
                    table[0].UpdateTarm = host;
                }
            }

            return table;
        }
        #endregion

        #region CreateKensaIraiTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="table">Update table</param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12  AnhNV　　    基本設計書_006_021_画面_HenkinShosai_V1.04
        /// 2014/12/21  小松　　    楽観ロックチェック修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDataTableUpdate
        (
            IKakuteiBtnClickALInput input,
            KensaIraiTblDataSet.KensaIraiTblDataTable table,
            string user,
            string host
        )
        {
            if (table.Count > 0)
            {
                // 2014.12.28 toyoda Delete Start
                //if (input.RakkanKensaIraiTblDataTable != null)
                //{
                //    // 既存の対象行が存在する場合のみ楽観ロックチェック

                //    string filter = string.Format("KensaIraiHokenjoCd = '{0}' and KensaIraiHoteiKbn = '{1}' and KensaIraiNendo = '{2}' and KensaIraiRenban = '{3}'",
                //        table[0].KensaIraiHokenjoCd, table[0].KensaIraiHoteiKbn, table[0].KensaIraiNendo, table[0].KensaIraiRenban);
                //    KensaIraiTblDataSet.KensaIraiTblRow[] kitRow = (KensaIraiTblDataSet.KensaIraiTblRow[])input.RakkanKensaIraiTblDataTable.Select(filter);

                //    // 更新日が違うか？
                //    if (table[0].UpdateDt != kitRow[0].UpdateDt)
                //    {
                //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                //    }
                //}
                // 2014.12.28 toyoda Delete End

                // 入金方法 
                table[0].KensaIraiNyukinHohoKbn = "003";
                // 入金済金額
                table[0].KensaIraiNyukinzumiAmt = input.NyukinGaku - input.HeninsumiGaku; // (17) - (19)
                // 入金完了区分
                table[0].KensaIraiNyukinKanryoKbn = "0";
                // 更新日
                table[0].UpdateDt = input.SystemDt;
                // 更新者
                table[0].UpdateUser = user;
                // 更新端末
                table[0].UpdateTarm = host;
            }

            return table;
        }
        #endregion

        #endregion
    }
    #endregion
}
