using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsuke;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.SuishitsuKensaIraiUketsukeList
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
    /// 2014/12/03　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 水質検査区分(1:計量証明/2:水質/3:外観)
        /// </summary>
        string SuishitsuKensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
        /// <summary>
        /// 受付日(YYYYMMDD)
        /// </summary>
        string KensaIraiUketsukeDt { get; set; }
        /// <summary>
        /// 検体番号（開始）(6桁ゼロパディング)
        /// </summary>
        string KentaiFromNo { get; set; }
        /// <summary>
        /// 検体番号（終了）(6桁ゼロパディング)
        /// </summary>
        string KentaiToNo { get; set; }
        /// <summary>
        /// 残留塩素の試験項目コード(3桁ゼロパディング)
        /// </summary>
        string ZanryuEnsoCd { get; set; }
        /// <summary>
        /// 透視度の試験項目コード(3桁ゼロパディング)
        /// </summary>
        string ToshidoCd { get; set; }
       
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
    /// 2014/12/03　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// 水質検査区分(1:計量証明/2:水質/3:外観)
        /// </summary>
        public string SuishitsuKensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 受付日(YYYYMMDD)
        /// </summary>
        public string KensaIraiUketsukeDt { get; set; }
        /// <summary>
        /// 検体番号（開始）(6桁ゼロパディング)
        /// </summary>
        public string KentaiFromNo { get; set; }
        /// <summary>
        /// 検体番号（終了）(6桁ゼロパディング)
        /// </summary>
        public string KentaiToNo { get; set; }
        /// <summary>
        /// 残留塩素の試験項目コード(3桁ゼロパディング)
        /// </summary>
        public string ZanryuEnsoCd { get; set; }
        /// <summary>
        /// 透視度の試験項目コード(3桁ゼロパディング)
        /// </summary>
        public string ToshidoCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("水質検査区分[{0}], 依頼年度[{1}], 支所コード[{2}], 受付日[{3}], 検体番号(開始)[{4}], 検体番号(終了)[{5}], 残留塩素[{6}],  透視度[{7}]",
                    new string[] { SuishitsuKensaKbn, IraiNendo, ShishoCd, KensaIraiUketsukeDt, KentaiFromNo, KentaiToNo, ZanryuEnsoCd, ToshidoCd });
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
    /// 2014/12/03　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput
    {
        /// <summary>
        /// 検査受付一覧－計量証明用情報
        /// </summary>
        SuishitsuKensaUketsukeDataSet.KensaDaicho9joInfoDataTable KensaDaicho9joInfoDT { get; set; }
        
        /// <summary>
        /// 検査受付一覧－水質検査用情報
        /// </summary>
        SuishitsuKensaUketsukeDataSet.KensaDaichoSuishitsuInfoDataTable KensaDaichoSuishitsuInfoDT { get; set; }
        
        /// <summary>
        /// 検査受付一覧－外観検査用情報
        /// </summary>
        SuishitsuKensaUketsukeDataSet.KensaDaichoGaikanInfoDataTable KensaDaichoGaikanInfoDT { get; set; }
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
    /// 2014/12/03　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// 検査受付一覧－計量証明用情報
        /// </summary>
        public SuishitsuKensaUketsukeDataSet.KensaDaicho9joInfoDataTable KensaDaicho9joInfoDT { get; set; }
        
        /// <summary>
        /// 検査受付一覧－水質検査用情報
        /// </summary>
        public SuishitsuKensaUketsukeDataSet.KensaDaichoSuishitsuInfoDataTable KensaDaichoSuishitsuInfoDT { get; set; }
        
        /// <summary>
        /// 検査受付一覧－外観検査用情報
        /// </summary>
        public SuishitsuKensaUketsukeDataSet.KensaDaichoGaikanInfoDataTable KensaDaichoGaikanInfoDT { get; set; }
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
    /// 2014/12/03　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaUketsukeList：KensakuBtnClick";

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
        /// 2014/12/03　小松　　    新規作成
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
        /// 2014/12/03　小松　　    新規作成
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
        /// 2014/12/03　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                if (input.SuishitsuKensaKbn == "1")
                {
                    // 計量証明
                    ISelectKensaDaicho9joInfoBySearchCondDAInput inda = new SelectKensaDaicho9joInfoBySearchCondDAInput();
                    inda.IraiNendo = input.IraiNendo;
                    inda.ShishoCd = input.ShishoCd;
                    inda.KensaIraiUketsukeDt = input.KensaIraiUketsukeDt;
                    inda.KentaiFromNo = input.KentaiFromNo;
                    inda.KentaiToNo = input.KentaiToNo;
                    output.KensaDaicho9joInfoDT = new SelectKensaDaicho9joInfoBySearchCondDataAccess().Execute(inda).KensaDaicho9joInfoDT;
                }
                else if (input.SuishitsuKensaKbn == "2")
                {
                    // 水質検査
                    ISelectKensaDaichoSuishitsuInfoBySearchCondDAInput inda = new SelectKensaDaichoSuishitsuInfoBySearchCondDAInput();
                    inda.IraiNendo = input.IraiNendo;
                    inda.ShishoCd = input.ShishoCd;
                    inda.KensaIraiUketsukeDt = input.KensaIraiUketsukeDt;
                    inda.KentaiFromNo = input.KentaiFromNo;
                    inda.KentaiToNo = input.KentaiToNo;
                    inda.ZanryuEnsoCd = input.ZanryuEnsoCd;
                    output.KensaDaichoSuishitsuInfoDT = new SelectKensaDaichoSuishitsuInfoBySearchCondDataAccess().Execute(inda).KensaDaichoSuishitsuInfoDT;
                }
                else
                {
                    // 外観検査
                    ISelectKensaDaichoGaikanInfoBySearchCondDAInput inda = new SelectKensaDaichoGaikanInfoBySearchCondDAInput();
                    inda.IraiNendo = input.IraiNendo;
                    inda.ShishoCd = input.ShishoCd;
                    inda.KensaIraiUketsukeDt = input.KensaIraiUketsukeDt;
                    inda.KentaiFromNo = input.KentaiFromNo;
                    inda.KentaiToNo = input.KentaiToNo;
                    inda.ToshidoCd = input.ToshidoCd;
                    output.KensaDaichoGaikanInfoDT = new SelectKensaDaichoGaikanInfoBySearchCondDataAccess().Execute(inda).KensaDaichoGaikanInfoDT;
                }
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
