using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShokuinMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShokuinMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokuinMstBySearchCondDAInput
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
    interface ISelectShokuinMstBySearchCondDAInput
    {
        /// <summary>
        /// ShishoCd
        /// </summary>
        String ShishoCd { get; set; }

        /// <summary>
        /// 職員コード（開始）
        /// </summary>
        String ShokuinCdFrom { get; set; }

        /// <summary>
        /// 職員コード（終了）
        /// </summary>
        String ShokuinCdTo { get; set; }

        /// <summary>
        /// 職員名
        /// </summary>
        String ShokuinNm { get; set; }

        /// <summary>
        /// 職員名カナ
        /// </summary>
        String ShokuinKana { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokuinMstBySearchCondDAInput
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
    class SelectShokuinMstBySearchCondDAInput : ISelectShokuinMstBySearchCondDAInput
    {
        /// <summary>
        /// ShishoCd
        /// </summary>
        public String ShishoCd { get; set; }

        /// <summary>
        /// 職員コード（開始）
        /// </summary>
        public String ShokuinCdFrom { get; set; }

        /// <summary>
        /// 職員コード（終了）
        /// </summary>
        public String ShokuinCdTo { get; set; }

        /// <summary>
        /// 職員名
        /// </summary>
        public String ShokuinNm { get; set; }

        /// <summary>
        /// 職員名カナ
        /// </summary>
        public String ShokuinKana { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokuinMstBySearchCondDAOutput
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
    interface ISelectShokuinMstBySearchCondDAOutput
    {
        /// <summary>
        /// ShokuinMstKensakuDataTable
        /// </summary>
        ShokuinMstDataSet.ShokuinMstKensakuDataTable ShokuinMstKensakuDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokuinMstBySearchCondDAOutput
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
    class SelectShokuinMstBySearchCondDAOutput : ISelectShokuinMstBySearchCondDAOutput
    {
        /// <summary>
        /// ShokuinMstKensakuDataTable
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstKensakuDataTable ShokuinMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokuinMstBySearchCondDataAccess
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
    class SelectShokuinMstBySearchCondDataAccess : BaseDataAccess<ISelectShokuinMstBySearchCondDAInput, ISelectShokuinMstBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokuinMstKensakuTableAdapter tableAdapter = new ShokuinMstKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShokuinMstBySearchCondDataAccess
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
        public SelectShokuinMstBySearchCondDataAccess()
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
        public override ISelectShokuinMstBySearchCondDAOutput Execute(ISelectShokuinMstBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShokuinMstBySearchCondDAOutput output = new SelectShokuinMstBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShokuinMstKensakuDT = tableAdapter.GetDataBySearchCond(input.ShishoCd,
                                                                                input.ShokuinCdFrom,
                                                                                input.ShokuinCdTo,
                                                                                DataAccessUtility.EscapeSQLString(input.ShokuinNm),
                                                                                DataAccessUtility.EscapeSQLString(input.ShokuinKana));
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
