using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SeikyuDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyuDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
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
    interface ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
    {
        /// <summary>
        /// 請求No 
        /// </summary>
        string SeikyuNo { get; set; }

        /// <summary>
        /// 請求項目区分
        /// </summary>
        string SeikyuKomokuKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
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
    class SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput : ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
    {
        /// <summary>
        /// 請求No 
        /// </summary>
        public string SeikyuNo { get; set; }

        /// <summary>
        /// 請求項目区分
        /// </summary>
        public string SeikyuKomokuKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
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
    interface ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
    {
        /// <summary>
        /// SeikyuDtlTblDataTable
        /// </summary>
        SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
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
    class SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput : ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
    {
        /// <summary>
        /// SeikyuDtlTblDataTable
        /// </summary>
        public SeikyuDtlTblDataSet.SeikyuDtlTblDataTable SeikyuDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess
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
    class SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess : BaseDataAccess<ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput, ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyuDtlTblTableAdapter tableAdapter = new SeikyuDtlTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess
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
        public SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess()
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
        public override ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput Execute(ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput output = new SelectSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SeikyuDtlTblDT = tableAdapter.GetDataBySeikyuNoSeikyuKomokuKbn(input.SeikyuNo, input.SeikyuKomokuKbn);

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
