using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GyoshaBukaiMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.GyoshaBukaiMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKaiinListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// 2015/01/30  DatNT   v1.04
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKaiinListBySearchCondDAInput
    {
        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        string GyosyaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        string GyosyaCdTo { get; set; }

        /// <summary>
        /// 業者名称
        /// </summary>
        string GyosyaNm { get; set; }

        // 2015/01/30 DatNT DEL Start
        ///// <summary>
        ///// 入会日検索使用フラグ
        ///// </summary>
        //bool NyukaiDtUse { get; set; }

        ///// <summary>
        ///// 入会日（開始）
        ///// </summary>
        //string NyukaiDtFrom { get; set; }

        ///// <summary>
        ///// 入会日（終了）
        ///// </summary>
        //string NyukaiDtTo { get; set; }
        // 2015/01/30 DatNT DEL End

        /// <summary>
        /// 製造
        /// </summary>
        bool Seizo { get; set; }

        /// <summary>
        /// 工事
        /// </summary>
        bool Koji { get; set; }

        /// <summary>
        /// 保守
        /// </summary>
        bool Hosyu { get; set; }

        /// <summary>
        /// 清掃
        /// </summary>
        bool Seiso { get; set; }

        /// <summary>
        /// 未加入
        /// </summary>
        bool Mikanyu { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKaiinListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKaiinListBySearchCondDAInput : ISelectKaiinListBySearchCondDAInput
    {
        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyosyaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string GyosyaCdTo { get; set; }

        /// <summary>
        /// 業者名称
        /// </summary>
        public string GyosyaNm { get; set; }

        /// <summary>
        /// 入会日検索使用フラグ
        /// </summary>
        public bool NyukaiDtUse { get; set; }

        /// <summary>
        /// 入会日（開始）
        /// </summary>
        public string NyukaiDtFrom { get; set; }

        /// <summary>
        /// 入会日（終了）
        /// </summary>
        public string NyukaiDtTo { get; set; }

        /// <summary>
        /// 製造
        /// </summary>
        public bool Seizo { get; set; }

        /// <summary>
        /// 工事
        /// </summary>
        public bool Koji { get; set; }

        /// <summary>
        /// 保守
        /// </summary>
        public bool Hosyu { get; set; }

        /// <summary>
        /// 清掃
        /// </summary>
        public bool Seiso { get; set; }

        /// <summary>
        /// 未加入
        /// </summary>
        public bool Mikanyu { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKaiinListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectKaiinListBySearchCondDAOutput
    {
        /// <summary>
        /// KaiinListDataTable
        /// </summary>
        GyoshaBukaiMstDataSet.KaiinListDataTable KaiinListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKaiinListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKaiinListBySearchCondDAOutput : ISelectKaiinListBySearchCondDAOutput
    {
        /// <summary>
        /// KaiinListDataTable
        /// </summary>
        public GyoshaBukaiMstDataSet.KaiinListDataTable KaiinListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKaiinListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/21  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectKaiinListBySearchCondDataAccess : BaseDataAccess<ISelectKaiinListBySearchCondDAInput, ISelectKaiinListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KaiinListTableAdapter tableAdapter = new KaiinListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKaiinListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/21  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectKaiinListBySearchCondDataAccess()
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
        /// 2014/07/21  DatNT　  新規作成
        /// 2015/01/30  DatNT   v1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectKaiinListBySearchCondDAOutput Execute(ISelectKaiinListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKaiinListBySearchCondDAOutput output = new SelectKaiinListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KaiinListDT = tableAdapter.GetDataBySearchCond(input.GyosyaCdFrom,
                                                                        input.GyosyaCdTo,
                                                                        DataAccessUtility.EscapeSQLString(input.GyosyaNm),
                                                                        // 2015/01/30 DatNT v1.04 DEL Start
                                                                        //input.NyukaiDtUse,
                                                                        //input.NyukaiDtFrom,
                                                                        //input.NyukaiDtTo,
                                                                        // 2015/01/30 DatNT v1.04 DEL End
                                                                        input.Seizo,
                                                                        input.Koji,
                                                                        input.Hosyu,
                                                                        input.Seiso,
                                                                        input.Mikanyu);

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
