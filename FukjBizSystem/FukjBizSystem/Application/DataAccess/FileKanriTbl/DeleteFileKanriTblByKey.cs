using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.FileKanriTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.FileKanriTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteFileKanriTblByKeyDAInput
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
    interface IDeleteFileKanriTblByKeyDAInput
    {
        /// <summary>
        /// ファイル区分
        /// </summary>
        string FileKbn { get; set; }

        /// <summary>
        /// ファイルNo
        /// </summary>
        string FileNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteFileKanriTblByKeyDAInput
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
    class DeleteFileKanriTblByKeyDAInput : IDeleteFileKanriTblByKeyDAInput
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
    //  インターフェイス名 ： IDeleteFileKanriTblByKeyDAOutput
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
    interface IDeleteFileKanriTblByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteFileKanriTblByKeyDAOutput
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
    class DeleteFileKanriTblByKeyDAOutput : IDeleteFileKanriTblByKeyDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteFileKanriTblByKeyDataAccess
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
    class DeleteFileKanriTblByKeyDataAccess : BaseDataAccess<IDeleteFileKanriTblByKeyDAInput, IDeleteFileKanriTblByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private FileKanriTblTableAdapter tableAdapter = new FileKanriTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteFileKanriTblByKeyDataAccess
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
        public DeleteFileKanriTblByKeyDataAccess()
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
        public override IDeleteFileKanriTblByKeyDAOutput Execute(IDeleteFileKanriTblByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteFileKanriTblByKeyDAOutput output = new DeleteFileKanriTblByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteByKey(input.FileKbn, input.FileNo);

            }
            catch (Exception e)
            {
                // トレースログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("エラー内容:{0}", e.Message));

                // ＤＢエラー
                throw new CustomException(ResultCode.DBError, string.Format("エラー内容:{0}", e.Message));
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
