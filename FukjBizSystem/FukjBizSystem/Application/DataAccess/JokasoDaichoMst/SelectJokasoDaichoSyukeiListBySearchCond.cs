using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.JokasoDaichoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJokasoDaichoSyukeiListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJokasoDaichoSyukeiListBySearchCondDAInput
    {
        /// <summary>
        /// 出力帳票
        /// </summary>
        string ShutsuryokuChohyo { get; set; }

        /// <summary>
        /// 保健所コード
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// 受付日使用有無
        /// </summary>
        bool UketsukeUse { get; set; }

        /// <summary>
        /// 受付日（開始）
        /// </summary>
        string UketsukeDtFrom { get; set; }

        /// <summary>
        /// 受付日（終了）
        /// </summary>
        string UketsukeDtTo { get; set; }

        /// <summary>
        /// 検査日使用有無
        /// </summary>
        bool KensaUse { get; set; }

        /// <summary>
        /// 検査日（開始）
        /// </summary>
        string KensaDtFrom { get; set; }

        /// <summary>
        /// 検査日（終了）
        /// </summary>
        string KensaDtTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoSyukeiListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoSyukeiListBySearchCondDAInput : ISelectJokasoDaichoSyukeiListBySearchCondDAInput
    {
        /// <summary>
        /// 出力帳票
        /// </summary>
        public string ShutsuryokuChohyo { get; set; }

        /// <summary>
        /// 保健所コード
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// 受付日使用有無
        /// </summary>
        public bool UketsukeUse { get; set; }

        /// <summary>
        /// 受付日（開始）
        /// </summary>
        public string UketsukeDtFrom { get; set; }

        /// <summary>
        /// 受付日（終了）
        /// </summary>
        public string UketsukeDtTo { get; set; }

        /// <summary>
        /// 検査日使用有無
        /// </summary>
        public bool KensaUse { get; set; }

        /// <summary>
        /// 検査日（開始）
        /// </summary>
        public string KensaDtFrom { get; set; }

        /// <summary>
        /// 検査日（終了）
        /// </summary>
        public string KensaDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJokasoDaichoSyukeiListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJokasoDaichoSyukeiListBySearchCondDAOutput
    {
        /// <summary>
        /// JokasoDaichoSyukeiListDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable JokasoDaichoSyukeiListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoSyukeiListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoSyukeiListBySearchCondDAOutput : ISelectJokasoDaichoSyukeiListBySearchCondDAOutput
    {
        /// <summary>
        /// JokasoDaichoSyukeiListDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable JokasoDaichoSyukeiListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJokasoDaichoSyukeiListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJokasoDaichoSyukeiListBySearchCondDataAccess : BaseDataAccess<ISelectJokasoDaichoSyukeiListBySearchCondDAInput, ISelectJokasoDaichoSyukeiListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JokasoDaichoSyukeiListTableAdapter tableAdapter = new JokasoDaichoSyukeiListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJokasoDaichoSyukeiListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJokasoDaichoSyukeiListBySearchCondDataAccess()
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
        /// 2014/10/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJokasoDaichoSyukeiListBySearchCondDAOutput Execute(ISelectJokasoDaichoSyukeiListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJokasoDaichoSyukeiListBySearchCondDAOutput output = new SelectJokasoDaichoSyukeiListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JokasoDaichoSyukeiListDT = tableAdapter.GetDataBySearchCond(input.ShutsuryokuChohyo,
                                                                                    input.HokenjoCd,
                                                                                    input.UketsukeUse,
                                                                                    input.UketsukeDtFrom,
                                                                                    input.UketsukeDtTo,
                                                                                    input.KensaUse,
                                                                                    input.KensaDtFrom,
                                                                                    input.KensaDtTo);

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
