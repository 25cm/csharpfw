﻿using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.JokasoDaichoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaIraishoOutputListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraishoOutputListBySearchCondDAInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        KensaIraishoOutputSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraishoOutputListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraishoOutputListBySearchCondDAInput : ISelectKensaIraishoOutputListBySearchCondDAInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public KensaIraishoOutputSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaIraishoOutputListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraishoOutputListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaIraishoOutputListDataTable
        /// </summary>
        JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable KensaIraishoOutputListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraishoOutputListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraishoOutputListBySearchCondDAOutput : ISelectKensaIraishoOutputListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaIraishoOutputListDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.KensaIraishoOutputListDataTable KensaIraishoOutputListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraishoOutputListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraishoOutputListBySearchCondDataAccess : BaseDataAccess<ISelectKensaIraishoOutputListBySearchCondDAInput, ISelectKensaIraishoOutputListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaIraishoOutputListTableAdapter tableAdapter = new KensaIraishoOutputListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaIraishoOutputListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaIraishoOutputListBySearchCondDataAccess()
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
        /// 2014/12/02  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaIraishoOutputListBySearchCondDAOutput Execute(ISelectKensaIraishoOutputListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaIraishoOutputListBySearchCondDAOutput output = new SelectKensaIraishoOutputListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaIraishoOutputListDataTable = tableAdapter.GetDataBySearchCond(input.SearchCond);

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