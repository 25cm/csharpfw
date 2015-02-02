using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KenchikuyotoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KenchikuyotoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKenchiKuyotoMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKenchiKuyotoMstByKeyDAInput
    {
        /// <summary>
        /// KenchikuyotoDaibunruiCd
        /// </summary>
        string HenchikuyotoDaibunruiCd { get; set; }

        /// <summary>
        /// KenchikuyotoShobunruiCd
        /// </summary>
        string KenchikuyotoShobunruiCd { get; set; }

        /// <summary>
        /// KenchikuyotoRenban
        /// </summary>
        int KenchikuyotoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKenchiKuyotoMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKenchiKuyotoMstByKeyDAInput : ISelectKenchiKuyotoMstByKeyDAInput
    {
        /// <summary>
        /// KenchikuyotoDaibunruiCd
        /// </summary>
        public string HenchikuyotoDaibunruiCd { get; set; }

        /// <summary>
        /// KenchikuyotoShobunruiCd
        /// </summary>
        public string KenchikuyotoShobunruiCd { get; set; }

        /// <summary>
        /// KenchikuyotoRenban
        /// </summary>
        public int KenchikuyotoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKenchiKuyotoMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKenchiKuyotoMstByKeyDAOutput
    {
        /// <summary>
        /// KenchikuyotoMstDataTable
        /// </summary>
        KenchikuyotoMstDataSet.KenchikuyotoMstDataTable KenchikuyotoMstDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKenchiKuyotoMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKenchiKuyotoMstByKeyDAOutput : ISelectKenchiKuyotoMstByKeyDAOutput
    {
        /// <summary>
        /// KenchikuyotoMstDataTable
        /// </summary>
        public KenchikuyotoMstDataSet.KenchikuyotoMstDataTable KenchikuyotoMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKenchiKuyotoMstByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKenchiKuyotoMstByKeyDataAccess : BaseDataAccess<ISelectKenchiKuyotoMstByKeyDAInput, ISelectKenchiKuyotoMstByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KenchikuyotoMstTableAdapter tableAdapter = new KenchikuyotoMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKenchiKuyotoMstByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKenchiKuyotoMstByKeyDataAccess()
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
        /// 2014/07/29　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKenchiKuyotoMstByKeyDAOutput Execute(ISelectKenchiKuyotoMstByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKenchiKuyotoMstByKeyDAOutput output = new SelectKenchiKuyotoMstByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KenchikuyotoMstDataTable = tableAdapter.GetDataByKey(input.HenchikuyotoDaibunruiCd, input.KenchikuyotoShobunruiCd, input.KenchikuyotoRenban);

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
