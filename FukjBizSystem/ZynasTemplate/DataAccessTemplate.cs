using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.Common;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace $rootnamespace$
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： I$safeitemname$DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface I$safeitemname$DAInput
    {
        // TODO 入力インターフェイスを実装してください
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： $safeitemname$DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class $safeitemname$DAInput : I$safeitemname$DAInput
    {
        // TODO 入力クラスを実装してください
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： I$safeitemname$DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface I$safeitemname$DAOutput
    {
        // TODO 出力インターフェイスを実装してください
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： $safeitemname$DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class $safeitemname$DAOutput : I$safeitemname$DAOutput
    {
        // TODO 出力クラスを実装してください
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： $safeitemname$DataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class $safeitemname$DataAccess : BaseDataAccess<I$safeitemname$DAInput, I$safeitemname$DAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        // TODO:使用するテーブルアダプタの実体を定義してください
        private XXXXDataSetTableAdapters.XXXXTableAdapter tableAdapter
            = new XXXXDataSetTableAdapters.XXXXTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： $safeitemname$DataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public $safeitemname$DataAccess()
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
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override I$safeitemname$DAOutput Execute(I$safeitemname$DAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            I$safeitemname$DAOutput output = new $safeitemname$DAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);
                
                // TODO 実行メソッドを実装してください

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
