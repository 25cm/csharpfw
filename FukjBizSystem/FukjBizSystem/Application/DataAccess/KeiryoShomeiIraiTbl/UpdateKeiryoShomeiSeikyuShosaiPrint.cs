using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.KeiryoShomeiIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiSeikyuShosaiPrintDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiSeikyuShosaiPrintDAInput
    {
        /// <summary>
        /// KeiryoShomeiSeikyuKbn
        /// </summary>
        string KeiryoShomeiSeikyuKbn { get; set; }

        /// <summary>
        /// Now
        /// </summary>
        DateTime Now { get; set; }

        /// <summary>
        /// LoginUser
        /// </summary>
        string LoginUser { get; set; }

        /// <summary>
        /// PcUpdate
        /// </summary>
        string PcUpdate { get; set; }

        /// <summary>
        /// OyaSeikyuNo
        /// </summary>
        string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiSeikyuShosaiPrintDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiSeikyuShosaiPrintDAInput : IUpdateKeiryoShomeiSeikyuShosaiPrintDAInput
    {
        /// <summary>
        /// KeiryoShomeiSeikyuKbn
        /// </summary>
        public string KeiryoShomeiSeikyuKbn { get; set; }

        /// <summary>
        /// Now
        /// </summary>
        public DateTime Now { get; set; }

        /// <summary>
        /// LoginUser
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// PcUpdate
        /// </summary>
        public string PcUpdate { get; set; }

        /// <summary>
        /// OyaSeikyuNo
        /// </summary>
        public string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiSeikyuShosaiPrintDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiSeikyuShosaiPrintDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiSeikyuShosaiPrintDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiSeikyuShosaiPrintDAOutput : IUpdateKeiryoShomeiSeikyuShosaiPrintDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiSeikyuShosaiPrintDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiSeikyuShosaiPrintDataAccess : BaseDataAccess<IUpdateKeiryoShomeiSeikyuShosaiPrintDAInput, IUpdateKeiryoShomeiSeikyuShosaiPrintDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KeiryoShomeiIraiTblTableAdapter tableAdapter = new KeiryoShomeiIraiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKeiryoShomeiSeikyuShosaiPrintDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/17　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKeiryoShomeiSeikyuShosaiPrintDataAccess()
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
        /// 2014/12/17　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKeiryoShomeiSeikyuShosaiPrintDAOutput Execute(IUpdateKeiryoShomeiSeikyuShosaiPrintDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKeiryoShomeiSeikyuShosaiPrintDAOutput output = new UpdateKeiryoShomeiSeikyuShosaiPrintDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.UpdateKeiryoShomeiSeikyuShosaiPrint(input.KeiryoShomeiSeikyuKbn, input.Now, input.LoginUser, input.PcUpdate, input.OyaSeikyuNo);

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
