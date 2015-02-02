using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KatashikiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KatashikiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKatashikiMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKatashikiMstBySearchCondDAInput
    {
        /// <summary>
        /// メーカー業者コード（開始）
        /// </summary>
        String KatashikiMakerCdFrom { get; set; }

        /// <summary>
        /// メーカー業者コード（終了）
        /// </summary>
        String KatashikiMakerCdTo { get; set; }

        /// <summary>
        /// メーカー業者名称
        /// </summary>
        String GyoshaNm { get; set; }

        /// <summary>
        /// 型式コード（開始）
        /// </summary>
        String KatashikiCdFrom { get; set; }

        /// <summary>
        /// 型式コード（終了）
        /// </summary>
        String KatashikiCdTo { get; set; }

        /// <summary>
        /// 型式名称
        /// </summary>
        String KatashikiNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiMstBySearchCondDAInput : ISelectKatashikiMstBySearchCondDAInput
    {
        /// <summary>
        /// メーカー業者コード（開始）
        /// </summary>
        public String KatashikiMakerCdFrom { get; set; }

        /// <summary>
        /// メーカー業者コード（終了）
        /// </summary>
        public String KatashikiMakerCdTo { get; set; }

        /// <summary>
        /// メーカー業者名称
        /// </summary>
        public String GyoshaNm { get; set; }

        /// <summary>
        /// 型式コード（開始）
        /// </summary>
        public String KatashikiCdFrom { get; set; }

        /// <summary>
        /// 型式コード（終了）
        /// </summary>
        public String KatashikiCdTo { get; set; }

        /// <summary>
        /// 型式名称
        /// </summary>
        public String KatashikiNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKatashikiMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKatashikiMstBySearchCondDAOutput
    {
        /// <summary>
        /// KatashikiMstKensakuDataTable
        /// </summary>
        KatashikiMstDataSet.KatashikiMstKensakuDataTable KatashikiMstKensakuDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiMstBySearchCondDAOutput : ISelectKatashikiMstBySearchCondDAOutput
    {
        /// <summary>
        /// KatashikiMstKensakuDataTable
        /// </summary>
        public KatashikiMstDataSet.KatashikiMstKensakuDataTable KatashikiMstKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiMstBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/03  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiMstBySearchCondDataAccess : BaseDataAccess<ISelectKatashikiMstBySearchCondDAInput, ISelectKatashikiMstBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KatashikiMstKensakuTableAdapter tableAdapter = new KatashikiMstKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKatashikiMstBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/03  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKatashikiMstBySearchCondDataAccess()
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
        /// 2014/07/03  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKatashikiMstBySearchCondDAOutput Execute(ISelectKatashikiMstBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKatashikiMstBySearchCondDAOutput output = new SelectKatashikiMstBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KatashikiMstKensakuDT = tableAdapter.GetDataBySearchCond(input.KatashikiMakerCdFrom,
                                                                                    input.KatashikiMakerCdTo,
                                                                                    DataAccessUtility.EscapeSQLString(input.GyoshaNm),
                                                                                    input.KatashikiCdFrom,
                                                                                    input.KatashikiCdTo,
                                                                                    DataAccessUtility.EscapeSQLString(input.KatashikiNm));

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
