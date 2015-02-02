using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Kensa.TaniSochiGroupAddDialog;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using FukjTabletSystem.Application.BusinessLogic.Kensa.ShokenHanteiDialog;

namespace FukjTabletSystem.Application.ApplicationLogic.TaniSochiGroupAddDialog
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetTaniSochiGroupMstByNotInJokasoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetTaniSochiGroupMstByNotInJokasoALInput : IBseALInput
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
    //  クラス名 ： GetTaniSochiGroupMstByNotInJokasoALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetTaniSochiGroupMstByNotInJokasoALInput : IGetTaniSochiGroupMstByNotInJokasoALInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }

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
    //  インターフェイス名 ： IGetTaniSochiGroupMstByNotInJokasoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetTaniSochiGroupMstByNotInJokasoALOutput : IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput
    {
        /// <summary>
        /// JokasoHokenjoCd
        /// </summary>
        string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoTorokuNendo
        /// </summary>
        string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// JokasoRenban
        /// </summary>
        string JokasoRenban { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTaniSochiGroupMstByNotInJokasoALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetTaniSochiGroupMstByNotInJokasoALOutput : IGetTaniSochiGroupMstByNotInJokasoALOutput
    {
        /// <summary>
        /// TaniSochiGroupMstDataTable
        /// </summary>
        public TaniSochiGroupMstDataSet.TaniSochiGroupMstDataTable TaniSochiGroupMst { get; set; }
        
        /// <summary>
        /// JokasoHokenjoCd
        /// </summary>
        public string JokasoHokenjoCd { get; set; }

        /// <summary>
        /// JokasoTorokuNendo
        /// </summary>
        public string JokasoTorokuNendo { get; set; }

        /// <summary>
        /// JokasoRenban
        /// </summary>
        public string JokasoRenban { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetTaniSochiGroupMstByNotInJokasoApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/17　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetTaniSochiGroupMstByNotInJokasoApplicationLogic : BaseApplicationLogic<IGetTaniSochiGroupMstByNotInJokasoALInput, IGetTaniSochiGroupMstByNotInJokasoALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "TaniSochiGroupAddDialog：GetTaniSochiGroupMstByNotInJokaso";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetTaniSochiGroupMstByNotInJokasoApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/17　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetTaniSochiGroupMstByNotInJokasoApplicationLogic()
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
        /// 2014/11/17　豊田　　    新規作成
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
        /// 2014/11/17　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetTaniSochiGroupMstByNotInJokasoALOutput Execute(IGetTaniSochiGroupMstByNotInJokasoALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetTaniSochiGroupMstByNotInJokasoALOutput output = new GetTaniSochiGroupMstByNotInJokasoALOutput();

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
                
                // まだ設定されていない単位装置グループマスタを取得
                IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLInput groupInput = new GetTaniSochiGroupMstByNotInJokasoAndBitMaskBLInput();
                groupInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                groupInput.JokasoHokenjoCd = jokasoOutput.JokasoDaichoMst[0].JokasoHokenjoCd;
                groupInput.JokasoTorokuNendo = jokasoOutput.JokasoDaichoMst[0].JokasoTorokuNendo;
                groupInput.JokasoRenban = jokasoOutput.JokasoDaichoMst[0].JokasoRenban;
                IGetTaniSochiGroupMstByNotInJokasoAndBitMaskBLOutput blOutput = new GetTaniSochiGroupMstByNotInJokasoAndBitMaskBusinessLogic().Execute(groupInput);

                output.JokasoHokenjoCd = jokasoOutput.JokasoDaichoMst[0].JokasoHokenjoCd;
                output.JokasoTorokuNendo = jokasoOutput.JokasoDaichoMst[0].JokasoTorokuNendo;
                output.JokasoRenban = jokasoOutput.JokasoDaichoMst[0].JokasoRenban;
                output.TaniSochiGroupMst = blOutput.TaniSochiGroupMst;
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
