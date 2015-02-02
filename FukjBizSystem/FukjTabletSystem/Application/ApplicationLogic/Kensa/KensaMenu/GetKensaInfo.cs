using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Kensa.KensaMenu;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Kensa.KensaMenu
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaInfoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaInfoALInput : IBseALInput
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
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaInfoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaInfoALInput : IGetKensaInfoALInput
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
            get
            {
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaInfoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetKensaInfoALOutput : IGetKensaYoteiListByKensaIraiKeyBLOutput, IGetJokasoDaichoMstLocationByKensaIraiKeyBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaInfoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaInfoALOutput : IGetKensaInfoALOutput
    {
        /// <summary>
        /// KensaYoteiListDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaYoteiListDataTable KensaYoteiList { get; set; }

        /// <summary>
        /// JokasoDaichoMstLocationDataTable
        /// </summary>
        public JokasoDaichoMstDataSet.JokasoDaichoMstLocationDataTable JokasoDaichoMstLocation { get; set; }

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaYoteiListByKensaIraiKeyApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/30　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaInfoApplicationLogic : BaseApplicationLogic<IGetKensaInfoALInput, IGetKensaInfoALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaMenu：GetKensaInfo";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaYoteiListByKensaIraiKeyApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/30　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaInfoApplicationLogic()
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
        /// 2014/10/30　豊田　　    新規作成
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
        /// 2014/10/30　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaInfoALOutput Execute(IGetKensaInfoALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaInfoALOutput output = new GetKensaInfoALOutput();

            try
            {
                // 検査予定情報の取得
                IGetKensaYoteiListByKensaIraiKeyBLInput yoteiInput = new GetKensaYoteiListByKensaIraiKeyBLInput();
                
                yoteiInput.IraiHoteiKbn = input.IraiHoteiKbn;
                yoteiInput.IraiHokenjoCd= input.IraiHokenjoCd;
                yoteiInput.IraiNendo = input.IraiNendo;
                yoteiInput.IraiRenban = input.IraiRenban;

                IGetKensaYoteiListByKensaIraiKeyBLOutput yoteiOutput = new GetKensaYoteiListByKensaIraiKeyBusinessLogic().Execute(yoteiInput);

                output.KensaYoteiList = yoteiOutput.KensaYoteiList;
                
                // 位置情報の取得
                IGetJokasoDaichoMstLocationByKensaIraiKeyBLInput locationInput = new GetJokasoDaichoMstLocationByKensaIraiKeyBLInput();

                locationInput.IraiHoteiKbn = input.IraiHoteiKbn;
                locationInput.IraiHokenjoCd = input.IraiHokenjoCd;
                locationInput.IraiNendo = input.IraiNendo;
                locationInput.IraiRenban = input.IraiRenban;

                IGetJokasoDaichoMstLocationByKensaIraiKeyBLOutput locationOutput = new GetJokasoDaichoMstLocationByKensaIraiKeyBusinessLogic().Execute(locationInput);

                output.JokasoDaichoMstLocation = locationOutput.JokasoDaichoMstLocation;
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
