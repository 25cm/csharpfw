using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SuishitsuNippoHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SuishitsuNippoHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuNippoHdrTblByUketsukeDtDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuNippoHdrTblByUketsukeDtDAInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        string UketsukeDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuNippoHdrTblByUketsukeDtDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuNippoHdrTblByUketsukeDtDAInput : ISelectSuishitsuNippoHdrTblByUketsukeDtDAInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        public string UketsukeDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSuishitsuNippoHdrTblByUketsukeDtDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSuishitsuNippoHdrTblByUketsukeDtDAOutput
    {
        /// <summary>
        /// SuishitsuNippoHdrTblDataTable
        /// </summary>
        SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblDataTable SuishitsuNippoHdrTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuNippoHdrTblByUketsukeDtDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuNippoHdrTblByUketsukeDtDAOutput : ISelectSuishitsuNippoHdrTblByUketsukeDtDAOutput
    {
        /// <summary>
        /// SuishitsuNippoHdrTblDataTable
        /// </summary>
        public SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblDataTable SuishitsuNippoHdrTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSuishitsuNippoHdrTblByUketsukeDtDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSuishitsuNippoHdrTblByUketsukeDtDataAccess : BaseDataAccess<ISelectSuishitsuNippoHdrTblByUketsukeDtDAInput, ISelectSuishitsuNippoHdrTblByUketsukeDtDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SuishitsuNippoHdrTblTableAdapter tableAdapter = new SuishitsuNippoHdrTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSuishitsuNippoHdrTblByUketsukeDtDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSuishitsuNippoHdrTblByUketsukeDtDataAccess()
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
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSuishitsuNippoHdrTblByUketsukeDtDAOutput Execute(ISelectSuishitsuNippoHdrTblByUketsukeDtDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSuishitsuNippoHdrTblByUketsukeDtDAOutput output = new SelectSuishitsuNippoHdrTblByUketsukeDtDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SuishitsuNippoHdrTblDT = tableAdapter.GetDataBySuishitsuUketsukeDt(input.UketsukeDt);

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
