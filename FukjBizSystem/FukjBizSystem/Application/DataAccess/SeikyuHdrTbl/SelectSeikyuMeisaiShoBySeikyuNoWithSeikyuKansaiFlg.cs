using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SeikyuHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyuHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/29　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAInput
    {
        /// <summary>
        /// 請求No
        /// </summary>
        string SeikyuNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/29　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAInput : ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAInput
    {
        /// <summary>
        /// 請求No
        /// </summary>
        public string SeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/29　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput
    {
        /// <summary>
        /// SeikyuMeisaiShoDataTable
        /// </summary>
        SeikyuHdrTblDataSet.SeikyuMeisaiShoDataTable SeikyuMeisaiShoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/29　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput : ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput
    {
        /// <summary>
        /// SeikyuMeisaiShoDataTable
        /// </summary>
        public SeikyuHdrTblDataSet.SeikyuMeisaiShoDataTable SeikyuMeisaiShoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/29　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDataAccess : BaseDataAccess<ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAInput, ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyuMeisaiShoTableAdapter tableAdapter = new SeikyuMeisaiShoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/29　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDataAccess()
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
        /// 2014/12/29　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput Execute(ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput output = new SelectSeikyuMeisaiShoBySeikyuNoWithSeikyuKansaiFlgDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SeikyuMeisaiShoDataTable = tableAdapter.GetDataByOyaSeikyuNoWithSeikyuKansaiFlg(input.SeikyuNo);
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
