using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShokuinMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensainSyuhoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokuinNmShishoNmKensainSyuhoListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokuinNmShishoNmKensainSyuhoListBLInput : ISelectShokuinNmShishoNmKensainSyuhoListDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokuinNmShishoNmKensainSyuhoListBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokuinNmShishoNmKensainSyuhoListBLInput : IGetShokuinNmShishoNmKensainSyuhoListBLInput
    {
        
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetShokuinNmShishoNmKensainSyuhoListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetShokuinNmShishoNmKensainSyuhoListBLOutput : ISelectShokuinNmShishoNmKensainSyuhoListDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokuinNmShishoNmKensainSyuhoListBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokuinNmShishoNmKensainSyuhoListBLOutput : IGetShokuinNmShishoNmKensainSyuhoListBLOutput
    {
        /// <summary>
        /// ShokuinNmShishoNmKensainSyuhoListDataTable
        /// </summary>
        public ShokuinMstDataSet.ShokuinNmShishoNmKensainSyuhoListDataTable ShokuinNmShishoNmKensainSyuhoListDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetShokuinNmShishoNmKensainSyuhoListBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/29  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetShokuinNmShishoNmKensainSyuhoListBusinessLogic : BaseBusinessLogic<IGetShokuinNmShishoNmKensainSyuhoListBLInput, IGetShokuinNmShishoNmKensainSyuhoListBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetShokuinNmShishoNmKensainSyuhoListBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetShokuinNmShishoNmKensainSyuhoListBusinessLogic()
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
        /// 2014/08/29  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetShokuinNmShishoNmKensainSyuhoListBLOutput Execute(IGetShokuinNmShishoNmKensainSyuhoListBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetShokuinNmShishoNmKensainSyuhoListBLOutput output = new GetShokuinNmShishoNmKensainSyuhoListBLOutput();

            try
            {
                output.ShokuinNmShishoNmKensainSyuhoListDT = new SelectShokuinNmShishoNmKensainSyuhoListDataAccess().Execute(input).ShokuinNmShishoNmKensainSyuhoListDT;
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
