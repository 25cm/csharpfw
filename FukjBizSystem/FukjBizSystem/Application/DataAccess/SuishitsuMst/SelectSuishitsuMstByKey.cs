using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuMstByKeyDAInput
    {
        /// <summary>
        /// SuishitsuCd
        /// </summary>
        String SuishitsuCd { get; set; }

        /// <summary>
        /// SuishitsuShishoCd
        /// </summary>
        String SuishitsuShishoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuMstByKeyDAInput : ISelectSuishitsuMstByKeyDAInput
    {
        /// <summary>
        /// SuishitsuCd
        /// </summary>
        public String SuishitsuCd { get; set; }

        /// <summary>
        /// SuishitsuShishoCd
        /// </summary>
        public String SuishitsuShishoCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuMstByKeyDAOutput
    {
        /// <summary>
        /// SuishitsuMstDataTable
        /// </summary>
        SuishitsuMstDataSet.SuishitsuMstDataTable SuishitsuMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuMstByKeyDAOutput : ISelectSuishitsuMstByKeyDAOutput
    {
        /// <summary>
        /// SuishitsuMstDataTable
        /// </summary>
        public SuishitsuMstDataSet.SuishitsuMstDataTable SuishitsuMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuMstByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/24  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuMstByKeyDataAccess : BaseDataAccess<ISelectSuishitsuMstByKeyDAInput, ISelectSuishitsuMstByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuMstTableAdapter tableAdapter = new SuishitsuMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSuishitsuMstByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSuishitsuMstByKeyDataAccess()
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
        /// 2014/06/24  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSuishitsuMstByKeyDAOutput Execute(ISelectSuishitsuMstByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSuishitsuMstByKeyDAOutput output = new SelectSuishitsuMstByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SuishitsuMstDT = tableAdapter.GetDataByKey(input.SuishitsuShishoCd, input.SuishitsuCd);

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
