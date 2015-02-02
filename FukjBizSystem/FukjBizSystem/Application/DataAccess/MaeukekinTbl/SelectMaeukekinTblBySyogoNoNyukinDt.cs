using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.MaeukekinTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.MaeukekinTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMaeukekinTblBySyogoNoNyukinDtDAInput
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
    interface ISelectMaeukekinTblBySyogoNoNyukinDtDAInput
    {
        /// <summary>
        /// 前受照合番号１
        /// </summary>
        string MaeukekinSyogoNo1 { get; set; }

        /// <summary>
        /// 前受照合番号２
        /// </summary>
        string MaeukekinSyogoNo2 { get; set; }

        /// <summary>
        /// 入金日付
        /// </summary>
        string MaeukekinNyukinDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaeukekinTblBySyogoNoNyukinDtDAInput
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
    class SelectMaeukekinTblBySyogoNoNyukinDtDAInput : ISelectMaeukekinTblBySyogoNoNyukinDtDAInput
    {
        /// <summary>
        /// 前受照合番号１
        /// </summary>
        public string MaeukekinSyogoNo1 { get; set; }

        /// <summary>
        /// 前受照合番号２
        /// </summary>
        public string MaeukekinSyogoNo2 { get; set; }

        /// <summary>
        /// 入金日付
        /// </summary>
        public string MaeukekinNyukinDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMaeukekinTblBySyogoNoNyukinDtDAOutput
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
    interface ISelectMaeukekinTblBySyogoNoNyukinDtDAOutput
    {
        /// <summary>
        /// 前受金テーブル
        /// </summary>
        MaeukekinTblDataSet.MaeukekinTblDataTable MaeukekinTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaeukekinTblBySyogoNoNyukinDtDAOutput
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
    class SelectMaeukekinTblBySyogoNoNyukinDtDAOutput : ISelectMaeukekinTblBySyogoNoNyukinDtDAOutput
    {
        /// <summary>
        /// 前受金テーブル
        /// </summary>
        public MaeukekinTblDataSet.MaeukekinTblDataTable MaeukekinTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaeukekinTblBySyogoNoNyukinDtDataAccess
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
    class SelectMaeukekinTblBySyogoNoNyukinDtDataAccess : BaseDataAccess<ISelectMaeukekinTblBySyogoNoNyukinDtDAInput, ISelectMaeukekinTblBySyogoNoNyukinDtDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private MaeukekinTblTableAdapter tableAdapter = new MaeukekinTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMaeukekinTblBySyogoNoNyukinDtDataAccess
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
        public SelectMaeukekinTblBySyogoNoNyukinDtDataAccess()
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
        public override ISelectMaeukekinTblBySyogoNoNyukinDtDAOutput Execute(ISelectMaeukekinTblBySyogoNoNyukinDtDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMaeukekinTblBySyogoNoNyukinDtDAOutput output = new SelectMaeukekinTblBySyogoNoNyukinDtDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.MaeukekinTblDataTable = tableAdapter.GetDataBySyogoNoNyukinDt(input.MaeukekinSyogoNo1, input.MaeukekinSyogoNo2, input.MaeukekinNyukinDt);
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
