using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaDaicho9joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaicho9joHdrTblByKeyBLInput
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
    interface IGetKensaDaicho9joHdrTblByKeyBLInput : ISelectKensaDaicho9joHdrTblByKeyDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaicho9joHdrTblByKeyBLInput
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
    class GetKensaDaicho9joHdrTblByKeyBLInput : IGetKensaDaicho9joHdrTblByKeyBLInput
    {
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
    //  インターフェイス名 ： IGetKensaDaicho9joHdrTblByKeyBLOutput
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
    interface IGetKensaDaicho9joHdrTblByKeyBLOutput : ISelectKensaDaicho9joHdrTblByKeyDAOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaicho9joHdrTblByKeyBLOutput
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
    class GetKensaDaicho9joHdrTblByKeyBLOutput : IGetKensaDaicho9joHdrTblByKeyBLOutput
    {
        /// <summary>
        /// 検査台帳（9条）ヘッダ情報
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KensaDaicho9joHdrTblDataTable KensaDaicho9joHdrDT { get; set; }
    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaicho9joHdrTblByKeyBusinessLogic
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
    class GetKensaDaicho9joHdrTblByKeyBusinessLogic : BaseBusinessLogic<IGetKensaDaicho9joHdrTblByKeyBLInput, IGetKensaDaicho9joHdrTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaDaicho9joHdrTblByKeyBusinessLogic
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
        public GetKensaDaicho9joHdrTblByKeyBusinessLogic()
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
        public override IGetKensaDaicho9joHdrTblByKeyBLOutput Execute(IGetKensaDaicho9joHdrTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaDaicho9joHdrTblByKeyBLOutput output = new GetKensaDaicho9joHdrTblByKeyBLOutput();

            try
            {
                // 主キー（依頼年度、支所CD、水質検査依頼番号）で検査依頼台帳（9条）ヘッダ情報を取得（一意レコード）
                output.KensaDaicho9joHdrDT = new SelectKensaDaicho9joHdrTblByKeyDataAccess().Execute(input).KensaDaicho9joHdrDT;
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
