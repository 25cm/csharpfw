using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.JokasoMemoList;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.MemoTabPage {
	#region 入力インターフェイス定義
	////////////////////////////////////////////////////////////////////////////
	//  インターフェイス名 ： IGetJokasoMemoListByKensaIraiKeyBLInput
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
	interface IGetJokasoMemoListByKensaIraiKeyBLInput : ISelectJokasoMemoListByKensaIraiKeyDAInput {
	}
	#endregion

	#region 入力クラス定義
	////////////////////////////////////////////////////////////////////////////
	//  クラス名 ： GetJokasoMemoListByKensaIraiKeyBLInput
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
	class GetJokasoMemoListByKensaIraiKeyBLInput : IGetJokasoMemoListByKensaIraiKeyBLInput {
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
	//  インターフェイス名 ： IGetJokasoMemoListByKensaIraiKeyBLOutput
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
	interface IGetJokasoMemoListByKensaIraiKeyBLOutput : ISelectJokasoMemoListByKensaIraiKeyDAOutput {
	}
	#endregion

	#region 出力クラス定義
	////////////////////////////////////////////////////////////////////////////
	//  クラス名 ： GetJokasoMemoListByKensaIraiKeyBLOutput
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
	class GetJokasoMemoListByKensaIraiKeyBLOutput : IGetJokasoMemoListByKensaIraiKeyBLOutput {
		/// <summary>
		/// JokasoDaichoMstDataTable
		/// </summary>
		public JokasoMemoTblDataSet.JokasoMemoListDataTable JokasoMemoList { get; set; }
	}
	#endregion

	#region クラス定義
	////////////////////////////////////////////////////////////////////////////
	//  クラス名 ： GetJokasoMemoListByKensaIraiKeyBusinessLogic
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
	class GetJokasoMemoListByKensaIraiKeyBusinessLogic : BaseBusinessLogic<IGetJokasoMemoListByKensaIraiKeyBLInput, IGetJokasoMemoListByKensaIraiKeyBLOutput> {
		#region コンストラクタ
		////////////////////////////////////////////////////////////////////////////
		//  コンストラクタ名 ： GetJokasoMemoListByKensaIraiKeyBusinessLogic
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
		public GetJokasoMemoListByKensaIraiKeyBusinessLogic() {
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
		public override IGetJokasoMemoListByKensaIraiKeyBLOutput Execute(IGetJokasoMemoListByKensaIraiKeyBLInput input) {
			TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

			// 出力クラスの実体作成
			IGetJokasoMemoListByKensaIraiKeyBLOutput output = new GetJokasoMemoListByKensaIraiKeyBLOutput();

			try {
				ISelectJokasoMemoListByKensaIraiKeyDAOutput daOutput = new SelectJokasoMemoListByKensaIraiKeyDataAccess().Execute(input);
				output.JokasoMemoList = daOutput.JokasoMemoList;
			} catch {
				throw;
			} finally {
				TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
			}

			return output;
		}
		#endregion

		#endregion

	}
	#endregion
}
