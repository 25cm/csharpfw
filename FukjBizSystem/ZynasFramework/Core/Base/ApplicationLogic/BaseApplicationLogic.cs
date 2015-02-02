using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.Common;

namespace Zynas.Framework.Core.Base.ApplicationLogic
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IBseALInput
    /// <summary>
    /// ベースアプリケーションロジックの入力インターフェイス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/12　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface IBseALInput
    {
        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        string DataString
        {
            get;
        }
    }
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28　habu　　    新規作成
    /// </history>
    public class IBseALInputImpl : IBseALInput
    {

        public string DataString
        {
            get
            {
                return CreateStdDataString();
            }
        }

        /// <summary>
        /// Create standard DataString using runtime infomation
        /// </summary>
        /// <returns></returns>
        public string CreateStdDataString()
        {
            StringBuilder dstrBuf = new StringBuilder();

            PropertyInfo[] propInfoes = this.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);

            foreach (PropertyInfo propInfo in propInfoes)
            {
                // NOTICE 呼出元(DataString)と同じプロパティ名はスキップする(must be same as caller propertyname)
                if (propInfo.Name == "DataString") { continue; }

                object val = propInfo.GetValue(this, null);

                dstrBuf.AppendFormat("{0} = [{1}], ", propInfo.Name, val);
            }

            return dstrBuf.ToString();
        }
    }

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： BaseApplicationLogic
    /// <summary>
    /// ベースアプリケーションロジッククラス
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2010/04/12　稗田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public abstract class BaseApplicationLogic<INPUT, OUTPUT>
    {
        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/04/12　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected abstract string GetFunctionName();
        #endregion

        #region StartTransaction
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： StartTransaction
        /// <summary>
        /// トランザクション開始
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void StartTransaction(params int[] timeout)
        {
            TransactionManager.CreateTran(timeout);
        }
        #endregion

        #region EndTransaction
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： EndTransaction
        /// <summary>
        /// トランザクション終了
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void EndTransaction()
        {
            TransactionManager.ReleaseTran();
        }
        #endregion

        #region CompleteTransaction
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： CompleteTransaction
        /// <summary>
        /// トランザクション完了
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2010/05/20　稗田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void CompleteTransaction()
        {
            TransactionManager.CompleteTran();
        }
        #endregion

        #region StartTransactionCe
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： StartTransactionCe
        /// <summary>
        /// トランザクション開始
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void StartTransactionCe(params int[] timeout)
        {
            TransactionManagerCe.CreateTran(timeout);
        }
        #endregion

        #region EndTransactionCe
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： EndTransactionCe
        /// <summary>
        /// トランザクション終了
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void EndTransactionCe()
        {
            TransactionManagerCe.ReleaseTran();
        }
        #endregion

        #region CompleteTransactionCe
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： CompleteTransactionCe
        /// <summary>
        /// トランザクション完了
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/20　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected void CompleteTransactionCe()
        {
            TransactionManagerCe.CompleteTran();
        }
        #endregion

        #endregion

        #region メソッド(public)

        #region Execute
        ////////////////////////////////////////////////////////////////////////////
        //  クラス名 ： Execute
        /// <summary>
        /// アプリケーションロジックの実行
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
