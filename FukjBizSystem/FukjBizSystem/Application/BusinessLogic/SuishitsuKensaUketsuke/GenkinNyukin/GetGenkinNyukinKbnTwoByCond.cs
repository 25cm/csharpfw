using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataAccess.NyukinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.GenkinNyukin
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGenkinNyukinKbnTwoByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGenkinNyukinKbnTwoByCondBLInput : ISelectGenkinNyukinTypeKbnTwoByCondDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGenkinNyukinKbnTwoByCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGenkinNyukinKbnTwoByCondBLInput : IGetGenkinNyukinKbnTwoByCondBLInput
    {
        /// <summary>
        /// KeiryoShomeiIraiNendo 
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd 
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban 
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGenkinNyukinKbnTwoByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGenkinNyukinKbnTwoByCondBLOutput : ISelectGenkinNyukinTypeKbnTwoByCondDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGenkinNyukinKbnTwoByCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGenkinNyukinKbnTwoByCondBLOutput : IGetGenkinNyukinKbnTwoByCondBLOutput
    {
        /// <summary>
        /// GenkinNyukinFormLoad1DataTable
        /// </summary>
        public NyukinTblDataSet.GenkinNyukinTblDataTable GenkinNyukinTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGenkinNyukinKbnTwoByCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGenkinNyukinKbnTwoByCondBusinessLogic : BaseBusinessLogic<IGetGenkinNyukinKbnTwoByCondBLInput, IGetGenkinNyukinKbnTwoByCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetGenkinNyukinKbnTwoByCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetGenkinNyukinKbnTwoByCondBusinessLogic()
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
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetGenkinNyukinKbnTwoByCondBLOutput Execute(IGetGenkinNyukinKbnTwoByCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetGenkinNyukinKbnTwoByCondBLOutput output = new GetGenkinNyukinKbnTwoByCondBLOutput();

            try
            {
                output.GenkinNyukinTblDataTable = new SelectGenkinNyukinTypeKbnTwoByCondDataAccess().Execute(input).GenkinNyukinTblDataTable;
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