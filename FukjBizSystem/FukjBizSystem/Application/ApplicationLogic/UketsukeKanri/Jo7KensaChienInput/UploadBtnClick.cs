// 2014/11/13 DatNT DEL
//using System;
//using System.Net;
//using System.Reflection;
//using FukjBizSystem.Application.BusinessLogic.UketsukeKanri.Jo7KensaChienInput;
//using FukjBizSystem.Application.DataSet;
//using Zynas.Framework.Core.Base.ApplicationLogic;
//using Zynas.Framework.Utility;

//namespace FukjBizSystem.Application.ApplicationLogic.UketsukeKanri.Jo7KensaChienInput
//{
//    #region 入力インターフェイス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  インターフェイス名 ： IUploadBtnClickALInput
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/09/17  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    interface IUploadBtnClickALInput : IBseALInput, IUpdateKensaIraiKanrenFileTblBLInput
//    {
        
//    }
//    #endregion

//    #region 入力クラス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  クラス名 ： UploadBtnClickALInput
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/09/17  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    class UploadBtnClickALInput : IUploadBtnClickALInput
//    {
//        /// <summary>
//        /// KensaIraiKanrenFileTblDataTable
//        /// </summary>
//        public KensaIraiKanrenFileTblDataSet.KensaIraiKanrenFileTblDataTable KensaIraiKanrenFileTblDT { get; set; }

//        /// <summary>
//        /// ログ出力用データ文字列取得
//        /// </summary>
//        public string DataString
//        {
//            get
//            {
//                return string.Format("KensaIraiKanrenFileTblDT[{0}]",
//                    new string[] {
//                        KensaIraiKanrenFileTblDT[0].KensaIraiHoteiKbn + "-" + KensaIraiKanrenFileTblDT[0].KensaIraiHokenjoCd + "-" + KensaIraiKanrenFileTblDT[0].KensaIraiNendo + "-" + KensaIraiKanrenFileTblDT[0].KensaIraiRenban + "-" + KensaIraiKanrenFileTblDT[0].KensaIraiFileShubetsuCd
//                    });
//            }
//        }
//    }
//    #endregion

//    #region 出力インターフェイス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  インターフェイス名 ： IUploadBtnClickALOutput
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/09/17  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    interface IUploadBtnClickALOutput
//    {
        
//    }
//    #endregion

//    #region 出力クラス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  クラス名 ： UploadBtnClickALOutput
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/09/17  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    class UploadBtnClickALOutput : IUploadBtnClickALOutput
//    {
        
//    }
//    #endregion

//    #region クラス定義
//    ////////////////////////////////////////////////////////////////////////////
//    //  クラス名 ： UploadBtnClickApplicationLogic
//    /// <summary>
//    /// 
//    /// </summary>
//    /// <remarks>
//    /// 
//    /// </remarks>
//    /// <history>
//    /// 日付　　　　担当者　　　内容
//    /// 2014/09/17  DatNT　  新規作成
//    /// </history>
//    ////////////////////////////////////////////////////////////////////////////
//    class UploadBtnClickApplicationLogic : BaseApplicationLogic<IUploadBtnClickALInput, IUploadBtnClickALOutput>
//    {
//        #region 定義

//        public enum OperationErr
//        {
//            RakkanLock,     // 楽観ロックエラー
//        }

//        #endregion

//        #region プロパティ

//        /// <summary>
//        /// 機能名
//        /// </summary>
//        private const string FunctionName = "Jo7KensaChienInput：UploadBtnClickApplicationLogic";

//        #endregion

//        #region コンストラクタ
//        ////////////////////////////////////////////////////////////////////////////
//        //  コンストラクタ名 ： UploadBtnClickApplicationLogic
//        /// <summary>
//        /// 
//        /// </summary>
//        /// <remarks>
//        /// 
//        /// </remarks>
//        /// <history>
//        /// 日付　　　　担当者　　　内容
//        /// 2014/09/17  DatNT　  新規作成
//        /// </history>
//        ////////////////////////////////////////////////////////////////////////////
//        public UploadBtnClickApplicationLogic()
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
//        /// 2014/09/17  DatNT　  新規作成
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
//        /// 2014/09/17  DatNT　  新規作成
//        /// </history>
//        ////////////////////////////////////////////////////////////////////////////
//        public override IUploadBtnClickALOutput Execute(IUploadBtnClickALInput input)
//        {
//            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

//            // 出力クラスの実体作成
//            IUploadBtnClickALOutput output = new UploadBtnClickALOutput();

//            try
//            {
//                StartTransaction();

//                IGetKensaIraiKanrenFileTblByKeyBLInput getByKeyInput = new GetKensaIraiKanrenFileTblByKeyBLInput();
//                getByKeyInput.KensaIraiHoteiKbn         = input.KensaIraiKanrenFileTblDT[0].KensaIraiHoteiKbn;
//                getByKeyInput.KensaIraiHokenjoCd        = input.KensaIraiKanrenFileTblDT[0].KensaIraiHokenjoCd;
//                getByKeyInput.KensaIraiNendo            = input.KensaIraiKanrenFileTblDT[0].KensaIraiNendo;
//                getByKeyInput.KensaIraiRenban           = input.KensaIraiKanrenFileTblDT[0].KensaIraiRenban;
//                getByKeyInput.KensaIraiFileShubetsuCd   = input.KensaIraiKanrenFileTblDT[0].KensaIraiFileShubetsuCd;
//                IGetKensaIraiKanrenFileTblByKeyBLOutput getByKeyOutput = new GetKensaIraiKanrenFileTblByKeyBusinessLogic().Execute(getByKeyInput);
                
//                DateTime now = Boundary.Common.Common.GetCurrentTimestamp();

//                // 関連ファイルパス
//                getByKeyOutput.KensaIraiKanrenFileTblDT[0].KensaIraiKanrenFilePath = input.KensaIraiKanrenFileTblDT[0].KensaIraiKanrenFilePath;

//                // 更新日
//                getByKeyOutput.KensaIraiKanrenFileTblDT[0].UpdateDt = now;

//                // 更新端末
//                getByKeyOutput.KensaIraiKanrenFileTblDT[0].UpdateTarm = input.KensaIraiKanrenFileTblDT[0].UpdateTarm;

//                // 更新者
//                getByKeyOutput.KensaIraiKanrenFileTblDT[0].UpdateUser = input.KensaIraiKanrenFileTblDT[0].UpdateUser;

//                IUpdateKensaIraiKanrenFileTblBLInput blInput = new UpdateKensaIraiKanrenFileTblBLInput();
//                blInput.KensaIraiKanrenFileTblDT = getByKeyOutput.KensaIraiKanrenFileTblDT;
//                IUpdateKensaIraiKanrenFileTblBLOutput blOutput = new UpdateKensaIraiKanrenFileTblBusinessLogic().Execute(blInput);

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
