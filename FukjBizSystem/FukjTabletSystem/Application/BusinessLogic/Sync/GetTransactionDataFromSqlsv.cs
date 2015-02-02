using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.Sync.GenbaShashinTbl;
using FukjBizSystem.Application.DataAccess.Sync.JokasoDaichoMst;
using FukjBizSystem.Application.DataAccess.Sync.JokasoHoyuTaniSochiGroupTbl;
using FukjBizSystem.Application.DataAccess.Sync.JokasoMemoTbl;
using FukjBizSystem.Application.DataAccess.Sync.KensaIraiKanrenFileTbl;
using FukjBizSystem.Application.DataAccess.Sync.KensaIraiTbl;
using FukjBizSystem.Application.DataAccess.Sync.KensaKekkaTbl;
using FukjBizSystem.Application.DataAccess.Sync.MonitoringTbl;
using FukjBizSystem.Application.DataAccess.Sync.SaiSaisuiTbl;
using FukjBizSystem.Application.DataAccess.Sync.ShokenKekkaHosokuTbl;
using FukjBizSystem.Application.DataAccess.Sync.ShokenKekkaTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.DataAccess.Sync.GaikanKensaKekkaTbl;

namespace FukjTabletSystem.Application.BusinessLogic.Sync
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetTransactionDataFromSqlsvBLInput
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
    interface IGetTransactionDataFromSqlsvBLInput
    {
        /// <summary>
        /// Yoteibi
        /// </summary>
        DateTime Yoteibi { get; set; }

        /// <summary>
        /// TantoshaCd
        /// </summary>
        string TantoshaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTransactionDataFromSqlsvBLInput
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
    class GetTransactionDataFromSqlsvBLInput : IGetTransactionDataFromSqlsvBLInput
    {
        /// <summary>
        /// Yoteibi
        /// </summary>
        public DateTime Yoteibi { get; set; }

        /// <summary>
        /// TantoshaCd
        /// </summary>
        public string TantoshaCd { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetTransactionDataFromSqlsvBLOutput
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
    interface IGetTransactionDataFromSqlsvBLOutput
    {
        /// <summary>
        /// KensaIraiTbl
        /// </summary>
        KensaIraiTblDataSet.KensaIraiTblDataTable KensaIraiTbl { get; set; }

        /// <summary>
        /// KensaIraiHistTbl
        /// </summary>
        KensaIraiHistTblDataSet.KensaIraiHistTblDataTable KensaIraiHistTbl { get; set; }
        
        /// <summary>
        /// GenbaShashinTbl
        /// </summary>
        GenbaShashinTblDataSet.GenbaShashinTblDataTable GenbaShashinTbl { get; set; }

        /// <summary>
        /// KensaIraiKanrenFileTbl
        /// </summary>
        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTbl { get; set; }

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
        /// GaikanKensaKekkaTbl
        /// </summary>
        GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable GaikanKensaKekkaTbl { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTransactionDataFromSqlsvBLOutput
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
    class GetTransactionDataFromSqlsvBLOutput : IGetTransactionDataFromSqlsvBLOutput
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

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTransactionDataFromSqlsvBusinessLogic
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
    class GetTransactionDataFromSqlsvBusinessLogic : BaseBusinessLogic<IGetTransactionDataFromSqlsvBLInput, IGetTransactionDataFromSqlsvBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetTransactionDataFromSqlsvBusinessLogic
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
        public GetTransactionDataFromSqlsvBusinessLogic()
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
        public override IGetTransactionDataFromSqlsvBLOutput Execute(IGetTransactionDataFromSqlsvBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetTransactionDataFromSqlsvBLOutput output = new GetTransactionDataFromSqlsvBLOutput();

            try
            {
                #region 登録用テーブル定義

                // 検査依頼
                output.KensaIraiTbl = new DataSet.SQLCE.KensaIraiTblDataSet.KensaIraiTblDataTable();

                // 検査依頼履歴
                output.KensaIraiHistTbl = new DataSet.SQLCE.KensaIraiHistTblDataSet.KensaIraiHistTblDataTable();

                // 現場写真
                output.GenbaShashinTbl = new DataSet.SQLCE.GenbaShashinTblDataSet.GenbaShashinTblDataTable();

                // 関連ファイル
                output.KensaIraiKanrenFileTbl = new DataSet.SQLCE.KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable();

                // 検査結果
                output.KensaKekkaTbl = new DataSet.SQLCE.KensaKekkaTblDataSet.KensaKekkaTblDataTable();

                // 再採水テーブル
                output.SaiSaisuiTbl = new DataSet.SQLCE.SaiSaisuiTblDataSet.SaiSaisuiTblDataTable();
                
                // 所見結果補足文
                output.ShokenKekkaTbl = new DataSet.SQLCE.ShokenKekkaTblDataSet.ShokenKekkaTblDataTable();

                // モニタリングテーブル
                output.MonitoringTbl = new DataSet.SQLCE.MonitoringTblDataSet.MonitoringTblDataTable();

                // 所見結果
                output.ShokenKekkaHosokuTbl = new DataSet.SQLCE.ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblDataTable();

                // 浄化槽台帳
                output.JokasoDaichoMst = new DataSet.SQLCE.JokasoDaichoMstDataSet.JokasoDaichoMstDataTable();

                // 浄化槽保有単位装置グループ
                output.JokasoHoyuTaniSochiGroupTbl = new DataSet.SQLCE.JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblDataTable();

                // 浄化槽定型メモ
                output.JokasoMemoTbl = new DataSet.SQLCE.JokasoMemoTblDataSet.JokasoMemoTblDataTable();

                // 外観検査結果
                output.GaikanKensaKekkaTbl = new DataSet.SQLCE.GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblDataTable();

                #endregion

                // 検査依頼をサーバから取得
                ISelectKensaIraiTblByYoteibiTantoushaDAInput selectKensaIraiTblByYoteibiTantoushaInput = new SelectKensaIraiTblByYoteibiTantoushaDAInput();
                // 検査予定日
                selectKensaIraiTblByYoteibiTantoushaInput.Yoteibi = input.Yoteibi;
                // 担当者
                selectKensaIraiTblByYoteibiTantoushaInput.TantoshaCd = input.TantoshaCd;
                // 検索
                ISelectKensaIraiTblByYoteibiTantoushaDAOutput selectKensaIraiTblByYoteibiTantoushaOutput =
                    new SelectKensaIraiTblByYoteibiTantoushaDataAccess().Execute(selectKensaIraiTblByYoteibiTantoushaInput);
                
                // 台帳の重複取得制御
                List<string> jokashoDaichoList = new List<string>();
                
                // 検査依頼を一件毎に処理する
                foreach (FukjBizSystem.Application.DataSet.KensaIraiTblDataSet.KensaIraiTblRow row in selectKensaIraiTblByYoteibiTantoushaOutput.KensaIraiTbl.Rows)
                {
                    #region 検査依頼

                    // レコードの追加
                    KensaIraiTblDataSet.KensaIraiTblRow newRow = output.KensaIraiTbl.NewKensaIraiTblRow();

                    // 値の詰め替え
                    foreach (DataColumn col in output.KensaIraiTbl.Columns)
                    {
                        newRow[col.ColumnName] = row[col.ColumnName];
                    }

                    // レコードの登録
                    output.KensaIraiTbl.AddKensaIraiTblRow(newRow);

                    #endregion
                    
                    #region 現場写真テーブル

                    // 現場写真をサーバから取得
                    SelectGenbaShashinTblDAInput selectGenbaShashinTblInput = new SelectGenbaShashinTblDAInput();
                    // 法定区分
                    selectGenbaShashinTblInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                    // 保健所コード
                    selectGenbaShashinTblInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                    // 年度
                    selectGenbaShashinTblInput.IraiNendo = row.KensaIraiNendo;
                    // 連番
                    selectGenbaShashinTblInput.IraiRenban = row.KensaIraiRenban;
                    // 検索
                    ISelectGenbaShashinTblDAOutput selectGenbaShashinTblOutput = new SelectGenbaShashinTblDataAccess().Execute(selectGenbaShashinTblInput);

                    // 現場写真を一件毎に処理する
                    foreach (DataRow genbaShashinRow in selectGenbaShashinTblOutput.GenbaShashinTbl)
                    {
                        // キー重複のチェック
                        if (output.GenbaShashinTbl.FindByGenbaShashinKensaHoteiKbnGenbaShashinKensaHokenjoCdGenbaShashinKensaNendoGenbaShashinKensaRenbanGenbaShashinCd(
                            genbaShashinRow["GenbaShashinKensaHoteiKbn"].ToString(),
                            genbaShashinRow["GenbaShashinKensaHokenjoCd"].ToString(),
                            genbaShashinRow["GenbaShashinKensaNendo"].ToString(),
                            genbaShashinRow["GenbaShashinKensaRenban"].ToString(),
                            genbaShashinRow["GenbaShashinCd"].ToString()) != null)
                        {
                            continue;
                        }

                        // レコードの追加
                        GenbaShashinTblDataSet.GenbaShashinTblRow newGaikanKensaRow = output.GenbaShashinTbl.NewGenbaShashinTblRow();

                        // 値の詰め替え
                        foreach (DataColumn col in output.GenbaShashinTbl.Columns)
                        {
                            newGaikanKensaRow[col.ColumnName] = genbaShashinRow[col.ColumnName];
                        }

                        // レコードの登録
                        output.GenbaShashinTbl.AddGenbaShashinTblRow(newGaikanKensaRow);
                    }

                    #endregion

                    #region 検査依頼関連ファイルテーブル

                    // 検査依頼関連ファイルをサーバから取得
                    SelectKensaIraiKanrenFileTblDAInput selectKensaIraiKanrenFileTblInput = new SelectKensaIraiKanrenFileTblDAInput();
                    // 法定区分
                    selectKensaIraiKanrenFileTblInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                    // 保健所コード
                    selectKensaIraiKanrenFileTblInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                    // 年度
                    selectKensaIraiKanrenFileTblInput.IraiNendo = row.KensaIraiNendo;
                    // 連番
                    selectKensaIraiKanrenFileTblInput.IraiRenban = row.KensaIraiRenban;
                    // 検索
                    ISelectKensaIraiKanrenFileTblDAOutput selectKensaIraiKanrenFileTblOutput = new SelectKensaIraiKanrenFileTblDataAccess().Execute(selectKensaIraiKanrenFileTblInput);

                    // 検査依頼関連ファイルを一件毎に処理する
                    foreach (DataRow kensaIraiKanrenFileRow in selectKensaIraiKanrenFileTblOutput.KensaIraiKanrenFileTbl)
                    {
                        // キー重複のチェック
                        if (output.KensaIraiKanrenFileTbl.FindByKensaIraiHoteiKbnKensaIraiHokenjoCdKensaIraiNendoKensaIraiRenbanKensaIraiFileShubetsuCd(
                            kensaIraiKanrenFileRow["KensaIraiHoteiKbn"].ToString(),
                            kensaIraiKanrenFileRow["KensaIraiHokenjoCd"].ToString(),
                            kensaIraiKanrenFileRow["KensaIraiNendo"].ToString(),
                            kensaIraiKanrenFileRow["KensaIraiRenban"].ToString(),
                            kensaIraiKanrenFileRow["KensaIraiFileShubetsuCd"].ToString()) != null)
                        {
                            continue;
                        }

                        // レコードの追加
                        KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow newGaikanKensaRow = output.KensaIraiKanrenFileTbl.NewKensaIraiKanrenFileTblRow();

                        // 値の詰め替え
                        foreach (DataColumn col in output.KensaIraiKanrenFileTbl.Columns)
                        {
                            newGaikanKensaRow[col.ColumnName] = kensaIraiKanrenFileRow[col.ColumnName];
                        }

                        // レコードの登録
                        output.KensaIraiKanrenFileTbl.AddKensaIraiKanrenFileTblRow(newGaikanKensaRow);
                    }

                    #endregion

                    #region 検査結果テーブル

                    // 検査結果をサーバから取得
                    SelectKensaKekkaTblDAInput selectKensaKekkaTblInput = new SelectKensaKekkaTblDAInput();
                    // 法定区分
                    selectKensaKekkaTblInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                    // 保健所コード
                    selectKensaKekkaTblInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                    // 年度
                    selectKensaKekkaTblInput.IraiNendo = row.KensaIraiNendo;
                    // 連番
                    selectKensaKekkaTblInput.IraiRenban = row.KensaIraiRenban;
                    // 検索
                    ISelectKensaKekkaTblDAOutput selectKensaKekkaTblOutput = new SelectKensaKekkaTblDataAccess().Execute(selectKensaKekkaTblInput);

                    // 検査結果を一件毎に処理する
                    foreach (DataRow kensaKekkaRow in selectKensaKekkaTblOutput.KensaKekkaTbl)
                    {
                        // キー重複のチェック
                        if (output.KensaKekkaTbl.FindByKensaKekkaIraiHoteiKbnKensaKekkaIraiHokenjoCdKensaKekkaIraiNendoKensaKekkaIraiRenban(
                            kensaKekkaRow["KensaKekkaIraiHoteiKbn"].ToString(),
                            kensaKekkaRow["KensaKekkaIraiHokenjoCd"].ToString(),
                            kensaKekkaRow["KensaKekkaIraiNendo"].ToString(),
                            kensaKekkaRow["KensaKekkaIraiRenban"].ToString()) != null)
                        {
                            continue;
                        }

                        // レコードの追加
                        KensaKekkaTblDataSet.KensaKekkaTblRow newGaikanKensaRow = output.KensaKekkaTbl.NewKensaKekkaTblRow();

                        // 値の詰め替え
                        foreach (DataColumn col in output.KensaKekkaTbl.Columns)
                        {
                            newGaikanKensaRow[col.ColumnName] = kensaKekkaRow[col.ColumnName];
                        }

                        // レコードの登録
                        output.KensaKekkaTbl.AddKensaKekkaTblRow(newGaikanKensaRow);
                    }

                    #endregion

                    #region 再採水テーブル

                    // 再採水をサーバから取得
                    SelectSaiSaisuiTblDAInput selectSaiSaisuiTblInput = new SelectSaiSaisuiTblDAInput();
                    // 法定区分
                    selectSaiSaisuiTblInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                    // 保健所コード
                    selectSaiSaisuiTblInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                    // 年度
                    selectSaiSaisuiTblInput.IraiNendo = row.KensaIraiNendo;
                    // 連番
                    selectSaiSaisuiTblInput.IraiRenban = row.KensaIraiRenban;
                    // 検索
                    ISelectSaiSaisuiTblDAOutput selectSaiSaisuiTblOutput = new SelectSaiSaisuiTblDataAccess().Execute(selectSaiSaisuiTblInput);

                    // 再採水を一件毎に処理する
                    foreach (DataRow kensaKekkaRow in selectSaiSaisuiTblOutput.SaiSaisuiTbl)
                    {
                        // キー重複のチェック
                        if (output.SaiSaisuiTbl.FindBySaiSaisuiIraiHoteiKbnSaiSaisuiIraiHokenjoCdSaiSaisuiIraiNendoSaiSaisuiIraiRrenban(
                            kensaKekkaRow["SaiSaisuiIraiHoteiKbn"].ToString(),
                            kensaKekkaRow["SaiSaisuiIraiHokenjoCd"].ToString(),
                            kensaKekkaRow["SaiSaisuiIraiNendo"].ToString(),
                            kensaKekkaRow["SaiSaisuiIraiRrenban"].ToString()) != null)
                        {
                            continue;
                        }

                        // レコードの追加
                        SaiSaisuiTblDataSet.SaiSaisuiTblRow newGaikanKensaRow = output.SaiSaisuiTbl.NewSaiSaisuiTblRow();

                        // 値の詰め替え
                        foreach (DataColumn col in output.SaiSaisuiTbl.Columns)
                        {
                            newGaikanKensaRow[col.ColumnName] = kensaKekkaRow[col.ColumnName];
                        }

                        // レコードの登録
                        output.SaiSaisuiTbl.AddSaiSaisuiTblRow(newGaikanKensaRow);
                    }

                    #endregion
                    
                    #region 所見結果テーブル

                    // 所見結果をサーバから取得
                    SelectShokenKekkaTblDAInput selectShokenKekkaTblInput = new SelectShokenKekkaTblDAInput();
                    // 法定区分
                    selectShokenKekkaTblInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                    // 保健所コード
                    selectShokenKekkaTblInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                    // 年度
                    selectShokenKekkaTblInput.IraiNendo = row.KensaIraiNendo;
                    // 連番
                    selectShokenKekkaTblInput.IraiRenban = row.KensaIraiRenban;
                    // 検索
                    ISelectShokenKekkaTblDAOutput selectShokenKekkaTblOutput = new SelectShokenKekkaTblDataAccess().Execute(selectShokenKekkaTblInput);

                    // 所見結果を一件毎に処理する
                    foreach (DataRow shokenKekkaRow in selectShokenKekkaTblOutput.ShokenKekkaTbl)
                    {
                        // キー重複のチェック
                        if (output.ShokenKekkaTbl.FindByKensaIraiShokanIraiHoteiKbnKensaIraiShokenIraiHokenjoCdKensaIraiShokenIraiNendoKensaIraiShokenIraiRenbanKensaIraiShokenRenban(
                            shokenKekkaRow["KensaIraiShokanIraiHoteiKbn"].ToString(),
                            shokenKekkaRow["KensaIraiShokenIraiHokenjoCd"].ToString(),
                            shokenKekkaRow["KensaIraiShokenIraiNendo"].ToString(),
                            shokenKekkaRow["KensaIraiShokenIraiRenban"].ToString(),
                            shokenKekkaRow["KensaIraiShokenRenban"].ToString()) != null)
                        {
                            continue;
                        }

                        // レコードの追加
                        ShokenKekkaTblDataSet.ShokenKekkaTblRow newGaikanKensaRow = output.ShokenKekkaTbl.NewShokenKekkaTblRow();

                        // 値の詰め替え
                        foreach (DataColumn col in output.ShokenKekkaTbl.Columns)
                        {
                            newGaikanKensaRow[col.ColumnName] = shokenKekkaRow[col.ColumnName];
                        }

                        // レコードの登録
                        output.ShokenKekkaTbl.AddShokenKekkaTblRow(newGaikanKensaRow);
                    }

                    #endregion

                    #region 所見結果補足文テーブル

                    // 所見結果補足文をサーバから取得
                    SelectShokenKekkaHosokuTblDAInput selectShokenKekkaHosokuTblInput = new SelectShokenKekkaHosokuTblDAInput();
                    // 法定区分
                    selectShokenKekkaHosokuTblInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                    // 保健所コード
                    selectShokenKekkaHosokuTblInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                    // 年度
                    selectShokenKekkaHosokuTblInput.IraiNendo = row.KensaIraiNendo;
                    // 連番
                    selectShokenKekkaHosokuTblInput.IraiRenban = row.KensaIraiRenban;
                    // 検索
                    ISelectShokenKekkaHosokuTblDAOutput selectShokenKekkaHosokuTblOutput = new SelectShokenKekkaHosokuTblDataAccess().Execute(selectShokenKekkaHosokuTblInput);

                    // 所見結果補足文を一件毎に処理する
                    foreach (DataRow shokenKekkaRow in selectShokenKekkaHosokuTblOutput.ShokenKekkaHosokuTbl)
                    {
                        // キー重複のチェック
                        if (output.ShokenKekkaHosokuTbl.FindByKensaIraiShokanIraiHoteiKbnKensaIraiShokenIraiHokenjoCdKensaIraiShokenIraiNendoKensaIraiShokenIraiRenbanKensaIraiShokenRenbanKensaIraiShokenHosokuRenban(
                            shokenKekkaRow["KensaIraiShokanIraiHoteiKbn"].ToString(),
                            shokenKekkaRow["KensaIraiShokenIraiHokenjoCd"].ToString(),
                            shokenKekkaRow["KensaIraiShokenIraiNendo"].ToString(),
                            shokenKekkaRow["KensaIraiShokenIraiRenban"].ToString(),
                            shokenKekkaRow["KensaIraiShokenRenban"].ToString(),
                            shokenKekkaRow["KensaIraiShokenHosokuRenban"].ToString()) != null)
                        {
                            continue;
                        }

                        // レコードの追加
                        ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuTblRow newGaikanKensaRow = output.ShokenKekkaHosokuTbl.NewShokenKekkaHosokuTblRow();

                        // 値の詰め替え
                        foreach (DataColumn col in output.ShokenKekkaHosokuTbl.Columns)
                        {
                            newGaikanKensaRow[col.ColumnName] = shokenKekkaRow[col.ColumnName];
                        }

                        // レコードの登録
                        output.ShokenKekkaHosokuTbl.AddShokenKekkaHosokuTblRow(newGaikanKensaRow);
                    }

                    #endregion

                    #region モニタリングテーブル

                    // モニタリングをサーバから取得
                    SelectMonitoringTblDAInput selectMonitoringTblInput = new SelectMonitoringTblDAInput();
                    // 法定区分
                    selectMonitoringTblInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                    // 保健所コード
                    selectMonitoringTblInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                    // 年度
                    selectMonitoringTblInput.IraiNendo = row.KensaIraiNendo;
                    // 連番
                    selectMonitoringTblInput.IraiRenban = row.KensaIraiRenban;
                    // 検索
                    ISelectMonitoringTblDAOutput selectMonitoringTblOutput = new SelectMonitoringTblDataAccess().Execute(selectMonitoringTblInput);

                    // モニタリングを一件毎に処理する
                    foreach (DataRow kensaKekkaRow in selectMonitoringTblOutput.MonitoringTbl)
                    {
                        // キー重複のチェック
                        if (output.MonitoringTbl.FindByKensaIraiHoteiKbnKensaIraiHokenjoCdKensaIraiNendoKensaIraiRenbanMonitoringGroupCdMonitoringKbnMonitoringShosaiCd(
                            kensaKekkaRow["KensaIraiHoteiKbn"].ToString(),
                            kensaKekkaRow["KensaIraiHokenjoCd"].ToString(),
                            kensaKekkaRow["KensaIraiNendo"].ToString(),
                            kensaKekkaRow["KensaIraiRenban"].ToString(),
                            kensaKekkaRow["MonitoringGroupCd"].ToString(),
                            kensaKekkaRow["MonitoringKbn"].ToString(),
                            kensaKekkaRow["MonitoringShosaiCd"].ToString()) != null)
                        {
                            continue;
                        }

                        // レコードの追加
                        MonitoringTblDataSet.MonitoringTblRow newGaikanKensaRow = output.MonitoringTbl.NewMonitoringTblRow();

                        // 値の詰め替え
                        foreach (DataColumn col in output.MonitoringTbl.Columns)
                        {
                            newGaikanKensaRow[col.ColumnName] = kensaKekkaRow[col.ColumnName];
                        }

                        // レコードの登録
                        output.MonitoringTbl.AddMonitoringTblRow(newGaikanKensaRow);
                    }

                    #endregion

                    #region 外観検査結果テーブル

                    // 外観検査結果をサーバから取得
                    SelectGaikanKensaKekkaTblDAInput selectGaikanKensaKekkaTblInput = new SelectGaikanKensaKekkaTblDAInput();
                    // 法定区分
                    selectGaikanKensaKekkaTblInput.IraiHoteiKbn = row.KensaIraiHoteiKbn;
                    // 保健所コード
                    selectGaikanKensaKekkaTblInput.IraiHokenjoCd = row.KensaIraiHokenjoCd;
                    // 年度
                    selectGaikanKensaKekkaTblInput.IraiNendo = row.KensaIraiNendo;
                    // 連番
                    selectGaikanKensaKekkaTblInput.IraiRenban = row.KensaIraiRenban;
                    // 検索
                    ISelectGaikanKensaKekkaTblDAOutput selectGaikanKensaKekkaTblOutput = new SelectGaikanKensaKekkaTblDataAccess().Execute(selectGaikanKensaKekkaTblInput);

                    // 外観検査結果を一件毎に処理する
                    foreach (DataRow genbaShashinRow in selectGaikanKensaKekkaTblOutput.GaikanKensaKekkaTbl)
                    {
                        // キー重複のチェック
                        if (output.GaikanKensaKekkaTbl.FindByGaikanKensaKekkaIraiHoteiKbnGaikanKensaKekkaIraiHokenjoCdGaikanKensaKekkakuIraiNendoGaikanKensaKekkaIraiRenbanGaikanKensaKekkaRenban(
                            genbaShashinRow["GaikanKensaKekkaIraiHoteiKbn"].ToString(),
                            genbaShashinRow["GaikanKensaKekkaIraiHokenjoCd"].ToString(),
                            genbaShashinRow["GaikanKensaKekkakuIraiNendo"].ToString(),
                            genbaShashinRow["GaikanKensaKekkaIraiRenban"].ToString(),
                            genbaShashinRow["GaikanKensaKekkaRenban"].ToString()) != null)
                        {
                            continue;
                        }

                        // レコードの追加
                        GaikanKensaKekkaTblDataSet.GaikanKensaKekkaTblRow newGaikanKensaRow = output.GaikanKensaKekkaTbl.NewGaikanKensaKekkaTblRow();

                        // 値の詰め替え
                        foreach (DataColumn col in output.GaikanKensaKekkaTbl.Columns)
                        {
                            newGaikanKensaRow[col.ColumnName] = genbaShashinRow[col.ColumnName];
                        }

                        // レコードの登録
                        output.GaikanKensaKekkaTbl.AddGaikanKensaKekkaTblRow(newGaikanKensaRow);
                    }

                    #endregion

                    // 台帳のキー
                    string jokashoDaichoKey = string.Format("{0}_{1}_{2}", row.KensaIraiJokasoHokenjoCd, row.KensaIraiJokasoTorokuNendo, row.KensaIraiJokasoRenban);

                    // 未取得の場合のみ
                    if (!jokashoDaichoList.Contains(jokashoDaichoKey))
                    {
                        // 取得済みに追加
                        jokashoDaichoList.Add(jokashoDaichoKey);

                        #region 浄化槽台帳マスタ

                        // 浄化槽台帳をサーバから取得
                        ISelectJokasoDaichoMstDAInput selectJokasoDaichoMstInput = new SelectJokasoDaichoMstDAInput();
                        // 保健所コード
                        selectJokasoDaichoMstInput.HokenjoCd = row.KensaIraiJokasoHokenjoCd;
                        // 登録年度
                        selectJokasoDaichoMstInput.TorokuNendo = row.KensaIraiJokasoTorokuNendo;
                        // 連番
                        selectJokasoDaichoMstInput.Renban = row.KensaIraiJokasoRenban;
                        // 検索
                        ISelectJokasoDaichoMstDAOutput selectJokasoDaichoMstOutput = new SelectJokasoDaichoMstDataAccess().Execute(selectJokasoDaichoMstInput);

                        // 浄化槽台帳を一件毎に処理する
                        foreach (DataRow jokasoDaichoMstrow in selectJokasoDaichoMstOutput.JokasoDaichoMst)
                        {
                            // レコードの追加
                            JokasoDaichoMstDataSet.JokasoDaichoMstRow newJokasoDaichoMstRow = output.JokasoDaichoMst.NewJokasoDaichoMstRow();

                            // 値の詰め替え
                            foreach (DataColumn col in output.JokasoDaichoMst.Columns)
                            {
                                newJokasoDaichoMstRow[col.ColumnName] = jokasoDaichoMstrow[col.ColumnName];
                            }

                            // アップロード時の更新有無の確認の為、更新日時と登録日時を合わせておく
                            newJokasoDaichoMstRow.UpdateDt = newJokasoDaichoMstRow.InsertDt;

                            // レコードの登録
                            output.JokasoDaichoMst.AddJokasoDaichoMstRow(newJokasoDaichoMstRow);
                        }

                        #endregion

                        #region 浄化槽保有単位装置グループテーブル

                        // 浄化槽保有単位装置グループをサーバから取得
                        ISelectJokasoHoyuTaniSochiGroupTblDAInput selectJokasoHoyuTaniSochiGroupTblInput = new SelectJokasoHoyuTaniSochiGroupTblDAInput();
                        // 保健所コード
                        selectJokasoHoyuTaniSochiGroupTblInput.HokenjoCd = row.KensaIraiJokasoHokenjoCd;
                        // 登録年度
                        selectJokasoHoyuTaniSochiGroupTblInput.TorokuNendo = row.KensaIraiJokasoTorokuNendo;
                        // 連番
                        selectJokasoHoyuTaniSochiGroupTblInput.Renban = row.KensaIraiJokasoRenban;
                        // 検索
                        ISelectJokasoHoyuTaniSochiGroupTblDAOutput selectJokasoHoyuTaniSochiGroupTblOutput = new SelectJokasoHoyuTaniSochiGroupTblDataAccess().Execute(selectJokasoHoyuTaniSochiGroupTblInput);

                        // 浄化槽保有単位装置グループを一件毎に処理する
                        foreach (DataRow jokasoHoyuTaniSochiGroupTblrow in selectJokasoHoyuTaniSochiGroupTblOutput.JokasoHoyuTaniSochiGroupTbl)
                        {
                            // レコードの追加
                            JokasoHoyuTaniSochiGroupTblDataSet.JokasoHoyuTaniSochiGroupTblRow newJokasoHoyuTaniSochiGroupTblRow = output.JokasoHoyuTaniSochiGroupTbl.NewJokasoHoyuTaniSochiGroupTblRow();

                            // 値の詰め替え
                            foreach (DataColumn col in output.JokasoHoyuTaniSochiGroupTbl.Columns)
                            {
                                newJokasoHoyuTaniSochiGroupTblRow[col.ColumnName] = jokasoHoyuTaniSochiGroupTblrow[col.ColumnName];
                            }

                            // レコードの登録
                            output.JokasoHoyuTaniSochiGroupTbl.AddJokasoHoyuTaniSochiGroupTblRow(newJokasoHoyuTaniSochiGroupTblRow);
                        }

                        #endregion

                        #region 浄化槽定型メモテーブル

                        // 浄化槽定型メモをサーバから取得
                        ISelectJokasoMemoTblDAInput selectJokasoMemoTblInput = new SelectJokasoMemoTblDAInput();
                        // 保健所コード
                        selectJokasoMemoTblInput.HokenjoCd = row.KensaIraiJokasoHokenjoCd;
                        // 登録年度
                        selectJokasoMemoTblInput.TorokuNendo = row.KensaIraiJokasoTorokuNendo;
                        // 連番
                        selectJokasoMemoTblInput.Renban = row.KensaIraiJokasoRenban;
                        // 検索
                        ISelectJokasoMemoTblDAOutput selectJokasoMemoTblOutput = new SelectJokasoMemoTblDataAccess().Execute(selectJokasoMemoTblInput);

                        // 浄化槽定型メモを一件毎に処理する
                        foreach (DataRow jokasoMemoTblrow in selectJokasoMemoTblOutput.JokasoMemoTbl)
                        {
                            // レコードの追加
                            JokasoMemoTblDataSet.JokasoMemoTblRow newJokasoMemoTblRow = output.JokasoMemoTbl.NewJokasoMemoTblRow();

                            // 値の詰め替え
                            foreach (DataColumn col in output.JokasoMemoTbl.Columns)
                            {
                                newJokasoMemoTblRow[col.ColumnName] = jokasoMemoTblrow[col.ColumnName];
                            }

                            // レコードの登録
                            output.JokasoMemoTbl.AddJokasoMemoTblRow(newJokasoMemoTblRow);
                        }

                        #endregion

                        // 検査依頼の重複取得制御
                        List<string> kensaIraiList = new List<string>();

                        // 今回検査依頼のキー
                        string kensaIraiKey = string.Format("{0}_{1}_{2}_{3}", row.KensaIraiHoteiKbn, row.KensaIraiHokenjoCd, row.KensaIraiNendo, row.KensaIraiRenban);

                        // 取得済みに追加
                        kensaIraiList.Add(kensaIraiKey);
                        
                        // 検査依頼履歴をサーバから取得
                        ISelectKensaIraiTblByJokasoDaichoKeyDAInput selectKensaIraiTblByJokasoDaichoKeyInput = new SelectKensaIraiTblByJokasoDaichoKeyDAInput();
                        // 保健所コード
                        selectKensaIraiTblByJokasoDaichoKeyInput.HokenjoCd = row.KensaIraiJokasoHokenjoCd;
                        // 登録年度
                        selectKensaIraiTblByJokasoDaichoKeyInput.TorokuNendo = row.KensaIraiJokasoTorokuNendo;
                        // 連番
                        selectKensaIraiTblByJokasoDaichoKeyInput.Renban = row.KensaIraiJokasoRenban;
                        // 検索
                        ISelectKensaIraiTblByJokasoDaichoKeyDAOutput selectKensaIraiTblByJokasoDaichoKeyOutput =
                            new SelectKensaIraiTblByJokasoDaichoKeyDataAccess().Execute(selectKensaIraiTblByJokasoDaichoKeyInput);

                        // 検査依頼を一件毎に処理する
                        foreach (FukjBizSystem.Application.DataSet.KensaIraiTblDataSet.KensaIraiTblRow kensaIraiRow in selectKensaIraiTblByJokasoDaichoKeyOutput.KensaIraiTbl.Rows)
                        {
                            // 検査依頼のキー
                            kensaIraiKey = string.Format("{0}_{1}_{2}_{3}", kensaIraiRow.KensaIraiHoteiKbn, kensaIraiRow.KensaIraiHokenjoCd, kensaIraiRow.KensaIraiNendo, kensaIraiRow.KensaIraiRenban);
                            
                            // 未取得の場合のみ
                            if (!kensaIraiList.Contains(kensaIraiKey))
                            {
                                // 取得済みに追加
                                kensaIraiList.Add(kensaIraiKey);

                                #region 検査依頼(履歴)

                                // レコードの追加
                                KensaIraiHistTblDataSet.KensaIraiHistTblRow histRow = output.KensaIraiHistTbl.NewKensaIraiHistTblRow();

                                // 値の詰め替え
                                foreach (DataColumn col in selectKensaIraiTblByJokasoDaichoKeyOutput.KensaIraiTbl.Columns)
                                {
                                    histRow[col.ColumnName] = kensaIraiRow[col.ColumnName];
                                }

                                // レコードの登録
                                output.KensaIraiHistTbl.AddKensaIraiHistTblRow(histRow);

                                #endregion

                                #region 検査結果テーブル

                                // 検査結果をサーバから取得
                                SelectKensaKekkaTblDAInput selectKensaKekkaHistTblInput = new SelectKensaKekkaTblDAInput();
                                // 法定区分
                                selectKensaKekkaHistTblInput.IraiHoteiKbn = kensaIraiRow.KensaIraiHoteiKbn;
                                // 保健所コード
                                selectKensaKekkaHistTblInput.IraiHokenjoCd = kensaIraiRow.KensaIraiHokenjoCd;
                                // 年度
                                selectKensaKekkaHistTblInput.IraiNendo = kensaIraiRow.KensaIraiNendo;
                                // 連番
                                selectKensaKekkaHistTblInput.IraiRenban = kensaIraiRow.KensaIraiRenban;
                                // 検索
                                ISelectKensaKekkaTblDAOutput selectKensaKekkaHistTblOutput = new SelectKensaKekkaTblDataAccess().Execute(selectKensaKekkaHistTblInput);

                                // 検査結果を一件毎に処理する
                                foreach (DataRow kensaKekkaHistRow in selectKensaKekkaHistTblOutput.KensaKekkaTbl)
                                {
                                    // レコードの追加
                                    KensaKekkaTblDataSet.KensaKekkaTblRow newGaikanKensaRow = output.KensaKekkaTbl.NewKensaKekkaTblRow();

                                    // 値の詰め替え
                                    foreach (DataColumn col in output.KensaKekkaTbl.Columns)
                                    {
                                        newGaikanKensaRow[col.ColumnName] = kensaKekkaHistRow[col.ColumnName];
                                    }

                                    // レコードの登録
                                    output.KensaKekkaTbl.AddKensaKekkaTblRow(newGaikanKensaRow);
                                }

                                #endregion

                                #region 現場写真テーブル

                                // 現場写真をサーバから取得
                                SelectGenbaShashinTblDAInput selectGenbaShashinHistTblInput = new SelectGenbaShashinTblDAInput();
                                // 法定区分
                                selectGenbaShashinHistTblInput.IraiHoteiKbn = kensaIraiRow.KensaIraiHoteiKbn;
                                // 保健所コード
                                selectGenbaShashinHistTblInput.IraiHokenjoCd = kensaIraiRow.KensaIraiHokenjoCd;
                                // 年度
                                selectGenbaShashinHistTblInput.IraiNendo = kensaIraiRow.KensaIraiNendo;
                                // 連番
                                selectGenbaShashinHistTblInput.IraiRenban = kensaIraiRow.KensaIraiRenban;
                                // 検索
                                ISelectGenbaShashinTblDAOutput selectGenbaShashinHistTblOutput = new SelectGenbaShashinTblDataAccess().Execute(selectGenbaShashinHistTblInput);

                                // 現場写真を一件毎に処理する
                                foreach (DataRow genbaShashinRow in selectGenbaShashinHistTblOutput.GenbaShashinTbl)
                                {
                                    // レコードの追加
                                    GenbaShashinTblDataSet.GenbaShashinTblRow newGaikanKensaRow = output.GenbaShashinTbl.NewGenbaShashinTblRow();

                                    // 値の詰め替え
                                    foreach (DataColumn col in output.GenbaShashinTbl.Columns)
                                    {
                                        newGaikanKensaRow[col.ColumnName] = genbaShashinRow[col.ColumnName];
                                    }

                                    // レコードの登録
                                    output.GenbaShashinTbl.AddGenbaShashinTblRow(newGaikanKensaRow);
                                }

                                #endregion

                                #region 検査依頼関連ファイルテーブル

                                // 検査依頼関連ファイルをサーバから取得
                                SelectKensaIraiKanrenFileTblDAInput selectKensaIraiKanrenFileHistTblInput = new SelectKensaIraiKanrenFileTblDAInput();
                                // 法定区分
                                selectKensaIraiKanrenFileHistTblInput.IraiHoteiKbn = kensaIraiRow.KensaIraiHoteiKbn;
                                // 保健所コード
                                selectKensaIraiKanrenFileHistTblInput.IraiHokenjoCd = kensaIraiRow.KensaIraiHokenjoCd;
                                // 年度
                                selectKensaIraiKanrenFileHistTblInput.IraiNendo = kensaIraiRow.KensaIraiNendo;
                                // 連番
                                selectKensaIraiKanrenFileHistTblInput.IraiRenban = kensaIraiRow.KensaIraiRenban;
                                // 検索
                                ISelectKensaIraiKanrenFileTblDAOutput selectKensaIraiKanrenFileHistTblOutput = new SelectKensaIraiKanrenFileTblDataAccess().Execute(selectKensaIraiKanrenFileHistTblInput);

                                // 検査依頼関連ファイルを一件毎に処理する
                                foreach (DataRow kensaIraiKanrenFileRow in selectKensaIraiKanrenFileHistTblOutput.KensaIraiKanrenFileTbl)
                                {
                                    // レコードの追加
                                    KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblRow newGaikanKensaRow = output.KensaIraiKanrenFileTbl.NewKensaIraiKanrenFileTblRow();

                                    // 値の詰め替え
                                    foreach (DataColumn col in output.KensaIraiKanrenFileTbl.Columns)
                                    {
                                        newGaikanKensaRow[col.ColumnName] = kensaIraiKanrenFileRow[col.ColumnName];
                                    }

                                    // レコードの登録
                                    output.KensaIraiKanrenFileTbl.AddKensaIraiKanrenFileTblRow(newGaikanKensaRow);
                                }

                                #endregion
                            }
                        }
                    }
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
