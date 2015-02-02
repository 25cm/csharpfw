using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensainGeppoTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensainGeppoList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLInput : IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensainGeppoTblByShukeiNengetsuBetweenBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensainGeppoTblByShukeiNengetsuBetweenBLInput : IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLInput
    {
        /// <summary>
        /// 集計年月FROM
        /// </summary>
        public string ShukeiNengetsuFrom { get; set; }

        /// <summary>
        /// 集計年月TO
        /// </summary>
        public string ShukeiNengetsuTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLOutput : IDeleteKensainGeppoTblByShukeiNengetsuBetweenDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensainGeppoTblByShukeiNengetsuBetweenBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensainGeppoTblByShukeiNengetsuBetweenBLOutput : IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteKensainGeppoTblByShukeiNengetsuBetweenBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/28  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteKensainGeppoTblByShukeiNengetsuBetweenBusinessLogic : BaseBusinessLogic<IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLInput, IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteKensainGeppoTblByShukeiNengetsuBetweenBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/28  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteKensainGeppoTblByShukeiNengetsuBetweenBusinessLogic()
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
        /// 2014/08/28  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLOutput Execute(IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteKensainGeppoTblByShukeiNengetsuBetweenBLOutput output = new DeleteKensainGeppoTblByShukeiNengetsuBetweenBLOutput();

            try
            {
                new DeleteKensainGeppoTblByShukeiNengetsuBetweenDataAccess().Execute(input);
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
