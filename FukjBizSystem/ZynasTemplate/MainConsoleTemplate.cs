using System;
using System.Collections.Generic;
using System.Text;
using Zynas.Framework.Core.Base.Boundary;
using Zynas.Framework.Core.Base.Common;
using Zynas.Framework.Utility;

namespace $rootnamespace$
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MainConsole
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
    class MainConsole : BaseConsole
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： BaseConsole
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
        public MainConsole()
            : base()
        {
        }
        #endregion
        
        #region メソッド(public)

        #region CreateReport
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateReport
        /// <summary>
        /// 帳票を出力します。
        /// </summary>
        /// <param name="args">コマンド引数</param>
        /// <returns>帳票結果コード</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public int CreateReport(string[] args)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 帳票結果コード
            int reportResultCode = 0; 
            
            try
            {
                // TODO 実行メソッドを実装してください

            }
            catch
            {
                throw;
            }
            finally
            {
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return reportResultCode;
        }
        #endregion
        
        #endregion
    }
    #endregion
}
