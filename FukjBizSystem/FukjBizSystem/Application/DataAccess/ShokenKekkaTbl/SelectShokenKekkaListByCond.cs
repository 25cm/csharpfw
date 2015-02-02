using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShokenKekkaTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShokenKekkaTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenKekkaListByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenKekkaListByCondDAInput
    {
        /// <summary>
        /// KensaIraiShokanIraiHoteiKbn
        /// </summary>
        string KensaIraiShokanIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiHokenjoCd 
        /// </summary>
        string KensaIraiShokenIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiNendo
        /// </summary>
        string KensaIraiShokenIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiRenban
        /// </summary>
        string KensaIraiShokenIraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaListByCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaListByCondDAInput : ISelectShokenKekkaListByCondDAInput
    {
        /// <summary>
        /// KensaIraiShokanIraiHoteiKbn
        /// </summary>
        public string KensaIraiShokanIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiHokenjoCd 
        /// </summary>
        public string KensaIraiShokenIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiNendo
        /// </summary>
        public string KensaIraiShokenIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiShokenIraiRenban
        /// </summary>
        public string KensaIraiShokenIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenKekkaListByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenKekkaListByCondDAOutput
    {
        /// <summary>
        /// ShokenKekkaListDataTable
        /// </summary>
        ShokenKekkaTblDataSet.ShokenKekkaListDataTable ShokenKekkaListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaListByCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaListByCondDAOutput : ISelectShokenKekkaListByCondDAOutput
    {
        /// <summary>
        /// ShokenKekkaListDataTable
        /// </summary>
        public ShokenKekkaTblDataSet.ShokenKekkaListDataTable ShokenKekkaListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenKekkaListByCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/14  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenKekkaListByCondDataAccess : BaseDataAccess<ISelectShokenKekkaListByCondDAInput, ISelectShokenKekkaListByCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokenKekkaListTableAdapter tableAdapter = new ShokenKekkaListTableAdapter();


        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShokenKekkaListByCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/14  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShokenKekkaListByCondDataAccess()
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
        /// 2014/10/14  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShokenKekkaListByCondDAOutput Execute(ISelectShokenKekkaListByCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShokenKekkaListByCondDAOutput output = new SelectShokenKekkaListByCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShokenKekkaListDataTable = tableAdapter.GetDataByCond(input.KensaIraiShokanIraiHoteiKbn,
                                                                                input.KensaIraiShokenIraiHokenjoCd,
                                                                                input.KensaIraiShokenIraiNendo,
                                                                                input.KensaIraiShokenIraiRenban);
                                                

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
