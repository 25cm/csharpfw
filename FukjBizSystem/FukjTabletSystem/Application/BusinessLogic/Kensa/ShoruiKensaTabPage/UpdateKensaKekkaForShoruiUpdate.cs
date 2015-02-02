using System.Reflection;
using FukjTabletSystem.Application.DataAccess.SQLCE.KensaKekkaTbl;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.BusinessLogic.Kensa.ShoruiKensaTabPage
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaKekkaForShoruiUpdateBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKensaKekkaForShoruiUpdateBLInput : IUpdateKensaKekkaForShoruiUpdateDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaKekkaForShoruiUpdateBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaKekkaForShoruiUpdateBLInput : IUpdateKensaKekkaForShoruiUpdateBLInput
    {
        /// <summary>
        /// KensaKekkaForShoruiUpdate
        /// </summary>
        public KensaKekkaTblDataSet.KensaKekkaForShoruiUpdateDataTable KensaKekkaForShoruiUpdate { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKensaKekkaForShoruiUpdateBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKensaKekkaForShoruiUpdateBLOutput : IUpdateKensaKekkaForShoruiUpdateDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaKekkaForShoruiUpdateBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaKekkaForShoruiUpdateBLOutput : IUpdateKensaKekkaForShoruiUpdateBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKensaKekkaForShoruiUpdateBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/21　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKensaKekkaForShoruiUpdateBusinessLogic : BaseBusinessLogic<IUpdateKensaKekkaForShoruiUpdateBLInput, IUpdateKensaKekkaForShoruiUpdateBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKensaKekkaForShoruiUpdateBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/21　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKensaKekkaForShoruiUpdateBusinessLogic()
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
        /// 2014/11/21　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKensaKekkaForShoruiUpdateBLOutput Execute(IUpdateKensaKekkaForShoruiUpdateBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKensaKekkaForShoruiUpdateBLOutput output = new UpdateKensaKekkaForShoruiUpdateBLOutput();

            try
            {
                new UpdateKensaKekkaForShoruiUpdateDataAccess().Execute(input);
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
