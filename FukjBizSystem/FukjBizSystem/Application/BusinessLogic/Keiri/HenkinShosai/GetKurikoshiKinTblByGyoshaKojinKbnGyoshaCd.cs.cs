using System.Reflection;
using FukjBizSystem.Application.DataAccess.KurikoshiKinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.HenkinShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput
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
    interface IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput : ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput
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
    class GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput : IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput
    {
        /// <summary>
        /// 業者個人区分
        /// </summary>
        public string GyosyaKojinKbn { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput
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
    interface IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput : ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput
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
    class GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput : IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput
    {
        /// <summary>
        /// 繰越金テーブル
        /// </summary>
        public KurikoshiKinTblDataSet.KurikoshiKinTblDataTable KurikoshiKinTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBusinessLogic
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
    class GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBusinessLogic : BaseBusinessLogic<IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput, IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBusinessLogic
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
        public GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBusinessLogic()
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
        public override IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput Execute(IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput output = new GetKurikoshiKinTblByGyoshaKojinKbnGyoshaCdBLOutput();

            try
            {
                ISelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDAOutput daOutput = new SelectKurikoshiKinTblByGyoshaKojinKbnGyoshaCdDataAccess().Execute(input);
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
