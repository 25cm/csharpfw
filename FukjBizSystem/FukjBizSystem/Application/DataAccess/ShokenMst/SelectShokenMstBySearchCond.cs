using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.ShokenMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.ShokenMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenMstBySearchCondDAInput
    {
        /// <summary>
        /// ShokenKbn
        /// </summary>
        string ShokenKbn { get; set; }

        /// <summary>
        /// ShokenCdFrom
        /// </summary>
        string ShokenCdFrom { get; set; }

        /// <summary>
        /// ShokenCdTo
        /// </summary>
        string ShokenCdTo { get; set; }

        /// <summary>
        /// ShokenJuyodo
        /// </summary>
        string ShokenJuyodo { get; set; }

        /// <summary>
        /// ShokenShitekiKbn
        /// </summary>
        string ShokenShitekiKbn { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenMstBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenMstBySearchCondDAInput : ISelectShokenMstBySearchCondDAInput
    {
        /// <summary>
        /// ShokenKbn
        /// </summary>
        public string ShokenKbn { get; set; }

        /// <summary>
        /// ShokenCdFrom
        /// </summary>
        public string ShokenCdFrom { get; set; }

        /// <summary>
        /// ShokenCdTo
        /// </summary>
        public string ShokenCdTo { get; set; }

        /// <summary>
        /// ShokenJuyodo
        /// </summary>
        public string ShokenJuyodo { get; set; }

        /// <summary>
        /// ShokenShitekiKbn
        /// </summary>
        public string ShokenShitekiKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectShokenMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectShokenMstBySearchCondDAOutput
    {
        /// <summary>
        /// ShokenMstKensakuDataTable
        /// </summary>
        ShokenMstDataSet.ShokenMstKensakuDataTable ShokenMstKensakuDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenMstBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenMstBySearchCondDAOutput : ISelectShokenMstBySearchCondDAOutput
    {
        /// <summary>
        /// ShokenMstKensakuDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenMstKensakuDataTable ShokenMstKensakuDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectShokenMstBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectShokenMstBySearchCondDataAccess : BaseDataAccess<ISelectShokenMstBySearchCondDAInput, ISelectShokenMstBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private ShokenMstKensakuTableAdapter tableAdapter = new ShokenMstKensakuTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectShokenMstBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectShokenMstBySearchCondDataAccess()
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
        /// 2014/08/22　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectShokenMstBySearchCondDAOutput Execute(ISelectShokenMstBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectShokenMstBySearchCondDAOutput output = new SelectShokenMstBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.ShokenMstKensakuDataTable = tableAdapter.GetDataBySearchCond(input.ShokenKbn,
                                                                                    input.ShokenCdFrom,
                                                                                    input.ShokenCdTo,
                                                                                    input.ShokenJuyodo,
                                                                                    input.ShokenShitekiKbn);

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
