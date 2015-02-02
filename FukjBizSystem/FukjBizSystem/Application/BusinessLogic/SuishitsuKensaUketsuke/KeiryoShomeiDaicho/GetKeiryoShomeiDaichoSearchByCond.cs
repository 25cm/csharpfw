using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaDaicho9joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKeiryoShomeiDaichoSearchByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKeiryoShomeiDaichoSearchByCondBLInput : ISelectKeiryoShomeiDaichoSearchByCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiDaichoSearchByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKeiryoShomeiDaichoSearchByCondBLInput : IGetKeiryoShomeiDaichoSearchByCondBLInput
    {
        /// <summary>
        /// 検索条件
        /// </summary>
        public KeiryoShomeiDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKeiryoShomeiDaichoSearchByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKeiryoShomeiDaichoSearchByCondBLOutput : ISelectKeiryoShomeiDaichoSearchByCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiDaichoSearchByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKeiryoShomeiDaichoSearchByCondBLOutput : IGetKeiryoShomeiDaichoSearchByCondBLOutput
    {
        /// <summary>
        /// 計量証明台帳データテーブル
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoSearchDataTable KeiryoShomeiDaichoDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiDaichoSearchByCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKeiryoShomeiDaichoSearchByCondBusinessLogic : BaseBusinessLogic<IGetKeiryoShomeiDaichoSearchByCondBLInput, IGetKeiryoShomeiDaichoSearchByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKeiryoShomeiDaichoSearchByCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKeiryoShomeiDaichoSearchByCondBusinessLogic()
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
        /// 2014/12/05  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKeiryoShomeiDaichoSearchByCondBLOutput Execute(IGetKeiryoShomeiDaichoSearchByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKeiryoShomeiDaichoSearchByCondBLOutput output = new GetKeiryoShomeiDaichoSearchByCondBLOutput();

            try
            {
                output.KeiryoShomeiDaichoDT = new SelectKeiryoShomeiDaichoSearchByCondDataAccess().Execute(input).KeiryoShomeiDaichoDT;
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
