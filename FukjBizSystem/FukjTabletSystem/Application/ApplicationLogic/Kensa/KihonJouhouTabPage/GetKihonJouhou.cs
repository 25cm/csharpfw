using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Kensa.Common;
using FukjTabletSystem.Application.BusinessLogic.Kensa.KihonJouhouTabPage;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Kensa.KihonJouhouTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKihonJouhouALInput
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
    interface IGetKihonJouhouALInput : IBseALInput, IGetKihonJouhouBLInput, IGetKenchikuyotoAllNmBLInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKihonJouhouALInput
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
    class GetKihonJouhouALInput : IGetKihonJouhouALInput
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
    //  インターフェイス名 ： IGetKihonJouhouALOutput
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
    interface IGetKihonJouhouALOutput : IGetKihonJouhouBLOutput, IGetKenchikuyotoAllNmBLOutput, IGetKensaKekkaForZaitakuUpdateByKensaIraiKeyBLOutput, IGetKihonJouhouIraiBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKihonJouhouALOutput
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
    class GetKihonJouhouALOutput : IGetKihonJouhouALOutput
    {
        /// <summary>
        /// KihonJouhouDataTable
        /// </summary>
        public KensaIraiTblDataSet.KihonJouhouDataTable KihonJouhou { get; set; }

        /// <summary>
        /// KenchikuyotoAllNmDataTable
        /// </summary>
        public KenchikuyotoMstDataSet.KenchikuyotoAllNmDataTable KenchikuyotoAllNm { get; set; }

        /// <summary>
        /// KensaKekkaForZaitakuUpdateDataTable
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaForZaitakuUpdateDataTable KensaKekkaForZaitakuUpdate { get; set; }

        /// <summary>
        /// KihonJouhouIraiDataTable
        /// </summary>
        public KensaIraiTblDataSet.KihonJouhouIraiDataTable KihonJouhouIrai { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKihonJouhouApplicationLogic
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
    class GetKihonJouhouApplicationLogic : BaseApplicationLogic<IGetKihonJouhouALInput, IGetKihonJouhouALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KihonJouhouTabPage：GetKihonJouhou";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKihonJouhouApplicationLogic
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
        public GetKihonJouhouApplicationLogic()
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
        public override IGetKihonJouhouALOutput Execute(IGetKihonJouhouALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKihonJouhouALOutput output = new GetKihonJouhouALOutput();

            try
            {
                IGetKihonJouhouBLOutput blOutput = new GetKihonJouhouBusinessLogic().Execute(input);
                output.KihonJouhou = blOutput.KihonJouhou;

                IGetKenchikuyotoAllNmBLOutput yotoNmOutput = new GetKenchikuyotoAllNmBusinessLogic().Execute(input);
                output.KenchikuyotoAllNm = yotoNmOutput.KenchikuyotoAllNm;

                IGetKensaKekkaForZaitakuUpdateByKensaIraiKeyBLInput zaitakuInput = new GetKensaKekkaForZaitakuUpdateByKensaIraiKeyBLInput();
                zaitakuInput.IraiHokenjoCd = input.IraiHokenjoCd;
                zaitakuInput.IraiHoteiKbn = input.IraiHoteiKbn;
                zaitakuInput.IraiNendo = input.IraiNendo;
                zaitakuInput.IraiRenban = input.IraiRenban;

                IGetKensaKekkaForZaitakuUpdateByKensaIraiKeyBLOutput zaitakuNmOutput = new GetKensaKekkaForZaitakuUpdateByKensaIraiKeyBusinessLogic().Execute(zaitakuInput);
                output.KensaKekkaForZaitakuUpdate = zaitakuNmOutput.KensaKekkaForZaitakuUpdate;

                IGetKihonJouhouIraiBLInput iraiInput = new GetKihonJouhouIraiBLInput();
                iraiInput.IraiHokenjoCd = input.IraiHokenjoCd;
                iraiInput.IraiHoteiKbn = input.IraiHoteiKbn;
                iraiInput.IraiNendo = input.IraiNendo;
                iraiInput.IraiRenban = input.IraiRenban;

                IGetKihonJouhouIraiBLOutput iraiOutput = new GetKihonJouhouIraiBusinessLogic().Execute(iraiInput);
                output.KihonJouhouIrai = iraiOutput.KihonJouhouIrai;
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
