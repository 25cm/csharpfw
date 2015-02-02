using System.Reflection;
using FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaTanKomokuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLInput : ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLInput : IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLInput
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
        /// <summary>
        /// 台帳検査項目枝番
        /// </summary>
        public string DaichoKensaKomokuEdaban { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput : ISelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput : IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput
    {
        /// <summary>
        /// 浄化槽台帳水質検査単項目マスタ情報
        /// </summary>
        public DaichoSuishitsuKensaTanKomokuMstDataSet.DaichoSuishitsuKensaTanKomokuMstDataTable KensaTanKomokuMstDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBusinessLogic : BaseBusinessLogic<IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLInput, IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBusinessLogic()
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
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput Execute(IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput output = new GetDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKBLOutput();

            try
            {
                // 浄化槽台帳水質検査単項目マスタ情報取得（浄化槽台帳水質検査項目マスタの主キー値で取得（複数））
                output.KensaTanKomokuMstDT = new SelectDaichoSuishitsuKensaTanKomokuMstByKensaKomokuMstPKDataAccess().Execute(input).KensaTanKomokuMstDT;
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
