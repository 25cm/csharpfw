using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.JokasoDaichiRirekiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.Sync.JokasoDaichiRirekiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMaxJokasoRirekiRenbanDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface ISelectMaxJokasoRirekiRenbanDAInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// TorokuNendo
        /// </summary>
        string TorokuNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        string Renban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaxJokasoRirekiRenbanDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SelectMaxJokasoRirekiRenbanDAInput : ISelectMaxJokasoRirekiRenbanDAInput
    {
        /// <summary>
        /// HokenjoCd
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// TorokuNendo
        /// </summary>
        public string TorokuNendo { get; set; }

        /// <summary>
        /// Renban
        /// </summary>
        public string Renban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMaxJokasoRirekiRenbanDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public interface ISelectMaxJokasoRirekiRenbanDAOutput
    {
        /// <summary>
        /// MaxJokasoRirekiRenban
        /// </summary>
        string MaxJokasoRirekiRenban { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaxJokasoRirekiRenbanDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SelectMaxJokasoRirekiRenbanDAOutput : ISelectMaxJokasoRirekiRenbanDAOutput
    {
        /// <summary>
        /// MaxJokasoRirekiRenban
        /// </summary>
        public string MaxJokasoRirekiRenban { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaxJokasoRirekiRenbanDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public class SelectMaxJokasoRirekiRenbanDataAccess : BaseDataAccess<ISelectMaxJokasoRirekiRenbanDAInput, ISelectMaxJokasoRirekiRenbanDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JokasoDaichiRirekiTblTableAdapter tableAdapter = new JokasoDaichiRirekiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMaxJokasoRirekiRenbanDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectMaxJokasoRirekiRenbanDataAccess()
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
        /// 2014/12/02　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectMaxJokasoRirekiRenbanDAOutput Execute(ISelectMaxJokasoRirekiRenbanDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMaxJokasoRirekiRenbanDAOutput output = new SelectMaxJokasoRirekiRenbanDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.MaxJokasoRirekiRenban = tableAdapter.GetMaxJokasoRirekiRenban(input.HokenjoCd, input.TorokuNendo, input.Renban);

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
