using System;
using System.Reflection;
using System.Text;
using FukjBizSystem.Application.BusinessLogic.Master.GyoshaMstShosai;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Master.GyoshaMstShosai
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 業者コード
        /// </summary>
        string GyoshaCd { get; set; }
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALInput : IDeleteBtnClickALInput
    {
        /// <summary>
        /// 業者コード
        /// </summary>
        public string GyoshaCd { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("業者コード[{0}]", GyoshaCd);
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALOutput
    {
        /// <summary>
        /// Error message
        /// </summary>
        string ErrMsg { get; set; }
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string ErrMsg { get; set; }
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
    /// 2014/07/02　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "GyoshaMstShosai：DeleteBtnClick";

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
        /// 2014/07/02　AnhNV　　    新規作成
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
        /// 2014/07/02　AnhNV　　    新規作成
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
        /// 2014/07/02　AnhNV　　    新規作成
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

                // UPD 20140728 START ZynasSou 
                // 業者営業マスタ＆業者営業地区マスタは必須登録のマスタではないので、未登録なら削除対象外
                //string errMsg = GyoshaMstDeleteCheck(input.GyoshaCd) + Environment.NewLine
                //    + GyoshaEigyoshoMstDeleteCheck(input.GyoshaCd) + Environment.NewLine
                //    + GyoshaEigyoChikuMstDeleteCheck(input.GyoshaCd) + Environment.NewLine
                //    + GyoshaBukaiMstDeleteCheck(input.GyoshaCd);
                string gyoshaMstMsg = GyoshaMstDeleteCheck(input.GyoshaCd);
                string gyoshaEigyoshoMstMsg = GyoshaEigyoshoMstDeleteCheck(input.GyoshaCd);
                string gyoshaEigyoChikuMstMsg = GyoshaEigyoChikuMstDeleteCheck(input.GyoshaCd);
                string gyoshaBukaiMstMsg = GyoshaBukaiMstDeleteCheck(input.GyoshaCd);

                //string errMsg = gyoshaMstMsg + Environment.NewLine + gyoshaBukaiMstMsg;
                StringBuilder errMsg = new StringBuilder();
                if (!string.IsNullOrEmpty(gyoshaMstMsg))            { errMsg.AppendLine(gyoshaMstMsg);         }
                if (!string.IsNullOrEmpty(gyoshaEigyoshoMstMsg))    { errMsg.AppendLine(gyoshaEigyoshoMstMsg);      }
                if (!string.IsNullOrEmpty(gyoshaEigyoChikuMstMsg))  { errMsg.AppendLine(gyoshaEigyoChikuMstMsg);    }
                if (!string.IsNullOrEmpty(gyoshaBukaiMstMsg))       { errMsg.AppendLine(gyoshaBukaiMstMsg);         }

                // UPD 20140728 END ZynasSou 

                if (!string.IsNullOrEmpty(errMsg.ToString()))
                {
                    output.ErrMsg = errMsg.ToString();
                    return output;
                }

                // Delete gyoshaMst
                IDeleteGyoshaMstByKeyBLInput gyoshaInp = new DeleteGyoshaMstByKeyBLInput();
                gyoshaInp.GyoshaCd = input.GyoshaCd;
                new DeleteGyoshaMstByKeyBusinessLogic().Execute(gyoshaInp);

                // ADD 20140728 START ZynasSou 
                if (string.IsNullOrEmpty(gyoshaEigyoshoMstMsg))
                {
                // ADD 20140728 END ZynasSou 
                    // Delete GyoshaEigyoshoMst
                    IDeleteGyoshaEigyoshoMstByGyoshaCdBLInput eiInp = new DeleteGyoshaEigyoshoMstByGyoshaCdBLInput();
                    eiInp.GyoshaCd = input.GyoshaCd;
                    new DeleteGyoshaEigyoshoMstByGyoshaCdBusinessLogic().Execute(eiInp);
                // ADD 20140728 START ZynasSou 
                }
                // ADD 20140728 END ZynasSou 

                // ADD 20140728 START ZynasSou 
                if (string.IsNullOrEmpty(gyoshaEigyoChikuMstMsg))
                {
                // ADD 20140728 END ZynasSou 
                    // Delete GyoshaEigyoChikuMst
                    IDeleteGyoshaEigyoChikuMstByGyoshaCdBLInput chikuInp = new DeleteGyoshaEigyoChikuMstByGyoshaCdBLInput();
                    chikuInp.GyoshaCd = input.GyoshaCd;
                    new DeleteGyoshaEigyoChikuMstByGyoshaCdBusinessLogic().Execute(chikuInp);
                // ADD 20140728 START ZynasSou
                }
                // ADD 20140728 END ZynasSou 

                // Delete GyoshaBukaiMst
                IDeleteGyoshaBukaiMstByGyoshaCdBLInput bukaiInp = new DeleteGyoshaBukaiMstByGyoshaCdBLInput();
                bukaiInp.GyoshaCd = input.GyoshaCd;
                new DeleteGyoshaBukaiMstByGyoshaCdBusinessLogic().Execute(bukaiInp);

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

        #region GyoshaMstDeleteCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaMstDeleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GyoshaMstDeleteCheck(string gyoshaCd)
        {
            // Get GyoshaMst by key
            IGetGyoshaMstByKeyBLInput keyInp = new GetGyoshaMstByKeyBLInput();
            keyInp.GyoshaCd = gyoshaCd;
            IGetGyoshaMstByKeyBLOutput keyOutp = new GetGyoshaMstByKeyBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.GyoshaMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[業者マスタ][業者コード：{0}]", gyoshaCd);
            }

            return string.Empty;
        }
        #endregion

        #region GyoshaEigyoshoMstDeleteCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaEigyoshoMstDeleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GyoshaEigyoshoMstDeleteCheck(string gyoshaCd)
        {
            // Get GyoshaMst by key
            IGetGyoshaEigyoshoMstByGyoshaCdBLInput keyInp = new GetGyoshaEigyoshoMstByGyoshaCdBLInput();
            keyInp.GyoshaCd = gyoshaCd;
            IGetGyoshaEigyoshoMstByGyoshaCdBLOutput keyOutp = new GetGyoshaEigyoshoMstByGyoshaCdBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.GyoshaEigyoshoMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[業者営業所マスタ][業者コード：{0}]", gyoshaCd);
            }

            return string.Empty;
        }
        #endregion

        #region GyoshaEigyoChikuMstDeleteCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaEigyoChikuMstDeleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GyoshaEigyoChikuMstDeleteCheck(string gyoshaCd)
        {
            // Get GyoshaMst by key
            IGetGyoshaEigyoChikuMstByGyoshaCdBLInput keyInp = new GetGyoshaEigyoChikuMstByGyoshaCdBLInput();
            keyInp.GyoshaCd = gyoshaCd;
            IGetGyoshaEigyoChikuMstByGyoshaCdBLOutput keyOutp = new GetGyoshaEigyoChikuMstByGyoshaCdBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.GyoshaEigyoChikuMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[業者営業地区マスタ][業者コード：{0}]", gyoshaCd);
            }

            return string.Empty;
        }
        #endregion

        #region GyoshaBukaiMstDeleteCheck
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GyoshaBukaiMstDeleteCheck
        /// <summary>
        /// 
        /// </summary>
        /// <param name="gyoshaCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/06/24  AnhNV　　    新規作成
        /// 2014/10/20　AnhNV　　    基本設計書_001_018_画面_GyoshaMstShosai_V1.05
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private string GyoshaBukaiMstDeleteCheck(string gyoshaCd)
        {
            // Get GyoshaMst by key
            IGetGyoshaBukaiMstByGyoshaCdBLInput keyInp = new GetGyoshaBukaiMstByGyoshaCdBLInput();
            keyInp.GyoshaCd = gyoshaCd;
            IGetGyoshaBukaiMstByGyoshaCdBLOutput keyOutp = new GetGyoshaBukaiMstByGyoshaCdBusinessLogic().Execute(keyInp);

            // Key does not exist
            if (keyOutp.GyoshaBukaiMstDataTable.Count == 0)
            {
                return string.Format("該当するデータは登録されていません。[業者部会マスタ][業者コード：{0}]", gyoshaCd);
            }

            return string.Empty;
        }
        #endregion

        #endregion
    }
    #endregion
}
