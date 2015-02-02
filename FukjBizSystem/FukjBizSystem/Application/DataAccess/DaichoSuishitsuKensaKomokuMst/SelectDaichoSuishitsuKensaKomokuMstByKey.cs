using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.DaichoSuishitsuKensaKomokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaKomokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectDaichoSuishitsuKensaKomokuMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectDaichoSuishitsuKensaKomokuMstByKeyDAInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード 
        /// </summary>
        string HokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        string TorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        string Renban { get; set; }

        /// <summary>
        /// 台帳検査項目枝番 
        /// </summary>
        string DaichoKensaKomokuEdaban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDaichoSuishitsuKensaKomokuMstByKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectDaichoSuishitsuKensaKomokuMstByKeyDAInput : ISelectDaichoSuishitsuKensaKomokuMstByKeyDAInput
    {
        /// <summary>
        /// 浄化槽台帳保健所コード 
        /// </summary>
        public string HokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳年度 
        /// </summary>
        public string TorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番 
        /// </summary>
        public string Renban { get; set; }

        /// <summary>
        /// 台帳検査項目枝番 
        /// </summary>
        public string DaichoKensaKomokuEdaban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectDaichoSuishitsuKensaKomokuMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectDaichoSuishitsuKensaKomokuMstByKeyDAOutput
    {
        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ
        /// </summary>
        DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDaichoSuishitsuKensaKomokuMstByKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectDaichoSuishitsuKensaKomokuMstByKeyDAOutput : ISelectDaichoSuishitsuKensaKomokuMstByKeyDAOutput
    {
        /// <summary>
        /// 浄化槽台帳水質検査項目マスタ
        /// </summary>
        public DaichoSuishitsuKensaKomokuMstDataSet.DaichoSuishitsuKensaKomokuMstDataTable DaichoSuishitsuKensaKomokuMstDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectDaichoSuishitsuKensaKomokuMstByKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectDaichoSuishitsuKensaKomokuMstByKeyDataAccess : BaseDataAccess<ISelectDaichoSuishitsuKensaKomokuMstByKeyDAInput, ISelectDaichoSuishitsuKensaKomokuMstByKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private DaichoSuishitsuKensaKomokuMstTableAdapter tableAdapter
            = new DaichoSuishitsuKensaKomokuMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectDaichoSuishitsuKensaKomokuMstByKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectDaichoSuishitsuKensaKomokuMstByKeyDataAccess()
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectDaichoSuishitsuKensaKomokuMstByKeyDAOutput Execute(ISelectDaichoSuishitsuKensaKomokuMstByKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectDaichoSuishitsuKensaKomokuMstByKeyDAOutput output = new SelectDaichoSuishitsuKensaKomokuMstByKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.DaichoSuishitsuKensaKomokuMstDataTable = tableAdapter.GetDataByKey(input.HokenjoCd, input.TorokuNendo, input.Renban, input.DaichoKensaKomokuEdaban);
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
