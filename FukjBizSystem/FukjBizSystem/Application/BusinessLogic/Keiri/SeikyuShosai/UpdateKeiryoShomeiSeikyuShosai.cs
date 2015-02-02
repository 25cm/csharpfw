using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiIraiTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.SeikyuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiSeikyuShosaiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiSeikyuShosaiBLInput : IUpdateKeiryoShomeiSeikyuShosaiDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiSeikyuShosaiBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiSeikyuShosaiBLInput : IUpdateKeiryoShomeiSeikyuShosaiBLInput
    {
        /// <summary>
        /// KeiryoShomeiSeikyuKbn
        /// </summary>
        public string KeiryoShomeiSeikyuKbn { get; set; }

        /// <summary>
        /// Now
        /// </summary>
        public DateTime Now { get; set; }

        /// <summary>
        /// LoginUser
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// PcUpdate
        /// </summary>
        public string PcUpdate { get; set; }

        /// <summary>
        /// OyaSeikyuNo
        /// </summary>
        public string OyaSeikyuNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiSeikyuShosaiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiSeikyuShosaiBLOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiSeikyuShosaiBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiSeikyuShosaiBLOutput : IUpdateKeiryoShomeiSeikyuShosaiBLOutput
    {
        
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiSeikyuShosaiBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/17　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiSeikyuShosaiBusinessLogic : BaseBusinessLogic<IUpdateKeiryoShomeiSeikyuShosaiBLInput, IUpdateKeiryoShomeiSeikyuShosaiBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKeiryoShomeiSeikyuShosaiBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/17　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKeiryoShomeiSeikyuShosaiBusinessLogic()
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
        /// 2014/12/17　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKeiryoShomeiSeikyuShosaiBLOutput Execute(IUpdateKeiryoShomeiSeikyuShosaiBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKeiryoShomeiSeikyuShosaiBLOutput output = new UpdateKeiryoShomeiSeikyuShosaiBLOutput();

            try
            {
                new UpdateKeiryoShomeiSeikyuShosaiDataAccess().Execute(input);
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
