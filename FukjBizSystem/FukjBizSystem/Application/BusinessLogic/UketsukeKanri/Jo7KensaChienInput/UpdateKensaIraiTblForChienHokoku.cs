using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaIraiTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaChienInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaIraiTblForChienHokokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKensaIraiTblForChienHokokuBLInput : IUpdateKensaIraiTblForChienHokokuDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaIraiTblForChienHokokuBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaIraiTblForChienHokokuBLInput : IUpdateKensaIraiTblForChienHokokuBLInput
    {
        /// <summary>
        /// KensaIraiTblForChienHokokuUpdateDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblForChienHokokuUpdateDataTable ChienHokokuUpdateDataTable { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaIraiTblForChienHokokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKensaIraiTblForChienHokokuBLOutput : IUpdateKensaIraiTblForChienHokokuDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaIraiTblForChienHokokuBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaIraiTblForChienHokokuBLOutput : IUpdateKensaIraiTblForChienHokokuBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaIraiTblForChienHokokuBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30  豊田　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaIraiTblForChienHokokuBusinessLogic : BaseBusinessLogic<IUpdateKensaIraiTblForChienHokokuBLInput, IUpdateKensaIraiTblForChienHokokuBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKensaIraiTblForChienHokokuBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30  豊田　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKensaIraiTblForChienHokokuBusinessLogic()
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
        /// 2015/01/30  豊田　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKensaIraiTblForChienHokokuBLOutput Execute(IUpdateKensaIraiTblForChienHokokuBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKensaIraiTblForChienHokokuBLOutput output = new UpdateKensaIraiTblForChienHokokuBLOutput();

            try
            {
                new UpdateKensaIraiTblForChienHokokuDataAccess().Execute(input);
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
