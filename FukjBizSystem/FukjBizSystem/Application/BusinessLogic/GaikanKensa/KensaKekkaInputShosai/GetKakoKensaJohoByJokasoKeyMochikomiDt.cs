using System.Reflection;
using FukjBizSystem.Application.DataAccess.GaikanKensaKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaKekkaInputShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKakoKensaJohoByJokasoKeyMochikomiDtBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKakoKensaJohoByJokasoKeyMochikomiDtBLInput : ISelectKakoKensaJohoByJokasoKeyMochikomiDtDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKakoKensaJohoByJokasoKeyMochikomiDtBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKakoKensaJohoByJokasoKeyMochikomiDtBLInput : IGetKakoKensaJohoByJokasoKeyMochikomiDtBLInput
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
    //  インターフェイス名 ： IGetKakoKensaJohoByJokasoKeyMochikomiDtBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKakoKensaJohoByJokasoKeyMochikomiDtBLOutput : ISelectKakoKensaJohoByJokasoKeyMochikomiDtDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKakoKensaJohoByJokasoKeyMochikomiDtBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKakoKensaJohoByJokasoKeyMochikomiDtBLOutput : IGetKakoKensaJohoByJokasoKeyMochikomiDtBLOutput
    {
        /// <summary>
        /// KakoKensaJohoDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.KakoKensaJohoDataTable KakoKensaJohoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKakoKensaJohoByJokasoKeyMochikomiDtBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKakoKensaJohoByJokasoKeyMochikomiDtBusinessLogic : BaseBusinessLogic<IGetKakoKensaJohoByJokasoKeyMochikomiDtBLInput, IGetKakoKensaJohoByJokasoKeyMochikomiDtBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKakoKensaJohoByJokasoKeyMochikomiDtBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKakoKensaJohoByJokasoKeyMochikomiDtBusinessLogic()
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
        /// 2014/12/01　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKakoKensaJohoByJokasoKeyMochikomiDtBLOutput Execute(IGetKakoKensaJohoByJokasoKeyMochikomiDtBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKakoKensaJohoByJokasoKeyMochikomiDtBLOutput output = new GetKakoKensaJohoByJokasoKeyMochikomiDtBLOutput();

            try
            {
                ISelectKakoKensaJohoByJokasoKeyMochikomiDtDAOutput daOutput = new SelectKakoKensaJohoByJokasoKeyMochikomiDtDataAccess().Execute(input);
                output.KakoKensaJohoDataTable = daOutput.KakoKensaJohoDataTable;
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
