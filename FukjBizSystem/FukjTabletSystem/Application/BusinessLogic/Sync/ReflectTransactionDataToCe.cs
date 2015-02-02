using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.GenbaShashinTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.JokasoDaichoMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.JokasoHoyuTaniSochiGroupTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.JokasoMemoTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiHistTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiKanrenFileTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.MonitoringTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.SaiSaisuiTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaHosokuTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using FukjTabletSystem.Application.DataAccess.SQLCE.GaikanKensaKekkaTbl;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectTransactionDataToCeBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IReflectTransactionDataToCeBLInput : IUpdateKensaIraiTblDAInput,
                                              IUpdateKensaIraiHistTblDAInput,
                                              IUpdateGenbaShashinTblDAInput,
                                              IUpdateKensaIraiKanrenFileTblDAInput,
                                              IUpdateKensaKekkaTblDAInput,
                                              IUpdateSaiSaisuiTblDAInput,
                                              IUpdateShokenKekkaTblDAInput,
                                              IUpdateShokenKekkaHosokuTblDAInput,
                                              IUpdateMonitoringTblDAInput,
                                              IUpdateJokasoDaichoMstDAInput,
                                              IUpdateJokasoHoyuTaniSochiGroupTblDAInput,
                                              IUpdateJokasoMemoTblDAInput,
                                              IUpdateGaikanKensaKekkaTblDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectTransactionDataToCeBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectTransactionDataToCeBLInput : IReflectTransactionDataToCeBLInput
    {
        /// <summary>
        /// KensaIraiTbl
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTbl { get; set; }

        /// <summary>
        /// KensaIraiHistTbl
        /// </summary>
        public KensaIraiHistTblDataSet.KensaIraiHistTblDataTable KensaIraiHistTbl { get; set; }
        
        /// <summary>
        /// GenbaShashinTbl
        /// </summary>
        public GenbaShashinTblDataSet.GenbaShashinTblDataTable GenbaShashinTbl { get; set; }

        /// <summary>
        /// KensaIraiKanrenFileTbl
        /// </summary>
        public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTbl { get; set; }

        /// <summary>
        /// KensaKekkaTbl
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaTbl { get; set; }

        /// <summary>
        /// SaiSaisuiTbl
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiTbl { get; set; }

        /// <summary>
        /// ShokenKekkaTbl
        /// </summary>
        public ShokenKekkaTblDataSet.ShokenKekkaTblDataTable ShokenKekkaTbl { get; set; }

        /// <summary>
        /// ShokenKekkaHosokuTbl
        /// </summary>
        public ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable ShokenKekkaHosokuTbl { get; set; }

        /// <summary>
        /// MonitoringTbl
        /// </summary>
        public MonitoringTblDataSet.MonitoringTblDataTable MonitoringTbl { get; set; }

        /// <summary>
        /// JokasoDaichoMst
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMst { get; set; }

        /// <summary>
        /// JokasoHoyuTaniSochiGroupTbl
        /// </summary>
        public JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable JokasoHoyuTaniSochiGroupTbl { get; set; }

        /// <summary>
        /// JokasoMemoTbl
        /// </summary>
        public JokasoMemoTblDataSet.JokasoMemoTblDataTable JokasoMemoTbl { get; set; }

        /// <summary>
        /// GaikanKensaKekkaTbl
        /// </summary>
        public GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaTbl { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IReflectTransactionDataToCeBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IReflectTransactionDataToCeBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectTransactionDataToCeBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectTransactionDataToCeBLOutput : IReflectTransactionDataToCeBLOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ReflectTransactionDataToCeBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/05　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ReflectTransactionDataToCeBusinessLogic : BaseBusinessLogic<IReflectTransactionDataToCeBLInput, IReflectTransactionDataToCeBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ReflectTransactionDataToCeBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ReflectTransactionDataToCeBusinessLogic()
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
        /// 2014/09/05　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IReflectTransactionDataToCeBLOutput Execute(IReflectTransactionDataToCeBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IReflectTransactionDataToCeBLOutput output = new ReflectTransactionDataToCeBLOutput();

            try
            {
                #region 既存のレコードを削除

                // 検査依頼
                new FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiTbl.DeleteKensaIraiTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiTbl.DeleteKensaIraiTblDAInput());

                // 検査依頼履歴
                new FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiHistTbl.DeleteKensaIraiHistTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiHistTbl.DeleteKensaIraiHistTblDAInput());

                // 現場写真
                new FukjTabletSystem.Application.DataAccess.SQLCE.GenbaShashinTbl.DeleteGenbaShashinTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.GenbaShashinTbl.DeleteGenbaShashinTblDAInput());

                // 関連ファイル
                new FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiKanrenFileTbl.DeleteKensaIraiKanrenFileTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiKanrenFileTbl.DeleteKensaIraiKanrenFileTblDAInput());

                // 検査結果
                new FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl.DeleteKensaKekkaTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl.DeleteKensaKekkaTblDAInput());

                // 再採水
                new FukjTabletSystem.Application.DataAccess.SQLCE.SaiSaisuiTbl.DeleteSaiSaisuiTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.SaiSaisuiTbl.DeleteSaiSaisuiTblDAInput());

                // 所見結果
                new FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaTbl.DeleteShokenKekkaTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaTbl.DeleteShokenKekkaTblDAInput());

                // 所見結果補足文
                new FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaHosokuTbl.DeleteShokenKekkaHosokuTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaHosokuTbl.DeleteShokenKekkaHosokuTblDAInput());

                // モニタリング
                new FukjTabletSystem.Application.DataAccess.SQLCE.MonitoringTbl.DeleteMonitoringTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.MonitoringTbl.DeleteMonitoringTblDAInput());

                // 浄化槽台帳
                new FukjTabletSystem.Application.DataAccess.SQLCE.JokasoDaichoMst.DeleteJokasoDaichoMstDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.JokasoDaichoMst.DeleteJokasoDaichoMstDAInput());

                // 浄化槽保有単位装置グループ
                new FukjTabletSystem.Application.DataAccess.SQLCE.JokasoHoyuTaniSochiGroupTbl.DeleteJokasoHoyuTaniSochiGroupTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.JokasoHoyuTaniSochiGroupTbl.DeleteJokasoHoyuTaniSochiGroupTblDAInput());

                // 浄化槽定型メモ
                new FukjTabletSystem.Application.DataAccess.SQLCE.JokasoMemoTbl.DeleteJokasoMemoTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.JokasoMemoTbl.DeleteJokasoMemoTblDAInput());

                // 外観検査結果
                new FukjTabletSystem.Application.DataAccess.SQLCE.GaikanKensaKekkaTbl.DeleteGaikanKensaKekkaTblDataAccess().Execute(
                    new FukjTabletSystem.Application.DataAccess.SQLCE.GaikanKensaKekkaTbl.DeleteGaikanKensaKekkaTblDAInput());

                #endregion

                #region データ登録

                // 検査依頼
                new FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiTbl.UpdateKensaIraiTblDataAccess().Execute(input);

                // 検査依頼履歴
                new FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiHistTbl.UpdateKensaIraiHistTblDataAccess().Execute(input);
                
                // 現場写真
                new FukjTabletSystem.Application.DataAccess.SQLCE.GenbaShashinTbl.UpdateGenbaShashinTblDataAccess().Execute(input);

                // 関連ファイル
                new FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiKanrenFileTbl.UpdateKensaIraiKanrenFileTblDataAccess().Execute(input);

                // 検査結果
                new FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl.UpdateKensaKekkaTblDataAccess().Execute(input);

                // 再採水
                new FukjTabletSystem.Application.DataAccess.SQLCE.SaiSaisuiTbl.UpdateSaiSaisuiTblDataAccess().Execute(input);

                // 所見結果
                new FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaTbl.UpdateShokenKekkaTblDataAccess().Execute(input);
                
                // 所見結果補足文
                new FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaHosokuTbl.UpdateShokenKekkaHosokuTblDataAccess().Execute(input);

                // モニタリング
                new FukjTabletSystem.Application.DataAccess.SQLCE.MonitoringTbl.UpdateMonitoringTblDataAccess().Execute(input);
                
                // 浄化槽台帳
                new FukjTabletSystem.Application.DataAccess.SQLCE.JokasoDaichoMst.UpdateJokasoDaichoMstDataAccess().Execute(input);

                // 浄化槽保有単位装置グループ
                new FukjTabletSystem.Application.DataAccess.SQLCE.JokasoHoyuTaniSochiGroupTbl.UpdateJokasoHoyuTaniSochiGroupTblDataAccess().Execute(input);

                // 浄化槽定型メモ
                new FukjTabletSystem.Application.DataAccess.SQLCE.JokasoMemoTbl.UpdateJokasoMemoTblDataAccess().Execute(input);

                // 外観検査結果
                new FukjTabletSystem.Application.DataAccess.SQLCE.GaikanKensaKekkaTbl.UpdateGaikanKensaKekkaTblDataAccess().Execute(input);

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
