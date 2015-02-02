using System;
using System.Data;
using System.Data.SqlClient;
using log4net;

namespace UriageShukeiBatch
{
    #region クラス定義
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： Program
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/10/10　DatNT    新規作成
    /// 2015/01/23  DatNT   v1.07
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    class Program
    {
        #region private

        #region LOGGING

        /// <summary>
        /// ロガー名
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger("[BatchLogger - 006_014_売上集計]");

        /// <summary>
        /// Batch
        /// </summary>
        private const string BATCH = "BATCH";

        #endregion

        #region SETTING FILE
        // 2015/01/23 DatNT v1.07 DEL Start
        ///// <summary>
        ///// Settings file's name
        ///// </summary>
        //private const string SETTING_FILE = ".\\settings.ini";

        ///// <summary>
        ///// Section ini file DB
        ///// </summary>
        //private const string SECTION_DATABASE = "DB";

        ///// <summary>
        ///// Section ini file FILE
        ///// </summary>
        //private const string SECTION_FILE = "FILE";

        ///// <summary>
        ///// DataSource
        ///// </summary>
        //private const string DATASOURCE_KEY = "DataSource";

        ///// <summary>
        ///// Database
        ///// </summary>
        //private const string DATABASE_KEY = "Database";

        ///// <summary>
        ///// User ID
        ///// </summary>
        //private const string USER_ID_KEY = "UserID";

        ///// <summary>
        ///// Password
        ///// </summary>
        //private const string PASSWORD = "Password";
        // 2015/01/23 DatNT v1.07 DEL End
        #endregion

        #region MESSAGE

        // 2015/01/23 DatNT v1.07 DEL Start
        ///// <summary>
        ///// 設定ファイルが取得できなかった場合
        ///// </summary>
        //private const string ERR_SETTING_FILE = "設定ファイルが取得できません";

        ///// <summary>
        ///// データベース接続エラーの場合
        ///// </summary>
        //private const string ERR_CONNECT_DB = "データベースに接続できません";
        // 2015/01/23 DatNT v1.07 DEL End

        /// <summary>
        /// 処理開始
        /// </summary>
        private const string START_PROCESSING = "処理開始";

        /// <summary>
        /// 処理終了
        /// </summary>
        private const string END_PROCESSING = "処理終了";

        /// <summary>
        /// 削除処理で失敗した場合
        /// </summary>
        private const string ERR_STEP_2 = "売上テーブル削除処理に失敗しました";

        /// <summary>
        /// 検査依頼集計で失敗した場合
        /// </summary>
        private const string ERR_STEP_3 = "検査依頼テーブル集計処理に失敗しました";

        /// <summary>
        /// 検査依頼集計で失敗した場合
        /// </summary>
        private const string ERR_STEP_4 = "検査依頼テーブル集計処理に失敗しました";

        /// <summary>
        /// 検査依頼集計で失敗した場合
        /// </summary>
        private const string ERR_STEP_5 = "検査依頼テーブル集計処理に失敗しました";

        /// <summary>
        /// 計量証明集計で失敗した場合
        /// </summary>
        private const string ERR_STEP_6 = "計量証明テーブル集計処理に失敗しました";

        /// <summary>
        /// 保証登録集計で失敗した場合
        /// </summary>
        private const string ERR_STEP_7 = "保証登録テーブル集計処理に失敗しました";

        /// <summary>
        /// 用紙販売集計で失敗した場合
        /// </summary>
        private const string ERR_STEP_8 = "用紙販売テーブル集計処理に失敗しました";

        /// <summary>
        /// 年会費集計で失敗した場合
        /// </summary>
        private const string ERR_STEP_9 = "年会費テーブル集計処理に失敗しました";

        /// <summary>
        /// 前受金集計で失敗した場合
        /// </summary>
        private const string ERR_STEP_10 = "前受金テーブル集計処理に失敗しました";

        #endregion

        #endregion

        #region Main
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： Main
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/10/10  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        static void Main(string[] args)
        {
            try
            {
                // Start LOG
                log.Debug(START_PROCESSING);

                string loginUser = BATCH;

                string machine = BATCH;

                #region DEL
                // 2015/01/23 DatNT v1.07 DEL Start
                //// 設定ファイル取得
                //string dataSource = string.Empty;
                //string databaseName = string.Empty;
                //string userId = string.Empty;
                //string password = string.Empty;

                //if (!File.Exists(SETTING_FILE))
                //{   
                //    Console.WriteLine(ERR_SETTING_FILE);
                //    return;
                //}
                //else
                //{
                //    dataSource = ReadINISetting(SETTING_FILE, SECTION_DATABASE, DATASOURCE_KEY);

                //    databaseName = ReadINISetting(SETTING_FILE, SECTION_DATABASE, DATABASE_KEY);

                //    userId = ReadINISetting(SETTING_FILE, SECTION_DATABASE, USER_ID_KEY);

                //    password = ReadINISetting(SETTING_FILE, SECTION_DATABASE, PASSWORD);

                //    if (string.IsNullOrEmpty(dataSource) || string.IsNullOrEmpty(databaseName) || string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(password))
                //    {
                //        Console.WriteLine(ERR_SETTING_FILE);
                //        return;
                //    }
                //}
                // 2015/01/23 DatNT v1.07 DEL End
                #endregion

                // データベース接続
                string connetionString = null;

                SqlConnection conn = null;

                SqlDataReader reader = null;

                // 2015/01/23 DatNT v1.07 MOD Start
                connetionString = Properties.Settings.Default.FukjBizSystemConnectionString;
                //connetionString = "Data Source=" + dataSource + ";Initial Catalog=" + databaseName + ";User ID=" + userId + ";Password=" + password + "";
                // 2015/01/23 DatNT v1.07 MOD End
                
                conn = new SqlConnection(connetionString);
                
                try
                {
                    conn.Open();

                    // Current DateTime
                    DateTime now = GetCurrentTime(conn);
                    DateTime uriageDtFrom = now.AddDays(-1);
                    DateTime uriageDtTo = now;

                    SqlCommand sqlCommand = conn.CreateCommand();

                    sqlCommand.CommandText = "EXEC UriageSyukeiStd @uriageDtFrom, @uriageDtTo , @loginUser,  @machine";

                    sqlCommand.Parameters.Add("@uriageDtFrom", SqlDbType.DateTime).Value = uriageDtFrom;
                    sqlCommand.Parameters.Add("@uriageDtTo", SqlDbType.DateTime).Value = uriageDtTo;
                    sqlCommand.Parameters.Add("@loginUser", SqlDbType.NVarChar).Value = loginUser;
                    sqlCommand.Parameters.Add("@machine", SqlDbType.NVarChar).Value = machine;

                    sqlCommand.ExecuteNonQuery();

                    reader = sqlCommand.ExecuteReader();

                    while (reader.Read())
                    {
                        string result = reader["ErrorFlg"].ToString();

                        if (result == "0")
                        {
                            // success
                        }
                        else
                        {
                            string[] errFlg = result.Split(',');

                            foreach (string errCd in errFlg)
                            {
                                if (!string.IsNullOrEmpty(errCd))
                                {
                                    switch (errCd)
                                    {
                                        case "2":
                                            Console.WriteLine(ERR_STEP_2);
                                            log.Debug(ERR_STEP_2);
                                            break;

                                        case "3":
                                            Console.WriteLine(ERR_STEP_3);
                                            log.Debug(ERR_STEP_3);
                                            break;

                                        case "4":
                                            Console.WriteLine(ERR_STEP_4);
                                            log.Debug(ERR_STEP_4);
                                            break;

                                        case "5":
                                            Console.WriteLine(ERR_STEP_5);
                                            log.Debug(ERR_STEP_5);
                                            break;

                                        case "6":
                                            Console.WriteLine(ERR_STEP_6);
                                            log.Debug(ERR_STEP_6);
                                            break;

                                        case "7":
                                            Console.WriteLine(ERR_STEP_7);
                                            log.Debug(ERR_STEP_7);
                                            break;

                                        case "8":
                                            Console.WriteLine(ERR_STEP_8);
                                            log.Debug(ERR_STEP_8);
                                            break;

                                        case "9":
                                            Console.WriteLine(ERR_STEP_9);
                                            log.Debug(ERR_STEP_9);
                                            break;

                                        case "10":
                                            Console.WriteLine(ERR_STEP_10);
                                            log.Debug(ERR_STEP_10);
                                            break;

                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    //// データベース接続エラーの場合
                    //Console.WriteLine(ERR_CONNECT_DB);
                    //return;
                    throw;
                }
                finally
                {
                    if (conn != null)
                    {
                        conn.Close();
                    }
                    if (reader != null)
                    {
                        reader.Close();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                // End LOG
                log.Debug(END_PROCESSING);
            }
        }
        #endregion

        #region GetCurrentTime
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： GetCurrentTime
        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/08  DatNT    新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        static DateTime GetCurrentTime(SqlConnection conn)
        {
            DateTime now = DateTime.Now;

            SqlCommand command = new SqlCommand("SELECT CURRENT_TIMESTAMP AS DateTimeNow", conn);

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                now = (DateTime)(reader["DateTimeNow"]);
            }

            if (reader != null)
            {
                reader.Close();
            }

            return now;
        }
        #endregion

        #region ReadINISetting
        // 2015/01/23 DatNT v1.07 DEL Start
        //////////////////////////////////////////////////////////////////////////////
        ////  メソッド名 ： ReadINISetting
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="iniFilePath"></param>
        ///// <param name="section"></param>
        ///// <param name="key"></param>
        ///// <history>
        ///// 日付　　　　担当者　　　内容
        ///// 2014/10/10  DatNT    新規作成
        ///// </history>
        //////////////////////////////////////////////////////////////////////////////
        //static string ReadINISetting(string iniFilePath, string section, string key)
        //{
        //    var retVal = new StringBuilder(255);

        //    GetPrivateProfileString(section, key, "", retVal, 255, iniFilePath);

        //    return retVal.ToString();
        //}
        // 2015/01/23 DatNT v1.07 DEL End
        #endregion

        //[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
        //internal static extern uint GetPrivateProfileString(string lpAppName,
        //                                                    string lpKeyName,
        //                                                    string lpDefault,
        //                                                    StringBuilder lpReturnedString,
        //                                                    uint nSize,
        //                                                    string lpFileName);

    }
    #endregion
}
