using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.MemoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.MemoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMemoMstSearchBySearchCondDAInput
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
    interface ISelectMemoMstSearchBySearchCondDAInput
    {
        /// <summary>
        /// 大分類コード（開始）
        /// </summary>
        string MemoDaibunruiCdFrom { get; set; }

        /// <summary>
        /// 大分類コード（終了）
        /// </summary>
        string MemoDaibunruiCdTo { get; set; }

        /// <summary>
        /// メモコード（開始）
        /// </summary>
        string MemoCdFrom { get; set; }

        /// <summary>
        /// メモコード（終了）
        /// </summary>
        string MemoCdTo { get; set; }

        /// <summary>
        /// メモ内容
        /// </summary>
        string Memo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMemoMstSearchBySearchCondDAInput
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
    class SelectMemoMstSearchBySearchCondDAInput : ISelectMemoMstSearchBySearchCondDAInput
    {
        /// <summary>
        /// 大分類コード（開始）
        /// </summary>
        public string MemoDaibunruiCdFrom { get; set; }

        /// <summary>
        /// 大分類コード（終了）
        /// </summary>
        public string MemoDaibunruiCdTo { get; set; }

        /// <summary>
        /// メモコード（開始）
        /// </summary>
        public string MemoCdFrom { get; set; }

        /// <summary>
        /// メモコード（終了）
        /// </summary>
        public string MemoCdTo { get; set; }

        /// <summary>
        /// メモ内容
        /// </summary>
        public string Memo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMemoMstSearchBySearchCondDAOutput
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
    interface ISelectMemoMstSearchBySearchCondDAOutput
    {
        /// <summary>
        /// MemoMstSearchListDataTable
        /// </summary>
        MemoMstDataSet.MemoMstSearchListDataTable MemoMstSearchListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMemoMstSearchBySearchCondDAOutput
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
    class SelectMemoMstSearchBySearchCondDAOutput : ISelectMemoMstSearchBySearchCondDAOutput
    {
        /// <summary>
        /// MemoMstSearchListDataTable
        /// </summary>
        public MemoMstDataSet.MemoMstSearchListDataTable MemoMstSearchListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMemoMstSearchBySearchCondDataAccess
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
    class SelectMemoMstSearchBySearchCondDataAccess : BaseDataAccess<ISelectMemoMstSearchBySearchCondDAInput, ISelectMemoMstSearchBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private MemoMstSearchListTableAdapter tableAdapter = new MemoMstSearchListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMemoMstSearchBySearchCondDataAccess
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
        public SelectMemoMstSearchBySearchCondDataAccess()
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
        public override ISelectMemoMstSearchBySearchCondDAOutput Execute(ISelectMemoMstSearchBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMemoMstSearchBySearchCondDAOutput output = new SelectMemoMstSearchBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.MemoMstSearchListDT = tableAdapter.GetDataBySearchCond(input.MemoDaibunruiCdFrom,
                                                                                input.MemoDaibunruiCdTo,
                                                                                input.MemoCdFrom,
                                                                                input.MemoCdTo,
                                                                                DataAccessUtility.EscapeSQLString(input.Memo));

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
