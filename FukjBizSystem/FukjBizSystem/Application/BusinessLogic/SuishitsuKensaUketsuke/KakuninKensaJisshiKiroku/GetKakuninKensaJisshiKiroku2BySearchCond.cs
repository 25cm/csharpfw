using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaDaicho9joHdrTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaUketsuke.KakuninKensaJisshiKiroku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKakuninKensaJisshiKiroku2BySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKakuninKensaJisshiKiroku2BySearchCondBLInput : ISelectKakuninKensaJisshiKiroku2BySearchCondDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKakuninKensaJisshiKiroku2BySearchCondBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKakuninKensaJisshiKiroku2BySearchCondBLInput : IGetKakuninKensaJisshiKiroku2BySearchCondBLInput
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
        // 20150121 sou End
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKakuninKensaJisshiKiroku2BySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKakuninKensaJisshiKiroku2BySearchCondBLOutput : ISelectKakuninKensaJisshiKiroku2BySearchCondDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKakuninKensaJisshiKiroku2BySearchCondBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKakuninKensaJisshiKiroku2BySearchCondBLOutput : IGetKakuninKensaJisshiKiroku2BySearchCondBLOutput
    {
        /// <summary>
        /// KakuninKensaJisshiKiroku2DataTable
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KakuninKensaJisshiKiroku2DataTable KakuninKensaJisshiKiroku2DT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKakuninKensaJisshiKiroku2BySearchCondBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKakuninKensaJisshiKiroku2BySearchCondBusinessLogic : BaseBusinessLogic<IGetKakuninKensaJisshiKiroku2BySearchCondBLInput, IGetKakuninKensaJisshiKiroku2BySearchCondBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKakuninKensaJisshiKiroku2BySearchCondBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKakuninKensaJisshiKiroku2BySearchCondBusinessLogic()
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
        /// 2014/12/02  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKakuninKensaJisshiKiroku2BySearchCondBLOutput Execute(IGetKakuninKensaJisshiKiroku2BySearchCondBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKakuninKensaJisshiKiroku2BySearchCondBLOutput output = new GetKakuninKensaJisshiKiroku2BySearchCondBLOutput();

            try
            {
                output.KakuninKensaJisshiKiroku2DT = new SelectKakuninKensaJisshiKiroku2BySearchCondDataAccess().Execute(input).KakuninKensaJisshiKiroku2DT;
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
