using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SeikyusyoKagamiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SeikyusyoKagamiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSeikyusyoKagamiTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateSeikyusyoKagamiTblDAInput
    {
        /// <summary>
        /// SeikyusyoKagamiTblDataTable
        /// </summary>
        SeikyusyoKagamiTblDataSet.SeikyusyoKagamiTblDataTable SeikyusyoKagamiTblDT { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSeikyusyoKagamiTblDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSeikyusyoKagamiTblDAInput : IUpdateSeikyusyoKagamiTblDAInput
    {
        /// <summary>
        /// SeikyusyoKagamiTblDataTable
        /// </summary>
        public SeikyusyoKagamiTblDataSet.SeikyusyoKagamiTblDataTable SeikyusyoKagamiTblDT { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateSeikyusyoKagamiTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateSeikyusyoKagamiTblDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSeikyusyoKagamiTblDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSeikyusyoKagamiTblDAOutput : IUpdateSeikyusyoKagamiTblDAOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateSeikyusyoKagamiTblDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateSeikyusyoKagamiTblDataAccess : BaseDataAccess<IUpdateSeikyusyoKagamiTblDAInput, IUpdateSeikyusyoKagamiTblDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SeikyusyoKagamiTblTableAdapter tableAdapter = new SeikyusyoKagamiTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateSeikyusyoKagamiTblDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateSeikyusyoKagamiTblDataAccess()
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
        /// 2014/10/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateSeikyusyoKagamiTblDAOutput Execute(IUpdateSeikyusyoKagamiTblDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateSeikyusyoKagamiTblDAOutput output = new UpdateSeikyusyoKagamiTblDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.Update(input.SeikyusyoKagamiTblDT);

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
