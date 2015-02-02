using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.CrossCheck.SaisuiTekiseiTenkenList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLInput : ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLInput : IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLInput
    {
        /// <summary>
        /// 浄化槽保健所コード
        /// </summary>
        public string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        public string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string KensaIraiJokasoRenban { get; set; }

        /// <summary>
        /// 水質検査持込日付
        /// </summary>
        public string KensaKekkaMochikomiDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput : ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput : IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput
    {
        /// <summary>
        /// Kako5SaisuiTekiseiTenkenListDataTable
        /// </summary>
        public KensaKekkaTblDataSet.Kako5SaisuiTekiseiTenkenListDataTable Kako5SaisuiTekiseiTenkenListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBusinessLogic : BaseBusinessLogic<IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLInput, IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBusinessLogic()
        {
            
        }
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
        /// 2014/12/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput Execute(IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput output = new GetKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtBLOutput();

            try
            {
                ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput daOutput
                    = new SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDataAccess().Execute(input);

                output.Kako5SaisuiTekiseiTenkenListDataTable = daOutput.Kako5SaisuiTekiseiTenkenListDataTable;
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
