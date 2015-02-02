using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.Utility;
using FukjBizSystem.Application.BusinessLogic.Master.SuishitsuShikenKoumokuMstList;
using FukjBizSystem.Application.DataSet;

namespace FukjBizSystem.Application.ApplicationLogic.JokasoDaichoKanri.JokasoDaichoSuishitsuKensaKomokuInfo
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IShinkiBtnClickALInput
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
    interface IShinkiBtnClickALInput : IBseALInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShinkiBtnClickALInput
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
    class ShinkiBtnClickALInput : IShinkiBtnClickALInput
    {

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IShinkiBtnClickALOutput
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
    interface IShinkiBtnClickALOutput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShinkiBtnClickALOutput
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
    class ShinkiBtnClickALOutput : IShinkiBtnClickALOutput
    {
        /// <summary>
        /// SuishitsuKensaKomokuInfoSearchDataTable
        /// </summary>
        public SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable SuishitsuKensaKomokuInfoSearchDataTable {get; set;}
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShinkiBtnClickApplicationLogic
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
    class ShinkiBtnClickApplicationLogic : BaseApplicationLogic<IShinkiBtnClickALInput, IShinkiBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "浄化槽台帳水質検査項目情報：ShinkiBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShinkiBtnClickApplicationLogic
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
        public ShinkiBtnClickApplicationLogic()
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
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IShinkiBtnClickALOutput Execute(IShinkiBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IShinkiBtnClickALOutput output = new ShinkiBtnClickALOutput();

            output.SuishitsuKensaKomokuInfoSearchDataTable = new SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchDataTable();

            try
            {
                IGetSuishitsuShikenKoumokuMstInfoBLOutput blOutput = new GetSuishitsuShikenKoumokuMstInfoBusinessLogic().Execute(new GetSuishitsuShikenKoumokuMstInfoBLInput());
                
                foreach(SuishitsuShikenKoumokuMstDataSet.SuishitsuShikenKoumokuMstRow row in blOutput.SuishitsuShikenKoumokuMstDataTable)
                {
                    SuishitsuShikenKoumokuMstDataSet.SuishitsuKensaKomokuInfoSearchRow newRow = output.SuishitsuKensaKomokuInfoSearchDataTable.NewSuishitsuKensaKomokuInfoSearchRow();
                    newRow.AddFlg = "0";
                    newRow.SuishitsuShikenKoumokuCd = row.SuishitsuShikenKoumokuCd;
                    newRow.SuishitsuShikenKomokuAmt = row.SuishitsuShikenKomokuAmt;
                    newRow.SeishikiNm = row.SeishikiNm;
                    newRow.RyakushikiNm = row.RyakushikiNm;
                    newRow.KeiryouHouhouNmDown = row.KeiryouHouhouNmDown;
                    newRow.KeiryouHouhouNmUp = row.KeiryouHouhouNmUp;
                    newRow.DaichoKensaSetKomokuKbn = string.Empty;
                    newRow.DaichoKensaSetKomokuKbnDisp = string.Empty;
                    newRow.ColorFlg = "0";
                    newRow.DaichoKensaSetKomokuKbn = "2";
                    newRow.DaichoKensaSetKomokuKbnDisp = "単独";

                    output.SuishitsuKensaKomokuInfoSearchDataTable.AddSuishitsuKensaKomokuInfoSearchRow(newRow);
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
