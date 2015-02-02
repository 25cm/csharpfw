using System.Reflection;
using FukjBizSystem.Application.DataAccess.FileKanriTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.FileKanriList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteFileKanriTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteFileKanriTblByKeyBLInput : IDeleteFileKanriTblByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteFileKanriTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteFileKanriTblByKeyBLInput : IDeleteFileKanriTblByKeyBLInput
    {
        /// <summary>
        /// ファイル区分
        /// </summary>
        public string FileKbn { get; set; }

        /// <summary>
        /// ファイルNo
        /// </summary>
        public string FileNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteFileKanriTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteFileKanriTblByKeyBLOutput : IDeleteFileKanriTblByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteFileKanriTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteFileKanriTblByKeyBLOutput : IDeleteFileKanriTblByKeyBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteFileKanriTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteFileKanriTblByKeyBusinessLogic : BaseBusinessLogic<IDeleteFileKanriTblByKeyBLInput, IDeleteFileKanriTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteFileKanriTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteFileKanriTblByKeyBusinessLogic()
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
        /// 2014/08/08  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteFileKanriTblByKeyBLOutput Execute(IDeleteFileKanriTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteFileKanriTblByKeyBLOutput output = new DeleteFileKanriTblByKeyBLOutput();

            try
            {
                new DeleteFileKanriTblByKeyDataAccess().Execute(input);
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
