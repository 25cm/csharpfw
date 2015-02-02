using System;
using System.Reflection;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaDaicho9joHdrTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.DataAccess;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.DataAccess.KensaDaicho9joHdrTbl
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ISelectKakuninKensaJisshiKiroku2BySearchCondDAInput
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
    interface ISelectKakuninKensaJisshiKiroku2BySearchCondDAInput
    {
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }

        // 20150116 sou Start
        ///// <summary>
        ///// 水質検査受付日FROM
        ///// </summary>
        //string UketsukeDtFrom { get; set; }
        //
        ///// <summary>
        ///// 水質検査受付日TO
        ///// </summary>
        //string UketsukeDtTo { get; set; }

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
        /// 水質検査依頼番号FROM
        /// </summary>
        string SuishitsuIraiNoFrom { get; set; }

        /// <summary>
        /// 水質検査依頼番号TO
        /// </summary>
        string SuishitsuIraiNoTo { get; set; }

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
        // 20150121 sou End
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKakuninKensaJisshiKiroku2BySearchCondDAInput
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
    class SelectKakuninKensaJisshiKiroku2BySearchCondDAInput : ISelectKakuninKensaJisshiKiroku2BySearchCondDAInput
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
    //  インターフェイス名 ： ISelectKakuninKensaJisshiKiroku2BySearchCondDAOutput
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
    interface ISelectKakuninKensaJisshiKiroku2BySearchCondDAOutput
    {
        /// <summary>
        /// KakuninKensaJisshiKiroku2DataTable
        /// </summary>
        KensaDaicho9joHdrTblDataSet.KakuninKensaJisshiKiroku2DataTable KakuninKensaJisshiKiroku2DT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKakuninKensaJisshiKiroku2BySearchCondDAOutput
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
    class SelectKakuninKensaJisshiKiroku2BySearchCondDAOutput : ISelectKakuninKensaJisshiKiroku2BySearchCondDAOutput
    {
        /// <summary>
        /// KakuninKensaJisshiKiroku2DataTable
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KakuninKensaJisshiKiroku2DataTable KakuninKensaJisshiKiroku2DT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SelectKakuninKensaJisshiKiroku2BySearchCondDataAccess
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
    class SelectKakuninKensaJisshiKiroku2BySearchCondDataAccess : BaseDataAccess<ISelectKakuninKensaJisshiKiroku2BySearchCondDAInput, ISelectKakuninKensaJisshiKiroku2BySearchCondDAOutput>
    {
        #region プロパティ(private)

        /// <summary>
        /// テーブルアダプタ
        /// </summary>
        private KakuninKensaJisshiKiroku2TableAdapter tableAdapter = new KakuninKensaJisshiKiroku2TableAdapter();

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： SelectKakuninKensaJisshiKiroku2BySearchCondDataAccess
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
        public SelectKakuninKensaJisshiKiroku2BySearchCondDataAccess()
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
        public override ISelectKakuninKensaJisshiKiroku2BySearchCondDAOutput Execute(ISelectKakuninKensaJisshiKiroku2BySearchCondDAInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ISelectKakuninKensaJisshiKiroku2BySearchCondDAOutput output = new SelectKakuninKensaJisshiKiroku2BySearchCondDAOutput();

            try
            {
                // 接続の解決
                tableAdapter.Connection = AddSqlConnection(tableAdapter.Connection);

                output.KakuninKensaJisshiKiroku2DT = tableAdapter.GetDataBySearchCond(  input.ShishoCd,
                                                                                        input.Nendo,
                                                                                        input.IraiUketsukeDtFrom,
                                                                                        input.IraiUketsukeDtTo,
                                                                                        input.SuishitsuIraiNoFrom,
                                                                                        // 20150121 sou Start
                                                                                        //input.SuishitsuIraiNoTo);
                                                                                        input.SuishitsuIraiNoTo,
                                                                                        input.kmkCdBodA,
                                                                                        input.kmkCdBodB,
                                                                                        input.kmkCdTr,
                                                                                        input.kmkCdCl,
                                                                                        input.kmkCdSs,
                                                                                        input.kmkCdNh4n,
                                                                                        input.kmkCdTnA,
                                                                                        input.kmkCdTnB,
                                                                                        input.kmkCdCod,
                                                                                        input.kmkCdGaikan,
                                                                                        input.kmkCdShuki,
                                                                                        input.kmkCdNo2n,
                                                                                        input.kmkCdNo3n);
                                                                                        // 20150121 sou End

            }
            catch (Exception e)
            {
                // トレースログ出力
                TraceLog.ErrorWrite(MethodInfo.GetCurrentMethod(), string.Format("エラー内容:{0}", e.Message));

                // ＤＢエラー
                throw new CustomException(ResultCode.DBError, string.Format("エラー内容:{0}", e.Message));
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
