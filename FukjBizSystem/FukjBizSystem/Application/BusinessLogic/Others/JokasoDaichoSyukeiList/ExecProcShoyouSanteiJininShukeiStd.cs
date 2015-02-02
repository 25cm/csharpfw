using System.Reflection;
using FukjBizSystem.Application.DataAccess.ShoyoSanteiJininShukeiTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.JokasoDaichoSyukeiList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcShoyouSanteiJininShukeiStdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcShoyouSanteiJininShukeiStdBLInput : IExecProcShoyouSanteiJininShukeiStdDAInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcShoyouSanteiJininShukeiStdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcShoyouSanteiJininShukeiStdBLInput : IExecProcShoyouSanteiJininShukeiStdBLInput
    {
        /// <summary>
        /// Nendo
        /// </summary>
        public int Nendo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcShoyouSanteiJininShukeiStdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcShoyouSanteiJininShukeiStdBLOutput : IExecProcShoyouSanteiJininShukeiStdDAOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcShoyouSanteiJininShukeiStdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcShoyouSanteiJininShukeiStdBLOutput : IExecProcShoyouSanteiJininShukeiStdBLOutput
    {
        /// <summary>
        /// ErrorFlg
        /// </summary>
        public string ErrorFlg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcShoyouSanteiJininShukeiStdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  HuyTX　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcShoyouSanteiJininShukeiStdBusinessLogic : BaseBusinessLogic<IExecProcShoyouSanteiJininShukeiStdBLInput, IExecProcShoyouSanteiJininShukeiStdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcShoyouSanteiJininShukeiStdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcShoyouSanteiJininShukeiStdBusinessLogic()
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
        /// 2014/12/23  HuyTX　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcShoyouSanteiJininShukeiStdBLOutput Execute(IExecProcShoyouSanteiJininShukeiStdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcShoyouSanteiJininShukeiStdBLOutput output = new ExecProcShoyouSanteiJininShukeiStdBLOutput();

            try
            {
                output.ErrorFlg = new ExecProcShoyouSanteiJininShukeiStdDataAccess().Execute(input).ErrorFlg;

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
