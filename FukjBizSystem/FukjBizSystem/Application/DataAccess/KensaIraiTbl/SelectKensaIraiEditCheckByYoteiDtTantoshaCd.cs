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
    //  インターフェイス名 ： ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAInput
    {
        /// <summary>
        /// 検査予定年/検査予定月/検査予定日
        /// </summary>
        string YoteiDt { get; set; }

        /// <summary>
        /// 外観検査担当者コード
        /// </summary>
        string KensaIraiKensaTantoshaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiEditCheckByYoteiDtTantoshaCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiEditCheckByYoteiDtTantoshaCdDAInput : ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAInput
    {
        /// <summary>
        /// 検査予定年/検査予定月/検査予定日
        /// </summary>
        public string YoteiDt { get; set; }

        /// <summary>
        /// 外観検査担当者コード
        /// </summary>
        public string KensaIraiKensaTantoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput
    {
        /// <summary>
        /// KensaIraiEditCheckDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaIraiEditCheckDataTable KensaIraiEditCheckDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput : ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput
    {
        /// <summary>
        /// KensaIraiEditCheckDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiEditCheckDataTable KensaIraiEditCheckDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaIraiEditCheckByYoteiDtTantoshaCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaIraiEditCheckByYoteiDtTantoshaCdDataAccess : BaseDataAccess<ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAInput, ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaIraiEditCheckTableAdapter tableAdapter = new KensaIraiEditCheckTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaIraiEditCheckByYoteiDtTantoshaCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaIraiEditCheckByYoteiDtTantoshaCdDataAccess()
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
        /// 2014/11/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput Execute(ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput output = new SelectKensaIraiEditCheckByYoteiDtTantoshaCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaIraiEditCheckDataTable = tableAdapter.GetDataByYoteiDtTantoshaCd(input.YoteiDt, input.KensaIraiKensaTantoshaCd);
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
