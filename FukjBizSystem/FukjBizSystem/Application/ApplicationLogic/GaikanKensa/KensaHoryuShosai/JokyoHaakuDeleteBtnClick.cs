﻿using System.IO;
using System.Reflection;
using FukjBizSystem.Application.BusinessLogic.Master.BushoMstList;
using Zynas.Framework.Core.Base.ApplicationLogic;
using Zynas.Framework.Utility;

namespace FukjBizSystem.Application.ApplicationLogic.GaikanKensa.KensaHoryuShosai
{
    #region 入力インターフェイス定義
    ////////////////////////////////////////////////////////////////////////////
    //  インターフェイス名 ： IJokyoHaakuDeleteBtnClickALInput
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
    interface IJokyoHaakuDeleteBtnClickALInput : IBseALInput
    {
        /// <summary>
        /// 協会No
        /// </summary>
        string KyokaiNo { get; set; }
    }
    #endregion

    #region 入力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokyoHaakuDeleteBtnClickALInput
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
    class JokyoHaakuDeleteBtnClickALInput : IJokyoHaakuDeleteBtnClickALInput
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
    //  インターフェイス名 ： IJokyoHaakuDeleteBtnClickALOutput
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
    interface IJokyoHaakuDeleteBtnClickALOutput
    {
        /// <summary>
        /// Error message for check exist file and folder
        /// </summary>
        string ErrMsg { get; set; }
    }
    #endregion

    #region 出力クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokyoHaakuDeleteBtnClickALOutput
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
    class JokyoHaakuDeleteBtnClickALOutput : IJokyoHaakuDeleteBtnClickALOutput
    {
        /// <summary>
        /// Error message for check exist file and folder
        /// </summary>
        public string ErrMsg { get; set; }
    }
    #endregion

    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： JokyoHaakuDeleteBtnClickApplicationLogic
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
    class JokyoHaakuDeleteBtnClickApplicationLogic : BaseApplicationLogic<IJokyoHaakuDeleteBtnClickALInput, IJokyoHaakuDeleteBtnClickALOutput>
    {
        #region プロパティ

        /// <summary>
        /// 機能名
        /// </summary>
        private const string FunctionName = "KensaHoryuShosai：JokyoHaakuDeleteBtnClick";

        #endregion

        #region コンストラクタ
        ////////////////////////////////////////////////////////////////////////////
        //  コンストラクタ名 ： JokyoHaakuDeleteBtnClickApplicationLogic
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
        public JokyoHaakuDeleteBtnClickApplicationLogic()
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
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        public override IJokyoHaakuDeleteBtnClickALOutput Execute(IJokyoHaakuDeleteBtnClickALInput input)
        {
            TraceLog.StartWrite(MethodInfo.GetCurrentMethod());

            // 出力クラスの実体作成
            IJokyoHaakuDeleteBtnClickALOutput output = new JokyoHaakuDeleteBtnClickALOutput();

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
                // Full file paths
                string shareFilePath = Path.Combine(serverFolder, fileName);
                string localFilePath = Path.Combine(localFolder, fileName);

                // Connect to server
                if (Utility.SharedFolderUtility.Connect())
                {
                    // File exist on server
                    if (File.Exists(shareFilePath))
                    {
                        try
                        {
                            // Delete file
                            File.Delete(shareFilePath);
                        }
                        catch
                        {
                            // An error occurred when deleting file on server
                            output.ErrMsg = "状況把握票の削除に失敗しました。\r\nシステム管理者へ連絡してください。";
                        }
                        finally
                        {
                            // Disconnect from server
                            Utility.SharedFolderUtility.Disconnect();
                        }
                    }
                    else // File does not exist on server
                    {
                        // Disconnect from server
                        Utility.SharedFolderUtility.Disconnect();
                        // Output message
                        output.ErrMsg = "対象の状況把握票が存在しません。";
                    }
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