using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.KatashikiBetsuTaniSochiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KatashikiBetsuTaniSochiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput
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
    interface IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput
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
    //  クラス名 ： DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput
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
    class DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput : IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput
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
    //  インターフェイス名 ： IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput
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
    interface IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput
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
    class DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput : IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDataAccess
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
    class DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDataAccess : BaseDataAccess<IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput, IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KatashikiBetsuTaniSochiMstTableAdapter tableAdapter = new KatashikiBetsuTaniSochiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDataAccess
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
        public DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDataAccess()
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
        public override IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput Execute(IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput output = new DeleteKatashikiBetsuTaniSochiMstByKatashikiMakerCdKatashikiCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteByKatashikiMakerCdKatashikiCd(input.KatashikiMakerCd, input.KatashikiCd);

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
