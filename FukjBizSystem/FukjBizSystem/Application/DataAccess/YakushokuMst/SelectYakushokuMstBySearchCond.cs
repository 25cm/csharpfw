using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.YakushokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.YakushokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYakushokuMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/04  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYakushokuMstBySearchCondDAInput
    {
        /// <summary>
        /// NameCd
        /// </summary>
        String NameCd { get; set; }

        /// <summary>
        /// 役職コード（開始）
        /// </summary>
        String YakushokuCdFrom { get; set; }

        /// <summary>
        /// 役職コード（終了）
        /// </summary>
        String YakushokuCdTo { get; set; }

        /// <summary>
        /// 役職名
        /// </summary>
        String YakushokuNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYakushokuMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/04  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYakushokuMstBySearchCondDAInput : ISelectYakushokuMstBySearchCondDAInput
    {
        /// <summary>
        /// NameCd
        /// </summary>
        public String NameCd { get; set; }

        /// <summary>
        /// 役職コード（開始）
        /// </summary>
        public String YakushokuCdFrom { get; set; }

        /// <summary>
        /// 役職コード（終了）
        /// </summary>
        public String YakushokuCdTo { get; set; }

        /// <summary>
        /// 役職名
        /// </summary>
        public String YakushokuNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYakushokuMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/04  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYakushokuMstBySearchCondDAOutput
    {
        /// <summary>
        /// YakushokuMstKensakuDataTable
        /// </summary>
        YakushokuMstDataSet.YakushokuMstKensakuDataTable YakushokuMstKensakuDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYakushokuMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/04  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYakushokuMstBySearchCondDAOutput : ISelectYakushokuMstBySearchCondDAOutput
    {
        /// <summary>
        /// YakushokuMstKensakuDataTable
        /// </summary>
        public YakushokuMstDataSet.YakushokuMstKensakuDataTable YakushokuMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYakushokuMstBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/04  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYakushokuMstBySearchCondDataAccess : BaseDataAccess<ISelectYakushokuMstBySearchCondDAInput, ISelectYakushokuMstBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private YakushokuMstKensakuTableAdapter tableAdapter = new YakushokuMstKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectYakushokuMstBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectYakushokuMstBySearchCondDataAccess()
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
        /// 2014/07/04  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectYakushokuMstBySearchCondDAOutput Execute(ISelectYakushokuMstBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectYakushokuMstBySearchCondDAOutput output = new SelectYakushokuMstBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.YakushokuMstKensakuDT = tableAdapter.GetDataBySearchCond(input.NameCd, 
                                                                                input.YakushokuCdFrom, 
                                                                                input.YakushokuCdTo,
                                                                                DataAccessUtility.EscapeSQLString(input.YakushokuNm));

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
