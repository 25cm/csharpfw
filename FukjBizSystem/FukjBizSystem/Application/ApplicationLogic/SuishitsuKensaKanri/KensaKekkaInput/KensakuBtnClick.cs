using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Zynas.Framework.Core.Base.ApplicationLogic;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.BusinessLogic.SuishitsuKensaKanri.KensaKekkaInput;
using Zynas.Framework.Utility;
using System.Reflection;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaKanri.KensaKekkaInput
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
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 検査区分
        /// </summary>
        string KensaKbn { get; set; }
        /// <summary>
        /// 依頼年度
        /// </summary>
        string IraiNendo { get; set; }
        /// <summary>
        /// 支所コード
        /// </summary>
        string ShishoCd { get; set; }
        /// <summary>
        /// 試験項目コード
        /// </summary>
        string ShikenkoumokuCd { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        string SuishitsuKensaIraiNoFrom { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        string SuishitsuKensaIraiNoTo { get; set; }
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
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALInput : IKensakuBtnClickALInput
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
        public string SuishitsuKensaIraiNoFrom { get; set; }
        /// <summary>
        /// 水質検査依頼番号
        /// </summary>
        public string SuishitsuKensaIraiNoTo { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査区分[{0}], 依頼年度[{1}], 支所コード[{2}], 試験項目コード[{3}], 水質検査依頼番号[{4}], 水質検査依頼番号[{5}]",
                    KensaKbn, IraiNendo, ShishoCd, ShikenkoumokuCd, SuishitsuKensaIraiNoFrom, SuishitsuKensaIraiNoTo);
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
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KensaKekkaInputSearch1DataTable
        /// </summary>
        KensaDaicho11joHdrTblDataSet.KensaKekkaInputSearch1DataTable KensaKekkaInputSearch1DataTable { get; set; }

        /// <summary>
        /// KensaKekkaInputSearch2DataTable
        /// </summary>
        KensaDaicho9joHdrTblDataSet.KensaKekkaInputSearch2DataTable KensaKekkaInputSearch2DataTable { get; set; }
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
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickALOutput : IKensakuBtnClickALOutput
    {
        /// <summary>
        /// KensaKekkaInputSearch1DataTable
        /// </summary>
        public KensaDaicho11joHdrTblDataSet.KensaKekkaInputSearch1DataTable KensaKekkaInputSearch1DataTable { get; set; }

        /// <summary>
        /// KensaKekkaInputSearch2DataTable
        /// </summary>
        public KensaDaicho9joHdrTblDataSet.KensaKekkaInputSearch2DataTable KensaKekkaInputSearch2DataTable { get; set; }
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
    /// 2014/12/02　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KensakuBtnClickApplicationLogic : BaseApplicationLogic<IKensakuBtnClickALInput, IKensakuBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKekkaInput：KensakuBtnClick";

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
        /// 2014/12/02　HieuNH　　　新規作成
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
        /// 2014/12/02　HieuNH　　　新規作成
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
        /// 2014/12/02　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKensakuBtnClickALOutput Execute(IKensakuBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKensakuBtnClickALOutput output = new KensakuBtnClickALOutput();

            try
            {
                if (!string.IsNullOrEmpty(input.KensaKbn) && (input.KensaKbn.Equals("2") || input.KensaKbn.Equals("3")))
                {
                    IGetKensaKekkaInputSearch1ByCondBLInput search1BLInput = new GetKensaKekkaInputSearch1ByCondBLInput();
                    search1BLInput.SearchCond = new KensaKekkaInputSearch1SearchCond();
                    search1BLInput.SearchCond.KensaKbn = input.KensaKbn;
                    search1BLInput.SearchCond.IraiNendo = input.IraiNendo;
                    search1BLInput.SearchCond.ShikenkoumokuCd = input.ShikenkoumokuCd;
                    search1BLInput.SearchCond.ShishoCd = input.ShishoCd;
                    search1BLInput.SearchCond.SuishitsuKensaIraiNoFrom = input.SuishitsuKensaIraiNoFrom;
                    search1BLInput.SearchCond.SuishitsuKensaIraiNoTo = input.SuishitsuKensaIraiNoTo;

                    IGetKensaKekkaInputSearch1ByCondBLOutput search1BLOutput = new GetKensaKekkaInputSearch1ByCondBusinessLogic().Execute(search1BLInput);
                    output.KensaKekkaInputSearch1DataTable = search1BLOutput.KensaKekkaInputSearch1DataTable;
                }
                else
                {
                    IGetKensaKekkaInputSearch2ByCondBLInput search2BLInput = new GetKensaKekkaInputSearch2ByCondBLInput();
                    search2BLInput.SearchCond = new KensaKekkaInputSearch2SearchCond();
                    search2BLInput.SearchCond.IraiNendo = input.IraiNendo;
                    search2BLInput.SearchCond.ShikenkoumokuCd = input.ShikenkoumokuCd;
                    search2BLInput.SearchCond.ShishoCd = input.ShishoCd;
                    search2BLInput.SearchCond.SuishitsuKensaIraiNoFrom = input.SuishitsuKensaIraiNoFrom;
                    search2BLInput.SearchCond.SuishitsuKensaIraiNoTo = input.SuishitsuKensaIraiNoTo;

                    IGetKensaKekkaInputSearch2ByCondBLOutput search2BLOutput = new GetKensaKekkaInputSearch2ByCondBusinessLogic().Execute(search2BLInput);
                    output.KensaKekkaInputSearch2DataTable = search2BLOutput.KensaKekkaInputSearch2DataTable;
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
