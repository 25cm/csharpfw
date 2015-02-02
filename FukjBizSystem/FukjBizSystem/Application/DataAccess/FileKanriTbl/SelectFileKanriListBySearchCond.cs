using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.FileKanriTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.FileKanriTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectFileKanriListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectFileKanriListBySearchCondDAInput
    {
        /// <summary>
        /// ファイル名
        /// </summary>
        string FileName { get; set; }

        /// <summary>
        /// 登録日検索使用フラグ
        /// </summary>
        bool TorokuDtUse { get; set; }

        /// <summary>
        /// 登録日（開始）
        /// </summary>
        DateTime TorokuDtFrom { get; set; }

        /// <summary>
        /// 登録日（終了）
        /// </summary>
        DateTime TorokuDtTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectFileKanriListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectFileKanriListBySearchCondDAInput : ISelectFileKanriListBySearchCondDAInput
    {
        /// <summary>
        /// ファイル名
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 登録日検索使用フラグ
        /// </summary>
        public bool TorokuDtUse { get; set; }

        /// <summary>
        /// 登録日（開始）
        /// </summary>
        public DateTime TorokuDtFrom { get; set; }

        /// <summary>
        /// 登録日（終了）
        /// </summary>
        public DateTime TorokuDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectFileKanriListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectFileKanriListBySearchCondDAOutput
    {
        /// <summary>
        /// FileKanriTblKensakuDataTable
        /// </summary>
        FileKanriTblDataSet.FileKanriTblKensakuDataTable FileKanriTblKensakuDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectFileKanriListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectFileKanriListBySearchCondDAOutput : ISelectFileKanriListBySearchCondDAOutput
    {
        /// <summary>
        /// FileKanriTblKensakuDataTable
        /// </summary>
        public FileKanriTblDataSet.FileKanriTblKensakuDataTable FileKanriTblKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectFileKanriListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectFileKanriListBySearchCondDataAccess : BaseDataAccess<ISelectFileKanriListBySearchCondDAInput, ISelectFileKanriListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private FileKanriTblKensakuTableAdapter tableAdapter = new FileKanriTblKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectFileKanriListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectFileKanriListBySearchCondDataAccess()
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
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectFileKanriListBySearchCondDAOutput Execute(ISelectFileKanriListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectFileKanriListBySearchCondDAOutput output = new SelectFileKanriListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.FileKanriTblKensakuDT = tableAdapter.GetDataBySearchCond(DataAccessUtility.EscapeSQLString(input.FileName),
                                                                                    input.TorokuDtUse,
                                                                                    input.TorokuDtFrom,
                                                                                    input.TorokuDtTo);

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
