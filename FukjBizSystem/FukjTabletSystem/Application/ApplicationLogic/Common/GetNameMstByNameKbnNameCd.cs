using System.Reflection;
using FukjTabletSystem.Application.BusinessLogic.Common;
using FukjTabletSystem.Application.DataSet.SQLCE;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjTabletSystem.Application.ApplicationLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNameMstByNameKbnNameCdALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNameMstByNameKbnNameCdALInput : IBseALInput, IGetNameMstByNameKbnNameCdBLInput
    {
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNameMstByNameKbnNameCdALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNameMstByNameKbnNameCdALInput : IGetNameMstByNameKbnNameCdALInput
    {
        /// <summary>
        /// 名称区分
        /// </summary>
        public string NameKbn { get; set; }

        /// <summary>
        /// 名称コード
        /// </summary>
        public string NameCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("NameKbn:{0} NameCd:{1}", NameKbn, NameCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetNameMstByNameKbnNameCdALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetNameMstByNameKbnNameCdALOutput : IGetNameMstByNameKbnNameCdBLOutput
    {
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNameMstByNameKbnNameCdALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNameMstByNameKbnNameCdALOutput : IGetNameMstByNameKbnNameCdALOutput
    {
        /// <summary>
        /// NameMst
        /// </summary>
        public NameMstDataSet.NameMstDataTable NameMst { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetNameMstByNameKbnNameCdApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/04　豊田　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetNameMstByNameKbnNameCdApplicationLogic : BaseApplicationLogic<IGetNameMstByNameKbnNameCdALInput, IGetNameMstByNameKbnNameCdALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "Common：GetNameMstByNameKbnNameCd";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetNameMstByNameKbnNameCdApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/04　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetNameMstByNameKbnNameCdApplicationLogic()
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
        /// 2014/11/04　豊田　　    新規作成
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
        /// 2014/11/04　豊田　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetNameMstByNameKbnNameCdALOutput Execute(IGetNameMstByNameKbnNameCdALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetNameMstByNameKbnNameCdALOutput output = new GetNameMstByNameKbnNameCdALOutput();

            try
            {
                // レイヤーオブジェクトの取得
                IGetNameMstByNameKbnNameCdBLOutput blOutput = new GetNameMstByNameKbnNameCdBusinessLogic().Execute(input);

                output.NameMst = blOutput.NameMst;
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
