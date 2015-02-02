using System.Reflection;
using FukjBizSystem.Application.DataAccess.KurikoshiKinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.HenkinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput : ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput : IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput
    {
        /// <summary>
        /// 業者個人区分
        /// </summary>
        public string GyosyaKojinKbn { get; set; }

        /// <summary>
        /// 浄化槽保健所コード
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// 浄化槽台帳登録年度
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// 浄化槽台帳連番
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput : ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput : IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput
    {
        /// <summary>
        /// 繰越金テーブル
        /// </summary>
        public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/06　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBusinessLogic : BaseBusinessLogic<IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput, IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/06　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBusinessLogic()
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
        /// 2014/11/06　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput Execute(IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput output = new GetKurikoshiKinTblByGyoshaKojinKbnJokasoKeyBLOutput();

            try
            {
                ISelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDAOutput daOutput = new SelectKurikoshiKinTblByGyoshaKojinKbnJokasoKeyDataAccess().Execute(input);
                output.KurikoshiKinTblDataTable = daOutput.KurikoshiKinTblDataTable;
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
