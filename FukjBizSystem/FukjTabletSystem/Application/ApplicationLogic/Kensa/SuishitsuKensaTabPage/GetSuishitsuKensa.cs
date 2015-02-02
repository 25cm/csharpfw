using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Kensa;
using FukjTabletSystem.Application.BusinessLogic.Kensa.SuishitsuKensaTabPage;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Kensa.SuishitsuKensaTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKensaALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKensaALInput : IBseALInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        string IraiRenban { get; set; }

        /// <summary>
        /// ScreeningKbn（スクリーニング区分）
        /// </summary>
        string ScreeningKbn { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKensaALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKensaALInput : IGetSuishitsuKensaALInput
    {
        /// <summary>
        /// IraiHoteiKbn
        /// </summary>
        public string IraiHoteiKbn { get; set; }

        /// <summary>
        /// IraiHokenjoCd
        /// </summary>
        public string IraiHokenjoCd { get; set; }

        /// <summary>
        /// IraiNendo
        /// </summary>
        public string IraiNendo { get; set; }

        /// <summary>
        /// IraiRenban
        /// </summary>
        public string IraiRenban { get; set; }
        
        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get{return string.Empty;}
        }

        /// <summary>
        /// ScreeningKbn（スクリーニング区分）
        /// </summary>
        public string ScreeningKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSuishitsuKensaALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetSuishitsuKensaALOutput :
        IGetKensaKekkaTblByKensaIraiKeyBLOutput,
        IGetLastKensaKekkaTblByKensaIraiKeyBLOutput,
        IGetSaiSaisuiTblByKensaIraiKeyBLOutput,
        IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKensaALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKensaALOutput : IGetSuishitsuKensaALOutput
    {
        /// <summary>
        /// 検査結果（今回）　KensaKekkaTblByKensaIraiKeyDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable KensaKekkaTbl { get; set; }

        /// <summary>
        /// 検査結果（前回）　KensaKekkaTblByKensaIraiKeyDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaTblByKensaIraiKeyDataTable LastKensaKekkaTbl{ get; set; }

        /// <summary>
        /// 再採水　SaiSaisuiTblByKensaIraiKeyDataTable
        /// </summary>
        public SaiSaisuiTblDataSet.SaiSaisuiTblByKensaIraiKeyDataTable SaiSaisuiTbl { get; set; }

        /// <summary>
        /// 処理方式別水質検査実施マスタ　ShoriHoshikiSuishitsuKensaJisshiMstDataTable
        /// </summary>
        public ShoriHoshikiSuishitsuKensaJisshiMstDataSet.ShoriHoshikiSuishitsuKensaJisshiMstDataTable ShoriHoshikiSuishitsuKensaJisshiMst { get; set; }

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSuishitsuKensaApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/18　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetSuishitsuKensaApplicationLogic : BaseApplicationLogic<IGetSuishitsuKensaALInput, IGetSuishitsuKensaALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SuishitsuKensaTabPage：GetSuishitsuKensa";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSuishitsuKensaApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetSuishitsuKensaApplicationLogic()
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
        /// 2014/11/18　戸口　　    新規作成
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
        /// 検査依頼のスクリーニング区分に応じて、表示データを取得する。
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/18　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetSuishitsuKensaALOutput Execute(IGetSuishitsuKensaALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSuishitsuKensaALOutput output = new GetSuishitsuKensaALOutput();

            try
            {
                // 検査結果テーブルの今回分を取得する
                IGetKensaKekkaTblByKensaIraiKeyBLInput kekkaInput = new GetKensaKekkaTblByKensaIraiKeyBLInput();
                kekkaInput.IraiHoteiKbn = input.IraiHoteiKbn;
                kekkaInput.IraiHokenjoCd = input.IraiHokenjoCd;
                kekkaInput.IraiNendo = input.IraiNendo;
                kekkaInput.IraiRenban = input.IraiRenban;
                IGetKensaKekkaTblByKensaIraiKeyBLOutput blOutputKekka = new GetKensaKekkaTblByKensaIraiKeyBusinessLogic().Execute(kekkaInput);
                output.KensaKekkaTbl = blOutputKekka.KensaKekkaTbl;

                // 処理方式別水質検査実施マスタを全件取得する。（内部キャッシュ用）
                IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLInput jisshiInput = new GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLInput();
                jisshiInput.IraiHoteiKbn = input.IraiHoteiKbn;
                jisshiInput.IraiHokenjoCd = input.IraiHokenjoCd;
                jisshiInput.IraiNendo = input.IraiNendo;
                jisshiInput.IraiRenban = input.IraiRenban;
                IGetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBLOutput blOutputKensaJisshiMst = new GetShoriHoshikiSuishitsuKensaJisshiMstByKensaIraiKeyBusinessLogic().Execute(jisshiInput);
                output.ShoriHoshikiSuishitsuKensaJisshiMst = blOutputKensaJisshiMst.ShoriHoshikiSuishitsuKensaJisshiMst;
                
                if( input.ScreeningKbn.Equals("0") )
                {
                    // 検査結果テーブルの前回分を取得する
                    IGetLastKensaKekkaTblByKensaIraiKeyBLInput lastInput = new GetLastKensaKekkaTblByKensaIraiKeyBLInput();
                    lastInput.IraiHoteiKbn = input.IraiHoteiKbn;
                    lastInput.IraiHokenjoCd = input.IraiHokenjoCd;
                    lastInput.IraiNendo = input.IraiNendo;
                    lastInput.IraiRenban = input.IraiRenban;
                    IGetLastKensaKekkaTblByKensaIraiKeyBLOutput blOutputLast = new GetLastKensaKekkaTblByKensaIraiKeyBusinessLogic().Execute(lastInput);
                    output.LastKensaKekkaTbl = blOutputLast.LastKensaKekkaTbl;
                }
                else
                {
                    //再採水テーブルを取得する
                    IGetSaiSaisuiTblByKensaIraiKeyBLInput saisuiInput = new GetSaiSaisuiTblByKensaIraiKeyBLInput();
                    saisuiInput.IraiHoteiKbn = input.IraiHoteiKbn;
                    saisuiInput.IraiHokenjoCd = input.IraiHokenjoCd;
                    saisuiInput.IraiNendo = input.IraiNendo;
                    saisuiInput.IraiRenban = input.IraiRenban;
                    IGetSaiSaisuiTblByKensaIraiKeyBLOutput blOutputSaisui = new GetSaiSaisuiTblByKensaIraiKeyBusinessLogic().Execute(saisuiInput);
                    output.SaiSaisuiTbl = blOutputSaisui.SaiSaisuiTbl;
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
