using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.NippoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NippoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectCountBySyubetsuKensaDtKensainCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectCountBySyubetsuKensaDtKensainCdDAInput
    {
        /// <summary>
        /// 検査種別
        /// </summary>
        string NippoDtlKensaSyubetsu { get; set; }

        /// <summary>
        /// 検査日
        /// </summary>
        string NippoDtlKensaDt { get; set; }

        /// <summary>
        /// 検査員コード
        /// </summary>
        string NippoDtlKensainCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectCountBySyubetsuKensaDtKensainCdDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectCountBySyubetsuKensaDtKensainCdDAInput : ISelectCountBySyubetsuKensaDtKensainCdDAInput
    {
        /// <summary>
        /// 検査種別
        /// </summary>
        public string NippoDtlKensaSyubetsu { get; set; }

        /// <summary>
        /// 検査日
        /// </summary>
        public string NippoDtlKensaDt { get; set; }

        /// <summary>
        /// 検査員コード
        /// </summary>
        public string NippoDtlKensainCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectCountBySyubetsuKensaDtKensainCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectCountBySyubetsuKensaDtKensainCdDAOutput
    {
        /// <summary>
        /// CountNumber
        /// </summary>
        int CountNumber { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectCountBySyubetsuKensaDtKensainCdDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectCountBySyubetsuKensaDtKensainCdDAOutput : ISelectCountBySyubetsuKensaDtKensainCdDAOutput
    {
        /// <summary>
        /// CountNumber
        /// </summary>
        public int CountNumber { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectCountBySyubetsuKensaDtKensainCdDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectCountBySyubetsuKensaDtKensainCdDataAccess : BaseDataAccess<ISelectCountBySyubetsuKensaDtKensainCdDAInput, ISelectCountBySyubetsuKensaDtKensainCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NippoDtlTblTableAdapter tableAdapter = new NippoDtlTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectCountBySyubetsuKensaDtKensainCdDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectCountBySyubetsuKensaDtKensainCdDataAccess()
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
        /// 2014/08/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectCountBySyubetsuKensaDtKensainCdDAOutput Execute(ISelectCountBySyubetsuKensaDtKensainCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectCountBySyubetsuKensaDtKensainCdDAOutput output = new SelectCountBySyubetsuKensaDtKensainCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.CountNumber = (int)tableAdapter.CountBySyubetsuKensaDtKensainCd(input.NippoDtlKensaSyubetsu, input.NippoDtlKensaDt, input.NippoDtlKensainCd);

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
