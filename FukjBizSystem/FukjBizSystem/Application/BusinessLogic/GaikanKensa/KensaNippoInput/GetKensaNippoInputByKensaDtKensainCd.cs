using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaNippoInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaNippoInputByKensaDtKensainCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaNippoInputByKensaDtKensainCdBLInput : ISelectKensaNippoInputByKensaDtKensainCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaNippoInputByKensaDtKensainCdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaNippoInputByKensaDtKensainCdBLInput : IGetKensaNippoInputByKensaDtKensainCdBLInput
    {
        /// <summary>
        /// 検査日
        /// </summary>
        public DateTime KensaDt { get; set; }

        /// <summary>
        /// 検査員コード
        /// </summary>
        public string KensainCd { get; set; }

        /// <summary>
        /// 1: ADD
        /// 2: EDIT
        /// </summary>
        public string Mode { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaNippoInputByKensaDtKensainCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaNippoInputByKensaDtKensainCdBLOutput : ISelectKensaNippoInputByKensaDtKensainCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaNippoInputByKensaDtKensainCdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaNippoInputByKensaDtKensainCdBLOutput : IGetKensaNippoInputByKensaDtKensainCdBLOutput
    {
        /// <summary>
        /// KensaNippoInputDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaNippoInputDataTable KensaNippoInputDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaNippoInputByKensaDtKensainCdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaNippoInputByKensaDtKensainCdBusinessLogic : BaseBusinessLogic<IGetKensaNippoInputByKensaDtKensainCdBLInput, IGetKensaNippoInputByKensaDtKensainCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaNippoInputByKensaDtKensainCdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaNippoInputByKensaDtKensainCdBusinessLogic()
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
        /// 2014/11/20　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaNippoInputByKensaDtKensainCdBLOutput Execute(IGetKensaNippoInputByKensaDtKensainCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaNippoInputByKensaDtKensainCdBLOutput output = new GetKensaNippoInputByKensaDtKensainCdBLOutput();

            try
            {
                ISelectKensaNippoInputByKensaDtKensainCdDAOutput daOutput = new SelectKensaNippoInputByKensaDtKensainCdDataAccess().Execute(input);
                output.KensaNippoInputDataTable = daOutput.KensaNippoInputDataTable;
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
