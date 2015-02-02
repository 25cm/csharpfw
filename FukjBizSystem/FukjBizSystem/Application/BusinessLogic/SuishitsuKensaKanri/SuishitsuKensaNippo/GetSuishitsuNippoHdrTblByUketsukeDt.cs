using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuNippoHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.SuishitsuKensaNippo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuNippoHdrTblByUketsukeDtBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuNippoHdrTblByUketsukeDtBLInput : ISelectSuishitsuNippoHdrTblByUketsukeDtDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuNippoHdrTblByUketsukeDtBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuNippoHdrTblByUketsukeDtBLInput : IGetSuishitsuNippoHdrTblByUketsukeDtBLInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        public string UketsukeDt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuNippoHdrTblByUketsukeDtBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuNippoHdrTblByUketsukeDtBLOutput : ISelectSuishitsuNippoHdrTblByUketsukeDtDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuNippoHdrTblByUketsukeDtBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuNippoHdrTblByUketsukeDtBLOutput : IGetSuishitsuNippoHdrTblByUketsukeDtBLOutput
    {
        /// <summary>
        /// SuishitsuNippoHdrTblDataTable
        /// </summary>
        public SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblDataTable SuishitsuNippoHdrTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuNippoHdrTblByUketsukeDtBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuNippoHdrTblByUketsukeDtBusinessLogic : BaseBusinessLogic<IGetSuishitsuNippoHdrTblByUketsukeDtBLInput, IGetSuishitsuNippoHdrTblByUketsukeDtBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuNippoHdrTblByUketsukeDtBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuNippoHdrTblByUketsukeDtBusinessLogic()
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
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuNippoHdrTblByUketsukeDtBLOutput Execute(IGetSuishitsuNippoHdrTblByUketsukeDtBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuNippoHdrTblByUketsukeDtBLOutput output = new GetSuishitsuNippoHdrTblByUketsukeDtBLOutput();

            try
            {
                output.SuishitsuNippoHdrTblDT = new SelectSuishitsuNippoHdrTblByUketsukeDtDataAccess().Execute(input).SuishitsuNippoHdrTblDT;
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
