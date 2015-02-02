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
    //  インターフェイス名 ： ISelectCenterKeikokuListByShishoCdDAInput
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
    interface ISelectCenterKeikokuListByShishoCdDAInput
    {
        /// <summary>
        /// ShishoCd 
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// KensaDateBefore 
        /// </summary>
        string KensaDateBefore { get; set; }

        /// <summary>
        /// ShiyoKaishiDateBefore 
        /// </summary>
        string ShiyoKaishiDateBefore { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectCenterKeikokuListByShishoCdDAInput
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
    class SelectCenterKeikokuListByShishoCdDAInput : ISelectCenterKeikokuListByShishoCdDAInput
    {
        /// <summary>
        /// ShishoCd 
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// KensaDateBefore 
        /// </summary>
        public string KensaDateBefore { get; set; }

        /// <summary>
        /// ShiyoKaishiDateBefore 
        /// </summary>
        public string ShiyoKaishiDateBefore { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectCenterKeikokuListByShishoCdDAOutput
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
    interface ISelectCenterKeikokuListByShishoCdDAOutput
    {
        /// <summary>
        /// CenterKeikokuListDataTable
        /// </summary>
        KensaIraiTblDataSet.CenterKeikokuListDataTable CenterKeikokuListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectCenterKeikokuListByShishoCdDAOutput
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
    class SelectCenterKeikokuListByShishoCdDAOutput : ISelectCenterKeikokuListByShishoCdDAOutput
    {
        /// <summary>
        /// CenterKeikokuListDataTable
        /// </summary>
        public KensaIraiTblDataSet.CenterKeikokuListDataTable CenterKeikokuListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectCenterKeikokuListByShishoCdDataAccess
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
    class SelectCenterKeikokuListByShishoCdDataAccess : BaseDataAccess<ISelectCenterKeikokuListByShishoCdDAInput, ISelectCenterKeikokuListByShishoCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private CenterKeikokuListTableAdapter tableAdapter = new CenterKeikokuListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectCenterKeikokuListByShishoCdDataAccess
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
        public SelectCenterKeikokuListByShishoCdDataAccess()
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
        public override ISelectCenterKeikokuListByShishoCdDAOutput Execute(ISelectCenterKeikokuListByShishoCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectCenterKeikokuListByShishoCdDAOutput output = new SelectCenterKeikokuListByShishoCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 20150127 sou Start
                //output.CenterKeikokuListDataTable = tableAdapter.GetDataByShishoCd(input.ShishoCd, input.KensaDateBefore, input.ShiyoKaishiDateBefore);
                output.CenterKeikokuListDataTable = tableAdapter.GetDataBySearchCond(input.ShishoCd, input.KensaDateBefore, input.ShiyoKaishiDateBefore);
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
