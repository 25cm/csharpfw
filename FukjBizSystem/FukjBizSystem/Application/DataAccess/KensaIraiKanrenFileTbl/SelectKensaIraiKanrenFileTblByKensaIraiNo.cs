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
    //  インターフェイス名 ： ISelectKensaIraiKanrenFileTblByKensaIraiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17  小松　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraiKanrenFileTblByKensaIraiNoDAInput
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
    //  クラス名 ： SelectKensaIraiKanrenFileTblByKensaIraiNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17  小松　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiKanrenFileTblByKensaIraiNoDAInput : ISelectKensaIraiKanrenFileTblByKensaIraiNoDAInput
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
    //  インターフェイス名 ： ISelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17  小松　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput
    {
        /// <summary>
        /// KensaIraiKanrenFileTblDataTable
        /// </summary>
        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17  小松　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput : ISelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput
    {
        /// <summary>
        /// KensaIraiKanrenFileTblDataTable
        /// </summary>
        public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiKanrenFileTblByKensaIraiNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17  小松　      新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiKanrenFileTblByKensaIraiNoDataAccess : BaseDataAccess<ISelectKensaIraiKanrenFileTblByKensaIraiNoDAInput, ISelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaIraiKanrenFileTblTableAdapter tableAdapter = new KensaIraiKanrenFileTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaIraiKanrenFileTblByKensaIraiNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/17  小松　      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaIraiKanrenFileTblByKensaIraiNoDataAccess()
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
        /// 2014/12/17  小松　      新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput Execute(ISelectKensaIraiKanrenFileTblByKensaIraiNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput output = new SelectKensaIraiKanrenFileTblByKensaIraiNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // 検査依頼番号でデータを取得（ｎ件）
                output.KensaIraiKanrenFileTblDT = tableAdapter.GetDataByKensaIraiKey(input.KensaIraiHoteiKbn, 
                                                                            input.KensaIraiHokenjoCd, 
                                                                            input.KensaIraiNendo, 
                                                                            input.KensaIraiRenban);

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
