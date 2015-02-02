using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.BusinessLogic.Master.SuishitsuKensaSetMstShosai;

namespace FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IChangeTorokuKbnALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IChangeTorokuKbnALInput : IBseALInput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable {get; set;}

        /// <summary>
        /// セットコード  
        /// </summary>
        string SetKomokuSetCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ChangeTorokuKbnALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ChangeTorokuKbnALInput : IChangeTorokuKbnALInput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable { get; set; }

        /// <summary>
        /// セットコード  
        /// </summary>
        public string SetKomokuSetCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("セットコード   {0}", SetKomokuSetCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IChangeTorokuKbnALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IChangeTorokuKbnALOutput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ChangeTorokuKbnALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ChangeTorokuKbnALOutput : IChangeTorokuKbnALOutput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ChangeTorokuKbnApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/11　HieuNH　　　新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ChangeTorokuKbnApplicationLogic : BaseApplicationLogic<IChangeTorokuKbnALInput, IChangeTorokuKbnALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "浄化槽台帳水質検査項目情報：ChangeTorokuKbn";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ChangeTorokuKbnApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/11　HieuNH　　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ChangeTorokuKbnApplicationLogic()
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
        /// 2014/12/11　HieuNH　　　新規作成
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
        /// 2014/12/11　HieuNH　　　新規作成
        /// 2014/12/22　HieuNH　　　Fix bug
        /// 2014/12/23  小松        単項目の試験項目も追加チェックをONで表示（変更可）
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IChangeTorokuKbnALOutput Execute(IChangeTorokuKbnALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IChangeTorokuKbnALOutput output = new ChangeTorokuKbnALOutput();

            try
            {
                IGetSetShikenKomokuMstBySetKomokuSetCdBLInput sskmBLInput = new GetSetShikenKomokuMstBySetKomokuSetCdBLInput();
                sskmBLInput.SetKomokuSetCd = input.SetKomokuSetCd;
                IGetSetShikenKomokuMstBySetKomokuSetCdBLOutput sskmBLOutput = new GetSetShikenKomokuMstBySetKomokuSetCdBusinessLogic().Execute(sskmBLInput);

                foreach (SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchRow row in input.SuishitsuKensaKomokuInfoSearchDataTable)
                {
                    System.Data.DataRow[] rows = sskmBLOutput.SetShikenKomokuMstDataTable.Select("SetKomokuCd = '"+ row.SuishitsuShikenKoumokuCd + "'");

                    if (rows.Length > 0)
                    {
                        row.DaichoKensaSetKomokuKbn = "1";
                        row.DaichoKensaSetKomokuKbnDisp = "セット";
                        row.AddFlg = "1";
                        row.ColorFlg = "1";
                    }
                    //// ADD HieuNH 2014/12/22 BEGIN
                    else
                    {
                        row.DaichoKensaSetKomokuKbn = "2";
                        row.DaichoKensaSetKomokuKbnDisp = "単独";
                        //row.AddFlg = "0";
                        row.ColorFlg = "0";
                    }
                    //// ADD HieuNH 2014/12/22 END
                }

                output.SuishitsuKensaKomokuInfoSearchDataTable = input.SuishitsuKensaKomokuInfoSearchDataTable;
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
