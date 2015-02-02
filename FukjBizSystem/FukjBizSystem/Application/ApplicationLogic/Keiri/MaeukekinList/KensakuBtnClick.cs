using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.MaeukekinList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.MaeukekinList
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
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput, IGetMaeukekinTblBySearchCondBLInput
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
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        // 2014/11/10 DatNT v1.02 MOD Start

        ///// <summary>
        ///// 採番区分
        ///// 採番区分 両方           : string.Empty
        ///// 採番区分 振込用紙記載No  : 0
        ///// 採番区分 自動採番        : 1
        ///// </summary>
        //public string SaibanKbn { get; set; }

        ///// <summary>
        ///// 前受金No（開始）
        ///// </summary>
        //public string MaeukeNoFrom { get; set; }

        ///// <summary>
        ///// 前受金No（終了）
        ///// </summary>
        //public string MaeukeNoTo { get; set; }

        /// <summary>
        /// 連動区分
        /// </summary>
        public string RendoKbn { get; set; }

        /// <summary>
        /// 前受金No
        /// </summary>
        public string MaeukeNo { get; set; }

        /// <summary>
        /// 売上日検索使用フラグ
        /// </summary>
        public bool UriageDtUse { get; set; }

        /// <summary>
        /// 売上日（開始）
        /// </summary>
        public string UriageDtFrom { get; set; }

        /// <summary>
        /// 売上日（終了）
        /// </summary>
        public string UriageDtTo { get; set; }

        /// <summary>
        /// 強制売上のみフラグ
        /// </summary>
        public bool KyoseiUriage { get; set; }

        // 2014/11/10 DatNT v1.02 MOD End

        /// <summary>
        /// 振込人
        /// </summary>
        public string FurikomininNm { get; set; }

        /// <summary>
        /// 入金日検索使用フラグ
        /// </summary>
        public bool NyukinDtUse { get; set; }

        /// <summary>
        /// 入金日（開始）
        /// </summary>
        public string NyukinDtFrom { get; set; }

        /// <summary>
        /// 入金日（終了）
        /// </summary>
        public string NyukinDtTo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                //return string.Format("採番区分[{0}], 前受金No（開始）[{1}], 前受金No（終了）[{2}], 振込人[{3}], 入金日検索使用フラグ[{4}], 入金日（開始）[{5}], 入金日（終了）[{6}]",
                //    new string[]{
                //        SaibanKbn,
                //        MaeukeNoFrom,
                //        MaeukeNoTo,
                //        FurikomininNm,
                //        NyukinDtUse.ToString(),
                //        NyukinDtFrom,
                //        NyukinDtTo
                //    });

                return string.Format("連動区分[{0}], 前受金No[{1}], 売上日検索使用フラグ[{2}], 売上日（開始）[{3}], 売上日（終了）[{4}], 強制売上のみフラグ[{5}], 振込人[{6}], 入金日検索使用フラグ[{7}], 入金日（開始）[{8}], 入金日（終了）[{9}]",
                    new string[]{
                        RendoKbn,
                        MaeukeNo,
                        UriageDtUse.ToString(),
                        UriageDtFrom,
                        UriageDtTo,
                        KyoseiUriage.ToString(),
                        FurikomininNm,
                        NyukinDtUse.ToString(),
                        NyukinDtFrom,
                        NyukinDtTo
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
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput : IGetMaeukekinTblBySearchCondBLOutput
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
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// MaeukekinTblKensakuDataTable
        /// </summary>
        public MaeukekinTblDataSet.MaeukekinTblKensakuDataTable MaeukekinTblKensakuDT { get; set; }
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
    /// 2014/07/18  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "MaeukekinList：KensakuBtnClickApplicationLogic";

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
        /// 2014/07/18  DatNT　  新規作成
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
        /// 2014/07/18  DatNT　  新規作成
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
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                output.MaeukekinTblKensakuDT = new GetMaeukekinTblBySearchCondBusinessLogic().Execute(input).MaeukekinTblKensakuDT;
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
