using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.KaiinKanri.KaiinNyukin;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using Zynas.Framework.Core.Generic.BusinessLogic;
using FukjBizSystem.Application.DataSet.NenKaihiTblDataSetTableAdapters;
using FukjBizSystem.Application.DataSet.NyukinTblDataSetTableAdapters;

namespace FukjBizSystem.Application.ApplicationLogic.SuishitsuKensaUketsuke.GenkinNyukin
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICheckExistsALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICheckExistsALInput : IBseALInput
    {
        /// <summary>
        /// 
        /// </summary>
        string KensaKbn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string KensaHoteiKbn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string KensaHokenjoCd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string KensaNendo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string KensaRenban { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string KeiryoNendo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string KeiryoShishoCd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        string KeiryoRenban { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CheckExistsALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CheckExistsALInput : ICheckExistsALInput
    {
        /// <summary>
        /// 
        /// </summary>
        public string KensaKbn { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string KensaHoteiKbn { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KensaHokenjoCd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KensaNendo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KensaRenban { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string KeiryoNendo { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KeiryoShishoCd { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string KeiryoRenban { get; set; }

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
    //  インターフェイス名 ： ICheckExistsALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICheckExistsALOutput
    {
        /// <summary>
        /// 
        /// </summary>
        NyukinTblDataSet.NyukinTblDataTable NyukinTbl { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CheckExistsALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CheckExistsALOutput : ICheckExistsALOutput
    {
        /// <summary>
        /// 
        /// </summary>
        public NyukinTblDataSet.NyukinTblDataTable NyukinTbl { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CheckExistsApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/22  habu　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CheckExistsApplicationLogic : BaseApplicationLogic<ICheckExistsALInput, ICheckExistsALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KaiinNyukin：CheckExists";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CheckExistsApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/22  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CheckExistsApplicationLogic()
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
        /// 2014/12/22  habu　　    新規作成
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
        /// 2014/12/22  habu　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ICheckExistsALOutput Execute(ICheckExistsALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICheckExistsALOutput output = new CheckExistsALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                NyukinTblDataSet.NyukinTblDataTable template = new NyukinTblDataSet.NyukinTblDataTable();

                // checkExists
                if (input.KensaKbn == "1")
                {
                    IStdFilteredGetDataBLInput getInput = new StdFilteredGetDataBLInput();
                    getInput.DataTableType = typeof(NyukinTblDataSet.NyukinTblDataTable);
                    getInput.TableAdapterType = typeof(NyukinTblTableAdapter);
                    getInput.Query.AddEqualCond(template.KensaIraiHoteiKbnColumn.ColumnName, input.KensaHoteiKbn);
                    getInput.Query.AddEqualCond(template.KensaIraiHokenjoCdColumn.ColumnName, input.KensaHokenjoCd);
                    getInput.Query.AddEqualCond(template.KensaIraiNendoColumn.ColumnName, input.KensaNendo);
                    getInput.Query.AddEqualCond(template.KensaIraiRenbanColumn.ColumnName, input.KensaRenban);
                    getInput.Query.AddEqualCond(template.NyukinSyubetsuColumn.ColumnName, "6");

                    IStdFilteredGetDataBLOutput getOutput = new StdFilteredGetDataBusinessLogic().Execute(getInput);
                    output.NyukinTbl = (NyukinTblDataSet.NyukinTblDataTable)getOutput.GetDataTable;
                }
                else
                {
                    IStdFilteredGetDataBLInput getInput = new StdFilteredGetDataBLInput();
                    getInput.DataTableType = typeof(NyukinTblDataSet.NyukinTblDataTable);
                    getInput.TableAdapterType = typeof(NyukinTblTableAdapter);
                    getInput.Query.AddEqualCond(template.KeiryoShomeiIraiNendoColumn.ColumnName, input.KeiryoNendo);
                    getInput.Query.AddEqualCond(template.KeiryoShomeiIraiSishoCdColumn.ColumnName, input.KeiryoShishoCd);
                    getInput.Query.AddEqualCond(template.KeiryoShomeiIraiRenbanColumn.ColumnName, input.KeiryoRenban);
                    getInput.Query.AddEqualCond(template.NyukinSyubetsuColumn.ColumnName, "5");

                    IStdFilteredGetDataBLOutput getOutput = new StdFilteredGetDataBusinessLogic().Execute(getInput);
                    output.NyukinTbl = (NyukinTblDataSet.NyukinTblDataTable)getOutput.GetDataTable;
                }

                // コミット
                CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                // トランザクション終了
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
