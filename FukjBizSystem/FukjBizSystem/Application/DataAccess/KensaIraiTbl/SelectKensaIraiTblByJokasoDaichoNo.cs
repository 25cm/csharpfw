using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaIraiTblByJokasoDaichoNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　小松　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraiTblByJokasoDaichoNoDAInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        string KensaIraiJokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiTblByJokasoDaichoNoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　小松　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiTblByJokasoDaichoNoDAInput : ISelectKensaIraiTblByJokasoDaichoNoDAInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード
        /// </summary>
        public string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        public string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        public string KensaIraiJokasoRenban { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaIraiTblByJokasoDaichoNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　小松　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraiTblByJokasoDaichoNoDAOutput
    {
        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiTblByJokasoDaichoNoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　小松　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiTblByJokasoDaichoNoDAOutput : ISelectKensaIraiTblByJokasoDaichoNoDAOutput
    {
        /// <summary>
        /// 検査依頼テーブル
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTblDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiTblByJokasoDaichoNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　小松　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiTblByJokasoDaichoNoDataAccess : BaseDataAccess<ISelectKensaIraiTblByJokasoDaichoNoDAInput, ISelectKensaIraiTblByJokasoDaichoNoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaIraiTblTableAdapter tableAdapter = new KensaIraiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaIraiTblByJokasoDaichoNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30　小松　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaIraiTblByJokasoDaichoNoDataAccess()
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
        /// 2015/01/30　小松　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaIraiTblByJokasoDaichoNoDAOutput Execute(ISelectKensaIraiTblByJokasoDaichoNoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaIraiTblByJokasoDaichoNoDAOutput output = new SelectKensaIraiTblByJokasoDaichoNoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaIraiTblDT = tableAdapter.GetDataByJokasoDaichoKey(input.KensaIraiJokasoHokenjoCd, input.KensaIraiJokasoTorokuNendo, input.KensaIraiJokasoRenban);
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
