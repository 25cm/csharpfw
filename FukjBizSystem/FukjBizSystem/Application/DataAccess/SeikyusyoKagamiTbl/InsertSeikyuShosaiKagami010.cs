using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.SeikyusyoKagamiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyusyoKagamiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertSeikyuShosaiKagami010DAInput
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
    interface IInsertSeikyuShosaiKagami010DAInput
    {
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
    //  クラス名 ： InsertSeikyuShosaiKagami010DAInput
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
    class InsertSeikyuShosaiKagami010DAInput : IInsertSeikyuShosaiKagami010DAInput
    {
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
    //  インターフェイス名 ： IInsertSeikyuShosaiKagami010DAOutput
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
    interface IInsertSeikyuShosaiKagami010DAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertSeikyuShosaiKagami010DAOutput
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
    class InsertSeikyuShosaiKagami010DAOutput : IInsertSeikyuShosaiKagami010DAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertSeikyuShosaiKagami010DataAccess
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
    class InsertSeikyuShosaiKagami010DataAccess : BaseDataAccess<IInsertSeikyuShosaiKagami010DAInput, IInsertSeikyuShosaiKagami010DAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyusyoKagamiTblTableAdapter tableAdapter = new SeikyusyoKagamiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InsertSeikyuShosaiKagami010DataAccess
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
        public InsertSeikyuShosaiKagami010DataAccess()
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
        public override IInsertSeikyuShosaiKagami010DAOutput Execute(IInsertSeikyuShosaiKagami010DAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertSeikyuShosaiKagami010DAOutput output = new InsertSeikyuShosaiKagami010DAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.InsertSeikyuShosaiKagami010(input.Now, input.PcUpdate, input.LoginUser, input.OyaSeikyuNo);

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
