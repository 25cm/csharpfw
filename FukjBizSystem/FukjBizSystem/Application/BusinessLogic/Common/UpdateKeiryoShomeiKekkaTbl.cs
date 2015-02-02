using System.Reflection;
using FukjBizSystem.Application.DataAccess.KeiryoShomeiKekkaTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiKekkaTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiKekkaTblBLInput : IUpdateKeiryoShomeiKekkaTblDAInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiKekkaTblBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiKekkaTblBLInput : IUpdateKeiryoShomeiKekkaTblBLInput
    {
        /// <summary>
        /// KeiryoShomeiKekkaTblDataTable
        /// </summary>
        public KeiryoShomeiKekkaTblDataSet.KeiryoShomeiKekkaTblDataTable KeiryoShomeiKekkaTblDT { get; set; }
    }
    #endregion


    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IUpdateKeiryoShomeiKekkaTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IUpdateKeiryoShomeiKekkaTblBLOutput
    {

    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiKekkaTblBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiKekkaTblBLOutput : IUpdateKeiryoShomeiKekkaTblBLOutput
    {

    }
    #endregion


    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： UpdateKeiryoShomeiKekkaTblBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/03  小松　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class UpdateKeiryoShomeiKekkaTblBusinessLogic : BaseBusinessLogic<IUpdateKeiryoShomeiKekkaTblBLInput, IUpdateKeiryoShomeiKekkaTblBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： UpdateKeiryoShomeiKekkaTblBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/03  小松　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public UpdateKeiryoShomeiKekkaTblBusinessLogic()
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
        /// 2014/12/03  小松　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IUpdateKeiryoShomeiKekkaTblBLOutput Execute(IUpdateKeiryoShomeiKekkaTblBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IUpdateKeiryoShomeiKekkaTblBLOutput output = new UpdateKeiryoShomeiKekkaTblBLOutput();

            try
            {
                new UpdateKeiryoShomeiKekkaTblDataAccess().Execute(input);
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
