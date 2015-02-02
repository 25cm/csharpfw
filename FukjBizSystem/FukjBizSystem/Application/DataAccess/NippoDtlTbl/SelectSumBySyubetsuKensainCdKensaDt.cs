using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet.NippoDtlTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.NippoDtlTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSumBySyubetsuKensainCdKensaDtDAInput
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
    interface ISelectSumBySyubetsuKensainCdKensaDtDAInput
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
    //  クラス名 ： SelectSumBySyubetsuKensainCdKensaDtDAInput
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
    class SelectSumBySyubetsuKensainCdKensaDtDAInput : ISelectSumBySyubetsuKensainCdKensaDtDAInput
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
    //  インターフェイス名 ： ISelectSumBySyubetsuKensainCdKensaDtDAOutput
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
    interface ISelectSumBySyubetsuKensainCdKensaDtDAOutput
    {
        /// <summary>
        /// KensaAmt
        /// </summary>
        int KensaAmt { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSumBySyubetsuKensainCdKensaDtDAOutput
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
    class SelectSumBySyubetsuKensainCdKensaDtDAOutput : ISelectSumBySyubetsuKensainCdKensaDtDAOutput
    {
        /// <summary>
        /// KensaAmt
        /// </summary>
        public int KensaAmt { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSumBySyubetsuKensainCdKensaDtDataAccess
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
    class SelectSumBySyubetsuKensainCdKensaDtDataAccess : BaseDataAccess<ISelectSumBySyubetsuKensainCdKensaDtDAInput, ISelectSumBySyubetsuKensainCdKensaDtDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private NippoDtlTblTableAdapter tableAdapter = new NippoDtlTblTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSumBySyubetsuKensainCdKensaDtDataAccess
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
        public SelectSumBySyubetsuKensainCdKensaDtDataAccess()
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
        public override ISelectSumBySyubetsuKensainCdKensaDtDAOutput Execute(ISelectSumBySyubetsuKensainCdKensaDtDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSumBySyubetsuKensainCdKensaDtDAOutput output = new SelectSumBySyubetsuKensainCdKensaDtDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                object obj = tableAdapter.SumBySyubetsuKensainCdKensaDt(input.NippoDtlKensaSyubetsu, input.NippoDtlKensainCd, input.NippoDtlKensaDt);

                if (obj != null)
                {
                    output.KensaAmt = Convert.ToInt32(obj);
                }
                else
                {
                    output.KensaAmt = 0;
                }
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
