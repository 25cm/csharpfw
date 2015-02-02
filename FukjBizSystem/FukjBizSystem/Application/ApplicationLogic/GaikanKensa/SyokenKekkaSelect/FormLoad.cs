using System.Reflection;
using FukjBizSystem.Application.Boundary.GaikanKensa;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.SyokenKekkaSelect;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.SyokenKekkaSelect
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
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALInput : IBseALInput
    {
        /// <summary>
        /// 所見区分
        /// </summary>
        string ShokenKbn { get; set; }

        /// <summary>
        /// 対象検査ビットマスク
        /// </summary>
        int ShokenTaishoKensaBitMask { get; set; }

        /// <summary>
        /// 表示モード
        /// </summary>
        SyokenKekkaSelectForm.Mode Mode { get; set; }
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
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALInput : IFormLoadALInput
    {
        /// <summary>
        /// 所見区分
        /// </summary>
        public string ShokenKbn { get; set; }

        /// <summary>
        /// 対象検査ビットマスク
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }

        /// <summary>
        /// 表示モード
        /// </summary>
        public SyokenKekkaSelectForm.Mode Mode { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("所見区分[{0}], 対象検査ビットマスク[{1}]", ShokenKbn, ShokenTaishoKensaBitMask);
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
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IFormLoadALOutput
    {
        /// <summary>
        /// ShokenCheckItemDataTable
        /// </summary>
        ShokenMstDataSet.ShokenCheckItemDataTable ShokenCheckItemDataTable { get; set; }

        /// <summary>
        /// ShokenKekkaSelectDataTable
        /// </summary>
        ShokenMstDataSet.ShokenKekkaSelectDataTable ShokenKekkaSelectDataTable { get; set; }
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
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadALOutput : IFormLoadALOutput
    {
        /// <summary>
        /// ShokenCheckItemDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenCheckItemDataTable ShokenCheckItemDataTable { get; set; }

        /// <summary>
        /// ShokenKekkaSelectDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenKekkaSelectDataTable ShokenKekkaSelectDataTable { get; set; }
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
    /// 2014/10/31　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class FormLoadApplicationLogic : BaseApplicationLogic<IFormLoadALInput, IFormLoadALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "ShokenKekkaSelect：FormLoad";

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
        /// 2014/10/31　AnhNV　　    新規作成
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
        /// 2014/10/31　AnhNV　　    新規作成
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
        /// 2014/10/31　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IFormLoadALOutput Execute(IFormLoadALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IFormLoadALOutput output = new FormLoadALOutput();

            try
            {
                // Get syokenDataGridView source
                IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput kbnInput = new GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput();
                kbnInput.ShokenKbn = input.ShokenKbn;
                kbnInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput kbnOutput = new GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBusinessLogic().Execute(kbnInput);
                output.ShokenKekkaSelectDataTable = kbnOutput.ShokenKekkaSelectDataTable;

                // Get combobox source 所見区分選択(3)
                IGetShokenCheckItemByShokenShitekiKbnBLInput sciInput = new GetShokenCheckItemByShokenShitekiKbnBLInput();
                sciInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                IGetShokenCheckItemByShokenShitekiKbnBLOutput sciOutput = new GetShokenCheckItemByShokenShitekiKbnBusinessLogic().Execute(sciInput);
                output.ShokenCheckItemDataTable = sciOutput.ShokenCheckItemDataTable;
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
