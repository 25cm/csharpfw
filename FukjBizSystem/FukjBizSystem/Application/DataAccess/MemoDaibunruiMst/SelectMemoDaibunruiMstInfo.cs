using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.MemoDaibunruiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.MemoDaibunruiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMemoDaibunruiMstInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMemoDaibunruiMstInfoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMemoDaibunruiMstInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMemoDaibunruiMstInfoDAInput : ISelectMemoDaibunruiMstInfoDAInput
    {
        
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectMemoDaibunruiMstInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectMemoDaibunruiMstInfoDAOutput
    {
        /// <summary>
        /// MemoDaibunruiMstDataTable
        /// </summary>
        MemoDaibunruiMstDataSet.MemoDaibunruiMstDataTable MemoDaibunruiMstInfoDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMemoDaibunruiMstInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMemoDaibunruiMstInfoDAOutput : ISelectMemoDaibunruiMstInfoDAOutput
    {
        /// <summary>
        /// MemoDaibunruiMstDataTable
        /// </summary>
        public MemoDaibunruiMstDataSet.MemoDaibunruiMstDataTable MemoDaibunruiMstInfoDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectMemoDaibunruiMstInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectMemoDaibunruiMstInfoDataAccess : BaseDataAccess<ISelectMemoDaibunruiMstInfoDAInput, ISelectMemoDaibunruiMstInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private MemoDaibunruiMstTableAdapter tableAdapter = new MemoDaibunruiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectMemoDaibunruiMstInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectMemoDaibunruiMstInfoDataAccess()
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
        /// 2014/08/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectMemoDaibunruiMstInfoDAOutput Execute(ISelectMemoDaibunruiMstInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectMemoDaibunruiMstInfoDAOutput output = new SelectMemoDaibunruiMstInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.MemoDaibunruiMstInfoDT = tableAdapter.GetData();
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
