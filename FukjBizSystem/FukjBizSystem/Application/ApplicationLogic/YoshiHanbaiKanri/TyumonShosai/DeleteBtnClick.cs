using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.MaeukekinShosai;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoNoPrint;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.ZaikoList;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.YoshiHanbaiKanri;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　AnhNV　　    新規作成
    /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string YoshiZaikoShishoCd { get; set; }

        /// <summary>
        /// 注文番号
        /// </summary>
        string YoshiHanbaiChumonNo { get; set; }

        /// <summary>
        /// YoshiHeaderDataTable
        /// </summary>
        TyumonShosaiDataSet.YoshiHeaderDataTable YoshiHeaderDataTable { get; set; }

        /// <summary>
        /// YoshiDetailDataTable
        /// </summary>
        TyumonShosaiDataSet.YoshiDetailDataTable YoshiDetailDataTable { get; set; }

        ///// <summary>
        ///// 用紙在庫テーブル
        ///// </summary>
        //YoshiZaikoTblDataSet.YoshiZaikoTblDataTable YoshiZaikoTblDataTable { get; set; }

        ///// <summary>
        ///// 保証登録テーブル
        ///// </summary>
        //HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　AnhNV　　    新規作成
    /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALInput : IDeleteBtnClickALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string YoshiZaikoShishoCd { get; set; }

        /// <summary>
        /// 注文番号
        /// </summary>
        public string YoshiHanbaiChumonNo { get; set; }

        /// <summary>
        /// YoshiHeaderDataTable
        /// </summary>
        public TyumonShosaiDataSet.YoshiHeaderDataTable YoshiHeaderDataTable { get; set; }

        /// <summary>
        /// YoshiDetailDataTable
        /// </summary>
        public TyumonShosaiDataSet.YoshiDetailDataTable YoshiDetailDataTable { get; set; }

        ///// <summary>
        ///// 用紙在庫テーブル
        ///// </summary>
        //public YoshiZaikoTblDataSet.YoshiZaikoTblDataTable YoshiZaikoTblDataTable { get; set; }

        ///// <summary>
        ///// 保証登録テーブル
        ///// </summary>
        //public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("注文番号[{0}]", YoshiHanbaiChumonNo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　AnhNV　　    新規作成
    /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALOutput
    {
        ///// <summary>
        ///// Error message for delete
        ///// </summary>
        //string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　AnhNV　　    新規作成
    /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
    {
        ///// <summary>
        ///// Error message for delete
        ///// </summary>
        //public string ErrMsg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
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
        private const string FunctionName = "TyumonShosai：DeleteBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteBtnClickApplicationLogic()
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
        /// 2014/07/23　AnhNV　　    新規作成
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
        /// 2014/07/23　AnhNV　　    新規作成
        /// 2014/10/07  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteBtnClickALOutput Execute(IDeleteBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnClickALOutput output = new DeleteBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                // 更新日が違うか？
                RakkanCheck(input);

                // Update latest value for 在庫数(隠し(21)
                IGetZaikosuiByYoshiZaikoShishoCdBLInput yzsInput = new GetZaikosuiByYoshiZaikoShishoCdBLInput();
                yzsInput.YoshiZaikoShishoCd = input.YoshiZaikoShishoCd;
                IGetZaikosuiByYoshiZaikoShishoCdBLOutput yzsOutput = new GetZaikosuiByYoshiZaikoShishoCdBusinessLogic().Execute(yzsInput);

                YoshiZaikoTblDataSet.YoshiZaikoTblDataTable yztTable = new YoshiZaikoTblDataSet.YoshiZaikoTblDataTable();
                foreach (TyumonShosaiDataSet.YoshiDetailRow yoshiRow in input.YoshiDetailDataTable)
                {
                    // Update latest value for 在庫数(隠し(21)
                    if (yoshiRow.YoshiCd == yzsOutput.ZaikoSuiDataTable[0].YoshiCd)
                    {
                        yoshiRow.ZaikoCntHideCol = yzsOutput.ZaikoSuiDataTable[0].YoshiZaikoSuryo;
                    }

                    // 前回販売数(隠し)(19) > 0
                    if (yoshiRow.HanbaiCntHidenCol > 0)
                    {
                        // Create 用紙在庫テーブル
                        yztTable.Merge(CreateYoshiZaikoTblUpdate(yoshiRow, input));
                    }
                }

                // Update 用紙在庫テーブル
                IUpdateYoshiZaikoTblBLInput yztInput = new UpdateYoshiZaikoTblBLInput();
                yztInput.YoshiZaikoTblDataTable = yztTable;
                new UpdateYoshiZaikoTblBusinessLogic().Execute(yztInput);

                // Delete 用紙販売ヘッダテーブル
                IDeleteYoshiHanbaiHdrTblByKeyBLInput hdrInput = new DeleteYoshiHanbaiHdrTblByKeyBLInput();
                hdrInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                new DeleteYoshiHanbaiHdrTblByKeyBusinessLogic().Execute(hdrInput);

                // Delete 用紙販売明細テーブル
                IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput dtlInput = new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput();
                dtlInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic().Execute(dtlInput);

                // Update 保証登録テーブル
                IUpdateHoshoTorokuTblBLInput httInput = new UpdateHoshoTorokuTblBLInput();
                httInput.HoshoTorokuTblDT = CreateHoshoTorokuTblUpdate(input);
                new UpdateHoshoTorokuTblBusinessLogic().Execute(httInput);

                // Delete 入金テーブル, 入金種別 = 3
                IDeleteNyukinTblBySyubetsuAndRenkeiNoBLInput nt3Input = new DeleteNyukinTblBySyubetsuAndRenkeiNoBLInput();
                nt3Input.NyukinSyubetsu = "3";
                nt3Input.NyukinRenkeiNo = input.YoshiHanbaiChumonNo;
                new DeleteNyukinTblBySyubetsuAndRenkeiNoBusinessLogic().Execute(nt3Input);

                // Delete 入金テーブル, 入金種別 = 7
                IDeleteNyukinTblBySyubetsuAndRenkeiNoBLInput nt7Input = new DeleteNyukinTblBySyubetsuAndRenkeiNoBLInput();
                nt7Input.NyukinSyubetsu = "7";
                nt7Input.NyukinRenkeiNo = input.YoshiHanbaiChumonNo;
                new DeleteNyukinTblBySyubetsuAndRenkeiNoBusinessLogic().Execute(nt7Input);

                #region comments
                //// Get 用紙販売ヘッダテーブル by key
                //IGetYoshiHanbaiHdrTblByKeyBLInput hdrInput = new GetYoshiHanbaiHdrTblByKeyBLInput();
                //hdrInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                //IGetYoshiHanbaiHdrTblByKeyBLOutput hdrOutput = new GetYoshiHanbaiHdrTblByKeyBusinessLogic().Execute(hdrInput);

                //if (hdrOutput.YoshiHanbaiHdrTblDataTable.Count > 0)
                //{
                //    // 処理済チェック(削除時)
                //    output.ErrMsg = ShoriSumiCheck(hdrOutput.YoshiHanbaiHdrTblDataTable[0]);

                //    // Check OK
                //    if (string.IsNullOrEmpty(output.ErrMsg))
                //    {
                //        // Update 保証登録テーブル
                //        IUpdateHoshoTorokuTblBLInput hoshoInput = new UpdateHoshoTorokuTblBLInput();
                //        hoshoInput.HoshoTorokuTblDT = CreateHoshoTorokuTblDelete(hdrOutput.YoshiHanbaiHdrTblDataTable[0], input);
                //        new UpdateHoshoTorokuTblBusinessLogic().Execute(hoshoInput);

                //        // Get 用紙販売明細テーブル by 注文番号
                //        IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput dtlInput = new GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput();
                //        dtlInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                //        IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput dtlOutput = new GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic().Execute(dtlInput);

                //        // Update 用紙在庫テーブル
                //        IUpdateYoshiZaikoTblBLInput zaikoInput = new UpdateYoshiZaikoTblBLInput();
                //        zaikoInput.YoshiZaikoTblDataTable = MakeYoshiZaikoTblUpdate(hdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiShishoCd, dtlOutput.YoshiHanbaiDtlTblDataTable, input);
                //        new UpdateYoshiZaikoTblBusinessLogic().Execute(zaikoInput);

                //        // Delete 用紙販売ヘッダテーブル
                //        IDeleteYoshiHanbaiHdrTblByKeyBLInput hdrDelInput = new DeleteYoshiHanbaiHdrTblByKeyBLInput();
                //        hdrDelInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                //        new DeleteYoshiHanbaiHdrTblByKeyBusinessLogic().Execute(hdrDelInput);

                //        // Delete 用紙販売明細テーブル
                //        IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput dtlDelInput = new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput();
                //        dtlDelInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                //        new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic().Execute(dtlDelInput);
                //    }
                //}
                //else
                //{
                //    // Error
                //    output.ErrMsg = string.Format("該当するデータは登録されていません。[注文番号：{0}]", input.YoshiHanbaiChumonNo);
                //}
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
                // トランザクション終了
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region ShoriSumiCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ShoriSumiCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdrRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private string ShoriSumiCheck(YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblRow hdrRow)
        //{
        //    string errMsg = string.Empty;

        //    // 処理済チェック(更新)
        //    //if (hdrRow.IsYoshiHanbaiGenkinNyukingakuNull() || hdrRow.YoshiHanbaiGenkinNyukingaku != 0
        //    //    || hdrRow.IsYoshiHanbaiSeikyuKingakuNull() || hdrRow.YoshiHanbaiSeikyuKingaku != 0
        //    //    || hdrRow.IsYoshiHanbaiKansaiFlgNull() || hdrRow.YoshiHanbaiKansaiFlg != "0"
        //    //    || hdrRow.IsYoshiHanbaiSeikyushoHakkoFlgNull() || hdrRow.YoshiHanbaiSeikyushoHakkoFlg != "0"
        //    //    || hdrRow.IsYoshiHanbaiNohinshoHakkoFlgNull() || hdrRow.YoshiHanbaiNohinshoHakkoFlg != "0"
        //    //    || hdrRow.IsYoshiHanbaiHassoFlgNull() || hdrRow.YoshiHanbaiHassoFlg != "0")
        //    //{
        //    //    errMsg = "既に処理済のため、更新/削除できません。";
        //    //}

        //    return errMsg;
        //}
        #endregion

        #region MakeYoshiZaikoTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeYoshiZaikoTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="shishoCd"></param>
        /// <param name="dtlTable"></param>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private YoshiZaikoTblDataSet.YoshiZaikoTblDataTable MakeYoshiZaikoTblUpdate
        //(
        //    string shishoCd,
        //    YoshiHanbaiDtlTblDataSet.YoshiHanbaiDtlTblDataTable dtlTable,
        //    IDeleteBtnClickALInput input
        //)
        //{
        //    // 更新日
        //    DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
        //    // 更新者
        //    string username = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
        //    // 更新端末
        //    string hostname = Dns.GetHostName();

        //    // 在庫数量
        //    object sumObj;
        //    sumObj = dtlTable.Compute("Sum(YoshiHanbaiGokeiSuryo)", string.Empty);
        //    int zaikoSuryo = 0;
        //    if (sumObj is DBNull)
        //    {
        //    }
        //    else
        //    {
        //        zaikoSuryo = Convert.ToInt32(sumObj);
        //    }

        //    // 用紙在庫テーブル
        //    YoshiZaikoTblDataSet.YoshiZaikoTblDataTable zaikoDT = new YoshiZaikoTblDataSet.YoshiZaikoTblDataTable();
        //    // Get 用紙在庫テーブル by key
        //    IGetYoshiZaikoTblByKeyBLInput zaikoInp = new GetYoshiZaikoTblByKeyBLInput();
        //    zaikoInp.YoshiZaikoShishoCd = shishoCd;

        //    foreach (YoshiHanbaiDtlTblDataSet.YoshiHanbaiDtlTblRow row in dtlTable)
        //    {
        //        // Row for optimistic lock checking
        //        YoshiZaikoTblDataSet.YoshiZaikoTblRow[] zaikoRow
        //            = (YoshiZaikoTblDataSet.YoshiZaikoTblRow[])input.YoshiZaikoTblDataTable.Select(string.Format("YoshiZaikoShishoCd='{0}' and YoshiZaikoYoshiCd='{1}'", shishoCd, row.YoshiHanbaiYoshiCd));

        //        // Set input for get YoshiZaikoTbl by key
        //        zaikoInp.YoshiZaikoYoshiCd = row.YoshiHanbaiYoshiCd;
        //        IGetYoshiZaikoTblByKeyBLOutput zaikoOutp = new GetYoshiZaikoTblByKeyBusinessLogic().Execute(zaikoInp);

        //        if (zaikoOutp.YoshiZaikoTblDataTable.Count > 0)
        //        {
        //            // 更新日が違うか？
        //            if (zaikoOutp.YoshiZaikoTblDataTable[0].UpdateDt != zaikoRow[0].UpdateDt)
        //            {
        //                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
        //            }

        //            // 在庫数量
        //            zaikoOutp.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo = zaikoOutp.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo + zaikoSuryo;

        //            // 更新日
        //            zaikoOutp.YoshiZaikoTblDataTable[0].UpdateDt = now;

        //            // 更新者
        //            zaikoOutp.YoshiZaikoTblDataTable[0].UpdateUser = username;

        //            // 更新端末
        //            zaikoOutp.YoshiZaikoTblDataTable[0].UpdateTarm = hostname;

        //            zaikoDT.Merge(zaikoOutp.YoshiZaikoTblDataTable);
        //        }
        //    }

        //    return zaikoDT;
        //}
        #endregion

        #region CreateHoshoTorokuTblDelete
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHoshoTorokuTblDelete
        /// <summary>
        /// 
        /// </summary>
        /// <param name="hdrRow"></param>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/07  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable CreateHoshoTorokuTblDelete
        //(
        //    YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblRow hdrRow,
        //    IDeleteBtnClickALInput input
        //)
        //{
        //    // Get HoshoTorokuTbl by HoshoTorokuShishoKbn, HoshoTorokuUriageDt, HoshoTorokuHanbaisakiCd (before edit)
        //    IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput alInput = new GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput();
        //    alInput.HoshoTorokuShishoKbn = hdrRow.YoshiHanbaiShishoCd;
        //    alInput.HoshoTorokuUriageDt = hdrRow.YoshiHanbaiDt;
        //    alInput.HoshoTorokuHanbaisakiCd = hdrRow.YoshiHanbaisakiGyoshaCd;
        //    IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput alOutput = new GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBusinessLogic().Execute(alInput);
        //    HoshoTorokuTblDataSet.HoshoTorokuTblDataTable hoshoTable = alOutput.HoshoTorokuTblDataTable;

        //    string filter = string.Empty;
        //    for (int i = 0; i < hoshoTable.Count; i++)
        //    {
        //        // Row for optimistic lock checking
        //        filter = string.Format("HoshoTorokuKensakikan='{0}' and HoshoTorokuNendo='{1}' and HoshoTorokuRenban='{2}'",
        //            hoshoTable[i].HoshoTorokuKensakikan, hoshoTable[i].HoshoTorokuNendo, hoshoTable[i].HoshoTorokuRenban);
        //        HoshoTorokuTblDataSet.HoshoTorokuTblRow[] hoshoRow
        //            = (HoshoTorokuTblDataSet.HoshoTorokuTblRow[])input.HoshoTorokuTblDataTable.Select(filter);

        //        // 更新日が違うか？
        //        if (hoshoTable[i].UpdateDt != hoshoRow[0].UpdateDt)
        //        {
        //            throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
        //        }

        //        // 支所区分
        //        hoshoTable[i].HoshoTorokuShishoKbn = string.Empty;

        //        // 売上日付
        //        hoshoTable[i].HoshoTorokuUriageDt = string.Empty;

        //        // 販売先コード
        //        hoshoTable[i].HoshoTorokuHanbaisakiCd = string.Empty;

        //        // 更新日
        //        hoshoTable[i].UpdateDt = hdrRow.UpdateDt;

        //        // 更新者
        //        hoshoTable[i].UpdateUser = hdrRow.UpdateUser;

        //        // 更新端末
        //        hoshoTable[i].UpdateTarm = hdrRow.UpdateTarm;
        //    }

        //    return alOutput.HoshoTorokuTblDataTable;
        //}
        #endregion

        #region CreateYoshiZaikoTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateYoshiZaikoTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="yoshiRow"></param>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YoshiZaikoTblDataSet.YoshiZaikoTblDataTable CreateYoshiZaikoTblUpdate(TyumonShosaiDataSet.YoshiDetailRow yoshiRow, IDeleteBtnClickALInput input)
        {
            // Get 用紙在庫テーブル by key
            IGetYoshiZaikoTblByKeyBLInput yztInput = new GetYoshiZaikoTblByKeyBLInput();
            yztInput.YoshiZaikoShishoCd = input.YoshiZaikoShishoCd;
            yztInput.YoshiZaikoYoshiCd = yoshiRow.YoshiCd;
            IGetYoshiZaikoTblByKeyBLOutput yztOutput = new GetYoshiZaikoTblByKeyBusinessLogic().Execute(yztInput);

            if (yztOutput.YoshiZaikoTblDataTable.Rows.Count > 0)
            {
                // 在庫数量
                yztOutput.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo = yoshiRow.HanbaiCntHidenCol + yoshiRow.ZaikoCntHideCol;
                // 更新日
                yztOutput.YoshiZaikoTblDataTable[0].UpdateDt = input.YoshiHeaderDataTable[0].UpdateDt;
                // 更新者
                yztOutput.YoshiZaikoTblDataTable[0].UpdateUser = input.YoshiHeaderDataTable[0].UpdateUser;
                // 更新端末
                yztOutput.YoshiZaikoTblDataTable[0].UpdateTarm = input.YoshiHeaderDataTable[0].UpdateTarm;
            }

            return yztOutput.YoshiZaikoTblDataTable;
        }
        #endregion

        #region CreateHoshoTorokuTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHoshoTorokuTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private HoshoTorokuTblDataSet.HoshoTorokuTblDataTable CreateHoshoTorokuTblUpdate(IDeleteBtnClickALInput input)
        {
            // Get 保証登録テーブル by 保証登録注文番号 
            IGetHoshoTorokuTblByChumonNoBLInput blInput = new GetHoshoTorokuTblByChumonNoBLInput();
            blInput.HoshoTorokuChumonNo = input.YoshiHanbaiChumonNo;
            IGetHoshoTorokuTblByChumonNoBLOutput blOutput = new GetHoshoTorokuTblByChumonNoBusinessLogic().Execute(blInput);

            // Number of record need to update
            int rowNum = blOutput.HoshoTorokuTblDataTable.Rows.Count;
            for (int i = 0; i < rowNum; i++)
            {
                // 支所区分 
                blOutput.HoshoTorokuTblDataTable[i].HoshoTorokuShishoKbn = string.Empty;
                // 売上日付
                blOutput.HoshoTorokuTblDataTable[i].HoshoTorokuUriageDt = string.Empty;
                // 販売先コード
                blOutput.HoshoTorokuTblDataTable[i].HoshoTorokuHanbaisakiCd = string.Empty;
                // 更新日
                blOutput.HoshoTorokuTblDataTable[i].UpdateDt = input.YoshiHeaderDataTable[0].UpdateDt;
                // 更新者
                blOutput.HoshoTorokuTblDataTable[i].UpdateUser = input.YoshiHeaderDataTable[0].UpdateUser;
                // 更新端末
                blOutput.HoshoTorokuTblDataTable[i].UpdateTarm = input.YoshiHeaderDataTable[0].UpdateTarm;
            }

            return blOutput.HoshoTorokuTblDataTable;
        }
        #endregion

        #region SetNewZaikoSuryo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetNewZaikoSuryo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private void SetNewZaikoSuryo(IDeleteBtnClickALInput input)
        //{
        //    // Update latest value for 在庫数(隠し(21)
        //    IGetZaikosuiByYoshiZaikoShishoCdBLInput yzsInput = new GetZaikosuiByYoshiZaikoShishoCdBLInput();
        //    yzsInput.YoshiZaikoShishoCd = input.YoshiZaikoShishoCd;
        //    IGetZaikosuiByYoshiZaikoShishoCdBLOutput yzsOutput = new GetZaikosuiByYoshiZaikoShishoCdBusinessLogic().Execute(yzsInput);

        //    if (yzsOutput.ZaikoSuiDataTable.Rows.Count > 0)
        //    {
        //        foreach (TyumonShosaiDataSet.YoshiDetailRow dtRow in input.YoshiDetailDataTable)
        //        {
        //            if (dtRow.YoshiCd == yzsOutput.ZaikoSuiDataTable[0].YoshiCd)
        //            {
        //                dtRow.ZaikoCntHideCol = yzsOutput.ZaikoSuiDataTable[0].YoshiZaikoSuryo;
        //            }
        //        }
        //    }
        //}
        #endregion

        #region RakkanCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： RakkanCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDeleteBtnClickALInput input)
        {
            // Get 用紙販売ヘッダテーブル by key
            IGetYoshiHanbaiHdrTblByKeyBLInput blInput = new GetYoshiHanbaiHdrTblByKeyBLInput();
            blInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
            IGetYoshiHanbaiHdrTblByKeyBLOutput blOutput = new GetYoshiHanbaiHdrTblByKeyBusinessLogic().Execute(blInput);
            
            if (blOutput.YoshiHanbaiHdrTblDataTable.Rows.Count > 0)
            {
                // 更新日が違うか？
                if (blOutput.YoshiHanbaiHdrTblDataTable[0].UpdateDt != input.YoshiHeaderDataTable[0].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
