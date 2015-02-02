using System;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.UriageTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiMakeFile
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcUriageSyukeiStdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcUriageSyukeiStdBLInput : IExecProcUriageSyukeiStdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcUriageSyukeiStdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcUriageSyukeiStdBLInput : IExecProcUriageSyukeiStdBLInput
    {
        /// <summary>
        /// 売上日FROM
        /// </summary>
        public DateTime UriageDtFrom { get; set; }

        /// <summary>
        /// 売上日TO
        /// </summary>
        public DateTime UriageDtTo { get; set; }

        /// <summary>
        /// ログイン者
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// 端末
        /// </summary>
        public string Machine { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcUriageSyukeiStdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcUriageSyukeiStdBLOutput : IExecProcUriageSyukeiStdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcUriageSyukeiStdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcUriageSyukeiStdBLOutput : IExecProcUriageSyukeiStdBLOutput
    {
        /// <summary>
        /// Error Flag
        /// </summary>
        public string ErrorFlg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcUriageSyukeiStdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/12  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcUriageSyukeiStdBusinessLogic : BaseBusinessLogic<IExecProcUriageSyukeiStdBLInput, IExecProcUriageSyukeiStdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcUriageSyukeiStdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcUriageSyukeiStdBusinessLogic()
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
        /// 2014/11/12  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcUriageSyukeiStdBLOutput Execute(IExecProcUriageSyukeiStdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcUriageSyukeiStdBLOutput output = new ExecProcUriageSyukeiStdBLOutput();

            try
            {
                output.ErrorFlg = new ExecProcUriageSyukeiStdDataAccess().Execute(input).ErrorFlg;
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
