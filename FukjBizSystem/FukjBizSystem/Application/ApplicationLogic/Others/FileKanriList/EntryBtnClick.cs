using System;
using System.IO;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Others.FileKanriList;
using FukjBizSystem.Application.DataSet;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.Others.FileKanriList
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IEntryBtnClickALInput
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
    interface IEntryBtnClickALInput : IBseALInput, IUpdateFileKanriTblBLInput
    {
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

        /// <summary>
        /// DateTime Today
        /// </summary>
        DateTime Today { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EntryBtnClickALInput
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
    class EntryBtnClickALInput : IEntryBtnClickALInput
    {
        /// <summary>
        /// FileKanriTblDataTable
        /// </summary>
        public FileKanriTblDataSet.FileKanriTblDataTable FileKanriTblDT { get; set; }

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
        /// DateTime Today
        /// </summary>
        public DateTime Today { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("FileKanriTblDataTable[{0}], FilePathUpload[{1}], FilePathUpload[{2}], FileServerDirectory[{3}], DateTimeToday[{4}]", 
                    new string[] { 
                        FileKanriTblDT[0].FileNo, 
                        FileNameUpload, 
                        FilePathUpload, 
                        FileServerDirectory,
                        Today.ToString("yyyyMMdd") 
                    });
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IEntryBtnClickALOutput
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
    interface IEntryBtnClickALOutput : IUpdateFileKanriTblBLOutput
    {
        /// <summary>
        /// Error message
        /// </summary>
        string ErrMessage { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EntryBtnClickALOutput
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
    class EntryBtnClickALOutput : IEntryBtnClickALOutput
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string ErrMessage { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： EntryBtnClickApplicationLogic
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
    class EntryBtnClickApplicationLogic : BaseApplicationLogic<IEntryBtnClickALInput, IEntryBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "FileKanriList：EntryBtnClickApplicationLogic";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： EntryBtnClickApplicationLogic
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
        public EntryBtnClickApplicationLogic()
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
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IEntryBtnClickALOutput Execute(IEntryBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IEntryBtnClickALOutput output = new EntryBtnClickALOutput();

            try
            {
                StartTransaction();

                #region Copy file to file server

                string fileName = input.FileNameUpload;

                // file copy
                string sourceFile = input.FilePathUpload;

                // file paste
                string destFile = Path.Combine(input.FileServerDirectory, fileName);

                // copy
                File.Copy(sourceFile, destFile, true);

                // Rename
                string newDestFile = input.FileKanriTblDT[0].FileNo + "_"  + fileName;

                File.Move(destFile, Path.Combine(input.FileServerDirectory, newDestFile));

                #endregion

                // Insert
                IGetFileKanriTblByKeyBLInput blInput    = new GetFileKanriTblByKeyBLInput();
                blInput.FileKbn                         = input.FileKanriTblDT[0].FileKbn;
                blInput.FileNo                          = input.FileKanriTblDT[0].FileNo;
                IGetFileKanriTblByKeyBLOutput blOutput  = new GetFileKanriTblByKeyBusinessLogic().Execute(blInput);

                if (blOutput.FileKanriTblDT != null && blOutput.FileKanriTblDT.Count > 0)
                {
                    output.ErrMessage = "ファイルの登録に失敗しました。\r\nシステム管理者に連絡してください。";

                    // delete file when have err
                    File.Delete(Path.Combine(input.FileServerDirectory, newDestFile));
                }
                else
                {
                    new UpdateFileKanriTblBusinessLogic().Execute(input);
                }

                CompleteTransaction();
            }
            catch
            {
                // ファイル登録失敗
                if (string.IsNullOrEmpty(output.ErrMessage))
                {
                    output.ErrMessage = "ファイルの登録に失敗しました。\r\nシステム管理者に連絡してください。";
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
