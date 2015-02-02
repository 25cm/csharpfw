using System.Reflection;
using FukjBizSystem.Application.DataAccess.MaeukekinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.MaeukekinList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMaeukekinTblBySearchCondBLInput
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
    interface IGetMaeukekinTblBySearchCondBLInput : ISelectMaeukekinTblBySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaeukekinTblBySearchCondBLInput
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
    class GetMaeukekinTblBySearchCondBLInput : IGetMaeukekinTblBySearchCondBLInput
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
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMaeukekinTblBySearchCondBLOutput
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
    interface IGetMaeukekinTblBySearchCondBLOutput : ISelectMaeukekinTblBySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaeukekinTblBySearchCondBLOutput
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
    class GetMaeukekinTblBySearchCondBLOutput : IGetMaeukekinTblBySearchCondBLOutput
    {
        /// <summary>
        /// MaeukekinTblKensakuDataTable
        /// </summary>
        public MaeukekinTblDataSet.MaeukekinTblKensakuDataTable MaeukekinTblKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaeukekinTblBySearchCondBusinessLogic
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
    class GetMaeukekinTblBySearchCondBusinessLogic : BaseBusinessLogic<IGetMaeukekinTblBySearchCondBLInput, IGetMaeukekinTblBySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMaeukekinTblBySearchCondBusinessLogic
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
        public GetMaeukekinTblBySearchCondBusinessLogic()
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
        /// 2014/07/18  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetMaeukekinTblBySearchCondBLOutput Execute(IGetMaeukekinTblBySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMaeukekinTblBySearchCondBLOutput output = new GetMaeukekinTblBySearchCondBLOutput();

            try
            {
                output.MaeukekinTblKensakuDT = new SelectMaeukekinTblBySearchCondDataAccess().Execute(input).MaeukekinTblKensakuDT;
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
