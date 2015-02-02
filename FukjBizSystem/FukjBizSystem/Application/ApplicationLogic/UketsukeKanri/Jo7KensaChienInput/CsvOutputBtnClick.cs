using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaChienInput;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.UketsukeKanri;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.Jo7KensaChienInput
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICsvOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICsvOutputBtnClickALInput : IBseALInput, IUpdateKensaIraiKanrenFileTblBLInput
    {
        /// <summary>
        /// Jo7KensaChienInputListRow
        /// </summary>
        Jo7KensaChienInputListDataSet.Jo7KensaChienInputListRow Jo7KensaChienInputListRow { get; set; }

        /// <summary>
        /// SavePath 
        /// </summary>
        string SavePath { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CsvOutputBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CsvOutputBtnClickALInput : ICsvOutputBtnClickALInput
    {
        /// <summary>
        /// KensaIraiKanrenFileTblDataTable
        /// </summary>
        public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTblDT { get; set; }

        /// <summary>
        /// Jo7KensaChienInputListRow
        /// </summary>
        public Jo7KensaChienInputListDataSet.Jo7KensaChienInputListRow Jo7KensaChienInputListRow { get; set; }

        /// <summary>
        /// SavePath 
        /// </summary>
        public string SavePath { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("KensaIraiKanrenFileTblDT[{0}]", 
                    new string[] {
                        KensaIraiKanrenFileTblDT[0].KensaIraiHoteiKbn + "-" + KensaIraiKanrenFileTblDT[0].KensaIraiHokenjoCd + "-" + KensaIraiKanrenFileTblDT[0].KensaIraiNendo + "-" + KensaIraiKanrenFileTblDT[0].KensaIraiRenban + "-" + KensaIraiKanrenFileTblDT[0].KensaIraiFileShubetsuCd
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICsvOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICsvOutputBtnClickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        string ErrMessage { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CsvOutputBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CsvOutputBtnClickALOutput : ICsvOutputBtnClickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        public string ErrMessage { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CsvOutputBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CsvOutputBtnClickApplicationLogic : BaseApplicationLogic<ICsvOutputBtnClickALInput, ICsvOutputBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "Jo7KensaChienInput：CsvOutputBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CsvOutputBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CsvOutputBtnClickApplicationLogic()
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
        /// 2014/09/17  DatNT　  新規作成
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
        /// 2014/09/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ICsvOutputBtnClickALOutput Execute(ICsvOutputBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICsvOutputBtnClickALOutput output = new CsvOutputBtnClickALOutput();

            try
            {
                //StartTransaction();

                //ADD_HuyTX_20141031_Print 036 Start
                IPrintKensaChienHokokushoBLInput printBLInput = new PrintKensaChienHokokushoBLInput();
                printBLInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;
                printBLInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KensaChienHokokushoFormatFile;
                printBLInput.AfterDispFlg = true;
                printBLInput.Jo7KensaChienInputListRow = input.Jo7KensaChienInputListRow;
                printBLInput.SavePath = input.SavePath;

                new PrintKensaChienHokokushoBusinessLogic().Execute(printBLInput);
                //ADD_HuyTX_20141031 End

                //IGetKensaIraiKanrenFileTblByKeyBLInput getByKeyInput = new GetKensaIraiKanrenFileTblByKeyBLInput();
                //getByKeyInput.KensaIraiHoteiKbn         = input.KensaIraiKanrenFileTblDT[0].KensaIraiHoteiKbn;
                //getByKeyInput.KensaIraiHokenjoCd        = input.KensaIraiKanrenFileTblDT[0].KensaIraiHokenjoCd;
                //getByKeyInput.KensaIraiNendo            = input.KensaIraiKanrenFileTblDT[0].KensaIraiNendo;
                //getByKeyInput.KensaIraiRenban           = input.KensaIraiKanrenFileTblDT[0].KensaIraiRenban;
                //getByKeyInput.KensaIraiFileShubetsuCd   = input.KensaIraiKanrenFileTblDT[0].KensaIraiFileShubetsuCd;
                //IGetKensaIraiKanrenFileTblByKeyBLOutput getByKeyOutput = new GetKensaIraiKanrenFileTblByKeyBusinessLogic().Execute(getByKeyInput);

                //if (getByKeyOutput.KensaIraiKanrenFileTblDT != null && getByKeyOutput.KensaIraiKanrenFileTblDT.Count > 0)
                //{
                //    output.ErrMessage = string.Format("既に検査依頼関連ファイルテーブルに登録済みです。\r\n[検査依頼法定区分：{0}]\r\n[検査依頼保健所コード：{1}]\r\n[検査依頼年度：{2}]\r\n[検査依頼連番：{3}]\r\n[関連ファイル種別：{4}]",
                //                            new string[] {
                //                                input.KensaIraiKanrenFileTblDT[0].KensaIraiHoteiKbn,
                //                                input.KensaIraiKanrenFileTblDT[0].KensaIraiHokenjoCd,
                //                                input.KensaIraiKanrenFileTblDT[0].KensaIraiNendo,
                //                                input.KensaIraiKanrenFileTblDT[0].KensaIraiRenban,
                //                                input.KensaIraiKanrenFileTblDT[0].KensaIraiFileShubetsuCd
                //                            });
                //}
                //else
                //{
                //    output.ErrMessage = string.Empty;

                //    //new UpdateKensaIraiKanrenFileTblBusinessLogic().Execute(input);
                //}

                //CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                //EndTransaction();
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
