using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.SeikyusyoKagamiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyusyoKagamiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertSeikyuShosaiKagami009DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertSeikyuShosaiKagami009DAInput
    {
        /// <summary>
        /// Zeiritsu
        /// </summary>
        decimal Zeiritsu { get; set; }

        /// <summary>
        /// Now
        /// </summary>
        DateTime Now { get; set; }

        /// <summary>
        /// PcUpdate
        /// </summary>
        string PcUpdate { get; set; }

        /// <summary>
        /// LoginUser
        /// </summary>
        string LoginUser { get; set; }

        /// <summary>
        /// OyaSeikyuNo
        /// </summary>
        string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertSeikyuShosaiKagami009DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertSeikyuShosaiKagami009DAInput : IInsertSeikyuShosaiKagami009DAInput
    {
        /// <summary>
        /// Zeiritsu
        /// </summary>
        public decimal Zeiritsu { get; set; }

        /// <summary>
        /// Now
        /// </summary>
        public DateTime Now { get; set; }

        /// <summary>
        /// PcUpdate
        /// </summary>
        public string PcUpdate { get; set; }

        /// <summary>
        /// LoginUser
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// OyaSeikyuNo
        /// </summary>
        public string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertSeikyuShosaiKagami009DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertSeikyuShosaiKagami009DAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertSeikyuShosaiKagami009DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertSeikyuShosaiKagami009DAOutput : IInsertSeikyuShosaiKagami009DAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertSeikyuShosaiKagami009DataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertSeikyuShosaiKagami009DataAccess : BaseDataAccess<IInsertSeikyuShosaiKagami009DAInput, IInsertSeikyuShosaiKagami009DAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyusyoKagamiTblTableAdapter tableAdapter = new SeikyusyoKagamiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InsertSeikyuShosaiKagami009DataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public InsertSeikyuShosaiKagami009DataAccess()
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
        /// 2014/12/16　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IInsertSeikyuShosaiKagami009DAOutput Execute(IInsertSeikyuShosaiKagami009DAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertSeikyuShosaiKagami009DAOutput output = new InsertSeikyuShosaiKagami009DAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.InsertSeikyuShosaiKagami009(input.Zeiritsu, input.Now, input.PcUpdate, input.LoginUser, input.OyaSeikyuNo);

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
