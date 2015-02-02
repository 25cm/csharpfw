using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuKensaSetMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuKensaSetMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuKensaSetMstInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuKensaSetMstInfoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuKensaSetMstInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuKensaSetMstInfoDAInput : ISelectSuishitsuKensaSetMstInfoDAInput
    {
        
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuKensaSetMstInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuKensaSetMstInfoDAOutput
    {
        /// <summary>
        /// 水質検査セットマスタ
        /// </summary>
        SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable SuishitsuKensaSetMstDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuKensaSetMstInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuKensaSetMstInfoDAOutput : ISelectSuishitsuKensaSetMstInfoDAOutput
    {
        /// <summary>
        /// 水質検査セットマスタ
        /// </summary>
        public SuishitsuKensaSetMstDataSet.SuishitsuKensaSetMstDataTable SuishitsuKensaSetMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuKensaSetMstInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuKensaSetMstInfoDataAccess : BaseDataAccess<ISelectSuishitsuKensaSetMstInfoDAInput, ISelectSuishitsuKensaSetMstInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuKensaSetMstTableAdapter tableAdapter
            = new SuishitsuKensaSetMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSuishitsuKensaSetMstInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSuishitsuKensaSetMstInfoDataAccess()
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
        /// 2014/12/10　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSuishitsuKensaSetMstInfoDAOutput Execute(ISelectSuishitsuKensaSetMstInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSuishitsuKensaSetMstInfoDAOutput output = new SelectSuishitsuKensaSetMstInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SuishitsuKensaSetMstDataTable = tableAdapter.GetData();
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
