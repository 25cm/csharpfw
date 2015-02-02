using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.DataAccess;
using FukjBizSystem.Application.DataSet.NyukinTblDataSetTableAdapters;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.DataAccess.NyukinTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGenkinNyukinTypeKbnTwoByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　ThanhVX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectGenkinNyukinTypeKbnTwoByCondDAInput
    {
        /// <summary>
        /// KeiryoShomeiIraiNendo 
        /// </summary>
        string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd 
        /// </summary>
        string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban 
        /// </summary>
        string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGenkinNyukinTypeKbnTwoByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19　ThanhVX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGenkinNyukinTypeKbnTwoByCondDAInput : ISelectGenkinNyukinTypeKbnTwoByCondDAInput
    {
        /// <summary>
        /// KeiryoShomeiIraiNendo 
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd 
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban 
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectGenkinNyukinTypeKbnTwoByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectGenkinNyukinTypeKbnTwoByCondDAOutput
    {
        /// <summary>
        /// GenkinNyukinTblDataTable
        /// </summary>
        NyukinTblDataSet.GenkinNyukinTblDataTable GenkinNyukinTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectGenkinNyukinTypeKbnTwoByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGenkinNyukinTypeKbnTwoByCondDAOutput : ISelectGenkinNyukinTypeKbnTwoByCondDAOutput
    {
        /// <summary>
        /// GenkinNyukinTblDataTable
        /// </summary>
        public NyukinTblDataSet.GenkinNyukinTblDataTable GenkinNyukinTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectNyukinShosaiByNyukinNoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/19  ThanhVX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectGenkinNyukinTypeKbnTwoByCondDataAccess : BaseDataAccess<ISelectGenkinNyukinTypeKbnTwoByCondDAInput, ISelectGenkinNyukinTypeKbnTwoByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary> 
        private GenkinNyukinTblTableAdapter tableAdapter = new GenkinNyukinTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectNyukinShosaiByNyukinNoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectGenkinNyukinTypeKbnTwoByCondDataAccess()
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
        /// 2014/11/19  ThanhVX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectGenkinNyukinTypeKbnTwoByCondDAOutput Execute(ISelectGenkinNyukinTypeKbnTwoByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectGenkinNyukinTypeKbnTwoByCondDAOutput output = new SelectGenkinNyukinTypeKbnTwoByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.GenkinNyukinTblDataTable = tableAdapter.GetGenkinNyukinKbnTwoByCond(input.KeiryoShomeiIraiNendo, 
                                                                                            input.KeiryoShomeiIraiSishoCd, 
                                                                                            input.KeiryoShomeiIraiRenban);
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
