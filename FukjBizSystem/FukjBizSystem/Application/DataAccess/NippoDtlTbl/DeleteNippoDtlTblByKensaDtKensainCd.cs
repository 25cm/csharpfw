using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.NippoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NippoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteNippoDtlTblByKensaDtKensainCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteNippoDtlTblByKensaDtKensainCdDAInput
    {
        /// <summary>
        /// 検査日
        /// </summary>
        string NippoDtlKensaDt { get; set; }

        /// <summary>
        /// 検査員コード
        /// </summary>
        string NippoDtlKensainCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteNippoDtlTblByKensaDtKensainCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteNippoDtlTblByKensaDtKensainCdDAInput : IDeleteNippoDtlTblByKensaDtKensainCdDAInput
    {
        /// <summary>
        /// 検査日
        /// </summary>
        public string NippoDtlKensaDt { get; set; }

        /// <summary>
        /// 検査員コード
        /// </summary>
        public string NippoDtlKensainCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteNippoDtlTblByKensaDtKensainCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteNippoDtlTblByKensaDtKensainCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteNippoDtlTblByKensaDtKensainCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteNippoDtlTblByKensaDtKensainCdDAOutput : IDeleteNippoDtlTblByKensaDtKensainCdDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteNippoDtlTblByKensaDtKensainCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteNippoDtlTblByKensaDtKensainCdDataAccess : BaseDataAccess<IDeleteNippoDtlTblByKensaDtKensainCdDAInput, IDeleteNippoDtlTblByKensaDtKensainCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NippoDtlTblTableAdapter tableAdapter = new NippoDtlTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteNippoDtlTblByKensaDtKensainCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteNippoDtlTblByKensaDtKensainCdDataAccess()
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
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteNippoDtlTblByKensaDtKensainCdDAOutput Execute(IDeleteNippoDtlTblByKensaDtKensainCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteNippoDtlTblByKensaDtKensainCdDAOutput output = new DeleteNippoDtlTblByKensaDtKensainCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteByKensaDtKensainCd(input.NippoDtlKensaDt, input.NippoDtlKensainCd);

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
