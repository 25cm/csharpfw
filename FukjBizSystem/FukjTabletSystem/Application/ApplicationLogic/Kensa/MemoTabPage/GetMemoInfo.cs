using System;
using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Kensa.MemoTabPage;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Kensa.MemoTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMemoInfoALInput
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
    interface IGetMemoInfoALInput : IBseALInput
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
    //  クラス名 ： GetMemoInfoALInput
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
    class GetMemoInfoALInput : IGetMemoInfoALInput
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
    //  インターフェイス名 ： IGetMemoInfoALOutput
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
    interface IGetMemoInfoALOutput : IGetMemoDaibunruiMstBLOutput,
									 IGetMemoMstBLOutput,
								     IGetJokasoMemoListByKensaIraiKeyBLOutput,
									 IGetJokasoDaichoMstMemoByKensaIraiKeyBLOutput,
									 IGetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMemoInfoALOutput
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
    class GetMemoInfoALOutput : IGetMemoInfoALOutput
    {
        /// <summary>
		/// MemoDaibunruiMstDataTable
        /// </summary>
		public MemoDaibunruiMstDataSet.MemoDaibunruiMstDataTable MemoDaibunruiMst { get; set; }

        /// <summary>
		/// MemoMstDataTable
        /// </summary>
		public MemoMstDataSet.MemoMstDataTable MemoMst { get; set; }

        /// <summary>
		/// JokasoMemoListDataTable
        /// </summary>
		public JokasoMemoTblDataSet.JokasoMemoListDataTable JokasoMemoList { get; set; }

        /// <summary>
		/// JokasoDaichoMstMemoDataTable
        /// </summary>
		public JokasoDaichoMstDataSet.JokasoDaichoMstMemoDataTable JokasoDaichoMstMemo { get; set; }

        /// <summary>
		/// KensaIraiKanrenFileTblDataTable
        /// </summary>
		public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTbl { get; set; }

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
	//  クラス名 ： GetMemoInfoApplicationLogic
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
    class GetMemoInfoApplicationLogic : BaseApplicationLogic<IGetMemoInfoALInput, IGetMemoInfoALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "MemoTabPage：GetMemoInfo";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
		//  コンストラクタ名 ： GetMemoInfoApplicationLogic
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
        public GetMemoInfoApplicationLogic()
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
        /// 2014/11/21　戸口　　    新規作成
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
        /// 2014/11/21　戸口　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetMemoInfoALOutput Execute(IGetMemoInfoALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMemoInfoALOutput output = new GetMemoInfoALOutput();

            try
            {
				// メモ大分類マスタの取得
				IGetMemoDaibunruiMstBLInput daiInput = new GetMemoDaibunruiMstBLInput();
				IGetMemoDaibunruiMstBLOutput daiOutput = new GetMemoDaibunruiMstBusinessLogic().Execute(daiInput);

				// 取得できず
				if (daiOutput.MemoDaibunruiMst.Count == 0)
				{
					throw new CustomException(0, "メモ大分類マスタが取得できませんでした。");
				}

				// メモマスタの取得
				IGetMemoMstBLInput memInput = new GetMemoMstBLInput();
				IGetMemoMstBLOutput memOutput = new GetMemoMstBusinessLogic().Execute(memInput);

				// 取得できず
				if (memOutput.MemoMst.Count == 0)
				{
					throw new CustomException(0, "メモマスタが取得できませんでした。");
				}

				// 浄化槽定型メモテーブルの取得（検査依頼のキーで取得）
				IGetJokasoMemoListByKensaIraiKeyBLInput jokasoMemoInput = new GetJokasoMemoListByKensaIraiKeyBLInput();
				jokasoMemoInput.IraiHoteiKbn = input.IraiHoteiKbn;
				jokasoMemoInput.IraiHokenjoCd = input.IraiHokenjoCd;
				jokasoMemoInput.IraiNendo = input.IraiNendo;
				jokasoMemoInput.IraiRenban = input.IraiRenban;
				IGetJokasoMemoListByKensaIraiKeyBLOutput jokasoMemoOutput = new GetJokasoMemoListByKensaIraiKeyBusinessLogic().Execute(jokasoMemoInput);

				// 浄化槽台帳マスタの取得（メモ用：検査依頼のキーで取得）
				IGetJokasoDaichoMstMemoByKensaIraiKeyBLInput jokasoDaichoMemoInput = new GetJokasoDaichoMstMemoByKensaIraiKeyBLInput();
				jokasoDaichoMemoInput.IraiHoteiKbn = input.IraiHoteiKbn;
				jokasoDaichoMemoInput.IraiHokenjoCd = input.IraiHokenjoCd;
				jokasoDaichoMemoInput.IraiNendo = input.IraiNendo;
				jokasoDaichoMemoInput.IraiRenban = input.IraiRenban;
				IGetJokasoDaichoMstMemoByKensaIraiKeyBLOutput jokasoDaichoMemoOutput = new GetJokasoDaichoMstMemoByKensaIraiKeyBusinessLogic().Execute(jokasoDaichoMemoInput);

				// 取得できず
				if (jokasoDaichoMemoOutput.JokasoDaichoMstMemo.Count == 0)
				{
					throw new CustomException(0, "浄化槽台帳が取得できませんでした。");
				}

				// 検査依頼関連ファイルテーブルの取得（見出し用：検査依頼のキーで取得）
				IGetKensaIraiKanrenFileTblByKensaIraiKeyBLInput kanrenInput = new GetKensaIraiKanrenFileTblByKensaIraiKeyBLInput();
				kanrenInput.IraiHoteiKbn = input.IraiHoteiKbn;
				kanrenInput.IraiHokenjoCd = input.IraiHokenjoCd;
				kanrenInput.IraiNendo = input.IraiNendo;
				kanrenInput.IraiRenban = input.IraiRenban;
				IGetKensaIraiKanrenFileTblByKensaIraiKeyBLOutput kanrenOutput = new GetKensaIraiKanrenFileTblByKensaIraiKeyBusinessLogic().Execute(kanrenInput);
				
				// 出力データをセット
				output.MemoDaibunruiMst = daiOutput.MemoDaibunruiMst;
				output.MemoMst = memOutput.MemoMst;
				output.JokasoMemoList = jokasoMemoOutput.JokasoMemoList;
				output.JokasoDaichoMstMemo = jokasoDaichoMemoOutput.JokasoDaichoMstMemo;
				output.KensaIraiKanrenFileTbl = kanrenOutput.KensaIraiKanrenFileTbl;

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
