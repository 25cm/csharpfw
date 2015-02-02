using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.GaikanKensa;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaNippoInput;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaNippoInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKoshinBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        KensaNippoInputForm.DispMode Mode { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// 検査日
        /// </summary>
        DateTime KensaDt { get; set; }

        /// <summary>
        /// 検査員
        /// </summary>
        string KensainCd { get; set; }

        /// <summary>
        /// 外観日報区分
        /// </summary>
        string NippoKbn { get; set; }

        /// <summary>
        /// 検査中止フラグ
        /// </summary>
        string NippoChushiFlg { get; set; }

        /// <summary>
        /// 日報ヘッダテーブル
        /// </summary>
        NippoHdrTblDataSet.NippoHdrTblDataTable NippoHdrTblDataTable { get; set; }

        /// <summary>
        /// 日報明細テーブル
        /// </summary>
        NippoDtlTblDataSet.NippoDtlTblDataTable NippoDtlTblDataTable { get; set; }

        /// <summary>
        /// KensaNippoInputDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaNippoInputDataTable KensaNippoInputDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALInput : IKoshinBtnClickALInput
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        public KensaNippoInputForm.DispMode Mode { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// 検査日
        /// </summary>
        public DateTime KensaDt { get; set; }

        /// <summary>
        /// 検査員
        /// </summary>
        public string KensainCd { get; set; }

        /// <summary>
        /// 外観日報区分
        /// </summary>
        public string NippoKbn { get; set; }

        /// <summary>
        /// 検査中止フラグ
        /// </summary>
        public string NippoChushiFlg { get; set; }

        /// <summary>
        /// 日報ヘッダテーブル
        /// </summary>
        public NippoHdrTblDataSet.NippoHdrTblDataTable NippoHdrTblDataTable { get; set; }

        /// <summary>
        /// 日報明細テーブル
        /// </summary>
        public NippoDtlTblDataSet.NippoDtlTblDataTable NippoDtlTblDataTable { get; set; }

        /// <summary>
        /// KensaNippoInputDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaNippoInputDataTable KensaNippoInputDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査日[{0}], 検査員[{1}]", KensaDt.ToString("yyyyMMdd"), KensainCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKoshinBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKoshinBtnClickALOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickALOutput : IKoshinBtnClickALOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KoshinBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KoshinBtnClickApplicationLogic : BaseApplicationLogic<IKoshinBtnClickALInput, IKoshinBtnClickALOutput>
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
        private const string FunctionName = "KensaNippoInput：KoshinBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KoshinBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KoshinBtnClickApplicationLogic()
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
        /// 2014/11/19　AnhNV　　    新規作成
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
        /// 2014/11/19　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKoshinBtnClickALOutput Execute(IKoshinBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKoshinBtnClickALOutput output = new KoshinBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                // Login user
                string user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                // Machine's name
                string host = Dns.GetHostName();

                // ADD mode
                if (input.Mode == KensaNippoInputForm.DispMode.Add)
                {
                    // 検査依頼テーブル
                    KensaIraiTblDataSet.KensaIraiTblDataTable kitTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();

                    foreach (KensaIraiTblDataSet.KensaNippoInputRow row in input.KensaNippoInputDataTable)
                    {
						kitTable.Merge(CreateKensaIraiTblDataTableUpdate(input, row, user, host, input.Mode));
                    }

                    // Update 日報ヘッダテーブル
                    IUpdateNippoHdrTblBLInput hdrInput = new UpdateNippoHdrTblBLInput();
                    hdrInput.NippoHdrTblDataTable = input.NippoHdrTblDataTable;
                    new UpdateNippoHdrTblBusinessLogic().Execute(hdrInput);
                    // Update 日報明細テーブル
                    IUpdateNippoDtlTblBLInput dtlInput = new UpdateNippoDtlTblBLInput();
                    dtlInput.NippoDtlTblDataTable = input.NippoDtlTblDataTable;
                    new UpdateNippoDtlTblBusinessLogic().Execute(dtlInput);
                    // Update 検査依頼テーブル
                    IUpdateKensaIraiTblBLInput kitInput = new UpdateKensaIraiTblBLInput();
                    kitInput.KensaIraiTblDataTable = kitTable;
                    new UpdateKensaIraiTblBusinessLogic().Execute(kitInput);
                }
                else // EDIT mode
                {
                    // Login user
                    user = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    // Machine's name
                    host = Dns.GetHostName();
                    // 検査依頼テーブル
                    KensaIraiTblDataSet.KensaIraiTblDataTable kitTable = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                    // 日報明細テーブル
                    NippoDtlTblDataSet.NippoDtlTblDataTable ndtTable = new NippoDtlTblDataSet.NippoDtlTblDataTable();

                    foreach (KensaIraiTblDataSet.KensaNippoInputRow row in input.KensaNippoInputDataTable)
                    {
                        // v1.04 DEL Start
                        //// Row is moving from 検査実施一覧グリッドビュー(7) to 検査中止一覧グリッドビュー(31)?
                        //if (row.RowMove == "1")
                        //{
                        //    //kitTable.Merge(CreateKensaIraiTblDataTableUpdateWhenRowDown(input, row, user, host));
                        //}
                        //else
                        //{
                        //    kitTable.Merge(CreateKensaIraiTblDataTableUpdate(input, row, user, host));
                        //}
                        // v1.04 DEL End

						kitTable.Merge(CreateKensaIraiTblDataTableUpdate(input, row, user, host, input.Mode));
                        ndtTable.Merge(CreateNippoDtlTblDataTableUpdate(input, row, user, host));
                    }

                    // Update 検査依頼テーブル
                    IUpdateKensaIraiTblBLInput kitInput = new UpdateKensaIraiTblBLInput();
                    kitInput.KensaIraiTblDataTable = kitTable;
                    new UpdateKensaIraiTblBusinessLogic().Execute(kitInput);
                    // Update 日報ヘッダテーブル
                    IUpdateNippoHdrTblBLInput hdrInput = new UpdateNippoHdrTblBLInput();
                    hdrInput.NippoHdrTblDataTable = input.NippoHdrTblDataTable;
                    new UpdateNippoHdrTblBusinessLogic().Execute(hdrInput);
                    // Update 日報明細テーブル
                    IUpdateNippoDtlTblBLInput ndtInput = new UpdateNippoDtlTblBLInput();
                    ndtInput.NippoDtlTblDataTable = ndtTable;
                    new UpdateNippoDtlTblBusinessLogic().Execute(ndtInput);
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

        #region CreateKensaIraiTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="row"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// 2014/12/03  AnhNV　　    基本設計書_009_010_画面_KensaNippoInput_V1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDataTableUpdate
        (
            IKoshinBtnClickALInput input,
            KensaIraiTblDataSet.KensaNippoInputRow row,
            string user,
            string host,
			KensaNippoInputForm.DispMode mode
        )
        {
            // Get KensaIraiTbl by key
            IGetKensaIraiTblByKeyBLInput kitInput = new GetKensaIraiTblByKeyBLInput();
            kitInput.KensaIraiHoteiKbn = row.KensaIraiHoteiKbn;
            kitInput.KensaIraiHokenjoCd = row.KensaIraiHokenjoCd;
            kitInput.KensaIraiNendo = row.KensaIraiNendo;
            kitInput.KensaIraiRenban = row.KensaIraiRenban;
            IGetKensaIraiTblByKeyBLOutput kitOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(kitInput);

            if (kitOutput.KensaIraiTblDataTable.Count > 0)
            {
                // 更新日が違うか？
                //if (!row.IsKensaIraiUpdateDtNull() && kitOutput.KensaIraiTblDataTable[0].UpdateDt != row.KensaIraiUpdateDt)
                if (kitOutput.KensaIraiTblDataTable[0].UpdateDt != row.KensaIraiUpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // Data in 検査実施一覧グリッドビュー(7)
                if (row.KensaChushiFlg == "0")
                {
                    // v1.05 ADD Start
                    // (74) is ON
                    if (row.NippoAdd == "1")
                    {
                        // 検査年
                        kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaNen = input.KensaDt.ToString("yyyy");
                        // 検査月
                        kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaTsuki = input.KensaDt.ToString("MM");
                        // 検査日
                        kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaBi = input.KensaDt.ToString("dd");
                    }
                    // v1.05 ADD End

                    // 外観日報区分
                    kitOutput.KensaIraiTblDataTable[0].KensaIraiGaikanNippoKbn = input.NippoKbn;

                    // v1.04
                    //if (row.DataRenkei == "2" || row.DataRenkei == "3")
                    //{
                    //    // ステータス区分
                    //    kitOutput.KensaIraiTblDataTable[0].KensaIraiStatusKbn = "10";
                    //}
                    // End v1.04

                    // v1.05 ADD Start
					// 受入20141217 mod sta
					if (!row.IsKensaKekkaKensaJoukyouKbnNull())
					{
                        //2015.01.09 mod 判定を変更 kiyokuni
                        if (!row.KensaKekkaKensaJoukyouKbn.Equals("003"))
                        //if (row.KensaKekkaKensaJoukyouKbn.Equals("001") || row.KensaKekkaKensaJoukyouKbn.Equals("002") || row.KensaKekkaKensaJoukyouKbn.Equals("004"))
                        {
							// ステータス区分
							kitOutput.KensaIraiTblDataTable[0].KensaIraiStatusKbn = "10";
						}
					}
					// 受入20141217 mod end
					// v1.05 ADD End
                }
                else if (row.KensaChushiFlg == "1") // Data in 検査中止一覧グリッドビュー(31)
                {
                    // 検査年
                    kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaNen = string.Empty;
                    // 検査月
                    kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaTsuki = string.Empty;
                    // 検査日
                    kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaBi = string.Empty;
                    // 外観日報区分
					if (mode.Equals(KensaNippoInputForm.DispMode.Add))
					{
						// 新規登録モード かつ 検査中止一覧の場合は、「外観日報区分」の更新は行わない・・・
						// のだが、登録更新が１つにまとめられてしまっているので、この場合は元の値で更新する。
						kitOutput.KensaIraiTblDataTable[0].KensaIraiGaikanNippoKbn = 
							kitOutput.KensaIraiTblDataTable[0].IsKensaIraiGaikanNippoKbnNull() ? String.Empty : kitOutput.KensaIraiTblDataTable[0].KensaIraiGaikanNippoKbn;
					}
					else
					{
						kitOutput.KensaIraiTblDataTable[0].KensaIraiGaikanNippoKbn = "0";
					}
                    // ステータス区分
                    kitOutput.KensaIraiTblDataTable[0].KensaIraiStatusKbn = "10";
                }
                
                // 更新日
                kitOutput.KensaIraiTblDataTable[0].UpdateDt = input.SystemDt;
                // 更新者
                kitOutput.KensaIraiTblDataTable[0].UpdateUser = user;
                // 更新端末
                kitOutput.KensaIraiTblDataTable[0].UpdateTarm = host;
            }

            return kitOutput.KensaIraiTblDataTable;
        }
        #endregion

        #region CreateNippoDtlTblDataTableUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNippoDtlTblDataTableUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="now"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private NippoDtlTblDataSet.NippoDtlTblDataTable CreateNippoDtlTblDataTableUpdate
        (
            IKoshinBtnClickALInput input,
            KensaIraiTblDataSet.KensaNippoInputRow row,
            string user,
            string host
        )
        {
            NippoDtlTblDataSet.NippoDtlTblDataTable table = new NippoDtlTblDataSet.NippoDtlTblDataTable();

            // Get NippoDtlTbl by key
            IGetNippoDtlTblByKeyBLInput dtlInput = new GetNippoDtlTblByKeyBLInput();
            dtlInput.NippoDtlKensaDt = input.KensaDt.ToString("yyyyMMdd");
            dtlInput.NippoDtlKensainCd = input.KensainCd;
            dtlInput.NippoDtlRenban = row.NippoDtlRenban;
            IGetNippoDtlTblByKeyBLOutput dtlOutput = new GetNippoDtlTblByKeyBusinessLogic().Execute(dtlInput);

            if (dtlOutput.NippoDtlTblDataTable.Count > 0)
            {
                // 更新日が違うか？
                if (!row.IsNippoDtlUpdateDtNull() && dtlOutput.NippoDtlTblDataTable[0].UpdateDt != row.NippoDtlUpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 補助員コード 
                dtlOutput.NippoDtlTblDataTable[0].NippoDtlHojoinCd = row.IsHojoinNull() ? string.Empty : row.Hojoin;
                // 検査中止フラグ
                dtlOutput.NippoDtlTblDataTable[0].NippoDtlKensaChushiFlg = row.KensaChushiFlg;
                // 検査中止理由
                dtlOutput.NippoDtlTblDataTable[0].NippoDtlKensaChushiRiyu = row.NippoDtlKensaChushiRiyu;
                // 更新日
                dtlOutput.NippoDtlTblDataTable[0].UpdateDt = input.SystemDt;
                // 更新者
                dtlOutput.NippoDtlTblDataTable[0].UpdateUser = user;
                // 更新端末
                dtlOutput.NippoDtlTblDataTable[0].UpdateTarm = host;
            }

            return dtlOutput.NippoDtlTblDataTable;
        }
        #endregion

        #region CreateKensaIraiTblDataTableUpdateWhenRowUp
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblDataTableUpdateWhenRowUp
        /// <summary>
        /// Update KensaIraiTbl when pass row from 検査中止一覧グリッドビュー(31) to 検査実施一覧グリッドビュー(7)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="row"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDataTableUpdateWhenRowUp
        //(
        //    IKoshinBtnClickALInput input,
        //    KensaIraiTblDataSet.KensaNippoInputRow row,
        //    string user,
        //    string host
        //)
        //{
        //    IGetKensaIraiTblByKeyBLInput kitInput = new GetKensaIraiTblByKeyBLInput();

        //    // Get KensaIraiTbl by key
        //    kitInput.KensaIraiHoteiKbn = row.KensaIraiHoteiKbn;
        //    kitInput.KensaIraiHokenjoCd = row.KensaIraiHokenjoCd;
        //    kitInput.KensaIraiNendo = row.KensaIraiNendo;
        //    kitInput.KensaIraiRenban = row.KensaIraiRenban;
        //    IGetKensaIraiTblByKeyBLOutput kitOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(kitInput);

        //    if (kitOutput.KensaIraiTblDataTable.Count > 0)
        //    {
        //        // 更新日が違うか？
        //        if (!row.IsKensaIraiUpdateDtNull() && kitOutput.KensaIraiTblDataTable[0].UpdateDt != row.KensaIraiUpdateDt)
        //        {
        //            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
        //        }

        //        // 検査年
        //        kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaNen = input.KensaDt.ToString("yyyy");
        //        // 検査月
        //        kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaTsuki = input.KensaDt.ToString("MM");
        //        // 検査日
        //        kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaBi = input.KensaDt.ToString("dd");
        //        // 外観日報区分
        //        kitOutput.KensaIraiTblDataTable[0].KensaIraiGaikanNippoKbn = input.NippoKbn;
        //        // 更新日
        //        kitOutput.KensaIraiTblDataTable[0].UpdateDt = input.SystemDt;
        //        // 更新者
        //        kitOutput.KensaIraiTblDataTable[0].UpdateUser = user;
        //        // 更新端末
        //        kitOutput.KensaIraiTblDataTable[0].UpdateTarm = host;
        //    }

        //    return kitOutput.KensaIraiTblDataTable;
        //}
        #endregion

        #region CreateKensaIraiTblDataTableUpdateWhenRowDown
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaIraiTblDataTableUpdateWhenRowDown
        /// <summary>
        /// Update KensaIraiTbl when pass row from 検査実施一覧グリッドビュー(7) to 検査中止一覧グリッドビュー(31)
        /// </summary>
        /// <param name="input"></param>
        /// <param name="row"></param>
        /// <param name="user"></param>
        /// <param name="host"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private KensaIraiTblDataSet.KensaIraiTblDataTable CreateKensaIraiTblDataTableUpdateWhenRowDown
        //(
        //    IKoshinBtnClickALInput input,
        //    KensaIraiTblDataSet.KensaNippoInputRow row,
        //    string user,
        //    string host
        //)
        //{
        //    // Get KensaIraiTbl by key
        //    IGetKensaIraiTblByKeyBLInput kitInput = new GetKensaIraiTblByKeyBLInput();
        //    kitInput.KensaIraiHoteiKbn = row.KensaIraiHoteiKbn;
        //    kitInput.KensaIraiHokenjoCd = row.KensaIraiHokenjoCd;
        //    kitInput.KensaIraiNendo = row.KensaIraiNendo;
        //    kitInput.KensaIraiRenban = row.KensaIraiRenban;
        //    IGetKensaIraiTblByKeyBLOutput kitOutput = new GetKensaIraiTblByKeyBusinessLogic().Execute(kitInput);

        //    if (kitOutput.KensaIraiTblDataTable.Count > 0)
        //    {
        //        // 更新日が違うか？
        //        if (!row.IsKensaIraiUpdateDtNull() && kitOutput.KensaIraiTblDataTable[0].UpdateDt != row.KensaIraiUpdateDt)
        //        {
        //            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
        //        }

        //        // 検査年
        //        kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaNen = string.Empty;
        //        // 検査月
        //        kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaTsuki = string.Empty;
        //        // 検査日
        //        kitOutput.KensaIraiTblDataTable[0].KensaIraiKensaBi = string.Empty;
        //        // 外観日報区分
        //        kitOutput.KensaIraiTblDataTable[0].KensaIraiGaikanNippoKbn = "0";
        //        // 更新日
        //        kitOutput.KensaIraiTblDataTable[0].UpdateDt = input.SystemDt;
        //        // 更新者
        //        kitOutput.KensaIraiTblDataTable[0].UpdateUser = user;
        //        // 更新端末
        //        kitOutput.KensaIraiTblDataTable[0].UpdateTarm = host;
        //    }

        //    return kitOutput.KensaIraiTblDataTable;
        //}
        #endregion

        #endregion
    }
    #endregion
}
