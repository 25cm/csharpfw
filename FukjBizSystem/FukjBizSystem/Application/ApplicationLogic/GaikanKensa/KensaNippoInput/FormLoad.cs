using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.GaikanKensa;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaKanryoInputList;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaNippoInput;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaNippoInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// 検査員コード
        /// </summary>
        string NippoKensainCd { get; set; }

        /// <summary>
        /// 検査日
        /// </summary>
        DateTime NippoKensaDt { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 検査員コード
        /// </summary>
        public string NippoKensainCd { get; set; }

        /// <summary>
        /// 検査日
        /// </summary>
        public DateTime NippoKensaDt { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査員コード[{0}], 検査日[{1}]", NippoKensainCd, NippoKensaDt);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IFormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// No search data
        /// </summary>
        bool IsError { get; set; }

        /// <summary>
        /// 職員マスタ
        /// </summary>
        ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }

        /// <summary>
        /// Result mode
        /// </summary>
        KensaNippoInputForm.DispMode DispMode { get; set; }

        /// <summary>
        /// KensaNippoInputDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaNippoInputDataTable KensaNippoInputDataTable { get; set; }

        /// <summary>
        /// KensaNippoEditableCheckDataTable
        /// </summary>
        KensaIraiTblDataSet.KensaNippoEditableCheckDataTable KensaNippoEditableCheckDataTable { get; set; }

        /// <summary>
        /// 日報ヘッダテーブル
        /// </summary>
        NippoHdrTblDataSet.NippoHdrTblDataTable NippoHdrTblDataTable { get; set; }

        /// <summary>
        /// 日報ヘッダテーブル
        /// </summary>
        NippoHdrTblDataSet.NippoHdrTblDataTable NippoVariableDataTable { get; set; }

        /// <summary>
        /// 日報明細テーブル
        /// </summary>
        NippoDtlTblDataSet.NippoDtlTblDataTable NippoDtlTblDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// No search data
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// 職員マスタ
        /// </summary>
        public ShokuinMstDataSet.ShokuinMstDataTable ShokuinMstDataTable { get; set; }

        /// <summary>
        /// Result mode
        /// </summary>
        public KensaNippoInputForm.DispMode DispMode { get; set; }

        /// <summary>
        /// KensaNippoInputDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaNippoInputDataTable KensaNippoInputDataTable { get; set; }

        /// <summary>
        /// KensaNippoEditableCheckDataTable
        /// </summary>
        public KensaIraiTblDataSet.KensaNippoEditableCheckDataTable KensaNippoEditableCheckDataTable { get; set; }

        /// <summary>
        /// 日報ヘッダテーブル
        /// </summary>
        public NippoHdrTblDataSet.NippoHdrTblDataTable NippoHdrTblDataTable { get; set; }

        /// <summary>
        /// 日報ヘッダテーブル
        /// </summary>
        public NippoHdrTblDataSet.NippoHdrTblDataTable NippoVariableDataTable { get; set; }

        /// <summary>
        /// 日報明細テーブル
        /// </summary>
        public NippoDtlTblDataSet.NippoDtlTblDataTable NippoDtlTblDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FormLoadApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaNippoInput：FormLoad";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： FormLoadApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public FormLoadApplicationLogic()
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
        /// 2014/11/11　AnhNV　　    新規作成
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
        /// 2014/11/11　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // 2015/01/28 DatNT MOD Start
                // Get ShokuinMst by KensainFlg & ShokuinTaishokuFlg
                IGetShokuinMstByKensainFlgTaishokuFlgBLInput shokuinInput = new GetShokuinMstByKensainFlgTaishokuFlgBLInput();
                shokuinInput.ShokuinKensainFlg = "1";
                shokuinInput.ShokuinTaishokuFlg = "0";
                output.ShokuinMstDataTable = new GetShokuinMstByKensainFlgTaishokuFlgBusinessLogic().Execute(shokuinInput).ShokuinMstDT;
                
                //// Get ShokuinMst by KensainFlg
                //IGetShokuinMstByShokuinKensainFlgBLInput shokuinInput = new GetShokuinMstByShokuinKensainFlgBLInput();
                //shokuinInput.ShokuinKensainFlg = "1";
                //IGetShokuinMstByShokuinKensainFlgBLOutput shokuinOutput = new GetShokuinMstByShokuinKensainFlgBusinessLogic().Execute(shokuinInput);
                //output.ShokuinMstDataTable = shokuinOutput.ShokuinMstDataTable;
                // 2015/01/28 DatNT MOD End

                if (!string.IsNullOrEmpty(input.NippoKensainCd))
                {
                    // Get NippoDtlTbl by NippoKensainCd
                    IGetNippoDtlTblByKensainCdBLInput dInput = new GetNippoDtlTblByKensainCdBLInput();
                    dInput.KensainCd = input.NippoKensainCd;
                    IGetNippoDtlTblByKensainCdBLOutput dOutput = new GetNippoDtlTblByKensainCdBusinessLogic().Execute(dInput);
                    output.NippoDtlTblDataTable = dOutput.NippoDtlTblDataTable;

                    // Get NippoHdrTbl by NippoKensainCd
                    IGetNippoHdrTblByNippoKensainCdBLInput nInput = new GetNippoHdrTblByNippoKensainCdBLInput();
                    nInput.NippoKensainCd = input.NippoKensainCd;
                    IGetNippoHdrTblByNippoKensainCdBLOutput nOutput = new GetNippoHdrTblByNippoKensainCdBusinessLogic().Execute(nInput);
                    output.NippoVariableDataTable = nOutput.NippoHdrTblDataTable;

                    // Get NippoHdrTbl by key
                    IGetNippoHdrTblByKeyBLInput nHdrInput = new GetNippoHdrTblByKeyBLInput();
                    nHdrInput.NippoKensaDt = input.NippoKensaDt.ToString("yyyyMMdd");
                    nHdrInput.NippoKensainCd = input.NippoKensainCd;
                    IGetNippoHdrTblByKeyBLOutput nHdrOutput = new GetNippoHdrTblByKeyBusinessLogic().Execute(nHdrInput);
                    output.NippoHdrTblDataTable = nHdrOutput.NippoHdrTblDataTable;

                    // Get KensaNippoEditableCheckDataTable
                    IGetKensaNippoEditableCheckInfoBLOutput kecOutput = new GetKensaNippoEditableCheckInfoBusinessLogic().Execute(new GetKensaNippoEditableCheckInfoBLInput());
                    output.KensaNippoEditableCheckDataTable = kecOutput.KensaNippoEditableCheckDataTable;

                    // No record in NippoHdrTbl?
                    if (nHdrOutput.NippoHdrTblDataTable.Count == 0)
                    {
                        // Check existing data in KensaIraiTbl
                        IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput kitInput = new GetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput();
                        kitInput.YoteiDt = input.NippoKensaDt.ToString("yyyyMMdd");
                        kitInput.KensaIraiKensaTantoshaCd = input.NippoKensainCd;
                        IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLOutput kitOutput = new GetKensaIraiEditCheckByYoteiDtTantoshaCdBusinessLogic().Execute(kitInput);

                        // No record was found?
                        if (kitOutput.KensaIraiEditCheckDataTable[0].RowNum == 0)
                        {
                            // Throw an error message
                            output.IsError = true;
                        }
                        else
                        {
                            // Get data from KensaIraiTbl (for 新規登録モード)
                            IGetKensaNippoInputByKensaDtKensainCdBLInput addInput = new GetKensaNippoInputByKensaDtKensainCdBLInput();
                            addInput.KensaDt = input.NippoKensaDt;
                            addInput.KensainCd = input.NippoKensainCd;
                            addInput.Mode = "1"; // ADD
                            IGetKensaNippoInputByKensaDtKensainCdBLOutput addOutput = new GetKensaNippoInputByKensaDtKensainCdBusinessLogic().Execute(addInput);
                            output.KensaNippoInputDataTable = addOutput.KensaNippoInputDataTable;

                            // Set ADD mode to screen
                            output.DispMode = KensaNippoInputForm.DispMode.Add;
                        }
                    }
                    else
                    {
                        IGetKensaNippoInputByKensaDtKensainCdBLInput editInput = new GetKensaNippoInputByKensaDtKensainCdBLInput();
                        editInput.KensaDt = input.NippoKensaDt;
                        editInput.KensainCd = input.NippoKensainCd;
                        editInput.Mode = "2"; // EDIT/NON-EDIT
                        IGetKensaNippoInputByKensaDtKensainCdBLOutput editOutput = new GetKensaNippoInputByKensaDtKensainCdBusinessLogic().Execute(editInput);
                        output.KensaNippoInputDataTable = editOutput.KensaNippoInputDataTable;

                        // Screen mode
                        output.DispMode = KensaNippoInputForm.DispMode.Edit;
                        int statusKbn = 0;
                        foreach (KensaIraiTblDataSet.KensaNippoInputRow editRow in editOutput.KensaNippoInputDataTable)
                        {
                            if (!Int32.TryParse(editRow.KensaIraiStatusKbn, out statusKbn)) continue;
                            
                            if (statusKbn >= 70 || editRow.KensaIraiSeikyuKbn == "1")
                            {
                                output.DispMode = KensaNippoInputForm.DispMode.NonEditable;
                                break;
                            }
                        }
                    }
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
