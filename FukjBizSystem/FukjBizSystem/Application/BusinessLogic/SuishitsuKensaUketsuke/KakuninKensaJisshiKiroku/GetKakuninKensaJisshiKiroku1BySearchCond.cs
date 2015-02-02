using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaDaicho11joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKakuninKensaJisshiKiroku1BySearchCondBLInput
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
    interface IGetKakuninKensaJisshiKiroku1BySearchCondBLInput : ISelectKakuninKensaJisshiKiroku1BySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKakuninKensaJisshiKiroku1BySearchCondBLInput
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
    class GetKakuninKensaJisshiKiroku1BySearchCondBLInput : IGetKakuninKensaJisshiKiroku1BySearchCondBLInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        // 20150116 sou Start
        ///// <summary>
        ///// 水質検査受付日FROM
        ///// </summary>
        //public string UketsukeDtFrom { get; set; }
        //
        ///// <summary>
        ///// 水質検査受付日TO
        ///// </summary>
        //public string UketsukeDtTo { get; set; }

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
        /// 1 : 11条水質
        /// 2 : 外観検査
        /// </summary>
        public string RadioChoosed { get; set; }

        /// <summary>
        /// 水質検査依頼番号FROM
        /// </summary>
        public string SuishitsuIraiNoFrom { get; set; }

        /// <summary>
        /// 水質検査依頼番号TO
        /// </summary>
        public string SuishitsuIraiNoTo { get; set; }

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
        // 20150121 sou End
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKakuninKensaJisshiKiroku1BySearchCondBLOutput
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
    interface IGetKakuninKensaJisshiKiroku1BySearchCondBLOutput : ISelectKakuninKensaJisshiKiroku1BySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKakuninKensaJisshiKiroku1BySearchCondBLOutput
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
    class GetKakuninKensaJisshiKiroku1BySearchCondBLOutput : IGetKakuninKensaJisshiKiroku1BySearchCondBLOutput
    {
        /// <summary>
        /// KakuninKensaJisshiKiroku1DataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.KakuninKensaJisshiKiroku1DataTable KakuninKensaJisshiKiroku1DT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKakuninKensaJisshiKiroku1BySearchCondBusinessLogic
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
    class GetKakuninKensaJisshiKiroku1BySearchCondBusinessLogic : BaseBusinessLogic<IGetKakuninKensaJisshiKiroku1BySearchCondBLInput, IGetKakuninKensaJisshiKiroku1BySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKakuninKensaJisshiKiroku1BySearchCondBusinessLogic
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
        public GetKakuninKensaJisshiKiroku1BySearchCondBusinessLogic()
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
        /// 2014/11/27  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKakuninKensaJisshiKiroku1BySearchCondBLOutput Execute(IGetKakuninKensaJisshiKiroku1BySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKakuninKensaJisshiKiroku1BySearchCondBLOutput output = new GetKakuninKensaJisshiKiroku1BySearchCondBLOutput();

            try
            {
                output.KakuninKensaJisshiKiroku1DT = new SelectKakuninKensaJisshiKiroku1BySearchCondDataAccess().Execute(input).KakuninKensaJisshiKiroku1DT;
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
