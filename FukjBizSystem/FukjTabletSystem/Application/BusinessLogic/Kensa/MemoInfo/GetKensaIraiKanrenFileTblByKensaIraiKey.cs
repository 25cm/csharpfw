using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaIraiKanrenFileTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.MemoTabPage
{
	#region 入力インターフェイス定義
	////////////////////////////////////////////////////////////////////////////
	//  インターフェイス名 ： IGetKensaIraiKanrenFileTblByKensaIraiKeyBLInput
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	/// <history>
	/// 日付　　　　担当者　　　内容
	/// 2014/11/21　戸口　　    新規作成
	/// </history>
	////////////////////////////////////////////////////////////////////////////
	interface IGetKensaIraiKanrenFileTblByKensaIraiKeyBLInput : ISelectKensaIraiKanrenFileTblByKensaIraiKeyDAInput
	{
	}
	#endregion

	#region 入力クラス定義
	////////////////////////////////////////////////////////////////////////////
	//  クラス名 ： GetKensaIraiKanrenFileTblByKensaIraiKeyBLInput
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	/// <history>
	/// 日付　　　　担当者　　　内容
	/// 2014/11/21　戸口　　    新規作成
	/// </history>
	////////////////////////////////////////////////////////////////////////////
	class GetKensaIraiKanrenFileTblByKensaIraiKeyBLInput : IGetKensaIraiKanrenFileTblByKensaIraiKeyBLInput
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
	}
	#endregion

	#region 出力インターフェイス定義
	////////////////////////////////////////////////////////////////////////////
	//  インターフェイス名 ： IGetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	/// <history>
	/// 日付　　　　担当者　　　内容
	/// 2014/11/21　戸口　　    新規作成
	/// </history>
	////////////////////////////////////////////////////////////////////////////
	interface IGetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput : ISelectKensaIraiKanrenFileTblByKensaIraiKeyDAOutput
	{
	}
	#endregion

	#region 出力クラス定義
	////////////////////////////////////////////////////////////////////////////
	//  クラス名 ： GetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	/// <history>
	/// 日付　　　　担当者　　　内容
	/// 2014/11/21　戸口　　    新規作成
	/// </history>
	////////////////////////////////////////////////////////////////////////////
	class GetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput : IGetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput
	{
		/// <summary>
		/// JokasoDaichoMstDataTable
		/// </summary>
		public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTbl { get; set; }
	}
	#endregion

	#region クラス定義
	////////////////////////////////////////////////////////////////////////////
	//  クラス名 ： GetKensaIraiKanrenFileTblByKensaIraiKeyBusinessLogic
	/// <summary>
	/// 
	/// </summary>
	/// <remarks>
	/// 
	/// </remarks>
	/// <history>
	/// 日付　　　　担当者　　　内容
	/// 2014/11/21　戸口　　    新規作成
	/// </history>
	////////////////////////////////////////////////////////////////////////////
	class GetKensaIraiKanrenFileTblByKensaIraiKeyBusinessLogic : BaseBusinessLogic<IGetKensaIraiKanrenFileTblByKensaIraiKeyBLInput, IGetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput>
	{
		#region コンストラクタ
		////////////////////////////////////////////////////////////////////////////
		//  コンストラクタ名 ： GetKensaIraiKanrenFileTblByKensaIraiKeyBusinessLogic
		/// <summary>
		/// 
		/// </summary>
		/// <remarks>
		/// 
		/// </remarks>
		/// <history>
		/// 日付　　　　担当者　　　内容
		/// 2014/11/21　戸口　　    新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		public GetKensaIraiKanrenFileTblByKensaIraiKeyBusinessLogic()
		{
		}
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
		/// 2014/11/21　戸口　　    新規作成
		/// </history>
		////////////////////////////////////////////////////////////////////////////
		public override IGetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput Execute(IGetKensaIraiKanrenFileTblByKensaIraiKeyBLInput input)
		{
			TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

			// 出力クラスの実体作成
			IGetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput output = new GetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput();

			try
			{
				ISelectKensaIraiKanrenFileTblByKensaIraiKeyDAOutput daOutput = new SelectKensaIraiKanrenFileTblByKensaIraiKeyDataAccess().Execute(input);
				output.KensaIraiKanrenFileTbl = daOutput.KensaIraiKanrenFileTbl;
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
