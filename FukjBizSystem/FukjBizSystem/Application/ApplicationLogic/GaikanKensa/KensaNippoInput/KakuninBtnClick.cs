using System;
using System.Reflection;
using FukjBizSystem.Application.Boundary.GaikanKensa;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaNippoInput;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaNippoInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuninBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuninBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 検査予定年/検査予定月/検査予定日
        /// </summary>
        DateTime YoteiDt { get; set; }

        /// <summary>
        /// 外観検査担当者コード
        /// </summary>
        string KensaIraiKensaTantoshaCd { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： KakuninBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuninBtnClickALInput : IKakuninBtnClickALInput
    {
        /// <summary>
        /// 検査予定年/検査予定月/検査予定日
        /// </summary>
        public DateTime YoteiDt { get; set; }

        /// <summary>
        /// 外観検査担当者コード
        /// </summary>
        public string KensaIraiKensaTantoshaCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("検査予定年/検査予定月/検査予定日[{0}], 外観検査担当者コード[{1}]", YoteiDt.ToString("yyyyMMdd"), KensaIraiKensaTantoshaCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IKakuninBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IKakuninBtnClickALOutput
    {
        /// <summary>
        /// No search data
        /// </summary>
        bool IsError { get; set; }

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
    //  クラス名 ： KakuninBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuninBtnClickALOutput : IKakuninBtnClickALOutput
    {
        /// <summary>
        /// No search data
        /// </summary>
        public bool IsError { get; set; }

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
    //  クラス名 ： KakuninBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class KakuninBtnClickApplicationLogic : BaseApplicationLogic<IKakuninBtnClickALInput, IKakuninBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaNippoInput：KakuninBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： KakuninBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public KakuninBtnClickApplicationLogic()
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
        /// 2014/11/12　AnhNV　　    新規作成
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
        /// 2014/11/12　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IKakuninBtnClickALOutput Execute(IKakuninBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IKakuninBtnClickALOutput output = new KakuninBtnClickALOutput();

            try
            {
                // Get NippoHdrTbl by key
                IGetNippoHdrTblByKeyBLInput nHdrInput = new GetNippoHdrTblByKeyBLInput();
                nHdrInput.NippoKensaDt = input.YoteiDt.ToString("yyyyMMdd");
                nHdrInput.NippoKensainCd = input.KensaIraiKensaTantoshaCd;
                IGetNippoHdrTblByKeyBLOutput nHdrOutput = new GetNippoHdrTblByKeyBusinessLogic().Execute(nHdrInput);
                output.NippoHdrTblDataTable = nHdrOutput.NippoHdrTblDataTable;

                // Get NippoHdrTbl by NippoKensainCd
                IGetNippoHdrTblByNippoKensainCdBLInput nInput = new GetNippoHdrTblByNippoKensainCdBLInput();
                nInput.NippoKensainCd = input.KensaIraiKensaTantoshaCd;
                IGetNippoHdrTblByNippoKensainCdBLOutput nOutput = new GetNippoHdrTblByNippoKensainCdBusinessLogic().Execute(nInput);
                output.NippoVariableDataTable = nOutput.NippoHdrTblDataTable;

                // Get NippoDtlTbl by NippoKensainCd
                IGetNippoDtlTblByKensainCdBLInput dInput = new GetNippoDtlTblByKensainCdBLInput();
                dInput.KensainCd = input.KensaIraiKensaTantoshaCd;
                IGetNippoDtlTblByKensainCdBLOutput dOutput = new GetNippoDtlTblByKensainCdBusinessLogic().Execute(dInput);
                output.NippoDtlTblDataTable = dOutput.NippoDtlTblDataTable;

                // Get KensaNippoEditableCheckDataTable
                IGetKensaNippoEditableCheckInfoBLOutput kecOutput = new GetKensaNippoEditableCheckInfoBusinessLogic().Execute(new GetKensaNippoEditableCheckInfoBLInput());
                output.KensaNippoEditableCheckDataTable = kecOutput.KensaNippoEditableCheckDataTable;

                // No record in NippoHdrTbl?
                if (nHdrOutput.NippoHdrTblDataTable.Count == 0)
                {
                    // Check existing data in KensaIraiTbl
                    IGetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput kitInput = new GetKensaIraiEditCheckByYoteiDtTantoshaCdBLInput();
                    kitInput.YoteiDt = input.YoteiDt.ToString("yyyyMMdd");
                    kitInput.KensaIraiKensaTantoshaCd = input.KensaIraiKensaTantoshaCd;
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
                        addInput.KensaDt = input.YoteiDt;
                        addInput.KensainCd = input.KensaIraiKensaTantoshaCd;
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
                    editInput.KensaDt = input.YoteiDt;
                    editInput.KensainCd = input.KensaIraiKensaTantoshaCd;
                    editInput.Mode = "2"; // EDIT/NON-EDIT
                    IGetKensaNippoInputByKensaDtKensainCdBLOutput editOutput = new GetKensaNippoInputByKensaDtKensainCdBusinessLogic().Execute(editInput);
                    output.KensaNippoInputDataTable = editOutput.KensaNippoInputDataTable;

                    // Screen mode
                    output.DispMode = KensaNippoInputForm.DispMode.Edit;
                    int statusKbn = 0;
                    foreach (KensaIraiTblDataSet.KensaNippoInputRow editRow in editOutput.KensaNippoInputDataTable)
                    {
                        if (!editRow.IsKensaIraiStatusKbnNull())
                        {
                            statusKbn = Convert.ToInt32(editRow.KensaIraiStatusKbn);
                        }

						// 受入20141219 外観日報区分が'2'（承認）の場合も、編集不可。
                        if (statusKbn >= 70 || editRow.KensaIraiGaikanNippoKbn.Equals("2") || editRow.KensaIraiSeikyuKbn.Equals("1"))
                        {
                            output.DispMode = KensaNippoInputForm.DispMode.NonEditable;
                            break;
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
