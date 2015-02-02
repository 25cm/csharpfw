using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaKeihatsuSuishinHiShukeiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// 2014/10/09  DatNT    v1.01
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKeihatsuSuishinListBySearchCondDAInput
    {
        // 2014/10/09 DatNT v1.01 DEL Start
        ///// <summary>
        ///// 集計年度
        ///// </summary>
        //string SuishinhiNendo { get; set; }

        ///// <summary>
        ///// 上下期区分
        ///// </summary>
        //string KamiShimoKbn { get; set; }
        // 2014/10/09 DatNT v1.01 DEL End

        // 2014/10/09 DatNT v1.01 ADD Start
        /// <summary>
        /// 集計日FROM
        /// </summary>
        string ShukeiDtFrom { get; set; }
        /// <summary>
        /// 集計日TO
        /// </summary>
        string ShukeiDtTo { get; set; }
        // 2014/10/09 DatNT v1.01 ADD End

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        string GyosyaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        string GyosyaCdTo { get; set; }

        /// <summary>
        /// 組合コード
        /// </summary>
        string KumiaiCd { get; set; }

        /// <summary>
        /// 対象業者/持込
        /// </summary>
        bool Mochikomi { get; set; }

        /// <summary>
        /// 対象業者/収集
        /// </summary>
        bool Syusyu { get; set; }

        /// <summary>
        /// 対象業者/取扱
        /// </summary>
        bool Toriatsukai { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// 2014/10/09  DatNT    v1.01
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKeihatsuSuishinListBySearchCondDAInput : ISelectKensaKeihatsuSuishinListBySearchCondDAInput
    {
        // 2014/10/09 DatNT v1.01 DEL Start
        ///// <summary>
        ///// 集計年度
        ///// </summary>
        //public string SuishinhiNendo { get; set; }

        ///// <summary>
        ///// 上下期区分
        ///// </summary>
        //public string KamiShimoKbn { get; set; }
        // 2014/10/09 DatNT v1.01 DEL End

        // 2014/10/09 DatNT v1.01 ADD Start
        /// <summary>
        /// 集計日FROM
        /// </summary>
        public string ShukeiDtFrom { get; set; }
        /// <summary>
        /// 集計日TO
        /// </summary>
        public string ShukeiDtTo { get; set; }
        // 2014/10/09 DatNT v1.01 ADD End

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyosyaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string GyosyaCdTo { get; set; }

        /// <summary>
        /// 組合コード
        /// </summary>
        public string KumiaiCd { get; set; }

        /// <summary>
        /// 対象業者/持込
        /// </summary>
        public bool Mochikomi { get; set; }

        /// <summary>
        /// 対象業者/収集
        /// </summary>
        public bool Syusyu { get; set; }

        /// <summary>
        /// 対象業者/取扱
        /// </summary>
        public bool Toriatsukai { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKensaKeihatsuSuishinListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKensaKeihatsuSuishinListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKeihatsuSuishinListBySearchCondDAOutput : ISelectKensaKeihatsuSuishinListBySearchCondDAOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinListDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinListDataTable KensaKeihatsuSuishinListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKensaKeihatsuSuishinListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKensaKeihatsuSuishinListBySearchCondDataAccess : BaseDataAccess<ISelectKensaKeihatsuSuishinListBySearchCondDAInput, ISelectKensaKeihatsuSuishinListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KensaKeihatsuSuishinListTableAdapter tableAdapter = new KensaKeihatsuSuishinListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKensaKeihatsuSuishinListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKensaKeihatsuSuishinListBySearchCondDataAccess()
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
        /// 2014/08/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKensaKeihatsuSuishinListBySearchCondDAOutput Execute(ISelectKensaKeihatsuSuishinListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKensaKeihatsuSuishinListBySearchCondDAOutput output = new SelectKensaKeihatsuSuishinListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KensaKeihatsuSuishinListDT = tableAdapter.GetDataBySearchCond(input.ShukeiDtFrom,
                                                                                        input.ShukeiDtTo,
                                                                                        input.GyosyaCdFrom,
                                                                                        input.GyosyaCdTo,
                                                                                        input.KumiaiCd,
                                                                                        input.Mochikomi,
                                                                                        input.Syusyu,
                                                                                        input.Toriatsukai);

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
