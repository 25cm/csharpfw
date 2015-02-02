using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaHosokuTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLInput : ISelectShokenKekkaHosokuListByKensaIraiAndBitMaskDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenKekkaHosokuListByKensaIraiAndBitMaskBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokenKekkaHosokuListByKensaIraiAndBitMaskBLInput : IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }

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
    //  インターフェイス名 ： IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput : ISelectShokenKekkaHosokuListByKensaIraiAndBitMaskDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput : IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput
    {
        /// <summary>
        /// ShokenKekkaHosokuListDataTable
        /// </summary>
        public ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuListDataTable ShokenKekkaHosokuList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenKekkaHosokuListByKensaIraiAndBitMaskBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokenKekkaHosokuListByKensaIraiAndBitMaskBusinessLogic : BaseBusinessLogic<IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLInput, IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShokenKekkaHosokuListByKensaIraiAndBitMaskBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShokenKekkaHosokuListByKensaIraiAndBitMaskBusinessLogic()
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
        /// 2014/11/17　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput Execute(IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput output = new GetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput();

            try
            {
                ISelectShokenKekkaHosokuListByKensaIraiAndBitMaskDAOutput daOutput = new SelectShokenKekkaHosokuListByKensaIraiAndBitMaskDataAccess().Execute(input);
                output.ShokenKekkaHosokuList = daOutput.ShokenKekkaHosokuList;
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
