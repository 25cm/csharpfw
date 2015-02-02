using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KatashikiBurowaMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KatashikiBurowaMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAInput
    {
        /// <summary>
        /// BurowaKatashikiMakerCd
        /// </summary>
        String BurowaKatashikiMakerCd { get; set; }

        /// <summary>
        /// BurowaKatashikiCd
        /// </summary>
        String BurowaKatashikiCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAInput : ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAInput
    {
        /// <summary>
        /// BurowaKatashikiMakerCd
        /// </summary>
        public String BurowaKatashikiMakerCd { get; set; }

        /// <summary>
        /// BurowaKatashikiCd
        /// </summary>
        public String BurowaKatashikiCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput
    {
        /// <summary>
        /// KatashikiBurowaMstDataTable
        /// </summary>
        KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable KatashikiBurowaMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput : ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput
    {
        /// <summary>
        /// KatashikiBurowaMstDataTable
        /// </summary>
        public KatashikiBurowaMstDataSet.KatashikiBurowaMstDataTable KatashikiBurowaMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDataAccess : BaseDataAccess<ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAInput, ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KatashikiBurowaMstTableAdapter tableAdapter = new KatashikiBurowaMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDataAccess()
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
        /// 2014/07/07  DatNT　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput Execute(ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput output = new SelectKatashikiBurowaMstByKatashikiMakerCdKatashikiCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KatashikiBurowaMstDT = tableAdapter.GetDataByKatashikiMakerCdKatashikiCd(
                                                                                            input.BurowaKatashikiMakerCd, 
                                                                                            input.BurowaKatashikiCd);

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
