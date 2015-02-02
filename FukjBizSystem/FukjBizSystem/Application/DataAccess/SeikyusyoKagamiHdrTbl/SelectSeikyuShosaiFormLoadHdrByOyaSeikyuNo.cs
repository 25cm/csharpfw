using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SeikyusyoKagamiHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyushoKagamiHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAInput
    {
        /// <summary>
        /// 親請求No
        /// </summary>
        string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAInput : ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAInput
    {
        /// <summary>
        /// 親請求No
        /// </summary>
        public string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput
    {
        /// <summary>
        /// SeikyuShosaiFormLoadHdrDataTable
        /// </summary>
        SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrDataTable SeikyuShosaiFormLoadHdrDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput : ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput
    {
        /// <summary>
        /// SeikyuShosaiFormLoadHdrDataTable
        /// </summary>
        public SeikyusyoKagamiHdrTblDataSet.SeikyuShosaiFormLoadHdrDataTable SeikyuShosaiFormLoadHdrDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDataAccess : BaseDataAccess<ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAInput, ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyuShosaiFormLoadHdrTableAdapter tableAdapter = new SeikyuShosaiFormLoadHdrTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDataAccess()
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
        /// 2014/11/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput Execute(ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput output = new SelectSeikyuShosaiFormLoadHdrByOyaSeikyuNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SeikyuShosaiFormLoadHdrDT = tableAdapter.GetDataByOyaSeikyuNo(input.OyaSeikyuNo);

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
