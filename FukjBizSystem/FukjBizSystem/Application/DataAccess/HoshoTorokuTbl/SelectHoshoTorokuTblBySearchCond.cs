using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.HoshoTorokuTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.HoshoTorokuTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectHoshoTorokuTblBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectHoshoTorokuTblBySearchCondDAInput
    {
        /// <summary>
        /// KenshakikanFrom
        /// </summary>
        string KenshakikanFrom { get; set; }

        /// <summary>
        /// KenshakikanTo
        /// </summary>
        string KenshakikanTo { get; set; }

        /// <summary>
        /// NendoFrom
        /// </summary>
        string NendoFrom { get; set; }

        /// <summary>
        /// NendoTo 
        /// </summary>
        string NendoTo { get; set; }

        /// <summary>
        /// RenbanFrom 
        /// </summary>
        string RenbanFrom { get; set; }

        /// <summary>
        /// RenbanTo 
        /// </summary>
        string RenbanTo { get; set; }

        /// <summary>
        /// KakuninDtFrom 
        /// </summary>
        string KakuninDtFrom { get; set; }

        /// <summary>
        /// KakuninDtTo 
        /// </summary>
        string KakuninDtTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoshoTorokuTblBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoshoTorokuTblBySearchCondDAInput : ISelectHoshoTorokuTblBySearchCondDAInput
    {
        /// <summary>
        /// KenshakikanFrom
        /// </summary>
        public string KenshakikanFrom { get; set; }

        /// <summary>
        /// KenshakikanTo
        /// </summary>
        public string KenshakikanTo { get; set; }

        /// <summary>
        /// NendoFrom
        /// </summary>
        public string NendoFrom { get; set; }

        /// <summary>
        /// NendoTo 
        /// </summary>
        public string NendoTo { get; set; }

        /// <summary>
        /// RenbanFrom 
        /// </summary>
        public string RenbanFrom { get; set; }

        /// <summary>
        /// RenbanTo 
        /// </summary>
        public string RenbanTo { get; set; }

        /// <summary>
        /// KakuninDtFrom 
        /// </summary>
        public string KakuninDtFrom { get; set; }

        /// <summary>
        /// KakuninDtTo 
        /// </summary>
        public string KakuninDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectHoshoTorokuTblBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectHoshoTorokuTblBySearchCondDAOutput
    {
        /// <summary>
        /// HoshoTorokuTblDT
        /// </summary>
        HoshoTorokuTblDataSet.HoshoTorokuTblKensakuDataTable HoshoTorokuTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoshoTorokuTblBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoshoTorokuTblBySearchCondDAOutput : ISelectHoshoTorokuTblBySearchCondDAOutput
    {
        /// <summary>
        /// HoshoTorokuTblDT
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblKensakuDataTable HoshoTorokuTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectHoshoTorokuTblBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectHoshoTorokuTblBySearchCondDataAccess : BaseDataAccess<ISelectHoshoTorokuTblBySearchCondDAInput, ISelectHoshoTorokuTblBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private HoshoTorokuTblKensakuTableAdapter tableAdapter = new HoshoTorokuTblKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectHoshoTorokuTblBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectHoshoTorokuTblBySearchCondDataAccess()
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
        /// 2014/07/17　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectHoshoTorokuTblBySearchCondDAOutput Execute(ISelectHoshoTorokuTblBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectHoshoTorokuTblBySearchCondDAOutput output = new SelectHoshoTorokuTblBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.HoshoTorokuTblDT = tableAdapter.GetDataBySearchCond(input.KenshakikanFrom,
                                                                            input.KenshakikanTo,
                                                                            input.NendoFrom,
                                                                            input.NendoTo,
                                                                            input.RenbanFrom,
                                                                            input.RenbanTo,
                                                                            input.KakuninDtFrom,
                                                                            input.KakuninDtTo);

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
