using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.KihonJouhouTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKihonJouhouIraiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKihonJouhouIraiBLInput : ISelectKihonJouhouIraiByKensaIraiKeyDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKihonJouhouIraiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKihonJouhouIraiBLInput : IGetKihonJouhouIraiBLInput
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
    //  インターフェイス名 ： IGetKihonJouhouIraiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKihonJouhouIraiBLOutput : ISelectKihonJouhouIraiByKensaIraiKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKihonJouhouIraiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKihonJouhouIraiBLOutput : IGetKihonJouhouIraiBLOutput
    {
        /// <summary>
        /// KihonJouhouIraiDataTable
        /// </summary>
        public KensaIraiTblDataSet.KihonJouhouIraiDataTable KihonJouhouIrai { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKihonJouhouIraiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKihonJouhouIraiBusinessLogic : BaseBusinessLogic<IGetKihonJouhouIraiBLInput, IGetKihonJouhouIraiBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKihonJouhouIraiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKihonJouhouIraiBusinessLogic()
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
        /// 2014/12/02　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKihonJouhouIraiBLOutput Execute(IGetKihonJouhouIraiBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKihonJouhouIraiBLOutput output = new GetKihonJouhouIraiBLOutput();

            try
            {
                ISelectKihonJouhouIraiByKensaIraiKeyDAOutput daOutput = new SelectKihonJouhouIraiByKensaIraiKeyDataAccess().Execute(input);
                output.KihonJouhouIrai = daOutput.KihonJouhouIrai;
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
