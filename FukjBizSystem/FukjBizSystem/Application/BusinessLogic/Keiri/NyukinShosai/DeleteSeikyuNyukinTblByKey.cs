using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyuNyukinTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSeikyuNyukinTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSeikyuNyukinTblByKeyBLInput : IDeleteSeikyuNyukinTblByKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuNyukinTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuNyukinTblByKeyBLInput : IDeleteSeikyuNyukinTblByKeyBLInput
    {
        /// <summary>
        /// SeikyuNo
        /// </summary>
        public string SeikyuNo { get; set; }

        /// <summary>
        /// SeikyuRenban
        /// </summary>
        public int SeikyuRenban { get; set; }

        /// <summary>
        /// NyukinNo
        /// </summary>
        public string NyukinNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSeikyuNyukinTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSeikyuNyukinTblByKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuNyukinTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuNyukinTblByKeyBLOutput : IDeleteSeikyuNyukinTblByKeyBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuNyukinTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuNyukinTblByKeyBusinessLogic : BaseBusinessLogic<IDeleteSeikyuNyukinTblByKeyBLInput, IDeleteSeikyuNyukinTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteSeikyuNyukinTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/14  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteSeikyuNyukinTblByKeyBusinessLogic()
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
        /// 2014/12/14  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteSeikyuNyukinTblByKeyBLOutput Execute(IDeleteSeikyuNyukinTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteSeikyuNyukinTblByKeyBLOutput output = new DeleteSeikyuNyukinTblByKeyBLOutput();

            try
            {
                new DeleteSeikyuNyukinTblByKeyDataAccess().Execute(input);

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
