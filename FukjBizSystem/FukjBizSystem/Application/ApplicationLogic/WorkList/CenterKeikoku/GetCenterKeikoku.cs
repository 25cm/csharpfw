using System;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.WorkList.CenterKeikoku;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.WorkList.CenterKeikoku
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetCenterKeikokuALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetCenterKeikokuALInput : IBseALInput, IGetCenterKeikokuBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetCenterKeikokuALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetCenterKeikokuALInput : IGetCenterKeikokuALInput
    {
        /// <summary>
        /// ShishoCd 
        /// </summary>
        public string ShishoCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return String.Empty;
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetCenterKeikokuALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetCenterKeikokuALOutput : IGetCenterKeikokuBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetCenterKeikokuALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetCenterKeikokuALOutput : IGetCenterKeikokuALOutput
    {
        /// <summary>
        /// CenterKeikokuListDataTable 
        /// </summary>
        public CenterKeikokuDataSet.CenterKeikokuListDataTable CenterKeikokuListDataTable { get; set; }

        /// <summary>
        /// Miwariate11JoListDataTable
        /// </summary>
        public CenterKeikokuDataSet.Miwariate11JoListDataTable Miwariate11JoListDataTable { get; set; }

        /// <summary>
        /// Miwariate7JoListDataTable
        /// </summary>
        public CenterKeikokuDataSet.Miwariate7JoListDataTable Miwariate7JoListDataTable { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetCenterKeikokuApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/23  豊田  　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetCenterKeikokuApplicationLogic : BaseApplicationLogic<IGetCenterKeikokuALInput, IGetCenterKeikokuALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "CenterKeikoku：GetCenterKeikoku";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetCenterKeikokuApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/23  豊田  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetCenterKeikokuApplicationLogic()
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
        /// 2014/12/23  豊田  　    新規作成
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
        /// 2014/12/23  豊田  　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetCenterKeikokuALOutput Execute(IGetCenterKeikokuALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetCenterKeikokuALOutput output = new GetCenterKeikokuALOutput();

            try
            {
                // 検索実行
                IGetCenterKeikokuBLOutput blOutput = new GetCenterKeikokuBusinessLogic().Execute(input);

                output.CenterKeikokuListDataTable = blOutput.CenterKeikokuListDataTable;
                output.Miwariate11JoListDataTable = blOutput.Miwariate11JoListDataTable;
                output.Miwariate7JoListDataTable = blOutput.Miwariate7JoListDataTable;
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
