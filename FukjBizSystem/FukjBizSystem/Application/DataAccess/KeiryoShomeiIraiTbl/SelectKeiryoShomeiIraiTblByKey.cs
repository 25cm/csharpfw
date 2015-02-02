using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KeiryoShomeiIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKeiryoShomeiIraiTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKeiryoShomeiIraiTblByKeyDAInput
    {
        /// <summary>
        /// 計量証明検査依頼年度
        /// </summary>
        string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// 計量証明支所コード
        /// </summary>
        string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// 計量証明依頼連番
        /// </summary>
        string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiIraiTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiIraiTblByKeyDAInput : ISelectKeiryoShomeiIraiTblByKeyDAInput
    {
        /// <summary>
        /// 計量証明検査依頼年度
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// 計量証明支所コード
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// 計量証明依頼連番
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKeiryoShomeiIraiTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKeiryoShomeiIraiTblByKeyDAOutput
    {
        /// <summary>
        /// KeiryoShomeiIraiTblDataTable
        /// </summary>
        KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiIraiTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiIraiTblByKeyDAOutput : ISelectKeiryoShomeiIraiTblByKeyDAOutput
    {
        /// <summary>
        /// KeiryoShomeiIraiTblDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiIraiTblDataTable KeiryoShomeiIraiTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiIraiTblByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiIraiTblByKeyDataAccess : BaseDataAccess<ISelectKeiryoShomeiIraiTblByKeyDAInput, ISelectKeiryoShomeiIraiTblByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KeiryoShomeiIraiTblTableAdapter tableAdapter = new KeiryoShomeiIraiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKeiryoShomeiIraiTblByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKeiryoShomeiIraiTblByKeyDataAccess()
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
        /// 2014/10/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKeiryoShomeiIraiTblByKeyDAOutput Execute(ISelectKeiryoShomeiIraiTblByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKeiryoShomeiIraiTblByKeyDAOutput output = new SelectKeiryoShomeiIraiTblByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KeiryoShomeiIraiTblDT = tableAdapter.GetDataByKey(input.KeiryoShomeiIraiNendo, input.KeiryoShomeiIraiSishoCd, input.KeiryoShomeiIraiRenban);
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
