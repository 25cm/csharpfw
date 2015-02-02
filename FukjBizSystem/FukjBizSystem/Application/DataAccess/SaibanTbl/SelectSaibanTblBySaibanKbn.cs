using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SaibanTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SaibanTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSaibanTblBySaibanKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSaibanTblBySaibanKbnDAInput
    {
        /// <summary>
        /// 採番区分
        /// </summary>
        String SaibanKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSaibanTblBySaibanKbnDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSaibanTblBySaibanKbnDAInput : ISelectSaibanTblBySaibanKbnDAInput
    {
        /// <summary>
        /// 採番区分
        /// </summary>
        public String SaibanKbn { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("採番区分[{0}]",
                    new string[]{
                        SaibanKbn
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSaibanTblBySaibanKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSaibanTblBySaibanKbnDAOutput
    {
        /// <summary>
        /// SaibanTblDataTable
        /// </summary>
        SaibanTblDataSet.SaibanKetasuSearchDataTable SaibanTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSaibanTblBySaibanKbnDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSaibanTblBySaibanKbnDAOutput : ISelectSaibanTblBySaibanKbnDAOutput
    {
        /// <summary>
        /// SaibanTblDataTable
        /// </summary>
        public SaibanTblDataSet.SaibanKetasuSearchDataTable SaibanTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSaibanTblBySaibanKbnDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  宗　　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSaibanTblBySaibanKbnDataAccess : BaseDataAccess<ISelectSaibanTblBySaibanKbnDAInput, ISelectSaibanTblBySaibanKbnDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SaibanKetasuSearchTableAdapter tableAdapter = new SaibanKetasuSearchTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSaibanTblBySaibanKbnDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSaibanTblBySaibanKbnDataAccess()
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
        /// 2014/07/29  宗　　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSaibanTblBySaibanKbnDAOutput Execute(ISelectSaibanTblBySaibanKbnDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSaibanTblBySaibanKbnDAOutput output = new SelectSaibanTblBySaibanKbnDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SaibanTblDT = tableAdapter.GetDataBySaibanKbn(input.SaibanKbn);

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
