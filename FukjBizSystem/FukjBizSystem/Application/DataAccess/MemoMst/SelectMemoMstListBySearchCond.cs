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
    //  インターフェイス名 ： ISelectMemoMstListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMemoMstListBySearchCondDAInput
    {
        /// <summary>
        /// 大分類コード
        /// </summary>
        string MemoDaibunruiCd { get; set; }

        /// <summary>
        /// メモ
        /// </summary>
        string Memo { get; set; }

        /// <summary>
        /// 重要
        /// </summary>
        bool Juyo { get; set; }

        /// <summary>
        /// 普通
        /// </summary>
        bool Hutsu { get; set; }

        /// <summary>
        /// 選択可
        /// </summary>
        bool SentakuKa { get; set; }

        /// <summary>
        /// 選択不可
        /// </summary>
        bool SentakuHuka {get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMemoMstListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMemoMstListBySearchCondDAInput : ISelectMemoMstListBySearchCondDAInput
    {
        /// <summary>
        /// 大分類コード
        /// </summary>
        public string MemoDaibunruiCd { get; set; }

        /// <summary>
        /// メモ
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// 重要
        /// </summary>
        public bool Juyo { get; set; }

        /// <summary>
        /// 普通
        /// </summary>
        public bool Hutsu { get; set; }

        /// <summary>
        /// 選択可
        /// </summary>
        public bool SentakuKa { get; set; }

        /// <summary>
        /// 選択不可
        /// </summary>
        public bool SentakuHuka { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMemoMstListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMemoMstListBySearchCondDAOutput
    {
        /// <summary>
        /// MemoMstKensakuDataTable
        /// </summary>
        MemoMstDataSet.MemoMstKensakuDataTable MemoMstKensakuDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMemoMstListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMemoMstListBySearchCondDAOutput : ISelectMemoMstListBySearchCondDAOutput
    {
        /// <summary>
        /// MemoMstKensakuDataTable
        /// </summary>
        public MemoMstDataSet.MemoMstKensakuDataTable MemoMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMemoMstListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMemoMstListBySearchCondDataAccess : BaseDataAccess<ISelectMemoMstListBySearchCondDAInput, ISelectMemoMstListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private MemoMstKensakuTableAdapter tableAdapter = new MemoMstKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMemoMstListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectMemoMstListBySearchCondDataAccess()
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
        /// 2014/08/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectMemoMstListBySearchCondDAOutput Execute(ISelectMemoMstListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMemoMstListBySearchCondDAOutput output = new SelectMemoMstListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.MemoMstKensakuDT = tableAdapter.GetDataBySearchCond(input.MemoDaibunruiCd,
                                                                            DataAccessUtility.EscapeSQLString(input.Memo),
                                                                            input.Juyo,
                                                                            input.Hutsu,
                                                                            input.SentakuKa,
                                                                            input.SentakuHuka);

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
