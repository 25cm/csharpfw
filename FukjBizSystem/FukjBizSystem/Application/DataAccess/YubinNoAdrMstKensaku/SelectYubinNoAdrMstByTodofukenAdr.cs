using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.Common;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.YubinNoAdrMstKensakuDataSetTableAdapters;


namespace FukjBizSystem.Application.DataAccess.YubinNoAdrMstKensaku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYubinNoAdrMstByTodofukenAdrDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYubinNoAdrMstByTodofukenAdrDAInput
    {
        /// <summary>
        /// 都道府県名
        /// </summary>
        String TodofukenNm { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        String AdrNm { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYubinNoAdrMstByTodofukenAdrDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYubinNoAdrMstByTodofukenAdrDAInput : ISelectYubinNoAdrMstByTodofukenAdrDAInput
    {
        /// <summary>
        /// 都道府県名
        /// </summary>
        public String TodofukenNm { get; set; }

        /// <summary>
        /// 住所
        /// </summary>
        public String AdrNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYubinNoAdrMstByTodofukenAdrDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYubinNoAdrMstByTodofukenAdrDAOutput
    {
        /// <summary>
        /// YubinNoAdrMstDataTable
        /// </summary>
        YubinNoAdrMstKensakuDataSet.YubinNoAdrMstDataTable YubinNoAdrMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYubinNoAdrMstByTodofukenAdrDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYubinNoAdrMstByTodofukenAdrDAOutput : ISelectYubinNoAdrMstByTodofukenAdrDAOutput
    {
        /// <summary>
        /// YubinNoAdrMstDataTable
        /// </summary>
        public YubinNoAdrMstKensakuDataSet.YubinNoAdrMstDataTable YubinNoAdrMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYubinNoAdrMstByTodofukenAdrDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// yyyy/mm/dd　××　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYubinNoAdrMstByTodofukenAdrDataAccess : BaseDataAccess<ISelectYubinNoAdrMstByTodofukenAdrDAInput, ISelectYubinNoAdrMstByTodofukenAdrDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private YubinNoAdrMstTableAdapter tableAdapter
            = new YubinNoAdrMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectYubinNoAdrMstByTodofukenAdrDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectYubinNoAdrMstByTodofukenAdrDataAccess()
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
        /// yyyy/mm/dd　××　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectYubinNoAdrMstByTodofukenAdrDAOutput Execute(ISelectYubinNoAdrMstByTodofukenAdrDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectYubinNoAdrMstByTodofukenAdrDAOutput output = new SelectYubinNoAdrMstByTodofukenAdrDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.YubinNoAdrMstDT = tableAdapter.GetDataByTodofukenAdr(input.TodofukenNm, input.AdrNm);

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
