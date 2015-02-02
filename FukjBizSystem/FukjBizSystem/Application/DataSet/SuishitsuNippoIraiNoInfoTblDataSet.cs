using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace FukjBizSystem.Application.DataSet {    
    
    public partial class SuishitsuNippoIraiNoInfoTblDataSet {
    }
}

namespace FukjBizSystem.Application.DataSet.SuishitsuNippoIraiNoInfoTblDataSetTableAdapters
{
    
    #region SuisitsuKensaNippoKensakuTableAdapter
    ////////////////////////////////////////////////////////////////////////////
    //  クラス名 ： SuisitsuKensaNippoKensakuTableAdapter
    /// <summary>
    /// 
    /// </summary>
    /// <remarks>
    /// 
    /// </remarks>
    /// <history>
    /// 日付　　　　担当者　　　内容
    /// 2014/12/05　DatNT　　 新規作成
    /// </history>
    ////////////////////////////////////////////////////////////////////////////
    public partial class SuisitsuKensaNippoKensakuTableAdapter {
        
        #region GetDataBySearchCond
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： GetDataBySearchCond
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UketsukeDt"></param>
        /// <param name="ShishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　DatNT　　 新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        [DataObjectMethod(DataObjectMethodType.Select)]
        internal SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuDataTable GetDataBySearchCond(
            string UketsukeDt,
            string ShishoCd)
        {
            SqlCommand command = CreateSqlCommand(UketsukeDt, ShishoCd);

            SqlDataAdapter adpt = new SqlDataAdapter(command);
            adpt.SelectCommand.Connection = this.Connection;

            SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuDataTable dataTable = new SuishitsuNippoIraiNoInfoTblDataSet.SuisitsuKensaNippoKensakuDataTable();
            adpt.Fill(dataTable);

            return dataTable;
        }
        #endregion

        #region CreateSqlCommand
        ////////////////////////////////////////////////////////////////////////////
        //  インターフェイス名 ： CreateSqlCommand
        /// <summary>
        /// 
        /// </summary>
        /// <param name="UketsukeDt"></param>
        /// <param name="ShishoCd"></param>
        /// <history>
        /// 日付　　　　担当者　　　内容
        /// 2014/12/05　DatNT　　新規作成
        /// </history>
        ////////////////////////////////////////////////////////////////////////////
        private SqlCommand CreateSqlCommand(
            string UketsukeDt,
            string ShishoCd)
        {
            SqlCommand command = new SqlCommand();
            SqlParameterCollection commandParams = command.Parameters;

            StringBuilder sqlContent = new StringBuilder();

            // SELECT
            sqlContent.Append("SELECT                                                                                           ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl.KeiryoShomeiNoFrom,                                             ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl.KeiryoShomeiNoTo,                                               ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl.KeiryoShomeiCnt,                                                ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl.SuishitsuNoFrom,                                                ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl.SuishitsuNoTo,                                                  ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl.SuishitsuCnt,                                                   ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl.GaikanNoFrom,                                                   ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl.GaikanNoTo,                                                     ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl.GaikanCnt,                                                      ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.ShishoCd,                                                              ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.SuishitsuUketsukeDt,                                                   ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.SuishitsuGyoshaCd,                                                     ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.SuishitsuKensaKbn,                                                     ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.SuishitsuKensaShubetsuCd,                                              ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.SuishitsuKensaShubetsuNm,                                              ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.KaiinFlg,                                                              ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.GenkinFlg,                                                             ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.SuishitsuKensaAmt,                                                     ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.MochikomiCnt,                                                          ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.ShushuCnt,                                                             ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.GokeiAmt,                                                              ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.NyukinAmt,                                                             ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.CheckFlg,                                                              ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.UpdateDt,                                                              ");
            sqlContent.Append("     GyoshaMst.GyoshaNm                                                                          ");

            // FROM
            sqlContent.Append("FROM                                                                                             ");
            sqlContent.Append("     SuishitsuNippoIraiNoInfoTbl                                                                 ");
            sqlContent.Append("INNER JOIN                                                                                       ");
            sqlContent.Append("     SuishitsuNippoHdrTbl                                                                        ");
            sqlContent.Append("ON SuishitsuNippoHdrTbl.ShishoCd = SuishitsuNippoIraiNoInfoTbl.ShishoCd                          ");
            sqlContent.Append("AND SuishitsuNippoHdrTbl.SuishitsuUketsukeDt = SuishitsuNippoIraiNoInfoTbl.SuishitsuUketsukeDt   ");
            sqlContent.Append("LEFT JOIN                                                                                        ");
            sqlContent.Append("     GyoshaMst                                                                                   ");
            sqlContent.Append("ON GyoshaMst.GyoshaCd = SuishitsuNippoHdrTbl.SuishitsuGyoshaCd                                   ");

            // WHERE
            sqlContent.Append("WHERE                                                                                            ");
            sqlContent.Append("     1 = 1                                                                                       ");

            sqlContent.Append("AND SuishitsuNippoIraiNoInfoTbl.SuishitsuUketsukeDt = @UketsukeDt ");
            commandParams.Add("@UketsukeDt", SqlDbType.NVarChar).Value = UketsukeDt;

            if (!string.IsNullOrEmpty(ShishoCd))
            {
                sqlContent.Append("AND SuishitsuNippoIraiNoInfoTbl.ShishoCd = @ShishoCd ");
                commandParams.Add("@ShishoCd", SqlDbType.NVarChar).Value = ShishoCd;
            }

            // ORDER BY
            sqlContent.Append("ORDER BY                                                                                         ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.SuishitsuGyoshaCd,                                                     ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.SuishitsuKensaShubetsuCd,                                              ");
            sqlContent.Append("     SuishitsuNippoHdrTbl.SuishitsuKensaAmt                                                      ");

            command.CommandText = sqlContent.ToString();

            return command;
        }
        #endregion
    }
    #endregion

}
