using System.IO;
using System.Net;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.FileKanriList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.FileKanriList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IChangeBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IChangeBtnClickALInput : IBseALInput, IUpdateFileKanriTblBLInput
    {
        /// <summary>
        /// File Name Old
        /// </summary>
        string FileNameOld { get; set; }

        /// <summary>
        /// File Name Upload
        /// </summary>
        string FileNameUpload { get; set; }

        /// <summary>
        /// File Path Upload
        /// </summary>
        string FilePathUpload { get; set; }

        /// <summary>
        /// FileServerDirectory
        /// </summary>
        string FileServerDirectory { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ChangeBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ChangeBtnClickALInput : IChangeBtnClickALInput
    {
        /// <summary>
        /// FileKanriTblDataTable
        /// </summary>
        public FileKanriTblDataSet.FileKanriTblDataTable FileKanriTblDT { get; set; }

        /// <summary>
        /// File Name Old
        /// </summary>
        public string FileNameOld { get; set; }

        /// <summary>
        /// File Name Upload
        /// </summary>
        public string FileNameUpload { get; set; }

        /// <summary>
        /// File Path Upload
        /// </summary>
        public string FilePathUpload { get; set; }

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
                return string.Format("FileKanriTblDataTable[{0}], FileNameOld[{1}], FileNameUpload[{2}], FilePathUpload[{3}], FileServerDirectory[{4}]", 
                    new string[] { 
                        FileKanriTblDT[0].FileNo,
                        FileNameOld,
                        FileNameUpload,
                        FilePathUpload,
                        FileServerDirectory
                    } );
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IChangeBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IChangeBtnClickALOutput : IUpdateFileKanriTblBLOutput
    {
        /// <summary>
        /// Error message
        /// </summary>
        string ErrMessage { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ChangeBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ChangeBtnClickALOutput : IChangeBtnClickALOutput
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string ErrMessage { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： ChangeBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/11  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class ChangeBtnClickApplicationLogic : BaseApplicationLogic<IChangeBtnClickALInput, IChangeBtnClickALOutput>
    {
        #region 定義

        public enum OperationErr
        {
            RakkanLock,     // 楽観ロックエラー
        }

        #endregion

        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "FileKanriList：ChangeBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： ChangeBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public ChangeBtnClickApplicationLogic()
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
        /// 2014/08/11  DatNT　  新規作成
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
        /// 2014/08/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IChangeBtnClickALOutput Execute(IChangeBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IChangeBtnClickALOutput output = new ChangeBtnClickALOutput();

            string filePathOldBk = string.Empty;

            try
            {
                StartTransaction();
                
                string filePathOld = Path.Combine(input.FileServerDirectory, input.FileNameOld);

                filePathOldBk = Path.Combine(input.FileServerDirectory, "Bk_" + input.FileNameOld);

                // Rename old file to Bk_fileNm
                if (!File.Exists(filePathOld))
                {
                    output.ErrMessage = "ファイルの登録に失敗しました。\r\nシステム管理者に連絡してください。";
                }
                else
                {
                    //File.Copy(filePathOld, filePathOldBk, true);

                    // update
                    FileKanriTblDataSet.FileKanriTblDataTable updateDT = CreateDataUpdate(input);

                    if (updateDT != null && updateDT.Count > 0)
                    {
                        IUpdateFileKanriTblBLInput updateInput = new UpdateFileKanriTblBLInput();
                        updateInput.FileKanriTblDT = updateDT;
                        IUpdateFileKanriTblBLOutput updateOutput = new UpdateFileKanriTblBusinessLogic().Execute(updateInput);

                        // copy new file to file server
                        // file copy
                        string sourceFile = input.FilePathUpload;

                        // file paste
                        string destFile = updateInput.FileKanriTblDT[0].FilePath;

                        // copy
                        File.Copy(sourceFile, destFile, true);

                        // delete old file
                        File.Delete(filePathOld);
                    }
                    else
                    {
                        output.ErrMessage = "ファイルの登録に失敗しました。\r\nシステム管理者に連絡してください。";
                    }
                }                

                CompleteTransaction();
            }
            catch
            {
                if (string.IsNullOrEmpty(output.ErrMessage))
                {
                    output.ErrMessage = "ファイルの登録に失敗しました。\r\nシステム管理者に連絡してください。";
                }
            }
            finally
            {
                EndTransaction();

                //File.Delete(filePathOldBk);
                
                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion

        #region メソッド(private)

        #region CreateDataUpdate
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateDataUpdate
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <param name="input">AL入力情報</param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/11  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private FileKanriTblDataSet.FileKanriTblDataTable CreateDataUpdate(IChangeBtnClickALInput input)
        {
            FileKanriTblDataSet.FileKanriTblDataTable updateDT = new FileKanriTblDataSet.FileKanriTblDataTable();

            IGetFileKanriTblByKeyBLInput blInput    = new GetFileKanriTblByKeyBLInput();
            blInput.FileKbn                         = input.FileKanriTblDT[0].FileKbn;
            blInput.FileNo                          = input.FileKanriTblDT[0].FileNo;
            IGetFileKanriTblByKeyBLOutput blOutput  = new GetFileKanriTblByKeyBusinessLogic().Execute(blInput);

            if (blOutput.FileKanriTblDT == null || blOutput.FileKanriTblDT.Count == 0)
            {
                return null;
            }

            FileKanriTblDataSet.FileKanriTblRow row = blOutput.FileKanriTblDT[0];

            // 更新日が違うか？
            if (row.UpdateDt != input.FileKanriTblDT[0].UpdateDt)
            {
                throw new CustomException((int)ResultCode.LockError, (int)OperationErr.RakkanLock, string.Empty);
            }

            // ファイル名 
            row.FileNm = input.FileKanriTblDT[0].FileNm;

            // ファイルパス 
            row.FilePath = input.FileKanriTblDT[0].FilePath;

            // 元ファイル名
            row.FileNmBefore = input.FileKanriTblDT[0].FileNmBefore;
            
            // 更新日
            row.UpdateDt = Boundary.Common.Common.GetCurrentTimestamp();

            // 更新者
            row.UpdateUser = Utility.ShokuinInfo.GetShokuinInfo().Shokuin.ShokuinNm;

            // 更新端末
            row.UpdateTarm = Dns.GetHostName();

            updateDT.ImportRow(row);

            return updateDT;
        }
        #endregion

        #endregion
    }
    #endregion
}
