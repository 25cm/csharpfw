using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.NippoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NippoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectCountByKensaSyubetsuKensaDtDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectCountByKensaSyubetsuKensaDtDAInput
    {
        /// <summary>
        /// 検査種別
        /// </summary>
        string NippoDtlKensaSyubetsu { get; set; }

        /// <summary>
        /// 検査日
        /// </summary>
        string NippoDtlKensaDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectCountByKensaSyubetsuKensaDtDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectCountByKensaSyubetsuKensaDtDAInput : ISelectCountByKensaSyubetsuKensaDtDAInput
    {
        /// <summary>
        /// 検査種別
        /// </summary>
        public string NippoDtlKensaSyubetsu { get; set; }

        /// <summary>
        /// 検査日
        /// </summary>
        public string NippoDtlKensaDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectCountByKensaSyubetsuKensaDtDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectCountByKensaSyubetsuKensaDtDAOutput
    {
        /// <summary>
        /// KensaCnt
        /// </summary>
        int KensaCnt { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectCountByKensaSyubetsuKensaDtDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectCountByKensaSyubetsuKensaDtDAOutput : ISelectCountByKensaSyubetsuKensaDtDAOutput
    {
        /// <summary>
        /// KensaCnt
        /// </summary>
        public int KensaCnt { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectCountByKensaSyubetsuKensaDtDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectCountByKensaSyubetsuKensaDtDataAccess : BaseDataAccess<ISelectCountByKensaSyubetsuKensaDtDAInput, ISelectCountByKensaSyubetsuKensaDtDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NippoDtlTblTableAdapter tableAdapter = new NippoDtlTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectCountByKensaSyubetsuKensaDtDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectCountByKensaSyubetsuKensaDtDataAccess()
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
        /// 2014/09/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectCountByKensaSyubetsuKensaDtDAOutput Execute(ISelectCountByKensaSyubetsuKensaDtDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectCountByKensaSyubetsuKensaDtDAOutput output = new SelectCountByKensaSyubetsuKensaDtDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaCnt = (int)tableAdapter.CountByKensaSyubetsuKensaDt(input.NippoDtlKensaSyubetsu, input.NippoDtlKensaDt);

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
