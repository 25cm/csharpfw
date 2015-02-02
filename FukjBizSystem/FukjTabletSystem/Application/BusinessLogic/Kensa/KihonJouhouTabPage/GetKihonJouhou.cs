using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.KihonJouhouTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKihonJouhouBLInput
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
    interface IGetKihonJouhouBLInput : ISelectKihonJouhouByKensaIraiKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKihonJouhouBLInput
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
    class GetKihonJouhouBLInput : IGetKihonJouhouBLInput
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
    //  インターフェイス名 ： IGetKihonJouhouBLOutput
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
    interface IGetKihonJouhouBLOutput : ISelectKihonJouhouByKensaIraiKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKihonJouhouBLOutput
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
    class GetKihonJouhouBLOutput : IGetKihonJouhouBLOutput
    {
        /// <summary>
        /// KihonJouhouDataTable
        /// </summary>
        public KensaIraiTblDataSet.KihonJouhouDataTable KihonJouhou { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKihonJouhouBusinessLogic
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
    class GetKihonJouhouBusinessLogic : BaseBusinessLogic<IGetKihonJouhouBLInput, IGetKihonJouhouBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKihonJouhouBusinessLogic
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
        public GetKihonJouhouBusinessLogic()
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
        public override IGetKihonJouhouBLOutput Execute(IGetKihonJouhouBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKihonJouhouBLOutput output = new GetKihonJouhouBLOutput();

            try
            {
                ISelectKihonJouhouByKensaIraiKeyDAOutput daOutput = new SelectKihonJouhouByKensaIraiKeyDataAccess().Execute(input);
                output.KihonJouhou = daOutput.KihonJouhou;
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
