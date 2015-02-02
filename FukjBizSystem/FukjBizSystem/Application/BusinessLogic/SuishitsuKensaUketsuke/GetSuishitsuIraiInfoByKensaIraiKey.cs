using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuIraiInfoByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuIraiInfoByKensaIraiKeyBLInput : ISelectSuishitsuIraiInfoByKensaIraiKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuIraiInfoByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuIraiInfoByKensaIraiKeyBLInput : IGetSuishitsuIraiInfoByKensaIraiKeyBLInput
    {
        /// <summary>
        /// KensaIraiHoteiKbn
        /// </summary>
        public string KensaIraiHoteiKbn { get; set; }

        /// <summary>
        /// KensaIraiHokenjoCd
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// KensaIraiNendo
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// KensaIraiRenban
        /// </summary>
        public string KensaIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuIraiInfoByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuIraiInfoByKensaIraiKeyBLOutput : ISelectSuishitsuIraiInfoByKensaIraiKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuIraiInfoByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuIraiInfoByKensaIraiKeyBLOutput : IGetSuishitsuIraiInfoByKensaIraiKeyBLOutput
    {
        /// <summary>
        /// SuishitsuIraiInfo
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.SuishitsuIraiInfoDataTable SuishitsuIraiInfo { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuIraiInfoByKensaIraiKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuIraiInfoByKensaIraiKeyBusinessLogic : BaseBusinessLogic<IGetSuishitsuIraiInfoByKensaIraiKeyBLInput, IGetSuishitsuIraiInfoByKensaIraiKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuIraiInfoByKensaIraiKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuIraiInfoByKensaIraiKeyBusinessLogic()
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
        /// 2014/12/08  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuIraiInfoByKensaIraiKeyBLOutput Execute(IGetSuishitsuIraiInfoByKensaIraiKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuIraiInfoByKensaIraiKeyBLOutput output = new GetSuishitsuIraiInfoByKensaIraiKeyBLOutput();

            try
            {
                output.SuishitsuIraiInfo = new SelectSuishitsuIraiInfoByKensaIraiKeyDataAccess().Execute(input).SuishitsuIraiInfo;
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
