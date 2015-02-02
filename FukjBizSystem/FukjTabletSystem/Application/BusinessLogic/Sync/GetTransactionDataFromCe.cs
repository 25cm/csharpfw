using System;
using System.Data;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.Utility;
using FukjTabletSystem.Application.DataAccess.SQLCE.GenbaShashinTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.JokasoDaichoMst;
using FukjTabletSystem.Application.DataAccess.SQLCE.JokasoHoyuTaniSochiGroupTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.JokasoMemoTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.MonitoringTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.SaiSaisuiTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaHosokuTbl;
using FukjTabletSystem.Application.DataAccess.SQLCE.ShokenKekkaTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using FukjTabletSystem.Application.DataAccess.SQLCE.GaikanKensaKekkaTbl;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetTransactionDataFromCeBLInput
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
    interface IGetTransactionDataFromCeBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTransactionDataFromCeBLInput
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
    class GetTransactionDataFromCeBLInput : IGetTransactionDataFromCeBLInput
    {
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetTransactionDataFromCeBLOutput
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
    interface IGetTransactionDataFromCeBLOutput
    {
        /// <summary>
        /// GenbaShashinTbl
        /// </summary>
        GenbaShashinTblDataSet.GenbaShashinTblDataTable GenbaShashinTbl { get; set; }

        /// <summary>
        /// JokasoDaichoMst
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoMstDataTable JokasoDaichoMst { get; set; }

        /// <summary>
        /// JokasoHoyuTaniSochiGroupTbl
        /// </summary>
        JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable JokasoHoyuTaniSochiGroupTbl { get; set; }

        /// <summary>
        /// JokasoMemoTbl
        /// </summary>
        JokasoMemoTblDataSet.JokasoMemoTblDataTable JokasoMemoTbl { get; set; }

        /// <summary>
        /// KensaIraiTbl
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTbl { get; set; }

        /// <summary>
        /// KensaKekkaTbl
        /// </summary>
        KensaKekkaTblDataSet.KensaKekkaTblDataTable KensaKekkaTbl { get; set; }

        /// <summary>
        /// SaiSaisuiTbl
        /// </summary>
        SaiSaisuiTblDataSet.SaiSaisuiTblDataTable SaiSaisuiTbl { get; set; }

        /// <summary>
        /// ShokenKekkaTbl
        /// </summary>
        ShokenKekkaTblDataSet.ShokenKekkaTblDataTable ShokenKekkaTbl { get; set; }

        /// <summary>
        /// ShokenKekkaHosokuTbl
        /// </summary>
        ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable ShokenKekkaHosokuTbl { get; set; }

        /// <summary>
        /// MonitoringTbl
        /// </summary>
        MonitoringTblDataSet.MonitoringTblDataTable MonitoringTbl { get; set; }

        /// <summary>
        /// GaikanKensaKekkaTbl
        /// </summary>
        GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaTbl { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTransactionDataFromCeBLOutput
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
    class GetTransactionDataFromCeBLOutput : IGetTransactionDataFromCeBLOutput
    {
        /// <summary>
        /// GenbaShashinTbl
        /// </summary>
        public GenbaShashinTblDataSet.GenbaShashinTblDataTable GenbaShashinTbl { get; set; }

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
        /// KensaIraiTbl
        /// </summary>
        public KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTbl { get; set; }
        
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
        /// GaikanKensaKekkaTbl
        /// </summary>
        public GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaTbl { get; set; }

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTransactionDataFromCeBusinessLogic
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
    class GetTransactionDataFromCeBusinessLogic : BaseBusinessLogic<IGetTransactionDataFromCeBLInput, IGetTransactionDataFromCeBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetTransactionDataFromCeBusinessLogic
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
        public GetTransactionDataFromCeBusinessLogic()
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
        public override IGetTransactionDataFromCeBLOutput Execute(IGetTransactionDataFromCeBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetTransactionDataFromCeBLOutput output = new GetTransactionDataFromCeBLOutput();

            try
            {
                #region 登録用テーブル定義

                // 検査依頼
                output.KensaIraiTbl = new KensaIraiTblDataSet.KensaIraiTblDataTable();
                
                // 現場写真
                output.GenbaShashinTbl = new GenbaShashinTblDataSet.GenbaShashinTblDataTable();
                
                // 検査結果
                output.KensaKekkaTbl = new KensaKekkaTblDataSet.KensaKekkaTblDataTable();

                // 再採水テーブル
                output.SaiSaisuiTbl = new SaiSaisuiTblDataSet.SaiSaisuiTblDataTable();
                
                // 所見結果補足文
                output.ShokenKekkaTbl = new ShokenKekkaTblDataSet.ShokenKekkaTblDataTable();

                // モニタリングテーブル
                output.MonitoringTbl = new MonitoringTblDataSet.MonitoringTblDataTable();

                // 所見結果
                output.ShokenKekkaHosokuTbl = new ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable();

                // 浄化槽台帳
                output.JokasoDaichoMst = new JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

                // 浄化槽保有単位装置グループ
                output.JokasoHoyuTaniSochiGroupTbl = new JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable();

                // 浄化槽定型メモ
                output.JokasoMemoTbl = new JokasoMemoTblDataSet.JokasoMemoTblDataTable();

                // 外観検査結果
                output.GaikanKensaKekkaTbl = new GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable();

                #endregion
                                
                #region 現場写真
                
                // 現場写真をローカルデータベースより取得
                ISelectGenbaShashinTblInKensaIraiDAInput selectGenbaShashinTblInput = new SelectGenbaShashinTblInKensaIraiDAInput();
                // 検索
                ISelectGenbaShashinTblInKensaIraiDAOutput selectGenbaShashinTblOutput = new SelectGenbaShashinTblInKensaIraiDataAccess().Execute(selectGenbaShashinTblInput);

                // 現場写真を一件毎に処理する
                foreach (DataRow GenbaShashinTblRow in selectGenbaShashinTblOutput.GenbaShashinTbl)
                {
                    // レコードの追加
                    GenbaShashinTblDataSet.GenbaShashinTblRow newGenbaShashinTblRow = output.GenbaShashinTbl.NewGenbaShashinTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.GenbaShashinTbl.Columns)
                    {
                        newGenbaShashinTblRow[col.ColumnName] = GenbaShashinTblRow[col.ColumnName];
                    }

                    newGenbaShashinTblRow.InsertDt = DateTime.Now;
                    newGenbaShashinTblRow.InsertTarm = Dns.GetHostName();
                    newGenbaShashinTblRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newGenbaShashinTblRow.UpdateDt = DateTime.Now;
                    newGenbaShashinTblRow.UpdateTarm = Dns.GetHostName();
                    newGenbaShashinTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    // レコードの登録
                    output.GenbaShashinTbl.AddGenbaShashinTblRow(newGenbaShashinTblRow);
                    newGenbaShashinTblRow.AcceptChanges();
                    newGenbaShashinTblRow.SetAdded();
                }

                #endregion

                #region 浄化槽台帳マスタ

                // 浄化槽台帳マスタをローカルデータベースより取得
                ISelectJokasoDaichoMstInKensaIraiDAInput selectJokasoDaichoMstInput = new SelectJokasoDaichoMstInKensaIraiDAInput();
                // 検索
                ISelectJokasoDaichoMstInKensaIraiDAOutput selectJokasoDaichoMstOutput = new SelectJokasoDaichoMstInKensaIraiDataAccess().Execute(selectJokasoDaichoMstInput);

                // 浄化槽台帳マスタを一件毎に処理する
                foreach (DataRow JokasoDaichoMstRow in selectJokasoDaichoMstOutput.JokasoDaichoMst)
                {
                    // レコードの追加
                    JokasoDaichoMstDataSet.JokasoDaichoMstRow newJokasoDaichoMstRow = output.JokasoDaichoMst.NewJokasoDaichoMstRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.JokasoDaichoMst.Columns)
                    {
                        newJokasoDaichoMstRow[col.ColumnName] = JokasoDaichoMstRow[col.ColumnName];
                    }

                    // 変更なしの場合は更新しない（ダウンロード時に更新日を登録日時に合わせている）
                    if ((DateTime)JokasoDaichoMstRow["UpdateDt"] == (DateTime)JokasoDaichoMstRow["InsertDt"])
                    {
                        // レコードの登録
                        output.JokasoDaichoMst.AddJokasoDaichoMstRow(newJokasoDaichoMstRow);
                        newJokasoDaichoMstRow.AcceptChanges();
                    }
                    else
                    {
                        newJokasoDaichoMstRow.UpdateDt = DateTime.Now;
                        newJokasoDaichoMstRow.UpdateTarm = Dns.GetHostName();
                        newJokasoDaichoMstRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                        // レコードの登録
                        output.JokasoDaichoMst.AddJokasoDaichoMstRow(newJokasoDaichoMstRow);
                        newJokasoDaichoMstRow.AcceptChanges();
                        newJokasoDaichoMstRow.SetModified();
                    }
                }

                #endregion

                #region 浄化槽保有単位装置グループ

                // 浄化槽保有単位装置グループをローカルデータベースより取得
                ISelectJokasoHoyuTaniSochiGroupTblInKensaIraiDAInput selectJokasoHoyuTaniSochiGroupTblInput = new SelectJokasoHoyuTaniSochiGroupTblInKensaIraiDAInput();
                // 検索
                ISelectJokasoHoyuTaniSochiGroupTblInKensaIraiDAOutput selectJokasoHoyuTaniSochiGroupTblOutput = new SelectJokasoHoyuTaniSochiGroupTblInKensaIraiDataAccess().Execute(selectJokasoHoyuTaniSochiGroupTblInput);

                // 浄化槽保有単位装置グループを一件毎に処理する
                foreach (DataRow JokasoHoyuTaniSochiGroupTblRow in selectJokasoHoyuTaniSochiGroupTblOutput.JokasoHoyuTaniSochiGroupTbl)
                {
                    // レコードの追加
                    JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblRow newJokasoHoyuTaniSochiGroupTblRow = output.JokasoHoyuTaniSochiGroupTbl.NewJokasoHoyuTaniSochiGroupTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.JokasoHoyuTaniSochiGroupTbl.Columns)
                    {
                        newJokasoHoyuTaniSochiGroupTblRow[col.ColumnName] = JokasoHoyuTaniSochiGroupTblRow[col.ColumnName];
                    }

                    newJokasoHoyuTaniSochiGroupTblRow.InsertDt = DateTime.Now;
                    newJokasoHoyuTaniSochiGroupTblRow.InsertTarm = Dns.GetHostName();
                    newJokasoHoyuTaniSochiGroupTblRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newJokasoHoyuTaniSochiGroupTblRow.UpdateDt = DateTime.Now;
                    newJokasoHoyuTaniSochiGroupTblRow.UpdateTarm = Dns.GetHostName();
                    newJokasoHoyuTaniSochiGroupTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                  
                    // レコードの登録
                    output.JokasoHoyuTaniSochiGroupTbl.AddJokasoHoyuTaniSochiGroupTblRow(newJokasoHoyuTaniSochiGroupTblRow);
                    newJokasoHoyuTaniSochiGroupTblRow.AcceptChanges();
                    newJokasoHoyuTaniSochiGroupTblRow.SetAdded();
                }

                #endregion

                #region 浄化槽メモ

                // 浄化槽メモをローカルデータベースより取得
                ISelectJokasoMemoTblInKensaIraiDAInput selectJokasoMemoTblInput = new SelectJokasoMemoTblInKensaIraiDAInput();
                // 検索
                ISelectJokasoMemoTblInKensaIraiDAOutput selectJokasoMemoTblOutput = new SelectJokasoMemoTblInKensaIraiDataAccess().Execute(selectJokasoMemoTblInput);

                // 浄化槽メモを一件毎に処理する
                foreach (DataRow JokasoMemoTblRow in selectJokasoMemoTblOutput.JokasoMemoTbl)
                {
                    // レコードの追加
                    JokasoMemoTblDataSet.JokasoMemoTblRow newJokasoMemoTblRow = output.JokasoMemoTbl.NewJokasoMemoTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.JokasoMemoTbl.Columns)
                    {
                        newJokasoMemoTblRow[col.ColumnName] = JokasoMemoTblRow[col.ColumnName];
                    }

                    newJokasoMemoTblRow.InsertDt = DateTime.Now;
                    newJokasoMemoTblRow.InsertTarm = Dns.GetHostName();
                    newJokasoMemoTblRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newJokasoMemoTblRow.UpdateDt = DateTime.Now;
                    newJokasoMemoTblRow.UpdateTarm = Dns.GetHostName();
                    newJokasoMemoTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    // レコードの登録
                    output.JokasoMemoTbl.AddJokasoMemoTblRow(newJokasoMemoTblRow);
                    newJokasoMemoTblRow.AcceptChanges();
                    newJokasoMemoTblRow.SetAdded();
                }

                #endregion

                #region 検査依頼

                // 検査依頼をローカルデータベースより取得
                ISelectKensaIraiTblInKensaIraiDAInput selectKensaIraiTblInput = new SelectKensaIraiTblInKensaIraiDAInput();
                // 検索
                ISelectKensaIraiTblInKensaIraiDAOutput selectKensaIraiTblOutput = new SelectKensaIraiTblInKensaIraiDataAccess().Execute(selectKensaIraiTblInput);

                // 検査依頼を一件毎に処理する
                foreach (DataRow KensaIraiTblRow in selectKensaIraiTblOutput.KensaIraiTbl)
                {
                    // レコードの追加
                    KensaIraiTblDataSet.KensaIraiTblRow newKensaIraiTblRow = output.KensaIraiTbl.NewKensaIraiTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.KensaIraiTbl.Columns)
                    {
                        newKensaIraiTblRow[col.ColumnName] = KensaIraiTblRow[col.ColumnName];
                    }

                    newKensaIraiTblRow.UpdateDt = DateTime.Now;
                    newKensaIraiTblRow.UpdateTarm = Dns.GetHostName();
                    newKensaIraiTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    // レコードの登録
                    output.KensaIraiTbl.AddKensaIraiTblRow(newKensaIraiTblRow);
                    newKensaIraiTblRow.AcceptChanges();
                    newKensaIraiTblRow.SetModified();
                }

                #endregion

                #region 検査結果

                // 検査結果をローカルデータベースより取得
                ISelectKensaKekkaTblInKensaIraiDAInput selectKensaKekkaTblInput = new SelectKensaKekkaTblInKensaIraiDAInput();
                // 検索
                ISelectKensaKekkaTblInKensaIraiDAOutput selectKensaKekkaTblOutput = new SelectKensaKekkaTblInKensaIraiDataAccess().Execute(selectKensaKekkaTblInput);

                // 検査結果を一件毎に処理する
                foreach (DataRow KensaKekkaTblRow in selectKensaKekkaTblOutput.KensaKekkaTbl)
                {
                    // レコードの追加
                    KensaKekkaTblDataSet.KensaKekkaTblRow newKensaKekkaTblRow = output.KensaKekkaTbl.NewKensaKekkaTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.KensaKekkaTbl.Columns)
                    {
                        newKensaKekkaTblRow[col.ColumnName] = KensaKekkaTblRow[col.ColumnName];
                    }

                    newKensaKekkaTblRow.UpdateDt = DateTime.Now;
                    newKensaKekkaTblRow.UpdateTarm = Dns.GetHostName();
                    newKensaKekkaTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    // レコードの登録
                    output.KensaKekkaTbl.AddKensaKekkaTblRow(newKensaKekkaTblRow);
                    newKensaKekkaTblRow.AcceptChanges();
                    newKensaKekkaTblRow.SetModified();
                }

                #endregion

                #region 再採水

                // 再採水をローカルデータベースより取得
                ISelectSaiSaisuiTblInKensaIraiDAInput selectSaiSaisuiTblInput = new SelectSaiSaisuiTblInKensaIraiDAInput();
                // 検索
                ISelectSaiSaisuiTblInKensaIraiDAOutput selectSaiSaisuiTblOutput = new SelectSaiSaisuiTblInKensaIraiDataAccess().Execute(selectSaiSaisuiTblInput);

                // 再採水を一件毎に処理する
                foreach (DataRow SaiSaisuiTblRow in selectSaiSaisuiTblOutput.SaiSaisuiTbl)
                {
                    // レコードの追加
                    SaiSaisuiTblDataSet.SaiSaisuiTblRow newSaiSaisuiTblRow = output.SaiSaisuiTbl.NewSaiSaisuiTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.SaiSaisuiTbl.Columns)
                    {
                        newSaiSaisuiTblRow[col.ColumnName] = SaiSaisuiTblRow[col.ColumnName];
                    }

                    newSaiSaisuiTblRow.UpdateDt = DateTime.Now;
                    newSaiSaisuiTblRow.UpdateTarm = Dns.GetHostName();
                    newSaiSaisuiTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    // レコードの登録
                    output.SaiSaisuiTbl.AddSaiSaisuiTblRow(newSaiSaisuiTblRow);
                    newSaiSaisuiTblRow.AcceptChanges();
                    newSaiSaisuiTblRow.SetModified();
                }

                #endregion

                #region 所見結果

                // 所見結果をローカルデータベースより取得
                ISelectShokenKekkaTblInKensaIraiDAInput selectShokenKekkaTblInput = new SelectShokenKekkaTblInKensaIraiDAInput();
                // 検索
                ISelectShokenKekkaTblInKensaIraiDAOutput selectShokenKekkaTblOutput = new SelectShokenKekkaTblInKensaIraiDataAccess().Execute(selectShokenKekkaTblInput);

                // 所見結果を一件毎に処理する
                foreach (DataRow ShokenKekkaTblRow in selectShokenKekkaTblOutput.ShokenKekkaTbl)
                {
                    // レコードの追加
                    ShokenKekkaTblDataSet.ShokenKekkaTblRow newShokenKekkaTblRow = output.ShokenKekkaTbl.NewShokenKekkaTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.ShokenKekkaTbl.Columns)
                    {
                        newShokenKekkaTblRow[col.ColumnName] = ShokenKekkaTblRow[col.ColumnName];
                    }

                    newShokenKekkaTblRow.InsertDt = DateTime.Now;
                    newShokenKekkaTblRow.InsertTarm = Dns.GetHostName();
                    newShokenKekkaTblRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newShokenKekkaTblRow.UpdateDt = DateTime.Now;
                    newShokenKekkaTblRow.UpdateTarm = Dns.GetHostName();
                    newShokenKekkaTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    // レコードの登録
                    output.ShokenKekkaTbl.AddShokenKekkaTblRow(newShokenKekkaTblRow);
                    newShokenKekkaTblRow.AcceptChanges();
                    newShokenKekkaTblRow.SetAdded();
                }

                #endregion

                #region 所見結果補足

                // 所見結果補足をローカルデータベースより取得
                ISelectShokenKekkaHosokuTblInKensaIraiDAInput selectShokenKekkaHosokuTblInput = new SelectShokenKekkaHosokuTblInKensaIraiDAInput();
                // 検索
                ISelectShokenKekkaHosokuTblInKensaIraiDAOutput selectShokenKekkaHosokuTblOutput = new SelectShokenKekkaHosokuTblInKensaIraiDataAccess().Execute(selectShokenKekkaHosokuTblInput);

                // 所見結果補足を一件毎に処理する
                foreach (DataRow ShokenKekkaHosokuTblRow in selectShokenKekkaHosokuTblOutput.ShokenKekkaHosokuTbl)
                {
                    // レコードの追加
                    ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblRow newShokenKekkaHosokuTblRow = output.ShokenKekkaHosokuTbl.NewShokenKekkaHosokuTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.ShokenKekkaHosokuTbl.Columns)
                    {
                        newShokenKekkaHosokuTblRow[col.ColumnName] = ShokenKekkaHosokuTblRow[col.ColumnName];
                    }

                    newShokenKekkaHosokuTblRow.InsertDt = DateTime.Now;
                    newShokenKekkaHosokuTblRow.InsertTarm = Dns.GetHostName();
                    newShokenKekkaHosokuTblRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newShokenKekkaHosokuTblRow.UpdateDt = DateTime.Now;
                    newShokenKekkaHosokuTblRow.UpdateTarm = Dns.GetHostName();
                    newShokenKekkaHosokuTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    
                    // レコードの登録
                    output.ShokenKekkaHosokuTbl.AddShokenKekkaHosokuTblRow(newShokenKekkaHosokuTblRow);
                    newShokenKekkaHosokuTblRow.AcceptChanges();
                    newShokenKekkaHosokuTblRow.SetAdded();
                }

                #endregion

                #region モニタリング

                // モニタリングをローカルデータベースより取得
                ISelectMonitoringTblInKensaIraiDAInput selectMonitoringTblInput = new SelectMonitoringTblInKensaIraiDAInput();
                // 検索
                ISelectMonitoringTblInKensaIraiDAOutput selectMonitoringTblOutput = new SelectMonitoringTblInKensaIraiDataAccess().Execute(selectMonitoringTblInput);

                // モニタリングを一件毎に処理する
                foreach (DataRow MonitoringTblRow in selectMonitoringTblOutput.MonitoringTbl)
                {
                    // レコードの追加
                    MonitoringTblDataSet.MonitoringTblRow newMonitoringTblRow = output.MonitoringTbl.NewMonitoringTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.MonitoringTbl.Columns)
                    {
                        newMonitoringTblRow[col.ColumnName] = MonitoringTblRow[col.ColumnName];
                    }

                    newMonitoringTblRow.InsertDt = DateTime.Now;
                    newMonitoringTblRow.InsertTarm = Dns.GetHostName();
                    newMonitoringTblRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newMonitoringTblRow.UpdateDt = DateTime.Now;
                    newMonitoringTblRow.UpdateTarm = Dns.GetHostName();
                    newMonitoringTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    
                    // レコードの登録
                    output.MonitoringTbl.AddMonitoringTblRow(newMonitoringTblRow);
                    newMonitoringTblRow.AcceptChanges();
                    newMonitoringTblRow.SetAdded();
                }

                #endregion

                #region 外観検査結果

                // 外観査結果をローカルデータベースより取得
                ISelectGaikanKensaKekkaTblInKensaIraiDAInput selectGaikanKensaKekkaTblInput = new SelectGaikanKensaKekkaTblInKensaIraiDAInput();
                // 検索
                ISelectGaikanKensaKekkaTblInKensaIraiDAOutput selectGaikanKensaKekkaTblOutput = new SelectGaikanKensaKekkaTblInKensaIraiDataAccess().Execute(selectGaikanKensaKekkaTblInput);

                // 外観検査結果を一件毎に処理する
                foreach (DataRow GaikanKensaKekkaTblRow in selectGaikanKensaKekkaTblOutput.GaikanKensaKekkaTbl)
                {
                    // レコードの追加
                    GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow newGaikanKensaKekkaTblRow = output.GaikanKensaKekkaTbl.NewGaikanKensaKekkaTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.GaikanKensaKekkaTbl.Columns)
                    {
                        newGaikanKensaKekkaTblRow[col.ColumnName] = GaikanKensaKekkaTblRow[col.ColumnName];
                    }

                    newGaikanKensaKekkaTblRow.InsertDt = DateTime.Now;
                    newGaikanKensaKekkaTblRow.InsertTarm = Dns.GetHostName();
                    newGaikanKensaKekkaTblRow.InsertUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                    newGaikanKensaKekkaTblRow.UpdateDt = DateTime.Now;
                    newGaikanKensaKekkaTblRow.UpdateTarm = Dns.GetHostName();
                    newGaikanKensaKekkaTblRow.UpdateUser = ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

                    // レコードの登録
                    output.GaikanKensaKekkaTbl.AddGaikanKensaKekkaTblRow(newGaikanKensaKekkaTblRow);
                    newGaikanKensaKekkaTblRow.AcceptChanges();
                    newGaikanKensaKekkaTblRow.SetAdded();
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
