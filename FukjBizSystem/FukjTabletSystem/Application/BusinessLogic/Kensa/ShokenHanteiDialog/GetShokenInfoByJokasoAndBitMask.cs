using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.KatashikiBetsuTaniSochiMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiGroupMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiKensaJokyoMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiKensaJokyoTeidoMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.TaniSochiKensaKomokuMst;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.ShokenHanteiDialog
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokenInfoByJokasoAndBitMaskBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokenInfoByJokasoAndBitMaskBLInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        int ShokenTaishoKensaBitMask { get; set; }

        /// <summary>
        /// JokasoHokenjoCd
        /// </summary>
        string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoTorokuNendo
        /// </summary>
        string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// JokasoRenban
        /// </summary>
        string JokasoRenban { get; set; }

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
    //  クラス名 ： GetShokenInfoByJokasoAndBitMaskBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokenInfoByJokasoAndBitMaskBLInput : IGetShokenInfoByJokasoAndBitMaskBLInput
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
    //  インターフェイス名 ： IGetShokenInfoByJokasoAndBitMaskBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokenInfoByJokasoAndBitMaskBLOutput : ISelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput,
                                                         ISelectTaniSochiKensaJokyoMstByJokasoAndBitMaskDAOutput,
                                                         ISelectTaniSochiKensaJokyoTeidoMstByJokasoAndBitMaskDAOutput,
                                                         ISelectTaniSochiKensaKomokuMstByJokasoAndBitMaskDAOutput,
                                                         ISelectShokenMstByJokasoAndBitMaskDAOutput,
                                                         ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenInfoByJokasoAndBitMaskBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokenInfoByJokasoAndBitMaskBLOutput : IGetShokenInfoByJokasoAndBitMaskBLOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiMstDataTable
        /// </summary>
        public KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable KatashikiBetsuTaniSochiMst { get; set; }

        /// <summary>
        /// TaniSochiGroupMstDataTable
        /// </summary>
        public TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable TaniSochiGroupMst { get; set; }

        /// <summary>
        /// TaniSochiKensaJokyoMstDataTable
        /// </summary>
        public TaniSochiKensaJokyoMstDataSet.TaniSochiKensaJokyoMstDataTable TaniSochiKensaJokyoMst { get; set; }

        /// <summary>
        /// TaniSochiKensaJokyoTeidoMstDataTable
        /// </summary>
        public TaniSochiKensaJokyoTeidoMstDataSet.TaniSochiKensaJokyoTeidoMstDataTable TaniSochiKensaJokyoTeidoMst { get; set; }

        /// <summary>
        /// TaniSochiKensaKomokuMstDataTable
        /// </summary>
        public TaniSochiKensaKomokuMstDataSet.TaniSochiKensaKomokuMstDataTable TaniSochiKensaKomokuMst { get; set; }

        /// <summary>
        /// ShokenMstDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenMstDataTable ShokenMst { get; set; }

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenInfoByJokasoAndBitMaskBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokenInfoByJokasoAndBitMaskBusinessLogic : BaseBusinessLogic<IGetShokenInfoByJokasoAndBitMaskBLInput, IGetShokenInfoByJokasoAndBitMaskBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShokenInfoByJokasoAndBitMaskBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/15　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShokenInfoByJokasoAndBitMaskBusinessLogic()
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
        /// 2014/11/15　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShokenInfoByJokasoAndBitMaskBLOutput Execute(IGetShokenInfoByJokasoAndBitMaskBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShokenInfoByJokasoAndBitMaskBLOutput output = new GetShokenInfoByJokasoAndBitMaskBLOutput();

            try
            {
                // 単位装置グループマスタ
                ISelectTaniSochiGroupMstByJokasoAndBitMaskDAInput grpInput = new SelectTaniSochiGroupMstByJokasoAndBitMaskDAInput();
                grpInput.JokasoHokenjoCd = input.JokasoHokenjoCd;
                grpInput.JokasoTorokuNendo = input.JokasoTorokuNendo;
                grpInput.JokasoRenban = input.JokasoRenban;
                grpInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectTaniSochiGroupMstByJokasoAndBitMaskDAOutput grpOutput = new SelectTaniSochiGroupMstByJokasoAndBitMaskDataAccess().Execute(grpInput);

                output.TaniSochiGroupMst = grpOutput.TaniSochiGroupMst;
                                
                // 単位装置検査項目マスタ
                ISelectTaniSochiKensaKomokuMstByJokasoAndBitMaskDAInput kmkInput = new SelectTaniSochiKensaKomokuMstByJokasoAndBitMaskDAInput();
                kmkInput.JokasoHokenjoCd = input.JokasoHokenjoCd;
                kmkInput.JokasoTorokuNendo = input.JokasoTorokuNendo;
                kmkInput.JokasoRenban = input.JokasoRenban;
                kmkInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectTaniSochiKensaKomokuMstByJokasoAndBitMaskDAOutput kmkOutput = new SelectTaniSochiKensaKomokuMstByJokasoAndBitMaskDataAccess().Execute(kmkInput);

                output.TaniSochiKensaKomokuMst = kmkOutput.TaniSochiKensaKomokuMst;

                // 単位装置検査状況マスタ
                ISelectTaniSochiKensaJokyoMstByJokasoAndBitMaskDAInput jokInput = new SelectTaniSochiKensaJokyoMstByJokasoAndBitMaskDAInput();
                jokInput.JokasoHokenjoCd = input.JokasoHokenjoCd;
                jokInput.JokasoTorokuNendo = input.JokasoTorokuNendo;
                jokInput.JokasoRenban = input.JokasoRenban;
                jokInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectTaniSochiKensaJokyoMstByJokasoAndBitMaskDAOutput jokOutput = new SelectTaniSochiKensaJokyoMstByJokasoAndBitMaskDataAccess().Execute(jokInput);

                output.TaniSochiKensaJokyoMst = jokOutput.TaniSochiKensaJokyoMst;

                // 単位装置検査状況程度マスタ
                ISelectTaniSochiKensaJokyoTeidoMstByJokasoAndBitMaskDAInput teiInput = new SelectTaniSochiKensaJokyoTeidoMstByJokasoAndBitMaskDAInput();
                teiInput.JokasoHokenjoCd = input.JokasoHokenjoCd;
                teiInput.JokasoTorokuNendo = input.JokasoTorokuNendo;
                teiInput.JokasoRenban = input.JokasoRenban;
                teiInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectTaniSochiKensaJokyoTeidoMstByJokasoAndBitMaskDAOutput teiOutput = new SelectTaniSochiKensaJokyoTeidoMstByJokasoAndBitMaskDataAccess().Execute(teiInput);

                output.TaniSochiKensaJokyoTeidoMst = teiOutput.TaniSochiKensaJokyoTeidoMst;

                // 単位装置グループマスタ(型式別)
                ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAInput kataGrpInput = new SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAInput();
                kataGrpInput.IraiHoteiKbn = input.IraiHoteiKbn;
                kataGrpInput.IraiHokenjoCd = input.IraiHokenjoCd;
                kataGrpInput.IraiNendo = input.IraiNendo;
                kataGrpInput.IraiRenban = input.IraiRenban;
                kataGrpInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDAOutput kataGrpOutput = new SelectKatashikiBetsuTaniSochiMstByShokenBitMaskAndKensaIraiKeyDataAccess().Execute(kataGrpInput);

                output.KatashikiBetsuTaniSochiMst = kataGrpOutput.KatashikiBetsuTaniSochiMst;

                // 単位装置検査項目マスタ(型式別)
                ISelectTaniSochiKensaKomokuByShokenBitMaskAndKensaIraiKeyDAInput kataKmkInput = new SelectTaniSochiKensaKomokuByShokenBitMaskAndKensaIraiKeyDAInput();
                kataKmkInput.IraiHoteiKbn = input.IraiHoteiKbn;
                kataKmkInput.IraiHokenjoCd = input.IraiHokenjoCd;
                kataKmkInput.IraiNendo = input.IraiNendo;
                kataKmkInput.IraiRenban = input.IraiRenban;
                kataKmkInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectTaniSochiKensaKomokuByShokenBitMaskAndKensaIraiKeyDAOutput kataKmkOutput = new SelectTaniSochiKensaKomokuByShokenBitMaskAndKensaIraiKeyDataAccess().Execute(kataKmkInput);

                output.TaniSochiKensaKomokuMst.Merge(kataKmkOutput.TaniSochiKensaKomokuMst);

                // 単位装置検査状況マスタ(型式別)
                ISelectTaniSochiKensaJokyoMstByShokenBitMaskAndKensaIraiKeyAInput kataJokInput = new SelectTaniSochiKensaJokyoMstByShokenBitMaskAndKensaIraiKeyAInput();
                kataJokInput.IraiHoteiKbn = input.IraiHoteiKbn;
                kataJokInput.IraiHokenjoCd = input.IraiHokenjoCd;
                kataJokInput.IraiNendo = input.IraiNendo;
                kataJokInput.IraiRenban = input.IraiRenban;
                kataJokInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectTaniSochiKensaJokyoMstByShokenBitMaskAndKensaIraiKeyAOutput kataJokOutput = new SelectTaniSochiKensaJokyoMstByShokenBitMaskAndKensaIraiKeyataAccess().Execute(kataJokInput);

                output.TaniSochiKensaJokyoMst.Merge(kataJokOutput.TaniSochiKensaJokyoMst);

                // 単位装置検査状況程度マスタ(型式別)
                ISelectTaniSochiKensaJokyoTeidoMstByShokenBitMaskAndKensaIraiKeyDAInput kataTeiInput = new SelectTaniSochiKensaJokyoTeidoMstByShokenBitMaskAndKensaIraiKeyDAInput();
                kataTeiInput.IraiHoteiKbn = input.IraiHoteiKbn;
                kataTeiInput.IraiHokenjoCd = input.IraiHokenjoCd;
                kataTeiInput.IraiNendo = input.IraiNendo;
                kataTeiInput.IraiRenban = input.IraiRenban;
                kataTeiInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectTaniSochiKensaJokyoTeidoMstByShokenBitMaskAndKensaIraiKeyDAOutput kataTeiOutput = new SelectTaniSochiKensaJokyoTeidoMstByShokenBitMaskAndKensaIraiKeyDataAccess().Execute(kataTeiInput);

                output.TaniSochiKensaJokyoTeidoMst.Merge(kataTeiOutput.TaniSochiKensaJokyoTeidoMst);

                // 所見マスタ
                ISelectShokenMstByJokasoAndBitMaskDAInput shoInput = new SelectShokenMstByJokasoAndBitMaskDAInput();
                shoInput.JokasoHokenjoCd = input.JokasoHokenjoCd;
                shoInput.JokasoTorokuNendo = input.JokasoTorokuNendo;
                shoInput.JokasoRenban = input.JokasoRenban;
                shoInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectShokenMstByJokasoAndBitMaskDAOutput shoOutput = new SelectShokenMstByJokasoAndBitMaskDataAccess().Execute(shoInput);

                output.ShokenMst = shoOutput.ShokenMst;

                // 所見マスタ(型式別)
                ISelectShokenMstByShokenBitMaskAndKensaIraiKeyDAInput kataShoInput = new SelectShokenMstByShokenBitMaskAndKensaIraiKeyDAInput();
                kataShoInput.IraiHoteiKbn = input.IraiHoteiKbn;
                kataShoInput.IraiHokenjoCd = input.IraiHokenjoCd;
                kataShoInput.IraiNendo = input.IraiNendo;
                kataShoInput.IraiRenban = input.IraiRenban;
                kataShoInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                ISelectShokenMstByShokenBitMaskAndKensaIraiKeyDAOutput kataShoOutput = new SelectShokenMstByShokenBitMaskAndKensaIraiKeyDataAccess().Execute(kataShoInput);

                output.ShokenMst.Merge(kataShoOutput.ShokenMst);
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
