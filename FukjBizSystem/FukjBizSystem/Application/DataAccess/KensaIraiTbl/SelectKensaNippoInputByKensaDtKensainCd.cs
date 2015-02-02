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
    //  インターフェイス名 ： ISelectKensaNippoInputByKensaDtKensainCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaNippoInputByKensaDtKensainCdDAInput
    {
        /// <summary>
        /// 検査日
        /// </summary>
        DateTime KensaDt { get; set; }

        /// <summary>
        /// 検査員コード
        /// </summary>
        string KensainCd { get; set; }

        /// <summary>
        /// 1: ADD
        /// 2: EDIT
        /// </summary>
        string Mode { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaNippoInputByKensaDtKensainCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaNippoInputByKensaDtKensainCdDAInput : ISelectKensaNippoInputByKensaDtKensainCdDAInput
    {
        /// <summary>
        /// 検査日
        /// </summary>
        public DateTime KensaDt { get; set; }

        /// <summary>
        /// 検査員コード
        /// </summary>
        public string KensainCd { get; set; }

        /// <summary>
        /// 1: ADD
        /// 2: EDIT
        /// </summary>
        public string Mode { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaNippoInputByKensaDtKensainCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaNippoInputByKensaDtKensainCdDAOutput
    {
        /// <summary>
        /// KensaNippoInputDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaNippoInputDataTable KensaNippoInputDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaNippoInputByKensaDtKensainCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaNippoInputByKensaDtKensainCdDAOutput : ISelectKensaNippoInputByKensaDtKensainCdDAOutput
    {
        /// <summary>
        /// KensaNippoInputDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaNippoInputDataTable KensaNippoInputDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaNippoInputByKensaDtKensainCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaNippoInputByKensaDtKensainCdDataAccess : BaseDataAccess<ISelectKensaNippoInputByKensaDtKensainCdDAInput, ISelectKensaNippoInputByKensaDtKensainCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaNippoInputTableAdapter tableAdapter = new KensaNippoInputTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaNippoInputByKensaDtKensainCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaNippoInputByKensaDtKensainCdDataAccess()
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
        /// 2014/11/20　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaNippoInputByKensaDtKensainCdDAOutput Execute(ISelectKensaNippoInputByKensaDtKensainCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaNippoInputByKensaDtKensainCdDAOutput output = new SelectKensaNippoInputByKensaDtKensainCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaNippoInputDataTable = tableAdapter.GetDataByKensaDtKensainCd(input.KensaDt, input.KensainCd, input.Mode);
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
