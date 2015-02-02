using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KatashikiBetsuTaniSochiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KatashikiBetsuTaniSochiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectBetsuTaniSochiByMakerCdKatashikiCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectBetsuTaniSochiByMakerCdKatashikiCdDAInput
    {
        /// <summary>
        /// メーカー業者コード
        /// </summary>
        String KatashikiMakerCd { get; set; }

        /// <summary>
        /// 型式コード
        /// </summary>
        String KatashikiCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectBetsuTaniSochiByMakerCdKatashikiCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectBetsuTaniSochiByMakerCdKatashikiCdDAInput : ISelectBetsuTaniSochiByMakerCdKatashikiCdDAInput
    {
        /// <summary>
        /// メーカー業者コード
        /// </summary>
        public String KatashikiMakerCd { get; set; }

        /// <summary>
        /// 型式コード
        /// </summary>
        public String KatashikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectBetsuTaniSochiByMakerCdKatashikiCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectBetsuTaniSochiByMakerCdKatashikiCdDAOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiListDataTable
        /// </summary>
        KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiListDataTable KatashikiBetsuTaniSochiListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectBetsuTaniSochiByMakerCdKatashikiCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectBetsuTaniSochiByMakerCdKatashikiCdDAOutput : ISelectBetsuTaniSochiByMakerCdKatashikiCdDAOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiListDataTable
        /// </summary>
        public KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiListDataTable KatashikiBetsuTaniSochiListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectBetsuTaniSochiByMakerCdKatashikiCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/09  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectBetsuTaniSochiByMakerCdKatashikiCdDataAccess : BaseDataAccess<ISelectBetsuTaniSochiByMakerCdKatashikiCdDAInput, ISelectBetsuTaniSochiByMakerCdKatashikiCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KatashikiBetsuTaniSochiListTableAdapter tableAdapter = new KatashikiBetsuTaniSochiListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectBetsuTaniSochiByMakerCdKatashikiCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectBetsuTaniSochiByMakerCdKatashikiCdDataAccess()
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
        /// 2014/07/09  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectBetsuTaniSochiByMakerCdKatashikiCdDAOutput Execute(ISelectBetsuTaniSochiByMakerCdKatashikiCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectBetsuTaniSochiByMakerCdKatashikiCdDAOutput output = new SelectBetsuTaniSochiByMakerCdKatashikiCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KatashikiBetsuTaniSochiListDT = tableAdapter.GetDataByKatashikiMakerCdKatashikiCd(input.KatashikiMakerCd, input.KatashikiCd);
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
