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
    //  インターフェイス名 ： ISelectPrintKeriyoShomeiType1TblDAInput
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
    interface ISelectPrintKeriyoShomeiType2TblDAInput
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
        /// Renban
        /// </summary>
        string Renban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintKeriyoShomeiType1TblDAInput
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
    class SelectPrintKeriyoShomeiType2TblDAInput : ISelectPrintKeriyoShomeiType2TblDAInput
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
        /// Renban
        /// </summary>
        public string Renban { get; set; }

    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGaichuKensaListTblByCondDAOutput
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
    interface ISelectPrintKeriyoShomeiType2TblDAOutput
    {
        /// <summary>
        /// PrintKeriyoShomeiType2DataTable
        /// </summary>
        KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable PrintKeriyoShomeiType2DataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGaichuKensaListTblByCondDAOutput
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
    class SelectPrintKeriyoShomeiType2TblDAOutput : ISelectPrintKeriyoShomeiType2TblDAOutput
    {
        /// <summary>
        /// PrintKeriyoShomeiType1DataTable
        /// </summary>
        public KeiryoShomeiIraiTblDataSet.PrintKeriyoShomeiType2DataTable PrintKeriyoShomeiType2DataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGaichuKensaListTblByCondDataAccess
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
    class SelectPrintKeriyoShomeiType2TblDataAccess : BaseDataAccess<ISelectPrintKeriyoShomeiType2TblDAInput, ISelectPrintKeriyoShomeiType2TblDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private PrintKeriyoShomeiType2TableAdapter tableAdapter = new PrintKeriyoShomeiType2TableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectGaichuKensaListTblByCondDataAccess
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
        public SelectPrintKeriyoShomeiType2TblDataAccess()
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
        public override ISelectPrintKeriyoShomeiType2TblDAOutput Execute(ISelectPrintKeriyoShomeiType2TblDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectPrintKeriyoShomeiType2TblDAOutput output = new SelectPrintKeriyoShomeiType2TblDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.PrintKeriyoShomeiType2DataTable = tableAdapter.GetPrintKeiryoShomeiType2ByCond(input.ShishoCd, input.Nendo, input.Renban);

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
