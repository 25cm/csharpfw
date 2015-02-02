using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.SuishitsuNippoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuNippoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICountDecideKeiryoShomeiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICountDecideKeiryoShomeiDAInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        string UketsukeDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountDecideKeiryoShomeiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountDecideKeiryoShomeiDAInput : ICountDecideKeiryoShomeiDAInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        public string UketsukeDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICountDecideKeiryoShomeiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICountDecideKeiryoShomeiDAOutput
    {
        /// <summary>
        /// RecordCount
        /// </summary>
        int RecordCount { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountDecideKeiryoShomeiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountDecideKeiryoShomeiDAOutput : ICountDecideKeiryoShomeiDAOutput
    {
        /// <summary>
        /// RecordCount
        /// </summary>
        public int RecordCount { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountDecideKeiryoShomeiDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CountDecideKeiryoShomeiDataAccess : BaseDataAccess<ICountDecideKeiryoShomeiDAInput, ICountDecideKeiryoShomeiDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private CountDecide2KensaNippoTableAdapter tableAdapter = new CountDecide2KensaNippoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CountDecideKeiryoShomeiDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CountDecideKeiryoShomeiDataAccess()
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
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ICountDecideKeiryoShomeiDAOutput Execute(ICountDecideKeiryoShomeiDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICountDecideKeiryoShomeiDAOutput output = new CountDecideKeiryoShomeiDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.RecordCount = (int)tableAdapter.CountKeiryoShomei(input.UketsukeDt);

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
