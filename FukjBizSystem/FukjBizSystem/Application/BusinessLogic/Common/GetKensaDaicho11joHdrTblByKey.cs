using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaicho11joHdrTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaicho11joHdrTblByKeyBLInput : ISelectKensaDaicho11joHdrTblByKeyDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaicho11joHdrTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaicho11joHdrTblByKeyBLInput : IGetKensaDaicho11joHdrTblByKeyBLInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        public string SuishitsuKensaIraiNo { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaicho11joHdrTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaicho11joHdrTblByKeyBLOutput : ISelectKensaDaicho11joHdrTblByKeyDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaicho11joHdrTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaicho11joHdrTblByKeyBLOutput : IGetKensaDaicho11joHdrTblByKeyBLOutput
    {
        /// <summary>
        /// 検査台帳（11条）ヘッダ情報
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.KensaDaicho11joHdrTblDataTable KensaDaicho11joHdrDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaicho11joHdrTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaicho11joHdrTblByKeyBusinessLogic : BaseBusinessLogic<IGetKensaDaicho11joHdrTblByKeyBLInput, IGetKensaDaicho11joHdrTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaDaicho11joHdrTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaDaicho11joHdrTblByKeyBusinessLogic()
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
        /// 2014/12/02　小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaDaicho11joHdrTblByKeyBLOutput Execute(IGetKensaDaicho11joHdrTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaDaicho11joHdrTblByKeyBLOutput output = new GetKensaDaicho11joHdrTblByKeyBLOutput();

            try
            {
                // 主キー（検査区分、依頼年度、支所CD、水質検査依頼番号）で検査依頼台帳（11条）ヘッダ情報を取得（一意レコード）
                output.KensaDaicho11joHdrDT = new SelectKensaDaicho11joHdrTblByKeyDataAccess().Execute(input).KensaDaicho11joHdrDT;
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
