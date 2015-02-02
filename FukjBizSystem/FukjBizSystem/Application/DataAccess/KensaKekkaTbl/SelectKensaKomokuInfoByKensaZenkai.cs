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
    //  インターフェイス名 ： ISelectKensaKomokuInfoByKensaZenkaiDAInput
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
    interface ISelectKensaKomokuInfoByKensaZenkaiDAInput
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
    //  クラス名 ： SelectKensaKomokuInfoByKensaZenkaiDAInput
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
    class SelectKensaKomokuInfoByKensaZenkaiDAInput : ISelectKensaKomokuInfoByKensaZenkaiDAInput
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
    //  インターフェイス名 ： ISelectKensaKomokuInfoByKensaZenkaiDAOutput
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
    interface ISelectKensaKomokuInfoByKensaZenkaiDAOutput
    {
        /// <summary>
        /// KensaKomokuInfoDataTable
        /// </summary>
        KensaKekkaTblDataSet.KensaKomokuInfoDataTable KensaKomokuInfoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKomokuInfoByKensaZenkaiDAOutput
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
    class SelectKensaKomokuInfoByKensaZenkaiDAOutput : ISelectKensaKomokuInfoByKensaZenkaiDAOutput
    {
        /// <summary>
        /// KensaKomokuInfoDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKomokuInfoDataTable KensaKomokuInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKomokuInfoByKensaZenkaiDataAccess
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
    class SelectKensaKomokuInfoByKensaZenkaiDataAccess : BaseDataAccess<ISelectKensaKomokuInfoByKensaZenkaiDAInput, ISelectKensaKomokuInfoByKensaZenkaiDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKomokuInfoTableAdapter tableAdapter = new KensaKomokuInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaKomokuInfoByKensaZenkaiDataAccess
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
        public SelectKensaKomokuInfoByKensaZenkaiDataAccess()
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
        public override ISelectKensaKomokuInfoByKensaZenkaiDAOutput Execute(ISelectKensaKomokuInfoByKensaZenkaiDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaKomokuInfoByKensaZenkaiDAOutput output = new SelectKensaKomokuInfoByKensaZenkaiDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaKomokuInfoDataTable = tableAdapter.GetDataByKensaIraiZenkai(input.KensaIraiZenkaiHoteiKbn, 
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
