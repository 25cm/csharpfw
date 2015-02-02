using System;
using System.IO;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.JokasoDaichoSyukeiList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.JokasoDaichoSyukeiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutputBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// ShutsuryokuChohyo 
        /// </summary>
        string ShutsuryokuChohyo { get; set; }

        /// <summary>
        /// JokasoDaichoSyukeiListDataTable
        /// </summary>
        JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable JokasoDaichoSyukeiListDataTable { get; set; }

        /// <summary>
        /// ShukeiKaishiNendo 
        /// </summary>
        int ShukeiKaishiNendo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickALInput : IOutputBtnClickALInput
    {
        /// <summary>
        /// ShutsuryokuChohyo 
        /// </summary>
        public string ShutsuryokuChohyo { get; set; }

        /// <summary>
        /// JokasoDaichoSyukeiListDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoSyukeiListDataTable JokasoDaichoSyukeiListDataTable { get; set; }

        /// <summary>
        /// ShukeiKaishiNendo 
        /// </summary>
        public int ShukeiKaishiNendo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("浄化槽台帳番号[{0}]", JokasoDaichoSyukeiListDataTable[0].jokasoNoCol);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IOutputBtnClickALOutput
    {
        /// <summary>
        /// IsError
        /// </summary>
        bool IsError { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickALOutput : IOutputBtnClickALOutput
    {
        /// <summary>
        /// IsError
        /// </summary>
        public bool IsError { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： OutputBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/28  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class OutputBtnClickApplicationLogic : BaseApplicationLogic<IOutputBtnClickALInput, IOutputBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JokasoDaichoSyukeiList：OutputBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： OutputBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/28  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public OutputBtnClickApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/28  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/10/28  HuyTX　    新規作成
        /// 2014/12/23  HuyTX　    Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IOutputBtnClickALOutput Execute(IOutputBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IOutputBtnClickALOutput output = new OutputBtnClickALOutput();

            try
            {

                StartTransaction();

                switch (input.ShutsuryokuChohyo)
                {
                    case "1":
                        #region (3) = ON

                        //print 027_不適正浄化槽一覧_帳票設計書.xlsx
                        IPrintFutekiseiJokasoBLInput printFutekiseiInput = new PrintFutekiseiJokasoBLInput();
                        printFutekiseiInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                        printFutekiseiInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.FutekiseiJokasoFormatFile);
                        printFutekiseiInput.AfterDispFlg = true;
                        printFutekiseiInput.JokasoDaichoSyukeiListDataTable = input.JokasoDaichoSyukeiListDataTable;
                        new PrintFutekiseiJokasoBusinessLogic().Execute(printFutekiseiInput);
                        break;

                        #endregion
                    case "2":
                        #region (4) = ON

                        //print 028_無管理浄化槽一覧_帳票設計書.xlsx
                        IPrintMukanriJokasoBLInput printMukanriBLInput = new PrintMukanriJokasoBLInput();
                        printMukanriBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                        printMukanriBLInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.MukanriJokasoFormatFile);
                        printMukanriBLInput.AfterDispFlg = true;
                        printMukanriBLInput.JokasoDaichoSyukeiListDataTable = input.JokasoDaichoSyukeiListDataTable;

                        new PrintMukanriJokasoBusinessLogic().Execute(printMukanriBLInput);

                        break;

                        #endregion
                    case "3":
                        #region (5) = ON

                        #region Update data

                        //delete all data in table IkoJokyoShukeiWrk
                        IDeleteAllIkoJokyoShukeiWrkBLInput delIkoJokyoBLInput = new DeleteAllIkoJokyoShukeiWrkBLInput();
                        new DeleteAllIkoJokyoShukeiWrkBusinessLogic().Execute(delIkoJokyoBLInput);

                        IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable ikoJokyoShukeiWrkDTInsert = new IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable();
                        IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable ikoJokyoShukeiWrkDTUpdate = new IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable();

                        IkoJokyoShukeiWrkDataSet.Kensa7JoKanryoDataTable kensa7JoKanryoDT = new IkoJokyoShukeiWrkDataSet.Kensa7JoKanryoDataTable();
                        IkoJokyoShukeiWrkDataSet.Kensa11JoKanryoDataTable kensa11JoKanryoDT = new IkoJokyoShukeiWrkDataSet.Kensa11JoKanryoDataTable();

                        for (int i = 0; i < 4; i++)
                        {
                            //get kensa7jo
                            IGetKensa7JoKanryoByKensaNendoBLInput getKensa7JoInput = new GetKensa7JoKanryoByKensaNendoBLInput();
                            getKensa7JoInput.KensaIraiNendo = (input.ShukeiKaishiNendo + i).ToString();
                            IGetKensa7JoKanryoByKensaNendoBLOutput getKensa7JoOutput = new GetKensa7JoKanryoByKensaNendoBusinessLogic().Execute(getKensa7JoInput);
                            if (getKensa7JoOutput.Kensa7JoKanryoDataTable != null && getKensa7JoOutput.Kensa7JoKanryoDataTable.Count > 0)
                            {
                                kensa7JoKanryoDT.Merge(getKensa7JoOutput.Kensa7JoKanryoDataTable);
                            }

                            //get kensa11jo
                            IGetKensa11JoKanryoByKensaNendoBLInput getKensa11JoInput = new GetKensa11JoKanryoByKensaNendoBLInput();
                            getKensa11JoInput.KensaIraiNendo = (input.ShukeiKaishiNendo + i).ToString();
                            IGetKensa11JoKanryoByKensaNendoBLOutput getKensa11JoOutput = new GetKensa11JoKanryoByKensaNendoBusinessLogic().Execute(getKensa11JoInput);
                            if (getKensa11JoOutput.Kensa11JoKanryoDataTable != null && getKensa11JoOutput.Kensa11JoKanryoDataTable.Count > 0)
                            {
                                kensa11JoKanryoDT.Merge(getKensa11JoOutput.Kensa11JoKanryoDataTable);
                            }   
                        }

                        //insert
                        ikoJokyoShukeiWrkDTInsert = CreateIkoJokyoShukeiWrkInsert(kensa7JoKanryoDT);
                        UpdateIkoJokyoShukeiWrk(ikoJokyoShukeiWrkDTInsert, true);
                        
                        //update
                        ikoJokyoShukeiWrkDTUpdate = CreateIkoJokyoShukeiWrkUpdate(kensa11JoKanryoDT, ikoJokyoShukeiWrkDTInsert);
                        UpdateIkoJokyoShukeiWrk(ikoJokyoShukeiWrkDTUpdate, false);

                        #endregion

                        #region Print data

                        //print 025_7条⇒11条検査移行状況表_帳票設計書.xlsx
                        IGetKensa7To11JoIkoJokyoBLInput getKensa7To11JoInput = new GetKensa7To11JoIkoJokyoBLInput();
                        IGetKensa7To11JoIkoJokyoBLOutput getKensa7To11JoOutput = new GetKensa7To11JoIkoJokyoBusinessLogic().Execute(getKensa7To11JoInput);

                        IPrintKensa7To11JoIkoJokyoBLInput printKensa7To11JoInput = new PrintKensa7To11JoIkoJokyoBLInput();
                        printKensa7To11JoInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                        printKensa7To11JoInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.Kensa7To11JoIkoJokyoFormatFile);
                        printKensa7To11JoInput.AfterDispFlg = true;
                        printKensa7To11JoInput.ShukeiKaishiNendo = input.ShukeiKaishiNendo;
                        printKensa7To11JoInput.Kensa7To11JoIkoJokyoDataTable = getKensa7To11JoOutput.Kensa7To11JoIkoJokyoDataTable;

                        new PrintKensa7To11JoIkoJokyoBusinessLogic().Execute(printKensa7To11JoInput);

                        #endregion

                        break;

                        #endregion
                    case "4":
                        #region (6) = ON

                        //print 026_11条検査未受験一覧_帳票設計書.xlsx
                        IPrint11JoKensaMijukenBLInput print11JoKensaInput = new Print11JoKensaMijukenBLInput();
                        print11JoKensaInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                        print11JoKensaInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.Kensa11JoMijukenFormatFile);
                        print11JoKensaInput.AfterDispFlg = true;
                        print11JoKensaInput.JokasoDaichoSyukeiListDataTable = input.JokasoDaichoSyukeiListDataTable;
                        new Print11JoKensaMijukenBusinessLogic().Execute(print11JoKensaInput);
                        break;

                        #endregion
                    case "5":
                        #region (7) = ON
                        //Ver1.03 Start
                        IExecProcShoyouSanteiJininShukeiStdBLInput execInput = new ExecProcShoyouSanteiJininShukeiStdBLInput();
                        execInput.Nendo = input.ShukeiKaishiNendo;
                        IExecProcShoyouSanteiJininShukeiStdBLOutput execOutput = new ExecProcShoyouSanteiJininShukeiStdBusinessLogic().Execute(execInput);
                        if (!string.IsNullOrEmpty(execOutput.ErrorFlg))
                        {
                            output.IsError = true;
                            return output;
                        }

                        //print 050_所要算定人員予測_帳票設計書.xlsx
                        IPrintShoyoSanteiJininBLInput printShoyoSanteiJininInput = new PrintShoyoSanteiJininBLInput();
                        printShoyoSanteiJininInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                        printShoyoSanteiJininInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.ShoyoSanteiJininFormatFile);
                        printShoyoSanteiJininInput.AfterDispFlg = true;
                        printShoyoSanteiJininInput.ShukeiKaishiNendo = input.ShukeiKaishiNendo;
                        new PrintShoyoSanteiJininBusinessLogic().Execute(printShoyoSanteiJininInput);
                        //Ver1.03 End

                        #endregion
                        break;
                    default:
                        break;
                }

                CompleteTransaction();

            }
            catch
            {
                if (input.ShutsuryokuChohyo == "3" || input.ShutsuryokuChohyo == "5")
                {
                    output.IsError = true;
                }
                else
                {
                    throw;
                }

            }
            finally
            {
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CreateIkoJokyoShukeiWrkInsert
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateIkoJokyoShukeiWrkInsert
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensa7JoDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable CreateIkoJokyoShukeiWrkInsert(IkoJokyoShukeiWrkDataSet.Kensa7JoKanryoDataTable kensa7JoDT)
        {
            IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable insertDT = new IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable();
            DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            foreach (IkoJokyoShukeiWrkDataSet.Kensa7JoKanryoRow kensa7JoRow in kensa7JoDT.Rows)
            {
                IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkRow newRow = insertDT.NewIkoJokyoShukeiWrkRow();
                
                //検査依頼保健所コード
                newRow.KensaIraiHokenjoCd = kensa7JoRow.KensaIraiHokenjoCd;

                //現地区コード
                newRow.JokasoGenChikuCd = !kensa7JoRow.IsJokasoGenChikuCdNull() ? kensa7JoRow.JokasoGenChikuCd : String.Empty;	//受入20141226 mod DbNull care.

                //検査依頼年度
                newRow.KensaIraiNendo = kensa7JoRow.KensaIraiNendo;

                //7条実施数
                newRow.Kensa7JoJisshiCnt = kensa7JoRow.Cnt;

                //移行済数
                newRow.IkoSumiCnt = 0;

                //登録日
                newRow.InsertDt = currentDateTime;

                //登録者
                newRow.InsertUser = loginUser;

                //登録端末
                newRow.InsertTarm = Dns.GetHostName();

                //更新日
                newRow.UpdateDt = currentDateTime;

                //更新者
                newRow.UpdateUser = loginUser;

                //更新端末
                newRow.UpdateTarm = Dns.GetHostName();

                insertDT.AddIkoJokyoShukeiWrkRow(newRow);
                insertDT.AcceptChanges();
                newRow.SetAdded();
            }

            return insertDT;
        }
        #endregion

        #region CreateIkoJokyoShukeiWrkUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateIkoJokyoShukeiWrkUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <param name="kensa11JoDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable CreateIkoJokyoShukeiWrkUpdate(IkoJokyoShukeiWrkDataSet.Kensa11JoKanryoDataTable kensa11JoDT, 
                                                                                                  IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable ikoJokyoShukeiWrkDTInsert)
        {
            IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable updateDT = new IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable();
            DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            foreach (IkoJokyoShukeiWrkDataSet.Kensa11JoKanryoRow kensa11JoRow in kensa11JoDT.Rows)
            {

				//受入20141226 mod DbNull care.
                IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkRow[] ikoJokyoShukeiWrkRows = (IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkRow[])
					ikoJokyoShukeiWrkDTInsert.Select(string.Format("KensaIraiHokenjoCd = '{0}' AND JokasoGenChikuCd = '{1}' AND KensaIraiNendo = '{2}'", 
						kensa11JoRow.KensaIraiHokenjoCd,
						!kensa11JoRow.IsJokasoGenChikuCdNull() ? kensa11JoRow.JokasoGenChikuCd : String.Empty, 
						kensa11JoRow.KensaIraiNendo));
                if (ikoJokyoShukeiWrkRows.Length > 0)
                {
                    //移行済数
                    ikoJokyoShukeiWrkRows[0].IkoSumiCnt = kensa11JoRow.Cnt;

                    //更新日
                    ikoJokyoShukeiWrkRows[0].UpdateDt = currentDateTime;

                    //更新者
                    ikoJokyoShukeiWrkRows[0].UpdateUser = loginUser;

                    //更新端末
                    ikoJokyoShukeiWrkRows[0].UpdateTarm = Dns.GetHostName();

                    updateDT.ImportRow(ikoJokyoShukeiWrkRows[0]);
                }
            }

            return updateDT;
        }
        #endregion

        #region UpdateIkoJokyoShukeiWrk
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： UpdateIkoJokyoShukeiWrk
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ikoJokyoShukeiWrkDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30  HuyTX　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private void UpdateIkoJokyoShukeiWrk(IkoJokyoShukeiWrkDataSet.IkoJokyoShukeiWrkDataTable ikoJokyoShukeiWrkDT, bool isInsert)
        {
            IUpdateIkoJokyoShukeiWrkBLInput updateInput = new UpdateIkoJokyoShukeiWrkBLInput();
            updateInput.IkoJokyoShukeiWrkDataTable = ikoJokyoShukeiWrkDT;
            updateInput.IsInsert = isInsert;
            new UpdateIkoJokyoShukeiWrkBusinessLogic().Execute(updateInput);
        }
        #endregion

        #endregion
    }
    #endregion
}
