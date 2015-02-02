using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.SetShikenKomokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SetShikenKomokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSetShikenKomokuMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSetShikenKomokuMstByKeyDAInput
    {
        /// <summary>
        /// SetKomokuSetCd
        /// </summary>
        string SetKomokuSetCd { get; set; }

        /// <summary>
        /// SetKomokuCd
        /// </summary>
        string SetKomokuCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSetShikenKomokuMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSetShikenKomokuMstByKeyDAInput : IDeleteSetShikenKomokuMstByKeyDAInput
    {
        /// <summary>
        /// SetKomokuSetCd
        /// </summary>
        public string SetKomokuSetCd { get; set; }

        /// <summary>
        /// SetKomokuCd
        /// </summary>
        public string SetKomokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSetShikenKomokuMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSetShikenKomokuMstByKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSetShikenKomokuMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSetShikenKomokuMstByKeyDAOutput : IDeleteSetShikenKomokuMstByKeyDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSetShikenKomokuMstByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSetShikenKomokuMstByKeyDataAccess : BaseDataAccess<IDeleteSetShikenKomokuMstByKeyDAInput, IDeleteSetShikenKomokuMstByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SetShikenKomokuMstTableAdapter tableAdapter = new SetShikenKomokuMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteSetShikenKomokuMstByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteSetShikenKomokuMstByKeyDataAccess()
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
        /// 2015/01/28  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteSetShikenKomokuMstByKeyDAOutput Execute(IDeleteSetShikenKomokuMstByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteSetShikenKomokuMstByKeyDAOutput output = new DeleteSetShikenKomokuMstByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteByKey(input.SetKomokuSetCd, input.SetKomokuCd);

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
