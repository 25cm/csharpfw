using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoShinseiShosai
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
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput, IGetHoshoTorokuTblByKeyBLInput
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
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 保証登録検査機関
        /// </summary>
        public string HoshoTorokuKensakikan { get; set; }

        /// <summary>
        /// 保証登録年度
        /// </summary>
        public string HoshoTorokuNendo { get; set; }

        /// <summary>
        /// 保証登録連番
        /// </summary>
        public string HoshoTorokuRenban { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("保証登録検査機関[{0}], 保証登録年度[{1}], 保証登録連番[{2}]",
                    new string[] { HoshoTorokuKensakikan, HoshoTorokuNendo, HoshoTorokuRenban });
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
    /// 2014/07/17　AnhNV　　    新規作成
    /// 2015/01/20　AnhNV　　    v1.03
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// 保証登録テーブル
        /// </summary>
        HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }

        /// <summary>
        /// 浄化槽マスタ
        /// </summary>
        JokasoMstDataSet.JokasoMstDataTable JokasoMstDataTable { get; set; }

        /// <summary>
        /// 法定管理マスタ
        /// </summary>
        HoteiKanriMstDataSet.HoteiKanriMstDataTable HoteiKanriMstDataTable { get; set; }

        ///// <summary>
        ///// 郵便番号住所マスタ
        ///// </summary>
        //YubinNoAdrMstDataSet.YubinNoAdrMstDataTable YubinNoAdrMstDataTable { get; set; }

        /// <summary>
        /// HoshoShinseiShosaiDataTable
        /// </summary>
        HoshoTorokuTblDataSet.HoshoShinseiShosaiDataTable HoshoShinseiShosaiDataTable { get; set; }

        //// 2015.01.20 AnhNV ADD v1.03 Start
        ///// <summary>
        ///// 業者マスタ
        ///// </summary>
        //GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDataTable { get; set; }

        ///// <summary>
        ///// 型式マスタ
        ///// </summary>
        //KatashikiMstDataSet.KatashikiMstDataTable KatashikiMstDataTable { get; set; }
        //// 2015.01.20 AnhNV ADD v1.03 End
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
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// 保証登録テーブル
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDataTable { get; set; }

        /// <summary>
        /// 浄化槽マスタ
        /// </summary>
        public JokasoMstDataSet.JokasoMstDataTable JokasoMstDataTable { get; set; }

        /// <summary>
        /// 法定管理マスタ
        /// </summary>
        public HoteiKanriMstDataSet.HoteiKanriMstDataTable HoteiKanriMstDataTable { get; set; }

        ///// <summary>
        ///// 郵便番号住所マスタ
        ///// </summary>
        //public YubinNoAdrMstDataSet.YubinNoAdrMstDataTable YubinNoAdrMstDataTable { get; set; }

        /// <summary>
        /// HoshoShinseiShosaiDataTable
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoShinseiShosaiDataTable HoshoShinseiShosaiDataTable { get; set; }

        //// 2015.01.20 AnhNV ADD v1.03 Start
        ///// <summary>
        ///// 業者マスタ
        ///// </summary>
        //public GyoshaMstDataSet.GyoshaMstDataTable GyoshaMstDataTable { get; set; }

        ///// <summary>
        ///// 型式マスタ
        ///// </summary>
        //public KatashikiMstDataSet.KatashikiMstDataTable KatashikiMstDataTable { get; set; }
        //// 2015.01.20 AnhNV ADD v1.03 End
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
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HoshoShinseiShosai：FormLoad";

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
        /// 2014/07/17　AnhNV　　    新規作成
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
        /// 2014/07/17　AnhNV　　    新規作成
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
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // Get 保証登録テーブル by key
                IGetHoshoTorokuTblByKeyBLOutput blOutput = new GetHoshoTorokuTblByKeyBusinessLogic().Execute(input);
                output.HoshoTorokuTblDataTable = blOutput.HoshoTorokuTblDataTable;

                // Get 浄化槽マスタ info
                IGetJokasoMstInfoBLOutput jokOutput = new GetJokasoMstInfoBusinessLogic().Execute(new GetJokasoMstInfoBLInput());
                output.JokasoMstDataTable = jokOutput.JokasoMstDataTable;

                // Get 法定管理マスタ info
                IGetHoteiKanriMstInfoBLOutput hoteiOutput = new GetHoteiKanriMstInfoBusinessLogic().Execute(new GetHoteiKanriMstInfoBLInput());
                output.HoteiKanriMstDataTable = hoteiOutput.HoteiKanriMstDataTable;

                //// Get 郵便番号住所マスタ info
                //IGetYubinNoAdrMstInfoBLOutput yubinOutput = new GetYubinNoAdrMstInfoBusinessLogic().Execute(new GetYubinNoAdrMstInfoBLInput());
                //output.YubinNoAdrMstDataTable = yubinOutput.YubinNoAdrMstDataTable;

                //// 2015.01.20 AnhNV ADD v1.03 Start
                //IGetGyoshaMstInfoBLOutput gyoshaOutput = new GetGyoshaMstInfoBusinessLogic().Execute(new GetGyoshaMstInfoBLInput());
                //output.GyoshaMstDataTable = gyoshaOutput.GyoshaMstDataTable;

                //IGetKatashikiMstInfoBLOutput kkmOutput = new GetKatashikiMstInfoBusinessLogic().Execute(new GetKatashikiMstInfoBLInput());
                //output.KatashikiMstDataTable = kkmOutput.KatashikiMstDataTable;
                //// 2015.01.20 AnhNV ADD v1.03 End

                // Get HoshoShinseiShosaiDataTable
                IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLInput shinsheiInput = new GetHoshoShinseiShosaiByKensakikanNendoRenbanBLInput();
                shinsheiInput.HoshoTorokuKensakikan = input.HoshoTorokuKensakikan;
                shinsheiInput.HoshoTorokuNendo = input.HoshoTorokuNendo;
                shinsheiInput.HoshoTorokuRenban = input.HoshoTorokuRenban;
                IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput shinsheiOutput = new GetHoshoShinseiShosaiByKensakikanNendoRenbanBusinessLogic().Execute(shinsheiInput);
                output.HoshoShinseiShosaiDataTable = shinsheiOutput.HoshoShinseiShosaiDataTable;
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
    }
    #endregion
}
