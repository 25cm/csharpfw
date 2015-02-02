using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.KeiryoShomeiIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiSuishitsuKensaNippoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiSuishitsuKensaNippoDAInput
    {
        /// <summary>
        /// 水質日報区分
        /// </summary>
        string KeiryoShomeiSuishitsuNippoKbn { get; set; }

        /// <summary>
        /// UpdateDt
        /// </summary>
        DateTime UpdateDt { get; set; }

        /// <summary>
        /// UpdateUser
        /// </summary>
        string UpdateUser { get; set; }

        /// <summary>
        /// UpdateTarm
        /// </summary>
        string UpdateTarm { get; set; }

        /// <summary>
        /// 受付日
        /// </summary>
        string UketsukeDt { get; set; }

        /// <summary>
        /// 支所CD
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        string GyoshaCd { get; set; }

        /// <summary>
        /// 検査種別コード
        /// </summary>
        string ShubetsuCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiSuishitsuKensaNippoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiSuishitsuKensaNippoDAInput : IUpdateKeiryoShomeiSuishitsuKensaNippoDAInput
    {
        /// <summary>
        /// 水質日報区分
        /// </summary>
        public string KeiryoShomeiSuishitsuNippoKbn { get; set; }

        //// <summary>
        /// UpdateDt
        /// </summary>
        public DateTime UpdateDt { get; set; }

        /// <summary>
        /// UpdateUser
        /// </summary>
        public string UpdateUser { get; set; }

        /// <summary>
        /// UpdateTarm
        /// </summary>
        public string UpdateTarm { get; set; }

        /// <summary>
        /// 受付日
        /// </summary>
        public string UketsukeDt { get; set; }

        /// <summary>
        /// 支所CD
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// 検査種別コード
        /// </summary>
        public string ShubetsuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiSuishitsuKensaNippoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiSuishitsuKensaNippoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiSuishitsuKensaNippoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiSuishitsuKensaNippoDAOutput : IUpdateKeiryoShomeiSuishitsuKensaNippoDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiSuishitsuKensaNippoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/07　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiSuishitsuKensaNippoDataAccess : BaseDataAccess<IUpdateKeiryoShomeiSuishitsuKensaNippoDAInput, IUpdateKeiryoShomeiSuishitsuKensaNippoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KeiryoShomeiIraiTblTableAdapter tableAdapter = new KeiryoShomeiIraiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKeiryoShomeiSuishitsuKensaNippoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/07　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKeiryoShomeiSuishitsuKensaNippoDataAccess()
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
        /// 2014/12/07　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKeiryoShomeiSuishitsuKensaNippoDAOutput Execute(IUpdateKeiryoShomeiSuishitsuKensaNippoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKeiryoShomeiSuishitsuKensaNippoDAOutput output = new UpdateKeiryoShomeiSuishitsuKensaNippoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.UpdateKeiryoShomeiSuishitsuKensaNippo(input.KeiryoShomeiSuishitsuNippoKbn,
                                                                    input.UpdateDt,
                                                                    input.UpdateUser,
                                                                    input.UpdateTarm,
                                                                    input.ShishoCd,
                                                                    input.UketsukeDt,
                                                                    input.GyoshaCd,
                                                                    input.ShubetsuCd);

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
