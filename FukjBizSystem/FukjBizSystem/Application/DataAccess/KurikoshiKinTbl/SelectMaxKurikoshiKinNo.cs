using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.KurikoshiKinTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KurikoshiKinTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMaxKurikoshiKinNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMaxKurikoshiKinNoDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaxKurikoshiKinNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMaxKurikoshiKinNoDAInput : ISelectMaxKurikoshiKinNoDAInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMaxKurikoshiKinNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMaxKurikoshiKinNoDAOutput
    {
        /// <summary>
        /// MaxKurikoshikinNo
        /// </summary>
        string MaxKurikoshikinNo { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaxKurikoshiKinNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMaxKurikoshiKinNoDAOutput : ISelectMaxKurikoshiKinNoDAOutput
    {
        /// <summary>
        /// MaxKurikoshikinNo
        /// </summary>
        public string MaxKurikoshikinNo { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaxKurikoshiKinNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/26  豊田　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMaxKurikoshiKinNoDataAccess : BaseDataAccess<ISelectMaxKurikoshiKinNoDAInput, ISelectMaxKurikoshiKinNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KurikoshiKinTblTableAdapter tableAdapter = new KurikoshiKinTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMaxKurikoshiKinNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/26  豊田　      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectMaxKurikoshiKinNoDataAccess()
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
        /// 2014/12/26  豊田　      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectMaxKurikoshiKinNoDAOutput Execute(ISelectMaxKurikoshiKinNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMaxKurikoshiKinNoDAOutput output = new SelectMaxKurikoshiKinNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.MaxKurikoshikinNo = tableAdapter.GetMaxKurikoshikinNo();

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
