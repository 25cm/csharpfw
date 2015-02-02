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
    //  インターフェイス名 ： ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput
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
    interface ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput
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
    //  クラス名 ： SelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput
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
    class SelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput : ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput
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
    //  インターフェイス名 ： ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput
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
    interface ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiMstDataTable
        /// </summary>
        KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable KatashikiBetsuTaniSochiMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput
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
    class SelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput : ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiMstDataTable
        /// </summary>
        public KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable KatashikiBetsuTaniSochiMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDataAccess
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
    class SelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDataAccess : BaseDataAccess<ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput, ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KatashikiBetsuTaniSochiMstTableAdapter tableAdapter = new KatashikiBetsuTaniSochiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDataAccess
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
        public SelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDataAccess()
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
        public override ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput Execute(ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput output = new SelectKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KatashikiBetsuTaniSochiMstDT = tableAdapter.GetDataByKatashikiMakerCdKatashikiCd(input.KatashikiMakerCd, input.KatashikiCd);

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
