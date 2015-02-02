using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAInput
    {
        /// <summary>
        /// 浄化槽保健所コード
        /// </summary>
        string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        string KensaIraiJokasoRenban { get; set; }

        /// <summary>
        /// 水質検査持込日付
        /// </summary>
        string KensaKekkaMochikomiDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAInput : ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAInput
    {
        /// <summary>
        /// 浄化槽保健所コード
        /// </summary>
        public string KensaIraiJokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        public string KensaIraiJokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string KensaIraiJokasoRenban { get; set; }

        /// <summary>
        /// 水質検査持込日付
        /// </summary>
        public string KensaKekkaMochikomiDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput
    {
        /// <summary>
        /// Kako5SaisuiTekiseiTenkenListDataTable
        /// </summary>
        KensaKekkaTblDataSet.Kako5SaisuiTekiseiTenkenListDataTable Kako5SaisuiTekiseiTenkenListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput : ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput
    {
        /// <summary>
        /// Kako5SaisuiTekiseiTenkenListDataTable
        /// </summary>
        public KensaKekkaTblDataSet.Kako5SaisuiTekiseiTenkenListDataTable Kako5SaisuiTekiseiTenkenListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/27　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDataAccess : BaseDataAccess<ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAInput, ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private Kako5SaisuiTekiseiTenkenListTableAdapter tableAdapter = new Kako5SaisuiTekiseiTenkenListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDataAccess()
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
        /// 2014/12/27　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput Execute(ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput output = new SelectKako5SaisuiTekiseiTenkenListByJokasoKeyMochikomiDtDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.Kako5SaisuiTekiseiTenkenListDataTable = tableAdapter.GetDataByJokasoKeyMochikomiDt(input.KensaIraiJokasoHokenjoCd
                    , input.KensaIraiJokasoTorokuNendo
                    , input.KensaIraiJokasoRenban
                    , input.KensaKekkaMochikomiDt);
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
