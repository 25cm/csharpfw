using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.DaichoSuishitsuKensaTanKomokuMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.DaichoSuishitsuKensaTanKomokuMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAInput
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
    interface IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAInput
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
    //  クラス名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAInput
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
    class DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAInput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAInput
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
    //  インターフェイス名 ： IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput
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
    interface IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput
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
    class DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput : IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDataAccess
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
    class DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDataAccess : BaseDataAccess<IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAInput, IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private DaichoSuishitsuKensaTanKomokuMstTableAdapter tableAdapter
            = new DaichoSuishitsuKensaTanKomokuMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDataAccess
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
        public DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDataAccess()
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
        public override IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput Execute(IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput output = new DeleteDaichoSuishitsuKensaTanKomokuMstByKeyWithoutDaichoKensaKomokuCdDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                tableAdapter.DeleteByKeyWithoutDaichoKensaKomokuCd(input.HokenjoCd, input.TorokuNendo, input.Renban, input.DaichoKensaKomokuEdaban);
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
