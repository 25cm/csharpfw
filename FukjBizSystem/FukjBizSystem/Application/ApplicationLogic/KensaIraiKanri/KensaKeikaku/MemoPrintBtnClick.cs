using System.Data;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.KensaIraiKanrenFileTblDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KensaIraiKanri;
using FukjBizSystem.Application.DataSet.KensaIraiKanri.KensaKeikakuDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.KensaIraiTblDataSetTableAdapters;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Core.Generic.BusinessLogic;
using Zynas.Framework.Utility;
using FukjBizSystem.Application.BusinessLogic.KensaKeikaku.PrintJokasoMemoList;
using System.IO;

namespace FukjBizSystem.Application.ApplicationLogic.KensaIraiKanri.KensaKeikaku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IMemoPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IMemoPrintBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 印刷データ
        /// </summary>
        KensaKeikakuDataSet.KensaKeikakuListRow[] PrintData { get; set; }

        /// <summary>
        /// 印刷データ
        /// </summary>
        KensaKeikakuDataSet.KensaKeikakuMemoTblRow[] PrintMemoData { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MemoPrintBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class MemoPrintBtnClickALInput : IBseALInputImpl, IMemoPrintBtnClickALInput
    {
        /// <summary>
        /// 印刷データ
        /// </summary>
        public KensaKeikakuDataSet.KensaKeikakuListRow[] PrintData { get; set; }

        /// <summary>
        /// 印刷データ
        /// </summary>
        public KensaKeikakuDataSet.KensaKeikakuMemoTblRow[] PrintMemoData { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IMemoPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IMemoPrintBtnClickALOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MemoPrintBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class MemoPrintBtnClickALOutput : IMemoPrintBtnClickALOutput
    {

    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： MemoPrintBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/30　habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class MemoPrintBtnClickApplicationLogic : BaseApplicationLogic<IMemoPrintBtnClickALInput, IMemoPrintBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaKeikaku：MemoPrintBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： MemoPrintBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/30　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public MemoPrintBtnClickApplicationLogic()
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
        /// 2015/01/30　habu　　    新規作成
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
        /// 2015/01/30　habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IMemoPrintBtnClickALOutput Execute(IMemoPrintBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IMemoPrintBtnClickALOutput output = new MemoPrintBtnClickALOutput();

            try
            {
                // 検体授受票出力実行
                {
                    IPrintJokasoMemoListBLInput blInput = new PrintJokasoMemoListBLInput();
                    blInput.AfterDispFlg = true;
                    blInput.FormatPath = Path.Combine(Properties.Settings.Default.PrintFormatFolder, Properties.Settings.Default.JokasoMemoListFormatFile);
                    blInput.PrintDirectory = Properties.Settings.Default.PrintDirectory;

                    blInput.PrintData = input.PrintData;
                    blInput.PrintMemoData = input.PrintMemoData;

                    IPrintJokasoMemoListBLOutput blOutput = new PrintJokasoMemoListBusinessLogic().Execute(blInput);
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
