using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.YoshiHanbaiKanri;
using FukjBizSystem.Application.BusinessLogic.Keiri.MaeukekinShosai;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiShosai;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.ZaikoList;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.YoshiHanbaiKanri;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region UpdateData
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateData
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　 新規作成
    /// 2014/10/06  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
    /// 2014/10/16　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
    /// 2015/01/28　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class UpdateData
    {
        /// <summary>
        /// 表示モード
        /// </summary>
        public TyumonShosaiForm.DispMode DispMode { get; set; }
        /// <summary>
        /// 注文番号(7)
        /// </summary>
        public string YoshiHanbaiChumonNo { get; set; }
        /// <summary>
        /// 支所コード(1)
        /// </summary>
        public string YoshiHanbaiShishoCd { get; set; }
        /// <summary>
        /// 販売先業者コード(2)
        /// </summary>
        public string YoshiHanbaisakiGyoshaCd { get; set; }
        /// <summary>
        /// 業者名称(4)
        /// </summary>
        public string GyoshaNm { get; set; }
        /// <summary>
        /// 販売先担当者(4)
        /// </summary>
        public string YoshiHanbaisakiTantosha { get; set; }
        /// <summary>
        /// 会員区分
        /// </summary>
        //public string KaiinKbn { get; set; }
        /// <summary>
        /// 会員価格フラグ
        /// </summary>
        public string KaiinFlg { get; set; }
        /// <summary>
        /// 保証登録番号(32)
        /// </summary>
        public string HoshoTorokuNo { get; set; }
        /// <summary>
        /// 保証登録用紙コード
        /// </summary>
        public string HosyoTorokuYoushiCd { get; set; }
        ///// <summary>
        ///// 担当者(5)
        ///// </summary>
        //public string Tanto { get; set; }
        /// <summary>
        /// 現金入金(30)
        /// </summary>
        public bool GenkinNyukinCheck { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public int Nendo { get; set; }
        /// <summary>
        /// 販売合計金額(8)
        /// </summary>
        public decimal YoshiHanbaiGokeiKingaku { get; set; }
        /// <summary>
        /// 送料(31)
        /// </summary>
        public decimal YoshiHanbaiSoryo { get; set; }
        /// <summary>
        /// 用紙一覧グリッドビュー(9)
        /// </summary>
        //public DataGridView YoshiListDgv { get; set; }
        /// <summary>
        /// Current datetime in DB
        /// </summary>
        public DateTime Now { get; set; }
        /// <summary>
        /// 販売日
        /// </summary>
        public DateTime YoshiHanbaiDt { get; set; }
        ///// <summary>
        ///// 用紙販売ヘッダテーブル
        ///// </summary>
        //public YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable YoshiHanbaiHdrTblDataTable { get; set; }
        ///// <summary>
        ///// 用紙在庫テーブル
        ///// </summary>
        //public YoshiZaikoTblDataSet.YoshiZaikoTblDataTable YoshiZaikoTblDataTable { get; set; }
        ///// <summary>
        ///// 保証登録テーブル
        ///// </summary>
        //public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }

        // 2015.01.28 AnhNV ADD End
        /// <summary>
        /// 保証登録フラグ
        /// </summary>
        public bool HoshoTorokuHanbaiFlg { get; set; }
        /// <summary>
        /// YoshiHeaderDataTable
        /// </summary>
        public TyumonShosaiDataSet.YoshiHeaderDataTable YoshiHeaderDataTable { get; set; }
        /// <summary>
        /// YoshiDetailDataTable
        /// </summary>
        public TyumonShosaiDataSet.YoshiDetailDataTable YoshiDetailDataTable { get; set; }
        /// <summary>
        /// HoshoTorokuAkibanDataTable
        /// </summary>
        public TyumonShosaiDataSet.HoshoTorokuAkibanDataTable HoshoTorokuAkibanDataTable { get; set; }
        // 2015.01.28 AnhNV ADD Start
    }
    #endregion

    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// UpdateData
        /// </summary>
        UpdateData UpdateData { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALInput : IDecisionBtnClickALInput
    {
        /// <summary>
        /// UpdateData
        /// </summary>
        public UpdateData UpdateData { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("注文番号[{0}]", UpdateData.YoshiHanbaiChumonNo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDecisionBtnClickALOutput
    {
        /// <summary>
        /// Update error message
        /// </summary>
        string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickALOutput : IDecisionBtnClickALOutput
    {
        /// <summary>
        /// Update error message
        /// </summary>
        public string ErrMsg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DecisionBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DecisionBtnClickApplicationLogic : BaseApplicationLogic<IDecisionBtnClickALInput, IDecisionBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        // 2015.01.29 AnhNV ADD Start
        /// <summary>
        /// NyukinMode
        /// </summary>
        public enum NyukinMode
        {
            Insert = 1,
            Update,
            Delete
        }
        // 2015.01.29 AnhNV ADD End

        // 2015.01.29 AnhNV DEL Start
        /// <summary>
        /// Dictionary keys
        /// </summary>
        //private const string GOKEI_KINGAKU = "gokeiKingaku";
        //private const string HANBAI_GAKU = "hanbaiGaku";
        //private const string SHOHIZEI = "shohizei";
        //private const string NYUKINGAKU = "nyukingaku";
        //// 20150106 habu Add
        //private const string GOKEI_KINGAKU_HOSHOU = "gokeiKingakuHoshou";
        //private const string HANBAI_GAKU_HOSHOU = "hanbaiGakuHoshou";
        //private const string NYUKINGAKU_HOSHOU = "nyukingakuHoshou";
        // 2015.01.29 AnhNV DEL End

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TyumonShosai：DecisionBtnClick";

        /// <summary>
        /// ログインユーザー名
        /// </summary>
        private string UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// クライアント端末名
        /// </summary>
        private string UpdateTarm = Dns.GetHostName();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DecisionBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DecisionBtnClickApplicationLogic()
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
        /// 2014/07/22　AnhNV　　    新規作成
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
        /// 2014/07/22　AnhNV　　    新規作成
        /// 2014/10/17　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDecisionBtnClickALOutput Execute(IDecisionBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDecisionBtnClickALOutput output = new DecisionBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                // 明細行番号
                //int meisaiNo = MakeMeisaiNo(input);

                // List of 明細行番号, 販売合計金額, 販売金額, 消費税合計, 販売金額Col(22)
                //Dictionary<string, decimal> dictData = GetDictData(input);

                // Register mode
                if (input.UpdateData.DispMode == TyumonShosaiForm.DispMode.Add)
                {
                    DoInsert(input/*, dictData*/);
                }
                else // Edit mode
                {
                    DoUpdate(input/*, output, dictData*/);
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

        #region DoInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// 2014/10/06  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2014/10/16　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2015/01/28　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoInsert(IDecisionBtnClickALInput input/*, Dictionary<string, decimal> dictData*/)
        {
            TyumonDataTable updateDT = new TyumonDataTable();
            YoshiHanbaiDtlTblDataSet.YoshiHanbaiDtlTblRow outDtlRow;

            // 保証登録空き番取得 - Add mode
            IGetHoshoTorokuAkibanByCondBLInput akbInput = new GetHoshoTorokuAkibanByCondBLInput();
            akbInput.SearchCond = new HoshoTorokuAkibanSearchCond();
            akbInput.SearchCond.AkibanMode = AkibanMode.Add;
            akbInput.SearchCond.HoshoTorokuChumonNo = string.Empty;
            IGetHoshoTorokuAkibanByCondBLOutput akbOutput = new GetHoshoTorokuAkibanByCondBusinessLogic().Execute(akbInput);

            // Total of 販売金額
            decimal totalHanbaiGaku = 0;
            // Total of 消費税合計
            decimal totalSyohizei = 0;
            // Total of 販売合計金額
            object gokeiKingakuObj = input.UpdateData.YoshiDetailDataTable.Compute("sum(HanbaiKakakuCol)", "HanbaiCntCol > 0");
            decimal totalGokeiKingaku = gokeiKingakuObj is DBNull ? 0 : Convert.ToDecimal(gokeiKingakuObj);
            // Total of 販売金額(24)
            decimal seikyuKingaku = 0;
            // ｛用紙一覧｝．｛保証登録フラグ｝=1の行の｛販売金額｝
            object subGokeiKingakuObj = input.UpdateData.YoshiDetailDataTable.Compute("sum(HanbaiKingakuCol)", "HoshoTorokuFlgHideCol = '1'");
            decimal subGokeiKingaku = subGokeiKingakuObj is DBNull ? 0 : Convert.ToDecimal(subGokeiKingakuObj);

            foreach (TyumonShosaiDataSet.YoshiDetailRow detailRow in input.UpdateData.YoshiDetailDataTable)
            {
                if (!detailRow.IsHanbaiCntColNull() && detailRow.HanbaiCntCol > 0)
                {
                    // Create dtl table
                    CreateYoshiHanbaiDtlInsert(input, detailRow, updateDT.YoshiHanbaiDtlTblDataTable, out outDtlRow);
                    // Create zaikoTbl table
                    CreateYoshiZaikoTblInsert(input, detailRow, updateDT.YoshiZaikoTblDataTable);

                    totalHanbaiGaku += outDtlRow.YoshiHanbaiGaku;
                    totalSyohizei += outDtlRow.YoshiHanbaiShohizei;
                }

                // 現金入金(8) is ON
                if (input.UpdateData.GenkinNyukinCheck)
                {
                    seikyuKingaku += detailRow.HanbaiKingakuCol;

                    if (detailRow.HoshoTorokuFlgHideCol != "1")
                    {
                        // Create NyukinTbl (保証登録以外)
                        if (!input.UpdateData.HoshoTorokuHanbaiFlg)
                        {
                            CreateNyukinTblInsertWithoutHoshou(input, updateDT.NyukinTblDataTable, totalGokeiKingaku);
                        }
                        else
                        {
                            CreateNyukinTblInsertWithoutHoshou(input, updateDT.NyukinTblDataTable, totalGokeiKingaku - subGokeiKingaku);
                        }
                    }

                    if (input.UpdateData.HoshoTorokuHanbaiFlg
                        && detailRow.HoshoTorokuFlgHideCol == "1")
                    {
                        // Create NyukinTbl (保証登録)
                        CreateNyukinTblInsertWithHoshou(input, updateDT.NyukinTblDataTable, detailRow.HanbaiKingakuCol);
                    }
                }
            }

            // Create Hdr table
            CreateYoshiHanbaiHdrInsert(input, updateDT.YoshiHanbaiHdrTblDataTable, totalHanbaiGaku, totalSyohizei, totalGokeiKingaku, seikyuKingaku);
            // Create HoshoTorokuTbl table
            CreateHoshoTorokuTblInsert(input, updateDT.HoshoTorokuTblDataTable, akbOutput.HoshoTorokuAkibanDataTable);

            // Executes update
            IUpdateTyumonBLInput updateInput = new UpdateTyumonBLInput();
            updateInput.TyumonDataTable = updateDT;
            new UpdateTyumonBusinessLogic().Execute(updateInput);

            // 2015.01.28 AnhNV DEL Start
            #region
            //// 販売合計金額
            ////decimal yoshiHanbaiGokeiKingaku = GetGokeiKingakuFromDgv(input);
            //// Error messages for 在庫数チェック
            ////string zaikosu = string.Empty;

            //// 販売金額
            ////decimal yoshiHanbaiGaku = 0;
            //// 消費税合計
            ////decimal yoshiHanbaiShohizei = 0;
            //// 販売金額Col(22)
            ////decimal genkinNyukingaku = 0;

            //// 会員/非会員
            ////bool isKaiin = KaiinCheck();

            //// Has 保証登録用紙コード or not
            //bool isContainsHoshouTorokuYoshi = false;
            //bool isContainsNormalYoshi = false;
            //// 販売価格 in YoshiHanbaiDtl row which contains YoshiCd = 23
            //decimal yoshiHanbaiKakakuYoshi = 0;
            //// Total of 販売価格
            //decimal yoshiHanbaiKakakuTotal = 0;
            //// Call to update
            //IUpdateTyumonBLInput blInput = new UpdateTyumonBLInput();
            //// Create 用紙販売ヘッダテーブル
            //updateDT.YoshiHanbaiHdrTblDataTable = CreateYoshiHanbaiHdrInsert(input, dictData);

            //// Get RenbanNo from HoshoTorokuNo(32)
            //int renban = !string.IsNullOrEmpty(input.UpdateData.HoshoTorokuNo) ?
            //    Convert.ToInt32(input.UpdateData.HoshoTorokuNo.Substring(6)) : 0;

            //// Loop the dgv
            //int rowIdx = 0;
            //foreach (DataGridViewRow dgvr in input.UpdateData.YoshiListDgv.Rows)
            //{
            //    // Skip empty 販売数(19) columns
            //    if (dgvr.Cells["HanbaiCntCol"].Value == null
            //        || string.IsNullOrEmpty(dgvr.Cells["HanbaiCntCol"].Value.ToString()))
            //    {
            //        continue;
            //    }

            //    // Create 用紙販売明細テーブル
            //    CreateYoshiHanbaiDtlInsert(input, dgvr, updateDT.YoshiHanbaiDtlTblDataTable);

            //    // Get total of 販売価格
            //    yoshiHanbaiKakakuTotal += updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiKakaku;

            //    // YoshiCdCol = 23?
            //    if (dgvr.Cells["YoshiCdCol"].Value.ToString() == input.UpdateData.HosyoTorokuYoushiCd)
            //    {
            //        yoshiHanbaiKakakuYoshi = updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiKakaku;
            //        isContainsHoshouTorokuYoshi = true;
            //    }
            //    else
            //    {
            //        isContainsNormalYoshi = true;
            //    }

            //    // Sum of 販売合計金額
            //    //yoshiHanbaiGokeiKingaku += updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiKakaku;

            //    // Sum of 販売金額
            //    //yoshiHanbaiGaku += updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiGaku;

            //    // Sum of 消費税合計
            //    //yoshiHanbaiShohizei += updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiShohizei;

            //    // 現金入金(30) is checked ON?
            //    //if (input.UpdateData.GenkinNyukinCheck)
            //    //{
            //    //    // Sum of 販売金額Col(22)
            //    //    genkinNyukingaku += Convert.ToDecimal(dgvr.Cells["HanbaiKingakuCol"].Value);
            //    //}

            //    // 販売数(19) value
            //    int hanbaiCnt = Convert.ToInt32(dgvr.Cells["HanbaiCntCol"].Value.ToString());

            //    // 保証登録の場合は、販売数分、保証登録テーブルの登録を行う
            //    if (dgvr.Cells["YoshiCdCol"].Value.ToString() == input.UpdateData.HosyoTorokuYoushiCd)
            //    {
            //        for (int i = 1; i <= hanbaiCnt; i++)
            //        {
            //            // Convert renban to string
            //            string renbanStr = renban.ToString().PadLeft(5, '0');

            //            // Create 保証登録テーブル
            //            updateDT.HoshoTorokuTblDataTable.Merge(CreateHoshoTorokuTblInsert(input, updateDT.YoshiHanbaiHdrTblDataTable[0], input.UpdateData.Now, renbanStr));

            //            // Next renban
            //            renban++;
            //        }
            //    }

            //    // 販売合計数量
            //    int gokeiSuryo = updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiGokeiSuryo;

            //    // Create 用紙在庫テーブル
            //    CreateYoshiZaikoTblInsert(input, dgvr, updateDT.YoshiZaikoTblDataTable, updateDT.YoshiHanbaiHdrTblDataTable[0], gokeiSuryo);

            //    // 在庫数チェック
            //    //zaikosu += ZaikosuCheck(dgvr, updateDT.YoshiHanbaiHdrTblDataTable[0], updateDT.YoshiHanbaiDtlTblDataTable[rowIdx]);

            //    // Next row
            //    rowIdx++;
            //}

            //// 現金入金(30) is ON
            //// 現金入金の場合、入金テーブルを登録する
            //if (input.UpdateData.GenkinNyukinCheck)
            //{
            //    // 20150106 habu 保証登録のみの場合は、通常のみの入金レコードを作成しない
            //    if (isContainsNormalYoshi)
            //    {
            //        // Create 入金テーブル (without yoshi) for insert
            //        CreateNyukinTblInsertWithoutYoshi(input, updateDT.NyukinTblDataTable, dictData, yoshiHanbaiKakakuYoshi);
            //    }

            //    // 保証登録を含む場合、保証登録は別個に入金テーブルを登録する
            //    // Has yoshiCd = 23?
            //    if (isContainsHoshouTorokuYoshi)
            //    {
            //        // Create 入金テーブル (with yoshi) for insert
            //        CreateNyukinTblInsertWithYoshi(input, updateDT.NyukinTblDataTable, yoshiHanbaiKakakuYoshi);
            //    }
            //}

            ////if (zaikosu != string.Empty)
            ////{
            ////    output.ErrMsg = string.Format("行{0}: 販売数が在庫数を超えています。", zaikosu.Remove(zaikosu.Length - 2));
            ////    return;
            ////}

            ////#region HDR MONEY FIELDS
            ////if (updateDT.YoshiHanbaiHdrTblDataTable.Count > 0)
            ////{
            ////    // Set 販売金額 for update
            ////    updateDT.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGaku = yoshiHanbaiGaku;
            ////    // Set 消費税合計 for update
            ////    updateDT.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiShohizei = yoshiHanbaiShohizei;
            ////    // Set 販売合計金額 for update
            ////    //updateDT.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGokeiKingaku = yoshiHanbaiGokeiKingaku;
            ////    // Set 現金入金額  for update
            ////    updateDT.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGenkinNyukingaku = genkinNyukingaku;
            ////}
            ////#endregion

            //// Execute insert
            //blInput.TyumonDataTable = updateDT;

            //new UpdateTyumonBusinessLogic().Execute(blInput);
            #endregion
            // 2015.01.28 AnhNV DEL End
        }
        #endregion

        #region DoUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DoUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// 2014/10/06  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2014/10/17　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2015/01/29　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DoUpdate(IDecisionBtnClickALInput input/*, IDecisionBtnClickALOutput output, Dictionary<string, decimal> dictData*/)
        {
            TyumonDataTable updateDT = new TyumonDataTable();
            YoshiHanbaiDtlTblDataSet.YoshiHanbaiDtlTblRow outDtlRow;

            // 保証登録空き番取得 - Update mode
            IGetHoshoTorokuAkibanByCondBLInput akbInput = new GetHoshoTorokuAkibanByCondBLInput();
            akbInput.SearchCond = new HoshoTorokuAkibanSearchCond();
            akbInput.SearchCond.AkibanMode = AkibanMode.Edit;
            akbInput.SearchCond.HoshoTorokuChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
            IGetHoshoTorokuAkibanByCondBLOutput akbOutput = new GetHoshoTorokuAkibanByCondBusinessLogic().Execute(akbInput);

            // Total of 販売金額(Dtl Table)
            decimal totalHanbaiGaku = 0;
            // Total of 消費税合計(Dtl Table)
            decimal totalSyohizei = 0;
            // Total of 販売合計金額
            object gokeiKingakuObj = input.UpdateData.YoshiDetailDataTable.Compute("sum(HanbaiKakakuCol)", "HanbaiCntCol > 0");
            decimal totalGokeiKingaku = gokeiKingakuObj is DBNull ? 0 : Convert.ToDecimal(gokeiKingakuObj);
            // Total of 販売金額(24)
            //decimal seikyuKingaku = 0;
            // ｛用紙一覧｝．｛保証登録フラグ｝=1の行の｛販売金額｝
            object subGokeiKingakuObj = input.UpdateData.YoshiDetailDataTable.Compute("sum(HanbaiKingakuCol)", "HoshoTorokuFlgHideCol = '1'");
            decimal subGokeiKingaku = subGokeiKingakuObj is DBNull ? 0 : Convert.ToDecimal(subGokeiKingakuObj);
            // Total of 販売金額計(Dtl Table)
            decimal totalHanbaiKakaku = 0;

            // Delete 用紙販売明細テーブル by YoshiHanbaiChumonNo
            IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput delInput = new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput();
            delInput.YoshiHanbaiChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
            new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic().Execute(delInput);
            // Nyukin exist check
            IGetNyukinExistCheckByNyukinRenkeiNoBLInput ckInput = new GetNyukinExistCheckByNyukinRenkeiNoBLInput();
            ckInput.NyukinRenkeiNo = input.UpdateData.YoshiHanbaiChumonNo;
            IGetNyukinExistCheckByNyukinRenkeiNoBLOutput ckOutput = new GetNyukinExistCheckByNyukinRenkeiNoBusinessLogic().Execute(ckInput);

            foreach (TyumonShosaiDataSet.YoshiDetailRow detailRow in input.UpdateData.YoshiDetailDataTable)
            {
                // (18) > 0
                if (detailRow.HanbaiCntCol > 0)
                {
                    // Create dtl table
                    CreateYoshiHanbaiDtlInsert(input, detailRow, updateDT.YoshiHanbaiDtlTblDataTable, out outDtlRow);

                    totalHanbaiGaku += outDtlRow.YoshiHanbaiGaku;
                    totalSyohizei += outDtlRow.YoshiHanbaiShohizei;
                    totalHanbaiKakaku += outDtlRow.YoshiHanbaiKakaku;
                }

                // (18) != (19)
                if (detailRow.HanbaiCntCol != detailRow.HanbaiCntHidenCol)
                {
                    // Create ZaikoTbl
                    CreateYoshiZaikoTblUpdate(input, detailRow);
                }

                // Create NyukinTbl (保証登録以外)
                TyumonShosaiDataSet.NyukinExistCheckRow[] hoshoRow = (TyumonShosaiDataSet.NyukinExistCheckRow[])ckOutput.NyukinExistCheckDataTable.Select("NyukinSyubetsu = '3'");
                int hoshoMode = GetNyukinMode(input.UpdateData.GenkinNyukinCheck, hoshoRow.Length > 0, detailRow.HoshoTorokuFlgHideCol == "0");
                switch (hoshoMode)
                {
                    case (int)NyukinMode.Insert:
                        // Create NyukinTbl (保証登録以外)
                        if (!input.UpdateData.HoshoTorokuHanbaiFlg)
                        {
                            CreateNyukinTblInsertWithoutHoshou(input, updateDT.NyukinTblDataTable, totalGokeiKingaku);
                        }
                        else
                        {
                            CreateNyukinTblInsertWithoutHoshou(input, updateDT.NyukinTblDataTable, totalGokeiKingaku - subGokeiKingaku);
                        }
                        break;
                    case (int)NyukinMode.Update:
                        // Create NyukinTbl (保証登録以外)
                        if (!input.UpdateData.HoshoTorokuHanbaiFlg)
                        {
                            CreateNyukinTblUpdate(input, updateDT.NyukinTblDataTable, totalGokeiKingaku, "3");
                        }
                        else
                        {
                            CreateNyukinTblUpdate(input, updateDT.NyukinTblDataTable, totalGokeiKingaku - subGokeiKingaku, "3");
                        }
                        break;
                    case (int)NyukinMode.Delete:
                        // Delete NyukinTbl
                        DeleteNyukinTbl(input, "3");
                        break;
                    default:
                        break;
                }

                // (保証登録)?
                if (input.UpdateData.HoshoTorokuHanbaiFlg
                        && detailRow.HoshoTorokuFlgHideCol == "1") // (20) == 1
                {
                    hoshoRow = (TyumonShosaiDataSet.NyukinExistCheckRow[])ckOutput.NyukinExistCheckDataTable.Select("NyukinSyubetsu = '7'");
                    hoshoMode = GetNyukinMode(input.UpdateData.GenkinNyukinCheck, hoshoRow.Length > 0, detailRow.HoshoTorokuFlgHideCol == "1");
                    // Create NyukinTbl (保証登録)
                    switch (hoshoMode)
                    {
                        case (int)NyukinMode.Insert:
                            // Create NyukinTbl (保証登録) - Insert
                            CreateNyukinTblInsertWithHoshou(input, updateDT.NyukinTblDataTable, detailRow.HanbaiKingakuCol);
                            break;
                        case (int)NyukinMode.Update:
                            // Create NyukinTbl (保証登録) - Update
                            if (!input.UpdateData.HoshoTorokuHanbaiFlg)
                            {
                                CreateNyukinTblUpdate(input, updateDT.NyukinTblDataTable, totalGokeiKingaku, "7");
                            }
                            else
                            {
                                CreateNyukinTblUpdate(input, updateDT.NyukinTblDataTable, totalGokeiKingaku - subGokeiKingaku, "7");
                            }
                            break;
                        case (int)NyukinMode.Delete:
                            // Delete NyukinTbl
                            DeleteNyukinTbl(input, "7");
                            break;
                        default:
                            break;
                    }
                }
            }

            // Create Hdr table
            CreateYoshiHanbaiHdrUpdate(input, totalHanbaiGaku, totalSyohizei, totalHanbaiKakaku);
            // Create HoshoToroku table
            CreateHoshoTorokuTblUpdate(input, updateDT.HoshoTorokuTblDataTable, akbOutput.HoshoTorokuAkibanDataTable);

            // 2015.01.29 AnhNV DEL Start
            #region
            //// 注文情報の登録済みチェック
            //output.ErrMsg = ExistCheck(input);
            //if (!string.IsNullOrEmpty(output.ErrMsg)) return;

            //// 処理済チェック(更新)
            ////output.ErrMsg = ShoriSumiCheck(input);
            //if (!string.IsNullOrEmpty(output.ErrMsg)) return;
            
            //// Error messages for 在庫数チェック
            ////string zaikosu = string.Empty;
            //// 販売合計数量
            ////int gokeiSuryo = MakeGokeiSuryoTotal(input);
            //// 販売合計金額
            ////decimal yoshiHanbaiGokeiKingaku = 0;
            //// Sum of 販売金額(22)
            //decimal hanbaiKingaku = 0;
            //// 販売合計数量 - before edit
            //int gokeiSuryoBefore = 0;
            //// 会員/非会員
            ////bool isKaiin = KaiinCheck();
            //object sumObj;

            //// 販売金額
            ////decimal yoshiHanbaiGaku = 0;
            ////// 消費税合計
            ////decimal yoshiHanbaiShohizei = 0;

            //TyumonDataTable updateDT = new TyumonDataTable();
            //IUpdateTyumonBLInput blInput = new UpdateTyumonBLInput();

            //// 用紙販売ヘッダテーブル
            //updateDT.YoshiHanbaiHdrTblDataTable = CreateYoshiHanbaiHdrUpdate(input, dictData);

            //// Get 用紙販売明細テーブル by YoshiHanbaiChumonNo
            //IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput dtlInput = new GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput();
            //dtlInput.YoshiHanbaiChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
            //IGetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput dtlOutput = new GetYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic().Execute(dtlInput);
            //sumObj = dtlOutput.YoshiHanbaiDtlTblDataTable.Compute("Sum(YoshiHanbaiGokeiSuryo)", string.Empty);
            //if (sumObj is DBNull)
            //{
            //}
            //else
            //{
            //    gokeiSuryoBefore = Convert.ToInt32(sumObj);
            //}

            //// Get RenbanNo from HoshoTorokuNo(32)
            //int renban = !string.IsNullOrEmpty(input.UpdateData.HoshoTorokuNo) ?
            //    Convert.ToInt32(input.UpdateData.HoshoTorokuNo.Substring(6)) : 0;

            //// Loop the dgv
            //int rowIdx = 0;
            //foreach (DataGridViewRow dgvr in input.UpdateData.YoshiListDgv.Rows)
            //{
            //    // Skip empty 販売数(19) columns
            //    if (dgvr.Cells["HanbaiCntCol"].Value == null
            //        || string.IsNullOrEmpty(dgvr.Cells["HanbaiCntCol"].Value.ToString()))
            //    {
            //        continue;
            //    }

            //    // Re-create 用紙販売明細テーブル
            //    //CreateYoshiHanbaiDtlInsert(input, dgvr, updateDT.YoshiHanbaiDtlTblDataTable);

            //    //// Sum of 販売金額
            //    //yoshiHanbaiGaku += updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiGaku;

            //    //// Sum of 消費税合計
            //    //yoshiHanbaiShohizei += updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiShohizei;

            //    //// Sum of 販売合計金額
            //    //yoshiHanbaiGokeiKingaku += updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiKakaku;
                
            //    if (input.UpdateData.GenkinNyukinCheck &&
            //        null != dgvr.Cells["HanbaiKingakuCol"].Value && string.Empty != dgvr.Cells["HanbaiKingakuCol"].Value.ToString())
            //    {
            //        // Sum of 販売金額(22)
            //        hanbaiKingaku += Convert.ToDecimal(dgvr.Cells["HanbaiKingakuCol"].Value);
            //    }

            //    // 販売数(19) value
            //    int hanbaiCnt = Convert.ToInt32(dgvr.Cells["HanbaiCntCol"].Value.ToString());
            //    if (dgvr.Cells["YoshiCdCol"].Value.ToString() == input.UpdateData.HosyoTorokuYoushiCd)
            //    {
            //        for (int i = 1; i <= hanbaiCnt; i++)
            //        {
            //            // Convert renban to string
            //            string renbanStr = renban.ToString().PadLeft(5, '0');

            //            // Create 保証登録テーブル
            //            //updateDT.HoshoTorokuTblDataTable.Merge(CreateHoshoTorokuTblInsert(input, updateDT.YoshiHanbaiHdrTblDataTable[0], input.UpdateData.Now, renbanStr));

            //            // Next renban
            //            renban++;
            //        }
            //    }

            //    // 販売合計数量
            //    int gokeiSuryo = updateDT.YoshiHanbaiDtlTblDataTable[rowIdx].YoshiHanbaiGokeiSuryo;

            //    // Create 用紙在庫テーブル
            //    updateDT.YoshiZaikoTblDataTable.Merge(CreateYoshiZaikoTblUpdate(input, dgvr, updateDT.YoshiHanbaiHdrTblDataTable[0], gokeiSuryo, gokeiSuryoBefore));

            //    // 在庫数チェック
            //    //zaikosu += ZaikosuCheck(dgvr, updateDT.YoshiHanbaiHdrTblDataTable[0], updateDT.YoshiHanbaiDtlTblDataTable[rowIdx]);

            //    // Next row
            //    rowIdx++;
            //}

            ////if (zaikosu != string.Empty)
            ////{
            ////    output.ErrMsg = string.Format("行{0}: 販売数が在庫数を超えています。", zaikosu.Remove(zaikosu.Length - 2));
            ////    return;
            ////}

            //// Clear HoshoTorokuTbl
            //updateDT.HoshoTorokuTblDataTable.Merge(CreateHoshoTorokuTblUpdate(input));

            //// Delete 用紙販売明細テーブル
            //DeleteYoshiHanbaiDtl(input);

            //// HDR
            //if (updateDT.YoshiHanbaiHdrTblDataTable.Count > 0)
            //{
            //    // 現金入金額
            //    updateDT.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGenkinNyukingaku = hanbaiKingaku;
            //    //// Set 販売金額 for update
            //    //updateDT.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGaku = yoshiHanbaiGaku;
            //    //// Set 消費税合計 for update
            //    //updateDT.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiShohizei = yoshiHanbaiShohizei;
            //    //// Set 販売合計金額 for update
            //    //updateDT.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiGokeiKingaku = yoshiHanbaiGokeiKingaku;
            //}

            //// 変更
            //blInput.TyumonDataTable = updateDT;
            //RakkanCheck(input);
            //new UpdateTyumonBusinessLogic().Execute(blInput);
            #endregion
            // 2015.01.29 AnhNV DEL End
        }
        #endregion

        #region DeleteYoshiHanbaiDtl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteYoshiHanbaiDtl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private void DeleteYoshiHanbaiDtl(IDecisionBtnClickALInput input)
        //{
        //    // Delete YoshiHanbaiDtl by YoshiHanbaiChumonNo
        //    IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput blInput = new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput();
        //    blInput.YoshiHanbaiChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
        //    new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic().Execute(blInput);
        //}
        #endregion

        #region ExistCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ExistCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private string ExistCheck(IDecisionBtnClickALInput input)
        //{
        //    // Message check
        //    string errMsg = string.Empty;

        //    // Get 用紙販売ヘッダテーブル by key
        //    IGetYoshiHanbaiHdrTblByKeyBLInput blInput = new GetYoshiHanbaiHdrTblByKeyBLInput();
        //    blInput.YoshiHanbaiChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
        //    IGetYoshiHanbaiHdrTblByKeyBLOutput blOutput = new GetYoshiHanbaiHdrTblByKeyBusinessLogic().Execute(blInput);

        //    // No record was found
        //    if (blOutput.YoshiHanbaiHdrTblDataTable.Count == 0)
        //    {
        //        errMsg = string.Format("該当するデータは登録されていません。[注文番号：{0}]", input.UpdateData.YoshiHanbaiChumonNo);
        //    }

        //    return errMsg;
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
        /// 2014/07/22  AnhNV　　    新規作成
        /// 2014/10/07  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void RakkanCheck(IDecisionBtnClickALInput input)
        {
            // Get 用紙販売ヘッダテーブル by key
            //IGetYoshiHanbaiHdrTblByKeyBLInput blInput = new GetYoshiHanbaiHdrTblByKeyBLInput();
            //blInput.YoshiHanbaiChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
            //IGetYoshiHanbaiHdrTblByKeyBLOutput blOutput = new GetYoshiHanbaiHdrTblByKeyBusinessLogic().Execute(blInput);

            //// 更新日が違うか？
            //if (blOutput.YoshiHanbaiHdrTblDataTable[0].UpdateDt != input.UpdateData.YoshiHanbaiHdrTblDataTable[0].UpdateDt)
            //{
            //    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            //}

            //// 更新日
            //input.UpdateData.YoshiHanbaiHdrTblDataTable[0].UpdateDt = input.UpdateData.Now;

            //// 更新者
            //input.UpdateData.YoshiHanbaiHdrTblDataTable[0].UpdateUser = this.LoginUser;

            //// 更新端末
            //input.UpdateData.YoshiHanbaiHdrTblDataTable[0].UpdateTarm = this.HostName;
        }
        #endregion

        #region ZaikosuCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ZaikosuCheck
        /// <summary>
        /// 在庫数チェック
        /// </summary>
        /// <param name="dgvr"></param>
        /// <param name="hdrRow"></param>
        /// <param name="dtlRow"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// 2014/08/25 Delete by AnhNV - follow to design update
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private string ZaikosuCheck
        //    (
        //        DataGridViewRow dgvr,
        //        YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblRow hdrRow,
        //        YoshiHanbaiDtlTblDataSet.YoshiHanbaiDtlTblRow dtlRow
        //    )
        //{
        //    string rowErr = string.Empty;

        //    // バラ販売数(17)
        //    int hanbaiCnt = 0;
        //    // セット販売数(18)
        //    int setHanbaiCnt = 0;
        //    // セット部数(16)
        //    int setBusu = 0;

        //    // バラ販売数(17)
        //    hanbaiCnt = Convert.ToInt32(dgvr.Cells["HanbaiCnt"].Value.ToString());
        //    // セット販売数(18)
        //    setHanbaiCnt = Convert.ToInt32(dgvr.Cells["SetHanbaiCnt"].Value.ToString());
        //    // セット部数(16)
        //    setBusu = Convert.ToInt32(dgvr.Cells["SetBusuCol"].Value.ToString());
            
        //    // Get YoshiZaikoTbl by key
        //    IGetYoshiZaikoTblByKeyBLInput blInput = new GetYoshiZaikoTblByKeyBLInput();
        //    blInput.YoshiZaikoShishoCd = hdrRow.YoshiHanbaiShishoCd;
        //    blInput.YoshiZaikoYoshiCd = dtlRow.YoshiHanbaiYoshiCd;
        //    IGetYoshiZaikoTblByKeyBLOutput blOutput = new GetYoshiZaikoTblByKeyBusinessLogic().Execute(blInput);
            
        //    // (17) + (18) x (16) > 用紙在庫テーブルの在庫数量
        //    if (blOutput.YoshiZaikoTblDataTable.Count > 0 
        //        && hanbaiCnt + setHanbaiCnt * setBusu > blOutput.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo)
        //    {
        //        rowErr = dgvr.Index + 1 + ", ";
        //    }

        //    return rowErr;
        //}
        #endregion

        #region MakeMeisaiNo
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeMeisaiNo
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  AnhNV　　    新規作成
        /// 2014/10/16　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2014/10/17　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private int MakeMeisaiNo(IDecisionBtnClickALInput input)
        //{
        //    // 明細行番号
        //    int meisaiNo = 0;

        //    foreach (DataGridViewRow dgvr in input.UpdateData.YoshiListDgv.Rows)
        //    {
        //        // Skip empty 販売数(19) columns
        //        if (dgvr.Cells["HanbaiCntCol"].Value == null
        //            || string.IsNullOrEmpty(dgvr.Cells["HanbaiCnt"].Value.ToString()))
        //        {
        //            continue;
        //        }

        //        meisaiNo++;
        //    }

        //    return meisaiNo;
        //}
        #endregion

        #region ShoriSumiCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： ShoriSumiCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23  AnhNV　　    新規作成
        /// 2014/10/06  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private string ShoriSumiCheck(IDecisionBtnClickALInput input)
        //{
        //    string errMsg = string.Empty;

        //    YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblRow row = input.UpdateData.YoshiHanbaiHdrTblDataTable[0];

        //    // 処理済チェック(更新)
        //    if (row.IsYoshiHanbaiGenkinNyukingakuNull() || row.YoshiHanbaiGenkinNyukingaku != 0
        //        || row.IsYoshiHanbaiSeikyuKingakuNull() || row.YoshiHanbaiSeikyuKingaku != 0
        //        || row.IsYoshiHanbaiKansaiFlgNull() || row.YoshiHanbaiKansaiFlg != "0"
        //        || row.IsYoshiHanbaiSeikyushoHakkoFlgNull() || row.YoshiHanbaiSeikyushoHakkoFlg != "0"
        //        || row.IsYoshiHanbaiNohinshoHakkoFlgNull() || row.YoshiHanbaiNohinshoHakkoFlg != "0"
        //        || row.IsYoshiHanbaiHassoFlgNull() || row.YoshiHanbaiHassoFlg != "0")
        //    {
        //        errMsg = "既に処理済のため、更新/削除できません。";
        //    }

        //    return errMsg;
        //}
        #endregion

        #region MakeGokeiSuryoTotal
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： MakeGokeiSuryoTotal
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/30  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private int MakeGokeiSuryoTotal(IDecisionBtnClickALInput input)
        //{
        //    // 販売合計数量
        //    int gokeiSuryo = 0;

        //    foreach (DataGridViewRow dgvr in input.UpdateData.YoshiListDgv.Rows)
        //    {
        //        // Skip empty columns 販売数量(17) and 販売セット数量(18)
        //        if (dgvr.Cells["HanbaiCnt"].Value == null
        //            || string.IsNullOrEmpty(dgvr.Cells["HanbaiCnt"].Value.ToString())
        //            || dgvr.Cells["SetHanbaiCnt"].Value == null
        //            || string.IsNullOrEmpty(dgvr.Cells["SetHanbaiCnt"].Value.ToString()))
        //        {
        //            continue;
        //        }

        //        // 販売合計数量 = 17 + 18 * 16
        //        gokeiSuryo += Convert.ToInt32(dgvr.Cells["HanbaiCnt"].Value != null ? dgvr.Cells["HanbaiCnt"].Value.ToString() : "0")
        //                        + Convert.ToInt32(dgvr.Cells["SetHanbaiCnt"].Value != null ? dgvr.Cells["SetHanbaiCnt"].Value.ToString() : "0")
        //                        * Convert.ToInt32(dgvr.Cells["SetBusuCol"].Value != null ? dgvr.Cells["SetBusuCol"].Value.ToString() : "0");
        //    }

        //    return gokeiSuryo;
        //}
        #endregion

        #region KaiinCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： KaiinCheck
        /// <summary>
        /// 
        /// </summary>
        /// <returns>
        /// TRUE: 会員
        /// FALSE: 非会員
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/26  AnhNV　　    新規作成
        /// 2014/10/06  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private bool KaiinCheck()
        //{
        //    bool result = false;

        //    // Get GyoshaBukaiMst info
        //    IGetGyoshaBukaiMstInfoBLOutput bukaiOutp = new GetGyoshaBukaiMstInfoBusinessLogic().Execute(new GetGyoshaBukaiMstInfoBLInput());
        //    int totalRowCnt = bukaiOutp.GyoshaBukaiMstDataTable.Count;
        //    GyoshaBukaiMstDataSet.GyoshaBukaiMstRow[] notEmptyNyukai =
        //        (GyoshaBukaiMstDataSet.GyoshaBukaiMstRow[])bukaiOutp.GyoshaBukaiMstDataTable.Select(" isnull(BukaiNyukaiDt,'') <> '' and isnull(BukaiTaikaiDt,'') = '' ");
        //    //GyoshaBukaiMstDataSet.GyoshaBukaiMstRow[] emptyNyukai =
        //    //    (GyoshaBukaiMstDataSet.GyoshaBukaiMstRow[])bukaiOutp.GyoshaBukaiMstDataTable.Select(" isnull(BukaiNyukaiDt,'') = '' and isnull(BukaiTaikaiDt,'') <> '' ");

        //    if (notEmptyNyukai.Length > 0)
        //    {
        //        result = true;
        //    }
        //    //else if (emptyNyukai.Length == totalRowCnt)
        //    //{
        //    //    result = false;
        //    //}

        //    return result;
        //}
        #endregion

        #region CreateYoshiHanbaiHdrInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateYoshiHanbaiHdrInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="totalHanbaiGaku"></param>
        /// <param name="totalShohizei"></param>
        /// <param name="totalGokeiKingaku"></param>
        /// <param name="seikyuKingaku"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// 2014/10/06  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2014/10/16　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2015/01/28　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateYoshiHanbaiHdrInsert
            (
                IDecisionBtnClickALInput input,
                YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable table,
                //Dictionary<string, decimal> dictData
                decimal totalHanbaiGaku,
                decimal totalShohizei,
                decimal totalGokeiKingaku,
                decimal seikyuKingaku
            )
        {
            YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblRow newRow = table.NewYoshiHanbaiHdrTblRow();

            // 注文番号
            newRow.YoshiHanbaiChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
            // 支所コード
            newRow.YoshiHanbaiShishoCd = input.UpdateData.YoshiHanbaiShishoCd;
            // 販売日
            newRow.YoshiHanbaiDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
            // 販売先業者コード
            newRow.YoshiHanbaisakiGyoshaCd = input.UpdateData.YoshiHanbaisakiGyoshaCd;
            // 販売先担当者
            newRow.YoshiHanbaisakiTantosha = input.UpdateData.YoshiHanbaisakiTantosha;
            // 販売金額
            newRow.YoshiHanbaiGaku = totalHanbaiGaku;
            // 消費税合計
            newRow.YoshiHanbaiShohizei = totalShohizei;
            // 送料
            newRow.YoshiHanbaiSoryo = input.UpdateData.YoshiHanbaiSoryo;
            // 販売合計金額
            newRow.YoshiHanbaiGokeiKingaku = totalGokeiKingaku;
            // 請求金額
            newRow.YoshiHanbaiSeikyuKingaku = seikyuKingaku;
            // 現金入金額
            newRow.YoshiHanbaiGenkinNyukingaku = input.UpdateData.GenkinNyukinCheck ? 1 : 0m;
            // 完済フラグ 
            newRow.YoshiHanbaiKansaiFlg = Utility.Constants.FLG_OFF;
            // 請求書発行フラグ
            newRow.YoshiHanbaiSeikyushoHakkoFlg = Utility.Constants.FLG_OFF;
            // 納品書発行フラグ
            newRow.YoshiHanbaiNohinshoHakkoFlg = Utility.Constants.FLG_OFF;
            // 発送フラグ
            newRow.YoshiHanbaiHassoFlg = string.Empty;
            // 発送日付
            newRow.YoshiHanbaiHassoDt = input.UpdateData.Now.ToString("yyyyMMdd");
            // 登録日時
            newRow.InsertDt = input.UpdateData.Now;
            // 登録者
            newRow.InsertUser = this.UpdateUser;
            // 登録端末
            newRow.InsertTarm = this.UpdateTarm;
            // 更新日時
            newRow.UpdateDt = input.UpdateData.Now;
            // 更新者
            newRow.UpdateUser = this.UpdateUser;
            // 更新端末
            newRow.UpdateTarm = this.UpdateTarm;

            // 行を挿入
            table.AddYoshiHanbaiHdrTblRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();
        }
        #endregion

        #region CreateYoshiHanbaiHdrUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateYoshiHanbaiHdrUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="totalHanbaiGaku"></param>
        /// <param name="totalShohizei"></param>
        /// <param name="totalHanbaiKakaku"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/07  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2014/10/17　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2015/01/29　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable CreateYoshiHanbaiHdrUpdate
        (
            IDecisionBtnClickALInput input,
            //Dictionary<string, decimal> dictData
            decimal totalHanbaiGaku,
            decimal totalShohizei,
            decimal totalHanbaiKakaku
        )
        {
            YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable table = new YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable();

            // Get YoshiHanbaiHdrTbl by key
            IGetYoshiHanbaiHdrTblByKeyBLInput hdrInput = new GetYoshiHanbaiHdrTblByKeyBLInput();
            hdrInput.YoshiHanbaiChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
            IGetYoshiHanbaiHdrTblByKeyBLOutput hdrOutput = new GetYoshiHanbaiHdrTblByKeyBusinessLogic().Execute(hdrInput);

            if (hdrOutput.YoshiHanbaiHdrTblDataTable.Count > 0)
            {
                table = hdrOutput.YoshiHanbaiHdrTblDataTable;

                // Optimistic locking check
                if (table[0].UpdateDt != input.UpdateData.YoshiHeaderDataTable[0].UpdateDt)
                {
                    throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                }

                // 販売先担当者
                table[0].YoshiHanbaisakiTantosha = input.UpdateData.YoshiHanbaisakiTantosha;
                // 販売日
                table[0].YoshiHanbaiDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
                // 販売金額
                table[0].YoshiHanbaiGaku = totalHanbaiGaku;
                // 消費税合計
                table[0].YoshiHanbaiShohizei = totalShohizei;
                // 送料
                table[0].YoshiHanbaiSoryo = input.UpdateData.YoshiHanbaiSoryo;
                // 販売合計金額
                table[0].YoshiHanbaiGokeiKingaku = totalHanbaiKakaku;
                //table[0].YoshiHanbaiGokeiKingaku = dictData[GOKEI_KINGAKU] + dictData[GOKEI_KINGAKU_HOSHOU] + input.UpdateData.YoshiHanbaiSoryo;
                //table[0].YoshiHanbaiGokeiKingaku = dictData[GOKEI_KINGAKU] + dictData[GOKEI_KINGAKU_HOSHOU];
                // TODO 現金入金の場合は、追って見直しが必要
                // 現金入金額
                table[0].YoshiHanbaiGenkinNyukingaku = input.UpdateData.GenkinNyukinCheck ? totalHanbaiKakaku : 0;
                // 完済フラグ
                table[0].YoshiHanbaiKansaiFlg = input.UpdateData.GenkinNyukinCheck ? Utility.Constants.FLG_ON : Utility.Constants.FLG_OFF;
                // 更新日
                table[0].UpdateDt = input.UpdateData.Now;
                // 更新者
                table[0].UpdateUser = UpdateUser;
                // 更新端末
                table[0].UpdateTarm = UpdateTarm;
            }

            return table;
        }
        #endregion

        #region CreateYoshiHanbaiDtlInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateYoshiHanbaiDtlInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="detailRow"></param>
        /// <param name="table"></param>
        /// <param name="outDtlRow"></param>
        /// <returns>
        /// 
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// 2014/10/06  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2014/10/17　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2015/01/28　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateYoshiHanbaiDtlInsert
            (
                IDecisionBtnClickALInput input,
                TyumonShosaiDataSet.YoshiDetailRow detailRow,
                YoshiHanbaiDtlTblDataSet.YoshiHanbaiDtlTblDataTable table,
                out YoshiHanbaiDtlTblDataSet.YoshiHanbaiDtlTblRow outDtlRow
            )
        {
            // Create a new row
            YoshiHanbaiDtlTblDataSet.YoshiHanbaiDtlTblRow newRow = table.NewYoshiHanbaiDtlTblRow();

            // 注文番号
            newRow.YoshiHanbaiChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
            // 販売用紙コード
            newRow.YoshiHanbaiYoshiCd = detailRow.YoshiCd;
            // 販売数量
            newRow.YoshiHanbaiSuryo = detailRow.IsYoshiSetBusuNull() ? detailRow.HanbaiCntCol : 0;
            // 販売単価
            newRow.YoshiHanbaiUp = detailRow.IsYoshiSetBusuNull() ? (input.UpdateData.KaiinFlg == "1" ? detailRow.KaiinTankaCol : detailRow.HiKaiinTankaCol) : 0;
            // 販売セット数量
            newRow.YoshiHanbaiSetSuryo = detailRow.IsYoshiSetBusuNull() ? detailRow.HanbaiCntCol : 0;
            // 販売セット価格
            newRow.YoshiHanbaiSetKakaku = detailRow.IsYoshiSetBusuNull() ? (input.UpdateData.KaiinFlg == "1" ? detailRow.KaiinTankaCol : detailRow.HiKaiinTankaCol) : 0;
            // 販売額 
            newRow.YoshiHanbaiGaku = detailRow.HanbaiKakakuCol;
            // 消費税額 
            newRow.YoshiHanbaiShohizei = detailRow.IsSyohizeiColNull() ? 0 : detailRow.SyohizeiCol;
            // 販売金額計
            newRow.YoshiHanbaiKakaku = detailRow.HanbaiKakakuCol + detailRow.SyohizeiCol;
            // 販売合計数量
            newRow.YoshiHanbaiGokeiSuryo = detailRow.IsYoshiSetBusuNull() ? detailRow.HanbaiCntCol : detailRow.YoshiSetBusu * detailRow.HanbaiCntCol;
            // 登録日
            newRow.InsertDt = input.UpdateData.Now;
            // 登録者
            newRow.InsertUser = this.UpdateUser;
            // 登録端末
            newRow.InsertTarm = this.UpdateTarm;
            // 更新日
            newRow.UpdateDt = input.UpdateData.Now;
            // 更新者
            newRow.UpdateUser = this.UpdateUser;
            // 更新端末
            newRow.UpdateTarm = this.UpdateTarm;

            outDtlRow = newRow;

            // 行を挿入
            table.AddYoshiHanbaiDtlTblRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();

            // 2015.01.28 AnhNV DEL Start
            #region
            //// 注文番号
            //newRow.YoshiHanbaiChumonNo = input.UpdateData.YoshiHanbaiChumonNo;

            //// 販売用紙コード
            //newRow.YoshiHanbaiYoshiCd = dgvr.Cells["YoshiCdCol"].Value.ToString();

            //#region to be removed
            //// 明細行番号
            ////newRow.YoshiHanbaiMeisaiGyoNo = meisaiNo;

            //// 販売数量(17)
            ////newRow.YoshiHanbaiSuryo = Convert.ToInt32(dgvr.Cells["HanbaiCnt"].Value == null || dgvr.Cells["HanbaiCnt"].Value.ToString() == string.Empty
            ////    ? "0" : dgvr.Cells["HanbaiCnt"].Value.ToString());

            ////// 販売単価
            //////newRow.YoshiHanbaiUp = input.UpdateData.KaiinKbn == "0"
            //////    ? Convert.ToDecimal(dgvr.Cells["HiKaiinTankaCol"].Value == null || dgvr.Cells["HiKaiinTankaCol"].Value.ToString() == string.Empty ? "0" : dgvr.Cells["HiKaiinTankaCol"].Value.ToString())
            //////    : Convert.ToDecimal(dgvr.Cells["KaiinTankaCol"].Value == null || dgvr.Cells["KaiinTankaCol"].Value.ToString() == string.Empty ? "0" : dgvr.Cells["KaiinTankaCol"].Value.ToString());

            ////// 販売単価
            ////newRow.YoshiHanbaiUp = !isKaiin
            ////    ? Convert.ToDecimal(dgvr.Cells["HiKaiinTankaCol"].Value == null || dgvr.Cells["HiKaiinTankaCol"].Value.ToString() == string.Empty ? "0" : dgvr.Cells["HiKaiinTankaCol"].Value.ToString())
            ////    : Convert.ToDecimal(dgvr.Cells["KaiinTankaCol"].Value == null || dgvr.Cells["KaiinTankaCol"].Value.ToString() == string.Empty ? "0" : dgvr.Cells["KaiinTankaCol"].Value.ToString());

            ////// 販売セット数量(18)
            ////newRow.YoshiHanbaiSetSuryo = Convert.ToInt32(dgvr.Cells["SetHanbaiCnt"].Value == null || dgvr.Cells["SetHanbaiCnt"].Value.ToString() == string.Empty 
            ////    ? "0" : dgvr.Cells["SetHanbaiCnt"].Value.ToString());

            ////// 販売セット価格
            //////newRow.YoshiHanbaiSetKakaku = input.UpdateData.KaiinKbn == "0"
            //////    ? Convert.ToDecimal(dgvr.Cells["HiKaiinSetKakakuCol"].Value == null || dgvr.Cells["HiKaiinSetKakakuCol"].Value.ToString() == string.Empty ? "0" : dgvr.Cells["HiKaiinSetKakakuCol"].Value.ToString())
            //////    : Convert.ToDecimal(dgvr.Cells["KaiinSetKakakuCol"].Value == null || dgvr.Cells["KaiinSetKakakuCol"].Value.ToString() == string.Empty ? "0" : dgvr.Cells["KaiinSetKakakuCol"].Value.ToString());

            ////// 販売セット価格
            ////newRow.YoshiHanbaiSetKakaku = !isKaiin
            ////    ? Convert.ToDecimal(dgvr.Cells["HiKaiinSetKakakuCol"].Value == null || dgvr.Cells["HiKaiinSetKakakuCol"].Value.ToString() == string.Empty ? "0" : dgvr.Cells["HiKaiinSetKakakuCol"].Value.ToString())
            ////    : Convert.ToDecimal(dgvr.Cells["KaiinSetKakakuCol"].Value == null || dgvr.Cells["KaiinSetKakakuCol"].Value.ToString() == string.Empty ? "0" : dgvr.Cells["KaiinSetKakakuCol"].Value.ToString());

            ////// 販売価格
            ////newRow.YoshiHanbaiKakaku = newRow.YoshiHanbaiSuryo * newRow.YoshiHanbaiUp
            ////    + newRow.YoshiHanbaiSetSuryo * newRow.YoshiHanbaiSetKakaku;

            ////// 販売合計数量
            ////newRow.YoshiHanbaiGokeiSuryo = newRow.YoshiHanbaiSuryo +
            ////    newRow.YoshiHanbaiSetSuryo * Convert.ToInt32(dgvr.Cells["SetBusuCol"].Value != null ? dgvr.Cells["SetBusuCol"].Value.ToString() : "0");

            ////受入20141222 mod (del&move) sta
            ////// セット部数(18) and 販売数(19) are not blank
            ////if (dgvr.Cells["SetBusuCol"].Value != null && dgvr.Cells["SetBusuCol"].Value.ToString() != string.Empty
            ////    && dgvr.Cells["HanbaiCntCol"].Value != null && dgvr.Cells["HanbaiCntCol"].Value.ToString() != string.Empty)
            ////{
            ////    // 販売数
            ////    newRow.YoshiHanbaiSuryo = Convert.ToInt32(dgvr.Cells["HanbaiCntCol"].Value);

            ////    // 販売セット数量
            ////    newRow.YoshiHanbaiSetSuryo = Convert.ToInt32(dgvr.Cells["HanbaiCntCol"].Value);
            ////}
            ////受入20141222 mod (del&move)  end
            //#endregion

            //// セット部数(18) is blank
            //if (dgvr.Cells["SetBusuCol"].Value == null || dgvr.Cells["SetBusuCol"].Value.ToString() == string.Empty)
            //{
            //    // 販売数    //受入20141222　セット部数が空白の場合、販売数をセット
            //    newRow.YoshiHanbaiSuryo = Convert.ToInt32(dgvr.Cells["HanbaiCntCol"].Value);

            //    if (input.UpdateData.KaiinFlg == "1"
            //        && dgvr.Cells["KaiinTankaCol"].Value != null
            //        && dgvr.Cells["KaiinTankaCol"].Value.ToString() != string.Empty)
            //    {
            //        // 販売単価
            //        newRow.YoshiHanbaiUp = Convert.ToDecimal(dgvr.Cells["KaiinTankaCol"].Value);
            //    }

            //    if (input.UpdateData.KaiinFlg == "0"
            //        && dgvr.Cells["HiKaiinTankaCol"].Value != null
            //        && dgvr.Cells["HiKaiinTankaCol"].Value.ToString() != string.Empty)
            //    {
            //        // 販売単価
            //        newRow.YoshiHanbaiUp = Convert.ToDecimal(dgvr.Cells["HiKaiinTankaCol"].Value);
            //    }

            //    // 販売セット数量
            //    newRow.YoshiHanbaiSetSuryo = 0;

            //    // 販売セット価格
            //    newRow.YoshiHanbaiSetKakaku = 0;

            //    if (dgvr.Cells["HanbaiCntCol"].Value != null && dgvr.Cells["HanbaiCntCol"].Value.ToString() != string.Empty)
            //    {
            //        // 販売合計数量 = 販売数(19)
            //        newRow.YoshiHanbaiGokeiSuryo = Convert.ToInt32(dgvr.Cells["HanbaiCntCol"].Value);
            //    }
            //}
            //else
            //{
            //    // 販売数量
            //    newRow.YoshiHanbaiSuryo = 0;

            //    // 販売単価
            //    newRow.YoshiHanbaiUp = 0;

            //    // 販売セット数量    //受入20141222　セット部数が空白ではない場合、販売数をセット
            //    newRow.YoshiHanbaiSetSuryo = Convert.ToInt32(dgvr.Cells["HanbaiCntCol"].Value);

            //    if (input.UpdateData.KaiinFlg == "1"
            //        && dgvr.Cells["KaiinTankaCol"].Value != null
            //        && dgvr.Cells["KaiinTankaCol"].Value.ToString() != string.Empty)
            //    {
            //        // 販売セット価格
            //        newRow.YoshiHanbaiSetKakaku = Convert.ToDecimal(dgvr.Cells["KaiinTankaCol"].Value);
            //    }

            //    if (input.UpdateData.KaiinFlg == "0"
            //        && dgvr.Cells["HiKaiinTankaCol"].Value != null
            //        && dgvr.Cells["HiKaiinTankaCol"].Value.ToString() != string.Empty)
            //    {
            //        // 販売セット価格
            //        newRow.YoshiHanbaiSetKakaku = Convert.ToDecimal(dgvr.Cells["HiKaiinTankaCol"].Value);
            //    }

            //    if (dgvr.Cells["HanbaiCntCol"].Value != null && dgvr.Cells["HanbaiCntCol"].Value.ToString() != string.Empty)
            //    {
            //        // 販売合計数量 = セット部数(18) * 販売数(19)
            //        newRow.YoshiHanbaiGokeiSuryo = Convert.ToInt32(dgvr.Cells["SetBusuCol"].Value) * Convert.ToInt32(dgvr.Cells["HanbaiCntCol"].Value);
            //    }
            //}

            //// 販売金額計
            //decimal yoshiHanbaiKakaku = 0;
            //// NULL check
            //bool hasYoshiHanbaiKakaku = false;

            //if (dgvr.Cells["HanbaiKakakuCol"].Value != null && dgvr.Cells["HanbaiKakakuCol"].Value.ToString() != string.Empty)
            //{
            //    // 販売額(20)
            //    newRow.YoshiHanbaiGaku = Convert.ToDecimal(dgvr.Cells["HanbaiKakakuCol"].Value);
            //    yoshiHanbaiKakaku += Convert.ToDecimal(dgvr.Cells["HanbaiKakakuCol"].Value);
            //    hasYoshiHanbaiKakaku = true;
            //}

            //if (dgvr.Cells["SyohizeiCol"].Value != null && dgvr.Cells["SyohizeiCol"].Value.ToString() != string.Empty)
            //{
            //    // 消費税額(21)
            //    newRow.YoshiHanbaiShohizei = Convert.ToDecimal(dgvr.Cells["SyohizeiCol"].Value);
            //    yoshiHanbaiKakaku += Convert.ToDecimal(dgvr.Cells["SyohizeiCol"].Value);
            //    hasYoshiHanbaiKakaku = true;
            //}

            //// Avoid inserting zero for NULL value
            //if (hasYoshiHanbaiKakaku)
            //{
            //    // 販売金額計
            //    newRow.YoshiHanbaiKakaku = yoshiHanbaiKakaku;
            //}

            //// 登録日時
            //newRow.InsertDt =

            //// 更新日時
            //newRow.UpdateDt = input.UpdateData.Now;

            //// 登録者
            //newRow.InsertUser =

            //// 更新者
            //newRow.UpdateUser = this.LoginUser;

            //// 登録端末
            //newRow.InsertTarm =

            //// 更新端末
            //newRow.UpdateTarm = this.HostName;

            //// 行を挿入
            //table.AddYoshiHanbaiDtlTblRow(newRow);

            //// 行の状態を設定
            //newRow.AcceptChanges();

            //// 行の状態を設定（新規）
            //newRow.SetAdded();
#endregion
            // 2015.01.28 AnhNV DEL End
        }
        #endregion

        #region CreateYoshiZaikoTblInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateYoshiZaikoTblInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="detailRow"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// 2015/01/28　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateYoshiZaikoTblInsert
            (
                IDecisionBtnClickALInput input,
                TyumonShosaiDataSet.YoshiDetailRow detailRow,
                YoshiZaikoTblDataSet.YoshiZaikoTblDataTable table
            )
        {
            IGetYoshiZaikoTblByKeyBLInput blInput = new GetYoshiZaikoTblByKeyBLInput();
            blInput.YoshiZaikoShishoCd = input.UpdateData.YoshiHanbaiShishoCd;
            //blInput.YoshiZaikoYoshiCd = dgvr.Cells["YoshiCdCol"].Value != null ? dgvr.Cells["YoshiCdCol"].Value.ToString() : string.Empty;
            blInput.YoshiZaikoYoshiCd = detailRow.YoshiCd;
            IGetYoshiZaikoTblByKeyBLOutput blOutput = new GetYoshiZaikoTblByKeyBusinessLogic().Execute(blInput);

            if (blOutput.YoshiZaikoTblDataTable.Count > 0)
            {
                // 在庫数量 = 在庫数量 - (17 + 18 * 16)
                //blOutput.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo = blOutput.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo - gokeiSuryo;
                // v1.10
                blOutput.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo = detailRow.ZaikoCntHideCol - 
                    (detailRow.IsYoshiSetBusuNull() ? detailRow.HanbaiCntCol : detailRow.YoshiSetBusu * detailRow.HanbaiCntCol);

                // 更新日
                blOutput.YoshiZaikoTblDataTable[0].UpdateDt = input.UpdateData.Now;

                // 更新者
                blOutput.YoshiZaikoTblDataTable[0].UpdateUser = this.UpdateUser;

                // 更新端末
                blOutput.YoshiZaikoTblDataTable[0].UpdateTarm = this.UpdateTarm;

                table.Merge(blOutput.YoshiZaikoTblDataTable);
            }
        }
        #endregion

        #region CreateYoshiZaikoTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateYoshiZaikoTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="detailRow"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22  AnhNV　　    新規作成
        /// 2015/01/29　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private YoshiZaikoTblDataSet.YoshiZaikoTblDataTable CreateYoshiZaikoTblUpdate
        (
            IDecisionBtnClickALInput input,
            //DataGridViewRow dgvr,
            //YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblRow hdrRow,
            TyumonShosaiDataSet.YoshiDetailRow detailRow
            //int gokeiSuryo,
            //int staticGokeiSuryo
        )
        {
            // Get 用紙在庫テーブル by key
            IGetYoshiZaikoTblByKeyBLInput blInput = new GetYoshiZaikoTblByKeyBLInput();
            blInput.YoshiZaikoShishoCd = input.UpdateData.YoshiHanbaiShishoCd;
            blInput.YoshiZaikoYoshiCd = detailRow.YoshiCd;
            IGetYoshiZaikoTblByKeyBLOutput blOutput = new GetYoshiZaikoTblByKeyBusinessLogic().Execute(blInput);

            if (blOutput.YoshiZaikoTblDataTable.Count > 0)
            {
                //// 在庫数量 = 在庫数量 － 明細の販売数量合計(17 + 18 * 16) ＋ 変更前の明細の販売数量合計(before edit)
                //blOutput.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo = blOutput.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo - gokeiSuryo + staticGokeiSuryo;
                // v1.10 ADD Start
                // 在庫数量 = (21) - (18) + (19)
                blOutput.YoshiZaikoTblDataTable[0].YoshiZaikoSuryo = detailRow.ZaikoCntHideCol - detailRow.HanbaiCntCol + detailRow.HanbaiCntHidenCol;
                // v1.10 ADD End
                // 更新日
                blOutput.YoshiZaikoTblDataTable[0].UpdateDt = input.UpdateData.Now;
                // 更新者
                blOutput.YoshiZaikoTblDataTable[0].UpdateUser = this.UpdateUser;
                // 更新端末
                blOutput.YoshiZaikoTblDataTable[0].UpdateTarm = this.UpdateTarm;
            }

            return blOutput.YoshiZaikoTblDataTable;
        }
        #endregion

        #region CreateHoshoTorokuTblInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHoshoTorokuTblInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="table"></param>
        /// <param name="akibanTable"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2015/01/28  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateHoshoTorokuTblInsert
            (
                IDecisionBtnClickALInput input,
                //YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblRow hdrRow,
                HoshoTorokuTblDataSet.HoshoTorokuTblDataTable table,
                TyumonShosaiDataSet.HoshoTorokuAkibanDataTable akibanTable
                //DateTime now,
                //string renban
            )
        {
            // 2015.01.28 AnhNV DEL Start
            //// Update keys
            //// 保証登録検査機関
            //string kensaKikan = input.UpdateData.HoshoTorokuNo.Substring(0, 4);
            //// 保証登録年度
            //int jYear = Convert.ToInt32(input.UpdateData.HoshoTorokuNo.Substring(4, 2));
            //string nendo = Utility.Utility.ConvertToSeireki(jYear);
            // 2015.01.28 AnhNV DEL End

            foreach (TyumonShosaiDataSet.HoshoTorokuAkibanRow row in akibanTable)
            {
                // Get HoshoTorokuTbl by key
                IGetHoshoTorokuTblByKeyBLInput hoshoInp = new GetHoshoTorokuTblByKeyBLInput();
                hoshoInp.HoshoTorokuKensakikan = row.HoshoTorokuKensakikan;
                hoshoInp.HoshoTorokuNendo = row.HoshoTorokuNendo;
                hoshoInp.HoshoTorokuRenban = row.HoshoTorokuRenban;
                IGetHoshoTorokuTblByKeyBLOutput hoshoOutp = new GetHoshoTorokuTblByKeyBusinessLogic().Execute(hoshoInp);

                if (hoshoOutp.HoshoTorokuTblDataTable.Count > 0)
                {
                    // 支所区分
                    hoshoOutp.HoshoTorokuTblDataTable[0].HoshoTorokuShishoKbn = input.UpdateData.YoshiHanbaiShishoCd;
                    // 売上日付
                    hoshoOutp.HoshoTorokuTblDataTable[0].HoshoTorokuUriageDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
                    // 販売先コード
                    hoshoOutp.HoshoTorokuTblDataTable[0].HoshoTorokuHanbaisakiCd = input.UpdateData.YoshiHanbaisakiGyoshaCd;
                    // 更新日
                    hoshoOutp.HoshoTorokuTblDataTable[0].UpdateDt = input.UpdateData.Now;
                    // 更新者
                    hoshoOutp.HoshoTorokuTblDataTable[0].UpdateUser = this.UpdateUser;
                    // 更新端末
                    hoshoOutp.HoshoTorokuTblDataTable[0].UpdateTarm = this.UpdateTarm;

                    // Merge to result
                    table.Merge(hoshoOutp.HoshoTorokuTblDataTable);
                }
            }

            // 2015.01.28 AnhNV DEL Start
            #region
            //// Get HoshoTorokuTbl by key
            //IGetHoshoTorokuTblByKeyBLInput hoshoInp = new GetHoshoTorokuTblByKeyBLInput();
            //hoshoInp.HoshoTorokuKensakikan = input.UpdateData.HoshoTorokuKensakikan;
            //hoshoInp.HoshoTorokuNendo = input.UpdateData.HoshoTorokuNendo;
            //hoshoInp.HoshoTorokuRenban = input.UpdateData.HoshoTorokuRenban;
            //IGetHoshoTorokuTblByKeyBLOutput hoshoOutp = new GetHoshoTorokuTblByKeyBusinessLogic().Execute(hoshoInp);
            //HoshoTorokuTblDataSet.HoshoTorokuTblDataTable table = hoshoOutp.HoshoTorokuTblDataTable;
            //DataRow[] hoshoDr = table.Select("HoshoTorokuShishoKbn = '' and HoshoTorokuUriageDt = '' and HoshoTorokuHanbaisakiCd = '' and HoshoTorokuDeleteFlg = '0'");

            //if (table.Count > 0 && hoshoDr.Length > 0)
            //{
            //    // 支所区分
            //    table[0].HoshoTorokuShishoKbn = hdrRow.YoshiHanbaiShishoCd;

            //    // 売上日付
            //    table[0].HoshoTorokuUriageDt = hdrRow.YoshiHanbaiDt;

            //    // 販売先コード
            //    table[0].HoshoTorokuHanbaisakiCd = hdrRow.YoshiHanbaisakiGyoshaCd;

            //    // 更新日
            //    table[0].UpdateDt = now;

            //    // 更新者
            //    table[0].UpdateUser = this.LoginUser;

            //    // 更新端末
            //    table[0].UpdateTarm = this.HostName;
            //}

            //return table;
            #endregion
            // 2015.01.28 AnhNV DEL End
        }
        #endregion

        #region CreateHoshoTorokuTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateHoshoTorokuTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="table"></param>
        /// <param name="akibanTable"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/07  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.06
        /// 2015/01/29  AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateHoshoTorokuTblUpdate
        (
            IDecisionBtnClickALInput input,
            HoshoTorokuTblDataSet.HoshoTorokuTblDataTable table,
            TyumonShosaiDataSet.HoshoTorokuAkibanDataTable akibanTable
        )
        {
            // Get 保証登録テーブル by 保証登録注文番号(ChumonNo)
            IGetHoshoTorokuTblByChumonNoBLInput httInput = new GetHoshoTorokuTblByChumonNoBLInput();
            httInput.HoshoTorokuChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
            IGetHoshoTorokuTblByChumonNoBLOutput httOutput = new GetHoshoTorokuTblByChumonNoBusinessLogic().Execute(httInput);
            int rowNum = httOutput.HoshoTorokuTblDataTable.Rows.Count;

            for (int i = 0; i < rowNum; i++)
            {
                // 支所区分
                httOutput.HoshoTorokuTblDataTable[i].HoshoTorokuShishoKbn = input.UpdateData.YoshiHanbaiShishoCd;
                // 売上日付
                httOutput.HoshoTorokuTblDataTable[i].HoshoTorokuUriageDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
                // 販売先コード
                httOutput.HoshoTorokuTblDataTable[i].HoshoTorokuHanbaisakiCd = input.UpdateData.YoshiHanbaisakiGyoshaCd;
                // 更新日
                httOutput.HoshoTorokuTblDataTable[i].UpdateDt = input.UpdateData.Now;
                // 更新者
                httOutput.HoshoTorokuTblDataTable[i].UpdateUser = this.UpdateUser;
                // 更新端末
                httOutput.HoshoTorokuTblDataTable[i].UpdateTarm = this.UpdateTarm;

                // Merge to result
                table.Merge(httOutput.HoshoTorokuTblDataTable);
            }

            foreach (TyumonShosaiDataSet.HoshoTorokuAkibanRow row in akibanTable)
            {
                // Get HoshoTorokuTbl by key
                IGetHoshoTorokuTblByKeyBLInput hoshoInp = new GetHoshoTorokuTblByKeyBLInput();
                hoshoInp.HoshoTorokuKensakikan = row.HoshoTorokuKensakikan;
                hoshoInp.HoshoTorokuNendo = row.HoshoTorokuNendo;
                hoshoInp.HoshoTorokuRenban = row.HoshoTorokuRenban;
                IGetHoshoTorokuTblByKeyBLOutput hoshoOutp = new GetHoshoTorokuTblByKeyBusinessLogic().Execute(hoshoInp);

                if (hoshoOutp.HoshoTorokuTblDataTable.Count > 0)
                {
                    // 支所区分
                    hoshoOutp.HoshoTorokuTblDataTable[0].HoshoTorokuShishoKbn = input.UpdateData.YoshiHanbaiShishoCd;
                    // 売上日付
                    hoshoOutp.HoshoTorokuTblDataTable[0].HoshoTorokuUriageDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
                    // 販売先コード
                    hoshoOutp.HoshoTorokuTblDataTable[0].HoshoTorokuHanbaisakiCd = input.UpdateData.YoshiHanbaisakiGyoshaCd;
                    // 保証登録注文番号
                    hoshoOutp.HoshoTorokuTblDataTable[0].HoshoTorokuChumonNo = input.UpdateData.YoshiHanbaiChumonNo;
                    // 更新日
                    hoshoOutp.HoshoTorokuTblDataTable[0].UpdateDt = input.UpdateData.Now;
                    // 更新者
                    hoshoOutp.HoshoTorokuTblDataTable[0].UpdateUser = this.UpdateUser;
                    // 更新端末
                    hoshoOutp.HoshoTorokuTblDataTable[0].UpdateTarm = this.UpdateTarm;

                    // Merge to result
                    table.Merge(hoshoOutp.HoshoTorokuTblDataTable);
                }
            }

            // 2015.01.29 AnhNV DEL Start
            #region
            //// Get HoshoTorokuTbl by HoshoTorokuShishoKbn, HoshoTorokuUriageDt, HoshoTorokuHanbaisakiCd (before edit)
            //IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput blInput = new GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLInput();
            //blInput.HoshoTorokuShishoKbn = input.UpdateData.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiShishoCd;
            //blInput.HoshoTorokuUriageDt = input.UpdateData.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaiDt;
            //blInput.HoshoTorokuHanbaisakiCd = input.UpdateData.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaisakiGyoshaCd;
            //IGetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBLOutput blOutput = new GetHoshoTorokuTblByShishoUriageDtHanbaisakiCdBusinessLogic().Execute(blInput);
            //HoshoTorokuTblDataSet.HoshoTorokuTblDataTable table = blOutput.HoshoTorokuTblDataTable;

            //for (int i = 0; i < table.Count; i++)
            //{
            //    // For checking optimistic lock
            //    string where = string.Format("HoshoTorokuKensakikan = '{0}' and HoshoTorokuNendo =  '{1}' and HoshoTorokuRenban = '{2}'",
            //        table[i].HoshoTorokuKensakikan,
            //        table[i].HoshoTorokuNendo,
            //        table[i].HoshoTorokuRenban);
            //    // Object before update
            //    HoshoTorokuTblDataSet.HoshoTorokuTblRow[] hoshoRow =
            //        (HoshoTorokuTblDataSet.HoshoTorokuTblRow[])input.UpdateData.HoshoTorokuTblDataTable.Select(where);

            //    // Optimistic lock
            //    if (table[i].UpdateDt != hoshoRow[0].UpdateDt)
            //    {
            //        throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            //    }

            //    // 支所区分
            //    table[i].HoshoTorokuShishoKbn = string.Empty;

            //    // 売上日付
            //    table[i].HoshoTorokuUriageDt = string.Empty;

            //    // 販売先コード
            //    table[i].HoshoTorokuHanbaisakiCd = string.Empty;

            //    // 更新日
            //    table[i].UpdateDt = input.UpdateData.Now;

            //    // 更新者
            //    table[i].UpdateUser = this.LoginUser;

            //    // 更新端末
            //    table[i].UpdateTarm = this.HostName;
            //}

            //return table;
            #endregion
            // 2015.01.29 AnhNV DEL End
        }
        #endregion

        #region CreateNyukinTblInsertWithoutHoshou
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNyukinTblInsertWithoutHoshou
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="table"></param>
        /// <param name="seikyuGaku"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateNyukinTblInsertWithoutHoshou
            (
                IDecisionBtnClickALInput input,
                NyukinTblDataSet.NyukinTblDataTable table,
                decimal seikyuGaku
                //Dictionary<string, decimal> dictData,
                //decimal yoshiHanbaiKakaku
            )
        {
            // Create a new row
            NyukinTblDataSet.NyukinTblRow newRow = table.NewNyukinTblRow();
            // 入金No
            newRow.NyukinNo = input.UpdateData.Nendo + Utility.Saiban.GetSaibanRenban(input.UpdateData.Nendo.ToString(), Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_07);
            // 支所コード
            newRow.NyukinShisyoCd = input.UpdateData.YoshiHanbaiShishoCd;
            // 入金日
            newRow.NyukinDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
            // 入金取扱日
            newRow.NyukinToriatukaiDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
            // 入金種別
            newRow.NyukinSyubetsu = "3";
            // 連携No
            newRow.NyukinRenkeiNo = input.UpdateData.YoshiHanbaiChumonNo;
            // 計量証明検査依頼年度
            newRow.KeiryoShomeiIraiNendo = string.Empty;
            // 計量証明支所コード
            newRow.KeiryoShomeiIraiSishoCd = string.Empty;
            // 計量証明依頼連番
            newRow.KeiryoShomeiIraiRenban = string.Empty;
            // 検査依頼法定区分
            newRow.KensaIraiHoteiKbn = string.Empty;
            // 検査依頼保健所コード
            newRow.KensaIraiHokenjoCd = string.Empty;
            // 検査依頼年度
            newRow.KensaIraiNendo = string.Empty;
            // 検査依頼連番
            newRow.KensaIraiRenban = string.Empty;
            // 入金方法
            newRow.NyukinHoho = "003";
            // 入金口座
            newRow.NyukinKoza = string.Empty;
            // 請求額
            newRow.SeikyuGaku = seikyuGaku;
            // 入金入力額
            newRow.NyukinGaku = seikyuGaku;
            // 手数料
            newRow.TesuryoGaku = 0;
            // 手数料内外区分
            newRow.TesuryoNaigaiKbn = "0";
            // 実入金額
            newRow.JitsuNyukinGaku = seikyuGaku;
            // 入金元区分
            newRow.NyukinmotoKbn = "1";
            // 業者コード
            newRow.NyukinGyosyaCd = input.UpdateData.YoshiHanbaisakiGyoshaCd;
            // 浄化槽保健所コード
            newRow.JokasoHokenjoCd = string.Empty;
            // 浄化槽台帳登録年度
            newRow.JokasoTorokuNendo = string.Empty;
            // 浄化槽台帳連番
            newRow.JokasoRenban = string.Empty;
            // 入金者名称
            newRow.NyukinsyaNm = input.UpdateData.GyoshaNm;
            // 割振り済フラグ
            newRow.WarifuriFlg = "1";
            // 割振り済金額
            newRow.WarifuriGaku = seikyuGaku;
            // 返金額合計
            newRow.HenkinGaku = 0;
            // 完済フラグ
            newRow.KansaiFlag = "0";
            // 次回繰り越し金
            newRow.JikaiKurikoshiKin = 0;
            // 繰り越し金
            newRow.KurikoshiKin = 0;
            // 登録日
            newRow.InsertDt = input.UpdateData.Now;
            // 登録者
            newRow.InsertUser = this.UpdateUser;
            // 登録端末
            newRow.InsertTarm = this.UpdateTarm;
            // 更新日
            newRow.UpdateDt = input.UpdateData.Now;
            // 更新者
            newRow.UpdateUser = this.UpdateUser;
            // 更新端末
            newRow.UpdateTarm = this.UpdateTarm;

            // 行を挿入
            table.AddNyukinTblRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();
        }
        #endregion

        #region CreateNyukinTblInsertWithHoshou
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNyukinTblInsertWithHoshou
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="table"></param>
        /// <param name="seikyuGaku"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/16　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateNyukinTblInsertWithHoshou
            (
                IDecisionBtnClickALInput input,
                NyukinTblDataSet.NyukinTblDataTable table,
                //decimal yoshiHanbaiKakakuTotal
                decimal seikyuGaku
            )
        {
            // Create a new row
            NyukinTblDataSet.NyukinTblRow newRow = table.NewNyukinTblRow();
            // 入金No
            newRow.NyukinNo = input.UpdateData.Nendo + Utility.Saiban.GetSaibanRenban(input.UpdateData.Nendo.ToString(), Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_07);
            // 支所コード
            newRow.NyukinShisyoCd = input.UpdateData.YoshiHanbaiShishoCd;
            // 入金日
            newRow.NyukinDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
            // 入金取扱日
            newRow.NyukinToriatukaiDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
            // 入金種別
            newRow.NyukinSyubetsu = "7";
            // 連携No
            newRow.NyukinRenkeiNo = input.UpdateData.YoshiHanbaiChumonNo;
            // 計量証明検査依頼年度
            newRow.KeiryoShomeiIraiNendo = string.Empty;
            // 計量証明支所コード
            newRow.KeiryoShomeiIraiSishoCd = string.Empty;
            // 計量証明依頼連番
            newRow.KeiryoShomeiIraiRenban = string.Empty;
            // 検査依頼法定区分
            newRow.KensaIraiHoteiKbn = string.Empty;
            // 検査依頼保健所コード
            newRow.KensaIraiHokenjoCd = string.Empty;
            // 検査依頼年度
            newRow.KensaIraiNendo = string.Empty;
            // 検査依頼連番
            newRow.KensaIraiRenban = string.Empty;
            // 入金方法
            newRow.NyukinHoho = "003";
            // 入金口座
            newRow.NyukinKoza = string.Empty;
            // 請求額
            newRow.SeikyuGaku = seikyuGaku;
            // 入金入力額
            newRow.NyukinGaku = seikyuGaku;
            // 手数料
            newRow.TesuryoGaku = 0;
            // 手数料内外区分
            newRow.TesuryoNaigaiKbn = "0";
            // 実入金額
            newRow.JitsuNyukinGaku = seikyuGaku;
            // 入金元区分
            newRow.NyukinmotoKbn = "1";
            // 業者コード
            newRow.NyukinGyosyaCd = input.UpdateData.YoshiHanbaisakiGyoshaCd;
            // 浄化槽保健所コード
            newRow.JokasoHokenjoCd = string.Empty;
            // 浄化槽台帳登録年度
            newRow.JokasoTorokuNendo = string.Empty;
            // 浄化槽台帳連番
            newRow.JokasoRenban = string.Empty;
            // 入金者名称
            newRow.NyukinsyaNm = input.UpdateData.GyoshaNm;
            // 割振り済フラグ
            newRow.WarifuriFlg = "1";
            // 割振り済金額
            newRow.WarifuriGaku = seikyuGaku;
            // 返金額合計
            newRow.HenkinGaku = 0;
            // 完済フラグ
            newRow.KansaiFlag = "0";
            // 次回繰り越し金
            newRow.JikaiKurikoshiKin = 0;
            // 繰り越し金
            newRow.KurikoshiKin = 0;
            // 登録日
            newRow.InsertDt = input.UpdateData.Now;
            // 登録者
            newRow.InsertUser = this.UpdateUser;
            // 登録端末
            newRow.InsertTarm = this.UpdateTarm;
            // 更新日
            newRow.UpdateDt = input.UpdateData.Now;
            // 更新者
            newRow.UpdateUser = this.UpdateUser;
            // 更新端末
            newRow.UpdateTarm = this.UpdateTarm;

            // 行を挿入
            table.AddNyukinTblRow(newRow);
            // 行の状態を設定
            newRow.AcceptChanges();
            // 行の状態を設定（新規）
            newRow.SetAdded();
        }
        #endregion

        #region GetDictData
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetDictData
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.08
        /// 2015/01/06　habu　　    保証登録は別個に集計する様に修正
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        //private Dictionary<string, decimal> GetDictData(IDecisionBtnClickALInput input)
        //{
        //    Dictionary<string, decimal> dict = new Dictionary<string, decimal>();

        //    // 販売合計金額などを集計する

        //    // 販売合計金額
        //    decimal gokeiKingaku = 0;
        //    // 販売金額(消費税除く)
        //    decimal yoshiHanbaiGaku = 0;
        //    // 消費税合計
        //    decimal yoshiHanbaiShohizei = 0;
        //    // 販売金額Col(22)
        //    decimal genkinNyukingaku = 0;
        //    // 20150106 habu Add
        //    decimal hoshouGokeiKingaku = 0;
        //    decimal hoshouHanbaiGaku = 0;
        //    decimal hoshouGenkinNyukingaku = 0;

        //    foreach (DataGridViewRow dgvr in input.UpdateData.YoshiListDgv.Rows)
        //    {
        //        bool isHoshouYoshi = dgvr.Cells["YoshiCdCol"].Value.ToString() == input.UpdateData.HosyoTorokuYoushiCd;

        //        // Skip empty 販売数(19) columns
        //        if (dgvr.Cells["HanbaiCntCol"].Value == null
        //            || string.IsNullOrEmpty(dgvr.Cells["HanbaiCntCol"].Value.ToString()))
        //        {
        //            continue;
        //        }

        //        if (dgvr.Cells["HanbaiKakakuCol"].Value != null && dgvr.Cells["HanbaiKakakuCol"].Value.ToString() != string.Empty)
        //        {
        //            if (!isHoshouYoshi)
        //            {
        //                yoshiHanbaiGaku += Convert.ToDecimal(dgvr.Cells["HanbaiKakakuCol"].Value);
        //                gokeiKingaku += Convert.ToDecimal(dgvr.Cells["HanbaiKakakuCol"].Value);
        //            }
        //            else
        //            {
        //                hoshouHanbaiGaku += Convert.ToDecimal(dgvr.Cells["HanbaiKakakuCol"].Value);
        //                hoshouGokeiKingaku += Convert.ToDecimal(dgvr.Cells["HanbaiKakakuCol"].Value);
        //            }
        //        }

        //        if (dgvr.Cells["SyohizeiCol"].Value != null && dgvr.Cells["SyohizeiCol"].Value.ToString() != string.Empty)
        //        {
        //            if (!isHoshouYoshi)
        //            {
        //                yoshiHanbaiShohizei += Convert.ToDecimal(dgvr.Cells["SyohizeiCol"].Value);
        //                gokeiKingaku += Convert.ToDecimal(dgvr.Cells["SyohizeiCol"].Value);
        //            }
        //            // 保証登録の場合は、消費税は発生しない
        //        }

        //        // 現金入金(30) is checked ON?
        //        if (input.UpdateData.GenkinNyukinCheck)
        //        {
        //            if (!isHoshouYoshi)
        //            {
        //                // Sum of 販売金額Col(22)
        //                genkinNyukingaku += Convert.ToDecimal(dgvr.Cells["HanbaiKingakuCol"].Value);
        //            }
        //            else
        //            {
        //                hoshouGenkinNyukingaku += Convert.ToDecimal(dgvr.Cells["HanbaiKingakuCol"].Value);
        //            }
        //        }
        //    }

        //    // Add to dict.
        //    dict.Add(GOKEI_KINGAKU, gokeiKingaku);
        //    dict.Add(HANBAI_GAKU, yoshiHanbaiGaku);
        //    dict.Add(SHOHIZEI, yoshiHanbaiShohizei);
        //    dict.Add(NYUKINGAKU, genkinNyukingaku);
        //    // 20150106 habu Add
        //    dict.Add(GOKEI_KINGAKU_HOSHOU, hoshouGokeiKingaku);
        //    dict.Add(HANBAI_GAKU_HOSHOU, hoshouHanbaiGaku);
        //    dict.Add(NYUKINGAKU_HOSHOU, hoshouGenkinNyukingaku);

        //    return dict;
        //}
        #endregion

        #region GetNyukinMode
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetNyukinMode
        /// <summary>
        /// 
        /// </summary>
        /// <param name="genkinNyukin">現金入金(8)</param>
        /// <param name="nyukinCheckRes">⑥入金存在チェックの取得結果</param>
        /// <param name="nyukinFlg">保証登録フラグ</param>
        /// <returns>
        /// 0: 処理なし
        /// 1: INSERT
        /// 2: UPDATE
        /// 3: DELETE
        /// </returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private int GetNyukinMode(bool genkinNyukin, bool nyukinCheckRes, bool nyukinFlg)
        {
            return genkinNyukin ? (nyukinCheckRes ? (nyukinFlg ? (int)NyukinMode.Update : (int)NyukinMode.Delete) : (nyukinFlg ? (int)NyukinMode.Insert : 0))
                  : (nyukinCheckRes ? (int)NyukinMode.Delete : 0);
        }
        #endregion

        #region CreateNyukinTblUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateNyukinTblUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="table"></param>
        /// <param name="seikyuGaku"></param>
        /// <param name="nyukinSyubetsu"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void CreateNyukinTblUpdate
        (
            IDecisionBtnClickALInput input,
            NyukinTblDataSet.NyukinTblDataTable table,
            decimal seikyuGaku,
            string nyukinSyubetsu
        )
        {
            // Get NyukinTbl by Syubetsu & RenkeiNo
            IGetNyukinTblBySyubetsuRenkeiNoBLInput blInput = new GetNyukinTblBySyubetsuRenkeiNoBLInput();
            blInput.NyukinSyubetsu = nyukinSyubetsu;
            blInput.NyukinRenkeiNo = input.UpdateData.YoshiHanbaiChumonNo;
            IGetNyukinTblBySyubetsuRenkeiNoBLOutput blOutput = new GetNyukinTblBySyubetsuRenkeiNoBusinessLogic().Execute(blInput);
            table = blOutput.NyukinTblDataTable;

            for (int i = 0; i < table.Count; i++)
            {
                // 入金日
                table[i].NyukinDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
                // 入金取扱日
                table[i].NyukinToriatukaiDt = input.UpdateData.YoshiHanbaiDt.ToString("yyyyMMdd");
                // 請求額
                table[i].SeikyuGaku = seikyuGaku;
                // 入金入力額
                table[i].NyukinGaku = seikyuGaku;
                // 実入金額
                table[i].JitsuNyukinGaku = seikyuGaku;
                // 更新日
                table[i].UpdateDt = input.UpdateData.Now;
                // 更新者
                table[i].UpdateUser = this.UpdateUser;
                // 更新端末
                table[i].UpdateTarm = this.UpdateTarm;
            }
        }
        #endregion

        #region DeleteNyukinTbl
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： DeleteNyukinTbl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <param name="nyukinSyubetsu"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/29　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void DeleteNyukinTbl(IDecisionBtnClickALInput input, string nyukinSyubetsu)
        {
            IDeleteNyukinTblBySyubetsuAndRenkeiNoBLInput ntDelInput = new DeleteNyukinTblBySyubetsuAndRenkeiNoBLInput();
            ntDelInput.NyukinSyubetsu = nyukinSyubetsu;
            ntDelInput.NyukinRenkeiNo = input.UpdateData.YoshiHanbaiChumonNo;
            new DeleteNyukinTblBySyubetsuAndRenkeiNoBusinessLogic().Execute(ntDelInput);
        }
        #endregion

        #endregion
    }
    #endregion
}
