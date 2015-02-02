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
    //  インターフェイス名 ： ISelect7JoKensaIraiListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelect7JoKensaIraiListBySearchCondDAInput
    {
        /// <summary>
        /// KensaIraiDtFrom 
        /// </summary>
        string KensaIraiDtFrom {get;set;}

        /// <summary>
        /// KensaIraiDtTo 
        /// </summary>
        string KensaIraiDtTo {get;set;}

        /// <summary>
        /// IsCheckKensaIraiSofuDt 
        /// </summary>
        bool IsCheckKensaIraiSofuDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Select7JoKensaIraiListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Select7JoKensaIraiListBySearchCondDAInput : ISelect7JoKensaIraiListBySearchCondDAInput
    {
        /// <summary>
        /// KensaIraiDtFrom 
        /// </summary>
        public string KensaIraiDtFrom { get; set; }

        /// <summary>
        /// KensaIraiDtTo 
        /// </summary>
        public string KensaIraiDtTo { get; set; }

        /// <summary>
        /// IsCheckKensaIraiSofuDt 
        /// </summary>
        public bool IsCheckKensaIraiSofuDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelect7JoKensaIraiListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelect7JoKensaIraiListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaIraiListDataTable
        /// </summary>
        KensaIraiTblDataSet.Jo7KensaIraiListDataTable Jo7KensaIraiListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Select7JoKensaIraiListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Select7JoKensaIraiListBySearchCondDAOutput : ISelect7JoKensaIraiListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaIraiListDataTable
        /// </summary>
        public KensaIraiTblDataSet.Jo7KensaIraiListDataTable Jo7KensaIraiListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Select7JoKensaIraiListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Select7JoKensaIraiListBySearchCondDataAccess : BaseDataAccess<ISelect7JoKensaIraiListBySearchCondDAInput, ISelect7JoKensaIraiListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private Jo7KensaIraiListTableAdapter tableAdapter = new Jo7KensaIraiListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： Select7JoKensaIraiListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public Select7JoKensaIraiListBySearchCondDataAccess()
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
        /// 2014/09/05  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelect7JoKensaIraiListBySearchCondDAOutput Execute(ISelect7JoKensaIraiListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelect7JoKensaIraiListBySearchCondDAOutput output = new Select7JoKensaIraiListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.Jo7KensaIraiListDataTable = tableAdapter.GetDataBySearchCond(input.KensaIraiDtFrom, input.KensaIraiDtTo, input.IsCheckKensaIraiSofuDt);

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
