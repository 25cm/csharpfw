using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaDaicho9joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKeiryoShomeiDaichoUpdateDtByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKeiryoShomeiDaichoUpdateDtByCondBLInput : ISelectKeiryoShomeiDaichoUpdateDtByCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiDaichoUpdateDtByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKeiryoShomeiDaichoUpdateDtByCondBLInput : IGetKeiryoShomeiDaichoUpdateDtByCondBLInput
    {
        /// <summary>
        /// 検索条件
        /// </summary>
        public KeiryoShomeiDaichoSearchCond UpdateDtSearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKeiryoShomeiDaichoUpdateDtByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKeiryoShomeiDaichoUpdateDtByCondBLOutput : ISelectKeiryoShomeiDaichoUpdateDtByCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiDaichoUpdateDtByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKeiryoShomeiDaichoUpdateDtByCondBLOutput : IGetKeiryoShomeiDaichoUpdateDtByCondBLOutput
    {
        /// <summary>
        /// 計量証明台帳データ更新日
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoUpdateDtDataTable KeiryoShomeiDaichoUpdateDtDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiDaichoUpdateDtByCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKeiryoShomeiDaichoUpdateDtByCondBusinessLogic : BaseBusinessLogic<IGetKeiryoShomeiDaichoUpdateDtByCondBLInput, IGetKeiryoShomeiDaichoUpdateDtByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKeiryoShomeiDaichoUpdateDtByCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKeiryoShomeiDaichoUpdateDtByCondBusinessLogic()
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
        /// 2014/12/08  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKeiryoShomeiDaichoUpdateDtByCondBLOutput Execute(IGetKeiryoShomeiDaichoUpdateDtByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKeiryoShomeiDaichoUpdateDtByCondBLOutput output = new GetKeiryoShomeiDaichoUpdateDtByCondBLOutput();

            try
            {
                output.KeiryoShomeiDaichoUpdateDtDT = new SelectKeiryoShomeiDaichoUpdateDtByCondDataAccess().Execute(input).KeiryoShomeiDaichoUpdateDtDT;
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
