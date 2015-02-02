using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.YoshiHanbaiHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.YoshiHanbaiHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYoshiHanbaiHdrTblBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYoshiHanbaiHdrTblBySearchCondDAInput
    {
        /// <summary>
        /// GyoshaCd
        /// </summary>
        string GyoshaCd { get; set; }

        /// <summary>
        /// YoshiHanbaiChumonNoFrom
        /// </summary>
        string YoshiHanbaiChumonNoFrom { get; set; }

        /// <summary>
        /// YoshiHanbaiChumonNoTo
        /// </summary>
        string YoshiHanbaiChumonNoTo { get; set; }

        /// <summary>
        /// YoshiHanbaiDtFrom
        /// </summary>
        string YoshiHanbaiDtFrom { get; set; }

        /// <summary>
        /// YoshiHanbaiDtTo
        /// </summary>
        string YoshiHanbaiDtTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYoshiHanbaiHdrTblBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYoshiHanbaiHdrTblBySearchCondDAInput : ISelectYoshiHanbaiHdrTblBySearchCondDAInput
    {
        /// <summary>
        /// GyoshaCd
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// YoshiHanbaiChumonNoFrom
        /// </summary>
        public string YoshiHanbaiChumonNoFrom { get; set; }

        /// <summary>
        /// YoshiHanbaiChumonNoTo
        /// </summary>
        public string YoshiHanbaiChumonNoTo { get; set; }

        /// <summary>
        /// YoshiHanbaiDtFrom
        /// </summary>
        public string YoshiHanbaiDtFrom { get; set; }

        /// <summary>
        /// YoshiHanbaiDtTo
        /// </summary>
        public string YoshiHanbaiDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectYoshiHanbaiHdrTblBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectYoshiHanbaiHdrTblBySearchCondDAOutput
    {
        /// <summary>
        /// YoshiHanbaiHdrTblKensakuDT
        /// </summary>
        YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblKensakuDataTable YoshiHanbaiHdrTblKensakuDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYoshiHanbaiHdrTblBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYoshiHanbaiHdrTblBySearchCondDAOutput : ISelectYoshiHanbaiHdrTblBySearchCondDAOutput
    {
        /// <summary>
        /// YoshiHanbaiHdrTblKensakuDT
        /// </summary>
        public YoshiHanbaiHdrTblDataSet.YoshiHanbaiHdrTblKensakuDataTable YoshiHanbaiHdrTblKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectYoshiHanbaiHdrTblBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/23　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectYoshiHanbaiHdrTblBySearchCondDataAccess : BaseDataAccess<ISelectYoshiHanbaiHdrTblBySearchCondDAInput, ISelectYoshiHanbaiHdrTblBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private YoshiHanbaiHdrTblKensakuTableAdapter tableAdapter = new YoshiHanbaiHdrTblKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectYoshiHanbaiHdrTblBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/23　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectYoshiHanbaiHdrTblBySearchCondDataAccess()
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
        /// 2014/07/23　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectYoshiHanbaiHdrTblBySearchCondDAOutput Execute(ISelectYoshiHanbaiHdrTblBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectYoshiHanbaiHdrTblBySearchCondDAOutput output = new SelectYoshiHanbaiHdrTblBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.YoshiHanbaiHdrTblKensakuDT = tableAdapter.GetDataBySearchCond(input.GyoshaCd, 
                    input.YoshiHanbaiChumonNoFrom, 
                    input.YoshiHanbaiChumonNoTo, 
                    input.YoshiHanbaiDtFrom, 
                    input.YoshiHanbaiDtTo);

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
