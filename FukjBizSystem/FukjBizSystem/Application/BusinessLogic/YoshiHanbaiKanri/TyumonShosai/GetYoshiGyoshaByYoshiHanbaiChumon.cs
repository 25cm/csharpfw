using System.Reflection;
using FukjBizSystem.Application.DataAccess.YoshiHanbaiHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.YoshiHanbaiKanri.TyumonShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYoshiGyoshaByYoshiHanbaiChumonBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYoshiGyoshaByYoshiHanbaiChumonBLInput : ISelectYoshiGyoshaByYoshiHanbaiChumonNoDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYoshiGyoshaByYoshiHanbaiChumonBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYoshiGyoshaByYoshiHanbaiChumonBLInput : IGetYoshiGyoshaByYoshiHanbaiChumonBLInput
    {
        /// <summary>
        /// 注文番号
        /// </summary>
        public string YoshiHanbaiChumonNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetYoshiGyoshaByYoshiHanbaiChumonBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetYoshiGyoshaByYoshiHanbaiChumonBLOutput : ISelectYoshiGyoshaByYoshiHanbaiChumonNoDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYoshiGyoshaByYoshiHanbaiChumonBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYoshiGyoshaByYoshiHanbaiChumonBLOutput : IGetYoshiGyoshaByYoshiHanbaiChumonBLOutput
    {
        /// <summary>
        /// YoshiGyoshaDataTable
        /// </summary>
        public YoshiHanbaiHdrTblDataSet.YoshiGyoshaDataTable YoshiGyoshaDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetYoshiGyoshaByYoshiHanbaiChumonBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetYoshiGyoshaByYoshiHanbaiChumonBusinessLogic : BaseBusinessLogic<IGetYoshiGyoshaByYoshiHanbaiChumonBLInput, IGetYoshiGyoshaByYoshiHanbaiChumonBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetYoshiGyoshaByYoshiHanbaiChumonBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetYoshiGyoshaByYoshiHanbaiChumonBusinessLogic()
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
        /// 2014/10/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetYoshiGyoshaByYoshiHanbaiChumonBLOutput Execute(IGetYoshiGyoshaByYoshiHanbaiChumonBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetYoshiGyoshaByYoshiHanbaiChumonBLOutput output = new GetYoshiGyoshaByYoshiHanbaiChumonBLOutput();

            try
            {
                ISelectYoshiGyoshaByYoshiHanbaiChumonNoDAOutput daOutput = new SelectYoshiGyoshaByYoshiHanbaiChumonNoDataAccess().Execute(input);
                output.YoshiGyoshaDataTable = daOutput.YoshiGyoshaDataTable;
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
