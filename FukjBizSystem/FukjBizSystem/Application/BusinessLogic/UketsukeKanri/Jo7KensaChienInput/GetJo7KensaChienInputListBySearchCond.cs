using System.Reflection;
using FukjBizSystem.Application.DataAccess.JokasoDaichoMst;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.UketsukeKanri;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaChienInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJo7KensaChienInputListBySearchCondBLInput
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
    interface IGetJo7KensaChienInputListBySearchCondBLInput : ISelectJo7KensaChienInputListBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJo7KensaChienInputListBySearchCondBLInput
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
    class GetJo7KensaChienInputListBySearchCondBLInput : IGetJo7KensaChienInputListBySearchCondBLInput
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
    //  インターフェイス名 ： IGetJo7KensaChienInputListBySearchCondBLOutput
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
    interface IGetJo7KensaChienInputListBySearchCondBLOutput : ISelectJo7KensaChienInputListBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJo7KensaChienInputListBySearchCondBLOutput
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
    class GetJo7KensaChienInputListBySearchCondBLOutput : IGetJo7KensaChienInputListBySearchCondBLOutput
    {
        /// <summary>
        /// Jo7KensaChienInputListDataTable
        /// </summary>
        public Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable Jo7KensaChienInputListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJo7KensaChienInputListBySearchCondBusinessLogic
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
    class GetJo7KensaChienInputListBySearchCondBusinessLogic : BaseBusinessLogic<IGetJo7KensaChienInputListBySearchCondBLInput, IGetJo7KensaChienInputListBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetJo7KensaChienInputListBySearchCondBusinessLogic
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
        public GetJo7KensaChienInputListBySearchCondBusinessLogic()
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
        public override IGetJo7KensaChienInputListBySearchCondBLOutput Execute(IGetJo7KensaChienInputListBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetJo7KensaChienInputListBySearchCondBLOutput output = new GetJo7KensaChienInputListBySearchCondBLOutput();

            try
            {
                output.Jo7KensaChienInputListDT = new SelectJo7KensaChienInputListBySearchCondDataAccess().Execute(input).Jo7KensaChienInputListDT;
            }
            catch
            {
                throw;
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
