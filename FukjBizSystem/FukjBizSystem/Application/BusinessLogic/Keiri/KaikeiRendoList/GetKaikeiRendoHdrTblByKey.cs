using System.Reflection;
using FukjBizSystem.Application.DataAccess.KaikeiRendoHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiRendoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKaikeiRendoHdrTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKaikeiRendoHdrTblByKeyBLInput : ISelectKaikeiRendoHdrTblByKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKaikeiRendoHdrTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKaikeiRendoHdrTblByKeyBLInput : IGetKaikeiRendoHdrTblByKeyBLInput
    {
        /// <summary>
        /// KaikeiNo
        /// </summary>
        public string KaikeiNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKaikeiRendoHdrTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKaikeiRendoHdrTblByKeyBLOutput : ISelectKaikeiRendoHdrTblByKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKaikeiRendoHdrTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKaikeiRendoHdrTblByKeyBLOutput : IGetKaikeiRendoHdrTblByKeyBLOutput
    {
        /// <summary>
        /// KaikeiRendoHdrTblDataTable
        /// </summary>
        public KaikeiRendoHdrTblDataSet.KaikeiRendoHdrTblDataTable KaikeiRendoHdrTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKaikeiRendoHdrTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/16  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKaikeiRendoHdrTblByKeyBusinessLogic : BaseBusinessLogic<IGetKaikeiRendoHdrTblByKeyBLInput, IGetKaikeiRendoHdrTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKaikeiRendoHdrTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/16  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKaikeiRendoHdrTblByKeyBusinessLogic()
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
        /// 2014/09/16  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKaikeiRendoHdrTblByKeyBLOutput Execute(IGetKaikeiRendoHdrTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKaikeiRendoHdrTblByKeyBLOutput output = new GetKaikeiRendoHdrTblByKeyBLOutput();

            try
            {
                output.KaikeiRendoHdrTblDataTable = new SelectKaikeiRendoHdrTblByKeyDataAccess().Execute(input).KaikeiRendoHdrTblDataTable;

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
