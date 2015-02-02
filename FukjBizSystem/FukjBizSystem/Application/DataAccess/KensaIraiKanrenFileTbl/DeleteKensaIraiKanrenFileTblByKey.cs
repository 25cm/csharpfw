using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanrenFileTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaIraiKanrenFileTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensaIraiKanrenFileTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensaIraiKanrenFileTblByKeyDAInput
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

        /// <summary>
        /// 関連ファイル種別
        /// </summary>
        string KensaIraiFileShubetsuCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaIraiKanrenFileTblByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaIraiKanrenFileTblByKeyDAInput : IDeleteKensaIraiKanrenFileTblByKeyDAInput
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

        /// <summary>
        /// 関連ファイル種別
        /// </summary>
        public string KensaIraiFileShubetsuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensaIraiKanrenFileTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensaIraiKanrenFileTblByKeyDAOutput
    {
        /// <summary>
        /// 検査依頼関連ファイルテーブル
        /// </summary>
        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaIraiKanrenFileTblByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaIraiKanrenFileTblByKeyDAOutput : IDeleteKensaIraiKanrenFileTblByKeyDAOutput
    {
        /// <summary>
        /// 検査依頼関連ファイルテーブル
        /// </summary>
        public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensaIraiKanrenFileTblByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensaIraiKanrenFileTblByKeyDataAccess : BaseDataAccess<IDeleteKensaIraiKanrenFileTblByKeyDAInput, IDeleteKensaIraiKanrenFileTblByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaIraiKanrenFileTblTableAdapter tableAdapter = new KensaIraiKanrenFileTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteKensaIraiKanrenFileTblByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteKensaIraiKanrenFileTblByKeyDataAccess()
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
        /// 2014/11/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteKensaIraiKanrenFileTblByKeyDAOutput Execute(IDeleteKensaIraiKanrenFileTblByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteKensaIraiKanrenFileTblByKeyDAOutput output = new DeleteKensaIraiKanrenFileTblByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteByKey(input.KensaIraiHoteiKbn, input.KensaIraiHokenjoCd, input.KensaIraiNendo, input.KensaIraiRenban, input.KensaIraiFileShubetsuCd);
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
