using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataAccess.GenbaShashinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.BusinessLogic.Common.GenbaShashinList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateGenbaShashinTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateGenbaShashinTblBLInput : IUpdateGenbaShashinTblDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateGenbaShashinTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateGenbaShashinTblBLInput : IUpdateGenbaShashinTblBLInput
    {
        /// <summary>
        /// JokasoDaichiRirekiTblDataTable
        /// </summary>
        public GenbaShashinTblDataSet.GenbaShashinTblDataTable GenbaShashinTbl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateGenbaShashinTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateGenbaShashinTblBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateGenbaShashinTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateGenbaShashinTblBLOutput : IUpdateGenbaShashinTblBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateGenbaShashinTblBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/15  豊田    　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateGenbaShashinTblBusinessLogic : BaseBusinessLogic<IUpdateGenbaShashinTblBLInput, IUpdateGenbaShashinTblBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateGenbaShashinTblBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/15  豊田    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateGenbaShashinTblBusinessLogic()
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
        /// 2014/12/15  豊田    　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateGenbaShashinTblBLOutput Execute(IUpdateGenbaShashinTblBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateGenbaShashinTblBLOutput output = new UpdateGenbaShashinTblBLOutput();

            try
            {
                new UpdateGenbaShashinTblDataAccess().Execute(input);
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
