using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaDaichoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaDaichoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
        /// <summary>
        /// 試験項目コード
        /// </summary>
        string ShikenkoumokuCd { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        string SuishitsuKensaIraiNo { get; set; }
        /// <summary>
        /// 再検査回数
        /// </summary>
        string SaikensaKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAInput : ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 試験項目コード
        /// </summary>
        public string ShikenkoumokuCd { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        public string SuishitsuKensaIraiNo { get; set; }
        /// <summary>
        /// 再検査回数
        /// </summary>
        public string SaikensaKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput
    {
        /// <summary>
        /// 検査台帳明細テーブル
        /// </summary>
        KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput : ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput
    {
        /// <summary>
        /// 検査台帳明細テーブル
        /// </summary>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDataAccess : BaseDataAccess<ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAInput, ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaDaichoDtlTblTableAdapter tableAdapter
            = new KensaDaichoDtlTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDataAccess()
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
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput Execute(ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput output = new SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaDaichoDtlTblDT = tableAdapter.GetDataByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbn(input.KensaKbn, input.IraiNendo,
                    input.ShishoCd, input.SuishitsuKensaIraiNo, input.ShikenkoumokuCd, input.SaikensaKbn);

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
