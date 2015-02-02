using System.Reflection;
using FukjBizSystem.Application.DataAccess.HoshoTorokuTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.BusinessLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLInput : ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAInput
    {
        
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoShinseiShosaiByKensakikanNendoRenbanBLInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoShinseiShosaiByKensakikanNendoRenbanBLInput : IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLInput
    {
        /// <summary>
        /// 保証登録検査機関
        /// </summary>
        public string HoshoTorokuKensakikan { get; set; }

        /// <summary>
        /// 保証登録年度
        /// </summary>
        public string HoshoTorokuNendo { get; set; }

        /// <summary>
        /// 保証登録連番
        /// </summary>
        public string HoshoTorokuRenban { get; set; }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput : ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput
    {
        
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput : IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput
    {
        /// <summary>
        /// HoshoShinseiShosaiDataTable
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoShinseiShosaiDataTable HoshoShinseiShosaiDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetHoshoShinseiShosaiByKensakikanNendoRenbanBusinessLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/17　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetHoshoShinseiShosaiByKensakikanNendoRenbanBusinessLogic : BaseBusinessLogic<IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLInput, IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput>
    {
        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetHoshoShinseiShosaiByKensakikanNendoRenbanBusinessLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetHoshoShinseiShosaiByKensakikanNendoRenbanBusinessLogic()
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
        /// 2014/07/17　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput Execute(IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput output = new GetHoshoShinseiShosaiByKensakikanNendoRenbanBLOutput();

            try
            {
                ISelectHoshoShinseiShosaiByKensakikanNendoRenbanDAOutput daOutput = new SelectHoshoShinseiShosaiByKensakikanNendoRenbanDataAccess().Execute(input);
                output.HoshoShinseiShosaiDataTable = daOutput.HoshoShinseiShosaiDataTable;
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
