using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaChienInput;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.UketsukeKanri;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.Jo7KensaChienInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
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
    interface IKensakuBtnClickALInput : IBseALInput, IGetJo7KensaChienInputListBySearchCondBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
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
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
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

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所コード[{0}], 処理対象人員[{1}], 使用開始日の条件追加フラグ[{2}], 使用開始日（開始）[{3}], 使用開始日（終了）[{4}], 検査実施日の条件追加フラグ[{5}], 検査実施日（開始）[{6}], 検査実施日（終了）[{7}], 報告書未作成[{8}], 報告書作成済[{9}]", 
                    new string[] { 
                        ShishoCd,
                        KensaIraiShoritaishoJinin,
                        KensaIraiShiyoKaishiDtJokenTuikaFlg.ToString(),
                        KensaIraiShiyoKaishiDtFrom,
                        KensaIraiShiyoKaishiDtTo,
                        KensaJisshiBijokenTsuikaFlg.ToString(),
                        KensaIraiKensaDtFrom,
                        KensaIraiKensaDtTo,
                        MiSakuseiFlag.ToString(),
                        SakuseiSumiFlag.ToString()
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
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
    interface IKensakuBtnClickALOutput : IGetJo7KensaChienInputListBySearchCondBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
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
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// Jo7KensaChienInputListDataTable
        /// </summary>
        public Jo7KensaChienInputListDataSet.Jo7KensaChienInputListDataTable Jo7KensaChienInputListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
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
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "Jo7KensaChienInput：KensakuBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
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
        public KensakuBtnClickApplicationLogic()
        {
            
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/15  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                output.Jo7KensaChienInputListDT = new GetJo7KensaChienInputListBySearchCondBusinessLogic().Execute(input).Jo7KensaChienInputListDT;
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
