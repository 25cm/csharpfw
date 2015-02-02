using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {
        
    public partial class FileKanriTblDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.FileKanriTblDataSetTableAdapters
{

    #region FileKanriTblKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： FileKanriTblKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/08/06  DatNT　  新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class FileKanriTblKensakuTableAdapter
    {
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="torokuDtUse"></param>
        /// <param name="torokuDtFrom"></param>
        /// <param name="torokuDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/04　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal FileKanriTblDataSet.FileKanriTblKensakuDataTable GetDataBySearchCond(
            string fileName,
            bool torokuDtUse,
            DateTime torokuDtFrom,
            DateTime torokuDtTo)
        {
            SqlCommand command = CreateSqlCommand(fileName,torokuDtUse, torokuDtFrom, torokuDtTo);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            FileKanriTblDataSet.FileKanriTblKensakuDataTable dataTable = new FileKanriTblDataSet.FileKanriTblKensakuDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  メソッド名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="torokuDtUse"></param>
        /// <param name="torokuDtFrom"></param>
        /// <param name="torokuDtTo"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/08/06  DatNT　  新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string fileName,
            bool torokuDtUse,
            DateTime torokuDtFrom,
            DateTime torokuDtTo)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                               ");
            sqlContent.Append("     FileKbn,                                                        ");
            sqlContent.Append("     FileNo,                                                         ");
            sqlContent.Append("     FileNmBefore,                                                   ");
            sqlContent.Append("     FileNm,                                                         ");
            sqlContent.Append("     FilePath,                                                       ");
            sqlContent.Append("     InsertDt,                                                       ");
            sqlContent.Append("     InsertUser,                                                     ");
            sqlContent.Append("     InsertTarm,                                                     ");
            sqlContent.Append("     UpdateDt,                                                       ");
            sqlContent.Append("     UpdateUser,                                                     ");
            sqlContent.Append("     UpdateTarm                                                      ");

            // FROM
            sqlContent.Append("FROM                                                                 ");
            sqlContent.Append("     FileKanriTbl                                                    ");

            // WHERE
            sqlContent.Append("WHERE                                                                ");
            sqlContent.Append("     1 = 1                                                           ");

            if (!string.IsNullOrEmpty(fileName))
            {
                sqlContent.Append("AND FileNmBefore LIKE CONCAT('%', @fileName, '%')                      ");
                commandParams.Add("@fileName", SqlDbType.NVarChar).Value = fileName;
            }

            if (torokuDtUse)
            {
                sqlContent.Append("AND InsertDt >= @torokuDtFrom AND InsertDt <= @torokuDtTo        ");
                commandParams.Add("@torokuDtFrom", SqlDbType.DateTime).Value = torokuDtFrom;
                commandParams.Add("@torokuDtTo", SqlDbType.DateTime).Value = torokuDtTo;
            }
            
            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     FileKbn, FileNo                                                 ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
