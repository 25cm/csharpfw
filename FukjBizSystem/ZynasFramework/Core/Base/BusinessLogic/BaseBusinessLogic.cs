
namespace Zynas.Framework.Core.Base.BusinessLogic
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： BaseBusinessLogic
    /// <summary>
    /// ベースビジネスロジッククラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/12　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public abstract class BaseBusinessLogic<INPUT, OUTPUT>
    {
        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： Execute
        /// <summary>
        /// ベースビジネスロジックの実行
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>戻り値</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/12　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public abstract OUTPUT Execute(INPUT input);
        #endregion

        #endregion
    }
    #endregion
}
