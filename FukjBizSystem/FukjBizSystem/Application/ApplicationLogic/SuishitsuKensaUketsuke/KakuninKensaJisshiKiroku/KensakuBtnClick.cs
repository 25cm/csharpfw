using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku
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
    /// 2014/11/27  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        // 20150116 sou Start
        ///// <summary>
        ///// 年度FROM
        ///// </summary>
        //string NendoFrom { get; set; }
        //
        ///// <summary>
        ///// 年度TO
        ///// </summary>
        //string NendoTo { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        string Nendo { get; set; }
        // 20150116 sou End

        /// <summary>
        /// 依頼受付日（開始）
        /// </summary>
        string IraiUketsukeDtFrom { get; set; }

        /// <summary>
        /// 依頼受付日（終了）
        /// </summary>
        string IraiUketsukeDtTo { get; set; }

        /// <summary>
        /// RadioChoosed
        /// </summary>
        string RadioChoosed { get; set; }

        /// <summary>
        /// 依頼No（開始）
        /// </summary>
        string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼No（終了）
        /// </summary>
        string IraiNoTo { get; set; }

        // 20150121 sou Start
        /// <summary>
        /// 試験項目コード(BODA)
        /// </summary>
        string kmkCdBodA { get; set; }

        /// <summary>
        /// 試験項目コード(BODB)
        /// </summary>
        string kmkCdBodB { get; set; }

        /// <summary>
        /// 試験項目コード(透視度)
        /// </summary>
        string kmkCdTr { get; set; }

        /// <summary>
        /// 試験項目コード(外観)
        /// </summary>
        string kmkCdGaikan { get; set; }

        /// <summary>
        /// 試験項目コード(臭気)
        /// </summary>
        string kmkCdShuki { get; set; }

        /// <summary>
        /// 試験項目コード(亜硝酸性窒素(定性))
        /// </summary>
        string kmkCdNo2n { get; set; }

        /// <summary>
        /// 試験項目コード(硝酸性窒素(定性))
        /// </summary>
        string kmkCdNo3n { get; set; }

        /// <summary>
        /// 試験項目コード(塩化物イオン)
        /// </summary>
        string kmkCdCl { get; set; }

        /// <summary>
        /// 試験項目コード(SS)
        /// </summary>
        string kmkCdSs { get; set; }

        /// <summary>
        /// 試験項目コード(アンモニア性窒素)
        /// </summary>
        string kmkCdNh4n { get; set; }

        /// <summary>
        /// 試験項目コード(全窒素A)
        /// </summary>
        string kmkCdTnA { get; set; }

        /// <summary>
        /// 試験項目コード(全窒素B)
        /// </summary>
        string kmkCdTnB { get; set; }

        /// <summary>
        /// 試験項目コード(COD)
        /// </summary>
        string kmkCdCod { get; set; }
        // 20150121 sou End
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
    /// 2014/11/27  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        // 20150116 sou Start
        ///// <summary>
        ///// 年度FROM
        ///// </summary>
        //public string NendoFrom { get; set; }
        //
        ///// <summary>
        ///// 年度TO
        ///// </summary>
        //public string NendoTo { get; set; }

        /// <summary>
        /// 年度
        /// </summary>
        public string Nendo { get; set; }
        // 20150116 sou End

        /// <summary>
        /// 依頼受付日（開始）
        /// </summary>
        public string IraiUketsukeDtFrom { get; set; }

        /// <summary>
        /// 依頼受付日（終了）
        /// </summary>
        public string IraiUketsukeDtTo { get; set; }

        /// <summary>
        /// RadioChoosed
        /// </summary>
        public string RadioChoosed { get; set; }

        /// <summary>
        /// 依頼No（開始）
        /// </summary>
        public string IraiNoFrom { get; set; }

        /// <summary>
        /// 依頼No（終了）
        /// </summary>
        public string IraiNoTo { get; set; }

        // 20150121 sou Start
        /// <summary>
        /// 試験項目コード(BODA)
        /// </summary>
        public string kmkCdBodA { get; set; }

        /// <summary>
        /// 試験項目コード(BODB)
        /// </summary>
        public string kmkCdBodB { get; set; }

        /// <summary>
        /// 試験項目コード(透視度)
        /// </summary>
        public string kmkCdTr { get; set; }

        /// <summary>
        /// 試験項目コード(外観)
        /// </summary>
        public string kmkCdGaikan { get; set; }

        /// <summary>
        /// 試験項目コード(臭気)
        /// </summary>
        public string kmkCdShuki { get; set; }

        /// <summary>
        /// 試験項目コード(亜硝酸性窒素(定性))
        /// </summary>
        public string kmkCdNo2n { get; set; }

        /// <summary>
        /// 試験項目コード(硝酸性窒素(定性))
        /// </summary>
        public string kmkCdNo3n { get; set; }

        /// <summary>
        /// 試験項目コード(塩化物イオン)
        /// </summary>
        public string kmkCdCl { get; set; }

        /// <summary>
        /// 試験項目コード(SS)
        /// </summary>
        public string kmkCdSs { get; set; }

        /// <summary>
        /// 試験項目コード(アンモニア性窒素)
        /// </summary>
        public string kmkCdNh4n { get; set; }

        /// <summary>
        /// 試験項目コード(全窒素A)
        /// </summary>
        public string kmkCdTnA { get; set; }

        /// <summary>
        /// 試験項目コード(全窒素B)
        /// </summary>
        public string kmkCdTnB { get; set; }

        /// <summary>
        /// 試験項目コード(COD)
        /// </summary>
        public string kmkCdCod { get; set; }
        // 20150121 sou End

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("支所コード[{0}], 年度[{1}], 依頼受付日（開始）[{2}], 依頼受付日（終了）[{3}], RadioChoosed[{4}], 依頼No（開始）[{5}], 依頼No（終了）[{6}]", 
                    new string[]{
                        ShishoCd,
                        Nendo,
                        IraiUketsukeDtFrom,
                        IraiUketsukeDtTo,
                        RadioChoosed,
                        IraiNoFrom,
                        IraiNoTo
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
    /// 2014/11/27  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput : IGetKakuninKensaJisshiKiroku1BySearchCondBLOutput, IGetKakuninKensaJisshiKiroku2BySearchCondBLOutput
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
    /// 2014/11/27  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KakuninKensaJisshiKiroku1DataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.KakuninKensaJisshiKiroku1DataTable KakuninKensaJisshiKiroku1DT { get; set; }

        /// <summary>
        /// KakuninKensaJisshiKiroku2DataTable
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KakuninKensaJisshiKiroku2DataTable KakuninKensaJisshiKiroku2DT { get; set; }
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
    /// 2014/11/27  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KakuninKensaJisshiKiroku：KensakuBtnClickApplicationLogic";

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
        /// 2014/11/27  DatNT　  新規作成
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
        /// 2014/11/27  DatNT　  新規作成
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
        /// 2014/11/27  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                if (input.RadioChoosed == "2" || input.RadioChoosed == "3")
                {
                    // 水質検査、外観検査
                    IGetKakuninKensaJisshiKiroku1BySearchCondBLInput blInput = new GetKakuninKensaJisshiKiroku1BySearchCondBLInput();
                    blInput.ShishoCd = input.ShishoCd;
                    blInput.IraiUketsukeDtFrom = input.IraiUketsukeDtFrom;
                    blInput.IraiUketsukeDtTo = input.IraiUketsukeDtTo;
                    blInput.RadioChoosed = input.RadioChoosed;
                    blInput.SuishitsuIraiNoFrom = input.IraiNoFrom;
                    blInput.SuishitsuIraiNoTo = input.IraiNoTo;
                    // 20150116 sou Start
                    //blInput.UketsukeDtFrom = input.NendoFrom;
                    //blInput.UketsukeDtTo = input.NendoTo;
                    blInput.Nendo = input.Nendo;
                    // 20150116 sou End
                    // 20150121 sou Start
                    blInput.kmkCdBodA = input.kmkCdBodA;
                    blInput.kmkCdBodB = input.kmkCdBodB;
                    blInput.kmkCdTr = input.kmkCdTr;
                    blInput.kmkCdGaikan = input.kmkCdGaikan;
                    blInput.kmkCdShuki = input.kmkCdShuki;
                    blInput.kmkCdNo2n = input.kmkCdNo2n;
                    blInput.kmkCdNo3n = input.kmkCdNo3n;
                    blInput.kmkCdCl = input.kmkCdCl;
                    // 20150121 sou End
                    IGetKakuninKensaJisshiKiroku1BySearchCondBLOutput blOutput = new GetKakuninKensaJisshiKiroku1BySearchCondBusinessLogic().Execute(blInput);

                    if (blOutput.KakuninKensaJisshiKiroku1DT != null && blOutput.KakuninKensaJisshiKiroku1DT.Count > 0)
                    {
                        output.KakuninKensaJisshiKiroku1DT = blOutput.KakuninKensaJisshiKiroku1DT;
                    }
                }
                else
                {
                    // 計量証明
                    IGetKakuninKensaJisshiKiroku2BySearchCondBLInput blInput = new GetKakuninKensaJisshiKiroku2BySearchCondBLInput();
                    blInput.ShishoCd = input.ShishoCd;
                    blInput.IraiUketsukeDtFrom = input.IraiUketsukeDtFrom;
                    blInput.IraiUketsukeDtTo = input.IraiUketsukeDtTo;
                    blInput.SuishitsuIraiNoFrom = input.IraiNoFrom;
                    blInput.SuishitsuIraiNoTo = input.IraiNoTo;
                    // 20150116 sou Start
                    //blInput.UketsukeDtFrom = input.NendoFrom;
                    //blInput.UketsukeDtTo = input.NendoTo;
                    blInput.Nendo = input.Nendo;
                    // 20150116 sou End
                    // 20150121 sou Start
                    blInput.kmkCdBodA = input.kmkCdBodA;
                    blInput.kmkCdBodB = input.kmkCdBodB;
                    blInput.kmkCdTr = input.kmkCdTr;
                    blInput.kmkCdCl = input.kmkCdCl;
                    blInput.kmkCdSs = input.kmkCdSs;
                    blInput.kmkCdNh4n = input.kmkCdNh4n;
                    blInput.kmkCdTnA = input.kmkCdTnA;
                    blInput.kmkCdTnB = input.kmkCdTnB;
                    blInput.kmkCdCod = input.kmkCdCod;
                    blInput.kmkCdGaikan = input.kmkCdGaikan;
                    blInput.kmkCdShuki = input.kmkCdShuki;
                    blInput.kmkCdNo2n = input.kmkCdNo2n;
                    blInput.kmkCdNo3n = input.kmkCdNo3n;
                    // 20150121 sou End
                    IGetKakuninKensaJisshiKiroku2BySearchCondBLOutput blOutput = new GetKakuninKensaJisshiKiroku2BySearchCondBusinessLogic().Execute(blInput);

                    if (blOutput.KakuninKensaJisshiKiroku2DT != null && blOutput.KakuninKensaJisshiKiroku2DT.Count > 0)
                    {
                        output.KakuninKensaJisshiKiroku2DT = blOutput.KakuninKensaJisshiKiroku2DT;
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
