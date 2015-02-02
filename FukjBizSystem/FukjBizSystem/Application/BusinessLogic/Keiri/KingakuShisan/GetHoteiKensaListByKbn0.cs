using System.Reflection;
using FukjBizSystem.Application.DataAccess.HoteiKensaRyokinMst;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.KingakuShisan
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoteiKensaListByKbn0BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoteiKensaListByKbn0BLInput : ISelectHoteiKensaListByKbn0DAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoteiKensaListByKbn0BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoteiKensaListByKbn0BLInput : IGetHoteiKensaListByKbn0BLInput
    {
        
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoteiKensaListByKbn0BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoteiKensaListByKbn0BLOutput : ISelectHoteiKensaListByKbn0DAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoteiKensaListByKbn0BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoteiKensaListByKbn0BLOutput : IGetHoteiKensaListByKbn0BLOutput
    {
        /// <summary>
        /// HoteiKensaListKbn0DataTable
        /// </summary>
        public HoteiKensaRyokinMstDataSet.HoteiKensaListKbn0DataTable HoteiKensaListKbn0DT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoteiKensaListByKbn0BusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/22  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoteiKensaListByKbn0BusinessLogic : BaseBusinessLogic<IGetHoteiKensaListByKbn0BLInput, IGetHoteiKensaListByKbn0BLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetHoteiKensaListByKbn0BusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetHoteiKensaListByKbn0BusinessLogic()
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
        /// 2014/08/22  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetHoteiKensaListByKbn0BLOutput Execute(IGetHoteiKensaListByKbn0BLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetHoteiKensaListByKbn0BLOutput output = new GetHoteiKensaListByKbn0BLOutput();

            try
            {
                output.HoteiKensaListKbn0DT = new SelectHoteiKensaListByKbn0DataAccess().Execute(input).HoteiKensaListKbn0DT;
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
