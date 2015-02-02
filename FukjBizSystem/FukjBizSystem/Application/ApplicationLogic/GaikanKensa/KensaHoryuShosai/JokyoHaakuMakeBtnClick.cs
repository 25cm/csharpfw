using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaHoryuShosai;
using FukjBizSystem.Application.DataSet;
using FukjBizSystem.Application.DataSet.GaikanKensa;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaHoryuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IJokyoHaakuMakeBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IJokyoHaakuMakeBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 協会No
        /// </summary>
        string KyokaiNo { get; set; }

        /// <summary>
        /// KensaHoryuShosaiDataTable
        /// </summary>
        KensaHoryuDataSet.KensaHoryuShosaiDataTable KensaHoryuShosaiDataTable { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokyoHaakuMakeBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class JokyoHaakuMakeBtnClickALInput : IJokyoHaakuMakeBtnClickALInput
    {
        /// <summary>
        /// 協会No
        /// </summary>
        public string KyokaiNo { get; set; }

        /// <summary>
        /// KensaHoryuShosaiDataTable
        /// </summary>
        public KensaHoryuDataSet.KensaHoryuShosaiDataTable KensaHoryuShosaiDataTable { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("協会No[{0}]", KyokaiNo);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IJokyoHaakuMakeBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IJokyoHaakuMakeBtnClickALOutput
    {
        /// <summary>
        /// Error message for check exist file and folder
        /// </summary>
        string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokyoHaakuMakeBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class JokyoHaakuMakeBtnClickALOutput : IJokyoHaakuMakeBtnClickALOutput
    {
        /// <summary>
        /// Error message for check exist file and folder
        /// </summary>
        public string ErrMsg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokyoHaakuMakeBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/09/09　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class JokyoHaakuMakeBtnClickApplicationLogic : BaseApplicationLogic<IJokyoHaakuMakeBtnClickALInput, IJokyoHaakuMakeBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaHoryuShosai：JokyoHaakuMakeBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JokyoHaakuMakeBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/09/09　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public JokyoHaakuMakeBtnClickApplicationLogic()
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
        /// 2014/09/09　AnhNV　　    新規作成
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
        /// 2014/09/09　AnhNV　　    新規作成
        /// 2014/11/07　AnhNV　　    基本設計書_009_009_画面_KensaHoryuShosai_Ver1.03
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IJokyoHaakuMakeBtnClickALOutput Execute(IJokyoHaakuMakeBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IJokyoHaakuMakeBtnClickALOutput output = new JokyoHaakuMakeBtnClickALOutput();

            // Using Microsoft Office to open file
            Excel.Application xlApp = new Excel.Application();

            try
            {
                // Split kyokaiNo to kensaIrai key
                string[] key = input.KyokaiNo.Split('-');

                // Get server folder
                string serverFolder = Utility.SharedFolderUtility.GetKensaIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_010,
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001,
                    Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN,
                    key[0],
                    Boundary.Common.Common.ConvertToHoshouNendoSeireki(key[1]),
                    key[2]);

                // Get local folder
                string localFolder = Utility.SharedFolderUtility.GetConstLocalFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_010,
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_001);

                // No server or local?
                if (!Directory.Exists(serverFolder) || !Directory.Exists(localFolder))
                {
                    output.ErrMsg = "状況把握票の保存先フォルダが設定されていません。";
                    return output;
                }

                // KyokaiNo file name
                string fileName = string.Concat(input.KyokaiNo, "_状況把握票.xlsx");

                // Full server share file path
                string shareFilePath = Path.Combine(serverFolder, fileName);
                string localFilePath = Path.Combine(localFolder, fileName);

                // Connect to server
                if (Utility.SharedFolderUtility.Connect())
                {
                    // File exist in server?
                    if (File.Exists(shareFilePath))
                    {
                        // Download file to local
                        Utility.SharedFolderUtility.DownloadFile(localFilePath, shareFilePath);

                        // Open file
                        xlApp.Workbooks.Open(localFilePath);
                        xlApp.Visible = true;

                        // Disconnect from server
                        Utility.SharedFolderUtility.Disconnect();
                    }
                    else
                    {
                        // Disconnect from server
                        Utility.SharedFolderUtility.Disconnect();

                        // File exist in local?
                        if (File.Exists(localFilePath))
                        {
                            File.Delete(localFilePath);
                        }

                        // Create file, and then open
                        IMake7JoKensaSetchiJokyoHaakuHyoBLInput printInput = new Make7JoKensaSetchiJokyoHaakuHyoBLInput();
                        printInput.SavePath = localFilePath;
                        printInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KensaSetchiJokyoHaakuHyoFormatFile;
                        printInput.KyokaiNo = input.KyokaiNo;
                        printInput.KensaHoryuShosaiDataTable = input.KensaHoryuShosaiDataTable;
                        IMake7JoKensaSetchiJokyoHaakuHyoBLOutput printOutput = new Make7JoKensaSetchiJokyoHaakuHyoBusinessLogic().Execute(printInput);

                        // Open file
                        xlApp.Workbooks.Open(localFilePath);
                        xlApp.Visible = true;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                #region オブジェクトを解放
                if (xlApp != null) { Marshal.ReleaseComObject(xlApp); }
                #endregion

                TraceLog.EndWrite(MethodInfo.GetCurrentMethod());
            }

            return output;
        }
        #endregion

        #endregion
    }
    #endregion
}
