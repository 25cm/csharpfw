using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.SeikyusyoKagamiTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertSeikyuShosaiKagami010BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertSeikyuShosaiKagami010BLInput : IInsertSeikyuShosaiKagami010DAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertSeikyuShosaiKagami010BLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertSeikyuShosaiKagami010BLInput : IInsertSeikyuShosaiKagami010BLInput
    {
        /// <summary>
        /// Now
        /// </summary>
        public DateTime Now { get; set; }

        /// <summary>
        /// PcUpdate
        /// </summary>
        public string PcUpdate { get; set; }

        /// <summary>
        /// LoginUser
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// OyaSeikyuNo
        /// </summary>
        public string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IInsertSeikyuShosaiKagami010BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IInsertSeikyuShosaiKagami010BLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertSeikyuShosaiKagami010BLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertSeikyuShosaiKagami010BLOutput : IInsertSeikyuShosaiKagami010BLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： InsertSeikyuShosaiKagami010BusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/16　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class InsertSeikyuShosaiKagami010BusinessLogic : BaseBusinessLogic<IInsertSeikyuShosaiKagami010BLInput, IInsertSeikyuShosaiKagami010BLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： InsertSeikyuShosaiKagami010BusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/16　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public InsertSeikyuShosaiKagami010BusinessLogic()
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
        /// 2014/12/16　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IInsertSeikyuShosaiKagami010BLOutput Execute(IInsertSeikyuShosaiKagami010BLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IInsertSeikyuShosaiKagami010BLOutput output = new InsertSeikyuShosaiKagami010BLOutput();

            try
            {
                new InsertSeikyuShosaiKagami010DataAccess().Execute(input);
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
