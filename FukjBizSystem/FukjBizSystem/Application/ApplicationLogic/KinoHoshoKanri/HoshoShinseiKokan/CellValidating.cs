using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.KinoHoshoKanri.HoshoShinseiKokan;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.KinoHoshoKanri.HoshoShinseiKokan
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICellValidatingALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICellValidatingALInput : IBseALInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CellValidatingALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CellValidatingALInput : ICellValidatingALInput
    {
        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： ICellValidatingALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface ICellValidatingALOutput
    {
        /// <summary>
        /// HoshoTorokuShinseiKokanInfoDataTable
        /// </summary>
        HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable HoshoTorokuShinseiKokanInfoDataTable { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CellValidatingALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CellValidatingALOutput : ICellValidatingALOutput
    {
        /// <summary>
        /// HoshoTorokuShinseiKokanInfoDataTable
        /// </summary>
        public HoshoTorokuTblDataSet.HoshoTorokuShinseiKokanInfoDataTable HoshoTorokuShinseiKokanInfoDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： CellValidatingApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/30  HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class CellValidatingApplicationLogic : BaseApplicationLogic<ICellValidatingALInput, ICellValidatingALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "HoshoShinseiKokan：CellValidating";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： CellValidatingApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public CellValidatingApplicationLogic()
        {
        }
        #endregion

        #region メソッド(protected)

        #region GetFunctionName
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetFunctionName
        /// <summary>
        /// 機能名取得
        /// </summary>
        /// <returns>機能名</returns>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/30  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        protected override string GetFunctionName()
        {
            return FunctionName;
        }
        #endregion

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
        /// 2014/09/30  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override ICellValidatingALOutput Execute(ICellValidatingALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            ICellValidatingALOutput output = new CellValidatingALOutput();

            try
            {
                IGetHoshoShinseiKokanInfoBLInput getHoshoShinseiKokanBLInput = new GetHoshoShinseiKokanInfoBLInput();
                output.HoshoTorokuShinseiKokanInfoDataTable = new GetHoshoShinseiKokanInfoBusinessLogic().Execute(getHoshoShinseiKokanBLInput).HoshoTorokuShinseiKokanInfoDataTable;

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
