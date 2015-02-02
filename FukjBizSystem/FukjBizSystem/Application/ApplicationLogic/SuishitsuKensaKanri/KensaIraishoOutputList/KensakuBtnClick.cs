using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaIraishoOutputList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KensaIraishoOutputList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        KensaIraishoOutputSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public KensaIraishoOutputSearchCond SearchCond { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("浄化槽番号（開始） (保健所コード)[{0}], 浄化槽番号（開始） (年度)[{1]], 浄化槽番号（開始） (連番)[{2}], 浄化槽番号（終了） (保健所コード)[{3}], 浄化槽番号（終了） (年度)[{4]], 浄化槽番号（終了） (連番)[{5}]",
                    new string[] {SearchCond.HokenjoCdFrom, 
                                SearchCond.NendoFrom, 
                                SearchCond.RenbanFrom, 
                                SearchCond.HokenjoCdTo, 
                                SearchCond.NendoTo, 
                                SearchCond.RenbanTo});
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KensaIraishoOutputListDataTable
        /// </summary>
        JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable KensaIraishoOutputListDataTable { get; set; }

        /// <summary>
        /// KishakuBairitsuKensaKekkaDataTable
        /// </summary>
        KensaKekkaTblDataSet.KishakuBairitsuKensaKekkaDataTable KishakuBairitsuKensaKekkaDataTable { get; set; }

        /// <summary>
        /// KishakuBairitsuShomeiKekkaDataTable
        /// </summary>
        KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaDataTable KishakuBairitsuShomeiKekkaDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KensaIraishoOutputListDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable KensaIraishoOutputListDataTable { get; set; }

        /// <summary>
        /// KishakuBairitsuKensaKekkaDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KishakuBairitsuKensaKekkaDataTable KishakuBairitsuKensaKekkaDataTable { get; set; }

        /// <summary>
        /// KishakuBairitsuShomeiKekkaDataTable
        /// </summary>
        public KeiryoShomeiKekkaTblDataSet.KishakuBairitsuShomeiKekkaDataTable KishakuBairitsuShomeiKekkaDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaIraishoOutputList：KensakuBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensakuBtnClickApplicationLogic()
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
        /// 2014/12/02  HuyTX　    新規作成
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
        /// 2014/12/02  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                //get data by search condition
                IGetKensaIraishoOutputListBySearchCondBLInput getKensaIraishoInput = new GetKensaIraishoOutputListBySearchCondBLInput();
                getKensaIraishoInput.SearchCond = input.SearchCond;
                output.KensaIraishoOutputListDataTable = new GetKensaIraishoOutputListBySearchCondBusinessLogic().Execute(getKensaIraishoInput).KensaIraishoOutputListDataTable;

                //get KishakuBairitsuKensaKekka
                IGetKishakuBairitsuKensaKekkaInfoBLInput getKensaKekkaInput = new GetKishakuBairitsuKensaKekkaInfoBLInput();
                getKensaKekkaInput.SearchCond = input.SearchCond;
                output.KishakuBairitsuKensaKekkaDataTable = new GetKishakuBairitsuKensaKekkaInfoBusinessLogic().Execute(getKensaKekkaInput).KishakuBairitsuKensaKekkaDataTable;

                //get KishakuBairitsuShomeiKekka
                IGetKishakuBairitsuShomeiKekkaInfoBLInput getShomeiKekkaInput = new GetKishakuBairitsuShomeiKekkaInfoBLInput();
                getShomeiKekkaInput.SearchCond = input.SearchCond;
                getShomeiKekkaInput.ShikenKomokuCd = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_065, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);
                output.KishakuBairitsuShomeiKekkaDataTable = new GetKishakuBairitsuShomeiKekkaInfoBusinessLogic().Execute(getShomeiKekkaInput).KishakuBairitsuShomeiKekkaDataTable;

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
