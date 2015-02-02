using System;
using System.IO;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Temp.PrintKensainBetsuKensaYotei;
using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.JinendoGaikanKensaYoteiInput;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using FukjBizSystem.Application.DataSet.GaikanKensa.GaikanKensaPrintDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensainBetsuKensaYotei
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 検査員
        /// </summary>
        string KensainCd { get; set; }

        /// <summary>
        /// 検査予定日
        /// </summary>
        DateTime KensaYoteiDate { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALInput : IBseALInputImpl ,IPrintBtnClickALInput
    {
        /// <summary>
        /// 検査員
        /// </summary>
        public string KensainCd { get; set; }

        /// <summary>
        /// 検査予定日
        /// </summary>
        public DateTime KensaYoteiDate { get; set; }

    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IPrintBtnClickALOutput
    {
        /// <summary>
        /// 
        /// </summary>
        string ErrMessage { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickALOutput : IPrintBtnClickALOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public string ErrMessage { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： PrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/14　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class PrintBtnClickApplicationLogic : BaseApplicationLogic<IPrintBtnClickALInput, IPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensainBetsuKensaYotei：PrintBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： PrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/14　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public PrintBtnClickApplicationLogic()
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
        /// 2014/11/14　habu　　    新規作成
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
        /// 2014/11/14　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IPrintBtnClickALOutput Execute(IPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IPrintBtnClickALOutput output = new PrintBtnClickALOutput();

            try
            {
                // 出力データ取得
                IStdGetDataBLInput getInput = new StdGetDataBLInput();
                getInput.TableAdapterType = typeof(PrintKensainBetsuKensaYoteiTableAdapter);
                getInput.GetMethodName = "GetDataByCond";
                getInput.ValueList.Add(input.KensaYoteiDate.Year.ToString("0000"));
                getInput.ValueList.Add(input.KensaYoteiDate.Month.ToString("00"));
                getInput.ValueList.Add(input.KensaYoteiDate.Day.ToString("00"));
                getInput.ValueList.Add(input.KensainCd);

                IStdGetDataBLOutput getOutput = new StdGetDataBusinessLogic().Execute(getInput);

                IStdGetDataBLInput getInputMemo = new StdGetDataBLInput();
                getInputMemo.TableAdapterType = typeof(PrintKensainBetsuKensaYoteiMemoTableAdapter);
                getInputMemo.GetMethodName = "GetDataByCond";
                getInputMemo.ValueList.Add(input.KensaYoteiDate.Year.ToString("0000"));
                getInputMemo.ValueList.Add(input.KensaYoteiDate.Month.ToString("00"));
                getInputMemo.ValueList.Add(input.KensaYoteiDate.Day.ToString("00"));
                getInputMemo.ValueList.Add(input.KensainCd);

                IStdGetDataBLOutput getOutputMemo = new StdGetDataBusinessLogic().Execute(getInputMemo);

                if (getOutput.GetDataTable.Rows.Count == 0)
                {
                    output.ErrMessage = "出力対象データが存在しません。";

                    return output;
                }

                // 出力実行
                IPrintKensainBetsuKensaYoteiBLInput blInput = new PrintKensainBetsuKensaYoteiBLInput();
                blInput.AfterDispFlg = true;
                blInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.KensainBetsuKensaYoteiFormatFile);
                blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;

                blInput.KensaYoteiDate = input.KensaYoteiDate;
                blInput.KensainCd = input.KensainCd;
                blInput.PrintDataTable = (GaikanKensaPrintDataSet.PrintKensainBetsuKensaYoteiDataTable)getOutput.GetDataTable;
                blInput.PrintDataTableMemo = (GaikanKensaPrintDataSet.PrintKensainBetsuKensaYoteiMemoDataTable)getOutputMemo.GetDataTable;

                IPrintKensainBetsuKensaYoteiBLOutput blOutput =  new PrintKensainBetsuKensaYoteiBusinessLogic().Execute(blInput);
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
