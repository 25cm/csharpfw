using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShoriHoshikiSuishitsuKensaJisshiMst;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.SuishitsuKensaTabPage
{

    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLInput : ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLInput : IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        public string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        public string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        public string IraiRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput : ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput : IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput
    {
        /// <summary>
        /// ShoriHoshikiSuishitsuKensaJisshiMstDataTable
        /// </summary>
        public ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable ShoriHoshikiSuishitsuKensaJisshiMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/20　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBusinessLogic  : BaseBusinessLogic<IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLInput, IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/20　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBusinessLogic()
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
        /// 2014/11/20　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput Execute(IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput output = new GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput();

            try
            {
                ISelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDAOutput daOutput = new SelectShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyDataAccess().Execute(input);
                output.ShoriHoshikiSuishitsuKensaJisshiMst = daOutput.ShoriHoshikiSuishitsuKensaJisshiMst;
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
