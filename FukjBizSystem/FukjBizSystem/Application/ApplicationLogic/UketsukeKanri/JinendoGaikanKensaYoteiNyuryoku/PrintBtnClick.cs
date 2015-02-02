using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiNyuryoku
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
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 作成年度
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        DateTime SystemDt { get; set; }

        /// <summary>
        /// 作成年度
        /// </summary>
        JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable JinendoGaikanKensaYoteiNyuryokuDataTable { get; set; }
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
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALInput : IPrintBtnClickALInput
    {
        /// <summary>
        /// 作成年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// 作成年度
        /// </summary>
        public JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanKensaYoteiNyuryokuDataTable JinendoGaikanKensaYoteiNyuryokuDataTable { get; set; }

        /// <summary>
        /// システム日付
        /// </summary>
        public DateTime SystemDt { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("作成年度 [{0}],  ",
                    new string[] {
                        Nendo, });
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
    /// 2014/11/25　HieuNH　　　新規作成
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
    /// 2014/11/25　HieuNH　　　新規作成
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
    /// 2014/11/25　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickApplicationLogic : BaseApplicationLogic<IPrintBtnClickALInput, IPrintBtnClickALOutput>
    {
        #region プロパティ

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JinendoGaikanKensaYoteiNyuryoku：PrintBtnClick";

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
        /// 2014/11/25　HieuNH　　　新規作成
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
        /// 2014/11/25　HieuNH　　　新規作成
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
        /// 2014/11/25　HieuNH　　　新規作成
        /// 2014/12/15　HieuNH　　　Check ZenkaiKensaDt null
        /// 2014/12/15　kiyokuni    DateTime.TryParseはyyyymmddを判定できないため廃止、印刷後の楽観ロック対策
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPrintBtnClickALOutput Execute(IPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPrintBtnClickALOutput output = new PrintBtnClickALOutput();

            try
            {
                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();
                string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;
                string pcUpdate = Dns.GetHostName();

                try
                {
                    // トランザクション開始
                    StartTransaction();

                    #region Update JinendoGaikanYoteiOutputTblDataTable

                    JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable jinendoGaikanYoteiOutputTblDataTable = new JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable();

                    // 一覧をループしながら更新処理を行う。
                    for (int i = 0; i < input.JinendoGaikanKensaYoteiNyuryokuDataTable.Count; i++)
                    {
                        if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsJokasoNoNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoNo))
                            continue;

                        IGetJinendoGaikanYoteiOutputTblByKeyBLInput blInput = new GetJinendoGaikanYoteiOutputTblByKeyBLInput();
                        blInput.Nendo = input.Nendo;
                        blInput.JokasoHokenjoCd = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoHokenjoCd;
                        blInput.JokasoTorokuNendo = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoTorokuNendo;
                        blInput.JokasoRenban = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoRenban;
                        IGetJinendoGaikanYoteiOutputTblByKeyBLOutput blOutput = new GetJinendoGaikanYoteiOutputTblByKeyBusinessLogic().Execute(blInput);

                        if (blOutput.JinendoGaikanYoteiOutputTblDT.Count > 0)
                        {
                            // UPDATE
                            // Check Rakkan Lock
                            if (blOutput.JinendoGaikanYoteiOutputTblDT[0].UpdateDt != input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].UpdateDt)
                            {
                                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
                            }

                            // 更新日
                            blOutput.JinendoGaikanYoteiOutputTblDT[0].UpdateDt = now;

                            // 更新者
                            blOutput.JinendoGaikanYoteiOutputTblDT[0].UpdateUser = loginUser;

                            // 更新端末
                            blOutput.JinendoGaikanYoteiOutputTblDT[0].UpdateTarm = pcUpdate;

                            // 業者コード
                            blOutput.JinendoGaikanYoteiOutputTblDT[0].SeikyuGyoshaCd = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].SeikyuGyoshaCd;

                            //// MODIFY HieuNH 2014/12/15 BEGIN
                            // 予定年月
                            // MM
                            string mm = string.Empty;
                            //if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                            //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsZenkaiKensaDtNull() ? "01" : input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                            //else
                            //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                            //// yyyy
                            string yyyy = string.Empty;
                            //if (int.Parse(mm) >= 4)
                            //    yyyy = input.Nendo;
                            //else
                            //    yyyy = (int.Parse(input.Nendo) + 1).ToString();
                            //blOutput.JinendoGaikanYoteiOutputTblDT[0].YoteiNengetsu = yyyy + mm;
                            bool isValid = true;

                            //DateTime zenkaikensaDt;
                            if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                            {
                                if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsZenkaiKensaDtNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt))
                                    isValid = false;
                                else
                                {
                                    if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Length == 8)
                                        mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                                    //if (DateTime.TryParse(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt, out zenkaikensaDt))
                                    //    mm = zenkaikensaDt.Month.ToString().PadLeft(2, '0');
                                    else
                                        isValid = false;
                                }
                            }
                            else
                            {
                                mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                            }
                            if (isValid)
                            {
                                if (int.Parse(mm) >= 4)
                                    yyyy = input.Nendo;
                                else
                                    yyyy = (int.Parse(input.Nendo) + 1).ToString();
                                blOutput.JinendoGaikanYoteiOutputTblDT[0].YoteiNengetsu = yyyy + mm;
                            }
                            else
                                blOutput.JinendoGaikanYoteiOutputTblDT[0].YoteiNengetsu = string.Empty;

                            //// MODIFY HieuNH 2014/12/15 END

                            // 依頼作成区分
                            //blOutput.JinendoGaikanYoteiOutputTblDT[0].IraiMakeKbn = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].Sakusei;
                            //blOutput.JinendoGaikanYoteiOutputTblDT[0].IraiMakeKbn = "0";

                            jinendoGaikanYoteiOutputTblDataTable.ImportRow(blOutput.JinendoGaikanYoteiOutputTblDT[0]);
                        }
                        else
                        {
                            // INSERT

                            JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblRow newRow = jinendoGaikanYoteiOutputTblDataTable.NewJinendoGaikanYoteiOutputTblRow();

                            // 年度
                            newRow.Nendo = input.Nendo;

                            // 浄化槽台帳保健所コード
                            newRow.JokasoHokenjoCd = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoHokenjoCd;

                            // 浄化槽台帳年度
                            newRow.JokasoTorokuNendo = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoTorokuNendo;

                            // 浄化槽台帳連番
                            newRow.JokasoRenban = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].JokasoRenban;

                            // 登録日時
                            newRow.InsertDt = now;

                            // 登録者
                            newRow.InsertUser = loginUser;

                            // 登録端末
                            newRow.InsertTarm = pcUpdate;

                            // 更新日
                            newRow.UpdateDt = now;

                            // 更新者
                            newRow.UpdateUser = loginUser;

                            // 更新端末
                            newRow.UpdateTarm = pcUpdate;

                            // 業者コード
                            newRow.SeikyuGyoshaCd = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].SeikyuGyoshaCd;

                            //// MODIFY HieuNH 2014/12/15 BEGIN
                            // 予定年月
                            // MM
                            string mm = string.Empty;
                            //if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                            //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsZenkaiKensaDtNull() ? "01" : input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                            //else
                            //    mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                            //// yyyy
                            string yyyy = string.Empty;
                            //if (int.Parse(mm) >= 4)
                            //    yyyy = input.Nendo;
                            //else
                            //    yyyy = (int.Parse(input.Nendo) + 1).ToString();
                            //newRow.YoteiNengetsu = yyyy + mm;
                            bool isValid = true;

                            //DateTime zenkaikensaDt;
                            if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsYoteiNengetsuDispNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp))
                            {
                                if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].IsZenkaiKensaDtNull() || string.IsNullOrEmpty(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt))
                                    isValid = false;
                                else
                                {
                                    if (input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Length == 8)
                                        mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt.Substring(4, 2);
                                    //if (DateTime.TryParse(input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].ZenkaiKensaDt, out zenkaikensaDt))
                                    //    mm = zenkaikensaDt.Month.ToString().PadLeft(2, '0');
                                    else
                                        isValid = false;
                                }
                            }
                            else
                            {
                                mm = input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].YoteiNengetsuDisp;
                            }
                            if (isValid)
                            {
                                if (int.Parse(mm) >= 4)
                                    yyyy = input.Nendo;
                                else
                                    yyyy = (int.Parse(input.Nendo) + 1).ToString();
                                newRow.YoteiNengetsu = yyyy + mm;
                            }
                            else
                                newRow.YoteiNengetsu = string.Empty;

                            //// MODIFY HieuNH 2014/12/15 END

                            // 依頼作成区分
                            newRow.IraiMakeKbn = "0";

                            // 連携作成区分
                            newRow.RenkeiMakeKbn = "2";

                            jinendoGaikanYoteiOutputTblDataTable.AddJinendoGaikanYoteiOutputTblRow(newRow);
                        }
                    }

                    IUpdateJinendoGaikanYoteiOutputTblBLInput updateBLInput = new UpdateJinendoGaikanYoteiOutputTblBLInput();
                    updateBLInput.JinendoGaikanYoteiOutputTblDT = jinendoGaikanYoteiOutputTblDataTable;
                    new UpdateJinendoGaikanYoteiOutputTblBusinessLogic().Execute(updateBLInput);

                    #endregion

                    CompleteTransaction();

                    //連続処理時の楽観ロック対策
                    // 一覧をループしながら更新処理を行う。
                    for (int i = 0; i < input.JinendoGaikanKensaYoteiNyuryokuDataTable.Count; i++)
                    {
                        input.JinendoGaikanKensaYoteiNyuryokuDataTable[i].UpdateDt = now;
                    }

                }
                catch
                {
                    throw;
                }
                finally
                {
                    EndTransaction();
                }

                IPrintJinendoGaikanKensaYoteiBLInput blPrintInput = new PrintJinendoGaikanKensaYoteiBLInput();
                blPrintInput.AfterDispFlg = true;
                blPrintInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.JinendoGaikanIraiFormatFile;
                blPrintInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                blPrintInput.Nendo = input.Nendo;
                blPrintInput.SystemDt = input.SystemDt;
                new PrintJinendoGaikanKensaYoteiBusinessLogic().Execute(blPrintInput);
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
