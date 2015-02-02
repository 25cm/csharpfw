using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Kensa.ShokenHanteiDialog;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Kensa.ShokenHanteiDialog
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokenInfoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokenInfoALInput : IBseALInput
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
        /// ShokenTaishoKensaBitMask
        /// </summary>
        int ShokenTaishoKensaBitMask { get; set; }

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenInfoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokenInfoALInput : IGetShokenInfoALInput
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
        /// ShokenTaishoKensaBitMask
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }

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
    //  インターフェイス名 ： IGetShokenInfoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokenInfoALOutput : IGetShokenInfoByJokasoAndBitMaskBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenInfoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokenInfoALOutput : IGetShokenInfoALOutput
    {
        /// <summary>
        /// KatashikiBetsuTaniSochiMstDataTable
        /// </summary>
        public KatashikiBetsuTaniSochiMstDataSet.KatashikiBetsuTaniSochiMstDataTable KatashikiBetsuTaniSochiMst { get; set; }


        /// <summary>
        /// TaniSochiGroupMstDataTable
        /// </summary>
        public TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable TaniSochiGroupMst { get; set; }

        /// <summary>
        /// TaniSochiKensaJokyoMstDataTable
        /// </summary>
        public TaniSochiKensaJokyoMstDataSet.TaniSochiKensaJokyoMstDataTable TaniSochiKensaJokyoMst { get; set; }

        /// <summary>
        /// TaniSochiKensaJokyoTeidoMstDataTable
        /// </summary>
        public TaniSochiKensaJokyoTeidoMstDataSet.TaniSochiKensaJokyoTeidoMstDataTable TaniSochiKensaJokyoTeidoMst { get; set; }

        /// <summary>
        /// TaniSochiKensaKomokuMstDataTable
        /// </summary>
        public TaniSochiKensaKomokuMstDataSet.TaniSochiKensaKomokuMstDataTable TaniSochiKensaKomokuMst { get; set; }

        /// <summary>
        /// ShokenMstDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenMstDataTable ShokenMst { get; set; }

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
    /// 2014/11/15　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokenInfoApplicationLogic : BaseApplicationLogic<IGetShokenInfoALInput, IGetShokenInfoALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "ShokenHanteiDialog：GetShokenInfo";

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
        /// 2014/11/15　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShokenInfoApplicationLogic()
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
        /// 2014/11/15　豊田　　    新規作成
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
        /// 2014/11/15　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShokenInfoALOutput Execute(IGetShokenInfoALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShokenInfoALOutput output = new GetShokenInfoALOutput();

            try
            {
                // 浄化槽台帳の取得
                IGetJokasoDaichoMstByKensaIraiKeyBLInput jokasoInput = new GetJokasoDaichoMstByKensaIraiKeyBLInput();
                jokasoInput.IraiHoteiKbn = input.IraiHoteiKbn;
                jokasoInput.IraiHokenjoCd = input.IraiHokenjoCd;
                jokasoInput.IraiNendo = input.IraiNendo;
                jokasoInput.IraiRenban = input.IraiRenban;
                IGetJokasoDaichoMstByKensaIraiKeyBLOutput jokasoOutput = new GetJokasoDaichoMstByKensaIraiKeyBusinessLogic().Execute(jokasoInput);

                // 想定外だが・・・
                if (jokasoOutput.JokasoDaichoMst.Count == 0)
                {
                    throw new CustomException(0, "浄化槽台帳が取得できませんでした。");
                }
                
                // 所見情報の取得
                IGetShokenInfoByJokasoAndBitMaskBLInput shokenInput = new GetShokenInfoByJokasoAndBitMaskBLInput();
                shokenInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                shokenInput.JokasoHokenjoCd = jokasoOutput.JokasoDaichoMst[0].JokasoHokenjoCd;
                shokenInput.JokasoTorokuNendo = jokasoOutput.JokasoDaichoMst[0].JokasoTorokuNendo;
                shokenInput.JokasoRenban = jokasoOutput.JokasoDaichoMst[0].JokasoRenban;
                shokenInput.IraiHoteiKbn = input.IraiHoteiKbn;
                shokenInput.IraiHokenjoCd = input.IraiHokenjoCd;
                shokenInput.IraiNendo = input.IraiNendo;
                shokenInput.IraiRenban = input.IraiRenban;
                IGetShokenInfoByJokasoAndBitMaskBLOutput shokenOutput = new GetShokenInfoByJokasoAndBitMaskBusinessLogic().Execute(shokenInput);

                output.KatashikiBetsuTaniSochiMst = shokenOutput.KatashikiBetsuTaniSochiMst;
                output.TaniSochiGroupMst = shokenOutput.TaniSochiGroupMst;
                output.TaniSochiKensaKomokuMst = shokenOutput.TaniSochiKensaKomokuMst;
                output.TaniSochiKensaJokyoMst = shokenOutput.TaniSochiKensaJokyoMst;
                output.TaniSochiKensaJokyoTeidoMst = shokenOutput.TaniSochiKensaJokyoTeidoMst;
                output.ShokenMst = shokenOutput.ShokenMst;
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
