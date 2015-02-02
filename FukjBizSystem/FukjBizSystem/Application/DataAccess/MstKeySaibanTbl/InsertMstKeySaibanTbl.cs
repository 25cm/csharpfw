using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.MstKeySaibanTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.MstKeySaibanTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertMstKeySaibanTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertMstKeySaibanTblDAInput
    {
        /// <summary>
        /// MstKeySaibanTblDataTable
        /// </summary>
        MstKeySaibanTblDataSet.MstKeySaibanTblDataTable MstKeySaibanTblDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertMstKeySaibanTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertMstKeySaibanTblDAInput : IInsertMstKeySaibanTblDAInput
    {
        /// <summary>
        /// MstKeySaibanTblDataTable
        /// </summary>
        public MstKeySaibanTblDataSet.MstKeySaibanTblDataTable MstKeySaibanTblDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertMstKeySaibanTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertMstKeySaibanTblDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertMstKeySaibanTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertMstKeySaibanTblDAOutput : IInsertMstKeySaibanTblDAOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertMstKeySaibanTblDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/24  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertMstKeySaibanTblDataAccess : BaseDataAccess<IInsertMstKeySaibanTblDAInput, IInsertMstKeySaibanTblDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private MstKeySaibanTblTableAdapter tableAdapter = new MstKeySaibanTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InsertMstKeySaibanTblDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/24  宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public InsertMstKeySaibanTblDataAccess()
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
        /// 2014/07/24  宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IInsertMstKeySaibanTblDAOutput Execute(IInsertMstKeySaibanTblDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertMstKeySaibanTblDAOutput output = new InsertMstKeySaibanTblDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                foreach (MstKeySaibanTblDataSet.MstKeySaibanTblRow row in input.MstKeySaibanTblDataTable)
                {
                    tableAdapter.Insert(
                        row.MstButsuriNm,
                        row.MstKeyValue1,
                        row.MstKeyValue2,
                        row.MstKeyValue3,
                        row.MstKeyRenban,
                        row.InsertDt,
                        row.InsertUser,
                        row.InsertTarm,
                        row.UpdateDt,
                        row.UpdateUser,
                        row.UpdateTarm
                    );
                }
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
