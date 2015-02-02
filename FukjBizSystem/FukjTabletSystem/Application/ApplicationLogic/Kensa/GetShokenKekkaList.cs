using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Kensa;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Kensa
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokenKekkaListALInput
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
    interface IGetShokenKekkaListALInput : IBseALInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        int ShokenTaishoKensaBitMask { get; set; }

        /// <summary>
        /// TaishouKensaHosokuBitMask
        /// </summary>
        int TaishouKensaHosokuBitMask { get; set; }

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
    //  クラス名 ： GetShokenKekkaListALInput
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
    class GetShokenKekkaListALInput : IGetShokenKekkaListALInput
    {
        /// <summary>
        /// ShokenTaishoKensaBitMask
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }

        /// <summary>
        /// TaishouKensaHosokuBitMask
        /// </summary>
        public int TaishouKensaHosokuBitMask { get; set; }

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
    //  インターフェイス名 ： IGetShokenKekkaListALOutput
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
    interface IGetShokenKekkaListALOutput : IGetShokenKekkaListByKensaIraiAndBitMaskBLOutput, IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenKekkaListALOutput
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
    class GetShokenKekkaListALOutput : IGetShokenKekkaListALOutput
    {
        /// <summary>
        /// ShokenKekkaListDataTable
        /// </summary>
        public ShokenKekkaTblDataSet.ShokenKekkaListDataTable ShokenKekkaList { get; set; }

        /// <summary>
        /// ShokenKekkaHosokuListDataTable
        /// </summary>
        public ShokenKekkaHosokuTblDataSet.ShokenKekkaHosokuListDataTable ShokenKekkaHosokuList { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenKekkaListApplicationLogic
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
    class GetShokenKekkaListApplicationLogic : BaseApplicationLogic<IGetShokenKekkaListALInput, IGetShokenKekkaListALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaComon：GetShokenKekkaList";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShokenKekkaListApplicationLogic
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
        public GetShokenKekkaListApplicationLogic()
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
        public override IGetShokenKekkaListALOutput Execute(IGetShokenKekkaListALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShokenKekkaListALOutput output = new GetShokenKekkaListALOutput();

            try
            {
                // 所見を取得
                IGetShokenKekkaListByKensaIraiAndBitMaskBLInput blShokenInput = new GetShokenKekkaListByKensaIraiAndBitMaskBLInput();

                blShokenInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                blShokenInput.IraiHoteiKbn = input.IraiHoteiKbn;
                blShokenInput.IraiHokenjoCd = input.IraiHokenjoCd;
                blShokenInput.IraiNendo = input.IraiNendo;
                blShokenInput.IraiRenban = input.IraiRenban;

                IGetShokenKekkaListByKensaIraiAndBitMaskBLOutput blShokenOutput = new GetShokenKekkaListByKensaIraiAndBitMaskBusinessLogic().Execute(blShokenInput);
                output.ShokenKekkaList = blShokenOutput.ShokenKekkaList;

                // 所見補足を取得
                IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLInput blHosokuInput = new GetShokenKekkaHosokuListByKensaIraiAndBitMaskBLInput();

                blHosokuInput.ShokenTaishoKensaBitMask = input.TaishouKensaHosokuBitMask;
                blHosokuInput.IraiHoteiKbn = input.IraiHoteiKbn;
                blHosokuInput.IraiHokenjoCd = input.IraiHokenjoCd;
                blHosokuInput.IraiNendo = input.IraiNendo;
                blHosokuInput.IraiRenban = input.IraiRenban;

                IGetShokenKekkaHosokuListByKensaIraiAndBitMaskBLOutput blHosokuOutput = new GetShokenKekkaHosokuListByKensaIraiAndBitMaskBusinessLogic().Execute(blHosokuInput);
                output.ShokenKekkaHosokuList = blHosokuOutput.ShokenKekkaHosokuList;
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
