using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JinendoGaikanYoteiOutputTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.JinendoGaikanYoteiOutputTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoGaikanYoteiPrintByNendoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanYoteiPrintByNendoDAInput
    {
        /// <summary>
        /// 検査予定年
        /// </summary>
        string Nendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanYoteiPrintByNendoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanYoteiPrintByNendoDAInput : ISelectJinendoGaikanYoteiPrintByNendoDAInput
    {
        /// <summary>
        /// 検査予定年
        /// </summary>
        public string Nendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoGaikanYoteiPrintByNendoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanYoteiPrintByNendoDAOutput
    {
        /// <summary>
        /// JinendoGaikanYoteiPrintDataTable
        /// </summary>
        JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiPrintDataTable JinendoGaikanYoteiPrintDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanYoteiPrintByNendoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanYoteiPrintByNendoDAOutput : ISelectJinendoGaikanYoteiPrintByNendoDAOutput
    {
        /// <summary>
        /// JinendoGaikanYoteiPrintDataTable
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiPrintDataTable JinendoGaikanYoteiPrintDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanYoteiPrintByNendoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanYoteiPrintByNendoDataAccess : BaseDataAccess<ISelectJinendoGaikanYoteiPrintByNendoDAInput, ISelectJinendoGaikanYoteiPrintByNendoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JinendoGaikanYoteiPrintTableAdapter tableAdapter
            = new JinendoGaikanYoteiPrintTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJinendoGaikanYoteiPrintByNendoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/25　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJinendoGaikanYoteiPrintByNendoDataAccess()
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
        /// 2014/11/25　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJinendoGaikanYoteiPrintByNendoDAOutput Execute(ISelectJinendoGaikanYoteiPrintByNendoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJinendoGaikanYoteiPrintByNendoDAOutput output = new SelectJinendoGaikanYoteiPrintByNendoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JinendoGaikanYoteiPrintDataTable = tableAdapter.GetDataByNendo(input.Nendo);
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
