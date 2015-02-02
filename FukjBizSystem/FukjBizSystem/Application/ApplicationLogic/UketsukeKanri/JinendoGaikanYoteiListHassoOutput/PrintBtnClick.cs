using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanYoteiListHassoOutput;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanYoteiListHassoOutput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALInput : IBseALInput, IGetJinendoGaikanYoteiListHassoOutputBySearchCondBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALInput : IPrintBtnClickALInput
    {
        /// <summary>
        /// SearchCond 
        /// </summary>
        public GaikanYoteiListHassoOutputSearchCond SearchCond { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("依頼No（開始）[{0}], 依頼No（終了）[{1}]",
                    string.Concat(SearchCond.HokenjoCdFrom, SearchCond.NendoFrom, SearchCond.RenbanFrom),
                    string.Concat(SearchCond.HokenjoCdTo, SearchCond.NendoTo, SearchCond.RenbanTo));
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALOutput : IPrintBtnClickALOutput
    {
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/26  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickApplicationLogic : BaseApplicationLogic<IPrintBtnClickALInput, IPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JinendoGaikanYoteiListHassoOutput：PrintBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintBtnClickApplicationLogic()
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
        /// 2014/09/26  HuyTX　　    新規作成
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
        /// 2014/09/26  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPrintBtnClickALOutput Execute(IPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPrintBtnClickALOutput output = new PrintBtnClickALOutput();

            try
            {
                KensaYoteiListWrkDataSet.KensaYoteiListWrkDataTable kensaYoteiListWrkDT = new KensaYoteiListWrkDataSet.KensaYoteiListWrkDataTable();
                try
                {

                    // トランザクション開始
                    StartTransaction();

                    //delete all data from KensaYoteiListWrk
                    IDeleteAllKensaYoteiListWrkBLInput deleteBLInput = new DeleteAllKensaYoteiListWrkBLInput();
                    new DeleteAllKensaYoteiListWrkBusinessLogic().Execute(deleteBLInput);

                    //search data
                    IGetJinendoGaikanYoteiListHassoOutputBySearchCondBLOutput searchBLOutput = new GetJinendoGaikanYoteiListHassoOutputBySearchCondBusinessLogic().Execute(input);

                    kensaYoteiListWrkDT = CreateKensaYoteiListWrkDataTable(searchBLOutput.JinendoGaikanYoteiListHassoOutputDataTable);

                    // Insert KensaYoteiListWrk
                    IUpdateKensaYoteiListWrkBLInput updateBLInput = new UpdateKensaYoteiListWrkBLInput();
                    updateBLInput.KensaYoteiListWrkDataTable = kensaYoteiListWrkDT;
                    new UpdateKensaYoteiListWrkBusinessLogic().Execute(updateBLInput);

                    // コミット
                    CompleteTransaction();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    // トランザクション終了
                    EndTransaction();
                }

                //Print data
                IPrintJinendoGaikanYoteiListHassoBLInput printBLInput = new PrintJinendoGaikanYoteiListHassoBLInput();
                printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder 
                    + string.Format("{0}", (input.SearchCond.Sort2 == "1") ? Properties.Settings.Default.JinendoGaikanYoteiListHasso1FormatFile : Properties.Settings.Default.JinendoGaikanYoteiListHasso2FormatFile);
                printBLInput.AfterPrintFlg = true;

                printBLInput.KensaYoteiListWrkDataTable = kensaYoteiListWrkDT;
                printBLInput.MakeList = input.SearchCond.MakeList;
                printBLInput.Sort1 = input.SearchCond.Sort1;
                printBLInput.Sort2 = input.SearchCond.Sort2;
                printBLInput.PrintType1 = input.SearchCond.PrintType1;
                printBLInput.PrintType2 = input.SearchCond.PrintType2;

                new PrintJinendoGaikanYoteiListHassoBusinessLogic().Execute(printBLInput);
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

        #region メソッド(private)

        #region CreateKensaYoteiListWrkDataTable
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateKensaYoteiListWrkDataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="JinendoGaikanDT"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/26  HuyTX　  新規作成
        /// 2014/11/19  HuyTX　  Ver1.03
        /// 2014/12/01  HuyTX　  Ver1.04
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private KensaYoteiListWrkDataSet.KensaYoteiListWrkDataTable CreateKensaYoteiListWrkDataTable(KensaYoteiListWrkDataSet.JinendoGaikanYoteiListHassoOutputDataTable JinendoGaikanDT)
        {
            KensaYoteiListWrkDataSet.KensaYoteiListWrkDataTable kensaYoteiListWrkDT = new KensaYoteiListWrkDataSet.KensaYoteiListWrkDataTable();

            DateTime currentDateTime = Boundary.Common.Common.GetCurrentTimestamp();
            string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
            string loginTarm = Dns.GetHostName();

            foreach (KensaYoteiListWrkDataSet.JinendoGaikanYoteiListHassoOutputRow jinendoGaikanRow in JinendoGaikanDT)
            {
                KensaYoteiListWrkDataSet.KensaYoteiListWrkRow newRow = kensaYoteiListWrkDT.NewKensaYoteiListWrkRow();

                //検査依頼法定区分
                newRow.KensaIraiHoteiKbn = jinendoGaikanRow.KensaIraiHoteiKbn;

                //検査依頼保健所コード
                newRow.KensaIraiHokenjoCd = jinendoGaikanRow.KensaIraiHokenjoCd;

                //検査依頼年度
                newRow.KensaIraiNendo = jinendoGaikanRow.KensaIraiNendo;

                //検査依頼連番
                newRow.KensaIraiRenban = jinendoGaikanRow.KensaIraiRenban;

                //支所コード
                newRow.ShishoCd = jinendoGaikanRow.KensaIraiUketsukeShishoKbn;

                //業者コード
                newRow.GyoshaCd = jinendoGaikanRow.JokasoItkatsuSeikyuGyoshaCd;

                //業者の名称
                newRow.GyoshaNm = jinendoGaikanRow.GyoshaNm;

                //業者の電話番号
                newRow.GyoshaTelNo = jinendoGaikanRow.GyoshaTelNo;

                //業者の郵便番号
                newRow.GyoshaZipCd = jinendoGaikanRow.GyoshaZipCd;

                //業者の住所
                newRow.GyoshaAdr = jinendoGaikanRow.GyoshaAdr;

                //市町村コード
                newRow.ShichosonCd = jinendoGaikanRow.JokasoGenChikuCd;

                //市町村名称
                newRow.ShichosonNm = jinendoGaikanRow.ChikuNm;

                //保健所コード
                newRow.HokenjoCd = jinendoGaikanRow.KensaIraiJokasoHokenjoCd;

                //MOD_Ver1.04 Start
                ////保健所の電話番号
                //newRow.HokenjoTelNo = jinendoGaikanRow.HokenjoTelNo;

                ////保健所の郵便番号
                //newRow.HokenjoZipCd = jinendoGaikanRow.HokenjoZipCd;

                ////保健所の住所
                //newRow.HokenjoAdr = jinendoGaikanRow.HokenjoAdr;

                //保健所の電話番号
                newRow.HokenjoTelNo = jinendoGaikanRow.ChikuTantoTelNo;

                //保健所の郵便番号
                newRow.HokenjoZipCd = jinendoGaikanRow.ChikuTantoYubinNo;

                //保健所の住所
                newRow.HokenjoAdr = jinendoGaikanRow.ChikuTantoAdr;
                //MOD_Ver1.04 End

                //検査予定年
                newRow.KensaYoteiNen = jinendoGaikanRow.KensaIraiKensaYoteiNen;

                //検査予定月
                newRow.KensaYoteiTsuki = jinendoGaikanRow.KensaIraiKensaYoteiTsuki;

                //検査予定日
                newRow.KensaYoteiBi = jinendoGaikanRow.KensaIraiKensaYoteiBi;

                //設置者名
                newRow.SetchishaNm = jinendoGaikanRow.KensaIraiSetchishaNm;

                //設置場所
                newRow.SetchibashoAdr = jinendoGaikanRow.JokasoSetchiBashoAdr;

                //処理区分
                newRow.ShorihoshikiKbn = jinendoGaikanRow.JokasoShoriHosikiKbn;

                //処理区分名称
                newRow.ShorihoshikiKbnNm = jinendoGaikanRow.ConstNm;

                //人槽
                newRow.Ninso = !jinendoGaikanRow.IsJokasoShoriTaishoJininNull() ? jinendoGaikanRow.JokasoShoriTaishoJinin.ToString() : string.Empty;

                //設置者区分
                newRow.SetchishaKbn = jinendoGaikanRow.JokasoSetchishaKbn;

                //設置者No
                newRow.SetchishaCd = jinendoGaikanRow.JokasoSetchishaCd;

                //人槽区分
                newRow.NinsoKbn = jinendoGaikanRow.NinsoKbn;

                //7条検査区分
                newRow.Jo7KensaKbn = string.Empty;

                //ADD_Ver1.03 Start
                //浄化槽台帳保健所コード
                newRow.JokasoHokenjoCd = jinendoGaikanRow.KensaIraiJokasoHokenjoCd;

                //浄化槽台帳登録年度
                newRow.JokasoTorokuNendo = jinendoGaikanRow.KensaIraiJokasoTorokuNendo;

                //浄化槽台帳連番
                newRow.JokasoRenban = jinendoGaikanRow.KensaIraiJokasoRenban;
                //ADD_Ver1.03 End

                //登録日
                newRow.InsertDt = currentDateTime;

                //登録者
                newRow.InsertUser = loginUser;

                //登録端末
                newRow.InsertTarm = loginTarm;

                //更新日
                newRow.UpdateDt = currentDateTime;

                //更新者
                newRow.UpdateUser = loginUser;

                //更新端末
                newRow.UpdateTarm = loginTarm;

                kensaYoteiListWrkDT.AddKensaYoteiListWrkRow(newRow);
                newRow.AcceptChanges();
                newRow.SetAdded();
            }
            
            return kensaYoteiListWrkDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
