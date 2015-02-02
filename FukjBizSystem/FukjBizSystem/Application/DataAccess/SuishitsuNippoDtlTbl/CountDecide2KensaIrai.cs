using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.SuishitsuNippoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuNippoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICountDecide2KensaIraiDAInput
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
    interface ICountDecide2KensaIraiDAInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        string UketsukeDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountDecide2KensaIraiDAInput
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
    class CountDecide2KensaIraiDAInput : ICountDecide2KensaIraiDAInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        public string UketsukeDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICountDecide2KensaIraiDAOutput
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
    interface ICountDecide2KensaIraiDAOutput
    {
        /// <summary>
        /// RecordCount
        /// </summary>
        int RecordCount { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountDecide2KensaIraiDAOutput
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
    class CountDecide2KensaIraiDAOutput : ICountDecide2KensaIraiDAOutput
    {
        /// <summary>
        /// RecordCount
        /// </summary>
        public int RecordCount { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CountDecide2KensaIraiDataAccess
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
    class CountDecide2KensaIraiDataAccess : BaseDataAccess<ICountDecide2KensaIraiDAInput, ICountDecide2KensaIraiDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private CountDecide2KensaNippoTableAdapter tableAdapter = new CountDecide2KensaNippoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CountDecide2KensaIraiDataAccess
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
        public CountDecide2KensaIraiDataAccess()
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
        public override ICountDecide2KensaIraiDAOutput Execute(ICountDecide2KensaIraiDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICountDecide2KensaIraiDAOutput output = new CountDecide2KensaIraiDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.RecordCount = (int) tableAdapter.CountKensaIrai(input.UketsukeDt);

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
