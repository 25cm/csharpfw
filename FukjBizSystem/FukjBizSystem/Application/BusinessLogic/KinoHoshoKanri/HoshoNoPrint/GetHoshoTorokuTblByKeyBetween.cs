using System.Reflection;
using FukjBizSystem.Application.DataAccess.HoshoTorokuTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoNoPrint
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoshoTorokuTblByKeyBetweenBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoshoTorokuTblByKeyBetweenBLInput : ISelectHoshoTorokuTblByKeyBetweenDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoTorokuTblByKeyBetweenBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoTorokuTblByKeyBetweenBLInput : IGetHoshoTorokuTblByKeyBetweenBLInput
    {
        /// <summary>
        /// 保証登録検査機関（開始）, 保証登録年度（開始）, 保証登録年度（終了）
        /// </summary>
        public string KensakikanNendoRenbanFrom { get; set; }

        /// <summary>
        /// 保証登録検査機関（終了）, 保証登録連番（終了）, 保証登録連番（終了）
        /// </summary>
        public string KensakikanNendoRenbanTo { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoshoTorokuTblByKeyBetweenBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoshoTorokuTblByKeyBetweenBLOutput : ISelectHoshoTorokuTblByKeyBetweenDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoTorokuTblByKeyBetweenBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoTorokuTblByKeyBetweenBLOutput : IGetHoshoTorokuTblByKeyBetweenBLOutput
    {
        /// <summary>
        /// HoshoTorokuTblDataTable
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuTblDataTable HoshoTorokuTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoTorokuTblByKeyBetweenBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoTorokuTblByKeyBetweenBusinessLogic : BaseBusinessLogic<IGetHoshoTorokuTblByKeyBetweenBLInput, IGetHoshoTorokuTblByKeyBetweenBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetHoshoTorokuTblByKeyBetweenBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetHoshoTorokuTblByKeyBetweenBusinessLogic()
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
        /// 2014/07/17  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetHoshoTorokuTblByKeyBetweenBLOutput Execute(IGetHoshoTorokuTblByKeyBetweenBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetHoshoTorokuTblByKeyBetweenBLOutput output = new GetHoshoTorokuTblByKeyBetweenBLOutput();

            try
            {
                output.HoshoTorokuTblDT = new SelectHoshoTorokuTblByKeyBetweenDataAccess().Execute(input).HoshoTorokuTblDT;
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
