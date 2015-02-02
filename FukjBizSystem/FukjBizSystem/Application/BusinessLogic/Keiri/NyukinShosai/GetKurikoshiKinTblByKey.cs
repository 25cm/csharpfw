using System.Reflection;
using FukjBizSystem.Application.DataAccess.KurikoshiKinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.NyukinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKurikoshiKinTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKurikoshiKinTblByKeyBLInput : ISelectKurikoshiKinTblByKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKurikoshiKinTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKurikoshiKinTblByKeyBLInput : IGetKurikoshiKinTblByKeyBLInput
    {
        /// <summary>
        /// KurikoshikinNo
        /// </summary>
        public string KurikoshikinNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKurikoshiKinTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKurikoshiKinTblByKeyBLOutput : ISelectKurikoshiKinTblByKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKurikoshiKinTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKurikoshiKinTblByKeyBLOutput : IGetKurikoshiKinTblByKeyBLOutput
    {
        /// <summary>
        /// KurikoshiKinTblDataTable
        /// </summary>
        public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKurikoshiKinTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/12  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKurikoshiKinTblByKeyBusinessLogic : BaseBusinessLogic<IGetKurikoshiKinTblByKeyBLInput, IGetKurikoshiKinTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKurikoshiKinTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/12  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKurikoshiKinTblByKeyBusinessLogic()
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
        /// 2014/12/12  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKurikoshiKinTblByKeyBLOutput Execute(IGetKurikoshiKinTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKurikoshiKinTblByKeyBLOutput output = new GetKurikoshiKinTblByKeyBLOutput();

            try
            {
                output.KurikoshiKinTblDataTable = new SelectKurikoshiKinTblByKeyDataAccess().Execute(input).KurikoshiKinTblDataTable;

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
