using System.IO;
using System.Reflection;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaHoryuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IGenkyoHokokuSaveBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGenkyoHokokuSaveBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 協会No
        /// </summary>
        string KyokaiNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GenkyoHokokuSaveBtnClickALInput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GenkyoHokokuSaveBtnClickALInput : IGenkyoHokokuSaveBtnClickALInput
    {
        /// <summary>
        /// 協会No
        /// </summary>
        public string KyokaiNo { get; set; }

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
    //  インターフェイス名 ： IGenkyoHokokuSaveBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    interface IGenkyoHokokuSaveBtnClickALOutput
    {
        /// <summary>
        /// Error message
        /// </summary>
        string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GenkyoHokokuSaveBtnClickALOutput
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GenkyoHokokuSaveBtnClickALOutput : IGenkyoHokokuSaveBtnClickALOutput
    {
        /// <summary>
        /// Error message
        /// </summary>
        public string ErrMsg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： GenkyoHokokuSaveBtnClickApplicationLogic
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/11/07　AnhNV　　    新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class GenkyoHokokuSaveBtnClickApplicationLogic : BaseApplicationLogic<IGenkyoHokokuSaveBtnClickALInput, IGenkyoHokokuSaveBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaHoryuShosai：GenkyoHokokuSaveBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： GenkyoHokokuSaveBtnClickApplicationLogic
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>
        /// 
        /// </remarks>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/11/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public GenkyoHokokuSaveBtnClickApplicationLogic()
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
        /// 2014/11/07　AnhNV　　    新規作成
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
        /// 2014/11/07　AnhNV　　    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IGenkyoHokokuSaveBtnClickALOutput Execute(IGenkyoHokokuSaveBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IGenkyoHokokuSaveBtnClickALOutput output = new GenkyoHokokuSaveBtnClickALOutput();

            try
            {
                // Split kyokaiNo to kensaIrai key
                string[] key = input.KyokaiNo.Split('-');

                // Get server folder
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

                // Full server share file path
                string shareFilePath = Path.Combine(serverFolder, fileName);
                string localFilePath = Path.Combine(localFolder, fileName);

                // Connect to server
                if (Utility.SharedFolderUtility.Connect())
                {
                    // File exist in server?
                    if (File.Exists(localFilePath))
                    {
                        // Upload file to server
                        Utility.SharedFolderUtility.UploadFile(localFilePath, shareFilePath, true);
                    }
                    else
                    {
                        output.ErrMsg = "対象の現況報告書が存在しません。";
                    }

                    // Disconnect from server
                    Utility.SharedFolderUtility.Disconnect();
                }
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
