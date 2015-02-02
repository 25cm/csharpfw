using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuIraiUketsukeWrkDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuIraiUketsukeWrk
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSuishitsuIraiUketsukeWrkDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateSuishitsuIraiUketsukeWrkDAInput
    {
        /// <summary>
        /// SuishitsuIraiUketsukeWrkDataTable
        /// </summary>
        SuishitsuIraiUketsukeWrkDataSet.SuishitsuIraiUketsukeWrkDataTable SuishitsuIraiUketsukeWrkDT { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSuishitsuIraiUketsukeWrkDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSuishitsuIraiUketsukeWrkDAInput : IUpdateSuishitsuIraiUketsukeWrkDAInput
    {
        /// <summary>
        /// SuishitsuIraiUketsukeWrkDataTable
        /// </summary>
        public SuishitsuIraiUketsukeWrkDataSet.SuishitsuIraiUketsukeWrkDataTable SuishitsuIraiUketsukeWrkDT { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSuishitsuIraiUketsukeWrkDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateSuishitsuIraiUketsukeWrkDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSuishitsuIraiUketsukeWrkDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSuishitsuIraiUketsukeWrkDAOutput : IUpdateSuishitsuIraiUketsukeWrkDAOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSuishitsuIraiUketsukeWrkDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSuishitsuIraiUketsukeWrkDataAccess : BaseDataAccess<IUpdateSuishitsuIraiUketsukeWrkDAInput, IUpdateSuishitsuIraiUketsukeWrkDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuIraiUketsukeWrkTableAdapter tableAdapter = new SuishitsuIraiUketsukeWrkTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateSuishitsuIraiUketsukeWrkDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateSuishitsuIraiUketsukeWrkDataAccess()
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
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateSuishitsuIraiUketsukeWrkDAOutput Execute(IUpdateSuishitsuIraiUketsukeWrkDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateSuishitsuIraiUketsukeWrkDAOutput output = new UpdateSuishitsuIraiUketsukeWrkDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.Update(input.SuishitsuIraiUketsukeWrkDT);
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
