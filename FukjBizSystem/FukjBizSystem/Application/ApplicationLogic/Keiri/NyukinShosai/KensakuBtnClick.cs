using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.NyukinShosai
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
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        SeikyushoKagamiHdrSearchCond SearchCond { get; set; }
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
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public SeikyushoKagamiHdrSearchCond SearchCond { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("請求No[{0}], 業者コード[{1}], 浄化槽台帳保健所コード [{2}], 浄化槽台帳年度 [{3}], 浄化槽台帳連番[{4}]",
                                    new string[] {SearchCond.SeikyuNo,
                                                    SearchCond.GyoshaCd,
                                                    SearchCond.JokasoHokenjoCd,
                                                    SearchCond.JokasoTorokuNendo,
                                                    SearchCond.JokasoRenban});
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
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput
    {
        /// <summary>
        /// SeikyushoKagamiHdrInfoDataTable
        /// </summary>
        SeikyusyoKagamiHdrTblDataSet.SeikyushoKagamiHdrInfoDataTable SeikyushoKagamiHdrInfoDataTable { get; set; }

        /// <summary>
        /// SeikyuNyukinTblListDataTable
        /// </summary>
        SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable SeikyuNyukinTblListDataTable { get; set; }
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
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// SeikyushoKagamiHdrInfoDataTable
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyushoKagamiHdrInfoDataTable SeikyushoKagamiHdrInfoDataTable { get; set; }

        /// <summary>
        /// SeikyuNyukinTblListDataTable
        /// </summary>
        public SeikyuNyukinTblDataSet.SeikyuNyukinTblListDataTable SeikyuNyukinTblListDataTable { get; set; }
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
    /// 2014/11/13  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "NyukinShosai：KensakuBtnClick";

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
        /// 2014/11/13  HuyTX　    新規作成
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
        /// 2014/11/13  HuyTX　    新規作成
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
        /// 2014/11/13  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                //get SeikyushoKagamiHdrTbl
                IGetSeikyuShoKagamiHdrTblInfoBySearchCondBLInput getSeikyuKagamiHdrInput = new GetSeikyuShoKagamiHdrTblInfoBySearchCondBLInput();
                getSeikyuKagamiHdrInput.SearchCond = input.SearchCond;
                output.SeikyushoKagamiHdrInfoDataTable = new GetSeikyuShoKagamiHdrTblInfoBySearchCondBusinessLogic().Execute(getSeikyuKagamiHdrInput).SeikyushoKagamiHdrInfoDataTable;

                //get SeikyuNyukinTblList
                IGetSeikyuNyukinListBySearchCondBLInput getSeikyuNyukinListBLInput = new GetSeikyuNyukinListBySearchCondBLInput();
                getSeikyuNyukinListBLInput.SearchCond = input.SearchCond;
                output.SeikyuNyukinTblListDataTable = new GetSeikyuNyukinListBySearchCondBusinessLogic().Execute(getSeikyuNyukinListBLInput).SeikyuNyukinTblListDataTable;

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
