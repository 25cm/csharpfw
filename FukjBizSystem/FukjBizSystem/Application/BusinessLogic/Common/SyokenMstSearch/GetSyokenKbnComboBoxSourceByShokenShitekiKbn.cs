using System.Reflection;
using FukjBizSystem.Application.DataAccess.GaikanKensaKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common.SyokenMstSearch
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLInput
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
    interface IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLInput : ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSyokenKbnComboBoxSourceByShokenShitekiKbnBLInput
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
    class GetSyokenKbnComboBoxSourceByShokenShitekiKbnBLInput : IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLInput
    {
        /// <summary>
        /// 指摘区分
        /// </summary>
        public string ShokenShitekiKbn { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput
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
    interface IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput : ISelectSyokenKbnComboBoxSourceByShokenShitekiKbnDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput
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
    class GetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput : IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput
    {
        /// <summary>
        /// SyokenKbnComboBoxSourceDataTable
        /// </summary>
        public GaikanKensaKekkaTblDataSet.SyokenKbnComboBoxSourceDataTable SyokenKbnComboBoxSourceDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetSyokenKbnComboBoxSourceByShokenShitekiKbnBusinessLogic
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
    class GetSyokenKbnComboBoxSourceByShokenShitekiKbnBusinessLogic : BaseBusinessLogic<IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLInput, IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetSyokenKbnComboBoxSourceByShokenShitekiKbnBusinessLogic
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
        public GetSyokenKbnComboBoxSourceByShokenShitekiKbnBusinessLogic()
        {
            
        }
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
        public override IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput Execute(IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput output = new GetSyokenKbnComboBoxSourceByShokenShitekiKbnBLOutput();

            try
            {
                output.SyokenKbnComboBoxSourceDT = new SelectSyokenKbnComboBoxSourceByShokenShitekiKbnDataAccess().Execute(input).SyokenKbnComboBoxSourceDT;
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
