using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using FukjBizSystem.Application.BusinessLogic.GaikanKensa.KensaHoryuShosai;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;
using Excel = Microsoft.Office.Interop.Excel;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaHoryuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGenkyoHokokuMakeBtnClickALInput
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
    interface IGenkyoHokokuMakeBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 協会No
        /// </summary>
        string KyokaiNo { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        string KensaIraiRenban { get; set; }

        /// <summary>
        /// 担当検査員(7)
        /// </summary>
        string TantoKensain { get; set; }

        /// <summary>
        /// 起票者/所属支所(14)
        /// </summary>
        string ShozokuShisyo { get; set; }

        /// <summary>
        /// 起票者/所属部署(15)
        /// </summary>
        string ShozokuBusho { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GenkyoHokokuMakeBtnClickALInput
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
    class GenkyoHokokuMakeBtnClickALInput : IGenkyoHokokuMakeBtnClickALInput
    {
        /// <summary>
        /// 協会No
        /// </summary>
        public string KyokaiNo { get; set; }

        /// <summary>
        /// 検査依頼保健所コード
        /// </summary>
        public string KensaIraiHokenjoCd { get; set; }

        /// <summary>
        /// 検査依頼年度
        /// </summary>
        public string KensaIraiNendo { get; set; }

        /// <summary>
        /// 検査依頼連番
        /// </summary>
        public string KensaIraiRenban { get; set; }

        /// <summary>
        /// 担当検査員(7)
        /// </summary>
        public string TantoKensain { get; set; }

        /// <summary>
        /// 起票者/所属支所(14)
        /// </summary>
        public string ShozokuShisyo { get; set; }

        /// <summary>
        /// 起票者/所属部署(15)
        /// </summary>
        public string ShozokuBusho { get; set; }

        /// <summary>
        /// ログ出力用データ文字列取得
        /// </summary>
        public string DataString
        {
            get
            {
                return string.Format("協会No[{0}], 担当検査員[{1}], 起票者/所属支所[{2}], 起票者/所属部署[{3}]",
                    KyokaiNo, TantoKensain, ShozokuShisyo, ShozokuBusho);
            }
        }
    }
    #endregion

    #region 出力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGenkyoHokokuMakeBtnClickALOutput
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
    interface IGenkyoHokokuMakeBtnClickALOutput
    {
        /// <summary>
        /// Error message for check exist file and folder
        /// </summary>
        string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GenkyoHokokuMakeBtnClickALOutput
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
    class GenkyoHokokuMakeBtnClickALOutput : IGenkyoHokokuMakeBtnClickALOutput
    {
        /// <summary>
        /// Error message for check exist file and folder
        /// </summary>
        public string ErrMsg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GenkyoHokokuMakeBtnClickApplicationLogic
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
    class GenkyoHokokuMakeBtnClickApplicationLogic : BaseApplicationLogic<IGenkyoHokokuMakeBtnClickALInput, IGenkyoHokokuMakeBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaHoryuShosai：GenkyoHokokuMakeBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GenkyoHokokuMakeBtnClickApplicationLogic
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
        public GenkyoHokokuMakeBtnClickApplicationLogic()
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
        public override IGenkyoHokokuMakeBtnClickALOutput Execute(IGenkyoHokokuMakeBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGenkyoHokokuMakeBtnClickALOutput output = new GenkyoHokokuMakeBtnClickALOutput();

            // Using Microsoft Office to open file
            Excel.Application xlApp = new Excel.Application();

            try
            {
                // Split kyokaiNo to kensaIrai key
                string[] key = input.KyokaiNo.Split('-');

                //// Get server folder
                string serverFolder = Utility.SharedFolderUtility.GetKensaIraiKeyFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_010,
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002,
                    Utility.Constants.HoteiKbnConstant.HOTEI_KBN_7JO_GAIKAN,
                    key[0],
                    Boundary.Common.Common.ConvertToHoshouNendoSeireki(key[1]),
                    key[2]);

                // Get local folder
                string localFolder = Utility.SharedFolderUtility.GetConstLocalFolder(Utility.Constants.ConstKbnConstanst.CONST_KBN_010,
                    Utility.Constants.ConstRenbanConstanst.CONST_RENBAN_002);

                // No server or local?
                if (!Directory.Exists(serverFolder) || !Directory.Exists(localFolder))
                {
                    output.ErrMsg = "現況報告書の保存先フォルダが設定されていません。";
                    return output;
                }

                // KyokaiNo file name
                string fileName = string.Concat(input.KyokaiNo, "_現況報告書.xlsx");

                // Full file paths
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
                        IMake7JoKensaIraiShoHenkyoHokokuShoBLInput printInput = new Make7JoKensaIraiShoHenkyoHokokuShoBLInput();
                        printInput.SavePath = localFilePath;
                        printInput.FormatPath = Properties.Settings.Default.PrintFormatFolder + Properties.Settings.Default.KensaIraiShoHenkyoHokokuShoFormatFile;
                        //printInput.KyokaiNo = input.KyokaiNo;
                        printInput.KensaIraiHokenjoCd = input.KensaIraiHokenjoCd;
                        printInput.KensaIraiNendo = input.KensaIraiNendo;
                        printInput.KensaIraiRenban = input.KensaIraiRenban;
                        printInput.ShozokuShisyo = input.ShozokuShisyo;
                        printInput.ShozokuBusho = input.ShozokuBusho;
                        printInput.TantoKensain = input.TantoKensain;
                        IMake7JoKensaIraiShoHenkyoHokokuShoBLOutput printOutput = new Make7JoKensaIraiShoHenkyoHokokuShoBusinessLogic().Execute(printInput);

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
