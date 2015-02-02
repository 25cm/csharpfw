using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMaxKensaDtByJokasoDaichoKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMaxKensaDtByJokasoDaichoKeyBLInput : ISelectMaxKensaDtByJokasoDaichoKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaxKensaDtByJokasoDaichoKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMaxKensaDtByJokasoDaichoKeyBLInput : IGetMaxKensaDtByJokasoDaichoKeyBLInput
    {
        /// <summary>
        /// KensaIraiJokasoHokenjoCd
        /// </summary>
        public string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiJokasoTorokuNendo
        /// </summary>
        public string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// KensaIraiJokasoRenban
        /// </summary>
        public string KensaIraiJokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMaxKensaDtByJokasoDaichoKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMaxKensaDtByJokasoDaichoKeyBLOutput : ISelectMaxKensaDtByJokasoDaichoKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaxKensaDtByJokasoDaichoKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMaxKensaDtByJokasoDaichoKeyBLOutput : IGetMaxKensaDtByJokasoDaichoKeyBLOutput
    {
        /// <summary>
        /// MaxKensaDt
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.MaxKensaDtDataTable MaxKensaDt { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaxKensaDtByJokasoDaichoKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/09  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMaxKensaDtByJokasoDaichoKeyBusinessLogic : BaseBusinessLogic<IGetMaxKensaDtByJokasoDaichoKeyBLInput, IGetMaxKensaDtByJokasoDaichoKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMaxKensaDtByJokasoDaichoKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/09  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetMaxKensaDtByJokasoDaichoKeyBusinessLogic()
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
        /// 2014/12/09  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetMaxKensaDtByJokasoDaichoKeyBLOutput Execute(IGetMaxKensaDtByJokasoDaichoKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMaxKensaDtByJokasoDaichoKeyBLOutput output = new GetMaxKensaDtByJokasoDaichoKeyBLOutput();

            try
            {
                output.MaxKensaDt = new SelectMaxKensaDtByJokasoDaichoKeyDataAccess().Execute(input).MaxKensaDt;
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
