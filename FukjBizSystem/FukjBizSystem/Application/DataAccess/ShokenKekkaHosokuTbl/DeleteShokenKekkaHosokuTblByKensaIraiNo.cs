using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.ShokenKekkaHosokuTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShokenKekkaHosokuTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShokenKekkaHosokuTblByKensaIraiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShokenKekkaHosokuTblByKensaIraiNoDAInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShokenKekkaHosokuTblByKensaIraiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShokenKekkaHosokuTblByKensaIraiNoDAInput : IDeleteShokenKekkaHosokuTblByKensaIraiNoDAInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteShokenKekkaHosokuTblByKensaIraiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteShokenKekkaHosokuTblByKensaIraiNoDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShokenKekkaHosokuTblByKensaIraiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShokenKekkaHosokuTblByKensaIraiNoDAOutput : IDeleteShokenKekkaHosokuTblByKensaIraiNoDAOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteShokenKekkaHosokuTblByKensaIraiNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteShokenKekkaHosokuTblByKensaIraiNoDataAccess : BaseDataAccess<IDeleteShokenKekkaHosokuTblByKensaIraiNoDAInput, IDeleteShokenKekkaHosokuTblByKensaIraiNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokenKekkaHosokuTblTableAdapter tableAdapter = new ShokenKekkaHosokuTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteShokenKekkaHosokuTblByKensaIraiNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteShokenKekkaHosokuTblByKensaIraiNoDataAccess()
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
        /// 2014/12/17　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteShokenKekkaHosokuTblByKensaIraiNoDAOutput Execute(IDeleteShokenKekkaHosokuTblByKensaIraiNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteShokenKekkaHosokuTblByKensaIraiNoDAOutput output = new DeleteShokenKekkaHosokuTblByKensaIraiNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 検査依頼番号で削除
                tableAdapter.DeleteByKensaIraiNo(input.KensaIraiHoteiKbn, input.KensaIraiHokenjoCd, input.KensaIraiNendo, input.KensaIraiRenban);
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
