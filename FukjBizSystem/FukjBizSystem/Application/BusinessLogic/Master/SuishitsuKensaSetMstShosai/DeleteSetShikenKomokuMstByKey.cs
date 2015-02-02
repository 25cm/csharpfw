using System.Reflection;
using FukjBizSystem.Application.DataAccess.SetShikenKomokuMst;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Master.SuishitsuKensaSetMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSetShikenKomokuMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSetShikenKomokuMstByKeyBLInput : IDeleteSetShikenKomokuMstByKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSetShikenKomokuMstByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSetShikenKomokuMstByKeyBLInput : IDeleteSetShikenKomokuMstByKeyBLInput
    {
        /// <summary>
        /// SetKomokuSetCd
        /// </summary>
        public string SetKomokuSetCd { get; set; }

        /// <summary>
        /// SetKomokuCd
        /// </summary>
        public string SetKomokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteSetShikenKomokuMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteSetShikenKomokuMstByKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSetShikenKomokuMstByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSetShikenKomokuMstByKeyBLOutput : IDeleteSetShikenKomokuMstByKeyBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteSetShikenKomokuMstByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/28  HuyTX    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteSetShikenKomokuMstByKeyBusinessLogic : BaseBusinessLogic<IDeleteSetShikenKomokuMstByKeyBLInput, IDeleteSetShikenKomokuMstByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteSetShikenKomokuMstByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/28  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteSetShikenKomokuMstByKeyBusinessLogic()
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
        /// 2015/01/28  HuyTX    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteSetShikenKomokuMstByKeyBLOutput Execute(IDeleteSetShikenKomokuMstByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteSetShikenKomokuMstByKeyBLOutput output = new DeleteSetShikenKomokuMstByKeyBLOutput();

            try
            {
                new DeleteSetShikenKomokuMstByKeyDataAccess().Execute(input);

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
