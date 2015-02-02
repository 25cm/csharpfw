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
    //  インターフェイス名 ： ISelectMaeukekinTblBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  DatNT　  新規作成
    /// 2014/11/10  DatNT   v1.02
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMaeukekinTblBySearchCondDAInput
    {
        // 2014/11/10 DatNT v1.02 MOD Start

        ///// <summary>
        ///// 採番区分
        ///// 採番区分 両方           : string.Empty
        ///// 採番区分 振込用紙記載No  : 0
        ///// 採番区分 自動採番        : 1
        ///// </summary>
        //string SaibanKbn { get; set; }

        ///// <summary>
        ///// 前受金No（開始）
        ///// </summary>
        //string MaeukeNoFrom { get; set; }

        ///// <summary>
        ///// 前受金No（終了）
        ///// </summary>
        //string MaeukeNoTo { get; set; }

        /// <summary>
        /// 連動区分
        /// </summary>
        string RendoKbn { get; set; }

        /// <summary>
        /// 前受金No
        /// </summary>
        string MaeukeNo { get; set; }

        /// <summary>
        /// 売上日検索使用フラグ
        /// </summary>
        bool UriageDtUse { get; set; }

        /// <summary>
        /// 売上日（開始）
        /// </summary>
        string UriageDtFrom { get; set; }

        /// <summary>
        /// 売上日（終了）
        /// </summary>
        string UriageDtTo { get; set; }

        /// <summary>
        /// 強制売上のみフラグ
        /// </summary>
        bool KyoseiUriage { get; set; }

        // 2014/11/10 DatNT v1.02 MOD End

        /// <summary>
        /// 振込人
        /// </summary>
        string FurikomininNm { get; set; }

        /// <summary>
        /// 入金日検索使用フラグ
        /// </summary>
        bool NyukinDtUse { get; set; }

        /// <summary>
        /// 入金日（開始）
        /// </summary>
        string NyukinDtFrom { get; set; }

        /// <summary>
        /// 入金日（終了）
        /// </summary>
        string NyukinDtTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaeukekinTblBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  DatNT　  新規作成
    /// 2014/11/10  DatNT   v1.02
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMaeukekinTblBySearchCondDAInput : ISelectMaeukekinTblBySearchCondDAInput
    {
        // 2014/11/10 DatNT v1.02 MOD Start

        ///// <summary>
        ///// 採番区分
        ///// 採番区分 両方           : string.Empty
        ///// 採番区分 振込用紙記載No  : 0
        ///// 採番区分 自動採番        : 1
        ///// </summary>
        //public string SaibanKbn { get; set; }

        ///// <summary>
        ///// 前受金No（開始）
        ///// </summary>
        //public string MaeukeNoFrom { get; set; }

        ///// <summary>
        ///// 前受金No（終了）
        ///// </summary>
        //public string MaeukeNoTo { get; set; }

        /// <summary>
        /// 連動区分
        /// </summary>
        public string RendoKbn { get; set; }

        /// <summary>
        /// 前受金No
        /// </summary>
        public string MaeukeNo { get; set; }

        /// <summary>
        /// 売上日検索使用フラグ
        /// </summary>
        public bool UriageDtUse { get; set; }

        /// <summary>
        /// 売上日（開始）
        /// </summary>
        public string UriageDtFrom { get; set; }

        /// <summary>
        /// 売上日（終了）
        /// </summary>
        public string UriageDtTo { get; set; }

        /// <summary>
        /// 強制売上のみフラグ
        /// </summary>
        public bool KyoseiUriage { get; set; }

        // 2014/11/10 DatNT v1.02 MOD End

        /// <summary>
        /// 振込人
        /// </summary>
        public string FurikomininNm { get; set; }

        /// <summary>
        /// 入金日検索使用フラグ
        /// </summary>
        public bool NyukinDtUse { get; set; }

        /// <summary>
        /// 入金日（開始）
        /// </summary>
        public string NyukinDtFrom { get; set; }

        /// <summary>
        /// 入金日（終了）
        /// </summary>
        public string NyukinDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMaeukekinTblBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMaeukekinTblBySearchCondDAOutput
    {
        /// <summary>
        /// MaeukekinTblKensakuDataTable
        /// </summary>
        MaeukekinTblDataSet.MaeukekinTblKensakuDataTable MaeukekinTblKensakuDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaeukekinTblBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMaeukekinTblBySearchCondDAOutput : ISelectMaeukekinTblBySearchCondDAOutput
    {
        /// <summary>
        /// MaeukekinTblKensakuDataTable
        /// </summary>
        public MaeukekinTblDataSet.MaeukekinTblKensakuDataTable MaeukekinTblKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMaeukekinTblBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMaeukekinTblBySearchCondDataAccess : BaseDataAccess<ISelectMaeukekinTblBySearchCondDAInput, ISelectMaeukekinTblBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private MaeukekinTblKensakuTableAdapter tableAdapter = new MaeukekinTblKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMaeukekinTblBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectMaeukekinTblBySearchCondDataAccess()
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
        /// 2014/07/18  DatNT　  新規作成
        /// 2014/11/10  DatNT    v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectMaeukekinTblBySearchCondDAOutput Execute(ISelectMaeukekinTblBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMaeukekinTblBySearchCondDAOutput output = new SelectMaeukekinTblBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                //output.MaeukekinTblKensakuDT = tableAdapter.GetDataBySearchCond(input.SaibanKbn,
                //                                                                input.MaeukeNoFrom,
                //                                                                input.MaeukeNoTo,
                //                                                                DataAccessUtility.EscapeSQLString(input.FurikomininNm),
                //                                                                input.NyukinDtUse,
                //                                                                input.NyukinDtFrom,
                //                                                                input.NyukinDtTo);

                output.MaeukekinTblKensakuDT = tableAdapter.GetDataBySearchCond(input.RendoKbn,
                                                                                input.MaeukeNo,
                                                                                input.UriageDtUse,
                                                                                input.UriageDtFrom,
                                                                                input.UriageDtTo,
                                                                                input.KyoseiUriage,
                                                                                DataAccessUtility.EscapeSQLString(input.FurikomininNm),
                                                                                input.NyukinDtUse,
                                                                                input.NyukinDtFrom,
                                                                                input.NyukinDtTo);

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
