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
    //  インターフェイス名 ： ISelectKeiryoShomeiKekkaTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗        　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKeiryoShomeiKekkaTblByKeyDAInput
    {
        /// <summary>
        /// 計量証明結果依頼年度
        /// </summary>
        string KeiryoShomeiKekkaIraiNendo { get; set; }

        /// <summary>
        /// 計量証明結果依頼支所コード
        /// </summary>
        string KeiryoShomeiKekkaIraiShishoCd { get; set; }

        /// <summary>
        /// 計量証明結果依頼番号
        /// </summary>
        string KeiryoShomeiKekkaIraiNo { get; set; }

        /// <summary>
        /// 計量証明試験項目コード
        /// </summary>
        string KeiryoShomeiShikenkoumokuCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiKekkaTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗        　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiKekkaTblByKeyDAInput : ISelectKeiryoShomeiKekkaTblByKeyDAInput
    {
        /// <summary>
        /// 計量証明結果依頼年度
        /// </summary>
        public string KeiryoShomeiKekkaIraiNendo { get; set; }

        /// <summary>
        /// 計量証明結果依頼支所コード
        /// </summary>
        public string KeiryoShomeiKekkaIraiShishoCd { get; set; }

        /// <summary>
        /// 計量証明結果依頼番号
        /// </summary>
        public string KeiryoShomeiKekkaIraiNo { get; set; }

        /// <summary>
        /// 計量証明試験項目コード
        /// </summary>
        public string KeiryoShomeiShikenkoumokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKeiryoShomeiKekkaTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗        　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKeiryoShomeiKekkaTblByKeyDAOutput
    {
        /// <summary>
        /// KeiryoShomeiKekkaTblDataTable
        /// </summary>
        KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable KeiryoShomeiKekkaTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiKekkaTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗        　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiKekkaTblByKeyDAOutput : ISelectKeiryoShomeiKekkaTblByKeyDAOutput
    {
        /// <summary>
        /// KeiryoShomeiKekkaTblDataTable
        /// </summary>
        public KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable KeiryoShomeiKekkaTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiKekkaTblByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  宗        　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiKekkaTblByKeyDataAccess : BaseDataAccess<ISelectKeiryoShomeiKekkaTblByKeyDAInput, ISelectKeiryoShomeiKekkaTblByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KeiryoShomeiKekkaTblTableAdapter tableAdapter = new KeiryoShomeiKekkaTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKeiryoShomeiKekkaTblByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  宗      　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKeiryoShomeiKekkaTblByKeyDataAccess()
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
        /// 2014/12/08  宗      　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKeiryoShomeiKekkaTblByKeyDAOutput Execute(ISelectKeiryoShomeiKekkaTblByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKeiryoShomeiKekkaTblByKeyDAOutput output = new SelectKeiryoShomeiKekkaTblByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KeiryoShomeiKekkaTblDT = tableAdapter.GetDataByKey(
                    input.KeiryoShomeiKekkaIraiNendo,
                    input.KeiryoShomeiKekkaIraiShishoCd,
                    input.KeiryoShomeiKekkaIraiNo,
                    input.KeiryoShomeiShikenkoumokuCd);

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
