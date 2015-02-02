using System.Collections.Generic;
using System.Reflection;
using FukjBizSystem.Application.DataAccess.KaikeiRendoHdrTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Keiri.KaikeiMakeFile
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcSuitoSyukeiStdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcSuitoSyukeiStdBLInput : IExecProcSuitoSyukeiStdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSuitoSyukeiStdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSuitoSyukeiStdBLInput : IExecProcSuitoSyukeiStdBLInput
    {
        /// <summary>
        /// 対象区分
        /// </summary>
        public string TaishoKbn { get; set; }

        /// <summary>
        /// 支所コード
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// 対象日（開始）
        /// </summary>
        public string TaisyoFrom { get; set; }

        /// <summary>
        /// 対象日（終了）
        /// </summary>
        public string TaisyoTo { get; set; }

        /// <summary>
        /// 作成対象
        /// </summary>
        public string SakuseiTaisho { get; set; }

        /// <summary>
        /// 作成範囲
        /// </summary>
        public string SakuseiHani { get; set; }

        /// <summary>
        /// 和暦
        /// </summary>
        public string Wareki { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// 更新端末
        /// </summary>
        public string PcUpdate { get; set; }

        /// <summary>
        /// 会計採番No
        /// </summary>
        public string KaikeiSaibanNo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcSuitoSyukeiStdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcSuitoSyukeiStdBLOutput : IExecProcSuitoSyukeiStdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSuitoSyukeiStdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSuitoSyukeiStdBLOutput : IExecProcSuitoSyukeiStdBLOutput
    {
        /// <summary>
        /// ListResult (ErrorFlg & KaikeiSaibanNo)
        /// </summary>
        public List<string> ListResult { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcSuitoSyukeiStdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcSuitoSyukeiStdBusinessLogic : BaseBusinessLogic<IExecProcSuitoSyukeiStdBLInput, IExecProcSuitoSyukeiStdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcSuitoSyukeiStdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcSuitoSyukeiStdBusinessLogic()
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
        /// 2014/11/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcSuitoSyukeiStdBLOutput Execute(IExecProcSuitoSyukeiStdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcSuitoSyukeiStdBLOutput output = new ExecProcSuitoSyukeiStdBLOutput();

            try
            {
                output.ListResult = new ExecProcSuitoSyukeiStdDataAccess().Execute(input).ListResult;
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
