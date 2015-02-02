using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Kensa.KensaRirekiList;
using FukjTabletSystem.Application.BusinessLogic.Kensa.KensaMenu;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Kensa.KensaRirekiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetKensaRirekiListALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
	interface IGetKensaRirekiListALInput : IBseALInput
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
    //  クラス名 ： GetKensaRirekiListALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaRirekiListALInput : IGetKensaRirekiListALInput
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
    //  インターフェイス名 ： IGetKensaRirekiListALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
	interface IGetKensaRirekiListALOutput : IGetKensaRirekiListByKensaIraiKeyBLOutput, IGetKensaYoteiListByKensaIraiKeyBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaRirekiListALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaRirekiListALOutput : IGetKensaRirekiListALOutput
    {
        /// <summary>
        /// KensaRirekiListDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaRirekiListDataTable KensaRirekiList { get; set; }
	
		/// <summary>
		/// KensaYoteiListDataTable
		/// </summary>
		public KensaIraiTblDataSet.KensaYoteiListDataTable KensaYoteiList { get; set; }
	}
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetKensaRirekiListApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/26　戸口　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetKensaRirekiListApplicationLogic : BaseApplicationLogic<IGetKensaRirekiListALInput, IGetKensaRirekiListALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaRirekiList：GetKensaRirekiList";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetKensaRirekiListApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/26　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetKensaRirekiListApplicationLogic()
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
        /// 2014/11/26　戸口　　    新規作成
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
        /// 2014/11/26　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetKensaRirekiListALOutput Execute(IGetKensaRirekiListALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetKensaRirekiListALOutput output = new GetKensaRirekiListALOutput();

            try
            {
                IGetKensaRirekiListByKensaIraiKeyBLInput blInput = new GetKensaRirekiListByKensaIraiKeyBLInput();
                blInput.IraiHoteiKbn = input.IraiHoteiKbn;
                blInput.IraiHokenjoCd = input.IraiHokenjoCd;
                blInput.IraiNendo = input.IraiNendo;
                blInput.IraiRenban = input.IraiRenban;

                IGetKensaRirekiListByKensaIraiKeyBLOutput blOutput = new GetKensaRirekiListByKensaIraiKeyBusinessLogic().Execute(blInput);
                output.KensaRirekiList = blOutput.KensaRirekiList;

                IGetKensaYoteiListByKensaIraiKeyBLInput blMenuInput = new GetKensaYoteiListByKensaIraiKeyBLInput();
                blMenuInput.IraiHoteiKbn = input.IraiHoteiKbn;
                blMenuInput.IraiHokenjoCd = input.IraiHokenjoCd;
                blMenuInput.IraiNendo = input.IraiNendo;
                blMenuInput.IraiRenban = input.IraiRenban;

                IGetKensaYoteiListByKensaIraiKeyBLOutput blMenuOutput = new GetKensaYoteiListByKensaIraiKeyBusinessLogic().Execute(blMenuInput);
				output.KensaYoteiList = blMenuOutput.KensaYoteiList;
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
