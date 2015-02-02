using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FukjBizSystem.Application.DataAccess.KensaDaichoDtlTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaKekkaInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput : ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput : IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        public string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        public string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }
        /// <summary>
        /// 試験項目コード
        /// </summary>
        public string ShikenkoumokuCd { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        public string SuishitsuKensaIraiNo { get; set; }
        /// <summary>
        /// 再検査回数
        /// </summary>
        public string SaikensaKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput : ISelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput : IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput
    {
        /// <summary>
        /// 検査台帳明細テーブル
        /// </summary>
        public KensaDaichoDtlTblDataSet.KensaDaichoDtlTblDataTable KensaDaichoDtlTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBusinessLogic : BaseBusinessLogic<IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput, IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBusinessLogic()
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
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput Execute(IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput output = new GetKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnBLOutput();

            try
            {
                output.KensaDaichoDtlTblDT = new SelectKensaDaichoDtlTblByKensaKbnIraiNendoShishoCdSuishitsuKensaIraiNoShikenkomokuCdSaikensaKbnDataAccess().Execute(input).KensaDaichoDtlTblDT;
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
