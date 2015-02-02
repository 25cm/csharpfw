using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShokenMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShokenMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSyokenMstSearchBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSyokenMstSearchBySearchCondDAInput
    {
        /// <summary>
        /// 指摘区分
        /// </summary>
        string ShokenShitekiKbn { get; set; }

        /// <summary>
        /// 所見区分
        /// </summary>
        string ShokenKbn { get; set; }

        /// <summary>
        /// 所見文章
        /// </summary>
        string ShokenWd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSyokenMstSearchBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSyokenMstSearchBySearchCondDAInput : ISelectSyokenMstSearchBySearchCondDAInput
    {
        /// <summary>
        /// 指摘区分
        /// </summary>
        public string ShokenShitekiKbn { get; set; }

        /// <summary>
        /// 所見区分
        /// </summary>
        public string ShokenKbn { get; set; }

        /// <summary>
        /// 所見文章
        /// </summary>
        public string ShokenWd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSyokenMstSearchBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSyokenMstSearchBySearchCondDAOutput
    {
        /// <summary>
        /// SyokenMstSearchListDataTable
        /// </summary>
        ShokenMstDataSet.SyokenMstSearchListDataTable SyokenMstSearchListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSyokenMstSearchBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSyokenMstSearchBySearchCondDAOutput : ISelectSyokenMstSearchBySearchCondDAOutput
    {
        /// <summary>
        /// SyokenMstSearchListDataTable
        /// </summary>
        public ShokenMstDataSet.SyokenMstSearchListDataTable SyokenMstSearchListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSyokenMstSearchBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSyokenMstSearchBySearchCondDataAccess : BaseDataAccess<ISelectSyokenMstSearchBySearchCondDAInput, ISelectSyokenMstSearchBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SyokenMstSearchListTableAdapter tableAdapter = new SyokenMstSearchListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSyokenMstSearchBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSyokenMstSearchBySearchCondDataAccess()
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
        /// 2014/09/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSyokenMstSearchBySearchCondDAOutput Execute(ISelectSyokenMstSearchBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSyokenMstSearchBySearchCondDAOutput output = new SelectSyokenMstSearchBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SyokenMstSearchListDT = tableAdapter.GetDataBySearchCond(input.ShokenShitekiKbn, 
                                                                                input.ShokenKbn, 
                                                                                DataAccessUtility.EscapeSQLString(input.ShokenWd));

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
