using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.YachoTorikomi
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaichoMeisai11joBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaichoMeisai11joBLInput : ISelectKensaDaichoMeisaiDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoMeisai11joBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoMeisai11joBLInput : IGetKensaDaichoMeisai11joBLInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string Kbn { get; set; }

        /// <summary>
        /// 依頼年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        public string IraiNo { get; set; }

        /// <summary>
        /// 試験項目コード
        /// </summary>
        public string KomokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaichoMeisai11joBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaichoMeisai11joBLOutput : ISelectKensaDaichoMeisaiDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoMeisai11joBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoMeisai11joBLOutput : IGetKensaDaichoMeisai11joBLOutput
    {
        /// <summary>
        /// KensaDaichoMeisaiDataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.KensaDaichoMeisaiDataTable KensaDaichoMeisaiDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoMeisai11joBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/08　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoMeisai11joBusinessLogic : BaseBusinessLogic<IGetKensaDaichoMeisai11joBLInput, IGetKensaDaichoMeisai11joBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaDaichoMeisai11joBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaDaichoMeisai11joBusinessLogic()
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
        /// 2014/12/08　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaDaichoMeisai11joBLOutput Execute(IGetKensaDaichoMeisai11joBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaDaichoMeisai11joBLOutput output = new GetKensaDaichoMeisai11joBLOutput();

            try
            {
                output.KensaDaichoMeisaiDT = new SelectKensaDaichoMeisaiDataAccess().Execute(input).KensaDaichoMeisaiDT;
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
