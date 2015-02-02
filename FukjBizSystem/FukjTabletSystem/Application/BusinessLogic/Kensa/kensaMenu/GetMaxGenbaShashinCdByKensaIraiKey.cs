using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using FukjTabletSystem.Application.DataAccess.SQLCE.GenbaShashinTbl;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.KensaMenu
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMaxGenbaShashinCdByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMaxGenbaShashinCdByKensaIraiKeyBLInput : ISelectMaxGenbaShashinCdByKensaIraiKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaxGenbaShashinCdByKensaIraiKeyBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMaxGenbaShashinCdByKensaIraiKeyBLInput : IGetMaxGenbaShashinCdByKensaIraiKeyBLInput
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
    //  インターフェイス名 ： IGetMaxGenbaShashinCdByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMaxGenbaShashinCdByKensaIraiKeyBLOutput : ISelectMaxGenbaShashinCdByKensaIraiKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaxGenbaShashinCdByKensaIraiKeyBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMaxGenbaShashinCdByKensaIraiKeyBLOutput : IGetMaxGenbaShashinCdByKensaIraiKeyBLOutput
    {
        /// <summary>
        /// MaxGenbaShashinCd
        /// </summary>
        public string MaxGenbaShashinCd { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaxGenbaShashinCdByKensaIraiKeyBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/28　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMaxGenbaShashinCdByKensaIraiKeyBusinessLogic : BaseBusinessLogic<IGetMaxGenbaShashinCdByKensaIraiKeyBLInput, IGetMaxGenbaShashinCdByKensaIraiKeyBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMaxGenbaShashinCdByKensaIraiKeyBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/28　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetMaxGenbaShashinCdByKensaIraiKeyBusinessLogic()
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
        /// 2014/11/28　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetMaxGenbaShashinCdByKensaIraiKeyBLOutput Execute(IGetMaxGenbaShashinCdByKensaIraiKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMaxGenbaShashinCdByKensaIraiKeyBLOutput output = new GetMaxGenbaShashinCdByKensaIraiKeyBLOutput();

            try
            {
                ISelectMaxGenbaShashinCdByKensaIraiKeyDAOutput daOutput = new SelectMaxGenbaShashinCdByKensaIraiKeyDataAccess().Execute(input);
                output.MaxGenbaShashinCd = daOutput.MaxGenbaShashinCd;
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
