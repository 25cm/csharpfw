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
    //  インターフェイス名 ： ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAInput
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
    interface ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAInput
    {
        /// <summary>
        /// 業者個人区分
        /// </summary>
        string GyosyaKojinKbn { get; set; }
        
        /// <summary>
        /// 浄化槽保健所コード
        /// </summary>
        string JokasoHokenjoCd { get; set; }
        
        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        string JokasoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAInput
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
    class SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAInput : ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAInput
    {
        /// <summary>
        /// 業者個人区分
        /// </summary>
        public string GyosyaKojinKbn { get; set; }

        /// <summary>
        /// 浄化槽保健所コード
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput
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
    interface ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput
    {
        /// <summary>
        /// 繰越金テーブル
        /// </summary>
        KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput
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
    class SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput : ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput
    {
        /// <summary>
        /// 繰越金テーブル
        /// </summary>
        public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDataAccess
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
    class SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDataAccess : BaseDataAccess<ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAInput, ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KurikoshiKinTblTableAdapter tableAdapter = new KurikoshiKinTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDataAccess
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
        public SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDataAccess()
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
        public override ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput Execute(ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput output = new SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KurikoshiKinTblDataTable = tableAdapter.GetDataByGyoshaKojinKbnJokasoKey(input.GyosyaKojinKbn,
                    input.JokasoHokenjoCd,
                    input.JokasoTorokuNendo,
                    input.JokasoRenban);
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
