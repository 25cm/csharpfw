using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.ShoriHoshikiSuishitsuKensaJisshiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.ShoriHoshikiSuishitsuKensaJisshiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        string IraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAInput : ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        public string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        public string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        public string IraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDataTable
        /// </summary>
        ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable ShoriHoshikiSuishitsuKensaJisshiMst { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput : ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDataTable
        /// </summary>
        public ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable ShoriHoshikiSuishitsuKensaJisshiMst { get; set; }
    }                                                          
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDataAccess  : BaseDataAccessCe<ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAInput, ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShoriHoshikiSuishitsuKensaJisshiMstTableAdapter tableAdapter = new ShoriHoshikiSuishitsuKensaJisshiMstTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDataAccess()
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
        /// 2014/11/18　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput Execute(ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput output = new SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShoriHoshikiSuishitsuKensaJisshiMst = tableAdapter.GetDataByKensaIraiKey(input.IraiHoteiKbn, input.IraiHokenjoCd, input.IraiNendo, input.IraiRenban);

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
