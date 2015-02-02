using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaHoryuShosai;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaTorisageList;
using FukjBizSystem.Application.BusinessLogic.Master.ShozokuMstShosai;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using BLCommon = FukjBizSystem.Application.BusinessLogic.Common;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaHoryuShosai
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
    /// 2014/08/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput, IGetKensaHoryuShosaiByKyokaiNoBLInput
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
    /// 2014/08/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("協会No[{0}]", string.Concat(KensaIraiHokenjoCd, "-", KensaIraiNendo, "-", KensaIraiRenban));
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
    /// 2014/08/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput : IGetListComboBoxesBLOutput, IGetKensaHoryuShosaiByKyokaiNoBLOutput, IGetShozokuMstByShokuinCdBLOutput
    {
        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// ShishoMstExceptJimukyokuDataTable 
        /// </summary>
        ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable ShishoMstExceptJimukyokuDataTable { get; set; }
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
    /// 2014/08/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// ComboBoxSources
        /// </summary>
        public ComboBoxSources ComboBoxSources { get; set; }

        /// <summary>
        /// KensaHoryuShosaiDataTable
        /// </summary>
        public KensaHoryuDataSet.KensaHoryuShosaiDataTable KensaHoryuShosaiDataTable { get; set; }

        /// <summary>
        /// ShozokuMstDT
        /// </summary>
        public ShozokuMstDataSet.ShozokuMstDataTable ShozokuMstDT { get; set; }

        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDataTable { get; set; }

        /// <summary>
        /// ShishoMstExceptJimukyokuDataTable 
        /// </summary>
        public ShishoMstDataSet.ShishoMstExceptJimukyokuDataTable ShishoMstExceptJimukyokuDataTable { get; set; }
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
    /// 2014/08/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaHoryuShosai：FormLoad";

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
        /// 2014/08/30　AnhNV　　    新規作成
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
        /// 2014/08/30　AnhNV　　    新規作成
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
        /// 2014/08/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // Get list of comboboxes
                IGetListComboBoxesBLOutput comboOutp = new GetListComboBoxesBusinessLogic().Execute(new GetListComboBoxesBLInput());
                output.ComboBoxSources = comboOutp.ComboBoxSources;

                // Get ShozokuMst by ShokuinCd (login user)
                IGetShozokuMstByShokuinCdBLInput shozokuInp = new GetShozokuMstByShokuinCdBLInput();
                shozokuInp.ShokuinCd = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinCd;
                IGetShozokuMstByShokuinCdBLOutput shozokuOutp = new GetShozokuMstByShokuinCdBusinessLogic().Execute(shozokuInp);
                output.ShozokuMstDT = shozokuOutp.ShozokuMstDT;

                // Get display by kyokaiNo
                IGetKensaHoryuShosaiByKyokaiNoBLOutput blOutput = new GetKensaHoryuShosaiByKyokaiNoBusinessLogic().Execute(input);
                output.KensaHoryuShosaiDataTable = blOutput.KensaHoryuShosaiDataTable;

                //20150128 HuyTX Add 課題対応 No279 支所コンボから事務局除外対応
                BLCommon.IGetShishoMstExceptJimukyokuBLOutput shishoOutput = new BLCommon.GetShishoMstExceptJimukyokuBusinessLogic().Execute(new BLCommon.GetShishoMstExceptJimukyokuBLInput());
                output.ShishoMstExceptJimukyokuDataTable = shishoOutput.ShishoMstExceptJimukyokuDT;
                //End

                // Get KensaIraiTbl by key
                //string[] keys = input.KyokaiNo.Split('-');
                IGetKensaIraiTblByKeyBLInput kensaInp = new GetKensaIraiTblByKeyBLInput();
                kensaInp.KensaIraiHoteiKbn = Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN;
                kensaInp.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                //kensaInp.KensaIraiNendo = (Convert.ToInt32(keys[1]) + 1988).ToString();
                kensaInp.KensaIraiNendo = input.KensaIraiNendo; // Wareki
                kensaInp.KensaIraiRenban = input.KensaIraiRenban;
                IGetKensaIraiTblByKeyBLOutput kensaOutp = new GetKensaIraiTblByKeyBusinessLogic().Execute(kensaInp);
                output.KensaIraiTblDataTable = kensaOutp.KensaIraiTblDataTable;
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
