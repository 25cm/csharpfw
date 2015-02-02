using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.NippoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NippoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGeppoShukeiByNengetsuDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectGeppoShukeiByNengetsuDAInput
    {
        /// <summary>
        /// 集計対象年月
        /// </summary>
        string ShukeiNengetsu { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGeppoShukeiByNengetsuDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGeppoShukeiByNengetsuDAInput : ISelectGeppoShukeiByNengetsuDAInput
    {
        /// <summary>
        /// 集計対象年月
        /// </summary>
        public string ShukeiNengetsu { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGeppoShukeiByNengetsuDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectGeppoShukeiByNengetsuDAOutput
    {
        /// <summary>
        /// 検査員別検査集計
        /// </summary>
        NippoDtlTblDataSet.NippoDtlGeppoShukeiDataTable GeoppoShukeiDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGeppoShukeiByNengetsuDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGeppoShukeiByNengetsuDAOutput : ISelectGeppoShukeiByNengetsuDAOutput
    {
        /// <summary>
        /// 検査員別検査集計
        /// </summary>
        public NippoDtlTblDataSet.NippoDtlGeppoShukeiDataTable GeoppoShukeiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGeppoShukeiByNengetsuDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGeppoShukeiByNengetsuDataAccess : BaseDataAccess<ISelectGeppoShukeiByNengetsuDAInput, ISelectGeppoShukeiByNengetsuDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NippoDtlGeppoShukeiTableAdapter tableAdapter = new NippoDtlGeppoShukeiTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectGeppoShukeiByNengetsuDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/22　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectGeppoShukeiByNengetsuDataAccess()
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
        /// 2014/12/22　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectGeppoShukeiByNengetsuDAOutput Execute(ISelectGeppoShukeiByNengetsuDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectGeppoShukeiByNengetsuDAOutput output = new SelectGeppoShukeiByNengetsuDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                string fromDate = input.ShukeiNengetsu + "01";
                string toDate = input.ShukeiNengetsu + "31";

                output.GeoppoShukeiDataTable = tableAdapter.GetDataByShukeiNengetsu(fromDate, toDate);
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
