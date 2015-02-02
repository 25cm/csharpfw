using System.Reflection;
using FukjBizSystem.Application.DataAccess.SuishitsuNippoHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.SuishitsuKensaNippo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuNippoHdrTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuNippoHdrTblByKeyBLInput : ISelectSuishitsuNippoHdrTblByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuNippoHdrTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuNippoHdrTblByKeyBLInput : IGetSuishitsuNippoHdrTblByKeyBLInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 受付日
        /// </summary>
        public string SuishitsuUketsukeDt { get; set; }

        /// <summary>
        /// 業者コード
        /// </summary>
        public string SuishitsuGyoshaCd { get; set; }

        /// <summary>
        /// 法定検査区分
        /// </summary>
        public string SuishitsuKensaKbn { get; set; }

        /// <summary>
        /// 検査種別コード
        /// </summary>
        public string SuishitsuKensaShubetsuCd { get; set; }

        /// <summary>
        /// 検査料金
        /// </summary>
        public decimal SuishitsuKensaAmt { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuNippoHdrTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuNippoHdrTblByKeyBLOutput : ISelectSuishitsuNippoHdrTblByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuNippoHdrTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuNippoHdrTblByKeyBLOutput : IGetSuishitsuNippoHdrTblByKeyBLOutput
    {
        /// <summary>
        /// SuishitsuNippoHdrTblDataTable
        /// </summary>
        public SuishitsuNippoHdrTblDataSet.SuishitsuNippoHdrTblDataTable SuishitsuNippoHdrTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuNippoHdrTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/04  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuNippoHdrTblByKeyBusinessLogic : BaseBusinessLogic<IGetSuishitsuNippoHdrTblByKeyBLInput, IGetSuishitsuNippoHdrTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuNippoHdrTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuNippoHdrTblByKeyBusinessLogic()
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
        /// 2014/12/04  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuNippoHdrTblByKeyBLOutput Execute(IGetSuishitsuNippoHdrTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuNippoHdrTblByKeyBLOutput output = new GetSuishitsuNippoHdrTblByKeyBLOutput();

            try
            {
                output.SuishitsuNippoHdrTblDT = new SelectSuishitsuNippoHdrTblByKeyDataAccess().Execute(input).SuishitsuNippoHdrTblDT;
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
