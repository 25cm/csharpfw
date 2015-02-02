using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiSyukei
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput : ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput : IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput
    {
        /// <summary>
        /// 年度 
        /// </summary>
        public string SuishinhiNendo { get; set; }

        /// <summary>
        /// 上下期区分
        /// </summary>
        public string KamiShimoKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput : ISelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput : IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput
    {
        /// <summary>
        /// KensaKeihatsuSuishinHiShukeiTblDataTable
        /// </summary>
        public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable KensaKeihatsuSuishinHiShukeiTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic : BaseBusinessLogic<IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput, IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic()
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
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput Execute(IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput output = new GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput();

            try
            {
                output.KensaKeihatsuSuishinHiShukeiTblDT = new SelectKensaKeihatsuSuishinHiShukeiTblByNendoKbnDataAccess().Execute(input).KensaKeihatsuSuishinHiShukeiTblDT;
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
