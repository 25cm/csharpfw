using System.Reflection;
using FukjBizSystem.Application.DataAccess.YoshiHanbaiDtlTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput : IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput : IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput
    {
        /// <summary>
        /// 注文番号
        /// </summary>
        public string YoshiHanbaiChumonNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput : IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/22　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic : BaseBusinessLogic<IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput, IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBusinessLogic()
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
        /// 2014/07/22　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput Execute(IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput output = new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoBLOutput();

            try
            {
                new DeleteYoshiHanbaiDtlTblByYoshiHanbaiChumonNoDataAccess().Execute(input);
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
