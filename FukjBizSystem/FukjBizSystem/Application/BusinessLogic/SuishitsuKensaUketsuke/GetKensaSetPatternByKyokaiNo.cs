using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaSetPatternByKyokaiNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  小松　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaSetPatternByKyokaiNoBLInput : ISelectKensaSetPatternByKyokaiNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaSetPatternByKyokaiNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  小松　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaSetPatternByKyokaiNoBLInput : IGetKensaSetPatternByKyokaiNoBLInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        public string JokasoHokenjoCd { get; set; }
        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        public string JokasoTorokuNendo { get; set; }
        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaSetPatternByKyokaiNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  小松　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaSetPatternByKyokaiNoBLOutput : ISelectKensaSetPatternByKyokaiNoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaSetPatternByKyokaiNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  小松　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaSetPatternByKyokaiNoBLOutput : IGetKensaSetPatternByKyokaiNoBLOutput
    {
        /// <summary>
        /// KensaSetPattern
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.KensaSetPatternDataTable KensaSetPattern { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaSetPatternByKyokaiNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  小松　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaSetPatternByKyokaiNoBusinessLogic : BaseBusinessLogic<IGetKensaSetPatternByKyokaiNoBLInput, IGetKensaSetPatternByKyokaiNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaSetPatternByKyokaiNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10  小松　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaSetPatternByKyokaiNoBusinessLogic()
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
        /// 2014/12/10  小松　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaSetPatternByKyokaiNoBLOutput Execute(IGetKensaSetPatternByKyokaiNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaSetPatternByKyokaiNoBLOutput output = new GetKensaSetPatternByKyokaiNoBLOutput();

            try
            {
                output.KensaSetPattern = new SelectKensaSetPatternByKyokaiNoDataAccess().Execute(input).KensaSetPattern;
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
