using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.DataAccess;
using FukjBizSystem.Application.DataSet.KeiryoShomeiIraiTblDataSetTableAdapters;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKeiryoShomeiOutputListByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKeiryoShomeiOutputListByCondDAInput
    {
        /// <summary>
        /// 支所
        /// </summary>
        string ShishoCd { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }
        /// <summary>
        /// 設置者
        /// </summary>
        string Settisha { get; set; }
        /// <summary>
        /// 水検No (開始)
        /// </summary>
        string SuikenNoFrom { get; set; }
        /// <summary>
        /// 水検No (終了)
        /// </summary>
        string SuikenNoTo { get; set; }
        /// <summary>
        /// 受付日（開始）
        /// </summary>
        string UketsukeDtFrom { get; set; }
        /// <summary>
        /// 受付日（終了）
        /// </summary>
        string UketsukeDtTo { get; set; }
        /// <summary>
        /// ChouhyouKubunFlg
        /// </summary>
        string ChouhyouKubunFlg { get; set; }
        // 20150201 sou Start
        /// <summary>
        /// 表示順
        /// </summary>
        string DispOrder { get; set; }
        // 20150201 sou End
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiOutputListByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiOutputListByCondDAInput : ISelectKeiryoShomeiOutputListByCondDAInput
    {
        /// <summary>
        /// 支所
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }
        /// <summary>
        /// 設置者
        /// </summary>
        public string Settisha { get; set; }
        /// <summary>
        /// 水検No (開始)
        /// </summary>
        public string SuikenNoFrom { get; set; }
        /// <summary>
        /// 水検No (終了)
        /// </summary>
        public string SuikenNoTo { get; set; }
        /// <summary>
        /// 受付日（開始）
        /// </summary>
        public string UketsukeDtFrom { get; set; }
        /// <summary>
        /// 受付日（終了）
        /// </summary>
        public string UketsukeDtTo { get; set; }
        /// <summary>
        /// ChouhyouKubunFlg
        /// </summary>
        public string ChouhyouKubunFlg { get; set; }
        // 20150201 sou Start
        /// <summary>
        /// 表示順
        /// </summary>
        public string DispOrder { get; set; }
        // 20150201 sou End
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKeiryoShomeiOutputListByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKeiryoShomeiOutputListByCondDAOutput
    {
        /// <summary>
        /// KeiryoShomeiOutputListDataTable
        /// </summary>
        KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable KeiryoShomeiOutputListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiOutputListByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiOutputListByCondDAOutput : ISelectKeiryoShomeiOutputListByCondDAOutput
    {
        /// <summary>
        /// KeiryoShomeiOutputListDataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.KeiryoShomeiOutputListDataTable KeiryoShomeiOutputListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKeiryoShomeiOutputListByCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/24  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKeiryoShomeiOutputListByCondDataAccess : BaseDataAccess<ISelectKeiryoShomeiOutputListByCondDAInput, ISelectKeiryoShomeiOutputListByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KeiryoShomeiOutputListTableAdapter tableAdapter = new KeiryoShomeiOutputListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKeiryoShomeiOutputListByCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKeiryoShomeiOutputListByCondDataAccess()
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
        /// 2014/11/24  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKeiryoShomeiOutputListByCondDAOutput Execute(ISelectKeiryoShomeiOutputListByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKeiryoShomeiOutputListByCondDAOutput output = new SelectKeiryoShomeiOutputListByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KeiryoShomeiOutputListDataTable = tableAdapter.GetKeiryoShomeiOutputListByCond(input.ShishoCd, 
                                                                                                       input.Nendo, 
                                                                                                       input.SuikenNoFrom, 
                                                                                                       input.SuikenNoTo, 
                                                                                                       input.Settisha, 
                                                                                                       input.UketsukeDtFrom, 
                                                                                                       input.UketsukeDtTo,
                                                                                                       // 20150201 sou Start
                                                                                                       //input.ChouhyouKubunFlg);
                                                                                                       input.ChouhyouKubunFlg,
                                                                                                       input.DispOrder);
                                                                                                       // 20150201 sou End

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
