using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.JokasoDaichoMstDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.UketsukeKanri;
using FukjBizSystem.Application.DataSet.UketsukeKanri.Jo7KensaChienInputListDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.JokasoDaichoMst
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJo7KensaChienInputListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJo7KensaChienInputListBySearchCondDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        /// <summary>
        /// 処理対象人員
        /// </summary>
        string KensaIraiShoritaishoJinin { get; set; }

        /// <summary>
        /// 使用開始日の条件追加フラグ
        /// </summary>
        bool KensaIraiShiyoKaishiDtJokenTuikaFlg { get; set; }

        /// <summary>
        /// 使用開始日（開始）
        /// </summary>
        string KensaIraiShiyoKaishiDtFrom { get; set; }

        /// <summary>
        /// 使用開始日（終了）
        /// </summary>
        string KensaIraiShiyoKaishiDtTo { get; set; }

        /// <summary>
        /// 検査実施日の条件追加フラグ
        /// </summary>
        bool KensaJisshiBijokenTsuikaFlg { get; set; }

        /// <summary>
        /// 検査実施日（開始）
        /// </summary>
        string KensaIraiKensaDtFrom { get; set; }

        /// <summary>
        /// 検査実施日（終了）
        /// </summary>
        string KensaIraiKensaDtTo { get; set; }

        // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
        /// <summary>
        /// 報告書未作成
        /// </summary>
        bool MiSakuseiFlag { get; set; }

        /// <summary>
        /// 報告書作成済
        /// </summary>
        bool SakuseiSumiFlag { get; set; }
        // 2015.01.30 toyoda Add End
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJo7KensaChienInputListBySearchCondDAInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJo7KensaChienInputListBySearchCondDAInput : ISelectJo7KensaChienInputListBySearchCondDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 処理対象人員
        /// </summary>
        public string KensaIraiShoritaishoJinin { get; set; }

        /// <summary>
        /// 使用開始日の条件追加フラグ
        /// </summary>
        public bool KensaIraiShiyoKaishiDtJokenTuikaFlg { get; set; }

        /// <summary>
        /// 使用開始日（開始）
        /// </summary>
        public string KensaIraiShiyoKaishiDtFrom { get; set; }

        /// <summary>
        /// 使用開始日（終了）
        /// </summary>
        public string KensaIraiShiyoKaishiDtTo { get; set; }

        /// <summary>
        /// 検査実施日の条件追加フラグ
        /// </summary>
        public bool KensaJisshiBijokenTsuikaFlg { get; set; }

        /// <summary>
        /// 検査実施日（開始）
        /// </summary>
        public string KensaIraiKensaDtFrom { get; set; }

        /// <summary>
        /// 検査実施日（終了）
        /// </summary>
        public string KensaIraiKensaDtTo { get; set; }

        // 2015.01.30 toyoda Add Start 遅延報告アップロード後にフラグを更新する
        /// <summary>
        /// 報告書未作成
        /// </summary>
        public bool MiSakuseiFlag { get; set; }

        /// <summary>
        /// 報告書作成済
        /// </summary>
        public bool SakuseiSumiFlag { get; set; }
        // 2015.01.30 toyoda Add End
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectJo7KensaChienInputListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ISelectJo7KensaChienInputListBySearchCondDAOutput
    {
        /// <summary>
        /// Jo7KensaChienInputListDataTable
        /// </summary>
        Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable Jo7KensaChienInputListDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJo7KensaChienInputListBySearchCondDAOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJo7KensaChienInputListBySearchCondDAOutput : ISelectJo7KensaChienInputListBySearchCondDAOutput
    {
        /// <summary>
        /// Jo7KensaChienInputListDataTable
        /// </summary>
        public Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable Jo7KensaChienInputListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectJo7KensaChienInputListBySearchCondDataAccess
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/15  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class SelectJo7KensaChienInputListBySearchCondDataAccess : BaseDataAccess<ISelectJo7KensaChienInputListBySearchCondDAInput, ISelectJo7KensaChienInputListBySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private Jo7KensaChienInputListTableAdapter tableAdapter = new Jo7KensaChienInputListTableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectJo7KensaChienInputListBySearchCondDataAccess
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public SelectJo7KensaChienInputListBySearchCondDataAccess()
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
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ISelectJo7KensaChienInputListBySearchCondDAOutput Execute(ISelectJo7KensaChienInputListBySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectJo7KensaChienInputListBySearchCondDAOutput output = new SelectJo7KensaChienInputListBySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.Jo7KensaChienInputListDT = tableAdapter.GetDataBySearchCond(input.ShishoCd,
                                                                                    input.KensaIraiShoritaishoJinin,
                                                                                    input.KensaIraiShiyoKaishiDtJokenTuikaFlg,
                                                                                    input.KensaIraiShiyoKaishiDtFrom,
                                                                                    input.KensaIraiShiyoKaishiDtTo,
                                                                                    input.KensaJisshiBijokenTsuikaFlg,
                                                                                    input.KensaIraiKensaDtFrom,
                                                                                    input.KensaIraiKensaDtTo,
                                                                                    input.MiSakuseiFlag,
                                                                                    input.SakuseiSumiFlag);

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
