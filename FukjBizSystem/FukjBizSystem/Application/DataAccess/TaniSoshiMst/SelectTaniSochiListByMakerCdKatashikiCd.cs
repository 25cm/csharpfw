using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.TaniSochiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.TaniSoshiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectTaniSochiListByMakerCdKatashikiCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectTaniSochiListByMakerCdKatashikiCdDAInput
    {
        /// <summary>
        /// KatashikiMakerCd
        /// </summary>
        String KatashikiMakerCd { get; set; }

        /// <summary>
        /// KatashikiCd
        /// </summary>
        String KatashikiCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectTaniSochiListByMakerCdKatashikiCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectTaniSochiListByMakerCdKatashikiCdDAInput : ISelectTaniSochiListByMakerCdKatashikiCdDAInput
    {
        /// <summary>
        /// KatashikiMakerCd
        /// </summary>
        public String KatashikiMakerCd { get; set; }

        /// <summary>
        /// KatashikiCd
        /// </summary>
        public String KatashikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectTaniSochiListByMakerCdKatashikiCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectTaniSochiListByMakerCdKatashikiCdDAOutput
    {
        /// <summary>
        /// TaniSochiListDataTable
        /// </summary>
        TaniSochiMstDataSet.TaniSochiListDataTable TaniSochiListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectTaniSochiListByMakerCdKatashikiCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectTaniSochiListByMakerCdKatashikiCdDAOutput : ISelectTaniSochiListByMakerCdKatashikiCdDAOutput
    {
        /// <summary>
        /// TaniSochiListDataTable
        /// </summary>
        public TaniSochiMstDataSet.TaniSochiListDataTable TaniSochiListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectTaniSochiListByMakerCdKatashikiCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/08  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectTaniSochiListByMakerCdKatashikiCdDataAccess : BaseDataAccess<ISelectTaniSochiListByMakerCdKatashikiCdDAInput, ISelectTaniSochiListByMakerCdKatashikiCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private TaniSochiListTableAdapter tableAdapter = new TaniSochiListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectTaniSochiListByMakerCdKatashikiCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectTaniSochiListByMakerCdKatashikiCdDataAccess()
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
        /// 2014/07/08  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectTaniSochiListByMakerCdKatashikiCdDAOutput Execute(ISelectTaniSochiListByMakerCdKatashikiCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectTaniSochiListByMakerCdKatashikiCdDAOutput output = new SelectTaniSochiListByMakerCdKatashikiCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.TaniSochiListDT = tableAdapter.GetDataByKatashikiMakerCdKatashikiCd(
                                                                                    input.KatashikiMakerCd,
                                                                                    input.KatashikiCd);

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
