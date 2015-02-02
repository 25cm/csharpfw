using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKekkaNmMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuKekkaNmMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuKekkaNmMstBySearchCondFromToDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06　宗　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuKekkaNmMstBySearchCondFromToDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// 水質結果名称コード(開始)
        /// </summary>
        string SuishitsuKekkaNmCdFrom { get; set; }

        /// <summary>
        /// 水質結果名称コード(終了)
        /// </summary>
        string SuishitsuKekkaNmCdTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuKekkaNmMstBySearchCondFromToDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06　宗　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuKekkaNmMstBySearchCondFromToDAInput : ISelectSuishitsuKekkaNmMstBySearchCondFromToDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 水質結果名称コード(開始)
        /// </summary>
        public string SuishitsuKekkaNmCdFrom { get; set; }

        /// <summary>
        /// 水質結果名称コード(終了)
        /// </summary>
        public string SuishitsuKekkaNmCdTo { get; set; }

        /// <summary>
        /// 水質結果名称
        /// </summary>
        public string SuishitsuKekkaNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06　宗　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput
    {
        /// <summary>
        /// SuishitsuKekkaNmMstDT
        /// </summary>
        SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable SuishitsuKekkaNmMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06　宗　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput : ISelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput
    {
        /// <summary>
        /// SuishitsuKekkaNmMstDT
        /// </summary>
        public SuishitsuKekkaNmMstDataSet.SuishitsuKekkaNmMstDataTable SuishitsuKekkaNmMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuKekkaNmMstBySearchCondFromToDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/06　宗　  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuKekkaNmMstBySearchCondFromToDataAccess : BaseDataAccess<ISelectSuishitsuKekkaNmMstBySearchCondFromToDAInput, ISelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuKekkaNmMstTableAdapter tableAdapter = new SuishitsuKekkaNmMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSuishitsuKekkaNmMstBySearchCondFromToDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/06　宗　  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSuishitsuKekkaNmMstBySearchCondFromToDataAccess()
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
        /// 2015/01/06　宗　  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput Execute(ISelectSuishitsuKekkaNmMstBySearchCondFromToDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput output = new SelectSuishitsuKekkaNmMstBySearchCondFromToDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SuishitsuKekkaNmMstDT = tableAdapter.GetDataBySearchCondFromTo(input.ShishoCd, input.SuishitsuKekkaNmCdFrom, input.SuishitsuKekkaNmCdTo);

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
