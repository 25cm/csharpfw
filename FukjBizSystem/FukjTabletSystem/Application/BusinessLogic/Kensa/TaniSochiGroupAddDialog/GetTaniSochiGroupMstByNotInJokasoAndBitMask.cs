using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiGroupMst;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.TaniSochiGroupAddDialog
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLInput
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
    interface IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLInput : ISelectTaniSochiGroupMstByNotInJokasoAndBitMaskDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTaniSochiGroupMstByNotInJokasoAndBitMaskBLInput
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
    class GetTaniSochiGroupMstByNotInJokasoAndBitMaskBLInput : IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }

        /// <summary>
        /// JokasoHokenjoCd
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoTorokuNendo
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// JokasoRenban
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput
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
    interface IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput : ISelectTaniSochiGroupMstByNotInJokasoAndBitMaskDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput
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
    class GetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput : IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput
    {
        /// <summary>
        /// TaniSochiGroupMstDataTable
        /// </summary>
        public TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable TaniSochiGroupMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTaniSochiGroupMstByNotInJokasoAndBitMaskBusinessLogic
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
    class GetTaniSochiGroupMstByNotInJokasoAndBitMaskBusinessLogic : BaseBusinessLogic<IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLInput, IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetTaniSochiGroupMstByNotInJokasoAndBitMaskBusinessLogic
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
        public GetTaniSochiGroupMstByNotInJokasoAndBitMaskBusinessLogic()
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
        public override IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput Execute(IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput output = new GetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput();

            try
            {
                ISelectTaniSochiGroupMstByNotInJokasoAndBitMaskDAOutput daOutput = new SelectTaniSochiGroupMstByNotInJokasoAndBitMaskDataAccess().Execute(input);
                output.TaniSochiGroupMst = daOutput.TaniSochiGroupMst;
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
