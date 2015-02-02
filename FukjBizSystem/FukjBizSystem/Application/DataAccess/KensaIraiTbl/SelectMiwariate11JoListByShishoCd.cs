using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMiwariate11JoListByShishoCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMiwariate11JoListByShishoCdDAInput
    {
        /// <summary>
        /// ShishoCd 
        /// </summary>
        string ShishoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMiwariate11JoListByShishoCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMiwariate11JoListByShishoCdDAInput : ISelectMiwariate11JoListByShishoCdDAInput
    {
        /// <summary>
        /// ShishoCd 
        /// </summary>
        public string ShishoCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMiwariate11JoListByShishoCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMiwariate11JoListByShishoCdDAOutput
    {
        /// <summary>
        /// Miwariate11JoListDataTable
        /// </summary>
        KensaIraiTblDataSet.Miwariate11JoListDataTable Miwariate11JoListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMiwariate11JoListByShishoCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMiwariate11JoListByShishoCdDAOutput : ISelectMiwariate11JoListByShishoCdDAOutput
    {
        /// <summary>
        /// Miwariate11JoListDataTable
        /// </summary>
        public KensaIraiTblDataSet.Miwariate11JoListDataTable Miwariate11JoListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMiwariate11JoListByShishoCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMiwariate11JoListByShishoCdDataAccess : BaseDataAccess<ISelectMiwariate11JoListByShishoCdDAInput, ISelectMiwariate11JoListByShishoCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private Miwariate11JoListTableAdapter tableAdapter = new Miwariate11JoListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMiwariate11JoListByShishoCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectMiwariate11JoListByShishoCdDataAccess()
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
        /// 2014/12/23  豊田　　    新規作成
        /// 2015/01/27  宗          支所コードが空の場合は全検索
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectMiwariate11JoListByShishoCdDAOutput Execute(ISelectMiwariate11JoListByShishoCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMiwariate11JoListByShishoCdDAOutput output = new SelectMiwariate11JoListByShishoCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 20150127 sou Start
                //output.Miwariate11JoListDataTable = tableAdapter.GetDataByShishoCd(input.ShishoCd);
                output.Miwariate11JoListDataTable = tableAdapter.GetDataBySearchCond(input.ShishoCd);
                // 20150127 sou End

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
