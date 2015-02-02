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
    //  インターフェイス名 ： ISelectEnkabutsuIonNodoHikakuListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectEnkabutsuIonNodoHikakuListBySearchCondDAInput
    {
        /// <summary>
        /// 採水日（開始）
        /// </summary>
        string SaisuiDtFrom { get; set; }

        /// <summary>
        /// 採水日（終了）
        /// </summary>
        string SaisuiDtTo { get; set; }

        /// <summary>
        /// 採水員名
        /// </summary>
        string SaisuiinNm { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectEnkabutsuIonNodoHikakuListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectEnkabutsuIonNodoHikakuListBySearchCondDAInput : ISelectEnkabutsuIonNodoHikakuListBySearchCondDAInput
    {
        /// <summary>
        /// 採水日（開始）
        /// </summary>
        public string SaisuiDtFrom { get; set; }

        /// <summary>
        /// 採水日（終了）
        /// </summary>
        public string SaisuiDtTo { get; set; }

        /// <summary>
        /// 採水員名
        /// </summary>
        public string SaisuiinNm { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput
    {
        /// <summary>
        /// EnkabutsuIonNodoHikakuListDataTable
        /// </summary>
        KensaIraiTblDataSet.EnkabutsuIonNodoHikakuListDataTable EnkabutsuIonNodoHikakuListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput : ISelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput
    {
        /// <summary>
        /// EnkabutsuIonNodoHikakuListDataTable
        /// </summary>
        public KensaIraiTblDataSet.EnkabutsuIonNodoHikakuListDataTable EnkabutsuIonNodoHikakuListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectEnkabutsuIonNodoHikakuListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectEnkabutsuIonNodoHikakuListBySearchCondDataAccess : BaseDataAccess<ISelectEnkabutsuIonNodoHikakuListBySearchCondDAInput, ISelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private EnkabutsuIonNodoHikakuListTableAdapter tableAdapter = new EnkabutsuIonNodoHikakuListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectEnkabutsuIonNodoHikakuListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectEnkabutsuIonNodoHikakuListBySearchCondDataAccess()
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
        /// 2014/08/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput Execute(ISelectEnkabutsuIonNodoHikakuListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput output = new SelectEnkabutsuIonNodoHikakuListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.EnkabutsuIonNodoHikakuListDT = tableAdapter.GetDataBySearchCond(input.SaisuiDtFrom,
                                                                                        input.SaisuiDtTo,
                                                                                        DataAccessUtility.EscapeSQLString(input.SaisuiinNm));

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
