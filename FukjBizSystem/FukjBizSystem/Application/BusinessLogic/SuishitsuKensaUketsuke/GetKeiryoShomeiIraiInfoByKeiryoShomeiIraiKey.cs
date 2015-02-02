using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuKensaUketsukeShosai;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLInput : ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLInput : IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLInput
    {
        /// <summary>
        /// KeiryoShomeiIraiNendo
        /// </summary>
        public string KeiryoShomeiIraiNendo { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiSishoCd
        /// </summary>
        public string KeiryoShomeiIraiSishoCd { get; set; }

        /// <summary>
        /// KeiryoShomeiIraiRenban
        /// </summary>
        public string KeiryoShomeiIraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput : ISelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput : IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput
    {
        /// <summary>
        /// KeiryoShomeiIraiInfo
        /// </summary>
        public SuishitsuKensaUketsukeShosaiDataSet.KeiryoShomeiIraiInfoDataTable KeiryoShomeiIraiInfo { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/10  豊田　　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBusinessLogic : BaseBusinessLogic<IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLInput, IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/10  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBusinessLogic()
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
        /// 2014/12/10  豊田　　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput Execute(IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput output = new GetKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyBLOutput();

            try
            {
                output.KeiryoShomeiIraiInfo = new SelectKeiryoShomeiIraiInfoByKeiryoShomeiIraiKeyDataAccess().Execute(input).KeiryoShomeiIraiInfo;
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
