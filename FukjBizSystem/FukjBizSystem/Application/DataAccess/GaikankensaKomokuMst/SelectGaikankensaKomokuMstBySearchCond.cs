using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikankensaKomokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.GaikankensaKomokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGaikankensaKomokuMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectGaikankensaKomokuMstBySearchCondDAInput
    {
        /// <summary>
        /// 外観検査項目コード（開始）
        /// </summary>
        String GaikankensaKomokuCdFrom { get; set; }

        /// <summary>
        /// 外観検査項目コード（終了）
        /// </summary>
        String GaikankensaKomokuCdTo { get; set; }

        /// <summary>
        /// 外観検査項目名称
        /// </summary>
        String GaikankensaKomokuNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGaikankensaKomokuMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGaikankensaKomokuMstBySearchCondDAInput : ISelectGaikankensaKomokuMstBySearchCondDAInput
    {
        /// <summary>
        /// 外観検査項目コード（開始）
        /// </summary>
        public String GaikankensaKomokuCdFrom { get; set; }

        /// <summary>
        /// 外観検査項目コード（終了）
        /// </summary>
        public String GaikankensaKomokuCdTo { get; set; }

        /// <summary>
        /// 外観検査項目名称
        /// </summary>
        public String GaikankensaKomokuNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGaikankensaKomokuMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectGaikankensaKomokuMstBySearchCondDAOutput
    {
        /// <summary>
        /// GaikankensaKomokuMstKensakuDataTable
        /// </summary>
        GaikankensaKomokuMstDataSet.GaikankensaKomokuMstKensakuDataTable GaikankensaKomokuMstKensakuDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGaikankensaKomokuMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGaikankensaKomokuMstBySearchCondDAOutput : ISelectGaikankensaKomokuMstBySearchCondDAOutput
    {
        /// <summary>
        /// GaikankensaKomokuMstKensakuDataTable
        /// </summary>
        public GaikankensaKomokuMstDataSet.GaikankensaKomokuMstKensakuDataTable GaikankensaKomokuMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGaikankensaKomokuMstBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/01  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGaikankensaKomokuMstBySearchCondDataAccess : BaseDataAccess<ISelectGaikankensaKomokuMstBySearchCondDAInput, ISelectGaikankensaKomokuMstBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private GaikankensaKomokuMstKensakuTableAdapter tableAdapter = new GaikankensaKomokuMstKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectGaikankensaKomokuMstBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectGaikankensaKomokuMstBySearchCondDataAccess()
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
        /// 2014/07/01  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectGaikankensaKomokuMstBySearchCondDAOutput Execute(ISelectGaikankensaKomokuMstBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectGaikankensaKomokuMstBySearchCondDAOutput output = new SelectGaikankensaKomokuMstBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.GaikankensaKomokuMstKensakuDT = tableAdapter.GetDataBySearchCond(
                                                                                    input.GaikankensaKomokuCdFrom,
                                                                                    input.GaikankensaKomokuCdTo,
                                                                                    DataAccessUtility.EscapeSQLString(input.GaikankensaKomokuNm)
                                                                                    );

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
