using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {
        
    public partial class TaniSochiMstDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.TaniSochiMstDataSetTableAdapters
{

    #region TaniSochiListTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： TaniSochiListTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/07/07  DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class TaniSochiListTableAdapter
    {
        #region GetDataByKatashikiMakerCdKatashikiCd
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataByKatashikiMakerCdKatashikiCd
        /// <summary>
        /// 
        /// </summary>
        /// <param name="katashikiMakerCd"></param>
        /// <param name="katashikiCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal TaniSochiMstDataSet.TaniSochiListDataTable GetDataByKatashikiMakerCdKatashikiCd(
            String katashikiMakerCd,
            String katashikiCd)
        {
            SqlCommand command = CreateSqlCommand(katashikiMakerCd, katashikiCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            TaniSochiMstDataSet.TaniSochiListDataTable dataTable = new TaniSochiMstDataSet.TaniSochiListDataTable();
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
        /// <param name="katashikiMakerCd"></param>
        /// <param name="katashikiCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/07/07　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            String katashikiMakerCd,
            String katashikiCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                       ");
            sqlContent.Append("     TaniSochiMst.TaniSochiCd,                                               ");
            sqlContent.Append("     TaniSochiMst.TaniSochiNm,                                               ");
            sqlContent.Append("     TaniSochiMst.TaniSochiShozokuGroupCd,                                   ");
            sqlContent.Append("     KatashikiBetsuTaniSochiMst.KatashikiMakerCd,                            ");
            sqlContent.Append("     KatashikiBetsuTaniSochiMst.KatashikiCd,                                 ");
            sqlContent.Append("     CASE                                                                    ");
            sqlContent.Append("         WHEN ISNULL(KATASHIKIBETSUTANISOCHIMST.KATASHIKIMAKERCD, '') = ''   ");
            sqlContent.Append("             AND ISNULL(KATASHIKIBETSUTANISOCHIMST.KATASHIKICD, '') = ''     ");
            sqlContent.Append("         THEN '0'                                                            ");
            sqlContent.Append("         ELSE '1'                                                            ");
            sqlContent.Append("     END AS Flg                                                              ");
            
            // FROM
            sqlContent.Append("FROM                                                                         ");
            sqlContent.Append("     TaniSochiMst                                                            ");
            sqlContent.Append("LEFT OUTER JOIN                                                              ");
            sqlContent.Append("     KatashikiBetsuTaniSochiMst                                              ");
            sqlContent.Append("    ON KatashikiBetsuTaniSochiMst.TaniSochiGroupCd = TaniSochiMst.TaniSochiShozokuGroupCd ");
            //sqlContent.Append("ON KatashikiBetsuTaniSochiMst.TaniSochiCd = TaniSochiMst.TaniSochiCd         ");

            // WHERE
            sqlContent.Append("WHERE                                                                        ");
            sqlContent.Append("     1 = 1                                                                   ");

            if (!String.IsNullOrEmpty(katashikiMakerCd) && !String.IsNullOrEmpty(katashikiCd))
            {
                sqlContent.Append("AND (KatashikiBetsuTaniSochiMst.KatashikiMakerCd = @katashikiMakerCd OR ISNULL(KatashikiBetsuTaniSochiMst.KatashikiMakerCd, '') = ''   ) ");
                sqlContent.Append("AND (KatashikiBetsuTaniSochiMst.KatashikiCd = @katashikiCd OR ISNULL(KatashikiBetsuTaniSochiMst.KatashikiCd, '') = ''                  ) ");

                commandParams.Add("@katashikiMakerCd", SqlDbType.NVarChar).Value = katashikiMakerCd;
                commandParams.Add("@katashikiCd", SqlDbType.NVarChar).Value = katashikiCd;
            }
            else
            {
                sqlContent.Append("AND ISNULL(KatashikiBetsuTaniSochiMst.KatashikiMakerCd, '') = '' ");
                sqlContent.Append("AND ISNULL(KatashikiBetsuTaniSochiMst.KatashikiCd, '') = ''      ");
            }

            // ORDER BY
            sqlContent.Append("ORDER BY ");
            sqlContent.Append("     TaniSochiMst.TaniSochiCd                                            ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion
}
