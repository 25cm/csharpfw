using System.Reflection;
using FukjBizSystem.Application.DataAccess.Sync.GaikanKensaKekkaTbl;
using FukjBizSystem.Application.DataAccess.Sync.GenbaShashinTbl;
using FukjBizSystem.Application.DataAccess.Sync.JokasoDaichiRirekiTbl;
using FukjBizSystem.Application.DataAccess.Sync.JokasoDaichoMst;
using FukjBizSystem.Application.DataAccess.Sync.JokasoHoyuTaniSochiGroupTbl;
using FukjBizSystem.Application.DataAccess.Sync.JokasoMemoTbl;
using FukjBizSystem.Application.DataAccess.Sync.KensaIraiTbl;
using FukjBizSystem.Application.DataAccess.Sync.KensaKekkaTbl;
using FukjBizSystem.Application.DataAccess.Sync.MonitoringTbl;
using FukjBizSystem.Application.DataAccess.Sync.SaiSaisuiTbl;
using FukjBizSystem.Application.DataAccess.Sync.ShokenKekkaHosokuTbl;
using FukjBizSystem.Application.DataAccess.Sync.ShokenKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectTransactionDataToSqlsvBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IReflectTransactionDataToSqlsvBLInput : IUpdateGenbaShashinTblDAInput,
                                           IUpdateJokasoDaichiRirekiTblDAInput,
                                           IUpdateJokasoDaichoMstDAInput,
                                           IUpdateJokasoHoyuTaniSochiGroupTblDAInput,
                                           IUpdateJokasoMemoTblDAInput,
                                           IUpdateKensaIraiTblDAInput,
                                           IUpdateKensaKekkaTblDAInput,
                                           IUpdateMonitoringTblDAInput,
                                           IUpdateSaiSaisuiTblDAInput,
                                           IUpdateShokenKekkaHosokuTblDAInput,
                                           IUpdateShokenKekkaTblDAInput,
                                           IUpdateGaikanKensaKekkaTblDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectTransactionDataToSqlsvBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectTransactionDataToSqlsvBLInput : IReflectTransactionDataToSqlsvBLInput
    {
        /// <summary>
        /// GenbaShashinTblDataTable
        /// </summary>
        public GenbaShashinTblDataSet.GenbaShashinTblDataTable GenbaShashinTbl { get; set; }

        /// <summary>
        /// JokasoDaichiRirekiTblDataTable
        /// </summary>
        public JokasoDaichiRirekiTblDataSet.JokasoDaichiRirekiTblDataTable JokasoDaichiRirekiTbl { get; set; }

        /// <summary>
        /// JokasoDaichoMstDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMst { get; set; }

        /// <summary>
        /// JokasoHoyuTaniSochiGroupTblDataTable
        /// </summary>
        public JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable JokasoHoyuTaniSochiGroupTbl { get; set; }

        /// <summary>
        /// JokasoMemoTblDataTable
        /// </summary>
        public JokasoMemoTblDataSet.JokasoMemoTblDataTable JokasoMemoTbl { get; set; }

        /// <summary>
        /// KensaIraiTbl
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTbl { get; set; }

        /// <summary>
        /// KensaKekkaTblDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaTbl { get; set; }

        /// <summary>
        /// MonitoringTblDataTable
        /// </summary>
        public MonitoringTblDataSet.MonitoringTblDataTable MonitoringTbl { get; set; }

        /// <summary>
        /// SaiSaisuiTblDataTable
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiTbl { get; set; }

        /// <summary>
        /// ShokenKekkaHosokuTblDataTable
        /// </summary>
        public ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable ShokenKekkaHosokuTbl { get; set; }

        /// <summary>
        /// ShokenKekkaTblDataTable
        /// </summary>
        public ShokenKekkaTblDataSet.ShokenKekkaTblDataTable ShokenKekkaTbl { get; set; }

        /// <summary>
        /// GaikanKensaKekkaTblDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaTbl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectTransactionDataToSqlsvBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IReflectTransactionDataToSqlsvBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectTransactionDataToSqlsvBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectTransactionDataToSqlsvBLOutput : IReflectTransactionDataToSqlsvBLOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectTransactionDataToSqlsvBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/01  豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectTransactionDataToSqlsvBusinessLogic : BaseBusinessLogic<IReflectTransactionDataToSqlsvBLInput, IReflectTransactionDataToSqlsvBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ReflectTransactionDataToSqlsvBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/01  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ReflectTransactionDataToSqlsvBusinessLogic()
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
        /// 2014/12/01  豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IReflectTransactionDataToSqlsvBLOutput Execute(IReflectTransactionDataToSqlsvBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IReflectTransactionDataToSqlsvBLOutput output = new ReflectTransactionDataToSqlsvBLOutput();

            try
            {
                #region 浄化槽台帳関連

                // 浄化槽保有単位装置グループテーブル
                if (input.JokasoHoyuTaniSochiGroupTbl != null && input.JokasoHoyuTaniSochiGroupTbl.Count > 0)
                {
                    foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in input.JokasoDaichoMst)
                    {
                        // 浄化槽台帳のキーで浄化槽保有単位装置を削除する
                        IDeleteJokasoHoyuTaniSochiGroupTblDAInput delInput = new DeleteJokasoHoyuTaniSochiGroupTblDAInput();
                        delInput.HokenjoCd = row.JokasoHokenjoCd;
                        delInput.TorokuNendo = row.JokasoTorokuNendo;
                        delInput.Renban = row.JokasoRenban;
                        new DeleteJokasoHoyuTaniSochiGroupTblDataAccess().Execute(delInput);
                    }

                    // Insert
                    new UpdateJokasoHoyuTaniSochiGroupTblDataAccess().Execute(input);
                }

                // 浄化槽定型メモテーブル
                if (input.JokasoMemoTbl != null && input.JokasoMemoTbl.Count > 0)
                {
                    foreach (JokasoDaichoMstDataSet.JokasoDaichoMstRow row in input.JokasoDaichoMst)
                    {
                        // 浄化槽台帳のキーで浄化槽定型メモを削除する
                        IDeleteJokasoMemoTblDAInput delInput = new DeleteJokasoMemoTblDAInput();
                        delInput.HokenjoCd = row.JokasoHokenjoCd;
                        delInput.TorokuNendo = row.JokasoTorokuNendo;
                        delInput.Renban = row.JokasoRenban;
                        new DeleteJokasoMemoTblDataAccess().Execute(delInput);
                    }

                    // Insert
                    new UpdateJokasoMemoTblDataAccess().Execute(input);
                }

                // 浄化槽台帳マスタ履歴
                if (input.JokasoDaichiRirekiTbl != null && input.JokasoDaichiRirekiTbl.Count > 0)
                {
                    // Insert
                    new UpdateJokasoDaichiRirekiTblDataAccess().Execute(input);
                }

                // 浄化槽台帳マスタ
                if (input.JokasoDaichoMst != null && input.JokasoDaichoMst.Count > 0)
                {
                    // Update
                    new UpdateJokasoDaichoMstDataAccess().Execute(input);
                }

                #endregion

                #region 検査依頼関連

                // 現場写真テーブル
                if (input.GenbaShashinTbl != null && input.GenbaShashinTbl.Count > 0)
                {
                    foreach (KensaIraiTblDataSet.KensaIraiTblRow row in input.KensaIraiTbl)
                    {
                        // 検査依頼のキーで現場写真を削除する
                        IDeleteGenbaShashinTblDAInput delInput = new DeleteGenbaShashinTblDAInput();
                        delInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                        delInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                        delInput.IraiNendo = row.KensaIraiNendo;
                        delInput.IraiRenban = row.KensaIraiRenban;
                        new DeleteGenbaShashinTblDataAccess().Execute(delInput);
                    }
                    
                    // Insert
                    new UpdateGenbaShashinTblDataAccess().Execute(input);
                }

                // 所見結果テーブル
                if (input.ShokenKekkaTbl != null && input.ShokenKekkaTbl.Count > 0)
                {
                    foreach (KensaIraiTblDataSet.KensaIraiTblRow row in input.KensaIraiTbl)
                    {
                        // 検査依頼のキーで所見結果を削除する
                        IDeleteShokenKekkaTblDAInput delInput = new DeleteShokenKekkaTblDAInput();
                        delInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                        delInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                        delInput.IraiNendo = row.KensaIraiNendo;
                        delInput.IraiRenban = row.KensaIraiRenban;
                        new DeleteShokenKekkaTblDataAccess().Execute(delInput);
                    }

                    // Insert
                    new UpdateShokenKekkaTblDataAccess().Execute(input);
                }

                // 所見結果補足文テーブル
                if (input.ShokenKekkaHosokuTbl != null && input.ShokenKekkaHosokuTbl.Count > 0)
                {
                    foreach (KensaIraiTblDataSet.KensaIraiTblRow row in input.KensaIraiTbl)
                    {
                        // 検査依頼のキーで所見結果補足文を削除する
                        IDeleteShokenKekkaHosokuTblDAInput delInput = new DeleteShokenKekkaHosokuTblDAInput();
                        delInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                        delInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                        delInput.IraiNendo = row.KensaIraiNendo;
                        delInput.IraiRenban = row.KensaIraiRenban;
                        new DeleteShokenKekkaHosokuTblDataAccess().Execute(delInput);
                    }

                    // Insert
                    new UpdateShokenKekkaHosokuTblDataAccess().Execute(input);
                }

                // モニタリングテーブル
                if (input.MonitoringTbl != null && input.MonitoringTbl.Count > 0)
                {
                    foreach (KensaIraiTblDataSet.KensaIraiTblRow row in input.KensaIraiTbl)
                    {
                        // 検査依頼のキーでモニタリングテーブルを削除する
                        IDeleteMonitoringTblDAInput delInput = new DeleteMonitoringTblDAInput();
                        delInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                        delInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                        delInput.IraiNendo = row.KensaIraiNendo;
                        delInput.IraiRenban = row.KensaIraiRenban;
                        new DeleteMonitoringTblDataAccess().Execute(delInput);
                    }

                    // Insert
                    new UpdateMonitoringTblDataAccess().Execute(input);
                }

                // 外観検査結果テーブル
                if (input.GaikanKensaKekkaTbl != null && input.GaikanKensaKekkaTbl.Count > 0)
                {
                    foreach (KensaIraiTblDataSet.KensaIraiTblRow row in input.KensaIraiTbl)
                    {
                        // 検査依頼のキーで外観検査結果を削除する
                        IDeleteGaikanKensaKekkaTblDAInput delInput = new DeleteGaikanKensaKekkaTblDAInput();
                        delInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                        delInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                        delInput.IraiNendo = row.KensaIraiNendo;
                        delInput.IraiRenban = row.KensaIraiRenban;
                        new DeleteGaikanKensaKekkaTblDataAccess().Execute(delInput);
                    }

                    // Insert
                    new UpdateGaikanKensaKekkaTblDataAccess().Execute(input);
                }
                
                // 検査依頼テーブル
                if (input.KensaIraiTbl != null && input.KensaIraiTbl.Count > 0)
                {
                    // Update
                    new UpdateKensaIraiTblDataAccess().Execute(input);
                }

                // 検査結果テーブル
                if (input.KensaKekkaTbl != null && input.KensaKekkaTbl.Count > 0)
                {
                    // Update
                    new UpdateKensaKekkaTblDataAccess().Execute(input);
                }

                // 再採水テーブル
                if (input.SaiSaisuiTbl != null && input.SaiSaisuiTbl.Count > 0)
                {
                    // Update
                    new UpdateSaiSaisuiTblDataAccess().Execute(input);
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
