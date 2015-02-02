using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.SaisuiinMstDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.SaisuiinMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJyukoYoteishaListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJyukoYoteishaListBySearchCondDAInput
    {
        /// <summary>
        /// 前回受講日追加フラグ
        /// </summary>
        bool ZenkaiJukoDtAddFlg { get; set; }

        /// <summary>
        /// 前回受講日（開始）
        /// </summary>
        string ZenkaiJukoDtFrom { get; set; }

        /// <summary>
        /// 前回受講日（終了）
        /// </summary>
        string ZenkaiJukoDtTo { get; set; }

        /// <summary>
        /// 有効期限追加フラグ
        /// </summary>
        bool SaisuiinYukokigenDtAddFlg { get; set; }

        /// <summary>
        /// 有効期限（開始）
        /// </summary>
        string SaisuiinYukokigenDtFrom { get; set; }

        /// <summary>
        /// 有効期限（終了）
        /// </summary>
        string SaisuiinYukokigenDtTo { get; set; }

        /// <summary>
        /// 採水員コード（開始）
        /// </summary>
        string SaisuiinCdFrom { get; set; }

        /// <summary>
        /// 採水員コード（終了）
        /// </summary>
        string SaisuiinCdTo { get; set; }

        /// <summary>
        /// 所属業者コード（開始）
        /// </summary>
        string SyozokuGyosyaCdFrom { get; set; }

        /// <summary>
        /// 所属業者コード（終了）
        /// </summary>
        string SyozokuGyosyaCdTo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJyukoYoteishaListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJyukoYoteishaListBySearchCondDAInput : ISelectJyukoYoteishaListBySearchCondDAInput
    {
        /// <summary>
        /// 前回受講日追加フラグ
        /// </summary>
        public bool ZenkaiJukoDtAddFlg { get; set; }

        /// <summary>
        /// 前回受講日（開始）
        /// </summary>
        public string ZenkaiJukoDtFrom { get; set; }

        /// <summary>
        /// 前回受講日（終了）
        /// </summary>
        public string ZenkaiJukoDtTo { get; set; }

        /// <summary>
        /// 有効期限追加フラグ
        /// </summary>
        public bool SaisuiinYukokigenDtAddFlg { get; set; }

        /// <summary>
        /// 有効期限（開始）
        /// </summary>
        public string SaisuiinYukokigenDtFrom { get; set; }

        /// <summary>
        /// 有効期限（終了）
        /// </summary>
        public string SaisuiinYukokigenDtTo { get; set; }

        /// <summary>
        /// 採水員コード（開始）
        /// </summary>
        public string SaisuiinCdFrom { get; set; }

        /// <summary>
        /// 採水員コード（終了）
        /// </summary>
        public string SaisuiinCdTo { get; set; }

        /// <summary>
        /// 所属業者コード（開始）
        /// </summary>
        public string SyozokuGyosyaCdFrom { get; set; }

        /// <summary>
        /// 所属業者コード（終了）
        /// </summary>
        public string SyozokuGyosyaCdTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJyukoYoteishaListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJyukoYoteishaListBySearchCondDAOutput
    {
        /// <summary>
        /// JyukoYoteishaListDataTable
        /// </summary>
        SaisuiinMstDataSet.JyukoYoteishaListDataTable JyukoYoteishaListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJyukoYoteishaListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJyukoYoteishaListBySearchCondDAOutput : ISelectJyukoYoteishaListBySearchCondDAOutput
    {
        /// <summary>
        /// JyukoYoteishaListDataTable
        /// </summary>
        public SaisuiinMstDataSet.JyukoYoteishaListDataTable JyukoYoteishaListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJyukoYoteishaListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJyukoYoteishaListBySearchCondDataAccess : BaseDataAccess<ISelectJyukoYoteishaListBySearchCondDAInput, ISelectJyukoYoteishaListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private JyukoYoteishaListTableAdapter tableAdapter = new JyukoYoteishaListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJyukoYoteishaListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJyukoYoteishaListBySearchCondDataAccess()
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
        /// 2014/07/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJyukoYoteishaListBySearchCondDAOutput Execute(ISelectJyukoYoteishaListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJyukoYoteishaListBySearchCondDAOutput output = new SelectJyukoYoteishaListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.JyukoYoteishaListDT = tableAdapter.GetDataBySearchCond(input.ZenkaiJukoDtAddFlg,
                                                                                input.ZenkaiJukoDtFrom,
                                                                                input.ZenkaiJukoDtTo,
                                                                                input.SaisuiinYukokigenDtAddFlg,
                                                                                input.SaisuiinYukokigenDtFrom,
                                                                                input.SaisuiinYukokigenDtTo,
                                                                                input.SaisuiinCdFrom,
                                                                                input.SaisuiinCdTo,
                                                                                input.SyozokuGyosyaCdFrom,
                                                                                input.SyozokuGyosyaCdTo);
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
