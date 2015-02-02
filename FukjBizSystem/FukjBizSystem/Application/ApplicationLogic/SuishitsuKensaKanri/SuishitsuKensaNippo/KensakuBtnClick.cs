using System.Net;
using System.Reflection;
using FukjBizSystem.Application.Boundary.SuishitsuKensaKanri;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.SuishitsuKensaNippo;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.SuishitsuKensaNippo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        string UketsukeDt { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// 受付日
        /// </summary>
        public string UketsukeDt { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("受付日[{0}], 支所コード[{1}]", new string[] { UketsukeDt, ShishoCd });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput : IGetSuisitsuKensaNippoBySearchCondBLOutput
    {
        /// <summary>
        /// ExecProcFailure
        /// </summary>
        bool ExecProcFailure { get; set; }

        /// <summary>
        /// 対象データ検索チェック
        /// </summary>
        bool KensakuCheck { get; set; }

        /// <summary>
        /// DispMode
        /// </summary>
        SuishitsuKensaNippoForm.DispMode DispMode { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// ExecProcFailure
        /// </summary>
        public bool ExecProcFailure { get; set; }

        /// <summary>
        /// 対象データ検索チェック
        /// </summary>
        public bool KensakuCheck { get; set; }

        /// <summary>
        /// DispMode
        /// </summary>
        public SuishitsuKensaNippoForm.DispMode DispMode { get; set; }

        /// <summary>
        /// SuisitsuKensaNippoKensakuDataTable
        /// </summary>
        public SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuDataTable SuisitsuKensaNippoKensakuDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KensakuBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaNippo：KensakuBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KensakuBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KensakuBtnClickApplicationLogic()
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
        /// 2014/12/05  DatNT　  新規作成
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
        /// 2014/12/05  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            string userId = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            string userTarm = Dns.GetHostName();

            try
            {
                // Excec procedure SuishitsuNippoStd
                IExecProcSuishitsuNippoStdBLInput procInput = new ExecProcSuishitsuNippoStdBLInput();
                procInput.UketsukeDt = input.UketsukeDt;
                procInput.ShishoCd = input.ShishoCd;
                procInput.UserId = userId;
                procInput.UserTarm = userTarm;
                IExecProcSuishitsuNippoStdBLOutput procOutput = new ExecProcSuishitsuNippoStdBusinessLogic().Execute(procInput);
                
				if (procOutput.Result == 0)
                {
                    output.ExecProcFailure = false;

                    // 水質日報ヘッダ存在チェック（モード判定１）
                    IGetSuishitsuNippoHdrTblByUketsukeDtBLInput decide1Input = new GetSuishitsuNippoHdrTblByUketsukeDtBLInput();
                    decide1Input.UketsukeDt = input.UketsukeDt;
                    IGetSuishitsuNippoHdrTblByUketsukeDtBLOutput decide1Output = new GetSuishitsuNippoHdrTblByUketsukeDtBusinessLogic().Execute(decide1Input);

                    if (decide1Output.SuishitsuNippoHdrTblDT != null && decide1Output.SuishitsuNippoHdrTblDT.Count > 0)
                    {
                        // Mode
                        SuishitsuKensaNippoForm.DispMode mode = SuishitsuKensaNippoForm.DispMode.Edit;

                        // 水質日報明細テーブル/検査依頼テーブル（モード判定２）
                        ICountDecide2KensaIraiBLInput decide2KensaIraiInput = new CountDecide2KensaIraiBLInput();
                        decide2KensaIraiInput.UketsukeDt = input.UketsukeDt;
                        ICountDecide2KensaIraiBLOutput decide2KensaIraiOutput = new CountDecide2KensaIraiBusinessLogic().Execute(decide2KensaIraiInput);

                        // 水質日報明細テーブル/計量証明依頼テーブル（モード判定２）
                        ICountDecideKeiryoShomeiBLInput decide2KeiryoInput = new CountDecideKeiryoShomeiBLInput();
                        decide2KeiryoInput.UketsukeDt = input.UketsukeDt;
                        ICountDecideKeiryoShomeiBLOutput decide2KeiryoOuput = new CountDecideKeiryoShomeiBusinessLogic().Execute(decide2KeiryoInput);

                        if (decide2KensaIraiOutput.RecordCount > 0 || decide2KeiryoOuput.RecordCount > 0)
                        {
                            mode = SuishitsuKensaNippoForm.DispMode.View;
                        }

                        // 水質日報データ取得
                        IGetSuisitsuKensaNippoBySearchCondBLInput searchInput = new GetSuisitsuKensaNippoBySearchCondBLInput();
                        searchInput.UketsukeDt = input.UketsukeDt;
                        searchInput.ShishoCd = input.ShishoCd;
                        IGetSuisitsuKensaNippoBySearchCondBLOutput searchOuput = new GetSuisitsuKensaNippoBySearchCondBusinessLogic().Execute(searchInput);

                        output.SuisitsuKensaNippoKensakuDT = searchOuput.SuisitsuKensaNippoKensakuDT;

                        output.DispMode = mode;
                    }
                    else
                    {
                        output.KensakuCheck = true;
                    }
				}
				else
				{
					output.ExecProcFailure = true;
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
