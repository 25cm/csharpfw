using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.GaikanKensaKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAInput
    {
        /// <summary>
        /// 指摘区分
        /// </summary>
        string ShokenShitekiKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAInput : ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAInput
    {
        /// <summary>
        /// 指摘区分
        /// </summary>
        public string ShokenShitekiKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput
    {
        /// <summary>
        /// SyokenKbnComboBoxSourceDataTable
        /// </summary>
        GaikanKensaKekkaTblDataSet.SyokenKbnComboBoxSourceDataTable SyokenKbnComboBoxSourceDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput : ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput
    {
        /// <summary>
        /// SyokenKbnComboBoxSourceDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.SyokenKbnComboBoxSourceDataTable SyokenKbnComboBoxSourceDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDataAccess : BaseDataAccess<ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAInput, ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SyokenKbnComboBoxSourceTableAdapter tableAdapter = new SyokenKbnComboBoxSourceTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDataAccess()
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
        /// 2014/09/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput Execute(ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput output = new SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SyokenKbnComboBoxSourceDT = tableAdapter.GetDataByShokenShitekiKbn(input.ShokenShitekiKbn);

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
