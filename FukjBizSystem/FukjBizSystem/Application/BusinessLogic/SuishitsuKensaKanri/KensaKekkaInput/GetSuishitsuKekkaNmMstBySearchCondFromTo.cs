using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKekkaNmMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaKekkaInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKekkaNmMstBySearchCondFromToBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKekkaNmMstBySearchCondFromToBLInput : ISelectSuishitsuKekkaNmMstBySearchCondFromToDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKekkaNmMstBySearchCondFromToBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKekkaNmMstBySearchCondFromToBLInput : IGetSuishitsuKekkaNmMstBySearchCondFromToBLInput
    {
        #region プロパティ
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 水質結果名称コード(開始)
        /// </summary>
        public string SuishitsuKekkaNmCdFrom { get; set; }

        /// <summary>
        /// 水質結果名称コード(終了)
        /// </summary>
        public string SuishitsuKekkaNmCdTo { get; set; }
        #endregion
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKekkaNmMstBySearchCondFromToBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKekkaNmMstBySearchCondFromToBLOutput : ISelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKekkaNmMstBySearchCondFromToBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKekkaNmMstBySearchCondFromToBLOutput : IGetSuishitsuKekkaNmMstBySearchCondFromToBLOutput
    {
        /// <summary>
        /// SuishitsuKekkaNmMstDT
        /// </summary>
        public SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable SuishitsuKekkaNmMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKekkaNmMstBySearchCondFromToBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKekkaNmMstBySearchCondFromToBusinessLogic : BaseBusinessLogic<IGetSuishitsuKekkaNmMstBySearchCondFromToBLInput, IGetSuishitsuKekkaNmMstBySearchCondFromToBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuKekkaNmMstBySearchCondFromToBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/06  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuKekkaNmMstBySearchCondFromToBusinessLogic()
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
        /// 2015/01/06  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuKekkaNmMstBySearchCondFromToBLOutput Execute(IGetSuishitsuKekkaNmMstBySearchCondFromToBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuKekkaNmMstBySearchCondFromToBLOutput output = new GetSuishitsuKekkaNmMstBySearchCondFromToBLOutput();

            try
            {
                output.SuishitsuKekkaNmMstDT = new SelectSuishitsuKekkaNmMstBySearchCondFromToDataAccess().Execute(input).SuishitsuKekkaNmMstDT;
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
