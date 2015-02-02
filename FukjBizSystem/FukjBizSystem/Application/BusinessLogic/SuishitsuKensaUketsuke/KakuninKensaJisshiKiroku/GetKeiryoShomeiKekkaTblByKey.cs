using System.Reflection;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKeiryoShomeiKekkaTblByKeyBLInput
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
    interface IGetKeiryoShomeiKekkaTblByKeyBLInput : ISelectKeiryoShomeiKekkaTblByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiKekkaTblByKeyBLInput
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
    class GetKeiryoShomeiKekkaTblByKeyBLInput : IGetKeiryoShomeiKekkaTblByKeyBLInput
    {
        /// <summary>
        /// 計量証明結果依頼年度
        /// </summary>
        public string KeiryoShomeiKekkaIraiNendo { get; set; }

        /// <summary>
        /// 計量証明結果依頼支所コード
        /// </summary>
        public string KeiryoShomeiKekkaIraiShishoCd { get; set; }

        /// <summary>
        /// 計量証明結果依頼番号
        /// </summary>
        public string KeiryoShomeiKekkaIraiNo { get; set; }

        /// <summary>
        /// 計量証明試験項目コード
        /// </summary>
        public string KeiryoShomeiShikenkoumokuCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKeiryoShomeiKekkaTblByKeyBLOutput
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
    interface IGetKeiryoShomeiKekkaTblByKeyBLOutput : ISelectKeiryoShomeiKekkaTblByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiKekkaTblByKeyBLOutput
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
    class GetKeiryoShomeiKekkaTblByKeyBLOutput : IGetKeiryoShomeiKekkaTblByKeyBLOutput
    {
        /// <summary>
        /// KeiryoShomeiKekkaTblDataTable
        /// </summary>
        public KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable KeiryoShomeiKekkaTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKeiryoShomeiKekkaTblByKeyBusinessLogic
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
    class GetKeiryoShomeiKekkaTblByKeyBusinessLogic : BaseBusinessLogic<IGetKeiryoShomeiKekkaTblByKeyBLInput, IGetKeiryoShomeiKekkaTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKeiryoShomeiKekkaTblByKeyBusinessLogic
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
        public GetKeiryoShomeiKekkaTblByKeyBusinessLogic()
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
        public override IGetKeiryoShomeiKekkaTblByKeyBLOutput Execute(IGetKeiryoShomeiKekkaTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKeiryoShomeiKekkaTblByKeyBLOutput output = new GetKeiryoShomeiKekkaTblByKeyBLOutput();

            try
            {
                output.KeiryoShomeiKekkaTblDT = new SelectKeiryoShomeiKekkaTblByKeyDataAccess().Execute(input).KeiryoShomeiKekkaTblDT;
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
