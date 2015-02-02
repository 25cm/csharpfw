using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.ChikuMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.ChikuMstList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetChikuMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/23　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetChikuMstBySearchCondBLInput : ISelectChikuMstBySearchCondDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetChikuMstBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/23　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetChikuMstBySearchCondBLInput : IGetChikuMstBySearchCondBLInput
    {
        /// <summary>
        /// 地区コード（開始）
        /// </summary>
        public String ChikuCdFrom { get; set; }

        /// <summary>
        /// 地区コード（終了）
        /// </summary>
        public String ChikuCdTo { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public String ChikuNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetChikuMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/23　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetChikuMstBySearchCondBLOutput : ISelectChikuMstBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetChikuMstBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/23　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetChikuMstBySearchCondBLOutput : IGetChikuMstBySearchCondBLOutput
    {
        /// <summary>
        /// ChikuMstKensakuDT
        /// </summary>
        public ChikuMstDataSet.ChikuMstKensakuDataTable ChikuMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetChikuMstBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/23　HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetChikuMstBySearchCondBusinessLogic : BaseBusinessLogic<IGetChikuMstBySearchCondBLInput, IGetChikuMstBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetChikuMstBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetChikuMstBySearchCondBusinessLogic()
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
        /// 2014/06/23　HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetChikuMstBySearchCondBLOutput Execute(IGetChikuMstBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetChikuMstBySearchCondBLOutput output = new GetChikuMstBySearchCondBLOutput();

            try
            {
                ISelectChikuMstBySearchCondDAInput daInput = new SelectChikuMstBySearchCondDAInput();
                daInput.ChikuCdFrom = input.ChikuCdFrom;
                daInput.ChikuCdTo = input.ChikuCdTo;
                daInput.ChikuNm = input.ChikuNm;

                ISelectChikuMstBySearchCondDAOutput daOutput = new SelectChikuMstBySearchCondDataAccess().Execute(input);

                output.ChikuMstKensakuDT = daOutput.ChikuMstKensakuDT;

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
