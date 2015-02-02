using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.KeiryoShomeiDaicho
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
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput, IGetKeiryoShomeiDaichoSearchByCondBLInput, IGetKeiryoShomeiDaichoUpdateDtByCondBLInput
    {
        
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
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// 検索条件
        /// </summary>
        public KeiryoShomeiDaichoSearchCond SearchCond { get; set; }

        /// <summary>
        /// 検索条件
        /// </summary>
        public KeiryoShomeiDaichoSearchCond UpdateDtSearchCond { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所コード[{0}], 試験項目コード[{1},{2},{3},{4},{5},{6},{7},{8},{9},{10}"
                    + ",{11},{12},{13},{14},{15},{16},{17},{18},{19},{20},{21},{22},{23},{24},{25},{26},{27},{28},{29},{30},{31},{32}]"
                    + ", 年度[{33}], 依頼受付日(開始)[{34}], 依頼受付日(終了)[{35}], 依頼No(開始)[{36}], 依頼No(終了)[{37}]",
                    new string[] { 
                        // 支所コード
                        SearchCond.ShishoCd, 
                        // 試験項目コード
                        SearchCond.KmkCdPh,
                        SearchCond.KmkCdSs,
                        SearchCond.KmkCdBodA,
                        SearchCond.KmkCdNh4n,
                        SearchCond.KmkCdCl,
                        SearchCond.KmkCdCod,
                        SearchCond.KmkCdHekisanA,
                        SearchCond.KmkCdMlss,
                        SearchCond.KmkCdTnA,
                        SearchCond.KmkCdAbsA,
                        SearchCond.KmkCdTpA,
                        SearchCond.KmkCdRinsan,
                        SearchCond.KmkCdNo2nTeiryo,
                        SearchCond.KmkCdNo3nTeiryo,
                        SearchCond.KmkCdAbsB,
                        SearchCond.KmkCdTnB,
                        SearchCond.KmkCdTpB,
                        SearchCond.KmkCdShikido,
                        SearchCond.KmkCdBodB,
                        SearchCond.KmkCdHekisanKoyu,
                        SearchCond.KmkCdHekisanDoshoku,
                        SearchCond.KmkCdHekisanB,
                        SearchCond.KmkCdNamari,
                        SearchCond.KmkCdAen,
                        SearchCond.KmkCdHouso,
                        SearchCond.KmkCdZanen,
                        SearchCond.KmkCdGaikan,
                        SearchCond.KmkCdShuki,
                        SearchCond.KmkCdTr,
                        SearchCond.KmkCdNo2nTeisei,
                        SearchCond.KmkCdNo3nTeisei,
                        SearchCond.KmkCdDaichokin,
                        // 年度
                        SearchCond.Nendo, 
                        // 依頼受付日(開始)
                        SearchCond.IraiUketsukeFromDt, 
                        // 依頼受付日(開始)
                        SearchCond.IraiUketsukeToDt, 
                        // 依頼No(開始)
                        SearchCond.IraiNoFrom, 
                        // 依頼No(終了)
                        SearchCond.IraiNoTo ,
                    });
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
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput : IGetKeiryoShomeiDaichoSearchByCondBLOutput, IGetKeiryoShomeiDaichoUpdateDtByCondBLOutput
    {
        
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
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// 計量証明台帳データテーブル
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoSearchDataTable  KeiryoShomeiDaichoDT { get; set; }
        /// <summary>
        /// 計量証明台帳データ更新日
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KeiryoShomeiDaichoUpdateDtDataTable KeiryoShomeiDaichoUpdateDtDT { get; set; }
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
    /// 2014/12/05  宗　　　　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KeiryoShomeiDaicho：KensakuBtnClickApplicationLogic";

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
        /// 2014/12/05  宗　　　　  新規作成
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
        /// 2014/12/05  宗　　　　  新規作成
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
        /// 2014/12/05  宗　　　　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                output.KeiryoShomeiDaichoDT = new GetKeiryoShomeiDaichoSearchByCondBusinessLogic().Execute(input).KeiryoShomeiDaichoDT;

                output.KeiryoShomeiDaichoUpdateDtDT = new GetKeiryoShomeiDaichoUpdateDtByCondBusinessLogic().Execute(input).KeiryoShomeiDaichoUpdateDtDT;
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
