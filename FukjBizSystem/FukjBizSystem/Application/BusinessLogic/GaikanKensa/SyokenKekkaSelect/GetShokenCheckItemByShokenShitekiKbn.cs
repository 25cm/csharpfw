using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShokenMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.GaikanKensa.SyokenKekkaSelect
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokenCheckItemByShokenShitekiKbnBLInput
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
    interface IGetShokenCheckItemByShokenShitekiKbnBLInput : ISelectShokenCheckItemByShokenShitekiKbnDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenCheckItemByShokenShitekiKbnBLInput
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
    class GetShokenCheckItemByShokenShitekiKbnBLInput : IGetShokenCheckItemByShokenShitekiKbnBLInput
    {
        /// <summary>
        /// 対象検査ビットマスク
        /// </summary>
        public int ShokenTaishoKensaBitMask { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokenCheckItemByShokenShitekiKbnBLOutput
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
    interface IGetShokenCheckItemByShokenShitekiKbnBLOutput : ISelectShokenCheckItemByShokenShitekiKbnDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenCheckItemByShokenShitekiKbnBLOutput
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
    class GetShokenCheckItemByShokenShitekiKbnBLOutput : IGetShokenCheckItemByShokenShitekiKbnBLOutput
    {
        /// <summary>
        /// ShokenCheckItemDataTable
        /// </summary>
        public ShokenMstDataSet.ShokenCheckItemDataTable ShokenCheckItemDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokenCheckItemByShokenShitekiKbnBusinessLogic
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
    class GetShokenCheckItemByShokenShitekiKbnBusinessLogic : BaseBusinessLogic<IGetShokenCheckItemByShokenShitekiKbnBLInput, IGetShokenCheckItemByShokenShitekiKbnBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShokenCheckItemByShokenShitekiKbnBusinessLogic
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
        public GetShokenCheckItemByShokenShitekiKbnBusinessLogic()
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
        public override IGetShokenCheckItemByShokenShitekiKbnBLOutput Execute(IGetShokenCheckItemByShokenShitekiKbnBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShokenCheckItemByShokenShitekiKbnBLOutput output = new GetShokenCheckItemByShokenShitekiKbnBLOutput();

            try
            {
                ISelectShokenCheckItemByShokenShitekiKbnDAOutput daOutput = new SelectShokenCheckItemByShokenShitekiKbnDataAccess().Execute(input);
                output.ShokenCheckItemDataTable = daOutput.ShokenCheckItemDataTable;
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
