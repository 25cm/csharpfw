using System;
using System.IO;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.FileKanriList;
using FukjBizSystem.Application.Utility;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.FileKanriList
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
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALInput : IBseALInput, IDeleteFileKanriTblByKeyBLInput
    {
        /// <summary>
        /// FileServerDirectory
        /// </summary>
        string FileServerDirectory { get; set; }
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
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALInput : IDeleteBtnClickALInput
    {
        /// <summary>
        /// ファイル区分
        /// </summary>
        public string FileKbn { get; set; }

        /// <summary>
        /// ファイルNo
        /// </summary>
        public string FileNo { get; set; }

        /// <summary>
        /// FileServerDirectory
        /// </summary>
        public string FileServerDirectory { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("ファイル区分[{0}], ファイルNo[{1}], FileServerDirectory[{3}]", 
                    new string[] { 
                        FileKbn, 
                        FileNo,
                        FileServerDirectory
                    });
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
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IDeleteBtnClickALOutput : IDeleteFileKanriTblByKeyBLOutput
    {
        /// <summary>
        /// Error message
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
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickALOutput : IDeleteBtnClickALOutput
    {
        /// <summary>
        /// Error message
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
    /// 2014/08/08  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class DeleteBtnClickApplicationLogic : BaseApplicationLogic<IDeleteBtnClickALInput, IDeleteBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "FileKanriList：DeleteBtnClickApplicationLogic";

        /// <summary>
        /// Error Msg
        /// </summary>
        private const string ERR_MSG = "ファイルの削除に失敗しました。\r\nシステム管理者に連絡してください。";

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
        /// 2014/08/08  DatNT　  新規作成
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
        /// 2014/08/08  DatNT　  新規作成
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
        /// 2014/08/08  DatNT　  新規作成
        /// 2014/11/05  DatNT   v1.02
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IDeleteBtnClickALOutput Execute(IDeleteBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IDeleteBtnClickALOutput output = new DeleteBtnClickALOutput();

            try
            {
                StartTransaction();

                // 2014/11/05 DatNT v1.02 MOD Start
                //IGetFileKanriTblByKeyBLInput blInput    = new GetFileKanriTblByKeyBLInput();
                //blInput.FileKbn                         = input.FileKbn;
                //blInput.FileNo                          = input.FileNo;
                //IGetFileKanriTblByKeyBLOutput blOutput  = new GetFileKanriTblByKeyBusinessLogic().Execute(blInput);

                //if (blOutput.FileKanriTblDT != null && blOutput.FileKanriTblDT.Count > 0)
                //{
                //    string filePath = input.FileServerDirectory + blOutput.FileKanriTblDT[0].FileNm;

                //    if (File.Exists(filePath))
                //    {
                //        new DeleteFileKanriTblByKeyBusinessLogic().Execute(input);

                //        // delete file
                //        File.Delete(filePath);
                //    }
                //    else
                //    {
                //        output.ErrMessage = "ファイルの削除に失敗しました。\r\nシステム管理者に連絡してください。";
                //    }
                //}
                //else
                //{
                //    output.ErrMessage = "ファイルの削除に失敗しました。\r\nシステム管理者に連絡してください。";
                //}

                try
                {
                    // 共有フォルダに接続
                    if (!SharedFolderUtility.Connect())
                    {
                        output.ErrMessage = ERR_MSG;
                        return output;
                    }
                    
                    IGetFileKanriTblByKeyBLInput blInput = new GetFileKanriTblByKeyBLInput();
                    blInput.FileKbn = input.FileKbn;
                    blInput.FileNo = input.FileNo;
                    IGetFileKanriTblByKeyBLOutput blOutput = new GetFileKanriTblByKeyBusinessLogic().Execute(blInput);

                    if (blOutput.FileKanriTblDT != null && blOutput.FileKanriTblDT.Count > 0)
                    {
                        string filePath = input.FileServerDirectory + blOutput.FileKanriTblDT[0].FileNm;

                        if (File.Exists(filePath))
                        {
                            new DeleteFileKanriTblByKeyBusinessLogic().Execute(input);

                            // delete file
                            File.Delete(filePath);
                        }
                        else
                        {
                            output.ErrMessage = ERR_MSG;
                        }
                    }
                    else
                    {
                        output.ErrMessage = ERR_MSG;
                    }
                }
                catch (Exception)
                {
                    output.ErrMessage = ERR_MSG;
                }
                finally
                {
                    // 共有フォルダから切断
                    SharedFolderUtility.Disconnect();
                }
                // 2014/11/05 DatNT v1.02 MOD End

                CompleteTransaction();
            }
            catch
            {
                if (string.IsNullOrEmpty(output.ErrMessage))
                {
                    output.ErrMessage = ERR_MSG;
                }
            }
            finally
            {
                EndTransaction();

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
