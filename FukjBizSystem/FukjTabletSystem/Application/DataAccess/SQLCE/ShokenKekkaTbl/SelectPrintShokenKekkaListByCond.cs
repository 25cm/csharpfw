using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.ShokenKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectPrintShokenKekkaListByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrintShokenKekkaListByCondDAInput
    {
        /// <summary>
        /// KensaIraiShokanIraiHoteiKbn
        /// </summary>
        string KensaIraiShokanIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiHokenjoCd 
        /// </summary>
        string KensaIraiShokenIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiNendo
        /// </summary>
        string KensaIraiShokenIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiRenban
        /// </summary>
        string KensaIraiShokenIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintShokenKekkaListByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintShokenKekkaListByCondDAInput : ISelectPrintShokenKekkaListByCondDAInput
    {
        /// <summary>
        /// KensaIraiShokanIraiHoteiKbn
        /// </summary>
        public string KensaIraiShokanIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiHokenjoCd 
        /// </summary>
        public string KensaIraiShokenIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiNendo
        /// </summary>
        public string KensaIraiShokenIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiRenban
        /// </summary>
        public string KensaIraiShokenIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectPrintShokenKekkaListByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrintShokenKekkaListByCondDAOutput
    {
        /// <summary>
        /// PrintShokenKekkaListDataTable
        /// </summary>
        ShokenKekkaTblDataSet.PrintShokenKekkaListDataTable PrintShokenKekkaListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintShokenKekkaListByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintShokenKekkaListByCondDAOutput : ISelectPrintShokenKekkaListByCondDAOutput
    {
        /// <summary>
        /// PrintShokenKekkaListDataTable
        /// </summary>
        public ShokenKekkaTblDataSet.PrintShokenKekkaListDataTable PrintShokenKekkaListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintShokenKekkaListByCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintShokenKekkaListByCondDataAccess : BaseDataAccessCe<ISelectPrintShokenKekkaListByCondDAInput, ISelectPrintShokenKekkaListByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private PrintShokenKekkaListTableAdapter tableAdapter = new PrintShokenKekkaListTableAdapter();


        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectPrintShokenKekkaListByCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectPrintShokenKekkaListByCondDataAccess()
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
        /// 2014/10/14  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectPrintShokenKekkaListByCondDAOutput Execute(ISelectPrintShokenKekkaListByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectPrintShokenKekkaListByCondDAOutput output = new SelectPrintShokenKekkaListByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.PrintShokenKekkaListDataTable = tableAdapter.GetDataByCond(input.KensaIraiShokanIraiHoteiKbn,
                                                                                input.KensaIraiShokenIraiHokenjoCd,
                                                                                input.KensaIraiShokenIraiNendo,
                                                                                input.KensaIraiShokenIraiRenban);
                                                

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
