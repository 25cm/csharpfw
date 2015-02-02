using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaDaicho11joHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaDaichoMeisaiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaichoMeisaiDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        string Kbn { get; set; }

        /// <summary>
        /// 依頼年度
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        string IraiNo { get; set; }

        /// <summary>
        /// 試験項目コード
        /// </summary>
        string KomokuCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaichoMeisaiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaichoMeisaiDAInput : ISelectKensaDaichoMeisaiDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string Kbn { get; set; }

        /// <summary>
        /// 依頼年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        public string IraiNo { get; set; }

        /// <summary>
        /// 試験項目コード
        /// </summary>
        public string KomokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaDaichoMeisaiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaichoMeisaiDAOutput
    {
        /// <summary>
        /// KensaDaichoMeisaiDataTable
        /// </summary>
        KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiDataTable KensaDaichoMeisaiDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaichoMeisaiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaichoMeisaiDAOutput : ISelectKensaDaichoMeisaiDAOutput
    {
        /// <summary>
        /// KensaDaichoMeisaiDataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiDataTable KensaDaichoMeisaiDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaichoMeisaiDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/06　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaichoMeisaiDataAccess : BaseDataAccess<ISelectKensaDaichoMeisaiDAInput, ISelectKensaDaichoMeisaiDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaDaichoMeisaiTableAdapter tableAdapter = new KensaDaichoMeisaiTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaDaichoMeisaiDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/06　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaDaichoMeisaiDataAccess()
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
        /// 2014/12/06　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaDaichoMeisaiDAOutput Execute(ISelectKensaDaichoMeisaiDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaDaichoMeisaiDAOutput output = new SelectKensaDaichoMeisaiDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaDaichoMeisaiDT = tableAdapter.GetData(input.Kbn, input.Nendo, input.ShishoCd, input.IraiNo, input.KomokuCd);

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
