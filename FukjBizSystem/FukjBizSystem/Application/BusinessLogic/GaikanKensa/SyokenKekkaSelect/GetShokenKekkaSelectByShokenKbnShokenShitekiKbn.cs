using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShokenMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.SyokenKekkaSelect
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput
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
    interface IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput : ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput
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
    class GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput : IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput
    {
        /// <summary>
        /// 所見区分
        /// </summary>
        public string ShokenKbn { get; set; }

        /// <summary>
        /// 対象検査ビットマスク
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput
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
    interface IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput : ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput
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
    class GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput : IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput
    {
        /// <summary>
        /// ShokenKekkaSelectDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenKekkaSelectDataTable ShokenKekkaSelectDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBusinessLogic
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
    class GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBusinessLogic : BaseBusinessLogic<IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput, IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBusinessLogic
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
        public GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBusinessLogic()
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
        /// 2014/10/31　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput Execute(IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput output = new GetShokenKekkaSelectByShokenKbnShokenShitekiKbnBLOutput();

            try
            {
                ISelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDAOutput daOutput = new SelectShokenKekkaSelectByShokenKbnShokenShitekiKbnDataAccess().Execute(input);
                output.ShokenKekkaSelectDataTable = daOutput.ShokenKekkaSelectDataTable;
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
