using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.RyoshushoPrint;
using FukjBizSystem.Application.BusinessLogic.Master.ShishoMstShosai;
using FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.YoshiHanbaiKanri;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.BusinessLogic.Common;

namespace FukjBizSystem.Application.ApplicationLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput, IGetYoshiHanbaiHdrTblByKeyBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 注文番号
        /// </summary>
        public string YoshiHanbaiChumonNo { get; set; }

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
    //  インターフェイス名 ： IFormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　AnhNV　　    新規作成
    /// 2014/10/06　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.06
    /// 2015/01/26　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.10
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        ///// <summary>
        ///// 用紙販売ヘッダテーブル
        ///// </summary>
        //YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable YoshiHanbaiHdrTblDataTable { get; set; }

        /// <summary>
        /// 支所マスタ
        /// </summary>
        ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable ShishoMstExceptJimukyokuDataTable { get; set; }

        /// <summary>
        /// 職員マスタ
        /// </summary>
        ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }

        /// <summary>
        /// YoshiHeaderDataTable
        /// </summary>
        TyumonShosaiDataSet.YoshiHeaderDataTable YoshiHeaderDataTable { get; set; }

        /// <summary>
        /// YoshiDetailDataTable
        /// </summary>
        TyumonShosaiDataSet.YoshiDetailDataTable YoshiDetailDataTable { get; set; }

        /// <summary>
        /// 保証登録販売フラグ
        /// </summary>
        bool HoshoTorokuHanbaiFlg { get; set; }

        /// <summary>
        /// 保証登録用紙コード
        /// </summary>
        string HoshoTorokuYoshiCd { get; set; }

        /// <summary>
        /// 保証登録番号From
        /// </summary>
        string HoshoTorokuNoFrom { get; set; }

        /// <summary>
        /// 保証登録番号To
        /// </summary>
        string HoshoTorokuNoTo { get; set; }

        ///// <summary>
        ///// 業者マスタ
        ///// </summary>
        //GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDataTable { get; set; }

        ///// <summary>
        ///// 業者部会マスタ
        ///// </summary>
        //GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable GyoshaBukaiMstDataTable { get; set; }

        ///// <summary>
        ///// 用紙在庫テーブル
        ///// </summary>
        //YoshiZaikoTblDataSet.YoshiZaikoTblDataTable YoshiZaikoTblDataTable { get; set; }

        ///// <summary>
        ///// 保証登録テーブル
        ///// </summary>
        //HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }

        ///// <summary>
        ///// TyumonShosaiDataTable
        ///// </summary>
        //YoshiHanbaiHdrTblDataSet.TyumonShosaiDataTable TyumonShosaiDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　AnhNV　　    新規作成
    /// 2014/10/06　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.06
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        ///// <summary>
        ///// 用紙販売ヘッダテーブル
        ///// </summary>
        //public YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblDataTable YoshiHanbaiHdrTblDataTable { get; set; }

        /// <summary>
        /// 支所マスタ
        /// </summary>
        public ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable ShishoMstExceptJimukyokuDataTable { get; set; }

        /// <summary>
        /// 職員マスタ
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }

        /// <summary>
        /// YoshiHeaderDataTable
        /// </summary>
        public TyumonShosaiDataSet.YoshiHeaderDataTable YoshiHeaderDataTable { get; set; }

        /// <summary>
        /// YoshiDetailDataTable
        /// </summary>
        public TyumonShosaiDataSet.YoshiDetailDataTable YoshiDetailDataTable { get; set; }

        /// <summary>
        /// 保証登録販売フラグ
        /// </summary>
        public bool HoshoTorokuHanbaiFlg { get; set; }

        /// <summary>
        /// 保証登録用紙コード
        /// </summary>
        public string HoshoTorokuYoshiCd { get; set; }

        /// <summary>
        /// 保証登録番号From
        /// </summary>
        public string HoshoTorokuNoFrom { get; set; }

        /// <summary>
        /// 保証登録番号To
        /// </summary>
        public string HoshoTorokuNoTo { get; set; }

        ///// <summary>
        ///// 業者マスタ
        ///// </summary>
        //public GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDataTable { get; set; }

        ///// <summary>
        ///// 業者部会マスタ
        ///// </summary>
        //public GyoshaBukaiMstDataSet.GyoshaBukaiMstDataTable GyoshaBukaiMstDataTable { get; set; }

        ///// <summary>
        ///// 用紙在庫テーブル
        ///// </summary>
        //public YoshiZaikoTblDataSet.YoshiZaikoTblDataTable YoshiZaikoTblDataTable { get; set; }

        ///// <summary>
        ///// 保証登録テーブル
        ///// </summary>
        //public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }

        ///// <summary>
        ///// TyumonShosaiDataTable
        ///// </summary>
        //public YoshiHanbaiHdrTblDataSet.TyumonShosaiDataTable TyumonShosaiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21　AnhNV　　    新規作成
    /// 2014/10/06　AnhNV　　  基本設計書_003_005_画面_TyumonSyosai_V1.06
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TyumonShosai：FormLoad";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FormLoadApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FormLoadApplicationLogic()
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
        /// 2014/07/21　AnhNV　　    新規作成
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
        /// 2014/07/21　AnhNV　　    新規作成
        /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // Get 保証登録用紙コード
                string hoshoTorokuYoshiCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_001, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                output.HoshoTorokuYoshiCd = hoshoTorokuYoshiCd;

                // Get 支所マスタ info
                IGetShishoMstExceptJimukyokuBLOutput shishoOutp = new GetShishoMstExceptJimukyokuBusinessLogic().Execute(new GetShishoMstExceptJimukyokuBLInput());
                output.ShishoMstExceptJimukyokuDataTable = shishoOutp.ShishoMstExceptJimukyokuDT;

                // Get 職員マスタ info
                // 2015/01/28 DatNT MOD Start
                //IGetShokuinMstInfoBLOutput shokuinOutput = new GetShokuinMstInfoBusinessLogic().Execute(new GetShokuinMstInfoBLInput());
                //output.ShokuinMstDataTable = shokuinOutput.ShokuinMstDataTable;
                IGetShokuinMstByShokuinTaishokuFlgBLInput shokuinInput = new GetShokuinMstByShokuinTaishokuFlgBLInput();
                shokuinInput.ShokuinTaishokuFlg = "0";
                output.ShokuinMstDataTable = new IGetShokuinMstByShokuinTaishokuFlgBusinessLogic().Execute(shokuinInput).ShokuinMstDT;
                // 2015/01/28 DatNT MOD End

                // Get detail info
                IGetYoshiDetailByShishoCdChumonNoBLInput ydInput = new GetYoshiDetailByShishoCdChumonNoBLInput();
                // Detail for add mode
                ydInput.YoshiHanbaiShishoCd = string.Empty;
                ydInput.YoshiHanbaiChumonNo = string.Empty;

                if (!string.IsNullOrEmpty(input.YoshiHanbaiChumonNo))
                {
                    // Get header info
                    IGetYoshiHeaderByChumonNoBLInput yhInput = new GetYoshiHeaderByChumonNoBLInput();
                    yhInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                    IGetYoshiHeaderByChumonNoBLOutput yhOutput = new GetYoshiHeaderByChumonNoBusinessLogic().Execute(yhInput);
                    output.YoshiHeaderDataTable = yhOutput.YoshiHeaderDataTable;

                    // Detail for update mode
                    ydInput.YoshiHanbaiShishoCd = yhOutput.YoshiHeaderDataTable[0].YoshiHanbaiShishoCd;
                    ydInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                }

                IGetYoshiDetailByShishoCdChumonNoBLOutput ydOutput = new GetYoshiDetailByShishoCdChumonNoBusinessLogic().Execute(ydInput);
                output.YoshiDetailDataTable = ydOutput.YoshiDetailDataTable;

                // 保証登録販売フラグ
                bool hoshoTorokuHanbaiFlg = false;
                // Set 保証登録フラグ(隠し) (20)
                foreach (TyumonShosaiDataSet.YoshiDetailRow row in ydOutput.YoshiDetailDataTable)
                {
                    if (!string.IsNullOrEmpty(input.YoshiHanbaiChumonNo))
                    {
                        SetTorokuFlgHidden(row, hoshoTorokuYoshiCd, out hoshoTorokuHanbaiFlg);
                    }
                    else
                    {
                        SetTorokuFlgHidden(row, hoshoTorokuYoshiCd);
                    }
                }

                output.HoshoTorokuHanbaiFlg = hoshoTorokuHanbaiFlg;

                // Get 保証登録番号From, 保証登録番号To
                if (hoshoTorokuHanbaiFlg)
                {
                    IGetHoshoTorokuAkibanByCondBLInput htaInput = new GetHoshoTorokuAkibanByCondBLInput();
                    htaInput.SearchCond = new HoshoTorokuAkibanSearchCond();
                    htaInput.SearchCond.AkibanMode = AkibanMode.Display;
                    htaInput.SearchCond.HoshoTorokuChumonNo = input.YoshiHanbaiChumonNo;
                    IGetHoshoTorokuAkibanByCondBLOutput htaOutput = new GetHoshoTorokuAkibanByCondBusinessLogic().Execute(htaInput);

                    if (htaOutput.HoshoTorokuAkibanDataTable.Rows.Count > 0)
                    {
                        output.HoshoTorokuNoFrom = htaOutput.HoshoTorokuAkibanDataTable[0].HoshoTorokuNo;
                        output.HoshoTorokuNoTo = htaOutput.HoshoTorokuAkibanDataTable[htaOutput.HoshoTorokuAkibanDataTable.Rows.Count - 1].HoshoTorokuNo;
                    }
                }

                #region comment
                //// Get 用紙在庫テーブル info
                //IGetYoshiZaikoTblInfoBLOutput zaikoOutp = new GetYoshiZaikoTblInfoBusinessLogic().Execute(new GetYoshiZaikoTblInfoBLInput());
                //output.YoshiZaikoTblDataTable = zaikoOutp.YoshiZaikoTblDT;

                //// Get 保証登録テーブル info
                //IGetHoshoTorokuTblInfoBLOutput hoshoOutput = new GetHoshoTorokuTblInfoBusinessLogic().Execute(new GetHoshoTorokuTblInfoBLInput());
                //output.HoshoTorokuTblDataTable = hoshoOutput.HoshoTorokuTblDataTable;

                //// Get TyumonShosaiDataTable
                //IGetTyumonShosaiBLInput blInput = new GetTyumonShosaiBLInput();
                //blInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                //IGetTyumonShosaiBLOutput blOutput = new GetTyumonShosaiBusinessLogic().Execute(blInput);
                //output.TyumonShosaiDataTable = blOutput.TyumonShosaiDataTable;

                //// Get data from yoshiHanbaiHdr and GyoshaMst by ChumonNo
                //if (!string.IsNullOrEmpty(input.YoshiHanbaiChumonNo))
                //{
                //    // Get 用紙販売ヘッダテーブル by key (for update)
                //    IGetYoshiHanbaiHdrTblByKeyBLInput hdrInput = new GetYoshiHanbaiHdrTblByKeyBLInput();
                //    hdrInput.YoshiHanbaiChumonNo = input.YoshiHanbaiChumonNo;
                //    IGetYoshiHanbaiHdrTblByKeyBLOutput hdrOutput = new GetYoshiHanbaiHdrTblByKeyBusinessLogic().Execute(hdrInput);
                //    output.YoshiHanbaiHdrTblDataTable = hdrOutput.YoshiHanbaiHdrTblDataTable;

                //    // Get 業者マスタ by key
                //    IGetGyoshaMstByKeyBLInput gyoshaInput = new GetGyoshaMstByKeyBLInput();
                //    gyoshaInput.GyoshaCd = hdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaisakiGyoshaCd;
                //    IGetGyoshaMstByKeyBLOutput gyoshaOutput = new GetGyoshaMstByKeyBusinessLogic().Execute(gyoshaInput);
                //    output.GyoshaMstDataTable = gyoshaOutput.GyoshaMstDataTable;

                //    // Get 業者部会マスタ by GyoshaCd
                //    IGetGyoshaBukaiMstByGyoshaCdBLInput bukaiInput = new GetGyoshaBukaiMstByGyoshaCdBLInput();
                //    bukaiInput.GyoshaCd = hdrOutput.YoshiHanbaiHdrTblDataTable[0].YoshiHanbaisakiGyoshaCd;
                //    IGetGyoshaBukaiMstByGyoshaCdBLOutput bukaiOutput = new GetGyoshaBukaiMstByGyoshaCdBusinessLogic().Execute(bukaiInput);
                //    output.GyoshaBukaiMstDataTable = bukaiOutput.GyoshaBukaiMstDataTable;
                //}
                #endregion
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

        #region SetTorokuFlgHidden
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetTorokuFlgHidden
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="hoshoTorokuYoshiCd"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetTorokuFlgHidden(TyumonShosaiDataSet.YoshiDetailRow row, string hoshoTorokuYoshiCd)
        {
            if (row.YoshiCd == hoshoTorokuYoshiCd)
            {
                row.HoshoTorokuFlgHideCol = "1";
            }
        }
        #endregion

        #region SetTorokuFlgHidden
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetTorokuFlgHidden
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="hoshoTorokuYoshiCd"></param>
        /// <param name="hoshoTorokuHanbaiFlg"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/26　AnhNV　　    基本設計書_003_005_画面_TyumonSyosai_V1.10
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void SetTorokuFlgHidden(TyumonShosaiDataSet.YoshiDetailRow row, string hoshoTorokuYoshiCd, out bool hoshoTorokuHanbaiFlg)
        {
            hoshoTorokuHanbaiFlg = false;

            if (row.YoshiCd == hoshoTorokuYoshiCd)
            {
                row.HoshoTorokuFlgHideCol = "1";
                hoshoTorokuHanbaiFlg = true;
            }
        }
        #endregion

        #endregion
    }
    #endregion
}
