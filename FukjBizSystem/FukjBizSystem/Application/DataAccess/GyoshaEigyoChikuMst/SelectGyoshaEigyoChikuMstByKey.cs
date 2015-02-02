using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GyoshaEigyoChikuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.GyoshaEigyoChikuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGyoshaEigyoChikuMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectGyoshaEigyoChikuMstByKeyDAInput
    {
        /// <summary>
        /// 業者コード
        /// </summary>
        string GyoshaEigyoChikuGyoshaCd { get; set; }

        // DEL 20140804 START ZynasSou
        ///// <summary>
        ///// 連番
        ///// </summary>
        //string GyoshaEigyoChikuRenban { get; set; }
        // DEL 20140804 END ZynasSou
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGyoshaEigyoChikuMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGyoshaEigyoChikuMstByKeyDAInput : ISelectGyoshaEigyoChikuMstByKeyDAInput
    {
        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaEigyoChikuGyoshaCd { get; set; }

        // DEL 20140804 START ZynasSou
        ///// <summary>
        ///// 連番
        ///// </summary>
        //public string GyoshaEigyoChikuRenban { get; set; }
        // DEL 20140804 END ZynasSou
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGyoshaEigyoChikuMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectGyoshaEigyoChikuMstByKeyDAOutput
    {
        /// <summary>
        /// GyoshaEigyoChikuMstDataTable
        /// </summary>
        GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstDataTable GyoshaEigyoChikuMstDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGyoshaEigyoChikuMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGyoshaEigyoChikuMstByKeyDAOutput : ISelectGyoshaEigyoChikuMstByKeyDAOutput
    {
        /// <summary>
        /// GyoshaEigyoChikuMstDataTable
        /// </summary>
        public GyoshaEigyoChikuMstDataSet.GyoshaEigyoChikuMstDataTable GyoshaEigyoChikuMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGyoshaEigyoChikuMstByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGyoshaEigyoChikuMstByKeyDataAccess : BaseDataAccess<ISelectGyoshaEigyoChikuMstByKeyDAInput, ISelectGyoshaEigyoChikuMstByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private GyoshaEigyoChikuMstTableAdapter tableAdapter = new GyoshaEigyoChikuMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectGyoshaEigyoChikuMstByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectGyoshaEigyoChikuMstByKeyDataAccess()
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
        /// 2014/07/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectGyoshaEigyoChikuMstByKeyDAOutput Execute(ISelectGyoshaEigyoChikuMstByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectGyoshaEigyoChikuMstByKeyDAOutput output = new SelectGyoshaEigyoChikuMstByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // UPD 20140804 START ZynasSou
                //output.GyoshaEigyoChikuMstDataTable = tableAdapter.GetDataByKey(input.GyoshaEigyoChikuGyoshaCd, input.GyoshaEigyoChikuRenban);
                output.GyoshaEigyoChikuMstDataTable = tableAdapter.GetDataByKey(input.GyoshaEigyoChikuGyoshaCd);
                // UPD 20140804 END ZynasSou
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
