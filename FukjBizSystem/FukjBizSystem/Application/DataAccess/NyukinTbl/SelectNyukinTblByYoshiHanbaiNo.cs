using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.NyukinTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NyukinTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectNyukinTblByYoshiHanbaiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectNyukinTblByYoshiHanbaiNoDAInput
    {
        /// <summary>
        /// 用紙販売注文No
        /// </summary>
        string YoshiHanbaiNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNyukinTblByYoshiHanbaiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNyukinTblByYoshiHanbaiNoDAInput : ISelectNyukinTblByYoshiHanbaiNoDAInput
    {
        /// <summary>
        /// 用紙販売注文No
        /// </summary>
        public string YoshiHanbaiNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectNyukinTblByYoshiHanbaiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectNyukinTblByYoshiHanbaiNoDAOutput
    {
        /// <summary>
        /// 入金データ
        /// </summary>
        NyukinTblDataSet.NyukinTblDataTable NyukinTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNyukinTblByYoshiHanbaiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNyukinTblByYoshiHanbaiNoDAOutput : ISelectNyukinTblByYoshiHanbaiNoDAOutput
    {
        /// <summary>
        /// 入金データ
        /// </summary>
        public NyukinTblDataSet.NyukinTblDataTable NyukinTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNyukinTblByYoshiHanbaiNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNyukinTblByYoshiHanbaiNoDataAccess : BaseDataAccess<ISelectNyukinTblByYoshiHanbaiNoDAInput, ISelectNyukinTblByYoshiHanbaiNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NyukinTblTableAdapter tableAdapter = new NyukinTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectNyukinTblByYoshiHanbaiNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectNyukinTblByYoshiHanbaiNoDataAccess()
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
        /// 2014/10/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectNyukinTblByYoshiHanbaiNoDAOutput Execute(ISelectNyukinTblByYoshiHanbaiNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectNyukinTblByYoshiHanbaiNoDAOutput output = new SelectNyukinTblByYoshiHanbaiNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 用紙販売番号から入金データを取得
                output.NyukinTblDT = tableAdapter.GetDataByYoshiHanbaiNo(input.YoshiHanbaiNo);
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
