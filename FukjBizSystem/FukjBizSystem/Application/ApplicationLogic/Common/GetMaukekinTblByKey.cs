using System.Reflection;
using FukjBizSystem.Application.DataAccess.MaeukekinTbl;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Common
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMaukekinTblByKeyALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/31  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMaukekinTblByKeyALInput : IBseALInput
    {
        /// <summary>
        /// 前受照合番号１
        /// </summary>
        string MaeukekinSyogoNo1 { get; set; }

        /// <summary>
        /// 前受照合番号２
        /// </summary>
        string MaeukekinSyogoNo2 { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaukekinTblByKeyALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/31  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMaukekinTblByKeyALInput : IGetMaukekinTblByKeyALInput
    {
        /// <summary>
        /// 前受照合番号１
        /// </summary>
        public string MaeukekinSyogoNo1 { get; set; }

        /// <summary>
        /// 前受照合番号２
        /// </summary>
        public string MaeukekinSyogoNo2 { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("MaeukekinSyogoNo1[{0}], MaeukekinSyogoNo2[{1}]", new string[] { MaeukekinSyogoNo1, MaeukekinSyogoNo2 });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGetMaukekinTblByKeyALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/31  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGetMaukekinTblByKeyALOutput
    {
        /// <summary>
        /// 前受金情報
        /// </summary>
        MaeukekinTblDataSet.MaeukekinTblDataTable MaeukekinTblDT { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaukekinTblByKeyALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/31  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMaukekinTblByKeyALOutput : IGetMaukekinTblByKeyALOutput
    {
        /// <summary>
        /// 前受金情報
        /// </summary>
        public MaeukekinTblDataSet.MaeukekinTblDataTable MaeukekinTblDT { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GetMaukekinTblByKeyApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2015/01/31  小松　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GetMaukekinTblByKeyApplicationLogic : BaseApplicationLogic<IGetMaukekinTblByKeyALInput, IGetMaukekinTblByKeyALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "共通処理機能：前受金情報取得（主キー）";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GetMaukekinTblByKeyApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2015/01/31  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GetMaukekinTblByKeyApplicationLogic()
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
        /// 2015/01/31  小松　　    新規作成
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
        /// 2015/01/31  小松　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGetMaukekinTblByKeyALOutput Execute(IGetMaukekinTblByKeyALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGetMaukekinTblByKeyALOutput output = new GetMaukekinTblByKeyALOutput();

            try
            {
                ISelectMaeukekinTblByKeyDAInput selIn = new SelectMaeukekinTblByKeyDAInput();
                selIn.MaeukekinSyogoNo1 = input.MaeukekinSyogoNo1;
                selIn.MaeukekinSyogoNo2 = input.MaeukekinSyogoNo2;
                ISelectMaeukekinTblByKeyDAOutput selOut = new SelectMaeukekinTblByKeyDataAccess().Execute(selIn);
                output.MaeukekinTblDT = selOut.MaeukekinTblDT;
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
