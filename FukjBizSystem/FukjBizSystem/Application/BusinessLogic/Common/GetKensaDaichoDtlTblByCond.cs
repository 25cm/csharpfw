using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataAccess.KensaDaichoDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaichoDtlTblByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaichoDtlTblByCondBLInput : ISelectKensaDaichoDtlTblByCondDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoDtlTblByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoDtlTblByCondBLInput : IGetKensaDaichoDtlTblByCondBLInput
    {
        /// <summary>
        /// 区分 
        /// </summary>
        public string Kbn { get; set; }
        /// <summary>
        /// 依頼年度 
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード 
        /// </summary>
        public string Sisho { get; set; }
        /// <summary>
        /// 依頼番号 
        /// </summary>
        public string IraiNo { get; set; }
    }

    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaichoDtlTblByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaichoDtlTblByCondBLOutput : ISelectKensaDaichoDtlTblByCondDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoDtlTblByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoDtlTblByCondBLOutput : IGetKensaDaichoDtlTblByCondBLOutput
    {
        /// <summary>
        /// KensaDaichoDtlTblDataTable
        /// </summary>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoDtlTblByCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoDtlTblByCondBusinessLogic : BaseBusinessLogic<IGetKensaDaichoDtlTblByCondBLInput, IGetKensaDaichoDtlTblByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaDaichoDtlTblByCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/28  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaDaichoDtlTblByCondBusinessLogic()
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
        /// 2014/11/28  宗    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaDaichoDtlTblByCondBLOutput Execute(IGetKensaDaichoDtlTblByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaDaichoDtlTblByCondBLOutput output = new GetKensaDaichoDtlTblByCondBLOutput();

            try
            {
                output.KensaDaichoDtlTblDT = new SelectKensaDaichoDtlTblByCondDataAccess().Execute(input).KensaDaichoDtlTblDT;
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
