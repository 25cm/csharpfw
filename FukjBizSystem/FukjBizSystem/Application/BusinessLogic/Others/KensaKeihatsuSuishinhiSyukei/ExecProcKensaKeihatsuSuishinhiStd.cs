using System.Reflection;
using FukjBizSystem.Application.DataAccess.KensaKeihatsuSuishinHiShukeiTbl;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.Others.KensaKeihatsuSuishinhiSyukei
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcKensaKeihatsuSuishinhiStdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcKensaKeihatsuSuishinhiStdBLInput : IExecProcKensaKeihatsuSuishinhiStdDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcKensaKeihatsuSuishinhiStdBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcKensaKeihatsuSuishinhiStdBLInput : IExecProcKensaKeihatsuSuishinhiStdBLInput
    {
        /// <summary>
        /// StepNo 更新仕様の処理番号
        /// </summary>
        public int StepNo { get; set; }

        /// <summary>
        /// 開始日
        /// </summary>
        public string SyukeiFrom { get; set; }

        /// <summary>
        /// 終了日
        /// </summary>
        public string SyukeiTo { get; set; }

        /// <summary>
        /// 支払日
        /// </summary>
        public string ShiharaiDt { get; set; }

        /// <summary>
        /// 推進費採番No 年度 + 採番No (10桁)
        /// </summary>
        public string SaibanNo { get; set; }

        /// <summary>
        /// 業者コード(開始)
        /// </summary>
        public string GyoshaCdFrom { get; set; }

        /// <summary>
        /// 業者コード(終了)
        /// </summary>
        public string GyoshaCdTo { get; set; }

        /// <summary>
        /// 更新者
        /// </summary>
        public string LoginUser { get; set; }

        /// <summary>
        /// 更新端末
        /// </summary>
        public string PcUpdate { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IExecProcKensaKeihatsuSuishinhiStdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IExecProcKensaKeihatsuSuishinhiStdBLOutput : IExecProcKensaKeihatsuSuishinhiStdDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcKensaKeihatsuSuishinhiStdBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcKensaKeihatsuSuishinhiStdBLOutput : IExecProcKensaKeihatsuSuishinhiStdBLOutput
    {
        /// <summary>
        /// Error Flag
        /// </summary>
        public string ErrorFlg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ExecProcKensaKeihatsuSuishinhiStdBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/13　DatNT    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ExecProcKensaKeihatsuSuishinhiStdBusinessLogic : BaseBusinessLogic<IExecProcKensaKeihatsuSuishinhiStdBLInput, IExecProcKensaKeihatsuSuishinhiStdBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ExecProcKensaKeihatsuSuishinhiStdBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/13　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ExecProcKensaKeihatsuSuishinhiStdBusinessLogic()
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
        /// 2014/12/13　DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IExecProcKensaKeihatsuSuishinhiStdBLOutput Execute(IExecProcKensaKeihatsuSuishinhiStdBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IExecProcKensaKeihatsuSuishinhiStdBLOutput output = new ExecProcKensaKeihatsuSuishinhiStdBLOutput();

            try
            {
                output.ErrorFlg = new ExecProcKensaKeihatsuSuishinhiStdDataAccess().Execute(input).ErrorFlg;
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
