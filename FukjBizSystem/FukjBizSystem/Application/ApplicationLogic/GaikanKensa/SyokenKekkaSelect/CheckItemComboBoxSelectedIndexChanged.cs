using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.SyokenKekkaSelect;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.SyokenKekkaSelect
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICheckItemComboBoxSelectedIndexChangedALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICheckItemComboBoxSelectedIndexChangedALInput : IBseALInput
    {
        /// <summary>
        /// 所見区分
        /// </summary>
        string ShokenKbn { get; set; }

        /// <summary>
        /// 対象検査ビットマスク
        /// </summary>
        int ShokenTaishoKensaBitMask { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CheckItemComboBoxSelectedIndexChangedALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CheckItemComboBoxSelectedIndexChangedALInput : ICheckItemComboBoxSelectedIndexChangedALInput
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
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("所見区分[{0}], 指摘区分[{1}]", ShokenKbn, ShokenTaishoKensaBitMask);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICheckItemComboBoxSelectedIndexChangedALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICheckItemComboBoxSelectedIndexChangedALOutput
    {
        /// <summary>
        /// ShokenKekkaSelectDataTable
        /// </summary>
        ShokenMstDataSet.ShokenKekkaSelectDataTable ShokenKekkaSelectDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CheckItemComboBoxSelectedIndexChangedALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CheckItemComboBoxSelectedIndexChangedALOutput : ICheckItemComboBoxSelectedIndexChangedALOutput
    {
        /// <summary>
        /// ShokenKekkaSelectDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenKekkaSelectDataTable ShokenKekkaSelectDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CheckItemComboBoxSelectedIndexChangedApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/03　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CheckItemComboBoxSelectedIndexChangedApplicationLogic : BaseApplicationLogic<ICheckItemComboBoxSelectedIndexChangedALInput, ICheckItemComboBoxSelectedIndexChangedALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SyokenKekkaSelect：CheckItemComboBoxSelectedIndexChanged";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CheckItemComboBoxSelectedIndexChangedApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CheckItemComboBoxSelectedIndexChangedApplicationLogic()
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
        /// 2014/11/03　AnhNV　　    新規作成
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
        /// 2014/11/03　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ICheckItemComboBoxSelectedIndexChangedALOutput Execute(ICheckItemComboBoxSelectedIndexChangedALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICheckItemComboBoxSelectedIndexChangedALOutput output = new CheckItemComboBoxSelectedIndexChangedALOutput();

            try
            {
                // 所見一覧データグリッドビュー datasource
                IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput kbnInput = new GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput();
                kbnInput.ShokenKbn = input.ShokenKbn;
                kbnInput.ShokenTaishoKensaBitMask = input.ShokenTaishoKensaBitMask;
                IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput kbnOutput = new GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBusinessLogic().Execute(kbnInput);
                output.ShokenKekkaSelectDataTable = kbnOutput.ShokenKekkaSelectDataTable;
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
