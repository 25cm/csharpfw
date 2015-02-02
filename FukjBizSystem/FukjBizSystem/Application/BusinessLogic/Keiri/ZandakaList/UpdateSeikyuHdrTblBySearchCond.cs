using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.ZandakaList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSeikyuHdrTblBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateSeikyuHdrTblBySearchCondBLInput : IUpdateSeikyuHdrTblBySearchCondDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSeikyuHdrTblBySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSeikyuHdrTblBySearchCondBLInput : IUpdateSeikyuHdrTblBySearchCondBLInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public SeikyuSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSeikyuHdrTblBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateSeikyuHdrTblBySearchCondBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSeikyuHdrTblBySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSeikyuHdrTblBySearchCondBLOutput : IUpdateSeikyuHdrTblBySearchCondBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSeikyuHdrTblBySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSeikyuHdrTblBySearchCondBusinessLogic : BaseBusinessLogic<IUpdateSeikyuHdrTblBySearchCondBLInput, IUpdateSeikyuHdrTblBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateSeikyuHdrTblBySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/21  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateSeikyuHdrTblBySearchCondBusinessLogic()
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
        /// 2015/01/21  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateSeikyuHdrTblBySearchCondBLOutput Execute(IUpdateSeikyuHdrTblBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateSeikyuHdrTblBySearchCondBLOutput output = new UpdateSeikyuHdrTblBySearchCondBLOutput();

            try
            {
                new UpdateSeikyuHdrTblBySearchCondDataAccess().Execute(input);

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
