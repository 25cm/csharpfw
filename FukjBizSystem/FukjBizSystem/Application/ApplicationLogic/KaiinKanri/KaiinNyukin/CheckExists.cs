using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.KaiinKanri.KaiinNyukin;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using Zynas.Framework.Core.Generic.BusinessLogic;
using FukjBizSystem.Application.DataSet.NenKaihiTblDataSetTableAdapters;

namespace FukjBizSystem.Application.ApplicationLogic.KaiinKanri.KaiinNyukin
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
        string Nendo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string GyoshaCd { get; set; }
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
        public string Nendo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string GyoshaCd { get; set; }

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
        NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblNenkaihi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblNyukaikin { get; set; }
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
        public NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblNenkaihi { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public NenKaihiTblDataSet.NenKaihiTblDataTable NenKaihiTblNyukaikin { get; set; }
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

                NenKaihiTblDataSet.NenKaihiTblDataTable template = new NenKaihiTblDataSet.NenKaihiTblDataTable();

                // checkExists
                {
                    IStdFilteredGetDataBLInput getInput = new StdFilteredGetDataBLInput();
                    getInput.DataTableType = typeof(NenKaihiTblDataSet.NenKaihiTblDataTable);
                    getInput.TableAdapterType = typeof(NenKaihiTblTableAdapter);
                    getInput.Query.AddEqualCond(template.NendoColumn.ColumnName, input.Nendo);
                    getInput.Query.AddEqualCond(template.KaihiGyosyaCdColumn.ColumnName, input.GyoshaCd);
                    getInput.Query.AddEqualCond(template.NenkaihiKbnColumn.ColumnName, "1");

                    IStdFilteredGetDataBLOutput getOutput = new StdFilteredGetDataBusinessLogic().Execute(getInput);
                    output.NenKaihiTblNenkaihi = (NenKaihiTblDataSet.NenKaihiTblDataTable)getOutput.GetDataTable;
                }
                {
                    IStdFilteredGetDataBLInput getInput = new StdFilteredGetDataBLInput();
                    getInput.DataTableType = typeof(NenKaihiTblDataSet.NenKaihiTblDataTable);
                    getInput.TableAdapterType = typeof(NenKaihiTblTableAdapter);
                    getInput.Query.AddEqualCond(template.NendoColumn.ColumnName, input.Nendo);
                    getInput.Query.AddEqualCond(template.KaihiGyosyaCdColumn.ColumnName, input.GyoshaCd);
                    getInput.Query.AddEqualCond(template.NenkaihiKbnColumn.ColumnName, "2");

                    IStdFilteredGetDataBLOutput getOutput = new StdFilteredGetDataBusinessLogic().Execute(getInput);
                    output.NenKaihiTblNyukaikin = (NenKaihiTblDataSet.NenKaihiTblDataTable)getOutput.GetDataTable;
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
