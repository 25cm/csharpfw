using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiKanrenFileTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaIraiFileListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiFileListBLInput : ISelectKensaIraiFileListByKensaIraiKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiFileListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiFileListBLInput : IGetKensaIraiFileListBLInput
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
    //  インターフェイス名 ： IGetKensaIraiFileListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaIraiFileListBLOutput : ISelectKensaIraiFileListByKensaIraiKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiFileListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiFileListBLOutput : IGetKensaIraiFileListBLOutput
    {
        /// <summary>
        /// KensaIraiFileListDataTable
        /// </summary>
        public KensaIraiKanrenFileTblDataSet.KensaIraiFileListDataTable KensaIraiFileList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaIraiFileListBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaIraiFileListBusinessLogic : BaseBusinessLogic<IGetKensaIraiFileListBLInput, IGetKensaIraiFileListBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaIraiFileListBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaIraiFileListBusinessLogic()
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
        /// 2014/10/30　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaIraiFileListBLOutput Execute(IGetKensaIraiFileListBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaIraiFileListBLOutput output = new GetKensaIraiFileListBLOutput();

            try
            {
                ISelectKensaIraiFileListByKensaIraiKeyDAOutput daOutput = new SelectKensaIraiFileListByKensaIraiKeyDataAccess().Execute(input);
                output.KensaIraiFileList = daOutput.KensaIraiFileList;
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
