using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.SuishitsuKensaTabPage
{

    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetLastKensaKekkaTblByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetLastKensaKekkaTblByKensaIraiKeyBLInput : ISelectLastKensaKekkaTblByKensaIraiKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetLastKensaKekkaTblByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetLastKensaKekkaTblByKensaIraiKeyBLInput : IGetLastKensaKekkaTblByKensaIraiKeyBLInput
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
    //  インターフェイス名 ： IGetLastKensaKekkaTblByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetLastKensaKekkaTblByKensaIraiKeyBLOutput : ISelectLastKensaKekkaTblByKensaIraiKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetLastKensaKekkaTblByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetLastKensaKekkaTblByKensaIraiKeyBLOutput : IGetLastKensaKekkaTblByKensaIraiKeyBLOutput
    {
        /// <summary>
        /// KensaKekkaTblDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable LastKensaKekkaTbl { get; set; }

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetLastKensaKekkaTblByKensaIraiKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetLastKensaKekkaTblByKensaIraiKeyBusinessLogic : BaseBusinessLogic<IGetLastKensaKekkaTblByKensaIraiKeyBLInput, IGetLastKensaKekkaTblByKensaIraiKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetLastKensaKekkaTblByKensaIraiKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetLastKensaKekkaTblByKensaIraiKeyBusinessLogic()
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
        /// 2014/11/14　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetLastKensaKekkaTblByKensaIraiKeyBLOutput Execute(IGetLastKensaKekkaTblByKensaIraiKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetLastKensaKekkaTblByKensaIraiKeyBLOutput output = new GetLastKensaKekkaTblByKensaIraiKeyBLOutput();

            try
            {
                ISelectLastKensaKekkaTblByKensaIraiKeyDAOutput daOutput = new SelectLastKensaKekkaTblByKensaIraiKeyDataAccess().Execute(input);
                output.LastKensaKekkaTbl = daOutput.LastKensaKekkaTbl;
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
