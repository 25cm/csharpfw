using System;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiListOutput;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.JinendoGaikanKensaYoteiListOutput
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
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable ZenkaiKensaDataWrkKensakuDT { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }

        /// <summary>
        /// GyoshaCdFrom
        /// </summary>
        string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        string GyoshaCdTo { get; set; }
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
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALInput : IPrintBtnClickALInput
    {
        /// <summary>
        /// ZenkaiKensaDataWrkKensakuDataTable
        /// </summary>
        public ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable ZenkaiKensaDataWrkKensakuDT { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// GyoshaCdFrom
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// GyoshaCdTo
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
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
    /// 2014/11/20  DatNT　  新規作成
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
    /// 2014/11/20  DatNT　  新規作成
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
    /// 2014/11/20  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickApplicationLogic : BaseApplicationLogic<IPrintBtnClickALInput, IPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "JinendoGaikanKensaYoteiListOutput：PrintBtnClickApplicationLogic";

        /// <summary>
        /// Login User
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// PC Update
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        ///// <summary>
        ///// Print DT
        ///// </summary>
        //private ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable _printDT;

        ///// <summary>
        ///// Update DT
        ///// </summary>
        //private JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable _updateDT;

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
        /// 2014/11/20  DatNT　  新規作成
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
        /// 2014/11/20  DatNT　  新規作成
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
        /// 2014/11/20  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPrintBtnClickALOutput Execute(IPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPrintBtnClickALOutput output = new PrintBtnClickALOutput();

            try
            {
                //DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

                //CreateDT(input, now);

                // 20141124 AnhNV ADD Start
                // Print 061

                //IGetZenkaiKensaDataWrkBySearchCondBLInput blInput = new GetZenkaiKensaDataWrkBySearchCondBLInput();
                //blInput.GyoshaCdFrom = input.GyoshaCdFrom;
                //blInput.GyoshaCdTo = input.GyoshaCdTo;
                //blInput.Nendo = input.Nendo;
                //blInput.ExistFlg = true;
                //IGetZenkaiKensaDataWrkBySearchCondBLOutput blOutput = new GetZenkaiKensaDataWrkBySearchCondBusinessLogic().Execute(blInput);

                IPrintJiNendoGaikanKensaYoteiListBLInput printInp = new PrintJiNendoGaikanKensaYoteiListBLInput();
                printInp.AfterDispFlg = false;
                printInp.AfterPrintFlg = true;
                printInp.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.JinendoGaikanKensaYoteiListFormatFile;
                printInp.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printInp.Nendo = input.Nendo;
                printInp.PrintTable = input.ZenkaiKensaDataWrkKensakuDT;
                new PrintJiNendoGaikanKensaYoteiListBusinessLogic().Execute(printInp);
                // 20141124 AnhNV ADD End

                #region DB update

                try
                {
                    StartTransaction();

                    DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

                    //// Insert
                    //IUpdateJinendoGaikanYoteiOutputTblBLInput insertInput = new UpdateJinendoGaikanYoteiOutputTblBLInput();
                    //insertInput.JinendoGaikanYoteiOutputTblDT = _updateDT;
                    //IUpdateJinendoGaikanYoteiOutputTblBLOutput insertOutput = new UpdateJinendoGaikanYoteiOutputTblBusinessLogic().Execute(insertInput);

                    IInsertJinendoGaikenStep7BLInput insertInput = new InsertJinendoGaikenStep7BLInput();
                    insertInput.GyoshaCdFrom = input.GyoshaCdFrom;
                    insertInput.GyoshaCdTo = input.GyoshaCdTo;
                    insertInput.Nendo = input.Nendo;
                    insertInput.Now = now;
                    IInsertJinendoGaikenStep7BLOutput insertOutput = new InsertJinendoGaikenStep7BusinessLogic().Execute(insertInput);

                    CompleteTransaction();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    EndTransaction();
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

        #region private 

        #region CreateDT
        // 2014/12/04 DatNT DEL
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： CreateDT
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/11/24　DatNT    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private void CreateDT(IPrintBtnClickALInput input, DateTime now)
        //{
        //    // Print DT
        //    ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable printDT = new ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuDataTable();

        //    // UpdateDT
        //    JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable updateDT = new JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblDataTable();

        //    foreach (ZenkaiKensaDataWrkDataSet.ZenkaiKensaDataWrkKensakuRow row in input.ZenkaiKensaDataWrkKensakuDT)
        //    {
        //        IGetJinendoGaikanYoteiOutputTblByKeyBLInput blInput = new GetJinendoGaikanYoteiOutputTblByKeyBLInput();
        //        blInput.Nendo = input.Nendo;
        //        blInput.JokasoHokenjoCd = row.JokasoHokenjoCd;
        //        blInput.JokasoTorokuNendo = row.JokasoTorokuNendo;
        //        blInput.JokasoRenban = row.JokasoRenban;
        //        IGetJinendoGaikanYoteiOutputTblByKeyBLOutput blOutput = new GetJinendoGaikanYoteiOutputTblByKeyBusinessLogic().Execute(blInput);

        //        if (blOutput.JinendoGaikanYoteiOutputTblDT == null || blOutput.JinendoGaikanYoteiOutputTblDT.Count == 0)
        //        {
        //            JinendoGaikanYoteiOutputTblDataSet.JinendoGaikanYoteiOutputTblRow updateRow = updateDT.NewJinendoGaikanYoteiOutputTblRow();

        //            // 年度
        //            updateRow.Nendo = input.Nendo;

        //            // 浄化槽台帳保健所コード
        //            updateRow.JokasoHokenjoCd = row.JokasoHokenjoCd;

        //            // 浄化槽台帳年度
        //            updateRow.JokasoTorokuNendo = row.JokasoTorokuNendo;

        //            // 浄化槽台帳連番
        //            updateRow.JokasoRenban = row.JokasoRenban;

        //            // 前回検査日
        //            updateRow.ZenkaiKensaDt = row.ZenkaiKensaDt;

        //            // 人槽区分
        //            updateRow.NinsoKbn = row.NinsoKbn;

        //            // 検査区分
        //            updateRow.KensaKbn = row.KensaKbn;

        //            // 処理方式
        //            updateRow.ShoriHoshikiKbn = row.ShoriHoshikiKbn;

        //            // 業者コード
        //            updateRow.SeikyuGyoshaCd = string.Empty;

        //            // 予定年月
        //            if (!row.IsZenkaiKensaDtNull())
        //            {
        //                if (!string.IsNullOrEmpty(row.ZenkaiKensaDt))
        //                {
        //                    updateRow.YoteiNengetsu = (Convert.ToInt32(row.ZenkaiKensaDt.Substring(0, 4)) + 1) + row.ZenkaiKensaDt.Substring(4, 2);
        //                }
        //            }

        //            // 依頼作成区分
        //            updateRow.IraiMakeKbn = "0";

        //            // 連携作成区分
        //            updateRow.RenkeiMakeKbn = "1";

        //            updateRow.InsertDt = now;
        //            updateRow.InsertTarm = pcUpdate;
        //            updateRow.InsertUser = loginUser;
        //            updateRow.UpdateDt = now;
        //            updateRow.UpdateTarm = pcUpdate;
        //            updateRow.UpdateUser = loginUser;

        //            updateDT.AddJinendoGaikanYoteiOutputTblRow(updateRow);
        //            updateRow.AcceptChanges();
        //            updateRow.SetAdded();

        //            printDT.ImportRow(row);
        //        }
        //    }

        //    _updateDT = updateDT;

        //    _printDT = printDT;
        //}
        #endregion

        #endregion
    }
    #endregion
}
