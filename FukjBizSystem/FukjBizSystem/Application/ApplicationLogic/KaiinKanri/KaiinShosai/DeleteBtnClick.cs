// 2014/11/13 DatNT DEL
//using System.Reflection;
//using FukjBizSystem.Application.BusinessLogic.Master.GyoshaMstShosai;
//using Zynas.Framework.Core.Base.ApplicationLogic;
//using Zynas.Framework.Utility;

//namespace FukjBizSystem.Application.ApplicationLogic.KaiinKanri.KaiinShosai
//{
//    #region 入力インターフェイス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  インターフェイス名 ： IDeleteBtnClickALInput
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/07/25  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    interface IDeleteBtnClickALInput : IBseALInput, IDeleteGyoshaBukaiMstByGyoshaCdBLInput
//    {
        
//    }
//    #endregion

//    #region 入力クラス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  クラス名 ： DeleteBtnClickALInput
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/07/25  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    class DeleteBtnClickALInput : IDeleteBtnClickALInput
//    {
//        /// <summary>
//        /// 業者コード
//        /// </summary>
//        public string GyoshaCd { get; set; }

//        /// <summary>
//        /// ログ出力用データ文字列取得
//        /// </summary>
//        public string DataString
//        {
//            get
//            {
//                return string.Format("業者コード[{0}]", new string[] { GyoshaCd });
//            }
//        }
//    }
//    #endregion

//    #region 出力インターフェイス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  インターフェイス名 ： IDeleteBtnClickALOutput
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/07/25  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    interface IDeleteBtnClickALOutput : IDeleteGyoshaBukaiMstByGyoshaCdBLOutput
//    {
//        /// <summary>
//        /// Result
//        /// </summary>
//        bool Result { get; set; }
//    }
//    #endregion

//    #region 出力クラス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  クラス名 ： DeleteBtnClickALOutput
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/07/25  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
//    {
//        /// <summary>
//        /// Result
//        /// </summary>
//        public bool Result { get; set; }
//    }
//    #endregion

//    #region クラス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  クラス名 ： DeleteBtnClickApplicationLogic
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/07/25  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
//    {
//        #region プロパティ

//        /// <summary>
//        /// 機能名
//        /// </summary>
//        private const string FunctionName = "KaiinShosai：DeleteBtnClickApplicationLogic";

//        #endregion

//        #region コンストラクタ
//        ////////////////////////////////////////////////////////////////////////////
//        //  コンストラクタ名 ： DeleteBtnClickApplicationLogic
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <remarks>
//        /// 
//        /// </remarks>
//        /// <history>
//        /// 日付　　　　担当者　　　内容
//        /// 2014/07/25  DatNT　  新規作成
//        /// </history>
//        ////////////////////////////////////////////////////////////////////////////
//        public DeleteBtnClickApplicationLogic()
//        {
            
//        }
//        #endregion

//        #region メソッド(protected)

//        #region GetFunctionName
//        ////////////////////////////////////////////////////////////////////////////
//        //  メソッド名 ： GetFunctionName
//        /// <summary>
//        /// 機能名取得
//        /// </summary>
//        /// <returns>機能名</returns>
//        /// <history>
//        /// 日付　　　　担当者　　　内容
//        /// 2014/07/25  DatNT　  新規作成
//        /// </history>
//        ////////////////////////////////////////////////////////////////////////////
//        protected override string GetFunctionName()
//        {
//            return FunctionName;
//        }
//        #endregion

//        #endregion

//        #region メソッド(public)

//        #region Execute
//        ////////////////////////////////////////////////////////////////////////////
//        //  メソッド名 ： Execute
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <param name="input"></param>
//        /// <returns></returns>
//        /// <history>
//        /// 日付　　　　担当者　　　内容
//        /// 2014/07/25  DatNT　  新規作成
//        /// </history>
//        ////////////////////////////////////////////////////////////////////////////
//        public override IDeleteBtnClickALOutput Execute(IDeleteBtnClickALInput input)
//        {
//            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

//            // 出力クラスの実体作成
//            IDeleteBtnClickALOutput output = new DeleteBtnClickALOutput();

//            try
//            {
//                StartTransaction();

//                IGetGyoshaBukaiMstByGyoshaCdBLInput blInput = new GetGyoshaBukaiMstByGyoshaCdBLInput();
//                blInput.GyoshaCd = input.GyoshaCd;
//                IGetGyoshaBukaiMstByGyoshaCdBLOutput blOutput = new GetGyoshaBukaiMstByGyoshaCdBusinessLogic().Execute(blInput);

//                if (blOutput.GyoshaBukaiMstDataTable != null && blOutput.GyoshaBukaiMstDataTable.Count > 0)
//                {
//                    new DeleteGyoshaBukaiMstByGyoshaCdBusinessLogic().Execute(input);

//                    output.Result = true;
//                }
//                else
//                {
//                    output.Result = false;

//                    return output;
//                }

//                CompleteTransaction();
//            }
//            catch
//            {
//                throw;
//            }
//            finally
//            {
//                EndTransaction();

//                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
//            }

//            return output;
//        }
//        #endregion

//        #endregion
//    }
//    #endregion
//}
