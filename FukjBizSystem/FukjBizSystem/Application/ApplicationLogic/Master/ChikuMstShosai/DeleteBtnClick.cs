using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.ChikuMstShosai;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.ChikuMstShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALInput : IBseALInput, IDeleteChikuMstByKeyBLInput
    {

    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALInput : IDeleteBtnClickALInput
    {
        /// <summary>
        /// ChikuMstCd
        /// </summary>
        public string ChikuMstCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("地区コード[{0}]", ChikuMstCd);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IDeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALOutput : IDeleteChikuMstByKeyBLOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        string ErrMessage { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
    {
        /// <summary>
        /// ErrMessage
        /// </summary>
        public string ErrMessage { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： DeleteBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/06/25　HuyTX　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "ChikuMstShosai：DeleteBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： DeleteBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public DeleteBtnClickApplicationLogic()
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
        /// 2014/06/25　HuyTX　　    新規作成
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
        /// 2014/06/25　HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteBtnClickALOutput Execute(IDeleteBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnClickALOutput output = new DeleteBtnClickALOutput();

            try
            {
                // トランザクション開始
                StartTransaction();

                //check ChikuCd not exist DB
                if (!string.IsNullOrEmpty(CheckExistChikuCd(input.ChikuMstCd)))
                {
                    output.ErrMessage = CheckExistChikuCd(input.ChikuMstCd);
                    return output;
                }

                //Delete
                IDeleteChikuMstByKeyBLInput blInput = new DeleteBtnClickALInput();
                blInput.ChikuMstCd = input.ChikuMstCd;
                new DeleteChikuMstByKeyBusinessLogic().Execute(blInput);

                // コミット
                CompleteTransaction();
            }
            catch
            {
                throw;
            }
            finally
            {
                // トランザクション終了
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CheckExistChikuCd
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CheckExistChikuCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="chikuCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/26  HuyTX　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string CheckExistChikuCd(string chikuCd)
        {
            IGetChikuMstByKeyBLInput blInput = new GetChikuMstByKeyBLInput();
            blInput.ChikuMstCd = chikuCd;

            IGetChikuMstByKeyBLOutput blOutput = new GetChikuMstByKeyBusinessLogic().Execute(blInput);
            if (blOutput.ChikuMstDT.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[地区コード：{0}]", chikuCd);
            }

            return string.Empty;
        }
        #endregion

        #endregion
    }
    #endregion
}
