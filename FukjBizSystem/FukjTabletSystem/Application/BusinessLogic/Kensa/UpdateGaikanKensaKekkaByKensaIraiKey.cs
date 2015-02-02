using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.DataAccess.SQLCE.GaikanKensaKekkaTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenMst;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateGaikanKensaKekkaByKensaIraiKeyBLInput
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
    interface IUpdateGaikanKensaKekkaByKensaIraiKeyBLInput
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
    //  クラス名 ： UpdateGaikanKensaKekkaByKensaIraiKeyBLInput
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
    class UpdateGaikanKensaKekkaByKensaIraiKeyBLInput : IUpdateGaikanKensaKekkaByKensaIraiKeyBLInput
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
    //  インターフェイス名 ： IUpdateGaikanKensaKekkaByKensaIraiKeyBLOutput
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
    interface IUpdateGaikanKensaKekkaByKensaIraiKeyBLOutput
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
    class UpdateGaikanKensaKekkaByKensaIraiKeyBLOutput : IUpdateGaikanKensaKekkaByKensaIraiKeyBLOutput
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
    class UpdateGaikanKensaKekkaByKensaIraiKeyBusinessLogic : BaseBusinessLogic<IUpdateGaikanKensaKekkaByKensaIraiKeyBLInput, IUpdateGaikanKensaKekkaByKensaIraiKeyBLOutput>
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
        public UpdateGaikanKensaKekkaByKensaIraiKeyBusinessLogic()
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
        public override IUpdateGaikanKensaKekkaByKensaIraiKeyBLOutput Execute(IUpdateGaikanKensaKekkaByKensaIraiKeyBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateGaikanKensaKekkaByKensaIraiKeyBLOutput output = new UpdateGaikanKensaKekkaByKensaIraiKeyBLOutput();

            try
            {
                // 外観検査結果
                GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable gaikanKensaKekkaTbl = new GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable();

                // 連番初期値
                int gaikanKensaKekkaRenban = 1;

                // （外観検査）所見結果を取得
                ISelectShokenKekkaTblByKensaIraiAndBitMaskDAInput shokenInput = new SelectShokenKekkaTblByKensaIraiAndBitMaskDAInput();

                shokenInput.IraiHoteiKbn = input.IraiHoteiKbn;
                shokenInput.IraiHokenjoCd = input.IraiHokenjoCd;
                shokenInput.IraiNendo = input.IraiNendo;
                shokenInput.IraiRenban = input.IraiRenban;
                shokenInput.ShokenTaishoKensaBitMask = ShokenUtility.GetBitMask(ShokenUtility.SelectMode.Shoken, ShokenUtility.SelectType.GaikanKensa);

                ISelectShokenKekkaTblByKensaIraiAndBitMaskDAOutput shokenOutput = new SelectShokenKekkaTblByKensaIraiAndBitMaskDataAccess().Execute(shokenInput);

                foreach (ShokenKekkaTblDataSet.ShokenKekkaTblRow shoken in shokenOutput.ShokenKekkaTbl)
                {
                    // 外観検査は所見区分に対して１件
                    GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow[] gaikanKensaKekkaRows = gaikanKensaKekkaTbl.Select(string.Format("GaikanKensaKekkaCheckKomokuCd='{0}'", shoken.ShokenKbn)) as GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow[];

                    if(gaikanKensaKekkaRows.Length > 0)
                    {
                        // 判定の悪いほう（区分地が大きいほう）を採用する
                        if(int.Parse(gaikanKensaKekkaRows[0].GaikanKensaKekkaCheckKomokuHantei) < int.Parse(shoken.ShokenCheckHantei))
                        {
                            gaikanKensaKekkaRows[0].GaikanKensaKekkaCheckKomokuHantei = shoken.ShokenCheckHantei;
                        }
                    }
                    else
                    {
                        // 外観検査結果を作成
                        GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow newRow = gaikanKensaKekkaTbl.NewGaikanKensaKekkaTblRow();

                        newRow.GaikanKensaKekkaIraiHoteiKbn = input.IraiHoteiKbn;
                        newRow.GaikanKensaKekkaIraiHokenjoCd = input.IraiHokenjoCd;
                        newRow.GaikanKensaKekkakuIraiNendo = input.IraiNendo;
                        newRow.GaikanKensaKekkaIraiRenban = input.IraiRenban;
                        newRow.GaikanKensaKekkaRenban = string.Format("{0:00}", gaikanKensaKekkaRenban);
                        newRow.GaikanKensaKekkaCheckKomokuHantei = shoken.ShokenCheckHantei;
                        newRow.GaikanKensaKekkaCheckKomokuCd = shoken.ShokenKbn;
                        
                        newRow.InsertDt = DateTime.Now;
                        newRow.InsertTarm = Dns.GetHostName();
                        newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                        newRow.UpdateDt = DateTime.Now;
                        newRow.UpdateTarm = Dns.GetHostName();
                        newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                        gaikanKensaKekkaTbl.AddGaikanKensaKekkaTblRow(newRow);

                        newRow.AcceptChanges();
                        newRow.SetAdded();

                        gaikanKensaKekkaRenban++;
                    }

                    #region 同時チェック

                    // 同時チェック項目の有無を確認
                    ISelectShokenMstByKeyDAInput shokenMstInput = new SelectShokenMstByKeyDAInput();
                    shokenMstInput.ShokenKbn = shoken.ShokenKbn;
                    shokenMstInput.ShokenCd = shoken.ShokenCd;

                    // 所見マスタを取得
                    ISelectShokenMstByKeyDAOutput shokenMstOutput = new SelectShokenMstByKeyDataAccess().Execute(shokenMstInput);

                    // 同時チェック項目あり
                    if (shokenMstOutput.ShokenMst.Count > 0 && !string.IsNullOrEmpty(shokenMstOutput.ShokenMst[0].ShokenDojiCheckKomoku))
                    {
                        // 外観検査は所見区分に対して１件
                        GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow[] gaikanKensaKekkaDojiRows = gaikanKensaKekkaTbl.Select(string.Format("GaikanKensaKekkaCheckKomokuCd='{0}'", shokenMstOutput.ShokenMst[0].ShokenDojiCheckKomoku)) as GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow[];

                        if (gaikanKensaKekkaDojiRows.Length > 0)
                        {
                            // 判定の悪いほう（区分地が大きいほう）を採用する
                            if (int.Parse(gaikanKensaKekkaDojiRows[0].GaikanKensaKekkaCheckKomokuHantei) < int.Parse(shokenMstOutput.ShokenMst[0].ShokenDojiCheckHandan))
                            {
                                gaikanKensaKekkaDojiRows[0].GaikanKensaKekkaCheckKomokuHantei = shokenMstOutput.ShokenMst[0].ShokenDojiCheckHandan;
                            }
                        }
                        else
                        {
                            // 外観検査結果を作成
                            GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow newRow = gaikanKensaKekkaTbl.NewGaikanKensaKekkaTblRow();

                            newRow.GaikanKensaKekkaIraiHoteiKbn = input.IraiHoteiKbn;
                            newRow.GaikanKensaKekkaIraiHokenjoCd = input.IraiHokenjoCd;
                            newRow.GaikanKensaKekkakuIraiNendo = input.IraiNendo;
                            newRow.GaikanKensaKekkaIraiRenban = input.IraiRenban;
                            newRow.GaikanKensaKekkaRenban = string.Format("{0:00}", gaikanKensaKekkaRenban);
                            newRow.GaikanKensaKekkaCheckKomokuHantei = shokenMstOutput.ShokenMst[0].ShokenDojiCheckHandan;
                            newRow.GaikanKensaKekkaCheckKomokuCd = shokenMstOutput.ShokenMst[0].ShokenDojiCheckKomoku;

                            newRow.InsertDt = DateTime.Now;
                            newRow.InsertTarm = Dns.GetHostName();
                            newRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                            newRow.UpdateDt = DateTime.Now;
                            newRow.UpdateTarm = Dns.GetHostName();
                            newRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                            gaikanKensaKekkaTbl.AddGaikanKensaKekkaTblRow(newRow);

                            newRow.AcceptChanges();
                            newRow.SetAdded();

                            gaikanKensaKekkaRenban++;
                        }
                    }

                    #endregion
                }

                #region 更新処理(Delete→Insert)

                // Delete
                IDeleteGaikanKensaKekkaTblByKensaIraiKeyDAInput deleteInput = new DeleteGaikanKensaKekkaTblByKensaIraiKeyDAInput();
                deleteInput.IraiHoteiKbn = input.IraiHoteiKbn;
                deleteInput.IraiHokenjoCd = input.IraiHokenjoCd;
                deleteInput.IraiNendo = input.IraiNendo;
                deleteInput.IraiRenban = input.IraiRenban;

                new DeleteGaikanKensaKekkaTblByKensaIraiKeyDataAccess().Execute(deleteInput);

                // Insert
                if (gaikanKensaKekkaTbl.Count > 0)
                {
                    IUpdateGaikanKensaKekkaTblDAInput updateInput = new UpdateGaikanKensaKekkaTblDAInput();

                    updateInput.GaikanKensaKekkaTbl = gaikanKensaKekkaTbl;

                    new UpdateGaikanKensaKekkaTblDataAccess().Execute(updateInput);
                }

                #endregion
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
