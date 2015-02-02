using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShokuinMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShokuinMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokuinMstByShokuinTaishokuFlgDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokuinMstByShokuinTaishokuFlgDAInput
    {
        /// <summary>
        /// ShokuinTaishokuFlg
        /// </summary>
        string ShokuinTaishokuFlg { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokuinMstByShokuinTaishokuFlgDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokuinMstByShokuinTaishokuFlgDAInput : ISelectShokuinMstByShokuinTaishokuFlgDAInput
    {
        /// <summary>
        /// ShokuinTaishokuFlg
        /// </summary>
        public string ShokuinTaishokuFlg { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokuinMstByShokuinTaishokuFlgDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokuinMstByShokuinTaishokuFlgDAOutput
    {
        /// <summary>
        /// ShokuinMstDataTable
        /// </summary>
        ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokuinMstByShokuinTaishokuFlgDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokuinMstByShokuinTaishokuFlgDAOutput : ISelectShokuinMstByShokuinTaishokuFlgDAOutput
    {
        /// <summary>
        /// ShokuinMstDataTable
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokuinMstByShokuinTaishokuFlgDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokuinMstByShokuinTaishokuFlgDataAccess : BaseDataAccess<ISelectShokuinMstByShokuinTaishokuFlgDAInput, ISelectShokuinMstByShokuinTaishokuFlgDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokuinMstTableAdapter tableAdapter = new ShokuinMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShokuinMstByShokuinTaishokuFlgDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShokuinMstByShokuinTaishokuFlgDataAccess()
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
        /// 2015/01/28　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShokuinMstByShokuinTaishokuFlgDAOutput Execute(ISelectShokuinMstByShokuinTaishokuFlgDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShokuinMstByShokuinTaishokuFlgDAOutput output = new SelectShokuinMstByShokuinTaishokuFlgDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShokuinMstDT = tableAdapter.GetDataByShokuinTaishokuFlg(input.ShokuinTaishokuFlg);

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
