using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.ConstMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.ConstMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectConstMstByKbnValueDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectConstMstByKbnValueDAInput
    {
        /// <summary>
        /// 定数区分
        /// </summary>
        string ConstKbn { get; set; }

        /// <summary>
        /// 定数値
        /// </summary>
        string ConstValue { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectConstMstByKbnValueDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectConstMstByKbnValueDAInput : ISelectConstMstByKbnValueDAInput
    {
        /// <summary>
        /// 定数区分
        /// </summary>
        public string ConstKbn { get; set; }

        /// <summary>
        /// 定数値
        /// </summary>
        public string ConstValue { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectConstMstByKbnValueDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectConstMstByKbnValueDAOutput
    {
        /// <summary>
        /// ConstMstDataTable
        /// </summary>
        ConstMstDataSet.ConstMstDataTable ConstMst { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectConstMstByKbnValueDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectConstMstByKbnValueDAOutput : ISelectConstMstByKbnValueDAOutput
    {
        /// <summary>
        /// ConstMstDataTable
        /// </summary>
        public ConstMstDataSet.ConstMstDataTable ConstMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectConstMstByKbnValueDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectConstMstByKbnValueDataAccess : BaseDataAccessCe<ISelectConstMstByKbnValueDAInput, ISelectConstMstByKbnValueDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ConstMstTableAdapter tableAdapter = new ConstMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectConstMstByKbnValueDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　豊田　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectConstMstByKbnValueDataAccess()
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
        /// 2014/11/04　豊田　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectConstMstByKbnValueDAOutput Execute(ISelectConstMstByKbnValueDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectConstMstByKbnValueDAOutput output = new SelectConstMstByKbnValueDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ConstMst = tableAdapter.GetDataByKbnValue(input.ConstKbn, input.ConstValue);

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
