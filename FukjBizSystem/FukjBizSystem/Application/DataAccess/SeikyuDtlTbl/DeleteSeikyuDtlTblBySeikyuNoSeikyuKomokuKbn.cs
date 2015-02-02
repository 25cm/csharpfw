using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.SeikyuDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyuDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
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
    //  クラス名 ： DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput : IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput
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
    //  インターフェイス名 ： IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput : IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess : BaseDataAccess<IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput, IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyuDtlTblTableAdapter tableAdapter = new SeikyuDtlTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDataAccess()
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
        /// 2014/10/03  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput Execute(IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput output = new DeleteSeikyuDtlTblBySeikyuNoSeikyuKomokuKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteBySeikyuNoSeikyuKomokuKbn(input.SeikyuNo, input.SeikyuKomokuKbn);

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
