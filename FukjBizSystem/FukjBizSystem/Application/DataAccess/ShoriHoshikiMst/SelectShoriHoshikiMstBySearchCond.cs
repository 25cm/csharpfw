using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShoriHoshikiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShoriHoshikiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShoriHoshikiMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShoriHoshikiMstBySearchCondDAInput
    {
        /// <summary>
        /// 処理方式区分（開始）
        /// </summary>
        String ShoriHoshikiKbnFrom { get; set; }

        /// <summary>
        /// 処理方式区分（終了）
        /// </summary>
        String ShoriHoshikiKbnTo { get; set; }

        /// <summary>
        /// 処理方式コード（開始）
        /// </summary>
        String ShoriHoshikiCdFrom { get; set; }

        /// <summary>
        /// 処理方式コード（終了）
        /// </summary>
        String ShoriHoshikiCdTo { get; set; }

        /// <summary>
        /// 処理方式種別名
        /// </summary>
        String ShoriHoshikiShubetsuNm { get; set; }

        /// <summary>
        /// 処理方式名
        /// </summary>
        String ShoriHoshikiNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShoriHoshikiMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShoriHoshikiMstBySearchCondDAInput : ISelectShoriHoshikiMstBySearchCondDAInput
    {
        /// <summary>
        /// 処理方式区分（開始）
        /// </summary>
        public String ShoriHoshikiKbnFrom { get; set; }

        /// <summary>
        /// 処理方式区分（終了）
        /// </summary>
        public String ShoriHoshikiKbnTo { get; set; }

        /// <summary>
        /// 処理方式コード（開始）
        /// </summary>
        public String ShoriHoshikiCdFrom { get; set; }

        /// <summary>
        /// 処理方式コード（終了）
        /// </summary>
        public String ShoriHoshikiCdTo { get; set; }

        /// <summary>
        /// 処理方式種別名
        /// </summary>
        public String ShoriHoshikiShubetsuNm { get; set; }

        /// <summary>
        /// 処理方式名
        /// </summary>
        public String ShoriHoshikiNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShoriHoshikiMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShoriHoshikiMstBySearchCondDAOutput
    {
        /// <summary>
        /// ShoriHoshikiMstKensakuDataTable
        /// </summary>
        ShoriHoshikiMstDataSet.ShoriHoshikiMstKensakuDataTable ShoriHoshikiMstKensakuDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShoriHoshikiMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShoriHoshikiMstBySearchCondDAOutput : ISelectShoriHoshikiMstBySearchCondDAOutput
    {
        /// <summary>
        /// ShoriHoshikiMstKensakuDataTable
        /// </summary>
        public ShoriHoshikiMstDataSet.ShoriHoshikiMstKensakuDataTable ShoriHoshikiMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShoriHoshikiMstBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/30  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShoriHoshikiMstBySearchCondDataAccess : BaseDataAccess<ISelectShoriHoshikiMstBySearchCondDAInput, ISelectShoriHoshikiMstBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShoriHoshikiMstKensakuTableAdapter tableAdapter = new ShoriHoshikiMstKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShoriHoshikiMstBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShoriHoshikiMstBySearchCondDataAccess()
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
        /// 2014/06/30  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShoriHoshikiMstBySearchCondDAOutput Execute(ISelectShoriHoshikiMstBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShoriHoshikiMstBySearchCondDAOutput output = new SelectShoriHoshikiMstBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShoriHoshikiMstKensakuDT = tableAdapter.GetDataBySearchCond(
                                                                            input.ShoriHoshikiKbnFrom,
                                                                            input.ShoriHoshikiKbnTo,
                                                                            input.ShoriHoshikiCdFrom,
                                                                            input.ShoriHoshikiCdTo,
                                                                            DataAccessUtility.EscapeSQLString(input.ShoriHoshikiShubetsuNm),
                                                                            DataAccessUtility.EscapeSQLString(input.ShoriHoshikiNm));

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
