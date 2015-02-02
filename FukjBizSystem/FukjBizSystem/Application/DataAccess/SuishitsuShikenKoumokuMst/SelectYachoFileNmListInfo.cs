using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKensaUketsukeDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataSet.SuishitsuShikenKoumokuMstDataSetTableAdapters;

namespace FukjBizSystem.Application.DataAccess.SuishitsuShikenKoumokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYachoFileNmListInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/19  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYachoFileNmListInfoDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYachoFileNmListInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/19  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYachoFileNmListInfoDAInput : ISelectYachoFileNmListInfoDAInput
    {

    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYachoFileNmListInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/19  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYachoFileNmListInfoDAOutput
    {
        /// <summary>
        /// 水質試験項目－野帳一覧
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.YachoFileNmListInfoDataTable YachoListInfoDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYachoFileNmListInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/19  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYachoFileNmListInfoDAOutput : ISelectYachoFileNmListInfoDAOutput
    {
        /// <summary>
        /// 水質試験項目－野帳一覧
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.YachoFileNmListInfoDataTable YachoListInfoDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYachoFileNmListInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/19  小松　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYachoFileNmListInfoDataAccess : BaseDataAccess<ISelectYachoFileNmListInfoDAInput, ISelectYachoFileNmListInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private YachoFileNmListInfoTableAdapter tableAdapter = new YachoFileNmListInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectYachoFileNmListInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/19  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectYachoFileNmListInfoDataAccess()
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
        /// 2014/12/19  小松　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectYachoFileNmListInfoDAOutput Execute(ISelectYachoFileNmListInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectYachoFileNmListInfoDAOutput output = new SelectYachoFileNmListInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.YachoListInfoDT = tableAdapter.GetData();

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
