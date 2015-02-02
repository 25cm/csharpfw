using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.NippoHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NippoHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaNippoListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaNippoListBySearchCondDAInput
    {
        /// <summary>
        /// 職員コード
        /// </summary>
        string ShokuinCd { get; set; }

        /// <summary>
        /// 検査日検索使用フラグ
        /// </summary>
        bool KensaDtUse { get; set; }

        /// <summary>
        /// 検査日（開始）
        /// </summary>
        string KensaDtFrom { get; set; }

        /// <summary>
        /// 検査日（終了）
        /// </summary>
        string KensaDtTo { get; set; }

        /// <summary>
        /// 対象区分
        /// </summary>
        string Taishokbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaNippoListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaNippoListBySearchCondDAInput : ISelectKensaNippoListBySearchCondDAInput
    {
        /// <summary>
        /// 職員コード
        /// </summary>
        public string ShokuinCd { get; set; }

        /// <summary>
        /// 検査日検索使用フラグ
        /// </summary>
        public bool KensaDtUse { get; set; }

        /// <summary>
        /// 検査日（開始）
        /// </summary>
        public string KensaDtFrom { get; set; }

        /// <summary>
        /// 検査日（終了）
        /// </summary>
        public string KensaDtTo { get; set; }

        /// <summary>
        /// 対象区分
        /// </summary>
        public string Taishokbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaNippoListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaNippoListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaNippoListDataTable
        /// </summary>
        NippoHdrTblDataSet.KensaNippoListDataTable KensaNippoListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaNippoListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaNippoListBySearchCondDAOutput : ISelectKensaNippoListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaNippoListDataTable
        /// </summary>
        public NippoHdrTblDataSet.KensaNippoListDataTable KensaNippoListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaNippoListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaNippoListBySearchCondDataAccess : BaseDataAccess<ISelectKensaNippoListBySearchCondDAInput, ISelectKensaNippoListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaNippoListTableAdapter tableAdapter = new KensaNippoListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaNippoListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaNippoListBySearchCondDataAccess()
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
        /// 2014/10/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaNippoListBySearchCondDAOutput Execute(ISelectKensaNippoListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaNippoListBySearchCondDAOutput output = new SelectKensaNippoListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaNippoListDT = tableAdapter.GetDataBySearchCond(input.ShokuinCd, input.KensaDtUse, input.KensaDtFrom, input.KensaDtTo, input.Taishokbn);

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
