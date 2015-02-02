using System.Reflection;
using FukjBizSystem.Application.DataAccess.GaikanKensaKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaKekkaInputShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGaikanKensaKekkaTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGaikanKensaKekkaTblByKeyBLInput : ISelectGaikanKensaKekkaTblByKeyDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGaikanKensaKekkaTblByKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGaikanKensaKekkaTblByKeyBLInput : IGetGaikanKensaKekkaTblByKeyBLInput
    {
        /// <summary>
        /// 検査依頼法定区分
        /// </summary>
        public string GaikanKensaKekkaIraiHoteiKbn { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string GaikanKensaKekkaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string GaikanKensaKekkakuIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string GaikanKensaKekkaIraiRenban { get; set; }

        /// <summary>
        /// 外観検査結果連番
        /// </summary>
        public string GaikanKensaKekkaRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetGaikanKensaKekkaTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetGaikanKensaKekkaTblByKeyBLOutput : ISelectGaikanKensaKekkaTblByKeyDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGaikanKensaKekkaTblByKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGaikanKensaKekkaTblByKeyBLOutput : IGetGaikanKensaKekkaTblByKeyBLOutput
    {
        /// <summary>
        /// 外観検査結果テーブル
        /// </summary>
        public GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetGaikanKensaKekkaTblByKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetGaikanKensaKekkaTblByKeyBusinessLogic : BaseBusinessLogic<IGetGaikanKensaKekkaTblByKeyBLInput, IGetGaikanKensaKekkaTblByKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetGaikanKensaKekkaTblByKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetGaikanKensaKekkaTblByKeyBusinessLogic()
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
        /// 2014/10/30　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetGaikanKensaKekkaTblByKeyBLOutput Execute(IGetGaikanKensaKekkaTblByKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetGaikanKensaKekkaTblByKeyBLOutput output = new GetGaikanKensaKekkaTblByKeyBLOutput();

            try
            {
                ISelectGaikanKensaKekkaTblByKeyDAOutput daOutput = new SelectGaikanKensaKekkaTblByKeyDataAccess().Execute(input);
                output.GaikanKensaKekkaTblDataTable = daOutput.GaikanKensaKekkaTblDataTable;
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
