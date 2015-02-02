using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Common.SyokenMstSearch;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Common.SyokenMstSearch
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IShitekiKbnComboBoxSelectedIndexChangedALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IShitekiKbnComboBoxSelectedIndexChangedALInput : IBseALInput, IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShitekiKbnComboBoxSelectedIndexChangedALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ShitekiKbnComboBoxSelectedIndexChangedALInput : IShitekiKbnComboBoxSelectedIndexChangedALInput
    {
        /// <summary>
        /// 指摘区分
        /// </summary>
        public string ShokenShitekiKbn { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("指摘区分[{0}]", ShokenShitekiKbn);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IShitekiKbnComboBoxSelectedIndexChangedALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IShitekiKbnComboBoxSelectedIndexChangedALOutput : IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShitekiKbnComboBoxSelectedIndexChangedALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ShitekiKbnComboBoxSelectedIndexChangedALOutput : IShitekiKbnComboBoxSelectedIndexChangedALOutput
    {
        /// <summary>
        /// SyokenKbnComboBoxSourceDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.SyokenKbnComboBoxSourceDataTable SyokenKbnComboBoxSourceDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ShitekiKbnComboBoxSelectedIndexChangedApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ShitekiKbnComboBoxSelectedIndexChangedApplicationLogic : BaseApplicationLogic<IShitekiKbnComboBoxSelectedIndexChangedALInput, IShitekiKbnComboBoxSelectedIndexChangedALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "SyokenMstSearch：ShitekiKbnComboBoxSelectedIndexChangedApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ShitekiKbnComboBoxSelectedIndexChangedApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ShitekiKbnComboBoxSelectedIndexChangedApplicationLogic()
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
        /// 2014/09/29  DatNT　  新規作成
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
        /// 2014/09/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IShitekiKbnComboBoxSelectedIndexChangedALOutput Execute(IShitekiKbnComboBoxSelectedIndexChangedALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IShitekiKbnComboBoxSelectedIndexChangedALOutput output = new ShitekiKbnComboBoxSelectedIndexChangedALOutput();

            try
            {
                output.SyokenKbnComboBoxSourceDT = new GetSyokenKbnComboBoxSourceByShokenShitekiKbnBusinessLogic().Execute(input).SyokenKbnComboBoxSourceDT;
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
