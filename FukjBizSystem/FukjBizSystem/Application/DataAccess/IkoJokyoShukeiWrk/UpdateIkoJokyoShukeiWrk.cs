using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.IkoJokyoShukeiWrkDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.IkoJokyoShukeiWrk
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateIkoJokyoShukeiWrkDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateIkoJokyoShukeiWrkDAInput
    {
        /// <summary>
        /// IkoJokyoShukeiWrkDataTable
        /// </summary>
        IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable IkoJokyoShukeiWrkDataTable { get; set; }

        /// <summary>
        /// IsInsert
        /// </summary>
        bool IsInsert { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateIkoJokyoShukeiWrkDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateIkoJokyoShukeiWrkDAInput : IUpdateIkoJokyoShukeiWrkDAInput
    {
        /// <summary>
        /// IkoJokyoShukeiWrkDataTable
        /// </summary>
        public IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable IkoJokyoShukeiWrkDataTable { get; set; }

        /// <summary>
        /// IsInsert
        /// </summary>
        public bool IsInsert { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateIkoJokyoShukeiWrkDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateIkoJokyoShukeiWrkDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateIkoJokyoShukeiWrkDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateIkoJokyoShukeiWrkDAOutput : IUpdateIkoJokyoShukeiWrkDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateIkoJokyoShukeiWrkDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/29  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateIkoJokyoShukeiWrkDataAccess : BaseDataAccess<IUpdateIkoJokyoShukeiWrkDAInput, IUpdateIkoJokyoShukeiWrkDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private IkoJokyoShukeiWrkTableAdapter tableAdapter = new IkoJokyoShukeiWrkTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateIkoJokyoShukeiWrkDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/29  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateIkoJokyoShukeiWrkDataAccess()
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
        /// 2014/10/29  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateIkoJokyoShukeiWrkDAOutput Execute(IUpdateIkoJokyoShukeiWrkDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateIkoJokyoShukeiWrkDAOutput output = new UpdateIkoJokyoShukeiWrkDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                //tableAdapter.Update(input.IkoJokyoShukeiWrkDataTable.Select(""));

                foreach (IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkRow row in input.IkoJokyoShukeiWrkDataTable.Rows)
                {
                    if (input.IsInsert)
                    {
                        tableAdapter.Insert(row.KensaIraiHokenjoCd,
                                            row.JokasoGenChikuCd,
                                            row.KensaIraiNendo,
                                            row.Kensa7JoJisshiCnt,
                                            row.IkoSumiCnt,
                                            row.InsertDt,
                                            row.InsertUser,
                                            row.InsertTarm,
                                            row.UpdateDt,
                                            row.UpdateUser,
                                            row.UpdateTarm);
                    }
                    else
                    {
                        tableAdapter.UpdateByCond(row.IkoSumiCnt,
                                                    row.UpdateDt,
                                                    row.UpdateUser,
                                                    row.UpdateTarm,
                                                    row.KensaIraiHokenjoCd,
                                                    row.JokasoGenChikuCd,
                                                    row.KensaIraiNendo);
                    }
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
