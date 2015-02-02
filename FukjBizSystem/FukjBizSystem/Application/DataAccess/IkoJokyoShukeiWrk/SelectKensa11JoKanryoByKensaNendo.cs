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
    //  インターフェイス名 ： ISelectKensa11JoKanryoByKensaNendoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensa11JoKanryoByKensaNendoDAInput
    {
        /// <summary>
        /// KensaIraiNendo 
        /// </summary>
        string KensaIraiNendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensa11JoKanryoByKensaNendoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensa11JoKanryoByKensaNendoDAInput : ISelectKensa11JoKanryoByKensaNendoDAInput
    {
        /// <summary>
        /// KensaIraiNendo 
        /// </summary>
        public string KensaIraiNendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensa11JoKanryoByKensaNendoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensa11JoKanryoByKensaNendoDAOutput
    {
        /// <summary>
        /// Kensa11JoKanryoDataTable
        /// </summary>
        IkoJokyoShukeiWrkDataSet.Kensa11JoKanryoDataTable Kensa11JoKanryoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensa11JoKanryoByKensaNendoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensa11JoKanryoByKensaNendoDAOutput : ISelectKensa11JoKanryoByKensaNendoDAOutput
    {
        /// <summary>
        /// Kensa11JoKanryoDataTable
        /// </summary>
        public IkoJokyoShukeiWrkDataSet.Kensa11JoKanryoDataTable Kensa11JoKanryoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensa11JoKanryoByKensaNendoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensa11JoKanryoByKensaNendoDataAccess : BaseDataAccess<ISelectKensa11JoKanryoByKensaNendoDAInput, ISelectKensa11JoKanryoByKensaNendoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private Kensa11JoKanryoTableAdapter tableAdapter = new Kensa11JoKanryoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensa11JoKanryoByKensaNendoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensa11JoKanryoByKensaNendoDataAccess()
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
        /// 2014/10/30  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensa11JoKanryoByKensaNendoDAOutput Execute(ISelectKensa11JoKanryoByKensaNendoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensa11JoKanryoByKensaNendoDAOutput output = new SelectKensa11JoKanryoByKensaNendoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.Kensa11JoKanryoDataTable = tableAdapter.GetDataByKensaNendo(input.KensaIraiNendo);

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
