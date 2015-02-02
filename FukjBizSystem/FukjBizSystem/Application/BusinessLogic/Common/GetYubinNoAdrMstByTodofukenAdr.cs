using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.YubinNoAdrMstKensaku;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYubinNoAdrMstByTodofukenAdrBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYubinNoAdrMstByTodofukenAdrBLInput:ISelectYubinNoAdrMstByTodofukenAdrDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstByTodofukenAdrBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstByTodofukenAdrBLInput : IGetYubinNoAdrMstByTodofukenAdrBLInput
    {
        /// <summary>
        /// 都道府県名
        /// </summary>
        public String TodofukenNm { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public String AdrNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYubinNoAdrMstByTodofukenAdrBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYubinNoAdrMstByTodofukenAdrBLOutput : ISelectYubinNoAdrMstByTodofukenAdrDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstByTodofukenAdrBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstByTodofukenAdrBLOutput : IGetYubinNoAdrMstByTodofukenAdrBLOutput
    {
        /// <summary>
        /// YubinNoAdrMstDataTable
        /// </summary>
        public YubinNoAdrMstKensakuDataSet.YubinNoAdrMstDataTable YubinNoAdrMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYubinNoAdrMstByTodofukenAdrBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYubinNoAdrMstByTodofukenAdrBusinessLogic : BaseBusinessLogic<IGetYubinNoAdrMstByTodofukenAdrBLInput, IGetYubinNoAdrMstByTodofukenAdrBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetYubinNoAdrMstByTodofukenAdrBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetYubinNoAdrMstByTodofukenAdrBusinessLogic()
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
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetYubinNoAdrMstByTodofukenAdrBLOutput Execute(IGetYubinNoAdrMstByTodofukenAdrBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetYubinNoAdrMstByTodofukenAdrBLOutput output = new GetYubinNoAdrMstByTodofukenAdrBLOutput();

            try
            {
                ISelectYubinNoAdrMstByTodofukenAdrDAOutput daOutput = new SelectYubinNoAdrMstByTodofukenAdrDataAccess().Execute(input);

                output.YubinNoAdrMstDT = daOutput.YubinNoAdrMstDT;

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
