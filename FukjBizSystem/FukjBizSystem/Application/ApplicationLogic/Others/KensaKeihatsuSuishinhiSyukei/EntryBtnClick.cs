using System;
using System.Collections.Generic;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiSyukei;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.KensaKeihatsuSuishinhiSyukei
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IEntryBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// 2014/10/16  DatNT    v1.03
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IEntryBtnClickALInput : IBseALInput //, IDeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput
    {
        // 2014/10/16 DatNT v1.03 ADD Start
        /// <summary>
        /// 業者コードFROM
        /// </summary>
        string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コードTO
        /// </summary>
        string GyoshaCdTo { get; set; }

        /// <summary>
        /// SaibanNo
        /// </summary>
        string SaibanNo { get; set; }

        /// <summary>
        /// 集計年月(開始)
        /// </summary>
        string ShukeiFromNengetsu { get; set; }

        /// <summary>
        /// 集計年月(終了)
        /// </summary>
        string ShukeiToNengetsu { get; set; }

        // 2014/10/16 DatNT v1.03 ADD End

        /// <summary>
        /// 支払日
        /// </summary>
        DateTime ShiharaiDt { get; set; }

        /// <summary>
        /// 開始日
        /// </summary>
        string KaishiDt { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        string ShuryoDt { get; set; }

        ///// <summary>
        ///// RegisterCheck
        ///// </summary>
        //bool RegisterCheck { get; set; }

        ///// <summary>
        ///// ReCreateCheck
        ///// </summary>
        //bool ReCreateCheck { get; set; }

        /// <summary>
        /// Step processing
        /// </summary>
        int StepProcessing { get; set; }

        /// <summary>
        /// HasError
        /// </summary>
        bool HasError { get; set; }

        ///// <summary>
        ///// DataTableInput
        ///// </summary>
        //KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable DataTableInput { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EntryBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// 2014/10/16  DatNT    v1.03
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class EntryBtnClickALInput : IEntryBtnClickALInput
    {
        // 2014/10/16 DatNT v1.03 DEL Start
        ///// <summary>
        ///// 年度 
        ///// </summary>
        //public string SuishinhiNendo { get; set; }

        ///// <summary>
        ///// 上下期区分
        ///// </summary>
        //public string KamiShimoKbn { get; set; }
        // 2014/10/16 DatNT v1.03 DEL End

        // 2014/10/16 DatNT v1.03 ADD Start
        /// <summary>
        /// 業者コードFROM
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コードTO
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// SaibanNo
        /// </summary>
        public string SaibanNo { get; set; }

        /// <summary>
        /// 集計年月(開始)
        /// </summary>
        public string ShukeiFromNengetsu { get; set; }

        /// <summary>
        /// 集計年月(終了)
        /// </summary>
        public string ShukeiToNengetsu { get; set; }
        // 2014/10/16 DatNT v1.03 ADD End

        /// <summary>
        /// 支払日
        /// </summary>
        public DateTime ShiharaiDt { get; set; }

        /// <summary>
        /// 開始日
        /// </summary>
        public string KaishiDt { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        public string ShuryoDt { get; set; }

        /// <summary>
        ///// RegisterCheck
        ///// </summary>
        //public bool RegisterCheck { get; set; }

        ///// <summary>
        ///// ReCreateCheck
        ///// </summary>
        //public bool ReCreateCheck { get; set; }

        /// <summary>
        /// Step processing
        /// </summary>
        public int StepProcessing { get; set; }

        /// <summary>
        /// HasError
        /// </summary>
        public bool HasError { get; set; }

        ///// <summary>
        ///// DataTableInput
        ///// </summary>
        //public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable DataTableInput { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("業者コードFROM[{0}], 業者コードTO[{1}], 支払日[{2}], 開始日[{3}], 終了日[{4}], StepProcessing[{5}]", 
                    new string[] { 
                        GyoshaCdFrom, 
                        GyoshaCdTo, 
                        ShiharaiDt.ToString("yyyyMMdd"),
                        KaishiDt,
                        ShuryoDt,
                        StepProcessing.ToString(),
                        //DataTableInput[0].SuishinhiNendo,
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IEntryBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IEntryBtnClickALOutput
    {
        /// <summary>
        /// message step by step
        /// </summary>
        string MessageStep { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        string ErrMessageStep { get; set; }

        /// <summary>
        /// RowCount
        /// </summary>
        int RowCount { get; set; }
        
        /// <summary>
        ///// RegisterCheckOutput
        ///// </summary>
        //bool RegisterCheckOutput { get; set; }

        ///// <summary>
        ///// ReCreateCheckOutput
        ///// </summary>
        //bool ReCreateCheckOutput { get; set; }

        ///// <summary>
        ///// DataTableOutput
        ///// </summary>
        //KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable DataTableOutput { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EntryBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class EntryBtnClickALOutput : IEntryBtnClickALOutput
    {
        /// <summary>
        /// message step by step
        /// </summary>
        public string MessageStep { get; set; }

        /// <summary>
        /// Error message
        /// </summary>
        public string ErrMessageStep { get; set; }

        /// <summary>
        /// RowCount
        /// </summary>
        public int RowCount { get; set; }
        
        ///// <summary>
        ///// RegisterCheckOutput
        ///// </summary>
        //public bool RegisterCheckOutput { get; set; }

        ///// <summary>
        ///// ReCreateCheckOutput
        ///// </summary>
        //public bool ReCreateCheckOutput { get; set; }

        ///// <summary>
        ///// DataTableOutput
        ///// </summary>
        //public KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable DataTableOutput { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EntryBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/25  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class EntryBtnClickApplicationLogic : BaseApplicationLogic<IEntryBtnClickALInput, IEntryBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKeihatsuSuishinhiSyukei：EntryBtnClickApplicationLogic";

        #region Message

        /// <summary>
        /// 処理開始 : 集計ボタンクリック直後
        /// </summary>
        private const string MESSAGE_START = "処理を開始します。";

        /// <summary>
        /// 処理ステップ１ : 対象業者抽出
        /// </summary>
        private const string MESSAGE_STEP_1 = "対象業者抽出中．．．（ステップ１／１０）";

        /// <summary>
        /// 処理ステップ２ : 9条持込集計
        /// </summary>
        private const string MESSAGE_STEP_2 = "9条検査持込集計中．．．（ステップ２／１０）";

        /// <summary>
        /// 処理ステップ３ : 9条収集集計
        /// </summary>
        private const string MESSAGE_STEP_3 = "9条検査収集集計中．．．（ステップ３／１０）";

        /// <summary>
        /// 処理ステップ４ : 9条取扱集計
        /// </summary>
        private const string MESSAGE_STEP_4 = "9条検査取扱集計中．．．（ステップ４／１０）";

        /// <summary>
        /// 処理ステップ５ : 11条水質持込集計
        /// </summary>
        private const string MESSAGE_STEP_5 = "11条水質検査持込集計中．．．（ステップ５／１０）";

        /// <summary>
        /// 処理ステップ６ : 9条取扱集計
        /// </summary>
        private const string MESSAGE_STEP_6 = "11条水質検査収集集計中．．．（ステップ６／１０）";
        
        /// <summary>
        /// 処理ステップ７ : 11条水質取扱集計
        /// </summary>
        private const string MESSAGE_STEP_7 = "11条水質検査取扱集計中．．．（ステップ７／１０）";

        /// <summary>
        /// 処理ステップ８ : 11条外観集計
        /// </summary>
        private const string MESSAGE_STEP_8 = "11条外観検査集計中．．．（ステップ８／１０）";

        /// <summary>
        /// 処理ステップ９ : 対象外業者削除
        /// </summary>
        private const string MESSAGE_STEP_9 = "対象外業者削除中．．．（ステップ９／１０）";

        /// <summary>
        /// 処理ステップ１０ : 支払合計処理
        /// </summary>
        private const string MESSAGE_STEP_10 = "支払合計集計中．．．（ステップ１０／１０）";

        /// <summary>
        /// Err mess step 1
        /// </summary>
        private const string ERR_MESS_STEP_1 = "対象業者抽出処理に失敗しました。";

        /// <summary>
        /// Err mess step 2
        /// </summary>
        private const string ERR_MESS_STEP_2 = "9条持込集計処理に失敗しました。";

        /// <summary>
        /// Err mess step 3
        /// </summary>
        private const string ERR_MESS_STEP_3 = "9条収集集計処理に失敗しました。";

        /// <summary>
        /// Err mess step 4
        /// </summary>
        private const string ERR_MESS_STEP_4 = "9条取扱集計処理に失敗しました。";

        /// <summary>
        /// Err mess step 5
        /// </summary>
        private const string ERR_MESS_STEP_5 = "11条水質持込集計処理に失敗しました。";

        /// <summary>
        /// Err mess step 6
        /// </summary>
        private const string ERR_MESS_STEP_6 = "11条水質収集集計処理に失敗しました。";

        /// <summary>
        /// Err mess step 7
        /// </summary>
        private const string ERR_MESS_STEP_7 = "11条水質取扱集計処理に失敗しました。";

        /// <summary>
        /// Err mess step 8
        /// </summary>
        private const string ERR_MESS_STEP_8 = "11条外観集計処理に失敗しました。";

        /// <summary>
        /// Err mess step 9
        /// </summary>
        private const string ERR_MESS_STEP_9 = "対象外業者削除処理に失敗しました。";

        /// <summary>
        /// Err mess step 10
        /// </summary>
        private const string ERR_MESS_STEP_10 = "支払合計処理処理に失敗しました。";

        #endregion

        #endregion

        #region プロパティ(private)

        ///// <summary>
        ///// 定義マスタ 区分005 コード008
        ///// </summary>
        //private string amount = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_005, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_008);

        ///// <summary>
        ///// 定義マスタ(区分005、コード001)から取得した単価
        ///// </summary>
        //private string tankaStep3 = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_005, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

        ///// <summary>
        ///// 定義マスタ(区分005、コード002)から取得した単価
        ///// </summary>
        //private string tankaStep4 = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_005, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002);

        ///// <summary>
        ///// 定義マスタ(区分005、コード003)から取得した単価
        ///// </summary> 
        //private string tankaStep5 = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_005, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_003);

        ///// <summary>
        ///// 定義マスタ(区分005、コード004)から取得した単価
        ///// </summary>
        //private string tankaStep6 = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_005, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_004);

        ///// <summary>
        ///// 定義マスタ(区分005、コード005)から取得した単価
        ///// </summary>
        //private string tankaStep7 = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_005, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_005);

        ///// <summary>
        ///// 定義マスタ(区分005、コード006)から取得した単価
        ///// </summary>
        //private string tankaStep8 = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_005, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_006);

        ///// <summary>
        ///// 定義マスタ(区分005、コード007)から取得した単価
        ///// </summary>
        //private string tankaStep9 = Boundary.Common.Common.GetConstValue(Utility.Constants.ConstKbnConstanst.CONST_KBN_005, Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_007);

        ///// <summary>
        ///// システム日付YYYYMMDD
        ///// </summary>
        //private DateTime sysDate = Boundary.Common.Common.GetCurrentTimestamp();

        /// <summary>
        /// Login user
        /// </summary>
        private string loginUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

        /// <summary>
        /// PC update
        /// </summary>
        private string pcUpdate = Dns.GetHostName();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： EntryBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/25  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public EntryBtnClickApplicationLogic()
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
        /// 2014/08/25  DatNT　  新規作成
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
        /// 2014/08/25  DatNT　  新規作成
        /// 2014/12/13  DatTN   v1.05 : use PROC KensaKeihatsuSuishinhiStd 
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IEntryBtnClickALOutput Execute(IEntryBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IEntryBtnClickALOutput output = new EntryBtnClickALOutput();

			bool errDetect = false;	//受入20141223

            try
            {

                // 2014/10/30 DatNT v1.06 DEL Start
                #region [登録済みチェック]

                //if (input.RegisterCheck)
                //{
                //    if (!RegisterCheck(input))
                //    {
                //        output.RegisterCheckOutput = false;
                //    }
                //    else
                //    {
                //        output.RegisterCheckOutput = true;
                //    }

                //    return output;
                //}
                //#endregion


                //#region [再作成不可チェック]

                //if (input.ReCreateCheck)
                //{
                //    if (!ReCreateCheck(input))
                //    {
                //        output.ReCreateCheckOutput = false;
                //    }
                //    else
                //    {
                //        output.ReCreateCheckOutput = true;
                //    }

                //    return output;
                //}
                #endregion
                // 2014/10/30 DatNT v1.06 DEL End

                //decimal zeiritsu = Boundary.Common.Common.GetSyohizei(input.Today.ToString("yyyyMMdd"));

                if (input.StepProcessing == 1)
                {
                    StartTransaction();
                }

                IExecProcKensaKeihatsuSuishinhiStdBLInput procInput = new ExecProcKensaKeihatsuSuishinhiStdBLInput();
                procInput.StepNo        = input.StepProcessing;
				//受入20141223 mod sta
				//procInput.SyukeiFrom    = input.ShukeiFromNengetsu;
				//procInput.SyukeiTo      = input.ShukeiToNengetsu;
				procInput.SyukeiFrom    = input.KaishiDt;
				procInput.SyukeiTo      = input.ShuryoDt;
				//受入20141223 mod end
				procInput.ShiharaiDt = input.ShiharaiDt.ToString("yyyyMMdd");
                procInput.SaibanNo      = input.SaibanNo;
                procInput.GyoshaCdFrom  = input.GyoshaCdFrom;
                procInput.GyoshaCdTo    = input.GyoshaCdTo;
                procInput.LoginUser     = loginUser;
                procInput.PcUpdate      = pcUpdate;
                IExecProcKensaKeihatsuSuishinhiStdBLOutput procOutput = new ExecProcKensaKeihatsuSuishinhiStdBusinessLogic().Execute(procInput);

                string errFlg = procOutput.ErrorFlg;

				// 受入20141223 add sta
				if (!String.IsNullOrEmpty(errFlg) && errFlg.Equals("1"))
				{
					errDetect = true;
				}
				// 受入20141223 add end

                List<string> listMsg = SetMsg(errFlg, procInput.StepNo);

                output.MessageStep = listMsg[0];

                output.ErrMessageStep = listMsg[1];

                #region 2014/12/13 DatNT v1.05 : Use Proc KensaKeihatsuSuishinhiStd - DEL
                //switch (input.StepProcessing)
                //{
                //    case 1:

                //        #region  1) 既存データ削除処理

                //        // 【データチェック仕様】[処理メッセージ]処理開始メッセージを表示
                //        listMsg.Add(MESSAGE_START);

                //        if (ProcessingStep1(input))
                //        {
                //            //【データチェック仕様】[処理メッセージ]処理ステップ１を表示
                //            listMsg.Add(MESSAGE_STEP_1);
                //        }
                //        else
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_1);
                //        }
                //        #endregion

                //        break;

                //    case 2:

                //        #region 2) 対象業者抽出処理

                //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataStep2 = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

                //        //【データチェック仕様】[処理メッセージ]処理ステップ２を表示
                //        listMsg.Add(MESSAGE_STEP_2);

                //        try
                //        {
                //            IGetGyoshaMstByKanpuUmuFlgBLInput gyoshaMstByKanpuUmuFlgBlInput = new GetGyoshaMstByKanpuUmuFlgBLInput();
                //            gyoshaMstByKanpuUmuFlgBlInput.KanpuUmuFlg = "2";
                //            IGetGyoshaMstByKanpuUmuFlgBLOutput gyoshaMstByKanpuUmuFlgBlOutput = new GetGyoshaMstByKanpuUmuFlgBusinessLogic().Execute(gyoshaMstByKanpuUmuFlgBlInput);

                //            if (gyoshaMstByKanpuUmuFlgBlOutput.GyoshaMstDT != null && gyoshaMstByKanpuUmuFlgBlOutput.GyoshaMstDT.Count > 0)
                //            {
                //                // 2014/10/16 DatNT v1.03 MOD Start

                //                //dataStep2 = CreateDataInsertStep2(input, gyoshaMstByKanpuUmuFlgBlOutput.GyoshaMstDT);
                //                //output.DataTableOutput = dataStep2;

                //                GyoshaMstDataSet.GyoshaMstDataTable gyoshaMstDT = new GyoshaMstDataSet.GyoshaMstDataTable();

                //                string filter = string.Empty;

                //                if (string.IsNullOrEmpty(input.GyoshaCdFrom) && !string.IsNullOrEmpty(input.GyoshaCdTo))
                //                {
                //                    filter = string.Format("GyoshaCd <= '{0}'", input.GyoshaCdTo);
                //                }
                //                else if (!string.IsNullOrEmpty(input.GyoshaCdFrom) && string.IsNullOrEmpty(input.GyoshaCdTo))
                //                {
                //                    filter = string.Format("GyoshaCd >= '{0}'", input.GyoshaCdFrom);
                //                }
                //                else if (!string.IsNullOrEmpty(input.GyoshaCdFrom) && !string.IsNullOrEmpty(input.GyoshaCdTo))
                //                {
                //                    filter = string.Format("GyoshaCd >= '{0}' And GyoshaCd <= '{1}' ", input.GyoshaCdFrom, input.GyoshaCdTo);
                //                }

                //                foreach (GyoshaMstDataSet.GyoshaMstRow row in gyoshaMstByKanpuUmuFlgBlOutput.GyoshaMstDT.Select(filter))
                //                {
                //                    gyoshaMstDT.ImportRow(row);
                //                }

                //                dataStep2 = CreateDataInsertStep2(input, gyoshaMstDT);
                //                output.DataTableOutput = dataStep2;

                //                // 2014/10/16 DatNT v1.03 MOD End
                //            }
                //            else
                //            {
                //                listMsg.Add("処理が正常に終了しました。（対象件数：0件）");
                //            }

                //        }
                //        catch (Exception)
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_2);
                //        }

                //        #endregion

                //        break;

                //    case 3:

                //        #region 3) 9条持込集計処理

                //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataStep3 = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

                //        //【データチェック仕様】[処理メッセージ]処理ステップ３を表示
                //        listMsg.Add(MESSAGE_STEP_3);

                //        try
                //        {
                //            foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow step3Row in input.DataTableInput)
                //            {
                //                IGetKensaKeihatsuSuishinhiSyukeiStep3BLInput step3BlInput = new GetKensaKeihatsuSuishinhiSyukeiStep3BLInput();
                //                step3BlInput.KaishiDt = input.KaishiDt;
                //                step3BlInput.ShuryoDt = input.ShuryoDt;
                //                step3BlInput.Amount = Convert.ToDecimal(amount);
                //                step3BlInput.GyoshaCd = step3Row.GyoshaCd;
                //                IGetKensaKeihatsuSuishinhiSyukeiStep3BLOutput step3BlOutput = new GetKensaKeihatsuSuishinhiSyukeiStep3BusinessLogic().Execute(step3BlInput);

                //                if (step3BlOutput.KensaKeihatsuSuishinhiSyukeiStep3DT != null && step3BlOutput.KensaKeihatsuSuishinhiSyukeiStep3DT.Count > 0)
                //                {
                //                    // 計量証明持込件数
                //                    step3Row.KeiryoShomeiMochiCnt = step3BlOutput.KensaKeihatsuSuishinhiSyukeiStep3DT.Count;

                //                    // 計量証明持込単価
                //                    step3Row.KeiryoShomeiMochiUp = Math.Truncate(Convert.ToDecimal(tankaStep3) * zeiritsu);

                //                    // 計量証明持込金額
                //                    step3Row.KeiryoShomeiMochiAmt = step3Row.KeiryoShomeiMochiCnt * step3Row.KeiryoShomeiMochiUp;
                //                }
                //                else
                //                {
                //                    // 計量証明持込件数
                //                    step3Row.KeiryoShomeiMochiCnt = 0;

                //                    // 計量証明持込単価
                //                    step3Row.KeiryoShomeiMochiUp = Convert.ToDecimal(tankaStep3);

                //                    // 計量証明持込金額
                //                    step3Row.KeiryoShomeiMochiAmt = 0;
                //                }

                //                dataStep3.ImportRow(step3Row);
                //            }

                //            output.DataTableOutput = dataStep3;
                //        }
                //        catch (Exception)
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_3);

                //            output.DataTableOutput = input.DataTableInput;
                //        }
                //        #endregion

                //        break;

                //    case 4:

                //        #region 4) 9条収集集計処理

                //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataStep4 = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

                //        //【データチェック仕様】[処理メッセージ]処理ステップ４を表示
                //        listMsg.Add(MESSAGE_STEP_4);

                //        try
                //        {
                //            foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow step4Row in input.DataTableInput)
                //            {
                //                IGetKensaKeihatsuSuishinhiSyukeiStep4BLInput step4BlInput = new GetKensaKeihatsuSuishinhiSyukeiStep4BLInput();
                //                step4BlInput.KaishiDt = input.KaishiDt;
                //                step4BlInput.ShuryoDt = input.ShuryoDt;
                //                step4BlInput.Amount = Convert.ToDecimal(amount);
                //                step4BlInput.GyoshaCd = step4Row.GyoshaCd;
                //                IGetKensaKeihatsuSuishinhiSyukeiStep4BLOutput step4BlOutput = new GetKensaKeihatsuSuishinhiSyukeiStep4BusinessLogic().Execute(step4BlInput);

                //                if (step4BlOutput.KensaKeihatsuSuishinhiSyukeiStep4DT != null && step4BlOutput.KensaKeihatsuSuishinhiSyukeiStep4DT.Count > 0)
                //                {
                //                    // 計量証明収集件数
                //                    step4Row.KeiryoShomeiShushuCnt = step4BlOutput.KensaKeihatsuSuishinhiSyukeiStep4DT.Count;

                //                    // 計量証明収集単価
                //                    step4Row.KeiryoShomeiShushuUp =  Math.Truncate(Convert.ToDecimal(tankaStep4) * zeiritsu);

                //                    // 計量証明収集金額
                //                    step4Row.KeiryoShomeiShushuAmt = step4Row.KeiryoShomeiShushuCnt * step4Row.KeiryoShomeiShushuUp;
                //                }
                //                else
                //                {
                //                    // 計量証明収集件数
                //                    step4Row.KeiryoShomeiShushuCnt = 0;

                //                    // 計量証明収集単価
                //                    step4Row.KeiryoShomeiShushuUp = Convert.ToDecimal(tankaStep4);

                //                    // 計量証明収集金額
                //                    step4Row.KeiryoShomeiShushuAmt = 0;
                //                }

                //                dataStep4.ImportRow(step4Row);
                //            }
                            
                //            output.DataTableOutput = dataStep4;

                //        }
                //        catch (Exception)
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_4);

                //            output.DataTableOutput = input.DataTableInput;
                //        }

                //        #endregion

                //        break;

                //    case 5:

                //        #region 5) 9条取扱集計処理

                //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataStep5 = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

                //        // 【データチェック仕様】[処理メッセージ]処理ステップ５を表示
                //        listMsg.Add(MESSAGE_STEP_5);

                //        try
                //        {
                //            foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow step5Row in input.DataTableInput)
                //            {
                //                IGetKensaKeihatsuSuishinhiSyukeiStep5BLInput step5BlInput = new GetKensaKeihatsuSuishinhiSyukeiStep5BLInput();
                //                step5BlInput.KaishiDt = input.KaishiDt;
                //                step5BlInput.ShuryoDt = input.ShuryoDt;
                //                step5BlInput.Amount = Convert.ToDecimal(amount);
                //                step5BlInput.GyoshaCd = step5Row.GyoshaCd;
                //                IGetKensaKeihatsuSuishinhiSyukeiStep5BLOutput step5BlOutput = new GetKensaKeihatsuSuishinhiSyukeiStep5BusinessLogic().Execute(step5BlInput);

                //                if (step5BlOutput.KensaKeihatsuSuishinhiSyukeiStep5DT != null && step5BlOutput.KensaKeihatsuSuishinhiSyukeiStep5DT.Count > 0)
                //                {
                //                    // 計量証明取扱件数
                //                    step5Row.KeiryoShomeiToriCnt = step5BlOutput.KensaKeihatsuSuishinhiSyukeiStep5DT.Count;

                //                    // 計量証明取扱単価
                //                    step5Row.KeiryoShomeiToriUp = Math.Truncate(Convert.ToDecimal(tankaStep5) * zeiritsu);

                //                    // 計量証明取扱金額
                //                    step5Row.KeiryoShomeiToriAmt = step5Row.KeiryoShomeiToriCnt * step5Row.KeiryoShomeiToriUp;
                //                }
                //                else
                //                {
                //                    // 計量証明取扱件数
                //                    step5Row.KeiryoShomeiToriCnt = 0;

                //                    // 計量証明取扱単価
                //                    step5Row.KeiryoShomeiToriUp = Convert.ToDecimal(tankaStep5);

                //                    // 計量証明取扱金額
                //                    step5Row.KeiryoShomeiToriAmt = 0;
                //                }

                //                dataStep5.ImportRow(step5Row);
                //            }
                            
                //            output.DataTableOutput = dataStep5;

                //        }
                //        catch (Exception)
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_5);

                //            output.DataTableOutput = input.DataTableInput;
                //        }

                //        #endregion

                //        break;

                //    case 6:

                //        #region 6) 11条水質持込集計処理

                //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataStep6 = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

                //        //【データチェック仕様】[処理メッセージ]処理ステップ６を表示
                //        listMsg.Add(MESSAGE_STEP_6);

                //        try
                //        {
                //            foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow step6Row in input.DataTableInput)
                //            {
                //                IGetKensaKeihatsuSuishinhiSyukeiStep6BLInput step6BlInput = new GetKensaKeihatsuSuishinhiSyukeiStep6BLInput();
                //                step6BlInput.KaishiDt = input.KaishiDt;
                //                step6BlInput.ShuryoDt = input.ShuryoDt;
                //                step6BlInput.GyoshaCd = step6Row.GyoshaCd;
                //                IGetKensaKeihatsuSuishinhiSyukeiStep6BLOutput step6BlOutput = new GetKensaKeihatsuSuishinhiSyukeiStep6BusinessLogic().Execute(step6BlInput);

                //                if (step6BlOutput.KensaKeihatsuSuishinhiSyukeiStep6DT != null && step6BlOutput.KensaKeihatsuSuishinhiSyukeiStep6DT.Count > 0)
                //                {
                //                    // 11条水質持込件数
                //                    step6Row.Kensa11SuishitsuMochiCnt = step6BlOutput.KensaKeihatsuSuishinhiSyukeiStep6DT.Count;

                //                    // 11条水質持込単価 
                //                    step6Row.Kensa11SuishitsuMochiUp = Math.Truncate(Convert.ToDecimal(tankaStep6) * zeiritsu);

                //                    // 11条水質持込金額
                //                    step6Row.Kensa11SuishitsuMochiAmt = step6Row.Kensa11SuishitsuMochiCnt * step6Row.Kensa11SuishitsuMochiUp;
                //                }
                //                else
                //                {
                //                    // 11条水質持込件数
                //                    step6Row.Kensa11SuishitsuMochiCnt = 0;

                //                    // 11条水質持込単価 
                //                    step6Row.Kensa11SuishitsuMochiUp = Convert.ToDecimal(tankaStep6);

                //                    // 11条水質持込金額
                //                    step6Row.Kensa11SuishitsuMochiAmt = 0;
                //                }

                //                dataStep6.ImportRow(step6Row);
                //            }
                            
                //            output.DataTableOutput = dataStep6;

                //        }
                //        catch (Exception)
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_6);

                //            output.DataTableOutput = input.DataTableInput;
                //        }

                //        #endregion

                //        break;

                //    case 7:

                //        #region 7) 11条水質収集集計処理

                //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataStep7 = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

                //        //【データチェック仕様】[処理メッセージ]処理ステップ７を表示
                //        listMsg.Add(MESSAGE_STEP_7);

                //        try
                //        {
                //            foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow step7Row in input.DataTableInput)
                //            {
                //                IGetKensaKeihatsuSuishinhiSyukeiStep7BLInput step7BlInput = new GetKensaKeihatsuSuishinhiSyukeiStep7BLInput();
                //                step7BlInput.KaishiDt = input.KaishiDt;
                //                step7BlInput.ShuryoDt = input.ShuryoDt;
                //                step7BlInput.GyoshaCd = step7Row.GyoshaCd;
                //                IGetKensaKeihatsuSuishinhiSyukeiStep7BLOutput step7BlOutput = new GetKensaKeihatsuSuishinhiSyukeiStep7BusinessLogic().Execute(step7BlInput);

                //                if (step7BlOutput.KensaKeihatsuSuishinhiSyukeiStep7DT != null && step7BlOutput.KensaKeihatsuSuishinhiSyukeiStep7DT.Count > 0)
                //                {
                //                    // 11条水質収集件数
                //                    step7Row.Kensa11SuishitsuShushuCnt = step7BlOutput.KensaKeihatsuSuishinhiSyukeiStep7DT.Count;

                //                    // 11条水質収集単価
                //                    step7Row.Kensa11SuishitsuShushuUp = Math.Truncate(Convert.ToDecimal(tankaStep7) * zeiritsu);

                //                    // 11条水質収集金額
                //                    step7Row.Kensa11SuishitsuShushuAmt = step7Row.Kensa11SuishitsuShushuCnt * step7Row.Kensa11SuishitsuShushuUp;
                //                }
                //                else
                //                {
                //                    // 11条水質収集件数
                //                    step7Row.Kensa11SuishitsuShushuCnt = 0;

                //                    // 11条水質収集単価
                //                    step7Row.Kensa11SuishitsuShushuUp = Convert.ToDecimal(tankaStep7);

                //                    // 11条水質収集金額
                //                    step7Row.Kensa11SuishitsuShushuAmt = 0;
                //                }

                //                dataStep7.ImportRow(step7Row);
                //            }
                            
                //            output.DataTableOutput = dataStep7;

                //        }
                //        catch (Exception)
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_7);

                //            output.DataTableOutput = input.DataTableInput;
                //        }

                //        #endregion

                //        break;

                //    case 8:

                //        #region 8) 11条水質取扱集計処理

                //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataStep8 = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

                //        //【データチェック仕様】[処理メッセージ]処理ステップ８を表示
                //        listMsg.Add(MESSAGE_STEP_8);

                //        try
                //        {
                //            foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow step8Row in input.DataTableInput)
                //            {
                //                IGetKensaKeihatsuSuishinhiSyukeiStep8BLInput step8BlInput = new GetKensaKeihatsuSuishinhiSyukeiStep8BLInput();
                //                step8BlInput.KaishiDt = input.KaishiDt;
                //                step8BlInput.ShuryoDt = input.ShuryoDt;
                //                step8BlInput.GyoshaCd = step8Row.GyoshaCd;
                //                IGetKensaKeihatsuSuishinhiSyukeiStep8BLOutput step8BlOutput = new GetKensaKeihatsuSuishinhiSyukeiStep8BusinessLogic().Execute(step8BlInput);

                //                if (step8BlOutput.KensaKeihatsuSuishinhiSyukeiStep8DT != null && step8BlOutput.KensaKeihatsuSuishinhiSyukeiStep8DT.Count > 0)
                //                {
                //                    // 11条水質取扱件数
                //                    step8Row.Kensa11SuishitsuToriCnt = step8BlOutput.KensaKeihatsuSuishinhiSyukeiStep8DT.Count;

                //                    // 11条水質取扱単価
                //                    step8Row.Kensa11SuishitsuToriUp = Math.Truncate(Convert.ToDecimal(tankaStep8) * zeiritsu);

                //                    // 11条水質取扱金額
                //                    step8Row.Kensa11SuishitsuToriAmt = step8Row.Kensa11SuishitsuToriCnt * step8Row.Kensa11SuishitsuToriUp;
                //                }
                //                else
                //                {
                //                    // 11条水質取扱件数
                //                    step8Row.Kensa11SuishitsuToriCnt = 0;

                //                    // 11条水質取扱単価
                //                    step8Row.Kensa11SuishitsuToriUp = Convert.ToDecimal(tankaStep8);

                //                    // 11条水質取扱金額
                //                    step8Row.Kensa11SuishitsuToriAmt = 0;
                //                }

                //                dataStep8.ImportRow(step8Row);
                //            }

                //            output.DataTableOutput = dataStep8;

                //        }
                //        catch (Exception)
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_8);

                //            output.DataTableOutput = input.DataTableInput;
                //        }
                //        #endregion

                //        break;

                //    case 9:

                //        #region 9) 11条外観集計処理

                //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataStep9 = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

                //        //【データチェック仕様】[処理メッセージ]処理ステップ９を表示
                //        listMsg.Add(MESSAGE_STEP_9);

                //        try
                //        {
                //            foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow step9Row in input.DataTableInput)
                //            {
                //                IGetKensaKeihatsuSuishinhiSyukeiStep9BLInput step9BlInput = new GetKensaKeihatsuSuishinhiSyukeiStep9BLInput();
                //                step9BlInput.KaishiDt = input.KaishiDt;
                //                step9BlInput.ShuryoDt = input.ShuryoDt;
                //                step9BlInput.GyoshaCd = step9Row.GyoshaCd;
                //                IGetKensaKeihatsuSuishinhiSyukeiStep9BLOutput step9BlOutput = new GetKensaKeihatsuSuishinhiSyukeiStep9BusinessLogic().Execute(step9BlInput);

                //                if (step9BlOutput.KensaKeihatsuSuishinhiSyukeiStep9DT != null && step9BlOutput.KensaKeihatsuSuishinhiSyukeiStep9DT.Count > 0)
                //                {
                //                    // 11条外観取扱件数
                //                    step9Row.Kensa11GaikanCnt = step9BlOutput.KensaKeihatsuSuishinhiSyukeiStep9DT.Count;

                //                    // 11条外観取扱単価
                //                    step9Row.Kensa11GaikanUp = Math.Truncate(Convert.ToDecimal(tankaStep9) * zeiritsu);

                //                    // 11条外観取扱金額
                //                    step9Row.Kensa11GaikanAmt = step9Row.Kensa11GaikanCnt * step9Row.Kensa11GaikanUp;
                //                }
                //                else
                //                {
                //                    // 11条外観取扱件数
                //                    step9Row.Kensa11GaikanCnt = 0;

                //                    // 11条外観取扱単価
                //                    step9Row.Kensa11GaikanUp = Convert.ToDecimal(tankaStep9);

                //                    // 11条外観取扱金額
                //                    step9Row.Kensa11GaikanAmt = 0;
                //                }

                //                dataStep9.ImportRow(step9Row);
                //            }
                            
                //            output.DataTableOutput = dataStep9;

                //        }
                //        catch (Exception)
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_9);

                //            output.DataTableOutput = input.DataTableInput;
                //        }

                //        #endregion

                //        break;

                //    case 10:

                //        #region 10) 対象外業者削除   11) 支払合計処理

                //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable dataStep10 = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

                //        //【データチェック仕様】[処理メッセージ]処理ステップ１０を表示
                //        listMsg.Add(MESSAGE_STEP_10);

                //        try
                //        {
                //            foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow step10Row in input.DataTableInput)
                //            {
                //                if ((step10Row.IsKeiryoShomeiMochiCntNull() || step10Row.KeiryoShomeiMochiCnt == 0)
                //                    && (step10Row.IsKeiryoShomeiShushuCntNull() || step10Row.KeiryoShomeiShushuCnt == 0)
                //                    && (step10Row.IsKeiryoShomeiToriCntNull() || step10Row.KeiryoShomeiToriCnt == 0)
                //                    && (step10Row.IsKensa11SuishitsuMochiCntNull() || step10Row.Kensa11SuishitsuMochiCnt == 0)
                //                    && (step10Row.IsKensa11SuishitsuShushuCntNull() || step10Row.Kensa11SuishitsuShushuCnt == 0)
                //                    && (step10Row.IsKensa11SuishitsuToriCntNull() || step10Row.Kensa11SuishitsuToriCnt == 0)
                //                    && (step10Row.IsKensa11GaikanCntNull() || step10Row.Kensa11GaikanCnt == 0))
                //                {
                //                    // don't handled
                //                }
                //                else
                //                {
                //                    // 支払合計 
                //                    step10Row.ShiharaiTotal = (step10Row.IsKeiryoShomeiMochiAmtNull() ? 0 : step10Row.KeiryoShomeiMochiAmt)
                //                                                + (step10Row.IsKeiryoShomeiShushuAmtNull() ? 0 : step10Row.KeiryoShomeiShushuAmt)
                //                                                + (step10Row.IsKeiryoShomeiToriAmtNull() ? 0 : step10Row.KeiryoShomeiToriAmt)
                //                                                + (step10Row.IsKensa11SuishitsuMochiAmtNull() ? 0 : step10Row.Kensa11SuishitsuMochiAmt)
                //                                                + (step10Row.IsKensa11SuishitsuShushuAmtNull() ? 0 : step10Row.Kensa11SuishitsuShushuAmt)
                //                                                + (step10Row.IsKensa11SuishitsuToriAmtNull() ? 0 : step10Row.Kensa11SuishitsuToriAmt)
                //                                                + (step10Row.IsKensa11GaikanAmtNull() ? 0 : step10Row.Kensa11GaikanAmt);

                //                    dataStep10.ImportRow(step10Row);
                //                }
                //            }

                //            //【データチェック仕様】[処理メッセージ]処理完了を表示
                //            listMsg.Add(string.Format("処理が正常に終了しました。（対象件数：{0}件）", dataStep10.Count));

                //            output.DataTableOutput = dataStep10;

                //        }
                //        catch (Exception)
                //        {
                //            listMsgErr.Add(ERR_MESS_STEP_10);

                //            output.DataTableOutput = input.DataTableInput;
                //        }

                //        #endregion

                //        break;

                //    case 11:

                //        #region Update

                //        StartTransaction();

                //        IUpdateKensaKeihatsuSuishinHiShukeiTblBLInput updateInput = new UpdateKensaKeihatsuSuishinHiShukeiTblBLInput();
                //        updateInput.KensaKeihatsuSuishinHiShukeiTblDT = input.DataTableInput;
                //        new UpdateKensaKeihatsuSuishinHiShukeiTblBusinessLogic().Execute(updateInput);

                //        CompleteTransaction();

                //        #endregion

                //        break;

                //    default:
                //        break;
                //}
                #endregion
                
                if (input.StepProcessing == 10)
                {
                    IGetKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLInput blInput = new GetKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLInput();
                    blInput.SuishinhiNo = input.SaibanNo;
                    IGetKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBLOutput blOutput = new GetKensaKeihatsuSuishinHiShukeiTblBySuishinhiNoBusinessLogic().Execute(blInput);

                    if (blOutput.KensaKeihatsuSuishinHiShukeiTblDT != null && blOutput.KensaKeihatsuSuishinHiShukeiTblDT.Count > 0)
                    {
                        output.RowCount = blOutput.KensaKeihatsuSuishinHiShukeiTblDT.Count;
                    }
                    else
                    {
                        output.RowCount = 0;
                    }

                    //if (!input.HasError && string.IsNullOrEmpty(output.ErrMessageStep))
                    if (string.IsNullOrEmpty(output.ErrMessageStep))	//受入20141223 途中でエラーの場合、それ以上は呼ばれなくなるので、コミット条件は10回完了かつ10回目がエラーではない場合。
                    {
                        CompleteTransaction();
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
				if (input.StepProcessing == 10 || errDetect)	// 受入20141223 mod ストアドエラー時もEndTranする。
                {
                    EndTransaction();
                }

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region 2014/12/13 DatNT v1.05 DEL

        //#region CreateDataInsertStep2
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： CreateDataInsertStep2
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/08/25  DatNT　　 新規作成
        ///// 2014/10/16  DatNT     v1.03
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable 
        //    CreateDataInsertStep2(IEntryBtnClickALInput input, GyoshaMstDataSet.GyoshaMstDataTable gyoshaMstDT)
        //{
        //    KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable insertDT = new KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblDataTable();

        //    foreach (GyoshaMstDataSet.GyoshaMstRow row in gyoshaMstDT)
        //    {
        //        KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow insertRow = insertDT.NewKensaKeihatsuSuishinHiShukeiTblRow();

        //        // 2014/10/16 DatNT v1.03 MOD Start
        //        //// 年度
        //        //insertRow.SuishinhiNendo = input.SuishinhiNendo;

        //        //// 上下期区分
        //        //insertRow.KamiShimoKbn = input.KamiShimoKbn;

        //        // 推進費No
        //        insertRow.SuishinhiNo = Utility.Saiban.GetSaibanRenban(Utility.DateUtility.GetNendo(input.Today).ToString(), Utility.Constants.SaibanKbnConstant.SAIBAN_KBN_10);
        //        // 2014/10/16 DatNT v1.03 MOD End

        //        // 業者コード
        //        insertRow.GyoshaCd = row.GyoshaCd;

        //        // 集計年月（開始）
        //        insertRow.ShukeiFromNengetsu = input.ShukeiFromNengetsu;

        //        // 集計年月(終了)
        //        insertRow.ShukeiToNengetsu = input.ShukeiToNengetsu;

        //        // 集計日
        //        insertRow.ShukeiDt = sysDate.ToString("yyyyMMdd");

        //        // 支払計上日
        //        insertRow.ShiharaiDt = input.ShiharaiDt.ToString("yyyyMMdd");

        //        // 協同組合コード
        //        insertRow.KyodoKumiaiCd = row.KyodoKumiaiCd;

        //        // 取扱業者区分
        //        insertRow.ToriatsukaiGyoshaKbn = row.ToriatsukaiGyoshaKbn;

        //        // 取扱業者コード
        //        insertRow.ToriatsukaiGyoshaCd = row.ToriatsukaiGyoshaCd;

        //        // 支払先区分
        //        if (string.IsNullOrEmpty(insertRow.KyodoKumiaiCd.Trim()))
        //        {
        //            insertRow.ShiharaisakiKbn = "1";
        //        }
        //        else
        //        {
        //            insertRow.ShiharaisakiKbn = "2";
        //        }

        //        // 会計連動済フラグ
        //        insertRow.KaikeiRendoFlg = "0";

        //        // 支払帳票印刷フラグ
        //        insertRow.ShiharaiPrintFlg = "0";

        //        // 登録日
        //        insertRow.InsertDt = sysDate;

        //        // 登録者
        //        insertRow.InsertUser = loginUser;

        //        // 登録端末
        //        insertRow.InsertTarm = pcUpdate;

        //        // 更新日
        //        insertRow.UpdateDt = sysDate;

        //        // 更新者
        //        insertRow.UpdateUser = loginUser;

        //        // 更新端末
        //        insertRow.UpdateTarm = pcUpdate;

        //        insertDT.AddKensaKeihatsuSuishinHiShukeiTblRow(insertRow);

        //        insertRow.AcceptChanges();

        //        insertRow.SetAdded();
        //    }           

        //    return insertDT;
        //}
        //#endregion

        //#region RegisterCheck
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： RegisterCheck
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/08/25  DatNT　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private bool RegisterCheck(IEntryBtnClickALInput input)
        //{
        //    //IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput registerCheckInput = new GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput();
        //    //registerCheckInput.SuishinhiNendo = input.SuishinhiNendo;
        //    //registerCheckInput.KamiShimoKbn = input.KamiShimoKbn;
        //    //IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput registerCheckOutput = new GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic().Execute(registerCheckInput);

        //    //if (registerCheckOutput.KensaKeihatsuSuishinHiShukeiTblDT != null && registerCheckOutput.KensaKeihatsuSuishinHiShukeiTblDT.Count > 0)
        //    //{
        //    //    foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow row in registerCheckOutput.KensaKeihatsuSuishinHiShukeiTblDT)
        //    //    {
        //    //        if (row.KaikeiRendoFlg != "0")
        //    //        {
        //    //            return true;
        //    //        }
        //    //    }
        //    //}

        //    return false;
        //}
        //#endregion

        //#region ReCreateCheck
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： ReCreateCheck
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="input"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/08/26  DatNT　　    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private bool ReCreateCheck(IEntryBtnClickALInput input)
        //{
        //    //IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput registerCheckInput = new GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLInput();
        //    //registerCheckInput.SuishinhiNendo = input.SuishinhiNendo;
        //    //registerCheckInput.KamiShimoKbn = input.KamiShimoKbn;
        //    //IGetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBLOutput registerCheckOutput = new GetKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic().Execute(registerCheckInput);

        //    //if (registerCheckOutput.KensaKeihatsuSuishinHiShukeiTblDT != null && registerCheckOutput.KensaKeihatsuSuishinHiShukeiTblDT.Count > 0)
        //    //{
        //    //    foreach (KensaKeihatsuSuishinHiShukeiTblDataSet.KensaKeihatsuSuishinHiShukeiTblRow row in registerCheckOutput.KensaKeihatsuSuishinHiShukeiTblDT)
        //    //    {
        //    //        if (row.KaikeiRendoFlg == "1")
        //    //        {
        //    //            return false;
        //    //        }
        //    //    }
        //    //}

        //    return true;
        //}
        //#endregion

        //#region ProcessingStep1
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： ProcessingStep1
        ///// <summary>
        ///// 1) 既存データ削除処理
        ///// </summary>
        ///// <param name="input"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/08/27  DatNT　　 新規作成
        ///// 2014/10/16  DatNT     v1.03
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //private bool ProcessingStep1(IEntryBtnClickALInput input)
        //{
        //    // 2014/10/16 DatNT v1.03 DEL Start
        //    //try
        //    //{
        //    //    if (!RegisterCheck(input))
        //    //    {
        //    //        new DeleteKensaKeihatsuSuishinHiShukeiTblByNendoKbnBusinessLogic().Execute(input);
        //    //    }
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    return false;
        //    //}
        //    // 2014/10/16 DatNT v1.03 DEL End

        //    return true;            
        //}
        //#endregion

        #endregion

        #region SetMsg
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： SetMsg
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errFlg"></param>
        /// <param name="stepNo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13  DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private List<string> SetMsg(string errFlg, int stepNo)
        {
            List<string> retList = new List<string>();

            string msg = string.Empty;

            string errMsg = string.Empty;

            switch (stepNo)
            {
                case 1:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_1;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_1;
                    }
                    break;

                case 2:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_2;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_2;
                    }
                    break;

                case 3:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_3;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_3;
                    }
                    break;

                case 4:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_4;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_4;
                    }
                    break;

                case 5:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_5;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_5;
                    }
                    break;

                case 6:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_6;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_6;
                    }
                    break;

                case 7:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_7;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_7;
                    }
                    break;

                case 8:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_8;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_8;
                    }
                    break;

                case 9:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_9;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_9;
                    }
                    break;

                case 10:
                    if (errFlg == "0")
                    {
                        msg = MESSAGE_STEP_10;
                    }
                    else
                    {
                        errMsg = ERR_MESS_STEP_10;
                    }
                    break;

                default:
                    break;
            }

            retList.Add(msg);
            retList.Add(errMsg);

            return retList;
        }
        #endregion

        #endregion
    }
    #endregion
}
