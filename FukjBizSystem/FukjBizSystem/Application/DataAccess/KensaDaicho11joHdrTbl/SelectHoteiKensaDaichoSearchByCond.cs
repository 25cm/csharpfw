using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaDaicho11joHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectHoteiKensaDaichoSearchByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectHoteiKensaDaichoSearchByCondDAInput
    {
        /// <summary>
        /// Search Condition
        /// </summary>
        HoteiKensaDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoteiKensaDaichoSearchByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoteiKensaDaichoSearchByCondDAInput : ISelectHoteiKensaDaichoSearchByCondDAInput
    {
        /// <summary>
        /// Search Condition
        /// </summary>
        public HoteiKensaDaichoSearchCond SearchCond { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectHoteiKensaDaichoSearchByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectHoteiKensaDaichoSearchByCondDAOutput
    {
        /// <summary>
        /// HoteiKensaDaichoDataTable
        /// </summary>
        KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchDataTable HoteiKensaDaichoDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoteiKensaDaichoSearchByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoteiKensaDaichoSearchByCondDAOutput : ISelectHoteiKensaDaichoSearchByCondDAOutput
    {
        /// <summary>
        /// HoteiKensaDaichoDataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.HoteiKensaDaichoSearchDataTable HoteiKensaDaichoDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoteiKensaDaichoSearchByCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoteiKensaDaichoSearchByCondDataAccess : BaseDataAccess<ISelectHoteiKensaDaichoSearchByCondDAInput, ISelectHoteiKensaDaichoSearchByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private HoteiKensaDaichoSearchTableAdapter tableAdapter = new HoteiKensaDaichoSearchTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectHoteiKensaDaichoSearchByCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/28  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectHoteiKensaDaichoSearchByCondDataAccess()
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
        /// 2014/11/28  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectHoteiKensaDaichoSearchByCondDAOutput Execute(ISelectHoteiKensaDaichoSearchByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectHoteiKensaDaichoSearchByCondDAOutput output = new SelectHoteiKensaDaichoSearchByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.HoteiKensaDaichoDT = tableAdapter.GetDataBySearchCond(input.SearchCond);

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
