using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShozokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShozokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertShozokuMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertShozokuMstDAInput
    {
        /// <summary>
        /// ShozokuMstRow
        /// </summary>
        ShozokuMstDataSet.ShozokuMstRow ShozokuMstRow { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertShozokuMstDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertShozokuMstDAInput : IInsertShozokuMstDAInput
    {
        /// <summary>
        /// ShozokuMstRow
        /// </summary>
        public ShozokuMstDataSet.ShozokuMstRow ShozokuMstRow { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertShozokuMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertShozokuMstDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertShozokuMstDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertShozokuMstDAOutput : IInsertShozokuMstDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertShozokuMstDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/27　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertShozokuMstDataAccess : BaseDataAccess<IInsertShozokuMstDAInput, IInsertShozokuMstDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShozokuMstTableAdapter tableAdapter = new ShozokuMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InsertShozokuMstDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/27　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public InsertShozokuMstDataAccess()
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
        /// 2015/01/27　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IInsertShozokuMstDAOutput Execute(IInsertShozokuMstDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertShozokuMstDAOutput output = new InsertShozokuMstDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.Insert(input.ShozokuMstRow.ShozokuShokuinCd,
                                    input.ShozokuMstRow.ShozokuBushoCd,
                                    input.ShozokuMstRow.ShozokuYakushokuCd,
                                    input.ShozokuMstRow.InsertDt,
                                    input.ShozokuMstRow.InsertUser,
                                    input.ShozokuMstRow.InsertTarm,
                                    input.ShozokuMstRow.UpdateDt,
                                    input.ShozokuMstRow.UpdateUser,
                                    input.ShozokuMstRow.UpdateTarm);

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
