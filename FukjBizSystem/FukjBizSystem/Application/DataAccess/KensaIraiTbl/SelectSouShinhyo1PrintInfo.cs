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
    //  インターフェイス名 ： ISelectSouShinhyo1PrintInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSouShinhyo1PrintInfoDAInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban 
        /// </summary>
        string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSouShinhyo1PrintInfoDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSouShinhyo1PrintInfoDAInput : ISelectSouShinhyo1PrintInfoDAInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban 
        /// </summary>
        public string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectSouShinhyo1PrintInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectSouShinhyo1PrintInfoDAOutput
    {
        /// <summary>
        /// SouShinhyo1PrintInfoDataTable
        /// </summary>
        KensaIraiTblDataSet.SouShinhyo1PrintInfoDataTable SouShinhyo1PrintInfoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSouShinhyo1PrintInfoDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSouShinhyo1PrintInfoDAOutput : ISelectSouShinhyo1PrintInfoDAOutput
    {
        /// <summary>
        /// SouShinhyo1PrintInfoDataTable
        /// </summary>
        public KensaIraiTblDataSet.SouShinhyo1PrintInfoDataTable SouShinhyo1PrintInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectSouShinhyo1PrintInfoDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/15　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectSouShinhyo1PrintInfoDataAccess : BaseDataAccess<ISelectSouShinhyo1PrintInfoDAInput, ISelectSouShinhyo1PrintInfoDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private SouShinhyo1PrintInfoTableAdapter tableAdapter = new SouShinhyo1PrintInfoTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectSouShinhyo1PrintInfoDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectSouShinhyo1PrintInfoDataAccess()
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
        /// 2014/08/15　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectSouShinhyo1PrintInfoDAOutput Execute(ISelectSouShinhyo1PrintInfoDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectSouShinhyo1PrintInfoDAOutput output = new SelectSouShinhyo1PrintInfoDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.SouShinhyo1PrintInfoDataTable = tableAdapter.GetDataByCond(input.KensaIraiHoteiKbn, 
                                                                                input.KensaIraiHokenjoCd, 
                                                                                input.KensaIraiNendo, 
                                                                                input.KensaIraiRenban);

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
