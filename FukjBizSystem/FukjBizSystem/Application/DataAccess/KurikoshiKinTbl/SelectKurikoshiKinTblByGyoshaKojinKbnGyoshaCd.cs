using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KurikoshiKinTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KurikoshiKinTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAInput
    {
        /// <summary>
        /// 業者個人区分
        /// </summary>
        string GyosyaKojinKbn { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        string GyoshaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAInput : ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAInput
    {
        /// <summary>
        /// 業者個人区分
        /// </summary>
        public string GyosyaKojinKbn { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput
    {
        /// <summary>
        /// 繰越金テーブル
        /// </summary>
        KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput : ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput
    {
        /// <summary>
        /// 繰越金テーブル
        /// </summary>
        public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDataAccess : BaseDataAccess<ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAInput, ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KurikoshiKinTblTableAdapter tableAdapter = new KurikoshiKinTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDataAccess()
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
        /// 2014/11/06　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput Execute(ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput output = new SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KurikoshiKinTblDataTable = tableAdapter.GetDataByGyoshaKojinKbnGyoshaCd(input.GyosyaKojinKbn, input.GyoshaCd);
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
