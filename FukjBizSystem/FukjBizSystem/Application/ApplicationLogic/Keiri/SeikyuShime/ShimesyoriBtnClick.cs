using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShime;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Keiri.SeikyuShime
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IShimesyoriBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IShimesyoriBtnClickALInput : IBseALInput, IExecProcSeikyuShimeBLInput
    {
        /// <summary>
        /// 日報未完了チェック
        /// </summary>
        bool ReportCheck { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShimesyoriBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ShimesyoriBtnClickALInput : IShimesyoriBtnClickALInput
    {
        /// <summary>
        /// 日報未完了チェック
        /// </summary>
        public bool ReportCheck { get; set; }

        /// <summary>
        /// 締め区分
        /// </summary>
        public string ShimeKbn { get; set; }

        /// <summary>
        /// 締め年月
        /// </summary>
        public string ShimeDt { get; set; }

        /// <summary>
        /// 業者コード（開始）
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード（終了）
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 請求日
        /// </summary>
        public string SeikyuDt { get; set; }

        /// <summary>
        /// 締め済業者/削除・再作成
        /// </summary>
        public string ShimeSumi { get; set; }

        /// <summary>
        /// Server DateTime
        /// </summary>
        public DateTime Now { get; set; }

        /// <summary>
        /// LoginUser
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// PcUpdate
        /// </summary>
        public string PcUpdate { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("日報未完了チェック[{0}], 締め区分[{1}], 締め年月[{2}], 業者コード（開始）[{3}], 業者コード（終了）[{4}], 請求日[{5}], 締め済業者/削除・再作成[{6}], ServerDateTime[{7}], LoginUser[{8}], PcUpdate[{9}], 年度[{10}]", 
                    new string[]{
                        ReportCheck.ToString(),
                        ShimeKbn,
                        ShimeDt,
                        GyoshaCdFrom,
                        GyoshaCdTo,
                        SeikyuDt,
                        ShimeSumi,
                        Now.ToString("yyyyMMdd"),
                        LoginUser,
                        PcUpdate,
                        Nendo
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IShimesyoriBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IShimesyoriBtnClickALOutput : IExecProcSeikyuShimeBLOutput, 
                                            ICountDailyReportIncompleteByCondBLOutput,
                                            ICountKeiryoShomeiReportIncompleteByCondBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShimesyoriBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ShimesyoriBtnClickALOutput : IShimesyoriBtnClickALOutput
    {
        /// <summary>
        /// Error Flag
        /// </summary>
        public string ErrorFlg { get; set; }

        /// <summary>
        /// DailyReportInCompleteCount
        /// </summary>
        public int DailyReportInCompleteCount { get; set; }

        /// <summary>
        /// KeiryouShomeiIncompleteCount
        /// </summary>
        public int KeiryouShomeiIncompleteCount { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShimesyoriBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/24  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ShimesyoriBtnClickApplicationLogic : BaseApplicationLogic<IShimesyoriBtnClickALInput, IShimesyoriBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SeikyuShime：ShimesyoriBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShimesyoriBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/24  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShimesyoriBtnClickApplicationLogic()
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
        /// 2014/09/24  DatNT　  新規作成
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
        /// 2014/09/24  DatNT　  新規作成
        /// 2014/10/29  DatNT    v1.03
        /// 2014/12/10  kiyokuni v1.07
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IShimesyoriBtnClickALOutput Execute(IShimesyoriBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IShimesyoriBtnClickALOutput output = new ShimesyoriBtnClickALOutput();

            try
            {
                if (input.ReportCheck)
                {
                    ICountDailyReportIncompleteByCondBLInput blInput = new CountDailyReportIncompleteByCondBLInput();
                    blInput.KensaIraiKensaNenTsuki  = input.ShimeDt;
                    blInput.GyoshaCdFrom            = input.GyoshaCdFrom;
                    blInput.GyoshaCdTo              = input.GyoshaCdTo;
                    blInput.ShimeKbn                = input.ShimeKbn;
                    output.DailyReportInCompleteCount = new CountDailyReportIncompleteByCondBusinessLogic().Execute(blInput).DailyReportInCompleteCount;

                    ICountKeiryoShomeiReportIncompleteByCondBLInput shomeiBLInput = new CountKeiryoShomeiReportIncompleteByCondBLInput();
                    shomeiBLInput.KensaIraiKensaNenTsuki = input.ShimeDt;
                    shomeiBLInput.GyoshaCdFrom = input.GyoshaCdFrom;
                    shomeiBLInput.GyoshaCdTo = input.GyoshaCdTo;
                    shomeiBLInput.ShimeKbn          = input.ShimeKbn;
                    output.KeiryouShomeiIncompleteCount = new CountKeiryoShomeiReportIncompleteByCondBusinessLogic().Execute(shomeiBLInput).KeiryouShomeiIncompleteCount;
                }
                else
                {
                    output.ErrorFlg = new ExecProcSeikyuShimeBusinessLogic().Execute(input).ErrorFlg;
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
