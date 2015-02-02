using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.JokasoDaichoMst;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.MemoTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetJokasoDaichoMstMemoByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
	interface IGetJokasoDaichoMstMemoByKensaIraiKeyBLInput : ISelectJokasoDaichoMstMemoByKensaIraiKeyDAInput
		                                                  
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoMstMemoByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoMstMemoByKensaIraiKeyBLInput : IGetJokasoDaichoMstMemoByKensaIraiKeyBLInput
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
    //  インターフェイス名 ： IGetJokasoDaichoMstMemoByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetJokasoDaichoMstMemoByKensaIraiKeyBLOutput : ISelectJokasoDaichoMstMemoByKensaIraiKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoMstMemoByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoMstMemoByKensaIraiKeyBLOutput : IGetJokasoDaichoMstMemoByKensaIraiKeyBLOutput
    {
        /// <summary>
        /// JokasoDaichoMstDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstMemoDataTable JokasoDaichoMstMemo { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetJokasoDaichoMstMemoByKensaIraiKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetJokasoDaichoMstMemoByKensaIraiKeyBusinessLogic : BaseBusinessLogic<IGetJokasoDaichoMstMemoByKensaIraiKeyBLInput, IGetJokasoDaichoMstMemoByKensaIraiKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetJokasoDaichoMstMemoByKensaIraiKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/21　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetJokasoDaichoMstMemoByKensaIraiKeyBusinessLogic()
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
        /// 2014/11/21　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetJokasoDaichoMstMemoByKensaIraiKeyBLOutput Execute(IGetJokasoDaichoMstMemoByKensaIraiKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetJokasoDaichoMstMemoByKensaIraiKeyBLOutput output = new GetJokasoDaichoMstMemoByKensaIraiKeyBLOutput();

            try
            {
                ISelectJokasoDaichoMstMemoByKensaIraiKeyDAOutput daOutput = new SelectJokasoDaichoMstMemoByKensaIraiKeyDataAccess().Execute(input);
                output.JokasoDaichoMstMemo = daOutput.JokasoDaichoMstMemo;
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
