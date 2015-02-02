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
    //  インターフェイス名 ： ISelectGeppoKadouShukeiByNengetsuDAInput
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
    interface ISelectGeppoKadouShukeiByNengetsuDAInput
    {
        /// <summary>
        /// 集計対象年月
        /// </summary>
        string ShukeiNengetsu { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGeppoKadouShukeiByNengetsuDAInput
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
    class SelectGeppoKadouShukeiByNengetsuDAInput : ISelectGeppoKadouShukeiByNengetsuDAInput
    {
        /// <summary>
        /// 集計対象年月
        /// </summary>
        public string ShukeiNengetsu { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGeppoKadouShukeiByNengetsuDAOutput
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
    interface ISelectGeppoKadouShukeiByNengetsuDAOutput
    {
        /// <summary>
        /// 検査員別稼動日集計
        /// </summary>
        NippoDtlTblDataSet.NippoHdrGeppoKadouShukeiDataTable GeoppoShukeiKadouDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGeppoKadouShukeiByNengetsuDAOutput
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
    class SelectGeppoKadouShukeiByNengetsuDAOutput : ISelectGeppoKadouShukeiByNengetsuDAOutput
    {
        /// <summary>
        /// 検査員別稼動日集計
        /// </summary>
        public NippoDtlTblDataSet.NippoHdrGeppoKadouShukeiDataTable GeoppoShukeiKadouDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGeppoKadouShukeiByNengetsuDataAccess
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
    class SelectGeppoKadouShukeiByNengetsuDataAccess : BaseDataAccess<ISelectGeppoKadouShukeiByNengetsuDAInput, ISelectGeppoKadouShukeiByNengetsuDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NippoHdrGeppoKadouShukeiTableAdapter tableAdapter = new NippoHdrGeppoKadouShukeiTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectGeppoKadouShukeiByNengetsuDataAccess
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
        public SelectGeppoKadouShukeiByNengetsuDataAccess()
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
        public override ISelectGeppoKadouShukeiByNengetsuDAOutput Execute(ISelectGeppoKadouShukeiByNengetsuDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectGeppoKadouShukeiByNengetsuDAOutput output = new SelectGeppoKadouShukeiByNengetsuDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                string fromDate = input.ShukeiNengetsu + "01";
                string toDate = input.ShukeiNengetsu + "31";

                output.GeoppoShukeiKadouDataTable = tableAdapter.GetDataByShukeiNengetsu(fromDate, toDate);
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
