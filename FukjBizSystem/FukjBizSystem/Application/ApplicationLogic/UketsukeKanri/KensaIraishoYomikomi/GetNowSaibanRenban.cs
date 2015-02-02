using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.KensaIraishoYomikomi;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.KensaIraishoYomikomi
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNowSaibanRenbanALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNowSaibanRenbanALInput : IBseALInput, IGetSaibanTblByKeyBLInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNowSaibanRenbanALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNowSaibanRenbanALInput : IGetNowSaibanRenbanALInput
    {
        /// <summary>
        /// 採番年度
        /// </summary>
        public String SaibanNendo { get; set; }

        /// <summary>
        /// 採番区分
        /// </summary>
        public String SaibanKbn { get; set; }
                
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="saibanNendo"></param>
        /// <param name="saibanKbn"></param>
        public GetNowSaibanRenbanALInput(String saibanNendo, String saibanKbn)
        {
            // 採番年度
            SaibanNendo = saibanNendo;

            // 採番区分
            SaibanKbn = saibanKbn;
        }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("採番年度[{0}], 採番区分[{1}]", new string[] { SaibanNendo, SaibanKbn });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNowSaibanRenbanALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNowSaibanRenbanALOutput
    {
        /// <summary>
        /// NowRenban
        /// </summary>
        decimal NowRenban { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNowSaibanRenbanALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNowSaibanRenbanALOutput : IGetNowSaibanRenbanALOutput
    {
        /// <summary>
        /// NowRenban
        /// </summary>
        public decimal NowRenban { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNowSaibanRenbanApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/27　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNowSaibanRenbanApplicationLogic : BaseApplicationLogic<IGetNowSaibanRenbanALInput, IGetNowSaibanRenbanALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaIraishoYomikomi：GetNowSaibanRenbanApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetNowSaibanRenbanApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetNowSaibanRenbanApplicationLogic()
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
        /// 2014/09/27　豊田　　    新規作成
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
        /// 2014/09/27　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetNowSaibanRenbanALOutput Execute(IGetNowSaibanRenbanALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetNowSaibanRenbanALOutput output = new GetNowSaibanRenbanALOutput();

            try
            {
                IGetSaibanTblByKeyBLOutput blOutput = new GetSaibanTblByKeyBusinessLogic().Execute(input);

                if (blOutput.SaibanTblDT.Count > 0)
                {
                    output.NowRenban = decimal.Parse(blOutput.SaibanTblDT[0].SaibanRenban);
                }
                else
                {
                    output.NowRenban = 0;
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
