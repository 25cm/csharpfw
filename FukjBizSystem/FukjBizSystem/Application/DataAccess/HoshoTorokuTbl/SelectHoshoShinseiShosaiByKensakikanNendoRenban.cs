using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.HoshoTorokuTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.HoshoTorokuTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAInput
    {
        /// <summary>
        /// 保証登録検査機関
        /// </summary>
        string HoshoTorokuKensakikan { get; set; }

        /// <summary>
        /// 保証登録年度
        /// </summary>
        string HoshoTorokuNendo { get; set; }

        /// <summary>
        /// 保証登録連番
        /// </summary>
        string HoshoTorokuRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoshoShinseiShosaiByKensakikanNendoRenbanDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoshoShinseiShosaiByKensakikanNendoRenbanDAInput : ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAInput
    {
        /// <summary>
        /// 保証登録検査機関
        /// </summary>
        public string HoshoTorokuKensakikan { get; set; }

        /// <summary>
        /// 保証登録年度
        /// </summary>
        public string HoshoTorokuNendo { get; set; }

        /// <summary>
        /// 保証登録連番
        /// </summary>
        public string HoshoTorokuRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput
    {
        /// <summary>
        /// HoshoShinseiShosaiDataTable
        /// </summary>
        HoshoTorokuTblDataSet.HoshoShinseiShosaiDataTable HoshoShinseiShosaiDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput : ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput
    {
        /// <summary>
        /// HoshoShinseiShosaiDataTable
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoShinseiShosaiDataTable HoshoShinseiShosaiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoshoShinseiShosaiByKensakikanNendoRenbanDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoshoShinseiShosaiByKensakikanNendoRenbanDataAccess : BaseDataAccess<ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAInput, ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private HoshoShinseiShosaiTableAdapter tableAdapter = new HoshoShinseiShosaiTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectHoshoShinseiShosaiByKensakikanNendoRenbanDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectHoshoShinseiShosaiByKensakikanNendoRenbanDataAccess()
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
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput Execute(ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput output = new SelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.HoshoShinseiShosaiDataTable = tableAdapter.GetDataByKensakikanNendoRenban(
                    input.HoshoTorokuKensakikan, input.HoshoTorokuNendo, input.HoshoTorokuRenban);
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
