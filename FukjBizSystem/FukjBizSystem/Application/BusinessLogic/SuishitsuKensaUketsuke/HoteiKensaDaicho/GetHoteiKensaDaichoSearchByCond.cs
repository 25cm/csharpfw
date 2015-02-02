using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.HoteiKensaDaicho
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoteiKensaDaichoSearchByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoteiKensaDaichoSearchByCondBLInput : ISelectHoteiKensaDaichoSearchByCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoteiKensaDaichoSearchByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoteiKensaDaichoSearchByCondBLInput : IGetHoteiKensaDaichoSearchByCondBLInput
    {
        /// <summary>
        /// Search Condition
        /// </summary>
        public HoteiKensaDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoteiKensaDaichoSearchByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoteiKensaDaichoSearchByCondBLOutput : ISelectHoteiKensaDaichoSearchByCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoteiKensaDaichoSearchByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoteiKensaDaichoSearchByCondBLOutput : IGetHoteiKensaDaichoSearchByCondBLOutput
    {
        /// <summary>
        /// HoteiKensaDaichoDataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchDataTable HoteiKensaDaichoDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoteiKensaDaichoSearchByCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoteiKensaDaichoSearchByCondBusinessLogic : BaseBusinessLogic<IGetHoteiKensaDaichoSearchByCondBLInput, IGetHoteiKensaDaichoSearchByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetHoteiKensaDaichoSearchByCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/28  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetHoteiKensaDaichoSearchByCondBusinessLogic()
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
        /// 2014/11/28  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetHoteiKensaDaichoSearchByCondBLOutput Execute(IGetHoteiKensaDaichoSearchByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetHoteiKensaDaichoSearchByCondBLOutput output = new GetHoteiKensaDaichoSearchByCondBLOutput();

            try
            {
                output.HoteiKensaDaichoDT = new SelectHoteiKensaDaichoSearchByCondDataAccess().Execute(input).HoteiKensaDaichoDT;
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
