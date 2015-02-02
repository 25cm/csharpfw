using System.Reflection;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaHosokuTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateShokenHyojiichiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateShokenHyojiichiBLInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        string IraiRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateShokenHyojiichiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateShokenHyojiichiBLInput : IUpdateShokenHyojiichiBLInput
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
    //  インターフェイス名 ： IUpdateShokenHyojiichiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateShokenHyojiichiBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateShokenHyojiichiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateShokenHyojiichiBLOutput : IUpdateShokenHyojiichiBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateShokenHyojiichiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/25　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateShokenHyojiichiBusinessLogic : BaseBusinessLogic<IUpdateShokenHyojiichiBLInput, IUpdateShokenHyojiichiBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateShokenHyojiichiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/25　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateShokenHyojiichiBusinessLogic()
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
        /// 2014/12/25　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateShokenHyojiichiBLOutput Execute(IUpdateShokenHyojiichiBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateShokenHyojiichiBLOutput output = new UpdateShokenHyojiichiBLOutput();

            try
            {
                ShokenKekkaTblDataSet.ShokenKekkaTblDataTable shokenKekkaTbl = new ShokenKekkaTblDataSet.ShokenKekkaTblDataTable();
                ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable shokenKekkaHosokuTbl = new ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable();

                // 表示位置初期値
                int shokenHyojiichi = 1;

                ShokenUtility.SelectType[] ShokenTypes = new ShokenUtility.SelectType[] { ShokenUtility.SelectType.GaikanKensa, ShokenUtility.SelectType.SuishitsuKensa, ShokenUtility.SelectType.ShoruiKensa };

                foreach (ShokenUtility.SelectType type in ShokenTypes)
                {
                    // 所見結果を取得
                    ISelectShokenKekkaTblByKensaIraiAndBitMaskDAInput shokenInput = new SelectShokenKekkaTblByKensaIraiAndBitMaskDAInput();

                    shokenInput.IraiHoteiKbn = input.IraiHoteiKbn;
                    shokenInput.IraiHokenjoCd = input.IraiHokenjoCd;
                    shokenInput.IraiNendo = input.IraiNendo;
                    shokenInput.IraiRenban = input.IraiRenban;
                    shokenInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Shoken, type);

                    ISelectShokenKekkaTblByKensaIraiAndBitMaskDAOutput shokenOutput = new SelectShokenKekkaTblByKensaIraiAndBitMaskDataAccess().Execute(shokenInput);

                    foreach (ShokenKekkaTblDataSet.ShokenKekkaTblRow shoken in shokenOutput.ShokenKekkaTbl)
                    {
                        shoken.ShokenHyojiichi = shokenHyojiichi;

                        try
                        {
                            shokenKekkaTbl.ImportRow(shoken);
                        }
                        catch
                        {
                            continue;
                        }

                        shokenHyojiichi++;

                        // 所見結果補足を取得
                        ISelectShokenKekkaHosokuTblByShokenKekkaKeyDAInput hosokuInput = new SelectShokenKekkaHosokuTblByShokenKekkaKeyDAInput();

                        hosokuInput.IraiHoteiKbn = shoken.KensaIraiShokanIraiHoteiKbn;
                        hosokuInput.IraiHokenjoCd = shoken.KensaIraiShokenIraiHokenjoCd;
                        hosokuInput.IraiNendo = shoken.KensaIraiShokenIraiNendo;
                        hosokuInput.IraiRenban = shoken.KensaIraiShokenIraiRenban;
                        hosokuInput.ShokenRenban = shoken.KensaIraiShokenRenban;

                        ISelectShokenKekkaHosokuTblByShokenKekkaKeyDAOutput hosokuOutput = new SelectShokenKekkaHosokuTblByShokenKekkaKeyDataAccess().Execute(hosokuInput);

                        foreach (ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblRow hosoku in hosokuOutput.ShokenKekkaHosokuTbl)
                        {
                            hosoku.ShokenHyojiichi = shokenHyojiichi;

                            try
                            {
                                shokenKekkaHosokuTbl.ImportRow(hosoku);
                            }
                            catch
                            {
                                continue;
                            }

                            shokenHyojiichi++;
                        }
                    }
                }

                // 更新処理
                if (shokenKekkaTbl.Count > 0)
                {
                    IUpdateShokenKekkaTblBLInput updShokenInput = new UpdateShokenKekkaTblBLInput();

                    updShokenInput.ShokenKekkaTbl = shokenKekkaTbl;

                    new UpdateShokenKekkaTblBusinessLogic().Execute(updShokenInput);
                }

                if (shokenKekkaHosokuTbl.Count > 0)
                {
                    IUpdateShokenKekkaHosokuTblBLInput updShokenHosokuInput = new UpdateShokenKekkaHosokuTblBLInput();

                    updShokenHosokuInput.ShokenKekkaHosokuTbl = shokenKekkaHosokuTbl;

                    new UpdateShokenKekkaHosokuTblBusinessLogic().Execute(updShokenHosokuInput);
                }
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
