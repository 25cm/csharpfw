using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KeiryoShomeiKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KeiryoShomeiKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiKekkaTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　          新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiKekkaTblDAInput
    {
        /// <summary>
        /// 計量証明結果テーブル情報
        /// </summary>
        KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable KeiryoShomeiKekkaTblDT { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiKekkaTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiKekkaTblDAInput : IUpdateKeiryoShomeiKekkaTblDAInput
    {
        /// <summary>
        /// 計量証明結果テーブル情報
        /// </summary>
        public KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable KeiryoShomeiKekkaTblDT { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiKekkaTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiKekkaTblDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiKekkaTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiKekkaTblDAOutput : IUpdateKeiryoShomeiKekkaTblDAOutput
    {
        
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiKekkaTblDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiKekkaTblDataAccess : BaseDataAccess<IUpdateKeiryoShomeiKekkaTblDAInput, IUpdateKeiryoShomeiKekkaTblDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KeiryoShomeiKekkaTblTableAdapter tableAdapter = new KeiryoShomeiKekkaTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKeiryoShomeiKekkaTblDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  小松　      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKeiryoShomeiKekkaTblDataAccess()
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
        /// 2014/12/03  小松　      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKeiryoShomeiKekkaTblDAOutput Execute(IUpdateKeiryoShomeiKekkaTblDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKeiryoShomeiKekkaTblDAOutput output = new UpdateKeiryoShomeiKekkaTblDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 計量証明結果テーブル更新
                tableAdapter.Update(input.KeiryoShomeiKekkaTblDT);

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
