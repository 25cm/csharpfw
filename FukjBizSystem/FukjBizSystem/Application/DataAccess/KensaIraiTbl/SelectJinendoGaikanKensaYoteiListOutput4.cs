using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoGaikanKensaYoteiListOutput4DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanKensaYoteiListOutput4DAInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

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
        /// 年度
        /// </summary>
        string Nendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanKensaYoteiListOutput4DAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanKensaYoteiListOutput4DAInput : ISelectJinendoGaikanKensaYoteiListOutput4DAInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

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
        /// 年度
        /// </summary>
        public string Nendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJinendoGaikanKensaYoteiListOutput4DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJinendoGaikanKensaYoteiListOutput4DAOutput
    {
        /// <summary>
        /// JinendoGaikanKensaYoteiListOutput4DataTable
        /// </summary>
        KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput4DataTable JinendoGaikanKensaYoteiListOutput4DT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanKensaYoteiListOutput4DAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanKensaYoteiListOutput4DAOutput : ISelectJinendoGaikanKensaYoteiListOutput4DAOutput
    {
        /// <summary>
        /// JinendoGaikanKensaYoteiListOutput4DataTable
        /// </summary>
        public KensaIraiTblDataSet.JinendoGaikanKensaYoteiListOutput4DataTable JinendoGaikanKensaYoteiListOutput4DT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJinendoGaikanKensaYoteiListOutput4DataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/23  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJinendoGaikanKensaYoteiListOutput4DataAccess : BaseDataAccess<ISelectJinendoGaikanKensaYoteiListOutput4DAInput, ISelectJinendoGaikanKensaYoteiListOutput4DAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JinendoGaikanKensaYoteiListOutput4TableAdapter tableAdapter = new JinendoGaikanKensaYoteiListOutput4TableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJinendoGaikanKensaYoteiListOutput4DataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/23  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJinendoGaikanKensaYoteiListOutput4DataAccess()
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
        /// 2014/11/23  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJinendoGaikanKensaYoteiListOutput4DAOutput Execute(ISelectJinendoGaikanKensaYoteiListOutput4DAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJinendoGaikanKensaYoteiListOutput4DAOutput output = new SelectJinendoGaikanKensaYoteiListOutput4DAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JinendoGaikanKensaYoteiListOutput4DT = tableAdapter.GetDataBySearchCond( input.KensaIraiHoteiKbn,
                                                                                                input.KensaIraiJokasoHokenjoCd,
                                                                                                input.KensaIraiJokasoTorokuNendo,
                                                                                                input.KensaIraiJokasoRenban,
                                                                                                input.Nendo);
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
