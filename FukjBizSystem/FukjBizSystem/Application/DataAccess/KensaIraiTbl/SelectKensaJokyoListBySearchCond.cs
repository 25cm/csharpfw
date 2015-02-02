using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;
using System.Collections.Generic;

namespace FukjBizSystem.Application.DataAccess.KensaIraiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaJokyoListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaJokyoListBySearchCondDAInput
    {
        /// <summary>
        /// HoteiKbn 
        /// </summary>
        List<string> HoteiKbn { get; set; }

        /// <summary>
        /// JokasoSetchishaNm 
        /// </summary>
        string JokasoSetchishaNm { get; set; }

        /// <summary>
        /// JokasoShisetsuNm 
        /// </summary>
        string JokasoShisetsuNm { get; set; }

        /// <summary>
        /// SettisyaCd 
        /// </summary>
        string SettisyaCd { get; set; }

        /// <summary>
        /// KensaIraiDtFrom 
        /// </summary>
        string KensaIraiDtFrom { get; set; }

        /// <summary>
        /// KensaIraiDtTo 
        /// </summary>
        string KensaIraiDtTo { get; set; }

        /// <summary>
        /// KensaDtFrom 
        /// </summary>
        string KensaDtFrom { get; set; }

        /// <summary>
        /// KensaDtTo 
        /// </summary>
        string KensaDtTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaJokyoListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaJokyoListBySearchCondDAInput : ISelectKensaJokyoListBySearchCondDAInput
    {
        /// <summary>
        /// HoteiKbn 
        /// </summary>
        public List<string> HoteiKbn { get; set; }

        /// <summary>
        /// JokasoSetchishaNm 
        /// </summary>
        public string JokasoSetchishaNm { get; set; }

        /// <summary>
        /// JokasoShisetsuNm 
        /// </summary>
        public string JokasoShisetsuNm { get; set; }

        /// <summary>
        /// SettisyaCd 
        /// </summary>
        public string SettisyaCd { get; set; }

        /// <summary>
        /// KensaIraiDtFrom 
        /// </summary>
        public string KensaIraiDtFrom { get; set; }

        /// <summary>
        /// KensaIraiDtTo 
        /// </summary>
        public string KensaIraiDtTo { get; set; }

        /// <summary>
        /// KensaDtFrom 
        /// </summary>
        public string KensaDtFrom { get; set; }

        /// <summary>
        /// KensaDtTo 
        /// </summary>
        public string KensaDtTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaJokyoListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaJokyoListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaJokyoListDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaJokyoListDataTable KensaJokyoListDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaJokyoListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaJokyoListBySearchCondDAOutput : ISelectKensaJokyoListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaJokyoListDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaJokyoListDataTable KensaJokyoListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaJokyoListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaJokyoListBySearchCondDataAccess : BaseDataAccess<ISelectKensaJokyoListBySearchCondDAInput, ISelectKensaJokyoListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaJokyoListTableAdapter tableAdapter = new KensaJokyoListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaJokyoListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaJokyoListBySearchCondDataAccess()
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
        /// 2014/08/18　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaJokyoListBySearchCondDAOutput Execute(ISelectKensaJokyoListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaJokyoListBySearchCondDAOutput output = new SelectKensaJokyoListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                // タイムアウトを設定(単位：秒)
                tableAdapter.CommandTimeout = Properties.Settings.Default.DefaultCommandTimeoutSec;

                output.KensaJokyoListDataTable = tableAdapter.GetDataBySearchCond(input.HoteiKbn,
                                                                                    DataAccessUtility.EscapeSQLString(input.JokasoSetchishaNm),
                                                                                    DataAccessUtility.EscapeSQLString(input.JokasoShisetsuNm),
                                                                                    input.SettisyaCd,
                                                                                    input.KensaIraiDtFrom,
                                                                                    input.KensaIraiDtTo,
                                                                                    input.KensaDtFrom,
                                                                                    input.KensaDtTo);

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
