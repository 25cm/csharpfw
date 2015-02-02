using System;
using System.Reflection;
using FukjTabletSystem.Application.DataSet.SQLCE;
using FukjTabletSystem.Application.DataSet.SQLCE.KensaKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectPrintKensaKomokuInfoByKensaZenkaiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrintKensaKomokuInfoByKensaZenkaiDAInput
    {
        /// <summary>
        /// KensaIraiZenkaiHoteiKbn
        /// </summary>
        string KensaIraiZenkaiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiZenkaiHokenjoCd
        /// </summary>
        string KensaIraiZenkaiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiZenkaiNendo
        /// </summary>
        string KensaIraiZenkaiNendo { get; set; }

        /// <summary>
        /// KensaIraiZenkaiRenban
        /// </summary>
        string KensaIraiZenkaiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintKensaKomokuInfoByKensaZenkaiDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintKensaKomokuInfoByKensaZenkaiDAInput : ISelectPrintKensaKomokuInfoByKensaZenkaiDAInput
    {
        /// <summary>
        /// KensaIraiZenkaiHoteiKbn
        /// </summary>
        public string KensaIraiZenkaiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiZenkaiHokenjoCd
        /// </summary>
        public string KensaIraiZenkaiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiZenkaiNendo
        /// </summary>
        public string KensaIraiZenkaiNendo { get; set; }

        /// <summary>
        /// KensaIraiZenkaiRenban
        /// </summary>
        public string KensaIraiZenkaiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectPrintKensaKomokuInfoByKensaZenkaiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectPrintKensaKomokuInfoByKensaZenkaiDAOutput
    {
        /// <summary>
        /// PrintKensaKomokuInfoDataTable
        /// </summary>
        KensaKekkaTblDataSet.PrintKensaKomokuInfoDataTable PrintKensaKomokuInfoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintKensaKomokuInfoByKensaZenkaiDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintKensaKomokuInfoByKensaZenkaiDAOutput : ISelectPrintKensaKomokuInfoByKensaZenkaiDAOutput
    {
        /// <summary>
        /// PrintKensaKomokuInfoDataTable
        /// </summary>
        public KensaKekkaTblDataSet.PrintKensaKomokuInfoDataTable PrintKensaKomokuInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectPrintKensaKomokuInfoByKensaZenkaiDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectPrintKensaKomokuInfoByKensaZenkaiDataAccess : BaseDataAccessCe<ISelectPrintKensaKomokuInfoByKensaZenkaiDAInput, ISelectPrintKensaKomokuInfoByKensaZenkaiDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private PrintKensaKomokuInfoTableAdapter tableAdapter = new PrintKensaKomokuInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectPrintKensaKomokuInfoByKensaZenkaiDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/21  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectPrintKensaKomokuInfoByKensaZenkaiDataAccess()
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
        /// 2014/11/21  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectPrintKensaKomokuInfoByKensaZenkaiDAOutput Execute(ISelectPrintKensaKomokuInfoByKensaZenkaiDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectPrintKensaKomokuInfoByKensaZenkaiDAOutput output = new SelectPrintKensaKomokuInfoByKensaZenkaiDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.PrintKensaKomokuInfoDataTable = tableAdapter.GetDataByKensaIraiZenkai(input.KensaIraiZenkaiHoteiKbn, 
                                                                                        input.KensaIraiZenkaiHokenjoCd, 
                                                                                        input.KensaIraiZenkaiNendo, 
                                                                                        input.KensaIraiZenkaiRenban);

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
