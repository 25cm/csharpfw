using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.NyukinTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NyukinTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/010  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAInput
    {
        /// <summary>
        /// 入金日
        /// </summary>
        string NyukinDt { get; set; }

        /// <summary>
        /// 連携No
        /// </summary>
        string NyukinRenkeiNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNyukinTblByNyukinDtNyukinRenkeiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/010  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNyukinTblByNyukinDtNyukinRenkeiNoDAInput : ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAInput
    {
        /// <summary>
        /// 入金日
        /// </summary>
        public string NyukinDt { get; set; }

        /// <summary>
        /// 連携No
        /// </summary>
        public string NyukinRenkeiNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/010  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAOutput
    {
        /// <summary>
        /// NyukinTblDataTable
        /// </summary>
        NyukinTblDataSet.NyukinTblDataTable NyukinTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNyukinTblByNyukinDtNyukinRenkeiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/010  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNyukinTblByNyukinDtNyukinRenkeiNoDAOutput : ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAOutput
    {
        /// <summary>
        /// NyukinTblDataTable
        /// </summary>
        public NyukinTblDataSet.NyukinTblDataTable NyukinTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNyukinTblByNyukinDtNyukinRenkeiNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/010  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectNyukinTblByNyukinDtNyukinRenkeiNoDataAccess : BaseDataAccess<ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAInput, ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NyukinTblTableAdapter tableAdapter = new NyukinTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectNyukinTblByNyukinDtNyukinRenkeiNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/010  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectNyukinTblByNyukinDtNyukinRenkeiNoDataAccess()
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
        /// 2014/11/010  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAOutput Execute(ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectNyukinTblByNyukinDtNyukinRenkeiNoDAOutput output = new SelectNyukinTblByNyukinDtNyukinRenkeiNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.NyukinTblDT = tableAdapter.GetDataByNyukinDtNyukinRenkeiNo(input.NyukinDt, input.NyukinRenkeiNo);

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
